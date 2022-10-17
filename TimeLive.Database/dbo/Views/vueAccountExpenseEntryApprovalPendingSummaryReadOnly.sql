
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingSummaryReadOnly
AS
SELECT     AccountProjectId, 
                      LeaderEmployeeId, ProjectManagerEmployeeId, AccountEmployeeId, 
                      AccountExternalUserId, EmployeeManagerId, 
                       SystemApproverTypeId
FROM         dbo.vueAccountExpenseEntryApprovalSummary