
CREATE VIEW dbo.vueExternalAccountEmployee
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.AccountId, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.Password, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountLocationId, dbo.AccountEmployee.BillingTypeId, 
                      dbo.AccountBillingType.BillingType, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, 
                      dbo.AccountPreferences.ShowClockStartEnd, dbo.Account.TimeZoneId, dbo.AccountRole.MasterAccountRoleId, dbo.Account.DefaultCurrencyId, dbo.Account.CountryId, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.TimeEntryFormat, dbo.AccountEmployee.AllowedAccessFromIP, dbo.AccountRole.AccountRoleId, 
                      dbo.AccountPreferences.AccountSessionTimeout, dbo.AccountPreferences.ShowCompletedTasksInTimeSheet, dbo.AccountPreferences.CurrencySymbol, 
                      dbo.AccountPreferences.IsCompanyOwnLogo, dbo.Account.AccountExpiryActivation, dbo.Account.LicenseActivation, dbo.AccountEmployee.EmployeeTypeId, 
                      dbo.AccountEmployee.ExternalUserClientId, dbo.AccountParty.PartyName, dbo.AccountParty.PartyNick, dbo.AccountEmployee.IsDisabled, 
                      dbo.AccountEmployee.IsDeleted, dbo.AccountParty.IsDeleted AS IsDeletedClient
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountEmployee.ExternalUserClientId = dbo.AccountParty.AccountPartyId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId