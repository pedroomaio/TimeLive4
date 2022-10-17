
CREATE VIEW dbo.vueTotalApprovedPeriods
AS
SELECT     dbo.vueTotalApprovalProjects.AccountEmployeeTimeEntryPeriodId
FROM         dbo.vueTotalApprovalProjects INNER JOIN
                      dbo.vueApprovedCountApprovalProjects ON 
                      dbo.vueTotalApprovalProjects.AccountEmployeeTimeEntryPeriodId = dbo.vueApprovedCountApprovalProjects.AccountEmployeeTimeEntryPeriodId AND 
                      dbo.vueTotalApprovalProjects.TotalCount = dbo.vueApprovedCountApprovalProjects.ApprovedCount