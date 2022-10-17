
CREATE VIEW dbo.vueAccountExpenseEntryApprovedForApproverEmployeeId
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountExpenseEntry.AccountExpenseEntryId, dbo.AccountExpenseEntryApproval.ExpenseApprovalId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, dbo.AccountExpenseEntry.Amount, 
                      dbo.AccountExpenseEntry.AccountEmployeeId AS ExpenseEntryAccountEmployeeId, dbo.AccountExpenseEntry.Description, dbo.AccountExpenseEntry.AccountId, 
                      dbo.AccountEmployee.EMailAddress, dbo.AccountExpenseEntry.Submitted, dbo.AccountEmployee.EmployeeManagerId, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId, ISNULL(dbo.AccountExpenseEntry.ExchangeRate, 0) AS ExchangeRate, 
                      dbo.AccountEmployeeExpenseSheet.Description AS MasterDescription, dbo.AccountEmployeeExpenseSheet.ExpenseSheetDate, 
                      dbo.AccountEmployeeExpenseSheet.SubmittedDate, 
                      CASE WHEN dbo.AccountApprovalPath.systemapprovertypeid = 1 THEN dbo.AccountProject.LeaderEmployeeId WHEN dbo.AccountApprovalPath.systemapprovertypeid
                       = 2 THEN dbo.AccountProject.ProjectManagerEmployeeId WHEN dbo.AccountApprovalPath.systemapprovertypeid = 3 THEN dbo.AccountApprovalPath.AccountEmployeeId
                       WHEN dbo.AccountApprovalPath.systemapprovertypeid = 4 THEN dbo.AccountApprovalPath.AccountExternalUserId WHEN dbo.AccountApprovalPath.systemapprovertypeid
                       = 5 THEN dbo.AccountEmployee.EmployeeManagerId END AS ApproverEmployeeId
FROM         dbo.AccountExpenseEntryApproval RIGHT OUTER JOIN
                      dbo.AccountEmployeeExpenseSheet INNER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId INNER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountExpenseEntry.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountExpenseEntry.AccountProjectId ON 
                      dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId = dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId ON 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId = dbo.AccountApprovalPath.AccountApprovalPathId AND 
                      dbo.AccountExpenseEntryApproval.AccountExpenseEntryId = dbo.AccountExpenseEntry.AccountExpenseEntryId AND 
                      dbo.AccountExpenseEntryApproval.ApprovalPathSequence = dbo.AccountApprovalPath.ApprovalPathSequence