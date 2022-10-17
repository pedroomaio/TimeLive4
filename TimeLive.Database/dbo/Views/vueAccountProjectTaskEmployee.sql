
CREATE VIEW dbo.vueAccountProjectTaskEmployee
AS
SELECT     dbo.AccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.AccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.AccountEmployeeId, 
                      dbo.AccountProject.AccountId, dbo.AccountProject.ProjectCode, dbo.AccountProjectTask.TaskStatusId, dbo.AccountProjectTask.Completed, 
                      dbo.AccountEmployee.EMailAddress, dbo.AccountProject.ProjectName, dbo.AccountProject.IsDeleted AS IsDeletedProject, 
                      dbo.AccountParty.IsDeleted AS IsDeletedParty, dbo.AccountEmployee.IsDeleted AS IsDeletedEmployee
FROM         dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId RIGHT OUTER JOIN
                      dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTaskEmployee INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountProjectTaskEmployee.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTaskEmployee.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountProjectTask.AccountProjectId