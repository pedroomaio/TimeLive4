
CREATE VIEW [dbo].[vueAccountModuleViewWithSystemModuleFields]
AS
SELECT     a.AccountModuleViewId, a.AccountModuleViewName, a.SystemModuleId, b.SystemModuleFieldName, b.SystemModuleFieldId, a.AccountId, 
                      a.AccountEmployeeId, a.IsSelected, a.CreatedOn, a.CreatedBy, a.ModifiedOn, a.ModifiedBy, b.SystemModuleFieldDisplayName, b.IsDefaultAdd, 
                      b.SystemModuleFieldWidth, a.IsDefaultView, b.IsRequired, b.SystemFieldsSortOrder
FROM         dbo.AccountModuleView AS a RIGHT OUTER JOIN
                      dbo.SystemModuleFields AS b ON a.SystemModuleId = b.SystemModuleId