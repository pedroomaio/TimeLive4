
CREATE VIEW dbo.vueTimesheetOverdueNotificationWithPreferenceForProjectManager
AS
SELECT     dbo.AccountPreferences.ScheduledEmailSendTime, MAX(dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName) AS EmployeeName, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.AccountId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployee.LastScheduledEmailSentTime, CASE WHEN MAX(dbo.AccountPreferences.CultureInfoName) IS NULL OR
                      MAX(dbo.AccountPreferences.CultureInfoName) = 'auto' THEN 'en-us' ELSE MAX(dbo.AccountPreferences.CultureInfoName) END AS CultureInfoName, 
                      ISNULL(MAX(dbo.vueAccountWorkingDayType.TimesheetOverdueAfterDays), 1) AS TimesheetOverdueAfterDays, 
                      ISNULL(MAX(dbo.vueAccountWorkingDayType.SystemTimesheetPeriodType), 'Weekly') AS SystemTimesheetPeriodType, 
                      ISNULL(MAX(dbo.vueAccountWorkingDayType.WeekStartDay), 1) AS WeekStartDay, ISNULL(MAX(dbo.vueAccountWorkingDayType.SystemInitialDayOfFirstPeriod), 1) 
                      AS SystemInitialDayOfFirstPeriod, ISNULL(MAX(dbo.vueAccountWorkingDayType.SystemInitialDayOfLastPeriod), 16) AS SystemInitialDayOfLastPeriod, 
                      ISNULL(MAX(dbo.vueAccountWorkingDayType.InitialDayOfTheMonth), 1) AS InitialDayOfTheMonth
FROM         dbo.vueAccountWorkingDayType INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountWorkingDayType.AccountWorkingDayTypeId = dbo.AccountEmployee.AccountWorkingDayTypeId INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProject.ProjectManagerEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.AccountEmployee.AccountEmployeeId = AccountEMailNotificationPreference_2.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON dbo.AccountEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId
WHERE     (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 66) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 65) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (dbo.AccountEmployee.EmployeeTypeId <> 2 OR
                      dbo.AccountEmployee.EmployeeTypeId IS NULL) AND (dbo.AccountProject.IsDeleted IS NULL OR dbo.AccountProject.IsDeleted = 0)
                      AND (dbo.AccountEmployee.IsDeleted <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1)
GROUP BY dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.AccountId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployee.LastScheduledEmailSentTime, dbo.AccountPreferences.ScheduledEmailSendTime