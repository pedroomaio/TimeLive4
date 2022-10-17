
CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithStatus
AS               
SELECT     dbo.AccountCostCenter.AccountCostCenter, dbo.AccountProject.ProjectName, dbo.AccountWorkType.AccountWorkType, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeId, dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.StartTime, 
                      dbo.AccountEmployeeTimeEntry.EndTime, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.AccountProjectId, 
                      dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, dbo.AccountEmployeeTimeEntry.Description, 
                      dbo.AccountEmployeeTimeEntry.TimeSheetApprovalPathId, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountEmployeeTimeEntry.TeamLeadApproved, dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.AccountEmployeeTimeEntry.AdministratorApproved, dbo.AccountEmployeeTimeEntry.CreatedOn, dbo.AccountEmployeeTimeEntry.ModifiedOn, 
                      dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, dbo.AccountEmployeeTimeEntry.AccountPartyId, 
                      dbo.AccountEmployeeTimeEntry.Submitted, dbo.AccountEmployeeTimeEntry.AccountWorkTypeId, dbo.AccountEmployeeTimeEntry.EmployeeRate, 
                      dbo.AccountEmployeeTimeEntry.AccountCostCenterId, dbo.AccountEmployeeTimeEntry.BillingRateCurrencyId, 
                      dbo.AccountEmployeeTimeEntry.EmployeeRateCurrencyId, dbo.AccountEmployeeTimeEntry.BillingRateExchangeRate, 
                      dbo.AccountEmployeeTimeEntry.EmployeeRateExchangeRate, dbo.AccountEmployeeTimeEntry.AccountBaseCurrencyId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId, 
                      dbo.AccountEmployeeTimeEntry.AccountTimeExpenseBillingTimesheetId, dbo.AccountEmployeeTimeEntry.Billed, 
                      dbo.AccountEmployeeTimeEntryApprovalProject.InApproval AS IsApproved, dbo.AccountEmployeeTimeEntryApprovalProject.IsRejected AS IsReject, 
                      dbo.AccountParty.PartyName, dbo.AccountParty.PartyNick, dbo.AccountParty.AccountPartyId AS AccountClientId, 
                      dbo.AccountEmployeeTimeEntryPeriod.PeriodDescription, dbo.AccountParty.AccountId, dbo.AccountEmployeeTimeEntry.IsTimeOff, 
                      dbo.AccountEmployeeTimeEntry.Hours, dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId, dbo.AccountTimeOffType.AccountTimeOffType, 
                      dbo.AccountTimeOffType.IsTimeOffRequestRequired, dbo.AccountEmployeeTimeEntryApprovalProject.Approved AS ProjectApproved, 
                      dbo.AccountEmployeeTimeEntry.Percentage, dbo.AccountEmployeeTimeEntry.CustomField1, dbo.AccountEmployeeTimeEntry.CustomField2, 
                      dbo.AccountEmployeeTimeEntry.CustomField3, dbo.AccountEmployeeTimeEntry.CustomField4, dbo.AccountEmployeeTimeEntry.CustomField5, 
                      dbo.AccountEmployeeTimeEntry.CustomField6, dbo.AccountEmployeeTimeEntry.CustomField7, dbo.AccountEmployeeTimeEntry.CustomField8, 
                      dbo.AccountEmployeeTimeEntry.CustomField9, dbo.AccountEmployeeTimeEntry.CustomField10, dbo.AccountEmployeeTimeEntry.CustomField11, 
                      dbo.AccountEmployeeTimeEntry.CustomField12, dbo.AccountEmployeeTimeEntry.CustomField13, dbo.AccountEmployeeTimeEntry.CustomField14, 
                      dbo.AccountEmployeeTimeEntry.CustomField15
FROM         dbo.AccountProject RIGHT OUTER JOIN
                      dbo.AccountTimeOffType RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountEmployeeTimeEntry.AccountPartyId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountTimeOffType.AccountTimeOffTypeId = dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryPeriod ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId LEFT
                       OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApprovalProject ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntryApprovalProject.AccountEmployeeTimeEntryApprovalProjectId
                       ON dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountWorkType ON dbo.AccountEmployeeTimeEntry.AccountWorkTypeId = dbo.AccountWorkType.AccountWorkTypeId LEFT OUTER JOIN
                      dbo.AccountCostCenter ON dbo.AccountEmployeeTimeEntry.AccountCostCenterId = dbo.AccountCostCenter.AccountCostCenterId