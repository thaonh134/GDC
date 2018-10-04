if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AuthUser]') and objectproperty(id, N'isusertable') = 1)			
drop table [dbo].[AuthUser]			
go			
			
create table [dbo].[AuthUser] (
	[entryid] [int] identity(1,1) not null 
	,[entrycode] [nvarchar](256) not null default ('')
	,[entryname] [nvarchar](256) not null default ('')
	,[fullname] [nvarchar] (256)  NULL  
 ,[password] [varchar] (256)  NULL  
 ,[visiblepassword] [varchar] (256)  NULL  
 ,[avatarpath] [nvarchar] (500)  NULL  
 ,[phone] [nvarchar] (256)  NULL  
 ,[email] [nvarchar] (256)  NULL  
 ,[address] [nvarchar] (256)  NULL  
 ,[birthday] [date]  NULL  
 ,[comments] [nvarchar] (max)  NULL  
 ,[roleid] [int]  NULL  
 ,[loginprovider] [nvarchar] (256)  NULL  
 ,[logintype] [int]  NULL  
 ,[lastlogin] [date]  NULL  	
	,[isactive] [bit]  NULL  
	,[createdat] [datetime] not null default (getdate()) 		
	,[createdby] [int] null 		
	,[updatedat] [datetime] not null default (getdate()) 		
	,[updatedby] [int] null		
) on [primary]			
go			
			
alter table [AuthUser] add			
	constraint [PK_AuthUser] primary key  clustered		
	(		
		[entryid]
			
			
	)  on [primary]		
go			