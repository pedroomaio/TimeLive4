
CREATE VIEW dbo.rptvueAccountEmployeeTimeOffRequestWithTimeEntryReport
AS
SELECT     AccountEmployeeTimeEntryId, AccountEmployeeId, TimeEntryDate, StartTime, EndTime, TotalTime, Description, Approved, CreatedOn, Submitted, 
                      ModifiedOn, Rejected, IsTimeOff, Hours, AccountTimeOffTypeId, AccountEmployeeTimeOffRequestId, AccountTimeOffType, IsTimeOffRequestRequired, 
                      AccountId, EmployeeName, EMailAddress, DepartmentCode, DepartmentName, Role, AccountLocation, EmployeeCode, AccountTimeOffPolicy, 
                      AccountTimeOffPolicyId, AccountLocationId, AccountDepartmentId, AccountRoleId, AccountProjectId, ProjectName, TotalHours
FROM         dbo.vueAccountEmployeeTimeOffRequestWithTimeEntryReport