using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using SQLIndexManager.Properties;

namespace SQLIndexManager {

  public partial class DatabaseBox : XtraForm {

    public DatabaseBox() {
      InitializeComponent();
      Text = Resources.DatabaseBoxTitle;

      view.CustomColumnDisplayText += GridMethod.GridColumnDisplayText;
      view.RowCellStyle += GridMethod.GridRowCellStyle;
      view.DoubleClick += GridMethod.GridDoubleClick;

      if (Settings.ServerInfo.IsAzure) {
        TotalSize.Visible = DataSize.Visible = LogSize.Visible = DataFreeSize.Visible = LogFreeSize.Visible = false;
        view.SortInfo.Clear();
        view.SortInfo.Add(new GridColumnSortInfo(DatabaseName, ColumnSortOrder.Ascending));
      }

      RefreshDatabases();
    }

    private void ButtonRefreshClick(object sender, EventArgs e) {
      RefreshDatabases();
    }

    public List<string> GetDatabases() {
      List<string> dbs = new List<string>();
      int[] rows = view.GetSelectedRows();

      foreach (int row in rows) {
        Database db = (Database)view.GetRow(row);
        dbs.Add(db.DatabaseName);
      }

      return dbs;
    }

    #region Refresh Databases

    private BackgroundWorker _workerScan;
    private List<Database> _databases = new List<Database>();
    private List<DiskInfo> _disks = new List<DiskInfo>();
    private Stopwatch _ts = new Stopwatch();

    private void ScanDatabases(object sender, DoWorkEventArgs e) {
      using (SqlConnection connection = Connection.Create(Settings.ActiveHost)) {
        try {
          connection.Open();

          if (!Settings.ServerInfo.IsAzure && Settings.ServerInfo.IsSysAdmin) {
            _disks = QueryEngine.GetDiskInfo(connection);
          }

          _databases = QueryEngine.GetDatabases(connection);
        }
        catch (Exception ex) {
          Output.Current.Add("Refresh failed", ex.Message);
          XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally {
          connection.Close();
        }
      }
    }

    private void ScanDatabasesFinish(object sender, RunWorkerCompletedEventArgs e) {
      if (_disks.Count > 0) {
        Text = $"{Resources.DatabaseBoxTitle}      {string.Join("  |  ", _disks.Select(_ => _.ToString()))}";
      }

      var max = _databases.Max(_ => _.TotalSize);
      foreach (var rule in view.FormatRules) {
        ((FormatConditionRuleDataBar)rule.Rule).Maximum = max;
      }

      grid.DataSource = _databases;

      foreach (string db in Settings.ActiveHost.Databases) {
        int index = view.LocateByValue(DatabaseName.FieldName, db);
        view.SelectRow(index);
      }

      _ts.Stop();
      buttonRefresh.Enabled = true;
      Output.Current.Add($"Found {_databases.Count} databases", null, _ts.ElapsedMilliseconds);
    }

    private void RefreshDatabases() {
      if (_workerScan != null && _workerScan.IsBusy) return;

      Output.Current.Add("Refresh databases...");

      _ts = Stopwatch.StartNew();
      _databases.Clear();
      _disks.Clear();

      grid.DataSource = null;
      buttonOK.Enabled = false;
      buttonRefresh.Enabled = false;
      TotalSize.Visible = DataSize.Visible = LogSize.Visible = DataFreeSize.Visible = LogFreeSize.Visible = !Settings.ServerInfo.IsAzure;

      _workerScan = new ThreadWorker() { WorkerSupportsCancellation = true };
      _workerScan.DoWork += ScanDatabases;
      _workerScan.RunWorkerCompleted += ScanDatabasesFinish;
      _workerScan.RunWorkerAsync();
    }

    #endregion

    #region Override Methods

    protected override bool ProcessDialogKey(Keys keyData) {
      if (keyData == Keys.Escape) {
        DialogResult = DialogResult.Cancel;
        return true;
      }

      if (keyData == Keys.Enter && buttonOK.Enabled) {
        DialogResult = DialogResult.OK;
        return true;
      }

      return base.ProcessDialogKey(keyData);
    }

    #endregion

    #region Grid Methods

    private void GridSelectionChanged(object sender, SelectionChangedEventArgs e) {
      buttonOK.Enabled = ((GridView)sender).SelectedRowsCount > 0;
    }

    #endregion

  }

}
