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

          try { _disks = QueryEngine.GetDiskInfo(connection); }
          catch (Exception ex) { Utils.ShowErrorFrom(ex, "Refresh disk info failed"); }

          try { _databases = QueryEngine.GetDatabases(connection); }
          catch (Exception ex) { Utils.ShowErrorFrom(ex, "Refresh databases failed"); }

          if (_databases.Count > 0 && !Settings.ServerInfo.IsAzure) {
            try { QueryEngine.RefreshDatabaseSize(connection, _databases); }
            catch (Exception ex) { Utils.ShowErrorFrom(ex, "Refresh database sizes failed"); }
          }
          
        }
        catch (Exception ex) {
          Utils.ShowErrorFrom(ex, "Refresh failed");
        }
        finally {
          connection.Close();
        }
      }
    }

    private void ScanDatabasesFinish(object sender, RunWorkerCompletedEventArgs e) {
      Text = _disks.Count > 0
          ? $"{Resources.DatabaseBoxTitle}      {string.Join("  |  ", _disks.Select(_ => _.ToString()))}"
          : Resources.DatabaseBoxTitle;

      grid.DataSource = null;

      if (_databases.Count > 0) {
        var max = _databases.Max(_ => _.TotalSize);
        foreach (var rule in view.FormatRules) {
          ((FormatConditionRuleDataBar)rule.Rule).Maximum = max;
        }

        grid.DataSource = _databases;

        foreach (string db in Settings.ActiveHost.Databases) {
          int index = view.LocateByValue(DatabaseName.FieldName, db);
          view.SelectRow(index);
        }
      }

      _ts.Stop();
      buttonRefresh.Enabled = true;
      Output.Current.Add($"Found {_databases.Count} databases", null, _ts.ElapsedMilliseconds);
    }

    private void RefreshDatabases() {
      if (_workerScan != null && _workerScan.IsBusy) return;

      Output.Current.Add("Refresh databases...");

      _ts = Stopwatch.StartNew();
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

    protected override bool ProcessKeyPreview(ref Message m) {
      if ((Keys)m.WParam == Keys.F5) {
        RefreshDatabases();
        return true;
      }

      return base.ProcessKeyPreview(ref m);
    }

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
