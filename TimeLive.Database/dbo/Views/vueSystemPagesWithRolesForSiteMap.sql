
CREATE VIEW dbo.vueSystemPagesWithRolesForSiteMap
AS
SELECT     dbo.AccountPagePermission.SystemSecurityCategoryPageId, dbo.AccountPagePermission.AccountId, dbo.AccountRole.Role, 
                      dbo.AccountPagePermission.AccountRoleId
FROM         dbo.AccountPagePermission INNER JOIN
                      dbo.AccountRole ON dbo.AccountPagePermission.AccountRoleId = dbo.AccountRole.AccountRoleId AND 
                      dbo.AccountPagePermission.AccountId = dbo.AccountRole.AccountId
GROUP BY dbo.AccountPagePermission.SystemSecurityCategoryPageId, dbo.AccountPagePermission.AccountId, dbo.AccountRole.Role, 
                      dbo.AccountPagePermission.AccountRoleId