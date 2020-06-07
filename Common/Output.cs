using System;
using System.IO;
using DevExpress.XtraBars;

namespace SQLIndexManager {

  public class OutputEvent {

    public DateTime DateTime { get; set; }
    public string Message { get; set; }
    public DateTime? Duration { get; set; }

  }

  public class Output {

    private static Output _log;
    private BarStaticItem _control;

    public static Output Current => _log ?? (_log = new Output());

    private Output() {
      if (File.Exists(AppInfo.LogFileName)) {
        try {
          File.Delete(AppInfo.LogFileName);
        }
        catch { }
      }
    }

    public void SetOutputControl(BarStaticItem control) {
      _control = control;
    }

    public void AddCaption(string message) {
      try {
        _control.Caption = message;
      }
      catch { }
    }

    public void Add(string message, string message2 = null, long? elapsedMilliseconds = null) {
      DateTime now = DateTime.Now;
      DateTime? duration = null;
      string msg = message;

      if (elapsedMilliseconds >= 0) {
        duration = (new DateTime(0)).AddMilliseconds((double) elapsedMilliseconds);
        msg = $"Elapsed time: {duration:HH:mm:ss:fff}. {message}";
      }

      OutputEvent ev = new OutputEvent {
        DateTime = now,
        Message = string.IsNullOrEmpty(message2) ? message : $"{message}{Environment.NewLine}{message2}",
        Duration = duration
      };

      try {
        if (_control != null) {
          _control.Caption = msg;
        }

        using (StreamWriter sw = File.AppendText(AppInfo.LogFileName)) {
          sw.WriteLine($"{now:HH:mm:ss.fff} - {msg}");
          if (!string.IsNullOrEmpty(message2))
            sw.WriteLine(message2);
        }
      }
      catch { }
    }

  }

}