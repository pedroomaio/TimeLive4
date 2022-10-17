CREATE VIEW dbo.vueSystemDefaultSecurity
AS
SELECT     dbo.SystemSecurityCategory.SystemSecurityCategoryId, dbo.SystemSecurityCategory.SystemSecurityCategory, 
                      dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId, dbo.SystemSecurityCategoryPage.Folder, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPage, dbo.SystemSecurityCategoryPage.SystemCategoryPageDescription, 
                      dbo.SystemSecurityCategoryMasterAccountRole.MasterRoleId, dbo.MasterAccountRole.Role, 
                      dbo.SystemSecurityCategoryPermission.SystemPermissionId, dbo.SystemSecurityCategoryPermission.SystemSecurityCategoryPermissionId, 
                      dbo.SystemSecurityCategoryPermission.TillDate, dbo.SystemSecurityCategoryPermission.TillHours, dbo.SystemPermission.SystemPermission, 
                      dbo.SystemSecurityCategoryMasterAccountRole.ShowMyData, dbo.SystemSecurityCategoryMasterAccountRole.ShowMyTeamsData, 
                      dbo.SystemSecurityCategoryMasterAccountRole.ShowMyProjectsData, dbo.SystemSecurityCategoryMasterAccountRole.ShowAllData, 
                      dbo.SystemSecurityCategoryPage.IsAllowAdd, dbo.SystemSecurityCategoryPage.IsAllowEdit, dbo.SystemSecurityCategoryPage.IsAllowDelete, 
                      dbo.SystemSecurityCategoryPage.IsAllowList
FROM         dbo.SystemSecurityCategory INNER JOIN
                      dbo.SystemSecurityCategoryPage ON 
                      dbo.SystemSecurityCategory.SystemSecurityCategoryId = dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId INNER JOIN
                      dbo.SystemSecurityCategoryMasterAccountRole ON 
                      dbo.SystemSecurityCategory.SystemSecurityCategoryId = dbo.SystemSecurityCategoryMasterAccountRole.SystemSecurityCategoryId INNER JOIN
                      dbo.MasterAccountRole ON dbo.SystemSecurityCategoryMasterAccountRole.MasterRoleId = dbo.MasterAccountRole.MasterAccountRoleId INNER JOIN
                      dbo.SystemSecurityCategoryPermission ON 
                      dbo.SystemSecurityCategory.SystemSecurityCategoryId = dbo.SystemSecurityCategoryPermission.SystemSecurityCategoryId INNER JOIN
                      dbo.SystemPermission ON dbo.SystemSecurityCategoryPermission.SystemPermissionId = dbo.SystemPermission.SystemPermissionId
WHERE     (dbo.SystemSecurityCategoryPermission.SystemPermissionId = 1) AND (ISNULL(dbo.SystemSecurityCategoryPage.IsAllowList, 0) = 1) OR
                      (dbo.SystemSecurityCategoryPermission.SystemPermissionId = 2) AND (ISNULL(dbo.SystemSecurityCategoryPage.IsAllowAdd, 0) = 1) OR
                      (dbo.SystemSecurityCategoryPermission.SystemPermissionId = 3) AND (ISNULL(dbo.SystemSecurityCategoryPage.IsAllowEdit, 0) = 1) OR
                      (dbo.SystemSecurityCategoryPermission.SystemPermissionId = 4) AND (ISNULL(dbo.SystemSecurityCategoryPage.IsAllowDelete, 0) = 1) OR
                      (dbo.SystemSecurityCategoryPage.IsCustomizeable = 0)