
CREATE VIEW dbo.vueExpenseApprovalSequence
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountExpenseEntry.AccountExpenseEntryId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, dbo.AccountExpenseEntry.Amount, 
                      dbo.AccountExpense.AccountExpenseName, dbo.AccountExpense.IsBillable, 
                      dbo.AccountExpenseEntry.AccountEmployeeId AS ExpenseEntryAccountEmployeeId, dbo.AccountExpenseEntry.Description, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountEmployee.EMailAddress, dbo.AccountExpenseEntry.Submitted, 
                      dbo.AccountEmployee.EmployeeManagerId, dbo.SystemCurrency.CurrencyCode, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId, ISNULL(dbo.AccountExpenseEntry.ExchangeRate, 0) AS ExchangeRate, 
                      dbo.AccountEmployeeExpenseSheet.Description AS MasterDescription, dbo.AccountEmployeeExpenseSheet.ExpenseSheetDate, 
                      dbo.AccountEmployeeExpenseSheet.SubmittedDate
FROM         dbo.AccountExpenseEntryApproval RIGHT OUTER JOIN
                      dbo.AccountEmployeeExpenseSheet INNER JOIN
                      dbo.AccountCurrency INNER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId INNER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId INNER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountExpenseEntry.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountExpenseEntry.AccountProjectId ON 
                      dbo.AccountCurrency.AccountCurrencyId = dbo.AccountExpenseEntry.AccountCurrencyId ON 
                      dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId = dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId ON 
                      dbo.AccountExpenseEntryApproval.AccountExpenseEntryId = dbo.AccountExpenseEntry.AccountExpenseEntryId AND 
                      dbo.AccountExpenseEntryApproval.ApprovalPathSequence = dbo.AccountApprovalPath.ApprovalPathSequence AND 
                      dbo.AccountExpenseEntryApproval.IsRejected <> 1 LEFT OUTER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId