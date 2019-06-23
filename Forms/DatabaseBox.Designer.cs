namespace SQLIndexManager {
  partial class DatabaseBox {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar3 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar4 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      this.colDataSize = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLogSize = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colDatabase = new DevExpress.XtraGrid.Columns.GridColumn();
      this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
      this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
      this.buttonRefresh = new DevExpress.XtraEditors.SimpleButton();
      this.grid = new DevExpress.XtraGrid.GridControl();
      this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colRecoveryModel = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
      this.SuspendLayout();
      // 
      // colDataSize
      // 
      this.colDataSize.Caption = "Data Size";
      this.colDataSize.FieldName = "DataSize";
      this.colDataSize.MaxWidth = 100;
      this.colDataSize.MinWidth = 80;
      this.colDataSize.Name = "colDataSize";
      this.colDataSize.Visible = true;
      this.colDataSize.VisibleIndex = 3;
      this.colDataSize.Width = 100;
      // 
      // colLogSize
      // 
      this.colLogSize.Caption = "Log Size";
      this.colLogSize.FieldName = "LogSize";
      this.colLogSize.MaxWidth = 100;
      this.colLogSize.MinWidth = 80;
      this.colLogSize.Name = "colLogSize";
      this.colLogSize.Visible = true;
      this.colLogSize.VisibleIndex = 4;
      this.colLogSize.Width = 100;
      // 
      // colDatabase
      // 
      this.colDatabase.Caption = "Database";
      this.colDatabase.FieldName = "DatabaseName";
      this.colDatabase.Name = "colDatabase";
      this.colDatabase.Visible = true;
      this.colDatabase.VisibleIndex = 1;
      this.colDatabase.Width = 100;
      // 
      // buttonCancel
      // 
      this.buttonCancel.AllowFocus = false;
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(582, 307);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 3;
      this.buttonCancel.Text = "Cancel";
      // 
      // buttonOK
      // 
      this.buttonOK.AllowFocus = false;
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Enabled = false;
      this.buttonOK.Location = new System.Drawing.Point(501, 307);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 2;
      this.buttonOK.Text = "OK";
      // 
      // buttonRefresh
      // 
      this.buttonRefresh.AllowFocus = false;
      this.buttonRefresh.Location = new System.Drawing.Point(12, 307);
      this.buttonRefresh.Name = "buttonRefresh";
      this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
      this.buttonRefresh.TabIndex = 1;
      this.buttonRefresh.Text = "Refresh";
      this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefreshClick);
      // 
      // grid
      // 
      this.grid.Font = new System.Drawing.Font("Tahoma", 9F);
      this.grid.Location = new System.Drawing.Point(12, 6);
      this.grid.MainView = this.view;
      this.grid.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
      this.grid.Name = "grid";
      this.grid.Size = new System.Drawing.Size(645, 293);
      this.grid.TabIndex = 0;
      this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
      // 
      // view
      // 
      this.view.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.view.Appearance.EvenRow.Options.UseBackColor = true;
      this.view.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.view.Appearance.FocusedRow.Options.UseBackColor = true;
      this.view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.view.Appearance.HeaderPanel.Options.UseFont = true;
      this.view.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Transparent;
      this.view.Appearance.HideSelectionRow.Options.UseBackColor = true;
      this.view.Appearance.OddRow.BackColor = System.Drawing.Color.Gainsboro;
      this.view.Appearance.OddRow.Options.UseBackColor = true;
      this.view.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.view.Appearance.Row.Options.UseFont = true;
      this.view.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.view.Appearance.SelectedRow.Options.UseBackColor = true;
      this.view.ColumnPanelRowHeight = 26;
      this.view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatabase,
            this.colRecoveryModel,
            this.colDataSize,
            this.colLogSize});
      this.view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
      gridFormatRule3.Column = this.colDataSize;
      gridFormatRule3.ColumnApplyTo = this.colDataSize;
      gridFormatRule3.Name = "DataSize";
      formatConditionRuleDataBar3.AllowNegativeAxis = false;
      formatConditionRuleDataBar3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(247)))));
      formatConditionRuleDataBar3.Appearance.BackColor2 = System.Drawing.Color.Transparent;
      formatConditionRuleDataBar3.Appearance.BorderColor = System.Drawing.Color.Transparent;
      formatConditionRuleDataBar3.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar3.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar3.DrawAxis = false;
      formatConditionRuleDataBar3.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar3.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      formatConditionRuleDataBar3.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar3.PredefinedName = null;
      formatConditionRuleDataBar3.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule3.Rule = formatConditionRuleDataBar3;
      gridFormatRule4.Column = this.colLogSize;
      gridFormatRule4.ColumnApplyTo = this.colLogSize;
      gridFormatRule4.Name = "LogSize";
      formatConditionRuleDataBar4.AllowNegativeAxis = false;
      formatConditionRuleDataBar4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
      formatConditionRuleDataBar4.Appearance.BackColor2 = System.Drawing.Color.Transparent;
      formatConditionRuleDataBar4.Appearance.BorderColor = System.Drawing.Color.Transparent;
      formatConditionRuleDataBar4.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar4.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar4.DrawAxis = false;
      formatConditionRuleDataBar4.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar4.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      formatConditionRuleDataBar4.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar4.PredefinedName = null;
      formatConditionRuleDataBar4.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule4.Rule = formatConditionRuleDataBar4;
      this.view.FormatRules.Add(gridFormatRule3);
      this.view.FormatRules.Add(gridFormatRule4);
      this.view.GridControl = this.grid;
      this.view.Name = "view";
      this.view.OptionsBehavior.Editable = false;
      this.view.OptionsCustomization.AllowColumnMoving = false;
      this.view.OptionsCustomization.AllowColumnResizing = false;
      this.view.OptionsCustomization.AllowFilter = false;
      this.view.OptionsCustomization.AllowGroup = false;
      this.view.OptionsCustomization.AllowQuickHideColumns = false;
      this.view.OptionsFilter.AllowFilterEditor = false;
      this.view.OptionsMenu.EnableColumnMenu = false;
      this.view.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
      this.view.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.view.OptionsSelection.MultiSelect = true;
      this.view.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
      this.view.OptionsView.EnableAppearanceEvenRow = true;
      this.view.OptionsView.EnableAppearanceOddRow = true;
      this.view.OptionsView.ShowGroupPanel = false;
      this.view.OptionsView.ShowIndicator = false;
      this.view.RowHeight = 24;
      this.view.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDataSize, DevExpress.Data.ColumnSortOrder.Descending)});
      this.view.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.GridSelectionChanged);
      this.view.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.GridCustomColumnDisplayText);
      this.view.DoubleClick += new System.EventHandler(this.GridDoubleClick);
      // 
      // colRecoveryModel
      // 
      this.colRecoveryModel.Caption = "Recovery Model";
      this.colRecoveryModel.FieldName = "RecoveryModel";
      this.colRecoveryModel.MaxWidth = 110;
      this.colRecoveryModel.MinWidth = 80;
      this.colRecoveryModel.Name = "colRecoveryModel";
      this.colRecoveryModel.Visible = true;
      this.colRecoveryModel.VisibleIndex = 2;
      this.colRecoveryModel.Width = 110;
      // 
      // DatabaseBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(667, 340);
      this.Controls.Add(this.grid);
      this.Controls.Add(this.buttonRefresh);
      this.Controls.Add(this.buttonOK);
      this.Controls.Add(this.buttonCancel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DatabaseBox";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select Databases";
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton buttonCancel;
    private DevExpress.XtraEditors.SimpleButton buttonOK;
    private DevExpress.XtraEditors.SimpleButton buttonRefresh;
    private DevExpress.XtraGrid.GridControl grid;
    private DevExpress.XtraGrid.Views.Grid.GridView view;
    private DevExpress.XtraGrid.Columns.GridColumn colDataSize;
    private DevExpress.XtraGrid.Columns.GridColumn colLogSize;
    private DevExpress.XtraGrid.Columns.GridColumn colDatabase;
    private DevExpress.XtraGrid.Columns.GridColumn colRecoveryModel;
  }
}