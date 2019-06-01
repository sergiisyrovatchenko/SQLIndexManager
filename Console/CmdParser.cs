using System.Collections.Generic;

namespace SQLIndexManager {

  public static class CmdParser {
    public static List<CmdArgument> Parse(string[] argumets) {

      List<CmdArgument> newArguments = new List<CmdArgument>();
      CmdArgument argument = new CmdArgument();

      foreach (var arg in argumets) {
        if (arg[0] == '/') {
          argument = new CmdArgument() { Argument = arg.ToLower().Trim().Replace("/", string.Empty) };
          newArguments.Add(argument);
        }
        else {
          argument.Params.Add(arg.Trim());
        }
      }

      return newArguments;
    }
  }

}
