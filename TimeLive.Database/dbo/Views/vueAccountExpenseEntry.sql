
CREATE VIEW dbo.vueAccountExpenseEntry
AS      					  
SELECT     CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2  and dbo.AccountEmployee.IsDisabled = 1  THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)'
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 and dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName 
					  WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 and dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)'
					  ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, dbo.AccountExpense.AccountExpenseName, dbo.AccountProject.ProjectName, 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntry.AccountId, 
                      dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountProjectId, dbo.AccountExpenseEntry.AccountExpenseId, 
                      dbo.AccountExpenseEntry.Amount, dbo.AccountExpenseEntry.TeamLeadApproved, dbo.AccountExpenseEntry.ProjectManagerApproved, 
                      dbo.AccountExpenseEntry.AdministratorApproved, dbo.AccountExpenseEntry.Approved, dbo.AccountExpenseEntry.CreatedOn, 
                      dbo.AccountExpenseEntry.CreatedByEmployeeId, dbo.AccountExpenseEntry.ModifiedOn, dbo.AccountExpenseEntry.ModifiedByEmployeeId, 
                      dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, dbo.AccountExpenseEntry.Description, dbo.AccountExpenseType.ExpenseType, 
                      dbo.AccountExpense.AccountExpenseTypeId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountExpenseEntry.Reimburse, dbo.AccountExpenseEntry.AccountCurrencyId, dbo.SystemCurrency.CurrencyCode, 
                      dbo.AccountExpenseType.IsQuantityField, dbo.AccountExpenseType.QuantityFieldCaption, dbo.AccountExpenseEntry.AccountBaseCurrencyId, 
                      dbo.AccountExpenseEntry.ExchangeRate, ISNULL(dbo.AccountExpenseEntry.TaxAmount, 0) AS TaxAmount, ISNULL(dbo.AccountExpenseEntry.AmountBeforeTax, 0) 
                      AS NetAmount, dbo.AccountExpenseEntry.Submitted, dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountExpenseEntry.TimeSheetApprovalPathId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountLocation.AccountLocation, dbo.AccountTaxZone.AccountTaxZone, dbo.AccountExpenseEntry.Quantity, 
                      dbo.AccountExpenseEntry.Rate, dbo.AccountPaymentMethod.PaymentMethod, dbo.AccountLocation.AccountLocationId, dbo.AccountParty.PartyNick, 
                      dbo.AccountProject.ProjectDescription, CASE WHEN ISNULL(dbo.AccountProject.ProjectPrefix, '') 
                      = '' THEN dbo.AccountProject.ProjectCode ELSE dbo.AccountProject.ProjectPrefix + '-' + dbo.AccountProject.ProjectCode END AS ProjectCode, 
                      dbo.AccountDepartment.DepartmentCode, dbo.vueAccountExpenseEntryApprovalLastAction.Comments, dbo.vueAccountExpenseEntryApprovalLastAction.ApprovedOn, 
                      dbo.AccountDepartment.AccountDepartmentId, dbo.AccountRole.Role, dbo.AccountRole.AccountRoleId, 
                      dbo.AccountExpenseEntry.AccountTimeExpenseBillingExpenseId, dbo.AccountExpenseEntry.Billed, dbo.AccountTimeExpenseBilling.InvoiceNumber, 
                      dbo.AccountTimeExpenseBilling.InvoiceDate, dbo.AccountProjectType.AccountProjectTypeId, dbo.AccountProjectType.ProjectType, 
                      dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId, dbo.AccountEmployeeExpenseSheet.Description AS ExpenseSheetDescription, 
                      dbo.AccountEmployeeExpenseSheet.ExpenseSheetDate, dbo.AccountEmployeeExpenseSheet.SubmittedDate, 
                      dbo.AccountEmployeeExpenseSheet.Approved AS SheetApproved, dbo.AccountEmployeeExpenseSheet.Rejected AS SheetRejected, 
                      dbo.AccountEmployeeExpenseSheet.Submitted AS SheetSubmitted, dbo.AccountEmployeeExpenseSheet.InApproval AS SheetInApproval, 
                      dbo.AccountTaxCode.TaxCode, dbo.AccountTaxCode.Formula, dbo.AccountTaxCode.AccountTaxCodeId, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountParty.IsDeleted, dbo.AccountExpenseEntry.CustomField1, dbo.AccountExpenseEntry.CustomField2, dbo.AccountExpenseEntry.CustomField3, 
                      dbo.AccountExpenseEntry.CustomField4, dbo.AccountExpenseEntry.CustomField5, dbo.AccountExpenseEntry.CustomField6, dbo.AccountExpenseEntry.CustomField7, 
                      dbo.AccountExpenseEntry.CustomField8, dbo.AccountExpenseEntry.CustomField9, dbo.AccountExpenseEntry.CustomField10, 
                      dbo.AccountExpenseEntry.CustomField11, dbo.AccountExpenseEntry.CustomField12, dbo.AccountExpenseEntry.CustomField13, 
                      dbo.AccountExpenseEntry.CustomField14, dbo.AccountExpenseEntry.CustomField15, dbo.AccountProjectTask.AccountProjectTaskId, 
                      dbo.AccountTaxZone.AccountTaxZoneId, dbo.AccountPaymentMethod.AccountPaymentMethodId, dbo.AccountProject.CustomField1 AS ProjectCustomField1, dbo.AccountProject.CustomField2 AS ProjectCustomField2, 
                      dbo.AccountProject.CustomField3 AS ProjectCustomField3, dbo.AccountProject.CustomField4 AS ProjectCustomField4, 
                      dbo.AccountProject.CustomField5 AS ProjectCustomField5, dbo.AccountProject.CustomField6 AS ProjectCustomField6, 
                      dbo.AccountProject.CustomField7 AS ProjectCustomField7, dbo.AccountProject.CustomField8 AS ProjectCustomField8, 
                      dbo.AccountProject.CustomField9 AS ProjectCustomField9, dbo.AccountProject.CustomField10 AS ProjectCustomField10, 
                      dbo.AccountProject.CustomField11 AS ProjectCustomField11, dbo.AccountProject.CustomField12 AS ProjectCustomField12, 
                      dbo.AccountProject.CustomField13 AS ProjectCustomField13, dbo.AccountProject.CustomField14 AS ProjectCustomField14, 
                      dbo.AccountProject.CustomField15 AS ProjectCustomField15
FROM         dbo.AccountLocation RIGHT OUTER JOIN
                      dbo.SystemCurrency RIGHT OUTER JOIN
                      dbo.AccountCurrency RIGHT OUTER JOIN
                      dbo.AccountPaymentMethod RIGHT OUTER JOIN
                      dbo.vueAccountExpenseEntryApprovalLastAction RIGHT OUTER JOIN
                      dbo.AccountTimeExpenseBillingExpense INNER JOIN
                      dbo.AccountTimeExpenseBilling ON 
                      dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId RIGHT OUTER JOIN
                      dbo.AccountEmployeeExpenseSheet RIGHT OUTER JOIN
                      dbo.AccountTaxCode RIGHT OUTER JOIN
                      dbo.AccountExpenseTypeTaxCode RIGHT OUTER JOIN
                      dbo.AccountExpenseType INNER JOIN
                      dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId ON 
                      dbo.AccountExpenseType.AccountExpenseTypeId = dbo.AccountExpense.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountExpenseEntry.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountExpenseEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId ON 
                      dbo.AccountExpenseTypeTaxCode.AccountTaxZoneId = dbo.AccountExpenseEntry.AccountTaxZoneId AND 
                      dbo.AccountExpenseTypeTaxCode.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId ON 
                      dbo.AccountTaxCode.AccountTaxCodeId = dbo.AccountExpenseTypeTaxCode.AccountTaxCodeId LEFT OUTER JOIN
                      dbo.AccountTaxZone ON dbo.AccountExpenseEntry.AccountTaxZoneId = dbo.AccountTaxZone.AccountTaxZoneId ON 
                      dbo.AccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId = dbo.AccountExpenseEntry.AccountEmployeeExpenseSheetId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingExpenseId = dbo.AccountExpenseEntry.AccountTimeExpenseBillingExpenseId ON 
                      dbo.vueAccountExpenseEntryApprovalLastAction.AccountExpenseEntryId = dbo.AccountExpenseEntry.AccountExpenseEntryId ON 
                      dbo.AccountPaymentMethod.AccountPaymentMethodId = dbo.AccountExpenseEntry.AccountPaymentMethodId ON 
                      dbo.AccountCurrency.AccountCurrencyId = dbo.AccountExpenseEntry.AccountCurrencyId LEFT OUTER JOIN
                      dbo.AccountParty RIGHT OUTER JOIN
                      dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountProjectType ON dbo.AccountProject.AccountProjectTypeId = dbo.AccountProjectType.AccountProjectTypeId ON 
                      dbo.AccountParty.AccountPartyId = dbo.AccountProject.AccountClientId ON dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.SystemCurrency.CurrencyId = dbo.AccountCurrency.SystemCurrencyId LEFT OUTER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId ON 
                      dbo.AccountLocation.AccountLocationId = dbo.AccountEmployee.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId
WHERE     (dbo.AccountParty.IsDeleted <> 1) OR
                      (dbo.AccountParty.IsDeleted IS NULL)