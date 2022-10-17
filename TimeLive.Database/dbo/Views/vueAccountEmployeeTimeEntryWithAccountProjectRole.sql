
CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithAccountProjectRole
AS
SELECT     dbo.AccountProjectRole.AccountProjectRoleId, dbo.AccountProjectRole.AccountProjectId, dbo.AccountProjectRole.AccountRoleId, 
                      dbo.AccountProjectRole.NumberOfResources, dbo.AccountProjectRole.BillingRate, dbo.AccountProjectRole.BillingTypeId, 
                      dbo.AccountProjectRole.AccountBillingRateId, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.AccountEmployeeId, 
                      dbo.AccountProject.ProjectBillingRateTypeId, dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, dbo.AccountProjectTask.IsBillable, 
                      dbo.AccountEmployeeTimeEntry.AccountWorkTypeId
FROM         dbo.AccountProjectRole INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectRole.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId INNER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountProjectRole.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId AND 
                      dbo.AccountProjectRole.AccountRoleId = dbo.AccountProjectEmployee.AccountRoleId AND 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountProjectEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId