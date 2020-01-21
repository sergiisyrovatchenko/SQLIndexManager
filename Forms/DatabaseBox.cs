using System;
using System.Collections.Generic;
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

    private void RefreshDatabases() {
      Stopwatch ts = Stopwatch.StartNew();
      Output.Current.Add("Refresh databases");

      grid.DataSource = null;
      buttonOK.Enabled = false;
      TotalSize.Visible = DataSize.Visible = LogSize.Visible = DataFreeSize.Visible = LogFreeSize.Visible = !Settings.ServerInfo.IsAzure;

      using (SqlConnection connection = Connection.Create(Settings.ActiveHost)) {
        try {
          connection.Open();

          if (!Settings.ServerInfo.IsAzure && Settings.ServerInfo.IsSysAdmin) {
            Output.Current.Add("Get disk info");
            try {
              List<DiskInfo> di = QueryEngine.GetDiskInfo(connection);
              if (di.Count > 0) {
                Text = $"{Resources.DatabaseBoxTitle}      {string.Join("  |  ", di.Select(_ => _.ToString()))}";
              }
            }
            catch (Exception ex) {
              Output.Current.Add("Refresh disk info failed", ex.Message);
            }
          }

          List<Database> dbs = QueryEngine.GetDatabases(connection);
          var max = dbs.Max(_ => _.TotalSize);
          foreach (var rule in view.FormatRules) {
            ((FormatConditionRuleDataBar)rule.Rule).Maximum = max;
          }

          grid.DataSource = dbs;

          foreach (string db in Settings.ActiveHost.Databases) {
            int index = view.LocateByValue(DatabaseName.FieldName, db);
            view.SelectRow(index);
          }

          Output.Current.Add($"Found {dbs.Count} databases", null, ts.ElapsedMilliseconds);
        }
        catch (Exception ex) {
          Output.Current.Add("Refresh databases failed", ex.Message, ts.ElapsedMilliseconds);
          XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally {
          connection.Close();
        }
      }
    }

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
