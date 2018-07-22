if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BillDetail]') and objectproperty(id, N'isusertable') = 1)			
drop table [dbo].[BillDetail]			
go			
			
create table [dbo].[BillDetail] (
	[entryid] [int] identity(1,1) not null 
	,[entrycode] [nvarchar](256) not null default ('')
	,[entryname] [nvarchar](256) not null default ('')
	,[billid] [int]  NULL  
 ,[productid] [int]  NULL  
 ,[productname] [nvarchar] (256)  NULL  
 ,[quantity] [int]  NULL  
 ,[price] [float]  NULL  
 ,[discount] [float]  NULL  
 ,[priceamount] [float]  NULL  	
	,[isactive] [bit]  NULL  
	,[createdat] [datetime] not null default (getdate()) 		
	,[createdby] [int] null 		
	,[updatedat] [datetime] not null default (getdate()) 		
	,[updatedby] [int] null		
	,[timestamp] [timestamp] not null		
) on [primary]			
go			
			
alter table [BillDetail] add			
	constraint [PK_BillDetail] primary key  clustered		
	(		
		[entryid]
			
			
	)  on [primary]		
go			