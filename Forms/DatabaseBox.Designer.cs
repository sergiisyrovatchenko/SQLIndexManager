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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar1 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar2 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar3 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar4 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
            this.colDataSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataFreeSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogFreeSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatabase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.DatabaseBoxlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRecoveryModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogReuseWait = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.buttonOK = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControlGroup();
            this.searchControl1item = new DevExpress.XtraLayout.LayoutControlItem();
            this.griditem = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonRefreshitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonOKitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonCancelitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseBoxlayoutControl1ConvertedLayout)).BeginInit();
            this.DatabaseBoxlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.griditem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRefreshitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOKitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancelitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // colDataSize
            // 
            this.colDataSize.Caption = "Data Size";
            this.colDataSize.FieldName = "DataSize";
            this.colDataSize.MaxWidth = 110;
            this.colDataSize.MinWidth = 110;
            this.colDataSize.Name = "colDataSize";
            this.colDataSize.Visible = true;
            this.colDataSize.VisibleIndex = 4;
            this.colDataSize.Width = 110;
            // 
            // colDataFreeSize
            // 
            this.colDataFreeSize.Caption = "Free Size";
            this.colDataFreeSize.FieldName = "DataFreeSize";
            this.colDataFreeSize.MaxWidth = 100;
            this.colDataFreeSize.MinWidth = 100;
            this.colDataFreeSize.Name = "colDataFreeSize";
            this.colDataFreeSize.Visible = true;
            this.colDataFreeSize.VisibleIndex = 5;
            this.colDataFreeSize.Width = 100;
            // 
            // colLogSize
            // 
            this.colLogSize.Caption = "Log Size";
            this.colLogSize.FieldName = "LogSize";
            this.colLogSize.MaxWidth = 110;
            this.colLogSize.MinWidth = 110;
            this.colLogSize.Name = "colLogSize";
            this.colLogSize.Visible = true;
            this.colLogSize.VisibleIndex = 6;
            this.colLogSize.Width = 110;
            // 
            // colLogFreeSize
            // 
            this.colLogFreeSize.Caption = "Free Size";
            this.colLogFreeSize.FieldName = "LogFreeSize";
            this.colLogFreeSize.MaxWidth = 100;
            this.colLogFreeSize.MinWidth = 100;
            this.colLogFreeSize.Name = "colLogFreeSize";
            this.colLogFreeSize.Visible = true;
            this.colLogFreeSize.VisibleIndex = 7;
            this.colLogFreeSize.Width = 100;
            // 
            // colDatabase
            // 
            this.colDatabase.Caption = "Database";
            this.colDatabase.FieldName = "DatabaseName";
            this.colDatabase.Name = "colDatabase";
            this.colDatabase.Visible = true;
            this.colDatabase.VisibleIndex = 1;
            this.colDatabase.Width = 241;
            // 
            // buttonCancel
            // 
            this.buttonCancel.AllowFocus = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(864, 366);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(76, 22);
            this.buttonCancel.StyleController = this.DatabaseBoxlayoutControl1ConvertedLayout;
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            // 
            // DatabaseBoxlayoutControl1ConvertedLayout
            // 
            this.DatabaseBoxlayoutControl1ConvertedLayout.Controls.Add(this.searchControl1);
            this.DatabaseBoxlayoutControl1ConvertedLayout.Controls.Add(this.grid);
            this.DatabaseBoxlayoutControl1ConvertedLayout.Controls.Add(this.buttonRefresh);
            this.DatabaseBoxlayoutControl1ConvertedLayout.Controls.Add(this.buttonOK);
            this.DatabaseBoxlayoutControl1ConvertedLayout.Controls.Add(this.buttonCancel);
            this.DatabaseBoxlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseBoxlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.DatabaseBoxlayoutControl1ConvertedLayout.Name = "DatabaseBoxlayoutControl1ConvertedLayout";
            this.DatabaseBoxlayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(968, 152, 650, 400);
            this.DatabaseBoxlayoutControl1ConvertedLayout.Root = this.layoutControl;
            this.DatabaseBoxlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(952, 400);
            this.DatabaseBoxlayoutControl1ConvertedLayout.TabIndex = 5;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.grid;
            this.searchControl1.Location = new System.Drawing.Point(87, 367);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.grid;
            this.searchControl1.Size = new System.Drawing.Size(219, 20);
            this.searchControl1.StyleController = this.DatabaseBoxlayoutControl1ConvertedLayout;
            this.searchControl1.TabIndex = 4;
            // 
            // grid
            // 
            this.grid.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grid.Location = new System.Drawing.Point(12, 7);
            this.grid.MainView = this.view;
            this.grid.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(928, 353);
            this.grid.TabIndex = 0;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // view
            // 
            this.view.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.view.Appearance.EvenRow.Options.UseBackColor = true;
            this.view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.view.Appearance.HeaderPanel.Options.UseFont = true;
            this.view.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Transparent;
            this.view.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.view.Appearance.OddRow.BackColor = System.Drawing.Color.Gainsboro;
            this.view.Appearance.OddRow.Options.UseBackColor = true;
            this.view.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.view.Appearance.Row.Options.UseFont = true;
            this.view.Appearance.SelectedRow.BackColor = System.Drawing.Color.Transparent;
            this.view.Appearance.SelectedRow.Options.UseBackColor = true;
            this.view.ColumnPanelRowHeight = 26;
            this.view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatabase,
            this.colRecoveryModel,
            this.colLogReuseWait,
            this.colDataSize,
            this.colDataFreeSize,
            this.colLogSize,
            this.colLogFreeSize});
            this.view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            gridFormatRule1.Column = this.colDataSize;
            gridFormatRule1.ColumnApplyTo = this.colDataSize;
            gridFormatRule1.Name = "DataSize";
            formatConditionRuleDataBar1.AllowNegativeAxis = false;
            formatConditionRuleDataBar1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(247)))));
            formatConditionRuleDataBar1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(214)))), ((int)(((byte)(254)))));
            formatConditionRuleDataBar1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(247)))));
            formatConditionRuleDataBar1.Appearance.Options.UseBackColor = true;
            formatConditionRuleDataBar1.Appearance.Options.UseBorderColor = true;
            formatConditionRuleDataBar1.DrawAxis = false;
            formatConditionRuleDataBar1.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            formatConditionRuleDataBar1.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar1.PredefinedName = null;
            formatConditionRuleDataBar1.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
            gridFormatRule1.Rule = formatConditionRuleDataBar1;
            gridFormatRule2.Column = this.colDataFreeSize;
            gridFormatRule2.ColumnApplyTo = this.colDataFreeSize;
            gridFormatRule2.Name = "DataFreeSize";
            formatConditionRuleDataBar2.AllowNegativeAxis = false;
            formatConditionRuleDataBar2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(247)))));
            formatConditionRuleDataBar2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(214)))), ((int)(((byte)(254)))));
            formatConditionRuleDataBar2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(247)))));
            formatConditionRuleDataBar2.Appearance.Options.UseBackColor = true;
            formatConditionRuleDataBar2.Appearance.Options.UseBorderColor = true;
            formatConditionRuleDataBar2.DrawAxis = false;
            formatConditionRuleDataBar2.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            formatConditionRuleDataBar2.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar2.PredefinedName = null;
            formatConditionRuleDataBar2.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
            gridFormatRule2.Rule = formatConditionRuleDataBar2;
            gridFormatRule3.Column = this.colLogSize;
            gridFormatRule3.ColumnApplyTo = this.colLogSize;
            gridFormatRule3.Name = "LogSize";
            formatConditionRuleDataBar3.AllowNegativeAxis = false;
            formatConditionRuleDataBar3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
            formatConditionRuleDataBar3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(243)))), ((int)(((byte)(233)))));
            formatConditionRuleDataBar3.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
            formatConditionRuleDataBar3.Appearance.Options.UseBackColor = true;
            formatConditionRuleDataBar3.Appearance.Options.UseBorderColor = true;
            formatConditionRuleDataBar3.DrawAxis = false;
            formatConditionRuleDataBar3.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            formatConditionRuleDataBar3.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar3.PredefinedName = null;
            formatConditionRuleDataBar3.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
            gridFormatRule3.Rule = formatConditionRuleDataBar3;
            gridFormatRule4.Column = this.colLogFreeSize;
            gridFormatRule4.ColumnApplyTo = this.colLogFreeSize;
            gridFormatRule4.Name = "LogFreeSize";
            formatConditionRuleDataBar4.AllowNegativeAxis = false;
            formatConditionRuleDataBar4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
            formatConditionRuleDataBar4.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(243)))), ((int)(((byte)(233)))));
            formatConditionRuleDataBar4.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
            formatConditionRuleDataBar4.Appearance.Options.UseBackColor = true;
            formatConditionRuleDataBar4.Appearance.Options.UseBorderColor = true;
            formatConditionRuleDataBar4.DrawAxis = false;
            formatConditionRuleDataBar4.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            formatConditionRuleDataBar4.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleDataBar4.PredefinedName = null;
            formatConditionRuleDataBar4.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
            gridFormatRule4.Rule = formatConditionRuleDataBar4;
            this.view.FormatRules.Add(gridFormatRule1);
            this.view.FormatRules.Add(gridFormatRule2);
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
            this.view.OptionsFind.AllowFindPanel = false;
            this.view.OptionsFind.FindFilterColumns = "DatabaseName";
            this.view.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.view.OptionsFind.FindNullPrompt = "";
            this.view.OptionsFind.ShowClearButton = false;
            this.view.OptionsFind.ShowCloseButton = false;
            this.view.OptionsFind.ShowFindButton = false;
            this.view.OptionsMenu.EnableColumnMenu = false;
            this.view.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.view.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.view.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.view.OptionsSelection.EnableAppearanceHideSelection = false;
            this.view.OptionsSelection.MultiSelect = true;
            this.view.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.view.OptionsSelection.UseIndicatorForSelection = false;
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
            this.colRecoveryModel.MaxWidth = 105;
            this.colRecoveryModel.MinWidth = 105;
            this.colRecoveryModel.Name = "colRecoveryModel";
            this.colRecoveryModel.Visible = true;
            this.colRecoveryModel.VisibleIndex = 2;
            this.colRecoveryModel.Width = 105;
            // 
            // colLogReuseWait
            // 
            this.colLogReuseWait.Caption = "Log Reuse Wait";
            this.colLogReuseWait.FieldName = "LogReuseWait";
            this.colLogReuseWait.MaxWidth = 130;
            this.colLogReuseWait.MinWidth = 130;
            this.colLogReuseWait.Name = "colLogReuseWait";
            this.colLogReuseWait.Visible = true;
            this.colLogReuseWait.VisibleIndex = 3;
            this.colLogReuseWait.Width = 130;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.AllowFocus = false;
            this.buttonRefresh.Location = new System.Drawing.Point(12, 366);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(71, 22);
            this.buttonRefresh.StyleController = this.DatabaseBoxlayoutControl1ConvertedLayout;
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefreshClick);
            // 
            // buttonOK
            // 
            this.buttonOK.AllowFocus = false;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(784, 366);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(76, 22);
            this.buttonOK.StyleController = this.DatabaseBoxlayoutControl1ConvertedLayout;
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            // 
            // layoutControl
            // 
            this.layoutControl.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControl.GroupBordersVisible = false;
            this.layoutControl.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.searchControl1item,
            this.griditem,
            this.buttonRefreshitem,
            this.buttonOKitem,
            this.buttonCancelitem,
            this.emptySpaceItem1});
            this.layoutControl.Name = "Root";
            this.layoutControl.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 5, 10);
            this.layoutControl.Size = new System.Drawing.Size(952, 400);
            this.layoutControl.TextVisible = false;
            // 
            // searchControl1item
            // 
            this.searchControl1item.Control = this.searchControl1;
            this.searchControl1item.Location = new System.Drawing.Point(75, 359);
            this.searchControl1item.MaxSize = new System.Drawing.Size(223, 26);
            this.searchControl1item.MinSize = new System.Drawing.Size(223, 26);
            this.searchControl1item.Name = "searchControl1item";
            this.searchControl1item.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 3, 2);
            this.searchControl1item.Size = new System.Drawing.Size(223, 26);
            this.searchControl1item.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.searchControl1item.TextSize = new System.Drawing.Size(0, 0);
            this.searchControl1item.TextVisible = false;
            // 
            // griditem
            // 
            this.griditem.Control = this.grid;
            this.griditem.Location = new System.Drawing.Point(0, 0);
            this.griditem.Name = "griditem";
            this.griditem.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 4);
            this.griditem.Size = new System.Drawing.Size(932, 359);
            this.griditem.TextSize = new System.Drawing.Size(0, 0);
            this.griditem.TextVisible = false;
            // 
            // buttonRefreshitem
            // 
            this.buttonRefreshitem.Control = this.buttonRefresh;
            this.buttonRefreshitem.Location = new System.Drawing.Point(0, 359);
            this.buttonRefreshitem.MaxSize = new System.Drawing.Size(75, 26);
            this.buttonRefreshitem.MinSize = new System.Drawing.Size(75, 26);
            this.buttonRefreshitem.Name = "buttonRefreshitem";
            this.buttonRefreshitem.Size = new System.Drawing.Size(75, 26);
            this.buttonRefreshitem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.buttonRefreshitem.TextSize = new System.Drawing.Size(0, 0);
            this.buttonRefreshitem.TextVisible = false;
            // 
            // buttonOKitem
            // 
            this.buttonOKitem.Control = this.buttonOK;
            this.buttonOKitem.Location = new System.Drawing.Point(772, 359);
            this.buttonOKitem.MaxSize = new System.Drawing.Size(80, 26);
            this.buttonOKitem.MinSize = new System.Drawing.Size(80, 26);
            this.buttonOKitem.Name = "buttonOKitem";
            this.buttonOKitem.Size = new System.Drawing.Size(80, 26);
            this.buttonOKitem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.buttonOKitem.TextSize = new System.Drawing.Size(0, 0);
            this.buttonOKitem.TextVisible = false;
            // 
            // buttonCancelitem
            // 
            this.buttonCancelitem.Control = this.buttonCancel;
            this.buttonCancelitem.Location = new System.Drawing.Point(852, 359);
            this.buttonCancelitem.MaxSize = new System.Drawing.Size(80, 26);
            this.buttonCancelitem.MinSize = new System.Drawing.Size(80, 26);
            this.buttonCancelitem.Name = "buttonCancelitem";
            this.buttonCancelitem.Size = new System.Drawing.Size(80, 26);
            this.buttonCancelitem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.buttonCancelitem.TextSize = new System.Drawing.Size(0, 0);
            this.buttonCancelitem.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(298, 359);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(474, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // DatabaseBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 400);
            this.Controls.Add(this.DatabaseBoxlayoutControl1ConvertedLayout);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(868, 432);
            this.Name = "DatabaseBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Databases";
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseBoxlayoutControl1ConvertedLayout)).EndInit();
            this.DatabaseBoxlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.griditem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRefreshitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonOKitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCancelitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
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
    private DevExpress.XtraGrid.Columns.GridColumn colLogReuseWait;
    private DevExpress.XtraEditors.SearchControl searchControl1;
    private DevExpress.XtraGrid.Columns.GridColumn colLogFreeSize;
    private DevExpress.XtraGrid.Columns.GridColumn colDataFreeSize;
    private DevExpress.XtraLayout.LayoutControl DatabaseBoxlayoutControl1ConvertedLayout;
    private DevExpress.XtraLayout.LayoutControlGroup layoutControl;
    private DevExpress.XtraLayout.LayoutControlItem searchControl1item;
    private DevExpress.XtraLayout.LayoutControlItem griditem;
    private DevExpress.XtraLayout.LayoutControlItem buttonRefreshitem;
    private DevExpress.XtraLayout.LayoutControlItem buttonOKitem;
    private DevExpress.XtraLayout.LayoutControlItem buttonCancelitem;
    private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
    private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
  }
}