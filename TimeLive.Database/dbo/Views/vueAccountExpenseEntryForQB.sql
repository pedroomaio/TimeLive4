
CREATE VIEW dbo.vueAccountExpenseEntryForQB
AS
SELECT     dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntry.AccountId, dbo.AccountExpenseEntry.Description, dbo.AccountExpenseEntry.Amount, 
                      dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpense.AccountExpenseName, 
                      dbo.AccountParty.PartyName + ':' + dbo.AccountProject.ProjectName AS CustomerJob, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployee.AccountEmployeeId, 
                      dbo.AccountExpenseType.ExpenseType
FROM         dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId INNER JOIN
                      dbo.AccountProject ON dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId INNER JOIN
                      dbo.AccountExpenseType ON dbo.AccountExpense.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId