using System.ComponentModel;

namespace SQLIndexManager {

  public enum IndexOp {
    [Description("REBUILD")]
    Rebuild = 0,

    [Description("REBUILD (COMPRESSION = ROW)")]
    RebuildRow = 1,

    [Description("REBUILD (COMPRESSION = PAGE)")]
    RebuildPage = 2,

    [Description("REBUILD (COMPRESSION = NONE)")]
    RebuildNone = 3,

    [Description("REBUILD (COMPRESSION = COLUMNSTORE)")]
    RebuildColumnstore = 4,

    [Description("REBUILD (COMPRESSION = COLUMNSTORE_ARCHIVE)")]
    RebuildColumnstoreArchive = 5,

    [Description("REORGANIZE")]
    Reorganize = 6,

    [Description("REORGANIZE (COMPRESS_ALL_ROW_GROUPS = ON)")]
    ReorganizeCompressAllRowGroup = 7,

    [Description("REBUILD (ONLINE = ON)")]
    RebuildOnline = 8,

    [Description("REBUILD (FILLFACTOR = 100)")]
    RebuildFillFactorZero = 9,

    [Description("UPDATE STATISTICS SAMPLE")]
    UpdateStatsSample = 10,

    [Description("UPDATE STATISTICS RESAMPLE")]
    UpdateStatsResample = 11,

    [Description("UPDATE STATISTICS FULL")]
    UpdateStatsFull = 12,

    [Description("DISABLE")]
    Disable = 13,

    [Description("DROP")]
    Drop = 14
  }

}
