
CREATE VIEW dbo.vueAccountWorkTypeBillingRate
AS
SELECT     dbo.AccountWorkTypeBillingRate.AccountWorkTypeBillingRateId, dbo.AccountWorkTypeBillingRate.AccountId, 
                      dbo.AccountWorkTypeBillingRate.SystemBillingRateTypeId, dbo.AccountWorkTypeBillingRate.AccountEmployeeId, 
                      dbo.AccountWorkTypeBillingRate.AccountProjectEmployeeId, dbo.AccountWorkTypeBillingRate.AccountProjectRoleId, 
                      dbo.AccountWorkTypeBillingRate.AccountProjectTaskId, dbo.AccountWorkTypeBillingRate.AccountBillingRateId, 
                      dbo.AccountWorkTypeBillingRate.AccountWorkTypeId, dbo.AccountWorkType.AccountWorkTypeCode, dbo.AccountWorkType.AccountWorkType, 
                      dbo.AccountWorkType.SystemWorkTypeId, dbo.AccountBillingRate.BillingRate, dbo.AccountBillingRate.StartDate, dbo.AccountBillingRate.EndDate, 
                      dbo.AccountBillingRate.EmployeeRate, dbo.AccountBillingRate.BillingRateCurrencyId, dbo.AccountBillingRate.EmployeeRateCurrencyId, 
                      vueAccountCurrency_1.CurrencyCode AS EmployeeRateCurrencyCode, dbo.vueAccountCurrency.CurrencyCode AS BillingRateCurrencyCode
FROM         dbo.AccountWorkTypeBillingRate INNER JOIN
                      dbo.AccountWorkType ON dbo.AccountWorkTypeBillingRate.AccountWorkTypeId = dbo.AccountWorkType.AccountWorkTypeId INNER JOIN
                      dbo.AccountBillingRate ON dbo.AccountWorkTypeBillingRate.AccountBillingRateId = dbo.AccountBillingRate.AccountBillingRateId LEFT OUTER JOIN
                      dbo.vueAccountCurrency ON dbo.AccountBillingRate.BillingRateCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId LEFT OUTER JOIN
                      dbo.vueAccountCurrency AS vueAccountCurrency_1 ON 
                      dbo.AccountBillingRate.EmployeeRateCurrencyId = vueAccountCurrency_1.AccountCurrencyId
WHERE     (dbo.AccountWorkType.SystemWorkTypeId = 1)