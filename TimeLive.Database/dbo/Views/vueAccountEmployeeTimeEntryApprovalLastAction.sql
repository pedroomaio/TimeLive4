CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalLastAction
AS
SELECT     TimeSheetApprovalId, AccountEmployeeTimeEntryId, IsReject, IsApproved, Comments, ApprovedOn, ApprovedByEmployeeId, 
                      TimeSheetApprovalTypeId, TimeSheetApprovalPathId
FROM         dbo.AccountEmployeeTimeEntryApproval AS parent
WHERE     (TimeSheetApprovalId =
                          (SELECT     MAX(TimeSheetApprovalId) AS Expr1
                            FROM          dbo.AccountEmployeeTimeEntryApproval
                            WHERE      (AccountEmployeeTimeEntryId = parent.AccountEmployeeTimeEntryId)))