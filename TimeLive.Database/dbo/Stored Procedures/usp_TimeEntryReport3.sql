
CREATE PROCEDURE [dbo].[usp_TimeEntryReport3]
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

-------------------------------------------------- Third Query --------------------------------------------------------


IF EXISTS (select 1 from information_schema.tables where table_name = @TableName3 and table_type = 'BASE TABLE')
exec ('drop table ' + @TableName3)

set @SQLQuery = N'
SELECT     Mainview.EmployeeName, Mainview.ProjectName, 
                      Mainview.TaskName, Mainview.TotalTime 
                      ,Mainview.Approved, Mainview.AccountEmployeeId, 
                      Mainview.AccountProjectId, Mainview.TeamLeadApproved, 
                      Mainview.ProjectManagerApproved, 
                      Mainview.AdministratorApproved, 
                      Mainview.AccountEmployeeTimeEntryId, Mainview.StartTime, 
                      Mainview.EndTime, Mainview.TimeEntryDate ,
                      ISNULL(Mainview.Description, N'''') AS Description, 
                      Mainview.AccountId, Mainview.TotalMinutes,
                      Mainview.WeekDay, Mainview.AccountPartyId AS AccountClientId, 
                      Mainview.PartyName AS ClientName, 
                      Mainview.AccountProjectTaskId, ISNULL(Mainview.BillingType, N'''') 
                      AS BillingType, Mainview.LeaderEmployeeId, 
                      Mainview.ProjectManagerEmployeeId, 
                      Mainview.TimeSheetApprovalTypeId, 
                      Mainview.ExpenseApprovalTypeId, ISNULL(Mainview.IsBillable, 0) 
                      AS IsBillable, ISNULL(Mainview.Rejected, 0) AS Rejected, 
                      ISNULL(Mainview.BillingRate, 0) AS BillingRate, 
                      Mainview.ProjectBillingRateTypeId, 
                      ISNULL(Mainview.EmployeeCode, N'''') AS EmployeeCode, 
                      Mainview.AccountDepartmentId, Mainview.DepartmentName, 
                      ISNULL(Mainview.EstimatedCost, 0) AS EstimatedCost, 
                      ISNULL(Mainview.EstimatedTimeSpent, 0) AS EstimatedHours, 
                      ISNULL(Mainview.Submitted, 0) AS Submitted, 
                      ISNULL(Mainview.AccountWorkType, N'''') AS AccountWorkType,
                      Mainview.EMailAddress, Mainview.AccountLocation, 
                      ISNULL(Mainview.AccountCostCenter, N'''') AS AccountCostCenter, 
                      ISNULL(Mainview.AccountCostCenterCode, N'''') AS AccountCostCenterCode, 
                      ISNULL(Mainview.AccountWorkTypeCode, N'''') AS AccountWorkTypeCode, 
                      ISNULL(Mainview.ProjectCode, N'''') AS ProjectCode, 
                      ISNULL(Mainview.TaskCode, N'''') AS TaskCode, 
                      Mainview.AccountLocationId, ISNULL(Mainview.Comments, N'''') 
                      AS ApproverComments, 
                      ISNULL(Mainview.TotalMinutes * Mainview.BillingRate / 60, 0)                       AS Amount,
                       Mainview.BillingRateCurrencyId, 
                      Mainview.EmployeeRateCurrencyId,
                      ISNULL(Mainview.BillingRateExchangeRate, 0) AS BillingRateExchangeRate, 
                      ISNULL(Mainview.EmployeeRateExchangeRate, 0) AS EmployeeRateExchangeRate, 
                      Mainview.AccountBaseCurrencyId, 
                      dbo.vueAccountCurrency.CurrencyCode AS BillingRateCurrencyCode, 
                      dbo.vueAccountCurrency.CurrencyCode AS AmountCurrencyCode, 
                      Mainview.AccountTaskTypeId, 
                      Mainview.TaskStatusId, Mainview.AccountPriorityId, 
                      Mainview.AccountProjectMilestoneId, dbo.AccountTaskType.TaskType, dbo.AccountStatus.Status AS TaskStatus, 
                      dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountPriority.Priority, 
                      CONVERT(float, Mainview.TotalMinutes) / 60 AS TotalHours, 
                      ISNULL(Mainview.DepartmentCode, N'''') AS DepartmentCode ,
                      ISNULL(Mainview.PartyNick, N'''') AS ClientNick, 
                      Mainview.EstimatedCurrencyId, 
                      vueAccountCurrency_1.CurrencyCode AS EstimatedCurrencyCode, 
                      Mainview.ApprovedOn, ISNULL(Mainview.EmployeeRate, 0) 
                      AS EmployeeRate, 
                      vueAccountCurrency_2.CurrencyCode AS EmployeeRateCurrencyCode, 
                      AccountEmployee_1.FirstName + '' '' + AccountEmployee_1.LastName AS TeamLeader, 
                      AccountEmployee_2.FirstName + '' '' + AccountEmployee_2.LastName AS ProjectManager, 
                      ISNULL(dbo.AccountEmployee.FirstName + N'' '' + dbo.AccountEmployee.LastName, N'''') AS EmployeeManager, 
                      vueAccountCurrency_1.ExchangeRate AS EstimatedCurrencyExchangeRate, 
                      ISNULL(Mainview.TotalMinutes * Mainview.EmployeeRate / 60, 0) 
                      AS EmployeeCost, { fn DAYOFMONTH(Mainview.TimeEntryDate) } AS DayNo, 
                      MONTH(Mainview.TimeEntryDate) AS MonthNo, DATEPART(week, 
                      Mainview.TimeEntryDate) - DATEPART(week, DATEADD(month, DATEDIFF(month, 0, 
                      Mainview.TimeEntryDate), 0)) + 1 AS WeekNo, 
                      YEAR(Mainview.TimeEntryDate) AS Year, 
                      LEFT({ fn MONTHNAME(Mainview.TimeEntryDate) }, 3) + '' - '' + CONVERT(nvarchar(10), 
                      YEAR(Mainview.TimeEntryDate)) AS Period, 
                      { fn DAYNAME(Mainview.TimeEntryDate) } AS WeekDayName, 
                      Mainview.AccountRoleId, Mainview.Role, 
                      dbo.AccountProjectType.ProjectType, dbo.AccountRole.Role AS ProjectRole, ISNULL(Mainview.ProjectDescription, N'''') 
                      AS ProjectDescription, ISNULL(Mainview.TaskDescription, N'''') AS TaskDescription, 
                      dbo.AccountTimeExpenseBilling.InvoiceNumber, dbo.AccountTimeExpenseBilling.InvoiceDate, dbo.AccountProjectType.AccountProjectTypeId, 
                      Mainview.Billed, Mainview.AccountEmployeeTimeEntryPeriodId, 
                      ISNULL(Mainview.ClientContactName, N'''') AS ClientContactName, 
                      ISNULL(Mainview.ClientDepartmentCode, N'''') AS ClientDepartmentCode, 
                      ISNULL(Mainview.ClientDepartmentName, N'''') AS ClientDepartmentName, 
                      ISNULL(Mainview.ClientDepartmentLocation, N'''') AS ClientDepartmentLocation, 
                      Mainview.IsTimeOff, Mainview.AccountWorkTypeId, 
                      Mainview.ProjectStatus, Mainview.ParentTaskName, 
                      Mainview.FirstName, Mainview.LastName, 
                      Mainview.EmployeeType, Mainview.HolidayName, 
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
                      Mainview.ProjectApprover,Mainview.CurrentApprover, 
                      Mainview.ClientCustomField15, Mainview.ClientCustomField14, 
                      Mainview.ClientCustomField13, Mainview.ClientCustomField12, 
                      Mainview.ClientCustomField11, Mainview.ClientCustomField10, 
                      Mainview.ClientCustomField9, Mainview.ClientCustomField8, 
                      Mainview.ClientCustomField7, Mainview.ClientCustomField6, 
                      Mainview.ClientCustomField5, Mainview.ClientCustomField4, 
                      Mainview.ClientCustomField3, Mainview.ClientCustomField2, 
                      Mainview.ClientCustomField1, Mainview.EmployeeCustomField15, 
                      Mainview.EmployeeCustomField14, Mainview.EmployeeCustomField13, 
                      Mainview.EmployeeCustomField12, Mainview.EmployeeCustomField11, 
                      Mainview.EmployeeCustomField10, Mainview.EmployeeCustomField9, 
                      Mainview.EmployeeCustomField8, Mainview.EmployeeCustomField7, 
                      Mainview.EmployeeCustomField4, Mainview.EmployeeCustomField3, 
                      Mainview.EmployeeCustomField6, Mainview.EmployeeCustomField2, 
                      Mainview.EmployeeCustomField1, CONVERT(VARCHAR(10), 
                      Mainview.TimeEntryStartDate, 110) + '' '' + ''-'' + '' '' + CONVERT(VARCHAR(10), 
                      Mainview.TimeEntryEndDate, 110) AS TimeEntryPeriod, Mainview.JobTitle, Mainview.TaskEnabled, 
                      Mainview.ProjectCustomField1, Mainview.ProjectCustomField2, 
                      Mainview.ProjectCustomField3, Mainview.ProjectCustomField4, 
                      Mainview.ProjectCustomField5, Mainview.ProjectCustomField6, 
                      Mainview.ProjectCustomField7, Mainview.ProjectCustomField8, 
                      Mainview.ProjectCustomField9, Mainview.ProjectCustomField10, 
                      Mainview.ProjectCustomField11, Mainview.ProjectCustomField12, 
                      Mainview.ProjectCustomField13, Mainview.ProjectCustomField14, 
                      Mainview.ProjectCustomField15, Mainview.AccountTimeOffType, Mainview.AccountCostCenterId
into ' + @TableName3 + '
FROM       dbo.AccountRole INNER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountRole.AccountRoleId = dbo.AccountProjectEmployee.AccountRoleId RIGHT OUTER JOIN
                      dbo.AccountTimeExpenseBillingTimesheet INNER JOIN
                      dbo.AccountTimeExpenseBilling ON 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId RIGHT OUTER JOIN 
                     ' + @TableName2 + ' as
                      Mainview LEFT OUTER JOIN
                      dbo.AccountProjectType ON 
                      Mainview.AccountProjectTypeId = dbo.AccountProjectType.AccountProjectTypeId 
                      LEFT OUTER JOIN
                      dbo.AccountProjectMilestone ON Mainview.AccountProjectMilestoneId = dbo.AccountProjectMilestone.AccountProjectMilestoneId LEFT OUTER JOIN
                      dbo.AccountStatus ON Mainview.TaskStatusId = dbo.AccountStatus.AccountStatusId LEFT OUTER JOIN
                      dbo.AccountPriority ON Mainview.AccountPriorityId = dbo.AccountPriority.AccountPriorityId LEFT OUTER JOIN
                      dbo.AccountTaskType ON Mainview.AccountTaskTypeId = dbo.AccountTaskType.AccountTaskTypeId  
                     ON  dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingTimesheetId = Mainview.AccountTimeExpenseBillingTimesheetId
                       ON dbo.AccountProjectEmployee.AccountEmployeeId = Mainview.AccountEmployeeId AND 
                      dbo.AccountProjectEmployee.AccountProjectId = Mainview.AccountProjectId 
                   LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      Mainview.LeaderEmployeeId = AccountEmployee_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_2 ON 
                      Mainview.ProjectManagerEmployeeId = AccountEmployee_2.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_3 ON dbo.AccountEmployee.AccountEmployeeId = AccountEmployee_3.EmployeeManagerId ON 
                      Mainview.AccountEmployeeId = AccountEmployee_3.AccountEmployeeId 
                      LEFT OUTER JOIN
                      dbo.vueAccountCurrency AS vueAccountCurrency_2 ON 
                      Mainview.EmployeeRateCurrencyId = vueAccountCurrency_2.AccountCurrencyId LEFT OUTER JOIN
                      dbo.vueAccountCurrency AS vueAccountCurrency_1 ON 
                      Mainview.EstimatedCurrencyId = vueAccountCurrency_1.AccountCurrencyId LEFT OUTER JOIN
                      dbo.vueAccountCurrency ON Mainview.BillingRateCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId
                      Where ' + @WhereClause
EXECUTE sp_executesql @SQLQuery

SET TRANSACTION ISOLATION LEVEL READ COMMITTED