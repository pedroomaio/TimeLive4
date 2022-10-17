
CREATE VIEW dbo.vueAccount
AS
SELECT     dbo.Account.AccountId, dbo.Account.AccountTypeId, dbo.Account.AccountName, dbo.Account.Address1, dbo.Account.Address2, dbo.Account.ZipCode, 
                      dbo.Account.State, dbo.Account.City, dbo.Account.CountryId, dbo.Account.EMailAddress, dbo.Account.Telephone, dbo.Account.Fax, 
                      dbo.Account.DefaultCurrencyId, dbo.Account.TimeZoneId, dbo.Account.IsDisabled, dbo.Account.IsDeleted, dbo.Account.StatusId, 
                      dbo.Account.CreatedOn, dbo.Account.ModifiedOn, dbo.Account.ModifiedByEmployeeId, dbo.AccountPreferences.ShowClockStartEnd, 
                      dbo.AccountPreferences.AccountPreferencesId, dbo.Account.LicenseKey, dbo.Account.SystemPackageTypeId, 
                      dbo.AccountPreferences.TimeEntryFormat, dbo.AccountPreferences.FromEmailAddress, dbo.AccountPreferences.FromEmailAddressDisplayName, 
                      dbo.Account.MachineId, dbo.Account.ActivationLicenseKey, dbo.Account.ActivationMachineKey, dbo.Account.ActivationType, 
                      dbo.AccountPreferences.ShowClientInTimesheet, dbo.AccountPreferences.InvoiceBillingTypeId, 
                      dbo.AccountPreferences.ShowBillingRateInInvoiceReport, dbo.AccountPreferences.InvoiceFooter, 
                      dbo.AccountPreferences.ShowProjectNameInInvoiceReport, dbo.AccountPreferences.ProjectCodePrefix, 
                      dbo.AccountPreferences.AutoGenerateProjectCode, dbo.AccountPreferences.TimeEntryHoursFormatId, 
                      dbo.AccountPreferences.ShowPercentageInTimesheet, dbo.AccountPreferences.EnablePasswordComplexity, 
                      dbo.AccountPreferences.ShowClientDepartmentInProject, dbo.AccountPreferences.ShowEntryDateInInvoiceReport, 
                      dbo.AccountPreferences.TimesheetSort, dbo.AccountPreferences.ShowCostCenterInTimesheetBy, dbo.AccountPreferences.ShowCopyTimesheetButton, 
                      dbo.AccountPreferences.ShowCopyActivitiesButtonInTimesheet, dbo.AccountPreferences.ShowProjectNameInTask, 
                      dbo.AccountPreferences.ShowClientNameInTask, dbo.AccountPreferences.IsShowElectronicSign, 
                      dbo.AccountPreferences.ShowCompletedProjectInProjectGrid, dbo.AccountPreferences.ShowEmployeeNameInInvoiceReport, 
                      dbo.AccountPreferences.CalculateTaskPercentageAutomatically, dbo.Account.IsLock, dbo.AccountPreferences.IncludeCurrentYearInProjectCode, 
                      dbo.AccountPreferences.ShowAdditionalProjectInformationType, dbo.AccountPreferences.EnableOfflineTimesheet, 
                      dbo.AccountPreferences.ShowWorkTypeInInvoiceDescription, dbo.AccountPreferences.ShowClientInExpenseSheet, 
                      dbo.AccountPreferences.AutomaticallyIncludeAdminitratorInProjectTeam, dbo.AccountPreferences.ShowAdditionalDepartmentInformationInEmployee, 
                      dbo.AccountPreferences.DefaultProjectTaskSelectionInTimesheet, dbo.AccountPreferences.InsertDefaultTaskNameInProject, 
                      dbo.AccountPreferences.DefaultTaskName, dbo.AccountPreferences.RoundOffValueInInvoice, dbo.AccountPreferences.IsProjectTemplateMandatory, 
                      dbo.AccountPreferences.ShowDisableProjectInReport, dbo.AccountPreferences.GoogleAppsDomain, 
                      dbo.AccountPreferences.IsShowEmployeeNameWithCode, dbo.AccountPreferences.EnableGoogleAuthentication, 
                      dbo.AccountPreferences.IsShowDisableEmployeesInReport, dbo.AccountPreferences.SortTaskBy, dbo.AccountPreferences.ShowTimeOffTypesBy, 
                      dbo.AccountPreferences.ShowClockStartEndBy, dbo.AccountPreferences.IsTimeOffStatusEditMode, 
                      dbo.AccountPreferences.IsShowTimeOffInDays
FROM         dbo.Account INNER JOIN
                      dbo.AccountPreferences ON dbo.Account.AccountId = dbo.AccountPreferences.AccountId