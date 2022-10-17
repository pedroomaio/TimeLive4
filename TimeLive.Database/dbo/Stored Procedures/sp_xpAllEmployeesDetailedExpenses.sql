-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpAllEmployeesDetailedExpenses] 
	-- Add the parameters for the stored procedure here
	@startDate datetime, @endDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @employee_id int

	set rowcount 0
	select * into #tmpEmployeeTable from ACCOUNTEMPLOYEE

	set rowcount 1

	select @employee_id = ACCOUNTEMPLOYEEID from #tmpEmployeeTable

	while @@rowcount <> 0
	begin
		set rowcount 0
		 EXEC [dbo].[sp_xpDetailedExpenses] @startDate,@endDate, @employee_id
		delete #tmpEmployeeTable where ACCOUNTEMPLOYEEID = @employee_id
		set rowcount 1
		select @employee_id = ACCOUNTEMPLOYEEID from #tmpEmployeeTable
	end
	set rowcount 0
END