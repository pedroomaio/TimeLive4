
CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithAccountProjectEmployee
AS
SELECT     dbo.AccountProjectEmployee.AccountProjectEmployeeId, dbo.AccountProjectEmployee.AccountId, dbo.AccountProjectEmployee.AccountProjectId, 
                      dbo.AccountProjectEmployee.AccountEmployeeId, dbo.AccountProjectEmployee.TaskCompletedPercentage, 
                      dbo.AccountProjectEmployee.TaskCompleted, dbo.AccountProjectEmployee.AccountRoleId, dbo.AccountProjectEmployee.AccountBillingRateId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountProject.ProjectBillingRateTypeId, 
                      dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, dbo.AccountProjectTask.IsBillable, dbo.AccountEmployeeTimeEntry.AccountWorkTypeId
FROM         dbo.AccountProjectEmployee INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND 
                      dbo.AccountProjectEmployee.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId