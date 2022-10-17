
CREATE VIEW dbo.vueAccountTimeExpenseBillingExpenseForEdit
AS
SELECT     dbo.AccountParty.PartyName, dbo.AccountTimeExpenseBilling.InvoiceNumber, dbo.AccountTimeExpenseBilling.InvoiceDate, 
                      dbo.AccountTimeExpenseBilling.PONumber, dbo.AccountProject.ProjectName, dbo.AccountProject.AccountProjectId, 
                      dbo.AccountParty.AccountPartyId AS AccountClientId, dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingExpenseId, 
                      dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingId, dbo.AccountTimeExpenseBillingExpense.Description, 
                      dbo.AccountTimeExpenseBillingExpense.ActualExpenseAmount, dbo.AccountTimeExpenseBillingExpense.BilledExpenseAmount, 
                      dbo.AccountExpense.AccountExpenseId, dbo.AccountExpense.AccountExpenseName, dbo.AccountExpenseType.AccountExpenseTypeId, 
                      dbo.AccountExpenseType.ExpenseType, dbo.AccountCurrencyExchangeRate.ExchangeRate, dbo.AccountTimeExpenseBillingExpense.AccountTaxCodeId1, 
                      dbo.AccountTimeExpenseBillingExpense.AccountTaxCodeId2, dbo.AccountTimeExpenseBillingExpense.TaxCode1, 
                      dbo.AccountTimeExpenseBillingExpense.TaxCode2, dbo.AccountTimeExpenseBillingExpense.AccountExpenseEntryId
FROM         dbo.AccountCurrencyExchangeRate RIGHT OUTER JOIN
                      dbo.AccountCurrency ON 
                      dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId = dbo.AccountCurrency.AccountCurrencyExchangeRateId RIGHT OUTER JOIN
                      dbo.AccountTimeExpenseBillingExpense INNER JOIN
                      dbo.AccountParty ON dbo.AccountTimeExpenseBillingExpense.AccountId = dbo.AccountParty.AccountId INNER JOIN
                      dbo.AccountTimeExpenseBilling ON 
                      dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId AND 
                      dbo.AccountParty.AccountPartyId = dbo.AccountTimeExpenseBilling.AccountClientId LEFT OUTER JOIN
                      dbo.AccountExpenseType ON dbo.AccountTimeExpenseBillingExpense.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountExpense ON dbo.AccountTimeExpenseBillingExpense.AccountExpenseId = dbo.AccountExpense.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountTimeExpenseBillingExpense.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountCurrency.AccountCurrencyId = dbo.AccountTimeExpenseBilling.AccountCurrencyId