ALTER TABLE dbo.AccountExpense
ADD Reimburse bit NULL
GO

ALTER VIEW vueAccountExpense AS
SELECT        dbo.AccountExpense.AccountExpenseId, dbo.AccountExpense.AccountExpenseName, dbo.AccountExpense.AccountExpenseTypeId, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountId, 
                         dbo.AccountExpense.CreatedOn, dbo.AccountExpense.CreatedByEmployeeId, dbo.AccountExpense.ModifiedOn, dbo.AccountExpense.ModifiedByEmployeeId, dbo.AccountExpense.IsBillable, 
                         dbo.AccountExpense.IsDisabled, dbo.AccountExpense.Reimburse
FROM            dbo.AccountExpense LEFT OUTER JOIN
                         dbo.AccountExpenseType ON dbo.AccountExpense.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId
GO