
CREATE VIEW dbo.vueTimesheetSequenceForApproval
AS
SELECT     dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, 
                      dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId AS TimeEntryAccountEmployeeId, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, 
                      dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, 
                      dbo.AccountApprovalPath.AccountEmployeeId, dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountProject.LeaderEmployeeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountApprovalType.AccountApprovalTypeId, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployee.EmployeeManagerId, 
                      dbo.AccountProject.AccountProjectId, dbo.AccountEmployeeTimeEntryApproval.IsApproved, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryApprovalProjectId, 
                      dbo.AccountEmployeeTimeEntryApproval.PreviousStatus, dbo.AccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.AccountEmployeeTimeEntryApprovalProject.Submitted, dbo.AccountEmployeeTimeEntryApprovalProject.Approved, 
                      dbo.AccountEmployeeTimeEntryApprovalProject.Rejected
FROM         dbo.AccountApprovalType INNER JOIN
                      dbo.AccountEmployeeTimeEntryApprovalProject INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntryApprovalProject.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountProject.TimeSheetApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountApprovalPath.ApprovalPathSequence = dbo.AccountEmployeeTimeEntryApproval.ApprovalPathSequence AND 
                      dbo.AccountEmployeeTimeEntryApproval.PreviousStatus <> 1 AND dbo.AccountEmployeeTimeEntryApproval.IsReject <> 1 AND 
                      dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId
                       AND dbo.AccountEmployeeTimeEntryApprovalProject.AccountProjectId = dbo.AccountEmployeeTimeEntryApproval.AccountProjectId RIGHT OUTER JOIN
                      dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryPeriod ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId ON 
                      dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId