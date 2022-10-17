
CREATE VIEW dbo.vueTimesheetSummaryPendingForApprovalDailyEmailWithPreferenceGrouped
AS
SELECT        AccountId, ApproverEmployeeId, ScheduledEmailSendTime, LastScheduledEmailSentTime, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday,
UserCurrentDateTime,UserCurrentDate,ScheduledSendTime,TodaySendTime,IsCurrentDaySetForEmail
FROM           
vueTimesheetSummaryPendingForApprovalDailyEmailWithPreference
where UserCurrentDateTime >= TodaySendTime
and day(LastScheduledEmailSentTime) < day(UserCurrentDateTime) and IsCurrentDaySetForEmail = 1
--and ApproverEmployeeId =31527
GROUP BY AccountId, ApproverEmployeeId, ScheduledEmailSendTime, LastScheduledEmailSentTime, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday,
UserCurrentDateTime,UserCurrentDate,ScheduledSendTime,TodaySendTime,IsCurrentDaySetForEmail