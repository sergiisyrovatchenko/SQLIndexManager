using System.Runtime.InteropServices;

namespace SQLIndexManager {

  public static class NativeMethods {
    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole();

    [DllImport("kernel32.dll")]
    public static extern bool AttachConsole(uint dwProcessId);

    [DllImport("kernel32.dll")]
    public static extern uint GetLastError();
  }

}
