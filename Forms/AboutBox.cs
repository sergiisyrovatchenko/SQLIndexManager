using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using SQLIndexManager.Properties;

namespace SQLIndexManager {

  public partial class AboutBox : XtraForm {

    public AboutBox() {
      InitializeComponent();

      labelProductName.Text = AppInfo.Title;
      labelProductDescription.Text = AppInfo.Product;
      labelCopyright.Text = $"Copyright by {AppInfo.Copyright}";
      labelVersion.Text = AppInfo.Version;
    }

    private void GitHub_HyperlinkClick(object sender, HyperlinkClickEventArgs e) {
      try {
        Process.Start(Resources.GitHubLink);
      }
      catch (Exception ex) {
        Output.Current.Add($"Error: {ex.Source}", ex.Message);
        XtraMessageBox.Show(ex.Message.Replace(". ", "." + Environment.NewLine), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
