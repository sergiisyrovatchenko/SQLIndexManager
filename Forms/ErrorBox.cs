using DevExpress.XtraEditors;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace SQLIndexManager {

  public partial class ErrorBox : XtraForm {
    public ErrorBox(Exception ex) {
      InitializeComponent();

      edError.Text =
        $"Application has encountered an unexpected error" +
        $"\r\nPlease send error detail to sergey.syrovatchenko@gmail.com" +
        $"\r\n\r\nProduct: {AssemblyProduct}" +
        $"\r\nBuild: {AssemblyVersion}" +
        $"\r\nOS: {Environment.OSVersion}" +
        $"\r\n\r\n{ex.Message}" +
        $"\r\n{ex.Source}" +
        $"\r\n{ex.StackTrace}";
    }

    private static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    private static string AssemblyProduct {
      get {
        var att = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        return ((AssemblyProductAttribute)att[0]).Product;
      }
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
