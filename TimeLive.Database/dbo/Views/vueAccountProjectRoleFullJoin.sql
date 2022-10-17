CREATE VIEW dbo.vueAccountProjectRoleFullJoin
AS
SELECT     dbo.AccountRole.AccountRoleId, dbo.AccountRole.AccountId, dbo.AccountRole.Role, dbo.AccountRole.MasterAccountRoleId, 
                      dbo.AccountProject.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountProjectRole.AccountProjectRoleId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountProjectRole ON dbo.AccountProject.AccountProjectId = dbo.AccountProjectRole.AccountProjectId INNER JOIN
                      dbo.AccountRole ON dbo.AccountProjectRole.AccountRoleId = dbo.AccountRole.AccountRoleId AND 
                      dbo.AccountProject.AccountId = dbo.AccountRole.AccountId