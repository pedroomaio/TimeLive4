
CREATE VIEW dbo.vueAccountBaseCurrency
AS
SELECT     dbo.AccountPreferences.AccountBaseCurrencyId, dbo.vueAccountCurrency.CurrencyCode + ' - ' + dbo.vueAccountCurrency.Currency AS BaseCurrency, 
                      dbo.AccountPreferences.AccountId, dbo.vueAccountCurrency.CurrencyCode
FROM         dbo.AccountPreferences LEFT OUTER JOIN
                      dbo.vueAccountCurrency ON dbo.AccountPreferences.AccountBaseCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId