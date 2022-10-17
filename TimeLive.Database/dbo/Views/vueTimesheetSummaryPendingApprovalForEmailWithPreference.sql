
CREATE VIEW dbo.vueTimesheetSummaryPendingApprovalForEmailWithPreference
AS
SELECT     dbo.vueTimesheetSummaryPendingApprovalForEmail.AccountEmployeeTimeEntryPeriodId, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingApprovalForEmail.TimeEntryStartDate, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingApprovalForEmail.TimeEntryViewType, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.EmployeeName, dbo.vueTimesheetSummaryPendingApprovalForEmail.TotalMinutes, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.TimeEntryDate, dbo.vueTimesheetSummaryPendingApprovalForEmail.BillableTotalMinutes, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.NonBillableTotalMinutes, dbo.vueTimesheetSummaryPendingApprovalForEmail.EMailAddress, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.AccountProjectId, dbo.vueTimesheetSummaryPendingApprovalForEmail.ApproverEmployeeId, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.ApproverEmployeeName, dbo.vueTimesheetSummaryPendingApprovalForEmail.ApproverEMailAddress, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.CultureInfoName, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.AccountEmployeeTimeEntryApprovalProjectId, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.SubmittedDate, dbo.vueTimesheetSummaryPendingApprovalForEmail.AccountId, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.IsEmailSend, dbo.vueTimesheetSummaryPendingApprovalForEmail.Submitted, 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.Approved, dbo.vueTimesheetSummaryPendingApprovalForEmail.Rejected
FROM         dbo.vueTimesheetSummaryPendingApprovalForEmail INNER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.AccountId = dbo.AccountEMailNotificationPreference.AccountId INNER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueTimesheetSummaryPendingApprovalForEmail.ApproverEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 45) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 46) AND (AccountEMailNotificationPreference_1.Enabled = 1)