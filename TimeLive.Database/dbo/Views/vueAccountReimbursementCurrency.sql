
CREATE VIEW dbo.vueAccountReimbursementCurrency
AS
SELECT     dbo.vueAccountCurrency.CurrencyCode + ' - ' + dbo.vueAccountCurrency.Currency AS ReimbursmentCurrency, dbo.AccountPreferences.AccountId, 
                      dbo.vueAccountCurrency.CurrencyCode, dbo.AccountPreferences.AccountReimbursementCurrencyId
FROM         dbo.AccountPreferences INNER JOIN
                      dbo.vueAccountCurrency ON dbo.AccountPreferences.AccountReimbursementCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId AND 
                      dbo.AccountPreferences.AccountId = dbo.vueAccountCurrency.AccountId