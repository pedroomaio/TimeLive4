
CREATE VIEW dbo.vueAccountCurrencyExchangeRate
AS
SELECT     dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId, dbo.AccountCurrencyExchangeRate.ExchangeRateEffectiveStartDate, 
                      dbo.AccountCurrencyExchangeRate.ExchangeRateEffectiveEndDate, dbo.AccountCurrencyExchangeRate.ExchangeRate, 
                      dbo.AccountCurrencyExchangeRate.AccountId, dbo.AccountCurrency.AccountCurrencyId
FROM         dbo.AccountCurrencyExchangeRate LEFT OUTER JOIN
                      dbo.AccountCurrency ON dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId = dbo.AccountCurrency.AccountCurrencyExchangeRateId