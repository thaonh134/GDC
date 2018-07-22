if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Category]') and objectproperty(id, N'isusertable') = 1)			
drop table [dbo].[Category]			
go			
			
create table [dbo].[Category] (
	[entryid] [int] identity(1,1) not null 
	,[entrycode] [nvarchar](256) not null default ('')
	,[entryname] [nvarchar](256) not null default ('')
	,[isactive] [bit]  NULL  
	,[createdat] [datetime] not null default (getdate()) 		
	,[createdby] [int] null 		
	,[updatedat] [datetime] not null default (getdate()) 		
	,[updatedby] [int] null		
	,[timestamp] [timestamp] not null		
) on [primary]			
go			
			
alter table [Category] add			
	constraint [PK_Category] primary key  clustered		
	(		
		[entryid]
			
			
	)  on [primary]		
go			