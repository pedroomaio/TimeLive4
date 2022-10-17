CREATE VIEW dbo.vueAccountProjectRole
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountProject.DefaultBillingRate AS RoleBillingRate, 
                      dbo.AccountRole.AccountRoleId, dbo.AccountRole.AccountId, dbo.AccountRole.Role, dbo.AccountRole.MasterAccountRoleId, 
                      dbo.AccountProjectRole.AccountProjectRoleId, dbo.AccountProjectRole.NumberOfResources, dbo.AccountProjectRole.BillingTypeId, 
                      dbo.AccountBillingRate.SystemBillingRateTypeId, dbo.AccountBillingRate.BillingRate, dbo.AccountBillingRate.StartDate, 
                      dbo.AccountBillingRate.EndDate, dbo.AccountBillingRate.EmployeeRate, dbo.AccountWorkType.AccountWorkTypeId, 
                      dbo.AccountBillingRate.AccountBillingRateId, dbo.AccountBillingRate.BillingRateCurrencyId, dbo.AccountBillingRate.EmployeeRateCurrencyId
FROM         dbo.AccountBillingRate RIGHT OUTER JOIN
                      dbo.AccountRole INNER JOIN
                      dbo.AccountProject ON dbo.AccountRole.AccountId = dbo.AccountProject.AccountId INNER JOIN
                      dbo.AccountWorkType ON dbo.AccountProject.AccountId = dbo.AccountWorkType.AccountId LEFT OUTER JOIN
                      dbo.AccountProjectRole ON dbo.AccountRole.AccountRoleId = dbo.AccountProjectRole.AccountRoleId AND 
                      dbo.AccountProject.AccountProjectId = dbo.AccountProjectRole.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountWorkTypeBillingRate ON dbo.AccountWorkType.AccountWorkTypeId = dbo.AccountWorkTypeBillingRate.AccountWorkTypeId AND 
                      dbo.AccountProjectRole.AccountProjectRoleId = dbo.AccountWorkTypeBillingRate.AccountProjectRoleId ON 
                      dbo.AccountBillingRate.AccountBillingRateId = dbo.AccountWorkTypeBillingRate.AccountBillingRateId