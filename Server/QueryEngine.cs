using SQLIndexManager.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SQLIndexManager {

  public static class QueryEngine {

    public static List<Database> GetDatabases(SqlConnection connection) {

      DataSet data = new DataSet();

      string query = !Settings.ServerInfo.IsAzure && Settings.ServerInfo.IsSysAdmin ? Query.DatabaseList : Query.DatabaseListAzure;
      
      SqlCommand cmd = new SqlCommand(query, connection) { CommandTimeout = Settings.Options.CommandTimeout };
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(data);

      List<Database> dbs = new List<Database>();
      foreach (DataRow _ in data.Tables[0].Rows) {
        dbs.Add(
          new Database {
            DatabaseName = _.Field<string>(Resources.DatabaseName),
            DataSize     = _.Field<long?>("DataSize"),
            LogSize      = _.Field<long?>("LogSize")
          }
        );
      }

      return dbs;

    }

    public static List<Index> GetIndexes(SqlConnection connection) {

      string lob = string.Empty;
      if (Settings.ServerInfo.IsOnlineRebuildAvailable)
        lob = Settings.ServerInfo.MajorVersion == 10 ? Query.Lob2008 : Query.Lob2012Plus;

      string indexStats = Settings.ServerInfo.IsAzure && connection.Database == Resources.DatamaseMaster
                              ? Query.IndexStatsAzureMaster
                              : Query.IndexStats;

      string indexQuery = Settings.ServerInfo.MajorVersion == 10 ? Query.Index2008 : Query.Index2012Plus;

      List<int> it = new List<int>();
      if (Settings.Options.ScanHeap) it.Add((int)IndexType.Heap);
      if (Settings.Options.ScanClusteredIndex) it.Add((int)IndexType.Clustered);
      if (Settings.Options.ScanNonClusteredIndex) it.Add((int)IndexType.NonClustered);

      if (Settings.ServerInfo.IsColumnstoreAvailable) {
        if (Settings.Options.ScanClusteredColumnstore) it.Add((int)IndexType.ColumnstoreClustered);
        if (Settings.Options.ScanNonClusteredColumnstore) it.Add((int)IndexType.ColumnstoreNonClustered);
      }

      string excludeList = string.Empty;
      if (Settings.Options.ExcludeSchemas.Count > 0) {
        excludeList = " OR [schema_id] IN (SELECT * FROM (VALUES (SCHEMA_ID('" + string.Join("')), (SCHEMA_ID('", Settings.Options.ExcludeSchemas) + "'))) t(ID) WHERE ID IS NOT NULL)";
      }

      if (Settings.Options.ExcludeObject.Count > 0) {
        excludeList += " OR [object_id] IN (SELECT * FROM (VALUES (OBJECT_ID('" + string.Join("')), (OBJECT_ID('", Settings.Options.ExcludeObject) + "'))) t(ID) WHERE ID IS NOT NULL)";
      }

      string query = string.Format(Query.PreDescribeIndexes, string.Join(", ", it), excludeList, indexQuery, lob, indexStats);

      DataSet data = new DataSet();
      SqlCommand cmd = new SqlCommand(query, connection) { CommandTimeout = Settings.Options.CommandTimeout };

      cmd.Parameters.Add(new SqlParameter("@Fragmentation",   SqlDbType.Float)  { Value = Settings.Options.ReorganizeThreshold });
      cmd.Parameters.Add(new SqlParameter("@MinIndexSize",    SqlDbType.BigInt) { Value = Settings.Options.MinIndexSize.PageSize() });
      cmd.Parameters.Add(new SqlParameter("@MaxIndexSize",    SqlDbType.BigInt) { Value = Settings.Options.MaxIndexSize.PageSize() });
      cmd.Parameters.Add(new SqlParameter("@PreDescribeSize", SqlDbType.BigInt) { Value = Settings.Options.PreDescribeSize.PageSize() });

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      adapter.Fill(data);

      List<Index> indexes = new List<Index>();
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
                   Settings.ServerInfo.MajorVersion > 10
                ||
                   (Settings.ServerInfo.MajorVersion == 10 && !_.Field<bool>(Resources.IsLob));
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
          LastUsage             = _.Field<DateTime?>(Resources.LastUsage),
          DataCompression       = (DataCompression)_.Field<byte>(Resources.DataCompression),
          Fragmentation         = _.Field<double?>(Resources.Fragmentation),
          IsAllowReorganize     = _.Field<bool>(Resources.IsAllowPageLocks) && indexType != IndexType.Heap,
          IsAllowOnlineRebuild  = isOnlineRebuild,
          IsAllowCompression    = Settings.ServerInfo.IsCompressionAvailable && !_.Field<bool>(Resources.IsSparse)
        };

        indexes.Add(index);
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

      DataSet data = new DataSet();

      SqlCommand cmd = new SqlCommand(Query.ColumnstoreIndexFragmentation, connection) { CommandTimeout = Settings.Options.CommandTimeout };
      cmd.Parameters.Add(new SqlParameter("@ObjectID", SqlDbType.Int) { Value = index.ObjectId });
      cmd.Parameters.Add(new SqlParameter("@Fragmentation", SqlDbType.Float) { Value = Settings.Options.ReorganizeThreshold });
      cmd.Parameters.Add(new SqlParameter("@MinIndexSize", SqlDbType.BigInt) { Value = Settings.Options.MinIndexSize.PageSize() });
      cmd.Parameters.Add(new SqlParameter("@MaxIndexSize", SqlDbType.BigInt) { Value = Settings.Options.MaxIndexSize.PageSize() });

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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

      DataSet data = new DataSet();

      string sqlInfo = string.Format(index.IsColumnstore ? Query.AfterFixColumnstoreIndex : Query.AfterFixIndex,
                                     index.ObjectId, index.IndexId, index.PartitionNumber);

      string sql = (index.FixType == IndexOp.Disable) 
                      ? index.GetQuery()
                      : $"{index.GetQuery()} \n {sqlInfo}";

      SqlCommand cmd = new SqlCommand(sql, connection) { CommandTimeout = Settings.Options.CommandTimeout };
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);

      try {
        adapter.Fill(data);
      }
      catch (Exception ex) {
        index.Error = ex.Message;
      }

      if (index.FixType == IndexOp.Disable) {
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
