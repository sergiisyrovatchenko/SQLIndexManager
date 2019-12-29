using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SQLIndexManager {

  [Serializable]
  public class Options {

    private IndexOp _skipOperation = IndexOp.IGNORE;
    private IndexOp _firstOperation = IndexOp.REORGANIZE;
    private IndexOp _secondOperation = IndexOp.REBUILD;
    private int _firstThreshold = 15;
    private int _secondThreshold = 30;
    private int _minIndexSize = 6;
    private int _preDescribeSize = 256;
    private int _maxIndexSize = 8192;
    private int _connectionTimeout = 15;
    private int _commandTimeout = 120;
    private int _delayAfterFix;
    private int _maxDop;
    private int _fillFactor;
    private int _sampleStatsPercent = 100;
    private int _maxDuration = 1;
    private DataCompression _dataCompression;
    private List<string> _includeSchemas = new List<string>();
    private List<string> _excludeSchemas = new List<string>();
    private List<string> _includeObject = new List<string>();
    private List<string> _excludeObject = new List<string>();

    public Options() {
      SortInTempDb = true;
      LobCompaction = true;
      ScanHeap = true;
      ScanClusteredIndex = true;
      ScanNonClusteredIndex = true;
      ScanClusteredColumnstore = true;
      ScanNonClusteredColumnstore = true;
      IgnorePermissions = true;
      IgnoreReadOnlyFL = true;
      ShowSettingsWhenConnectionChanged = true;

      ScanMode = ScanMode.LIMITED;
      DataCompression = DataCompression.DEFAULT;
      NoRecompute = NoRecompute.DEFAULT;
      AbortAfterWait = AbortAfterWait.NONE;
    }

    [XmlAttribute]
    public int ConnectionTimeout {
      get => _connectionTimeout;
      set => _connectionTimeout = value.IsBetween(15, 90) ? value : _connectionTimeout;
    }

    [XmlAttribute]
    public int CommandTimeout {
      get => _commandTimeout;
      set => _commandTimeout = value.IsBetween(0, 1800) ? value : _commandTimeout;
    }

    [XmlAttribute]
    public IndexOp SkipOperation {
      get => _skipOperation;
      set => _skipOperation = CheckAllowedIndexOp(value, _skipOperation, true);
    }

    [XmlAttribute]
    public IndexOp FirstOperation {
      get => _firstOperation;
      set => _firstOperation = CheckAllowedIndexOp(value, _firstOperation);
    }

    [XmlAttribute]
    public IndexOp SecondOperation {
      get => _secondOperation;
      set => _secondOperation = CheckAllowedIndexOp(value, _secondOperation);
    }

    [XmlAttribute]
    public int FirstThreshold {
      get => _firstThreshold;
      set => UpdateThreshold(value, _secondThreshold);
    }

    [XmlAttribute]
    public int SecondThreshold {
      get => _secondThreshold;
      set => UpdateThreshold(_firstThreshold, value);
    }

    [XmlAttribute]
    public int DelayAfterFix {
      get => _delayAfterFix;
      set => _delayAfterFix = value.IsBetween(0, 5000) ? value : _delayAfterFix;
    }

    [XmlAttribute]
    public int MaxDop {
      get => _maxDop;
      set => _maxDop = value.IsBetween(0, 64) ? value : _maxDop;
    }

    [XmlAttribute]
    public int FillFactor {
      get => _fillFactor;
      set => _fillFactor = value.IsBetween(0, 100) ? value : _fillFactor;
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
    public bool ShowSettingsWhenConnectionChanged;

    [XmlAttribute]
    public bool Online;

    [XmlAttribute]
    public bool PadIndex;

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

    [XmlAttribute]
    public bool ScanMissingIndex;

    [XmlAttribute]
    public bool IgnorePermissions;

    [XmlAttribute]
    public bool IgnoreReadOnlyFL;

    [XmlElement]
    public List<string> IncludeSchemas {
      get => _includeSchemas;
      set => _includeSchemas = value.RemoveInvalidTokens();
    }

    [XmlElement]
    public List<string> ExcludeSchemas {
      get => _excludeSchemas;
      set => _excludeSchemas = value.RemoveInvalidTokens();
    }

    [XmlElement]
    public List<string> ExcludeObject {
      get => _excludeObject;
      set => _excludeObject = value.RemoveInvalidTokens();
    }

    [XmlElement]
    public List<string> IncludeObject {
      get => _includeObject;
      set => _includeObject = value.RemoveInvalidTokens();
    }

    [XmlAttribute]
    public int MaxDuration {
      get => _maxDuration;
      set => _maxDuration = value.IsBetween(1, 10) ? value : _maxDuration;
    }

    [XmlAttribute]
    public NoRecompute NoRecompute;

    [XmlAttribute]
    public DataCompression DataCompression {
      get => _dataCompression;
      set => _dataCompression = (value != DataCompression.COLUMNSTORE && value != DataCompression.COLUMNSTORE_ARCHIVE) ? value : _dataCompression;
    }

    [XmlAttribute]
    public AbortAfterWait AbortAfterWait;

    [XmlAttribute]
    public ScanMode ScanMode;

    private IndexOp CheckAllowedIndexOp(IndexOp newValue, IndexOp oldValue, bool isSkip = false) {
      return (newValue == IndexOp.REBUILD 
           || newValue == IndexOp.REORGANIZE
           || newValue == IndexOp.UPDATE_STATISTICS_FULL
           || newValue == IndexOp.UPDATE_STATISTICS_RESAMPLE
           || newValue == IndexOp.UPDATE_STATISTICS_SAMPLE
           || (isSkip && newValue == IndexOp.NO_ACTION)
           || (isSkip && newValue == IndexOp.IGNORE)
        ) ? newValue : oldValue;
    }

    private void UpdateThreshold(int first, int second) {
      _firstThreshold = first.IsBetween(1, 99) ? first : _firstThreshold;
      _secondThreshold = second.IsBetween(2, 100) ? second : _secondThreshold;

      if (_firstThreshold > _secondThreshold)
        _secondThreshold = _firstThreshold + 1;

      if (_firstThreshold == _secondThreshold) {
        if (_firstThreshold > 0)
          _firstThreshold -= 1;
        else
          _secondThreshold += 1;
      }
    }

    private void UpdateSize(int min, int pre, int max) {
      _minIndexSize = min.IsBetween(0, 255) ? min : _minIndexSize;
      _preDescribeSize = min.IsBetween(_minIndexSize, 256) ? pre : _preDescribeSize;
      _maxIndexSize = max.IsBetween(512, 131072) ? max : _maxIndexSize;

      if (_minIndexSize > _preDescribeSize)
        _preDescribeSize = _minIndexSize + 1;

      if (_minIndexSize == _maxIndexSize) {
        if (_minIndexSize > 0)
          _minIndexSize -= 1;
        else
          _maxIndexSize += 1;
      }
    }

  }

}