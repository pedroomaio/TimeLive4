
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingApprover
AS                      
SELECT     AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, AccountApprovalTypeId, SystemApproverTypeId, 
                      AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, AccountExpenseEntryId, ExpenseApprovalId, ExpenseApprovalPathId, ProjectName, ProjectCode, 
                      ProjectDescription, EmployeeName, Approved, ExpenseApprovalTypeId, AccountExpenseEntryDate, Comments, IsRejected, IsApproved, Amount, 
                      AccountExpenseName, IsBillable, ExpenseEntryAccountEmployeeId, Description, AccountId, MaxApprovalPathSequence, 
                      CASE WHEN systemapprovertypeid = 1 THEN LeaderEmployeeId WHEN systemapprovertypeid = 2 THEN ProjectManagerEmployeeId WHEN systemapprovertypeid = 3
                       THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId WHEN systemapprovertypeid = 5 THEN EmployeeManagerId END AS ApproverEmployeeId,
                       EMailAddress, EmployeeManagerId, AccountEmployeeExpenseSheetId, MasterDescription, ExpenseSheetDate, BaseCurrencyCode, SubmittedDate, 
                      EmployeeNameWithCode
FROM         dbo.vueAccountExpenseEntryApprovalPending