

CREATE VIEW [dbo].[vueAccountEmployeeTimeOffRequestForReport]
AS
SELECT        dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId, dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId, dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId, 
                         dbo.AccountEmployeeTimeOffRequest.RequestSubmitDate, dbo.AccountEmployeeTimeOffRequest.HoursOff, dbo.AccountEmployeeTimeOffRequest.StartDate, dbo.AccountEmployeeTimeOffRequest.EndDate, 
                         dbo.AccountEmployeeTimeOffRequest.InApproval, dbo.AccountEmployeeTimeOffRequest.Approved, dbo.AccountEmployeeTimeOffRequest.Rejected, dbo.AccountEmployeeTimeOffRequest.Description, 
                         dbo.AccountEmployeeTimeOffRequest.ApprovedOn, dbo.AccountEmployeeTimeOffRequest.ApprovedBy, dbo.AccountEmployeeTimeOffRequest.DayOff, dbo.AccountEmployeeTimeOffRequest.CreatedByEmployee, 
                         dbo.AccountEmployeeTimeOffRequest.CreatedOn, dbo.AccountEmployeeTimeOffRequest.ModifiedByEmployeeId, dbo.AccountEmployeeTimeOffRequest.ModifiedOn, 
                         dbo.AccountEmployeeTimeOffRequest.AccountId, dbo.AccountEmployeeTimeOffRequest.AccountProjectId, dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountTimeOffType.IsTimeOffRequestRequired, 
                         CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                         dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disabled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                         dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND 
                         dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disabled)' ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName
                          END AS EmployeeName, dbo.AccountLocation.AccountLocation, dbo.AccountLocation.AccountLocationId, dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountDepartment.AccountDepartmentId, 
                         dbo.AccountDepartment.DepartmentCode, dbo.AccountDepartment.DepartmentName, dbo.AccountRole.AccountRoleId, dbo.AccountRole.Role, 
                         AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS ApprovedByEmployeeName, dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, 
                         CASE WHEN rejected = 0 THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END AS Submitted, dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId,
						 (Select Available from VueAccountEmployeeTimeOff where dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = VueAccountEmployeeTimeOff.AccountTimeOffTypeId and dbo.AccountEmployee.AccountEmployeeId = VueAccountEmployeeTimeOff.AccountEmployeeId) as [AvailableHours]
FROM            dbo.AccountRole RIGHT OUTER JOIN
                         dbo.AccountEmployeeTimeOffRequest LEFT OUTER JOIN
                         dbo.AccountProject ON dbo.AccountEmployeeTimeOffRequest.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                         dbo.AccountEmployee ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                         dbo.AccountPreferences ON dbo.AccountEmployeeTimeOffRequest.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                         dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountEmployeeTimeOffRequest.ApprovedBy = AccountEmployee_1.AccountEmployeeId ON 
                         dbo.AccountRole.AccountRoleId = dbo.AccountEmployee.AccountRoleId LEFT OUTER JOIN
                         dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                         dbo.AccountTimeOffPolicy ON dbo.AccountEmployee.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId LEFT OUTER JOIN
                         dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                         dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId