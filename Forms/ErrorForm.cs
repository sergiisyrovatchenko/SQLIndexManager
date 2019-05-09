using System.Reflection;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System;

namespace SQLIndexManager {
  public partial class ErrorForm : XtraForm {
    public ErrorForm(Exception ex) {
      InitializeComponent();

      edError.Text = $"Applicatin has encountered an unexpected error." +
        $" \r\nPlease send error detail to dbmole@dmail.com" +
        $" \r\n\r\n{ex.Message}" +
        $" \r\n{ex.Source}" +
        $" \r\n{ex.StackTrace}";
    }

    private static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    private static string AssemblyProduct {
      get {
        var att = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        return ((AssemblyProductAttribute)att[0]).Product;
      }
    }

    private static string AssemblyCopyright {
      get {
        var att = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        return ((AssemblyCopyrightAttribute)att[0]).Copyright;
      }
    }

    protected override bool ProcessDialogKey(Keys keyData) {
      if (keyData == Keys.Escape) {
        Close();
        return true;
      }

      return base.ProcessDialogKey(keyData);
    }
  }
}
