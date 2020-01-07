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

namespace SQLIndexManager {

  public partial class DatabaseBox : XtraForm {

    public DatabaseBox() {
      InitializeComponent();

      view.CustomColumnDisplayText += GridMethod.GridColumnDisplayText;
      view.RowCellStyle += GridMethod.GridRowCellStyle;
      view.DoubleClick += GridMethod.GridDoubleClick;

      if (Settings.ServerInfo.IsAzure || !Settings.ServerInfo.IsSysAdmin) {
        DataSize.Visible = LogSize.Visible = false;
        view.SortInfo.Clear();
        view.SortInfo.Add(new GridColumnSortInfo(DatabaseName, ColumnSortOrder.Ascending));
      }

      RefreshDatabases(false);
    }

    private void ButtonRefreshClick(object sender, EventArgs e) {
      RefreshDatabases(true);
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

    private void RefreshDatabases(bool scanUsedSpace) {
      grid.DataSource = null;
      buttonOK.Enabled = false;

      DataSize.Visible = LogSize.Visible = !Settings.ServerInfo.IsAzure && Settings.ServerInfo.IsSysAdmin;
      DataFreeSize.Visible = LogFreeSize.Visible = !Settings.ServerInfo.IsAzure && Settings.ServerInfo.IsSysAdmin && scanUsedSpace;

      Stopwatch ts = Stopwatch.StartNew();
      Output.Current.Add("Refresh databases");

      using (SqlConnection connection = Connection.Create(Settings.ActiveHost)) {
        try {
          connection.Open();

          List<Database> dbs = QueryEngine.GetDatabases(connection, scanUsedSpace);
          var max = dbs.Max(_ => Math.Max(_.DataSize, _.LogSize));
          foreach (var rule in view.FormatRules) {
            ((FormatConditionRuleDataBar)rule.Rule).Maximum = max;
          }

          grid.DataSource = dbs;

          foreach (string db in Settings.ActiveHost.Databases) {
            int index = view.LocateByValue(DatabaseName.FieldName, db);
            view.SelectRow(index);
          }

          Output.Current.Add($"Refreshed {dbs.Count} databases", null, ts.ElapsedMilliseconds);
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
