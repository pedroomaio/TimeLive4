
CREATE VIEW dbo.vueAccountEmployeeTimeEntryRejectedEmail
AS
SELECT     dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.vueAccountEmployeeTimeEntry.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntry.TaskName, dbo.vueAccountEmployeeTimeEntry.TotalTime, dbo.vueAccountEmployeeTimeEntry.Approved, 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntry.TeamLeadApproved, dbo.vueAccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.vueAccountEmployeeTimeEntry.AdministratorApproved, dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntry.StartTime, dbo.vueAccountEmployeeTimeEntry.EndTime, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntry.Description, dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.vueAccountEmployeeTimeEntry.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntry.WeekDay, dbo.vueAccountEmployeeTimeEntry.AccountPartyId, dbo.vueAccountEmployeeTimeEntry.PartyName, 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectTaskId, dbo.vueAccountEmployeeTimeEntry.BillingType, 
                      dbo.vueAccountEmployeeTimeEntry.LeaderEmployeeId, dbo.vueAccountEmployeeTimeEntry.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntry.TimeSheetApprovalTypeId, dbo.vueAccountEmployeeTimeEntry.ExpenseApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntry.IsBillable, dbo.vueAccountEmployeeTimeEntry.Rejected, dbo.vueAccountEmployeeTimeEntry.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntry.ProjectBillingRateTypeId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments, dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId
FROM         dbo.vueAccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId LEFT OUTER
                       JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectId = dbo.AccountEMailNotificationPreference.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountId = AccountEMailNotificationPreference_2.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 19) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 17) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 18) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)