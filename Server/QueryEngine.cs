using SQLIndexManager.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SQLIndexManager {

  public static class QueryEngine {

    public static List<Database> GetDatabases(SqlConnection connection, bool scanUsedSpace) {
      string query = !Settings.ServerInfo.IsAzure && Settings.ServerInfo.IsSysAdmin 
                        ? (scanUsedSpace ? Query.DatabaseFullList : Query.DatabaseList)
                        : Query.DatabaseListAzure;

      SqlCommand cmd = new SqlCommand(query, connection) { CommandTimeout = Settings.Options.CommandTimeout };

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet data = new DataSet();
      adapter.Fill(data);

      List<Database> dbs = new List<Database>();
      foreach (DataRow _ in data.Tables[0].Rows) {
        long dataSize = _.Field<long?>(Resources.DataSize) ?? 0;
        long logSize = _.Field<long?>(Resources.LogSize) ?? 0;

        dbs.Add(
          new Database {
            DatabaseName  = _.Field<string>(Resources.DatabaseName),
            RecoveryModel = _.Field<string>(Resources.RecoveryModel),
            LogReuseWait  = _.Field<string>(Resources.LogReuseWait),
            DataSize      = dataSize,
            DataFreeSize  = dataSize - (_.Field<long?>(Resources.DataUsedSize) ?? 0),
            LogSize       = logSize,
            LogFreeSize   = logSize - (_.Field<long?>(Resources.LogUsedSize) ?? 0)
          }
        );
      }

      return dbs;
    }

    public static ServerInfo GetServerInfo(SqlConnection connection) {
      DataSet data = new DataSet();

      SqlCommand cmd = new SqlCommand(Query.ServerInfo, connection) { CommandTimeout = Settings.Options.CommandTimeout };

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(data);
      DataRow row = data.Tables[0].Rows[0];

      string productLevel = row.Field<string>(Resources.ProductLevel);
      string edition = row.Field<string>(Resources.Edition);
      string serverVersion = row.Field<string>(Resources.ServerVersion);
      bool isSysAdmin = row.Field<bool?>(Resources.IsSysAdmin) ?? false;

      return new ServerInfo(productLevel, edition, serverVersion, isSysAdmin);
    }

    public static List<Index> GetIndexes(SqlConnection connection) {
      List<int> it = new List<int>();
      if (Settings.Options.ScanHeap) it.Add((int)IndexType.Heap);
      if (Settings.Options.ScanClusteredIndex) it.Add((int)IndexType.Clustered);
      if (Settings.Options.ScanNonClusteredIndex) it.Add((int)IndexType.NonClustered);

      if (Settings.ServerInfo.IsColumnstoreAvailable) {
        if (Settings.Options.ScanClusteredColumnstore) it.Add((int)IndexType.ColumnstoreClustered);
        if (Settings.Options.ScanNonClusteredColumnstore) it.Add((int)IndexType.ColumnstoreNonClustered);
      }

      List<Index> indexes = new List<Index>();

      if (it.Count > 0) {

        string lob = string.Empty;
        if (Settings.ServerInfo.IsOnlineRebuildAvailable)
          lob = Settings.ServerInfo.MajorVersion == Server.Sql2008 ? Query.Lob2008 : Query.Lob2012Plus;

        string indexStats = Settings.ServerInfo.IsAzure && connection.Database == Resources.DatamaseMaster
                              ? Query.IndexStatsAzureMaster
                              : Query.IndexStats;

        string indexQuery = Settings.ServerInfo.MajorVersion == Server.Sql2008 ? Query.Index2008 : Query.Index2012Plus;

        List<string> excludeObjectMask = Settings.Options.ExcludeObject.Where(_ => _.Contains("%")).ToList();
        List<string> includeObjectMask = Settings.Options.IncludeObject.Where(_ => _.Contains("%")).ToList();
        List<string> excludeObjectId = Settings.Options.ExcludeObject.Where(_ => !_.Contains("%")).ToList();
        List<string> includeObjectId = Settings.Options.IncludeObject.Where(_ => !_.Contains("%")).ToList();

        string excludeList = string.Empty;
        if (Settings.Options.ExcludeSchemas.Count > 0)
          excludeList += "OR [schema_id] = SCHEMA_ID(N'" + string.Join("') OR [schema_id] = SCHEMA_ID(N'", Settings.Options.ExcludeSchemas) + "') ";

        if (excludeObjectMask.Count > 0)
          excludeList += "OR [name] LIKE N'" + string.Join("' OR [name] LIKE N'", excludeObjectMask) + "' ";

        if (excludeObjectId.Count > 0)
          excludeList += "OR [object_id] = OBJECT_ID(N'" + string.Join("') OR [object_id] = OBJECT_ID(N'", excludeObjectId) + "') ";

        string includeListSchemas = Settings.Options.IncludeSchemas.Count > 0
                                      ? "AND ( [schema_id] = SCHEMA_ID(N'" + string.Join("') OR [schema_id] = SCHEMA_ID(N'", Settings.Options.IncludeSchemas) + "') ) "
                                      : string.Empty;

        string includeListObject = string.Empty;
        if (includeObjectMask.Count > 0)
          includeListObject += "OR [name] LIKE N'" + string.Join("' OR [name] LIKE N'", includeObjectMask) + "' ";

        if (includeObjectId.Count > 0)
          includeListObject += "OR [object_id] = OBJECT_ID(N'" + string.Join("') OR [object_id] = OBJECT_ID(N'", includeObjectId) + "') ";

        if (!string.IsNullOrEmpty(includeListObject))
          includeListObject = $"AND ( 1 = 0 {includeListObject})";

        string includeList = string.IsNullOrEmpty(includeListSchemas) && string.IsNullOrEmpty(includeListObject)
                                ? Query.IncludeListEmpty
                                : string.Format(Query.IncludeList, includeListSchemas, includeListObject);

        string ignoreReadOnlyFL = Settings.Options.IgnoreReadOnlyFL ? "" : "AND fg.[is_read_only] = 0";
        string ignorePermissions = Settings.Options.IgnorePermissions ? "" : "AND PERMISSIONS(i.[object_id]) & 2 = 2";

        string query = string.Format(Query.PreDescribeIndexes,
                                    string.Join(", ", it), excludeList, indexQuery, lob,
                                    indexStats, ignoreReadOnlyFL, ignorePermissions, includeList);

        SqlCommand cmd = new SqlCommand(query, connection) { CommandTimeout = Settings.Options.CommandTimeout };

        cmd.Parameters.Add(new SqlParameter("@Fragmentation", SqlDbType.Float) { Value = Settings.Options.ReorganizeThreshold });
        cmd.Parameters.Add(new SqlParameter("@MinIndexSize", SqlDbType.BigInt) { Value = Settings.Options.MinIndexSize.PageSize() });
        cmd.Parameters.Add(new SqlParameter("@MaxIndexSize", SqlDbType.BigInt) { Value = Settings.Options.MaxIndexSize.PageSize() });
        cmd.Parameters.Add(new SqlParameter("@PreDescribeSize", SqlDbType.BigInt) { Value = Settings.Options.PreDescribeSize.PageSize() });

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet data = new DataSet();
        adapter.Fill(data);

        foreach (DataRow _ in data.Tables[0].AsEnumerable()) {

          IndexType indexType = (IndexType)_.Field<byte>(Resources.IndexType);
          bool isOnlineRebuild = Settings.ServerInfo.IsOnlineRebuildAvailable;

          if (isOnlineRebuild) {
            if (
                 _.Field<bool>(Resources.IsLobLegacy)
              ||
                 indexType == IndexType.Heap
              ||
                 indexType == IndexType.ColumnstoreClustered
              ||
                 indexType == IndexType.ColumnstoreNonClustered
            ) {
              isOnlineRebuild = false;
            }
            else {
              isOnlineRebuild =
                     Settings.ServerInfo.MajorVersion > Server.Sql2008
                  ||
                     (Settings.ServerInfo.MajorVersion == Server.Sql2008 && !_.Field<bool>(Resources.IsLob));
            }
          }

          Index index = new Index {
            DatabaseName          = connection.Database,
            ObjectId              = _.Field<int>(Resources.ObjectID),
            IndexId               = _.Field<int>(Resources.IndexID),
            IndexName             = _.Field<string>(Resources.IndexName),
            ObjectName            = _.Field<string>(Resources.ObjectName),
            SchemaName            = _.Field<string>(Resources.SchemaName),
            PagesCount            = _.Field<long>(Resources.PagesCount),
            UnusedPagesCount      = _.Field<long>(Resources.UnusedPagesCount),
            PartitionNumber       = _.Field<int>(Resources.PartitionNumber),
            RowsCount             = _.Field<long>(Resources.RowsCount),
            FileGroupName         = _.Field<string>(Resources.FileGroupName),
            IndexType             = indexType,
            IsPartitioned         = _.Field<bool>(Resources.IsPartitioned),
            IsUnique              = _.Field<bool>(Resources.IsUnique),
            IsPK                  = _.Field<bool>(Resources.IsPK),
            IsFiltered            = _.Field<bool>(Resources.IsFiltered),
            FillFactor            = _.Field<int>(Resources.FillFactor),
            IndexStats            = _.Field<DateTime?>(Resources.IndexStats),
            TotalWrites           = _.Field<long?>(Resources.TotalWrites),
            TotalReads            = _.Field<long?>(Resources.TotalReads),
            TotalSeeks            = _.Field<long?>(Resources.TotalSeeks),
            TotalScans            = _.Field<long?>(Resources.TotalScans),
            TotalLookups          = _.Field<long?>(Resources.TotalLookups),
            LastUsage             = _.Field<DateTime?>(Resources.LastUsage),
            DataCompression       = (DataCompression)_.Field<byte>(Resources.DataCompression),
            Fragmentation         = _.Field<double?>(Resources.Fragmentation),
            IsAllowReorganize     = _.Field<bool>(Resources.IsAllowPageLocks) && indexType != IndexType.Heap,
            IsAllowOnlineRebuild  = isOnlineRebuild,
            IsAllowCompression    = Settings.ServerInfo.IsCompressionAvailable && !_.Field<bool>(Resources.IsSparse),
            IndexColumns          = _.Field<string>(Resources.IndexColumns),
            IncludedColumns       = _.Field<string>(Resources.IncludedColumns)
          };

          indexes.Add(index);
        }
      }

      if (Settings.Options.ScanMissingIndex) {

        SqlCommand cmd = new SqlCommand(Query.MissingIndex, connection) { CommandTimeout = Settings.Options.CommandTimeout };

        cmd.Parameters.Add(new SqlParameter("@Fragmentation", SqlDbType.Float) { Value = Settings.Options.ReorganizeThreshold });
        cmd.Parameters.Add(new SqlParameter("@MinIndexSize", SqlDbType.BigInt) { Value = Settings.Options.MinIndexSize.PageSize() });
        cmd.Parameters.Add(new SqlParameter("@MaxIndexSize", SqlDbType.BigInt) { Value = Settings.Options.MaxIndexSize.PageSize() });

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet data = new DataSet();
        adapter.Fill(data);

        foreach (DataRow _ in data.Tables[0].AsEnumerable()) {
          double fragmentation = _.Field<double>(Resources.Fragmentation);
          string indexCols = _.Field<string>(Resources.IndexColumns);
          string objName = _.Field<string>(Resources.ObjectName);
          string indexName = $"IX_{Guid.NewGuid().ToString().Truncate(5)}_{objName}_{indexCols}"
                                    .Replace(",", "_")
                                    .Replace("[", string.Empty)
                                    .Replace("]", string.Empty)
                                    .Replace(" ", string.Empty).Truncate(240);

          Index index = new Index {
            DatabaseName          = connection.Database,
            ObjectId              = _.Field<int>(Resources.ObjectID),
            IndexName             = indexName,
            ObjectName            = objName,
            SchemaName            = _.Field<string>(Resources.SchemaName),
            PagesCount            = _.Field<long>(Resources.PagesCount),
            RowsCount             = _.Field<long>(Resources.RowsCount),
            FileGroupName         = _.Field<string>(Resources.FileGroupName),
            IndexType             = IndexType.MissingIndex,
            IndexStats            = _.Field<DateTime?>(Resources.IndexStats),
            TotalReads            = _.Field<long?>(Resources.TotalReads),
            TotalSeeks            = _.Field<long?>(Resources.TotalSeeks),
            TotalScans            = _.Field<long?>(Resources.TotalScans),
            LastUsage             = _.Field<DateTime?>(Resources.LastUsage),
            DataCompression       = DataCompression.None,
            Fragmentation         = fragmentation,
            IndexColumns          = indexCols,
            IncludedColumns       = _.Field<string>(Resources.IncludedColumns)
          };

          indexes.Add(index);
        }
      }

      return indexes;
    }

    public static void GetIndexFragmentation(SqlConnection connection, Index index) {
      SqlCommand cmd = new SqlCommand(Query.IndexFragmentation, connection) { CommandTimeout = Settings.Options.CommandTimeout };

      cmd.Parameters.Add(new SqlParameter("@ObjectID",        SqlDbType.Int) { Value = index.ObjectId });
      cmd.Parameters.Add(new SqlParameter("@IndexID",         SqlDbType.Int) { Value = index.IndexId });
      cmd.Parameters.Add(new SqlParameter("@PartitionNumber", SqlDbType.Int) { Value = index.PartitionNumber });

      index.Fragmentation = (double?)cmd.ExecuteScalar();
    }

    public static void GetColumnstoreFragmentation(SqlConnection connection, Index index, List<Index> indexes) {
      SqlCommand cmd = new SqlCommand(Query.ColumnstoreIndexFragmentation, connection) { CommandTimeout = Settings.Options.CommandTimeout };

      cmd.Parameters.Add(new SqlParameter("@ObjectID", SqlDbType.Int) { Value = index.ObjectId });
      cmd.Parameters.Add(new SqlParameter("@Fragmentation", SqlDbType.Float) { Value = Settings.Options.ReorganizeThreshold });
      cmd.Parameters.Add(new SqlParameter("@MinIndexSize", SqlDbType.BigInt) { Value = Settings.Options.MinIndexSize.PageSize() });
      cmd.Parameters.Add(new SqlParameter("@MaxIndexSize", SqlDbType.BigInt) { Value = Settings.Options.MaxIndexSize.PageSize() });

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet data = new DataSet();
      adapter.Fill(data);

      foreach(DataRow row in data.Tables[0].Rows) {
        int indexId = row.Field<int>(Resources.IndexID);
        int partitionNumber = row.Field<int>(Resources.PartitionNumber);

        Index idx = indexes.FirstOrDefault(_ => _.ObjectId == index.ObjectId
                                             && _.IndexId == indexId
                                             && _.PartitionNumber == partitionNumber);

        if (idx != null) {
          idx.Fragmentation = row.Field<double>(Resources.Fragmentation);
          idx.PagesCount = row.Field<long>(Resources.PagesCount);
          idx.UnusedPagesCount = row.Field<long>(Resources.UnusedPagesCount);
        }
      }
    }

    public static void FixIndex(SqlConnection connection, Index index) {
      string sqlInfo = string.Format(index.IsColumnstore ? Query.AfterFixColumnstoreIndex : Query.AfterFixIndex,
                                     index.ObjectId, index.IndexId, index.PartitionNumber);

      bool isDeadIndex = (index.FixType == IndexOp.Disable || index.FixType == IndexOp.Drop);
      string sql = isDeadIndex || index.FixType == IndexOp.CreateIndex
                      ? index.GetQuery()
                      : $"{index.GetQuery()} \n {sqlInfo}";

      SqlCommand cmd = new SqlCommand(sql, connection) { CommandTimeout = Settings.Options.CommandTimeout };
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet data = new DataSet();

      try {
        adapter.Fill(data);
      }
      catch (Exception ex) {
        index.Error = ex.Message;
      }

      if (index.FixType == IndexOp.CreateIndex) {
        index.Fragmentation = 0;
      }
      if (isDeadIndex) {
        index.PagesCountBefore = index.PagesCount;
        index.Fragmentation = 0;
        index.PagesCount = 0;
        index.UnusedPagesCount = 0;
        index.RowsCount = 0;
      }
      else if (data.Tables.Count == 1 && data.Tables[0].Rows.Count == 1) {
        DataRow row = data.Tables[0].Rows[0];

        index.PagesCountBefore  = index.PagesCount - row.Field<long>(Resources.PagesCount);
        index.Fragmentation     = row.Field<double>(Resources.Fragmentation);
        index.PagesCount        = row.Field<long>(Resources.PagesCount);
        index.UnusedPagesCount  = row.Field<long>(Resources.UnusedPagesCount);
        index.RowsCount         = row.Field<long>(Resources.RowsCount);
        index.DataCompression   = ((DataCompression)row.Field<byte>(Resources.DataCompression));
        index.IndexStats        = row.Field<DateTime?>(Resources.IndexStats);
      }

    }
  }

}
