CREATE VIEW dbo.vueAccountBillingRate
AS
SELECT     dbo.AccountBillingRate.AccountBillingRateId, dbo.AccountBillingRate.AccountId, dbo.AccountBillingRate.SystemBillingRateTypeId, 
                      dbo.AccountBillingRate.AccountProjectEmployeeId, dbo.AccountBillingRate.AccountProjectRoleId, dbo.AccountBillingRate.BillingRate, 
                      dbo.AccountBillingRate.StartDate, dbo.AccountBillingRate.EndDate, dbo.AccountBillingRate.AccountEmployeeId, 
                      dbo.AccountBillingRate.AccountProjectTaskId, dbo.AccountBillingRate.AccountWorkTypeId, dbo.AccountBillingRate.EmployeeRate, 
                      dbo.AccountBillingRate.BillingRateCurrencyId, dbo.AccountBillingRate.EmployeeRateCurrencyId, 
                      dbo.vueAccountCurrency.CurrencyCode AS BillingRateCurrencyCode, vueAccountCurrency_1.CurrencyCode AS EmployeeRateCurrencyCode
FROM         dbo.AccountBillingRate LEFT OUTER JOIN
                      dbo.vueAccountCurrency AS vueAccountCurrency_1 ON 
                      dbo.AccountBillingRate.EmployeeRateCurrencyId = vueAccountCurrency_1.AccountCurrencyId AND 
                      dbo.AccountBillingRate.AccountId = vueAccountCurrency_1.AccountId LEFT OUTER JOIN
                      dbo.vueAccountCurrency ON dbo.AccountBillingRate.BillingRateCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId AND 
                      dbo.AccountBillingRate.AccountId = dbo.vueAccountCurrency.AccountId