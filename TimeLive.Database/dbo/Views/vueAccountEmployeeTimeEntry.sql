
CREATE VIEW dbo.vueAccountEmployeeTimeEntry
AS                        
SELECT     CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE dbo.AccountEmployee.FirstName
                       + ' ' + dbo.AccountEmployee.LastName END AS EmployeeName, dbo.AccountProject.ProjectName, 
                      CASE WHEN dbo.AccountProjectTask.AccountProjectTaskId IS NOT NULL 
                      THEN dbo.AccountProjectTask.TaskName ELSE AccountTimeOffType.AccountTimeOffType END AS TaskName, 
                      dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.Approved, dbo.AccountEmployee.AccountEmployeeId, 
                      dbo.AccountProject.AccountProjectId, dbo.AccountEmployeeTimeEntry.TeamLeadApproved, dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.AccountEmployeeTimeEntry.AdministratorApproved, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountEmployeeTimeEntry.Description, dbo.AccountEmployee.AccountId, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, DATEPART(dw, dbo.AccountEmployeeTimeEntry.TimeEntryDate) 
                      AS WeekDay, dbo.AccountParty.AccountPartyId, dbo.AccountParty.PartyName, dbo.AccountProjectTask.AccountProjectTaskId, 
                      dbo.AccountBillingType.BillingType, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountProjectTask.IsBillable, 
                      dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, dbo.AccountProject.ProjectBillingRateTypeId, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountDepartment.DepartmentName, 
                      dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, dbo.AccountEmployeeTimeEntry.Submitted, 
                      dbo.AccountWorkType.AccountWorkType, dbo.AccountEmployee.EMailAddress, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountCostCenter.AccountCostCenter, dbo.AccountCostCenter.AccountCostCenterCode, dbo.AccountWorkType.AccountWorkTypeCode, 
                      dbo.AccountProject.ProjectCode, dbo.AccountProjectTask.TaskCode, dbo.AccountLocation.AccountLocationId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction.Comments, dbo.AccountEmployeeTimeEntry.BillingRateCurrencyId, 
                      dbo.AccountEmployeeTimeEntry.EmployeeRateCurrencyId, dbo.AccountEmployeeTimeEntry.BillingRateExchangeRate, 
                      dbo.AccountEmployeeTimeEntry.EmployeeRateExchangeRate, dbo.AccountEmployeeTimeEntry.AccountBaseCurrencyId, 
                      dbo.AccountProjectTask.AccountTaskTypeId, dbo.AccountProjectTask.TaskStatusId, dbo.AccountProjectTask.AccountPriorityId, 
                      dbo.AccountProjectTask.AccountProjectMilestoneId, dbo.AccountDepartment.DepartmentCode, dbo.AccountParty.PartyNick, 
                      dbo.AccountProjectTask.EstimatedCurrencyId, dbo.vueAccountEmployeeTimeEntryApprovalLastAction.ApprovedOn, 
                      dbo.AccountEmployeeTimeEntry.EmployeeRate, dbo.AccountRole.AccountRoleId, dbo.AccountRole.Role, dbo.AccountProject.AccountProjectTypeId, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProjectTask.TaskDescription, 
                      dbo.AccountEmployeeTimeEntry.AccountTimeExpenseBillingTimesheetId, dbo.AccountEmployeeTimeEntry.Billed, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId, 
                      CASE WHEN dbo.AccountEmployeeTimeEntry.Submitted = 1 THEN ROUND(CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60, 2) END AS SubmittedHours, 
                      CASE WHEN dbo.AccountEmployeeTimeEntry.Approved = 1 THEN ROUND(CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60, 2) END AS ApprovedHours, 
                      CASE WHEN dbo.AccountEmployeeTimeEntry.Rejected = 1 THEN ROUND(CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60, 2) END AS RejectedHours, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, 
                      dbo.AccountPartyContact.FirstName + N' ' + dbo.AccountPartyContact.LastName AS ClientContactName, 
                      dbo.AccountPartyDepartment.PartyDepartmentCode AS ClientDepartmentCode, 
                      dbo.AccountPartyDepartment.PartyDepartmentName AS ClientDepartmentName, 
                      dbo.AccountPartyDepartment.PartyDepartmentLocation AS ClientDepartmentLocation, dbo.AccountWorkType.AccountWorkTypeId, 
                      dbo.AccountEmployeeTimeEntry.IsTimeOff, dbo.AccountEmployeeTimeEntry.Hours, dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeOffRequestId, dbo.AccountEmployeeTimeEntry.Percentage, 
                      dbo.AccountEmployeeTimeEntry.CustomField1, dbo.AccountEmployeeTimeEntry.CustomField2, dbo.AccountEmployeeTimeEntry.CustomField3, 
                      dbo.AccountEmployeeTimeEntry.CustomField4, dbo.AccountEmployeeTimeEntry.CustomField5, dbo.AccountEmployeeTimeEntry.CustomField6, 
                      dbo.AccountEmployeeTimeEntry.CustomField7, dbo.AccountEmployeeTimeEntry.CustomField8, dbo.AccountEmployeeTimeEntry.CustomField9, 
                      dbo.AccountEmployeeTimeEntry.CustomField10, dbo.AccountEmployeeTimeEntry.CustomField11, dbo.AccountEmployeeTimeEntry.CustomField12, 
                      dbo.AccountEmployeeTimeEntry.CustomField13, dbo.AccountEmployeeTimeEntry.CustomField14, 
                      dbo.AccountEmployeeTimeEntry.CustomField15
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountTimeOffType ON 
                      dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountPartyDepartment ON 
                      dbo.AccountProject.AccountPartyDepartmentId = dbo.AccountPartyDepartment.AccountPartyDepartmentId LEFT OUTER JOIN
                      dbo.AccountPartyContact ON dbo.AccountProject.AccountPartyContactId = dbo.AccountPartyContact.AccountPartyContactId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryPeriod ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId LEFT
                       OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApprovalLastAction.AccountEmployeeTimeEntryId LEFT
                       OUTER JOIN
                      dbo.AccountCostCenter ON dbo.AccountEmployeeTimeEntry.AccountCostCenterId = dbo.AccountCostCenter.AccountCostCenterId LEFT OUTER JOIN
                      dbo.AccountWorkType ON dbo.AccountEmployeeTimeEntry.AccountWorkTypeId = dbo.AccountWorkType.AccountWorkTypeId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId