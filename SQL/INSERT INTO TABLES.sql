USE [SW_COUNTYPERMITS]
GO

INSERT INTO [dbo].[SW_PERMITS]
           ([USER_ID]
           ,[TYPE_ID]
           ,[COUNTY_ID]
           ,[APPLICATION_DATE])
     VALUES
           (<USER_ID, int,>
           ,<TYPE_ID, int,>
           ,<COUNTY_ID, int,>
           ,<APPLICATION_DATE, datetime,>)
GO


INSERT INTO [dbo].[SW_SUBMITTERS]
           ([NAME]
           ,[LASTNAME]
           ,[ADDRESS])
     VALUES
           (<NAME, varchar(50),>
           ,<LASTNAME, varchar(50),>
           ,<ADDRESS, varchar(200),>)
GO


INSERT INTO [dbo].[SW_PERMIT_TYPE]
           ([TYPE]
           ,[DESCRIPTION])
     VALUES
           (<TYPE, varchar(50),>
           ,<DESCRIPTION, varchar(250),>)
GO

