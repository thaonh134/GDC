if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Delivery]') and objectproperty(id, N'isusertable') = 1)			
drop table [dbo].[Delivery]			
go			
			
create table [dbo].[Delivery] (
	[entryid] [int] identity(1,1) not null 
	,[entrycode] [nvarchar](256) not null default ('')
	,[entryname] [nvarchar](256) not null default ('')
	,[userid] [int]  NULL  
 ,[fullname] [nvarchar] (256)  NULL  
 ,[address] [nvarchar] (256)  NULL  
 ,[phone] [nvarchar] (256)  NULL  
 ,[email] [nvarchar] (256)  NULL  
 ,[comments] [nvarchar] (max)  NULL  	
	,[isactive] [bit]  NULL  
	,[createdat] [datetime] not null default (getdate()) 		
	,[createdby] [int] null 		
	,[updatedat] [datetime] not null default (getdate()) 		
	,[updatedby] [int] null		
	,[timestamp] [timestamp] not null		
) on [primary]			
go			
			
alter table [Delivery] add			
	constraint [PK_Delivery] primary key  clustered		
	(		
		[entryid]
			
			
	)  on [primary]		
go			