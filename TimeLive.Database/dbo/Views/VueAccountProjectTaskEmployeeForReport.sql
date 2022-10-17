
CREATE VIEW dbo.VueAccountProjectTaskEmployeeForReport
AS
SELECT     dbo.AccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.AccountProjectTaskEmployee.AccountId, 
                      CASE WHEN AccountEmployee.IsDisabled = 1 THEN AccountEmployee.FirstName + ' ' + AccountEmployee.LastName + ' ' + '(Disabled)' ELSE AccountEmployee.FirstName
                       + ' ' + AccountEmployee.LastName END AS EmployeeName, dbo.AccountProjectTaskEmployee.AccountProjectTaskId, 
                      dbo.AccountProjectTaskEmployee.AccountEmployeeId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, 
                      dbo.AccountEmployee.AccountWorkingDayTypeId, dbo.AccountEmployee.AccountTimeOffPolicyId, dbo.AccountEmployee.TimeOffApprovalTypeId, 
                      dbo.AccountEmployee.AccountHolidayTypeId, dbo.AccountParty.PartyName AS ClientName, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.Duration AS TaskDuration, dbo.AccountProjectTask.DurationUnit AS TaskDurationUnit, 
                      dbo.AccountProjectTask.DeadlineDate AS TaskDeadlineDate, dbo.AccountProjectTask.Completed AS TaskCompleted, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.EstimatedCost AS TaskEmployeeCost, 
                      dbo.AccountProjectTask.EstimatedTimeSpent AS TaskEstimatedTimeSpent, dbo.AccountProjectTask.EstimatedTimeSpentUnit AS TaskEstimatedTimeSpentUnit, 
                      dbo.AccountProjectTask.TaskCode, dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.State, dbo.AccountEmployee.City, dbo.AccountEmployee.Zip, dbo.AccountEmployee.HomePhoneNo, dbo.AccountEmployee.WorkPhoneNo, 
                      dbo.AccountEmployee.MobilePhoneNo, dbo.AccountEmployee.BillingRateStateDate, dbo.AccountEmployee.TerminationDate, dbo.AccountEmployee.EmployeeCode, 
                      dbo.AccountEmployee.JobTitle, dbo.AccountEmployee.HiredDate, dbo.AccountEmployeeType.AccountEmployeeType, 
                      dbo.AccountWorkingDayType.AccountWorkingDayType, dbo.AccountWorkingDayType.HoursPerDay, dbo.AccountWorkingDayType.WeekStartDay, 
                      dbo.AccountWorkingDayType.MinimumHoursPerDay, dbo.AccountWorkingDayType.MaximumHoursPerDay, dbo.AccountWorkingDayType.MinimumHoursPerWeek, 
                      dbo.AccountWorkingDayType.MaximumHoursPerWeek, dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.StartDate AS ProjectStartDate, dbo.AccountProject.Deadline AS ProjectDeadlineDate, 
                      dbo.AccountProject.EstimatedTime AS ProjectEstimatedTime, dbo.AccountProject.EstimatedDuration AS ProjectEstimatedDuration, 
                      dbo.AccountProject.EstimatedDurationUnit AS ProjectEstimatedDurationUnit, CASE WHEN ISNULL(dbo.AccountProject.ProjectPrefix,'') = '' THEN dbo.AccountProject.ProjectCode ELSE dbo.AccountProject.ProjectPrefix + '-' + 
					  dbo.AccountProject.ProjectCode END AS ProjectCode, dbo.AccountProject.Completed AS ProjectCompleted, 
                      dbo.AccountStatus.Status AS TaskStatus, dbo.AccountPriority.Priority, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.AccountTaskTypeId, dbo.AccountTaskType.TaskType, dbo.AccountBillingRate.BillingRate, 
                      dbo.AccountBillingRate.StartDate AS BillingRateStartDate, dbo.AccountBillingRate.EndDate AS BillingRateEndDate, dbo.AccountBillingRate.EmployeeRate, 
                      SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, 
                      dbo.AccountProjectTask.StartDate AS TaskStartDate, dbo.AccountProject.AccountClientId
FROM         dbo.AccountBillingRate INNER JOIN
                      dbo.AccountTaskType INNER JOIN
                      dbo.AccountProjectTaskEmployee INNER JOIN
                      dbo.AccountParty INNER JOIN
                      dbo.AccountProject ON dbo.AccountParty.AccountPartyId = dbo.AccountProject.AccountClientId INNER JOIN
                      dbo.AccountStatus INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountStatus.AccountStatusId = dbo.AccountProjectTask.TaskStatusId INNER JOIN
                      dbo.AccountPriority ON dbo.AccountProjectTask.AccountPriorityId = dbo.AccountPriority.AccountPriorityId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountProjectTask.AccountProjectId ON 
                      dbo.AccountProjectTaskEmployee.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProjectTaskEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountTaskType.AccountTaskTypeId = dbo.AccountProjectTask.AccountTaskTypeId ON 
                      dbo.AccountBillingRate.AccountBillingRateId = dbo.AccountProjectTask.AccountBillingRateId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId AND 
                      dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId AND 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEmployeeType ON dbo.AccountEmployee.EmployeePayTypeId = dbo.AccountEmployeeType.AccountEmployeeTypeId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountWorkingDayType ON dbo.AccountEmployee.AccountWorkingDayTypeId = dbo.AccountWorkingDayType.AccountWorkingDayTypeId LEFT OUTER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountTimeOffPolicy ON dbo.AccountEmployee.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId
WHERE     (dbo.AccountParty.IsDeleted <> 1) OR
                      (dbo.AccountParty.IsDeleted IS NULL)
GROUP BY dbo.AccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.AccountProjectTaskEmployee.AccountId, 
                      CASE WHEN AccountEmployee.IsDisabled = 1 THEN AccountEmployee.FirstName + ' ' + AccountEmployee.LastName + ' ' + '(Disabled)' ELSE AccountEmployee.FirstName
                       + ' ' + AccountEmployee.LastName END, dbo.AccountProjectTaskEmployee.AccountProjectTaskId, dbo.AccountProjectTaskEmployee.AccountEmployeeId, 
                      dbo.AccountProjectTask.AccountProjectId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.AccountWorkingDayTypeId, 
                      dbo.AccountEmployee.AccountTimeOffPolicyId, dbo.AccountEmployee.TimeOffApprovalTypeId, dbo.AccountEmployee.AccountHolidayTypeId, 
                      dbo.AccountParty.PartyName, dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.Duration, 
                      dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, 
                      dbo.AccountProjectTask.EstimatedTimeSpentUnit, dbo.AccountProjectTask.TaskCode, dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, 
                      dbo.AccountLocation.AccountLocation, dbo.AccountEmployee.State, dbo.AccountEmployee.City, dbo.AccountEmployee.Zip, dbo.AccountEmployee.HomePhoneNo, 
                      dbo.AccountEmployee.WorkPhoneNo, dbo.AccountEmployee.MobilePhoneNo, dbo.AccountEmployee.BillingRateStateDate, dbo.AccountEmployee.TerminationDate, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.JobTitle, dbo.AccountEmployee.HiredDate, dbo.AccountEmployeeType.AccountEmployeeType, 
                      dbo.AccountWorkingDayType.AccountWorkingDayType, dbo.AccountWorkingDayType.HoursPerDay, dbo.AccountWorkingDayType.WeekStartDay, 
                      dbo.AccountWorkingDayType.MinimumHoursPerDay, dbo.AccountWorkingDayType.MaximumHoursPerDay, dbo.AccountWorkingDayType.MinimumHoursPerWeek, 
                      dbo.AccountWorkingDayType.MaximumHoursPerWeek, dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.StartDate, dbo.AccountProject.Deadline, dbo.AccountProject.EstimatedTime, 
                      dbo.AccountProject.EstimatedDuration, dbo.AccountProject.EstimatedDurationUnit, CASE WHEN ISNULL(dbo.AccountProject.ProjectPrefix,'') = '' THEN dbo.AccountProject.ProjectCode ELSE dbo.AccountProject.ProjectPrefix + '-' + 
					  dbo.AccountProject.ProjectCode END, dbo.AccountProject.Completed, 
                      dbo.AccountStatus.Status, dbo.AccountPriority.Priority, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.AccountTaskTypeId, dbo.AccountTaskType.TaskType, dbo.AccountBillingRate.BillingRate, dbo.AccountBillingRate.StartDate, 
                      dbo.AccountBillingRate.EndDate, dbo.AccountBillingRate.EmployeeRate, dbo.AccountProjectTask.StartDate, dbo.AccountProject.AccountClientId