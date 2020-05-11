using DevExpress.XtraSplashScreen;

namespace SQLIndexManager {

  public partial class SplashScreenBox : SplashScreen {

    public SplashScreenBox() {
      InitializeComponent();

      labelProductName.Text = AppInfo.Title;
      labelProductDescription.Text = AppInfo.Product;
      labelCopyright.Text = $"Copyright by {AppInfo.Copyright}";
      labelVersion.Text = AppInfo.Version;
    }

  }

}