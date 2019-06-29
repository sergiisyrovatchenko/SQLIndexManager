using DevExpress.XtraEditors;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace SQLIndexManager {

  public partial class ErrorBox : XtraForm {
    public ErrorBox(Exception ex) {
      InitializeComponent();

      edError.Text =
        @"Application has encountered an unexpected error" +
        @"\r\nPlease send error detail to sergey.syrovatchenko@gmail.com" +
        $@"\r\nBuild: {AssemblyVersion}" +
        $@"\r\nOS: {Environment.OSVersion}" +
        $@"\r\n\r\n{ex.Message}" +
        $@"\r\n{ex.Source}" +
        $@"\r\n{ex.StackTrace}";
    }

    private static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

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
