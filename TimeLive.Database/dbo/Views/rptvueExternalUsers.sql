
CREATE VIEW dbo.rptvueExternalUsers
AS
SELECT     ExternalUserId, Password, Prefix, FirstName, LastName, MiddleName, EMailAddress, AccountId, AccountDepartmentId, AccountRoleId, AccountLocationId, Notes, 
                      AddressLine1, AddressLine2, State, City, Zip, CountryId, HomePhoneNo, WorkPhoneNo, MobilePhoneNo, TimeEntryApprovalPathId, BillingRateStateDate, 
                      BillingTypeId, StartDate, TerminationDate, StatusId, IsDeleted, IsDisabled, DefaultProjectId, TimeZoneId, DefaultEmployee, CreatedOn, CreatedByEmployeeId, 
                      ModifiedOn, ModifiedByEmployeeId, AllowedAccessFromIP, AccountClientId, EmployeeTypeId, AccountBillingRateId, Username, EmployeeCode, EmployeeManagerId, 
                      ClientNick, ClientName, Role, ExternalUser
FROM         dbo.vueAccountExternalUserForReport
WHERE     (IsDeleted <> 1)