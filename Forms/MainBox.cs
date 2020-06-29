using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Taskbar.Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SQLIndexManager.Properties;

namespace SQLIndexManager {

  public partial class MainBox : RibbonForm {

    public MainBox() {
      InitializeComponent();

      Output.Current.SetOutputControl(labelInfo);
      Output.Current.Add($"Log folder: {Environment.CurrentDirectory}");

      view.CustomColumnDisplayText += GridMethod.GridColumnDisplayText;
      view.RowCellStyle += GridMethod.GridRowCellStyle;
      view.DoubleClick += GridMethod.GridDoubleClick;

      popupIndexOperation.DataSource = Enum.GetValues(typeof(IndexOp)).Cast<IndexOp>().ToList();

      RestoreLayout();
    }
    
    #region Save/Restore Layout

    private void MainBox_FormClosing(object sender, FormClosingEventArgs e) {
      SaveLayout();
    }

    readonly Stream _defaultLayout = new MemoryStream();

    private void RestoreLayout() {
      try {
        view.SaveLayoutToStream(_defaultLayout);
        _defaultLayout.Seek(0, SeekOrigin.Begin);
      }
      catch { }

      if (File.Exists(AppInfo.LayoutFileName)) {
        try {
          string layout = AES.Decrypt(File.ReadAllText(AppInfo.LayoutFileName));

          using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(layout))) {
            view.RestoreLayoutFromStream(stream);
          }
          Output.Current.Add($"Grid layout restored: {AppInfo.LayoutFileName}");
        }
        catch {
          Output.Current.Add("Failed to restore layout");
        }
      }
    }

    private void SaveLayout() {
      HideSystemColumns();

      try {
        using (StreamWriter file = new StreamWriter(new FileStream(AppInfo.LayoutFileName, FileMode.Create))) {
          Stream str = new MemoryStream();
          view.SaveLayoutToStream(str);
          str.Seek(0, SeekOrigin.Begin);
          StreamReader reader = new StreamReader(str);
          string layout = reader.ReadToEnd();

          file.Write(AES.Encrypt(layout));
          file.Close();
          Output.Current.Add($"Grid layout saved: {AppInfo.LayoutFileName}");
        }
      }
      catch {
        Output.Current.Add("Failed to save layout");
      }
    }

    #endregion

    #region Scan Indexes

    private readonly List<Index> _indexes = new List<Index>();
    private BackgroundWorker _workerScan;

    private void ScanIndexes(object sender, DoWorkEventArgs e) {
      using (ConnectionList connectionList = new ConnectionList(Settings.ActiveHost)) {
        foreach (var database in Settings.ActiveHost.Databases) {
          List<Index> idx = new List<Index>();

          if (_workerScan.CancellationPending) {
            e.Cancel = true;
            return;
          }

          SqlConnection connection = connectionList.Get(database);
          if (connection == null) continue;

          Output.Current.Add($"Describe: {database}");
          Stopwatch opw = Stopwatch.StartNew();

          short retries = 0;
          while (true) {
            try {
              idx = QueryEngine.GetIndexes(connection);
              break;
            }
            catch (SqlException ex) {
              _ps.Errors++;

              if (ex.Message.Contains("kill")) {
                Output.Current.Add($"Cancel: {ex.Source}", ex.Message);
                return;
              }

              if (!ex.Message.Contains("timeout")) {
                Output.Current.Add($"Error: {ex.Source}", ex.Message);
                XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
              }

              Output.Current.Add($"Pre-describe #{retries} failed: {database}. Rescan...", ex.Message);
              retries++;

              if (retries > 2)
                break;
            }
          }

          opw.Stop();
          Output.Current.Add($"Pre-describe: {(idx.Count(_ => _.Fragmentation != null))}. " +
                             $"Post-describe: {(idx.Count(_ => _.Fragmentation == null))}", null, opw.ElapsedMilliseconds);

          List<int> clid = new List<int>();
          _ps.IndexesTotal = idx.Count;
          _ps.Indexes = idx.Count(_ => _.Fragmentation != null);
          _ps.IndexesSize = idx.Where(_ => _.Fragmentation != null).Sum(_ => _.PagesCount);
          _ps.SavedSpace = idx.Where(_ => _.Fragmentation != null).Sum(_ => _.UnusedPagesCount);

          foreach (Index index in idx.Where(_ => _.Fragmentation == null)
                                     .OrderBy(_ => _.ObjectId)
                                     .ThenBy(_ => _.IndexId)
                                     .ThenBy(_ => _.PartitionNumber)) {
            try {
              if (_workerScan.CancellationPending) {
                _indexes.AddRange(idx);
                e.Cancel = true;
                return;
              }

              connection = connectionList.Get(database);
              if (connection == null) break;

              _ps.Indexes++;

              if (index.IndexType == IndexType.CLUSTERED_COLUMNSTORE || index.IndexType == IndexType.NONCLUSTERED_COLUMNSTORE) {
                if (!clid.Exists(_ => _ == index.ObjectId)) {
                  Output.Current.AddCaption(index.ToString());
                  opw = Stopwatch.StartNew();

                  QueryEngine.GetColumnstoreFragmentation(connection, index, idx);
                  clid.Add(index.ObjectId);

                  opw.Stop();
                  Output.Current.Add(index.ToString(), null, opw.ElapsedMilliseconds);
                }
              }
              else {
                Output.Current.AddCaption(index.ToString());
                opw = Stopwatch.StartNew();

                QueryEngine.GetIndexFragmentation(connection, index);

                opw.Stop();
                Output.Current.Add(index.ToString(), null, opw.ElapsedMilliseconds);
              }
            }
            catch (Exception ex) {
              _ps.Errors++;
              Output.Current.Add($"Failed: {index}", ex.Message);
            }

            _ps.Indexes = idx.Count(_ => _.Fragmentation != null);
            _ps.IndexesSize = idx.Where(_ => _.Fragmentation != null).Sum(_ => _.PagesCount);
            _ps.SavedSpace = idx.Where(_ => _.Fragmentation != null).Sum(_ => _.UnusedPagesCount);

            _workerScan.ReportProgress(0);
          }

          _indexes.AddRange(idx);
        }
      }
    }

    private void ScanIndexesFinish(object sender, RunWorkerCompletedEventArgs e) {
      taskbar.ProgressMode = TaskbarButtonProgressMode.NoProgress;

      buttonOptions.Enabled =
        buttonDatabases.Enabled =
          buttonRefreshIndex.Enabled =
            buttonNewConnection.Enabled = true;

      buttonStopScan.Visibility = BarItemVisibility.Never;

      List<Index> indexes = _indexes.Where(_ => _.Fragmentation >= (Settings.Options.SkipOperation == IndexOp.IGNORE ? Settings.Options.FirstThreshold : 0) 
                                             && _.PagesCount >= Settings.Options.MinIndexSize.PageSize()
                                             && _.PagesCount <= Settings.Options.MaxIndexSize.PageSize())
                                        .OrderBy(_ => _.Fragmentation < Settings.Options.FirstThreshold
                                                            && Settings.Options.SkipOperation != Settings.Options.FirstOperation
                                                      ? 3
                                                      :  _.Fragmentation < Settings.Options.SecondThreshold 
                                                        && Settings.Options.FirstOperation != Settings.Options.SecondOperation 
                                                            ? 2 : 1 )
                                        .ThenByDescending(_ => (_.Fragmentation + 0.1) * _.PagesCount).ToList();

      QueryEngine.UpdateFixType(indexes);
      QueryEngine.FindDublicateIndexes(indexes);
      QueryEngine.FindUnusedIndexes(indexes);

      _ps.Indexes = _ps.IndexesTotal = indexes.Count;
      _ps.IndexesSize = indexes.Sum(_ => _.PagesCount);
      _ps.SavedSpace = indexes.Sum(_ => _.UnusedPagesCount);
      UpdateProgressStats();
      
      Output.Current.Add($"Processed: {_indexes.Count}. Fragmented: {_ps.Indexes}{(_ps.Indexes == 0 ? ". No indexes found. Try searching again or change settings..." : string.Empty)}");

      grid.DataSource = indexes;
    }

    private void RefreshIndexes() {
      if (_workerFix != null && _workerFix.IsBusy) return;

      grid.DataSource = null;

      RestoreSortRules();

      view.OptionsBehavior.Editable = true;
      view.OptionsSelection.MultiSelect = true;

      HideSystemColumns();

      buttonFix.Enabled =
        buttonOptions.Enabled =
            buttonDatabases.Enabled =
              buttonRefreshIndex.Enabled =
                buttonNewConnection.Enabled = false;

      buttonStopScan.Visibility = BarItemVisibility.Always;
      taskbar.ProgressMode = TaskbarButtonProgressMode.Indeterminate;

      _indexes.Clear();
      _ps = new ProgressStatus { Databases = Settings.ActiveHost.Databases.Count };
      UpdateProgressStats();

      _workerScan = new ThreadWorker() { WorkerSupportsCancellation = true, WorkerReportsProgress = true };
      _workerScan.DoWork += ScanIndexes;
      _workerScan.RunWorkerCompleted += ScanIndexesFinish;
      _workerScan.ProgressChanged += ScanIndexesProgressChanged;
      _workerScan.RunWorkerAsync();
    }

    private ProgressStatus _ps;

    private void ScanIndexesProgressChanged(object sender, ProgressChangedEventArgs e) {
      UpdateProgressStats();
    }

    private void UpdateProgressStats() {
      labelErrors.Visibility = _ps.Errors > 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
      labelErrors.Caption = _ps.Errors.ToString();

      labelDatabases.Visibility = _ps.Databases > 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
      labelDatabases.Caption = _ps.Databases.ToString();

      labelIndexes.Visibility = _ps.Indexes > 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
      labelIndexes.Caption = _ps.Indexes != _ps.IndexesTotal ? $"{_ps.Indexes} / {_ps.IndexesTotal}" : _ps.Indexes.ToString();

      labelIndexesSize.Visibility = _ps.IndexesSize > 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
      labelIndexesSize.Caption = Convert.ToDecimal(_ps.IndexesSize * 8).FormatSize();

      labelSavedSpace.Visibility = _ps.SavedSpace != 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
      labelSavedSpace.Caption = Convert.ToDecimal(_ps.SavedSpace * 8).FormatSize();

      labelElapsedTime.Visibility = _ps.Duration.ElapsedMilliseconds > 0 ? BarItemVisibility.Always : BarItemVisibility.Never;
      DateTime duration = (new DateTime(0)).AddMilliseconds(_ps.Duration.ElapsedMilliseconds);
      labelElapsedTime.Caption = duration.ToString("HH:mm:ss:fff");
    }

    #endregion

    #region Fix Indexes

    private void buttonFix_ItemClick(object sender, ItemClickEventArgs e) {
      if (_workerFix != null && _workerFix.IsBusy) return;

      buttonFix.Enabled =
        buttonDatabases.Enabled =
          buttonRefreshIndex.Enabled =
            buttonNewConnection.Enabled =
              buttonOptions.Enabled = false;

      buttonStopFix.Visibility = BarItemVisibility.Always;

      List<Index> selIndex = ((List<Index>)view.DataSource).Where(_ => _.IsSelected && _.FixType != IndexOp.SKIP).ToList();

      List<Index> fixIndex =
          selIndex.Where(x => Settings.ActiveHost.Databases.Any(y => y == x.DatabaseName))
                  .OrderBy(_ => _.Fragmentation < Settings.Options.FirstThreshold
                                && Settings.Options.SkipOperation != Settings.Options.FirstOperation
                    ? 3
                    :  _.Fragmentation < Settings.Options.SecondThreshold
                       && Settings.Options.FirstOperation != Settings.Options.SecondOperation
                      ? 2 : 1 )
                  .ThenByDescending(_ => (_.Fragmentation + 0.1) * _.PagesCount).ToList();

      _ps = new ProgressStatus
                  {
                    Databases = fixIndex.Select(_ => _.DatabaseName).Distinct().Count(),
                    IndexesTotal = fixIndex.Count
                  };
      UpdateProgressStats();

      foreach (Index row in fixIndex) {
        row.Progress = Resources.IconElapsedTime;
      }

      SaveSortRules();

      view.ClearColumnsFilter();
      view.ClearSelection();

      view.Columns[Resources.Duration].Visible = true;
      view.Columns[Resources.Duration].VisibleIndex = 0;

      view.Columns[Resources.Progress].Visible = true;
      view.Columns[Resources.Progress].VisibleIndex = 0;

      view.Columns[Resources.PagesCountBefore].Visible = true;
      view.Columns[Resources.PagesCountBefore].VisibleIndex = view.Columns[Resources.PagesCount].VisibleIndex + 1;

      grid.DataSource = fixIndex;

      view.OptionsBehavior.Editable = false;
      view.OptionsSelection.MultiSelect = false;

      Output.Current.Add("Start processing");

      taskbar.ProgressMaximumValue = fixIndex.Count;
      taskbar.ProgressMode = TaskbarButtonProgressMode.Normal;

      _workerFix = new BackgroundWorker { WorkerSupportsCancellation = true, WorkerReportsProgress = true };
      _workerFix.DoWork += FixIndexes;
      _workerFix.RunWorkerCompleted += FixIndexesFinish;
      _workerFix.ProgressChanged += FixIndexesProgressChanged;
      _workerFix.RunWorkerAsync(fixIndex);
    }

    private void FixIndexesProgressChanged(object sender, ProgressChangedEventArgs e) {
      taskbar.ProgressCurrentValue = e.ProgressPercentage + 1;
      UpdateProgressStats();

      if (e.UserState != null) {
        Index index = (Index)e.UserState;
        var rowHandle = view.FindRow(index);
        if (rowHandle != GridControl.InvalidRowHandle) {
          view.RefreshRow(rowHandle);
          view.SelectRow(rowHandle);
          view.MakeRowVisible(rowHandle);
        }
      }

      view.RefreshData();
    }

    private BackgroundWorker _workerFix;

    private void FixIndexes(object sender, DoWorkEventArgs e) {

      List<Index> indexes = (List<Index>)e.Argument;

      using (var connectionList = new ConnectionList(Settings.ActiveHost)) {

        for (int i = 0; i < indexes.Count; i++) {
          Index index = indexes[i];
          if (_workerFix.CancellationPending) {
            Output.Current.Add("Canceled");
            e.Cancel = true;
            return;
          }

          index.Progress = Resources.IconRun;
          _ps.Indexes++;
          _ps.IndexesSize += index.PagesCount;
          _workerFix.ReportProgress(i, index);

          Output.Current.AddCaption(index.ToString());
          Stopwatch watch = Stopwatch.StartNew();

          string sql = string.Empty;
          SqlConnection connection = connectionList.Get(index.DatabaseName);
          if (connection != null) {
            sql = QueryEngine.FixIndex(connection, index);
          }
          watch.Stop();
          Output.Current.Add(index.ToString(), sql, index.Duration);

          index.Progress = Resources.IconOk;
          index.Duration = watch.ElapsedMilliseconds;
          _ps.SavedSpace += (index.PagesCountBefore ?? 0);

          if (!string.IsNullOrEmpty(index.Error)) {
            Output.Current.Add(index.ToString(), index.Error);
            index.Progress = Resources.IconError;
            _ps.Errors++;
          }
          else {
            if (Settings.Options.DelayAfterFix > 0 && i < indexes.Count - 1) {
              _workerFix.ReportProgress(i, index);
              index.Progress = Resources.IconDelay;
              Thread.Sleep(Settings.Options.DelayAfterFix);
              index.Progress = Resources.IconOk;
            }
          }

          _workerFix.ReportProgress(i, index);
        }
      }
    }

    private void FixIndexesFinish(object sender, RunWorkerCompletedEventArgs e) {
      taskbar.ProgressMaximumValue = 0;
      taskbar.ProgressCurrentValue = 0;
      taskbar.ProgressMode = TaskbarButtonProgressMode.NoProgress;

      buttonDatabases.Enabled =
        buttonRefreshIndex.Enabled =
          buttonNewConnection.Enabled =
            buttonOptions.Enabled = true;

      buttonFix.Enabled = false;

      buttonStopFix.Visibility = BarItemVisibility.Never;

      UpdateProgressStats();
      Output.Current.Add("Done!");
    }

    #endregion

    #region Dialogs

    private void MainBox_Shown(object sender, EventArgs e) {
      ShowConnectionBox();
    }

    private void ShowDatabaseBox(bool isConnectionChanged) {
      using (DatabaseBox form = new DatabaseBox()) {
        if (form.ShowDialog(this) == DialogResult.OK) {
          List<string> dbs = form.GetDatabases();
          bool isDatabaseSelectionEqual = Settings.ActiveHost.Databases.OrderBy(t => t).SequenceEqual(dbs.OrderBy(t => t));

          Settings.ActiveHost.Databases = dbs;

          if (Settings.Options.ShowSettingsWhenConnectionChanged && (!isDatabaseSelectionEqual || isConnectionChanged)) {
            ShowSettingsBox();
          }

          RefreshIndexes();
        }
        else {
          labelDatabases.Caption = Settings.ActiveHost.Databases.Count.ToString();
          labelDatabases.Visibility = BarItemVisibility.Always;
        }
      }
    }

    private void ShowConnectionBox() {
      using (ConnectionBox form = new ConnectionBox()) {
        if (form.ShowDialog(this) == DialogResult.OK) {
          Host host = form.GetHost();
          Host lastHost = Settings.Hosts[0];

          bool isConnectionChanged = !string.Equals(host.Server, (Settings.ActiveHost ?? new Host()).Server, StringComparison.CurrentCultureIgnoreCase)
                                  && !string.Equals(host.Server, (lastHost ?? new Host()).Server, StringComparison.CurrentCultureIgnoreCase);

          Settings.ActiveHost = host;
          Text = host.Server.ToUpper();

          buttonDatabases.Enabled = true;
          buttonRefreshIndex.Enabled = host.Databases.Count > 0;

          labelServerInfo.Visibility = BarItemVisibility.Always;
          labelServerInfo.Caption = host.ServerInfo.ToString();

          Output.Current.Add($"Host: {host.Server}");
          Output.Current.Add($"Server: {host.ServerInfo}");

          if (isConnectionChanged) {
            grid.DataSource = null;
            _ps = new ProgressStatus { Databases = host.Databases.Count };
            UpdateProgressStats();
          }

          ShowDatabaseBox(isConnectionChanged);
        }
      }
    }

    private void ShowSettingsBox() {
      using (SettingsBox form = new SettingsBox()) {
        if (form.ShowDialog(this) == DialogResult.OK) {
          Settings.Options = form.GetSettings();
        }
      }
    }

    #endregion

    #region Grid Methods

    private string GetFixChanges() {
      List<Index> fix = ((List<Index>)view.DataSource).Where(_ => _.IsSelected).ToList();
      StringBuilder sb = new StringBuilder();

      var groupList = fix.GroupBy(u => u.DatabaseName).Select(grp => grp.ToList()).ToList();
      foreach (var group in groupList) {
        sb.AppendLine($"USE {group[0].DatabaseName.ToQuota()}{Environment.NewLine}GO{Environment.NewLine}");

        foreach (Index i in group.OrderBy(_ => _.SchemaName)
                                 .ThenBy(_ => _.ObjectName)
                                 .ThenBy(_ => _.IndexName)
                                 .ThenBy(_ => _.PartitionNumber)) {
          sb.AppendLine($"RAISERROR(N'{i}', 0, 1) WITH NOWAIT{Environment.NewLine}{i.GetQuery()}{Environment.NewLine}GO{Environment.NewLine}");
        }
      }

      return sb.ToString();
    }

    private void FixedOpPopupValueChanged(object sender, EventArgs e) {
      Index row = (Index)view.GetFocusedRow();
      if (row == null) return;

      int rowIndex = view.FindRow(row);

      view.PostEditor();
      view.SelectRow(rowIndex);
      view.UpdateCurrentRow();
    }

    private void FixedOpPopup(object sender, EventArgs e) {
      LookUpEdit obj = (LookUpEdit)sender;
      obj.Properties.DataSource = null;

      Index row = (Index)view.GetFocusedRow();
      if (row == null) return;

      List<IndexOp> ops = GetIndexOperations(row);
      obj.Properties.DropDownRows = ops.Count;
      obj.Properties.DataSource = ops.Select(_ => new { Fix = _, Name = _.Description() });
    }

    private List<IndexOp> GetIndexOperations(Index ix) {
      List<IndexOp> i = new List<IndexOp>();

      if (ix.IndexType == IndexType.MISSING_INDEX) {
        i.Add(IndexOp.CREATE_INDEX);
      }
      else if (ix.IsColumnstore) {
        i.Add(IndexOp.REBUILD);

        i.Add(ix.DataCompression == DataCompression.COLUMNSTORE_ARCHIVE
          ? IndexOp.REBUILD_COLUMNSTORE
          : IndexOp.REBUILD_COLUMNSTORE_ARCHIVE);

        i.Add(IndexOp.REORGANIZE);

        if (Settings.ServerInfo.MajorVersion >= ServerVersion.Sql2016)
          i.Add(IndexOp.REORGANIZE_COMPRESS_ALL_ROW_GROUPS);
      }
      else {
        i.Add(IndexOp.REBUILD);

        if (ix.IsAllowCompression) {
          if (ix.DataCompression == DataCompression.NONE) {
            i.Add(IndexOp.REBUILD_ROW);
            i.Add(IndexOp.REBUILD_PAGE);
          }
          else {
            i.Add(IndexOp.REBUILD_NONE);
            i.Add(ix.DataCompression == DataCompression.PAGE
              ? IndexOp.REBUILD_ROW
              : IndexOp.REBUILD_PAGE);
          }

          if (!ix.IsPartitioned && ix.IndexType == IndexType.HEAP && Settings.ServerInfo.MajorVersion >= ServerVersion.Sql2016) {
            i.Add(IndexOp.CREATE_COLUMNSTORE_INDEX);
          }
        }

        if (ix.IsAllowOnlineRebuild)
          i.Add(IndexOp.REBUILD_ONLINE);

        if (ix.IsAllowReorganize)
          i.Add(IndexOp.REORGANIZE);

        if (!ix.IsPartitioned) {
          if (ix.IndexType == IndexType.CLUSTERED || ix.IndexType == IndexType.NONCLUSTERED) {
            i.Add(IndexOp.UPDATE_STATISTICS_FULL);
            i.Add(IndexOp.UPDATE_STATISTICS_RESAMPLE);
            i.Add(IndexOp.UPDATE_STATISTICS_SAMPLE);
          }

          if (ix.IndexType == IndexType.NONCLUSTERED) {
            i.Add(IndexOp.DISABLE_INDEX);
            i.Add(IndexOp.DROP_INDEX);
          }

          if (ix.IndexType == IndexType.HEAP) {
            i.Add(IndexOp.DROP_TABLE);
          }
        }
      }

      i.Add(IndexOp.SKIP);

      return i;
    }

    private void GridSelectionChanged(object sender, SelectionChangedEventArgs e) {
      if (_workerFix != null && _workerFix.IsBusy) return;

      GridView obj = (GridView)sender;

      int[] rows = obj.GetSelectedRows();
      foreach (int row in rows) {
        Index a = (Index)obj.GetRow(row);
        a.IsSelected = true;
      }

      for (int i = 0; i != obj.RowCount; i++) {
        if (rows.Contains(i)) continue;

        Index a = (Index)obj.GetRow(i);
        a.IsSelected = false;
      }

      List<Index> dataView = (List<Index>)obj.DataSource;
      int selectedItems = dataView.Count(_ => _.IsSelected);

      buttonFix.Enabled = selectedItems > 0;
    }

    private void GridRowCountChanged(object sender, EventArgs e) {
      GridView obj = (GridView)sender;

      if (obj.RowCount == 0) return;

      List<Index> dv = (List<Index>)obj.DataSource;

      obj.SelectionChanged -= GridSelectionChanged;

      foreach (Index var in dv.Where(_ => _.IsSelected)) {
        for (int i = 0; i < obj.DataRowCount; i++) {
          if (var.Equals(obj.GetRow(i)) && obj.IsDataRow(i)) {
            obj.SelectRow(i);
          }
        }
      }

      obj.SelectionChanged += GridSelectionChanged;
    }

    private void GridRowCellClick(object sender, RowCellClickEventArgs e) {
      if (e.Column != null && e.Column.Name == Resources.FixType) {
        GridView obj = (GridView)sender;
        obj.ShowEditor();

        LookUpEdit ed = (LookUpEdit)obj.ActiveEditor;
        ed?.ShowPopup();
      }
    }

    private void GridPopupMenuShowing(object sender, PopupMenuShowingEventArgs e) {
      if (e.MenuType == GridMenuType.Column) {
        string[] columns = {
                    GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnGroup),
                    GridLocalizer.Active.GetLocalizedString(GridStringId.MenuGroupPanelShow)
                };

        foreach (DXMenuItem item in e.Menu.Items) {
          if (columns.Contains(item.Caption))
            item.Visible = false;
        }
      }

      var col = e.HitInfo.Column;
      if (col == null) return;

      if (e.MenuType == GridMenuType.Column) {
        if (col.Caption == Resources.Selection || col.Caption == Resources.Progress)
          return;

        string colName = (col.Fixed == FixedStyle.None) ? "Freeze Column" : "Unfreeze Column";
        e.Menu.Items.Add(new DXMenuItem(colName, ChangeFixedColumnStyle, Resources.IconLeftCol) { Tag = col.FieldName });

        if (view.Editable) {
          e.Menu.Items.Add(new DXMenuItem("Restore Default Layout", RestoreDefaultLayout, Resources.IconRestoreLayout));
        }
      }
      else if (e.MenuType == GridMenuType.Row) {

        if (col.Caption == Resources.Selection || col.Caption == Resources.Progress)
          return;

        if (view.OptionsBehavior.Editable) {
          e.Menu.Items.Add(new DXMenuItem("Change Fix Action", ChangeFixAction, Resources.IconReplace));
        }
        
        e.Menu.Items.Add(new DXMenuItem("Copy Fix Script", CopyFixScript, Resources.IconCopyFix));
        e.Menu.Items.Add(new DXMenuItem("Copy Value", CopyCellValue, Resources.IconCopy) { Tag = col.FieldName });
        e.Menu.Items.Add(new DXMenuItem("Filter Value", FilterCellValue, Resources.IconFilter) { Tag = col.FieldName });
      }
    }

    private void RestoreDefaultLayout(object sender, EventArgs e) {
      try {
        foreach (GridColumn col in view.Columns.Where(_ => _.Fixed != FixedStyle.None)) {
          col.Fixed = FixedStyle.None;
        }

        view.RestoreLayoutFromStream(_defaultLayout);
        _defaultLayout.Seek(0, SeekOrigin.Begin);

        Output.Current.Add("Default grid layout restored");
      }
      catch {
        Output.Current.Add("Failed to restore default layout");
      }
    }

    private void ChangeFixedColumnStyle(object sender, EventArgs e) {
      DXMenuItem mi = (DXMenuItem)sender;
      GridColumn col = view.Columns[mi.Tag.ToString()];
      if (col != null) {
        col.Fixed = (col.Fixed == FixedStyle.Left) ? FixedStyle.None : FixedStyle.Left;
      }
    }

    private void CopyFixScript(object sender, EventArgs e) {
      Index row = (Index)view.GetFocusedRow();
      if (row == null) return;

      string query = $"USE {row.DatabaseName.ToQuota()}{Environment.NewLine}GO{Environment.NewLine}{row.GetQuery()}{Environment.NewLine}GO{Environment.NewLine}";
      Clipboard.SetText(query);
    }

    private void CopyCellValue(object sender, EventArgs e) {
      DXMenuItem mi = (DXMenuItem)sender;
      GridColumn col = view.Columns[mi.Tag.ToString()];
      var cellValue = view.GetFocusedRowCellValue(col);
      if (cellValue != null)
        Clipboard.SetText(cellValue.ToString());
    }

    private void FilterCellValue(object sender, EventArgs e) {
      DXMenuItem mi = (DXMenuItem)sender;
      GridColumn col = view.Columns[mi.Tag.ToString()];
      var cellValue = view.GetFocusedRowCellValue(col);
      view.SetRowCellValue(GridControl.AutoFilterRowHandle, col, cellValue);
    }

    private void ChangeFixAction(object sender, EventArgs e) {
      using (ActionBox form = new ActionBox()) {
        if (form.ShowDialog(this) == DialogResult.OK) {
          UpdateFixAction(form.GetFixAction());
        }
      }
    }

    private void UpdateFixAction(IndexOp op) {
      List<Index> indexes = (List<Index>)view.DataSource;

      for (int i = 0; i < view.DataRowCount; i++) {
        if (view.IsDataRow(i)) {
          var rowHandle = view.GetDataSourceRowIndex(i);
          Index index = indexes[rowHandle];
          if (index == null) continue;

          if (op == IndexOp.REBUILD_NONE && index.DataCompression == DataCompression.NONE) {
            index.FixType = IndexOp.REBUILD;
          }
          else {
            List<IndexOp> ops = GetIndexOperations(index);
            if (ops.Contains(op))
              index.FixType = op;
          }
        }
      }

      view.RefreshData();
    }

    private void GridCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e) {
      foreach (BarItemLink itemLink in e.CustomizationMenu.ItemLinks) {
        itemLink.Visible = false;
      }
    }

    private void GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e) {
      if (e.Info == null || e.SelectedControl == grid) {
        GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);

        if (info.InRowCell && info.RowHandle != -1 && info.Column != null && info.Column.FieldName == Resources.Progress) {
          Index index = (Index)view.GetRow(info.RowHandle);
          e.Info = new ToolTipControlInfo($"{info.RowHandle} - {info.Column}", $"{index.GetQuery()}\n{index.Error}");
        }
      }
    }

    #endregion

    #region Controls

    private void HideSystemColumns() {
      view.Columns[Resources.Progress].Visible = false;
      view.Columns[Resources.Duration].Visible = false;
      view.Columns[Resources.PagesCountBefore].Visible = false;
    }

    private void ButtonLog(object sender, ItemClickEventArgs e) {
      try {
        Process.Start(AppInfo.LogFileName);
      }
      catch (Exception ex) {
        XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void ButtonNewConnectionClick(object sender, ItemClickEventArgs e) {
      ShowConnectionBox();
    }

    private void ButtonFindClick(object sender, ItemClickEventArgs e) {
      RefreshIndexes();
    }

    private void ButtonDatabasesClick(object sender, ItemClickEventArgs e) {
      ShowDatabaseBox(false);
    }

    private void ButtonStopScanClick(object sender, ItemClickEventArgs e) {
      Output.Current.Add("Canceling...");
      QueryEngine.KillActiveSessions();
      _workerScan.CancelAsync();
      buttonStopScan.Visibility = BarItemVisibility.Never;
    }

    private void ButtonStopFixClick(object sender, ItemClickEventArgs e) {
      Output.Current.Add("Canceling...");
      QueryEngine.KillActiveSessions();
      _workerFix.CancelAsync();
      buttonStopFix.Visibility = BarItemVisibility.Never;
    }

    private void ButtonCopyFixClick(object sender, ItemClickEventArgs e) {
      string text = GetFixChanges();
      Clipboard.SetText(text);
    }

    private void ButtonSaveFixClick(object sender, ItemClickEventArgs e) {
      SaveFileDialog dialog = new SaveFileDialog {
        Filter = @"SQL Files (*.sql)|*.sql|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
        FilterIndex = 0,
        RestoreDirectory = true
      };

      if (dialog.ShowDialog() == DialogResult.OK) {
        string text = GetFixChanges();

        using (StreamWriter writer = new StreamWriter(dialog.OpenFile())) {
          writer.WriteLine(text);
          writer.Dispose();
          writer.Close();
        }
      }
    }

    private void ButtonOptionsClick(object sender, ItemClickEventArgs e) {
      ShowSettingsBox();
    }

    private void ButtonAboutClick(object sender, ItemClickEventArgs e) {
      using (AboutBox form = new AboutBox()) {
        form.ShowDialog(this);
      }
    }

    #endregion

    #region Save/Restore Sort

    private readonly List<GridColumnSortInfo> _sortInfo = new List<GridColumnSortInfo>();

    private void SaveSortRules() {
      foreach (GridColumnSortInfo col in view.SortInfo) {
        _sortInfo.Add(col);
      }

      view.ClearSorting();
    }

    private void RestoreSortRules() {
      if (_sortInfo.Count > 0 && view.SortInfo.Count == 0) {
        foreach (GridColumnSortInfo sortCol in _sortInfo) {
          view.SortInfo.Add(sortCol);
        }

        _sortInfo.Clear();
      }
    }

    #endregion

  }

}
