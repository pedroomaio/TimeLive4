
CREATE PROCEDURE [dbo].[usp_TimeEntryReport4]
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


DECLARE @SQLQuery AS NVARCHAR(max)
/* Build Transact-SQL String by including the parameter */

-------------------------------------------------------- Fourth Query -----------------------------------------------------------------------



IF EXISTS (select 1 from information_schema.tables where table_name = @TableName4 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName4)
set @SQLQuery = N'
SELECT     Mainview.EmployeeName, Mainview.ProjectName, 
                      Mainview.TaskName, Mainview.TotalTime, 
                      Mainview.Approved, Mainview.AccountEmployeeId, 
                      Mainview.AccountProjectId, Mainview.TeamLeadApproved, 
                      Mainview.ProjectManagerApproved, Mainview.AdministratorApproved, 
                      Mainview.AccountEmployeeTimeEntryId, Mainview.StartTime, 
                      Mainview.EndTime, Mainview.TimeEntryDate, 
                      Mainview.Description, Mainview.AccountId, 
                      Mainview.TotalMinutes, Mainview.WeekDay, 
                      Mainview.ClientName, Mainview.AccountProjectTaskId, 
                      Mainview.BillingType, Mainview.LeaderEmployeeId, 
                      Mainview.ProjectManagerEmployeeId, Mainview.TimeSheetApprovalTypeId, 
                      Mainview.ExpenseApprovalTypeId, Mainview.IsBillable, 
                      Mainview.Rejected, Mainview.BillingRate, 
                      Mainview.ProjectBillingRateTypeId, Mainview.EmployeeCode, 
                      Mainview.AccountDepartmentId, Mainview.DepartmentName, 
                      Mainview.EstimatedCost, Mainview.EstimatedHours, 
                      Mainview.Submitted, Mainview.AccountWorkType, 
                      Mainview.EMailAddress, Mainview.AccountLocation, 
                      Mainview.AccountCostCenter, Mainview.AccountCostCenterCode, 
                      Mainview.AccountWorkTypeCode, Mainview.ProjectCode, 
                      Mainview.TaskCode, Mainview.AccountLocationId, 
                      Mainview.ApproverComments, Mainview.Amount, 
                      Mainview.BillingRateCurrencyId, Mainview.EmployeeRateCurrencyId, 
                      Mainview.BillingRateExchangeRate, Mainview.EmployeeRateExchangeRate, 
                      Mainview.AccountBaseCurrencyId, Mainview.BillingRateCurrencyCode, 
                      Mainview.AmountCurrencyCode, CASE WHEN Mainview.Submitted = 1 AND 
                      Mainview.Approved = 0 THEN ''Submitted'' WHEN Mainview.Approved = 1 THEN ''Approved'' WHEN Mainview.Rejected
                       = 1 THEN ''Rejected'' WHEN Mainview.Submitted = 0 AND Mainview.Approved = 0 AND 
                      Mainview.Rejected = 0 THEN ''Not Submitted'' END AS ApprovalStatus, 
                      Mainview.AccountTaskTypeId, Mainview.TaskStatusId, 
                      Mainview.AccountPriorityId, Mainview.AccountProjectMilestoneId, 
                      Mainview.TaskType, Mainview.TaskStatus, 
                      Mainview.MilestoneDescription, Mainview.Priority, 
                      Mainview.TotalHours, Mainview.DepartmentCode, 
                      Mainview.ClientNick, Mainview.AccountClientId, 
                      Mainview.EstimatedCurrencyId, 
                      Mainview.EstimatedCurrencyCode, 
                      Mainview.ApprovedOn, Mainview.EmployeeRate, 
                      Mainview.EmployeeRateCurrencyCode, 
                     Mainview.TeamLeader, 
                      Mainview.ProjectManager, Mainview.EmployeeManager, 
                      ISNULL(Mainview.EstimatedCurrencyExchangeRate, 0) AS EstimatedCurrencyExchangeRate, 
                      Mainview.EmployeeCost, Mainview.AccountRoleId, 
                      Mainview.Role, Mainview.WeekDayName, 
                      Mainview.Period, Mainview.Year, Mainview.WeekNo, 
                      Mainview.MonthNo, Mainview.DayNo, 
                      CASE WHEN Mainview.IsBillable = 1 THEN Mainview.TotalHours ELSE 0 END AS BillableTotalHours,
                       CASE WHEN Mainview.IsBillable = 0 THEN Mainview.TotalHours WHEN Mainview.IsBillable
                       IS NULL THEN Mainview.TotalHours ELSE 0 END AS NonBillableTotalHours, 
                      CASE WHEN Mainview.EmployeeRateExchangeRate > 0 THEN Mainview.EmployeeCost / Mainview.EmployeeRateExchangeRate
                       ELSE 0 END AS CurrencyEmployeeCost, 
                      CASE WHEN Mainview.BillingRateExchangeRate > 0 THEN Mainview.Amount / Mainview.BillingRateExchangeRate
                       ELSE 0 END AS CurrencyAmount, 
                      CASE WHEN Mainview.EstimatedCurrencyExchangeRate > 0 THEN Mainview.EstimatedCost / Mainview.EstimatedCurrencyExchangeRate
                       ELSE 0 END AS CurrencyEstimatedCost, 
                      CASE WHEN Mainview.BillingRateExchangeRate > 0 THEN Mainview.BillingRate / Mainview.BillingRateExchangeRate
                       ELSE 0 END AS CurrencyBillingRate, 
                      CASE WHEN Mainview.EmployeeRateExchangeRate > 0 THEN Mainview.EmployeeRate / Mainview.EmployeeRateExchangeRate
                       ELSE 0 END AS CurrencyEmployeeRate, Mainview.ProjectRole, Mainview.ProjectType, 
                      Mainview.ProjectDescription, Mainview.TaskDescription, 
                      Mainview.InvoiceNumber, Mainview.InvoiceDate, 
                      Mainview.AccountProjectTypeId, Mainview.Billed, 
                      Mainview.ClientContactName, Mainview.ClientDepartmentCode, 
                      Mainview.ClientDepartmentName, Mainview.ClientDepartmentLocation, 
                      Mainview.IsTimeOff, Mainview.AccountWorkTypeId, 
                      CASE WHEN Mainview.IsBillable = 1 THEN Mainview.BillingRate * Mainview.TotalHours
                       ELSE 0 END AS BillableTotalAmount, 
                      CASE WHEN Mainview.IsBillable = 0 THEN Mainview.BillingRate * Mainview.TotalHours
                       ELSE 0 END AS NonBillableTotalAmount, Mainview.ProjectStatus, 
                      Mainview.ParentTaskName, Mainview.FirstName, 
                      Mainview.LastName, Mainview.EmployeeType, 
                      Mainview.HolidayName, SUM(ISNULL(dbo.vueAccountEmployeeTimeEntryWithLastStatus.Percentage, 0)) AS Percentage, 
                      Mainview.CustomField1, Mainview.CustomField2, 
                      Mainview.CustomField3, Mainview.CustomField4, 
                      Mainview.CustomField5, Mainview.CustomField6, 
                      Mainview.CustomField7, Mainview.CustomField8, 
                      Mainview.CustomField9, Mainview.CustomField10, 
                      Mainview.CustomField11, Mainview.CustomField12, 
                      Mainview.CustomField13, Mainview.CustomField14, 
                      Mainview.CustomField15, Mainview.TaskStartDate, 
                      Mainview.TaskDeadlineDate, Mainview.TaskCustomField1, 
                      Mainview.TaskCustomField2, Mainview.TaskCustomField3, 
                      Mainview.TaskCustomField4, Mainview.TaskCustomField5, 
                      Mainview.TaskCustomField6, Mainview.TaskCustomField7, 
                      Mainview.TaskCustomField8, Mainview.TaskCustomField9, 
                      Mainview.TaskCustomField10, Mainview.TaskCustomField11, 
                      Mainview.TaskCustomField12, Mainview.TaskCustomField13, 
                      Mainview.TaskCustomField14, Mainview.TaskCustomField15,
                      Mainview.ProjectApprover , Mainview.CurrentApprover, 
                      Mainview.EmployeeCustomField1, Mainview.EmployeeCustomField2, 
                      Mainview.EmployeeCustomField6, Mainview.EmployeeCustomField3, 
                      Mainview.EmployeeCustomField4, Mainview.EmployeeCustomField7, 
                      Mainview.EmployeeCustomField8, Mainview.EmployeeCustomField9, 
                      Mainview.EmployeeCustomField10, Mainview.EmployeeCustomField11, 
                      Mainview.EmployeeCustomField12, Mainview.EmployeeCustomField13, 
                      Mainview.EmployeeCustomField14, Mainview.EmployeeCustomField15, 
                      Mainview.ClientCustomField1, Mainview.ClientCustomField2, 
                      Mainview.ClientCustomField3, Mainview.ClientCustomField4, 
                      Mainview.ClientCustomField5, Mainview.ClientCustomField6, 
                      Mainview.ClientCustomField7, Mainview.ClientCustomField8, 
                      Mainview.ClientCustomField9, Mainview.ClientCustomField10, 
                      Mainview.ClientCustomField11, Mainview.ClientCustomField12, 
                      Mainview.ClientCustomField13, Mainview.ClientCustomField14, 
                      Mainview.ClientCustomField15, Mainview.TimeEntryPeriod, Mainview.JobTitle, Mainview.TaskEnabled, 
                      Mainview.ProjectCustomField1, Mainview.ProjectCustomField2, 
                      Mainview.ProjectCustomField3, Mainview.ProjectCustomField4, 
                      Mainview.ProjectCustomField5, Mainview.ProjectCustomField6, 
                      Mainview.ProjectCustomField7, Mainview.ProjectCustomField8, 
                      Mainview.ProjectCustomField9, Mainview.ProjectCustomField10, 
                      Mainview.ProjectCustomField11, Mainview.ProjectCustomField12, 
                      Mainview.ProjectCustomField13, Mainview.ProjectCustomField14, 
                      Mainview.ProjectCustomField15, Mainview.AccountTimeOffType, Mainview.AccountCostCenterId
                      into ' + @TableName4 + '
FROM         ' + @TableName3 + ' as Mainview INNER JOIN
                      dbo.vueAccountEmployeeTimeEntryWithLastStatus ON 
                      Mainview.AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryWithLastStatus.AccountEmployeeTimeEntryId
                      WHERE ' + @WhereClause + ' 
GROUP BY Mainview.EmployeeName, Mainview.ProjectName, 
                      Mainview.TaskName, Mainview.TotalTime, 
                      Mainview.AccountEmployeeId, Mainview.AccountProjectId, 
                      Mainview.AccountEmployeeTimeEntryId, Mainview.StartTime, 
                      Mainview.EndTime, Mainview.TimeEntryDate, 
                      Mainview.Description, Mainview.AccountId, 
                      Mainview.TotalMinutes, Mainview.WeekDay, 
                      Mainview.ClientName, Mainview.AccountProjectTaskId, 
                      Mainview.BillingType, Mainview.LeaderEmployeeId, 
                      Mainview.ProjectManagerEmployeeId, Mainview.TimeSheetApprovalTypeId, 
                      Mainview.ExpenseApprovalTypeId, Mainview.BillingRate, 
                      Mainview.ProjectBillingRateTypeId, Mainview.EmployeeCode, 
                      Mainview.AccountDepartmentId, Mainview.DepartmentName, 
                      Mainview.EstimatedCost, Mainview.EstimatedHours, 
                      Mainview.AccountWorkType, Mainview.EMailAddress, 
                      Mainview.AccountLocation, Mainview.AccountCostCenter, 
                      Mainview.AccountCostCenterCode, Mainview.AccountWorkTypeCode, 
                      Mainview.ProjectCode, Mainview.TaskCode, 
                      Mainview.AccountLocationId, Mainview.ApproverComments, 
                      Mainview.Amount, Mainview.BillingRateCurrencyId, 
                      Mainview.EmployeeRateCurrencyId, Mainview.BillingRateExchangeRate, 
                      Mainview.EmployeeRateExchangeRate, Mainview.AccountBaseCurrencyId, 
                      Mainview.BillingRateCurrencyCode, Mainview.AmountCurrencyCode, 
                      Mainview.AccountTaskTypeId, Mainview.TaskStatusId, 
                      Mainview.AccountPriorityId, Mainview.AccountProjectMilestoneId, 
                      Mainview.TaskType, Mainview.TaskStatus, 
                      Mainview.MilestoneDescription, Mainview.Priority, 
                      Mainview.TotalHours, Mainview.DepartmentCode, 
                      Mainview.ClientNick, Mainview.AccountClientId, 
                      Mainview.EstimatedCurrencyId, 
                      Mainview.EstimatedCurrencyCode, 
                      Mainview.ApprovedOn, Mainview.EmployeeRate, 
                      Mainview.EmployeeRateCurrencyCode, 
                      Mainview.TeamLeader, 
                      Mainview.ProjectManager, Mainview.EmployeeManager, 
                      ISNULL(Mainview.EstimatedCurrencyExchangeRate, 0), 
                     Mainview.EmployeeCost, 
                      Mainview.AccountRoleId, Mainview.Role, 
                      Mainview.WeekDayName, Mainview.Period, 
                      Mainview.Year, Mainview.WeekNo, Mainview.MonthNo, 
                      Mainview.DayNo, Mainview.ProjectRole, 
                      Mainview.ProjectType, Mainview.ProjectDescription, 
                      Mainview.TaskDescription, Mainview.InvoiceNumber, 
                      Mainview.InvoiceDate, Mainview.AccountProjectTypeId, 
                      Mainview.ClientContactName, Mainview.ClientDepartmentCode, 
                      Mainview.ClientDepartmentName, Mainview.ClientDepartmentLocation, 
                      Mainview.AccountWorkTypeId, Mainview.ProjectStatus, 
                      Mainview.ParentTaskName, Mainview.FirstName, 
                      Mainview.LastName, Mainview.EmployeeType, 
                      Mainview.Approved, Mainview.TeamLeadApproved, 
                      Mainview.ProjectManagerApproved, Mainview.AdministratorApproved, 
                      Mainview.IsBillable, Mainview.Rejected, 
                      Mainview.Submitted, Mainview.Billed, 
                      Mainview.IsTimeOff, 
                      CASE WHEN Mainview.IsBillable = 0 THEN Mainview.BillingRate * Mainview.TotalHours
                       ELSE 0 END, 
                      CASE WHEN Mainview.IsBillable = 1 THEN Mainview.BillingRate * Mainview.TotalHours
                       ELSE 0 END, 
                      CASE WHEN Mainview.EmployeeRateExchangeRate > 0 THEN Mainview.EmployeeRate / Mainview.EmployeeRateExchangeRate
                       ELSE 0 END, 
                      CASE WHEN Mainview.BillingRateExchangeRate > 0 THEN Mainview.BillingRate / Mainview.BillingRateExchangeRate
                       ELSE 0 END, 
                      CASE WHEN Mainview.EstimatedCurrencyExchangeRate > 0 THEN Mainview.EstimatedCost / Mainview.EstimatedCurrencyExchangeRate
                       ELSE 0 END, 
                      CASE WHEN Mainview.BillingRateExchangeRate > 0 THEN Mainview.Amount / Mainview.BillingRateExchangeRate
                       ELSE 0 END, 
                      CASE WHEN Mainview.EmployeeRateExchangeRate > 0 THEN Mainview.EmployeeCost / Mainview.EmployeeRateExchangeRate
                       ELSE 0 END, 
                      CASE WHEN Mainview.IsBillable = 0 THEN Mainview.TotalHours WHEN Mainview.IsBillable
                       IS NULL THEN Mainview.TotalHours ELSE 0 END, 
                      CASE WHEN Mainview.IsBillable = 1 THEN Mainview.TotalHours ELSE 0 END, 
                      CASE WHEN Mainview.Submitted = 1 AND 
                      Mainview.Approved = 0 THEN ''Submitted'' WHEN Mainview.Approved = 1 THEN ''Approved'' WHEN Mainview.Rejected
                       = 1 THEN ''Rejected'' WHEN Mainview.Submitted = 0 AND Mainview.Approved = 0 AND 
                      Mainview.Rejected = 0 THEN ''Not Submitted'' END, Mainview.HolidayName, 
                      Mainview.CustomField1, Mainview.CustomField2, 
                      Mainview.CustomField3, Mainview.CustomField4, 
                      Mainview.CustomField5, Mainview.CustomField6, 
                      Mainview.CustomField7, Mainview.CustomField8, 
                      Mainview.CustomField9, Mainview.CustomField10, 
                      Mainview.CustomField11, Mainview.CustomField12, 
                      Mainview.CustomField13, Mainview.CustomField14, 
                      Mainview.CustomField15, Mainview.TaskStartDate, 
                      Mainview.TaskDeadlineDate, Mainview.TaskCustomField1, 
                      Mainview.TaskCustomField2, Mainview.TaskCustomField3, 
                      Mainview.TaskCustomField4, Mainview.TaskCustomField5, 
                      Mainview.TaskCustomField6, Mainview.TaskCustomField7, 
                      Mainview.TaskCustomField8, Mainview.TaskCustomField9, 
                      Mainview.TaskCustomField10, Mainview.TaskCustomField11, 
                      Mainview.TaskCustomField12, Mainview.TaskCustomField13, 
                      Mainview.TaskCustomField14, Mainview.TaskCustomField15,
                      Mainview.ProjectApprover , Mainview.CurrentApprover, 
                      Mainview.EmployeeCustomField1, Mainview.EmployeeCustomField2, 
                      Mainview.EmployeeCustomField6, Mainview.EmployeeCustomField3, 
                      Mainview.EmployeeCustomField4, Mainview.EmployeeCustomField7, 
                      Mainview.EmployeeCustomField8, Mainview.EmployeeCustomField9, 
                      Mainview.EmployeeCustomField10, Mainview.EmployeeCustomField11, 
                      Mainview.EmployeeCustomField12, Mainview.EmployeeCustomField13, 
                      Mainview.EmployeeCustomField14, Mainview.EmployeeCustomField15, 
                      Mainview.ClientCustomField1, Mainview.ClientCustomField2, 
                      Mainview.ClientCustomField3, Mainview.ClientCustomField4, 
                      Mainview.ClientCustomField5, Mainview.ClientCustomField6, 
                      Mainview.ClientCustomField7, Mainview.ClientCustomField8, 
                      Mainview.ClientCustomField9, Mainview.ClientCustomField10, 
                      Mainview.ClientCustomField11, Mainview.ClientCustomField12, 
                      Mainview.ClientCustomField13, Mainview.ClientCustomField14, 
                      Mainview.ClientCustomField15, Mainview.TimeEntryPeriod, Mainview.JobTitle, Mainview.TaskEnabled, 
                      Mainview.ProjectCustomField1, Mainview.ProjectCustomField2, 
                      Mainview.ProjectCustomField3, Mainview.ProjectCustomField4, 
                      Mainview.ProjectCustomField5, Mainview.ProjectCustomField6, 
                      Mainview.ProjectCustomField7, Mainview.ProjectCustomField8, 
                      Mainview.ProjectCustomField9, Mainview.ProjectCustomField10, 
                      Mainview.ProjectCustomField11, Mainview.ProjectCustomField12, 
                      Mainview.ProjectCustomField13, Mainview.ProjectCustomField14, 
                      Mainview.ProjectCustomField15, Mainview.AccountTimeOffType, Mainview.AccountCostCenterId'
                      
EXECUTE sp_executesql @SQLQuery

--------------------------------- FINALLY ------------------------------------

IF EXISTS (select 1 from information_schema.tables where table_name = @TableName1 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName1)
IF EXISTS (select 1 from information_schema.tables where table_name = @TableName2 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName2)
IF EXISTS (select 1 from information_schema.tables where table_name = @TableName3 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName3)
--IF EXISTS (select 1 from information_schema.tables where table_name = @TableName4 and table_type = 'BASE TABLE')
--exec ('drop table ' + @TableName4)
SET TRANSACTION ISOLATION LEVEL READ COMMITTED