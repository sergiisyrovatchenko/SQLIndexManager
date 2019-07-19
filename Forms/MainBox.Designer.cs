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
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar1 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar2 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar3 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar4 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar5 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBox));
      this.popupIndexOperation = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.repositoryItemHypertextLabel1 = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
      this.gridControl1 = new DevExpress.XtraGrid.GridControl();
      this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.Duration = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridToolTipController = new DevExpress.Utils.ToolTipController(this.components);
      this.statusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
      this.labelDatabase = new DevExpress.XtraBars.BarStaticItem();
      this.labelIndex = new DevExpress.XtraBars.BarStaticItem();
      this.buttonStopScan = new DevExpress.XtraBars.BarButtonItem();
      this.buttonStopFix = new DevExpress.XtraBars.BarButtonItem();
      this.buttonLog = new DevExpress.XtraBars.BarButtonItem();
      this.labelServerInfo = new DevExpress.XtraBars.BarStaticItem();
      this.labelInfo = new DevExpress.XtraBars.BarStaticItem();
      this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
      this.buttonNewConnection = new DevExpress.XtraBars.BarButtonItem();
      this.buttonFix = new DevExpress.XtraBars.BarButtonItem();
      this.popupFix = new DevExpress.XtraBars.PopupMenu(this.components);
      this.buttonCopyFix = new DevExpress.XtraBars.BarButtonItem();
      this.buttonSaveFix = new DevExpress.XtraBars.BarButtonItem();
      this.buttonOptions = new DevExpress.XtraBars.BarButtonItem();
      this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
      this.buttonExportExcel = new DevExpress.XtraBars.BarButtonItem();
      this.buttonExportCSV = new DevExpress.XtraBars.BarButtonItem();
      this.buttonExportText = new DevExpress.XtraBars.BarButtonItem();
      this.buttonExportHtml = new DevExpress.XtraBars.BarButtonItem();
      this.buttonAbout = new DevExpress.XtraBars.BarButtonItem();
      this.buttonRefreshIndex = new DevExpress.XtraBars.BarButtonItem();
      this.buttonDatabases = new DevExpress.XtraBars.BarButtonItem();
      this.boxSearch = new DevExpress.XtraBars.BarEditItem();
      this.boxSearchControl = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
      this.labelSeparator = new DevExpress.XtraBars.BarStaticItem();
      this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
      this.popupExport = new DevExpress.XtraBars.PopupMenu(this.components);
      this.taskbar = new DevExpress.Utils.Taskbar.TaskbarAssistant();
      this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
      this.buttonFind = new DevExpress.XtraBars.BarButtonItem();
      this.splitContainer = new DevExpress.XtraEditors.SplitContainerControl();
      this.gridControl2 = new DevExpress.XtraGrid.GridControl();
      this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupFix)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxSearchControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupExport)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
      RowsCount.DisplayFormat.FormatString = "N0";
      RowsCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
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
      SchemaName.MaxWidth = 200;
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
      ObjectName.MaxWidth = 350;
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
      FileGroupName.MaxWidth = 150;
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
      IndexName.MaxWidth = 400;
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
      IndexType.MaxWidth = 200;
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
      IndexStats.MaxWidth = 110;
      IndexStats.MinWidth = 110;
      IndexStats.Name = "IndexStats";
      IndexStats.OptionsColumn.AllowEdit = false;
      IndexStats.OptionsColumn.AllowFocus = false;
      IndexStats.OptionsColumn.AllowSize = false;
      IndexStats.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      IndexStats.Visible = true;
      IndexStats.VisibleIndex = 12;
      IndexStats.Width = 110;
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
      LastUsage.MaxWidth = 110;
      LastUsage.MinWidth = 110;
      LastUsage.Name = "LastUsage";
      LastUsage.OptionsColumn.AllowEdit = false;
      LastUsage.OptionsColumn.AllowFocus = false;
      LastUsage.OptionsColumn.AllowSize = false;
      LastUsage.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
      LastUsage.Visible = true;
      LastUsage.VisibleIndex = 15;
      LastUsage.Width = 110;
      // 
      // FixType
      // 
      FixType.Caption = "Fix";
      FixType.ColumnEdit = this.popupIndexOperation;
      FixType.FieldName = "FixType";
      FixType.MaxWidth = 200;
      FixType.MinWidth = 90;
      FixType.Name = "FixType";
      FixType.OptionsColumn.AllowIncrementalSearch = false;
      FixType.OptionsColumn.AllowShowHide = false;
      FixType.OptionsColumn.ShowInCustomizationForm = false;
      FixType.OptionsColumn.ShowInExpressionEditor = false;
      FixType.OptionsColumn.TabStop = false;
      FixType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
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
      DatabaseName.MaxWidth = 200;
      DatabaseName.MinWidth = 100;
      DatabaseName.Name = "DatabaseName";
      DatabaseName.OptionsColumn.AllowEdit = false;
      DatabaseName.OptionsColumn.AllowFocus = false;
      DatabaseName.OptionsColumn.AllowShowHide = false;
      DatabaseName.OptionsColumn.ShowInCustomizationForm = false;
      DatabaseName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
      DatabaseName.Visible = true;
      DatabaseName.VisibleIndex = 2;
      DatabaseName.Width = 110;
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
      IndexColumns.MaxWidth = 600;
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
      IncludedColumns.MaxWidth = 600;
      IncludedColumns.MinWidth = 150;
      IncludedColumns.Name = "IncludedColumns";
      IncludedColumns.OptionsColumn.AllowEdit = false;
      IncludedColumns.OptionsColumn.AllowFocus = false;
      IncludedColumns.OptionsFilter.AllowFilter = false;
      IncludedColumns.Width = 150;
      // 
      // repositoryItemHypertextLabel1
      // 
      this.repositoryItemHypertextLabel1.Name = "repositoryItemHypertextLabel1";
      // 
      // gridControl1
      // 
      this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl1.Font = new System.Drawing.Font("Tahoma", 9F);
      this.gridControl1.Location = new System.Drawing.Point(0, 0);
      this.gridControl1.MainView = this.gridView1;
      this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.popupIndexOperation});
      this.gridControl1.Size = new System.Drawing.Size(1190, 500);
      this.gridControl1.TabIndex = 2;
      this.gridControl1.ToolTipController = this.gridToolTipController;
      this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
      // 
      // gridView1
      // 
      this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
      this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
      this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
      this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Transparent;
      this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
      this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.Gainsboro;
      this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
      this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.gridView1.Appearance.Row.Options.UseFont = true;
      this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
      this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.gridView1.ColumnPanelRowHeight = 26;
      this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            Progress,
            this.Duration,
            FixType,
            DatabaseName,
            SchemaName,
            ObjectName,
            IndexName,
            IndexType,
            PartitionNumber,
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
            IncludedColumns});
      this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
      gridFormatRule1.Column = Fragmentation;
      gridFormatRule1.ColumnApplyTo = Fragmentation;
      gridFormatRule1.Name = "Fragmentation";
      formatConditionRuleDataBar1.AllowNegativeAxis = false;
      formatConditionRuleDataBar1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
      formatConditionRuleDataBar1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
      formatConditionRuleDataBar1.Appearance.BorderColor = System.Drawing.Color.Transparent;
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
      gridFormatRule1.Rule = formatConditionRuleDataBar1;
      gridFormatRule2.Column = PagesCount;
      gridFormatRule2.ColumnApplyTo = PagesCount;
      gridFormatRule2.Name = "PagesCount";
      formatConditionRuleDataBar2.AllowNegativeAxis = false;
      formatConditionRuleDataBar2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(247)))));
      formatConditionRuleDataBar2.Appearance.BackColor2 = System.Drawing.Color.Transparent;
      formatConditionRuleDataBar2.Appearance.BorderColor = System.Drawing.Color.Transparent;
      formatConditionRuleDataBar2.Appearance.Options.UseBackColor = true;
      formatConditionRuleDataBar2.Appearance.Options.UseBorderColor = true;
      formatConditionRuleDataBar2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
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
      gridFormatRule3.Column = UnusedPagesCount;
      gridFormatRule3.ColumnApplyTo = UnusedPagesCount;
      gridFormatRule3.Name = "UnusedPagesCount";
      formatConditionRuleDataBar3.AllowNegativeAxis = false;
      formatConditionRuleDataBar3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
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
      gridFormatRule4.Column = RowsCount;
      gridFormatRule4.ColumnApplyTo = RowsCount;
      gridFormatRule4.Name = "RowsCount";
      formatConditionRuleDataBar4.AllowNegativeAxis = false;
      formatConditionRuleDataBar4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(214)))), ((int)(((byte)(135)))));
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
      gridFormatRule5.Column = SavedSpace;
      gridFormatRule5.ColumnApplyTo = SavedSpace;
      gridFormatRule5.Name = "SavedSpace";
      formatConditionRuleDataBar5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(218)))), ((int)(((byte)(206)))));
      formatConditionRuleDataBar5.Appearance.BackColor2 = System.Drawing.Color.Transparent;
      formatConditionRuleDataBar5.Appearance.BorderColor = System.Drawing.Color.Transparent;
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
            1,
            0,
            0,
            0});
      formatConditionRuleDataBar5.MinimumType = DevExpress.XtraEditors.FormatConditionValueType.Number;
      formatConditionRuleDataBar5.PredefinedName = null;
      formatConditionRuleDataBar5.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
      gridFormatRule5.Rule = formatConditionRuleDataBar5;
      this.gridView1.FormatRules.Add(gridFormatRule1);
      this.gridView1.FormatRules.Add(gridFormatRule2);
      this.gridView1.FormatRules.Add(gridFormatRule3);
      this.gridView1.FormatRules.Add(gridFormatRule4);
      this.gridView1.FormatRules.Add(gridFormatRule5);
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsCustomization.AllowGroup = false;
      this.gridView1.OptionsFind.AllowFindPanel = false;
      this.gridView1.OptionsFind.FindFilterColumns = "DatabaseName;SchemaName;ObjectName;IndexName;FileGroupName;IndexColumns;IncludedC" +
    "olumns";
      this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
      this.gridView1.OptionsFind.FindNullPrompt = "";
      this.gridView1.OptionsFind.ShowClearButton = false;
      this.gridView1.OptionsFind.ShowCloseButton = false;
      this.gridView1.OptionsFind.ShowFindButton = false;
      this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
      this.gridView1.OptionsLayout.StoreDataSettings = false;
      this.gridView1.OptionsLayout.StoreVisualOptions = false;
      this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
      this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
      this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
      this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
      this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridView1.OptionsSelection.MultiSelect = true;
      this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
      this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
      this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
      this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
      this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
      this.gridView1.OptionsView.ColumnAutoWidth = false;
      this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
      this.gridView1.OptionsView.EnableAppearanceOddRow = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.OptionsView.ShowIndicator = false;
      this.gridView1.RowHeight = 24;
      this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GridRowCellClick);
      this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GridRowCellStyle);
      this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GridPopupMenuShowing);
      this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.GridSelectionChanged);
      this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.GridColumnDisplayText);
      this.gridView1.DoubleClick += new System.EventHandler(this.GridDoubleClick);
      this.gridView1.RowCountChanged += new System.EventHandler(this.GridRowCountChanged);
      // 
      // Duration
      // 
      this.Duration.AppearanceCell.Options.UseTextOptions = true;
      this.Duration.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
      this.Duration.Caption = "Duration";
      this.Duration.DisplayFormat.FormatString = "mm:ss.fff";
      this.Duration.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.Duration.FieldName = "Duration";
      this.Duration.MaxWidth = 70;
      this.Duration.MinWidth = 70;
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
      this.Duration.OptionsFilter.AllowFilter = false;
      this.Duration.Width = 70;
      // 
      // gridToolTipController
      // 
      this.gridToolTipController.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.GetActiveObjectInfo);
      // 
      // statusBar
      // 
      this.statusBar.ItemLinks.Add(this.labelDatabase);
      this.statusBar.ItemLinks.Add(this.labelIndex);
      this.statusBar.ItemLinks.Add(this.buttonStopScan);
      this.statusBar.ItemLinks.Add(this.buttonStopFix);
      this.statusBar.ItemLinks.Add(this.buttonLog);
      this.statusBar.ItemLinks.Add(this.labelServerInfo);
      this.statusBar.ItemLinks.Add(this.labelInfo);
      this.statusBar.Location = new System.Drawing.Point(0, 768);
      this.statusBar.Name = "statusBar";
      this.statusBar.Ribbon = this.ribbonControl1;
      this.statusBar.Size = new System.Drawing.Size(1190, 31);
      this.statusBar.ToolTipController = this.toolTipController;
      // 
      // labelDatabase
      // 
      this.labelDatabase.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelDatabase.Caption = "0";
      this.labelDatabase.Id = 12;
      this.labelDatabase.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelDatabase.ImageOptions.Image")));
      this.labelDatabase.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelDatabase.ImageOptions.LargeImage")));
      this.labelDatabase.Name = "labelDatabase";
      this.labelDatabase.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelIndex
      // 
      this.labelIndex.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelIndex.Caption = "0";
      this.labelIndex.Id = 13;
      this.labelIndex.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelIndex.ImageOptions.Image")));
      this.labelIndex.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelIndex.ImageOptions.LargeImage")));
      this.labelIndex.Name = "labelIndex";
      this.labelIndex.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
      // labelServerInfo
      // 
      this.labelServerInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
      this.labelServerInfo.Caption = "Not connected";
      this.labelServerInfo.Id = 26;
      this.labelServerInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelServerInfo.ImageOptions.Image")));
      this.labelServerInfo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("labelServerInfo.ImageOptions.LargeImage")));
      this.labelServerInfo.Name = "labelServerInfo";
      this.labelServerInfo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
      // 
      // labelInfo
      // 
      this.labelInfo.Id = 24;
      this.labelInfo.Name = "labelInfo";
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
            this.labelServerInfo,
            this.buttonStopFix,
            this.buttonCopyFix,
            this.labelDatabase,
            this.labelIndex,
            this.buttonDatabases,
            this.boxSearch,
            this.labelSeparator,
            this.buttonStopScan,
            this.buttonExportExcel,
            this.buttonExportCSV,
            this.buttonExportText,
            this.buttonLog,
            this.buttonExportHtml});
      this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
      this.ribbonControl1.MaxItemId = 28;
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
      this.buttonCopyFix.Caption = "Copy Script";
      this.buttonCopyFix.Id = 7;
      this.buttonCopyFix.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyFix.ImageOptions.Image")));
      this.buttonCopyFix.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonCopyFix.ImageOptions.LargeImage")));
      this.buttonCopyFix.Name = "buttonCopyFix";
      this.buttonCopyFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonCopyFixClick);
      // 
      // buttonSaveFix
      // 
      this.buttonSaveFix.Caption = "Save Script";
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
      this.buttonOptions.DropDownControl = this.popupMenu1;
      this.buttonOptions.Id = 16;
      this.buttonOptions.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonOptions.ImageOptions.Image")));
      this.buttonOptions.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonOptions.ImageOptions.LargeImage")));
      this.buttonOptions.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
      this.buttonOptions.Name = "buttonOptions";
      this.buttonOptions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonOptionsClick);
      // 
      // popupMenu1
      // 
      this.popupMenu1.ItemLinks.Add(this.buttonExportExcel);
      this.popupMenu1.ItemLinks.Add(this.buttonExportCSV);
      this.popupMenu1.ItemLinks.Add(this.buttonExportText);
      this.popupMenu1.ItemLinks.Add(this.buttonExportHtml);
      this.popupMenu1.Name = "popupMenu1";
      this.popupMenu1.Ribbon = this.ribbonControl1;
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
      this.boxSearchControl.Client = this.gridControl1;
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
      // toolTipController
      // 
      this.toolTipController.Active = false;
      // 
      // popupExport
      // 
      this.popupExport.ItemLinks.Add(this.buttonExportExcel);
      this.popupExport.ItemLinks.Add(this.buttonExportCSV);
      this.popupExport.ItemLinks.Add(this.buttonExportText);
      this.popupExport.ItemLinks.Add(this.buttonExportHtml);
      this.popupExport.Name = "popupExport";
      this.popupExport.Ribbon = this.ribbonControl1;
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
      this.splitContainer.Panel1.Controls.Add(this.gridControl1);
      this.splitContainer.Panel1.Text = "Panel1";
      this.splitContainer.Panel2.Controls.Add(this.gridControl2);
      this.splitContainer.Panel2.Text = "Panel2";
      this.splitContainer.Size = new System.Drawing.Size(1190, 741);
      this.splitContainer.SplitterPosition = 500;
      this.splitContainer.TabIndex = 5;
      // 
      // gridControl2
      // 
      this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl2.Font = new System.Drawing.Font("Tahoma", 9F);
      this.gridControl2.Location = new System.Drawing.Point(0, 0);
      this.gridControl2.MainView = this.gridView2;
      this.gridControl2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
      this.gridControl2.Name = "gridControl2";
      this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
      this.gridControl2.Size = new System.Drawing.Size(1190, 236);
      this.gridControl2.TabIndex = 4;
      this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
      // 
      // gridView2
      // 
      this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
      this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
      this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
      this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Transparent;
      this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
      this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.Gainsboro;
      this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
      this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.75F);
      this.gridView2.Appearance.Row.Options.UseFont = true;
      this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
      this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
      this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.gridView2.ColumnPanelRowHeight = 22;
      this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colDateTime,
            this.colDuration,
            this.colMessage});
      this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
      this.gridView2.GridControl = this.gridControl2;
      this.gridView2.Name = "gridView2";
      this.gridView2.OptionsBehavior.Editable = false;
      this.gridView2.OptionsCustomization.AllowColumnMoving = false;
      this.gridView2.OptionsCustomization.AllowColumnResizing = false;
      this.gridView2.OptionsCustomization.AllowFilter = false;
      this.gridView2.OptionsCustomization.AllowGroup = false;
      this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
      this.gridView2.OptionsFilter.AllowFilterEditor = false;
      this.gridView2.OptionsMenu.EnableColumnMenu = false;
      this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
      this.gridView2.OptionsView.EnableAppearanceOddRow = true;
      this.gridView2.OptionsView.RowAutoHeight = true;
      this.gridView2.OptionsView.ShowGroupPanel = false;
      this.gridView2.OptionsView.ShowIndicator = false;
      this.gridView2.RowHeight = 22;
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
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupFix)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.boxSearchControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupExport)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
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
    private BarStaticItem labelServerInfo;
    private BarButtonItem buttonStopFix;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.Utils.Taskbar.TaskbarAssistant taskbar;
    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit popupIndexOperation;
    private DevExpress.Utils.ImageCollection imageCollection;
    private DevExpress.XtraGrid.Columns.GridColumn Duration;
    private BarButtonItem buttonCopyFix;
    private BarStaticItem labelDatabase;
    private BarStaticItem labelIndex;
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
    private DevExpress.XtraGrid.GridControl gridControl2;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    private DevExpress.XtraGrid.Columns.GridColumn colDuration;
    private DevExpress.XtraGrid.Columns.GridColumn colMessage;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    private PopupMenu popupFix;
    private BarButtonItem buttonExportHtml;
    private PopupMenu popupMenu1;
  }
}