using System;
using System.Collections.Generic;
using System.IO;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace SQLIndexManager {

  public class OutputEvent {

    public DateTime DateTime { get; set; }
    public string Message { get; set; }
    public DateTime? Duration { get; set; }

  }

  public class Output {

    private static Output _log;
    private readonly List<OutputEvent> _events;
    private BarStaticItem _control;
    private GridControl _secondaryControl;

    public static Output Current => _log ?? (_log = new Output());

    private Output() {
      _events = new List<OutputEvent>();

      if (File.Exists(Settings.LogFileName)) {
        try {
          File.Delete(Settings.LogFileName);
        }
        catch { }
      }
    }

    public void SetOutputControl(BarStaticItem control, GridControl secondaryControl) {
      _control = control;
      _secondaryControl = secondaryControl;
      _secondaryControl.DataSource = _events;
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
        Message = string.IsNullOrEmpty(message2) ? message : $"{message}\n{message2}",
        Duration = duration
      };

      _events.Add(ev);

      try {
        if (_control != null) {
          _control.Caption = msg;
        }

        if (_secondaryControl != null) {
          GridView grid = (GridView)_secondaryControl.MainView;
          grid.RefreshData();
        }

        using (StreamWriter sw = File.AppendText(Settings.LogFileName)) {
          sw.WriteLine($"[ {now:HH:mm:ss.fff} ] {msg}");
          if (!string.IsNullOrEmpty(message2))
            sw.WriteLine(message2);
        }
      }
      catch { }
    }

  }

}