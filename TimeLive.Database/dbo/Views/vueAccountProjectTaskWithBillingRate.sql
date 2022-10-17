
CREATE VIEW dbo.vueAccountProjectTaskWithBillingRate
AS
SELECT     dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.AccountTaskTypeId, 
                      dbo.AccountProjectTask.Duration, dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, 
                      dbo.AccountProjectTask.CompletedPercent, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.AccountProjectMilestoneId, dbo.AccountProjectTask.IsReOpen, dbo.AccountProjectTask.CreatedOn, 
                      dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.ModifiedOn, dbo.AccountProjectTask.ModifiedByEmployeeId, 
                      dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, dbo.AccountProjectTask.EstimatedTimeSpentUnit, 
                      dbo.AccountProjectTask.IsBillable, dbo.AccountProjectTask.IsDisabled, dbo.AccountProjectTask.IsForAllProjectTask, 
                      dbo.AccountBillingRate.BillingRate, dbo.AccountBillingRate.StartDate, dbo.AccountBillingRate.EndDate, 
                      dbo.AccountWorkTypeBillingRate.SystemBillingRateTypeId, dbo.AccountBillingRate.EmployeeRate, dbo.AccountWorkType.AccountWorkTypeId, 
                      dbo.AccountBillingRate.AccountBillingRateId
FROM         dbo.AccountWorkTypeBillingRate RIGHT OUTER JOIN
                      dbo.AccountBillingRate ON dbo.AccountWorkTypeBillingRate.AccountBillingRateId = dbo.AccountBillingRate.AccountBillingRateId RIGHT OUTER JOIN
                      dbo.AccountProjectTask INNER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountWorkType ON dbo.AccountProject.AccountId = dbo.AccountWorkType.AccountId ON 
                      dbo.AccountWorkTypeBillingRate.AccountWorkTypeId = dbo.AccountWorkType.AccountWorkTypeId AND 
                      dbo.AccountWorkTypeBillingRate.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId