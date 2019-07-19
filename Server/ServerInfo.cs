namespace SQLIndexManager {

  public class ServerInfo {

    private string ProductLevel;
    private string Edition;
    public bool IsSysAdmin;
    public string ServerVersion;
    public string Version => $"SQL Server {ProductVersion} {ProductLevel} ({ServerVersion}) {Edition}";

    public bool IsAzure => Edition == "SQL Azure";
    private bool IsMaxEdititon => Edition.StartsWith("Enterprise") || Edition.StartsWith("Developer");

    public int MajorVersion;
    private int MinorVersion;
    private int PatchVersion;

    public bool IsColumnstoreAvailable {
      get {
        if (
            (MajorVersion >= Server.Sql2014 && IsMaxEdititon) // 2014..2019 Enterprise/Developer/Evaluation
         ||
            (MajorVersion == Server.Sql2016 && PatchVersion >= 4001) // 2016 SP1
         ||
            (MajorVersion >= Server.Sql2017)
        ) {
          return true;
        }

        return false;
      }
    }

    public bool IsCompressionAvailable {
      get {
        if (
            (MajorVersion >= Server.Sql2008 && IsMaxEdititon)
         ||
            (MajorVersion == Server.Sql2016 && PatchVersion >= 4001) // 2016 SP1
         ||
            (MajorVersion >= Server.Sql2017)
        ) {
          return true;
        }

        return false;
      }
    }

    public bool IsOnlineRebuildAvailable {
      get {
        if (MajorVersion >= Server.Sql2008 && IsMaxEdititon)
        {
          if (
              (MajorVersion == Server.Sql2014 && PatchVersion < 2370) // 2014 RTM
           ||
              (MajorVersion == Server.Sql2012 && (
                                                     PatchVersion < 3437 // 2012 RTM..SP1
                                                  ||
                                                     PatchVersion.IsBetween(5058, 5521) // 2012 SP2
                                                 )
              )
          ) {
            return false; // https://sqlperformance.com/2014/06/sql-indexes/hotfix-sql-2012-rebuilds
          }

          return true;
        }

        return false;
      }
    }

    public string ProductVersion {
      get {
        switch (MajorVersion) {
          case Server.Sql2005:
            return "2005";
          case Server.Sql2008:
            return MinorVersion == 50 ? "2008 R2" : "2008";
          case Server.Sql2012:
            return "2012";
          case Server.Sql2014:
            return "2014";
          case Server.Sql2016:
            return "2016";
          case Server.Sql2017:
            return "2017";
          case Server.Sql2019:
            return "2019";
          default:
            return "?";
        }
      }
    }

    public ServerInfo(string productLevel, string edition, string serverVersion, bool isSysAdmin) {
      ProductLevel = productLevel;
      Edition = edition;
      ServerVersion = serverVersion;
      IsSysAdmin = isSysAdmin;

      MajorVersion = int.Parse(serverVersion.Split('.')[0]);
      MinorVersion = int.Parse(serverVersion.Split('.')[1]);
      PatchVersion = int.Parse(serverVersion.Split('.')[2]);
    }
  }

}
