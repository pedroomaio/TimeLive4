
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForInstantTimeOff
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountEmployeeTimeEntryId, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.TimeEntryDate, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.StartTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.EndTime, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.TotalTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.Description, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.Approved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AdministratorApproved, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.CreatedOn, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.Rejected, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.Submitted, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.IsTimeOff, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.Hours, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountTimeOffTypeId, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountEmployeeTimeOffRequestId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.ApprovalTypeName, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountExternalUserId, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.EmployeeManagerId, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.ModifiedOn, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.TimeSheetApprovalId, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.ApprovedByEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.Comments, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.MaxApprovalPathSequence, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.TimeEntryAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.EmployeeName, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountTimeOffType, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.IsApproved, dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountEmployeeTimeEntryPeriodId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.ApproverEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountId, dbo.AccountEMailNotificationPreference.Monday, 
                      dbo.AccountEMailNotificationPreference.Tuesday, dbo.AccountEMailNotificationPreference.Wednesday, dbo.AccountEMailNotificationPreference.Thursday, 
                      dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, dbo.AccountEMailNotificationPreference.Sunday, 
                      dbo.AccountEmployee.EMailAddress AS ApproverEmailAddress, dbo.AccountPreferences.CultureInfoName
FROM         dbo.AccountEMailNotificationPreference INNER JOIN
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff ON 
                      dbo.AccountEMailNotificationPreference.AccountId = dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountId INNER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.TimeEntryAccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId INNER
                       JOIN
                      dbo.AccountPreferences ON dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.AccountId = dbo.AccountPreferences.AccountId INNER JOIN
                      dbo.AccountEmployee ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApproverForTimeOff.ApproverEmployeeId = dbo.AccountEmployee.AccountEmployeeId
WHERE     (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 69) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 70) AND (AccountEMailNotificationPreference_1.Enabled = 1)