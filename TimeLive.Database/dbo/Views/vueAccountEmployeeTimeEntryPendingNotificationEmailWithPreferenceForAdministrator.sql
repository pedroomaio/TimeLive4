
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreferenceForAdministrator
AS
SELECT     dbo.AccountPreferences.ScheduledEmailSendTime, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.AccountId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployee.LastScheduledEmailSentTime, dbo.AccountRole.Role, dbo.AccountRole.MasterAccountRoleId, 
                      CASE WHEN dbo.AccountPreferences.CultureInfoName IS NULL 
                      THEN 'en-us' WHEN dbo.AccountPreferences.CultureInfoName = 'auto' THEN 'en-us' ELSE CultureInfoName END AS CultureInfoName, 
                      dbo.AccountEMailNotificationPreference.Monday, dbo.AccountEMailNotificationPreference.Tuesday, 
                      dbo.AccountEMailNotificationPreference.Wednesday, dbo.AccountEMailNotificationPreference.Thursday, 
                      dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, 
                      dbo.AccountEMailNotificationPreference.Sunday
FROM         dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 RIGHT OUTER JOIN
                      dbo.AccountRole INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountRole.AccountRoleId = dbo.AccountEmployee.AccountRoleId ON 
                      AccountEMailNotificationPreference_2.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON dbo.AccountEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId
WHERE     (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 34) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 33) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (dbo.AccountEmployee.EmployeeTypeId <> 2 OR
                      dbo.AccountEmployee.EmployeeTypeId IS NULL) AND (dbo.AccountRole.MasterAccountRoleId = 1) AND (dbo.AccountEmployee.IsDeleted <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1)