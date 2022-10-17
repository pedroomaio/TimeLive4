
CREATE VIEW [dbo].[rptvueAccountEmployeeTimeOff]
AS
SELECT     EmployeeName, EMailAddress, AccountDepartmentId, AccountRoleId, AccountLocationId, AccountEmployeeTimeOffId, AccountEmployeeId, AccountId, 
                      AccountTimeOffTypeId, Earned, Consume, Available, LastEarnedDate, CreatedByEmployeeId, CreatedOn, ModifiedByEmployeeId, ModifiedOn, 
                      CarryForward, AccountTimeOffPolicyId, AccountTimeOffType, IsTimeOffRequestRequired, AccountLocation, DepartmentCode, DepartmentName, Role, 
                      AccountTimeOffPolicy, EmployeeCode, HiredDate, TerminationDate, EarnedDay, AvailableDay, ConsumeDay, CarryForwardDay
FROM         dbo.vueAccountEmployeeTimeOffForReport