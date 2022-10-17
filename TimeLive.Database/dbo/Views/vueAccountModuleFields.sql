
CREATE VIEW [dbo].[vueAccountModuleFields]
AS
SELECT     dbo.vueAccountModuleViewWithSystemModuleFields.AccountModuleViewId, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.AccountModuleViewName, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.SystemModuleId, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.SystemModuleFieldName, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.SystemModuleFieldId, dbo.vueAccountModuleViewWithSystemModuleFields.AccountId, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.AccountEmployeeId, dbo.vueAccountModuleViewWithSystemModuleFields.IsSelected, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.CreatedOn, dbo.vueAccountModuleViewWithSystemModuleFields.CreatedBy, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.ModifiedOn, dbo.vueAccountModuleViewWithSystemModuleFields.ModifiedBy, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.SystemModuleFieldDisplayName, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.IsDefaultAdd, dbo.vueAccountModuleViewWithSystemModuleFields.SystemModuleFieldWidth, 
                      c.AccountModuleFieldId, c.AccountModuleFieldName, dbo.vueAccountModuleViewWithSystemModuleFields.IsDefaultView, c.SortOrder, 
                      dbo.vueAccountModuleViewWithSystemModuleFields.IsRequired, dbo.vueAccountModuleViewWithSystemModuleFields.SystemFieldsSortOrder
FROM         dbo.vueAccountModuleViewWithSystemModuleFields LEFT OUTER JOIN
                      dbo.AccountModuleFields AS c ON dbo.vueAccountModuleViewWithSystemModuleFields.AccountModuleViewId = c.AccountModuleViewId AND 
                      dbo.vueAccountModuleViewWithSystemModuleFields.SystemModuleFieldId = c.SystemModuleFieldId