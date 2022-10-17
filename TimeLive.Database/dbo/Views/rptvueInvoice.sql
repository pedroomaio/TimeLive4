
CREATE VIEW dbo.rptvueInvoice
AS
SELECT     dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId, dbo.AccountTimeExpenseBilling.AccountClientId, 
                      dbo.AccountTimeExpenseBilling.BillingCycleStartDate, dbo.AccountTimeExpenseBilling.BillingCycleEndDate, 
                      dbo.AccountTimeExpenseBilling.InvoiceNumber, dbo.AccountTimeExpenseBilling.InvoiceDate, dbo.AccountTimeExpenseBilling.PONumber, 
                      dbo.AccountTimeExpenseBilling.Description, dbo.AccountTimeExpenseBilling.SubTotal, dbo.AccountTimeExpenseBilling.TaxCode1, 
                      dbo.AccountTimeExpenseBilling.TaxCode2, dbo.AccountTimeExpenseBilling.GrandTotal, dbo.AccountParty.PartyName, dbo.Account.AccountId, 
                      dbo.AccountTimeExpenseBilling.IsPaid, dbo.SystemCurrency.CurrencyCode, 
                      dbo.AccountCurrencyExchangeRate.ExchangeRate AS CurrencyExchangeRate, 
                      CASE WHEN dbo.AccountCurrencyExchangeRate.ExchangeRate > 0 THEN dbo.AccountTimeExpenseBilling.GrandTotal / dbo.AccountCurrencyExchangeRate.ExchangeRate
                       ELSE 0 END AS CurrencyNetAmount
FROM         dbo.AccountCurrencyExchangeRate RIGHT OUTER JOIN
                      dbo.AccountCurrency ON 
                      dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId = dbo.AccountCurrency.AccountCurrencyExchangeRateId LEFT OUTER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId RIGHT OUTER JOIN
                      dbo.AccountParty INNER JOIN
                      dbo.AccountTimeExpenseBilling ON dbo.AccountParty.AccountPartyId = dbo.AccountTimeExpenseBilling.AccountClientId INNER JOIN
                      dbo.Account ON dbo.AccountParty.AccountId = dbo.Account.AccountId ON 
                      dbo.AccountCurrency.AccountCurrencyId = dbo.AccountTimeExpenseBilling.AccountCurrencyId