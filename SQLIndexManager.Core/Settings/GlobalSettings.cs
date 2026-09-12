using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using SQLIndexManager.Core.Server;

namespace SQLIndexManager.Core.Settings {

  [Serializable]
  public class GlobalSettings {

    [XmlElement]
    public Options Options = new Options();

    [XmlElement]
    public List<Host> Hosts = new List<Host>();

  }

}
