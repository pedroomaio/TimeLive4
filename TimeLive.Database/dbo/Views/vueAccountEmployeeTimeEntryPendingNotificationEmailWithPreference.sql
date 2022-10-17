
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreference
AS
SELECT     dbo.AccountPreferences.ScheduledEmailSendTime, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.AccountId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployee.LastScheduledEmailSentTime, dbo.AccountEMailNotificationPreference.Monday, 
                      dbo.AccountEMailNotificationPreference.Tuesday, dbo.AccountEMailNotificationPreference.Wednesday, 
                      dbo.AccountEMailNotificationPreference.Thursday, dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, 
                      dbo.AccountEMailNotificationPreference.Sunday, dbo.vueAccountWorkingDayType.HoursPerDay, 
                      dbo.vueAccountWorkingDayType.WeekStartDay AS EmployeeWeekStartDay, dbo.vueAccountWorkingDayType.SystemTimesheetPeriodTypeId, 
                      dbo.vueAccountWorkingDayType.SystemInitialDaysOfThePeriodId, ISNULL(dbo.vueAccountWorkingDayType.InitialDayOfTheMonth, 1) 
                      AS InitialDayOfTheMonth, dbo.vueAccountWorkingDayType.SystemTimesheetPeriodType, 
                      dbo.vueAccountWorkingDayType.SystemInitialDaysOfThePeriod, ISNULL(dbo.vueAccountWorkingDayType.SystemInitialDayOfFirstPeriod, 1) 
                      AS SystemInitialDayOfFirstPeriod, ISNULL(dbo.vueAccountWorkingDayType.SystemInitialDayOfLastPeriod, 16) AS SystemInitialDayOfLastPeriod,
	        CASE WHEN dbo.AccountPreferences.CultureInfoName IS NULL OR
                      dbo.AccountPreferences.CultureInfoName = 'auto' THEN 'en-us' ELSE dbo.AccountPreferences.CultureInfoName END AS CultureInfoName
FROM         dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 RIGHT OUTER JOIN
                      dbo.vueAccountWorkingDayType RIGHT OUTER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountWorkingDayType.AccountWorkingDayTypeId = dbo.AccountEmployee.AccountWorkingDayTypeId ON 
                      AccountEMailNotificationPreference_2.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON dbo.AccountEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId
WHERE     (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 30) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 29) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (dbo.AccountEmployee.EmployeeTypeId <> 2 OR
                      dbo.AccountEmployee.EmployeeTypeId IS NULL) AND (dbo.AccountEmployee.IsDeleted <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1)