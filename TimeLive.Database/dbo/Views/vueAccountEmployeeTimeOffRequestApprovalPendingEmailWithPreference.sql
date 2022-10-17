CREATE VIEW dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmailWithPreference
AS
SELECT     dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.AccountEmployeeTimeOffRequestId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.AccountTimeOffTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.TimeOffAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.RequestSubmitDate, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.HoursOff, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.StartDate, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.EndDate, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.InApproval, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Approved, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Rejected, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Description, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.ApprovedOn, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.ApprovedBy, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.DayOff, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.CreatedByEmployeeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.CreatedOn, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.AccountId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.AccountApprovalPathId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.TimeOffApprovalPathId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.ApprovedByEmployeeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.ApprovedOnApproval, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.IsRejected, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.IsApproved, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Comments, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.TimeOffApprovalTypeId, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.FirstName, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.LastName, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.FullName, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.AccountTimeOffType, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.IsTimeOffRequestRequired, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.EMailAddress, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.EmployeeManagerId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.ApproverEmployeeId, dbo.AccountEmployee.EMailAddress AS ApproverEmailAddress, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.ScheduledEmailSendTime, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Monday, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Tuesday, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Wednesday, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Thursday, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Friday, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Saturday, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.Sunday, dbo.AccountEmployee.LastScheduledEmailSentTime
FROM         dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail INNER JOIN
                      dbo.AccountEmployee ON 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.ApproverEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                       dbo.AccountEmployee as TimeEntryAccountEmployee ON 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.TimeOffAccountEmployeeId = TimeEntryAccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail.AccountId = dbo.AccountPreferences.AccountId
WHERE     (TimeEntryAccountEmployee.IsDeleted <> 1) AND (TimeEntryAccountEmployee.IsDisabled <> 1) AND (dbo.AccountEmployee.IsDisabled <> 1) AND (dbo.AccountEmployee.IsDeleted <> 1)