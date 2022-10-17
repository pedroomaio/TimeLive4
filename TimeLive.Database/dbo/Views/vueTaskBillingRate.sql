CREATE VIEW dbo.vueTaskBillingRate
AS
SELECT     CASE WHEN dbo.AccountProject.ProjectBillingRateTypeId = 2 THEN dbo.AccountProjectRole.BillingRate ELSE dbo.AccountProjectRole.BillingRate END AS
                       BillingRate, 
                      CASE WHEN dbo.AccountProject.ProjectBillingRateTypeId = 2 THEN dbo.AccountProjectRole.BillingTypeId ELSE dbo.AccountEmployee.BillingTypeId END
                       AS BillingTypeId, dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTaskEmployee.AccountEmployeeId, 
                      dbo.AccountEmployee.BillingTypeId AS EmployeeBillingTypeId, dbo.AccountProjectRole.BillingRate AS EmployeeBillingRate, 
                      dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountProject.ProjectBillingRateTypeId, dbo.AccountProjectEmployee.AccountRoleId, dbo.AccountProjectEmployee.AccountProjectEmployeeId, 
                      dbo.AccountProjectRole.NumberOfResources, dbo.AccountProjectRole.BillingRate AS RoleBillingRate, 
                      dbo.AccountProjectRole.BillingTypeId AS RoleBillingTypeId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountProject.AccountProjectId = dbo.AccountProjectTask.AccountProjectId INNER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountProjectRole ON dbo.AccountProjectEmployee.AccountProjectId = dbo.AccountProjectRole.AccountProjectId AND 
                      dbo.AccountProjectEmployee.AccountRoleId = dbo.AccountProjectRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountProjectTaskEmployee ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTaskEmployee.AccountEmployeeId ON 
                      dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountProjectTaskEmployee.AccountEmployeeId AND 
                      dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountProjectTaskEmployee.AccountProjectTaskId