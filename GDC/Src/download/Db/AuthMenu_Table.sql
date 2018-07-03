if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AuthMenu]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)			
drop table [dbo].[AuthMenu]			
GO			
			
CREATE TABLE [dbo].[AuthMenu] (
	[Id] [int] IDENTITY(1,1) NOT NULL 
	,[Code] [nvarchar](256) NOT NULL DEFAULT ('')
	,[Name] [nvarchar](256) NOT NULL DEFAULT ('')
	,[NameVi] [nvarchar] (256)  NULL  
 ,[MenuId] [nvarchar] (256)  NULL  
 ,[ParentMenuId] [nvarchar] (256)  NULL  
 ,[MenuIndex] [int]  NULL  
 ,[ControllerName] [nvarchar] (256)  NULL  
 ,[Icon] [nvarchar] (256)  NULL  
 ,[Active] [bit]  NULL  	
	,[CreatedAt] [datetime] NOT null DEFAULT (GETDATE()) 		
	,[CreatedBy] [int] null 		
	,[UpdatedAt] [datetime] NOT null DEFAULT (GETDATE()) 		
	,[UpdatedBy] [int] null		
	,[TimeStamp] [timestamp] NOT NULL		
) ON [PRIMARY]			
GO			
			
ALTER TABLE [dbo].[AuthMenu] ADD			
	CONSTRAINT [PK_AuthMenu] PRIMARY KEY  CLUSTERED		
	(		
		[Id]
			
			
	)  ON [PRIMARY]		
GO			