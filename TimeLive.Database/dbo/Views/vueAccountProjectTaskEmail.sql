CREATE VIEW dbo.vueAccountProjectTaskEmail
AS
SELECT     dbo.vueAccountProjectTask.AccountProjectTaskId, dbo.vueAccountProjectTask.AccountProjectId, 
                      dbo.vueAccountProjectTask.ParentAccountProjectTaskId, dbo.vueAccountProjectTask.TaskName, dbo.vueAccountProjectTask.TaskDescription, 
                      dbo.vueAccountProjectTask.AccountTaskTypeId, dbo.vueAccountProjectTask.Duration, dbo.vueAccountProjectTask.DurationUnit, 
                      dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, dbo.vueAccountProjectTask.Completed, 
                      dbo.vueAccountProjectTask.IsParentTask, dbo.vueAccountProjectTask.IsForAllEmployees, dbo.vueAccountProjectTask.AccountPriorityId, 
                      dbo.vueAccountProjectTask.TaskStatusId, dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.CreatedByEmployeeId, 
                      dbo.vueAccountProjectTask.ModifiedOn, dbo.vueAccountProjectTask.ModifiedByEmployeeId, dbo.vueAccountProjectTask.TaskStatus, 
                      dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, dbo.vueAccountProjectTask.Priority, 
                      dbo.vueAccountProjectTask.ProjectName, dbo.vueAccountProjectTask.ProjectCode, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.AccountId, dbo.vueAccountProjectTask.AccountProjectMilestoneId, dbo.vueAccountProjectTask.MilestoneDescription, 
                      dbo.vueAccountProjectTask.IsReOpen, dbo.vueAccountProjectTask.ModifiedByFirstName, dbo.vueAccountProjectTask.ModifiedByLastName, 
                      dbo.vueAccountProjectTask.EstimatedCost, dbo.vueAccountProjectTask.EstimatedTimeSpent, dbo.vueAccountProjectTask.EstimatedTimeSpentUnit, 
                      dbo.vueAccountProjectTask.AccountEmployeeId, dbo.AccountEmployee.EMailAddress
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.vueAccountProjectTask ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTask.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTask.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTask.CreatedByEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 4) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 3) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 2) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)