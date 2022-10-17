
CREATE VIEW dbo.vueAccountTimeExpenseBillingExpense
AS
SELECT     dbo.AccountExpenseEntry.Billed, dbo.AccountProject.ProjectName, dbo.AccountProject.AccountClientId, dbo.AccountProject.AccountProjectId, 
                      dbo.AccountExpense.AccountExpenseName, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpenseEntry.AccountTimeExpenseBillingExpenseId, 
                      dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseType.AccountExpenseTypeId, dbo.AccountExpense.AccountExpenseId, 
                      dbo.AccountTimeExpenseBillingExpense.BilledExpenseAmount, dbo.AccountTimeExpenseBillingExpense.Description, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId, dbo.AccountExpenseEntry.Amount, dbo.AccountExpenseEntry.ExchangeRate, 
                      dbo.AccountTimeExpenseBillingExpense.ActualExpenseAmount, dbo.AccountTimeExpenseBillingExpense.AccountTaxCodeId1, 
                      dbo.AccountTimeExpenseBillingExpense.AccountTaxCodeId2, dbo.AccountTimeExpenseBillingExpense.TaxCode1, 
                      dbo.AccountTimeExpenseBillingExpense.TaxCode2, dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpenseEntry.Description AS ExpenseDescription, 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId
FROM         dbo.AccountTimeExpenseBillingExpense INNER JOIN
                      dbo.AccountTimeExpenseBilling ON 
                      dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId RIGHT OUTER JOIN
                      dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountProject ON dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId INNER JOIN
                      dbo.AccountExpenseType ON dbo.AccountExpenseType.AccountExpenseTypeId = dbo.AccountExpense.AccountExpenseTypeId RIGHT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountParty.AccountPartyId = dbo.AccountProject.AccountClientId ON 
                      dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingExpenseId = dbo.AccountExpenseEntry.AccountTimeExpenseBillingExpenseId AND 
                      dbo.AccountTimeExpenseBillingExpense.AccountProjectId = dbo.AccountExpenseEntry.AccountProjectId AND 
                      dbo.AccountTimeExpenseBillingExpense.AccountExpenseId = dbo.AccountExpenseEntry.AccountExpenseId
WHERE     (dbo.AccountExpenseEntry.Approved = 1) AND (dbo.AccountExpenseEntry.Billed <> 1)