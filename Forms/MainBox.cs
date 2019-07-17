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

    private void RestoreLayout() {
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

    private void ScanIndexStart(object sender, DoWorkEventArgs e) {
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

              if (index.IndexType == IndexType.ColumnstoreClustered || index.IndexType == IndexType.ColumnstoreNonClustered) {
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

      buttonDatabases.Enabled =
        buttonRefreshIndex.Enabled =
          buttonNewConnection.Enabled =
            buttonOptions.Enabled = true;

      buttonStopScan.Visibility = BarItemVisibility.Never;

      List<Index> indexes = _scanIndexes.Where(_ => _.Fragmentation >= Settings.Options.ReorganizeThreshold
                                                 && _.PagesCount >= Settings.Options.MinIndexSize.PageSize()
                                                 && _.PagesCount <= Settings.Options.MaxIndexSize.PageSize())
                                        .OrderByDescending(_ => Math.Ceiling(Math.Truncate(_.Fragmentation ?? 0) / 20) * 20)
                                        .ThenByDescending(_ => _.PagesCount).ToList();

      foreach (Index ix in indexes) {
        if (ix.IndexType == IndexType.MissingIndex)
          ix.FixType = IndexOp.CreateIndex;
        else if (ix.Fragmentation < Settings.Options.RebuildThreshold && ix.IsAllowReorganize)
          ix.FixType = IndexOp.Reorganize;
        else if (Settings.Options.Online && ix.IsAllowOnlineRebuild)
          ix.FixType = IndexOp.RebuildOnline;
        else if (!ix.IsColumnstore && ix.IsAllowCompression) {
          if (Settings.Options.DataCompression == DataCompression.None.ToDescription() && ix.DataCompression != DataCompression.None)
            ix.FixType = IndexOp.RebuildNone;
          else if (Settings.Options.DataCompression == DataCompression.Row.ToDescription())
            ix.FixType = IndexOp.RebuildRow;
          else if (Settings.Options.DataCompression == DataCompression.Page.ToDescription())
            ix.FixType = IndexOp.RebuildPage;
          else
            ix.FixType = IndexOp.Rebuild;
        }
        else
          ix.FixType = IndexOp.Rebuild;
      }

      labelIndex.Caption = indexes.Count.ToString();
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
      labelIndex.Caption = @"0";

      RestoreSortRules();

      gridView1.OptionsBehavior.Editable = true;
      gridView1.OptionsSelection.MultiSelect = true;

      gridView1.Columns[Resources.Progress].Visible = false;
      gridView1.Columns[Resources.Duration].Visible = false;
      gridView1.Columns[Resources.PagesCountBefore].Visible = false;

      buttonDatabases.Enabled =
        buttonRefreshIndex.Enabled =
          buttonNewConnection.Enabled =
            buttonOptions.Enabled = false;

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

      buttonDatabases.Enabled =
        buttonRefreshIndex.Enabled =
          buttonNewConnection.Enabled =
            buttonFix.Enabled =
              buttonOptions.Enabled = false;

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

          string sql = item.GetQuery();
          Output.Current.AddCaption(item.ToString());

          Stopwatch watch = Stopwatch.StartNew();

          item.Progress = imageCollection.Images[1];

          SqlConnection connection = connectionList.Get(item.DatabaseName);
          if (connection != null) {
            QueryEngine.FixIndex(connection, item);
          }

          item.Progress = imageCollection.Images[2];

          watch.Stop();

          _totalDuration += watch.ElapsedMilliseconds;
          item.Duration = (new DateTime(0)).AddMilliseconds(watch.ElapsedMilliseconds);

          if (string.IsNullOrEmpty(item.Error)) {
            Output.Current.Add(item.ToString(), sql, watch.ElapsedMilliseconds);
          }
          else {
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
      List<Index> dv = (List<Index>)gridView1.DataSource;
      List<Index> fix = dv.Where(_ => _.IsSelected).ToList();

      StringBuilder sb = new StringBuilder();

      var groupList = fix.GroupBy(u => u.DatabaseName).Select(grp => grp.ToList()).ToList();
      foreach (var group in groupList) {
        sb.AppendLine($"USE [{group[0].DatabaseName.ToQuota()}]\nGO\n");

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

      List<IndexOp> i = new List<IndexOp> { IndexOp.Rebuild };

      if (row.IsColumnstore) {
        i.Add(row.DataCompression == DataCompression.ColumnstoreArchive
          ? IndexOp.RebuildColumnstore
          : IndexOp.RebuildColumnstoreArchive);

        i.Add(IndexOp.Reorganize);

        if (Settings.ServerInfo.MajorVersion >= 13)
          i.Add(IndexOp.ReorganizeCompressAllRowGroup);
      }
      else {
        if (row.IsAllowCompression) {
          if (row.DataCompression == DataCompression.None) {
            i.Add(IndexOp.RebuildRow);
            i.Add(IndexOp.RebuildPage);
          }
          else {
            i.Add(IndexOp.RebuildNone);
            i.Add(row.DataCompression == DataCompression.Page
              ? IndexOp.RebuildRow
              : IndexOp.RebuildPage);
          }
        }

        if (row.IsAllowOnlineRebuild)
          i.Add(IndexOp.RebuildOnline);

        if (row.FillFactor > 0 && row.FillFactor < 100)
          i.Add(IndexOp.RebuildFillFactorZero);

        if (row.IsAllowReorganize)
          i.Add(IndexOp.Reorganize);

        if (!row.IsPartitioned) {
          if (row.IndexType == IndexType.Clustered || row.IndexType == IndexType.NonClustered) {
            i.Add(IndexOp.UpdateStatsFull);
            i.Add(IndexOp.UpdateStatsSample);
            i.Add(IndexOp.UpdateStatsResample);
          }

          if (row.IndexType == IndexType.NonClustered) {
            i.Add(IndexOp.Disable);
            i.Add(IndexOp.Drop);
          }
        }
      }

      obj.Properties.DropDownRows = i.Count;
      obj.Properties.DataSource = i.Select(_ => new { Fix = _, Name = _.ToDescription() });
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
      if (e.Column != null && e.Column.Name == "FixType") {
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
          if (e.Value != null) {
            e.DisplayText = (Convert.ToDecimal(e.Value) * 8).FormatSize();
          }
          break;

        case "Fragmentation":
          double value = Convert.ToDouble(e.Value);
          e.DisplayText = string.Format(value - Math.Truncate(value) < 0.1 || value > 99.9 ? "{0:n0} %" : "{0:n1} %", value);
          break;

        case "Compression":
          e.DisplayText = ((DataCompression)e.Value).ToDescription();
          break;

        case "IndexType":
          e.DisplayText = ((IndexType)e.Value).ToDescription();
          break;

        case "FixType":
          e.DisplayText = ((IndexOp)e.Value).ToDescription();
          break;
      }
    }

    private void GridPopupMenuShowing(object sender, PopupMenuShowingEventArgs e) {
      if (e.MenuType == GridMenuType.Column) {
        string[] columns = {
                    GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnGroup),
                    GridLocalizer.Active.GetLocalizedString(GridStringId.MenuGroupPanelShow),
                    GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnBestFit),
                    GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnBestFitAllColumns)
                };

        foreach (DXMenuItem item in e.Menu.Items) {
          if (columns.Contains(item.Caption))
            item.Visible = false;
        }
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

        if (info.InRowCell && info.RowHandle != -1 && info.Column != null && info.Column.FieldName == "Progress") {
          Index index = (Index)gridView1.GetRow(info.RowHandle);
          e.Info = new ToolTipControlInfo($"{info.RowHandle} - {info.Column}", $"{index.GetQuery()}\n{index.Error}");
        }
      }
    }

    private void CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e) {
      string noIndexesFoundText = "No indexes found";
      string trySearchingAgainText = "Try searching again";
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
