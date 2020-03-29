using System;
using System.Drawing;

namespace SQLIndexManager {

  public class Index {

    public string DatabaseName { get; set; }
    public int ObjectId { get; set; }
    public int IndexId { get; set; }
    public string IndexName { get; set; }
    public string ObjectName { get; set; }
    public string SchemaName { get; set; }
    public IndexType IndexType { get; set; }

    public double? Fragmentation { get; set; }
    public double? PageSpaceUsed { get; set; }
    public long PagesCount { get; set; }
    public long? PagesCountBefore { get; set; }
    public long UnusedPagesCount { get; set; }
    public int PartitionNumber { get; set; }
    public long RowsCount { get; set; }

    public long? TotalWrites { get; set; }
    public long? TotalReads { get; set; }
    public long? TotalScans { get; set; }
    public long? TotalSeeks { get; set; }
    public long? TotalLookups { get; set; }
    public DateTime? LastUsage { get; set; }
    public DateTime? LastWrite { get; set; }
    public DateTime? LastRead { get; set; }

    public DateTime CreateDate { get; set; }
    public DateTime ModifyDate { get; set; }
    public DataCompression DataCompression { get; set; }
    public int FillFactor { get; set; }
    public DateTime? IndexStats { get; set; }
    public string FileGroupName { get; set; }

    public string IndexColumns { get; set; }
    public string IncludedColumns { get; set; }

    public bool IsPartitioned { get; set; }
    public bool IsUnique { get; set; }
    public bool IsPK { get; set; }
    public bool IsFiltered { get; set; }
    public bool IsAllowReorganize { get; set; }
    public bool IsAllowOnlineRebuild { get; set; }
    public bool IsAllowCompression { get; set; }
    public bool IsColumnstore => (IndexType == IndexType.CLUSTERED_COLUMNSTORE || IndexType == IndexType.NONCLUSTERED_COLUMNSTORE);

    public string Error { get; set; }
    public Image Progress { get; set; }
    public long? Duration { get; set; }
    public IndexOp FixType { get; set; }
    public WarningType? Warning { get; set; }
    public bool IsSelected { get; set; }

    public string GetQuery() {
      string sql = string.Empty;
      string indexName = IndexName.ToQuota();
      string objectName = $"{SchemaName.ToQuota()}.{ObjectName.ToQuota()}";
      string fullIndexName = $"{indexName} ON {objectName}";
      string partition = IsPartitioned ? PartitionNumber.ToString() : "ALL";

      if (IsColumnstore) {

        switch (FixType) {
          case IndexOp.REBUILD:
          case IndexOp.REBUILD_COLUMNSTORE:
          case IndexOp.REBUILD_COLUMNSTORE_ARCHIVE:
            DataCompression compression = (FixType == IndexOp.REBUILD_COLUMNSTORE) ? DataCompression.COLUMNSTORE : DataCompression.COLUMNSTORE_ARCHIVE;
            sql = $"ALTER INDEX {fullIndexName} REBUILD PARTITION = {partition}{Environment.NewLine}    " +
                    $"WITH (DATA_COMPRESSION = {(FixType == IndexOp.REBUILD ? DataCompression : compression)}, MAXDOP = {Settings.Options.MaxDop});";
            break;

          case IndexOp.REORGANIZE:
          case IndexOp.REORGANIZE_COMPRESS_ALL_ROW_GROUPS:
            sql = $"ALTER INDEX {fullIndexName} REORGANIZE PARTITION = {partition}" +
                    $"{(FixType == IndexOp.REORGANIZE_COMPRESS_ALL_ROW_GROUPS ? $"{Environment.NewLine}    WITH (COMPRESS_ALL_ROW_GROUPS = ON)" : "")};";
            break;
        }

      }
      else {

        switch (FixType) {
          case IndexOp.REBUILD:
          case IndexOp.REBUILD_ROW:
          case IndexOp.REBUILD_PAGE:
          case IndexOp.REBUILD_NONE:
          case IndexOp.REBUILD_ONLINE:
          case IndexOp.CREATE_INDEX:

            DataCompression compression;
            if (FixType == IndexOp.REBUILD_PAGE)
              compression = DataCompression.PAGE;
            else if (FixType == IndexOp.REBUILD_ROW)
              compression = DataCompression.ROW;
            else if (FixType == IndexOp.REBUILD_NONE)
              compression = DataCompression.NONE;
            else if (Settings.Options.DataCompression != DataCompression.DEFAULT && FixType != IndexOp.REBUILD)
              compression = Settings.Options.DataCompression;
            else
              compression = DataCompression;

            string onlineRebuild = "OFF";
            if (FixType == IndexOp.REBUILD_ONLINE || (Settings.Options.Online && IsAllowOnlineRebuild)) {
              if (Settings.Options.WaitAtLowPriority && Settings.ServerInfo.MajorVersion >= ServerVersion.Sql2014)
                onlineRebuild = "ON (" +
                                  $"WAIT_AT_LOW_PRIORITY (MAX_DURATION = {Settings.Options.MaxDuration} MINUTES, " +
                                  $"ABORT_AFTER_WAIT = {Settings.Options.AbortAfterWait}))";
              else
                onlineRebuild = "ON";
            }

            string sqlHeader;
            if (IndexType == IndexType.MISSING_INDEX)
              sqlHeader = $"CREATE NONCLUSTERED INDEX {fullIndexName}{Environment.NewLine}    ({IndexColumns}){Environment.NewLine}    " 
                        + (string.IsNullOrEmpty(IncludedColumns) ? "" : $"INCLUDE ({IncludedColumns}){Environment.NewLine}    ");
            else if (IndexType == IndexType.HEAP)
              sqlHeader = $"ALTER TABLE {objectName} REBUILD PARTITION = {partition}{Environment.NewLine}    ";
            else
              sqlHeader = $"ALTER INDEX {fullIndexName} REBUILD PARTITION = {partition}{Environment.NewLine}    ";

            sql = sqlHeader +
                    "WITH (" +
                    (IndexType == IndexType.HEAP
                      ? ""
                      : $"SORT_IN_TEMPDB = {Settings.Options.SortInTempDb.OnOff()}, ") +
                    (IsPartitioned || IndexType == IndexType.HEAP
                      ? ""
                      : $"PAD_INDEX = {Settings.Options.PadIndex.OnOff()}, ") +
                    (IsPartitioned || Settings.Options.FillFactor == 0
                      ? ""
                      : $"FILLFACTOR = {Settings.Options.FillFactor}, ") +
                    (IsPartitioned || Settings.Options.NoRecompute == NoRecompute.DEFAULT || IndexType == IndexType.HEAP
                      ? ""
                      : $"STATISTICS_NORECOMPUTE = {Settings.Options.NoRecompute}, ") +
                    (!IsAllowCompression
                      ? ""
                      : $"DATA_COMPRESSION = {compression}, ") +
                    $"ONLINE = {onlineRebuild}, " +
                    $"MAXDOP = {Settings.Options.MaxDop});";
            break;

          case IndexOp.REORGANIZE:
            sql = $"ALTER INDEX {fullIndexName} REORGANIZE PARTITION = {partition}{Environment.NewLine}    " +
                    $"WITH (LOB_COMPACTION = {Settings.Options.LobCompaction.OnOff()});";
            break;

          case IndexOp.DISABLE_INDEX:
            sql = $"ALTER INDEX {fullIndexName} DISABLE;";
            break;

          case IndexOp.DROP_INDEX:
            sql = $"DROP INDEX {fullIndexName};";
            break;

          case IndexOp.DROP_TABLE:
            sql = $"DROP TABLE {objectName};";
            break;

          case IndexOp.UPDATE_STATISTICS_SAMPLE:
          case IndexOp.UPDATE_STATISTICS_RESAMPLE:
          case IndexOp.UPDATE_STATISTICS_FULL:
            sql = $"UPDATE STATISTICS {objectName} {indexName}{Environment.NewLine}    " + (
                FixType == IndexOp.UPDATE_STATISTICS_SAMPLE
                    ? $"WITH SAMPLE {Settings.Options.SampleStatsPercent} PERCENT;"
                    : (FixType == IndexOp.UPDATE_STATISTICS_FULL ? "WITH FULLSCAN;" : "WITH RESAMPLE;")
            );
            break;
        }

      }

      return sql;
    }

    public override string ToString() {
      return $"{DatabaseName} | {SchemaName}.{ObjectName} " +
             $"| {(string.IsNullOrEmpty(IndexName) ? "Heap" : $"{IndexName}")} {(IsPartitioned ? "[ " + PartitionNumber + " ] " : string.Empty)}" +
             $"| {(Convert.ToDecimal(PagesCount) * 8).FormatSize()}".Replace("'", string.Empty);
    }

  }

}
