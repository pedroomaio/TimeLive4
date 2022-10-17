
CREATE VIEW dbo.vueAccountCostCenterEmployee
AS
SELECT     dbo.AccountCostCenter.AccountCostCenterCode, dbo.AccountCostCenter.AccountCostCenter, dbo.AccountCostCenter.SortOrder, dbo.AccountCostCenter.AccountId, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountCostCenterEmployee.AccountCostCenterEmployeeId, dbo.AccountCostCenter.AccountCostCenterId
FROM         dbo.AccountCostCenter INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountCostCenter.AccountId = dbo.AccountEmployee.AccountId LEFT OUTER JOIN
                      dbo.AccountCostCenterEmployee ON dbo.AccountCostCenter.AccountCostCenterId = dbo.AccountCostCenterEmployee.AccountCostCenterId AND 
                      dbo.AccountCostCenter.AccountId = dbo.AccountCostCenterEmployee.AccountId AND 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountCostCenterEmployee.AccountEmployeeId