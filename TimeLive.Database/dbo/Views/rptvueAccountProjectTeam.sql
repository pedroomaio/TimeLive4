
CREATE VIEW dbo.rptvueAccountProjectTeam
AS
SELECT AccountProjectEmployeeId, AccountId, AccountProjectId, AccountEmployeeId, AccountRoleId, AccountBillingRateId, AccountProjectEmployeeTemplateId, FirstName,
					  LastName, AccountClientId, ProjectName, ProjectBillingType, DepartmentName, AccountLocation, Role, AccountEmployeeType, ClientName, ProjectStatus,
					  EmployeeStatus, AccountWorkingDayType, HoursPerDay, MinimumHoursPerDay, MaximumHoursPerDay, MinimumHoursPerWeek, MaximumHoursPerWeek,
					  AccountTimeOffPolicy, AccountHolidayType, ClientContactFirstName, ClientContactLastName, ClientDepartmentCode, ClientDepartmentName,
					  ClientDepartmentLocation, ProjectStatusId, ProjectType, AccountProjectTypeId, ProjectDescription, ProjectStartDate, Deadline, EstimatedTime, EstimatedDuration,
					  EstimatedDurationUnit, ProjectCode, ProjectBillingRate, Completed, IsDisabledProject, IsDeletedProject, ClientNick, ClientEMailAddress, ClientAddress1,
					  ClientAddress2, ClientState, ClientCity, ClientZipCode, ClientTelephone1, ClientTelephone2, ClientFax, EmployeeState, EmployeeCity, EmployeeZip,
					  EmployeeWorkPhoneNo, TerminationDate, EmployeeCode, HiredDate, BillingRate, BillingRateStartDate, BillingRateEndDate, EmployeeRate, EmployeeName,
					  ROUND(CONVERT(float, TotalMinutes) / 60, 2) AS TotalHours, REPLACE(TotalMinutes / 60, '', '.00') + ':' + RIGHT('0' + REPLACE(TotalMinutes - TotalMinutes / 60 * 60, '',
					  '.00'), 2) AS TotalTime
FROM dbo.vueAccountProjectTeamForReport