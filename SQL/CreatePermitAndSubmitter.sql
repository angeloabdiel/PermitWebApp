USE [SW_COUNTYPERMITS]
GO

/****** Object:  StoredProcedure [dbo].[CreatePermitAndSubmitter]    Script Date: 13/01/2026 06:50:10 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreatePermitAndSubmitter]
(
    @TYPE_ID        INT,
    @COUNTY_ID      INT,
    @NAME           VARCHAR(100),
    @LASTNAME       VARCHAR(100),
    @ADDRESS        VARCHAR(255)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -----------------------------------------
        -- 1. Insert into SW_SUBMITTERS
        -----------------------------------------
        INSERT INTO [SW_COUNTYPERMITS].[dbo].[SW_SUBMITTERS]
        (
            NAME,
            LASTNAME,
            ADDRESS
        )
        VALUES
        (
            @NAME,
            @LASTNAME,
            @ADDRESS
        );

        -- Get generated USER_ID
        DECLARE @USER_ID INT = SCOPE_IDENTITY();


        -----------------------------------------
        -- 2. Insert into SW_PERMITS
        -----------------------------------------
        INSERT INTO [SW_COUNTYPERMITS].[dbo].[SW_PERMITS]
        (
            USER_ID,
            TYPE_ID,
            COUNTY_ID,
            APPLICATION_DATE
        )
        VALUES
        (
            @USER_ID,
            @TYPE_ID,
            @COUNTY_ID,
            GETDATE()
        );

        -- Get the newly generated PERMIT_ID
        DECLARE @PERMIT_ID INT = SCOPE_IDENTITY();

        COMMIT TRANSACTION;

        -- Return permit id to caller
        SELECT @PERMIT_ID AS PERMIT_ID, @USER_ID AS USER_ID;

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        -- Rethrow error to caller
        THROW;
    END CATCH
END;

GO