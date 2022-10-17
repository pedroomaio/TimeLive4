
CREATE VIEW dbo.vueAccountFeatures
AS
SELECT     dbo.SystemFeatures.SystemFeatureId, dbo.SystemFeatures.SystemFeatureName, dbo.AccountFeatures.AccountId, 
                      dbo.AccountFeatures.AccountFeatureId, dbo.AccountFeatures.SortOrder
FROM         dbo.SystemFeatures LEFT OUTER JOIN
                      dbo.AccountFeatures ON dbo.SystemFeatures.SystemFeatureId = dbo.AccountFeatures.SystemFeatureId