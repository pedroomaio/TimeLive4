
CREATE VIEW dbo.rptvueAccountProjectTasks
AS
SELECT     AccountProjectTaskId, AccountProjectId, ParentAccountProjectTaskId, TaskName, TaskDescription, AccountTaskTypeId, DeadlineDate, CompletedPercent, Completed, 
                      IsParentTask, IsForAllEmployees, AccountPriorityId, TaskStatusId, CreatedOn, CreatedByEmployeeId, ModifiedOn, ModifiedByEmployeeId, TaskStatus, 
                      CreatedByFirstName, CreatedByLastName, Priority, ProjectName, ProjectCode, TaskType, AccountId, AccountProjectMilestoneId, MilestoneDescription, IsReOpen, 
                      ModifiedByFirstName, ModifiedByLastName, ISNULL(EstimatedCost, 0) AS EstimatedCost, EstimatedHours, EstimatedTimeSpentUnit, AccountEmployeeId, IsDisabled, 
                      TaskCode, IsTemplate, IsForAllProjectTask, IsBillable, AccountClientId, ClientNick, ClientName, Duration, ParentTaskName, EstimatedCurrencyId, 
                      EstimatedCurrencyCode, BillableTotalHours, NonBillableTotalHours, TotalHours, CurrencyEmployeeCost, EstimatedCurrencyExchangeRate, 
                      CASE WHEN dbo.vueAccountProjectTaskOnlyForReport.EstimatedCurrencyExchangeRate > 0 THEN dbo.vueAccountProjectTaskOnlyForReport.EstimatedCost / dbo.vueAccountProjectTaskOnlyForReport.EstimatedCurrencyExchangeRate
                       ELSE 0 END AS CurrencyEstimatedCost, CurrencyAmount, ProjectDescription, MilestoneDate, StartDate, CustomField1, CustomField2, CustomField3, CustomField4, 
                      CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, 
                      CustomField15
FROM         dbo.vueAccountProjectTaskOnlyForReport