
/****** Object:  View [dbo].[vueAccountEmployeeExpenseSheet]    Script Date: 25/10/2016 10:42:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[vueAccountEmployeeExpenseSheet]
AS                        
SELECT     dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId, dbo.AccountEmployeeExpenseSheet.AccountId, 
                      dbo.AccountEmployeeExpenseSheet.AccountEmployeeId, dbo.AccountEmployeeExpenseSheet.Description, dbo.AccountEmployeeExpenseSheet.ExpenseSheetDate, 
                      MAX(dbo.vueAccountCurrency.Currency) AS Currency, MAX(dbo.vueAccountCurrency.CurrencyCode) AS CurrencyCode, 
                      MAX(dbo.vueAccountCurrency.AccountCurrencyId) AS AccountCurrencyId, CASE WHEN dbo.AccountEmployeeExpenseSheet.Submitted = 0 AND 
                      dbo.AccountEmployeeExpenseSheet.Approved = 0 AND dbo.AccountEmployeeExpenseSheet.Rejected = 0 AND 
                      dbo.AccountEmployeeExpenseSheet.InApproval = 0 THEN 'Not Submitted' WHEN dbo.AccountEmployeeExpenseSheet.Submitted = 1 AND 
                      dbo.AccountEmployeeExpenseSheet.Approved = 1 AND 
                      dbo.AccountEmployeeExpenseSheet.Rejected = 0 THEN 'Approved' WHEN dbo.AccountEmployeeExpenseSheet.Submitted = 0 AND 
                      dbo.AccountEmployeeExpenseSheet.Rejected = 1 THEN 'Rejected' WHEN dbo.AccountEmployeeExpenseSheet.Submitted = 1 AND 
                      dbo.AccountEmployeeExpenseSheet.Approved = 0 AND dbo.AccountEmployeeExpenseSheet.Rejected = 0 AND 
                      dbo.AccountEmployeeExpenseSheet.InApproval = 1 THEN 'Submitted' WHEN dbo.AccountEmployeeExpenseSheet.Submitted = 1 AND 
                      dbo.AccountEmployeeExpenseSheet.Approved = 0 AND dbo.AccountEmployeeExpenseSheet.Rejected = 0 AND 
                      dbo.AccountEmployeeExpenseSheet.InApproval = 0 THEN 'Submitted' WHEN dbo.AccountEmployeeExpenseSheet.Submitted = 0 AND 
                      dbo.AccountEmployeeExpenseSheet.Approved = 1 THEN 'Not Submitted' WHEN dbo.AccountEmployeeExpenseSheet.Submitted = 0 AND 
                      dbo.AccountEmployeeExpenseSheet.InApproval = 1 THEN 'Not Submitted' WHEN dbo.AccountEmployeeExpenseSheet.Submitted = 1 AND 
                      dbo.AccountEmployeeExpenseSheet.Approved = 1 AND dbo.AccountEmployeeExpenseSheet.Rejected = 1 AND 
                      dbo.AccountEmployeeExpenseSheet.InApproval = 1 THEN 'Approved' WHEN dbo.AccountEmployeeExpenseSheet.Submitted = 1 AND 
                      dbo.AccountEmployeeExpenseSheet.Rejected = 1 THEN 'Submitted' END AS Status, dbo.AccountEmployeeExpenseSheet.InApproval, 
                      dbo.AccountEmployeeExpenseSheet.Submitted, dbo.AccountEmployeeExpenseSheet.Rejected, dbo.AccountEmployeeExpenseSheet.Approved, 
                      dbo.AccountEmployeeExpenseSheet.SubmittedDate, 
                      CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disabled)'
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName 
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disabled)'
					  ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, dbo.AccountEmployee.EMailAddress, MAX(dbo.vueAccountCurrency.ExchangeRate) 
                      AS ExchangeRate, dbo.AccountEmployeeExpenseSheet.ApprovedOn, dbo.AccountEmployeeExpenseSheet.ApprovedByEmployeeId, 
                      dbo.AccountEmployeeExpenseSheet.RejectedOn, dbo.AccountEmployeeExpenseSheet.RejectedByEmployeeId, 
                      SUM(ISNULL(dbo.vueAccountEmployeeExpenseSheetOnlyAmount.Amount * dbo.vueAccountCurrency.ExchangeRate, 0)) AS Amount, 
					  SUM(ISNULL(dbo.vueAccountEmployeeExpenseSheetOnlyAmount.Amount1, 0)) AS OriginalAmount,
					  MAX(expenseCurrency.CurrencyCode) AS OriginalCurrencyCode,
                      dbo.AccountEmployeeExpenseSheet.CustomField1, dbo.AccountEmployeeExpenseSheet.CustomField2, dbo.AccountEmployeeExpenseSheet.CustomField3, 
                      dbo.AccountEmployeeExpenseSheet.CustomField4, dbo.AccountEmployeeExpenseSheet.CustomField5, dbo.AccountEmployeeExpenseSheet.CustomField6, 
                      dbo.AccountEmployeeExpenseSheet.CustomField7, dbo.AccountEmployeeExpenseSheet.CustomField8, dbo.AccountEmployeeExpenseSheet.CustomField9, 
                      dbo.AccountEmployeeExpenseSheet.CustomField10, dbo.AccountEmployeeExpenseSheet.CustomField11, dbo.AccountEmployeeExpenseSheet.CustomField12, 
                      dbo.AccountEmployeeExpenseSheet.CustomField13, dbo.AccountEmployeeExpenseSheet.CustomField14, dbo.AccountEmployeeExpenseSheet.CustomField15
FROM         dbo.AccountExpenseEntry INNER JOIN
                      dbo.vueAccountEmployeeExpenseSheetOnlyAmount ON 
                      dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId = dbo.vueAccountEmployeeExpenseSheetOnlyAmount.AccountEmployeeExpenseSheetId AND 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.vueAccountEmployeeExpenseSheetOnlyAmount.AccountExpenseEntryId RIGHT OUTER JOIN
                      dbo.AccountEmployeeExpenseSheet INNER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployeeExpenseSheet.AccountId = dbo.AccountPreferences.AccountId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeExpenseSheet.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId = dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId LEFT OUTER JOIN
                      dbo.vueAccountCurrency ON dbo.AccountPreferences.AccountBaseCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId LEFT OUTER JOIN
					  dbo.vueAccountCurrency AS expenseCurrency ON dbo.AccountExpenseEntry.AccountCurrencyId = expenseCurrency.AccountCurrencyId
GROUP BY dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId, dbo.AccountEmployeeExpenseSheet.AccountId, 
                      dbo.AccountEmployeeExpenseSheet.AccountEmployeeId, dbo.AccountEmployeeExpenseSheet.Description, dbo.AccountEmployeeExpenseSheet.ExpenseSheetDate, 
                      dbo.AccountEmployeeExpenseSheet.InApproval, dbo.AccountEmployeeExpenseSheet.Submitted, dbo.AccountEmployeeExpenseSheet.Rejected, 
                      dbo.AccountEmployeeExpenseSheet.Approved, dbo.AccountEmployeeExpenseSheet.SubmittedDate, dbo.AccountEmployee.FirstName, 
                      dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, dbo.AccountEmployeeExpenseSheet.ApprovedOn, 
                      dbo.AccountEmployeeExpenseSheet.ApprovedByEmployeeId, dbo.AccountEmployeeExpenseSheet.RejectedOn, 
                      dbo.AccountEmployeeExpenseSheet.RejectedByEmployeeId, dbo.AccountEmployee.IsDisabled, dbo.AccountEmployeeExpenseSheet.CustomField1, 
                      dbo.AccountEmployeeExpenseSheet.CustomField2, dbo.AccountEmployeeExpenseSheet.CustomField3, dbo.AccountEmployeeExpenseSheet.CustomField4, 
                      dbo.AccountEmployeeExpenseSheet.CustomField5, dbo.AccountEmployeeExpenseSheet.CustomField6, dbo.AccountEmployeeExpenseSheet.CustomField7, 
                      dbo.AccountEmployeeExpenseSheet.CustomField8, dbo.AccountEmployeeExpenseSheet.CustomField9, dbo.AccountEmployeeExpenseSheet.CustomField10, 
                      dbo.AccountEmployeeExpenseSheet.CustomField11, dbo.AccountEmployeeExpenseSheet.CustomField12, dbo.AccountEmployeeExpenseSheet.CustomField13, 
                      dbo.AccountEmployeeExpenseSheet.CustomField14, dbo.AccountEmployeeExpenseSheet.CustomField15, 
                      CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disabled)'
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName 
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disabled)'
					  ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END

GO