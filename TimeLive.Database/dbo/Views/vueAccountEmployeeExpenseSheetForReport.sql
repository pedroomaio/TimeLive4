
CREATE VIEW dbo.vueAccountEmployeeExpenseSheetForReport
AS
SELECT     dbo.vueAccountEmployeeExpenseSheet.AccountEmployeeExpenseSheetId, dbo.vueAccountEmployeeExpenseSheet.AccountId, 
                      dbo.vueAccountEmployeeExpenseSheet.AccountEmployeeId, dbo.vueAccountEmployeeExpenseSheet.Description, 
                      dbo.vueAccountEmployeeExpenseSheet.ExpenseSheetDate, dbo.vueAccountEmployeeExpenseSheet.Amount, dbo.vueAccountEmployeeExpenseSheet.Currency, 
                      dbo.vueAccountEmployeeExpenseSheet.CurrencyCode, dbo.vueAccountEmployeeExpenseSheet.AccountCurrencyId, dbo.vueAccountEmployeeExpenseSheet.Status, 
                      dbo.vueAccountEmployeeExpenseSheet.InApproval, dbo.vueAccountEmployeeExpenseSheet.Submitted, dbo.vueAccountEmployeeExpenseSheet.Rejected, 
                      dbo.vueAccountEmployeeExpenseSheet.Approved, dbo.vueAccountEmployeeExpenseSheet.SubmittedDate, dbo.vueAccountEmployeeExpenseSheet.EmployeeName, 
                      dbo.vueAccountEmployeeExpenseSheet.EMailAddress, { fn DAYOFMONTH(dbo.vueAccountEmployeeExpenseSheet.ExpenseSheetDate) } AS DayNo, 
                      MONTH(dbo.vueAccountEmployeeExpenseSheet.ExpenseSheetDate) AS MonthNo, DATEPART(week, dbo.vueAccountEmployeeExpenseSheet.ExpenseSheetDate) 
                      - DATEPART(week, DATEADD(month, DATEDIFF(month, 0, dbo.vueAccountEmployeeExpenseSheet.ExpenseSheetDate), 0)) + 1 AS WeekNo, 
                      YEAR(dbo.vueAccountEmployeeExpenseSheet.ExpenseSheetDate) AS Year, LEFT({ fn MONTHNAME(dbo.vueAccountEmployeeExpenseSheet.ExpenseSheetDate) }, 3) 
                      + ' - ' + CONVERT(nvarchar(10), YEAR(dbo.vueAccountEmployeeExpenseSheet.ExpenseSheetDate)) AS Period, 
                      { fn DAYNAME(dbo.vueAccountEmployeeExpenseSheet.ExpenseSheetDate) } AS WeekDayName, dbo.vueAccountEmployee.DepartmentName, 
                      dbo.vueAccountEmployee.Role, dbo.vueAccountEmployee.AccountLocation, dbo.vueAccountEmployee.AccountDepartmentId, 
                      dbo.vueAccountEmployee.AccountLocationId, dbo.vueAccountEmployee.AccountRoleId, dbo.vueAccountEmployee.EmployeeCode, 
                      dbo.AccountDepartment.DepartmentCode, dbo.vueAccountEmployeeExpenseSheet.ExchangeRate, 
                      CASE WHEN dbo.vueAccountEmployeeExpenseSheet.ExchangeRate > 0 THEN dbo.vueAccountEmployeeExpenseSheet.Amount / dbo.vueAccountEmployeeExpenseSheet.ExchangeRate
                       ELSE 0 END AS CurrencyAmount, dbo.vueAccountEmployeeExpenseSheet.ApprovedOn, dbo.vueAccountEmployeeExpenseSheet.ApprovedByEmployeeId, 
                      dbo.vueAccountEmployeeExpenseSheet.RejectedOn, dbo.vueAccountEmployeeExpenseSheet.RejectedByEmployeeId, 
                      dbo.vueAccountEmployeeExpenseSheet.CustomField1, dbo.vueAccountEmployeeExpenseSheet.CustomField2, 
                      dbo.vueAccountEmployeeExpenseSheet.CustomField3, dbo.vueAccountEmployeeExpenseSheet.CustomField4, 
                      dbo.vueAccountEmployeeExpenseSheet.CustomField5, dbo.vueAccountEmployeeExpenseSheet.CustomField6, 
                      dbo.vueAccountEmployeeExpenseSheet.CustomField7, dbo.vueAccountEmployeeExpenseSheet.CustomField8, 
                      dbo.vueAccountEmployeeExpenseSheet.CustomField9, dbo.vueAccountEmployeeExpenseSheet.CustomField10, 
                      dbo.vueAccountEmployeeExpenseSheet.CustomField11, dbo.vueAccountEmployeeExpenseSheet.CustomField12, 
                      dbo.vueAccountEmployeeExpenseSheet.CustomField13, dbo.vueAccountEmployeeExpenseSheet.CustomField14, 
                      dbo.vueAccountEmployeeExpenseSheet.CustomField15
FROM         dbo.vueAccountEmployeeExpenseSheet LEFT OUTER JOIN
                      dbo.vueAccountEmployee ON dbo.vueAccountEmployeeExpenseSheet.AccountEmployeeId = dbo.vueAccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.vueAccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId