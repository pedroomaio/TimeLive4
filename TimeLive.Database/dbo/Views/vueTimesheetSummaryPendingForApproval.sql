
CREATE VIEW dbo.vueTimesheetSummaryPendingForApproval
AS    
SELECT     AccountEmployeeTimeEntryPeriodId, TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType, Submitted, Approved, Rejected, 
                      MAX(TimeSheetApprovalId) AS TimeSheetApprovalId, AccountApprovalPathId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, 
                      ApprovalPathSequence, LeaderEmployeeId, ProjectManagerEmployeeId, AccountApprovalTypeId, EmployeeName, EmployeeManagerId, AccountProjectId, 
                      CASE WHEN systemapprovertypeid = 1 THEN LeaderEmployeeId WHEN systemapprovertypeid = 2 THEN ProjectManagerEmployeeId WHEN systemapprovertypeid = 3
                       THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId WHEN systemapprovertypeid = 5 THEN EmployeeManagerId END AS ApproverEmployeeId,
                       IsApproved, EMailAddress, AccountEmployeeTimeEntryApprovalProjectId, IsEmailSend, SubmittedDate, IsDisabled, IsDeleted, EmployeeNameWithCode
FROM         dbo.vueTimesheetSummaryForApproval
WHERE     (ApprovalPathSequence IN
                          (SELECT     TOP (1) ApprovalPathSequence
                            FROM          dbo.vueTimesheetSequenceForApproval
                            WHERE      (TimeSheetApprovalId IS NULL) AND (AccountProjectId = dbo.vueTimesheetSummaryForApproval.AccountProjectId) AND 
                                                   (AccountEmployeeTimeEntryPeriodId = dbo.vueTimesheetSummaryForApproval.AccountEmployeeTimeEntryPeriodId)))
GROUP BY AccountEmployeeTimeEntryPeriodId, TimeEntryAccountEmployeeId, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType, Submitted, Approved, Rejected, 
                      AccountApprovalPathId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, LeaderEmployeeId, ProjectManagerEmployeeId, 
                      AccountApprovalTypeId, EmployeeName, EmployeeManagerId, AccountProjectId, IsApproved, EMailAddress, AccountEmployeeTimeEntryApprovalProjectId, 
                      IsEmailSend, SubmittedDate, IsDisabled, IsDeleted, EmployeeNameWithCode