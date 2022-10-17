

CREATE VIEW [dbo].[rptvueAccountEmployeeTimeOffRequest]
AS
SELECT        AccountEmployeeTimeOffRequestId, AccountTimeOffTypeId, AccountEmployeeId, RequestSubmitDate, HoursOff, StartDate, EndDate, InApproval, Submitted, Approved, Rejected, Description, ApprovedOn, 
                         ApprovedBy, DayOff, CreatedByEmployee, CreatedOn, ModifiedByEmployeeId, ModifiedOn, AccountId, AccountProjectId, AccountTimeOffType, IsTimeOffRequestRequired, EmployeeName, AccountLocation, 
                         AccountLocationId, AccountTimeOffPolicy, AccountDepartmentId, DepartmentCode, DepartmentName, AccountRoleId, Role, ApprovedByEmployeeName, ProjectName, ProjectDescription, AccountTimeOffPolicyId, 
                         dbo.CombineValuesForTimeOffCurrentApprover(AccountEmployeeTimeOffRequestId) AS CurrentApprover, AvailableHours
FROM            dbo.vueAccountEmployeeTimeOffRequestForReport