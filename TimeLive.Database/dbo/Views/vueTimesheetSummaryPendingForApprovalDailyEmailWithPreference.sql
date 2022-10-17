
CREATE VIEW dbo.vueTimesheetSummaryPendingForApprovalDailyEmailWithPreference
AS
SELECT     
dbo.vueTimesheetSummaryPendingForApprovalDailyEmail.AccountProjectId, 
                      dbo.vueTimesheetSummaryPendingForApprovalDailyEmail.ApproverEmployeeId, 
					   dbo.AccountEmployee.AccountId, 
dbo.AccountPreferences.ScheduledEmailSendTime,
					  DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()) as UserCurrentDateTime , 
					  isnull(ApproverEmployee.LastScheduledEmailSentTime,DATEADD(day,-1,(DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate())))) as LastScheduledEmailSentTime,
						 CONVERT(CHAR(8), DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()), 112) as UserCurrentDate,
						 CONVERT(CHAR(8), dbo.AccountPreferences.ScheduledEmailSendTime, 108) as ScheduledSendTime,
						 CONVERT(DATETIME, CONVERT(CHAR(8), DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()), 112)   + ' ' + CONVERT(CHAR(8), dbo.AccountPreferences.ScheduledEmailSendTime, 108)) as TodaySendTime,
						AccountEMailNotificationPreference_1.Monday, AccountEMailNotificationPreference_1.Tuesday, AccountEMailNotificationPreference_1.Wednesday, 
						AccountEMailNotificationPreference_1.Thursday, 
                      AccountEMailNotificationPreference_1.Friday, AccountEMailNotificationPreference_1.Saturday, AccountEMailNotificationPreference_1.Sunday,
					  case when datename(dw,(DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()))) = 'Monday' then AccountEMailNotificationPreference_1.Monday  
					  when datename(dw,(DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()))) = 'Tuesday' then AccountEMailNotificationPreference_1.Tuesday  
					  when datename(dw,(DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()))) = 'Wednesday' then AccountEMailNotificationPreference_1.Wednesday  
					  when datename(dw,(DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()))) = 'Thursday' then AccountEMailNotificationPreference_1.Thursday  
					  when datename(dw,(DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()))) = 'Friday' then AccountEMailNotificationPreference_1.Friday  
					  when datename(dw,(DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()))) = 'Saturday' then AccountEMailNotificationPreference_1.Saturday  
					  when datename(dw,(DATEADD(mi, dbo.GET_TZVALUE(dbo.SystemTimeZone.TimeZoneDifference), getdate()))) = 'Sunday' then AccountEMailNotificationPreference_1.Sunday  
					  end as IsCurrentDaySetForEmail
FROM         dbo.AccountPreferences INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountPreferences.AccountId = dbo.AccountEmployee.AccountId 
					  RIGHT OUTER JOIN
                      dbo.vueTimesheetSummaryPendingForApprovalDailyEmail 
                       ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueTimesheetSummaryPendingForApprovalDailyEmail.ApproverEmployeeId
					  Left outer join dbo.AccountEmployee as ApproverEmployee on ApproverEmployee.AccountEmployeeId = dbo.vueTimesheetSummaryPendingForApprovalDailyEmail.ApproverEmployeeId 
					  Left outer join dbo.SystemTimeZone on dbo.SystemTimeZone.SystemTimeZoneId = ApproverEmployee.TimeZoneId 
					  LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueTimesheetSummaryPendingForApprovalDailyEmail.ApproverEmployeeId = dbo.AccountEMailNotificationPreference.AccountEmployeeId LEFT
                       OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueTimesheetSummaryPendingForApprovalDailyEmail.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.AccountEmployee.AccountId = AccountEMailNotificationPreference_1.AccountId LEFT OUTER JOIN
					  dbo.AccountEmployee as TimeEntryAccountEmployee on dbo.vueTimesheetSummaryPendingForApprovalDailyEmail.TimeEntryAccountEmployeeId = TimeEntryAccountEmployee.AccountEmployeeId 
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 11) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 12) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 13) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND
					  dbo.AccountEmployee.IsDisabled <> 1 AND dbo.AccountEmployee.IsDeleted <> 1 AND TimeEntryAccountEmployee.IsDisabled <> 1 AND TimeEntryAccountEmployee.IsDeleted <> 1