using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SQLIndexManager {

  public partial class AboutBox : XtraForm {
    const string Mail = "sergey.syrovatchenko@gmail.com";

    public AboutBox() {
      InitializeComponent();

      var assembly = Assembly.GetExecutingAssembly();
      var title = (AssemblyTitleAttribute)assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];
      var product = (AssemblyProductAttribute)assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0];
      var copyright = (AssemblyCopyrightAttribute)assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0];

      labelMail.Text = Mail;
      labelProductName.Text = title.Title;
      labelProductDescription.Text = product.Product;
      labelCopyright.Text = copyright.Copyright;
      labelVersion.Text = assembly.GetName().Version.ToString();
    }

    private void labelMail_HyperlinkClick(object sender, HyperlinkClickEventArgs e) {
      Process.Start($"mailto:{Mail}");
    }

    private void Copyright_HyperlinkClick(object sender, HyperlinkClickEventArgs e) {
      Process.Start("www.linkedin.com/in/sergeysyrovatchenko");
    }

    private void GitHub_HyperlinkClick(object sender, HyperlinkClickEventArgs e) {
      Process.Start("www.github.com/sergeysyrovatchenko/SQLIndexManager");
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
