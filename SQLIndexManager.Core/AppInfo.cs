using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SQLIndexManager.Core {

  public static class AppInfo {

    public static string Title => ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
    public static string Product => ((AssemblyProductAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;
    public static string Copyright => ((AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;
    public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    private static string ExeName => Process.GetCurrentProcess().ProcessName;
    private static string ExePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    public static string ApplicationName => $"{ExeName}-{Process.GetCurrentProcess().Id}";
    public static readonly string LayoutFileName = $"{ExePath}\\{ExeName}.layout";
    public static readonly string SettingFileName = $"{ExePath}\\{ExeName}.cfg";
    public static readonly string LogFileName = $"{ExePath}\\{ExeName}.log";

  }

}
