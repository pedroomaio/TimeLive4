
CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeSheetApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectDescription, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectCode, dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TaskName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TaskDescription, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.Approved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TotalTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.Comments, dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.IsApproved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeEntryAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountId, dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApproverEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.Description, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.EmployeeManagerId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.NonBillableTotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.BillableTotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountEmployeeTimeEntryPeriodId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.EmployeeWeekStartDay, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeEntryStartDate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeEntryEndDate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeEntryViewType, AccountEMailNotificationPreference_1.Monday, 
                      AccountEMailNotificationPreference_1.Tuesday, AccountEMailNotificationPreference_1.Wednesday, AccountEMailNotificationPreference_1.Thursday, 
                      AccountEMailNotificationPreference_1.Friday, AccountEMailNotificationPreference_1.Saturday, AccountEMailNotificationPreference_1.Sunday
FROM         dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApproverEmployeeId = dbo.AccountEMailNotificationPreference.AccountEmployeeId LEFT
                       OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountId = AccountEMailNotificationPreference_1.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 11) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 12) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 13) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)