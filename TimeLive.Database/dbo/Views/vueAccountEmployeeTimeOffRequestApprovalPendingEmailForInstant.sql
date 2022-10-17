
CREATE VIEW dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmailForInstant
AS
SELECT     dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountEmployeeTimeOffRequestId, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountTimeOffTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.TimeOffAccountEmployeeId, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.RequestSubmitDate, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.HoursOff, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.StartDate, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.EndDate, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.InApproval, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.Approved, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.Rejected, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.Description, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApprovedOn, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApprovedBy, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.DayOff, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.CreatedByEmployeeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.CreatedOn, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApprovalTypeName, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountApprovalPathId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.SystemApproverTypeId, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApprovalPathSequence, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.TimeOffApprovalPathId, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApprovedByEmployeeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApprovedOnApproval, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.IsRejected, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.IsApproved, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.Comments, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.TimeOffApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.FirstName, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.LastName, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.FullName, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountTimeOffType, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.IsTimeOffRequestRequired, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.EMailAddress, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountApprovalTypeId, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.EmployeeManagerId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApproverEmployeeId, dbo.AccountEMailNotificationPreference.Monday, 
                      dbo.AccountEMailNotificationPreference.Tuesday, dbo.AccountEMailNotificationPreference.Wednesday, dbo.AccountEMailNotificationPreference.Thursday, 
                      dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, dbo.AccountEMailNotificationPreference.Sunday, 
                      dbo.AccountEmployee.EMailAddress AS ApproverEmailAddress, dbo.AccountPreferences.CultureInfoName
FROM         dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover INNER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountId = dbo.AccountEMailNotificationPreference.AccountId INNER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApproverEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId INNER JOIN
                      dbo.AccountEmployee ON 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApproverEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountId = dbo.AccountPreferences.AccountId
WHERE     (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 69) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 70) AND (AccountEMailNotificationPreference_1.Enabled = 1)