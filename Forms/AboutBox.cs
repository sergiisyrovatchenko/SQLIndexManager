using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SQLIndexManager {

  public partial class AboutBox : XtraForm {
    public AboutBox() {
      InitializeComponent();

      var assembly = Assembly.GetExecutingAssembly();
      var title = (AssemblyTitleAttribute)assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];
      var product = (AssemblyProductAttribute)assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0];
      var copyright = (AssemblyCopyrightAttribute)assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0];

      labelProductName.Text = title.Title;
      labelProductDescription.Text = product.Product;
      labelCopyright.Text = copyright.Copyright;
      labelVersion.Text = assembly.GetName().Version.ToString();
    }

    private void SqlRu_HyperlinkClick(object sender, HyperlinkClickEventArgs e) {
      Process.Start("www.sql.ru/forum/1312218-a/sql-index-manager-besplatnaya-utilita-po-obsluzhivaniu-indeksov-dlya-sql-server-i-azure");
    }

    private void GitHub_HyperlinkClick(object sender, HyperlinkClickEventArgs e) {
      Process.Start("www.github.com/sergeysyrovatchenko/SQLIndexManager");
    }

    private void LinkedIn_HyperlinkClick(object sender, HyperlinkClickEventArgs e) {
      Process.Start("www.linkedin.com/in/sergeysyrovatchenko");
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
