
CREATE VIEW dbo.vueAccountPagePermission
AS
SELECT     dbo.AccountPagePermission.AccountPagePermissionId, dbo.AccountPagePermission.AccountId, dbo.AccountPagePermission.AccountRoleId, 
                      dbo.AccountPagePermission.SystemSecurityCategoryPageId, dbo.AccountPagePermission.ShowAllData, dbo.AccountPagePermission.ShowMyData, 
                      dbo.AccountPagePermission.ShowMyProjectsData, dbo.AccountPagePermission.ShowMyTeamsData, dbo.AccountPagePermission.TillDate, 
                      dbo.AccountPagePermission.TillHours, dbo.SystemSecurityCategoryPage.Folder, dbo.SystemSecurityCategoryPage.SystemCategoryPage, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPageDescription, dbo.SystemSecurityCategoryPage.IsSiteMapPage, dbo.SystemPermission.SystemPermission, 
                      dbo.AccountRole.Role, dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId, 
                      SystemSecurityCategoryPage_1.SystemCategoryPage AS ParentSystemCategoryPage, 
                      SystemSecurityCategoryPage_1.SystemCategoryPageDescription AS ParentSystemCategoryPageDescription, 
                      SystemSecurityCategoryPage_1.IsSiteMapPage AS ParentIsSiteMapPage, SystemSecurityCategoryPage_1.Folder AS ParentFolder, 
                      dbo.SystemSecurityCategoryPage.SequenceNumber, dbo.AccountPagePermission.SystemPermissionId, dbo.SystemSecurityCategoryPage.ControlLevelPermission, 
                      dbo.AccountPagePermission.ShowMySubOrdinatesData, dbo.SystemSecurityCategoryPage.SystemFeatureId
FROM         dbo.AccountPagePermission INNER JOIN
                      dbo.SystemSecurityCategoryPage ON 
                      dbo.AccountPagePermission.SystemSecurityCategoryPageId = dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId INNER JOIN
                      dbo.AccountRole ON dbo.AccountPagePermission.AccountRoleId = dbo.AccountRole.AccountRoleId INNER JOIN
                      dbo.SystemPermission ON dbo.AccountPagePermission.SystemPermissionId = dbo.SystemPermission.SystemPermissionId LEFT OUTER JOIN
                      dbo.SystemSecurityCategoryPage AS SystemSecurityCategoryPage_1 ON 
                      dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId = SystemSecurityCategoryPage_1.SystemSecurityCategoryPageId