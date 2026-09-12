namespace SQLIndexManager.Core.Server {

  public enum IndexType {
    MISSING_INDEX = -1,
    HEAP = 0,
    CLUSTERED = 1,
    NONCLUSTERED = 2,
    CLUSTERED_COLUMNSTORE = 5,
    NONCLUSTERED_COLUMNSTORE = 6
  }

}
