if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AuthMenu]') and objectproperty(id, N'isusertable') = 1)			
drop table [dbo].[AuthMenu]			
go			
			
create table [dbo].[AuthMenu] (
	[entryid] [int] identity(1,1) not null 
	,[entrycode] [nvarchar](256) not null default ('')
	,[entryname] [nvarchar](256) not null default ('')
	,[entrynamevi] [nvarchar] (256)  NULL  
 ,[areasname] [nvarchar] (256)  NULL  
 ,[menuid] [nvarchar] (256)  NULL  
 ,[parentmenuid] [nvarchar] (256)  NULL  
 ,[menuindex] [int]  NULL  
 ,[controllername] [nvarchar] (256)  NULL  
 ,[icon] [nvarchar] (256)  NULL  	
	,[isactive] [bit]  NULL  
	,[createdat] [datetime] not null default (getdate()) 		
	,[createdby] [int] null 		
	,[updatedat] [datetime] not null default (getdate()) 		
	,[updatedby] [int] null		
	,[timestamp] [timestamp] not null		
) on [primary]			
go			
			
alter table [AuthMenu] add			
	constraint [PK_AuthMenu] primary key  clustered		
	(		
		[entryid]
			
			
	)  on [primary]		
go			