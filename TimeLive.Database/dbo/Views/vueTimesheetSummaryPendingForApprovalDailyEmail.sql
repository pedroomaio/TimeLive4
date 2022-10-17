
CREATE VIEW dbo.vueTimesheetSummaryPendingForApprovalDailyEmail
AS
SELECT     dbo.vueTimesheetSummaryForApproval.AccountEmployeeTimeEntryPeriodId, TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType, Submitted, Approved, Rejected, 
                      MAX(dbo.vueTimesheetSummaryForApproval.TimeSheetApprovalId) AS TimeSheetApprovalId, AccountApprovalPathId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, 
                      dbo.vueTimesheetSummaryForApproval.ApprovalPathSequence, LeaderEmployeeId, ProjectManagerEmployeeId, AccountApprovalTypeId, EmployeeName, EmployeeManagerId, dbo.vueTimesheetSummaryForApproval.AccountProjectId, 
                      CASE WHEN systemapprovertypeid = 1 THEN LeaderEmployeeId WHEN systemapprovertypeid = 2 THEN ProjectManagerEmployeeId WHEN systemapprovertypeid = 3
                       THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId WHEN systemapprovertypeid = 5 THEN EmployeeManagerId END
					     AS ApproverEmployeeId,
                       IsApproved, EMailAddress, AccountEmployeeTimeEntryApprovalProjectId, IsEmailSend, SubmittedDate, IsDisabled, IsDeleted, EmployeeNameWithCode
FROM         dbo.vueTimesheetSummaryForApproval
inner join 
(
select AccountEmployeeTimeEntryPeriodId, TimeSheetApprovalId, ApprovalPathSequence, AccountProjectID 
from vueTimesheetSequenceForApprovalPendingEmail) ApprovalSequence 
on 
dbo.vueTimesheetSummaryForApproval.ApprovalPathSequence = ApprovalSequence.ApprovalPathSequence
and 
dbo.vueTimesheetSummaryForApproval.AccountProjectId = ApprovalSequence.AccountProjectId
and
dbo.vueTimesheetSummaryForApproval.AccountEmployeeTimeEntryPeriodId = ApprovalSequence.AccountEmployeeTimeEntryPeriodId
GROUP BY dbo.vueTimesheetSummaryForApproval.AccountEmployeeTimeEntryPeriodId, TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType, Submitted, Approved, Rejected, 
                      AccountApprovalPathId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, dbo.vueTimesheetSummaryForApproval.ApprovalPathSequence, LeaderEmployeeId, ProjectManagerEmployeeId, 
                      AccountApprovalTypeId, EmployeeName, EmployeeManagerId, dbo.vueTimesheetSummaryForApproval.AccountProjectId, IsApproved, EMailAddress, AccountEmployeeTimeEntryApprovalProjectId, 
                      IsEmailSend, SubmittedDate, IsDisabled, IsDeleted, EmployeeNameWithCode