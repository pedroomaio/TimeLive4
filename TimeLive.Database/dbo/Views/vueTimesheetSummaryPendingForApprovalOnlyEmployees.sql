
CREATE VIEW [dbo].[vueTimesheetSummaryPendingForApprovalOnlyEmployees]
AS
SELECT        TimesheetSummary.AccountEmployeeTimeEntryPeriodId, TimesheetSummary.TimeEntryAccountEmployeeId, TimesheetSummary.TimeEntryStartDate, TimesheetSummary.TimeEntryEndDate, 
                         TimesheetSummary.TimeEntryViewType, TimesheetSummary.Submitted, TimesheetSummary.Approved, TimesheetSummary.Rejected, MAX(TimesheetSummary.TimeSheetApprovalId) AS TimeSheetApprovalId, 
                         TimesheetSummary.AccountApprovalPathId, TimesheetSummary.SystemApproverTypeId, TimesheetSummary.AccountExternalUserId, TimesheetSummary.AccountEmployeeId, 
                         TimesheetSummary.ApprovalPathSequence, TimesheetSummary.LeaderEmployeeId, TimesheetSummary.ProjectManagerEmployeeId, TimesheetSummary.AccountApprovalTypeId, 
                         TimesheetSummary.EmployeeName, TimesheetSummary.EmployeeManagerId, TimesheetSummary.AccountProjectId, 
                         CASE WHEN TimesheetSummary.systemapprovertypeid = 1 THEN TimesheetSummary.LeaderEmployeeId WHEN TimesheetSummary.systemapprovertypeid = 2 THEN TimesheetSummary.ProjectManagerEmployeeId
                          WHEN TimesheetSummary.systemapprovertypeid = 3 THEN TimesheetSummary.AccountEmployeeId WHEN TimesheetSummary.systemapprovertypeid = 4 THEN TimesheetSummary.AccountExternalUserId WHEN
                          TimesheetSummary.systemapprovertypeid = 5 THEN TimesheetSummary.EmployeeManagerId END AS ApproverEmployeeId, TimesheetSummary.IsApproved, TimesheetSummary.EMailAddress, 
                         TimesheetSummary.AccountEmployeeTimeEntryApprovalProjectId, TimesheetSummary.IsEmailSend, TimesheetSummary.SubmittedDate, TimesheetSummary.IsDisabled, TimesheetSummary.IsDeleted, 
                         TimesheetSummary.EmployeeNameWithCode, TimesheetSummary.ProjectName
FROM            dbo.vueTimesheetSummaryForApproval AS TimesheetSummary LEFT OUTER JOIN
                         dbo.vueTimesheetSequenceForApproval AS TimesheetSequence ON TimesheetSequence.ApprovalPathSequence = TimesheetSummary.ApprovalPathSequence AND 
                         TimesheetSequence.TimeSheetApprovalId IS NULL AND TimesheetSequence.AccountProjectId = TimesheetSummary.AccountProjectId AND 
                         TimesheetSequence.AccountEmployeeTimeEntryPeriodId = TimesheetSummary.AccountEmployeeTimeEntryPeriodId
GROUP BY TimesheetSummary.AccountEmployeeTimeEntryPeriodId, TimesheetSummary.TimeEntryAccountEmployeeId, TimesheetSummary.TimeEntryStartDate, TimesheetSummary.TimeEntryEndDate, 
                         TimesheetSummary.TimeEntryViewType, TimesheetSummary.Submitted, TimesheetSummary.Approved, TimesheetSummary.Rejected, TimesheetSummary.AccountApprovalPathId, 
                         TimesheetSummary.SystemApproverTypeId, TimesheetSummary.AccountExternalUserId, TimesheetSummary.AccountEmployeeId, TimesheetSummary.ApprovalPathSequence, 
                         TimesheetSummary.LeaderEmployeeId, TimesheetSummary.ProjectManagerEmployeeId, TimesheetSummary.AccountApprovalTypeId, TimesheetSummary.EmployeeName, 
                         TimesheetSummary.EmployeeManagerId, TimesheetSummary.AccountProjectId, TimesheetSummary.IsApproved, TimesheetSummary.EMailAddress, 
                         TimesheetSummary.AccountEmployeeTimeEntryApprovalProjectId, TimesheetSummary.IsEmailSend, TimesheetSummary.SubmittedDate, TimesheetSummary.IsDisabled, TimesheetSummary.IsDeleted, 
                         TimesheetSummary.EmployeeNameWithCode, TimesheetSummary.ProjectName