if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SubCategory]') and objectproperty(id, N'isusertable') = 1)			
drop table [dbo].[SubCategory]			
go			
			
create table [dbo].[SubCategory] (
	[entryid] [int] identity(1,1) not null 
	,[entrycode] [nvarchar](256) not null default ('')
	,[entryname] [nvarchar](256) not null default ('')
	,[categoryid] [int]  NULL  	
	,[isactive] [bit]  NULL  
	,[createdat] [datetime] not null default (getdate()) 		
	,[createdby] [int] null 		
	,[updatedat] [datetime] not null default (getdate()) 		
	,[updatedby] [int] null		
) on [primary]			
go			
			
alter table [SubCategory] add			
	constraint [PK_SubCategory] primary key  clustered		
	(		
		[entryid]
			
			
	)  on [primary]		
go			