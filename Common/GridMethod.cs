using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SQLIndexManager.Core;
using SQLIndexManager.Core.Server;
using SQLIndexManager.Properties;

namespace SQLIndexManager.Common {

  public static class GridMethod {

    public static void GridRowCellStyle(object sender, RowCellStyleEventArgs e) {
      if (e.RowHandle == ((GridView)sender).FocusedRowHandle) {
        e.Appearance.BackColor = Color.Silver;
      }
    }

    public static void GridDoubleClick(object sender, EventArgs e) {
      GridView obj = (GridView)sender;
      Point pt = obj.GridControl.PointToClient(Control.MousePosition);

      GridHitInfo info = obj.CalcHitInfo(pt);
      if (info.Column == null || info.Column.Caption == Resources.Fix || info.Column.Caption == Resources.Selection)
        return;

      if (info.InRow || info.InRowCell) {
        if (obj.IsRowSelected(info.RowHandle))
          obj.UnselectRow(info.RowHandle);
        else
          obj.SelectRow(info.RowHandle);
      }
    }

    public static void GridColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
      switch (e.Column.FieldName) {
        case "TotalSize":
        case "DataSize":
        case "DataFreeSize":
        case "LogSize":
        case "LogFreeSize":
        case "PagesCount":
        case "PagesCountBefore":
        case "UnusedPagesCount":
          if (e.Value != null)
            e.DisplayText = (Convert.ToDecimal(e.Value) * 8).FormatSize() + " ";
          break;

        case "Fragmentation":
        case "PageSpaceUsed":
        case "StatsSampled":
          if (e.Value != null)
            e.DisplayText = $"{e.Value:n1} % ";
          break;

        case "CreateDate":
        case "ModifyDate":
        case "IndexStats":
        case "LastUsage":
        case "LastWrite":
        case "LastRead":
          if (e.Value != null)
            e.DisplayText = $"{((DateTime)e.Value).ToLocalTime():dd/MM/yy HH:mm}";
          break;

        case "RowsCount":
        case "RowsSampled":
        case "TotalUpdates":
        case "TotalScans":
        case "TotalSeeks":
        case "TotalLookups":
          e.DisplayText = $"{e.Value:n0} ";
          break;

        case "FixType":
          e.DisplayText = ((IndexOp)e.Value).Description();
          break;

        case "Duration":
          if (e.Value != null)
            e.DisplayText = $"{new DateTime(0).AddMilliseconds(Convert.ToInt64(e.Value)):mm:ss.fff}";
          break;
      }
    }

  }
}
