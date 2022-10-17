
CREATE VIEW dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover
AS
SELECT     AccountEmployeeTimeOffRequestId, AccountTimeOffTypeId, TimeOffAccountEmployeeId, RequestSubmitDate, HoursOff, StartDate, EndDate, InApproval, Approved, 
                      Rejected, Description, ApprovedOn, ApprovedBy, DayOff, CreatedByEmployeeId, CreatedOn, AccountId, ApprovalTypeName, AccountApprovalPathId, 
                      SystemApproverTypeId, AccountExternalUserId, ApprovalPathSequence, AccountEmployeeId, TimeOffApprovalPathId, ApprovedByEmployeeId, ApprovedOnApproval, 
                      IsRejected, IsApproved, Comments, TimeOffApprovalTypeId, FirstName, LastName, FullName, AccountTimeOffType, IsTimeOffRequestRequired, EMailAddress, 
                      AccountApprovalTypeId, MaxApprovalPathSequence, EmployeeManagerId, 
                      CASE WHEN systemapprovertypeid = 3 THEN AccountEmployeeId WHEN systemapprovertypeid = 5 THEN EmployeeManagerId END AS ApproverEmployeeId, 
                      EmployeeNameWithCode
FROM         dbo.vueAccountEmployeeTimeOffRequestApprovalPending