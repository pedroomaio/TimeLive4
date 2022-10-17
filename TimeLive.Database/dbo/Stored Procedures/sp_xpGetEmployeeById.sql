
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpGetEmployeeById]
	@EmployeeId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT FirstName, LastName, EmployeeCode, Username from [dbo].[AccountEmployee] where AccountEmployeeId = @EmployeeId and IsDisabled = 0 order by AccountEmployeeId
END