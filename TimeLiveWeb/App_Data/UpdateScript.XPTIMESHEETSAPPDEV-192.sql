GO
ALTER TABLE AccountReport
add Visible bit
GO
Update AccountReport
Set Visible = 1
GO
Alter table AccountReport
Alter Column Visible bit NOT NULL

GO
/****** Object:  View [dbo].[vueAccountReport]    Script Date: 22/03/2017 12:15:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vueAccountReport]
AS
SELECT        dbo.AccountReportCategory.AccountReportCategory, dbo.AccountReport.AccountReportId, dbo.AccountReport.AccountReportCategoryId, dbo.AccountReport.ReportName, dbo.AccountReport.ReportDescription, 
                         dbo.AccountReport.ReportIconPath, dbo.AccountReport.AccountId, dbo.AccountReport.SystemReportTypeId, dbo.AccountReport.SystemReportId, dbo.AccountReport.IsConsolidated, 
                         dbo.AccountReport.ReportPageName, dbo.AccountReport.ReportOrder, dbo.AccountReportCategory.SequenceNo, CAST(dbo.AccountReportCategory.SequenceNo AS nvarchar(4000)) 
                         + ' - ' + dbo.AccountReportCategory.AccountReportCategory AS AccountReportCategorySequence, dbo.AccountReportCategory.SystemFeatureId AS SystemFeatureCategoryId, 
                         dbo.SystemReportDataSource.SystemFeatureId, dbo.AccountReport.Visible
FROM            dbo.SystemReportDataSource INNER JOIN
                         dbo.AccountReportDataSourceMapping ON dbo.SystemReportDataSource.SystemReportDataSourceId = dbo.AccountReportDataSourceMapping.SystemReportDataSourceId RIGHT OUTER JOIN
                         dbo.AccountReport ON dbo.AccountReportDataSourceMapping.AccountReportId = dbo.AccountReport.AccountReportId RIGHT OUTER JOIN
                         dbo.AccountReportCategory ON dbo.AccountReport.AccountReportCategoryId = dbo.AccountReportCategory.AccountReportCategoryId

GO

Insert into SystemSecurityCategoryPage values
(170, 1, 210107 , 'AccountAdmin' , 'AccountReports.aspx' , 'Reports Managments' , 15 , 1 , 1 , 1 , 1 , 1 , 1 , null , null ,null ,null ,null , null , null)
