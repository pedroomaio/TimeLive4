CREATE TABLE [dbo].[AccountAbsenceType] (
    [AccountAbsenceTypeId]       INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]                  INT            NOT NULL,
    [AbsenceDescription]         NVARCHAR (100) NOT NULL,
    [CreatedOn]                  DATETIME       CONSTRAINT [DF_AccountAbsenceType_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]        INT            NOT NULL,
    [ModifiedOn]                 DATETIME       CONSTRAINT [DF_AccountAbsenceType_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]       INT            NOT NULL,
    [MasterAccountAbsenceTypeId] SMALLINT       NULL,
    [IsDisabled]                 BIT            CONSTRAINT [DF_AccountAbsenceType_IsDisabled] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AbsenseType] PRIMARY KEY CLUSTERED ([AccountAbsenceTypeId] ASC),
    CONSTRAINT [FK_AccountAbsenceType_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountAbsenceType]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_1098539047_1_2_3]
    ON [dbo].[AccountAbsenceType]([AccountAbsenceTypeId], [AccountId], [AbsenceDescription]);


GO
CREATE STATISTICS [_dta_stat_1098539047_2_9_1]
    ON [dbo].[AccountAbsenceType]([AccountId], [IsDisabled], [AccountAbsenceTypeId]);


GO
CREATE STATISTICS [_dta_stat_1098539047_9_1]
    ON [dbo].[AccountAbsenceType]([IsDisabled], [AccountAbsenceTypeId]);


GO
CREATE STATISTICS [_dta_stat_1098539047_3_2]
    ON [dbo].[AccountAbsenceType]([AbsenceDescription], [AccountId]);

