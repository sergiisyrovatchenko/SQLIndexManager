namespace SQLIndexManager.Core.Server {

  public enum DataCompression {
    DEFAULT = -1,
    NONE = 0,
    ROW = 1,
    PAGE = 2,
    COLUMNSTORE = 3,
    COLUMNSTORE_ARCHIVE = 4
  }

}
