
CREATE PROCEDURE [dbo].[usp_TimeEntryReport1]
    (
@AccountEmployeeId integer,
@WhereClause nvarchar(max)
	)
AS
   SET NOCOUNT ON
   SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
    SET ARITHABORT ON
declare @TableName1 nvarchar(500),@TableName2 nvarchar(500),@TableName3 nvarchar(500),@TableName4 nvarchar(500)

set @TableName1 = 'TimeEntryReport_' + convert(varchar(200),@AccountEmployeeId) + '_1'
set @TableName2 = 'TimeEntryReport_' + convert(varchar(200),@AccountEmployeeId) + '_2'
set @TableName3 = 'TimeEntryReport_' + convert(varchar(200),@AccountEmployeeId) + '_3'
set @TableName4 = 'TimeEntryReport_' + convert(varchar(200),@AccountEmployeeId) + '_4'

IF EXISTS (select 1 from information_schema.tables where table_name = @TableName1 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName1)

DECLARE @SQLQuery AS NVARCHAR(max)
/* Build Transact-SQL String by including the parameter */
SET @SQLQuery = N'Select * into ' + @TableName1 + ' from (SELECT     CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + '' '' + dbo.AccountEmployee.FirstName + '' '' + ''(Disabled)'' WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 2 AND 
                      dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + '' '' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy
                       = 1 AND 
                      dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName + '' '' + ''(Disabled)'' ELSE dbo.AccountEmployee.FirstName
                       + '' '' + dbo.AccountEmployee.LastName END AS EmployeeName, 
                      CASE WHEN dbo.AccountProject.IsDisabled = 1 THEN dbo.AccountProject.ProjectName + '' '' + ''(Disabled)'' ELSE dbo.AccountProject.ProjectName END AS
                       ProjectName, 
                      CASE WHEN dbo.AccountEmployeeTimeEntry.IsTimeOff <> 1 THEN AccountProjectTask_1.TaskName ELSE dbo.AccountTimeOffType.AccountTimeOffType
                       END AS TaskName, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.Approved, dbo.AccountEmployee.AccountEmployeeId, 
                      dbo.AccountProject.AccountProjectId, dbo.AccountEmployeeTimeEntry.TeamLeadApproved, dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.AccountEmployeeTimeEntry.AdministratorApproved, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      ISNULL(dbo.AccountProject.AccountId, dbo.AccountTimeOffType.AccountId) AS AccountId, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, DATEPART(dw, dbo.AccountEmployeeTimeEntry.TimeEntryDate) 
                      AS WeekDay, AccountProjectTask_1.AccountProjectTaskId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, AccountProjectTask_1.IsBillable, 
                      dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, dbo.AccountProject.ProjectBillingRateTypeId, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.AccountDepartmentId, AccountProjectTask_1.EstimatedCost, 
                      AccountProjectTask_1.EstimatedTimeSpent, dbo.AccountEmployeeTimeEntry.Submitted, dbo.AccountEmployee.EMailAddress, 
                      CASE WHEN ISNULL(dbo.AccountProject.ProjectPrefix, '''') 
                      = '''' THEN dbo.AccountProject.ProjectCode ELSE dbo.AccountProject.ProjectPrefix + ''-'' + dbo.AccountProject.ProjectCode END AS ProjectCode, 
                      AccountProjectTask_1.TaskCode, dbo.AccountEmployeeTimeEntry.BillingRateCurrencyId, dbo.AccountEmployeeTimeEntry.EmployeeRateCurrencyId, 
                      dbo.AccountEmployeeTimeEntry.BillingRateExchangeRate, dbo.AccountEmployeeTimeEntry.EmployeeRateExchangeRate, 
                      dbo.AccountEmployeeTimeEntry.AccountBaseCurrencyId, AccountProjectTask_1.AccountTaskTypeId, AccountProjectTask_1.TaskStatusId, 
                      AccountProjectTask_1.AccountPriorityId, AccountProjectTask_1.AccountProjectMilestoneId, AccountProjectTask_1.EstimatedCurrencyId, 
                      dbo.AccountEmployeeTimeEntry.EmployeeRate, dbo.AccountProject.AccountProjectTypeId, 
                      dbo.AccountEmployeeTimeEntry.AccountTimeExpenseBillingTimesheetId, dbo.AccountEmployeeTimeEntry.Billed, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId, 
                      CASE WHEN dbo.AccountEmployeeTimeEntry.Submitted = 1 THEN (CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) END AS SubmittedHours, 
                      CASE WHEN dbo.AccountEmployeeTimeEntry.Approved = 1 THEN (CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) END AS ApprovedHours, 
                      CASE WHEN dbo.AccountEmployeeTimeEntry.Rejected = 1 THEN (CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) END AS RejectedHours, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, 
                      dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, dbo.AccountEmployeeTimeEntry.IsTimeOff, 
                      dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId, CASE WHEN dbo.AccountEmployeeTimeEntry.IsTimeOff <> 0 THEN (CONVERT(float, 
                      DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) END AS TimeOffHours,
                       CASE WHEN dbo.AccountEmployeeTimeEntry.IsTimeOff <> 1 THEN (CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) END AS TimesheetHours, AccountProjectTask_1.ParentAccountProjectTaskId, 
                      dbo.AccountEmployee.IsDisabled, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployeeTimeEntry.Percentage, 
                      dbo.AccountEmployeeTimeEntry.CustomField1, dbo.AccountEmployeeTimeEntry.CustomField2, dbo.AccountEmployeeTimeEntry.CustomField3, 
                      dbo.AccountEmployeeTimeEntry.CustomField4, dbo.AccountEmployeeTimeEntry.CustomField5, dbo.AccountEmployeeTimeEntry.CustomField6, 
                      dbo.AccountEmployeeTimeEntry.CustomField7, dbo.AccountEmployeeTimeEntry.CustomField8, dbo.AccountEmployeeTimeEntry.CustomField9, 
                      dbo.AccountEmployeeTimeEntry.CustomField10, dbo.AccountEmployeeTimeEntry.CustomField11, dbo.AccountEmployeeTimeEntry.CustomField12, 
                      dbo.AccountEmployeeTimeEntry.CustomField13, dbo.AccountEmployeeTimeEntry.CustomField14, dbo.AccountEmployeeTimeEntry.CustomField15, 
                      AccountProjectTask_1.StartDate AS TaskStartDate, AccountProjectTask_1.DeadlineDate AS TaskDeadlineDate, 
                      CASE WHEN AccountProjectTask_1.IsBillable = 1 THEN (CONVERT(float, DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n,
                       dbo.AccountEmployeeTimeEntry.TotalTime)) / 60) ELSE 0 END AS BillableHours, dbo.AccountEmployee.JobTitle, 
					    dbo.CombineValuesForTimeEntryApprover(dbo.accountproject.AccountProjectId) as ProjectApprover,
                      dbo.CombineValuesForTimeEntryCurrentApprover(dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId) as CurrentApprover, 
					  CASE WHEN ISNULL(AccountProjectTask_1.IsDisabled, 0) = 0 THEN ''Yes'' ELSE ''No'' END AS TaskEnabled, 
                      dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountEmployee.EmployeeManagerID, dbo.AccountProject.ProjectStatusId,
                      dbo.AccountEmployee.AccountHolidayTypeId, dbo.AccountEmployee.EmployeePayTypeId, dbo.AccountProject.AccountPartyDepartmentId,
                      dbo.AccountProject.AccountPartyContactId,dbo.AccountEmployee.AccountLocationId,dbo.AccountEmployee.AccountRoleId,
                      dbo.AccountEmployeeTimeEntry.AccountCostCenterId,dbo.AccountEmployeeTimeEntry.AccountWorkTypeId,
                      dbo.AccountEmployee.BillingTypeId,dbo.AccountProject.AccountClientId
                      ,                       dbo.AccountProject.CustomField1 AS ProjectCustomField1, 
                      dbo.AccountProject.CustomField2 AS ProjectCustomField2, dbo.AccountProject.CustomField3 AS ProjectCustomField3, 
                      dbo.AccountProject.CustomField4 AS ProjectCustomField4, dbo.AccountProject.CustomField5 AS ProjectCustomField5, 
                      dbo.AccountProject.CustomField6 AS ProjectCustomField6, dbo.AccountProject.CustomField7 AS ProjectCustomField7, 
                      dbo.AccountProject.CustomField8 AS ProjectCustomField8, dbo.AccountProject.CustomField9 AS ProjectCustomField9, 
                      dbo.AccountProject.CustomField10 AS ProjectCustomField10, dbo.AccountProject.CustomField11 AS ProjectCustomField11, 
                      dbo.AccountProject.CustomField12 AS ProjectCustomField12, dbo.AccountProject.CustomField13 AS ProjectCustomField13, 
                      dbo.AccountProject.CustomField14 AS ProjectCustomField14, dbo.AccountProject.CustomField15 AS ProjectCustomField15
                      ,dbo.AccountProject.ProjectDescription, AccountProjectTask_1.TaskDescription, dbo.AccountEmployeeTimeEntry.Description,
                      AccountProjectTask_1.CustomField1 AS TaskCustomField1, 
                      AccountProjectTask_1.CustomField2 AS TaskCustomField2, AccountProjectTask_1.CustomField3 AS TaskCustomField3, 
                      AccountProjectTask_1.CustomField4 AS TaskCustomField4, AccountProjectTask_1.CustomField5 AS TaskCustomField5, 
                      AccountProjectTask_1.CustomField6 AS TaskCustomField6, AccountProjectTask_1.CustomField7 AS TaskCustomField7, 
                      AccountProjectTask_1.CustomField8 AS TaskCustomField8, AccountProjectTask_1.CustomField9 AS TaskCustomField9, 
                      AccountProjectTask_1.CustomField10 AS TaskCustomField10, AccountProjectTask_1.CustomField11 AS TaskCustomField11, 
                      AccountProjectTask_1.CustomField12 AS TaskCustomField12, AccountProjectTask_1.CustomField13 AS TaskCustomField13, 
                      AccountProjectTask_1.CustomField14 AS TaskCustomField14, AccountProjectTask_1.CustomField15 AS TaskCustomField15,
                      dbo.AccountEmployee.CustomField1 AS EmployeeCustomField1, 
                      dbo.AccountEmployee.CustomField2 AS EmployeeCustomField2, dbo.AccountEmployee.CustomField3 AS EmployeeCustomField3, 
                      dbo.AccountEmployee.CustomField4 AS EmployeeCustomField4, dbo.AccountEmployee.CustomField5 AS EmployeeCustomField5, 
                      dbo.AccountEmployee.CustomField6 AS EmployeeCustomField6, dbo.AccountEmployee.CustomField7 AS EmployeeCustomField7, 
                      dbo.AccountEmployee.CustomField8 AS EmployeeCustomField8, dbo.AccountEmployee.CustomField9 AS EmployeeCustomField9, 
                      dbo.AccountEmployee.CustomField10 AS EmployeeCustomField10, dbo.AccountEmployee.CustomField11 AS EmployeeCustomField11, 
                      dbo.AccountEmployee.CustomField12 AS EmployeeCustomField12, dbo.AccountEmployee.CustomField13 AS EmployeeCustomField13, 
                      dbo.AccountEmployee.CustomField14 AS EmployeeCustomField14, dbo.AccountEmployee.CustomField15 AS EmployeeCustomField15
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountProjectTask AS AccountProjectTask_1 ON 
                      dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = AccountProjectTask_1.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountTimeOffType ON 
                      dbo.AccountEmployeeTimeEntry.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryPeriod ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId)
                      MainView
                      WHERE  ' + @WhereClause
/* Execute Transact-SQL String */
EXECUTE sp_executesql @SQLQuery

SET TRANSACTION ISOLATION LEVEL READ COMMITTED