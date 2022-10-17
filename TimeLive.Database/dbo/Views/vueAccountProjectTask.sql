                 
CREATE VIEW [dbo].[vueAccountProjectTask]
AS
SELECT     dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.AccountTaskTypeId, 
                      dbo.AccountProjectTask.Duration, dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, 
                      dbo.AccountProjectTask.CompletedPercent, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.CreatedOn, dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.ModifiedOn, 
                      dbo.AccountProjectTask.ModifiedByEmployeeId, dbo.AccountStatus.Status AS TaskStatus, dbo.AccountEmployee.FirstName AS CreatedByFirstName, 
                      dbo.AccountEmployee.LastName AS CreatedByLastName, dbo.AccountPriority.Priority, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectCode, dbo.AccountTaskType.TaskType, dbo.AccountProject.AccountId, dbo.AccountProjectTask.AccountProjectMilestoneId, 
                      dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountProjectTask.IsReOpen, AccountEmployee_1.FirstName AS ModifiedByFirstName, 
                      AccountEmployee_1.LastName AS ModifiedByLastName, dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, 
                      dbo.AccountProjectTask.EstimatedTimeSpentUnit, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProjectTask.IsDisabled, 
                      dbo.AccountProjectTask.TaskCode, dbo.AccountProject.IsTemplate, dbo.AccountProjectTask.IsForAllProjectTask, dbo.AccountProjectTask.IsBillable, 
                      dbo.AccountProjectTask.EstimatedCurrencyId, dbo.AccountParty.PartyName, dbo.AccountParty.PartyNick, dbo.AccountProject.AccountClientId, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProjectMilestone.MilestoneDate, dbo.AccountProject.IsDeleted AS IsProjectDeleted, 
                      dbo.AccountProjectTask.StartDate, dbo.AccountParty.IsDeleted AS IsDeletedClient, dbo.AccountProjectTask.Predecessors, 
                      dbo.AccountProjectTask.CustomField1, dbo.AccountProjectTask.CustomField2, dbo.AccountProjectTask.CustomField3, 
                      dbo.AccountProjectTask.CustomField4, dbo.AccountProjectTask.CustomField5, dbo.AccountProjectTask.CustomField6, 
                      dbo.AccountProjectTask.CustomField7, dbo.AccountProjectTask.CustomField8, dbo.AccountProjectTask.CustomField9, 
                      dbo.AccountProjectTask.CustomField10, dbo.AccountProjectTask.CustomField11, dbo.AccountProjectTask.CustomField12, 
                      dbo.AccountProjectTask.CustomField13, dbo.AccountProjectTask.CustomField14, dbo.AccountProjectTask.CustomField15, 
                      dbo.AccountProjectMilestone.Completed AS MilestoneCompleted, dbo.AccountProject.IsDisabled AS IsProjectDisabled, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS AssignedBy
FROM         dbo.AccountTaskType RIGHT OUTER JOIN
                      dbo.AccountProjectMilestone RIGHT OUTER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId RIGHT OUTER JOIN
                      dbo.AccountProjectTask LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountProjectTask.ModifiedByEmployeeId = AccountEmployee_1.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountProjectTask.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountProjectTask.CreatedByEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountProjectMilestone.AccountProjectMilestoneId = dbo.AccountProjectTask.AccountProjectMilestoneId ON 
                      dbo.AccountTaskType.AccountTaskTypeId = dbo.AccountProjectTask.AccountTaskTypeId LEFT OUTER JOIN
                      dbo.AccountStatus ON dbo.AccountProjectTask.TaskStatusId = dbo.AccountStatus.AccountStatusId LEFT OUTER JOIN
                      dbo.AccountPriority ON dbo.AccountProjectTask.AccountPriorityId = dbo.AccountPriority.AccountPriorityId
WHERE     (dbo.AccountProject.IsDeleted <> 1) OR
                      (dbo.AccountProject.IsDeleted IS NULL)