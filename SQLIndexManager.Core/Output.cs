using System;
using System.Collections.Generic;
using System.IO;

namespace SQLIndexManager.Core {

  public class OutputEvent {

    public DateTime DateTime { get; set; }
    public string Message { get; set; }
    public DateTime? Duration { get; set; }

  }

  public class Output {
    
    private readonly List<IOutputHandler> _outputs = new ();

    public static Output Current { get; } = new ();

    private Output() {
      if (File.Exists(AppInfo.LogFileName)) {
        try {
          File.Delete(AppInfo.LogFileName);
        }
        catch { }
      }
    }

    public void AddOutputHandler(IOutputHandler outputHandler) {
      
      _outputs.Add(outputHandler);
    }

    public void AddCaption(string message) {
      try {
        _outputs.ForEach(x => x.AddCaption(message));
      }
      catch { }
    }

    public void Add(string message, string message2 = null, long? elapsedMilliseconds = null) {
      DateTime now = DateTime.Now;
      DateTime? duration = null;
      string msg = message;

      if (elapsedMilliseconds >= 0) {
        duration = (new DateTime(0)).AddMilliseconds((double)elapsedMilliseconds);
        msg = $"Elapsed time: {duration:HH:mm:ss:fff}. {message}";
      }

      OutputEvent ev = new OutputEvent {
        DateTime = now,
        Message = string.IsNullOrEmpty(message2) ? message : $"{message}{Environment.NewLine}{message2}",
        Duration = duration
      };

      try {
        AddCaption(msg);

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
