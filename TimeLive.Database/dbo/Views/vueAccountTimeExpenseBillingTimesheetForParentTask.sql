
CREATE VIEW dbo.vueAccountTimeExpenseBillingTimesheetForParentTask
AS
SELECT     ISNULL(AccountProjectTask_1.TaskName, b.TaskName) AS TaskName, dbo.AccountProject.AccountClientId, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.AccountProjectId, dbo.AccountEmployeeTimeEntry.BillingRateCurrencyId, dbo.AccountEmployeeTimeEntry.Approved, SUM(DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, SUM(ROUND(CONVERT(float, 
                      DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60, 2)) AS TotalHours, 
                      SUM(ROUND(CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60, 2) 
                      * dbo.AccountEmployeeTimeEntry.BillingRate) AS Amount, 
                      SUM(dbo.AccountTimeExpenseBillingTimesheet.BillHours) AS BillHours, SUM(dbo.AccountTimeExpenseBillingTimesheet.TotalAmount) AS TotalAmount, 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountTaxCodeId1, dbo.AccountTimeExpenseBillingTimesheet.AccountTaxCodeId2, 
                      SUM(dbo.AccountTimeExpenseBilling.SubTotal) AS SubTotal, dbo.AccountTimeExpenseBilling.TaxCode1, dbo.AccountTimeExpenseBilling.TaxCode2, 
                      SUM(dbo.AccountTimeExpenseBilling.GrandTotal) AS GrandTotal, dbo.AccountParty.PartyNick, dbo.AccountEmployeeTimeEntry.Billed, 
                      dbo.AccountEmployeeTimeEntry.BillingRateExchangeRate, b.IsBillable, dbo.AccountEmployeeTimeEntry.Description AS TimesheetDescription, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.BillingRate, dbo.AccountTimeExpenseBillingTimesheet.ActualBillingRate, 
                      b.ParentAccountProjectTaskId, b.AccountProjectTaskId
FROM         dbo.AccountProjectTask AS AccountProjectTask_1 RIGHT OUTER JOIN
                          (SELECT     IsBillable, AccountProjectID, AccountProjectTaskId, TaskName, ParentAccountProjectTaskId
                            FROM          dbo.AccountProjectTaskWithParentTask(NULL) AS AccountProjectTaskWithParentTask_1) AS b INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON b.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      AccountProjectTask_1.AccountProjectTaskId = b.ParentAccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountTimeExpenseBillingTimesheet RIGHT OUTER JOIN
                      dbo.AccountTimeExpenseBilling ON 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId ON 
                      dbo.AccountEmployeeTimeEntry.AccountTimeExpenseBillingTimesheetId = dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingTimesheetId AND 
                      dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountTimeExpenseBillingTimesheet.AccountProjectId AND 
                      dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountTimeExpenseBillingTimesheet.AccountProjectTaskId RIGHT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId
WHERE     (dbo.AccountEmployeeTimeEntry.Approved = 1) AND (dbo.AccountEmployeeTimeEntry.Billed <> 1)
GROUP BY dbo.AccountProject.AccountClientId, dbo.AccountProject.ProjectName, dbo.AccountProject.AccountProjectId, dbo.AccountTimeExpenseBillingTimesheet.Description, 
                      dbo.AccountEmployeeTimeEntry.Approved, dbo.AccountTimeExpenseBilling.TaxCode1, dbo.AccountTimeExpenseBilling.TaxCode2, dbo.AccountParty.PartyNick, 
                      ISNULL(AccountProjectTask_1.TaskName, b.TaskName), dbo.AccountEmployeeTimeEntry.Description, b.IsBillable, 
                      dbo.AccountEmployeeTimeEntry.BillingRateExchangeRate, dbo.AccountEmployeeTimeEntry.Billed, dbo.AccountEmployeeTimeEntry.BillingRateCurrencyId, 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountTaxCodeId1, dbo.AccountTimeExpenseBillingTimesheet.AccountTaxCodeId2, b.ParentAccountProjectTaskId, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.BillingRate, dbo.AccountTimeExpenseBillingTimesheet.ActualBillingRate, 
                      b.AccountProjectTaskId