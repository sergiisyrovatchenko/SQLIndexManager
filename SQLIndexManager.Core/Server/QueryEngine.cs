using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SQLIndexManager.Core.Server {

  public static class QueryEngine {

    public static List<Database> GetDatabases(SqlConnection connection) {
      SqlCommand cmd = new SqlCommand(Query.DatabaseList, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet data = new DataSet();
      adapter.Fill(data);

      List<Database> dbs = new List<Database>();
      foreach (DataRow r in data.Tables[0].Rows) {
        dbs.Add(
          new Database {
            DatabaseId    = r.Field<int>(MessageConstants.DatabaseId),
            DatabaseName  = r.Field<string>(MessageConstants.DatabaseName),
            RecoveryModel = r.Field<string>(MessageConstants.RecoveryModel),
            LogReuseWait  = r.Field<string>(MessageConstants.LogReuseWait),
            CreateDate    = r.Field<DateTime>(MessageConstants.CreateDate)
          }
        );
      }

      return dbs;
    }

    public static List<Database> RefreshDatabaseSize(SqlConnection connection, List<Database> dbs) {
      SqlCommand cmd = new SqlCommand(Query.DatabaseSizeList, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet data = new DataSet();
      adapter.Fill(data);

      foreach (DataRow r in data.Tables[0].Rows) {
        int databaseId = r.Field<int>(MessageConstants.DatabaseId);
        Database db = dbs.FirstOrDefault(_ => _.DatabaseId == databaseId);

        if (db != null) {
          db.DataSize     = r.Field<long?>(MessageConstants.DataSize) ?? 0;
          db.DataUsedSize = r.Field<long?>(MessageConstants.DataUsedSize) ?? 0;
          db.LogSize      = r.Field<long?>(MessageConstants.LogSize) ?? 0;
          db.LogUsedSize  = r.Field<long?>(MessageConstants.LogUsedSize) ?? 0;
        }
      }

      return dbs;
    }

    public static List<DiskInfo> GetDiskInfo(SqlConnection connection) {
      List<DiskInfo> di = new List<DiskInfo>();

      if (!Settings.Settings.ServerInfo.IsAzure && Settings.Settings.ServerInfo.IsSysAdmin) {
        SqlCommand cmd = new SqlCommand(Query.DiskInfo, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet data = new DataSet();
        adapter.Fill(data);

        foreach (DataRow _ in data.Tables[0].Rows) {
          di.Add(
            new DiskInfo {
              Drive = _.Field<string>(0),
              FreeSpace = _.Field<int>(1)
            }
          );
        }
      }

      return di;
    }

    public static ServerInfo GetServerInfo(SqlConnection connection) {
      DataSet data = new DataSet();

      SqlCommand cmd = new SqlCommand(Query.ServerInfo, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(data);
      DataRow row = data.Tables[0].Rows[0];

      string serverName = row.Field<string>(MessageConstants.ServerName);
      string productLevel = row.Field<string>(MessageConstants.ProductLevel);
      string productUpdateLevel = row.Field<string>(MessageConstants.ProductUpdateLevel);
      string edition = row.Field<string>(MessageConstants.Edition);
      string serverVersion = row.Field<string>(MessageConstants.ServerVersion);
      bool isSysAdmin = row.Field<bool?>(MessageConstants.IsSysAdmin) ?? false;

      return new ServerInfo(serverName, productLevel, productUpdateLevel, edition, serverVersion, isSysAdmin);
    }

    public static List<Index> GetIndexes(SqlConnection connection) {
      List<int> it = new List<int>();
      if (Settings.Settings.Options.ScanHeap) it.Add((int)IndexType.HEAP);
      if (Settings.Settings.Options.ScanClusteredIndex) it.Add((int)IndexType.CLUSTERED);
      if (Settings.Settings.Options.ScanNonClusteredIndex) it.Add((int)IndexType.NONCLUSTERED);

      if (Settings.Settings.ServerInfo.IsColumnstoreAvailable) {
        if (Settings.Settings.Options.ScanClusteredColumnstore) it.Add((int)IndexType.CLUSTERED_COLUMNSTORE);
        if (Settings.Settings.Options.ScanNonClusteredColumnstore) it.Add((int)IndexType.NONCLUSTERED_COLUMNSTORE);
      }

      int threshold = Settings.Settings.Options.SkipOperation == IndexOp.IGNORE ? Settings.Settings.Options.FirstThreshold : 0;

      List<Index> indexes = new List<Index>();

      if (it.Count > 0) {

        string lob = string.Empty;
        if (Settings.Settings.ServerInfo.IsOnlineRebuildAvailable)
          lob = Settings.Settings.ServerInfo.MajorVersion == ServerVersion.Sql2008 ? Query.Lob2008 : Query.Lob2012Plus;

        string indexStats = Settings.Settings.ServerInfo.IsAzure && connection.Database == MessageConstants.DatamaseMaster
                              ? Query.IndexStatsAzureMaster
                              : Query.IndexStats;

        string indexQuery = Settings.Settings.ServerInfo.MajorVersion == ServerVersion.Sql2008 ? Query.Index2008 : Query.Index2012Plus;

        List<string> excludeObjectMask = Settings.Settings.Options.ExcludeObject.Where(_ => _.Contains("%")).ToList();
        List<string> includeObjectMask = Settings.Settings.Options.IncludeObject.Where(_ => _.Contains("%")).ToList();
        List<string> excludeObjectId = Settings.Settings.Options.ExcludeObject.Where(_ => !_.Contains("%")).ToList();
        List<string> includeObjectId = Settings.Settings.Options.IncludeObject.Where(_ => !_.Contains("%")).ToList();

        string excludeList = string.Empty;
        if (Settings.Settings.Options.ExcludeSchemas.Count > 0)
          excludeList += "OR [schema_id] = SCHEMA_ID(N'" + string.Join("') OR [schema_id] = SCHEMA_ID(N'", Settings.Settings.Options.ExcludeSchemas) + "') ";

        if (excludeObjectMask.Count > 0)
          excludeList += "OR [name] LIKE N'" + string.Join("' OR [name] LIKE N'", excludeObjectMask) + "' ";

        if (excludeObjectId.Count > 0)
          excludeList += "OR [object_id] = OBJECT_ID(N'" + string.Join("') OR [object_id] = OBJECT_ID(N'", excludeObjectId) + "') ";

        string includeListSchemas = Settings.Settings.Options.IncludeSchemas.Count > 0
                                      ? "AND ( [schema_id] = SCHEMA_ID(N'" + string.Join("') OR [schema_id] = SCHEMA_ID(N'", Settings.Settings.Options.IncludeSchemas) + "') ) "
                                      : string.Empty;

        string includeListObject = string.Empty;
        if (includeObjectMask.Count > 0)
          includeListObject += "OR [name] LIKE N'" + string.Join("' OR [name] LIKE N'", includeObjectMask) + "' ";

        if (includeObjectId.Count > 0)
          includeListObject += "OR [object_id] = OBJECT_ID(N'" + string.Join("') OR [object_id] = OBJECT_ID(N'", includeObjectId) + "') ";

        if (!string.IsNullOrEmpty(includeListObject))
          includeListObject = $"AND ( 1 = 0 {includeListObject})";

        int filterRows = Settings.Settings.Options.ShowOnlyMore1000Rows ? 1000 : 0;

        string includeList = string.IsNullOrEmpty(includeListSchemas) && string.IsNullOrEmpty(includeListObject)
                                ? string.Format(Query.IncludeListEmpty, filterRows)
                                : string.Format(Query.IncludeList, filterRows, includeListSchemas, includeListObject);

        string ignoreReadOnlyFL = Settings.Settings.Options.IgnoreReadOnlyFL ? "" : "AND fg.[is_read_only] = 0 ";
        string ignorePermissions = Settings.Settings.Options.IgnorePermissions ? "" : "AND PERMISSIONS(i.[object_id]) & 2 = 2 ";
        string ignoreHeapWithCompression = Settings.Settings.Options.IgnoreHeapWithCompression ? "AND (i.[type] != 0 OR (i.[type] = 0 AND p.DataCompression = 0)) " : "";

        string statsInfo = Settings.Settings.ServerInfo.IsFullStats ? Query.StatsFull : Query.StatsLite;

        string query = string.Format(Query.PreDescribeIndexes,
                                    string.Join(", ", it), excludeList, indexQuery, lob,
                                    indexStats, ignoreReadOnlyFL, ignorePermissions, includeList, ignoreHeapWithCompression, statsInfo);

        SqlCommand cmd = new SqlCommand(query, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };

        cmd.Parameters.Add(new SqlParameter("@Fragmentation",   SqlDbType.Float)         { Value = threshold });
        cmd.Parameters.Add(new SqlParameter("@MinIndexSize",    SqlDbType.BigInt)        { Value = Settings.Settings.Options.MinIndexSize.PageSize() });
        cmd.Parameters.Add(new SqlParameter("@MaxIndexSize",    SqlDbType.BigInt)        { Value = Settings.Settings.Options.MaxIndexSize.PageSize() });
        cmd.Parameters.Add(new SqlParameter("@PreDescribeSize", SqlDbType.BigInt)        { Value = Settings.Settings.Options.PreDescribeSize.PageSize() });
        cmd.Parameters.Add(new SqlParameter("@ScanMode",        SqlDbType.NVarChar, 100) { Value = Settings.Settings.Options.ScanMode });

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet data = new DataSet();
        adapter.Fill(data);

        foreach (DataRow _ in data.Tables[0].AsEnumerable()) {

          IndexType indexType = (IndexType)_.Field<byte>(MessageConstants.IndexType);
          bool isOnlineRebuild = Settings.Settings.ServerInfo.IsOnlineRebuildAvailable;

          if (isOnlineRebuild) {
            if (
                 _.Field<bool>(MessageConstants.IsLobLegacy)
              ||
                 indexType == IndexType.CLUSTERED_COLUMNSTORE
              ||
                 indexType == IndexType.NONCLUSTERED_COLUMNSTORE
            ) {
              isOnlineRebuild = false;
            }
            else {
              isOnlineRebuild =
                     Settings.Settings.ServerInfo.MajorVersion > ServerVersion.Sql2008
                  ||
                     (Settings.Settings.ServerInfo.MajorVersion == ServerVersion.Sql2008 && !_.Field<bool>(MessageConstants.IsLob));
            }
          }

          DateTime? lastWrite = _.Field<DateTime?>(MessageConstants.LastWrite);
          DateTime? lastRead = _.Field<DateTime?>(MessageConstants.LastRead);

          var index = new Index {
            DatabaseName         = connection.Database,
            ObjectId             = _.Field<int>(MessageConstants.ObjectID),
            IndexId              = _.Field<int>(MessageConstants.IndexID),
            IndexName            = _.Field<string>(MessageConstants.IndexName),
            ObjectName           = _.Field<string>(MessageConstants.ObjectName),
            SchemaName           = _.Field<string>(MessageConstants.SchemaName),
            PagesCount           = _.Field<long>(MessageConstants.PagesCount),
            UnusedPagesCount     = _.Field<long>(MessageConstants.UnusedPagesCount),
            PartitionNumber      = _.Field<int>(MessageConstants.PartitionNumber),
            RowsCount            = _.Field<long>(MessageConstants.RowsCount),
            FileGroupName        = _.Field<string>(MessageConstants.FileGroupName),
            IndexType            = indexType,
            IsPartitioned        = _.Field<bool>(MessageConstants.IsPartitioned),
            IsUnique             = _.Field<bool>(MessageConstants.IsUnique),
            IsPK                 = _.Field<bool>(MessageConstants.IsPK),
            IsFiltered           = _.Field<bool>(MessageConstants.IsFiltered),
            FillFactor           = _.Field<int>(MessageConstants.FillFactor),
            IndexStats           = _.Field<DateTime?>(MessageConstants.IndexStats),
            TotalUpdates         = _.Field<long?>(MessageConstants.TotalUpdates),
            TotalSeeks           = _.Field<long?>(MessageConstants.TotalSeeks),
            TotalScans           = _.Field<long?>(MessageConstants.TotalScans),
            TotalLookups         = _.Field<long?>(MessageConstants.TotalLookups),
            LastWrite            = lastWrite,
            LastRead             = lastRead,
            LastUsage            = Nullable.Compare(lastWrite, lastRead) > 0 ? lastWrite : lastRead,
            CreateDate           = _.Field<DateTime>(MessageConstants.CreateDate),
            ModifyDate           = _.Field<DateTime>(MessageConstants.ModifyDate),
            DataCompression      = (DataCompression)_.Field<byte>(MessageConstants.DataCompression),
            Fragmentation        = _.Field<double?>(MessageConstants.Fragmentation),
            PageSpaceUsed        = _.Field<double?>(MessageConstants.PageSpaceUsed),
            IsTable              = _.Field<bool>(MessageConstants.IsTable),
            IsFKs                = _.Field<bool>(MessageConstants.IsFKs),
            IsAllowReorganize    = _.Field<bool>(MessageConstants.IsAllowPageLocks) && indexType != IndexType.HEAP,
            IsAllowOnlineRebuild = isOnlineRebuild,
            IsAllowCompression   = Settings.Settings.ServerInfo.IsCompressionAvailable && !_.Field<bool>(MessageConstants.IsSparse),
            IndexColumns         = _.Field<string>(MessageConstants.IndexColumns),
            IncludedColumns      = _.Field<string>(MessageConstants.IncludedColumns),
            IsNoRecompute        = _.Field<bool?>(MessageConstants.IsNoRecompute),
            StatsSampled         = _.Field<double?>(MessageConstants.StatsSampled),
            RowsSampled          = _.Field<long?>(MessageConstants.RowsSampled)
          };

          indexes.Add(index);
        }
      }

      if (Settings.Settings.Options.ScanMissingIndex && !(Settings.Settings.ServerInfo.IsAzure && connection.Database == MessageConstants.DatamaseMaster)) {

        SqlCommand cmd = new SqlCommand(Query.MissingIndex, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };

        cmd.Parameters.Add(new SqlParameter("@Fragmentation", SqlDbType.Float)  { Value = threshold });
        cmd.Parameters.Add(new SqlParameter("@MinIndexSize",  SqlDbType.BigInt) { Value = Settings.Settings.Options.MinIndexSize.PageSize() });
        cmd.Parameters.Add(new SqlParameter("@MaxIndexSize",  SqlDbType.BigInt) { Value = Settings.Settings.Options.MaxIndexSize.PageSize() });

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet data = new DataSet();
        adapter.Fill(data);

        foreach (DataRow _ in data.Tables[0].AsEnumerable()) {
          string indexCols = _.Field<string>(MessageConstants.IndexColumns);
          string objName = _.Field<string>(MessageConstants.ObjectName);
          string indexName = $"IX_{Guid.NewGuid().ToString().Truncate(5)}_{objName}_{indexCols}"
                                    .Replace(",", "_")
                                    .Replace("[", string.Empty)
                                    .Replace("]", string.Empty)
                                    .Replace(" ", string.Empty).Truncate(240);

          DateTime? lastRead = _.Field<DateTime?>(MessageConstants.LastRead);

          Index index = new Index {
            DatabaseName         = connection.Database,
            ObjectId             = _.Field<int>(MessageConstants.ObjectID),
            IndexName            = indexName,
            ObjectName           = objName,
            SchemaName           = _.Field<string>(MessageConstants.SchemaName),
            PagesCount           = _.Field<long>(MessageConstants.PagesCount),
            RowsCount            = _.Field<long>(MessageConstants.RowsCount),
            FileGroupName        = "PRIMARY",
            IndexType            = IndexType.MISSING_INDEX,
            IndexStats           = _.Field<DateTime?>(MessageConstants.IndexStats),
            TotalSeeks           = _.Field<long?>(MessageConstants.TotalSeeks),
            TotalScans           = _.Field<long?>(MessageConstants.TotalScans),
            LastRead             = lastRead,
            LastUsage            = lastRead,
            DataCompression      = DataCompression.NONE,
            Fragmentation        = _.Field<double>(MessageConstants.Fragmentation),
            IsAllowOnlineRebuild = false,
            IsAllowCompression   = Settings.Settings.ServerInfo.IsCompressionAvailable,
            IndexColumns         = indexCols,
            IncludedColumns      = _.Field<string>(MessageConstants.IncludedColumns)
          };

          indexes.Add(index);
        }
      }

      return indexes;
    }

    public static void GetIndexFragmentation(SqlConnection connection, Index index) {
      SqlCommand cmd = new SqlCommand(Query.IndexFragmentation, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };

      cmd.Parameters.Add(new SqlParameter("@ObjectID",        SqlDbType.Int) { Value = index.ObjectId });
      cmd.Parameters.Add(new SqlParameter("@IndexID",         SqlDbType.Int) { Value = index.IndexId });
      cmd.Parameters.Add(new SqlParameter("@PartitionNumber", SqlDbType.Int) { Value = index.PartitionNumber });
      cmd.Parameters.Add(new SqlParameter("@ScanMode",        SqlDbType.NVarChar, 100) { Value = Settings.Settings.Options.ScanMode });

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet data = new DataSet();
      adapter.Fill(data);

      if (data.Tables.Count == 1 && data.Tables[0].Rows.Count == 1) {
        DataRow row = data.Tables[0].Rows[0];

        index.Fragmentation = row.Field<double>(MessageConstants.Fragmentation);
        index.PageSpaceUsed = row.Field<double?>(MessageConstants.PageSpaceUsed);
      }
    }

    public static void GetColumnstoreFragmentation(SqlConnection connection, Index index, List<Index> indexes) {
      SqlCommand cmd = new SqlCommand(Query.ColumnstoreIndexFragmentation, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };

      int threshold = Settings.Settings.Options.SkipOperation == IndexOp.IGNORE ? Settings.Settings.Options.FirstThreshold : 0;

      cmd.Parameters.Add(new SqlParameter("@ObjectID",      SqlDbType.Int)    { Value = index.ObjectId });
      cmd.Parameters.Add(new SqlParameter("@Fragmentation", SqlDbType.Float)  { Value = threshold });
      cmd.Parameters.Add(new SqlParameter("@MinIndexSize",  SqlDbType.BigInt) { Value = Settings.Settings.Options.MinIndexSize.PageSize() });
      cmd.Parameters.Add(new SqlParameter("@MaxIndexSize",  SqlDbType.BigInt) { Value = Settings.Settings.Options.MaxIndexSize.PageSize() });

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet data = new DataSet();
      adapter.Fill(data);

      foreach(DataRow row in data.Tables[0].Rows) {
        int indexId = row.Field<int>(MessageConstants.IndexID);
        int partitionNumber = row.Field<int>(MessageConstants.PartitionNumber);

        Index idx = indexes.FirstOrDefault(_ => _.ObjectId == index.ObjectId
                                             && _.IndexId == indexId
                                             && _.PartitionNumber == partitionNumber);

        if (idx != null) {
          idx.Fragmentation = row.Field<double>(MessageConstants.Fragmentation);
          idx.PagesCount = row.Field<long>(MessageConstants.PagesCount);
          idx.UnusedPagesCount = row.Field<long>(MessageConstants.UnusedPagesCount);
        }
      }
    }

    public static string FixIndex(SqlConnection connection, Index ix) {
      int indexId = ix.FixType == IndexOp.CREATE_COLUMNSTORE_INDEX && ix.IndexType == IndexType.HEAP ? 1 : ix.IndexId;
      string sql;
      string query = ix.GetQuery();

      if (ix.FixType == IndexOp.DISABLE_INDEX || ix.FixType == IndexOp.DROP_INDEX || ix.FixType == IndexOp.DROP_TABLE || ix.FixType == IndexOp.CREATE_INDEX) {
        sql = query;
      }
      else {
        string sqlInfo;
        if (ix.IsColumnstore)
          sqlInfo = Query.AfterFixColumnstoreIndex;
        else if (Settings.Settings.ServerInfo.IsFullStats && (ix.IndexType == IndexType.CLUSTERED || ix.IndexType == IndexType.NONCLUSTERED) && !ix.IsPartitioned)
          sqlInfo = Query.AfterFixIndexWithStats;
        else
          sqlInfo = Query.AfterFixIndex;

        sql = $"{query} \n {string.Format(sqlInfo, ix.ObjectId, indexId, ix.PartitionNumber, Settings.Settings.Options.ScanMode)}";
      }

      SqlCommand cmd = new SqlCommand(sql, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet data = new DataSet();

      try {
        adapter.Fill(data);
      }
      catch (Exception ex) {
        ix.Error = ex.Message;
      }

      if (string.IsNullOrEmpty(ix.Error)) {
        try {
          if (ix.FixType == IndexOp.CREATE_INDEX) {
            ix.IndexStats = DateTime.UtcNow;
            ix.Fragmentation = 0;
          }
          else if (ix.FixType == IndexOp.DISABLE_INDEX || ix.FixType == IndexOp.DROP_INDEX || ix.FixType == IndexOp.DROP_TABLE || ix.FixType == IndexOp.TRUNCATE_TABLE) {
            ix.PagesCountBefore = ix.PagesCount;
            ix.Fragmentation = 0;
            ix.PagesCount = 0;
            ix.UnusedPagesCount = 0;
            ix.RowsCount = 0;
          }
          else if (data.Tables.Count == 1 && data.Tables[0].Rows.Count == 1) {
            DataRow row = data.Tables[0].Rows[0];

            ix.PagesCountBefore = ix.PagesCount - row.Field<long>(MessageConstants.PagesCount);
            ix.Fragmentation = row.Field<double>(MessageConstants.Fragmentation);
            ix.PageSpaceUsed = row.Field<double?>(MessageConstants.PageSpaceUsed);
            ix.PagesCount = row.Field<long>(MessageConstants.PagesCount);
            ix.UnusedPagesCount = row.Field<long>(MessageConstants.UnusedPagesCount);
            ix.RowsCount = row.Field<long>(MessageConstants.RowsCount);
            ix.DataCompression = ((DataCompression)row.Field<byte>(MessageConstants.DataCompression));
            ix.IndexStats = row.Field<DateTime?>(MessageConstants.IndexStats);
            ix.StatsSampled = row.Field<double?>(MessageConstants.StatsSampled) ?? ix.StatsSampled;
            ix.RowsSampled = row.Field<long?>(MessageConstants.RowsSampled) ?? ix.RowsSampled;

            if (ix.FixType == IndexOp.CREATE_COLUMNSTORE_INDEX) {
              ix.IndexName = "CCL";
              ix.IndexType = IndexType.CLUSTERED_COLUMNSTORE;
            }
          }
        }
        catch (Exception ex) {
          ix.Error = ex.Message;
        }
      }

      return query;
    }

    public static void FindUnusedIndexes(List<Index> indexes) {
      foreach (Index ix in indexes.Where(
                  _ => !_.IsPartitioned
                    && _.Warning == null
                    && _.TotalUpdates > 50000
                    && (_.TotalScans ?? 0) + (_.TotalSeeks ?? 0) < (_.TotalUpdates ?? 0) / 20
                    && (_.IndexType == IndexType.CLUSTERED || _.IndexType == IndexType.NONCLUSTERED || _.IndexType == IndexType.HEAP))) {
        ix.Warning = WarningType.UNUSED;
      }
    }

    public static void FindDublicateIndexes(List<Index> indexes) {
      var data = indexes.Where(_ => !_.IsPartitioned
                                 && _.Warning == null
                                 && (_.IndexType == IndexType.CLUSTERED || _.IndexType == IndexType.NONCLUSTERED))
                        .GroupBy(_ => new { _.DatabaseName, _.ObjectId })
                        .Select(_ => new { _.Key.DatabaseName, _.Key.ObjectId, Indexes = _.ToList() })
                        .Where(_ => _.Indexes.Count > 1);

      foreach (var item in data) {
        foreach (Index a in item.Indexes) {
          if (a.Warning != null) continue;
          foreach (Index b in item.Indexes) {
            if (a != b && b.Warning == null && a.IndexColumns == b.IndexColumns && a.IncludedColumns.Sort() == b.IncludedColumns.Sort())
              a.Warning = b.Warning = WarningType.DUPLICATE;
          }
        }

        foreach (Index a in item.Indexes) {
          foreach (Index b in item.Indexes) {
            if (a != b && b.Warning == null) {
              int len = Math.Min(a.IndexColumns.Length, b.IndexColumns.Length);
              if (a.IndexColumns == b.IndexColumns || a.IndexColumns.Left(len) == b.IndexColumns.Left(len))
                b.Warning = WarningType.OVERLAP;
            }
          }
        }
      }
    }

    private static IndexOp CorrectIndexOp(IndexOp op, Index ix) {
      if (op == IndexOp.NO_ACTION || op == IndexOp.IGNORE || (ix.IsColumnstore && ix.Fragmentation == 0))
        return IndexOp.SKIP;

      if (ix.IndexType == IndexType.MISSING_INDEX)
        return IndexOp.CREATE_INDEX;

      if (op == IndexOp.REORGANIZE && (ix.IsAllowReorganize || ix.IsColumnstore))
        return IndexOp.REORGANIZE;

      if (op == IndexOp.REBUILD && !ix.IsColumnstore && ix.IsAllowCompression) {
        if (Settings.Settings.Options.DataCompression == DataCompression.NONE && ix.DataCompression != DataCompression.NONE)
          return IndexOp.REBUILD_NONE;

        if (Settings.Settings.Options.DataCompression == DataCompression.ROW && ix.DataCompression != DataCompression.ROW)
          return IndexOp.REBUILD_ROW;

        if (Settings.Settings.Options.DataCompression == DataCompression.PAGE && ix.DataCompression != DataCompression.PAGE)
          return IndexOp.REBUILD_PAGE;
      }

      if (op == IndexOp.UPDATE_STATISTICS_FULL || op == IndexOp.UPDATE_STATISTICS_RESAMPLE || op == IndexOp.UPDATE_STATISTICS_SAMPLE) {
        if (!ix.IsPartitioned && (ix.IndexType == IndexType.CLUSTERED || ix.IndexType == IndexType.NONCLUSTERED)) {
          return op;
        }
      }

      return Settings.Settings.Options.Online && ix.IsAllowOnlineRebuild && (op == IndexOp.REBUILD || op == IndexOp.REORGANIZE)
                ? IndexOp.REBUILD_ONLINE
                : IndexOp.REBUILD;
    }

    public static void UpdateFixType(List<Index> indexes) {
      foreach (Index ix in indexes) {
        if (ix.Fragmentation < Settings.Settings.Options.FirstThreshold) {
          ix.FixType = CorrectIndexOp(Settings.Settings.Options.SkipOperation, ix);
        }
        else if (ix.Fragmentation < Settings.Settings.Options.SecondThreshold) {
          ix.FixType = CorrectIndexOp(Settings.Settings.Options.FirstOperation, ix);
        }
        else {
          ix.FixType = CorrectIndexOp(Settings.Settings.Options.SecondOperation, ix);
        }
      }
    }

    public static void KillActiveSessions() {
      if (!Settings.Settings.ServerInfo.IsSysAdmin) return;

      using (SqlConnection connection = ConnectionUtils.Create(Settings.Settings.ActiveHost)) {
        try {
          connection.Open();
          SqlCommand cmd = new SqlCommand(Query.KillActiveSessions, connection) { CommandTimeout = Settings.Settings.Options.CommandTimeout };
          cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 128) { Value = AppInfo.ApplicationName });
          cmd.ExecuteNonQuery();
        }
        catch { }
        finally {
          connection.Close();
        }
      }
    }

  }

}