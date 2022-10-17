
CREATE VIEW dbo.rptvueAccountEmployeeExpenseSheet
AS
SELECT     dbo.vueAccountEmployeeExpenseSheetForReport.AccountEmployeeExpenseSheetId, dbo.vueAccountEmployeeExpenseSheetForReport.AccountId, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.AccountEmployeeId, dbo.vueAccountEmployeeExpenseSheetForReport.Description, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.ExpenseSheetDate, ISNULL(dbo.vueAccountEmployeeExpenseSheetForReport.Amount, 0) AS Amount, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.Currency, dbo.vueAccountEmployeeExpenseSheetForReport.CurrencyCode, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.AccountCurrencyId, dbo.vueAccountEmployeeExpenseSheetForReport.Status, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.InApproval, dbo.vueAccountEmployeeExpenseSheetForReport.Submitted, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.Rejected, dbo.vueAccountEmployeeExpenseSheetForReport.Approved, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.SubmittedDate, dbo.vueAccountEmployeeExpenseSheetForReport.EmployeeName, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.EMailAddress, dbo.vueAccountEmployeeExpenseSheetForReport.DayNo, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.MonthNo, dbo.vueAccountEmployeeExpenseSheetForReport.WeekNo, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.Year, dbo.vueAccountEmployeeExpenseSheetForReport.Period, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.WeekDayName, dbo.vueAccountEmployeeExpenseSheetForReport.DepartmentName, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.Role, dbo.vueAccountEmployeeExpenseSheetForReport.AccountLocation, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.AccountDepartmentId, dbo.vueAccountEmployeeExpenseSheetForReport.AccountLocationId, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.AccountRoleId, dbo.vueAccountEmployeeExpenseSheetForReport.EmployeeCode, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.DepartmentCode, dbo.vueAccountEmployeeExpenseSheetForReport.ExchangeRate, 
                      ISNULL(dbo.vueAccountEmployeeExpenseSheetForReport.CurrencyAmount, 0) AS CurrencyAmount, 
                      CASE WHEN dbo.vueAccountEmployeeExpenseSheetForReport.Approved = 1 THEN dbo.vueAccountEmployeeExpenseSheetForReport.ApprovedOn ELSE NULL 
                      END AS ApprovedDate, 
                      CASE WHEN dbo.vueAccountEmployeeExpenseSheetForReport.Rejected = 1 THEN dbo.vueAccountEmployeeExpenseSheetForReport.RejectedOn ELSE NULL 
                      END AS RejectedDate, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS ApprovedByEmployeeName, 
                      AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS RejectedByEmployeeName, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField1, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.CustomField2, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField3, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.CustomField4, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField5, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.CustomField6, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField7, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.CustomField8, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField9, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.CustomField10, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField11, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.CustomField12, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField13, 
                      dbo.vueAccountEmployeeExpenseSheetForReport.CustomField14, dbo.vueAccountEmployeeExpenseSheetForReport.CustomField15
FROM         dbo.vueAccountEmployeeExpenseSheetForReport LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      dbo.vueAccountEmployeeExpenseSheetForReport.RejectedByEmployeeId = AccountEmployee_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeExpenseSheetForReport.ApprovedByEmployeeId = dbo.AccountEmployee.AccountEmployeeId