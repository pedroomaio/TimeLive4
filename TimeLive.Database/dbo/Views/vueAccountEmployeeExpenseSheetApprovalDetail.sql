
CREATE VIEW dbo.vueAccountEmployeeExpenseSheetApprovalDetail
AS
SELECT     dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountProjectId, 
                      dbo.AccountProject.ProjectName, dbo.AccountApprovalType.ApprovalTypeName, dbo.SystemApproverType.SystemApproverType, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, 
                      AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS ApprovalEmployeeName, dbo.AccountExpenseEntry.AccountExpenseEntryId, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountExpenseEntryApproval.ApprovedOn, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, dbo.AccountEmployeeExpenseSheet.Approved, 
                      dbo.AccountEmployeeExpenseSheet.Rejected, dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId, 
                      dbo.AccountEmployeeExpenseSheet.Description, dbo.AccountExpenseEntry.AccountExpenseId, dbo.AccountEmployeeExpenseSheet.Submitted, 
                      dbo.AccountEmployeeExpenseSheet.SubmittedDate
FROM         dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountEmployeeExpenseSheet ON 
                      dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId = dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId LEFT OUTER JOIN
                      dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.SystemApproverType INNER JOIN
                      dbo.AccountApprovalPath INNER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId ON 
                      dbo.SystemApproverType.SystemApproverTypeId = dbo.AccountApprovalPath.SystemApproverTypeId ON 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      dbo.AccountExpenseEntryApproval.ApprovedByEmployeeId = AccountEmployee_1.AccountEmployeeId
WHERE     (dbo.AccountExpenseEntryApproval.ExpenseApprovalTypeId IS NOT NULL) OR
                      (dbo.AccountApprovalType.AccountApprovalTypeId IS NULL)