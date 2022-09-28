using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SQLIndexManager.Core;
using SQLIndexManager.Core.Server;
using SQLIndexManager.Core.Settings;
using SQLIndexManager.Properties;

namespace SQLIndexManager.Forms {

  public partial class ErrorBox : XtraForm {

    public ErrorBox(Exception ex) {
      InitializeComponent();

      ServerInfo si = null;
      try { si = Settings.ServerInfo; } catch { }

      edError.Text =
        $"Application has encountered an unexpected error{Environment.NewLine}" +
        $"Please send error detail to {Resources.GitHubLink}{Environment.NewLine}" +
        (si == null ? "" : $"{Environment.NewLine}SQL Server: {si}") +
        $"{Environment.NewLine}Build: {AppInfo.Version}" +
        $"{Environment.NewLine}{Environment.NewLine}{ex.Message}" +
        $"{Environment.NewLine}{ex.Source}" +
        $"{Environment.NewLine}{ex.StackTrace}";
    }

    #region Override Methods

    protected override bool ProcessDialogKey(Keys keyData) {
      if (keyData == Keys.Escape) {
        Close();
        return true;
      }

      return base.ProcessDialogKey(keyData);
    }

    #endregion

  }

}
