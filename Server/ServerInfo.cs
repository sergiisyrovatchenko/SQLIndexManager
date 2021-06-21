namespace SQLIndexManager {

  public class ServerInfo {
    public readonly string ServerName;
    private readonly string ProductLevel;
    private readonly string ProductUpdateLevel;
    private readonly string Edition;
    public readonly bool IsSysAdmin;
    private readonly string Version;

    public readonly int MajorVersion;
    private readonly int MinorVersion;
    private readonly int PatchVersion;

    public bool IsAzure => Edition == "SQL Azure";
    private bool IsMaxEdititon => Edition.StartsWith("Enterprise") || Edition.StartsWith("Developer");
    public override string ToString() => $"SQL Server {ProductVersion} " +
                                         $"{(string.IsNullOrEmpty(ProductUpdateLevel) ? ProductLevel : $"{ProductLevel} {ProductUpdateLevel}")} " +
                                         $"({Version}) {Edition}";

    public bool IsColumnstoreAvailable => IsAzure
         || (MajorVersion >= ServerVersion.Sql2014 && IsMaxEdititon)
         || (MajorVersion == ServerVersion.Sql2016 && PatchVersion >= 4001)
         || MajorVersion >= ServerVersion.Sql2017;

    public bool IsCompressionAvailable => IsAzure
         || (MajorVersion >= ServerVersion.Sql2008 && IsMaxEdititon)
         || (MajorVersion == ServerVersion.Sql2016 && PatchVersion >= 4001)
         || MajorVersion >= ServerVersion.Sql2017;

    // https://www.sqlskills.com/blogs/erin/new-statistics-dmf-in-sql-server-2008r2-sp2/
    public bool IsFullStats => IsAzure
         || (MajorVersion >= ServerVersion.Sql2008 && MinorVersion == 50 && PatchVersion >= 4000)
         || (MajorVersion == ServerVersion.Sql2012 && PatchVersion >= 3000)
         || MajorVersion >= ServerVersion.Sql2014;

    public bool IsOnlineRebuildAvailable => IsAzure
         || (MajorVersion >= ServerVersion.Sql2008 && IsMaxEdititon);

    private string ProductVersion {
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
          case ServerVersion.Sql2021:
            return "2021";
          default:
            return "?";
        }
      }
    }

    public ServerInfo(string serverName, string productLevel, string productUpdateLevel, string edition, string serverVersion, bool isSysAdmin) {
      ServerName = serverName;
      ProductLevel = productLevel;
      ProductUpdateLevel = productUpdateLevel;
      Edition = edition;
      Version = serverVersion;
      IsSysAdmin = isSysAdmin;

      MajorVersion = int.Parse(serverVersion.Split('.')[0]);
      MinorVersion = int.Parse(serverVersion.Split('.')[1]);
      PatchVersion = int.Parse(serverVersion.Split('.')[2]);
    }

  }

}