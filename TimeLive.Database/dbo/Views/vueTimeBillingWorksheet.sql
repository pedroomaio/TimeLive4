
CREATE VIEW dbo.vueTimeBillingWorksheet
AS
SELECT     dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.vueAccountEmployeeTimeEntry.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntry.TaskName, dbo.vueAccountEmployeeTimeEntry.TotalTime, dbo.vueAccountEmployeeTimeEntry.Approved, 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntry.TeamLeadApproved, dbo.vueAccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.vueAccountEmployeeTimeEntry.AdministratorApproved, dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntry.StartTime, dbo.vueAccountEmployeeTimeEntry.EndTime, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntry.Description, dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.vueAccountEmployeeTimeEntry.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntry.WeekDay, dbo.vueAccountEmployeeTimeEntry.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntry.BillingType, dbo.vueAccountEmployeeTimeEntry.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntry.ProjectManagerEmployeeId, dbo.vueAccountEmployeeTimeEntry.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntry.ExpenseApprovalTypeId, dbo.vueAccountEmployeeTimeEntry.IsBillable, 
                      dbo.vueAccountEmployeeTimeEntry.Rejected, dbo.vueAccountEmployeeTimeEntry.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntry.ProjectBillingRateTypeId, dbo.vueAccountEmployeeTimeEntry.EmployeeCode, 
                      dbo.vueAccountEmployeeTimeEntry.AccountDepartmentId, dbo.vueAccountEmployeeTimeEntry.DepartmentName, 
                      dbo.vueAccountEmployeeTimeEntry.EstimatedCost, dbo.vueAccountEmployeeTimeEntry.EstimatedTimeSpent, 
                      dbo.vueAccountEmployeeTimeEntry.Submitted, dbo.vueAccountEmployeeTimeEntry.AccountWorkType, 
                      dbo.vueAccountEmployeeTimeEntry.EMailAddress, dbo.vueAccountEmployeeTimeEntry.AccountLocation, 
                      dbo.vueAccountEmployeeTimeEntry.AccountCostCenter, dbo.vueAccountEmployeeTimeEntry.AccountCostCenterCode, 
                      dbo.vueAccountEmployeeTimeEntry.AccountWorkTypeCode, dbo.vueAccountEmployeeTimeEntry.ProjectCode, 
                      dbo.vueAccountEmployeeTimeEntry.TaskCode, dbo.vueAccountEmployeeTimeEntry.AccountLocationId, dbo.vueAccountEmployeeTimeEntry.Comments,
                       dbo.vueAccountEmployeeTimeEntry.Billed, dbo.vueAccountEmployeeTimeEntry.AccountTimeExpenseBillingTimesheetId, 
                      dbo.AccountTimeExpenseBilling.InvoiceNumber, dbo.AccountTimeExpenseBilling.InvoiceDate, dbo.AccountTimeExpenseBilling.PONumber, 
                      dbo.AccountTimeExpenseBilling.SubTotal, dbo.AccountTimeExpenseBilling.TaxCode1, dbo.AccountTimeExpenseBilling.TaxCode2, 
                      dbo.AccountTimeExpenseBilling.GrandTotal, dbo.AccountTimeExpenseBilling.BillingCycleStartDate, 
                      dbo.AccountTimeExpenseBilling.BillingCycleEndDate, dbo.AccountParty.PartyNick, dbo.AccountParty.AccountPartyId AS AccountClientId, 
                      dbo.AccountParty.PartyName
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId RIGHT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEntry ON dbo.AccountProject.AccountProjectId = dbo.vueAccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountTimeExpenseBilling INNER JOIN
                      dbo.AccountTimeExpenseBillingTimesheet ON 
                      dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingId ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountTimeExpenseBillingTimesheetId = dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingTimesheetId
WHERE     (dbo.vueAccountEmployeeTimeEntry.IsBillable = 1) AND (dbo.vueAccountEmployeeTimeEntry.Approved = 1)