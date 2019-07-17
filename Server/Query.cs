namespace SQLIndexManager {

  public class Query {

    public const string PreDescribeIndexes = @"
SET NOCOUNT ON

IF OBJECT_ID('tempdb.dbo.#AllocationUnits') IS NOT NULL
    DROP TABLE #AllocationUnits

CREATE TABLE #AllocationUnits (
      ContainerID   BIGINT PRIMARY KEY
    , ReservedPages BIGINT NOT NULL
    , UsedPages     BIGINT NOT NULL
)

INSERT INTO #AllocationUnits (ContainerID, ReservedPages, UsedPages)
SELECT [container_id]
     , SUM([total_pages])
     , SUM([used_pages])
FROM sys.allocation_units WITH(NOLOCK)
GROUP BY [container_id]
HAVING SUM([total_pages]) BETWEEN @MinIndexSize AND @MaxIndexSize

IF OBJECT_ID('tempdb.dbo.#ExcludeList') IS NOT NULL
    DROP TABLE #ExcludeList

CREATE TABLE #ExcludeList (ID INT PRIMARY KEY)

INSERT INTO #ExcludeList
SELECT [object_id]
FROM sys.objects WITH(NOLOCK)
WHERE [type] IN ('V', 'U')
    AND ( [is_ms_shipped] = 1 {1})

IF OBJECT_ID('tempdb.dbo.#Partitions') IS NOT NULL
    DROP TABLE #Partitions
{7}

IF OBJECT_ID('tempdb.dbo.#Indexes') IS NOT NULL
    DROP TABLE #Indexes

CREATE TABLE #Indexes (
      ObjectID         INT NOT NULL
    , IndexID          INT NOT NULL
    , IndexName        SYSNAME NULL
    , PagesCount       BIGINT NOT NULL
    , UnusedPagesCount BIGINT NOT NULL
    , PartitionNumber  INT NOT NULL
    , RowsCount        BIGINT NOT NULL
    , IndexType        TINYINT NOT NULL
    , IsAllowPageLocks BIT NOT NULL
    , DataSpaceID      INT NOT NULL
    , DataCompression  TINYINT NOT NULL
    , IsUnique         BIT NOT NULL
    , IsPK             BIT NOT NULL
    , FillFactorValue  INT NOT NULL
    , IsFiltered       BIT NOT NULL
    , PRIMARY KEY (ObjectID, IndexID, PartitionNumber)
)

INSERT INTO #Indexes
SELECT ObjectID         = i.[object_id]
     , IndexID          = i.index_id
     , IndexName        = i.[name]
     , PagesCount       = a.ReservedPages
     , UnusedPagesCount = CASE WHEN ABS(a.ReservedPages - a.UsedPages) > 32 THEN a.ReservedPages - a.UsedPages ELSE 0 END
     , PartitionNumber  = p.[partition_number]
     , RowsCount        = ISNULL(p.[rows], 0)
     , IndexType        = i.[type]
     , IsAllowPageLocks = i.[allow_page_locks]
     , DataSpaceID      = i.[data_space_id]
     , DataCompression  = p.[data_compression]
     , IsUnique         = i.[is_unique]
     , IsPK             = i.[is_primary_key]
     , FillFactorValue  = i.[fill_factor]
     , IsFiltered       = i.[has_filter]
FROM #AllocationUnits a
JOIN #Partitions p ON a.ContainerID = p.[partition_id]
JOIN sys.indexes i WITH(NOLOCK) ON i.[object_id] = p.[object_id] AND p.[index_id] = i.[index_id] {6}
WHERE i.[type] IN ({0})
    AND i.[object_id] > 255

DECLARE @DBID   INT
      , @DBNAME SYSNAME

SET @DBNAME = DB_NAME()
SELECT @DBID = [database_id]
FROM sys.databases WITH(NOLOCK)
WHERE [name] = @DBNAME

IF OBJECT_ID('tempdb.dbo.#Fragmentation') IS NOT NULL
    DROP TABLE #Fragmentation

CREATE TABLE #Fragmentation (
      ObjectID         INT NOT NULL
    , IndexID          INT NOT NULL
    , PartitionNumber  INT NOT NULL
    , Fragmentation    FLOAT NOT NULL
    , PRIMARY KEY (ObjectID, IndexID, PartitionNumber)
)
{2}

IF OBJECT_ID('tempdb.dbo.#Columns') IS NOT NULL
    DROP TABLE #Columns

CREATE TABLE #Columns (
      ObjectID     INT NOT NULL
    , ColumnID     INT NOT NULL
    , ColumnName   SYSNAME NULL
    , SystemTypeID TINYINT NULL
    , IsSparse     BIT
    , IsColumnSet  BIT
    , MaxLen       SMALLINT
    , PRIMARY KEY (ObjectID, ColumnID)
)

INSERT INTO #Columns
SELECT ObjectID     = [object_id]
     , ColumnID     = [column_id]
     , ColumnName   = [name]
     , SystemTypeID = [system_type_id]
     , IsSparse     = [is_sparse]
     , IsColumnSet  = [is_column_set]
     , MaxLen       = [max_length]
FROM sys.columns WITH(NOLOCK)
WHERE [object_id] IN (SELECT DISTINCT i.ObjectID FROM #Indexes i)

IF OBJECT_ID('tempdb.dbo.#IndexColumns') IS NOT NULL
    DROP TABLE #IndexColumns

CREATE TABLE #IndexColumns (
      ObjectID      INT NOT NULL
    , IndexID       INT NOT NULL
    , IndexColumnID INT NOT NULL
    , ColumnID      TINYINT NOT NULL
    , IsIncluded    BIT NOT NULL
    , PRIMARY KEY (ObjectID, IndexID, ColumnID)
)

INSERT INTO #IndexColumns
SELECT ObjectID      = [object_id]
     , IndexID       = [index_id]
     , IndexColumnID = [index_column_id]
     , ColumnID      = [column_id]
     , IsIncluded    = ISNULL([is_included_column], 0)
FROM sys.index_columns ic WITH(NOLOCK)
WHERE EXISTS(
        SELECT *
        FROM #Indexes i
        WHERE i.ObjectID = ic.[object_id]
            AND i.IndexID = ic.[index_id]
    )

IF OBJECT_ID('tempdb.dbo.#Lob') IS NOT NULL
    DROP TABLE #Lob

CREATE TABLE #Lob (
      ObjectID    INT NOT NULL
    , IndexID     INT NOT NULL
    , IsLobLegacy BIT
    , IsLob       BIT
    , PRIMARY KEY (ObjectID, IndexID)
)
{3}

IF OBJECT_ID('tempdb.dbo.#Sparse') IS NOT NULL
    DROP TABLE #Sparse

CREATE TABLE #Sparse (ObjectID INT PRIMARY KEY)
INSERT INTO #Sparse
SELECT DISTINCT ObjectID
FROM #Columns
WHERE IsSparse = 1
    OR IsColumnSet = 1

IF OBJECT_ID('tempdb.dbo.#AggColumns') IS NOT NULL
    DROP TABLE #AggColumns

SELECT *
     , IndexColumns = STUFF((
            SELECT ', [' + c.ColumnName + ']'
            FROM #IndexColumns i
            JOIN #Columns c ON i.ObjectID = c.ObjectID AND i.ColumnID = c.ColumnID
            WHERE i.ObjectID = t.ObjectID
                AND i.IndexID = t.IndexID
                AND i.IsIncluded = 0
            ORDER BY i.IndexColumnID
        FOR XML PATH(''), TYPE).value('(./text())[1]', 'NVARCHAR(MAX)'), 1, 2, '')
     , IncludedColumns = STUFF((
            SELECT ', [' + c.ColumnName + ']'
            FROM #IndexColumns i
            JOIN #Columns c ON i.ObjectID = c.ObjectID AND i.ColumnID = c.ColumnID
            WHERE i.ObjectID = t.ObjectID
                AND i.IndexID = t.IndexID
                AND i.IsIncluded = 1
            ORDER BY i.IndexColumnID
        FOR XML PATH(''), TYPE).value('(./text())[1]', 'NVARCHAR(MAX)'), 1, 2, '')
INTO #AggColumns
FROM (
    SELECT DISTINCT ObjectID, IndexID
    FROM #Indexes
    WHERE IndexType IN (1, 2, 6)
) t

SELECT i.ObjectID
     , i.IndexID
     , i.IndexName
     , ObjectName       = o.[name]
     , SchemaName       = s.[name]
     , i.PagesCount
     , i.UnusedPagesCount
     , i.PartitionNumber
     , i.RowsCount
     , i.IndexType
     , i.IsAllowPageLocks
     , u.TotalWrites
     , u.TotalReads
     , u.TotalSeeks
     , u.TotalScans
     , u.TotalLookups
     , u.LastUsage
     , i.DataCompression
     , f.Fragmentation
     , IndexStats       = STATS_DATE(i.ObjectID, i.IndexID)
     , IsLobLegacy      = ISNULL(lob.IsLobLegacy, 0)
     , IsLob            = ISNULL(lob.IsLob, 0)
     , IsSparse         = CAST(CASE WHEN p.ObjectID IS NULL THEN 0 ELSE 1 END AS BIT)
     , IsPartitioned    = CAST(CASE WHEN dds.[data_space_id] IS NOT NULL THEN 1 ELSE 0 END AS BIT)
     , FileGroupName    = fg.[name]
     , i.IsUnique
     , i.IsPK
     , i.FillFactorValue
     , i.IsFiltered
     , a.IndexColumns
     , a.IncludedColumns
FROM #Indexes i
JOIN sys.objects o WITH(NOLOCK) ON o.[object_id] = i.ObjectID
JOIN sys.schemas s WITH(NOLOCK) ON s.[schema_id] = o.[schema_id]
LEFT JOIN #AggColumns a ON a.ObjectID = i.ObjectID AND a.IndexID = i.IndexID
LEFT JOIN #Sparse p ON p.ObjectID = i.ObjectID
LEFT JOIN #Fragmentation f ON f.ObjectID = i.ObjectID AND f.IndexID = i.IndexID AND f.PartitionNumber = i.PartitionNumber
LEFT JOIN ({4}) u ON i.ObjectID = u.ObjectID AND i.IndexID = u.IndexID
LEFT JOIN #Lob lob ON lob.ObjectID = i.ObjectID AND lob.IndexID = i.IndexID
LEFT JOIN sys.destination_data_spaces dds WITH(NOLOCK) ON i.DataSpaceID = dds.[partition_scheme_id] AND i.PartitionNumber = dds.[destination_id]
JOIN sys.filegroups fg WITH(NOLOCK) ON ISNULL(dds.[data_space_id], i.DataSpaceID) = fg.[data_space_id] {5}
WHERE o.[type] IN ('V', 'U')
    AND (
            f.Fragmentation >= @Fragmentation
        OR
            i.PagesCount > @PreDescribeSize
        OR
            i.IndexType IN (5, 6)
    )
";

    public const string MissingIndex = @"
SET NOCOUNT ON

IF OBJECT_ID('tempdb.dbo.#Indexes') IS NOT NULL
    DROP TABLE #Indexes

SELECT ObjectID     = d.[object_id]
     , UserImpact   = gs.[avg_user_impact]
     , TotalReads   = gs.[user_seeks] + gs.[user_scans]
     , TotalSeeks   = gs.[user_seeks]
     , TotalScans   = gs.[user_scans]
     , LastUsage    = ISNULL(gs.[last_user_scan], gs.[last_user_seek])
     , IndexColumns =
                CASE
                    WHEN d.[equality_columns] IS NOT NULL AND d.[inequality_columns] IS NOT NULL
                        THEN d.[equality_columns] + ', ' + d.[inequality_columns]
                    WHEN d.[equality_columns] IS NOT NULL AND d.[inequality_columns] IS NULL
                        THEN d.[equality_columns]
                    ELSE d.[inequality_columns]
                END
     , IncludedColumns = d.[included_columns]
INTO #Indexes
FROM sys.dm_db_missing_index_groups g WITH(NOLOCK)
JOIN sys.dm_db_missing_index_group_stats gs WITH(NOLOCK) ON gs.[group_handle] = g.[index_group_handle]
JOIN sys.dm_db_missing_index_details d WITH(NOLOCK) ON g.[index_handle] = d.[index_handle]
WHERE d.[database_id] = DB_ID()

IF OBJECT_ID('tempdb.dbo.#AllocationUnits') IS NOT NULL
    DROP TABLE #AllocationUnits

SELECT ObjectID   = p.[object_id]
     , RowsCount  = SUM(p.[rows])
     , PagesCount = SUM(t.[total_pages])
     , IndexStats = STATS_DATE(p.[object_id], 1)
INTO #AllocationUnits
FROM sys.partitions p
JOIN (
    SELECT [container_id]
         , [total_pages] = SUM([total_pages])
    FROM sys.allocation_units WITH(NOLOCK)
    GROUP BY [container_id]
    HAVING SUM([total_pages]) BETWEEN @MinIndexSize AND @MaxIndexSize
) t ON t.[container_id] = p.[partition_id]
WHERE p.[object_id] IN (SELECT DISTINCT i.ObjectID FROM #Indexes i)
    AND p.[index_id] IN (0, 1)
GROUP BY p.[object_id]

SELECT *, FileGroupName = (
                  SELECT f.[name]
                  FROM sys.filegroups f WITH(NOLOCK)
                  WHERE f.[is_default] = 1
              )
FROM (
    SELECT i.ObjectID
         , ObjectName    = o.[name]
         , SchemaName    = s.[name]
         , Fragmentation = CAST(100. * (i.UserImpact * i.TotalReads) / MAX(i.UserImpact * i.TotalReads) OVER() AS FLOAT)
         , a.RowsCount
         , a.PagesCount
         , i.TotalReads
         , i.TotalSeeks
         , i.TotalScans
         , i.LastUsage
         , a.IndexStats
         , i.IndexColumns
         , i.IncludedColumns
    FROM #Indexes i
    JOIN #AllocationUnits a ON i.ObjectID = a.ObjectID
    JOIN sys.objects o WITH(NOLOCK) ON o.[object_id] = i.ObjectID
    JOIN sys.schemas s WITH(NOLOCK) ON o.[schema_id] = s.[schema_id]
) t
WHERE t.Fragmentation >= @Fragmentation
";

    public const string IncludeListEmpty = @"
SELECT [object_id]
     , [index_id]
     , [partition_id]
     , [partition_number]
     , [rows]
     , [data_compression]
INTO #Partitions
FROM sys.partitions WITH(NOLOCK)
WHERE [object_id] > 255
    AND [rows] > 0
    AND [object_id] NOT IN (SELECT * FROM #ExcludeList)";

    public const string IncludeList = @"
IF OBJECT_ID('tempdb.dbo.#IncludeList') IS NOT NULL
    DROP TABLE #IncludeList

CREATE TABLE #IncludeList (ID INT PRIMARY KEY)

INSERT INTO #IncludeList
SELECT [object_id]
FROM sys.objects WITH(NOLOCK)
WHERE [type] IN ('V', 'U')
    {0}{1}

SELECT [object_id]
     , [index_id]
     , [partition_id]
     , [partition_number]
     , [rows]
     , [data_compression]
INTO #Partitions
FROM sys.partitions WITH(NOLOCK)
WHERE [object_id] > 255
    AND [rows] > 0
    AND [object_id] NOT IN (SELECT * FROM #ExcludeList)
    AND [object_id] IN (SELECT * FROM #IncludeList)";

    public const string IndexStats = @"
    SELECT ObjectID      = [object_id]
         , IndexID       = [index_id]
         , TotalWrites   = NULLIF([user_updates], 0)
         , TotalReads    = NULLIF([user_seeks] + [user_scans] + [user_lookups], 0)
         , TotalSeeks    = NULLIF([user_seeks], 0)
         , TotalScans    = NULLIF([user_scans], 0)
         , TotalLookups  = NULLIF([user_lookups], 0)
         , LastUsage     = (
                                SELECT MAX(dt)
                                FROM (
                                    VALUES ([last_user_seek])
                                         , ([last_user_scan])
                                         , ([last_user_lookup])
                                         , ([last_user_update])
                                ) t(dt)
                           )
    FROM sys.dm_db_index_usage_stats WITH(NOLOCK)
    WHERE [database_id] = @DBID
";

    // Azure -> master -> sys.dm_db_index_usage_stats -> VIEW DATABASE STATE permission denied in database 'master'
    public const string IndexStatsAzureMaster = @"
    SELECT ObjectID     = NULL
         , IndexID      = NULL
         , TotalWrites  = NULL
         , TotalReads   = NULL
         , TotalSeeks   = NULL
         , TotalScans   = NULL
         , TotalLookups = NULL
         , LastUsage    = NULL
";

    public const string Lob2008 = @"
INSERT INTO #Lob (ObjectID, IndexID, IsLobLegacy, IsLob)
SELECT c.ObjectID
     , IndexID     = ISNULL(i.IndexID, 1)
     , IsLobLegacy = MAX(CASE WHEN c.SystemTypeID IN (34, 35, 99) THEN 1 END)
     , IsLob       = MAX(CASE WHEN c.MaxLen = -1 THEN 1 END)
FROM #Columns c
LEFT JOIN #IndexColumns i ON c.ObjectID = i.ObjectID AND c.ColumnID = i.ColumnID
WHERE c.SystemTypeID IN (34, 35, 99)
    OR c.MaxLen = -1
GROUP BY c.ObjectID
       , i.IndexID";

    public const string Lob2012Plus = @"
INSERT INTO #Lob (ObjectID, IndexID, IsLobLegacy, IsLob)
SELECT c.ObjectID
     , IndexID     = ISNULL(i.IndexID, 1)
     , IsLobLegacy = MAX(CASE WHEN c.SystemTypeID IN (34, 35, 99) THEN 1 END)
     , IsLob       = 0
FROM #Columns c
LEFT JOIN #IndexColumns i ON c.ObjectID = i.ObjectID AND c.ColumnID = i.ColumnID
WHERE c.SystemTypeID IN (34, 35, 99)
GROUP BY c.ObjectID
       , i.IndexID";

    public const string Index2008 = @"
DECLARE @ObjectID        INT
      , @IndexID         INT
      , @PartitionNumber INT

DECLARE cur CURSOR FAST_FORWARD READ_ONLY LOCAL FOR
    SELECT ObjectID
         , IndexID
         , PartitionNumber
    FROM #Indexes
    WHERE PagesCount <= @PreDescribeSize

OPEN cur

FETCH NEXT FROM cur INTO @ObjectID, @IndexID, @PartitionNumber

WHILE @@FETCH_STATUS = 0 BEGIN

    INSERT INTO #Fragmentation (ObjectID, IndexID, PartitionNumber, Fragmentation)
    SELECT @ObjectID
         , @IndexID
         , @PartitionNumber
         , [avg_fragmentation_in_percent]
    FROM sys.dm_db_index_physical_stats(@DBID, @ObjectID, @IndexID, @PartitionNumber, 'LIMITED') r
    WHERE [index_level] = 0
        AND [alloc_unit_type_desc] = 'IN_ROW_DATA'

    FETCH NEXT FROM cur INTO @ObjectID, @IndexID, @PartitionNumber

END

CLOSE cur
DEALLOCATE cur";

    public const string Index2012Plus = @"
INSERT INTO #Fragmentation (ObjectID, IndexID, PartitionNumber, Fragmentation)
SELECT i.ObjectID
     , i.IndexID
     , i.PartitionNumber
     , r.[avg_fragmentation_in_percent]
FROM #Indexes i
CROSS APPLY sys.dm_db_index_physical_stats(@DBID, i.ObjectID, i.IndexID, i.PartitionNumber, 'LIMITED') r
WHERE i.PagesCount <= @PreDescribeSize
    AND r.[index_level] = 0
    AND r.[alloc_unit_type_desc] = 'IN_ROW_DATA'
    AND i.IndexType IN (0, 1, 2)";

    public const string ColumnstoreIndexFragmentation = @"
SELECT *
FROM (
    SELECT IndexID          = [index_id]
         , PartitionNumber  = [partition_number]
         , PagesCount       = SUM([size_in_bytes]) / 8192
         , UnusedPagesCount = ISNULL(SUM(CASE WHEN [state] = 1 THEN [size_in_bytes] END), 0) / 8192
         , Fragmentation    = CAST(ISNULL(SUM(CASE WHEN [state] = 1 THEN [size_in_bytes] END), 0) * 100. / SUM([size_in_bytes]) AS FLOAT)
    FROM sys.fn_column_store_row_groups(@ObjectID)
    GROUP BY [index_id]
           , [partition_number]
) t
WHERE Fragmentation >= @Fragmentation
    AND PagesCount BETWEEN @MinIndexSize AND @MaxIndexSize
";

    // https://dba.stackexchange.com/questions/44908/what-is-the-actual-behavior-of-compatibility-level-80/
    public const string IndexFragmentation = @"
DECLARE @DBID INT = DB_ID()

SELECT [avg_fragmentation_in_percent]
FROM sys.dm_db_index_physical_stats(@DBID, @ObjectID, @IndexID, @PartitionNumber, 'LIMITED')
WHERE [index_level] = 0
    AND [alloc_unit_type_desc] = 'IN_ROW_DATA'
";
    
    public const string ServerInfo = @"
SELECT ProductLevel  = SERVERPROPERTY('ProductLevel')
     , Edition       = SERVERPROPERTY('Edition')
     , ServerVersion = SERVERPROPERTY('ProductVersion')
     , IsSysAdmin    = CAST(IS_SRVROLEMEMBER('sysadmin') AS BIT)
";

    public const string DatabaseFullList = @"
SET NOCOUNT ON

IF OBJECT_ID('tempdb.dbo.#UsedSpace') IS NOT NULL
    DROP TABLE #UsedSpace

CREATE TABLE #UsedSpace (
      DatabaseID   INT
    , DataUsedSize BIGINT
    , LogUsedSize  BIGINT
)

DECLARE @SQL NVARCHAR(MAX) = (
    SELECT '
    USE [' + REPLACE(REPLACE([name], ']', ']]'), '[', '[[') + ']
    INSERT INTO #UsedSpace
    SELECT DB_ID()
         , SUM(CASE WHEN [type] = 0 THEN [size] ELSE 0 END)
         , SUM(CASE WHEN [type] = 1 THEN [size] ELSE 0 END)
    FROM (
        SELECT [type], [size] = SUM(CAST(FILEPROPERTY([name], ''SpaceUsed'') AS BIGINT))
        FROM sys.database_files WITH(NOLOCK)
        GROUP BY [type]
    ) t;'
    FROM sys.databases WITH(NOLOCK)
    WHERE [state] = 0
        AND [database_id] != 2
        AND ISNULL(HAS_DBACCESS([name]), 1) = 1
    FOR XML PATH(''), TYPE).value('(./text())[1]', 'NVARCHAR(MAX)')

EXEC sys.sp_executesql @SQL

SELECT DatabaseName = t.[name]
     , d.DataSize
     , u.DataUsedSize
     , d.LogSize
     , u.LogUsedSize
     , RecoveryModel = t.recovery_model_desc
     , LogReuseWait  = t.log_reuse_wait_desc
FROM sys.databases t WITH(NOLOCK)
LEFT JOIN #UsedSpace u ON u.DatabaseID = t.[database_id]
LEFT JOIN (
    SELECT [database_id]
         , DataSize = SUM(CASE WHEN [type] = 0 THEN CAST(size AS BIGINT) END)
         , LogSize  = SUM(CASE WHEN [type] = 1 THEN CAST(size AS BIGINT) END)
    FROM sys.master_files WITH(NOLOCK)
    GROUP BY [database_id]
) d ON d.[database_id] = t.[database_id]
WHERE t.[state] = 0
    AND t.[database_id] != 2
    AND ISNULL(HAS_DBACCESS(t.[name]), 1) = 1
";

    public const string DatabaseList = @"
SELECT DatabaseName = t.[name]
     , d.DataSize
     , DataUsedSize  = CAST(NULL AS BIGINT)
     , d.LogSize
     , LogUsedSize   = CAST(NULL AS BIGINT)
     , RecoveryModel = t.recovery_model_desc
     , LogReuseWait  = t.log_reuse_wait_desc
FROM sys.databases t WITH(NOLOCK)
LEFT JOIN (
    SELECT [database_id]
         , DataSize = SUM(CASE WHEN [type] = 0 THEN CAST(size AS BIGINT) END)
         , LogSize  = SUM(CASE WHEN [type] = 1 THEN CAST(size AS BIGINT) END)
    FROM sys.master_files WITH(NOLOCK)
    GROUP BY [database_id]
) d ON d.[database_id] = t.[database_id]
WHERE t.[state] = 0
    AND t.[database_id] != 2
    AND ISNULL(HAS_DBACCESS(t.[name]), 1) = 1
";

    public const string DatabaseListAzure = @"
SELECT DatabaseName  = [name]
     , DataSize      = CAST(NULL AS BIGINT)
     , DataUsedSize  = CAST(NULL AS BIGINT)
     , LogSize       = CAST(NULL AS BIGINT)
     , LogUsedSize   = CAST(NULL AS BIGINT)
     , RecoveryModel = recovery_model_desc
     , LogReuseWait  = log_reuse_wait_desc
FROM sys.databases WITH(NOLOCK)
WHERE [state] = 0
    AND ISNULL(HAS_DBACCESS([name]), 1) = 1
";

    public const string AfterFixIndex = @"
DECLARE @UnusedPagesCount  BIGINT
      , @ReservedPageCount BIGINT
      , @RowsCount         BIGINT
      , @Compression       TINYINT
      , @DBID              INT
      , @DBNAME            SYSNAME

SET @DBNAME = DB_NAME()
SELECT @DBID = [database_id]
FROM sys.databases WITH(NOLOCK)
WHERE [name] = @DBNAME

SELECT TOP(1) @UnusedPagesCount   = [used_page_count]
            , @ReservedPageCount  = [reserved_page_count]
            , @RowsCount          = [row_count]
FROM sys.dm_db_partition_stats WITH(NOLOCK)
WHERE [object_id] = {0}
    AND [index_id] = {1}
    AND [partition_number] = {2}

SELECT @Compression = [data_compression]
FROM sys.partitions WITH(NOLOCK)
WHERE [object_id] = {0}
    AND [index_id] = {1}
    AND [partition_number] = {2}

SELECT Fragmentation    = [avg_fragmentation_in_percent]
     , PagesCount       = ISNULL(@ReservedPageCount, 0)
     , UnusedPagesCount = ISNULL(CASE WHEN ABS(@ReservedPageCount - @UnusedPagesCount) > 32 THEN @ReservedPageCount - @UnusedPagesCount END, 0)
     , RowsCount        = ISNULL(@RowsCount, 0)
     , IndexStats       = STATS_DATE({0}, {1})
     , DataCompression  = @Compression
FROM sys.dm_db_index_physical_stats(@DBID, {0}, {1}, {2}, 'LIMITED')
WHERE [index_level] = 0
    AND [alloc_unit_type_desc] = 'IN_ROW_DATA'
";

    public const string AfterFixColumnstoreIndex = @"
DECLARE @PagesCount      BIGINT
      , @UnusedPageCount BIGINT
      , @Fragmentation   FLOAT
      , @Compression     TINYINT

SELECT @PagesCount      = SUM([size_in_bytes]) / 8192
     , @UnusedPageCount = ISNULL(SUM(CASE WHEN [state] = 1 THEN [size_in_bytes] END), 0) / 8192
     , @Fragmentation   = ISNULL(SUM(CASE WHEN [state] = 1 THEN [size_in_bytes] END), 0) * 100. / SUM([size_in_bytes])
FROM sys.fn_column_store_row_groups({0})
WHERE [index_id] = {1}
    AND [partition_number] = {2}

SELECT Fragmentation    = @Fragmentation
     , PagesCount       = ISNULL(@PagesCount, 0)
     , UnusedPagesCount = ISNULL(@UnusedPageCount, 0)
     , RowsCount        = ISNULL([rows], 0)
     , IndexStats       = NULL
     , DataCompression  = [data_compression]
FROM sys.partitions WITH(NOLOCK)
WHERE [object_id] = {0}
    AND [index_id] = {1}
    AND [partition_number] = {2}
";
  }

}