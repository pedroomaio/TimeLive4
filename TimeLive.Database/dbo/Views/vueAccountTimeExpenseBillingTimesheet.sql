	
CREATE VIEW dbo.vueAccountTimeExpenseBillingTimesheet
AS
SELECT        dbo.AccountProject.AccountClientId, dbo.AccountProject.ProjectName, dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProject.AccountProjectId, 
                         dbo.AccountEmployeeTimeEntry.AccountTimeExpenseBillingTimesheetId, dbo.AccountEmployeeTimeEntry.BillingRate, dbo.AccountEmployeeTimeEntry.BillingRateCurrencyId, 
                         dbo.AccountTimeExpenseBillingTimesheet.Description, dbo.AccountEmployeeTimeEntry.Approved, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, 
                         dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, ROUND(CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) 
                         / 60, 2) AS TotalHours, dbo.AccountEmployeeTimeEntry.BillingRate * DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) AS Amount, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                         dbo.AccountTimeExpenseBillingTimesheet.BillHours, dbo.AccountTimeExpenseBillingTimesheet.ActualBillingRate, dbo.AccountTimeExpenseBillingTimesheet.TotalAmount, 
                         dbo.AccountTimeExpenseBillingTimesheet.AccountTaxCodeId1, dbo.AccountTimeExpenseBillingTimesheet.AccountTaxCodeId2, dbo.AccountTimeExpenseBilling.SubTotal, 
                         dbo.AccountTimeExpenseBilling.TaxCode1, dbo.AccountTimeExpenseBilling.TaxCode2, dbo.AccountTimeExpenseBilling.GrandTotal, dbo.AccountParty.PartyNick, 
                         dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId, dbo.AccountEmployeeTimeEntry.Billed, dbo.AccountEmployeeTimeEntry.BillingRateExchangeRate, dbo.AccountProjectTask.IsBillable, 
                         dbo.AccountEmployeeTimeEntry.Description AS TimesheetDescription, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                         dbo.AccountProjectTask.IsParentTask, dbo.AccountEmployeeTimeEntry.AccountWorkTypeId, dbo.AccountWorkType.AccountWorkType, dbo.AccountParty.FixedBidBillingMode, 
                         dbo.AccountProject.ProjectBillingTypeId
FROM            dbo.AccountWorkType RIGHT OUTER JOIN
                         dbo.AccountProjectTask INNER JOIN
                         dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId INNER JOIN
                         dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                         dbo.AccountWorkType.AccountWorkTypeId = dbo.AccountEmployeeTimeEntry.AccountWorkTypeId LEFT OUTER JOIN
                         dbo.AccountTimeExpenseBillingTimesheet RIGHT OUTER JOIN
                         dbo.AccountTimeExpenseBilling ON dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingId ON 
                         dbo.AccountEmployeeTimeEntry.AccountTimeExpenseBillingTimesheetId = dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingTimesheetId AND 
                         dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountTimeExpenseBillingTimesheet.AccountProjectId AND 
                         dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountTimeExpenseBillingTimesheet.AccountProjectTaskId RIGHT OUTER JOIN
                         dbo.AccountParty ON dbo.AccountParty.AccountPartyId = dbo.AccountProject.AccountClientId
WHERE        (dbo.AccountEmployeeTimeEntry.Approved = 1) AND (dbo.AccountEmployeeTimeEntry.Billed <> 1)