
CREATE VIEW dbo.vueAccountEmployeeForQB
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
                      dbo.AccountEmployee.AccountBillingRateId, dbo.AccountEmployee.Username, dbo.AccountEmployee.EmployeeCode, 
                      dbo.AccountEmployee.EmployeeManagerId, dbo.AccountEmployee.JobTitle, dbo.AccountEmployee.EmployeePayTypeId, 
                      dbo.AccountEmployee.HiredDate, dbo.AccountEmployee.AccountWorkingDayTypeId, dbo.AccountEmployee.LastScheduledEmailSentTime, 
                      dbo.AccountEmployee.AccountTimeOffPolicyId, dbo.AccountEmployee.TimeOffApprovalTypeId, 
                      dbo.AccountEmployee.LastTimeOffCalculationScheduledTime, dbo.AccountEmployee.InitialPolicy, dbo.AccountEmployee.AccountHolidayTypeId, 
                      dbo.AccountEmployee.IsEmailSend, dbo.AccountEmployee.IsForcePasswordChange, dbo.AccountEmployee.PasswordChangedDate, 
                      dbo.AccountEmployeeType.IsVendor, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS FullName
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.AccountEmployeeType ON dbo.AccountEmployee.EmployeePayTypeId = dbo.AccountEmployeeType.AccountEmployeeTypeId