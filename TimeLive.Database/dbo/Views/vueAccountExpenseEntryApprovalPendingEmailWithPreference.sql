CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingEmailWithPreference
AS
SELECT     dbo.vueAccountExpenseEntryApprovalPendingEmail.AccountProjectId, dbo.vueAccountExpenseEntryApprovalPendingEmail.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.ProjectManagerEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.AccountApprovalPathId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.SystemApproverTypeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.ApprovalPathSequence, dbo.vueAccountExpenseEntryApprovalPendingEmail.ExpenseApprovalId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.EmployeeName, dbo.vueAccountExpenseEntryApprovalPendingEmail.Approved, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.IsRejected, dbo.vueAccountExpenseEntryApprovalPendingEmail.IsApproved, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.Amount, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.ExpenseEntryAccountEmployeeId AS AccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.Description, dbo.vueAccountExpenseEntryApprovalPendingEmail.ApproverEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.AccountId, dbo.AccountEmployee.EMailAddress AS ApproverEmailAddress, 
                      dbo.AccountPreferences.ScheduledEmailSendTime, dbo.vueAccountExpenseEntryApprovalPendingEmail.EMailAddress, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.EmployeeManagerId, CASE WHEN dbo.AccountPreferences.CultureInfoName IS NULL OR
                      dbo.AccountPreferences.CultureInfoName = 'auto' THEN 'en-us' ELSE dbo.AccountPreferences.CultureInfoName END AS CultureInfoName, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.AccountEmployeeExpenseSheetId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.ExpenseSheetDate, dbo.vueAccountExpenseEntryApprovalPendingEmail.BaseCurrencyCode, 
                      dbo.AccountEmployee.LastScheduledEmailSentTime, dbo.vueAccountExpenseEntryApprovalPendingEmail.Monday, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.Tuesday, dbo.vueAccountExpenseEntryApprovalPendingEmail.Wednesday, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.Thursday, dbo.vueAccountExpenseEntryApprovalPendingEmail.Friday, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.Saturday, dbo.vueAccountExpenseEntryApprovalPendingEmail.Sunday, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.Rejected, dbo.vueAccountExpenseEntryApprovalPendingEmail.Submitted, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.SubmittedDate, dbo.vueAccountExpenseEntryApprovalPendingEmail.IsEmailSend
FROM         dbo.vueAccountExpenseEntryApprovalPendingEmail LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountExpenseEntryApprovalPendingEmail.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountEmployee ON 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.ApproverEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                         dbo.AccountEmployee as ExpenseEntryAccountEmployee ON 
                      dbo.vueAccountExpenseEntryApprovalPendingEmail.ExpenseEntryAccountEmployeeId = ExpenseEntryAccountEmployee.AccountEmployeeId 
WHERE     (ExpenseEntryAccountEmployee.IsDeleted <> 1) AND (ExpenseEntryAccountEmployee.IsDisabled <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1) AND (dbo.AccountEmployee.IsDeleted <> 1)