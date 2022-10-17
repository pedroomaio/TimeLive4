
CREATE VIEW dbo.vueAccountProjectTaskForQB
AS
SELECT     dbo.AccountProject.AccountId, dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, 
                      CASE WHEN dbo.AccountProjectTask.ParentAccountProjectTaskId IS NULL THEN '' ELSE Replace(vueAccountProjectTaskWithParentForQB.Parents, 
                      ':' + LEFT(AccountProjectTask.TaskName, 31), '') END AS JobItemParent, CASE WHEN dbo.AccountProjectTask.ParentAccountProjectTaskId IS NULL 
                      THEN LEFT(accountproject.ProjectName, 21) ELSE LEFT(accountproject.ProjectName, 21) 
                      + ':' + Replace(vueAccountProjectTaskWithParentForQB.Parents, ':' + LEFT(AccountProjectTask.TaskName, 31), '') END AS ItemParent, 
                      CASE WHEN dbo.AccountProjectTask.ParentAccountProjectTaskId IS NULL THEN LEFT(PartyName, 41) + ':' + LEFT(ProjectName, 31) 
                      ELSE LEFT(PartyName, 41) + ':' + LEFT(ProjectName, 31) + ':' + Replace(vueAccountProjectTaskWithParentForQB.Parents, 
                      ':' + LEFT(AccountProjectTask.TaskName, 31), '') END AS JobParent, LEFT(dbo.AccountProjectTask.TaskName, 31) AS TaskName, 
                      dbo.AccountProjectTask.TaskCode, dbo.AccountProject.IsTemplate, dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountParty.PartyName
FROM         dbo.AccountParty INNER JOIN
                      dbo.AccountProjectTask INNER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountParty.AccountPartyId = dbo.AccountProject.AccountClientId LEFT OUTER JOIN
                      dbo.vueAccountProjectTaskWithParentForQB ON 
                      dbo.AccountProjectTask.AccountProjectTaskId = dbo.vueAccountProjectTaskWithParentForQB.AccountProjectTaskId