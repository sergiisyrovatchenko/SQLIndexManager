using System.ComponentModel;

namespace SQLIndexManager {

  public enum DataCompression {
    [Description("NONE")]
    None = 0,

    [Description("ROW")]
    Row = 1,

    [Description("PAGE")]
    Page = 2,

    [Description("COLUMNSTORE")]
    Columnstore = 3,

    [Description("COLUMNSTORE_ARCHIVE")]
    ColumnstoreArchive = 4
  }

}
