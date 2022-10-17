CREATE TABLE [dbo].[SystemReportPermission] (
    [SystemReportPermissionId] UNIQUEIDENTIFIER CONSTRAINT [DF_SystemReportPermission_SystemReportPermissionId] DEFAULT (newid()) NOT NULL,
    [AccountReportId]          UNIQUEIDENTIFIER NOT NULL,
    [MasterAccountRoleId]      INT              NOT NULL,
    [ShowReport]               BIT              NULL,
    [AllowCustomization]       BIT              NULL,
    [AllowAllUser]             BIT              NULL,
    [AllowOwnReport]           BIT              NULL,
    [AllowOwnTeam]             BIT              NULL,
    [AllowOwnProject]          BIT              NULL,
    [AllowOwnSubOrdinates]     BIT              NULL,
    [AllowOwnApproval]         BIT              NULL,
    CONSTRAINT [PK_SystemReportPermission] PRIMARY KEY CLUSTERED ([SystemReportPermissionId] ASC)
);

