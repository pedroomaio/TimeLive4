
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForProjectManager
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, MAX(dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName) AS EmployeeName, 
                      MAX(dbo.AccountEmployee.EMailAddress) AS EMailAddress, dbo.AccountEmployee.LastScheduledEmailSentTime, dbo.AccountEmployee.AccountId, 
                      dbo.AccountPreferences.ScheduledEmailSendTime, CASE WHEN MAX(dbo.AccountPreferences.CultureInfoName) IS NULL 
                      THEN 'en-us' WHEN MAX(dbo.AccountPreferences.CultureInfoName) = 'auto' THEN 'en-us' ELSE MAX(dbo.AccountPreferences.CultureInfoName) 
                      END AS CultureInfoName, AccountEMailNotificationPreference_1.Monday, AccountEMailNotificationPreference_1.Tuesday, 
                      AccountEMailNotificationPreference_1.Wednesday, AccountEMailNotificationPreference_1.Thursday, AccountEMailNotificationPreference_1.Friday, 
                      AccountEMailNotificationPreference_1.Saturday, AccountEMailNotificationPreference_1.Sunday
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProject.ProjectManagerEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEMailNotificationPreference.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.AccountEmployee.AccountId = AccountEMailNotificationPreference_1.AccountId
WHERE     (dbo.AccountEmployee.EmployeeTypeId <> 2 OR
                      dbo.AccountEmployee.EmployeeTypeId IS NULL) AND (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 36) AND 
                      (dbo.AccountEMailNotificationPreference.Enabled = 1) AND (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 35) AND 
                      (AccountEMailNotificationPreference_1.Enabled = 1) AND (dbo.AccountEmployee.IsDeleted <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1)
GROUP BY dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.LastScheduledEmailSentTime, dbo.AccountEmployee.AccountId, 
                      dbo.AccountPreferences.ScheduledEmailSendTime, AccountEMailNotificationPreference_1.Monday, AccountEMailNotificationPreference_1.Tuesday, 
                      AccountEMailNotificationPreference_1.Wednesday, AccountEMailNotificationPreference_1.Thursday, AccountEMailNotificationPreference_1.Friday, 
                      AccountEMailNotificationPreference_1.Saturday, AccountEMailNotificationPreference_1.Sunday