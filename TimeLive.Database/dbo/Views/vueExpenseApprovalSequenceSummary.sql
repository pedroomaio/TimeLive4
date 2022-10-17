
CREATE VIEW dbo.vueExpenseApprovalSequenceSummary
AS
SELECT     dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpenseEntry.Amount, 
                      dbo.AccountExpenseEntry.AccountEmployeeId AS ExpenseEntryAccountEmployeeId, dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId, 
                      dbo.AccountEmployeeExpenseSheet.Description, dbo.AccountEmployeeExpenseSheet.ExpenseSheetDate, dbo.AccountProject.AccountProjectId, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountApprovalPath.AccountApprovalPathId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.ApprovalPathSequence, 
                      dbo.AccountApprovalPath.AccountEmployeeId, dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountEmployee.EmployeeManagerId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployee.AccountId, dbo.AccountExpenseEntry.Rejected, dbo.AccountExpenseEntry.Submitted, dbo.AccountExpenseEntry.Approved
FROM         dbo.AccountExpenseEntryApproval RIGHT OUTER JOIN
                      dbo.AccountApprovalPath INNER JOIN
                      dbo.AccountProject ON dbo.AccountApprovalPath.AccountApprovalTypeId = dbo.AccountProject.ExpenseApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployeeExpenseSheet RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountExpenseEntry.AccountEmployeeId ON 
                      dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId = dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountExpenseEntry.AccountProjectId ON 
                      dbo.AccountExpenseEntryApproval.ApprovalPathSequence = dbo.AccountApprovalPath.ApprovalPathSequence AND 
                      dbo.AccountExpenseEntryApproval.AccountExpenseEntryId = dbo.AccountExpenseEntry.AccountExpenseEntryId AND 
                      dbo.AccountExpenseEntryApproval.IsRejected <> 1