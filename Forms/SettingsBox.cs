using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace SQLIndexManager {

  public partial class SettingsBox : XtraForm {

    public SettingsBox() {
      InitializeComponent();

      object[] indexOps = {
                        IndexOp.REBUILD.Description(),
                        IndexOp.REORGANIZE.Description(),
                        IndexOp.UPDATE_STATISTICS_FULL.Description(),
                        IndexOp.UPDATE_STATISTICS_RESAMPLE.Description(),
                        IndexOp.UPDATE_STATISTICS_SAMPLE.Description(),
                      };

      object[] dataCompression = {
                        DataCompression.DEFAULT,
                        DataCompression.NONE,
                        DataCompression.ROW,
                        DataCompression.PAGE
                      };

      boxSkipThreshold.Properties.Items.Add(IndexOp.IGNORE.Description());
      boxSkipThreshold.Properties.Items.Add(IndexOp.NO_ACTION.Description());
      boxSkipThreshold.Properties.Items.AddRange(indexOps);

      boxFirstThreshold.Properties.Items.AddRange(indexOps);
      boxSecondThreshold.Properties.Items.AddRange(indexOps);
      boxDataCompression.Properties.Items.AddRange(dataCompression);
      boxAbortAfterWait.Properties.Items.AddRange(Enum.GetNames(typeof(AbortAfterWait)));
      boxNoRecompute.Properties.Items.AddRange(Enum.GetNames(typeof(NoRecompute)));
      boxScanMode.Properties.Items.AddRange(Enum.GetNames(typeof(ScanMode)));

      UpdateControls(Settings.Options);
    }

    private void UpdateControls(Options o) {
      boxSkipThreshold.EditValue = o.SkipOperation.Description();
      boxFirstThreshold.EditValue = o.FirstOperation.Description();
      boxSecondThreshold.EditValue = o.SecondOperation.Description();
      boxThreshold.Value = new TrackBarRange(o.FirstThreshold, o.SecondThreshold);
      boxMinIndexSize.Value = new TrackBarRange(o.MinIndexSize, o.PreDescribeSize);
      boxMaxIndexSize.Value = o.MaxIndexSize;
      boxOnline.Checked = o.Online;
      boxPadIndex.Checked = o.PadIndex;
      boxSortInTempDb.Checked = o.SortInTempDb;
      boxLobCompaction.Checked = o.LobCompaction;
      boxMultiThreadingCount.Value = o.DelayAfterFix;
      boxDelayAfterFix.Value = o.DelayAfterFix;
      boxMultiThreadingCount.Value = o.MultiThreadingCount;
      boxMaxDod.Value = o.MaxDop;
      boxStatsSamplePercent.Value = o.SampleStatsPercent;
      boxConnectionTimeout.Value = o.ConnectionTimeout;
      boxCommandTimeout.Value = o.CommandTimeout;
      boxWaitAtLowPriority.Checked = o.WaitAtLowPriority;
      boxMaxDuration.EditValue = o.MaxDuration;
      boxAbortAfterWait.EditValue = o.AbortAfterWait;
      boxDataCompression.EditValue = o.DataCompression;
      boxNoRecompute.EditValue = o.NoRecompute;
      boxFillFactor.EditValue = o.FillFactor;
      boxScanMode.EditValue = o.ScanMode;
      boxShowSettingsWhenConnectionChanged.Checked = o.ShowSettingsWhenConnectionChanged;

      boxScanHeap.Checked = o.ScanHeap;
      boxScanClusteredIndex.Checked = o.ScanClusteredIndex;
      boxScanNonClusteredIndex.Checked = o.ScanNonClusteredIndex;
      boxScanClusteredColumnstore.Checked = o.ScanClusteredColumnstore;
      boxScanNonClusteredColumnstore.Checked = o.ScanNonClusteredColumnstore;
      boxScanMissingIndex.Checked = o.ScanMissingIndex;

      boxIncludeSchemas.EditValue = string.Join(";", o.IncludeSchemas);
      boxExcludeSchemas.EditValue = string.Join(";", o.ExcludeSchemas);
      boxIncludeObject.EditValue = string.Join(";", o.IncludeObject);
      boxExcludeObject.EditValue = string.Join(";", o.ExcludeObject);
      boxIgnorePermissions.Checked = o.IgnorePermissions;
      boxIgnoreReadOnlyFL.Checked = o.IgnoreReadOnlyFL;
      boxIgnoreHeapWithCompression.Checked = o.IgnoreHeapWithCompression;
      boxShowOnlyMore1000Rows.Checked = o.ShowOnlyMore1000Rows;
    }

    public Options GetSettings() {
      return new Options {
        SkipOperation = Utils.GetValueFromDescription<IndexOp>((string)boxSkipThreshold.EditValue),
        FirstOperation = Utils.GetValueFromDescription<IndexOp>((string)boxFirstThreshold.EditValue),
        SecondOperation = Utils.GetValueFromDescription<IndexOp>((string)boxSecondThreshold.EditValue),
        FirstThreshold = boxThreshold.Value.Minimum,
        SecondThreshold = boxThreshold.Value.Maximum,
        MinIndexSize = boxMinIndexSize.Value.Minimum,
        PreDescribeSize = boxMinIndexSize.Value.Maximum,
        MaxIndexSize = boxMaxIndexSize.Value,
        DelayAfterFix = (int)boxDelayAfterFix.Value,
        MultiThreadingCount = (int)boxMultiThreadingCount.Value,
        MaxDop = (int)boxMaxDod.Value,
        Online = boxOnline.Checked,
        PadIndex = boxPadIndex.Checked,
        SortInTempDb = boxSortInTempDb.Checked,
        LobCompaction = boxLobCompaction.Checked,
        SampleStatsPercent = (int)boxStatsSamplePercent.Value,
        ConnectionTimeout = (int)boxConnectionTimeout.Value,
        CommandTimeout = (int)boxCommandTimeout.Value,
        WaitAtLowPriority = boxWaitAtLowPriority.Checked,
        MaxDuration = (int)boxMaxDuration.Value,
        AbortAfterWait = boxAbortAfterWait.EditValue.ToEnum<AbortAfterWait>(),
        DataCompression = boxDataCompression.EditValue.ToEnum<DataCompression>(),
        NoRecompute = boxNoRecompute.EditValue.ToEnum<NoRecompute>(),
        FillFactor = (int)boxFillFactor.Value,
        ScanMode = boxScanMode.EditValue.ToEnum<ScanMode>(),
        ShowSettingsWhenConnectionChanged = boxShowSettingsWhenConnectionChanged.Checked,

        ScanHeap = boxScanHeap.Checked,
        ScanClusteredIndex = boxScanClusteredIndex.Checked,
        ScanNonClusteredIndex = boxScanNonClusteredIndex.Checked,
        ScanClusteredColumnstore = boxScanClusteredColumnstore.Checked,
        ScanNonClusteredColumnstore = boxScanNonClusteredColumnstore.Checked,
        ScanMissingIndex = boxScanMissingIndex.Checked,

        IncludeSchemas = new List<string> (boxIncludeSchemas.EditValue.ToString().Split(';')),
        ExcludeSchemas = new List<string> (boxExcludeSchemas.EditValue.ToString().Split(';')),
        IncludeObject = new List<string> (boxIncludeObject.EditValue.ToString().Split(';')),
        ExcludeObject = new List<string> (boxExcludeObject.EditValue.ToString().Split(';')),
        IgnorePermissions = boxIgnorePermissions.Checked,
        IgnoreReadOnlyFL = boxIgnoreReadOnlyFL.Checked,
        IgnoreHeapWithCompression = boxIgnoreHeapWithCompression.Checked,
        ShowOnlyMore1000Rows = boxShowOnlyMore1000Rows.Checked
      };

    }

    #region Controls

    private void ButtonRestoreClick(object sender, EventArgs e) {
      UpdateControls(new Options());
    }

    private void IndexSizeValueChanged(object sender, EventArgs e) {
      labelSize.Text = $@">= {boxMinIndexSize.Value.Minimum.FormatMbSize()} ... {boxMinIndexSize.Value.Maximum.FormatMbSize()} <= {boxMaxIndexSize.Value.FormatMbSize()}";
    }

    private void ThresholdValueChanged(object sender, EventArgs e) {
      labelSkipThreshold.Text = $@"< {boxThreshold.Value.Minimum}%";
      labelFirstThreshold.Text = $@">= {boxThreshold.Value.Minimum}% AND < {boxThreshold.Value.Maximum }%";
      labelSecondThreshold.Text = $@">= {boxThreshold.Value.Maximum}%";
    }

    private void TrackBarEditValueChanged(object sender, EventArgs e) {
      var obj = (RangeTrackBarControl)sender;
      TrackBarRange val = obj.Value;

      if (val.Minimum == val.Maximum) {
        if (val.Minimum > 0)
          val.Minimum -= 1;
        else
          val.Maximum += 1;
      }

      obj.Value = val;
    }

    private void IndexTypeCheckedChanged(object sender, EventArgs e) {
      buttonOK.Enabled = (
             boxScanHeap.Checked
          || boxScanClusteredIndex.Checked
          || boxScanNonClusteredIndex.Checked
          || boxScanClusteredColumnstore.Checked
          || boxScanNonClusteredColumnstore.Checked
          || boxScanMissingIndex.Checked
        );
    }

    private void TokenValidate(object sender, TokenEditValidateTokenEventArgs e) {
      e.IsValid = true;
    }

    #endregion

    #region Override Methods

    protected override bool ProcessDialogKey(Keys keyData) {
      if (keyData == Keys.Escape) {
        DialogResult = DialogResult.Cancel;
        return true;
      }

      if (keyData == Keys.Enter && buttonOK.Enabled) {
        DialogResult = DialogResult.OK;
        return true;
      }

      return base.ProcessDialogKey(keyData);
    }

    #endregion

  }

}
