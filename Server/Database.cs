namespace SQLIndexManager {

  public class Database {
    public string DatabaseName { get; set; }
    public string RecoveryModel { get; set; }
    public long? DataSize { get; set; }
    public long? LogSize { get; set; }
  }

}