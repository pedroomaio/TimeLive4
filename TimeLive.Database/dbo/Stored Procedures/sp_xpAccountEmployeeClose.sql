-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpAccountEmployeeClose] 
	-- Add the parameters for the stored procedure here
	@AccountEmployeeCode nvarchar(100),
	@TerminationDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[AccountEmployee] set IsDisabled = 1, StatusId = 3157, TerminationDate = @TerminationDate where EmployeeCode = @AccountEmployeeCode

END