
CREATE VIEW dbo.vueAccountEmployeeTimeOffRequestRejectedEmail
AS
SELECT     dbo.vueAccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId, dbo.vueAccountEmployeeTimeOffRequest.AccountTimeOffTypeId, 
                      dbo.vueAccountEmployeeTimeOffRequest.AccountEmployeeId, dbo.vueAccountEmployeeTimeOffRequest.RequestSubmitDate, 
                      dbo.vueAccountEmployeeTimeOffRequest.HoursOff, dbo.vueAccountEmployeeTimeOffRequest.StartDate, 
                      dbo.vueAccountEmployeeTimeOffRequest.EndDate, dbo.vueAccountEmployeeTimeOffRequest.InApproval, 
                      dbo.vueAccountEmployeeTimeOffRequest.Approved, dbo.vueAccountEmployeeTimeOffRequest.Rejected, 
                      dbo.vueAccountEmployeeTimeOffRequest.Description, dbo.vueAccountEmployeeTimeOffRequest.ApprovedOn, 
                      dbo.vueAccountEmployeeTimeOffRequest.ApprovedBy, dbo.vueAccountEmployeeTimeOffRequest.DayOff, 
                      dbo.vueAccountEmployeeTimeOffRequest.CreatedByEmployee, dbo.vueAccountEmployeeTimeOffRequest.CreatedOn, 
                      dbo.vueAccountEmployeeTimeOffRequest.ModifiedByEmployeeId, dbo.vueAccountEmployeeTimeOffRequest.ModifiedOn, 
                      dbo.vueAccountEmployeeTimeOffRequest.AccountId, dbo.vueAccountEmployeeTimeOffRequest.AccountTimeOffType, 
                      dbo.vueAccountEmployeeTimeOffRequest.IsTimeOffRequestRequired, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployeeTimeOffRequestApproval.Comments, dbo.vueAccountEmployeeTimeOffRequest.EmployeeName
FROM         dbo.vueAccountEmployeeTimeOffRequest INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeOffRequest.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeOffRequest.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeOffRequestApproval ON 
                      dbo.vueAccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId = dbo.AccountEmployeeTimeOffRequestApproval.AccountEmployeeTimeOffRequestId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 42) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 41) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)