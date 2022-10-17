
CREATE VIEW dbo.vueAccountEmployeeTimeOffForReport
AS
SELECT     CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.AccountDepartmentId, 
                      dbo.AccountEmployee.AccountRoleId, dbo.AccountEmployee.AccountLocationId, dbo.AccountEmployeeTimeOff.AccountId, 
                      dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId, dbo.vueAccountEmployeeTimeOff.EarnedDay, dbo.vueAccountEmployeeTimeOff.ConsumeDay, 
                      dbo.vueAccountEmployeeTimeOff.AvailableDay, dbo.vueAccountEmployeeTimeOff.CarryForwardDay, 
                      ISNULL(dbo.AccountEmployeeTimeOff.CarryForward, 0) AS CarryForward, ISNULL(dbo.AccountEmployeeTimeOff.Earned, 0) AS Earned, 
                      ISNULL(dbo.AccountEmployeeTimeOff.Consume, 0) AS Consume, ISNULL(dbo.AccountEmployeeTimeOff.Available, 0) AS Available, 
                      dbo.AccountEmployeeTimeOff.LastEarnedDate, dbo.AccountEmployeeTimeOff.CreatedByEmployeeId, dbo.AccountEmployeeTimeOff.CreatedOn, 
                      dbo.AccountEmployeeTimeOff.ModifiedByEmployeeId, dbo.AccountEmployeeTimeOff.ModifiedOn, 
                      dbo.AccountEmployeeTimeOff.AccountTimeOffPolicyId, dbo.AccountTimeOffType.AccountTimeOffType, 
                      dbo.AccountTimeOffType.IsTimeOffRequestRequired, dbo.AccountLocation.AccountLocation, dbo.AccountDepartment.DepartmentCode, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.HiredDate, dbo.AccountEmployee.TerminationDate, 
                      dbo.AccountEmployeeTimeOff.AccountEmployeeId, dbo.AccountEmployeeTimeOff.AccountEmployeeTimeOffId
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.AccountEmployeeTimeOff ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeOff.AccountEmployeeId INNER JOIN
                      dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId INNER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId INNER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId INNER JOIN
                      dbo.AccountTimeOffPolicy ON dbo.AccountEmployeeTimeOff.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId INNER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId INNER JOIN
                      dbo.vueAccountEmployeeTimeOff ON 
                      dbo.AccountEmployeeTimeOff.AccountEmployeeTimeOffId = dbo.vueAccountEmployeeTimeOff.AccountEmployeeTimeOffId