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
            (MajorVersion >= 12 && IsMaxEdititon) // 2014..2019 Enterprise/Developer/Evaluation
         ||
            (MajorVersion == 13 && PatchVersion >= 4001) // 2016 SP1
         ||
            (MajorVersion >= 14) // 2017..2019
        ) {
          return true;
        }

        return false;
      }
    }

    public bool IsCompressionAvailable {
      get {
        if (
            (MajorVersion >= 10 && IsMaxEdititon) // 2008..2019 Enterprise/Developer/Evaluation
         ||
            (MajorVersion == 13 && PatchVersion >= 4001) // 2016 SP1
         ||
            (MajorVersion >= 14) // 2017..2019
        ) {
          return true;
        }

        return false;
      }
    }

    public bool IsOnlineRebuildAvailable {
      get {
        if (MajorVersion >= 10 && IsMaxEdititon) // 2008..2019 Enterprise/Developer/Evaluation
        {
          if (
              (MajorVersion == 12 && PatchVersion < 2370) // 2014 RTM
           ||
              (MajorVersion == 11 && (
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
          case 9:
            return "2005";
          case 10:
            return MinorVersion == 50 ? "2008 R2" : "2008";
          case 11:
            return "2012";
          case 12:
            return "2014";
          case 13:
            return "2016";
          case 14:
            return "2017";
          case 15:
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
