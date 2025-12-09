USE [SW_COUNTYPERMITS]
GO

INSERT INTO [dbo].[SW_PERMIT_TYPE]
           ([TYPE]
           ,[DESCRIPTION])
     VALUES
           ('Water Use Permit'
           ,'Permit for water use'),

		   ('Environmental Resource Permit'
		   ,'Permit for environmental resource');
GO


