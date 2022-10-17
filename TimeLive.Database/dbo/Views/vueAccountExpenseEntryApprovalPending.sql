
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPending
AS      
SELECT     dbo.vueAccountExpenseEntryApproval.AccountProjectId, dbo.vueAccountExpenseEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId, dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountExpenseEntryApproval.SystemApproverTypeId, dbo.vueAccountExpenseEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApproval.AccountEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId, MAX(dbo.vueAccountExpenseEntryApproval.ExpenseApprovalId) AS ExpenseApprovalId, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.vueAccountExpenseEntryApproval.ProjectName, 
                      dbo.vueAccountExpenseEntryApproval.ProjectDescription, dbo.vueAccountExpenseEntryApproval.ProjectCode, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeName, dbo.vueAccountExpenseEntryApproval.Approved, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryDate, 
                      MAX(dbo.vueAccountExpenseEntryApproval.Comments) AS Comments, dbo.vueAccountExpenseEntryApproval.IsRejected, 
                      dbo.vueAccountExpenseEntryApproval.IsApproved, CASE WHEN MAX(dbo.vueAccountExpenseEntryApproval.ExchangeRate) 
                      <> 0 THEN (dbo.vueAccountExpenseEntryApproval.Amount / MAX(dbo.vueAccountExpenseEntryApproval.ExchangeRate)) 
                      * dbo.vueAccountCurrency.ExchangeRate ELSE 0 END AS Amount, dbo.vueAccountExpenseEntryApproval.AccountExpenseName, 
                      dbo.vueAccountExpenseEntryApproval.IsBillable, dbo.vueAccountApproverType.MaxApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseEntryAccountEmployeeId, dbo.vueAccountExpenseEntryApproval.Description, 
                      dbo.vueAccountExpenseEntryApproval.AccountId, dbo.vueAccountExpenseEntryApproval.EMailAddress, dbo.vueAccountExpenseEntryApproval.Submitted, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeManagerId, dbo.vueAccountExpenseEntryApproval.CurrencyCode, dbo.vueAccountExpenseEntryApproval.Rejected, 
                      dbo.vueAccountExpenseEntryApproval.AccountEmployeeExpenseSheetId, MAX(dbo.vueAccountCurrency.CurrencyCode) AS BaseCurrencyCode, 
                      MAX(dbo.vueAccountCurrency.Currency) AS BaseCurrency, dbo.vueAccountCurrency.ExchangeRate AS BaseCurrencyExchangeRate, 
                      MAX(dbo.vueAccountExpenseEntryApproval.MasterDescription) AS MasterDescription, MAX(dbo.vueAccountExpenseEntryApproval.ExpenseSheetDate) 
                      AS ExpenseSheetDate, MAX(dbo.vueAccountExpenseEntryApproval.SubmittedDate) AS SubmittedDate, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeNameWithCode
FROM         dbo.vueAccountExpenseEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountExpenseEntryApproval.AccountId = dbo.AccountPreferences.AccountId INNER JOIN
                      dbo.vueAccountCurrency ON dbo.AccountPreferences.AccountBaseCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId
WHERE     (dbo.vueAccountExpenseEntryApproval.ApprovalPathSequence IN
                          (SELECT     TOP (1) ApprovalPathSequence
                            FROM          dbo.vueExpenseApprovalSequence AS vueExpenseApprovalSequence_1
                            WHERE      (ExpenseApprovalId IS NULL) AND (AccountExpenseEntryId = dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId))) AND 
                      (dbo.vueAccountExpenseEntryApproval.Approved = 0) AND (dbo.vueAccountExpenseEntryApproval.Submitted = 1) AND 
                      (dbo.vueAccountExpenseEntryApproval.Rejected IS NULL OR
                      dbo.vueAccountExpenseEntryApproval.Rejected = 0)
GROUP BY dbo.vueAccountExpenseEntryApproval.AccountProjectId, dbo.vueAccountExpenseEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId, dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountExpenseEntryApproval.SystemApproverTypeId, dbo.vueAccountExpenseEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApproval.AccountEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId, dbo.vueAccountExpenseEntryApproval.ExpenseApprovalPathId, 
                      dbo.vueAccountExpenseEntryApproval.ProjectName, dbo.vueAccountExpenseEntryApproval.ProjectDescription, dbo.vueAccountExpenseEntryApproval.ProjectCode, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeName, dbo.vueAccountExpenseEntryApproval.Approved, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntryApproval.IsRejected, dbo.vueAccountExpenseEntryApproval.IsApproved, dbo.vueAccountExpenseEntryApproval.Amount, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseName, dbo.vueAccountExpenseEntryApproval.IsBillable, 
                      dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueAccountExpenseEntryApproval.ExpenseEntryAccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.Description, dbo.vueAccountExpenseEntryApproval.AccountId, dbo.vueAccountExpenseEntryApproval.EMailAddress, 
                      dbo.vueAccountExpenseEntryApproval.Submitted, dbo.vueAccountExpenseEntryApproval.EmployeeManagerId, dbo.vueAccountExpenseEntryApproval.CurrencyCode, 
                      dbo.vueAccountExpenseEntryApproval.Rejected, dbo.vueAccountExpenseEntryApproval.AccountEmployeeExpenseSheetId, dbo.vueAccountCurrency.ExchangeRate, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeNameWithCode