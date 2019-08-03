using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQLIndexManager {

  public partial class SettingsBox : XtraForm {
    public SettingsBox() {
      InitializeComponent();
      UpdateControls(Settings.Options);
    }

    private void UpdateControls(Options o) {
      boxThreshold.Value = new TrackBarRange(o.ReorganizeThreshold, o.RebuildThreshold);
      boxMinIndexSize.Value = new TrackBarRange(o.MinIndexSize, o.PreDescribeSize);
      boxMaxIndexSize.Value = o.MaxIndexSize;
      boxOnline.Checked = o.Online;
      boxSortInTempDb.Checked = o.SortInTempDb;
      boxLobCompaction.Checked = o.LobCompaction;
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
    }

    public Options GetSettings() {
      return new Options {
        ReorganizeThreshold = boxThreshold.Value.Minimum,
        RebuildThreshold = boxThreshold.Value.Maximum,
        MinIndexSize = boxMinIndexSize.Value.Minimum,
        PreDescribeSize = boxMinIndexSize.Value.Maximum,
        MaxIndexSize = boxMaxIndexSize.Value,
        MaxDop = (int)boxMaxDod.Value,
        Online = boxOnline.Checked,
        SortInTempDb = boxSortInTempDb.Checked,
        LobCompaction = boxLobCompaction.Checked,
        SampleStatsPercent = (int)boxStatsSamplePercent.Value,
        ConnectionTimeout = (int)boxConnectionTimeout.Value,
        CommandTimeout = (int)boxCommandTimeout.Value,
        WaitAtLowPriority = boxWaitAtLowPriority.Checked,
        MaxDuration = (int)boxMaxDuration.Value,
        AbortAfterWait = (string)boxAbortAfterWait.EditValue,
        DataCompression = (string)boxDataCompression.EditValue,
        NoRecompute = (string)boxNoRecompute.EditValue,
        FillFactor = (int)boxFillFactor.Value,
        ScanMode = (string)boxScanMode.EditValue,

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
        IgnoreReadOnlyFL = boxIgnoreReadOnlyFL.Checked
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
      labelReorganize.Text = $@">= {boxThreshold.Value.Minimum}% AND < {boxThreshold.Value.Maximum }%";
      labelRebuild.Text = $@">= {boxThreshold.Value.Maximum}%";
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
