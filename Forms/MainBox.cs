using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Taskbar.Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using SQLIndexManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLIndexManager {

  public partial class MainBox : RibbonForm {

    private long _totalDuration;

    public MainBox() {
      InitializeComponent();
      splitContainer.PanelVisibility = SplitPanelVisibility.Panel1;

      Output.Current.SetOutputControl(labelInfo, gridControl2);
      Output.Current.Add($"Log folder: {Environment.CurrentDirectory}");
      popupIndexOperation.DataSource = Enum.GetValues(typeof(IndexOp)).Cast<IndexOp>().ToList();

      RestoreLayout();
    }

    private void UpdateActiveHost(Host host) {
      Settings.ActiveHost = host;

      buttonDatabases.Enabled = (host != null);
      buttonRefreshIndex.Enabled = (host != null && host.Databases.Count > 0);

      labelServerInfo.Visibility =
        labelDatabase.Visibility =
          labelError.Visibility =
            labelIndex.Visibility = (host == null) ? BarItemVisibility.Never : BarItemVisibility.Always;

      if (host == null) {
        ShowConnectionBox();
      }
      else {
        Output.Current.Add($"Current host: {host}");
        labelServerInfo.Caption = host.ToString();
        ShowDatabaseBox();
      }
    }

    #region Save/Restore Layout

    private void MainBox_FormClosing(object sender, FormClosingEventArgs e) {
      SaveLayout();
    }

    Stream defaultLayout = new MemoryStream();

    private void RestoreLayout() {
      try {
        gridView1.SaveLayoutToStream(defaultLayout);
        defaultLayout.Seek(0, SeekOrigin.Begin);
      }
      catch { }

      if (File.Exists(Settings.LayoutFileName)) {
        try {
          string layout = AES.Decrypt(File.ReadAllText(Settings.LayoutFileName));

          using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(layout))) {
            gridView1.RestoreLayoutFromStream(stream);
          }
          Output.Current.Add($"Grid layout restored: {Settings.LayoutFileName}");
        }
        catch {
          Output.Current.Add("Failed to restore layout");
        }
      }
    }

    private void RestoreDefaultLayout(object sender, ItemClickEventArgs e) {
      try {
        gridView1.RestoreLayoutFromStream(defaultLayout);
        defaultLayout.Seek(0, SeekOrigin.Begin);

        Output.Current.Add($"Default grid layout restored");
      }
      catch {
        Output.Current.Add("Failed to restore default layout");
      }
    }

    private void SaveLayout() {
      gridView1.Columns["Progress"].Visible = false;
      gridView1.Columns["Duration"].Visible = false;

      try {
        using (StreamWriter file = new StreamWriter(new FileStream(Settings.LayoutFileName, FileMode.Create))) {
          Stream str = new MemoryStream();
          gridView1.SaveLayoutToStream(str);
          str.Seek(0, SeekOrigin.Begin);
          StreamReader reader = new StreamReader(str);
          string layout = reader.ReadToEnd();

          file.Write(AES.Encrypt(layout));
          file.Close();
          Output.Current.Add($"Grid layout saved: {Settings.LayoutFileName}");
        }
      }
      catch {
        Output.Current.Add("Failed to save layout");
      }
    }

    #endregion

    #region Scan Indexes

    private readonly List<Index> _scanIndexes = new List<Index>();
    private BackgroundWorker _workerScan;
    private Stopwatch _scanDuration = new Stopwatch();
    private int _errors;

    private void ScanIndexStart(object sender, DoWorkEventArgs e) {
      _errors = 0;
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
              _errors++;
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

          foreach (Index index in idx.Where(_ => _.Fragmentation == null)
                                     .OrderBy(_ => _.ObjectId)
                                     .ThenBy(_ => _.IndexId)
                                     .ThenBy(_ => _.PartitionNumber)) {
            try {
              if (_workerScan.CancellationPending) {
                _scanIndexes.AddRange(idx);
                e.Cancel = true;
                return;
              }

              connection = connectionList.Get(database);
              if (connection == null) break;

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
              _errors++;
              Output.Current.Add($"Failed: {index}", ex.Message);
            }
          }

          _scanIndexes.AddRange(idx);
        }
      }
    }

    private void ScanIndexFinish(object sender, RunWorkerCompletedEventArgs e) {
      taskbar.ProgressMode = TaskbarButtonProgressMode.NoProgress;
      _scanDuration.Stop();

      buttonOptions.Enabled =
        buttonDatabases.Enabled =
          buttonRefreshIndex.Enabled =
            buttonNewConnection.Enabled =
              buttonRestoreDefaultLayout.Enabled = true;

      buttonStopScan.Visibility = BarItemVisibility.Never;

      List<Index> indexes = _scanIndexes.Where(_ => _.Fragmentation >= Settings.Options.FirstThreshold
                                                 && _.PagesCount >= Settings.Options.MinIndexSize.PageSize()
                                                 && _.PagesCount <= Settings.Options.MaxIndexSize.PageSize())
                                        .OrderByDescending(_ => Math.Ceiling(Math.Truncate(_.Fragmentation ?? 0) / 20) * 20)
                                        .ThenByDescending(_ => _.PagesCount).ToList();

      QueryEngine.UpdateFixType(indexes);
      QueryEngine.FindDublicateIndexes(indexes);
      QueryEngine.FindUnusedIndexes(indexes);

      labelIndex.Caption = indexes.Count.ToString();
      labelError.Caption = _errors.ToString();
      Output.Current.Add($"Processed: {_scanIndexes.Count}. Fragmented: {indexes.Count}", null, _scanDuration.ElapsedMilliseconds);

      gridView1.CustomDrawEmptyForeground += CustomDrawEmptyForeground;
      gridControl1.DataSource = indexes;

      if (indexes.Count > 0) {
        var rulePagesCount = gridView1.FormatRules[Resources.PagesCount].RuleCast<FormatConditionRuleDataBar>();
        var ruleUnusedPagesCount = gridView1.FormatRules[Resources.UnusedPagesCount].RuleCast<FormatConditionRuleDataBar>();

        rulePagesCount.Minimum = 1;
        rulePagesCount.Maximum = indexes.Max(_ => _.PagesCount);

        ruleUnusedPagesCount.Minimum = 1;
        ruleUnusedPagesCount.Maximum = indexes.Max(_ => _.UnusedPagesCount) > 1000
                                          ? indexes.Max(_ => _.UnusedPagesCount)
                                          : rulePagesCount.Maximum;
      }
    }

    private void RefreshIndexes() {
      if (_workerFix != null && _workerFix.IsBusy) return;

      gridView1.CustomDrawEmptyForeground -= CustomDrawEmptyForeground;
      gridControl1.DataSource = null;

      labelDatabase.Caption = Settings.ActiveHost.Databases.Count.ToString();
      labelIndex.Caption =
        labelError.Caption = @"0";

      RestoreSortRules();

      gridView1.OptionsBehavior.Editable = true;
      gridView1.OptionsSelection.MultiSelect = true;

      gridView1.Columns[Resources.Progress].Visible = false;
      gridView1.Columns[Resources.Duration].Visible = false;
      gridView1.Columns[Resources.PagesCountBefore].Visible = false;

      buttonFix.Enabled =
        buttonOptions.Enabled =
            buttonDatabases.Enabled =
              buttonRefreshIndex.Enabled =
                buttonNewConnection.Enabled = false;

      buttonStopScan.Visibility = BarItemVisibility.Always;
      taskbar.ProgressMode = TaskbarButtonProgressMode.Indeterminate;

      _scanIndexes.Clear();
      _scanDuration = Stopwatch.StartNew();

      _workerScan = new ThreadWorker() { WorkerSupportsCancellation = true, WorkerReportsProgress = true };
      _workerScan.DoWork += ScanIndexStart;
      _workerScan.RunWorkerCompleted += ScanIndexFinish;
      _workerScan.RunWorkerAsync();
    }

    #endregion

    #region Fix Indexes

    private void buttonFix_ItemClick(object sender, ItemClickEventArgs e) {
      if (_workerFix != null && _workerFix.IsBusy) return;

      _totalDuration = 0;

      buttonFix.Enabled =
        buttonDatabases.Enabled =
          buttonRefreshIndex.Enabled =
            buttonNewConnection.Enabled =
              buttonOptions.Enabled =
                buttonRestoreDefaultLayout.Enabled = false;

      buttonStopFix.Visibility = BarItemVisibility.Always;

      List<Index> selIndex = ((List<Index>)gridView1.DataSource).Where(_ => _.IsSelected).ToList();

      List<Index> fixIndex =
          selIndex.Where(x => Settings.ActiveHost.Databases.Any(y => y == x.DatabaseName))
                  .OrderByDescending(_ => Math.Ceiling(Math.Truncate(_.Fragmentation ?? 0) / 20) * 20)
                  .ThenByDescending(_ => _.PagesCount).ToList();

      labelDatabase.Caption = fixIndex.Select(_ => _.DatabaseName).Distinct().Count().ToString();
      labelIndex.Caption = fixIndex.Count.ToString();

      foreach (Index row in fixIndex) {
        row.Progress = imageCollection.Images[0];
      }

      SaveSortRules();

      gridView1.ClearColumnsFilter();
      gridView1.ClearSelection();

      gridView1.Columns[Resources.Duration].Visible = true;
      gridView1.Columns[Resources.Duration].VisibleIndex = 0;

      gridView1.Columns[Resources.Progress].Visible = true;
      gridView1.Columns[Resources.Progress].VisibleIndex = 0;

      gridView1.Columns[Resources.PagesCountBefore].Visible = true;
      gridView1.Columns[Resources.PagesCountBefore].VisibleIndex = gridView1.Columns[Resources.PagesCount].VisibleIndex + 1;

      gridControl1.DataSource = fixIndex;

      gridView1.OptionsBehavior.Editable = false;
      gridView1.OptionsSelection.MultiSelect = false;

      Output.Current.Add("Start processing");

      taskbar.ProgressMaximumValue = fixIndex.Count;
      taskbar.ProgressMode = TaskbarButtonProgressMode.Normal;

      _workerFix = new BackgroundWorker { WorkerSupportsCancellation = true, WorkerReportsProgress = true };
      _workerFix.DoWork += FixIndexes;
      _workerFix.RunWorkerCompleted += FixIndexesFinish;
      _workerFix.ProgressChanged += backgroundWorker_ProgressChanged;
      _workerFix.RunWorkerAsync(fixIndex);
    }

    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
      taskbar.ProgressCurrentValue = e.ProgressPercentage;
      gridView1.RefreshData();
    }

    private BackgroundWorker _workerFix;

    private void FixIndexes(object sender, DoWorkEventArgs e) {

      List<Index> indexes = (List<Index>)e.Argument;

      using (var connectionList = new ConnectionList(Settings.ActiveHost)) {

        int count = 1;

        foreach (Index item in indexes) {
          if (_workerFix.CancellationPending) {
            Output.Current.Add("Canceled");
            e.Cancel = true;
            return;
          }

          Output.Current.AddCaption(item.ToString());
          Stopwatch watch = Stopwatch.StartNew();

          item.Progress = imageCollection.Images[1];

          string sql = string.Empty;
          SqlConnection connection = connectionList.Get(item.DatabaseName);
          if (connection != null) {
            sql = QueryEngine.FixIndex(connection, item);
          }

          item.Progress = imageCollection.Images[2];

          watch.Stop();

          _totalDuration += watch.ElapsedMilliseconds;
          item.Duration = (new DateTime(0)).AddMilliseconds(watch.ElapsedMilliseconds);

          Output.Current.Add(item.ToString(), sql, watch.ElapsedMilliseconds);

          if (!string.IsNullOrEmpty(item.Error)) {
            Output.Current.Add(item.ToString(), item.Error);
            item.Progress = imageCollection.Images[3];
          }

          _workerFix.ReportProgress(count++);
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
      labelError.Caption = ((List<Index>)gridView1.DataSource).Count(_ => _.Error != null).ToString();

      buttonStopFix.Visibility = BarItemVisibility.Never;

      Output.Current.Add("Finished", null, _totalDuration);
    }

    #endregion

    #region Dialogs

    private void MainBox_Shown(object sender, EventArgs e) {
      UpdateActiveHost(null);
    }

    private void ShowDatabaseBox() {
      using (DatabaseBox form = new DatabaseBox()) {
        DialogResult dr = form.ShowDialog(this);
        if (dr == DialogResult.OK) {
          Settings.ActiveHost.Databases = form.GetDatabases();
          RefreshIndexes();
        }
        else {
          labelDatabase.Caption = Settings.ActiveHost.Databases.Count.ToString();
        }
      }
    }

    private void ShowConnectionBox() {
      using (ConnectionBox form = new ConnectionBox()) {
        DialogResult dr = form.ShowDialog(this);
        if (dr == DialogResult.OK) {
          UpdateActiveHost(form.GetHost());
        }
      }
    }

    #endregion

    #region Grid Methods

    private string GetFixChanges() {
      List<Index> fix = ((List<Index>)gridView1.DataSource).Where(_ => _.IsSelected).ToList();
      StringBuilder sb = new StringBuilder();

      var groupList = fix.GroupBy(u => u.DatabaseName).Select(grp => grp.ToList()).ToList();
      foreach (var group in groupList) {
        sb.AppendLine($"USE {group[0].DatabaseName.ToQuota()}\nGO\n");

        foreach (Index i in group.OrderBy(_ => _.SchemaName)
                                 .ThenBy(_ => _.ObjectName)
                                 .ThenBy(_ => _.IndexName)
                                 .ThenBy(_ => _.PartitionNumber)) {
          sb.AppendLine($"RAISERROR(N'{i}', 0, 1) WITH NOWAIT\n{i.GetQuery()}\nGO\n");
        }
      }

      return sb.ToString();
    }

    private void FixedOpPopupValueChanged(object sender, EventArgs e) {
      Index row = (Index)gridView1.GetFocusedRow();
      if (row == null) return;

      int rowIndex = gridView1.FindRow(row);

      gridView1.PostEditor();
      gridView1.SelectRow(rowIndex);
      gridView1.UpdateCurrentRow();
    }

    private void FixedOpPopup(object sender, EventArgs e) {
      LookUpEdit obj = (LookUpEdit)sender;
      obj.Properties.DataSource = null;

      Index row = (Index)gridView1.GetFocusedRow();
      if (row == null) return;

      List<IndexOp> i = new List<IndexOp>();

      if (row.IndexType == IndexType.MISSING_INDEX) {
        i.Add(IndexOp.CREATE_INDEX);
      }
      else if (row.IsColumnstore) {
        i.Add(IndexOp.REBUILD);

        i.Add(row.DataCompression == DataCompression.COLUMNSTORE_ARCHIVE
          ? IndexOp.REBUILD_COLUMNSTORE
          : IndexOp.REBUILD_COLUMNSTORE_ARCHIVE);

        i.Add(IndexOp.REORGANIZE);

        if (Settings.ServerInfo.MajorVersion >= ServerVersion.Sql2016)
          i.Add(IndexOp.REORGANIZE_COMPRESS_ALL_ROW_GROUPS);
      }
      else {
        i.Add(IndexOp.REBUILD);

        if (row.IsAllowCompression) {
          if (row.DataCompression == DataCompression.NONE) {
            i.Add(IndexOp.REBUILD_ROW);
            i.Add(IndexOp.REBUILD_PAGE);
          }
          else {
            i.Add(IndexOp.REBUILD_NONE);
            i.Add(row.DataCompression == DataCompression.PAGE
              ? IndexOp.REBUILD_ROW
              : IndexOp.REBUILD_PAGE);
          }
        }

        if (row.IsAllowOnlineRebuild)
          i.Add(IndexOp.REBUILD_ONLINE);

        if (row.IsAllowReorganize)
          i.Add(IndexOp.REORGANIZE);

        if (!row.IsPartitioned) {
          if (row.IndexType == IndexType.CLUSTERED || row.IndexType == IndexType.NONCLUSTERED) {
            i.Add(IndexOp.UPDATE_STATISTICS_FULL);
            i.Add(IndexOp.UPDATE_STATISTICS_RESAMPLE);
            i.Add(IndexOp.UPDATE_STATISTICS_SAMPLE);
          }

          if (row.IndexType == IndexType.NONCLUSTERED) {
            i.Add(IndexOp.DISABLE_INDEX);
            i.Add(IndexOp.DROP_INDEX);
          }

          if (row.IndexType == IndexType.HEAP) {
            i.Add(IndexOp.DROP_TABLE);
          }
        }
      }

      obj.Properties.DropDownRows = i.Count;
      obj.Properties.DataSource = i.Select(_ => new { Fix = _, Name = _.Description() });
    }

    private void GridDoubleClick(object sender, EventArgs e) {
      GridView obj = (GridView)sender;
      Point pt = obj.GridControl.PointToClient(MousePosition);

      GridHitInfo info = obj.CalcHitInfo(pt);
      if (info.Column == null || info.Column.Caption == @"Fix" || info.Column.Caption == @"Selection")
        return;

      if (info.InRow || info.InRowCell) {
        if (obj.IsRowSelected(info.RowHandle))
          obj.UnselectRow(info.RowHandle);
        else
          obj.SelectRow(info.RowHandle);
      }
    }

    private void GridSelectionChanged(object sender, SelectionChangedEventArgs e) {
      if (_workerFix != null && _workerFix.IsBusy) return;

      GridView obj = (GridView)sender;

      int[] b = obj.GetSelectedRows();
      foreach (int row in b) {
        Index a = (Index)obj.GetRow(row);
        a.IsSelected = true;
      }

      for (int i = 0; i != obj.RowCount; i++) {
        if (b.Contains(i)) continue;

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

    private void GridColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
      switch (e.Column.FieldName) {
        case "PagesCount":
        case "PagesCountBefore":
        case "UnusedPagesCount":
          if (e.Value != null)
            e.DisplayText = (Convert.ToDecimal(e.Value) * 8).FormatSize() + " ";
          break;

        case "Fragmentation":
        case "PageSpaceUsed":
          if (e.Value != null) {
            e.DisplayText = $"{e.Value:n1} % ";
          }
          break;

        case "RowsCount":
          e.DisplayText = $"{e.Value:n0} ";
          break;

        case "FixType":
          e.DisplayText = ((IndexOp)e.Value).Description();
          break;
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

        if (e.HitInfo.Column == null || e.HitInfo.Column.Caption == @"Selection")
          return;

        string colName = (e.HitInfo.Column.Fixed == FixedStyle.None) ? "Freeze column" : "Unfreeze column";
        e.Menu.Items.Add(new DXMenuItem(colName, ChangeFixedColumnStyle) { Tag = e.HitInfo.Column.FieldName });
      }
    }

    private void ChangeFixedColumnStyle(object sender, EventArgs e) {
      DXMenuItem mi = (DXMenuItem)sender;
      GridColumn col = gridView1.Columns[mi.Tag.ToString()];
      if (col != null) {
        col.Fixed = (col.Fixed == FixedStyle.Left) ? FixedStyle.None : FixedStyle.Left;
      }
    }

    private void GridCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e) {
      foreach (BarItemLink itemLink in e.CustomizationMenu.ItemLinks) {
        itemLink.Visible = false;
      }
    }

    private void GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e) {
      if (e.Info == null || e.SelectedControl == gridControl1) {
        GridHitInfo info = gridView1.CalcHitInfo(e.ControlMousePosition);

        if (info.InRowCell && info.RowHandle != -1 && info.Column != null && info.Column.FieldName == Resources.Progress) {
          Index index = (Index)gridView1.GetRow(info.RowHandle);
          e.Info = new ToolTipControlInfo($"{info.RowHandle} - {info.Column}", $"{index.GetQuery()}\n{index.Error}");
        }
      }
    }

    private void CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e) {
      string noIndexesFoundText = "No indexes found";
      string trySearchingAgainText = "Try searching again or change settings";
      int offset = 15;

      e.DefaultDraw();
      e.Appearance.Options.UseFont = true;
      e.Appearance.Font = new Font("Tahoma", 12);
      Size size = e.Appearance.CalcTextSize(e.Cache, noIndexesFoundText, e.Bounds.Width).ToSize();
      int x = (e.Bounds.Width - size.Width) / 2;
      int y = e.Bounds.Y + offset;
      Rectangle noIndexesFoundBounds = new Rectangle(new Point(x, y), size);
      e.Appearance.DrawString(e.Cache, noIndexesFoundText, noIndexesFoundBounds);
      size = e.Appearance.CalcTextSize(e.Cache, trySearchingAgainText, e.Bounds.Width).ToSize();
      x = noIndexesFoundBounds.X - (size.Width - noIndexesFoundBounds.Width) / 2;
      y = noIndexesFoundBounds.Bottom + offset;
      size.Width += offset;
      Rectangle trySearchingAgainBounds = new Rectangle(new Point(x, y), size);
      e.Appearance.DrawString(e.Cache, trySearchingAgainText, trySearchingAgainBounds);
    }

    #endregion

    #region Controls

    private void ButtonLog(object sender, ItemClickEventArgs e) {
      splitContainer.PanelVisibility = buttonLog.Down ? SplitPanelVisibility.Both : SplitPanelVisibility.Panel1;
    }

    private void ButtonNewConnectionClick(object sender, ItemClickEventArgs e) {
      ShowConnectionBox();
    }

    private void ButtonFindClick(object sender, ItemClickEventArgs e) {
      RefreshIndexes();
    }

    private void ButtonDatabasesClick(object sender, ItemClickEventArgs e) {
      ShowDatabaseBox();
    }

    private void ButtonStopScanClick(object sender, ItemClickEventArgs e) {
      Output.Current.Add("Canceling...");
      _workerScan.CancelAsync();
      buttonStopScan.Visibility = BarItemVisibility.Never;
    }

    private void ButtonStopFixClick(object sender, ItemClickEventArgs e) {
      Output.Current.Add("Canceling...");
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
      using (SettingsBox form = new SettingsBox()) {
        DialogResult dr = form.ShowDialog(this);
        if (dr == DialogResult.OK) {
          Settings.Options = form.GetSettings();
        }
      }
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
      foreach (GridColumnSortInfo col in gridView1.SortInfo) {
        _sortInfo.Add(col);
      }

      gridView1.ClearSorting();
    }

    private void RestoreSortRules() {
      if (_sortInfo.Count > 0 && gridView1.SortInfo.Count == 0) {
        foreach (GridColumnSortInfo sortCol in _sortInfo) {
          gridView1.SortInfo.Add(sortCol);
        }

        _sortInfo.Clear();
      }
    }

    #endregion

    #region Export

    private void ExportCsv(object sender, ItemClickEventArgs e) {
      SaveFileDialog dialog = new SaveFileDialog {
        Filter = @"CSV Files (*.csv)|*.csv",
        RestoreDirectory = true
      };

      if (dialog.ShowDialog() == DialogResult.OK) {
        CsvExportOptionsEx advOptions = new CsvExportOptionsEx {
          ExportType = DevExpress.Export.ExportType.WYSIWYG,
          TextExportMode = TextExportMode.Value
        };

        try {
          gridControl1.ExportToCsv(dialog.FileName, advOptions);
          Output.Current.Add($"Export to CSV: {dialog.FileName}");
        }
        catch (Exception ex) {
          Output.Current.Add("Export to CSV failed", ex.Message);
          XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void ExportExcel(object sender, ItemClickEventArgs e) {
      SaveFileDialog dialog = new SaveFileDialog {
        Filter = @"Excel Files (*.xlsx)|*.xlsx",
        RestoreDirectory = true
      };

      if (dialog.ShowDialog() == DialogResult.OK) {
        XlsxExportOptionsEx advOptions = new XlsxExportOptionsEx {
          ExportType = DevExpress.Export.ExportType.DataAware,
          TextExportMode = TextExportMode.Value,
          SheetName = Settings.ActiveHost.Server
        };

        try {
          gridControl1.ExportToXlsx(dialog.FileName, advOptions);
          Output.Current.Add($"Export to Excel: {dialog.FileName}");
        }
        catch (Exception ex) {
          Output.Current.Add("Export to Excel failed", ex.Message);
          XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void ExportText(object sender, ItemClickEventArgs e) {
      SaveFileDialog dialog = new SaveFileDialog {
        Filter = @"Text Files (*.txt)|*.txt",
        RestoreDirectory = true
      };

      if (dialog.ShowDialog() == DialogResult.OK) {
        try {
          gridControl1.ExportToText(dialog.FileName);
          Output.Current.Add($"Export to Text: {dialog.FileName}");
        }
        catch (Exception ex) {
          Output.Current.Add("Export to Text failed", ex.Message);
          XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void ExportHtml(object sender, ItemClickEventArgs e) {
      SaveFileDialog dialog = new SaveFileDialog {
        Filter = @"HTML Files (*.html)|*.html",
        RestoreDirectory = true
      };

      if (dialog.ShowDialog() == DialogResult.OK) {
        try {
          gridControl1.ExportToHtml(dialog.FileName);
          Output.Current.Add($"Export to Html: {dialog.FileName}");
        }
        catch (Exception ex) {
          Output.Current.Add("Export to Html failed", ex.Message);
          XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    #endregion

  }

}
