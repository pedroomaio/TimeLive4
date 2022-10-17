CREATE TABLE [dbo].[SystemTimeSheetApprovalPath] (
    [SystemTimeSheetApprovalPathId] INT            NOT NULL,
    [TimeSheetApprovalPath]         NVARCHAR (100) NOT NULL,
    [IsNoApprovalRequired]          BIT            NOT NULL,
    [IsProjectManager]              BIT            NOT NULL,
    [IsTeamLead]                    BIT            NOT NULL,
    [IsAdministrator]               BIT            NOT NULL,
    CONSTRAINT [PK_SystemTimeSheetApprovalPath] PRIMARY KEY CLUSTERED ([SystemTimeSheetApprovalPathId] ASC)
);

