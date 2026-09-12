using System.ComponentModel;
using System.Threading;

namespace SQLIndexManager.Common {

  public class ThreadWorker : BackgroundWorker {

    private Thread _workerThread;

    protected override void OnDoWork(DoWorkEventArgs e) {
      _workerThread = Thread.CurrentThread;
      try {
        base.OnDoWork(e);
      }
      catch (ThreadAbortException) {
        e.Cancel = true;
        Thread.ResetAbort();
      }
    }

    public void Abort() {
      if (_workerThread != null && _workerThread.IsAlive) {
        _workerThread.Abort();
        _workerThread.Join(500);
        _workerThread = null;
      }
    }

  }

}