
CREATE VIEW dbo.vueAccountEmployeeTimeOffRequestApprovalPendingEmail
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
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApprovedOnApproval, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.IsRejected, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.IsApproved, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.Comments, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.TimeOffApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.FirstName, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.LastName, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.FullName, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountTimeOffType, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.IsTimeOffRequestRequired, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.EMailAddress, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountApprovalTypeId, dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.EmployeeManagerId, 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApproverEmployeeId, dbo.AccountEMailNotificationPreference.Monday, 
                      dbo.AccountEMailNotificationPreference.Tuesday, dbo.AccountEMailNotificationPreference.Wednesday, dbo.AccountEMailNotificationPreference.Thursday, 
                      dbo.AccountEMailNotificationPreference.Friday, dbo.AccountEMailNotificationPreference.Saturday, dbo.AccountEMailNotificationPreference.Sunday
FROM         dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover INNER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.AccountId = dbo.AccountEMailNotificationPreference.AccountId INNER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeOffRequestApprovalPendingApprover.ApproverEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 43) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 44) AND (AccountEMailNotificationPreference_1.Enabled = 1)