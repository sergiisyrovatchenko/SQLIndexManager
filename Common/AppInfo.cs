using System.Reflection;

namespace SQLIndexManager {

  public static class AppInfo {

    public static string Title => ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
    public static string Product => ((AssemblyProductAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0]).Product;
    public static string Copyright => ((AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright;
    public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

  }

}
