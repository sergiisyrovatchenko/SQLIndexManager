using System.Collections.Generic;

namespace SQLIndexManager.Core.CommandLine {

  public class CmdArgument {

    public string Argument;
    public readonly List<string> Params = new List<string>();
  }

}
