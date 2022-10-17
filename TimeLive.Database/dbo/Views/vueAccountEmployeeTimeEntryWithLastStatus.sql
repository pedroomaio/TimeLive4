
CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithLastStatus
AS               
SELECT     dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.AccountEmployeeId, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, 
                      dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.AccountProjectId, dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, 
                      dbo.AccountEmployeeTimeEntry.Description, dbo.AccountEmployeeTimeEntry.TimeSheetApprovalPathId, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountEmployeeTimeEntry.TeamLeadApproved, dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.AccountEmployeeTimeEntry.AdministratorApproved, dbo.AccountEmployeeTimeEntry.CreatedOn, dbo.AccountEmployeeTimeEntry.ModifiedOn, 
                      dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction.IsApproved, dbo.vueAccountEmployeeTimeEntryApprovalLastAction.IsReject, 
                      dbo.AccountEmployeeTimeEntry.AccountPartyId, dbo.AccountEmployeeTimeEntry.Submitted, dbo.AccountEmployeeTimeEntry.AccountWorkTypeId, 
                      dbo.AccountEmployeeTimeEntry.AccountCostCenterId, dbo.vueAccountEmployeeTimeEntryApprovalLastAction.ApprovedByEmployeeId, 
                      dbo.AccountProject.ProjectName, dbo.AccountProjectTask.TaskName, dbo.AccountCostCenter.AccountCostCenter, 
                      dbo.AccountWorkType.AccountWorkType, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId, dbo.AccountParty.PartyName, 
                      dbo.AccountParty.AccountPartyId AS AccountClientId, dbo.AccountParty.PartyNick, dbo.vueAccountEmployeeTimeEntryApprovalLastAction.ApprovedOn, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntry.IsTimeOff, 
                      dbo.AccountEmployeeTimeEntry.Hours, dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId, dbo.AccountEmployeeTimeEntry.Percentage, 
                      dbo.AccountEmployeeTimeEntry.CustomField1, dbo.AccountEmployeeTimeEntry.CustomField2, dbo.AccountEmployeeTimeEntry.CustomField3, 
                      dbo.AccountEmployeeTimeEntry.CustomField4, dbo.AccountEmployeeTimeEntry.CustomField5, dbo.AccountEmployeeTimeEntry.CustomField6, 
                      dbo.AccountEmployeeTimeEntry.CustomField7, dbo.AccountEmployeeTimeEntry.CustomField8, dbo.AccountEmployeeTimeEntry.CustomField9, 
                      dbo.AccountEmployeeTimeEntry.CustomField10, dbo.AccountEmployeeTimeEntry.CustomField11, dbo.AccountEmployeeTimeEntry.CustomField12, 
                      dbo.AccountEmployeeTimeEntry.CustomField13, dbo.AccountEmployeeTimeEntry.CustomField14, dbo.AccountEmployeeTimeEntry.CustomField15, 
                      DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, 
                      dbo.AccountEmployeeTimeEntryPeriod.PeriodDescription
FROM         dbo.AccountProjectTask RIGHT OUTER JOIN
                      dbo.AccountProject RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryPeriod ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountEmployeeTimeEntry.AccountPartyId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountCostCenter ON dbo.AccountEmployeeTimeEntry.AccountCostCenterId = dbo.AccountCostCenter.AccountCostCenterId LEFT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApprovalLastAction.AccountEmployeeTimeEntryId LEFT
                       OUTER JOIN
                      dbo.AccountWorkType ON dbo.AccountEmployeeTimeEntry.AccountWorkTypeId = dbo.AccountWorkType.AccountWorkTypeId