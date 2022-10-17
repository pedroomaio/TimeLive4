
CREATE PROCEDURE [dbo].[usp_TimeEntryReport2]
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

--------------------------------------------------------- SECOND QUERY ------------------------------------------------------------

IF EXISTS (select 1 from information_schema.tables where table_name = @TableName2 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName2)
DECLARE @SQLQuery AS NVARCHAR(max)
set @SQLQuery = N'
select  Mainview.EmployeeName, Mainview.ProjectName, Mainview.TaskName, Mainview.TotalTime, Mainview.Approved, Mainview.AccountEmployeeId, Mainview.AccountProjectId, Mainview.TeamLeadApproved, Mainview.ProjectManagerApproved, 
                      Mainview.AdministratorApproved, Mainview.AccountEmployeeTimeEntryId, Mainview.StartTime, Mainview.EndTime, Mainview.TimeEntryDate, Mainview.AccountId, Mainview.TotalMinutes, Mainview.WeekDay, Mainview.AccountProjectTaskId, 
                      Mainview.LeaderEmployeeId, Mainview.ProjectManagerEmployeeId, Mainview.TimeSheetApprovalTypeId, Mainview.ExpenseApprovalTypeId, Mainview.IsBillable, Mainview.Rejected, Mainview.BillingRate, 
                      Mainview.ProjectBillingRateTypeId, Mainview.EmployeeCode, Mainview.AccountDepartmentId, Mainview.EstimatedCost, Mainview.EstimatedTimeSpent, Mainview.Submitted, Mainview.EMailAddress, Mainview.ProjectCode, 
                      Mainview.TaskCode, Mainview.BillingRateCurrencyId, Mainview.EmployeeRateCurrencyId, Mainview.BillingRateExchangeRate, Mainview.EmployeeRateExchangeRate, Mainview.AccountBaseCurrencyId, 
                      Mainview.AccountTaskTypeId, Mainview.TaskStatusId, Mainview.AccountPriorityId, Mainview.AccountProjectMilestoneId, Mainview.EstimatedCurrencyId, Mainview.EmployeeRate, Mainview.AccountProjectTypeId, 
                      Mainview.AccountTimeExpenseBillingTimesheetId, Mainview.Billed, Mainview.AccountEmployeeTimeEntryApprovalProjectId, Mainview.AccountEmployeeTimeEntryPeriodId, Mainview.SubmittedHours, 
                      Mainview.ApprovedHours, Mainview.RejectedHours, Mainview.TimeEntryStartDate, Mainview.TimeEntryEndDate, Mainview.TimeEntryViewType, Mainview.IsTimeOff, Mainview.AccountTimeOffTypeId, Mainview.TimeOffHours, 
                      Mainview.TimesheetHours, Mainview.ParentAccountProjectTaskId, Mainview.IsDisabled, Mainview.FirstName, Mainview.LastName, Mainview.Percentage, Mainview.CustomField1, Mainview.CustomField2, Mainview.CustomField3, 
                      Mainview.CustomField4, Mainview.CustomField5, Mainview.CustomField6, Mainview.CustomField7, Mainview.CustomField8, Mainview.CustomField9, Mainview.CustomField10, Mainview.CustomField11, Mainview.CustomField12, 
                      Mainview.CustomField13, Mainview.CustomField14, Mainview.CustomField15, Mainview.TaskStartDate, Mainview.TaskDeadlineDate, Mainview.BillableHours, Mainview.JobTitle, Mainview.ProjectApprover, Mainview.CurrentApprover, 
                      Mainview.TaskEnabled, Mainview.AccountTimeOffType, Mainview.EmployeeManagerID, Mainview.ProjectStatusId, Mainview.AccountHolidayTypeId, Mainview.EmployeePayTypeId, Mainview.AccountPartyDepartmentId, 
                      Mainview.AccountPartyContactId, Mainview.AccountLocationId, Mainview.AccountRoleId, Mainview.AccountCostCenterId, Mainview.AccountWorkTypeId, Mainview.BillingTypeId, Mainview.AccountClientId, 
                      Mainview.ProjectCustomField1, Mainview.ProjectCustomField2, Mainview.ProjectCustomField3, Mainview.ProjectCustomField4, Mainview.ProjectCustomField5, Mainview.ProjectCustomField6, 
                      Mainview.ProjectCustomField7, Mainview.ProjectCustomField8, Mainview.ProjectCustomField9, Mainview.ProjectCustomField10, Mainview.ProjectCustomField11, Mainview.ProjectCustomField12, 
                      Mainview.ProjectCustomField13, Mainview.ProjectCustomField14, Mainview.ProjectCustomField15, Mainview.ProjectDescription, Mainview.TaskDescription, Mainview.Description,
                        dbo.AccountParty.AccountPartyId, dbo.AccountParty.PartyName, 
                       dbo.AccountBillingType.BillingType, dbo.AccountDepartment.DepartmentName, dbo.AccountWorkType.AccountWorkType, 
                       dbo.AccountLocation.AccountLocation, dbo.AccountCostCenter.AccountCostCenter, dbo.AccountCostCenter.AccountCostCenterCode, 
                      dbo.AccountWorkType.AccountWorkTypeCode, dbo.vueAccountEmployeeTimeEntryApprovalLastAction.Comments, 
                      dbo.AccountDepartment.DepartmentCode, 
                      dbo.AccountParty.PartyNick, dbo.vueAccountEmployeeTimeEntryApprovalLastAction.ApprovedOn, 
                      dbo.AccountRole.Role, 
                      dbo.AccountPartyContact.FirstName + N'' '' + dbo.AccountPartyContact.LastName AS ClientContactName, 
                      dbo.AccountPartyDepartment.PartyDepartmentCode AS ClientDepartmentCode, 
                      dbo.AccountPartyDepartment.PartyDepartmentName AS ClientDepartmentName, 
                      dbo.AccountPartyDepartment.PartyDepartmentLocation AS ClientDepartmentLocation, 
                      dbo.AccountStatus.Status AS ProjectStatus, 
                      dbo.AccountProjectTask.TaskName AS ParentTaskName, ISNULL(dbo.AccountEmployeeType.AccountEmployeeType, N'''') AS EmployeeType, 
                      ISNULL(dbo.AccountHolidayTypeDetail.HolidayName, N'''') AS HolidayName, 
                      dbo.AccountParty.IsDeleted, 
                       Mainview.EmployeeCustomField1, 
                      Mainview.EmployeeCustomField2, Mainview.EmployeeCustomField3, 
                      Mainview.EmployeeCustomField4, Mainview.EmployeeCustomField5, 
                      Mainview.EmployeeCustomField6, Mainview.EmployeeCustomField7, 
                      Mainview.EmployeeCustomField8, Mainview.EmployeeCustomField9, 
                      Mainview.EmployeeCustomField10, Mainview.EmployeeCustomField11, 
                      Mainview.EmployeeCustomField12, Mainview.EmployeeCustomField13, 
                      Mainview.EmployeeCustomField14, Mainview.EmployeeCustomField15, 
                      dbo.AccountParty.CustomField1 AS ClientCustomField1, dbo.AccountParty.CustomField2 AS ClientCustomField2, 
                      dbo.AccountParty.CustomField3 AS ClientCustomField3, dbo.AccountParty.CustomField4 AS ClientCustomField4, 
                      dbo.AccountParty.CustomField5 AS ClientCustomField5, dbo.AccountParty.CustomField6 AS ClientCustomField6, 
                      dbo.AccountParty.CustomField7 AS ClientCustomField7, dbo.AccountParty.CustomField8 AS ClientCustomField8, 
                      dbo.AccountParty.CustomField9 AS ClientCustomField9, dbo.AccountParty.CustomField10 AS ClientCustomField10, 
                      dbo.AccountParty.CustomField11 AS ClientCustomField11, dbo.AccountParty.CustomField12 AS ClientCustomField12, 
                      dbo.AccountParty.CustomField13 AS ClientCustomField13, dbo.AccountParty.CustomField14 AS ClientCustomField14, 
                      dbo.AccountParty.CustomField15 AS ClientCustomField15, Mainview.TaskCustomField1, 
                      Mainview.TaskCustomField2, Mainview.TaskCustomField3, 
                      Mainview.TaskCustomField4, Mainview.TaskCustomField5, 
                      Mainview.TaskCustomField6, Mainview.TaskCustomField7, 
                      Mainview.TaskCustomField8, Mainview.TaskCustomField9, 
                      Mainview.TaskCustomField10, Mainview.TaskCustomField11, 
                      Mainview.TaskCustomField12, Mainview.TaskCustomField13, 
                      Mainview.TaskCustomField14, Mainview.TaskCustomField15
into ' + @TableName2 + '
 from ' + @TableName1 + ' Mainview
left outer join         
dbo.AccountEmployee ON dbo.AccountEmployee.AccountEmployeeId = Mainview.EmployeeManagerId
LEFT OUTER JOIN
                      dbo.AccountHolidayTypeDetail ON Mainview.AccountHolidayTypeId = dbo.AccountHolidayTypeDetail.AccountHolidayTypeId AND 
                      Mainview.AccountId = dbo.AccountHolidayTypeDetail.AccountId AND 
                      Mainview.TimeEntryDate = dbo.AccountHolidayTypeDetail.HolidayDate 
                      LEFT OUTER JOIN
                      dbo.AccountEmployeeType ON Mainview.EmployeePayTypeId = dbo.AccountEmployeeType.AccountEmployeeTypeId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountProjectTask.AccountProjectTaskId = MainView.ParentAccountProjectTaskId
                      LEFT OUTER JOIN
                      dbo.AccountStatus ON Mainview.ProjectStatusId = dbo.AccountStatus.AccountStatusId LEFT OUTER JOIN
                      dbo.AccountPartyDepartment ON 
                      Mainview.AccountPartyDepartmentId = dbo.AccountPartyDepartment.AccountPartyDepartmentId LEFT OUTER JOIN
                      dbo.AccountPartyContact ON Mainview.AccountPartyContactId = dbo.AccountPartyContact.AccountPartyContactId LEFT OUTER JOIN
                      dbo.AccountLocation ON Mainview.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountRole ON Mainview.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction ON 
                      Mainview.AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApprovalLastAction.AccountEmployeeTimeEntryId LEFT
                       OUTER JOIN
                      dbo.AccountCostCenter ON Mainview.AccountCostCenterId = dbo.AccountCostCenter.AccountCostCenterId LEFT OUTER JOIN
                      dbo.AccountWorkType ON Mainview.AccountWorkTypeId = dbo.AccountWorkType.AccountWorkTypeId LEFT OUTER JOIN
                      dbo.AccountDepartment ON Mainview.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountBillingType ON Mainview.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId LEFT OUTER JOIN
                      dbo.AccountParty ON Mainview.AccountClientId = dbo.AccountParty.AccountPartyId
WHERE  ' + @WhereClause + ' and isnull(dbo.AccountParty.IsDeleted,0) = 0'
EXECUTE sp_executesql @SQLQuery
SET TRANSACTION ISOLATION LEVEL READ COMMITTED