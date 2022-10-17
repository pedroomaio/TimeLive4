
CREATE VIEW dbo.vueAccountProjectRoleBillingRate
AS
SELECT     dbo.AccountProjectRole.AccountProjectRoleId, dbo.AccountProjectRole.AccountProjectId, dbo.AccountProjectRole.AccountRoleId, 
                      dbo.AccountProjectRole.NumberOfResources, dbo.AccountProjectRole.BillingRate, dbo.AccountProjectRole.BillingTypeId, 
                      dbo.AccountProjectRole.AccountBillingRateId, dbo.AccountProjectEmployee.AccountProjectEmployeeId, dbo.AccountProjectEmployee.AccountEmployeeId, 
                      dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS FullName, dbo.AccountRole.Role, 
                      dbo.AccountProject.ProjectName, dbo.AccountBillingType.BillingType, dbo.AccountProjectEmployee.AccountId, dbo.AccountProject.IsDeleted AS IsDeletedProject
FROM         dbo.AccountProjectEmployee INNER JOIN
                      dbo.AccountProjectRole ON dbo.AccountProjectEmployee.AccountProjectId = dbo.AccountProjectRole.AccountProjectId AND 
                      dbo.AccountProjectEmployee.AccountRoleId = dbo.AccountProjectRole.AccountRoleId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountBillingType ON dbo.AccountProjectRole.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId INNER JOIN
                      dbo.AccountRole ON dbo.AccountProjectRole.AccountRoleId = dbo.AccountRole.AccountRoleId INNER JOIN
                      dbo.AccountProject ON dbo.AccountProjectRole.AccountProjectId = dbo.AccountProject.AccountProjectId