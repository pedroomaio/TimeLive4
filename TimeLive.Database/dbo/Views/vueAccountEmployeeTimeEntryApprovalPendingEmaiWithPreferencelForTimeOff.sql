CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOff
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.TimeEntryDate, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.StartTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.EndTime, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.TotalTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Description, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Approved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AdministratorApproved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.CreatedOn, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Rejected, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Submitted, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.IsTimeOff, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Hours, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountTimeOffTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountEmployeeTimeOffRequestId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.EmployeeManagerId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.ModifiedOn, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.ApprovedByEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Comments, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.TimeEntryAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountTimeOffType, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.TotalMinutes, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.IsApproved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountEmployeeTimeEntryPeriodId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.ApproverEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountId, dbo.AccountEmployee.EMailAddress AS ApproverEmailAddress, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.ScheduledEmailSendTime, dbo.AccountEmployee.LastScheduledEmailSentTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Monday, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Tuesday, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Wednesday, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Thursday, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Friday, dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Saturday, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.Sunday
FROM         dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff INNER JOIN
                      dbo.AccountEmployee ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.ApproverEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountEmployee as TimeEntryAccountEmployee ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.TimeEntryAccountEmployeeId = TimeEntryAccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailForTimeOff.AccountId = dbo.AccountPreferences.AccountId
WHERE     (TimeEntryAccountEmployee.IsDeleted <> 1) AND (TimeEntryAccountEmployee.IsDisabled <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1) AND (dbo.AccountEmployee.IsDeleted <> 1)