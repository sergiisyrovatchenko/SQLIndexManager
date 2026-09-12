using System;

namespace SQLIndexManager.Core.Server {

  public class Database {

    public int DatabaseId { get; set; }
    public string DatabaseName { get; set; }
    public string RecoveryModel { get; set; }
    public string LogReuseWait { get; set; }
    public DateTime CreateDate { get; set; }
    public long TotalSize => DataUsedSize + LogSize;
    public long DataSize { get; set; }
    public long DataUsedSize { get; set; }
    public long DataFreeSize => DataSize - DataUsedSize;
    public long LogSize { get; set; }
    public long LogUsedSize { get; set; }
    public long LogFreeSize => LogSize - LogUsedSize;

  }

}