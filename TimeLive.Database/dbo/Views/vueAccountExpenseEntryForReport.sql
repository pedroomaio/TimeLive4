
CREATE VIEW dbo.vueAccountExpenseEntryForReport
AS
SELECT     EmployeeName, AccountExpenseName, ProjectName, AccountExpenseEntryId, AccountExpenseEntryDate, AccountId, AccountEmployeeId, AccountProjectId, 
                      AccountExpenseId, Amount AS NetAmount, TeamLeadApproved, ProjectManagerApproved, AdministratorApproved, ISNULL(Approved, 0) AS Approved, CreatedOn, 
                      CreatedByEmployeeId, ModifiedOn, ModifiedByEmployeeId, PartyName AS ClientName, AccountClientId, ISNULL(Description, N'') AS Description, ExpenseType, 
                      AccountExpenseTypeId, LeaderEmployeeId, IsBillable, ISNULL(Rejected, 0) AS Rejected, ISNULL(EmployeeCode, N'') AS EmployeeCode, Reimburse, 
                      AccountCurrencyId, CurrencyCode, IsQuantityField, ISNULL(QuantityFieldCaption, N'') AS QuantityFieldCaption, AccountBaseCurrencyId, ISNULL(ExchangeRate, 0) 
                      AS ExchangeRate, TaxAmount, NetAmount AS Amount, ISNULL(Submitted, 0) AS Submitted, TimeSheetApprovalTypeId, ExpenseApprovalTypeId, 
                      ProjectManagerEmployeeId, TimeSheetApprovalPathId, EMailAddress, DepartmentName, AccountLocation, ISNULL(AccountTaxZone, N'') AS AccountTaxZone, 
                      ISNULL(Quantity, 0) AS Quantity, ISNULL(Rate, 0) AS Rate, ISNULL(PaymentMethod, N'') AS PaymentMethod, AccountLocationId, ISNULL(PartyNick, N'') AS ClientNick, 
                      ProjectDescription, ISNULL(ProjectCode, N'') AS ProjectCode, ISNULL(DepartmentCode, N'') AS DepartmentCode, ISNULL(Comments, N'') AS Comments, ApprovedOn, 
                      AccountDepartmentId, Role, AccountRoleId, { fn DAYOFMONTH(AccountExpenseEntryDate) } AS DayNo, MONTH(AccountExpenseEntryDate) AS MonthNo, 
                      DATEPART(week, AccountExpenseEntryDate) - DATEPART(week, DATEADD(month, DATEDIFF(month, 0, AccountExpenseEntryDate), 0)) + 1 AS WeekNo, 
                      YEAR(AccountExpenseEntryDate) AS Year, LEFT({ fn MONTHNAME(AccountExpenseEntryDate) }, 3) + ' - ' + CONVERT(nvarchar(10), YEAR(AccountExpenseEntryDate)) 
                      AS Period, { fn DAYNAME(AccountExpenseEntryDate) } AS WeekDayName, InvoiceNumber, InvoiceDate, AccountProjectTypeId, ProjectType, Billed, 
                      AccountEmployeeExpenseSheetId, ExpenseSheetDescription, ExpenseSheetDate, SubmittedDate, SheetApproved, SheetRejected, SheetSubmitted, SheetInApproval, 
                      TaskName, 
                      CASE WHEN dbo.vueAccountExpenseEntry.Reimburse <> 0 THEN dbo.vueAccountExpenseEntry.Amount / dbo.vueAccountExpenseEntry.ExchangeRate ELSE 0 END AS
                       CurrencyReimbursementAmount, 
                      CASE WHEN dbo.vueAccountExpenseEntry.IsBillable <> 0 THEN dbo.vueAccountExpenseEntry.Amount ELSE 0 END AS BillableAmount, CustomField1, CustomField2, 
                      CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, 
                      CustomField13, CustomField14, CustomField15, ProjectCustomField1, ProjectCustomField2, ProjectCustomField3, 
                      ProjectCustomField4, ProjectCustomField5, ProjectCustomField6, ProjectCustomField7, ProjectCustomField8, ProjectCustomField9, 
                      ProjectCustomField10, ProjectCustomField11, ProjectCustomField12, ProjectCustomField13, ProjectCustomField14, ProjectCustomField15
FROM         dbo.vueAccountExpenseEntry