
CREATE VIEW dbo.vueAccountCurrency
AS
SELECT     dbo.SystemCurrency.CurrencyCode, dbo.SystemCurrency.Currency, dbo.AccountCurrency.Disabled, dbo.AccountCurrency.AccountId, 
                      dbo.AccountCurrency.AccountCurrencyId, dbo.AccountCurrencyExchangeRate.ExchangeRate, dbo.AccountCurrency.AccountCurrencyExchangeRateId, 
                      dbo.AccountCurrencyExchangeRate.ExchangeRateEffectiveStartDate, dbo.AccountCurrencyExchangeRate.ExchangeRateEffectiveEndDate
FROM         dbo.AccountCurrencyExchangeRate RIGHT OUTER JOIN
                      dbo.AccountCurrency ON 
                      dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId = dbo.AccountCurrency.AccountCurrencyExchangeRateId LEFT OUTER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId