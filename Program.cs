using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace SQLIndexManager {

  static class Program {
    [STAThread]
    static void Main() {
      CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      CultureInfo.DefaultThreadCurrentCulture = culture;
      CultureInfo.DefaultThreadCurrentUICulture = culture;

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      Application.ThreadException += Application_ThreadException;
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
      SkinManager.EnableFormSkins();
      UserLookAndFeel.Default.SetSkinStyle("Office 2016 Dark");

      Application.Run(new MainBox());
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
      using (ErrorBox errorBox = new ErrorBox(e.Exception)) {
        errorBox.ShowDialog();
      }
    }
  }

}
