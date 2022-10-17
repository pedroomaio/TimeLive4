
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPeriodApprovalProject
AS
SELECT     dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryApprovalProject.Submitted, 
                      dbo.AccountEmployeeTimeEntryApprovalProject.Approved, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryApprovalProject.Rejected, 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountId
FROM         dbo.AccountEmployeeTimeEntryApprovalProject INNER JOIN
                      dbo.AccountEmployeeTimeEntryPeriod ON 
                      dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId
GROUP BY dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryApprovalProject.Submitted, 
                      dbo.AccountEmployeeTimeEntryApprovalProject.Approved, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryApprovalProject.Rejected, 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountId