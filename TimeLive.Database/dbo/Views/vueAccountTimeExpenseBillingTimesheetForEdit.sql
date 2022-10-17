
CREATE VIEW dbo.vueAccountTimeExpenseBillingTimesheetForEdit
AS
SELECT     dbo.AccountProject.AccountClientId, dbo.AccountProject.ProjectName, dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.AccountProjectTaskId, 
                      dbo.AccountProject.AccountProjectId, dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingTimesheetId, 
                      dbo.AccountTimeExpenseBillingTimesheet.Description, dbo.AccountTimeExpenseBillingTimesheet.BillingRate, dbo.AccountTimeExpenseBillingTimesheet.BillHours, 
                      dbo.AccountTimeExpenseBillingTimesheet.TotalAmount, dbo.AccountTimeExpenseBillingTimesheet.AccountTaxCodeId1, 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountTaxCodeId2, dbo.AccountTimeExpenseBillingTimesheet.TaxCode2, 
                      dbo.AccountTimeExpenseBillingTimesheet.TaxCode1, dbo.AccountTimeExpenseBillingTimesheet.ActualHours, 
                      dbo.AccountTimeExpenseBillingTimesheet.ActualBillingRate, dbo.AccountParty.PartyName, dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingId, 
                      dbo.AccountTimeExpenseBilling.InvoiceNumber, dbo.AccountCurrencyExchangeRate.ExchangeRate, 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountEmployeeTimeEntryId
FROM         dbo.AccountCurrency LEFT OUTER JOIN
                      dbo.AccountCurrencyExchangeRate ON 
                      dbo.AccountCurrency.AccountCurrencyExchangeRateId = dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId RIGHT OUTER JOIN
                      dbo.AccountTimeExpenseBillingTimesheet INNER JOIN
                      dbo.AccountTimeExpenseBilling ON 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId INNER JOIN
                      dbo.AccountParty ON dbo.AccountTimeExpenseBilling.AccountClientId = dbo.AccountParty.AccountPartyId AND 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountId = dbo.AccountParty.AccountId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountTimeExpenseBillingTimesheet.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountTimeExpenseBillingTimesheet.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountCurrency.AccountCurrencyId = dbo.AccountTimeExpenseBilling.AccountCurrencyId