
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff
AS
SELECT     AccountEmployeeTimeEntryId, AccountEmployeeId, TimeEntryDate, StartTime, EndTime, TotalTime, Description, Approved, AdministratorApproved, CreatedOn, 
                      Rejected, Submitted, IsTimeOff, Hours, AccountTimeOffTypeId, AccountEmployeeTimeOffRequestId, ApprovalTypeName, AccountApprovalTypeId, 
                      AccountApprovalPathId, SystemApproverTypeId, AccountExternalUserId, ApprovalPathSequence, EmployeeManagerId, ModifiedOn, TimeSheetApprovalId, 
                      ApprovedByEmployeeId, Comments, IsReject, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, EmployeeName, EMailAddress, AccountTimeOffType, 
                      TotalMinutes, IsApproved, AccountEmployeeTimeEntryPeriodId, 
                      CASE WHEN systemapprovertypeid = 3 THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId WHEN systemapprovertypeid = 5 THEN
                       EmployeeManagerId END AS ApproverEmployeeId, AccountId
FROM         dbo.vueAccountEmployeeTimeEntryApprovalPendingForTimeOff