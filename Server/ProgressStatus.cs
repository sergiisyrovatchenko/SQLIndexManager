using System.Diagnostics;

namespace SQLIndexManager.Server {

  public class ProgressStatus {

    public int Databases;
    public int Errors;
    public int Indexes;
    public int IndexesTotal;
    public long IndexesSize;
    public long SavedSpace;
    public Stopwatch Duration;

    public ProgressStatus() {
      Databases = 0;
      Errors = 0;
      Indexes = 0;
      IndexesTotal = 0;
      IndexesSize = 0;
      SavedSpace = 0;
      Duration = Stopwatch.StartNew();
    }

  }

}
