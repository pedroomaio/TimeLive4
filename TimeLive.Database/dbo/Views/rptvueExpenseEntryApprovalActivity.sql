
CREATE VIEW dbo.rptvueExpenseEntryApprovalActivity
AS
SELECT     ExpenseApprovalId, AccountExpenseEntryId, ExpenseApprovalTypeId, ExpenseApprovalPathId, ApprovedByEmployeeId, ApprovedOn, Comments, IsRejected, 
                      IsApproved, EmployeeName, AccountExpenseName, ProjectName, AccountExpenseEntryDate, AccountId, AccountEmployeeId, AccountProjectId, AccountExpenseId, 
                      Amount, Approved, ClientName, AccountClientId, Description, ExpenseType, AccountExpenseTypeId, IsBillable, Rejected, EmployeeCode, Reimburse, 
                      AccountCurrencyId, CurrencyCode, ExchangeRate, AccountBaseCurrencyId, TaxAmount, NetAmount, Submitted, EMailAddress, DepartmentName, AccountLocation, 
                      AccountTaxZone, Quantity, Rate, PaymentMethod, AccountLocationId, ClientNick, ProjectDescription, ProjectCode, DepartmentCode, ApproverEmployeeName, 
                      ApproverEMailAddress, ApprovalTypeName, SystemApproverType, Status, Role, AccountRoleId, AccountDepartmentId, 
                      CASE WHEN dbo.vueExpenseEntryApprovalActivityForReport.ExchangeRate > 0 THEN dbo.vueExpenseEntryApprovalActivityForReport.NetAmount / dbo.vueExpenseEntryApprovalActivityForReport.ExchangeRate
                       ELSE 0 END AS CurrencyNetAmount, 
                      CASE WHEN dbo.vueExpenseEntryApprovalActivityForReport.ExchangeRate > 0 THEN dbo.vueExpenseEntryApprovalActivityForReport.Amount / dbo.vueExpenseEntryApprovalActivityForReport.ExchangeRate
                       ELSE 0 END AS CurrencyAmount, 
                      CASE WHEN dbo.vueExpenseEntryApprovalActivityForReport.ExchangeRate > 0 THEN dbo.vueExpenseEntryApprovalActivityForReport.TaxAmount / dbo.vueExpenseEntryApprovalActivityForReport.ExchangeRate
                       ELSE 0 END AS CurrencyTaxAmount, TaskName
FROM         dbo.vueExpenseEntryApprovalActivityForReport