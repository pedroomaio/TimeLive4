CREATE VIEW dbo.vueAccountProjectEmployeeTask
AS
SELECT     dbo.AccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.AccountProjectTask.AccountProjectId, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.TaskName, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProject.AccountId, dbo.AccountProject.ProjectCode, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.Completed, dbo.AccountProject.ProjectName, dbo.AccountBillingRate.BillingRate
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTaskEmployee RIGHT OUTER JOIN
                      dbo.AccountBillingRate RIGHT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountBillingRate.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId ON 
                      dbo.AccountProjectTaskEmployee.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTaskEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId