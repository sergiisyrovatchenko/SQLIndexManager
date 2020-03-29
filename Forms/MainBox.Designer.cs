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
      DevExpress.XtraGrid.Columns.GridColumn TotalWrites;
      DevExpress.XtraGrid.Columns.GridColumn TotalReads;
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
      DevExpress.XtraGrid.Columns.GridColumn colDateTime;
      DevExpress.XtraGrid.Columns.GridColumn TotalSeeks;
      DevExpress.XtraGrid.Columns.GridColumn TotalScans;
      DevExpress.XtraGrid.Columns.GridColumn TotalLookups;
      DevExpress.XtraGrid.Columns.GridColumn IndexColumns;
      DevExpress.XtraGrid.Columns.GridColumn IncludedColumns;
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBox));
      this.popupIndexOperation = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.Warning = new DevExpress.XtraGrid.Columns.GridColumn();
      this.PageSpaceUsed = new DevExpress.XtraGrid.Columns.GridColumn();
      this.Duration = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemHypertextLabel1 = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
      this.grid = new DevExpress.XtraGrid.GridControl();
      this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.Error = new DevExpress.XtraGrid.Columns.GridColumn();
      this.CreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
      this.ModifyDate = new DevExpress.XtraGrid.Columns.GridColumn();
      this.LastRead = new DevExpress.XtraGrid.Columns.GridColumn();
      this.LastWrite = new DevExpress.XtraGrid.Columns.GridColumn();
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
      this.popupExport = new DevExpress.XtraBars.PopupMenu(this.components);
      this.buttonExportExcel = new DevExpress.XtraBars.BarButtonItem();
      this.buttonExportCSV = new DevExpress.XtraBars.BarButtonItem();
      this.buttonExportText = new DevExpress.XtraBars.BarButtonItem();
      this.buttonExportHtml = new DevExpress.XtraBars.BarButtonItem();
      this.buttonRestoreDefaultLayout = new DevExpress.XtraBars.BarButtonItem();
      this.buttonAbout = new DevExpress.XtraBars.BarButtonItem();
      this.buttonRefreshIndex = new DevExpress.XtraBars.BarButtonItem();
      this.buttonDatabases = new DevExpress.XtraBars.BarButtonItem();
      this.boxSearch = new DevExpress.XtraBars.BarEditItem();
      this.boxSearchControl = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
      this.labelSeparator = new DevExpress.XtraBars.BarStaticItem();
      this.buttonFeedback = new DevExpress.XtraBars.BarButtonItem();
      this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
      this.taskbar = new DevExpress.Utils.Taskbar.TaskbarAssistant();
      this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
      this.buttonFind = new DevExpress.XtraBars.BarButtonItem();
      this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
      this.gridLog = new DevExpress.XtraGrid.GridControl();
      this.viewLog = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
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
      TotalWrites = new DevExpress.XtraGrid.Columns.GridColumn();
      TotalReads = new DevExpress.XtraGrid.Columns.GridColumn();
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
      colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
      TotalSeeks = new DevExpress.XtraGrid.Columns.GridColumn();
      TotalScans = new DevExpress.XtraGrid.Columns.GridColumn();
      TotalLookups = new DevExpress.XtraGrid.Columns.GridColumn();
      IndexColumns = new DevExpress.XtraGrid.Columns.GridColumn();
      IncludedColumns = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.popupIndexOperation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupFix)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupExport)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxSearchControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridLog)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.viewLog)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
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
      FileGroupName.Visible = true;
      FileGroupName.VisibleIndex = 17;
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
      IndexStats.DisplayFormat.FormatString = "dd/MM/yy HH:mm";
      IndexStats.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      IndexStats.FieldName = "IndexStats";
      IndexStats.MaxWidth = 105;
      IndexStats.MinWidth = 105;
      IndexStats.Name = "IndexStats";
      IndexStats.OptionsColumn.AllowEdit = false;
      IndexStats.OptionsColumn.AllowFocus = false;
      IndexStats.OptionsColumn.AllowSize = false;
      IndexStats.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      IndexStats.Visible = true;
      IndexStats.VisibleIndex = 12;
      IndexStats.Width = 105;
      // 
      // TotalWrites
      // 
      TotalWrites.Caption = "Writes";
      TotalWrites.DisplayFormat.FormatString = "N0";
      TotalWrites.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      TotalWrites.FieldName = "TotalWrites";
      TotalWrites.MaxWidth = 95;
      TotalWrites.MinWidth = 95;
      TotalWrites.Name = "TotalWrites";
      TotalWrites.OptionsColumn.AllowEdit = false;
      TotalWrites.OptionsColumn.AllowFocus = false;
      TotalWrites.OptionsColumn.AllowSize = false;
      TotalWrites.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      TotalWrites.Visible = true;
      TotalWrites.VisibleIndex = 14;
      TotalWrites.Width = 95;
      // 
      // TotalReads
      // 
      TotalReads.Caption = "Reads";
      TotalReads.DisplayFormat.FormatString = "N0";
      TotalReads.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      TotalReads.FieldName = "TotalReads";
      TotalReads.MaxWidth = 95;
      TotalReads.MinWidth = 95;
      TotalReads.Name = "TotalReads";
      TotalReads.OptionsColumn.AllowEdit = false;
      TotalReads.OptionsColumn.AllowFocus = false;
      TotalReads.OptionsColumn.AllowSize = false;
      TotalReads.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      TotalReads.Visible = true;
      TotalReads.VisibleIndex = 13;
      TotalReads.Width = 95;
      // 
      // LastUsage
      // 
      LastUsage.AppearanceCell.Options.UseTextOptions = true;
      LastUsage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      LastUsage.Caption = "Last Usage";
      LastUsage.DisplayFormat.FormatString = "dd/MM/yy HH:mm";
      LastUsage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      LastUsage.FieldName = "LastUsage";
      LastUsage.MaxWidth = 105;
      LastUsage.MinWidth = 105;
      LastUsage.Name = "LastUsage";
      LastUsage.OptionsColumn.AllowEdit = false;
      LastUsage.OptionsColumn.AllowFocus = false;
      LastUsage.OptionsColumn.AllowSize = false;
      LastUsage.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      LastUsage.Visible = true;
      LastUsage.VisibleIndex = 15;
      LastUsage.Width = 105;
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
      Compression.MaxWidth = 100;
      Compression.MinWidth = 78;
      Compression.Name = "Compression";
      Compression.OptionsColumn.AllowEdit = false;
      Compression.OptionsColumn.AllowFocus = false;
      Compression.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      Compression.Visible = true;
      Compression.VisibleIndex = 16;
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
      // colDateTime
      // 
      colDateTime.AppearanceCell.Options.UseTextOptions = true;
      colDateTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      colDateTime.Caption = "Event";
      colDateTime.DisplayFormat.FormatString = "HH:mm:ss.fff";
      colDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      colDateTime.FieldName = "DateTime";
      colDateTime.MaxWidth = 90;
      colDateTime.MinWidth = 90;
      colDateTime.Name = "colDateTime";
      colDateTime.OptionsColumn.AllowEdit = false;
      colDateTime.OptionsColumn.AllowFocus = false;
      colDateTime.OptionsColumn.AllowShowHide = false;
      colDateTime.OptionsColumn.ShowInCustomizationForm = false;
      colDateTime.Visible = true;
      colDateTime.VisibleIndex = 0;
      colDateTime.Width = 90;
      // 
      // TotalSeeks
      // 
      TotalSeeks.Caption = "Seeks";
      TotalSeeks.DisplayFormat.FormatString = "N0";
      TotalSeeks.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      TotalSeeks.FieldName = "TotalSeeks";
      TotalSeeks.MaxWidth = 95;
      TotalSeeks.MinWidth = 95;
      TotalSeeks.Name = "TotalSeeks";
      TotalSeeks.OptionsColumn.AllowEdit = false;
      TotalSeeks.OptionsColumn.AllowFocus = false;
      TotalSeeks.OptionsColumn.AllowSize = false;
      TotalSeeks.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      TotalSeeks.Width = 95;
      // 
      // TotalScans
      // 
      TotalScans.Caption = "Scans";
      TotalScans.DisplayFormat.FormatString = "N0";
      TotalScans.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      TotalScans.FieldName = "TotalScans";
      TotalScans.MaxWidth = 95;
      TotalScans.MinWidth = 95;
      TotalScans.Name = "TotalScans";
      TotalScans.OptionsColumn.AllowEdit = false;
      TotalScans.OptionsColumn.AllowFocus = false;
      TotalScans.OptionsColumn.AllowSize = false;
      TotalScans.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      TotalScans.Width = 95;
      // 
      // TotalLookups
      // 
      TotalLookups.Caption = "Lookups";
      TotalLookups.DisplayFormat.FormatString = "N0";
      TotalLookups.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      TotalLookups.FieldName = "TotalLookups";
      TotalLookups.MaxWidth = 95;
      TotalLookups.MinWidth = 95;
      TotalLookups.Name = "TotalLookups";
      TotalLookups.OptionsColumn.AllowEdit = false;
      TotalLookups.OptionsColumn.AllowFocus = false;
      TotalLookups.OptionsColumn.AllowSize = false;
      TotalLookups.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
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
      this.Warning.AppearanceCell.Options.UseTextOptions = true;
      this.Warning.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.Warning.Caption = "Warning";
      this.Warning.FieldName = "Warning";
      this.Warning.MaxWidth = 90;
      this.Warning.MinWidth = 90;
      this.Warning.Name = "Warning";
      this.Warning.OptionsColumn.AllowEdit = false;
      this.Warning.OptionsColumn.AllowFocus = false;
      this.Warning.OptionsColumn.AllowSize = false;
      this.Warning.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      this.Warning.Width = 90;
      // 
      // PageSpaceUsed
      // 
      this.PageSpaceUsed.Caption = "Page Space Used";
      this.PageSpaceUsed.FieldName = "PageSpaceUsed";
      this.PageSpaceUsed.MaxWidth = 103;
      this.PageSpaceUsed.MinWidth = 103;
      this.PageSpaceUsed.Name = "PageSpaceUsed";
      this.PageSpaceUsed.OptionsColumn.AllowEdit = false;
      this.PageSpaceUsed.OptionsColumn.AllowFocus = false;
      this.PageSpaceUsed.OptionsColumn.AllowSize = false;
      this.PageSpaceUsed.OptionsFilter.AllowAutoFilter = false;
      this.PageSpaceUsed.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.Excel;
      this.PageSpaceUsed.OptionsFilter.PopupExcelFilterDefaultTab = DevExpress.XtraGrid.Columns.ExcelFilterDefaultTab.Values;
      this.PageSpaceUsed.OptionsFilter.PopupExcelFilterEnumFilters = DevExpress.XtraGrid.Columns.ExcelFilterEnumFilters.EqualityFilters;
      this.PageSpaceUsed.OptionsFilter.PopupExcelFilterNumericValuesTabFilterType = DevExpress.XtraGrid.Columns.ExcelFilterNumericValuesTabFilterType.Range;
      this.PageSpaceUsed.UnboundType = DevExpress.Data.UnboundColumnType.String;
      this.PageSpaceUsed.Width = 103;
      // 
      // Duration
      // 
      this.Duration.AppearanceCell.Options.UseTextOptions = true;
      this.Duration.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.Duration.Caption = "Duration";
      this.Duration.FieldName = "Duration";
      this.Duration.MaxWidth = 73;
      this.Duration.MinWidth = 73;
      this.Duration.Name = "Duration";
      this.Duration.OptionsColumn.AllowEdit = false;
      this.Duration.OptionsColumn.AllowFocus = false;
      this.Duration.OptionsColumn.AllowIncrementalSearch = false;
      this.Duration.OptionsColumn.AllowMove = false;
      this.Duration.OptionsColumn.AllowShowHide = false;
      this.Duration.OptionsColumn.AllowSize = false;
      this.Duration.OptionsColumn.ReadOnly = true;
      this.Duration.OptionsColumn.ShowInCustomizationForm = false;
      this.Duration.OptionsColumn.ShowInExpressionEditor = false;
      this.Duration.OptionsColumn.TabStop = false;
      this.Duration.OptionsFilter.AllowAutoFilter = false;
      this.Duration.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
      this.Duration.Width = 73;
      // 
      // repositoryItemHypertextLabel1
      // 
      this.repositoryItemHypertextLabel1.Name = "repositoryItemHypertextLabel1";
      // 
      // grid
      // 
      this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grid.Font = new System.Drawing.Font("Tahoma", 9F);
      this.grid.Location = new System.Drawing.Point(0, 0);
      this.grid.MainView = this.view;
      this.grid.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
      this.grid.Name = "grid";
      this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.popupIndexOperation});
      this.grid.Size = new System.Drawing.Size(1190, 500);
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
            this.Duration,
            FixType,
            DatabaseName,
            SchemaName,
            ObjectName,
            IndexName,
            IndexType,
            PartitionNumber,
            this.PageSpaceUsed,
            Fragmentation,
            PagesCount,
            SavedSpace,
            UnusedPagesCount,
            RowsCount,
            IndexStats,
            TotalReads,
            TotalWrites,
            LastUsage,
            Compression,
            FileGroupName,
            FillFactor,
            IsPK,
            IsUnique,
            IsFiltered,
            IsPartitioned,
            TotalSeeks,
            TotalScans,
            TotalLookups,
            IndexColumns,
            IncludedColumns,
            this.Warning,
            this.Error,
            this.CreateDate,
            this.ModifyDate,
            this.LastRead,
            this.LastWrite});
      this.view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
      gridFormatRule1.Column = this.Warning;
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
      gridFormatRule7.Column = this.PageSpaceUsed;
      gridFormatRule7.ColumnApplyTo = this.PageSpaceUsed;
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
      gridFormatRule8.Column = this.Duration;
      gridFormatRule8.ColumnApplyTo = this.Duration;
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
      gridFormatRule9.Column = TotalReads;
      gridFormatRule9.ColumnApplyTo = TotalReads;
      gridFormatRule9.Name = "TotalReads";
      formatConditionRuleDataBar8.AllowNegativeAxis = false;
      formatConditionRuleDataBar8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(110)))));
      formatConditionRuleDataBar8.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
      formatConditionRuleDataBar8.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(90)))));
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
      gridFormatRule10.Column = TotalWrites;
      gridFormatRule10.ColumnApplyTo = TotalWrites;
      gridFormatRule10.Name = "TotalWrites";
      formatConditionRuleDataBar9.AllowNegativeAxis = false;
      formatConditionRuleDataBar9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(110)))));
      formatConditionRuleDataBar9.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
      formatConditionRuleDataBar9.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(90)))));
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
      gridFormatRule11.Column = TotalSeeks;
      gridFormatRule11.ColumnApplyTo = TotalSeeks;
      gridFormatRule11.Name = "TotalSeeks";
      formatConditionRuleDataBar10.AllowNegativeAxis = false;
      formatConditionRuleDataBar10.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(110)))));
      formatConditionRuleDataBar10.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
      formatConditionRuleDataBar10.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(90)))));
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
      gridFormatRule12.Column = TotalScans;
      gridFormatRule12.ColumnApplyTo = TotalScans;
      gridFormatRule12.Name = "TotalScans";
      formatConditionRuleDataBar11.AllowNegativeAxis = false;
      formatConditionRuleDataBar11.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(110)))));
      formatConditionRuleDataBar11.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
      formatConditionRuleDataBar11.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(90)))));
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
      gridFormatRule13.Column = TotalLookups;
      gridFormatRule13.ColumnApplyTo = TotalLookups;
      gridFormatRule13.Name = "TotalLookups";
      formatConditionRuleDataBar12.AllowNegativeAxis = false;
      formatConditionRuleDataBar12.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(110)))));
      formatConditionRuleDataBar12.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
      formatConditionRuleDataBar12.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(90)))));
      formatConditionRuleDataBar12.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar12.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar12.DrawAxis = false;
      formatConditionRuleDataBar12.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      formatConditionRuleDataBar12.MaximumType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
      formatConditionRuleDataBar12.Minimum = new decimal(new int[] {
            1000,
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
      // Error
      // 
      this.Error.Caption = "Error Message";
      this.Error.FieldName = "Error";
      this.Error.MaxWidth = 300;
      this.Error.MinWidth = 120;
      this.Error.Name = "Error";
      this.Error.OptionsColumn.AllowEdit = false;
      this.Error.OptionsColumn.AllowFocus = false;
      this.Error.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      this.Error.Width = 120;
      // 
      // CreateDate
      // 
      this.CreateDate.AppearanceCell.Options.UseTextOptions = true;
      this.CreateDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.CreateDate.Caption = "Create Date";
      this.CreateDate.DisplayFormat.FormatString = "dd/MM/yy HH:mm";
      this.CreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.CreateDate.FieldName = "CreateDate";
      this.CreateDate.MaxWidth = 105;
      this.CreateDate.MinWidth = 105;
      this.CreateDate.Name = "CreateDate";
      this.CreateDate.OptionsColumn.AllowEdit = false;
      this.CreateDate.OptionsColumn.AllowFocus = false;
      this.CreateDate.OptionsColumn.AllowSize = false;
      this.CreateDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      this.CreateDate.Width = 105;
      // 
      // ModifyDate
      // 
      this.ModifyDate.AppearanceCell.Options.UseTextOptions = true;
      this.ModifyDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.ModifyDate.Caption = "Modify Date";
      this.ModifyDate.DisplayFormat.FormatString = "dd/MM/yy HH:mm";
      this.ModifyDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.ModifyDate.FieldName = "ModifyDate";
      this.ModifyDate.MaxWidth = 105;
      this.ModifyDate.MinWidth = 105;
      this.ModifyDate.Name = "ModifyDate";
      this.ModifyDate.OptionsColumn.AllowEdit = false;
      this.ModifyDate.OptionsColumn.AllowFocus = false;
      this.ModifyDate.OptionsColumn.AllowSize = false;
      this.ModifyDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      this.ModifyDate.Width = 105;
      // 
      // LastRead
      // 
      this.LastRead.AppearanceCell.Options.UseTextOptions = true;
      this.LastRead.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.LastRead.Caption = "Last Read";
      this.LastRead.DisplayFormat.FormatString = "dd/MM/yy HH:mm";
      this.LastRead.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.LastRead.FieldName = "LastRead";
      this.LastRead.MaxWidth = 105;
      this.LastRead.MinWidth = 105;
      this.LastRead.Name = "LastRead";
      this.LastRead.OptionsColumn.AllowEdit = false;
      this.LastRead.OptionsColumn.AllowFocus = false;
      this.LastRead.OptionsColumn.AllowSize = false;
      this.LastRead.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      this.LastRead.Width = 105;
      // 
      // LastWrite
      // 
      this.LastWrite.AppearanceCell.Options.UseTextOptions = true;
      this.LastWrite.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.LastWrite.Caption = "Last Write";
      this.LastWrite.DisplayFormat.FormatString = "dd/MM/yy HH:mm";
      this.LastWrite.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.LastWrite.FieldName = "LastWrite";
      this.LastWrite.MaxWidth = 105;
      this.LastWrite.MinWidth = 105;
      this.LastWrite.Name = "LastWrite";
      this.LastWrite.OptionsColumn.AllowEdit = false;
      this.LastWrite.OptionsColumn.AllowFocus = false;
      this.LastWrite.OptionsColumn.AllowSize = false;
      this.LastWrite.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      this.LastWrite.Width = 105;
      // 
      // gridToolTipController
      // 
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
      this.statusBar.ItemLinks.Add(this.buttonLog);
      this.statusBar.ItemLinks.Add(this.labelInfo);
      this.statusBar.ItemLinks.Add(this.labelServerInfo);
      this.statusBar.Location = new System.Drawing.Point(0, 768);
      this.statusBar.Name = "statusBar";
      this.statusBar.Ribbon = this.ribbonControl1;
      this.statusBar.Size = new System.Drawing.Size(1190, 31);
      this.statusBar.ToolTipController = this.toolTipController;
      // 
      // labelDatabases
      // 
      this.labelDatabases.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelDatabases.Id = 12;
      this.labelDatabases.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelDatabases.ImageOptions.Image")));
      this.labelDatabases.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelDatabases.ImageOptions.LargeImage")));
      this.labelDatabases.Name = "labelDatabases";
      this.labelDatabases.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      this.labelDatabases.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelErrors
      // 
      this.labelErrors.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelErrors.Id = 29;
      this.labelErrors.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelErrors.ImageOptions.Image")));
      this.labelErrors.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelErrors.ImageOptions.LargeImage")));
      this.labelErrors.Name = "labelErrors";
      this.labelErrors.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelIndexes
      // 
      this.labelIndexes.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelIndexes.Id = 13;
      this.labelIndexes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelIndexes.ImageOptions.Image")));
      this.labelIndexes.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelIndexes.ImageOptions.LargeImage")));
      this.labelIndexes.Name = "labelIndexes";
      this.labelIndexes.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
      this.labelIndexes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelIndexesSize
      // 
      this.labelIndexesSize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelIndexesSize.Id = 33;
      this.labelIndexesSize.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelIndexesSize.ImageOptions.Image")));
      this.labelIndexesSize.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelIndexesSize.ImageOptions.LargeImage")));
      this.labelIndexesSize.Name = "labelIndexesSize";
      this.labelIndexesSize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelSavedSpace
      // 
      this.labelSavedSpace.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelSavedSpace.Id = 31;
      this.labelSavedSpace.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelSavedSpace.ImageOptions.Image")));
      this.labelSavedSpace.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelSavedSpace.ImageOptions.LargeImage")));
      this.labelSavedSpace.Name = "labelSavedSpace";
      this.labelSavedSpace.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelElapsedTime
      // 
      this.labelElapsedTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelElapsedTime.Id = 34;
      this.labelElapsedTime.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelElapsedTime.ImageOptions.Image")));
      this.labelElapsedTime.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelElapsedTime.ImageOptions.LargeImage")));
      this.labelElapsedTime.Name = "labelElapsedTime";
      this.labelElapsedTime.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // buttonStopScan
      // 
      this.buttonStopScan.Caption = "Stop";
      this.buttonStopScan.Id = 19;
      this.buttonStopScan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonStopScan.ImageOptions.Image")));
      this.buttonStopScan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonStopScan.ImageOptions.LargeImage")));
      this.buttonStopScan.Name = "buttonStopScan";
      this.buttonStopScan.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      this.buttonStopScan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonStopScanClick);
      // 
      // buttonStopFix
      // 
      this.buttonStopFix.Caption = "Stop";
      this.buttonStopFix.Id = 2;
      this.buttonStopFix.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonStopFix.ImageOptions.Image")));
      this.buttonStopFix.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonStopFix.ImageOptions.LargeImage")));
      this.buttonStopFix.Name = "buttonStopFix";
      this.buttonStopFix.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      this.buttonStopFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonStopFixClick);
      // 
      // buttonLog
      // 
      this.buttonLog.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
      this.buttonLog.Id = 26;
      this.buttonLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonLog.ImageOptions.Image")));
      this.buttonLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonLog.ImageOptions.LargeImage")));
      this.buttonLog.Name = "buttonLog";
      this.buttonLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonLog);
      // 
      // labelInfo
      // 
      this.labelInfo.Id = 24;
      this.labelInfo.Name = "labelInfo";
      // 
      // labelServerInfo
      // 
      this.labelServerInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelServerInfo.Id = 35;
      this.labelServerInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelServerInfo.ImageOptions.Image")));
      this.labelServerInfo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelServerInfo.ImageOptions.LargeImage")));
      this.labelServerInfo.Name = "labelServerInfo";
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
            this.buttonExportExcel,
            this.buttonExportCSV,
            this.buttonExportText,
            this.buttonLog,
            this.buttonExportHtml,
            this.buttonRestoreDefaultLayout,
            this.labelErrors,
            this.labelSavedSpace,
            this.labelIndexesSize,
            this.labelElapsedTime,
            this.labelServerInfo,
            this.buttonFeedback});
      this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
      this.ribbonControl1.MaxItemId = 38;
      this.ribbonControl1.Name = "ribbonControl1";
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonNewConnection);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonDatabases);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonRefreshIndex);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonFix);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonOptions);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonAbout);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.labelSeparator);
      this.ribbonControl1.QuickToolbarItemLinks.Add(this.buttonFeedback);
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
      this.ribbonControl1.Size = new System.Drawing.Size(1190, 27);
      this.ribbonControl1.StatusBar = this.statusBar;
      this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
      this.ribbonControl1.ShowCustomizationMenu += new DevExpress.XtraBars.Ribbon.RibbonCustomizationMenuEventHandler(this.GridCustomizationMenu);
      // 
      // buttonNewConnection
      // 
      this.buttonNewConnection.AllowRightClickInMenu = false;
      this.buttonNewConnection.Caption = "New Connection";
      this.buttonNewConnection.Id = 14;
      this.buttonNewConnection.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonNewConnection.ImageOptions.Image")));
      this.buttonNewConnection.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonNewConnection.ImageOptions.LargeImage")));
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
      this.buttonFix.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonFix.ImageOptions.Image")));
      this.buttonFix.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonFix.ImageOptions.LargeImage")));
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
      this.buttonCopyFix.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyFix.ImageOptions.Image")));
      this.buttonCopyFix.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonCopyFix.ImageOptions.LargeImage")));
      this.buttonCopyFix.Name = "buttonCopyFix";
      this.buttonCopyFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonCopyFixClick);
      // 
      // buttonSaveFix
      // 
      this.buttonSaveFix.Caption = "Save Fix Script";
      this.buttonSaveFix.Id = 23;
      this.buttonSaveFix.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveFix.ImageOptions.Image")));
      this.buttonSaveFix.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonSaveFix.ImageOptions.LargeImage")));
      this.buttonSaveFix.Name = "buttonSaveFix";
      this.buttonSaveFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonSaveFixClick);
      // 
      // buttonOptions
      // 
      this.buttonOptions.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
      this.buttonOptions.Caption = "Settings";
      this.buttonOptions.DropDownControl = this.popupExport;
      this.buttonOptions.Id = 16;
      this.buttonOptions.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonOptions.ImageOptions.Image")));
      this.buttonOptions.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonOptions.ImageOptions.LargeImage")));
      this.buttonOptions.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
      this.buttonOptions.Name = "buttonOptions";
      this.buttonOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonOptionsClick);
      // 
      // popupExport
      // 
      this.popupExport.ItemLinks.Add(this.buttonExportExcel);
      this.popupExport.ItemLinks.Add(this.buttonExportCSV);
      this.popupExport.ItemLinks.Add(this.buttonExportText);
      this.popupExport.ItemLinks.Add(this.buttonExportHtml);
      this.popupExport.ItemLinks.Add(this.buttonRestoreDefaultLayout, true);
      this.popupExport.Name = "popupExport";
      this.popupExport.Ribbon = this.ribbonControl1;
      // 
      // buttonExportExcel
      // 
      this.buttonExportExcel.Caption = "Export to Excel";
      this.buttonExportExcel.Id = 22;
      this.buttonExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonExportExcel.ImageOptions.Image")));
      this.buttonExportExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonExportExcel.ImageOptions.LargeImage")));
      this.buttonExportExcel.Name = "buttonExportExcel";
      this.buttonExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportExcel);
      // 
      // buttonExportCSV
      // 
      this.buttonExportCSV.Caption = "Export to CSV";
      this.buttonExportCSV.Id = 23;
      this.buttonExportCSV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonExportCSV.ImageOptions.Image")));
      this.buttonExportCSV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonExportCSV.ImageOptions.LargeImage")));
      this.buttonExportCSV.Name = "buttonExportCSV";
      this.buttonExportCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportCsv);
      // 
      // buttonExportText
      // 
      this.buttonExportText.Caption = "Export to TXT";
      this.buttonExportText.Id = 24;
      this.buttonExportText.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonExportText.ImageOptions.Image")));
      this.buttonExportText.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonExportText.ImageOptions.LargeImage")));
      this.buttonExportText.Name = "buttonExportText";
      this.buttonExportText.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportText);
      // 
      // buttonExportHtml
      // 
      this.buttonExportHtml.Caption = "Export to HTML";
      this.buttonExportHtml.Id = 27;
      this.buttonExportHtml.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonExportHtml.ImageOptions.Image")));
      this.buttonExportHtml.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonExportHtml.ImageOptions.LargeImage")));
      this.buttonExportHtml.Name = "buttonExportHtml";
      this.buttonExportHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportHtml);
      // 
      // buttonRestoreDefaultLayout
      // 
      this.buttonRestoreDefaultLayout.Caption = "Restore Layout";
      this.buttonRestoreDefaultLayout.Id = 28;
      this.buttonRestoreDefaultLayout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonRestoreDefaultLayout.ImageOptions.Image")));
      this.buttonRestoreDefaultLayout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonRestoreDefaultLayout.ImageOptions.LargeImage")));
      this.buttonRestoreDefaultLayout.Name = "buttonRestoreDefaultLayout";
      this.buttonRestoreDefaultLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RestoreDefaultLayout);
      // 
      // buttonAbout
      // 
      this.buttonAbout.Caption = "About";
      this.buttonAbout.Id = 17;
      this.buttonAbout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonAbout.ImageOptions.Image")));
      this.buttonAbout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonAbout.ImageOptions.LargeImage")));
      this.buttonAbout.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
      this.buttonAbout.Name = "buttonAbout";
      this.buttonAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonAboutClick);
      // 
      // buttonRefreshIndex
      // 
      this.buttonRefreshIndex.Caption = "Refresh Indexes";
      this.buttonRefreshIndex.Enabled = false;
      this.buttonRefreshIndex.Id = 19;
      this.buttonRefreshIndex.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefreshIndex.ImageOptions.Image")));
      this.buttonRefreshIndex.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonRefreshIndex.ImageOptions.LargeImage")));
      this.buttonRefreshIndex.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
      this.buttonRefreshIndex.Name = "buttonRefreshIndex";
      this.buttonRefreshIndex.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonFindClick);
      // 
      // buttonDatabases
      // 
      this.buttonDatabases.Caption = "Select Databases";
      this.buttonDatabases.Enabled = false;
      this.buttonDatabases.Id = 14;
      this.buttonDatabases.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonDatabases.ImageOptions.Image")));
      this.buttonDatabases.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonDatabases.ImageOptions.LargeImage")));
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
      this.labelSeparator.Width = 68;
      // 
      // buttonFeedback
      // 
      this.buttonFeedback.Caption = "Feature Requests, Suggestions && Bugs";
      this.buttonFeedback.Id = 36;
      this.buttonFeedback.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonFeedback.ImageOptions.Image")));
      this.buttonFeedback.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonFeedback.ImageOptions.LargeImage")));
      this.buttonFeedback.Name = "buttonFeedback";
      this.buttonFeedback.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonFeedbackClick);
      // 
      // toolTipController
      // 
      this.toolTipController.Active = false;
      // 
      // taskbar
      // 
      this.taskbar.ParentControl = this;
      // 
      // imageCollection
      // 
      this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
      this.imageCollection.InsertGalleryImage("time_16x16.png", "office2013/scheduling/time_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/scheduling/time_16x16.png"), 0);
      this.imageCollection.Images.SetKeyName(0, "time_16x16.png");
      this.imageCollection.InsertGalleryImage("pagenext_16x16.png", "devav/actions/pagenext_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("devav/actions/pagenext_16x16.png"), 1);
      this.imageCollection.Images.SetKeyName(1, "pagenext_16x16.png");
      this.imageCollection.InsertGalleryImage("apply_16x16.png", "office2013/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/apply_16x16.png"), 2);
      this.imageCollection.Images.SetKeyName(2, "apply_16x16.png");
      this.imageCollection.InsertGalleryImage("close_16x16.png", "office2013/actions/close_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/close_16x16.png"), 3);
      this.imageCollection.Images.SetKeyName(3, "close_16x16.png");
      this.imageCollection.InsertGalleryImage("copy_16x16.png", "office2013/edit/copy_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/edit/copy_16x16.png"), 4);
      this.imageCollection.Images.SetKeyName(4, "copy_16x16.png");
      this.imageCollection.InsertGalleryImage("masterfilter_16x16.png", "office2013/filter/masterfilter_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/filter/masterfilter_16x16.png"), 5);
      this.imageCollection.Images.SetKeyName(5, "masterfilter_16x16.png");
      this.imageCollection.InsertGalleryImage("showworktimeonly_16x16.png", "office2013/scheduling/showworktimeonly_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/scheduling/showworktimeonly_16x16.png"), 6);
      this.imageCollection.Images.SetKeyName(6, "showworktimeonly_16x16.png");
      this.imageCollection.InsertGalleryImage("replace_16x16.png", "office2013/format/replace_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/format/replace_16x16.png"), 7);
      this.imageCollection.Images.SetKeyName(7, "replace_16x16.png");
      this.imageCollection.InsertGalleryImage("article_16x16.png", "office2013/support/article_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/support/article_16x16.png"), 8);
      this.imageCollection.Images.SetKeyName(8, "article_16x16.png");
      // 
      // buttonFind
      // 
      this.buttonFind.ActAsDropDown = true;
      this.buttonFind.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
      this.buttonFind.Enabled = false;
      this.buttonFind.Id = 11;
      this.buttonFind.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonFind.ImageOptions.LargeImage")));
      this.buttonFind.Name = "buttonFind";
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.Horizontal = false;
      this.splitContainer.Location = new System.Drawing.Point(0, 27);
      this.splitContainer.Name = "splitContainer";
      this.splitContainer.Panel1.Controls.Add(this.grid);
      this.splitContainer.Panel1.Text = "Panel1";
      this.splitContainer.Panel2.Controls.Add(this.gridLog);
      this.splitContainer.Panel2.Text = "Panel2";
      this.splitContainer.Size = new System.Drawing.Size(1190, 741);
      this.splitContainer.SplitterPosition = 500;
      this.splitContainer.TabIndex = 5;
      // 
      // gridLog
      // 
      this.gridLog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridLog.Font = new System.Drawing.Font("Tahoma", 9F);
      this.gridLog.Location = new System.Drawing.Point(0, 0);
      this.gridLog.MainView = this.viewLog;
      this.gridLog.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
      this.gridLog.Name = "gridLog";
      this.gridLog.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
      this.gridLog.Size = new System.Drawing.Size(1190, 236);
      this.gridLog.TabIndex = 4;
      this.gridLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewLog});
      // 
      // viewLog
      // 
      this.viewLog.Appearance.EvenRow.BackColor = System.Drawing.Color.Gainsboro;
      this.viewLog.Appearance.EvenRow.Options.UseBackColor = true;
      this.viewLog.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.viewLog.Appearance.FocusedRow.Options.UseBackColor = true;
      this.viewLog.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.viewLog.Appearance.HeaderPanel.Options.UseFont = true;
      this.viewLog.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Transparent;
      this.viewLog.Appearance.HideSelectionRow.Options.UseBackColor = true;
      this.viewLog.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.viewLog.Appearance.OddRow.Options.UseBackColor = true;
      this.viewLog.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.viewLog.Appearance.Row.Options.UseFont = true;
      this.viewLog.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.viewLog.Appearance.SelectedRow.Options.UseBackColor = true;
      this.viewLog.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.viewLog.ColumnPanelRowHeight = 22;
      this.viewLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colDateTime,
            this.colDuration,
            this.colMessage});
      this.viewLog.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
      this.viewLog.GridControl = this.gridLog;
      this.viewLog.Name = "viewLog";
      this.viewLog.OptionsBehavior.Editable = false;
      this.viewLog.OptionsCustomization.AllowColumnMoving = false;
      this.viewLog.OptionsCustomization.AllowColumnResizing = false;
      this.viewLog.OptionsCustomization.AllowFilter = false;
      this.viewLog.OptionsCustomization.AllowGroup = false;
      this.viewLog.OptionsCustomization.AllowQuickHideColumns = false;
      this.viewLog.OptionsFilter.AllowFilterEditor = false;
      this.viewLog.OptionsMenu.EnableColumnMenu = false;
      this.viewLog.OptionsView.EnableAppearanceEvenRow = true;
      this.viewLog.OptionsView.EnableAppearanceOddRow = true;
      this.viewLog.OptionsView.RowAutoHeight = true;
      this.viewLog.OptionsView.ShowGroupPanel = false;
      this.viewLog.OptionsView.ShowIndicator = false;
      this.viewLog.RowHeight = 22;
      // 
      // colDuration
      // 
      this.colDuration.AppearanceCell.Options.UseTextOptions = true;
      this.colDuration.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.colDuration.Caption = "Duration";
      this.colDuration.DisplayFormat.FormatString = "HH:mm:ss.fff";
      this.colDuration.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.colDuration.FieldName = "Duration";
      this.colDuration.MaxWidth = 90;
      this.colDuration.MinWidth = 90;
      this.colDuration.Name = "colDuration";
      this.colDuration.Visible = true;
      this.colDuration.VisibleIndex = 1;
      this.colDuration.Width = 90;
      // 
      // colMessage
      // 
      this.colMessage.AppearanceCell.Options.UseTextOptions = true;
      this.colMessage.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
      this.colMessage.Caption = "Message";
      this.colMessage.ColumnEdit = this.repositoryItemMemoEdit1;
      this.colMessage.FieldName = "Message";
      this.colMessage.Name = "colMessage";
      this.colMessage.Visible = true;
      this.colMessage.VisibleIndex = 2;
      this.colMessage.Width = 1010;
      // 
      // repositoryItemMemoEdit1
      // 
      this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
      // 
      // MainBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1190, 799);
      this.Controls.Add(this.splitContainer);
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
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupFix)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupExport)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxSearchControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridLog)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.viewLog)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
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
    private DevExpress.Utils.ImageCollection imageCollection;
    private DevExpress.XtraGrid.Columns.GridColumn Duration;
    private BarButtonItem buttonCopyFix;
    private BarStaticItem labelDatabases;
    private BarStaticItem labelIndexes;
    private DevExpress.Utils.ToolTipController toolTipController;
    private BarButtonItem buttonDatabases;
    private BarEditItem boxSearch;
    private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl boxSearchControl;
    private BarStaticItem labelSeparator;
    private DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel repositoryItemHypertextLabel1;
    private BarButtonItem buttonStopScan;
    private BarButtonItem buttonFind;
    private DevExpress.Utils.ToolTipController gridToolTipController;
    private PopupMenu popupExport;
    private BarButtonItem buttonExportExcel;
    private BarButtonItem buttonExportCSV;
    private BarButtonItem buttonExportText;
    private DevExpress.XtraEditors.SplitContainerControl splitContainer;
    private BarButtonItem buttonLog;
    private DevExpress.XtraGrid.GridControl gridLog;
    private DevExpress.XtraGrid.Views.Grid.GridView viewLog;
    private DevExpress.XtraGrid.Columns.GridColumn colDuration;
    private DevExpress.XtraGrid.Columns.GridColumn colMessage;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    private PopupMenu popupFix;
    private BarButtonItem buttonExportHtml;
    private DevExpress.XtraGrid.Columns.GridColumn PageSpaceUsed;
    private DevExpress.XtraGrid.Columns.GridColumn Warning;
    private BarButtonItem buttonRestoreDefaultLayout;
    private DevExpress.XtraGrid.Columns.GridColumn Error;
    private BarStaticItem labelErrors;
    private BarStaticItem labelSavedSpace;
    private BarStaticItem labelIndexesSize;
    private BarStaticItem labelElapsedTime;
    private BarStaticItem labelServerInfo;
    private DevExpress.XtraGrid.Columns.GridColumn CreateDate;
    private DevExpress.XtraGrid.Columns.GridColumn ModifyDate;
    private DevExpress.XtraGrid.Columns.GridColumn LastRead;
    private DevExpress.XtraGrid.Columns.GridColumn LastWrite;
    private BarButtonItem buttonFeedback;
  }
}