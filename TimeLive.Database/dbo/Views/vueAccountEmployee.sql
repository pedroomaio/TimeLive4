

CREATE VIEW [dbo].[vueAccountEmployee]
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.AccountId, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.Password, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.BillingTypeId, dbo.AccountBillingType.BillingType, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, dbo.AccountPreferences.ShowClockStartEnd, dbo.Account.TimeZoneId, 
                      dbo.AccountRole.MasterAccountRoleId, dbo.Account.DefaultCurrencyId, dbo.Account.CountryId, dbo.AccountPreferences.CultureInfoName, 
                      dbo.AccountPreferences.TimeEntryFormat, dbo.AccountEmployee.AllowedAccessFromIP, dbo.AccountRole.AccountRoleId, 
                      dbo.AccountPreferences.AccountSessionTimeout, dbo.AccountPreferences.ShowCompletedTasksInTimeSheet, 
                      dbo.AccountPreferences.CurrencySymbol, dbo.AccountPreferences.IsCompanyOwnLogo, dbo.Account.AccountExpiryActivation, 
                      dbo.Account.LicenseActivation, dbo.AccountEmployee.EmployeeTypeId, dbo.AccountEmployee.ExternalUserClientId, 
                      dbo.AccountEmployee.AccountBillingRateId, dbo.AccountPreferences.ScheduledEmailSendTime, dbo.AccountEmployee.Username, 
                      dbo.AccountEmployee.IsDisabled, dbo.AccountPreferences.FromEmailAddress, dbo.AccountPreferences.FromEmailAddressDisplayName, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountPreferences.Version, dbo.AccountPreferences.LockSubmittedRecords, 
                      dbo.AccountPreferences.LockApprovedRecords, ISNULL(dbo.AccountDepartment.DepartmentCode + ' - ', '') 
                      + dbo.AccountDepartment.DepartmentName AS Department, CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                      + dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disabled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2
                       AND dbo.AccountEmployee.IsDisabled = 0 THEN ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                      + dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ', '') 
                      + dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disabled)' ELSE ISNULL(dbo.AccountEmployee.EmployeeCode + ' - ',
                       '') + dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS EmployeeNameWithCode, 
                      dbo.AccountPreferences.ShowWorkTypeInTimeSheet, dbo.AccountPreferences.NumberOfBlankRowsInTimeEntry, 
                      dbo.AccountPreferences.ShowCostCenterInTimeSheet, dbo.AccountPreferences.WeekStartDay, dbo.AccountPreferences.AccountBaseCurrencyId, 
                      dbo.AccountEmployee.UserInterfaceLanguage, dbo.AccountEmployee.EmployeeManagerId, dbo.AccountPreferences.DefaultTimeEntryMode, 
                      dbo.AccountPreferences.PageSize, dbo.AccountEmployee.TimeZoneId AS EmployeeTimeZoneId, dbo.AccountEmployee.TerminationDate, 
                      dbo.AccountEmployee.StatusId, dbo.AccountEmployee.JobTitle, dbo.AccountEmployee.EmployeePayTypeId, dbo.AccountEmployee.HiredDate, 
                      dbo.AccountEmployee.AccountWorkingDayTypeId, dbo.AccountWorkingDayType.AccountWorkingDayType, dbo.AccountWorkingDayType.HoursPerDay, 
                      dbo.AccountWorkingDayType.WeekStartDay AS EmployeeWeekStartDay, dbo.AccountPreferences.ShowClientInTimesheet, 
                      dbo.AccountWorkingDayType.MinimumHoursPerDay, dbo.AccountWorkingDayType.MaximumHoursPerDay, 
                      dbo.AccountWorkingDayType.MinimumHoursPerWeek, dbo.AccountWorkingDayType.MaximumHoursPerWeek, 
                      dbo.AccountPreferences.ShowDescriptionInWeekView, dbo.AccountPreferences.InvoiceNoPrefix, 
                      dbo.AccountPreferences.ShowAdditionalTaskInformationType, dbo.vueAccountTimesheetPeriodType.SystemTimesheetPeriodTypeId, 
                      dbo.vueAccountTimesheetPeriodType.SystemInitialDaysOfThePeriodId, ISNULL(dbo.vueAccountTimesheetPeriodType.InitialDayOfTheMonth, 1) 
                      AS InitialDayOfTheMonth, dbo.vueAccountTimesheetPeriodType.SystemTimesheetPeriodType, 
                      dbo.vueAccountTimesheetPeriodType.SystemInitialDaysOfThePeriod, ISNULL(dbo.vueAccountTimesheetPeriodType.SystemInitialDayOfFirstPeriod, 1) 
                      AS SystemInitialDayOfFirstPeriod, ISNULL(dbo.vueAccountTimesheetPeriodType.SystemInitialDayOfLastPeriod, 16) AS SystemInitialDayOfLastPeriod, 
                      dbo.AccountEmployee.LastScheduledEmailSentTime, dbo.AccountPreferences.TimesheetPrintFooter, 
                      dbo.AccountPreferences.ExpenseSheetPrintFooter, dbo.AccountPreferences.ShowCompletedProjectsInTimeSheet, 
                      dbo.AccountPreferences.ShowProjectForTimeOff, dbo.AccountPreferences.ShowTimeOffInTimesheet, dbo.AccountEmployee.IsDeleted, 
                      dbo.AccountEmployee.IsForcePasswordChange, dbo.AccountEmployee.PasswordChangedDate, dbo.AccountPreferences.PasswordExpiryPeriod, 
                      dbo.AccountPreferences.ShowAllInTimesheetReadOnly, dbo.AccountPreferences.ShowTaskInExpenseSheet, 
                      dbo.AccountPreferences.InvoiceBillingTypeId, dbo.AccountPreferences.ShowBillingRateInInvoiceReport, 
                      dbo.SystemInvoiceBillingType.InvoiceBillingType, dbo.AccountPreferences.InvoiceFooter, dbo.AccountPreferences.TimesheetOverduePeriods, 
                      dbo.AccountWorkingDayType.TimesheetOverdueAfterDays, dbo.AccountEmployee.CreatedOn, dbo.AccountEmployee.CreatedByEmployeeId, 
                      dbo.AccountEmployee.ModifiedOn, dbo.AccountEmployee.ModifiedByEmployeeId, dbo.AccountPreferences.ShowProjectNameInInvoiceReport, 
                      dbo.AccountPreferences.ProjectCodePrefix, dbo.AccountPreferences.AutoGenerateProjectCode, dbo.AccountPreferences.TimeEntryHoursFormatId, 
                      dbo.AccountPreferences.ShowPercentageInTimesheet, dbo.AccountPreferences.EnablePasswordComplexity, 
                      dbo.AccountPreferences.ShowClientDepartmentInProject, dbo.AccountPreferences.ShowEntryDateInInvoiceReport, 
                      dbo.AccountPreferences.TimesheetSort, dbo.AccountPreferences.ShowCostCenterInTimesheetBy, dbo.AccountPreferences.ShowCopyTimesheetButton, 
                      dbo.AccountPreferences.ShowCopyActivitiesButtonInTimesheet, dbo.AccountPreferences.ShowProjectNameInTask, 
                      dbo.AccountPreferences.ShowClientNameInTask, dbo.AccountPreferences.IsShowElectronicSign, 
                      ISNULL(dbo.AccountWorkingDayType.MinimumPercentagePerDay, 0) AS MinimumPercentagePerDay, 
                      ISNULL(dbo.AccountWorkingDayType.MaximumPercentagePerDay, 100) AS MaximumPercentagePerDay, 
                      ISNULL(dbo.AccountWorkingDayType.MinimumPercentagePerWeek, 0) AS MinimumPercentagePerWeek, 
                      ISNULL(dbo.AccountWorkingDayType.MaximumPercentagePerWeek, 500) AS MaximumPercentagePerWeek, 
                      dbo.AccountPreferences.ShowCompletedProjectInProjectGrid, dbo.AccountPreferences.ShowEmployeeNameInInvoiceReport, 
                      dbo.AccountPreferences.CalculateTaskPercentageAutomatically, dbo.AccountWorkingDayType.LockAllPreviousTimesheets, 
                      dbo.AccountWorkingDayType.LockAllFutureTimesheets, dbo.AccountWorkingDayType.LockPreviousTimesheetPeriods, 
                      dbo.AccountWorkingDayType.LockFutureTimsheetPeriods, dbo.AccountWorkingDayType.LockPreviousNextMonthTimesheetOn, 
                      dbo.AccountWorkingDayType.EnableBalanceValidationForTimeOff, dbo.Account.IsLock, dbo.AccountPreferences.IncludeCurrentYearInProjectCode, 
                      dbo.AccountPreferences.ShowAdditionalProjectInformationType, dbo.AccountWorkingDayType.LockAllPeriodExceptPrevious, 
                      dbo.AccountWorkingDayType.LockAllPeriodExceptNext, dbo.AccountPreferences.EnableOfflineTimesheet, 
                      dbo.AccountEmployee.IsShowEmployeeProfilePicture, dbo.AccountPreferences.ShowWorkTypeInInvoiceDescription, 
                      dbo.AccountPreferences.ShowClientInExpenseSheet, dbo.AccountPreferences.AutomaticallyIncludeAdminitratorInProjectTeam, 
                      dbo.AccountPreferences.ShowAdditionalDepartmentInformationInEmployee, dbo.AccountDepartment.DepartmentCode, 
                      dbo.AccountPreferences.DefaultProjectTaskSelectionInTimesheet, dbo.AccountPreferences.InsertDefaultTaskNameInProject, 
                      dbo.AccountPreferences.DefaultTaskName, dbo.AccountEmployee.OpenIDClaimIdentifier, dbo.AccountEmployee.OpenIDSource, 
                      dbo.AccountPreferences.RoundOffValueInInvoice, dbo.AccountPreferences.IsProjectTemplateMandatory, 
                      dbo.AccountPreferences.ShowDisableProjectInReport, dbo.AccountPreferences.GoogleAppsDomain, 
                      dbo.AccountPreferences.IsShowEmployeeNameWithCode, dbo.AccountPreferences.EnableGoogleAuthentication, 
                      dbo.AccountPreferences.IsShowDisableEmployeesInReport, dbo.AccountPreferences.SortTaskBy, dbo.AccountPreferences.ShowTimeOffTypesBy, 
                      dbo.AccountPreferences.ShowClockStartEndBy, dbo.AccountWorkingDayType.ShowClockStartEndEmployee, 
                      dbo.AccountPreferences.IsTimeOffStatusEditMode, dbo.AccountEmployee.IsTimeInOutAvailable, dbo.AccountPreferences.AutoResizeTimesheet, 
                      dbo.AccountPreferences.ShowEmployeeNameBy, dbo.AccountPreferences.HideProjectFromApplication, 
                      dbo.AccountPreferences.ShowProjectInTimesheet, dbo.AccountPreferences.IsShowTimeOffInDays, dbo.AccountPreferences.EnableTaskHoursValidation,
                      dbo.AccountPreferences.EnableSingleSignonSSO, dbo.AccountPreferences.SAMLSSOURL, dbo.AccountPreferences.IsAllowOverlappingTimeEntries
FROM         dbo.SystemInvoiceBillingType RIGHT OUTER JOIN
                      dbo.AccountPreferences ON dbo.SystemInvoiceBillingType.InvoiceBillingTypeId = dbo.AccountPreferences.InvoiceBillingTypeId RIGHT OUTER JOIN
                      dbo.vueAccountTimesheetPeriodType RIGHT OUTER JOIN
                      dbo.AccountWorkingDayType ON 
                      dbo.vueAccountTimesheetPeriodType.AccountTimesheetPeriodTypeId = dbo.AccountWorkingDayType.AccountTimesheetPeriodTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId ON 
                      dbo.AccountWorkingDayType.AccountWorkingDayTypeId = dbo.AccountEmployee.AccountWorkingDayTypeId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId ON 
                      dbo.AccountPreferences.AccountId = dbo.AccountEmployee.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId