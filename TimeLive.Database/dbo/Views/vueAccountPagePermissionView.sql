CREATE VIEW dbo.vueAccountPagePermissionView
AS
SELECT     dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId, dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId, 
                      dbo.SystemSecurityCategoryPage.SequenceNumber, dbo.SystemSecurityCategoryPage.Folder, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPage, dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPageDescription, dbo.SystemSecurityCategoryPage.IsSiteMapPage, 
                      MAX(dbo.AccountPagePermission.AccountPagePermissionId) AS AccountPagePermissionId, MAX(dbo.AccountPagePermission.AccountId) AS AccountId, 
                      MAX(dbo.AccountPagePermission.AccountRoleId) AS AccountRoleId
FROM         dbo.AccountPagePermission INNER JOIN
                      dbo.SystemSecurityCategoryPage ON 
                      dbo.AccountPagePermission.SystemSecurityCategoryPageId = dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId
GROUP BY dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId, dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId, 
                      dbo.SystemSecurityCategoryPage.SequenceNumber, dbo.SystemSecurityCategoryPage.Folder, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPage, dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPageDescription, dbo.SystemSecurityCategoryPage.IsSiteMapPage