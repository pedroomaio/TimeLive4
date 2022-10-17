
CREATE VIEW dbo.vueAccountExternalUserForReport
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId AS ExternalUserId, dbo.AccountEmployee.Password, dbo.AccountEmployee.Prefix, dbo.AccountEmployee.FirstName, 
                      dbo.AccountEmployee.LastName, ISNULL(dbo.AccountEmployee.MiddleName, N'') AS MiddleName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployee.AccountId, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountRoleId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.Notes, dbo.AccountEmployee.AddressLine1, dbo.AccountEmployee.AddressLine2, dbo.AccountEmployee.State, dbo.AccountEmployee.City, 
                      dbo.AccountEmployee.Zip, dbo.AccountEmployee.CountryId, dbo.AccountEmployee.HomePhoneNo, dbo.AccountEmployee.WorkPhoneNo, 
                      dbo.AccountEmployee.MobilePhoneNo, dbo.AccountEmployee.TimeEntryApprovalPathId, dbo.AccountEmployee.BillingRateStateDate, 
                      dbo.AccountEmployee.BillingTypeId, dbo.AccountEmployee.StartDate, dbo.AccountEmployee.TerminationDate, dbo.AccountEmployee.StatusId, 
                      dbo.AccountEmployee.IsDeleted, dbo.AccountEmployee.IsDisabled, dbo.AccountEmployee.DefaultProjectId, dbo.AccountEmployee.TimeZoneId, 
                      dbo.AccountEmployee.DefaultEmployee, dbo.AccountEmployee.CreatedOn, dbo.AccountEmployee.CreatedByEmployeeId, dbo.AccountEmployee.ModifiedOn, 
                      dbo.AccountEmployee.ModifiedByEmployeeId, dbo.AccountEmployee.AllowedAccessFromIP, dbo.AccountEmployee.ExternalUserClientId AS AccountClientId, 
                      dbo.AccountEmployee.EmployeeTypeId, dbo.AccountEmployee.AccountBillingRateId, dbo.AccountEmployee.Username, dbo.AccountEmployee.EmployeeCode, 
                      dbo.AccountEmployee.EmployeeManagerId, ISNULL(dbo.AccountParty.PartyNick, N'') AS ClientNick, dbo.AccountParty.PartyName AS ClientName, 
                      dbo.AccountRole.Role, dbo.AccountEmployee.FirstName + N' ' + dbo.AccountEmployee.LastName AS ExternalUser
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.AccountParty ON dbo.AccountEmployee.ExternalUserClientId = dbo.AccountParty.AccountPartyId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId
WHERE     (dbo.AccountEmployee.EmployeeTypeId = 2) AND (dbo.AccountParty.IsDeleted <> 1 OR
                      dbo.AccountParty.IsDeleted IS NULL)