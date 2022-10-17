
CREATE VIEW dbo.vueAccountEMailNotificationPreference
AS
SELECT     dbo.AccountEMailNotificationPreference.AccountEMailNotificationPreferenceId, dbo.AccountEMailNotificationPreference.AccountId, 
                      dbo.AccountEMailNotificationPreference.AccountProjectId, dbo.AccountEMailNotificationPreference.AccountEmployeeId, 
                      dbo.AccountEMailNotificationPreference.SystemEMailNotificationId, dbo.AccountEMailNotificationPreference.SystemEMailNotificationTypeId, 
                      dbo.AccountEMailNotificationPreference.Enabled, dbo.SystemEMailNotification.SystemEMailNotification, 
                      dbo.SystemEMailNotificationType.SystemEMailNotificationType, dbo.AccountEMailNotificationPreference.Monday, 
                      dbo.AccountEMailNotificationPreference.Tuesday, dbo.AccountEMailNotificationPreference.Wednesday, 
                      dbo.AccountEMailNotificationPreference.Thursday, dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, 
                      dbo.AccountEMailNotificationPreference.Sunday, dbo.SystemEMailNotification.IsWeekDayAllow, dbo.SystemEMailNotification.SystemFeatureId
FROM         dbo.AccountEMailNotificationPreference LEFT OUTER JOIN
                      dbo.SystemEMailNotification ON 
                      dbo.AccountEMailNotificationPreference.SystemEMailNotificationTypeId = dbo.SystemEMailNotification.SystemEMailNotificationTypeId AND 
                      dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = dbo.SystemEMailNotification.SystemEMailNotificationId LEFT OUTER JOIN
                      dbo.SystemEMailNotificationType ON 
                      dbo.SystemEMailNotification.SystemEMailNotificationTypeId = dbo.SystemEMailNotificationType.SystemEMailNotificationTypeId