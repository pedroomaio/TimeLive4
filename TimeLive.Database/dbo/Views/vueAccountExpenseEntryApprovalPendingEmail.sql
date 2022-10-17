
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingEmail
AS
SELECT     dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountProjectId, dbo.vueAccountExpenseEntryApprovalPendingSummary.EmployeeName, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.Amount, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ExpenseEntryAccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountEmployeeExpenseSheetId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.Description, dbo.vueAccountExpenseEntryApprovalPendingSummary.ExpenseSheetDate, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ProjectManagerEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountEmployeeId, dbo.vueAccountExpenseEntryApprovalPendingSummary.IsRejected, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.IsApproved, dbo.vueAccountExpenseEntryApprovalPendingSummary.ExpenseApprovalId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.Approved, dbo.vueAccountExpenseEntryApprovalPendingSummary.Rejected, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.Submitted, dbo.vueAccountExpenseEntryApprovalPendingSummary.ApproverEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.EmployeeManagerId, dbo.vueAccountExpenseEntryApprovalPendingSummary.EMailAddress, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountId, dbo.vueAccountExpenseEntryApprovalPendingSummary.SystemApproverTypeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountApprovalPathId, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.BaseCurrencyCode, AccountEMailNotificationPreference_1.Monday, 
                      AccountEMailNotificationPreference_1.Tuesday, AccountEMailNotificationPreference_1.Wednesday, AccountEMailNotificationPreference_1.Thursday, 
                      AccountEMailNotificationPreference_1.Friday, AccountEMailNotificationPreference_1.Saturday, AccountEMailNotificationPreference_1.Sunday, 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.SubmittedDate, dbo.vueAccountExpenseEntryApprovalPendingSummary.IsEmailSend
FROM         dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 RIGHT OUTER JOIN
                      dbo.vueAccountExpenseEntryApprovalPendingSummary ON 
                      AccountEMailNotificationPreference_2.AccountProjectId = dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.AccountId = AccountEMailNotificationPreference_1.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountExpenseEntryApprovalPendingSummary.ExpenseEntryAccountEmployeeId = dbo.AccountEMailNotificationPreference.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 26) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 27) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 28) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)