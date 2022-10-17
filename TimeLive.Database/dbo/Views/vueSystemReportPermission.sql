
CREATE VIEW dbo.vueSystemReportPermission
AS
SELECT     dbo.AccountReport.ReportName, dbo.AccountReport.ReportDescription, dbo.MasterAccountRole.Role, dbo.AccountRole.AccountRoleId, 
                      dbo.SystemReportPermission.SystemReportPermissionId, dbo.SystemReportPermission.AccountReportId, 
                      dbo.SystemReportPermission.MasterAccountRoleId, dbo.SystemReportPermission.ShowReport, dbo.SystemReportPermission.AllowCustomization, 
                      dbo.SystemReportPermission.AllowAllUser, dbo.SystemReportPermission.AllowOwnReport, dbo.SystemReportPermission.AllowOwnTeam, 
                      dbo.SystemReportPermission.AllowOwnProject, dbo.SystemReportPermission.AllowOwnSubOrdinates, dbo.AccountRole.AccountId, 
                      dbo.SystemReportPermission.AllowOwnApproval
FROM         dbo.SystemReportPermission INNER JOIN
                      dbo.MasterAccountRole ON dbo.SystemReportPermission.MasterAccountRoleId = dbo.MasterAccountRole.MasterAccountRoleId INNER JOIN
                      dbo.AccountRole ON dbo.MasterAccountRole.MasterAccountRoleId = dbo.AccountRole.MasterAccountRoleId LEFT OUTER JOIN
                      dbo.AccountReport ON dbo.SystemReportPermission.AccountReportId = dbo.AccountReport.AccountReportId