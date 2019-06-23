using System.ComponentModel;

namespace SQLIndexManager {

  public enum IndexType {
    [Description("MISSING INDEX")]
    MissingIndex = -1,

    [Description("HEAP")]
    Heap = 0,

    [Description("CLUSTERED")]
    Clustered = 1,

    [Description("NONCLUSTERED")]
    NonClustered = 2,

    [Description("CLUSTERED COLUMNSTORE")]
    ColumnstoreClustered = 5,

    [Description("NONCLUSTERED COLUMNSTORE")]
    ColumnstoreNonClustered = 6
  }

}
