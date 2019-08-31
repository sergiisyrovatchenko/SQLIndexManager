using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SQLIndexManager {

  [Serializable]
  public class GlobalSettings {

    [XmlElement]
    public Options Options = new Options();

    [XmlElement]
    public List<Host> Hosts = new List<Host>();

    [XmlIgnore]
    public List<string> NetworkHosts = new List<string>();

  }

}
