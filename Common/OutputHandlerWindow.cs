using DevExpress.XtraBars;
using SQLIndexManager.Core;

namespace SQLIndexManager.Common {
  public class OutputHandlerWindow : IOutputHandler {
    
    private readonly BarStaticItem _control;

    public OutputHandlerWindow(BarStaticItem control) {

      _control = control;
    }
    
    public void AddCaption(string message) {

      _control.Caption = message;
    }
  }
}
