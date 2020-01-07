using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace SQLIndexManager {

  public class Settings {

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

    public static List<Host> Hosts => Instance.Hosts;

    public static List<string> NetworkHosts {
      get => Instance.NetworkHosts;
      set => Instance.NetworkHosts = value;
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

    public static string ExeName => Process.GetCurrentProcess().ProcessName;
    public static string ExePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string ApplicationName => $"{ExeName}-{Process.GetCurrentProcess().Id}";

    public static readonly string LayoutFileName = $"{ExePath}\\{ExeName}.layout";
    public static readonly string SettingFileName = $"{ExePath}\\{ExeName}.cfg";
    public static readonly string LogFileName = $"{ExePath}\\{ExeName}.log";

    public static void Save() {
      if (File.Exists(SettingFileName)) {
        try {
          File.Delete(SettingFileName);
        }
        catch { }
      }

      XmlSerializer serializer = new XmlSerializer(typeof(GlobalSettings));

      try {
        using (FileStream writer = File.OpenWrite(SettingFileName)) {
          _current.Hosts.RemoveAll(s => !s.IsUserConnection);
          _current.Hosts.ForEach(s => {
            if (s.AuthType == AuthTypes.SQLSERVER && s.Password != null) {
              s.Password = s.SavePassword
                              ? AES.Encrypt(s.Password)
                              : null;
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
      if (File.Exists(SettingFileName)) {
        XmlSerializer serializer = new XmlSerializer(typeof(GlobalSettings));

        try {
          using (StreamReader reader = File.OpenText(SettingFileName)) {

            _current = (GlobalSettings)serializer.Deserialize(reader);

            _current.Hosts.RemoveAll(_ => _.Server == null);
            _current.Hosts.ForEach(s => {
              s.IsUserConnection = true;
              if (s.AuthType == AuthTypes.SQLSERVER && !string.IsNullOrEmpty(s.Password)) {
                s.Password = AES.Decrypt(s.Password);
                s.SavePassword = true;
              }
            });

          }
        }
        catch {
          Output.Current.Add("Failed to load settings");
        }
      }

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

      if (_current.Hosts.Count == 0) {
        _current.Hosts.Add(new Host() { Server = Environment.MachineName });
      }
    }

  }

}