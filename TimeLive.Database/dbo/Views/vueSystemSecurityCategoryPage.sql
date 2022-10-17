
CREATE VIEW dbo.vueSystemSecurityCategoryPage
AS
SELECT     dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId, dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId, 
                      dbo.SystemSecurityCategoryPage.SequenceNumber, dbo.SystemSecurityCategoryPage.Folder, dbo.SystemSecurityCategoryPage.SystemCategoryPage, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPageDescription, dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId, 
                      dbo.SystemSecurityCategoryPage.IsSiteMapPage, dbo.SystemSecurityCategoryPage.IsCustomizeable, dbo.SystemSecurityCategoryPage.IsAllowAdd, 
                      dbo.SystemSecurityCategoryPage.IsAllowEdit, dbo.SystemSecurityCategoryPage.IsAllowDelete, dbo.SystemSecurityCategoryPage.IsAllowList, 
                      dbo.SystemSecurityCategoryPage.IsShowDataOptions, dbo.SystemSecurityCategoryPage.IsShowTillOptions, dbo.SystemSecurityCategoryPage.IsSystemPage, 
                      dbo.SystemSecurityCategory.SystemSecurityCategory, dbo.SystemSecurityCategoryPage.NotShowInPermission, 
                      dbo.SystemSecurityCategoryPage.SystemFeatureId
FROM         dbo.SystemSecurityCategoryPage INNER JOIN
                      dbo.SystemSecurityCategory ON dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId = dbo.SystemSecurityCategory.SystemSecurityCategoryId AND 
                      dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId = dbo.SystemSecurityCategory.SystemSecurityCategoryId