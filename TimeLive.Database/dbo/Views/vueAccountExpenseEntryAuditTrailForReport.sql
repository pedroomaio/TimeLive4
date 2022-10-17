
CREATE VIEW dbo.vueAccountExpenseEntryAuditTrailForReport
AS                         
SELECT     dbo.Audit.Type, dbo.Audit.TableName, dbo.Audit.PK, dbo.Audit.FieldName AS AuditFieldName, dbo.Audit.OldValue AS AuditOldVal, dbo.Audit.NewValue AS AuditNewVal, 
                      dbo.Audit.UpdateDate, dbo.Audit.UserName, 
                      CASE WHEN FieldName = 'AccountExpenseId' THEN AccountExpenseOld.AccountExpenseName WHEN FieldName = 'AccountProjectId' THEN AccountProjectOld.ProjectName
                       WHEN FieldName = 'AccountCurrencyId' THEN vueAccountCurrencyOld.CurrencyCode WHEN FieldName = 'AccountPaymentMethodId' THEN AccountPaymentMethodOld.PaymentMethod
                       WHEN FieldName = 'AccountTaxZoneId' THEN AccountTaxZoneOld.AccountTaxZone WHEN FieldName = 'IsBillable' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes'
                       WHEN Audit.OldValue <> '1' THEN 'No' END WHEN FieldName = 'Reimburse' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN Audit.OldValue <> '1' THEN 'No'
                       END WHEN FieldName = 'Amount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.OldValue)) 
                      WHEN FieldName = 'AmountBeforeTax' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.OldValue)) 
                      WHEN FieldName = 'TaxAmount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.OldValue)) WHEN FieldName = 'Quantity' THEN CONVERT(char(100), 
                      CONVERT(decimal(10, 2), Audit.OldValue)) WHEN FieldName = 'Rate' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.OldValue)) 
                      ELSE Audit.OldValue END AS OldValue, 
                      CASE WHEN FieldName = 'AccountExpenseId' THEN AccountExpenseNew.AccountExpenseName WHEN FieldName = 'AccountProjectId' THEN AccountProjectNew.ProjectName
                       WHEN FieldName = 'AccountCurrencyId' THEN vueAccountCurrencyNew.CurrencyCode WHEN FieldName = 'AccountPaymentMethodId' THEN AccountPaymentMethodNew.PaymentMethod
                       WHEN FieldName = 'AccountTaxZoneId' THEN AccountTaxZoneNew.AccountTaxZone WHEN FieldName = 'IsBillable' THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes'
                       WHEN Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'Reimburse' THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN
                       'No' END WHEN FieldName = 'Amount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) 
                      WHEN FieldName = 'AmountBeforeTax' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) 
                      WHEN FieldName = 'TaxAmount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) WHEN FieldName = 'Quantity' THEN CONVERT(char(100), 
                      CONVERT(decimal(10, 2), Audit.NewValue)) WHEN FieldName = 'Rate' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) 
                      ELSE Audit.NewValue END AS NewValue, 
                      CASE WHEN FieldName = 'AccountProjectId' THEN 'ProjectName' WHEN FieldName = 'AccountExpenseId' THEN 'ExpenseName' WHEN FieldName = 'AccountPaymentMethodId'
                       THEN 'PaymentMethod' WHEN FieldName = 'AccountCurrencyId' THEN 'Currency' WHEN FieldName = 'AccountTaxZoneId' THEN 'TaxZone' ELSE Audit.FieldName END
                       AS FieldName, 
                       CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)'
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName 
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)'
					  ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS UpdatedBy, dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountId, 
                      dbo.AccountExpenseEntry.AccountExpenseEntryDate AS Date, dbo.AccountExpenseEntry.AccountProjectId, dbo.AccountExpenseEntry.AccountExpenseId, 
                      dbo.AccountExpenseEntry.Amount
FROM         dbo.AccountPreferences RIGHT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountPreferences.AccountId = dbo.AccountEmployee.AccountId RIGHT OUTER JOIN
                      dbo.Audit LEFT OUTER JOIN
                      dbo.AccountExpenseEntry ON dbo.Audit.PK = dbo.AccountExpenseEntry.AccountExpenseEntryId LEFT OUTER JOIN
                      dbo.AccountProject AS AccountProjectOld ON dbo.Audit.OldValue = CONVERT(varchar, AccountProjectOld.AccountProjectId) LEFT OUTER JOIN
                      dbo.AccountProject AS AccountProjectNew ON dbo.Audit.NewValue = CONVERT(varchar, AccountProjectNew.AccountProjectId) LEFT OUTER JOIN
                      dbo.AccountExpense AS AccountExpenseOld ON dbo.Audit.OldValue = CONVERT(varchar, AccountExpenseOld.AccountExpenseId) LEFT OUTER JOIN
                      dbo.AccountExpense AS AccountExpenseNew ON dbo.Audit.NewValue = CONVERT(varchar, AccountExpenseNew.AccountExpenseId) LEFT OUTER JOIN
                      dbo.vueAccountCurrency AS vueAccountCurrencyOld ON dbo.Audit.OldValue = CONVERT(varchar, vueAccountCurrencyOld.AccountCurrencyId) LEFT OUTER JOIN
                      dbo.vueAccountCurrency AS vueAccountCurrencyNew ON dbo.Audit.NewValue = CONVERT(varchar, vueAccountCurrencyNew.AccountCurrencyId) LEFT OUTER JOIN
                      dbo.AccountTaxZone AS AccountTaxZoneOld ON dbo.Audit.OldValue = CONVERT(varchar, AccountTaxZoneOld.AccountTaxZoneId) LEFT OUTER JOIN
                      dbo.AccountTaxZone AS AccountTaxZoneNew ON dbo.Audit.NewValue = CONVERT(varchar, AccountTaxZoneNew.AccountTaxZoneId) LEFT OUTER JOIN
                      dbo.AccountPaymentMethod AS AccountPaymentMethodOld ON dbo.Audit.OldValue = CONVERT(varchar, AccountPaymentMethodOld.AccountPaymentMethodId) 
                      LEFT OUTER JOIN
                      dbo.AccountPaymentMethod AS AccountPaymentMethodNew ON dbo.Audit.NewValue = CONVERT(varchar, AccountPaymentMethodNew.AccountPaymentMethodId) ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.Audit.UserName
WHERE     (dbo.Audit.TableName = 'AccountExpenseEntry') AND (dbo.Audit.Type = 'U') AND (dbo.Audit.FieldName IN ('AccountExpenseEntryDate', 'AccountProjectId', 
                      'AccountExpenseId', 'Description', 'Amount', 'IsBillable', 'Quantity', 'Rate', 'AmountBeforeTax', 'TaxAmount', 'Reimburse', 'AccountCurrencyId', 
                      'AccountPaymentMethodId', 'AccountTaxZoneId'))