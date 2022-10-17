
CREATE VIEW dbo.vueAccountExpenseEntryApprovalSummary
AS                       
SELECT     dbo.AccountProject.AccountProjectId, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, CASE WHEN Isnull(dbo.AccountExpenseEntry.ExchangeRate, 0) 
                      <> 0 THEN ((dbo.AccountExpenseEntry.Amount / dbo.AccountExpenseEntry.ExchangeRate) * dbo.vueAccountCurrency.ExchangeRate) 
                      ELSE 0 END AS Amount, dbo.AccountExpenseEntry.AccountEmployeeId AS ExpenseEntryAccountEmployeeId, 
                      dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId, dbo.AccountEmployeeExpenseSheet.Description, 
                      dbo.AccountEmployeeExpenseSheet.ExpenseSheetDate, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountApprovalPath.AccountEmployeeId, dbo.AccountExpenseEntryApproval.IsRejected, 
                      dbo.AccountExpenseEntryApproval.IsApproved, dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountEmployee.EmployeeManagerId, 
                      dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.AccountId, dbo.AccountExpenseEntry.AccountExpenseEntryId, 
                      dbo.vueAccountCurrency.CurrencyCode, dbo.AccountExpenseEntry.Approved, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountExpenseEntry.Submitted, dbo.AccountEmployeeExpenseSheet.SubmittedDate, dbo.AccountExpenseEntry.IsEmailSend
FROM         dbo.AccountApprovalPath INNER JOIN
                      dbo.AccountEmployeeExpenseSheet INNER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountExpenseEntry.AccountEmployeeId ON 
                      dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId = dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId INNER JOIN
                      dbo.AccountProject ON dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId ON 
                      dbo.AccountApprovalPath.AccountApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountPreferences ON dbo.AccountExpenseEntry.AccountId = dbo.AccountPreferences.AccountId INNER JOIN
                      dbo.vueAccountCurrency ON dbo.AccountPreferences.AccountBaseCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountApprovalPath.ApprovalPathSequence = dbo.AccountExpenseEntryApproval.ApprovalPathSequence AND 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId AND 
                      dbo.AccountExpenseEntryApproval.IsRejected <> 1