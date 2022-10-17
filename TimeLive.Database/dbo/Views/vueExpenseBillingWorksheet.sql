
CREATE VIEW dbo.vueExpenseBillingWorksheet
AS
SELECT     dbo.vueAccountExpenseEntry.EmployeeName, dbo.vueAccountExpenseEntry.AccountExpenseName, dbo.vueAccountExpenseEntry.ProjectName, 
                      dbo.vueAccountExpenseEntry.AccountExpenseEntryId, dbo.vueAccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntry.AccountId, dbo.vueAccountExpenseEntry.AccountEmployeeId, dbo.vueAccountExpenseEntry.AccountProjectId, 
                      dbo.vueAccountExpenseEntry.AccountExpenseId, dbo.vueAccountExpenseEntry.Amount AS ExpenseAmount, 
                      dbo.vueAccountExpenseEntry.TeamLeadApproved, dbo.vueAccountExpenseEntry.ProjectManagerApproved, 
                      dbo.vueAccountExpenseEntry.AdministratorApproved, dbo.vueAccountExpenseEntry.Approved, dbo.vueAccountExpenseEntry.CreatedOn, 
                      dbo.vueAccountExpenseEntry.CreatedByEmployeeId, dbo.vueAccountExpenseEntry.ModifiedOn, dbo.vueAccountExpenseEntry.ModifiedByEmployeeId,
                       dbo.vueAccountExpenseEntry.PartyName, dbo.vueAccountExpenseEntry.AccountClientId, dbo.vueAccountExpenseEntry.Description, 
                      dbo.vueAccountExpenseEntry.ExpenseType, dbo.vueAccountExpenseEntry.AccountExpenseTypeId, dbo.vueAccountExpenseEntry.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntry.IsBillable, dbo.vueAccountExpenseEntry.Rejected, dbo.vueAccountExpenseEntry.EmployeeCode, 
                      dbo.vueAccountExpenseEntry.Reimburse, dbo.vueAccountExpenseEntry.AccountCurrencyId, dbo.vueAccountExpenseEntry.CurrencyCode, 
                      dbo.vueAccountExpenseEntry.IsQuantityField, dbo.vueAccountExpenseEntry.QuantityFieldCaption, 
                      dbo.vueAccountExpenseEntry.AccountBaseCurrencyId, dbo.vueAccountExpenseEntry.ExchangeRate, dbo.vueAccountExpenseEntry.TaxAmount, 
                      dbo.vueAccountExpenseEntry.NetAmount, dbo.vueAccountExpenseEntry.Submitted, dbo.vueAccountExpenseEntry.TimeSheetApprovalTypeId, 
                      dbo.vueAccountExpenseEntry.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntry.ProjectManagerEmployeeId, 
                      dbo.vueAccountExpenseEntry.TimeSheetApprovalPathId, dbo.vueAccountExpenseEntry.EMailAddress, dbo.vueAccountExpenseEntry.DepartmentName,
                       dbo.vueAccountExpenseEntry.AccountLocation, dbo.vueAccountExpenseEntry.AccountTaxZone, dbo.vueAccountExpenseEntry.Quantity, 
                      dbo.vueAccountExpenseEntry.Rate, dbo.vueAccountExpenseEntry.PaymentMethod, dbo.vueAccountExpenseEntry.AccountLocationId, 
                      dbo.vueAccountExpenseEntry.Billed, dbo.vueAccountExpenseEntry.AccountTimeExpenseBillingExpenseId, 
                      dbo.AccountTimeExpenseBilling.InvoiceNumber, dbo.AccountTimeExpenseBilling.InvoiceDate, dbo.AccountTimeExpenseBilling.PONumber, 
                      dbo.AccountTimeExpenseBilling.SubTotal, dbo.AccountTimeExpenseBilling.TaxCode1, dbo.AccountTimeExpenseBilling.TaxCode2, 
                      dbo.AccountTimeExpenseBilling.GrandTotal, dbo.AccountTimeExpenseBilling.BillingCycleStartDate, 
                      dbo.AccountTimeExpenseBilling.BillingCycleEndDate
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId RIGHT OUTER JOIN
                      dbo.vueAccountExpenseEntry ON dbo.AccountProject.AccountProjectId = dbo.vueAccountExpenseEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountTimeExpenseBilling INNER JOIN
                      dbo.AccountTimeExpenseBillingExpense ON 
                      dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingId ON 
                      dbo.vueAccountExpenseEntry.AccountTimeExpenseBillingExpenseId = dbo.AccountTimeExpenseBillingExpense.AccountTimeExpenseBillingExpenseId
WHERE     (dbo.vueAccountExpenseEntry.IsBillable = 1) AND (dbo.vueAccountExpenseEntry.Approved = 1)