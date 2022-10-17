CREATE VIEW dbo.vueAccountRole
AS
SELECT     dbo.AccountRole.AccountRoleId, dbo.AccountRole.AccountId, dbo.AccountRole.Role, dbo.AccountRole.IsDisabled, dbo.AccountRole.IsDeleted, 
                      dbo.AccountRole.CreatedOn, dbo.AccountRole.CreatedByEmployeeId, dbo.AccountRole.ModifiedOn, dbo.AccountRole.ModifiedByEmployeeId, 
                      dbo.AccountRole.MasterAccountRoleId, dbo.MasterAccountRole.IsSystemRole
FROM         dbo.AccountRole LEFT OUTER JOIN
                      dbo.MasterAccountRole ON dbo.AccountRole.MasterAccountRoleId = dbo.MasterAccountRole.MasterAccountRoleId