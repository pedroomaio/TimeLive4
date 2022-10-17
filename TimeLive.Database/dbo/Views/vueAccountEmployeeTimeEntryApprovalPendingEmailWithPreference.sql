CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountProjectId, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ApprovalTypeName, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.SystemApproverTypeId, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeSheetApprovalPathId, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ProjectDescription, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ProjectCode, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TaskName, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TaskDescription, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Approved, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TotalTime, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Comments, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.IsApproved, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeEntryAccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.EMailAddress, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ApproverEmployeeId, 
                      dbo.AccountPreferences.ScheduledEmailSendTime, AccountEmployee_1.EMailAddress AS ApproverEMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Description, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.EmployeeManagerId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TotalMinutes, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.NonBillableTotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.BillableTotalMinutes, dbo.AccountPreferences.CultureInfoName, 
                      AccountEmployee_1.LastScheduledEmailSentTime, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountEmployeeTimeEntryPeriodId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeEntryStartDate, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.EmployeeWeekStartDay, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeEntryEndDate, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeEntryViewType, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Monday, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Tuesday, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Wednesday, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Thursday, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Friday, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Saturday, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Sunday
FROM         dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail LEFT OUTER JOIN
                      dbo.AccountEmployee ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeEntryAccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ApproverEmployeeId = AccountEmployee_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountId = dbo.AccountPreferences.AccountId
WHERE     (AccountEmployee_1.IsDeleted <> 1) AND (AccountEmployee_1.IsDisabled <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1) AND (dbo.AccountEmployee.IsDeleted <> 1)