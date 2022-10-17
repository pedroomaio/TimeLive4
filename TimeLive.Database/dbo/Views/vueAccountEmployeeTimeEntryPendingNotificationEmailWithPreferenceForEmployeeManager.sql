
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForEmployeeManager
AS
SELECT     dbo.AccountPreferences.ScheduledEmailSendTime, MAX(dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName) AS EmployeeName, 
                      AccountEmployee_1.AccountId, dbo.AccountEmployee.LastScheduledEmailSentTime, MAX(dbo.AccountEmployee.EMailAddress) AS EMailAddress, 
                      dbo.AccountEmployee.AccountEmployeeId, CASE WHEN MAX(dbo.AccountPreferences.CultureInfoName) IS NULL 
                      THEN 'en-us' WHEN MAX(dbo.AccountPreferences.CultureInfoName) = 'auto' THEN 'en-us' ELSE MAX(dbo.AccountPreferences.CultureInfoName) 
                      END AS CultureInfoName, dbo.AccountEMailNotificationPreference.Monday, dbo.AccountEMailNotificationPreference.Tuesday, 
                      dbo.AccountEMailNotificationPreference.Wednesday, dbo.AccountEMailNotificationPreference.Thursday, 
                      dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, 
                      dbo.AccountEMailNotificationPreference.Sunday
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      AccountEMailNotificationPreference_2.AccountEmployeeId = AccountEmployee_1.EmployeeManagerId ON 
                      dbo.AccountEmployee.AccountEmployeeId = AccountEmployee_1.EmployeeManagerId RIGHT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON AccountEmployee_1.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountPreferences ON AccountEmployee_1.AccountId = dbo.AccountPreferences.AccountId
WHERE     (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 32) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 31) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (AccountEmployee_1.EmployeeTypeId <> 2 OR
                      AccountEmployee_1.EmployeeTypeId IS NULL) AND (dbo.AccountEmployee.IsDeleted <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1)
GROUP BY dbo.AccountPreferences.ScheduledEmailSendTime, AccountEmployee_1.AccountId, dbo.AccountEmployee.LastScheduledEmailSentTime, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEMailNotificationPreference.Monday, dbo.AccountEMailNotificationPreference.Tuesday, 
                      dbo.AccountEMailNotificationPreference.Wednesday, dbo.AccountEMailNotificationPreference.Thursday, 
                      dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, dbo.AccountEMailNotificationPreference.Sunday