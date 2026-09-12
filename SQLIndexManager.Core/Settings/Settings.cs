using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.Win32;
using SQLIndexManager.Core.Server;

namespace SQLIndexManager.Core.Settings {

  public static class Settings {

    private static GlobalSettings _current;
    private static Host _activeHost;
    private static readonly Destructor _finalise = new Destructor();
    public static bool IgnoreFileSetting = false;

    public static Host ActiveHost {
      get => _activeHost;
      set {
        _activeHost = value;
        
        Host oldHost = _current.Hosts.FirstOrDefault(_ => string.Equals(_.Server, _activeHost.Server, StringComparison.CurrentCultureIgnoreCase));
        if (oldHost != null) {
          value.Databases = oldHost.Databases;
        }

        _current.Hosts.Remove(oldHost);
        _current.Hosts.Insert(0, _activeHost);
      }
    }

    public static ServerInfo ServerInfo => _activeHost.ServerInfo;

    public static List<Host> Hosts {
      get => Instance.Hosts;
      set => Instance.Hosts = value;
    }

    public static Options Options {
      get => Instance.Options;
      set => Instance.Options = value;
    }

    private static GlobalSettings Instance {
      get {
        if (_current == null) {
          _current = new GlobalSettings();
          if (!IgnoreFileSetting)
            Load();
        }

        return _current;
      }
    }

    private sealed class Destructor {
      ~Destructor() {
        if (!IgnoreFileSetting)
          Save();
      }
    }

    private static void Save() {
      if (File.Exists(AppInfo.SettingFileName)) {
        try {
          File.Delete(AppInfo.SettingFileName);
        }
        catch { }
      }

      XmlSerializer serializer = new XmlSerializer(typeof(GlobalSettings));

      try {
        using (FileStream writer = File.OpenWrite(AppInfo.SettingFileName)) {
          _current.Hosts.RemoveAll(s => !s.IsUserConnection);
          _current.Hosts.ForEach(s => {
            if (s.AuthType == AuthTypes.Sql && s.Password != null) {
              s.Password = AES.Encrypt(s.Password);
            }
          });

          serializer.Serialize(writer, _current);
        }
      }
      catch {
        Output.Current.Add("Failed to save settings");
      }
    }

    private static void Load() {
      if (File.Exists(AppInfo.SettingFileName)) {
        XmlSerializer serializer = new XmlSerializer(typeof(GlobalSettings));

        try {
          using (StreamReader reader = File.OpenText(AppInfo.SettingFileName)) {

            _current = (GlobalSettings)serializer.Deserialize(reader);

            _current.Hosts.RemoveAll(_ => _.Server == null);
            _current.Hosts.ForEach(s => {
              s.IsUserConnection = true;
              if (s.AuthType == AuthTypes.Sql && !string.IsNullOrEmpty(s.Password)) {
                s.Password = AES.Decrypt(s.Password);
              }
            });

          }
        }
        catch {
          Output.Current.Add("Failed to load settings");
        }
      }

      try {
        LoadFromRegistry();
      }
      catch (PlatformNotSupportedException ex) {
        Output.Current.Add("Registry is not supported on this platform.");
      }

      if (_current.Hosts.Count == 0) {
        _current.Hosts.Add(new Host() { Server = Environment.MachineName });
      }
    }
    private static void LoadFromRegistry() {
      RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
      using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView)) {
        RegistryKey instanceKey = null;
        try {
          instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
        }
        catch {
          Output.Current.Add("Failed to read registry");
        }

        if (instanceKey != null) {
          foreach (string instanceName in instanceKey.GetValueNames()) {
            string host = (instanceName == "MSSQLSERVER") ? Environment.MachineName : $"{Environment.MachineName}\\{instanceName}";
            if (!_current.Hosts.Exists(_ => string.Equals(_.Server, host, StringComparison.CurrentCultureIgnoreCase))) {
              _current.Hosts.Add(new Host() { Server = host });
            }
          }
        }
      }
    }

  }

}