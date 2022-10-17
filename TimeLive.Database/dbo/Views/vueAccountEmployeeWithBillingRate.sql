CREATE VIEW dbo.vueAccountEmployeeWithBillingRate
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.Password, dbo.AccountEmployee.Prefix, dbo.AccountEmployee.FirstName, 
                      dbo.AccountEmployee.LastName, dbo.AccountEmployee.MiddleName, dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.AccountId, 
                      dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountRoleId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.Notes, dbo.AccountEmployee.AddressLine1, dbo.AccountEmployee.AddressLine2, dbo.AccountEmployee.State, 
                      dbo.AccountEmployee.City, dbo.AccountEmployee.Zip, dbo.AccountEmployee.CountryId, dbo.AccountEmployee.HomePhoneNo, 
                      dbo.AccountEmployee.WorkPhoneNo, dbo.AccountEmployee.MobilePhoneNo, dbo.AccountEmployee.TimeEntryApprovalPathId, 
                      dbo.AccountEmployee.BillingRateStateDate, dbo.AccountEmployee.BillingTypeId, dbo.AccountEmployee.StartDate, 
                      dbo.AccountEmployee.TerminationDate, dbo.AccountEmployee.StatusId, dbo.AccountEmployee.IsDeleted, dbo.AccountEmployee.IsDisabled, 
                      dbo.AccountEmployee.DefaultProjectId, dbo.AccountEmployee.TimeZoneId, dbo.AccountEmployee.DefaultEmployee, dbo.AccountEmployee.CreatedOn, 
                      dbo.AccountEmployee.CreatedByEmployeeId, dbo.AccountEmployee.ModifiedOn, dbo.AccountEmployee.ModifiedByEmployeeId, 
                      dbo.AccountEmployee.AllowedAccessFromIP, dbo.AccountEmployee.ExternalUserClientId, dbo.AccountEmployee.EmployeeTypeId, 
                      dbo.AccountEmployee.Username, dbo.AccountEmployee.EmployeeCode, dbo.AccountWorkTypeBillingRate.SystemBillingRateTypeId, 
                      dbo.AccountBillingRate.BillingRate, dbo.AccountBillingRate.EmployeeRate, dbo.AccountBillingRate.AccountBillingRateId, 
                      dbo.AccountWorkType.AccountWorkTypeId, dbo.AccountBillingRate.StartDate AS BillingRateStartDate, 
                      dbo.AccountBillingRate.EndDate AS BillingRateEndDate, dbo.AccountBillingRate.BillingRateCurrencyId, 
                      dbo.AccountBillingRate.EmployeeRateCurrencyId
FROM         dbo.AccountBillingRate RIGHT OUTER JOIN
                      dbo.AccountWorkTypeBillingRate ON 
                      dbo.AccountBillingRate.AccountBillingRateId = dbo.AccountWorkTypeBillingRate.AccountBillingRateId RIGHT OUTER JOIN
                      dbo.AccountEmployee LEFT OUTER JOIN
                      dbo.AccountWorkType ON dbo.AccountEmployee.AccountId = dbo.AccountWorkType.AccountId ON 
                      dbo.AccountWorkTypeBillingRate.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId AND 
                      dbo.AccountWorkTypeBillingRate.AccountWorkTypeId = dbo.AccountWorkType.AccountWorkTypeId