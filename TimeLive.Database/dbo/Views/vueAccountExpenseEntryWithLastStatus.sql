
CREATE VIEW [dbo].[vueAccountExpenseEntryWithLastStatus]
AS
SELECT        dbo.vueAccountExpenseEntryWithLastAction.IsRejected, dbo.vueAccountExpenseEntryWithLastAction.IsApproved, dbo.vueAccountExpenseEntry.EmployeeName, 
                         dbo.vueAccountExpenseEntry.AccountExpenseName, dbo.vueAccountExpenseEntry.ProjectName, dbo.vueAccountExpenseEntry.AccountExpenseEntryId, dbo.vueAccountExpenseEntry.AccountExpenseEntryDate, 
                         dbo.vueAccountExpenseEntry.AccountId, dbo.vueAccountExpenseEntry.AccountEmployeeId, dbo.vueAccountExpenseEntry.AccountProjectId, dbo.vueAccountExpenseEntry.AccountExpenseId, 
                         dbo.vueAccountExpenseEntry.Amount, dbo.vueAccountExpenseEntry.TeamLeadApproved, dbo.vueAccountExpenseEntry.ProjectManagerApproved, dbo.vueAccountExpenseEntry.AdministratorApproved, 
                         dbo.vueAccountExpenseEntry.Approved, dbo.vueAccountExpenseEntry.CreatedOn, dbo.vueAccountExpenseEntry.CreatedByEmployeeId, dbo.vueAccountExpenseEntry.ModifiedOn, 
                         dbo.vueAccountExpenseEntry.ModifiedByEmployeeId, dbo.vueAccountExpenseEntry.PartyName, dbo.vueAccountExpenseEntry.AccountClientId, dbo.vueAccountExpenseEntry.Description, 
                         dbo.vueAccountExpenseEntry.ExpenseType, dbo.vueAccountExpenseEntry.AccountExpenseTypeId, dbo.vueAccountExpenseEntry.LeaderEmployeeId, dbo.vueAccountExpenseEntry.IsBillable, 
                         dbo.vueAccountExpenseEntry.Rejected, dbo.vueAccountExpenseEntry.EmployeeCode, dbo.vueAccountExpenseEntry.Reimburse, dbo.vueAccountExpenseEntry.AccountCurrencyId, 
                         dbo.vueAccountExpenseEntry.CurrencyCode, dbo.vueAccountExpenseEntry.IsQuantityField, dbo.vueAccountExpenseEntry.QuantityFieldCaption, dbo.vueAccountExpenseEntry.Submitted, 
                         dbo.vueAccountExpenseEntry.AccountEmployeeExpenseSheetId, dbo.vueAccountExpenseEntry.SubmittedDate, dbo.vueAccountExpenseEntry.ExpenseSheetDate, 
                         dbo.vueAccountExpenseEntry.ExpenseSheetDescription, dbo.vueAccountExpenseEntry.ExchangeRate, dbo.vueAccountExpenseEntry.TaxAmount, dbo.vueAccountExpenseEntry.NetAmount, 
                         dbo.vueAccountExpenseEntry.PaymentMethod, dbo.vueAccountExpenseEntry.Quantity, dbo.vueAccountExpenseEntry.Rate, dbo.vueAccountExpenseEntry.AccountTaxCodeId, 
                         dbo.vueAccountExpenseEntry.TaxCode, dbo.vueAccountExpenseEntry.TaskName, dbo.vueAccountExpenseEntry.AccountProjectTaskId, dbo.vueAccountExpenseEntry.AccountTaxZoneId, 
                         dbo.vueAccountExpenseEntry.AccountPaymentMethodId, dbo.vueAccountExpenseEntry.AccountTaxZone, dbo.vueAccountExpenseEntry.CustomField1, dbo.vueAccountExpenseEntry.CustomField2, 
                         dbo.vueAccountExpenseEntry.CustomField3
FROM            dbo.vueAccountExpenseEntryWithLastAction RIGHT OUTER JOIN
                         dbo.vueAccountExpenseEntry ON dbo.vueAccountExpenseEntryWithLastAction.AccountExpenseEntryId = dbo.vueAccountExpenseEntry.AccountExpenseEntryId