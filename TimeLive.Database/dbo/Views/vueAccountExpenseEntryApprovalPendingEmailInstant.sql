
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingEmailInstant
AS
SELECT     dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountProjectId, dbo.vueAccountExpenseEntryApprovalPendingSummary.EmployeeName, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.Amount, dbo.vueAccountExpenseEntryApprovalPendingSummary.ExpenseEntryAccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountEmployeeExpenseSheetId, dbo.vueAccountExpenseEntryApprovalPendingSummary.Description, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ExpenseSheetDate, dbo.vueAccountExpenseEntryApprovalPendingSummary.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ProjectManagerEmployeeId, dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ApprovalPathSequence, dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.IsRejected, dbo.vueAccountExpenseEntryApprovalPendingSummary.IsApproved, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ExpenseApprovalId, dbo.vueAccountExpenseEntryApprovalPendingSummary.Approved, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.Rejected, dbo.vueAccountExpenseEntryApprovalPendingSummary.Submitted, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ApproverEmployeeId, dbo.vueAccountExpenseEntryApprovalPendingSummary.EmployeeManagerId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.EMailAddress, dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.SystemApproverTypeId, dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountApprovalPathId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.BaseCurrencyCode, dbo.vueAccountExpenseEntryApprovalPendingSummary.SubmittedDate, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.IsEmailSend
FROM         dbo.vueAccountExpenseEntryApprovalPendingSummary INNER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ApproverEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId INNER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountId = dbo.AccountEMailNotificationPreference.AccountId
WHERE     (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 47) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 48) AND (AccountEMailNotificationPreference_1.Enabled = 1)