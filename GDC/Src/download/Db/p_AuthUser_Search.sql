------------------------------------
-- created by: autogen
-- desc: search page
-- test string: p_AuthUser_Search
------------------------------------

IF OBJECT_ID(N'[dbo].[p_AuthUser_Search]') IS NOT NULL
	DROP PROCEDURE [dbo].[p_AuthUser_Search]
GO

CREATE PROCEDURE [p_AuthUser_Search]	
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
    ,[fullname]
 ,[password]
 ,[visiblepassword]
 ,[avatarpath]
 ,[phone]
 ,[email]
 ,[address]
 ,[birthday]
 ,[comments]
 ,[roleid]
 ,[loginprovider]
 ,[logintype]
 ,[lastlogin]	
    ,a.isactive  
    ,a.createdat  
    INTO   #Result  
    FROM   [AuthUser] a  
    WHERE   a.IsActive = CASE WHEN @Status = '' THEN a.IsActive ELSE @Status END  

    -- p_AuthUser_Search

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

    SELECT @Sort = CASE WHEN @Sort <> '' THEN @Sort ELSE 'ORDER BY entryid 	 DESC' END
    SELECT @Sql = REPLACE(@Sql, '{WhereCondition}', @WhereCondition)
    SELECT @Sql = REPLACE(@Sql, '{Sort}', @Sort)
    SELECT @Sql = REPLACE(@Sql, '{Page}', @Page)
    SELECT @Sql = REPLACE(@Sql, '{PageSize}', @PageSize)

    EXEC (@Sql)
GO