
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover
AS
SELECT     AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, AccountApprovalTypeId, 
                      SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, AccountEmployeeTimeEntryId, TimeSheetApprovalId, 
                      TimeSheetApprovalPathId, ProjectName, ProjectDescription, ProjectCode, TaskName, AccountProjectTaskId, TaskDescription, EmployeeName, 
                      Approved, TimeSheetApprovalTypeId, TotalTime, TimeEntryDate, Comments, IsReject, IsApproved, MaxApprovalPathSequence, 
                      TimeEntryAccountEmployeeId, AccountId, EMailAddress, EmployeeManagerId, 
                      CASE WHEN systemapprovertypeid = 1 THEN LeaderEmployeeId WHEN systemapprovertypeid = 2 THEN ProjectManagerEmployeeId WHEN systemapprovertypeid
                       = 3 THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId WHEN systemapprovertypeid = 5 THEN EmployeeManagerId
                       END AS ApproverEmployeeId, Description, TotalMinutes, NonBillableTotalMinutes, BillableTotalMinutes, AccountEmployeeTimeEntryPeriodId, 
                      EmployeeWeekStartDay, TimeEntryStartDate, TimeEntryEndDate, TimeEntryViewType
FROM         dbo.vueAccountEmployeeTimeEntryApprovalPending