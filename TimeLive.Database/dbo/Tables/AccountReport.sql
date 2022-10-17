CREATE TABLE [dbo].[AccountReport] (
    [AccountReportId]         UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReport_AccountReportId] DEFAULT (newid()) NOT NULL,
    [AccountReportCategoryId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountReport_AccountReportCategoryId] DEFAULT (newid()) NOT NULL,
    [ReportName]              NVARCHAR (200)   NOT NULL,
    [ReportDescription]       NVARCHAR (4000)  NOT NULL,
    [ReportIconPath]          VARCHAR (100)    NULL,
    [AccountId]               INT              NULL,
    [SystemReportTypeId]      UNIQUEIDENTIFIER NULL,
    [SystemReportId]          UNIQUEIDENTIFIER NULL,
    [IsConsolidated]          BIT              NULL,
    [ReportPageName]          NVARCHAR (200)   NULL,
    [ReportOrder]             INT              NULL,
    [ShowCompanyLogo]         BIT              CONSTRAINT [DF_AccountReport_ShowCompanyLogo] DEFAULT ((0)) NOT NULL,
    [ReportTitle]             NVARCHAR (200)   NULL,
    [ReportHeader]            NVARCHAR (4000)  NULL,
    [ReportFooter]            NVARCHAR (4000)  NULL,
    CONSTRAINT [PK_AccountReport] PRIMARY KEY CLUSTERED ([AccountReportId] ASC)
);

