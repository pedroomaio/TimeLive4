
CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithTimeOffForReport
AS
SELECT       
 CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                         dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disbaled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                         dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND 
                         dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disbaled)' ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName
						 END AS EmployeeName
                          , CASE WHEN dbo.AccountProject.IsDisabled = 1 THEN dbo.AccountProject.ProjectName + ' ' + '(Disabled)' ELSE dbo.AccountProject.ProjectName END AS ProjectName, 
                         CASE WHEN dbo.AccountEmployeeTimeEntry.IsTimeOff <> 1 THEN AccountProjectTask.TaskName ELSE dbo.AccountTimeOffType.AccountTimeOffType END AS TaskName, 
                         dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.Approved, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProject.AccountProjectId, 
                         dbo.AccountEmployeeTimeEntry.TeamLeadApproved, dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, dbo.AccountEmployeeTimeEntry.AdministratorApproved, 
                         dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                         dbo.AccountEmployeeTimeEntry.Description
	   ,
	    dbo.AccountEmployeeTimeEntryPeriod.AccountId
	   , DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                         * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, DATEPART(dw, dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS WeekDay, dbo.AccountParty.AccountPartyId, 
                         dbo.AccountParty.PartyName, AccountProjectTask.AccountProjectTaskId, dbo.AccountBillingType.BillingType, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                         dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, AccountProjectTask.IsBillable, dbo.AccountEmployeeTimeEntry.Rejected, 
                         dbo.AccountEmployeeTimeEntry.BillingRate, dbo.AccountProject.ProjectBillingRateTypeId, dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.AccountDepartmentId, 
                         dbo.AccountDepartment.DepartmentName, AccountProjectTask.EstimatedCost, AccountProjectTask.EstimatedTimeSpent, dbo.AccountEmployeeTimeEntry.Submitted, dbo.AccountWorkType.AccountWorkType, 
                         dbo.AccountEmployee.EMailAddress, dbo.AccountLocation.AccountLocation, dbo.AccountCostCenter.AccountCostCenter, dbo.AccountCostCenter.AccountCostCenterCode, 
                         dbo.AccountWorkType.AccountWorkTypeCode, CASE WHEN ISNULL(dbo.AccountProject.ProjectPrefix, '') 
                         = '' THEN dbo.AccountProject.ProjectCode ELSE dbo.AccountProject.ProjectPrefix + '-' + dbo.AccountProject.ProjectCode END AS ProjectCode, AccountProjectTask.TaskCode, 
                         dbo.AccountLocation.AccountLocationId,
						 dbo.vueAccountEmployeeTimeEntryApprovalLastAction.Comments, 
						 dbo.AccountEmployeeTimeEntry.BillingRateCurrencyId, 
                         dbo.AccountEmployeeTimeEntry.EmployeeRateCurrencyId, dbo.AccountEmployeeTimeEntry.BillingRateExchangeRate, dbo.AccountEmployeeTimeEntry.EmployeeRateExchangeRate, 
                         dbo.AccountEmployeeTimeEntry.AccountBaseCurrencyId, AccountProjectTask.AccountTaskTypeId, AccountProjectTask.TaskStatusId, AccountProjectTask.AccountPriorityId, 
                         AccountProjectTask.AccountProjectMilestoneId, dbo.AccountDepartment.DepartmentCode, dbo.AccountParty.PartyNick, AccountProjectTask.EstimatedCurrencyId, 
                         dbo.vueAccountEmployeeTimeEntryApprovalLastAction.ApprovedOn, 
						 dbo.AccountEmployeeTimeEntry.EmployeeRate, dbo.AccountRole.AccountRoleId, dbo.AccountRole.Role, 
                         dbo.AccountProject.AccountProjectTypeId, dbo.AccountProject.ProjectDescription, AccountProjectTask.TaskDescription, dbo.AccountEmployeeTimeEntry.AccountTimeExpenseBillingTimesheetId, 
                         dbo.AccountEmployeeTimeEntry.Billed, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId,
                         CASE WHEN dbo.AccountEmployeeTimeEntry.Submitted = 1 THEN (CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60)
                          END AS SubmittedHours, CASE WHEN dbo.AccountEmployeeTimeEntry.Approved = 1 THEN (CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, 
                         dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) END AS ApprovedHours, CASE WHEN dbo.AccountEmployeeTimeEntry.Rejected = 1 THEN (CONVERT(float, DATEPART(hh, 
                         dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) END AS RejectedHours, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, 
                         dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, 
                         dbo.AccountPartyContact.FirstName + N' ' + dbo.AccountPartyContact.LastName AS ClientContactName, dbo.AccountPartyDepartment.PartyDepartmentCode AS ClientDepartmentCode, 
                         dbo.AccountPartyDepartment.PartyDepartmentName AS ClientDepartmentName, dbo.AccountPartyDepartment.PartyDepartmentLocation AS ClientDepartmentLocation, dbo.AccountEmployeeTimeEntry.IsTimeOff, 
                         dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId, CASE WHEN dbo.AccountEmployeeTimeEntry.IsTimeOff <> 0 THEN (CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                         * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) END AS TimeOffHours, CASE WHEN dbo.AccountEmployeeTimeEntry.IsTimeOff <> 1 THEN (CONVERT(float, DATEPART(hh, 
                         dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) END AS TimesheetHours, dbo.AccountWorkType.AccountWorkTypeId, 
                         dbo.AccountStatus.Status AS ProjectStatus, AccountProjectTask.ParentAccountProjectTaskId, ParentTask.TaskName AS ParentTaskName, dbo.AccountEmployee.IsDisabled, 
                         dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, ISNULL(dbo.AccountEmployeeType.AccountEmployeeType, N'') AS EmployeeType, ISNULL(dbo.AccountHolidayTypeDetail.HolidayName, N'') 
                         AS HolidayName, dbo.AccountEmployeeTimeEntry.Percentage, dbo.AccountEmployeeTimeEntry.CustomField1, dbo.AccountEmployeeTimeEntry.CustomField2, dbo.AccountEmployeeTimeEntry.CustomField3, 
                         dbo.AccountEmployeeTimeEntry.CustomField4, dbo.AccountEmployeeTimeEntry.CustomField5, dbo.AccountEmployeeTimeEntry.CustomField6, dbo.AccountEmployeeTimeEntry.CustomField7, 
                         dbo.AccountEmployeeTimeEntry.CustomField8, dbo.AccountEmployeeTimeEntry.CustomField9, dbo.AccountEmployeeTimeEntry.CustomField10, dbo.AccountEmployeeTimeEntry.CustomField11, 
                         dbo.AccountEmployeeTimeEntry.CustomField12, dbo.AccountEmployeeTimeEntry.CustomField13, dbo.AccountEmployeeTimeEntry.CustomField14, dbo.AccountEmployeeTimeEntry.CustomField15, 
                         AccountProjectTask.StartDate AS TaskStartDate, AccountProjectTask.DeadlineDate AS TaskDeadlineDate, dbo.AccountParty.IsDeleted, CASE WHEN AccountProjectTask.IsBillable = 1 THEN (CONVERT(float, 
                         DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) ELSE 0 END AS BillableHours, 
                         AccountProjectTask.CustomField1 AS TaskCustomField1, AccountProjectTask.CustomField2 AS TaskCustomField2, AccountProjectTask.CustomField3 AS TaskCustomField3, 
                         AccountProjectTask.CustomField4 AS TaskCustomField4, AccountProjectTask.CustomField5 AS TaskCustomField5, AccountProjectTask.CustomField6 AS TaskCustomField6, 
                         AccountProjectTask.CustomField7 AS TaskCustomField7, AccountProjectTask.CustomField8 AS TaskCustomField8, AccountProjectTask.CustomField9 AS TaskCustomField9, 
                         AccountProjectTask.CustomField10 AS TaskCustomField10, AccountProjectTask.CustomField11 AS TaskCustomField11, AccountProjectTask.CustomField12 AS TaskCustomField12, 
                         AccountProjectTask.CustomField13 AS TaskCustomField13, AccountProjectTask.CustomField14 AS TaskCustomField14, AccountProjectTask.CustomField15 AS TaskCustomField15, 
                         dbo.AccountEmployee.JobTitle,
						 REPLACE(dbo.CombineValuesForTimeEntryApprover(dbo.AccountProject.AccountProjectId), 'SystemApproverTypeId5', ISNULL(EM.FirstName + ' ' + EM.LastName, '')) AS ProjectApprover, 
						 dbo.CombineValuesForTimeEntryCurrentApprover(dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId) AS CurrentApprover, 
                         dbo.AccountEmployee.CustomField1 AS EmployeeCustomField1, dbo.AccountEmployee.CustomField2 AS EmployeeCustomField2, dbo.AccountEmployee.CustomField3 AS EmployeeCustomField3, 
                         dbo.AccountEmployee.CustomField4 AS EmployeeCustomField4, dbo.AccountEmployee.CustomField5 AS EmployeeCustomField5, dbo.AccountEmployee.CustomField6 AS EmployeeCustomField6, 
                         dbo.AccountEmployee.CustomField7 AS EmployeeCustomField7, dbo.AccountEmployee.CustomField8 AS EmployeeCustomField8, dbo.AccountEmployee.CustomField9 AS EmployeeCustomField9, 
                         dbo.AccountEmployee.CustomField10 AS EmployeeCustomField10, dbo.AccountEmployee.CustomField11 AS EmployeeCustomField11, dbo.AccountEmployee.CustomField12 AS EmployeeCustomField12, 
                         dbo.AccountEmployee.CustomField13 AS EmployeeCustomField13, dbo.AccountEmployee.CustomField14 AS EmployeeCustomField14, dbo.AccountEmployee.CustomField15 AS EmployeeCustomField15, 
                         dbo.AccountParty.CustomField1 AS ClientCustomField1, dbo.AccountParty.CustomField2 AS ClientCustomField2, dbo.AccountParty.CustomField3 AS ClientCustomField3, 
                         dbo.AccountParty.CustomField4 AS ClientCustomField4, dbo.AccountParty.CustomField5 AS ClientCustomField5, dbo.AccountParty.CustomField6 AS ClientCustomField6, 
                         dbo.AccountParty.CustomField7 AS ClientCustomField7, dbo.AccountParty.CustomField8 AS ClientCustomField8, dbo.AccountParty.CustomField9 AS ClientCustomField9, 
                         dbo.AccountParty.CustomField10 AS ClientCustomField10, dbo.AccountParty.CustomField11 AS ClientCustomField11, dbo.AccountParty.CustomField12 AS ClientCustomField12, 
                         dbo.AccountParty.CustomField13 AS ClientCustomField13, dbo.AccountParty.CustomField14 AS ClientCustomField14, dbo.AccountParty.CustomField15 AS ClientCustomField15, 
                         CASE WHEN ISNULL(AccountProjectTask.IsDisabled, 0) = 0 THEN 'Yes' ELSE 'No' END AS TaskEnabled, dbo.AccountProject.CustomField1 AS ProjectCustomField1, 
                         dbo.AccountProject.CustomField2 AS ProjectCustomField2, dbo.AccountProject.CustomField3 AS ProjectCustomField3, dbo.AccountProject.CustomField4 AS ProjectCustomField4, 
                         dbo.AccountProject.CustomField5 AS ProjectCustomField5, dbo.AccountProject.CustomField6 AS ProjectCustomField6, dbo.AccountProject.CustomField7 AS ProjectCustomField7, 
                         dbo.AccountProject.CustomField8 AS ProjectCustomField8, dbo.AccountProject.CustomField9 AS ProjectCustomField9, dbo.AccountProject.CustomField10 AS ProjectCustomField10, 
                         dbo.AccountProject.CustomField11 AS ProjectCustomField11, dbo.AccountProject.CustomField12 AS ProjectCustomField12, dbo.AccountProject.CustomField13 AS ProjectCustomField13, 
                         dbo.AccountProject.CustomField14 AS ProjectCustomField14, dbo.AccountProject.CustomField15 AS ProjectCustomField15, dbo.AccountTimeOffType.AccountTimeOffType, 
                         dbo.AccountCostCenter.AccountCostCenterId, ISNULL(EM.FirstName + N' ' + EM.LastName, N'') AS EmployeeManager,dbo.AccountEmployee.EmployeeManagerId, dbo.AccountEmployeeTimeEntry.CreatedOn,
						 ProjectBillingType.BillingType As ProjectBillingType
FROM            dbo.AccountEmployeeTimeEntry LEFT OUTER JOIN
                         dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId
						 LEFT OUTER JOIN
                         dbo.AccountEmployeeTimeEntryPeriod ON dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId 
						 LEFT OUTER JOIN dbo.AccountEmployee AS EM ON EM.AccountEmployeeId = dbo.AccountEmployee.EmployeeManagerId LEFT OUTER JOIN
                         dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId 
						 LEFT OUTER JOIN
                         dbo.AccountHolidayTypeDetail ON dbo.AccountEmployee.AccountHolidayTypeId = dbo.AccountHolidayTypeDetail.AccountHolidayTypeId AND 
                         dbo.AccountEmployee.AccountId = dbo.AccountHolidayTypeDetail.AccountId AND dbo.AccountEmployeeTimeEntry.TimeEntryDate = dbo.AccountHolidayTypeDetail.HolidayDate
						 LEFT OUTER JOIN dbo.AccountEmployeeType ON dbo.AccountEmployee.EmployeePayTypeId = dbo.AccountEmployeeType.AccountEmployeeTypeId
						 LEFT OUTER JOIN
                         dbo.AccountProjectTask  ON 
                         dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = AccountProjectTask.AccountProjectTaskId
						 LEFT OUTER JOIN
                         dbo.AccountProjectTask AS ParentTask ON ParentTask.AccountProjectTaskId = dbo.AccountProjectTask.ParentAccountProjectTaskId 
						 LEFT OUTER JOIN
                         dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                         dbo.AccountStatus ON dbo.AccountProject.ProjectStatusId = dbo.AccountStatus.AccountStatusId 
						 LEFT OUTER JOIN
                         dbo.AccountBillingType AS ProjectBillingType ON dbo.AccountProject.ProjectBillingTypeId = ProjectBillingType.AccountBillingTypeId LEFT OUTER JOIN
                         dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId
						 LEFT OUTER JOIN
                         dbo.AccountPartyDepartment ON dbo.AccountProject.AccountPartyDepartmentId = dbo.AccountPartyDepartment.AccountPartyDepartmentId LEFT OUTER JOIN
                         dbo.AccountPartyContact ON dbo.AccountProject.AccountPartyContactId = dbo.AccountPartyContact.AccountPartyContactId 
						 LEFT OUTER JOIN
                         dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                         dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId
						 LEFT OUTER JOIN
                         dbo.vueAccountEmployeeTimeEntryApprovalLastAction ON 
                         dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApprovalLastAction.AccountEmployeeTimeEntryId LEFT OUTER JOIN
                         dbo.AccountCostCenter ON dbo.AccountEmployeeTimeEntry.AccountCostCenterId = dbo.AccountCostCenter.AccountCostCenterId LEFT OUTER JOIN
                         dbo.AccountWorkType ON dbo.AccountEmployeeTimeEntry.AccountWorkTypeId = dbo.AccountWorkType.AccountWorkTypeId LEFT OUTER JOIN
                         dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                         dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId LEFT OUTER JOIN
                         dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId
						 
WHERE        
isnull(dbo.AccountParty.IsDeleted,0) <> 1