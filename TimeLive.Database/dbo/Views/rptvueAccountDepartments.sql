
CREATE VIEW dbo.rptvueAccountDepartments
AS
SELECT     dbo.AccountDepartment.AccountDepartmentId, dbo.AccountDepartment.AccountId, ISNULL(dbo.AccountDepartment.DepartmentCode, N'') 
                      AS DepartmentCode, dbo.AccountDepartment.DepartmentName, dbo.AccountDepartment.IsDisabled
FROM         dbo.AccountDepartment INNER JOIN
                      dbo.Account ON dbo.AccountDepartment.AccountId = dbo.Account.AccountId