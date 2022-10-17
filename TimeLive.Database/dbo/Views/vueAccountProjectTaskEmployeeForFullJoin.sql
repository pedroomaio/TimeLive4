
CREATE VIEW [dbo].[vueAccountProjectTaskEmployeeForFullJoin]
AS
SELECT        dbo.AccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.TaskName, 
                         dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProject.AccountId
FROM            dbo.AccountProjectTaskEmployee INNER JOIN
                         dbo.AccountEmployee ON dbo.AccountProjectTaskEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                         dbo.AccountProjectTask INNER JOIN
                         dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                         dbo.AccountProjectTaskEmployee.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId
WHERE        (dbo.AccountEmployee.IsDeleted <> 1)