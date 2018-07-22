if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Bill]') and objectproperty(id, N'isusertable') = 1)			
drop table [dbo].[Bill]			
go			
			
create table [dbo].[Bill] (
	[entryid] [int] identity(1,1) not null 
	,[entrycode] [nvarchar](256) not null default ('')
	,[entryname] [nvarchar](256) not null default ('')
	,[userid] [int]  NULL  
 ,[deliveryid] [int]  NULL  
 ,[quantity] [int]  NULL  
 ,[priceamount] [float]  NULL  	
	,[isactive] [bit]  NULL  
	,[createdat] [datetime] not null default (getdate()) 		
	,[createdby] [int] null 		
	,[updatedat] [datetime] not null default (getdate()) 		
	,[updatedby] [int] null		
	,[timestamp] [timestamp] not null		
) on [primary]			
go			
			
alter table [Bill] add			
	constraint [PK_Bill] primary key  clustered		
	(		
		[entryid]
			
			
	)  on [primary]		
go			