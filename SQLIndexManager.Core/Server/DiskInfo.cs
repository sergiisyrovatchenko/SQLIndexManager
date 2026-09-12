namespace SQLIndexManager.Core.Server {

  public class DiskInfo {

    public string Drive;
    public int FreeSpace;

    public override string ToString() {
      return $"{Drive}: {(((double)FreeSpace) / 1024):N2}";
    }

  }

}
