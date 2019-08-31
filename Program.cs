using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SQLIndexManager {

  static class Program {

    [STAThread]
    static void Main(string[] args) {
      CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      CultureInfo.DefaultThreadCurrentCulture = culture;
      CultureInfo.DefaultThreadCurrentUICulture = culture;

      if (args != null && args.Length > 0) {
        Settings.IgnoreFileSetting = true;
        Output.Current.Add($"Command line: {string.Join(" ", args)}");

        try {
          AttachConsole();
          var provider = new CmdWorker(CmdParser.Parse(args));
          Environment.Exit(provider.FixIndexes());
        }
        catch (Exception ex) {
          Output.Current.Add(ex.Message);
        }
      }
      else {
        Application.ThreadException += Application_ThreadException;
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        SkinManager.EnableFormSkins();
        UserLookAndFeel.Default.SetSkinStyle("Office 2016 Dark");

        Application.Run(new MainBox());
      }
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
      using (ErrorBox errorBox = new ErrorBox(e.Exception)) {
        errorBox.ShowDialog();
      }
    }

    private static void AttachConsole() {
      const uint attachParentProcess = 0xffffffff;
      const uint errorSuccess = 0;
      const uint errorAccessDenied = 5;

      bool consoleAttached = NativeMethods.AttachConsole(attachParentProcess);
      if (consoleAttached) return;

      var error = NativeMethods.GetLastError();
      if (error == errorSuccess || error == errorAccessDenied)
        consoleAttached = true;

      if (!consoleAttached && !NativeMethods.AllocConsole())
        Environment.Exit(1);
      else
        Console.OutputEncoding = (Encoding)Console.OutputEncoding.Clone();
    }

  }

}