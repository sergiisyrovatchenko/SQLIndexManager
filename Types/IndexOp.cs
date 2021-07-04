using System.ComponentModel;

namespace SQLIndexManager {

  public enum IndexOp {
    [Description("REBUILD")]
    REBUILD = 0,

    [Description("REBUILD (COMPRESSION = ROW)")]
    REBUILD_ROW = 1,

    [Description("REBUILD (COMPRESSION = PAGE)")]
    REBUILD_PAGE = 2,

    [Description("REBUILD (COMPRESSION = NONE)")]
    REBUILD_NONE = 3,

    [Description("REBUILD (COMPRESSION = COLUMNSTORE)")]
    REBUILD_COLUMNSTORE = 4,

    [Description("REBUILD (COMPRESSION = COLUMNSTORE_ARCHIVE)")]
    REBUILD_COLUMNSTORE_ARCHIVE = 5,

    [Description("REORGANIZE")]
    REORGANIZE = 6,

    [Description("REORGANIZE (COMPRESS_ALL_ROW_GROUPS = ON)")]
    REORGANIZE_COMPRESS_ALL_ROW_GROUPS = 7,

    [Description("REBUILD (ONLINE = ON)")]
    REBUILD_ONLINE = 8,

    [Description("UPDATE STATISTICS SAMPLE")]
    UPDATE_STATISTICS_SAMPLE = 9,

    [Description("UPDATE STATISTICS RESAMPLE")]
    UPDATE_STATISTICS_RESAMPLE = 10,

    [Description("UPDATE STATISTICS FULL")]
    UPDATE_STATISTICS_FULL = 11,

    [Description("DISABLE INDEX")]
    DISABLE_INDEX = 12,

    [Description("DROP INDEX")]
    DROP_INDEX = 13,

    [Description("CREATE INDEX")]
    CREATE_INDEX = 14,

    [Description("DROP TABLE")]
    DROP_TABLE = 15,

    [Description("NO ACTION")]
    NO_ACTION = 16,

    [Description("IGNORE")]
    IGNORE = 17,

    [Description("SKIP")]
    SKIP = 18,

    [Description("CREATE COLUMNSTORE INDEX")]
    CREATE_COLUMNSTORE_INDEX = 19,

    [Description("TRUNCATE TABLE")]
    TRUNCATE_TABLE = 20
  }

}
