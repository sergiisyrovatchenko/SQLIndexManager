using DevExpress.XtraBars;

namespace SQLIndexManager {
  partial class MainBox {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      DevExpress.XtraGrid.Columns.GridColumn Fragmentation;
      DevExpress.XtraGrid.Columns.GridColumn PagesCount;
      DevExpress.XtraGrid.Columns.GridColumn RowsCount;
      DevExpress.XtraGrid.Columns.GridColumn SchemaName;
      DevExpress.XtraGrid.Columns.GridColumn ObjectName;
      DevExpress.XtraGrid.Columns.GridColumn FileGroupName;
      DevExpress.XtraGrid.Columns.GridColumn IndexName;
      DevExpress.XtraGrid.Columns.GridColumn IndexType;
      DevExpress.XtraGrid.Columns.GridColumn PartitionNumber;
      DevExpress.XtraGrid.Columns.GridColumn IndexStats;
      DevExpress.XtraGrid.Columns.GridColumn TotalUpdates;
      DevExpress.XtraGrid.Columns.GridColumn LastUsage;
      DevExpress.XtraGrid.Columns.GridColumn FixType;
      DevExpress.XtraGrid.Columns.GridColumn Progress;
      DevExpress.XtraGrid.Columns.GridColumn UnusedPagesCount;
      DevExpress.XtraGrid.Columns.GridColumn Compression;
      DevExpress.XtraGrid.Columns.GridColumn DatabaseName;
      DevExpress.XtraGrid.Columns.GridColumn SavedSpace;
      DevExpress.XtraGrid.Columns.GridColumn FillFactor;
      DevExpress.XtraGrid.Columns.GridColumn IsPK;
      DevExpress.XtraGrid.Columns.GridColumn IsUnique;
      DevExpress.XtraGrid.Columns.GridColumn IsFiltered;
      DevExpress.XtraGrid.Columns.GridColumn IsPartitioned;
      DevExpress.XtraGrid.Columns.GridColumn TotalSeeks;
      DevExpress.XtraGrid.Columns.GridColumn TotalScans;
      DevExpress.XtraGrid.Columns.GridColumn TotalLookups;
      DevExpress.XtraGrid.Columns.GridColumn IndexColumns;
      DevExpress.XtraGrid.Columns.GridColumn IncludedColumns;
      DevExpress.XtraGrid.Columns.GridColumn Warning;
      DevExpress.XtraGrid.Columns.GridColumn PageSpaceUsed;
      DevExpress.XtraGrid.Columns.GridColumn Duration;
      DevExpress.XtraGrid.Columns.GridColumn Error;
      DevExpress.XtraGrid.Columns.GridColumn CreateDate;
      DevExpress.XtraGrid.Columns.GridColumn ModifyDate;
      DevExpress.XtraGrid.Columns.GridColumn LastRead;
      DevExpress.XtraGrid.Columns.GridColumn LastWrite;
      DevExpress.XtraGrid.Columns.GridColumn StatsSampled;
      DevExpress.XtraGrid.Columns.GridColumn IsNoRecompute;
      DevExpress.XtraGrid.Columns.GridColumn RowsSampled;
      DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
      DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
      DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
      DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon2 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
      DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon3 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar1 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar2 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar3 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar4 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule6 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar5 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule7 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar6 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule8 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar7 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule9 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar8 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule10 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar9 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule11 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar10 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule12 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar11 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule13 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar12 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
      DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
      DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
      DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
      DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
      DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
      DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
      DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
      DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
      DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
      DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
      DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBox));
      DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
      DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
      DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
      DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
      this.popupIndexOperation = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.grid = new DevExpress.XtraGrid.GridControl();
      this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.gridToolTipController = new DevExpress.Utils.ToolTipController(this.components);
      this.statusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
      this.labelDatabases = new DevExpress.XtraBars.BarStaticItem();
      this.labelErrors = new DevExpress.XtraBars.BarStaticItem();
      this.labelIndexes = new DevExpress.XtraBars.BarStaticItem();
      this.labelIndexesSize = new DevExpress.XtraBars.BarStaticItem();
      this.labelSavedSpace = new DevExpress.XtraBars.BarStaticItem();
      this.labelElapsedTime = new DevExpress.XtraBars.BarStaticItem();
      this.buttonStopScan = new DevExpress.XtraBars.BarButtonItem();
      this.buttonStopFix = new DevExpress.XtraBars.BarButtonItem();
      this.buttonAutoScroll = new DevExpress.XtraBars.BarButtonItem();
      this.buttonLog = new DevExpress.XtraBars.BarButtonItem();
      this.labelInfo = new DevExpress.XtraBars.BarStaticItem();
      this.labelServerInfo = new DevExpress.XtraBars.BarStaticItem();
      this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
      this.buttonNewConnection = new DevExpress.XtraBars.BarButtonItem();
      this.buttonFix = new DevExpress.XtraBars.BarButtonItem();
      this.popupFix = new DevExpress.XtraBars.PopupMenu(this.components);
      this.buttonCopyFix = new DevExpress.XtraBars.BarButtonItem();
      this.buttonSaveFix = new DevExpress.XtraBars.BarButtonItem();
      this.buttonOptions = new DevExpress.XtraBars.BarButtonItem();
      this.buttonAbout = new DevExpress.XtraBars.BarButtonItem();
      this.buttonRefreshIndex = new DevExpress.XtraBars.BarButtonItem();
      this.buttonDatabases = new DevExpress.XtraBars.BarButtonItem();
      this.boxSearch = new DevExpress.XtraBars.BarEditItem();
      this.boxSearchControl = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
      this.labelSeparator = new DevExpress.XtraBars.BarStaticItem();
      this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
      this.taskbar = new DevExpress.Utils.Taskbar.TaskbarAssistant();
      this.buttonFind = new DevExpress.XtraBars.BarButtonItem();
      Fragmentation = new DevExpress.XtraGrid.Columns.GridColumn();
      PagesCount = new DevExpress.XtraGrid.Columns.GridColumn();
      RowsCount = new DevExpress.XtraGrid.Columns.GridColumn();
      SchemaName = new DevExpress.XtraGrid.Columns.GridColumn();
      ObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
      FileGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
      IndexName = new DevExpress.XtraGrid.Columns.GridColumn();
      IndexType = new DevExpress.XtraGrid.Columns.GridColumn();
      PartitionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
      IndexStats = new DevExpress.XtraGrid.Columns.GridColumn();
      TotalUpdates = new DevExpress.XtraGrid.Columns.GridColumn();
      LastUsage = new DevExpress.XtraGrid.Columns.GridColumn();
      FixType = new DevExpress.XtraGrid.Columns.GridColumn();
      Progress = new DevExpress.XtraGrid.Columns.GridColumn();
      UnusedPagesCount = new DevExpress.XtraGrid.Columns.GridColumn();
      Compression = new DevExpress.XtraGrid.Columns.GridColumn();
      DatabaseName = new DevExpress.XtraGrid.Columns.GridColumn();
      SavedSpace = new DevExpress.XtraGrid.Columns.GridColumn();
      FillFactor = new DevExpress.XtraGrid.Columns.GridColumn();
      IsPK = new DevExpress.XtraGrid.Columns.GridColumn();
      IsUnique = new DevExpress.XtraGrid.Columns.GridColumn();
      IsFiltered = new DevExpress.XtraGrid.Columns.GridColumn();
      IsPartitioned = new DevExpress.XtraGrid.Columns.GridColumn();
      TotalSeeks = new DevExpress.XtraGrid.Columns.GridColumn();
      TotalScans = new DevExpress.XtraGrid.Columns.GridColumn();
      TotalLookups = new DevExpress.XtraGrid.Columns.GridColumn();
      IndexColumns = new DevExpress.XtraGrid.Columns.GridColumn();
      IncludedColumns = new DevExpress.XtraGrid.Columns.GridColumn();
      Warning = new DevExpress.XtraGrid.Columns.GridColumn();
      PageSpaceUsed = new DevExpress.XtraGrid.Columns.GridColumn();
      Duration = new DevExpress.XtraGrid.Columns.GridColumn();
      Error = new DevExpress.XtraGrid.Columns.GridColumn();
      CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
      ModifyDate = new DevExpress.XtraGrid.Columns.GridColumn();
      LastRead = new DevExpress.XtraGrid.Columns.GridColumn();
      LastWrite = new DevExpress.XtraGrid.Columns.GridColumn();
      StatsSampled = new DevExpress.XtraGrid.Columns.GridColumn();
      IsNoRecompute = new DevExpress.XtraGrid.Columns.GridColumn();
      RowsSampled = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.popupIndexOperation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupFix)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxSearchControl)).BeginInit();
      this.SuspendLayout();
      // 
      // Fragmentation
      // 
      Fragmentation.Caption = "Fragmentation";
      Fragmentation.FieldName = "Fragmentation";
      Fragmentation.MaxWidth = 103;
      Fragmentation.MinWidth = 103;
      Fragmentation.Name = "Fragmentation";
      Fragmentation.OptionsColumn.AllowEdit = false;
      Fragmentation.OptionsColumn.AllowFocus = false;
      Fragmentation.OptionsColumn.AllowShowHide = false;
      Fragmentation.OptionsColumn.AllowSize = false;
      Fragmentation.OptionsColumn.ShowInCustomizationForm = false;
      Fragmentation.OptionsFilter.AllowAutoFilter = false;
      Fragmentation.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      Fragmentation.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      Fragmentation.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      Fragmentation.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      Fragmentation.UnboundType = DevExpress.Data.UnboundColumnType.String;
      Fragmentation.Visible = true;
      Fragmentation.VisibleIndex = 8;
      Fragmentation.Width = 103;
      // 
      // PagesCount
      // 
      PagesCount.Caption = "Index Size";
      PagesCount.FieldName = "PagesCount";
      PagesCount.MaxWidth = 90;
      PagesCount.MinWidth = 90;
      PagesCount.Name = "PagesCount";
      PagesCount.OptionsColumn.AllowEdit = false;
      PagesCount.OptionsColumn.AllowFocus = false;
      PagesCount.OptionsColumn.AllowShowHide = false;
      PagesCount.OptionsColumn.AllowSize = false;
      PagesCount.OptionsColumn.ShowInCustomizationForm = false;
      PagesCount.OptionsFilter.AllowAutoFilter = false;
      PagesCount.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      PagesCount.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      PagesCount.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      PagesCount.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      PagesCount.Visible = true;
      PagesCount.VisibleIndex = 9;
      PagesCount.Width = 90;
      // 
      // RowsCount
      // 
      RowsCount.Caption = "Rows";
      RowsCount.FieldName = "RowsCount";
      RowsCount.MaxWidth = 100;
      RowsCount.MinWidth = 100;
      RowsCount.Name = "RowsCount";
      RowsCount.OptionsColumn.AllowEdit = false;
      RowsCount.OptionsColumn.AllowFocus = false;
      RowsCount.OptionsColumn.AllowSize = false;
      RowsCount.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      RowsCount.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      RowsCount.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      RowsCount.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      RowsCount.Visible = true;
      RowsCount.VisibleIndex = 11;
      RowsCount.Width = 100;
      // 
      // SchemaName
      // 
      SchemaName.Caption = "Schema";
      SchemaName.FieldName = "SchemaName";
      SchemaName.MaxWidth = 250;
      SchemaName.MinWidth = 60;
      SchemaName.Name = "SchemaName";
      SchemaName.OptionsColumn.AllowEdit = false;
      SchemaName.OptionsColumn.AllowFocus = false;
      SchemaName.OptionsColumn.AllowShowHide = false;
      SchemaName.OptionsColumn.ShowInCustomizationForm = false;
      SchemaName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      SchemaName.Visible = true;
      SchemaName.VisibleIndex = 3;
      SchemaName.Width = 60;
      // 
      // ObjectName
      // 
      ObjectName.Caption = "Object";
      ObjectName.FieldName = "ObjectName";
      ObjectName.MaxWidth = 700;
      ObjectName.MinWidth = 120;
      ObjectName.Name = "ObjectName";
      ObjectName.OptionsColumn.AllowEdit = false;
      ObjectName.OptionsColumn.AllowFocus = false;
      ObjectName.OptionsColumn.AllowShowHide = false;
      ObjectName.OptionsColumn.ShowInCustomizationForm = false;
      ObjectName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      ObjectName.Visible = true;
      ObjectName.VisibleIndex = 4;
      ObjectName.Width = 155;
      // 
      // FileGroupName
      // 
      FileGroupName.Caption = "File Group";
      FileGroupName.FieldName = "FileGroupName";
      FileGroupName.MaxWidth = 200;
      FileGroupName.MinWidth = 78;
      FileGroupName.Name = "FileGroupName";
      FileGroupName.OptionsColumn.AllowEdit = false;
      FileGroupName.OptionsColumn.AllowFocus = false;
      FileGroupName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      FileGroupName.Width = 78;
      // 
      // IndexName
      // 
      IndexName.Caption = "Index";
      IndexName.FieldName = "IndexName";
      IndexName.MaxWidth = 800;
      IndexName.MinWidth = 150;
      IndexName.Name = "IndexName";
      IndexName.OptionsColumn.AllowEdit = false;
      IndexName.OptionsColumn.AllowFocus = false;
      IndexName.OptionsColumn.AllowShowHide = false;
      IndexName.OptionsColumn.ShowInCustomizationForm = false;
      IndexName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      IndexName.Visible = true;
      IndexName.VisibleIndex = 5;
      IndexName.Width = 210;
      // 
      // IndexType
      // 
      IndexType.Caption = "Type";
      IndexType.FieldName = "IndexType";
      IndexType.MaxWidth = 250;
      IndexType.MinWidth = 80;
      IndexType.Name = "IndexType";
      IndexType.OptionsColumn.AllowEdit = false;
      IndexType.OptionsColumn.AllowFocus = false;
      IndexType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      IndexType.Visible = true;
      IndexType.VisibleIndex = 6;
      IndexType.Width = 100;
      // 
      // PartitionNumber
      // 
      PartitionNumber.AppearanceCell.Options.UseTextOptions = true;
      PartitionNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      PartitionNumber.Caption = "Partition";
      PartitionNumber.FieldName = "PartitionNumber";
      PartitionNumber.MaxWidth = 60;
      PartitionNumber.MinWidth = 60;
      PartitionNumber.Name = "PartitionNumber";
      PartitionNumber.OptionsColumn.AllowEdit = false;
      PartitionNumber.OptionsColumn.AllowFocus = false;
      PartitionNumber.OptionsColumn.AllowShowHide = false;
      PartitionNumber.OptionsColumn.AllowSize = false;
      PartitionNumber.OptionsColumn.ShowInCustomizationForm = false;
      PartitionNumber.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      PartitionNumber.Visible = true;
      PartitionNumber.VisibleIndex = 7;
      PartitionNumber.Width = 60;
      // 
      // IndexStats
      // 
      IndexStats.AppearanceCell.Options.UseTextOptions = true;
      IndexStats.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      IndexStats.Caption = "Statistics";
      IndexStats.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      IndexStats.FieldName = "IndexStats";
      IndexStats.MaxWidth = 104;
      IndexStats.MinWidth = 104;
      IndexStats.Name = "IndexStats";
      IndexStats.OptionsColumn.AllowEdit = false;
      IndexStats.OptionsColumn.AllowFocus = false;
      IndexStats.OptionsColumn.AllowSize = false;
      IndexStats.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      IndexStats.Visible = true;
      IndexStats.VisibleIndex = 12;
      IndexStats.Width = 104;
      // 
      // TotalUpdates
      // 
      TotalUpdates.Caption = "Updates";
      TotalUpdates.FieldName = "TotalUpdates";
      TotalUpdates.MaxWidth = 90;
      TotalUpdates.MinWidth = 90;
      TotalUpdates.Name = "TotalUpdates";
      TotalUpdates.OptionsColumn.AllowEdit = false;
      TotalUpdates.OptionsColumn.AllowFocus = false;
      TotalUpdates.OptionsColumn.AllowSize = false;
      TotalUpdates.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      TotalUpdates.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      TotalUpdates.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      TotalUpdates.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      TotalUpdates.Visible = true;
      TotalUpdates.VisibleIndex = 16;
      TotalUpdates.Width = 90;
      // 
      // LastUsage
      // 
      LastUsage.AppearanceCell.Options.UseTextOptions = true;
      LastUsage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      LastUsage.Caption = "Last Usage";
      LastUsage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      LastUsage.FieldName = "LastUsage";
      LastUsage.MaxWidth = 104;
      LastUsage.MinWidth = 104;
      LastUsage.Name = "LastUsage";
      LastUsage.OptionsColumn.AllowEdit = false;
      LastUsage.OptionsColumn.AllowFocus = false;
      LastUsage.OptionsColumn.AllowSize = false;
      LastUsage.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      LastUsage.Visible = true;
      LastUsage.VisibleIndex = 17;
      LastUsage.Width = 104;
      // 
      // FixType
      // 
      FixType.Caption = "Fix";
      FixType.ColumnEdit = this.popupIndexOperation;
      FixType.FieldName = "FixType";
      FixType.MaxWidth = 220;
      FixType.MinWidth = 90;
      FixType.Name = "FixType";
      FixType.OptionsColumn.AllowIncrementalSearch = false;
      FixType.OptionsColumn.AllowShowHide = false;
      FixType.OptionsColumn.ShowInCustomizationForm = false;
      FixType.OptionsColumn.ShowInExpressionEditor = false;
      FixType.OptionsColumn.TabStop = false;
      FixType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      FixType.Visible = true;
      FixType.VisibleIndex = 1;
      FixType.Width = 90;
      // 
      // popupIndexOperation
      // 
      this.popupIndexOperation.AllowFocused = false;
      this.popupIndexOperation.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
      this.popupIndexOperation.AutoHeight = false;
      this.popupIndexOperation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.popupIndexOperation.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
      this.popupIndexOperation.DisplayMember = "Name";
      this.popupIndexOperation.DropDownRows = 9;
      this.popupIndexOperation.HideSelection = false;
      this.popupIndexOperation.ImmediatePopup = true;
      this.popupIndexOperation.KeyMember = "Fix";
      this.popupIndexOperation.Name = "popupIndexOperation";
      this.popupIndexOperation.PopupFormMinSize = new System.Drawing.Size(270, 0);
      this.popupIndexOperation.PopupSizeable = false;
      this.popupIndexOperation.ShowFooter = false;
      this.popupIndexOperation.ShowHeader = false;
      this.popupIndexOperation.ShowLines = false;
      this.popupIndexOperation.ShowPopupShadow = false;
      this.popupIndexOperation.ValueMember = "Fix";
      this.popupIndexOperation.BeforePopup += new System.EventHandler(this.FixedOpPopup);
      this.popupIndexOperation.EditValueChanged += new System.EventHandler(this.FixedOpPopupValueChanged);
      // 
      // Progress
      // 
      Progress.FieldName = "Progress";
      Progress.MaxWidth = 25;
      Progress.MinWidth = 25;
      Progress.Name = "Progress";
      Progress.OptionsColumn.AllowEdit = false;
      Progress.OptionsColumn.AllowFocus = false;
      Progress.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
      Progress.OptionsColumn.AllowIncrementalSearch = false;
      Progress.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
      Progress.OptionsColumn.AllowMove = false;
      Progress.OptionsColumn.AllowShowHide = false;
      Progress.OptionsColumn.AllowSize = false;
      Progress.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
      Progress.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
      Progress.OptionsColumn.ShowCaption = false;
      Progress.OptionsColumn.ShowInCustomizationForm = false;
      Progress.OptionsColumn.ShowInExpressionEditor = false;
      Progress.OptionsColumn.TabStop = false;
      Progress.OptionsFilter.AllowAutoFilter = false;
      Progress.OptionsFilter.AllowFilter = false;
      Progress.Width = 25;
      // 
      // UnusedPagesCount
      // 
      UnusedPagesCount.Caption = "Unused Space";
      UnusedPagesCount.FieldName = "UnusedPagesCount";
      UnusedPagesCount.MaxWidth = 90;
      UnusedPagesCount.MinWidth = 90;
      UnusedPagesCount.Name = "UnusedPagesCount";
      UnusedPagesCount.OptionsColumn.AllowEdit = false;
      UnusedPagesCount.OptionsColumn.AllowFocus = false;
      UnusedPagesCount.OptionsColumn.AllowSize = false;
      UnusedPagesCount.OptionsFilter.AllowAutoFilter = false;
      UnusedPagesCount.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      UnusedPagesCount.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      UnusedPagesCount.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      UnusedPagesCount.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      UnusedPagesCount.Visible = true;
      UnusedPagesCount.VisibleIndex = 10;
      UnusedPagesCount.Width = 90;
      // 
      // Compression
      // 
      Compression.Caption = "Compression";
      Compression.FieldName = "DataCompression";
      Compression.MaxWidth = 120;
      Compression.MinWidth = 78;
      Compression.Name = "Compression";
      Compression.OptionsColumn.AllowEdit = false;
      Compression.OptionsColumn.AllowFocus = false;
      Compression.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      Compression.Visible = true;
      Compression.VisibleIndex = 13;
      Compression.Width = 78;
      // 
      // DatabaseName
      // 
      DatabaseName.Caption = "Database";
      DatabaseName.FieldName = "DatabaseName";
      DatabaseName.MaxWidth = 250;
      DatabaseName.MinWidth = 100;
      DatabaseName.Name = "DatabaseName";
      DatabaseName.OptionsColumn.AllowEdit = false;
      DatabaseName.OptionsColumn.AllowFocus = false;
      DatabaseName.OptionsColumn.AllowShowHide = false;
      DatabaseName.OptionsColumn.ShowInCustomizationForm = false;
      DatabaseName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      DatabaseName.Visible = true;
      DatabaseName.VisibleIndex = 2;
      DatabaseName.Width = 100;
      // 
      // SavedSpace
      // 
      SavedSpace.Caption = "Saved Space";
      SavedSpace.FieldName = "PagesCountBefore";
      SavedSpace.MaxWidth = 90;
      SavedSpace.MinWidth = 90;
      SavedSpace.Name = "SavedSpace";
      SavedSpace.OptionsColumn.AllowEdit = false;
      SavedSpace.OptionsColumn.AllowFocus = false;
      SavedSpace.OptionsColumn.AllowShowHide = false;
      SavedSpace.OptionsColumn.AllowSize = false;
      SavedSpace.OptionsColumn.ShowInCustomizationForm = false;
      SavedSpace.OptionsFilter.AllowAutoFilter = false;
      SavedSpace.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      SavedSpace.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      SavedSpace.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      SavedSpace.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      SavedSpace.Width = 90;
      // 
      // FillFactor
      // 
      FillFactor.AppearanceCell.Options.UseTextOptions = true;
      FillFactor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      FillFactor.Caption = "Fill Factor";
      FillFactor.FieldName = "FillFactor";
      FillFactor.MaxWidth = 60;
      FillFactor.MinWidth = 60;
      FillFactor.Name = "FillFactor";
      FillFactor.OptionsColumn.AllowEdit = false;
      FillFactor.OptionsColumn.AllowFocus = false;
      FillFactor.OptionsColumn.AllowSize = false;
      FillFactor.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      FillFactor.Width = 60;
      // 
      // IsPK
      // 
      IsPK.Caption = "PK";
      IsPK.FieldName = "IsPK";
      IsPK.MaxWidth = 40;
      IsPK.MinWidth = 40;
      IsPK.Name = "IsPK";
      IsPK.OptionsColumn.AllowEdit = false;
      IsPK.OptionsColumn.AllowFocus = false;
      IsPK.OptionsColumn.AllowSize = false;
      IsPK.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      IsPK.Width = 40;
      // 
      // IsUnique
      // 
      IsUnique.Caption = "Unique";
      IsUnique.FieldName = "IsUnique";
      IsUnique.MaxWidth = 50;
      IsUnique.MinWidth = 50;
      IsUnique.Name = "IsUnique";
      IsUnique.OptionsColumn.AllowEdit = false;
      IsUnique.OptionsColumn.AllowFocus = false;
      IsUnique.OptionsColumn.AllowSize = false;
      IsUnique.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      IsUnique.Width = 50;
      // 
      // IsFiltered
      // 
      IsFiltered.Caption = "Filtered";
      IsFiltered.FieldName = "IsFiltered";
      IsFiltered.MaxWidth = 50;
      IsFiltered.MinWidth = 50;
      IsFiltered.Name = "IsFiltered";
      IsFiltered.OptionsColumn.AllowEdit = false;
      IsFiltered.OptionsColumn.AllowFocus = false;
      IsFiltered.OptionsColumn.AllowSize = false;
      IsFiltered.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      IsFiltered.Width = 50;
      // 
      // IsPartitioned
      // 
      IsPartitioned.Caption = "Partitioned";
      IsPartitioned.FieldName = "IsPartitioned";
      IsPartitioned.MaxWidth = 70;
      IsPartitioned.MinWidth = 70;
      IsPartitioned.Name = "IsPartitioned";
      IsPartitioned.OptionsColumn.AllowEdit = false;
      IsPartitioned.OptionsColumn.AllowFocus = false;
      IsPartitioned.OptionsColumn.AllowSize = false;
      IsPartitioned.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      IsPartitioned.Width = 70;
      // 
      // TotalSeeks
      // 
      TotalSeeks.Caption = "Seeks";
      TotalSeeks.FieldName = "TotalSeeks";
      TotalSeeks.MaxWidth = 90;
      TotalSeeks.MinWidth = 90;
      TotalSeeks.Name = "TotalSeeks";
      TotalSeeks.OptionsColumn.AllowEdit = false;
      TotalSeeks.OptionsColumn.AllowFocus = false;
      TotalSeeks.OptionsColumn.AllowSize = false;
      TotalSeeks.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      TotalSeeks.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      TotalSeeks.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      TotalSeeks.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      TotalSeeks.Visible = true;
      TotalSeeks.VisibleIndex = 15;
      TotalSeeks.Width = 90;
      // 
      // TotalScans
      // 
      TotalScans.Caption = "Scans";
      TotalScans.FieldName = "TotalScans";
      TotalScans.MaxWidth = 90;
      TotalScans.MinWidth = 90;
      TotalScans.Name = "TotalScans";
      TotalScans.OptionsColumn.AllowEdit = false;
      TotalScans.OptionsColumn.AllowFocus = false;
      TotalScans.OptionsColumn.AllowSize = false;
      TotalScans.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      TotalScans.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      TotalScans.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      TotalScans.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      TotalScans.Visible = true;
      TotalScans.VisibleIndex = 14;
      TotalScans.Width = 90;
      // 
      // TotalLookups
      // 
      TotalLookups.Caption = "Lookups";
      TotalLookups.FieldName = "TotalLookups";
      TotalLookups.MaxWidth = 95;
      TotalLookups.MinWidth = 95;
      TotalLookups.Name = "TotalLookups";
      TotalLookups.OptionsColumn.AllowEdit = false;
      TotalLookups.OptionsColumn.AllowFocus = false;
      TotalLookups.OptionsColumn.AllowSize = false;
      TotalLookups.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      TotalLookups.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      TotalLookups.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      TotalLookups.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      TotalLookups.Width = 95;
      // 
      // IndexColumns
      // 
      IndexColumns.Caption = "Index Columns";
      IndexColumns.FieldName = "IndexColumns";
      IndexColumns.MaxWidth = 1000;
      IndexColumns.MinWidth = 150;
      IndexColumns.Name = "IndexColumns";
      IndexColumns.OptionsColumn.AllowEdit = false;
      IndexColumns.OptionsColumn.AllowFocus = false;
      IndexColumns.OptionsFilter.AllowFilter = false;
      IndexColumns.Width = 150;
      // 
      // IncludedColumns
      // 
      IncludedColumns.Caption = "Included Columns";
      IncludedColumns.FieldName = "IncludedColumns";
      IncludedColumns.MaxWidth = 1000;
      IncludedColumns.MinWidth = 150;
      IncludedColumns.Name = "IncludedColumns";
      IncludedColumns.OptionsColumn.AllowEdit = false;
      IncludedColumns.OptionsColumn.AllowFocus = false;
      IncludedColumns.OptionsFilter.AllowFilter = false;
      IncludedColumns.Width = 150;
      // 
      // Warning
      // 
      Warning.AppearanceCell.Options.UseTextOptions = true;
      Warning.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      Warning.Caption = "Warning";
      Warning.FieldName = "Warning";
      Warning.MaxWidth = 90;
      Warning.MinWidth = 90;
      Warning.Name = "Warning";
      Warning.OptionsColumn.AllowEdit = false;
      Warning.OptionsColumn.AllowFocus = false;
      Warning.OptionsColumn.AllowSize = false;
      Warning.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      Warning.Width = 90;
      // 
      // PageSpaceUsed
      // 
      PageSpaceUsed.Caption = "Page Space Used";
      PageSpaceUsed.FieldName = "PageSpaceUsed";
      PageSpaceUsed.MaxWidth = 103;
      PageSpaceUsed.MinWidth = 103;
      PageSpaceUsed.Name = "PageSpaceUsed";
      PageSpaceUsed.OptionsColumn.AllowEdit = false;
      PageSpaceUsed.OptionsColumn.AllowFocus = false;
      PageSpaceUsed.OptionsColumn.AllowSize = false;
      PageSpaceUsed.OptionsFilter.AllowAutoFilter = false;
      PageSpaceUsed.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      PageSpaceUsed.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      PageSpaceUsed.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      PageSpaceUsed.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      PageSpaceUsed.UnboundType = DevExpress.Data.UnboundColumnType.String;
      PageSpaceUsed.Width = 103;
      // 
      // Duration
      // 
      Duration.AppearanceCell.Options.UseTextOptions = true;
      Duration.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      Duration.Caption = "Duration";
      Duration.FieldName = "Duration";
      Duration.MaxWidth = 73;
      Duration.MinWidth = 73;
      Duration.Name = "Duration";
      Duration.OptionsColumn.AllowEdit = false;
      Duration.OptionsColumn.AllowFocus = false;
      Duration.OptionsColumn.AllowIncrementalSearch = false;
      Duration.OptionsColumn.AllowMove = false;
      Duration.OptionsColumn.AllowShowHide = false;
      Duration.OptionsColumn.AllowSize = false;
      Duration.OptionsColumn.ReadOnly = true;
      Duration.OptionsColumn.ShowInCustomizationForm = false;
      Duration.OptionsColumn.ShowInExpressionEditor = false;
      Duration.OptionsColumn.TabStop = false;
      Duration.OptionsFilter.AllowAutoFilter = false;
      Duration.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      Duration.Width = 73;
      // 
      // Error
      // 
      Error.Caption = "Error Message";
      Error.FieldName = "Error";
      Error.MaxWidth = 300;
      Error.MinWidth = 120;
      Error.Name = "Error";
      Error.OptionsColumn.AllowEdit = false;
      Error.OptionsColumn.AllowFocus = false;
      Error.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      Error.Width = 120;
      // 
      // CreateDate
      // 
      CreateDate.AppearanceCell.Options.UseTextOptions = true;
      CreateDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      CreateDate.Caption = "Create Date";
      CreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      CreateDate.FieldName = "CreateDate";
      CreateDate.MaxWidth = 105;
      CreateDate.MinWidth = 105;
      CreateDate.Name = "CreateDate";
      CreateDate.OptionsColumn.AllowEdit = false;
      CreateDate.OptionsColumn.AllowFocus = false;
      CreateDate.OptionsColumn.AllowSize = false;
      CreateDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      CreateDate.Width = 105;
      // 
      // ModifyDate
      // 
      ModifyDate.AppearanceCell.Options.UseTextOptions = true;
      ModifyDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      ModifyDate.Caption = "Modify Date";
      ModifyDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      ModifyDate.FieldName = "ModifyDate";
      ModifyDate.MaxWidth = 105;
      ModifyDate.MinWidth = 105;
      ModifyDate.Name = "ModifyDate";
      ModifyDate.OptionsColumn.AllowEdit = false;
      ModifyDate.OptionsColumn.AllowFocus = false;
      ModifyDate.OptionsColumn.AllowSize = false;
      ModifyDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      ModifyDate.Width = 105;
      // 
      // LastRead
      // 
      LastRead.AppearanceCell.Options.UseTextOptions = true;
      LastRead.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      LastRead.Caption = "Last Read";
      LastRead.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      LastRead.FieldName = "LastRead";
      LastRead.MaxWidth = 105;
      LastRead.MinWidth = 105;
      LastRead.Name = "LastRead";
      LastRead.OptionsColumn.AllowEdit = false;
      LastRead.OptionsColumn.AllowFocus = false;
      LastRead.OptionsColumn.AllowSize = false;
      LastRead.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      LastRead.Width = 105;
      // 
      // LastWrite
      // 
      LastWrite.AppearanceCell.Options.UseTextOptions = true;
      LastWrite.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      LastWrite.Caption = "Last Write";
      LastWrite.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      LastWrite.FieldName = "LastWrite";
      LastWrite.MaxWidth = 105;
      LastWrite.MinWidth = 105;
      LastWrite.Name = "LastWrite";
      LastWrite.OptionsColumn.AllowEdit = false;
      LastWrite.OptionsColumn.AllowFocus = false;
      LastWrite.OptionsColumn.AllowSize = false;
      LastWrite.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      LastWrite.Width = 105;
      // 
      // StatsSampled
      // 
      StatsSampled.Caption = "Stats Sampled";
      StatsSampled.FieldName = "StatsSampled";
      StatsSampled.MaxWidth = 90;
      StatsSampled.MinWidth = 90;
      StatsSampled.Name = "StatsSampled";
      StatsSampled.OptionsColumn.AllowEdit = false;
      StatsSampled.OptionsColumn.AllowFocus = false;
      StatsSampled.OptionsColumn.AllowSize = false;
      StatsSampled.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      StatsSampled.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      StatsSampled.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      StatsSampled.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      StatsSampled.Width = 90;
      // 
      // IsNoRecompute
      // 
      IsNoRecompute.Caption = "No Recompute";
      IsNoRecompute.FieldName = "IsNoRecompute";
      IsNoRecompute.MaxWidth = 90;
      IsNoRecompute.MinWidth = 90;
      IsNoRecompute.Name = "IsNoRecompute";
      IsNoRecompute.OptionsColumn.AllowEdit = false;
      IsNoRecompute.OptionsColumn.AllowFocus = false;
      IsNoRecompute.OptionsColumn.AllowSize = false;
      IsNoRecompute.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      IsNoRecompute.Width = 90;
      // 
      // RowsSampled
      // 
      RowsSampled.Caption = "Rows Sampled";
      RowsSampled.FieldName = "RowsSampled";
      RowsSampled.MaxWidth = 100;
      RowsSampled.MinWidth = 100;
      RowsSampled.Name = "RowsSampled";
      RowsSampled.OptionsColumn.AllowEdit = false;
      RowsSampled.OptionsColumn.AllowFocus = false;
      RowsSampled.OptionsColumn.AllowSize = false;
      RowsSampled.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      RowsSampled.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      RowsSampled.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      RowsSampled.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      RowsSampled.Width = 100;
      // 
      // grid
      // 
      this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grid.Font = new System.Drawing.Font("Tahoma", 9F);
      this.grid.Location = new System.Drawing.Point(0, 32);
      this.grid.MainView = this.view;
      this.grid.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
      this.grid.Name = "grid";
      this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.popupIndexOperation});
      this.grid.Size = new System.Drawing.Size(1190, 746);
      this.grid.TabIndex = 2;
      this.grid.ToolTipController = this.gridToolTipController;
      this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
      // 
      // view
      // 
      this.view.Appearance.EvenRow.BackColor = System.Drawing.Color.Gainsboro;
      this.view.Appearance.EvenRow.Options.UseBackColor = true;
      this.view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.view.Appearance.HeaderPanel.Options.UseFont = true;
      this.view.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.view.Appearance.OddRow.Options.UseBackColor = true;
      this.view.Appearance.Row.BackColor = System.Drawing.Color.Silver;
      this.view.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.view.Appearance.Row.Options.UseBackColor = true;
      this.view.Appearance.Row.Options.UseFont = true;
      this.view.Appearance.SelectedRow.BackColor = System.Drawing.Color.Transparent;
      this.view.Appearance.SelectedRow.Options.UseBackColor = true;
      this.view.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.view.ColumnPanelRowHeight = 26;
      this.view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            Progress,
            Duration,
            FixType,
            DatabaseName,
            SchemaName,
            ObjectName,
            IndexName,
            IndexType,
            PartitionNumber,
            PageSpaceUsed,
            Fragmentation,
            PagesCount,
            SavedSpace,
            UnusedPagesCount,
            RowsCount,
            IndexStats,
            Compression,
            TotalScans,
            TotalSeeks,
            TotalUpdates,
            LastUsage,
            FileGroupName,
            FillFactor,
            IsPK,
            IsUnique,
            IsFiltered,
            IsPartitioned,
            TotalLookups,
            IndexColumns,
            IncludedColumns,
            Warning,
            Error,
            CreateDate,
            ModifyDate,
            LastRead,
            LastWrite,
            IsNoRecompute,
            StatsSampled,
            RowsSampled});
      this.view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
      gridFormatRule1.Column = Warning;
      gridFormatRule1.ColumnApplyTo = IndexName;
      gridFormatRule1.Name = "Warning";
      formatConditionIconSet1.CategoryName = "Symbols";
      formatConditionIconSetIcon1.PredefinedName = "Flags3_1.png";
      formatConditionIconSetIcon1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      formatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
      formatConditionIconSetIcon2.PredefinedName = "Flags3_2.png";
      formatConditionIconSetIcon2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
      formatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
      formatConditionIconSetIcon3.PredefinedName = "Flags3_3.png";
      formatConditionIconSetIcon3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
      formatConditionIconSetIcon3.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
      formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
      formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon2);
      formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon3);
      formatConditionIconSet1.Name = "Flags3";
      formatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
      gridFormatRule1.Rule = formatConditionRuleIconSet1;
      gridFormatRule2.Column = Fragmentation;
      gridFormatRule2.ColumnApplyTo = Fragmentation;
      gridFormatRule2.Name = "Fragmentation";
      formatConditionRuleDataBar1.AllowNegativeAxis = false;
      formatConditionRuleDataBar1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
      formatConditionRuleDataBar1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
      formatConditionRuleDataBar1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
      formatConditionRuleDataBar1.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar1.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar1.DrawAxis = false;
      formatConditionRuleDataBar1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar1.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      formatConditionRuleDataBar1.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar1.PredefinedName = null;
      formatConditionRuleDataBar1.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule2.Rule = formatConditionRuleDataBar1;
      gridFormatRule3.Column = PagesCount;
      gridFormatRule3.ColumnApplyTo = PagesCount;
      gridFormatRule3.Name = "PagesCount";
      formatConditionRuleDataBar2.AllowNegativeAxis = false;
      formatConditionRuleDataBar2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(247)))));
      formatConditionRuleDataBar2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(214)))), ((int)(((byte)(254)))));
      formatConditionRuleDataBar2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(247)))));
      formatConditionRuleDataBar2.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar2.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar2.DrawAxis = false;
      formatConditionRuleDataBar2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar2.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar2.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
      formatConditionRuleDataBar2.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar2.PredefinedName = null;
      formatConditionRuleDataBar2.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule3.Rule = formatConditionRuleDataBar2;
      gridFormatRule4.Column = UnusedPagesCount;
      gridFormatRule4.ColumnApplyTo = UnusedPagesCount;
      gridFormatRule4.Name = "UnusedPagesCount";
      formatConditionRuleDataBar3.AllowNegativeAxis = false;
      formatConditionRuleDataBar3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
      formatConditionRuleDataBar3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(243)))), ((int)(((byte)(233)))));
      formatConditionRuleDataBar3.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
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
            64,
            0,
            0,
            0});
      formatConditionRuleDataBar3.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar3.PredefinedName = null;
      formatConditionRuleDataBar3.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule4.Rule = formatConditionRuleDataBar3;
      gridFormatRule5.Column = RowsCount;
      gridFormatRule5.ColumnApplyTo = RowsCount;
      gridFormatRule5.Name = "RowsCount";
      formatConditionRuleDataBar4.AllowNegativeAxis = false;
      formatConditionRuleDataBar4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(135)))));
      formatConditionRuleDataBar4.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(237)))), ((int)(((byte)(179)))));
      formatConditionRuleDataBar4.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(135)))));
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
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar4.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar4.PredefinedName = null;
      formatConditionRuleDataBar4.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule5.Rule = formatConditionRuleDataBar4;
      gridFormatRule6.Column = SavedSpace;
      gridFormatRule6.ColumnApplyTo = SavedSpace;
      gridFormatRule6.Name = "SavedSpace";
      formatConditionRuleDataBar5.AllowNegativeAxis = false;
      formatConditionRuleDataBar5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
      formatConditionRuleDataBar5.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(243)))), ((int)(((byte)(233)))));
      formatConditionRuleDataBar5.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
      formatConditionRuleDataBar5.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar5.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar5.DrawAxis = false;
      formatConditionRuleDataBar5.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar5.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar5.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
      formatConditionRuleDataBar5.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar5.PredefinedName = null;
      formatConditionRuleDataBar5.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule6.Rule = formatConditionRuleDataBar5;
      gridFormatRule7.Column = PageSpaceUsed;
      gridFormatRule7.ColumnApplyTo = PageSpaceUsed;
      gridFormatRule7.Name = "PageSpaceUsed";
      formatConditionRuleDataBar6.AllowNegativeAxis = false;
      formatConditionRuleDataBar6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(125)))), ((int)(((byte)(212)))));
      formatConditionRuleDataBar6.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(165)))), ((int)(((byte)(238)))));
      formatConditionRuleDataBar6.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(125)))), ((int)(((byte)(212)))));
      formatConditionRuleDataBar6.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar6.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar6.DrawAxis = false;
      formatConditionRuleDataBar6.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar6.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      formatConditionRuleDataBar6.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar6.PredefinedName = null;
      formatConditionRuleDataBar6.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule7.Rule = formatConditionRuleDataBar6;
      gridFormatRule8.Column = Duration;
      gridFormatRule8.ColumnApplyTo = Duration;
      gridFormatRule8.Name = "Duration";
      formatConditionRuleDataBar7.AllowNegativeAxis = false;
      formatConditionRuleDataBar7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(135)))));
      formatConditionRuleDataBar7.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(237)))), ((int)(((byte)(179)))));
      formatConditionRuleDataBar7.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(135)))));
      formatConditionRuleDataBar7.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar7.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar7.DrawAxis = false;
      formatConditionRuleDataBar7.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar7.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar7.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      formatConditionRuleDataBar7.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar7.PredefinedName = null;
      formatConditionRuleDataBar7.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule8.Rule = formatConditionRuleDataBar7;
      gridFormatRule9.Column = TotalUpdates;
      gridFormatRule9.ColumnApplyTo = TotalUpdates;
      gridFormatRule9.Name = "TotalUpdates";
      formatConditionRuleDataBar8.AllowNegativeAxis = false;
      formatConditionRuleDataBar8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(135)))));
      formatConditionRuleDataBar8.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(237)))), ((int)(((byte)(179)))));
      formatConditionRuleDataBar8.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(135)))));
      formatConditionRuleDataBar8.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar8.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar8.DrawAxis = false;
      formatConditionRuleDataBar8.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar8.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar8.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      formatConditionRuleDataBar8.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar8.PredefinedName = null;
      formatConditionRuleDataBar8.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule9.Rule = formatConditionRuleDataBar8;
      gridFormatRule10.Column = TotalSeeks;
      gridFormatRule10.ColumnApplyTo = TotalSeeks;
      gridFormatRule10.Name = "TotalSeeks";
      formatConditionRuleDataBar9.AllowNegativeAxis = false;
      formatConditionRuleDataBar9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(229)))), ((int)(((byte)(155)))));
      formatConditionRuleDataBar9.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(164)))));
      formatConditionRuleDataBar9.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(229)))), ((int)(((byte)(115)))));
      formatConditionRuleDataBar9.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar9.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar9.DrawAxis = false;
      formatConditionRuleDataBar9.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar9.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar9.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      formatConditionRuleDataBar9.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar9.PredefinedName = null;
      formatConditionRuleDataBar9.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule10.Rule = formatConditionRuleDataBar9;
      gridFormatRule11.Column = TotalScans;
      gridFormatRule11.ColumnApplyTo = TotalScans;
      gridFormatRule11.Name = "TotalScans";
      formatConditionRuleDataBar10.AllowNegativeAxis = false;
      formatConditionRuleDataBar10.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(229)))), ((int)(((byte)(155)))));
      formatConditionRuleDataBar10.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(164)))));
      formatConditionRuleDataBar10.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(229)))), ((int)(((byte)(115)))));
      formatConditionRuleDataBar10.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar10.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar10.DrawAxis = false;
      formatConditionRuleDataBar10.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar10.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar10.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      formatConditionRuleDataBar10.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar10.PredefinedName = null;
      formatConditionRuleDataBar10.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule11.Rule = formatConditionRuleDataBar10;
      gridFormatRule12.Column = TotalLookups;
      gridFormatRule12.ColumnApplyTo = TotalLookups;
      gridFormatRule12.Name = "TotalLookups";
      formatConditionRuleDataBar11.AllowNegativeAxis = false;
      formatConditionRuleDataBar11.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(229)))), ((int)(((byte)(155)))));
      formatConditionRuleDataBar11.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(164)))));
      formatConditionRuleDataBar11.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(229)))), ((int)(((byte)(115)))));
      formatConditionRuleDataBar11.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar11.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar11.DrawAxis = false;
      formatConditionRuleDataBar11.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar11.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar11.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      formatConditionRuleDataBar11.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar11.PredefinedName = null;
      formatConditionRuleDataBar11.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule12.Rule = formatConditionRuleDataBar11;
      gridFormatRule13.Column = StatsSampled;
      gridFormatRule13.ColumnApplyTo = StatsSampled;
      gridFormatRule13.Name = "StatsSampled";
      formatConditionRuleDataBar12.AllowNegativeAxis = false;
      formatConditionRuleDataBar12.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(135)))));
      formatConditionRuleDataBar12.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(237)))), ((int)(((byte)(179)))));
      formatConditionRuleDataBar12.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(135)))));
      formatConditionRuleDataBar12.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar12.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar12.DrawAxis = false;
      formatConditionRuleDataBar12.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar12.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar12.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      formatConditionRuleDataBar12.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar12.PredefinedName = null;
      formatConditionRuleDataBar12.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule13.Rule = formatConditionRuleDataBar12;
      this.view.FormatRules.Add(gridFormatRule1);
      this.view.FormatRules.Add(gridFormatRule2);
      this.view.FormatRules.Add(gridFormatRule3);
      this.view.FormatRules.Add(gridFormatRule4);
      this.view.FormatRules.Add(gridFormatRule5);
      this.view.FormatRules.Add(gridFormatRule6);
      this.view.FormatRules.Add(gridFormatRule7);
      this.view.FormatRules.Add(gridFormatRule8);
      this.view.FormatRules.Add(gridFormatRule9);
      this.view.FormatRules.Add(gridFormatRule10);
      this.view.FormatRules.Add(gridFormatRule11);
      this.view.FormatRules.Add(gridFormatRule12);
      this.view.FormatRules.Add(gridFormatRule13);
      this.view.GridControl = this.grid;
      this.view.Name = "view";
      this.view.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
      this.view.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
      this.view.OptionsCustomization.AllowGroup = false;
      this.view.OptionsFind.AllowFindPanel = false;
      this.view.OptionsFind.FindFilterColumns = "DatabaseName;SchemaName;ObjectName;IndexName;FileGroupName;IndexColumns;IncludedC" +
    "olumns";
      this.view.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
      this.view.OptionsFind.FindNullPrompt = "";
      this.view.OptionsFind.ShowClearButton = false;
      this.view.OptionsFind.ShowCloseButton = false;
      this.view.OptionsFind.ShowFindButton = false;
      this.view.OptionsLayout.Columns.AddNewColumns = false;
      this.view.OptionsLayout.StoreDataSettings = false;
      this.view.OptionsLayout.StoreVisualOptions = false;
      this.view.OptionsMenu.EnableGroupPanelMenu = false;
      this.view.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
      this.view.OptionsMenu.ShowAutoFilterRowItem = false;
      this.view.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
      this.view.OptionsSelection.EnableAppearanceFocusedRow = false;
      this.view.OptionsSelection.EnableAppearanceHideSelection = false;
      this.view.OptionsSelection.MultiSelect = true;
      this.view.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
      this.view.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
      this.view.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
      this.view.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
      this.view.OptionsSelection.UseIndicatorForSelection = false;
      this.view.OptionsView.ColumnAutoWidth = false;
      this.view.OptionsView.EnableAppearanceEvenRow = true;
      this.view.OptionsView.EnableAppearanceOddRow = true;
      this.view.OptionsView.ShowGroupPanel = false;
      this.view.OptionsView.ShowIndicator = false;
      this.view.RowHeight = 24;
      this.view.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GridRowCellClick);
      this.view.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GridPopupMenuShowing);
      this.view.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.GridSelectionChanged);
      this.view.RowCountChanged += new System.EventHandler(this.GridRowCountChanged);
      // 
      // gridToolTipController
      // 
      this.gridToolTipController.ToolTipAnchor = DevExpress.Utils.ToolTipAnchor.Object;
      this.gridToolTipController.ToolTipLocation = DevExpress.Utils.ToolTipLocation.TopCenter;
      this.gridToolTipController.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.GetActiveObjectInfo);
      // 
      // statusBar
      // 
      this.statusBar.ItemLinks.Add(this.labelDatabases);
      this.statusBar.ItemLinks.Add(this.labelErrors);
      this.statusBar.ItemLinks.Add(this.labelIndexes);
      this.statusBar.ItemLinks.Add(this.labelIndexesSize);
      this.statusBar.ItemLinks.Add(this.labelSavedSpace);
      this.statusBar.ItemLinks.Add(this.labelElapsedTime);
      this.statusBar.ItemLinks.Add(this.buttonStopScan);
      this.statusBar.ItemLinks.Add(this.buttonStopFix);
      this.statusBar.ItemLinks.Add(this.buttonAutoScroll);
      this.statusBar.ItemLinks.Add(this.buttonLog);
      this.statusBar.ItemLinks.Add(this.labelInfo);
      this.statusBar.ItemLinks.Add(this.labelServerInfo);
      this.statusBar.Location = new System.Drawing.Point(0, 778);
      this.statusBar.Name = "statusBar";
      this.statusBar.Ribbon = this.ribbonControl1;
      this.statusBar.Size = new System.Drawing.Size(1190, 21);
      this.statusBar.ToolTipController = this.toolTipController;
      // 
      // labelDatabases
      // 
      this.labelDatabases.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelDatabases.Id = 12;
      this.labelDatabases.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconDatabases;
      this.labelDatabases.Name = "labelDatabases";
      this.labelDatabases.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      toolTipTitleItem1.Text = "Databases";
      superToolTip1.Items.Add(toolTipTitleItem1);
      this.labelDatabases.SuperTip = superToolTip1;
      this.labelDatabases.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelErrors
      // 
      this.labelErrors.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelErrors.Id = 29;
      this.labelErrors.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconErrors;
      this.labelErrors.Name = "labelErrors";
      toolTipTitleItem2.Text = "Errors";
      superToolTip2.Items.Add(toolTipTitleItem2);
      this.labelErrors.SuperTip = superToolTip2;
      this.labelErrors.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelIndexes
      // 
      this.labelIndexes.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelIndexes.Id = 13;
      this.labelIndexes.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconIndexes;
      this.labelIndexes.Name = "labelIndexes";
      this.labelIndexes.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      toolTipTitleItem3.Text = "Indexes";
      superToolTip3.Items.Add(toolTipTitleItem3);
      this.labelIndexes.SuperTip = superToolTip3;
      this.labelIndexes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelIndexesSize
      // 
      this.labelIndexesSize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelIndexesSize.Id = 33;
      this.labelIndexesSize.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconIndexesSize;
      this.labelIndexesSize.Name = "labelIndexesSize";
      toolTipTitleItem4.Text = "Index Size";
      superToolTip4.Items.Add(toolTipTitleItem4);
      this.labelIndexesSize.SuperTip = superToolTip4;
      this.labelIndexesSize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelSavedSpace
      // 
      this.labelSavedSpace.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelSavedSpace.Id = 31;
      this.labelSavedSpace.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconSavedSpace;
      this.labelSavedSpace.Name = "labelSavedSpace";
      toolTipTitleItem5.Text = "Saved Space";
      superToolTip5.Items.Add(toolTipTitleItem5);
      this.labelSavedSpace.SuperTip = superToolTip5;
      this.labelSavedSpace.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelElapsedTime
      // 
      this.labelElapsedTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelElapsedTime.Id = 34;
      this.labelElapsedTime.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconElapsedTime;
      this.labelElapsedTime.Name = "labelElapsedTime";
      toolTipTitleItem6.Text = "Elapsed Time";
      superToolTip6.Items.Add(toolTipTitleItem6);
      this.labelElapsedTime.SuperTip = superToolTip6;
      this.labelElapsedTime.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // buttonStopScan
      // 
      this.buttonStopScan.Caption = "Stop";
      this.buttonStopScan.Id = 19;
      this.buttonStopScan.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconStop;
      this.buttonStopScan.Name = "buttonStopScan";
      this.buttonStopScan.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      this.buttonStopScan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonStopScanClick);
      // 
      // buttonStopFix
      // 
      this.buttonStopFix.Caption = "Stop";
      this.buttonStopFix.Id = 2;
      this.buttonStopFix.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconStop;
      this.buttonStopFix.Name = "buttonStopFix";
      this.buttonStopFix.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      this.buttonStopFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonStopFixClick);
      // 
      // buttonAutoScroll
      // 
      this.buttonAutoScroll.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
      this.buttonAutoScroll.Caption = "Auto Scroll Window";
      this.buttonAutoScroll.Down = true;
      this.buttonAutoScroll.Id = 41;
      this.buttonAutoScroll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonAutoScroll.ImageOptions.Image")));
      this.buttonAutoScroll.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonAutoScroll.ImageOptions.LargeImage")));
      this.buttonAutoScroll.Name = "buttonAutoScroll";
      this.buttonAutoScroll.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
      this.buttonAutoScroll.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // buttonLog
      // 
      this.buttonLog.Caption = "Show Log  File";
      this.buttonLog.Id = 26;
      this.buttonLog.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconLog;
      this.buttonLog.Name = "buttonLog";
      this.buttonLog.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
      this.buttonLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonLog);
      // 
      // labelInfo
      // 
      this.labelInfo.Id = 24;
      this.labelInfo.Name = "labelInfo";
      toolTipTitleItem7.Text = "Output";
      superToolTip7.Items.Add(toolTipTitleItem7);
      this.labelInfo.SuperTip = superToolTip7;
      // 
      // labelServerInfo
      // 
      this.labelServerInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelServerInfo.Id = 35;
      this.labelServerInfo.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconInfo;
      this.labelServerInfo.Name = "labelServerInfo";
      toolTipTitleItem8.Text = "Version";
      superToolTip8.Items.Add(toolTipTitleItem8);
      this.labelServerInfo.SuperTip = superToolTip8;
      this.labelServerInfo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // ribbonControl1
      // 
      this.ribbonControl1.AllowKeyTips = false;
      this.ribbonControl1.AllowMdiChildButtons = false;
      this.ribbonControl1.AllowMinimizeRibbon = false;
      this.ribbonControl1.ExpandCollapseItem.Id = 0;
      this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.buttonNewConnection,
            this.buttonFix,
            this.buttonOptions,
            this.buttonAbout,
            this.buttonRefreshIndex,
            this.buttonSaveFix,
            this.labelInfo,
            this.buttonStopFix,
            this.buttonCopyFix,
            this.labelDatabases,
            this.labelIndexes,
            this.buttonDatabases,
            this.boxSearch,
            this.labelSeparator,
            this.buttonStopScan,
            this.buttonLog,
            this.labelErrors,
            this.labelSavedSpace,
            this.labelIndexesSize,
            this.labelElapsedTime,
            this.labelServerInfo,
            this.buttonAutoScroll});
      this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
      this.ribbonControl1.MaxItemId = 42;
      this.ribbonControl1.Name = "ribbonControl1";
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonNewConnection);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonDatabases);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonRefreshIndex);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonFix);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonOptions);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonAbout);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.labelSeparator);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.boxSearch);
      this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.boxSearchControl});
      this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
      this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
      this.ribbonControl1.ShowCategoryInCaption = false;
      this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
      this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
      this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
      this.ribbonControl1.ShowQatLocationSelector = false;
      this.ribbonControl1.ShowToolbarCustomizeItem = false;
      this.ribbonControl1.Size = new System.Drawing.Size(1190, 32);
      this.ribbonControl1.StatusBar = this.statusBar;
      this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
      this.ribbonControl1.ShowCustomizationMenu += new DevExpress.XtraBars.Ribbon.RibbonCustomizationMenuEventHandler(this.GridCustomizationMenu);
      // 
      // buttonNewConnection
      // 
      this.buttonNewConnection.AllowRightClickInMenu = false;
      this.buttonNewConnection.Caption = "New Connection";
      this.buttonNewConnection.Id = 14;
      this.buttonNewConnection.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconNewConnection;
      this.buttonNewConnection.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
      this.buttonNewConnection.Name = "buttonNewConnection";
      this.buttonNewConnection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonNewConnectionClick);
      // 
      // buttonFix
      // 
      this.buttonFix.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
      this.buttonFix.Caption = "Fix Indexes";
      this.buttonFix.DropDownControl = this.popupFix;
      this.buttonFix.Enabled = false;
      this.buttonFix.Id = 15;
      this.buttonFix.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconFix;
      this.buttonFix.Name = "buttonFix";
      this.buttonFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.buttonFix_ItemClick);
      // 
      // popupFix
      // 
      this.popupFix.ItemLinks.Add(this.buttonCopyFix);
      this.popupFix.ItemLinks.Add(this.buttonSaveFix);
      this.popupFix.Name = "popupFix";
      this.popupFix.Ribbon = this.ribbonControl1;
      // 
      // buttonCopyFix
      // 
      this.buttonCopyFix.Caption = "Copy Fix Script";
      this.buttonCopyFix.Id = 7;
      this.buttonCopyFix.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconCopyFix;
      this.buttonCopyFix.Name = "buttonCopyFix";
      this.buttonCopyFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonCopyFixClick);
      // 
      // buttonSaveFix
      // 
      this.buttonSaveFix.Caption = "Save Fix Script";
      this.buttonSaveFix.Id = 23;
      this.buttonSaveFix.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconSaveFix;
      this.buttonSaveFix.Name = "buttonSaveFix";
      this.buttonSaveFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonSaveFixClick);
      // 
      // buttonOptions
      // 
      this.buttonOptions.Caption = "Settings";
      this.buttonOptions.Id = 16;
      this.buttonOptions.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconOptions;
      this.buttonOptions.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
      this.buttonOptions.Name = "buttonOptions";
      this.buttonOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonOptionsClick);
      // 
      // buttonAbout
      // 
      this.buttonAbout.Caption = "About";
      this.buttonAbout.Id = 17;
      this.buttonAbout.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconAbout;
      this.buttonAbout.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
      this.buttonAbout.Name = "buttonAbout";
      this.buttonAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonAboutClick);
      // 
      // buttonRefreshIndex
      // 
      this.buttonRefreshIndex.Caption = "Refresh Indexes";
      this.buttonRefreshIndex.Enabled = false;
      this.buttonRefreshIndex.Id = 19;
      this.buttonRefreshIndex.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconRefresh;
      this.buttonRefreshIndex.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
      this.buttonRefreshIndex.Name = "buttonRefreshIndex";
      this.buttonRefreshIndex.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonFindClick);
      // 
      // buttonDatabases
      // 
      this.buttonDatabases.Caption = "Select Databases";
      this.buttonDatabases.Enabled = false;
      this.buttonDatabases.Id = 14;
      this.buttonDatabases.ImageOptions.Image = global::SQLIndexManager.Properties.Resources.IconScan;
      this.buttonDatabases.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
      this.buttonDatabases.Name = "buttonDatabases";
      this.buttonDatabases.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonDatabasesClick);
      // 
      // boxSearch
      // 
      this.boxSearch.Edit = this.boxSearchControl;
      this.boxSearch.EditWidth = 220;
      this.boxSearch.Id = 15;
      this.boxSearch.Name = "boxSearch";
      // 
      // boxSearchControl
      // 
      this.boxSearchControl.AutoHeight = false;
      this.boxSearchControl.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
      this.boxSearchControl.Client = this.grid;
      this.boxSearchControl.Name = "boxSearchControl";
      this.boxSearchControl.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
      // 
      // labelSeparator
      // 
      this.labelSeparator.Enabled = false;
      this.labelSeparator.Id = 16;
      this.labelSeparator.Name = "labelSeparator";
      this.labelSeparator.ShowImageInToolbar = false;
      this.labelSeparator.Width = 25;
      // 
      // toolTipController
      // 
      this.toolTipController.ToolTipAnchor = DevExpress.Utils.ToolTipAnchor.Object;
      this.toolTipController.ToolTipLocation = DevExpress.Utils.ToolTipLocation.TopCenter;
      // 
      // taskbar
      // 
      this.taskbar.ParentControl = this;
      // 
      // buttonFind
      // 
      this.buttonFind.ActAsDropDown = true;
      this.buttonFind.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
      this.buttonFind.Enabled = false;
      this.buttonFind.Id = 11;
      this.buttonFind.Name = "buttonFind";
      // 
      // MainBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1190, 799);
      this.Controls.Add(this.grid);
      this.Controls.Add(this.statusBar);
      this.Controls.Add(this.ribbonControl1);
      this.MinimumSize = new System.Drawing.Size(950, 599);
      this.Name = "MainBox";
      this.Ribbon = this.ribbonControl1;
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.StatusBar = this.statusBar;
      this.Text = "SQL Index Manager";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainBox_FormClosing);
      this.Shown += new System.EventHandler(this.MainBox_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.popupIndexOperation)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupFix)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxSearchControl)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraBars.Ribbon.RibbonStatusBar statusBar;
    private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    private BarButtonItem buttonNewConnection;
    private BarButtonItem buttonFix;
    private BarButtonItem buttonOptions;
    private BarButtonItem buttonAbout;
    private BarButtonItem buttonRefreshIndex;
    private BarButtonItem buttonSaveFix;
    private BarStaticItem labelInfo;
    private BarButtonItem buttonStopFix;
    private DevExpress.XtraGrid.Views.Grid.GridView view;
    private DevExpress.Utils.Taskbar.TaskbarAssistant taskbar;
    private DevExpress.XtraGrid.GridControl grid;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit popupIndexOperation;
    private BarButtonItem buttonCopyFix;
    private BarStaticItem labelDatabases;
    private BarStaticItem labelIndexes;
    private DevExpress.Utils.ToolTipController toolTipController;
    private BarButtonItem buttonDatabases;
    private BarEditItem boxSearch;
    private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl boxSearchControl;
    private BarStaticItem labelSeparator;
    private BarButtonItem buttonStopScan;
    private BarButtonItem buttonFind;
    private DevExpress.Utils.ToolTipController gridToolTipController;
    private BarButtonItem buttonLog;
    private PopupMenu popupFix;
    private BarStaticItem labelErrors;
    private BarStaticItem labelSavedSpace;
    private BarStaticItem labelIndexesSize;
    private BarStaticItem labelElapsedTime;
    private BarStaticItem labelServerInfo;
    private BarButtonItem buttonAutoScroll;
  }
}