CREATE VIEW dbo.vueAccountBillingType
AS
SELECT     dbo.AccountBillingType.AccountBillingTypeId, dbo.AccountBillingType.AccountId, dbo.AccountBillingType.BillingType, 
                      dbo.SystemBillingCategory.SystemBillingCategory, dbo.AccountBillingType.MasterAccountBillingTypeId, dbo.AccountBillingType.IsDisabled
FROM         dbo.AccountBillingType LEFT OUTER JOIN
                      dbo.SystemBillingCategory ON dbo.AccountBillingType.BillingCategoryId = dbo.SystemBillingCategory.SystemBillingCategoryId