
CREATE VIEW dbo.rptvueAccountEmployees
AS
SELECT     AccountEmployeeId, Password, Prefix, FirstName, LastName, MiddleName, EMailAddress, AccountId, AccountDepartmentId, AccountRoleId, 
                      AccountLocationId, Notes, AddressLine1 AS Address1, AddressLine2 AS Address2, State, City, Zip AS ZipCode, CountryId, HomePhoneNo, 
                      WorkPhoneNo, MobilePhoneNo, TimeEntryApprovalPathId, BillingRateStateDate, BillingTypeId, StartDate, TerminationDate, StatusId, IsDeleted, 
                      IsDisabled, DefaultProjectId, TimeZoneId, DefaultEmployee, CreatedOn, CreatedByEmployeeId, ModifiedOn, ModifiedByEmployeeId, 
                      AllowedAccessFromIP, ExternalUserClientId, EmployeeTypeId, AccountBillingRateId, Username, EmployeeCode, EmployeeManagerId, EmployeeName,
                       DepartmentCode, DepartmentName, Role, AccountLocation, Country, ISNULL(EmployeeManager, '') AS EmployeeManager, AccountWorkTypeCode, 
                      AccountWorkType, BillingRate, EmployeeRate, EmployeeRateCurrencyCode, BillingRateCurrencyCode, HiredDate, EmployeeStatus, EmployeeType, 
                      CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, 
                      CustomField11, CustomField12, CustomField13, CustomField14, CustomField15, AccountTimeOffPolicy, JobTitle
FROM         dbo.vueAccountEmployeesForReport
WHERE     (IsDeleted <> 1)