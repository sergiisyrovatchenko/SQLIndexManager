using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SQLIndexManager {

  [Serializable]
  public class Host {

    [XmlAttribute]
    public string Server;

    [XmlAttribute]
    public AuthTypes AuthType;

    [XmlAttribute]
    public string User;

    [XmlAttribute]
    public string Password;

    [XmlElement]
    public List<string> Databases;

    [XmlIgnore]
    public bool IsUserConnection;

    [XmlIgnore]
    public bool SavePassword;

    [XmlIgnore]
    public ServerInfo ServerInfo;

    public Host() {
      AuthType = AuthTypes.WINDOWS;
      Databases = new List<string>();
    }

    public override string ToString() {
      return $"{Server} | {ServerInfo}";
    }

  }

}