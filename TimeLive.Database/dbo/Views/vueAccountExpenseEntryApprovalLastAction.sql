
CREATE VIEW dbo.vueAccountExpenseEntryApprovalLastAction
AS
SELECT     ExpenseApprovalId, AccountExpenseEntryId, ExpenseApprovalTypeId, ExpenseApprovalPathId, ApprovedByEmployeeId, ApprovedOn, Comments, 
                      IsRejected, IsApproved
FROM         dbo.AccountExpenseEntryApproval AS parent
WHERE     (ExpenseApprovalId =
                          (SELECT     MAX(ExpenseApprovalId) AS Expr1
                            FROM          dbo.AccountExpenseEntryApproval
                            WHERE      (AccountExpenseEntryId = parent.AccountExpenseEntryId)))