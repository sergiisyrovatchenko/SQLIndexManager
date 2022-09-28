// See https://aka.ms/new-console-template for more information

using SQLIndexManager;
using SQLIndexManager.Core;
using SQLIndexManager.Core.CommandLine;

Output.Current.AddOutputHandler(new ConsoleOutputHandler());

var provider = new CmdWorker(CmdParser.Parse(args));
return provider.FixIndexes();

class ConsoleOutputHandler : IOutputHandler {

  public void AddCaption(string message) {
    Console.WriteLine(message);
  }
}