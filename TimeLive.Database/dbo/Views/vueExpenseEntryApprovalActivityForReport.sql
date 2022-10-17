
CREATE VIEW dbo.vueExpenseEntryApprovalActivityForReport
AS
SELECT     dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountExpenseEntryApproval.AccountExpenseEntryId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalTypeId, dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, 
                      dbo.AccountExpenseEntryApproval.ApprovedByEmployeeId, dbo.AccountExpenseEntryApproval.ApprovedOn, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, dbo.vueAccountExpenseEntryForReport.EmployeeName, 
                      dbo.vueAccountExpenseEntryForReport.AccountExpenseName, dbo.vueAccountExpenseEntryForReport.ProjectName, 
                      dbo.vueAccountExpenseEntryForReport.AccountExpenseEntryDate, dbo.vueAccountExpenseEntryForReport.AccountId, 
                      dbo.vueAccountExpenseEntryForReport.AccountEmployeeId, dbo.vueAccountExpenseEntryForReport.AccountProjectId, 
                      dbo.vueAccountExpenseEntryForReport.AccountExpenseId, dbo.vueAccountExpenseEntryForReport.Amount, dbo.vueAccountExpenseEntryForReport.Approved, 
                      dbo.vueAccountExpenseEntryForReport.ClientName, dbo.vueAccountExpenseEntryForReport.AccountClientId, dbo.vueAccountExpenseEntryForReport.Description, 
                      dbo.vueAccountExpenseEntryForReport.ExpenseType, dbo.vueAccountExpenseEntryForReport.AccountExpenseTypeId, 
                      dbo.vueAccountExpenseEntryForReport.IsBillable, dbo.vueAccountExpenseEntryForReport.Rejected, dbo.vueAccountExpenseEntryForReport.EmployeeCode, 
                      dbo.vueAccountExpenseEntryForReport.Reimburse, dbo.vueAccountExpenseEntryForReport.AccountCurrencyId, 
                      dbo.vueAccountExpenseEntryForReport.CurrencyCode, ISNULL(dbo.vueAccountExpenseEntryForReport.ExchangeRate, 0) AS ExchangeRate, 
                      dbo.vueAccountExpenseEntryForReport.AccountBaseCurrencyId, dbo.vueAccountExpenseEntryForReport.TaxAmount, 
                      dbo.vueAccountExpenseEntryForReport.NetAmount, dbo.vueAccountExpenseEntryForReport.Submitted, dbo.vueAccountExpenseEntryForReport.EMailAddress, 
                      dbo.vueAccountExpenseEntryForReport.DepartmentName, dbo.vueAccountExpenseEntryForReport.AccountLocation, 
                      dbo.vueAccountExpenseEntryForReport.AccountTaxZone, dbo.vueAccountExpenseEntryForReport.Quantity, dbo.vueAccountExpenseEntryForReport.Rate, 
                      dbo.vueAccountExpenseEntryForReport.PaymentMethod, dbo.vueAccountExpenseEntryForReport.AccountLocationId, 
                      dbo.vueAccountExpenseEntryForReport.ClientNick, dbo.vueAccountExpenseEntryForReport.ProjectDescription, dbo.vueAccountExpenseEntryForReport.ProjectCode, 
                      dbo.vueAccountExpenseEntryForReport.DepartmentCode, dbo.vueAccountEmployee.EmployeeName AS ApproverEmployeeName, 
                      dbo.vueAccountEmployee.EMailAddress AS ApproverEMailAddress, dbo.AccountApprovalType.ApprovalTypeName, dbo.SystemApproverType.SystemApproverType, 
                      CASE WHEN dbo.AccountExpenseEntryApproval.IsApproved = 1 THEN 'Approved' WHEN dbo.AccountExpenseEntryApproval.IsRejected = 1 THEN 'Rejected' END AS Status,
                       dbo.vueAccountEmployee.Role, dbo.vueAccountEmployee.AccountRoleId, dbo.vueAccountEmployee.AccountDepartmentId, 
                      dbo.vueAccountExpenseEntryForReport.TaskName
FROM         dbo.SystemApproverType INNER JOIN
                      dbo.AccountApprovalPath ON dbo.SystemApproverType.SystemApproverTypeId = dbo.AccountApprovalPath.SystemApproverTypeId RIGHT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId LEFT OUTER JOIN
                      dbo.AccountApprovalType ON dbo.AccountExpenseEntryApproval.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId LEFT OUTER JOIN
                      dbo.vueAccountEmployee ON dbo.AccountExpenseEntryApproval.ApprovedByEmployeeId = dbo.vueAccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.vueAccountExpenseEntryForReport ON 
                      dbo.AccountExpenseEntryApproval.AccountExpenseEntryId = dbo.vueAccountExpenseEntryForReport.AccountExpenseEntryId