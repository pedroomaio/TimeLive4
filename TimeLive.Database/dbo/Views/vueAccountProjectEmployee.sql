
CREATE VIEW dbo.vueAccountProjectEmployee
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountProject.LeaderEmployeeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountProjectEmployee.AccountProjectEmployeeId, dbo.AccountProjectEmployee.AccountRoleId, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.Password, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS FullName, dbo.AccountEmployee.AccountId, 
                      dbo.AccountBillingRate.BillingRate, dbo.AccountBillingRate.StartDate, dbo.AccountBillingRate.EndDate, dbo.AccountBillingRate.EmployeeRate, 
                      dbo.AccountBillingRate.AccountBillingRateId, dbo.vueAccountEmployeeWithBillingRate.BillingRate AS EmployeeBillingRate, 
                      dbo.vueAccountEmployeeWithBillingRate.EmployeeRate AS EmployeeEmployeeRate, dbo.vueAccountEmployeeWithBillingRate.AccountWorkTypeId, 
                      dbo.AccountBillingRate.SystemBillingRateTypeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, 
                      dbo.AccountBillingRate.BillingRateCurrencyId, dbo.AccountBillingRate.EmployeeRateCurrencyId, 
                      dbo.vueAccountEmployeeWithBillingRate.BillingRateCurrencyId AS EmployeeBillingRateCurrencyId, 
                      dbo.vueAccountEmployeeWithBillingRate.EmployeeRateCurrencyId AS EmployeeEmployeeRateCurrencyId, dbo.AccountEmployee.IsDisabled, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountLocation.AccountLocation, dbo.AccountEmployee.AccountDepartmentId, 
                      dbo.AccountEmployee.AccountLocationId, dbo.AccountEmployee.IsDeleted
FROM         dbo.AccountLocation RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployee.AccountId = dbo.AccountProject.AccountId ON 
                      dbo.AccountLocation.AccountLocationId = dbo.AccountEmployee.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountWorkType INNER JOIN
                      dbo.vueAccountEmployeeWithBillingRate ON 
                      dbo.AccountWorkType.AccountWorkTypeId = dbo.vueAccountEmployeeWithBillingRate.AccountWorkTypeId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountEmployeeWithBillingRate.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectEmployee.AccountEmployeeId AND 
                      dbo.AccountProject.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId AND 
                      dbo.AccountWorkType.AccountId = dbo.AccountProjectEmployee.AccountId LEFT OUTER JOIN
                      dbo.AccountWorkTypeBillingRate ON 
                      dbo.AccountProjectEmployee.AccountProjectEmployeeId = dbo.AccountWorkTypeBillingRate.AccountProjectEmployeeId AND 
                      dbo.AccountWorkType.AccountWorkTypeId = dbo.AccountWorkTypeBillingRate.AccountWorkTypeId LEFT OUTER JOIN
                      dbo.AccountBillingRate ON dbo.AccountWorkTypeBillingRate.AccountBillingRateId = dbo.AccountBillingRate.AccountBillingRateId