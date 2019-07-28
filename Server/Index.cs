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
    public bool IsColumnstore => (IndexType == IndexType.ColumnstoreClustered || IndexType == IndexType.ColumnstoreNonClustered);

    public string Error { get; set; }
    public Image Progress { get; set; }
    public DateTime? Duration { get; set; }
    public IndexOp FixType { get; set; }
    public WarningType? Warning { get; set; }
    public bool IsSelected { get; set; }

    public string GetQuery() {
      string sql = string.Empty;
      string indexName = IndexName.ToQuota();
      string schemaName = SchemaName.ToQuota();
      string objectName = ObjectName.ToQuota();
      string partition = IsPartitioned ? PartitionNumber.ToString() : "ALL";
      DataCompression compression = DataCompression;

      if (IsColumnstore) {

        if (FixType == IndexOp.RebuildColumnstore)
          compression = DataCompression.Columnstore;

        if (FixType == IndexOp.RebuildColumnstoreArchive)
          compression = DataCompression.ColumnstoreArchive;

        switch (FixType) {
          case IndexOp.Rebuild:
          case IndexOp.RebuildColumnstore:
          case IndexOp.RebuildColumnstoreArchive:
            sql = $"ALTER INDEX [{indexName}]\n    " +
                    $"ON [{schemaName}].[{objectName}] REBUILD PARTITION = {partition}\n    " +
                    $"WITH (DATA_COMPRESSION = {compression.ToDescription()}, MAXDOP = {Settings.Options.MaxDop});";
            break;

          case IndexOp.Reorganize:
            sql = $"ALTER INDEX [{indexName}]\n    " +
                    $"ON [{schemaName}].[{objectName}] REORGANIZE PARTITION = {partition};";
            break;

          case IndexOp.ReorganizeCompressAllRowGroup:
            sql = $"ALTER INDEX [{indexName}]\n    " +
                    $"ON [{schemaName}].[{objectName}] REORGANIZE PARTITION = {partition}\n    " +
                    "WITH (COMPRESS_ALL_ROW_GROUPS = ON);";
            break;
        }
      }
      else {

        if (FixType == IndexOp.RebuildPage)
          compression = DataCompression.Page;
        else if (FixType == IndexOp.RebuildRow)
          compression = DataCompression.Row;
        else if (FixType == IndexOp.RebuildNone)
          compression = DataCompression.None;

        switch (FixType) {
          case IndexOp.CreateIndex:
            bool isCreateOnline = Settings.ServerInfo.MajorVersion > Server.Sql2008 
                               && Settings.ServerInfo.IsOnlineRebuildAvailable
                               && Settings.Options.Online;

            sql = $"CREATE NONCLUSTERED INDEX [{indexName}]\n" +
                    $"ON [{schemaName}].[{objectName}] ({IndexColumns})\n" +
                    (string.IsNullOrEmpty(IncludedColumns) ? "" : $"INCLUDE({IncludedColumns})\n") +
                    $"WITH (SORT_IN_TEMPDB = {(Settings.Options.SortInTempDb ? Options.ON : Options.OFF)}, " +
                    $"ONLINE = {(isCreateOnline ? Options.ON : Options.OFF)}, " +
                    (Settings.Options.FillFactor.IsBetween(1, 100)
                            ? $"FILLFACTOR = {Settings.Options.FillFactor}, "
                            : ""
                          ) +
                    (Settings.Options.DataCompression == Options.DEFAULT
                            ? ""
                            : $"DATA_COMPRESSION = {Settings.Options.DataCompression}, "
                          ) +
                    (Settings.Options.NoRecompute == Options.DEFAULT && !IsPartitioned
                            ? ""
                            : $"STATISTICS_NORECOMPUTE = {Settings.Options.NoRecompute}, "
                          ) +
                    $"MAXDOP = {Settings.Options.MaxDop});";
            break;

          case IndexOp.Rebuild:
          case IndexOp.RebuildPage:
          case IndexOp.RebuildRow:
          case IndexOp.RebuildNone:
          case IndexOp.RebuildOnline:
          case IndexOp.RebuildFillFactorZero:
            if (IndexType == IndexType.Heap) {
              sql = $"ALTER TABLE [{schemaName}].[{objectName}] REBUILD PARTITION = {partition}\n    " +
                      $"WITH (DATA_COMPRESSION = {compression.ToDescription()}, MAXDOP = {Settings.Options.MaxDop});";
            }
            else {
              string onlineRebuild = "OFF";
              if (FixType == IndexOp.RebuildOnline) {
                if (Settings.Options.WaitAtLowPriority && Settings.ServerInfo.MajorVersion >= Server.Sql2014)
                  onlineRebuild = $"ON (" +
                                    $"WAIT_AT_LOW_PRIORITY(MAX_DURATION = {Settings.Options.MaxDuration} MINUTES, " +
                                    $"ABORT_AFTER_WAIT = {Settings.Options.AbortAfterWait}))";
                else
                  onlineRebuild = Options.ON;
              }

              sql = $"ALTER INDEX [{indexName}]\n    " +
                      $"ON [{schemaName}].[{objectName}] REBUILD PARTITION = {partition}\n    " +
                      $"WITH (SORT_IN_TEMPDB = {(Settings.Options.SortInTempDb ? Options.ON : Options.OFF)}, " +
                      $"ONLINE = {onlineRebuild}, " +
                      (Settings.Options.NoRecompute == Options.DEFAULT && !IsPartitioned
                            ? ""
                            : $"STATISTICS_NORECOMPUTE = {Settings.Options.NoRecompute}, "
                          ) +
                      (FixType == IndexOp.RebuildFillFactorZero 
                            ? "FILLFACTOR = 100, "
                            : (Settings.Options.FillFactor.IsBetween(1, 100) 
                                  ? $"FILLFACTOR = {Settings.Options.FillFactor}, "
                                  : ""
                              )
                       ) +
                      $"DATA_COMPRESSION = {compression.ToDescription()}, " +
                      $"MAXDOP = {Settings.Options.MaxDop});";
            }
            break;

          case IndexOp.Reorganize:
            sql = $"ALTER INDEX [{indexName}]\n    " +
                    $"ON [{schemaName}].[{objectName}] REORGANIZE PARTITION = {partition}\n    " +
                    $"WITH (LOB_COMPACTION = {(Settings.Options.LobCompaction ? Options.ON : Options.OFF)});";
            break;

          case IndexOp.Disable:
            sql = $"ALTER INDEX [{indexName}] ON [{schemaName}].[{objectName}] DISABLE;";
            break;

          case IndexOp.Drop:
            sql = $"DROP INDEX [{indexName}] ON [{schemaName}].[{objectName}];";
            break;

          case IndexOp.UpdateStatsSample:
          case IndexOp.UpdateStatsResample:
          case IndexOp.UpdateStatsFull:
            sql = $"UPDATE STATISTICS [{schemaName}].[{objectName}] [{indexName}]\n    " + (
                FixType == IndexOp.UpdateStatsSample
                    ? $"WITH SAMPLE {Settings.Options.SampleStatsPercent} PERCENT;"
                    : (FixType == IndexOp.UpdateStatsFull ? "WITH FULLSCAN;" : "WITH RESAMPLE;")
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
