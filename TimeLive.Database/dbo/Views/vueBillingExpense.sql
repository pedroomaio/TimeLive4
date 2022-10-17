
CREATE VIEW dbo.vueBillingExpense
AS
SELECT     dbo.AccountTimeExpenseBilling.AccountClientId, dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingExpenseId, 
                      dbo.AccountTimeExpenseBillingExpense.AccountId, dbo.AccountTimeExpenseBillingExpense.AccountProjectId, 
                      dbo.AccountTimeExpenseBillingExpense.AccountExpenseTypeId, dbo.AccountTimeExpenseBillingExpense.AccountExpenseId, 
                      dbo.AccountTimeExpenseBillingExpense.BilledExpenseAmount
FROM         dbo.AccountTimeExpenseBilling LEFT OUTER JOIN
                      dbo.AccountTimeExpenseBillingExpense ON 
                      dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingId