
CREATE VIEW [dbo].[vueTotalSubmittedPeriods]
AS
SELECT     dbo.vueTotalApprovalProjectsSubmitted.AccountEmployeeTimeEntryPeriodId
FROM         dbo.vueTotalApprovalProjectsSubmitted INNER JOIN
                      dbo.vueSubmittedCountApprovalProjects ON 
                      dbo.vueTotalApprovalProjectsSubmitted.AccountEmployeeTimeEntryPeriodId = dbo.vueSubmittedCountApprovalProjects.AccountEmployeeTimeEntryPeriodId AND 
                      dbo.vueTotalApprovalProjectsSubmitted.TotalCount = dbo.vueSubmittedCountApprovalProjects.ApprovedCount