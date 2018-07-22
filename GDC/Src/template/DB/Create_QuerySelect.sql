------------------------------------
-- created by: autogen
-- desc: search page
-- test string: p_@=tablename=@_Search
------------------------------------

IF OBJECT_ID(N'[dbo].[p_@=tablename=@_Search]') IS NOT NULL
	DROP PROCEDURE [dbo].[p_@=tablename=@_Search]
GO

CREATE PROCEDURE [p_@=tablename=@_Search]	
	@page int = 1  
 ,@pageSize int = 100  
 ,@whereCondition nvarchar(max) = ''  
 ,@sort nvarchar(max) = ''  
 ,@status varchar(32) = '1'  
 ,@currUserId int  = 0  
 ,@language nvarchar(max) = 'vi'  
AS
    IF OBJECT_ID('tempdb..#Result') IS NOT NULL
	   DROP TABLE #Result

    SELECT  
	a.entryid  
    ,a.entrycode  
    ,a.entryname  
    ,@=fields=@	
    ,a.isactive  
    ,a.createdat  
    INTO   #Result  
    FROM   [@=tablename=@] a  
    WHERE   a.IsActive = CASE WHEN @Status = '' THEN a.IsActive ELSE @Status END  

    -- p_@=tablename=@_Search

    DECLARE @Sql nvarchar(max)

    SELECT @Sql = 
    N'
    ;WITH FullSet AS
    (
	   SELECT	 a.*
	   FROM	 #Result a
    )
	 
    ,FilteredSet AS
    (
	   SELECT	 *
	   FROM	 FullSet
	   WHERE	 1 = 1 {WhereCondition}
    )
	 
    ,CountSet AS
    (
	   SELECT	 COUNT(*) AS ''RowCount''
	   FROM	 FilteredSet
    )

    SELECT b.[RowCount], a.*
    FROM FilteredSet a, CountSet b
    {Sort}
    OFFSET (({Page} - 1) * {PageSize}) ROWS
    FETCH NEXT {PageSize} ROWS ONLY
    '

    SELECT @Sort = CASE WHEN @Sort <> '' THEN @Sort ELSE 'ORDER BY entryid @=pkeys=@	 DESC' END
    SELECT @Sql = REPLACE(@Sql, '{WhereCondition}', @WhereCondition)
    SELECT @Sql = REPLACE(@Sql, '{Sort}', @Sort)
    SELECT @Sql = REPLACE(@Sql, '{Page}', @Page)
    SELECT @Sql = REPLACE(@Sql, '{PageSize}', @PageSize)

    EXEC (@Sql)
GO