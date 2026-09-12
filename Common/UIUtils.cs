using System;
using SQLIndexManager.Core;
using SQLIndexManager.Forms;

namespace SQLIndexManager.Common {
  
  public static class UIUtils {
    
    public static void ShowErrorFrom(Exception e, string message = "Error") {
      Output.Current.Add($"{message}: {e.Source}", e.Message);
      using (ErrorBox errorBox = new ErrorBox(e)) {
        errorBox.ShowDialog();
      }
    }
  }
}
