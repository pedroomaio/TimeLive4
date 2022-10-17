CREATE VIEW dbo.rptvueAccountExpenseEntry
AS
SELECT     dbo.vueAccountExpenseEntryForReport.EmployeeName, dbo.vueAccountExpenseEntryForReport.AccountExpenseName, 
                      dbo.vueAccountExpenseEntryForReport.ProjectName, dbo.vueAccountExpenseEntryForReport.AccountExpenseEntryId, dbo.vueAccountExpenseEntryForReport.AccountExpenseEntryDate, dbo.vueAccountExpenseEntryForReport.AccountId, 
                      dbo.vueAccountExpenseEntryForReport.AccountEmployeeId, dbo.vueAccountExpenseEntryForReport.AccountProjectId, dbo.vueAccountExpenseEntryForReport.AccountExpenseId, dbo.vueAccountExpenseEntryForReport.Amount, 
                      dbo.vueAccountExpenseEntryForReport.TeamLeadApproved, dbo.vueAccountExpenseEntryForReport.ProjectManagerApproved, 
                      dbo.vueAccountExpenseEntryForReport.AdministratorApproved, dbo.vueAccountExpenseEntryForReport.Approved, dbo.vueAccountExpenseEntryForReport.CreatedOn, 
                      dbo.vueAccountExpenseEntryForReport.CreatedByEmployeeId, dbo.vueAccountExpenseEntryForReport.ModifiedOn, dbo.vueAccountExpenseEntryForReport.ModifiedByEmployeeId, dbo.vueAccountExpenseEntryForReport.ClientName, 
                      dbo.vueAccountExpenseEntryForReport.AccountClientId, dbo.vueAccountExpenseEntryForReport.Description, dbo.vueAccountExpenseEntryForReport.ExpenseType, 
                      dbo.vueAccountExpenseEntryForReport.AccountExpenseTypeId, dbo.vueAccountExpenseEntryForReport.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryForReport.IsBillable, dbo.vueAccountExpenseEntryForReport.Rejected, dbo.vueAccountExpenseEntryForReport.EmployeeCode, 
                      dbo.vueAccountExpenseEntryForReport.Reimburse, dbo.vueAccountExpenseEntryForReport.AccountCurrencyId, dbo.vueAccountExpenseEntryForReport.CurrencyCode, dbo.vueAccountExpenseEntryForReport.IsQuantityField, 
                      dbo.vueAccountExpenseEntryForReport.QuantityFieldCaption, dbo.vueAccountExpenseEntryForReport.AccountBaseCurrencyId, 
                      dbo.vueAccountExpenseEntryForReport.ExchangeRate, dbo.vueAccountExpenseEntryForReport.TaxAmount, dbo.vueAccountExpenseEntryForReport.NetAmount, 
                      dbo.vueAccountExpenseEntryForReport.Submitted, dbo.vueAccountExpenseEntryForReport.TimeSheetApprovalTypeId, dbo.vueAccountExpenseEntryForReport.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntryForReport.ProjectManagerEmployeeId, 
                      dbo.vueAccountExpenseEntryForReport.TimeSheetApprovalPathId, dbo.vueAccountExpenseEntryForReport.EMailAddress, dbo.vueAccountExpenseEntryForReport.DepartmentName, dbo.vueAccountExpenseEntryForReport.AccountLocation, 
                      dbo.vueAccountExpenseEntryForReport.AccountTaxZone, dbo.vueAccountExpenseEntryForReport.Quantity, dbo.vueAccountExpenseEntryForReport.Rate, dbo.vueAccountExpenseEntryForReport.PaymentMethod, dbo.vueAccountExpenseEntryForReport.AccountLocationId, 
                      dbo.vueAccountExpenseEntryForReport.ClientNick, dbo.vueAccountExpenseEntryForReport.ProjectDescription, dbo.vueAccountExpenseEntryForReport.ProjectCode, 
                      dbo.vueAccountExpenseEntryForReport.DepartmentCode, CASE WHEN vueAccountExpenseEntryForReport.Submitted = 1 AND 
                      vueAccountExpenseEntryForReport.Approved = 0 THEN 'Submitted' WHEN vueAccountExpenseEntryForReport.Approved = 1 THEN 'Approved' WHEN vueAccountExpenseEntryForReport.Rejected
                       = 1 THEN 'Rejected' WHEN vueAccountExpenseEntryForReport.Submitted = 0 AND vueAccountExpenseEntryForReport.Approved = 0 AND 
                      vueAccountExpenseEntryForReport.Rejected = 0 THEN 'Not Submitted' END AS ApprovalStatus, dbo.vueAccountExpenseEntryForReport.Comments AS ApproverComments, dbo.vueAccountExpenseEntryForReport.ApprovedOn, 
                      dbo.vueAccountExpenseEntryForReport.AccountDepartmentId, dbo.vueAccountExpenseEntryForReport.Role, dbo.vueAccountExpenseEntryForReport.AccountRoleId, 
                      dbo.vueAccountExpenseEntryForReport.DayNo, dbo.vueAccountExpenseEntryForReport.MonthNo, dbo.vueAccountExpenseEntryForReport.WeekNo, dbo.vueAccountExpenseEntryForReport.Year, dbo.vueAccountExpenseEntryForReport.Period, dbo.vueAccountExpenseEntryForReport.WeekDayName, 
                      CASE WHEN dbo.vueAccountExpenseEntryForReport.ExchangeRate > 0 THEN Round(dbo.vueAccountExpenseEntryForReport.NetAmount / dbo.vueAccountExpenseEntryForReport.ExchangeRate,2)
                       ELSE 0 END AS CurrencyNetAmount, CASE WHEN dbo.vueAccountExpenseEntryForReport.ExchangeRate > 0 THEN Round(dbo.vueAccountExpenseEntryForReport.Amount / dbo.vueAccountExpenseEntryForReport.ExchangeRate,2)
                       ELSE 0 END AS CurrencyAmount, 
                      CASE WHEN dbo.vueAccountExpenseEntryForReport.ExchangeRate > 0 THEN dbo.vueAccountExpenseEntryForReport.TaxAmount / dbo.vueAccountExpenseEntryForReport.ExchangeRate
                       ELSE 0 END AS CurrencyTaxAmount, dbo.vueAccountExpenseEntryForReport.InvoiceNumber, dbo.vueAccountExpenseEntryForReport.InvoiceDate, 
                      dbo.vueAccountExpenseEntryForReport.AccountProjectTypeId, dbo.vueAccountExpenseEntryForReport.ProjectType, dbo.vueAccountExpenseEntryForReport.Billed, 
                      dbo.vueAccountExpenseEntryForReport.AccountEmployeeExpenseSheetId, dbo.vueAccountExpenseEntryForReport.ExpenseSheetDescription, 
                      dbo.vueAccountExpenseEntryForReport.ExpenseSheetDate, dbo.vueAccountExpenseEntryForReport.SubmittedDate, dbo.vueAccountExpenseEntryForReport.SheetApproved, dbo.vueAccountExpenseEntryForReport.SheetRejected, 
                      dbo.vueAccountExpenseEntryForReport.SheetSubmitted, dbo.vueAccountExpenseEntryForReport.SheetInApproval, dbo.vueAccountExpenseEntryForReport.TaskName, 
                      CASE WHEN dbo.vueAccountCurrency.ExchangeRate > 0 THEN dbo.vueAccountExpenseEntryForReport.CurrencyReimbursementAmount * dbo.vueAccountCurrency.ExchangeRate
                       ELSE 0 END AS ReimbursementAmount, dbo.vueAccountCurrency.ExchangeRate AS ReimbursementExchangeRate, 
                      dbo.vueAccountCurrency.CurrencyCode AS ReimbursementCurrencyCode, dbo.vueAccountExpenseEntryForReport.BillableAmount, dbo.vueAccountExpenseEntryForReport.CustomField1, 
                      dbo.vueAccountExpenseEntryForReport.CustomField2, dbo.vueAccountExpenseEntryForReport.CustomField3, dbo.vueAccountExpenseEntryForReport.CustomField4, 
                      dbo.vueAccountExpenseEntryForReport.CustomField5, dbo.vueAccountExpenseEntryForReport.CustomField6, dbo.vueAccountExpenseEntryForReport.CustomField7, 
                      dbo.vueAccountExpenseEntryForReport.CustomField8, dbo.vueAccountExpenseEntryForReport.CustomField9, dbo.vueAccountExpenseEntryForReport.CustomField10, 
                      dbo.vueAccountExpenseEntryForReport.CustomField11, dbo.vueAccountExpenseEntryForReport.CustomField12, dbo.vueAccountExpenseEntryForReport.CustomField13, dbo.vueAccountExpenseEntryForReport.CustomField14, 
                      dbo.vueAccountExpenseEntryForReport.CustomField15, dbo.vueAccountExpenseEntryForReport.ProjectCustomField12, dbo.vueAccountExpenseEntryForReport.ProjectCustomField13, dbo.vueAccountExpenseEntryForReport.ProjectCustomField14, 
                      dbo.vueAccountExpenseEntryForReport.ProjectCustomField15, dbo.vueAccountExpenseEntryForReport.ProjectCustomField1, dbo.vueAccountExpenseEntryForReport.ProjectCustomField2, dbo.vueAccountExpenseEntryForReport.ProjectCustomField3, 
                      dbo.vueAccountExpenseEntryForReport.ProjectCustomField4, dbo.vueAccountExpenseEntryForReport.ProjectCustomField5, dbo.vueAccountExpenseEntryForReport.ProjectCustomField7, dbo.vueAccountExpenseEntryForReport.ProjectCustomField6, 
                      dbo.vueAccountExpenseEntryForReport.ProjectCustomField8, dbo.vueAccountExpenseEntryForReport.ProjectCustomField9, dbo.vueAccountExpenseEntryForReport.ProjectCustomField10, dbo.vueAccountExpenseEntryForReport.ProjectCustomField11
FROM         dbo.vueAccountExpenseEntryForReport INNER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountExpenseEntryForReport.AccountId = dbo.AccountPreferences.AccountId INNER JOIN
                      dbo.vueAccountCurrency ON dbo.AccountPreferences.AccountReimbursementCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId