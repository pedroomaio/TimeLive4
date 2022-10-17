
CREATE VIEW dbo.vueAccountExpenseEntryWithLastAction
AS
SELECT     AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, 
                      EmployeeName, Approved, IsRejected, IsApproved, ExpenseEntryAccountEmployeeId, AccountExpenseEntryId
FROM         dbo.vueAccountExpenseEntryApproval AS parent
WHERE     (ExpenseApprovalId =
                          (SELECT     MAX(ExpenseApprovalId) AS Expr1
                            FROM          dbo.AccountExpenseEntryApproval
                            WHERE      (AccountExpenseEntryId = parent.AccountExpenseEntryId)))
GROUP BY AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, 
                      EmployeeName, Approved, IsRejected, IsApproved, ExpenseEntryAccountEmployeeId, AccountExpenseEntryId