
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingEmailInstantWithPreference
AS
SELECT     dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.AccountProjectId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.EmployeeName, dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.Amount, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.ExpenseEntryAccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.AccountEmployeeExpenseSheetId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.Description, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.ExpenseSheetDate, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.ProjectManagerEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.AccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.IsRejected, dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.IsApproved, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.ExpenseApprovalId, dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.Approved, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.Rejected, dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.Submitted, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.ApproverEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.EmployeeManagerId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.EMailAddress, dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.AccountId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.SystemApproverTypeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.AccountApprovalPathId, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.BaseCurrencyCode, 
                      dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.SubmittedDate, dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.IsEmailSend, 
                      dbo.AccountPreferences.ScheduledEmailSendTime, dbo.AccountEmployee.EMailAddress AS ApproverEmailAddress, 
                      dbo.AccountEmployee.LastScheduledEmailSentTime, CASE WHEN dbo.AccountPreferences.CultureInfoName IS NULL OR
                      dbo.AccountPreferences.CultureInfoName = 'auto' THEN 'en-us' ELSE dbo.AccountPreferences.CultureInfoName END AS CultureInfoName
FROM         dbo.vueAccountExpenseEntryApprovalPendingEmailInstant INNER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.AccountId = dbo.AccountPreferences.AccountId INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountExpenseEntryApprovalPendingEmailInstant.ApproverEmployeeId = dbo.AccountEmployee.AccountEmployeeId