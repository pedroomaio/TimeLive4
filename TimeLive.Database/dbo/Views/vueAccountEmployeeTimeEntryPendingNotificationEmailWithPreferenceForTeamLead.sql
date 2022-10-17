
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForTeamLead
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, MAX(dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName) AS EmployeeName, 
                      MAX(dbo.AccountEmployee.EMailAddress) AS EMailAddress, dbo.AccountEmployee.LastScheduledEmailSentTime, 
                      dbo.AccountPreferences.ScheduledEmailSendTime, dbo.AccountEmployee.AccountId, CASE WHEN MAX(dbo.AccountPreferences.CultureInfoName) 
                      IS NULL THEN 'en-us' WHEN MAX(dbo.AccountPreferences.CultureInfoName) 
                      = 'auto' THEN 'en-us' ELSE MAX(dbo.AccountPreferences.CultureInfoName) END AS CultureInfoName, dbo.AccountEMailNotificationPreference.Monday, 
                      dbo.AccountEMailNotificationPreference.Tuesday, dbo.AccountEMailNotificationPreference.Wednesday, 
                      dbo.AccountEMailNotificationPreference.Thursday, dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, 
                      dbo.AccountEMailNotificationPreference.Sunday
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProject.LeaderEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON dbo.AccountEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.AccountEmployee.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (dbo.AccountEmployee.EmployeeTypeId <> 2 OR
                      dbo.AccountEmployee.EmployeeTypeId IS NULL) AND (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 37) AND 
                      (dbo.AccountEMailNotificationPreference.Enabled = 1) AND (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 38) AND 
                      (AccountEMailNotificationPreference_1.Enabled = 1) AND (dbo.AccountEmployee.IsDeleted <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1)
GROUP BY dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.LastScheduledEmailSentTime, dbo.AccountPreferences.ScheduledEmailSendTime, 
                      dbo.AccountEmployee.AccountId, dbo.AccountEMailNotificationPreference.Monday, dbo.AccountEMailNotificationPreference.Tuesday, 
                      dbo.AccountEMailNotificationPreference.Wednesday, dbo.AccountEMailNotificationPreference.Thursday, 
                      dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, dbo.AccountEMailNotificationPreference.Sunday