namespace SQLIndexManager {

  public class ServerInfo {

    private readonly string ProductLevel;
    private readonly string Edition;
    public readonly bool IsSysAdmin;
    private readonly string Version;

    public override string ToString() {
      return $"SQL Server {ProductVersion} {ProductLevel} ({Version}) {Edition}";
    }

    public bool IsAzure => Edition == "SQL Azure";
    private bool IsMaxEdititon => Edition.StartsWith("Enterprise") || Edition.StartsWith("Developer");

    public readonly int MajorVersion;
    private readonly int MinorVersion;
    private readonly int PatchVersion;

    public bool IsColumnstoreAvailable {
      get {
        if (
            (MajorVersion >= ServerVersion.Sql2014 && IsMaxEdititon) // 2014..2019 Enterprise/Developer/Evaluation
         ||
            (MajorVersion == ServerVersion.Sql2016 && PatchVersion >= 4001) // 2016 SP1
         ||
            (MajorVersion >= ServerVersion.Sql2017)
        ) {
          return true;
        }

        return false;
      }
    }

    public bool IsCompressionAvailable {
      get {
        if (
            (MajorVersion >= ServerVersion.Sql2008 && IsMaxEdititon)
         ||
            (MajorVersion == ServerVersion.Sql2016 && PatchVersion >= 4001) // 2016 SP1
         ||
            (MajorVersion >= ServerVersion.Sql2017)
        ) {
          return true;
        }

        return false;
      }
    }

    public bool IsOnlineRebuildAvailable {
      get {
        if (MajorVersion >= ServerVersion.Sql2008 && IsMaxEdititon)
        {
          if (
              (MajorVersion == ServerVersion.Sql2014 && PatchVersion < 2370) // 2014 RTM
           ||
              (MajorVersion == ServerVersion.Sql2012 && (
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
          case ServerVersion.Sql2005:
            return "2005";
          case ServerVersion.Sql2008:
            return MinorVersion == 50 ? "2008 R2" : "2008";
          case ServerVersion.Sql2012:
            return "2012";
          case ServerVersion.Sql2014:
            return "2014";
          case ServerVersion.Sql2016:
            return "2016";
          case ServerVersion.Sql2017:
            return "2017";
          case ServerVersion.Sql2019:
            return "2019";
          default:
            return "?";
        }
      }
    }

    public ServerInfo(string productLevel, string edition, string serverVersion, bool isSysAdmin) {
      ProductLevel = productLevel;
      Edition = edition;
      Version = serverVersion;
      IsSysAdmin = isSysAdmin;

      MajorVersion = int.Parse(serverVersion.Split('.')[0]);
      MinorVersion = int.Parse(serverVersion.Split('.')[1]);
      PatchVersion = int.Parse(serverVersion.Split('.')[2]);
    }

  }

}