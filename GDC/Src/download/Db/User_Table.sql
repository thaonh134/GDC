if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[User]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)			
drop table [dbo].[User]			
GO			
			
CREATE TABLE [dbo].[User] (
	[Id] [int] IDENTITY(1,1) NOT NULL 
	,[Code] [nvarchar](256) NOT NULL DEFAULT ('')
	,[Name] [nvarchar](256) NOT NULL DEFAULT ('')
	,[FullName] [nvarchar] (256)  NULL  
 ,[Password] [varchar] (256)  NULL  
 ,[AvatarPath] [nvarchar] (500)  NULL  
 ,[Phone] [nvarchar] (256)  NULL  
 ,[Email] [nvarchar] (256)  NULL  
 ,[BirthDay] [date]  NULL  
 ,[RoleId] [int]  NULL  
 ,[Active] [bit]  NULL  
 ,[LoginProvider] [nvarchar] (256)  NULL  
 ,[LastLogin] [date]  NULL  	
	,[CreatedAt] [datetime] NOT null DEFAULT (GETDATE()) 		
	,[CreatedBy] [int] null 		
	,[UpdatedAt] [datetime] NOT null DEFAULT (GETDATE()) 		
	,[UpdatedBy] [int] null		
	,[TimeStamp] [timestamp] NOT NULL		
) ON [PRIMARY]			
GO			
			
ALTER TABLE [dbo].[User] ADD			
	CONSTRAINT [PK_User] PRIMARY KEY  CLUSTERED		
	(		
		[Id]
			
			
	)  ON [PRIMARY]		
GO			