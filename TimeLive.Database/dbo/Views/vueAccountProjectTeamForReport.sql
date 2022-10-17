
CREATE VIEW dbo.vueAccountProjectTeamForReport
AS                       
SELECT     dbo.AccountProjectEmployee.AccountProjectEmployeeId, dbo.AccountProjectEmployee.AccountId, dbo.AccountProjectEmployee.AccountProjectId, 
                      dbo.AccountProjectEmployee.AccountEmployeeId, dbo.AccountProjectEmployee.AccountRoleId, dbo.AccountProjectEmployee.AccountBillingRateId, 
                      dbo.AccountProjectEmployee.AccountProjectEmployeeTemplateId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, 
                      dbo.AccountProject.AccountClientId, dbo.AccountProject.ProjectName, dbo.AccountBillingType.BillingType AS ProjectBillingType, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountLocation.AccountLocation, dbo.AccountRole.Role, dbo.AccountEmployeeType.AccountEmployeeType, 
                      dbo.AccountParty.PartyName AS ClientName, dbo.AccountStatus.Status AS ProjectStatus, AccountStatus_1.Status AS EmployeeStatus, 
                      dbo.AccountWorkingDayType.AccountWorkingDayType, dbo.AccountWorkingDayType.HoursPerDay, dbo.AccountWorkingDayType.MinimumHoursPerDay, 
                      dbo.AccountWorkingDayType.MaximumHoursPerDay, dbo.AccountWorkingDayType.MinimumHoursPerWeek, dbo.AccountWorkingDayType.MaximumHoursPerWeek, 
                      dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountHolidayType.AccountHolidayType, dbo.AccountPartyContact.FirstName AS ClientContactFirstName, 
                      dbo.AccountPartyContact.LastName AS ClientContactLastName, dbo.AccountPartyDepartment.PartyDepartmentCode AS ClientDepartmentCode, 
                      dbo.AccountPartyDepartment.PartyDepartmentName AS ClientDepartmentName, dbo.AccountPartyDepartment.PartyDepartmentLocation AS ClientDepartmentLocation, 
                      dbo.AccountProject.ProjectStatusId, dbo.AccountProjectType.ProjectType, dbo.AccountProject.AccountProjectTypeId, dbo.AccountProject.ProjectDescription, 
                      dbo.AccountProject.StartDate AS ProjectStartDate, dbo.AccountProject.Deadline, dbo.AccountProject.EstimatedTime, dbo.AccountProject.EstimatedDuration, 
                      dbo.AccountProject.EstimatedDurationUnit, CASE WHEN ISNULL(dbo.AccountProject.ProjectPrefix, '') 
                      = '' THEN dbo.AccountProject.ProjectCode ELSE dbo.AccountProject.ProjectPrefix + '-' + dbo.AccountProject.ProjectCode END AS ProjectCode, 
                      dbo.AccountProject.DefaultBillingRate AS ProjectBillingRate, dbo.AccountProject.Completed, dbo.AccountProject.IsDisabled AS IsDisabledProject, 
                      dbo.AccountProject.IsDeleted AS IsDeletedProject, dbo.AccountParty.PartyNick AS ClientNick, dbo.AccountParty.EMailAddress AS ClientEMailAddress, 
                      dbo.AccountParty.Address1 AS ClientAddress1, dbo.AccountParty.Address2 AS ClientAddress2, dbo.AccountParty.State AS ClientState, 
                      dbo.AccountParty.City AS ClientCity, dbo.AccountParty.ZipCode AS ClientZipCode, dbo.AccountParty.Telephone1 AS ClientTelephone1, 
                      dbo.AccountParty.Telephone2 AS ClientTelephone2, dbo.AccountParty.Fax AS ClientFax, dbo.AccountEmployee.State AS EmployeeState, 
                      dbo.AccountEmployee.City AS EmployeeCity, dbo.AccountEmployee.Zip AS EmployeeZip, dbo.AccountEmployee.WorkPhoneNo AS EmployeeWorkPhoneNo, 
                      dbo.AccountEmployee.TerminationDate, dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.HiredDate, dbo.AccountBillingRate.BillingRate, 
                      dbo.AccountBillingRate.StartDate AS BillingRateStartDate, dbo.AccountBillingRate.EndDate AS BillingRateEndDate, dbo.AccountBillingRate.EmployeeRate, 
                      CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)'
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName 
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)'
					  ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, 
                      dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes
FROM         dbo.AccountProjectEmployee INNER JOIN
                      dbo.AccountProject ON dbo.AccountProjectEmployee.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountBillingType ON dbo.AccountProject.ProjectBillingTypeId = dbo.AccountBillingType.AccountBillingTypeId INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId INNER JOIN
                      dbo.AccountStatus ON dbo.AccountProject.ProjectStatusId = dbo.AccountStatus.AccountStatusId INNER JOIN
                      dbo.AccountProjectType ON dbo.AccountProject.AccountProjectTypeId = dbo.AccountProjectType.AccountProjectTypeId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND 
                      dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountBillingRate ON dbo.AccountProjectEmployee.AccountBillingRateId = dbo.AccountBillingRate.AccountBillingRateId LEFT OUTER JOIN
                      dbo.AccountPartyDepartment ON dbo.AccountProject.AccountPartyDepartmentId = dbo.AccountPartyDepartment.AccountPartyDepartmentId LEFT OUTER JOIN
                      dbo.AccountPartyContact ON dbo.AccountProject.AccountPartyContactId = dbo.AccountPartyContact.AccountPartyContactId LEFT OUTER JOIN
                      dbo.AccountHolidayType ON dbo.AccountEmployee.AccountHolidayTypeId = dbo.AccountHolidayType.AccountHolidayTypeId LEFT OUTER JOIN
                      dbo.AccountWorkingDayType ON dbo.AccountEmployee.AccountWorkingDayTypeId = dbo.AccountWorkingDayType.AccountWorkingDayTypeId LEFT OUTER JOIN
                      dbo.AccountTimeOffPolicy ON dbo.AccountEmployee.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId LEFT OUTER JOIN
                      dbo.AccountStatus AS AccountStatus_1 ON dbo.AccountEmployee.StatusId = AccountStatus_1.AccountStatusId LEFT OUTER JOIN
                      dbo.AccountEmployeeType ON dbo.AccountEmployee.EmployeePayTypeId = dbo.AccountEmployeeType.AccountEmployeeTypeId LEFT OUTER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId
WHERE     (dbo.AccountParty.IsDeleted <> 1) OR
                      (dbo.AccountParty.IsDeleted IS NULL)
GROUP BY dbo.AccountProjectEmployee.AccountProjectEmployeeId, dbo.AccountProjectEmployee.AccountId, dbo.AccountProjectEmployee.AccountProjectId, 
                      dbo.AccountProjectEmployee.AccountEmployeeId, dbo.AccountProjectEmployee.AccountRoleId, dbo.AccountProjectEmployee.AccountBillingRateId, 
                      dbo.AccountProjectEmployee.AccountProjectEmployeeTemplateId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, 
                      dbo.AccountProject.AccountClientId, dbo.AccountProject.ProjectName, dbo.AccountBillingType.BillingType, dbo.AccountDepartment.DepartmentName, 
                      dbo.AccountLocation.AccountLocation, dbo.AccountRole.Role, dbo.AccountEmployeeType.AccountEmployeeType, dbo.AccountParty.PartyName, 
                      dbo.AccountStatus.Status, AccountStatus_1.Status, dbo.AccountWorkingDayType.AccountWorkingDayType, dbo.AccountWorkingDayType.HoursPerDay, 
                      dbo.AccountWorkingDayType.MinimumHoursPerDay, dbo.AccountWorkingDayType.MaximumHoursPerDay, dbo.AccountWorkingDayType.MinimumHoursPerWeek, 
                      dbo.AccountWorkingDayType.MaximumHoursPerWeek, dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountHolidayType.AccountHolidayType, 
                      dbo.AccountPartyContact.FirstName, dbo.AccountPartyContact.LastName, dbo.AccountPartyDepartment.PartyDepartmentCode, 
                      dbo.AccountPartyDepartment.PartyDepartmentName, dbo.AccountPartyDepartment.PartyDepartmentLocation, dbo.AccountProject.ProjectStatusId, 
                      dbo.AccountProjectType.ProjectType, dbo.AccountProject.AccountProjectTypeId, dbo.AccountProject.ProjectDescription, dbo.AccountProject.StartDate, 
                      dbo.AccountProject.Deadline, dbo.AccountProject.EstimatedTime, dbo.AccountProject.EstimatedDuration, dbo.AccountProject.EstimatedDurationUnit, 
                      CASE WHEN ISNULL(dbo.AccountProject.ProjectPrefix, '') 
                      = '' THEN dbo.AccountProject.ProjectCode ELSE dbo.AccountProject.ProjectPrefix + '-' + dbo.AccountProject.ProjectCode END, dbo.AccountProject.DefaultBillingRate, 
                      dbo.AccountProject.Completed, dbo.AccountProject.IsDisabled, dbo.AccountProject.IsDeleted, dbo.AccountParty.PartyNick, dbo.AccountParty.EMailAddress, 
                      dbo.AccountParty.Address1, dbo.AccountParty.Address2, dbo.AccountParty.State, dbo.AccountParty.City, dbo.AccountParty.ZipCode, dbo.AccountParty.Telephone1, 
                      dbo.AccountParty.Telephone2, dbo.AccountParty.Fax, dbo.AccountEmployee.State, dbo.AccountEmployee.City, dbo.AccountEmployee.Zip, 
                      dbo.AccountEmployee.WorkPhoneNo, dbo.AccountEmployee.TerminationDate, dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.HiredDate, 
                      dbo.AccountBillingRate.BillingRate, dbo.AccountBillingRate.StartDate, dbo.AccountBillingRate.EndDate, dbo.AccountBillingRate.EmployeeRate, 
                      CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)'
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName 
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)'
					  ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END