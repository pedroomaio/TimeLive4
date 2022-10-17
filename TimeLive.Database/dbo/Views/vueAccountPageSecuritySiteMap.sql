
CREATE VIEW dbo.vueAccountPageSecuritySiteMap
AS
SELECT     dbo.CombineValuesForSiteMap(dbo.vueSystemPagesSiteMap.SystemSecurityCategoryPageId, dbo.vueSystemPagesSiteMap.AccountId) AS Roles, 
                      dbo.vueSystemPagesSiteMap.AccountId, dbo.vueSystemPagesSiteMap.SystemSecurityCategoryPageId, dbo.SystemSecurityCategoryPage.SequenceNumber, 
                      dbo.SystemSecurityCategoryPage.Folder, dbo.SystemSecurityCategoryPage.SystemCategoryPage, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPageDescription, dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId, 
                      dbo.SystemSecurityCategoryPage.IsSiteMapPage, dbo.SystemSecurityCategoryPage.IsCustomizeable, dbo.SystemSecurityCategoryPage.IsAllowAdd, 
                      dbo.SystemSecurityCategoryPage.IsAllowEdit, dbo.SystemSecurityCategoryPage.IsAllowDelete, dbo.SystemSecurityCategoryPage.IsAllowList, 
                      dbo.SystemSecurityCategoryPage.IsShowDataOptions, dbo.SystemSecurityCategoryPage.IsShowTillOptions, dbo.SystemSecurityCategoryPage.IsSystemPage, 
                      dbo.SystemSecurityCategoryPage.ControlLevelPermission, dbo.SystemSecurityCategoryPage.NotShowInPermission, 
                      dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId, dbo.SystemSecurityCategory.SystemSecurityCategory, 
                      SystemSecurityCategoryPage_1.Folder AS ParentFolder, SystemSecurityCategoryPage_1.SystemCategoryPage AS ParentSystemCategoryPage, 
                      SystemSecurityCategoryPage_1.SystemCategoryPageDescription AS ParentSystemCategoryPageDescription, 
                      SystemSecurityCategoryPage_1.IsSiteMapPage AS ParentIsSiteMapPage, dbo.SystemSecurityCategoryPage.SystemFeatureId
FROM         dbo.vueSystemPagesSiteMap INNER JOIN
                      dbo.SystemSecurityCategoryPage ON 
                      dbo.vueSystemPagesSiteMap.SystemSecurityCategoryPageId = dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId INNER JOIN
                      dbo.SystemSecurityCategory ON dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId = dbo.SystemSecurityCategory.SystemSecurityCategoryId AND 
                      dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId = dbo.SystemSecurityCategory.SystemSecurityCategoryId LEFT OUTER JOIN
                      dbo.SystemSecurityCategoryPage AS SystemSecurityCategoryPage_1 ON 
                      dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId = SystemSecurityCategoryPage_1.SystemSecurityCategoryPageId