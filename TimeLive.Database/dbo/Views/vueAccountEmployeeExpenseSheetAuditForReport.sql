
CREATE VIEW dbo.vueAccountEmployeeExpenseSheetAuditForReport
AS
SELECT     dbo.Audit.Type, dbo.Audit.TableName, dbo.Audit.PK, dbo.Audit.FieldName AS AuditFieldName, dbo.Audit.OldValue AS AuditOldVal, 
                      dbo.Audit.NewValue AS AuditNewVal, dbo.Audit.UpdateDate, dbo.Audit.UserName, AccountProject_1.ProjectName, 
                      AccountExpense_1.AccountExpenseName, dbo.AccountExpenseEntry.Amount, 
                      CASE WHEN TableName = 'AccountEmployeeExpenseSheet' THEN AccountEmployeeExpenseSheet.AccountId WHEN TableName = 'AccountExpenseEntry'
                       THEN AccountExpenseEntry.AccountId END AS AccountId, 
                      CASE WHEN TableName = 'AccountEmployeeExpenseSheet' THEN AccountEmployeeExpenseSheet.AccountEmployeeId WHEN TableName = 'AccountExpenseEntry'
                       THEN AccountExpenseEntry.AccountEmployeeId END AS AccountEmployeeId, 
                      CASE WHEN FieldName = 'AccountExpenseId' THEN AccountExpense.AccountExpenseName WHEN FieldName = 'AccountProjectId' THEN AccountProject.ProjectName
                       WHEN FieldName = 'AccountCurrencyId' THEN vueAccountCurrency.CurrencyCode WHEN FieldName = 'AccountPaymentMethodId' THEN AccountPaymentMethod.PaymentMethod
                       WHEN FieldName = 'AccountTaxZoneId' THEN AccountTaxZone.AccountTaxZone WHEN FieldName = 'ApprovedByEmployeeId' THEN AccountEmployee_2.FirstName
                       + ' ' + AccountEmployee_2.LastName WHEN FieldName = 'RejectedByEmployeeId' THEN AccountEmployee_2.FirstName + ' ' + AccountEmployee_2.LastName
                       WHEN FieldName = 'Approved' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN Audit.OldValue <> '1' THEN 'No' END WHEN FieldName = 'Submitted'
                       THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN Audit.OldValue <> '1' THEN 'No' END WHEN FieldName = 'Rejected' THEN CASE WHEN Audit.OldValue
                       = '1' THEN 'Yes' WHEN Audit.OldValue <> '1' THEN 'No' END WHEN FieldName = 'IsBillable' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN
                       Audit.OldValue <> '1' THEN 'No' END WHEN FieldName = 'Reimburse' THEN CASE WHEN Audit.OldValue = '1' THEN 'Yes' WHEN Audit.OldValue <> '1' THEN
                       'No' END WHEN FieldName = 'Amount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.OldValue)) 
                      WHEN FieldName = 'AmountBeforeTax' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.OldValue)) 
                      WHEN FieldName = 'TaxAmount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.OldValue)) 
                      WHEN FieldName = 'Quantity' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.OldValue)) 
                      WHEN FieldName = 'Rate' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.OldValue)) ELSE Audit.OldValue END AS OldValue, 
                      CASE WHEN FieldName = 'AccountExpenseId ' THEN AccountExpense_2.AccountExpenseName WHEN FieldName = 'AccountProjectId' THEN AccountProject_2.ProjectName
                       WHEN FieldName = 'AccountCurrencyId' THEN vueAccountCurrency_1.CurrencyCode WHEN FieldName = 'AccountPaymentMethodId' THEN AccountPaymentMethod_1.PaymentMethod
                       WHEN FieldName = 'AccountTaxZoneId' THEN AccountTaxZone_1.AccountTaxZone WHEN FieldName = 'ApprovedByEmployeeId' THEN AccountEmployee_1.FirstName
                       + ' ' + AccountEmployee_1.LastName WHEN FieldName = 'RejectedByEmployeeId' THEN AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName
                       WHEN FieldName = 'SubmittedDate' THEN CONVERT(nvarchar(16), Audit.NewValue, 112) 
                      WHEN FieldName = 'Approved' THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'Submitted'
                       THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'Rejected' THEN CASE WHEN Audit.NewValue
                       = '1' THEN 'Yes' WHEN Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'IsBillable' THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN
                       Audit.NewValue <> '1' THEN 'No' END WHEN FieldName = 'Reimburse' THEN CASE WHEN Audit.NewValue = '1' THEN 'Yes' WHEN Audit.NewValue <> '1'
                       THEN 'No' END WHEN FieldName = 'Amount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) 
                      WHEN FieldName = 'AmountBeforeTax' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) 
                      WHEN FieldName = 'TaxAmount' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) 
                      WHEN FieldName = 'Quantity' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) 
                      WHEN FieldName = 'Rate' THEN CONVERT(char(100), CONVERT(decimal(10, 2), Audit.NewValue)) ELSE Audit.NewValue END AS NewValue, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS UpdatedBy, 
                      CASE WHEN FieldName = 'ApprovedByEmployeeId' THEN 'ApprovedBy' WHEN FieldName = 'RejectedByEmployeeId' THEN 'RejectedBy' WHEN FieldName
                       = 'AccountProjectId' THEN 'ProjectName' WHEN FieldName = 'AccountExpenseId' THEN 'ExpenseName' WHEN FieldName = 'AccountPaymentMethodId'
                       THEN 'PaymentMethod' WHEN FieldName = 'AccountCurrencyId' THEN 'Currency' WHEN FieldName = 'AccountTaxZoneId' THEN 'TaxZone' ELSE Audit.FieldName
                       END AS FieldName, 
                      CASE WHEN TableName = 'AccountEmployeeExpenseSheet' THEN AccountEmployeeExpenseSheet.ExpenseSheetDate WHEN TableName = 'AccountExpenseEntry'
                       THEN AccountExpenseEntry.AccountExpenseEntryDate END AS Date
FROM         dbo.AccountEmployeeExpenseSheet RIGHT OUTER JOIN
                      dbo.AccountProject AS AccountProject_1 INNER JOIN
                      dbo.AccountExpenseEntry ON AccountProject_1.AccountProjectId = dbo.AccountExpenseEntry.AccountProjectId INNER JOIN
                      dbo.AccountExpense AS AccountExpense_1 ON 
                      dbo.AccountExpenseEntry.AccountExpenseId = AccountExpense_1.AccountExpenseId RIGHT OUTER JOIN
                      dbo.Audit INNER JOIN
                      dbo.AccountEmployee ON dbo.Audit.UserName = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_2 ON dbo.Audit.OldValue = CONVERT(nvarchar(50), AccountEmployee_2.AccountEmployeeId) 
                      LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.Audit.NewValue = CONVERT(nvarchar(50), AccountEmployee_1.AccountEmployeeId) 
                      LEFT OUTER JOIN
                      dbo.AccountTaxZone ON dbo.Audit.OldValue = CONVERT(nvarchar(50), dbo.AccountTaxZone.AccountTaxZoneId) LEFT OUTER JOIN
                      dbo.AccountTaxZone AS AccountTaxZone_1 ON dbo.Audit.NewValue = CONVERT(nvarchar(50), AccountTaxZone_1.AccountTaxZoneId) LEFT OUTER JOIN
                      dbo.AccountPaymentMethod ON dbo.Audit.OldValue = CONVERT(nvarchar(50), dbo.AccountPaymentMethod.AccountPaymentMethodId) 
                      LEFT OUTER JOIN
                      dbo.AccountPaymentMethod AS AccountPaymentMethod_1 ON dbo.Audit.NewValue = CONVERT(nvarchar(50), 
                      AccountPaymentMethod_1.AccountPaymentMethodId) LEFT OUTER JOIN
                      dbo.vueAccountCurrency AS vueAccountCurrency_1 ON dbo.Audit.NewValue = CONVERT(nvarchar(50), vueAccountCurrency_1.AccountCurrencyId) 
                      LEFT OUTER JOIN
                      dbo.vueAccountCurrency ON dbo.Audit.OldValue = CONVERT(nvarchar(50), dbo.vueAccountCurrency.AccountCurrencyId) LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.Audit.OldValue = CONVERT(nvarchar(50), dbo.AccountProject.AccountProjectId) ON CONVERT(nvarchar(50), 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId) = dbo.Audit.PK ON CONVERT(nvarchar(50), 
                      dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId) = dbo.Audit.PK LEFT OUTER JOIN
                      dbo.AccountProject AS AccountProject_2 ON dbo.Audit.NewValue = CONVERT(nvarchar(50), AccountProject_2.AccountProjectId) LEFT OUTER JOIN
                      dbo.AccountExpense AS AccountExpense_2 ON dbo.Audit.NewValue = CONVERT(nvarchar(50), AccountExpense_2.AccountExpenseId) LEFT OUTER JOIN
                      dbo.AccountExpense ON dbo.Audit.OldValue = CONVERT(nvarchar(50), dbo.AccountExpense.AccountExpenseId)
WHERE     (dbo.Audit.TableName = 'AccountEmployeeExpenseSheet' OR
                      dbo.Audit.TableName = 'AccountExpenseEntry') AND (dbo.Audit.Type = 'U') AND (dbo.Audit.FieldName IN (N'ExpenseSheetDate', N'Description', 
                      'Submitted', 'Approved', 'Rejected', 'SubmittedDate', 'ApprovedOn', 'ApprovedByEmployeeId', 'RejectedByEmployeeId', 'RejectedOn', 
                      'AccountExpenseEntryDate', 'AccountProjectId', 'AccountExpenseId', 'Description', 'Amount', 'IsBillable', 'Quantity', 'Rate', 'AmountBeforeTax', 
                      'TaxAmount', 'Reimburse', 'AccountCurrencyId', 'AccountPaymentMethodId', 'AccountTaxZoneId'))