if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Product]') and objectproperty(id, N'isusertable') = 1)			
drop table [dbo].[Product]			
go			
			
create table [dbo].[Product] (
	[entryid] [int] identity(1,1) not null 
	,[entrycode] [nvarchar](256) not null default ('')
	,[entryname] [nvarchar](256) not null default ('')
	,[entrynamevi] [nvarchar] (256)  NULL  
 ,[subcategoryid] [int]  NULL  
 ,[categoryid] [int]  NULL  
 ,[defautlimg] [nvarchar] (256)  NULL  
 ,[listimgs] [nvarchar] (max)  NULL  
 ,[price] [float]  NULL  
 ,[discount] [float]  NULL  
 ,[priceamount] [float]  NULL  
 ,[brand] [nvarchar] (256)  NULL  
 ,[origin] [nvarchar] (256)  NULL  
 ,[contents] [nvarchar] (256)  NULL  
 ,[unit] [nvarchar] (256)  NULL  
 ,[unitquantity] [float]  NULL  
 ,[viewcount] [int]  NULL  
 ,[sellcount] [int]  NULL  
 ,[comments] [nvarchar] (max)  NULL  	
	,[isactive] [bit]  NULL  
	,[createdat] [datetime] not null default (getdate()) 		
	,[createdby] [int] null 		
	,[updatedat] [datetime] not null default (getdate()) 		
	,[updatedby] [int] null		
) on [primary]			
go			
			
alter table [Product] add			
	constraint [PK_Product] primary key  clustered		
	(		
		[entryid]
			
			
	)  on [primary]		
go			