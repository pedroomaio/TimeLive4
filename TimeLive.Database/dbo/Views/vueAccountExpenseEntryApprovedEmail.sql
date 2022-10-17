
CREATE VIEW dbo.vueAccountExpenseEntryApprovedEmail
AS
SELECT     dbo.AccountEmployee.EMailAddress, dbo.vueAccountExpenseEntry.EmployeeName, dbo.vueAccountExpenseEntry.AccountExpenseName, 
                      dbo.vueAccountExpenseEntry.ProjectName, dbo.vueAccountExpenseEntry.AccountExpenseEntryId, dbo.vueAccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntry.AccountId, dbo.vueAccountExpenseEntry.AccountEmployeeId, dbo.vueAccountExpenseEntry.AccountProjectId, 
                      dbo.vueAccountExpenseEntry.AccountExpenseId, dbo.vueAccountExpenseEntry.Amount, dbo.vueAccountExpenseEntry.TeamLeadApproved, 
                      dbo.vueAccountExpenseEntry.ProjectManagerApproved, dbo.vueAccountExpenseEntry.AdministratorApproved, dbo.vueAccountExpenseEntry.Approved, 
                      dbo.vueAccountExpenseEntry.CreatedOn, dbo.vueAccountExpenseEntry.CreatedByEmployeeId, dbo.vueAccountExpenseEntry.ModifiedOn, 
                      dbo.vueAccountExpenseEntry.ModifiedByEmployeeId, dbo.vueAccountExpenseEntry.PartyName, dbo.vueAccountExpenseEntry.AccountClientId, 
                      dbo.vueAccountExpenseEntry.Description, dbo.vueAccountExpenseEntry.ExpenseType, dbo.vueAccountExpenseEntry.AccountExpenseTypeId, 
                      dbo.vueAccountExpenseEntry.LeaderEmployeeId, dbo.vueAccountExpenseEntry.IsBillable, dbo.vueAccountExpenseEntry.Rejected, 
                      dbo.vueAccountExpenseEntry.EmployeeCode, dbo.vueAccountExpenseEntry.Reimburse, dbo.vueAccountExpenseEntry.AccountCurrencyId, 
                      dbo.vueAccountExpenseEntry.CurrencyCode, dbo.vueAccountExpenseEntry.IsQuantityField, dbo.vueAccountExpenseEntry.QuantityFieldCaption, 
                      dbo.vueAccountExpenseEntry.AccountBaseCurrencyId, dbo.vueAccountExpenseEntry.ExchangeRate, dbo.vueAccountExpenseEntry.TaxAmount, 
                      dbo.vueAccountExpenseEntry.NetAmount, dbo.vueAccountExpenseEntry.Submitted, dbo.vueAccountExpenseEntry.TimeSheetApprovalTypeId, 
                      dbo.vueAccountExpenseEntry.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntry.ProjectManagerEmployeeId, 
                      dbo.vueAccountExpenseEntry.TimeSheetApprovalPathId, dbo.vueAccountExpenseEntry.DepartmentName, dbo.vueAccountExpenseEntry.AccountLocation, 
                      dbo.vueAccountExpenseEntry.AccountTaxZone, dbo.vueAccountExpenseEntry.Quantity, dbo.vueAccountExpenseEntry.Rate, 
                      dbo.vueAccountExpenseEntry.PaymentMethod, dbo.vueAccountExpenseEntry.AccountLocationId, dbo.vueAccountExpenseEntry.PartyNick, 
                      dbo.vueAccountExpenseEntry.ProjectDescription, dbo.vueAccountExpenseEntry.ProjectCode, dbo.vueAccountExpenseEntry.DepartmentCode, 
                      dbo.vueAccountExpenseEntry.ApprovedOn, dbo.vueAccountExpenseEntry.AccountDepartmentId, dbo.vueAccountExpenseEntry.Role, 
                      dbo.vueAccountExpenseEntry.AccountRoleId, dbo.vueAccountExpenseEntry.AccountTimeExpenseBillingExpenseId, dbo.vueAccountExpenseEntry.Billed, 
                      dbo.vueAccountExpenseEntry.InvoiceNumber, dbo.vueAccountExpenseEntry.InvoiceDate, dbo.vueAccountExpenseEntry.AccountProjectTypeId, 
                      dbo.vueAccountExpenseEntry.ProjectType, dbo.vueAccountExpenseEntry.AccountEmployeeExpenseSheetId, dbo.vueAccountExpenseEntry.ExpenseSheetDescription, 
                      dbo.vueAccountExpenseEntry.ExpenseSheetDate, dbo.vueAccountExpenseEntry.SubmittedDate, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.vueAccountBaseCurrency.BaseCurrency, 
                      dbo.vueAccountBaseCurrency.CurrencyCode AS BaseCurrencyCode, 
                      CASE WHEN dbo.vueAccountExpenseEntry.ExchangeRate <> 0 THEN dbo.vueAccountExpenseEntry.Amount / dbo.vueAccountExpenseEntry.ExchangeRate ELSE 0 END
                       AS BaseCurrencyAmount
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.vueAccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountExpenseEntry.AccountEmployeeId INNER JOIN
                      dbo.vueAccountBaseCurrency ON dbo.vueAccountExpenseEntry.AccountId = dbo.vueAccountBaseCurrency.AccountId LEFT OUTER JOIN
                      dbo.vueAccountExpenseEntryApprovalLastAction INNER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.vueAccountExpenseEntryApprovalLastAction.ExpenseApprovalId = dbo.AccountExpenseEntryApproval.ExpenseApprovalId ON 
                      dbo.vueAccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountExpenseEntry.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountExpenseEntry.AccountProjectId = dbo.AccountEMailNotificationPreference.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountExpenseEntry.AccountId = AccountEMailNotificationPreference_2.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 22) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 20) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 21) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)