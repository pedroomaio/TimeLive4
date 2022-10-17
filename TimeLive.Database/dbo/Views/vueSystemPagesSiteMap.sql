
CREATE VIEW dbo.vueSystemPagesSiteMap
AS
SELECT     SystemSecurityCategoryPageId, AccountId
FROM         dbo.AccountPagePermission
GROUP BY SystemSecurityCategoryPageId, AccountId