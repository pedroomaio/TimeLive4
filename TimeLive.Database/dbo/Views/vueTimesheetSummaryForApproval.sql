
CREATE VIEW [dbo].[vueTimesheetSummaryForApproval]
AS
SELECT        dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId AS TimeEntryAccountEmployeeId, 
                         dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, 
                         dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.SystemApproverTypeId, 
                         dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountProject.LeaderEmployeeId, 
                         dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountApprovalType.AccountApprovalTypeId, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                         dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                         dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND 
                         dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName
                          END AS EmployeeName, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND dbo.AccountEmployee.IsDisabled = 1 THEN ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                         + dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                         dbo.AccountEmployee.IsDisabled = 0 THEN ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                         + dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND 
                         dbo.AccountEmployee.IsDisabled = 1 THEN ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                         + dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                         + dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS EmployeeNameWithCode, dbo.AccountEmployee.EmployeeManagerId, dbo.AccountProject.AccountProjectId, 
                         dbo.AccountEmployeeTimeEntryApproval.IsApproved, dbo.AccountEmployee.EMailAddress, dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryApprovalProjectId, 
                         dbo.AccountEmployeeTimeEntryApproval.PreviousStatus, dbo.AccountEmployeeTimeEntryApproval.IsReject, dbo.AccountEmployeeTimeEntryApprovalProject.Submitted, 
                         dbo.AccountEmployeeTimeEntryApprovalProject.Approved, dbo.AccountEmployeeTimeEntryApprovalProject.Rejected, dbo.AccountEmployeeTimeEntryApprovalProject.IsEmailSend, 
                         dbo.AccountEmployeeTimeEntryPeriod.SubmittedDate, dbo.AccountEmployee.IsDisabled, dbo.AccountEmployee.IsDeleted, dbo.AccountProject.ProjectName
FROM            dbo.AccountEmployeeTimeEntryApproval RIGHT OUTER JOIN
                         dbo.AccountPreferences RIGHT OUTER JOIN
                         dbo.AccountEmployee RIGHT OUTER JOIN
                         dbo.AccountApprovalType INNER JOIN
                         dbo.AccountEmployeeTimeEntryApprovalProject INNER JOIN
                         dbo.AccountProject ON dbo.AccountEmployeeTimeEntryApprovalProject.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                         dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountProject.TimeSheetApprovalTypeId INNER JOIN
                         dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                         dbo.AccountEmployeeTimeEntryPeriod ON dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId ON 
                         dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId ON dbo.AccountPreferences.AccountId = dbo.AccountEmployeeTimeEntryPeriod.AccountId ON 
                         dbo.AccountEmployeeTimeEntryApproval.ApprovalPathSequence = dbo.AccountApprovalPath.ApprovalPathSequence AND dbo.AccountEmployeeTimeEntryApproval.PreviousStatus <> 1 AND 
                         dbo.AccountEmployeeTimeEntryApproval.IsReject <> 1 AND 
                         dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryPeriodId AND 
                         dbo.AccountEmployeeTimeEntryApproval.AccountProjectId = dbo.AccountEmployeeTimeEntryApprovalProject.AccountProjectId