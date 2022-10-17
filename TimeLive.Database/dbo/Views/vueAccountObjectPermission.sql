
CREATE VIEW dbo.vueAccountObjectPermission
AS
SELECT     dbo.AccountRole.Role, dbo.AccountObjectPermission.AccountObjectPermissionId, dbo.AccountObjectPermission.ShowReport, 
                      dbo.AccountObjectPermission.AllowCustomization, dbo.AccountObjectPermission.AllowAllUser, dbo.AccountObjectPermission.AllowOwnReport, 
                      dbo.AccountObjectPermission.AllowOwnTeam, dbo.AccountObjectPermission.AllowOwnProject, dbo.AccountObjectPermission.AllowOwnSubOrdinates, 
                      dbo.AccountReport.AccountReportCategoryId, dbo.AccountReport.ReportName, dbo.AccountReport.ReportDescription, 
                      dbo.AccountReport.ReportIconPath, dbo.AccountReport.SystemReportTypeId, dbo.AccountReport.SystemReportId, dbo.AccountReport.IsConsolidated, 
                      dbo.AccountRole.AccountId, dbo.AccountRole.AccountRoleId, dbo.AccountObjectPermission.AccountReportId, 
                      dbo.AccountObjectPermission.AllowOwnApproval
FROM         dbo.AccountReport INNER JOIN
                      dbo.AccountObjectPermission ON dbo.AccountReport.AccountReportId = dbo.AccountObjectPermission.AccountReportId RIGHT OUTER JOIN
                      dbo.AccountRole ON dbo.AccountObjectPermission.AccountRoleId = dbo.AccountRole.AccountRoleId