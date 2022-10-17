CREATE VIEW [dbo].[vxp_DetailMonthAllocation]
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId AS _EMPLOYEE_ID, dbo.AccountEmployee.EmployeeCode AS _EMPLOYEE_CODE, REPLACE(CONVERT(varchar(10), 
                      dbo.getLastBusinessDay(dbo.AccountEmployeeTimeEntry.TimeEntryDate), 111), '/', '-') AS _MONTH_NR, dbo.AccountEmployeeTimeEntry.TimeEntryDate AS _DATE, 
                      dbo.AccountProject.ProjectCode AS _PROJECT_CODE, dbo.AccountEmployeeTimeEntry.Approved AS _APPROVED, SUM(CAST(DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) AS float) + CAST(DATEPART(mi, dbo.AccountEmployeeTimeEntry.TotalTime) AS float) / 60) AS _TOTAL_TIME, 
                      dbo.AccountProject.ProjectDescription AS _PROJECT_DESCRIPTION, dbo.AccountEmployeeTimeEntry.Submitted AS _SUBMITTED, 
                      dbo.AccountTaskType.TaskType AS _TASK_CODE, AccountEmployee_1.EmployeeCode AS _PROJECT_MANAGER
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountProject.ProjectManagerEmployeeId = AccountEmployee_1.AccountEmployeeId  INNER JOIN
					  dbo.AccountTaskType ON dbo.AccountProjectTask.AccountTaskTypeId = dbo.AccountTaskType.AccountTaskTypeId
WHERE dbo.AccountEmployee.isDisabled <> 1
GROUP BY dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.EmployeeCode, DATEPART(month, dbo.AccountEmployeeTimeEntry.TimeEntryDate), 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountProject.ProjectCode, dbo.AccountEmployeeTimeEntry.Approved, dbo.AccountProject.ProjectDescription, 
                      dbo.AccountEmployeeTimeEntry.Submitted, dbo.AccountTaskType.TaskType, AccountEmployee_1.EmployeeCode