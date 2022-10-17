
CREATE VIEW dbo.vueAccountProjectTaskEmployeeForTaskTeam
AS
SELECT     dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTaskEmployee.AccountProjectTaskEmployeeId, 
                      dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS FullName, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountParty.PartyName
FROM         dbo.AccountProjectTask INNER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId LEFT OUTER JOIN
                      dbo.AccountProjectTaskEmployee ON dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountProjectTaskEmployee.AccountProjectTaskId AND 
                      dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountProjectTaskEmployee.AccountEmployeeId
WHERE     (dbo.AccountEmployee.IsDeleted <> 1)