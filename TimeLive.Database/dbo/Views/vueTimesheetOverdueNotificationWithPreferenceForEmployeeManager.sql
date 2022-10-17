CREATE VIEW dbo.vueTimesheetOverdueNotificationWithPreferenceForEmployeeManager
AS
SELECT     dbo.AccountPreferences.ScheduledEmailSendTime, MAX(AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName) AS EmployeeName, 
                      dbo.AccountEmployee.AccountId, CASE WHEN MAX(dbo.AccountPreferences.CultureInfoName) IS NULL OR
                      MAX(dbo.AccountPreferences.CultureInfoName) = 'auto' THEN 'en-us' ELSE MAX(dbo.AccountPreferences.CultureInfoName) END AS CultureInfoName, 
                      ISNULL(MAX(dbo.vueAccountWorkingDayType.TimesheetOverdueAfterDays), 1) AS TimesheetOverdueAfterDays, AccountEmployee_1.AccountEmployeeId, 
                      AccountEmployee_1.EMailAddress, AccountEmployee_1.LastScheduledEmailSentTime, ISNULL(MAX(dbo.vueAccountWorkingDayType.SystemTimesheetPeriodType), 
                      'Weekly') AS SystemTimesheetPeriodType, ISNULL(MAX(dbo.vueAccountWorkingDayType.WeekStartDay), 1) AS WeekStartDay, 
                      ISNULL(MAX(dbo.vueAccountWorkingDayType.SystemInitialDayOfFirstPeriod), 1) AS SystemInitialDayOfFirstPeriod, 
                      ISNULL(MAX(dbo.vueAccountWorkingDayType.SystemInitialDayOfLastPeriod), 16) AS SystemInitialDayOfLastPeriod, 
                      ISNULL(MAX(dbo.vueAccountWorkingDayType.InitialDayOfTheMonth), 1) AS InitialDayOfTheMonth
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountEmployee.EmployeeManagerId = AccountEmployee_1.AccountEmployeeId INNER JOIN
                      dbo.vueAccountWorkingDayType ON AccountEmployee_1.AccountWorkingDayTypeId = dbo.vueAccountWorkingDayType.AccountWorkingDayTypeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.AccountEmployee.EmployeeManagerId = AccountEMailNotificationPreference_2.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON dbo.AccountEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId
WHERE     (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 64) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 63) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (dbo.AccountEmployee.EmployeeTypeId <> 2 OR
                      dbo.AccountEmployee.EmployeeTypeId IS NULL) AND (AccountEmployee_1.IsDeleted <> 1) AND (AccountEmployee_1.IsDisabled <> 1)
GROUP BY dbo.AccountPreferences.ScheduledEmailSendTime, dbo.AccountEmployee.AccountId, AccountEmployee_1.AccountEmployeeId, AccountEmployee_1.EMailAddress, 
                      AccountEmployee_1.LastScheduledEmailSentTime