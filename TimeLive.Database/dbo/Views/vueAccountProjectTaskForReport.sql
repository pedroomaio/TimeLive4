
CREATE VIEW dbo.vueAccountProjectTaskForReport
AS
SELECT     dbo.vueAccountProjectTask.AccountProjectTaskId, dbo.vueAccountProjectTask.AccountProjectId, dbo.vueAccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.vueAccountProjectTask.TaskName, dbo.vueAccountProjectTask.TaskDescription, dbo.vueAccountProjectTask.AccountTaskTypeId, 
                      dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, dbo.vueAccountProjectTask.Completed, 
                      dbo.vueAccountProjectTask.IsParentTask, dbo.vueAccountProjectTask.IsForAllEmployees, dbo.vueAccountProjectTask.AccountPriorityId, 
                      dbo.vueAccountProjectTask.TaskStatusId, dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.CreatedByEmployeeId, 
                      dbo.vueAccountProjectTask.ModifiedOn, dbo.vueAccountProjectTask.ModifiedByEmployeeId, dbo.vueAccountProjectTask.TaskStatus, 
                      dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, dbo.vueAccountProjectTask.Priority, 
                      dbo.vueAccountProjectTask.ProjectName, dbo.vueAccountProjectTask.ProjectCode, dbo.vueAccountProjectTask.TaskType, dbo.vueAccountProjectTask.AccountId, 
                      dbo.vueAccountProjectTask.AccountProjectMilestoneId, dbo.vueAccountProjectTask.MilestoneDescription, dbo.vueAccountProjectTask.IsReOpen, 
                      dbo.vueAccountProjectTask.ModifiedByFirstName, dbo.vueAccountProjectTask.ModifiedByLastName, dbo.vueAccountProjectTask.EstimatedCost, 
                      dbo.vueAccountProjectTask.EstimatedTimeSpent AS EstimatedHours, dbo.vueAccountProjectTask.EstimatedTimeSpentUnit, 
                      dbo.vueAccountProjectTask.AccountEmployeeId, dbo.vueAccountProjectTask.IsDisabled, dbo.vueAccountProjectTask.TaskCode, 
                      dbo.vueAccountProjectTask.IsTemplate, dbo.vueAccountProjectTask.IsForAllProjectTask, dbo.vueAccountProjectTask.IsBillable, 
                      dbo.AccountParty.AccountPartyId AS AccountClientId, dbo.AccountParty.PartyNick AS ClientNick, dbo.AccountParty.PartyName AS ClientName, CONVERT(nvarchar(200), 
                      dbo.vueAccountProjectTask.Duration) + ' - ' + dbo.vueAccountProjectTask.DurationUnit AS Duration, dbo.AccountProjectTask.TaskName AS ParentTaskName, 
                      dbo.vueAccountProjectTask.EstimatedCurrencyId, dbo.vueAccountCurrency.CurrencyCode AS EstimatedCurrencyCode, dbo.vueAccountProjectTask.ProjectDescription, 
                      dbo.vueAccountProjectTask.MilestoneDate, dbo.vueAccountProjectTask.StartDate, dbo.AccountParty.IsDeleted, dbo.vueAccountProjectTask.CustomField1, 
                      dbo.vueAccountProjectTask.CustomField2, dbo.vueAccountProjectTask.CustomField3, dbo.vueAccountProjectTask.CustomField4, 
                      dbo.vueAccountProjectTask.CustomField5, dbo.vueAccountProjectTask.CustomField6, dbo.vueAccountProjectTask.CustomField7, 
                      dbo.vueAccountProjectTask.CustomField8, dbo.vueAccountProjectTask.CustomField9, dbo.vueAccountProjectTask.CustomField10, 
                      dbo.vueAccountProjectTask.CustomField11, dbo.vueAccountProjectTask.CustomField12, dbo.vueAccountProjectTask.CustomField13, 
                      dbo.vueAccountProjectTask.CustomField14, dbo.vueAccountProjectTask.CustomField15
FROM         dbo.vueAccountProjectTask INNER JOIN
                      dbo.AccountProject ON dbo.vueAccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId LEFT OUTER JOIN
                      dbo.vueAccountCurrency ON dbo.vueAccountProjectTask.EstimatedCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.vueAccountProjectTask.ParentAccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId
WHERE     (dbo.AccountParty.IsDeleted <> 1) OR
                      (dbo.AccountParty.IsDeleted IS NULL)