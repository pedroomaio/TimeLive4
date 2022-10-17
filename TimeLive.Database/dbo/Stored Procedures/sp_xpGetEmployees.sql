-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpGetEmployees]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT AccountEmployeeId, FirstName, LastName, EmployeeCode, Username from [dbo].[AccountEmployee] where IsDisabled = 0 and IsDeleted=0 order by AccountEmployeeId
END