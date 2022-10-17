
CREATE VIEW dbo.vueAccountExpenseWithTaxCode
AS
SELECT     dbo.AccountExpense.AccountExpenseId, dbo.AccountExpense.AccountId, dbo.AccountExpenseType.AccountExpenseTypeId, 
                      dbo.AccountExpenseType.ExpenseType, dbo.AccountExpenseType.IsQuantityField, dbo.AccountExpenseType.QuantityFieldCaption, 
                      dbo.AccountTaxCode.Formula, dbo.AccountTaxCode.TaxCode, dbo.AccountTaxCode.AccountTaxZoneId, dbo.AccountTaxCode.AccountTaxCodeId, 
                      dbo.AccountExpense.DefaultExpenseRate, dbo.AccountExpense.DisabledEditingOfRate
FROM         dbo.AccountExpenseTypeTaxCode RIGHT OUTER JOIN
                      dbo.AccountTaxCode ON dbo.AccountExpenseTypeTaxCode.AccountTaxCodeId = dbo.AccountTaxCode.AccountTaxCodeId RIGHT OUTER JOIN
                      dbo.AccountExpenseType ON 
                      dbo.AccountExpenseTypeTaxCode.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId RIGHT OUTER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseType.AccountExpenseTypeId = dbo.AccountExpense.AccountExpenseTypeId