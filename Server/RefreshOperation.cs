using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQLIndexManager.Common {

  public class RefreshOperation : BackgroundWorker {

    private List<string> databases;
    private Host host;
    private List<Index> indexes;
    private bool canceled;
    ThreadWorker currentWorker;

    public RefreshOperation(Host host, List<string> databases) {

      this.host = host;
      this.databases = databases;
    }

    public RunWorkerCompletedEventHandler FinishScan;

    public void Cancel() {

      canceled = true;
      currentWorker.Abort();
    }

    public void Start(ProgressBox progress) {

      Queue<ThreadWorker> threadQueue = new Queue<ThreadWorker>();
      for (int i = 0; i < databases.Count; i++) {
        string database = databases[i];

        ThreadWorker _worker = new ThreadWorker() { WorkerReportsProgress = true };
        _worker.DoWork += StartScan;
        _worker.ProgressChanged += progress.ProgressChanged;
        threadQueue.Enqueue(_worker);
      }

      SqlConnection connection = Connection.Create(host, ConnectionType.DefaultDatabase);

      foreach (var _worker in threadQueue) {

          _worker.RunWorkerCompleted += progress.FinishScan;
          if (!canceled)
            try {
              connection.Open();
              currentWorker = _worker;
              _worker.RunWorkerAsync();
            }
            finally {
              connection.Close();
            }
        }
        OnFinish();
      }

    private void StartScan(object sender, DoWorkEventArgs e) {

      if (e.Cancel)
        return;
      BackgroundWorker worker = (BackgroundWorker)sender;

      if (!Database.Check(connection, database)) {
        worker.ReportProgress(0, $"Database {database} is not accessible.");
      }
      else {
        worker.ReportProgress(0, $"Scan indexes {database}");

        if (progress.InvokeRequired)
            progress.Invoke(new Action(() => progress.Text = string.Format((databases.Count == 1 ? "{2}" : "{0} / {1} - {2}"), i + 1, databases.Count, database)));


          if (e.Cancel)
            return;
          host.Database = database;

          DataTable dt = QueryEngine.GetIndexes(host);
          List<Index> idx = IndexInfoBuilder.GetIndexes(dt, host);

          if (progress.InvokeRequired)
            progress.Invoke(new Action(() => progress.Properties.Maximum = idx.Count));

          int cnt = idx.Count - idx.Count(_ => _.Fragmentation == null);

          if (e.Cancel)
            return;

          foreach (Index index in idx.Where(_ => _.Fragmentation == null)) {
            worker.ReportProgress(cnt++, index.ToString());
            QueryEngine.GetIndexFragmentation(index, host);
          }

          worker.ReportProgress(cnt, "Scan finished");

          lock (indexes) {
            indexes.AddRange(idx);
          }
        }
    }

    private void OnFinish() {

      if (FinishScan != null)
        FinishScan(this, new RunWorkerCompletedEventArgs(indexes, null, canceled));
    }
  }
}
