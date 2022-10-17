
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingSummary
AS
SELECT     AccountProjectId, EmployeeName, SUM(Amount) AS Amount, ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, 
                      ExpenseSheetDate, LeaderEmployeeId, ProjectManagerEmployeeId, AccountExternalUserId, ApprovalPathSequence, AccountEmployeeId, IsRejected, 
                      IsApproved, MAX(ExpenseApprovalId) AS ExpenseApprovalId, Approved, Rejected, Submitted, 
                      CASE WHEN systemapprovertypeid = 1 THEN LeaderEmployeeId WHEN systemapprovertypeid = 2 THEN ProjectManagerEmployeeId WHEN systemapprovertypeid
                       = 3 THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId WHEN systemapprovertypeid = 5 THEN EmployeeManagerId
                       END AS ApproverEmployeeId, EmployeeManagerId, EMailAddress, AccountId, SystemApproverTypeId, AccountApprovalPathId, 
                      CurrencyCode AS BaseCurrencyCode, SubmittedDate, IsEmailSend
FROM         dbo.vueAccountExpenseEntryApprovalSummary
WHERE     (ApprovalPathSequence IN
                          (SELECT     TOP 1 ApprovalPathSequence
                            FROM          dbo.vueExpenseApprovalSequenceSummary
                            WHERE      (ExpenseApprovalId IS NULL) AND (AccountProjectId = dbo.vueAccountExpenseEntryApprovalSummary.AccountProjectId) AND 
                                                   (AccountEmployeeExpenseSheetId = dbo.vueAccountExpenseEntryApprovalSummary.AccountEmployeeExpenseSheetId)))
GROUP BY EmployeeName, ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, AccountProjectId, 
                      LeaderEmployeeId, ProjectManagerEmployeeId, AccountExternalUserId, ApprovalPathSequence, AccountEmployeeId, IsRejected, IsApproved, 
                      Approved, Rejected, Submitted, EmployeeManagerId, EMailAddress, AccountId, SystemApproverTypeId, AccountApprovalPathId, CurrencyCode, 
                      SubmittedDate, IsEmailSend