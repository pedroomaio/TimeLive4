
CREATE VIEW dbo.vueAccountEmployeeTimeOffRequestWithTimeEntryReport
AS                        
SELECT     dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.AccountEmployeeId, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, dbo.AccountEmployeeTimeEntry.TotalTime, 
                      dbo.AccountEmployeeTimeEntry.Description, dbo.AccountEmployeeTimeEntry.Approved, dbo.AccountEmployeeTimeEntry.CreatedOn, 
                      dbo.AccountEmployeeTimeEntry.Submitted, dbo.AccountEmployeeTimeEntry.ModifiedOn, dbo.AccountEmployeeTimeEntry.Rejected, 
                      dbo.AccountEmployeeTimeEntry.IsTimeOff, dbo.AccountEmployeeTimeEntry.Hours, dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId, dbo.AccountTimeOffType.AccountTimeOffType, 
                      dbo.AccountTimeOffType.IsTimeOffRequestRequired, dbo.AccountTimeOffType.AccountId, 
                      CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and AccountEmployee_1.IsDisabled = 1  THEN AccountEmployee_1.LastName + ' ' + AccountEmployee_1.FirstName + ' ' + '(Disbaled)'
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and AccountEmployee_1.IsDisabled = 0 THEN AccountEmployee_1.LastName + ' ' + AccountEmployee_1.FirstName 
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and AccountEmployee_1.IsDisabled = 1 THEN AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName + ' ' + '(Disbaled)'
					  ELSE AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName END AS EmployeeName, AccountEmployee_1.EMailAddress, dbo.AccountDepartment.DepartmentCode, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountLocation.AccountLocation, AccountEmployee_1.EmployeeCode, 
                      dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId, dbo.AccountLocation.AccountLocationId, 
                      dbo.AccountDepartment.AccountDepartmentId, dbo.AccountRole.AccountRoleId, dbo.AccountEmployeeTimeEntry.AccountProjectId, dbo.AccountProject.ProjectName, 
                      ROUND(CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60, 2) 
                      AS TotalHours
FROM         dbo.AccountTimeOffType RIGHT OUTER JOIN
                      dbo.AccountDepartment RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = AccountEmployee_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountRole ON AccountEmployee_1.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountPreferences ON AccountEmployee_1.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON AccountEmployee_1.AccountLocationId = dbo.AccountLocation.AccountLocationId ON 
                      dbo.AccountDepartment.AccountDepartmentId = AccountEmployee_1.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountTimeOffPolicy ON AccountEmployee_1.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId ON 
                      dbo.AccountTimeOffType.AccountTimeOffTypeId = dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId
WHERE     (dbo.AccountEmployeeTimeEntry.IsTimeOff = 1)