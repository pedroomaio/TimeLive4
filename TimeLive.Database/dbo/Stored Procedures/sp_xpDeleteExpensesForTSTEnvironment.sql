-- =============================================
-- Author:		<Rui Maia>
-- Create date: <2016-10-12>
-- Description:	<Deletes expense values for test environments>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpDeleteExpensesForTSTEnvironment]
AS
BEGIN
SET NOCOUNT ON;


-- apagar todos os mapas anteriores a set 2016
delete from  accountExpenseEntry where accountemployeeexpenseSheetId in (
select accountemployeeexpenseSheetId from accountEmployeeExpenseSheet where expenseSheetdate < '20160901'
)

-- apagar todas as entradas de kms dos mapas
delete from accountExpenseEntry where accountExpenseid in (
	select accountexpenseid from accountexpense where accountExpenseTypeid=7320 /*exp.9x*/ or accountExpenseTypeid=7317 /*exp.90*/
)

-- apagar todos os mapas que ficaram com 0 entradas
delete from accountEmployeeExpenseSheet where accountEmployeeExpenseSheetId in (
select accountEmployeeExpenseSheetId from accountEmployeeExpenseSheet aees where not exists (
	select 1 from accountExpenseEntry aee where aee.accountemployeeexpenseSheetId = aees.accountemployeeexpenseSheetId
)
)
END