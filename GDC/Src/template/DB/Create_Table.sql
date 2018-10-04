if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[@=tablename=@]') and objectproperty(id, N'isusertable') = 1)			
drop table [dbo].[@=tablename=@]			
go			
			
create table [dbo].[@=tablename=@] (
	[entryid] [int] identity(1,1) not null 
	,[entrycode] [nvarchar](256) not null default ('')
	,[entryname] [nvarchar](256) not null default ('')
	,@=fields=@	
	,[isactive] [bit]  NULL  
	,[createdat] [datetime] not null default (getdate()) 		
	,[createdby] [int] null 		
	,[updatedat] [datetime] not null default (getdate()) 		
	,[updatedby] [int] null		
) on [primary]			
go			
			
alter table [@=tablename=@] add			
	constraint [PK_@=tablename=@] primary key  clustered		
	(		
		[entryid]
		@=pkeys=@	
			
	)  on [primary]		
go			