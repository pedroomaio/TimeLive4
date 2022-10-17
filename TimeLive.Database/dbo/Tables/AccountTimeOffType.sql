CREATE TABLE [dbo].[AccountTimeOffType] (
    [AccountTimeOffTypeId]     UNIQUEIDENTIFIER CONSTRAINT [DF_AccountTimeOffType_AccountTimeOffTypeId] DEFAULT (newid()) NOT NULL,
    [AccountTimeOffType]       NVARCHAR (100)   NOT NULL,
    [IsTimeOffRequestRequired] BIT              CONSTRAINT [DF_AccountTimeOffType_IsTimeOffRequestRequired] DEFAULT ((0)) NOT NULL,
    [AccountId]                INT              NOT NULL,
    [CreatedByEmployeeId]      INT              NOT NULL,
    [CreatedOn]                DATETIME         CONSTRAINT [DF_AccountTimeOffType_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]     INT              NOT NULL,
    [ModifiedOn]               DATETIME         CONSTRAINT [DF_AccountTimeOffType_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [IsDisabled]               BIT              NOT NULL,
    [MasterTimeOffTypeId]      UNIQUEIDENTIFIER NULL,
    [Paid]                     BIT              NULL,
    [Color]                    VARCHAR (10)     NULL,
    [BriefExplanation]         VARCHAR (MAX)    NULL,
    [ScheduleWeekends]         BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccountTimeOffType] PRIMARY KEY CLUSTERED ([AccountTimeOffTypeId] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_AccountTimeOffTypeId]
    ON [dbo].[AccountTimeOffType]([AccountTimeOffTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsTimeOffRequestRequired]
    ON [dbo].[AccountTimeOffType]([IsTimeOffRequestRequired] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountTimeOffType]([AccountId] ASC);

