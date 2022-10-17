CREATE TABLE [dbo].[AccountProjectType] (
    [AccountProjectTypeId]       INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]                  INT            NULL,
    [ProjectType]                NVARCHAR (200) NOT NULL,
    [CreatedOn]                  DATETIME       NULL,
    [CreatedByEmployeeId]        INT            NULL,
    [ModifiedOn]                 DATETIME       NULL,
    [ModifiedByEmployeeId]       INT            NULL,
    [MasterAccountProjectTypeId] SMALLINT       NULL,
    [IsDisabled]                 BIT            CONSTRAINT [DF_AccountProjectType_IsDisabled] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ProjectType] PRIMARY KEY CLUSTERED ([AccountProjectTypeId] ASC),
    CONSTRAINT [FK_AccountProjectType_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountProjectType]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_35583265_2_9_1_3]
    ON [dbo].[AccountProjectType]([AccountId], [IsDisabled], [AccountProjectTypeId], [ProjectType]);


GO
CREATE STATISTICS [_dta_stat_35583265_9_1_3]
    ON [dbo].[AccountProjectType]([IsDisabled], [AccountProjectTypeId], [ProjectType]);


GO
CREATE STATISTICS [_dta_stat_35583265_3_1_2]
    ON [dbo].[AccountProjectType]([ProjectType], [AccountProjectTypeId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_35583265_1_2]
    ON [dbo].[AccountProjectType]([AccountProjectTypeId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_35583265_3_2]
    ON [dbo].[AccountProjectType]([ProjectType], [AccountId]);

