
CREATE VIEW dbo.vueAccountExpenseEntryApprovalForReport
AS
SELECT     dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountExpenseEntryApproval.AccountExpenseEntryId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalTypeId, dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, 
                      dbo.AccountExpenseEntryApproval.ApprovedByEmployeeId, dbo.AccountExpenseEntryApproval.ApprovedOn, 
                      dbo.AccountExpenseEntryApproval.Comments, dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, 
                      CASE WHEN AccountEmployee.IsDisabled = 1 THEN AccountEmployee.FirstName + ' ' + AccountEmployee.LastName + ' ' + '(Disabled)' ELSE AccountEmployee.FirstName
                       + ' ' + AccountEmployee.LastName END AS EmployeeName, dbo.AccountExpenseEntry.AccountId, dbo.AccountProject.AccountProjectId, 
                      dbo.AccountProject.ProjectName, dbo.AccountProject.AccountClientId, dbo.AccountParty.PartyName, 
                      AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS ApprovalEmployeeName, dbo.AccountExpenseEntry.AccountEmployeeId, 
                      ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                      + dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeNameWithCode, dbo.AccountEmployee.IsDisabled
FROM         dbo.AccountExpenseEntryApproval INNER JOIN
                      dbo.AccountExpenseEntry ON 
                      dbo.AccountExpenseEntryApproval.AccountExpenseEntryId = dbo.AccountExpenseEntry.AccountExpenseEntryId INNER JOIN
                      dbo.AccountProject ON dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      dbo.AccountExpenseEntryApproval.ApprovedByEmployeeId = AccountEmployee_1.AccountEmployeeId