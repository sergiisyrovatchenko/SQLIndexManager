namespace SQLIndexManager {

  public class Database {
    public string DatabaseName { get; set; }
    public string RecoveryModel { get; set; }
    public string LogReuseWait { get; set; }
    public long DataSize { get; set; }
    public long DataFreeSize { get; set; }
    public long LogSize { get; set; }
    public long LogFreeSize { get; set; }
  }

}