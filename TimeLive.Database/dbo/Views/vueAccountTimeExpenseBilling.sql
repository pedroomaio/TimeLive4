
CREATE VIEW dbo.vueAccountTimeExpenseBilling
AS
SELECT     dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId, dbo.AccountTimeExpenseBilling.AccountId, 
                      dbo.AccountTimeExpenseBilling.AccountClientId, dbo.AccountTimeExpenseBilling.BillingCycleStartDate, 
                      dbo.AccountTimeExpenseBilling.BillingCycleEndDate, dbo.AccountTimeExpenseBilling.InvoiceNumber, dbo.AccountTimeExpenseBilling.InvoiceDate, 
                      dbo.AccountTimeExpenseBilling.PONumber, dbo.AccountTimeExpenseBilling.CreatedOn, dbo.AccountTimeExpenseBilling.CreatedByEmployeeId, 
                      dbo.AccountTimeExpenseBilling.ModifiedOn, dbo.AccountTimeExpenseBilling.ModifiedByEmployeeId, dbo.AccountTimeExpenseBilling.IsDisabled, 
                      dbo.AccountParty.PartyName, dbo.AccountTimeExpenseBilling.AccountCurrencyId, dbo.SystemCurrency.CurrencyCode, 
                      dbo.AccountTimeExpenseBilling.Description, dbo.AccountTimeExpenseBilling.IsPaid, dbo.AccountTimeExpenseBilling.GrandTotal, 
                      dbo.AccountTimeExpenseBilling.AccountProjectId
FROM         dbo.AccountCurrency INNER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId RIGHT OUTER JOIN
                      dbo.AccountTimeExpenseBilling INNER JOIN
                      dbo.AccountParty ON dbo.AccountTimeExpenseBilling.AccountClientId = dbo.AccountParty.AccountPartyId AND 
                      dbo.AccountTimeExpenseBilling.AccountId = dbo.AccountParty.AccountId ON 
                      dbo.AccountCurrency.AccountCurrencyId = dbo.AccountTimeExpenseBilling.AccountCurrencyId