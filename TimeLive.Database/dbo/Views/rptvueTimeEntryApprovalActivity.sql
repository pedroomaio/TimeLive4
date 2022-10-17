
CREATE VIEW dbo.rptvueTimeEntryApprovalActivity
AS
SELECT     TimeSheetApprovalId, AccountEmployeeTimeEntryId, TimeSheetApprovalTypeId, TimeSheetApprovalPathId, ApprovedByEmployeeId, ApprovedOn, 
                      Comments, IsReject, IsApproved, EmployeeName, ProjectName, TaskName, TotalTime, StartTime, EndTime, TimeEntryDate, ClientName, 
                      EMailAddress, ApproverComments, TotalHours, Approved, AccountEmployeeId, AccountProjectId, Description, AccountId, TotalMinutes, AccountClientId, 
                      AccountProjectTaskId, BillingType, IsBillable, Rejected, BillingRate, AccountDepartmentId, DepartmentName, ProjectCode, TaskCode, ClientNick, 
                      ApprovalTypeName, SystemApproverType, ApproverEmployeeName, ApproverEmailAddress, Submitted, Status, EmployeeCode, AccountLocation, 
                      Role, DepartmentCode, AccountLocationId, AccountRoleId, ProjectDescription, TaskDescription, PeriodStartDate, PeriodEndDate, Period
FROM         dbo.vueTimeEntryApprovalActivityForReport