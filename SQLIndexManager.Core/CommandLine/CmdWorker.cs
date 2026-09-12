using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using SQLIndexManager.Core.Server;
using Index = SQLIndexManager.Core.Server.Index;

namespace SQLIndexManager.Core.CommandLine {

  public class CmdWorker {

    public CmdWorker(List<CmdArgument> args) {
      
      var host = SetupSettings(args);
      
      if (host.Databases.Count == 0)
        throw new ArgumentException("No database selected");

      host.ServerInfo = GetServerInfo(host);
      
      if (host.ServerInfo.MajorVersion < ServerVersion.Sql2008)
        throw new ArgumentException(MessageConstants.MinVersionMessage);
      else
        Settings.Settings.ActiveHost = host;
    }

    public int FixIndexes() {
      
      Output.Current.Add($"Host: {Settings.Settings.ActiveHost}");

      using (ConnectionList connectionList = new ConnectionList(Settings.Settings.ActiveHost)) {

        List<Index> scanIndex = new List<Index>();
        Stopwatch watch;
        Stopwatch totalWatch = Stopwatch.StartNew();

        foreach (var database in Settings.Settings.ActiveHost.Databases) {
          List<Index> idx = new List<Index>();
          watch = Stopwatch.StartNew();
          SqlConnection connection = connectionList.Get(database);
          if (connection == null) continue;

          Output.Current.Add(new string('-', 150));
          Output.Current.Add($"Describe: {database}");

          short retries = 0;
          while (true) {
            try {
              idx = QueryEngine.GetIndexes(connection);
              break;
            }
            catch (SqlException ex) {
              if (!ex.Message.Contains("timeout")) {
                throw new ArgumentException($"Error: {ex.Source} {ex.Message}");
              }

              retries++;
              if (retries > 2)
                break;
            }
          }

          watch.Stop();
          Output.Current.Add($"Pre-describe: {(idx.Count(_ => _.Fragmentation != null))}. " +
                             $"Post-describe: {(idx.Count(_ => _.Fragmentation == null))}", null, watch.ElapsedMilliseconds);

          List<int> clid = new List<int>();

          foreach (Index index in idx.Where(_ => _.Fragmentation == null)
                                     .OrderBy(_ => _.ObjectId)
                                     .ThenBy(_ => _.IndexId)
                                     .ThenBy(_ => _.PartitionNumber)) {
            try {
              connection = connectionList.Get(database);
              if (connection == null) break;

              if (index.IndexType == IndexType.CLUSTERED_COLUMNSTORE || index.IndexType == IndexType.NONCLUSTERED_COLUMNSTORE) {
                if (!clid.Exists(_ => _ == index.ObjectId)) {
                  watch = Stopwatch.StartNew();
                  QueryEngine.GetColumnstoreFragmentation(connection, index, idx);
                  clid.Add(index.ObjectId);
                  watch.Stop();
                  Output.Current.Add(index.ToString(), null, watch.ElapsedMilliseconds);
                }
              }
              else {
                watch = Stopwatch.StartNew();
                QueryEngine.GetIndexFragmentation(connection, index);
                watch.Stop();
                Output.Current.Add(index.ToString(), null, watch.ElapsedMilliseconds);
              }
            }
            catch (Exception ex) {
              Output.Current.Add($"Failed: {index}", ex.Message);
            }
          }

          scanIndex.AddRange(idx);
        }

        var fixIndex = scanIndex.Where(_ => _.Fragmentation >= Settings.Settings.Options.FirstThreshold
                                         && _.PagesCount >= Settings.Settings.Options.MinIndexSize.PageSize()
                                         && _.PagesCount <= Settings.Settings.Options.MaxIndexSize.PageSize()).ToList();

        Output.Current.Add(new string('-', 150));
        Output.Current.Add($"Processed: {scanIndex.Count}. Fragmented: {fixIndex.Count}", null, totalWatch.ElapsedMilliseconds);

        if (fixIndex.Count > 0) {
          totalWatch = Stopwatch.StartNew();
          Output.Current.Add("Fix...");

          foreach (Index ix in fixIndex) {
            if (ix.IndexType == IndexType.MISSING_INDEX)
              ix.FixType = IndexOp.CREATE_INDEX;
            else if (ix.Fragmentation < Settings.Settings.Options.SecondThreshold && ix.IsAllowReorganize)
              ix.FixType = IndexOp.REORGANIZE;
            else if (Settings.Settings.Options.Online && ix.IsAllowOnlineRebuild)
              ix.FixType = IndexOp.REBUILD_ONLINE;
            else
              ix.FixType = IndexOp.REBUILD;

            watch = Stopwatch.StartNew();
            SqlConnection connection = connectionList.Get(ix.DatabaseName);
            if (connection != null) {
              QueryEngine.FixIndex(connection, ix);
            }
            watch.Stop();

            if (string.IsNullOrEmpty(ix.Error))
              Output.Current.Add(ix.ToString(),
                  $"Fragmentation: {ix.Fragmentation:n2}%. " +
                  $"Size: {(Convert.ToDecimal(ix.PagesCountBefore) * 8).FormatSize()} -> {(Convert.ToDecimal(ix.PagesCount) * 8).FormatSize()}. " +
                  $"Saved: {(Convert.ToDecimal(ix.PagesCountBefore - ix.PagesCount) * 8).FormatSize()}", watch.ElapsedMilliseconds);
            else
              Output.Current.Add(ix.ToString(), ix.Error);
          }

          Output.Current.Add(new string('-', 150));
          Output.Current.Add($"Processed: {fixIndex.Count(_ => string.IsNullOrEmpty(_.Error))}. " +
                             $"Errors: {fixIndex.Count(_ => !string.IsNullOrEmpty(_.Error))}", null, totalWatch.ElapsedMilliseconds);
        }
      }

      return 0;
    }

    private static ServerInfo GetServerInfo(Host host)
    {
      using (SqlConnection connection = ConnectionUtils.Create(host))
      {
        try
        {
          return QueryEngine.GetServerInfo(connection);
        }
        catch (Exception ex)
        {
          throw new ArgumentException(ex.Message.Replace(". ", "." + Environment.NewLine));
        }
        finally
        {
          connection.Close();
        }
      }
    }

    private static Host SetupSettings(List<CmdArgument> args)
    {
      Host host = new Host();
      Settings.Settings.Options.IgnorePermissions = false;
      Settings.Settings.Options.IgnoreReadOnlyFL = false;

      foreach (CmdArgument cmd in args)
      {
        switch (cmd.Argument)
        {
          case "connection":
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(cmd.Params[0]);
            host.Server = sb.DataSource;
            host.AuthType = sb.IntegratedSecurity ? AuthTypes.Windows : AuthTypes.Sql;
            host.User = sb.UserID;
            if (!string.IsNullOrEmpty(sb.InitialCatalog))
            {
              host.Databases.Add(sb.InitialCatalog);
            }

            if (!sb.IntegratedSecurity)
            {
              host.Password = sb.Password;
            }

            Settings.Settings.Options.ConnectionTimeout = sb.ConnectTimeout;
            break;

          case "databases":
            host.Databases.Clear();
            List<string> dbs = new List<string>(cmd.Params[0].Split(';'));
            host.Databases.AddRange(dbs.Where(_ => !string.IsNullOrEmpty(_)).Distinct());
            break;

          case "connectiontimeout":
            Settings.Settings.Options.ConnectionTimeout = Convert.ToInt32(cmd.Params[0]);
            break;

          case "commandtimeout":
            Settings.Settings.Options.CommandTimeout = Convert.ToInt32(cmd.Params[0]);
            break;

          case "online":
            Settings.Settings.Options.Online = true;
            break;

          case "missingindex":
            Settings.Settings.Options.ScanMissingIndex = true;
            break;

          case "ignoreheap":
            Settings.Settings.Options.ScanHeap = false;
            break;

          case "ignorecolumnstore":
            Settings.Settings.Options.ScanClusteredColumnstore = false;
            Settings.Settings.Options.ScanNonClusteredColumnstore = false;
            break;

          case "ignorebtree":
            Settings.Settings.Options.ScanClusteredIndex = false;
            Settings.Settings.Options.ScanNonClusteredIndex = false;
            break;

          case "maxdop":
            Settings.Settings.Options.MaxDop = Convert.ToInt32(cmd.Params[0]);
            break;

          case "rebuildthreshold":
            Settings.Settings.Options.SecondThreshold = Convert.ToInt32(cmd.Params[0]);
            break;

          case "reorganizethreshold":
            Settings.Settings.Options.FirstThreshold = Convert.ToInt32(cmd.Params[0]);
            break;

          case "minindexsize":
            Settings.Settings.Options.MinIndexSize = Convert.ToInt32(cmd.Params[0]);
            break;

          case "predescribesize":
            Settings.Settings.Options.PreDescribeSize = Convert.ToInt32(cmd.Params[0]);
            break;

          case "maxindexsize":
            Settings.Settings.Options.MaxIndexSize = Convert.ToInt32(cmd.Params[0]);
            break;

          default:
            throw new ArgumentException($"Unknown argument \"{cmd.Argument}\"");
        }
      }

      return host;
    }
  }

}