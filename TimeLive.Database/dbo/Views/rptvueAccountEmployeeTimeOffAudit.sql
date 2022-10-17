
CREATE VIEW [dbo].[rptvueAccountEmployeeTimeOffAudit]
AS
SELECT     AccountEmployeeTimeOffAuditId, AccountTimeOffTypeId, AccountTimeOffPolicyId, SystemEarnPeriodId, SystemResetToZeroTypeId, 
                      AccountEmployeeId, AccountId, CreatedByEmployeeId, ModifiedByEmployeeId, EffectiveDate, EarnedHours, ConsumeHours, AvailableHours, 
                      CarryForward, ResetToHours, PolicyEarnHours, MaximumAvailable, InitialSetToHours, LastEarnedDate, LastResetDate, AuditPeriodType, TimeOffType,
                       AuditAction, ExecutionType, AuditSource, TimeOffPolicy, SortOrder, ExecutedDate, CreatedOn, ModifiedOn, EarnPeriod, ResetPeriod, EmployeeName, 
                      FirstName, LastName, HiredDate, DepartmentName, Role, EmployeeCode, EMailAddress, AccountLocation, DepartmentCode, AccountRoleId, 
                      AccountDepartmentId, AccountLocationId, AvailableDay, ConsumeDay, EarnedDay, CarryForwardDay
FROM         dbo.vueAccountEmployeeTimeOffAudit