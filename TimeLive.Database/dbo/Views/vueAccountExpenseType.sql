
CREATE VIEW dbo.vueAccountExpenseType
AS
SELECT     AccountExpenseType_1.AccountExpenseTypeId, AccountExpenseType_1.ExpenseType, AccountExpenseType_1.AccountId, 
                      AccountExpenseType_1.CreatedOn, AccountExpenseType_1.ModifiedOn, AccountExpenseType_1.CreatedByEmployeeId, 
                      AccountExpenseType_1.ModifiedByEmployeeId, AccountExpenseType_1.IsDisabled, AccountExpenseType_1.IsQuantityField, 
                      AccountExpenseType_1.QuantityFieldCaption, dbo.AccountTaxZone.AccountTaxZone, dbo.AccountTaxZone.AccountTaxZoneId, 
                      dbo.AccountTaxCode.TaxCode, dbo.AccountTaxCode.Formula, dbo.AccountTaxCode.AccountTaxCodeId
FROM         dbo.AccountExpenseTypeTaxCode LEFT OUTER JOIN
                      dbo.AccountTaxCode ON dbo.AccountExpenseTypeTaxCode.AccountTaxZoneId = dbo.AccountTaxCode.AccountTaxZoneId AND 
                      dbo.AccountExpenseTypeTaxCode.AccountTaxCodeId = dbo.AccountTaxCode.AccountTaxCodeId RIGHT OUTER JOIN
                      dbo.AccountExpenseType AS AccountExpenseType_1 INNER JOIN
                      dbo.AccountTaxZone ON AccountExpenseType_1.AccountId = dbo.AccountTaxZone.AccountId ON 
                      dbo.AccountExpenseTypeTaxCode.AccountExpenseTypeId = AccountExpenseType_1.AccountExpenseTypeId AND 
                      dbo.AccountExpenseTypeTaxCode.AccountTaxZoneId = dbo.AccountTaxZone.AccountTaxZoneId