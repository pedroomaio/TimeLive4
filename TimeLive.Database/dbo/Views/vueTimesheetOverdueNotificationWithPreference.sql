
CREATE VIEW dbo.vueTimesheetOverdueNotificationWithPreference
AS
SELECT     dbo.AccountPreferences.ScheduledEmailSendTime, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.AccountId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployee.LastScheduledEmailSentTime, CASE WHEN dbo.AccountPreferences.CultureInfoName IS NULL OR
                      dbo.AccountPreferences.CultureInfoName = 'auto' THEN 'en-us' ELSE dbo.AccountPreferences.CultureInfoName END AS CultureInfoName, 
                      ISNULL(dbo.vueAccountWorkingDayType.TimesheetOverdueAfterDays, 1) AS TimesheetOverdueAfterDays, 
                      ISNULL(dbo.vueAccountWorkingDayType.SystemTimesheetPeriodType, 'Weekly') AS SystemTimesheetPeriodType, 
                      ISNULL(dbo.vueAccountWorkingDayType.WeekStartDay, 1) AS WeekStartDay, ISNULL(dbo.vueAccountWorkingDayType.SystemInitialDayOfFirstPeriod, 1) 
                      AS SystemInitialDayOfFirstPeriod, ISNULL(dbo.vueAccountWorkingDayType.SystemInitialDayOfLastPeriod, 16) AS SystemInitialDayOfLastPeriod, 
                      ISNULL(dbo.vueAccountWorkingDayType.InitialDayOfTheMonth, 1) AS InitialDayOfTheMonth
FROM         dbo.vueAccountWorkingDayType INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountWorkingDayType.AccountWorkingDayTypeId = dbo.AccountEmployee.AccountWorkingDayTypeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.AccountEmployee.AccountEmployeeId = AccountEMailNotificationPreference_2.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON dbo.AccountEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId
WHERE     (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 60) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 59) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (dbo.AccountEmployee.EmployeeTypeId <> 2 OR
                      dbo.AccountEmployee.EmployeeTypeId IS NULL) AND (dbo.AccountEmployee.IsDeleted <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1)