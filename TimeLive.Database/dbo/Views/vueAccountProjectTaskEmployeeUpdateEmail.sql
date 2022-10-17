CREATE VIEW dbo.vueAccountProjectTaskEmployeeUpdateEmail
AS
SELECT     dbo.vueAccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountProjectId, 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId, dbo.vueAccountProjectTaskEmployee.TaskName, 
                      dbo.vueAccountProjectTaskEmployee.FirstName, dbo.vueAccountProjectTaskEmployee.LastName, 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountId, 
                      dbo.vueAccountProjectTaskEmployee.ProjectCode, dbo.vueAccountProjectTaskEmployee.TaskStatusId, 
                      dbo.vueAccountProjectTaskEmployee.Completed, dbo.AccountProject.ProjectName, dbo.AccountEmployee.EMailAddress, 
                      dbo.vueAccountProjectTask.TaskDescription, dbo.vueAccountProjectTask.TaskStatus, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.Priority, dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, 
                      dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.MilestoneDescription, dbo.vueAccountProjectTask.Duration, 
                      dbo.vueAccountProjectTask.DurationUnit, dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, 
                      dbo.vueAccountProjectTask.IsReOpen, dbo.vueAccountProjectTask.ModifiedByFirstName, dbo.vueAccountProjectTask.ModifiedByLastName
FROM         dbo.AccountProject RIGHT OUTER JOIN
                      dbo.vueAccountProjectTaskEmployee LEFT OUTER JOIN
                      dbo.vueAccountProjectTask ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId = dbo.vueAccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.vueAccountProjectTaskEmployee.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTaskEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 7) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 6) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 5) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)