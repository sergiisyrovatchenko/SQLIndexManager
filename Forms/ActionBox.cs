using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SQLIndexManager {

  public partial class ActionBox : XtraForm {

    public ActionBox() {
      InitializeComponent();

      List<IndexOp> indexOps = new List<IndexOp> { IndexOp.REBUILD, IndexOp.REORGANIZE };
      if (Settings.ServerInfo.IsCompressionAvailable) {
        indexOps.AddRange(new List<IndexOp> {
            IndexOp.REBUILD_ROW,
            IndexOp.REBUILD_PAGE,
            IndexOp.REBUILD_NONE
          }
        );
      }

      if (Settings.ServerInfo.IsColumnstoreAvailable) {
        indexOps.AddRange(new List<IndexOp> {
            IndexOp.REBUILD_COLUMNSTORE,
            IndexOp.REBUILD_COLUMNSTORE_ARCHIVE
          }
        );

        if (Settings.ServerInfo.MajorVersion >= ServerVersion.Sql2016) {
          indexOps.Add(IndexOp.CREATE_COLUMNSTORE_INDEX);
        }
      }

      if (Settings.ServerInfo.IsOnlineRebuildAvailable) {
        indexOps.Add(IndexOp.REBUILD_ONLINE);
      }

      indexOps.AddRange(new List<IndexOp> {
          IndexOp.UPDATE_STATISTICS_SAMPLE,
          IndexOp.UPDATE_STATISTICS_RESAMPLE,
          IndexOp.UPDATE_STATISTICS_FULL,
          IndexOp.DISABLE_INDEX,
          IndexOp.DROP_TABLE,
          IndexOp.SKIP
        }
      );

      foreach (IndexOp op in indexOps) {
        boxFixAction.Properties.Items.Add(op.Description());
      }

      boxFixAction.SelectedIndex = 0;
    }

    public IndexOp GetFixAction() {
      return Utils.GetValueFromDescription<IndexOp>((string)boxFixAction.EditValue);
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

  }

}
