
CREATE VIEW [dbo].[vueAccountEmployeeTimeOffAudit]
AS
SELECT     TOP (100) PERCENT dbo.AccountEmployeeTimeOffAudit.AccountEmployeeTimeOffAuditId, dbo.AccountEmployeeTimeOffAudit.AccountTimeOffTypeId, 
                      dbo.AccountEmployeeTimeOffAudit.AccountTimeOffPolicyId, dbo.AccountEmployeeTimeOffAudit.SystemEarnPeriodId, 
                      dbo.AccountEmployeeTimeOffAudit.SystemResetToZeroTypeId, dbo.AccountEmployeeTimeOffAudit.AccountId, 
                      dbo.AccountEmployeeTimeOffAudit.CreatedByEmployeeId, dbo.AccountEmployeeTimeOffAudit.ModifiedByEmployeeId, 
                      dbo.AccountEmployeeTimeOffAudit.EffectiveDate, ROUND(dbo.AccountEmployeeTimeOffAudit.Earned, 2) AS EarnedHours, 
                      ROUND(dbo.AccountEmployeeTimeOffAudit.Consume, 2) AS ConsumeHours, ROUND(dbo.AccountEmployeeTimeOffAudit.Available, 2) 
                      AS AvailableHours, ROUND(dbo.AccountEmployeeTimeOffAudit.CarryForward, 2) AS CarryForward, dbo.AccountEmployeeTimeOffAudit.ResetToHours, 
                      dbo.AccountEmployeeTimeOffAudit.EarnHours AS PolicyEarnHours, dbo.AccountEmployeeTimeOffAudit.MaximumAvailable, 
                      dbo.AccountEmployeeTimeOffAudit.InitialSetToHours, dbo.AccountEmployeeTimeOffAudit.LastEarnedDate, 
                      dbo.AccountEmployeeTimeOffAudit.LastResetDate, dbo.AccountEmployeeTimeOffAudit.BeforeAfterPolicyChange AS AuditPeriodType, 
                      dbo.AccountEmployeeTimeOffAudit.AccountTimeOffType AS TimeOffType, 
                      dbo.AccountEmployeeTimeOffAudit.PolicyEarnResetAutidAction AS AuditAction, 
                      dbo.AccountEmployeeTimeOffAudit.PolicyExecutionType AS ExecutionType, dbo.AccountEmployeeTimeOffAudit.AuditSource, 
                      dbo.AccountEmployeeTimeOffAudit.AccountTimeOffPolicy AS TimeOffPolicy, dbo.AccountEmployeeTimeOffAudit.SortOrder, 
                      dbo.AccountEmployeeTimeOffAudit.PolicyExecutedDate AS ExecutedDate, dbo.AccountEmployeeTimeOffAudit.CreatedOn, 
                      dbo.AccountEmployeeTimeOffAudit.ModifiedOn, dbo.AccountEmployeeTimeOffAudit.SystemEarnPeriod AS EarnPeriod, 
                      dbo.AccountEmployeeTimeOffAudit.SystemResetToZeroType AS ResetPeriod, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, 
                      dbo.AccountEmployee.HiredDate, dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.EmployeeCode, 
                      dbo.AccountEmployee.EMailAddress, dbo.AccountLocation.AccountLocation, dbo.AccountDepartment.DepartmentCode, dbo.AccountRole.AccountRoleId, 
                      dbo.AccountDepartment.AccountDepartmentId, dbo.AccountLocation.AccountLocationId, dbo.vueAccountEmployee.AccountWorkingDayTypeId, 
                      ROUND(dbo.AccountEmployeeTimeOffAudit.Earned / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2) AS EarnedDay, 
                      ROUND(dbo.AccountEmployeeTimeOffAudit.Consume / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2) AS ConsumeDay, 
                      ROUND(dbo.AccountEmployeeTimeOffAudit.Available / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2) AS AvailableDay, 
                      ROUND(dbo.AccountEmployeeTimeOffAudit.CarryForward / CASE WHEN ISNULL(dbo.vueAccountWorkingDayType.HoursPerDay, 0) = 0 THEN 1 ELSE dbo.vueAccountWorkingDayType.HoursPerDay END, 2) AS CarryForwardDay, 
                      dbo.AccountEmployeeTimeOffAudit.AccountEmployeeId
FROM         dbo.AccountEmployeeTimeOffAudit INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeOffAudit.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployeeTimeOffAudit.AccountId = dbo.AccountPreferences.AccountId INNER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId INNER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId INNER JOIN
                      dbo.vueAccountEmployee ON dbo.AccountEmployeeTimeOffAudit.AccountEmployeeId = dbo.vueAccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.vueAccountWorkingDayType ON 
                      dbo.vueAccountEmployee.AccountWorkingDayTypeId = dbo.vueAccountWorkingDayType.AccountWorkingDayTypeId