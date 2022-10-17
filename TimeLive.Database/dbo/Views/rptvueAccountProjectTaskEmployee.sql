
CREATE VIEW dbo.rptvueAccountProjectTaskEmployee
AS
SELECT     AccountProjectTaskEmployeeId, AccountProjectId, AccountProjectTaskId, TaskName, AccountEmployeeId, AccountId, TaskDescription, TaskCode, DepartmentName, 
                      AccountLocation, AccountEmployeeType, EmployeeCode, IsParentTask, IsForAllEmployees, EmployeeName, ClientName, TaskDuration, TaskDurationUnit, 
                      TaskDeadlineDate, TaskCompleted, TaskEmployeeCost, TaskEstimatedTimeSpent, TaskEstimatedTimeSpentUnit, Role, State, City, Zip, HomePhoneNo, 
                      WorkPhoneNo, MobilePhoneNo, BillingRateStateDate, TerminationDate, JobTitle, HiredDate, AccountWorkingDayType, HoursPerDay, WeekStartDay, 
                      MinimumHoursPerDay, MaximumHoursPerDay, MaximumHoursPerWeek, MinimumHoursPerWeek, AccountTimeOffPolicy, ProjectName, ProjectDescription, 
                      ProjectStartDate, ProjectDeadlineDate, ProjectEstimatedTime, ProjectEstimatedDuration, ProjectEstimatedDurationUnit, ProjectCode, ProjectCompleted, TaskStatus, 
                      Priority, AccountPriorityId, TaskStatusId, AccountTaskTypeId, TaskType, BillingRate, BillingRateStartDate, BillingRateEndDate, EmployeeRate, ROUND(CONVERT(float, 
                      TotalMinutes) / 60, 2) AS TotalHours, REPLACE(TotalMinutes / 60, '', '.00') + ':' + RIGHT('0' + REPLACE(TotalMinutes - TotalMinutes / 60 * 60, '', '.00'), 2) AS TotalTime, 
                      TaskStartDate, AccountClientId
FROM         dbo.VueAccountProjectTaskEmployeeForReport