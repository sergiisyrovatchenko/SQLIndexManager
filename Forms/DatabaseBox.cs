using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SQLIndexManager {

  public partial class DatabaseBox : XtraForm {

    public DatabaseBox() {
      InitializeComponent();

      if (Settings.ServerInfo.IsAzure || !Settings.ServerInfo.IsSysAdmin) {
        colDataSize.Visible = colLogSize.Visible = false;
        view.SortInfo.Clear();
        view.SortInfo.Add(new GridColumnSortInfo(colDatabase, ColumnSortOrder.Ascending));
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

      colDataSize.Visible = colLogSize.Visible = !Settings.ServerInfo.IsAzure
                                              && Settings.ServerInfo.IsSysAdmin;

      colDataFreeSize.Visible = colLogFreeSize.Visible = scanUsedSpace
                                                      && !Settings.ServerInfo.IsAzure
                                                      && Settings.ServerInfo.IsSysAdmin;

      Stopwatch ts = Stopwatch.StartNew();

      using (SqlConnection connection = Connection.Create(Settings.ActiveHost)) {

        try {
          connection.Open();

          List<Database> dbs = QueryEngine.GetDatabases(connection, scanUsedSpace);
          var max = dbs.Max(_ => Math.Max(_.DataSize, _.LogSize));
          foreach (var rule in view.FormatRules) {
            ((FormatConditionRuleDataBar)rule.Rule).Maximum = max;
          }

          grid.DataSource = dbs;
          Output.Current.Add($"Refresh {dbs.Count} databases", null, ts.ElapsedMilliseconds);

          foreach (string db in Settings.ActiveHost.Databases) {
            int index = view.LocateByValue(colDatabase.FieldName, db);
            view.SelectRow(index);
          }
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

    private void GridCustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
      if (e.Value == null)
        return;
      
      if (   e.Column.FieldName == colDataSize.FieldName
          || e.Column.FieldName == colDataFreeSize.FieldName
          || e.Column.FieldName == colLogSize.FieldName
          || e.Column.FieldName == colLogFreeSize.FieldName
       ) {
        e.DisplayText = (Convert.ToDecimal(e.Value) * 8).FormatSize();
      }
    }

    private void GridSelectionChanged(object sender, SelectionChangedEventArgs e) {
      int[] rows = ((GridView)sender).GetSelectedRows();
      buttonOK.Enabled = rows.Length > 0;
    }

    private void GridDoubleClick(object sender, EventArgs e) {
      GridView obj = (GridView)sender;
      Point pt = obj.GridControl.PointToClient(MousePosition);

      GridHitInfo info = obj.CalcHitInfo(pt);
      if (info.Column == null || info.Column.Caption == @"Selection")
        return;

      if (info.InRow || info.InRowCell) {
        if (obj.IsRowSelected(info.RowHandle))
          obj.UnselectRow(info.RowHandle);
        else
          obj.SelectRow(info.RowHandle);
      }
    }

    #endregion

  }

}
