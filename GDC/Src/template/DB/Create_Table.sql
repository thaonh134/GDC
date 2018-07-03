if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[@=TableName=@]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)			
drop table [dbo].[@=TableName=@]			
GO			
			
CREATE TABLE [dbo].[@=TableName=@] (
	[Id] [int] IDENTITY(1,1) NOT NULL 
	,[Code] [nvarchar](256) NOT NULL DEFAULT ('')
	,[Name] [nvarchar](256) NOT NULL DEFAULT ('')
	,@=Fields=@	
	,[CreatedAt] [datetime] NOT null DEFAULT (GETDATE()) 		
	,[CreatedBy] [int] null 		
	,[UpdatedAt] [datetime] NOT null DEFAULT (GETDATE()) 		
	,[UpdatedBy] [int] null		
	,[TimeStamp] [timestamp] NOT NULL		
) ON [PRIMARY]			
GO			
			
ALTER TABLE [dbo].[@=TableName=@] ADD			
	CONSTRAINT [PK_@=TableName=@] PRIMARY KEY  CLUSTERED		
	(		
		[Id]
		@=Pkeys=@	
			
	)  ON [PRIMARY]		
GO			