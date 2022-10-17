-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpAddEmployeeToProjectTeam]
	@ipProjectId int,
	@ipAccountEmployeeId int,
	@opErrorCode int output,
	@opErrorMesssage nvarchar(255) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	Declare @CONST_ACCOOUNTID int = 354 -- constant Account Id

	BEGIN TRY 
		BEGIN TRANSACTION
		-- Insert into project employee table
		INSERT INTO [dbo].[AccountProjectEmployee]
			([AccountId], 
			[AccountProjectId], 
			[AccountEmployeeId], 
			[TaskCompletedPercentage], 
			[TaskCompleted], 
			[AccountRoleId], 
			[AccountBillingRateId], 
			[AccountProjectEmployeeTemplateId])
		VALUES
			(@CONST_ACCOOUNTID,
			@ipProjectId,
			@ipAccountEmployeeId,
			NULL,
			NULL,
			0,
			NULL,
			NULL)
			
		COMMIT TRANSACTION
	    SELECT @opErrorCode=0 , @opErrorMesssage='User successfully added to project';
		
   	END TRY  
	BEGIN CATCH  
		ROLLBACK
		SELECT @opErrorCode=ERROR_NUMBER(), @opErrorMesssage=ERROR_MESSAGE() ;
	END CATCH;
END;