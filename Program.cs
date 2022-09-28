﻿using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraSplashScreen;
using SQLIndexManager.Common;
using SQLIndexManager.Console;
using SQLIndexManager.Core;
using SQLIndexManager.Core.CommandLine;
using SQLIndexManager.Core.Settings;
using SQLIndexManager.Forms;

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

        UserLookAndFeel.Default.SetSkinStyle("Office 2016 Dark");

        SplashScreenManager.ShowForm(typeof(SplashScreenBox));
        var mainBox = new MainBox();
        SplashScreenManager.CloseForm();

        Application.Run(mainBox);
      }
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
      UIUtils.ShowErrorFrom(e.Exception);
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
        System.Console.OutputEncoding = (Encoding)System.Console.OutputEncoding.Clone();
    }
  }

}