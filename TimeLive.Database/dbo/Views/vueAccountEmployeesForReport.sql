

CREATE VIEW [dbo].[vueAccountEmployeesForReport]
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.Password, dbo.AccountEmployee.Prefix, dbo.AccountEmployee.FirstName, 
                      dbo.AccountEmployee.LastName, ISNULL(dbo.AccountEmployee.MiddleName, N'') AS MiddleName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployee.AccountId, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountRoleId, 
                      dbo.AccountEmployee.AccountLocationId, ISNULL(dbo.AccountEmployee.Notes, N'') AS Notes, ISNULL(dbo.AccountEmployee.AddressLine1, N'') 
                      AS AddressLine1, ISNULL(dbo.AccountEmployee.AddressLine2, N'') AS AddressLine2, ISNULL(dbo.AccountEmployee.State, N'') AS State, 
                      ISNULL(dbo.AccountEmployee.City, N'') AS City, ISNULL(dbo.AccountEmployee.Zip, N'') AS Zip, dbo.AccountEmployee.CountryId, 
                      ISNULL(dbo.AccountEmployee.HomePhoneNo, N'') AS HomePhoneNo, ISNULL(dbo.AccountEmployee.WorkPhoneNo, N'') AS WorkPhoneNo, 
                      ISNULL(dbo.AccountEmployee.MobilePhoneNo, N'') AS MobilePhoneNo, dbo.AccountEmployee.TimeEntryApprovalPathId, 
                      dbo.AccountEmployee.BillingRateStateDate, dbo.AccountEmployee.BillingTypeId, dbo.AccountEmployee.StartDate, 
                      dbo.AccountEmployee.TerminationDate, dbo.AccountEmployee.StatusId, dbo.AccountEmployee.IsDeleted, dbo.AccountEmployee.IsDisabled, 
                      dbo.AccountEmployee.DefaultProjectId, dbo.AccountEmployee.TimeZoneId, dbo.AccountEmployee.DefaultEmployee, dbo.AccountEmployee.CreatedOn, 
                      dbo.AccountEmployee.CreatedByEmployeeId, dbo.AccountEmployee.ModifiedOn, dbo.AccountEmployee.ModifiedByEmployeeId, 
                      dbo.AccountEmployee.AllowedAccessFromIP, dbo.AccountEmployee.ExternalUserClientId, dbo.AccountEmployee.EmployeeTypeId, 
                      dbo.AccountEmployee.AccountBillingRateId, dbo.AccountEmployee.Username, ISNULL(dbo.AccountEmployee.EmployeeCode, N'') AS EmployeeCode, 
                      dbo.AccountEmployee.EmployeeManagerId, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disabled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disabled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, ISNULL(dbo.AccountDepartment.DepartmentCode, N'') AS DepartmentCode, dbo.AccountDepartment.DepartmentName, 
                       dbo.AccountRole.Role, dbo.AccountLocation.AccountLocation, ISNULL(dbo.SystemCountry.Country, N'') AS Country, ISNULL(AccountEmployee_1.FirstName + N' ' + AccountEmployee_1.LastName, N'') AS EmployeeManager, 
                      ISNULL(dbo.vueAccountWorkTypeBillingRate.AccountWorkTypeCode, N'') AS AccountWorkTypeCode, 
                      ISNULL(dbo.vueAccountWorkTypeBillingRate.AccountWorkType, N'') AS AccountWorkType, ISNULL(dbo.vueAccountWorkTypeBillingRate.BillingRate, 0)
                       AS BillingRate, ISNULL(dbo.vueAccountWorkTypeBillingRate.EmployeeRate, 0) AS EmployeeRate, 
                      dbo.vueAccountWorkTypeBillingRate.EmployeeRateCurrencyCode, dbo.vueAccountWorkTypeBillingRate.BillingRateCurrencyCode, 
                      dbo.AccountEmployee.HiredDate, ISNULL(dbo.AccountStatus.Status, N'') AS EmployeeStatus, 
                      ISNULL(dbo.AccountEmployeeType.AccountEmployeeType, N'') AS EmployeeType, dbo.AccountEmployee.CustomField1, 
                      dbo.AccountEmployee.CustomField2, dbo.AccountEmployee.CustomField3, dbo.AccountEmployee.CustomField4, dbo.AccountEmployee.CustomField5, 
                      dbo.AccountEmployee.CustomField6, dbo.AccountEmployee.CustomField7, dbo.AccountEmployee.CustomField8, dbo.AccountEmployee.CustomField9, 
                      dbo.AccountEmployee.CustomField10, dbo.AccountEmployee.CustomField11, dbo.AccountEmployee.CustomField12, 
                      dbo.AccountEmployee.CustomField13, dbo.AccountEmployee.CustomField14, dbo.AccountEmployee.CustomField15, 
                      dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountApprovalType.ApprovalTypeName AS TimeOffApprovalType, 
                      ISNULL(dbo.AccountEmployee.JobTitle, N'') As JobTitle
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId AND 
                      dbo.Account.AccountId = dbo.AccountDepartment.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId AND 
                      dbo.Account.AccountId = dbo.AccountRole.AccountId INNER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId AND 
                      dbo.Account.AccountId = dbo.AccountLocation.AccountId INNER JOIN
                      dbo.AccountPreferences ON dbo.Account.AccountId = dbo.AccountPreferences.AccountId INNER JOIN
                      dbo.SystemCountry ON dbo.AccountEmployee.CountryId = dbo.SystemCountry.CountryId LEFT OUTER JOIN
                      dbo.AccountApprovalType ON dbo.AccountEmployee.TimeOffApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.Account.AccountId = AccountEmployee_1.AccountId AND 
                      dbo.AccountEmployee.EmployeeManagerId = AccountEmployee_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountTimeOffPolicy ON dbo.AccountEmployee.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId LEFT OUTER JOIN
                      dbo.AccountEmployeeType ON dbo.AccountEmployee.EmployeePayTypeId = dbo.AccountEmployeeType.AccountEmployeeTypeId LEFT OUTER JOIN
                      dbo.AccountStatus ON dbo.AccountEmployee.StatusId = dbo.AccountStatus.AccountStatusId AND 
                      dbo.Account.AccountId = dbo.AccountStatus.AccountId LEFT OUTER JOIN
                      dbo.vueAccountWorkTypeBillingRate ON dbo.Account.AccountId = dbo.vueAccountWorkTypeBillingRate.AccountId AND 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountWorkTypeBillingRate.AccountEmployeeId
WHERE     (dbo.AccountEmployee.EmployeeTypeId IS NULL)