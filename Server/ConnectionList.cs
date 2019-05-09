using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace SQLIndexManager {

  public class ConnectionList : IDisposable {

    bool _disposed;
    readonly IDictionary<string, SqlConnection> _databases = new Dictionary<string, SqlConnection>();

    public ConnectionList(Host host) {
      foreach(string database in host.Databases) {
        SqlConnection connection = Connection.Create(host, database);
        _databases.Add(database, connection);
      }
    }

    public SqlConnection Get(string database) {
      if (!_databases.ContainsKey(database))
        return null;

      SqlConnection connection = _databases[database];
      
      if (!connection.State.HasFlag(ConnectionState.Open)) {
        short retries = 0;
        while (true) {
          try {
            connection.Open();
            break;
          }
          catch (SqlException ex) {
            retries++;
            Output.Current.Add($"Open connection: {database}", ex.Message);

            if (retries > 2 || ex.Number == 4060) {
              _databases.Remove(database);
              return null;
            }

            if (ex.Number == 40615 || ex.Number == 18456) {
              Thread.Sleep(2000);
            }
          }
        }
      }

      return connection;
    }

    public void Dispose() {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing) {
      if (_disposed)
        return;

      if (disposing) {
        foreach (var item in _databases) {
          SqlConnection connection = item.Value;
          if (connection != null && connection.State.HasFlag(ConnectionState.Open)) {
            connection.Close();
          }
        }
      }

      _disposed = true;
    }

    ~ConnectionList() {
      Dispose(false);
    }
  }
}
