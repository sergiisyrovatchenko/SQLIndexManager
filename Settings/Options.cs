using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SQLIndexManager {

  [Serializable]
  public class Options {
    private int _reorganizeThreshold = 15;
    private int _rebuildThreshold = 30;
    private int _minIndexSize = 6;
    private int _preDescribeSize = 256;
    private int _maxIndexSize = 8192;
    private int _connectionTimeout = 15;
    private int _commandTimeout = 90;
    private int _maxDop;
    private int _sampleStatsPercent = 100;
    private int _maxDuration = 1;
    private string _abortAfterWait = "NONE";
    private List<string> _excludeSchemas = new List<string>();
    private List<string> _excludeObject = new List<string>();

    [XmlAttribute]
    public int ConnectionTimeout {
      get => _connectionTimeout;
      set => _connectionTimeout = value.IsBetween(15, 90) ? value : _connectionTimeout;
    }

    [XmlAttribute]
    public int CommandTimeout {
      get => _commandTimeout;
      set => _commandTimeout = value.IsBetween(0, 900) ? value : _commandTimeout;
    }

    [XmlAttribute]
    public int ReorganizeThreshold {
      get => _reorganizeThreshold;
      set => UpdateThreshold(value, _rebuildThreshold);
    }

    [XmlAttribute]
    public int RebuildThreshold {
      get => _rebuildThreshold;
      set => UpdateThreshold(_reorganizeThreshold, value);
    }

    [XmlAttribute]
    public int MaxDop {
      get => _maxDop;
      set => _maxDop = value.IsBetween(0, 64) ? value : _maxDop;
    }

    [XmlAttribute]
    public int SampleStatsPercent {
      get => _sampleStatsPercent;
      set => _sampleStatsPercent = value.IsBetween(1, 100) ? value : _sampleStatsPercent;
    }

    [XmlAttribute]
    public int MinIndexSize {
      get => _minIndexSize;
      set => UpdateSize(value, _preDescribeSize, _maxIndexSize);
    }

    [XmlAttribute]
    public int PreDescribeSize {
      get => _preDescribeSize;
      set => UpdateSize(_minIndexSize, value, _maxIndexSize);
    }

    [XmlAttribute]
    public int MaxIndexSize {
      get => _maxIndexSize;
      set => UpdateSize(_minIndexSize, _preDescribeSize, value);
    }

    [XmlAttribute]
    public bool Online;

    [XmlAttribute]
    public bool SortInTempDb;

    [XmlAttribute]
    public bool LobCompaction;

    [XmlAttribute]
    public bool WaitAtLowPriority;

    [XmlAttribute]
    public bool ScanHeap;

    [XmlAttribute]
    public bool ScanClusteredIndex;

    [XmlAttribute]
    public bool ScanNonClusteredIndex;

    [XmlAttribute]
    public bool ScanClusteredColumnstore;

    [XmlAttribute]
    public bool ScanNonClusteredColumnstore;

    [XmlElement]
    public List<string> ExcludeSchemas {
      get => _excludeSchemas;
      set {
        List<string> items = new List<string>();
        foreach (string item in value) {
          string t = item.Replace("'", "").Trim();
          if (!string.IsNullOrEmpty(t))
            items.Add(t);
        }
        _excludeSchemas = items;
      }
    }

    [XmlElement]
    public List<string> ExcludeObject {
      get => _excludeObject;
      set {
        List<string> items = new List<string>();
        foreach (string item in value) {
          string t = item.Replace("'", "").Trim();
          if (!string.IsNullOrEmpty(t))
            items.Add(t);
        }
        _excludeObject = items;
      }
    }

    [XmlAttribute]
    public int MaxDuration {
      get => _maxDuration;
      set => _maxDuration = value.IsBetween(1, 10) ? value : _maxDuration;
    }

    [XmlAttribute]
    public string AbortAfterWait {
      get => _abortAfterWait;
      set => _abortAfterWait = (value == "NONE" || value == "SELF" || value == "BLOCKERS") ? value : _abortAfterWait;
    }

    private void UpdateThreshold(int reorganize, int rebuild) {
      _reorganizeThreshold = reorganize.IsBetween(0, 99) ? reorganize : _reorganizeThreshold;
      _rebuildThreshold = rebuild.IsBetween(1, 100) ? rebuild : _rebuildThreshold;

      if (_reorganizeThreshold == _rebuildThreshold) {
        if (_reorganizeThreshold > 0)
          _reorganizeThreshold -= 1;
        else
          _rebuildThreshold += 1;
      }
    }

    private void UpdateSize(int min, int pre, int max) {
      _minIndexSize = min.IsBetween(0, 255) ? min : _minIndexSize;
      _preDescribeSize = min.IsBetween(_minIndexSize, 256) ? pre : _preDescribeSize;
      _maxIndexSize = max.IsBetween(1, 65536) ? max : _maxIndexSize;

      if (_minIndexSize == _maxIndexSize) {
        if (_minIndexSize > 0)
          _minIndexSize -= 1;
        else
          _maxIndexSize += 1;
      }
    }

    public Options() {
      SortInTempDb = true;
      LobCompaction = true;
      ScanHeap = true;
      ScanClusteredIndex = true;
      ScanNonClusteredIndex = true;
      ScanClusteredColumnstore = true;
      ScanNonClusteredColumnstore = true;
    }
  }

}
