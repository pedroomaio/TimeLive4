CREATE TABLE [dbo].[AccountWorkingDay] (
    [AccountWorkingDayId]     INT              IDENTITY (1, 1) NOT NULL,
    [AccountId]               INT              NOT NULL,
    [WorkingDayNo]            TINYINT          NOT NULL,
    [AccountWorkingDayTypeId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_AccountWorkingDay] PRIMARY KEY CLUSTERED ([AccountWorkingDayId] ASC),
    CONSTRAINT [FK_AccountWorkingDay_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountWorkingDay_AccountWorkingDayType] FOREIGN KEY ([AccountWorkingDayTypeId]) REFERENCES [dbo].[AccountWorkingDayType] ([AccountWorkingDayTypeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountWorkingDay_10_397244470__K2_K4_K3_1]
    ON [dbo].[AccountWorkingDay]([AccountId] ASC, [AccountWorkingDayTypeId] ASC, [WorkingDayNo] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountWorkingDay_5_397244470__K4_K1_K3]
    ON [dbo].[AccountWorkingDay]([AccountWorkingDayTypeId] ASC, [AccountWorkingDayId] ASC, [WorkingDayNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountWorkingDayTypeId]
    ON [dbo].[AccountWorkingDay]([AccountWorkingDayTypeId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountWorkingDay]
    ON [dbo].[AccountWorkingDay]([AccountId] ASC, [WorkingDayNo] ASC, [AccountWorkingDayTypeId] ASC);


GO
CREATE STATISTICS [_dta_stat_397244470_3_4]
    ON [dbo].[AccountWorkingDay]([WorkingDayNo], [AccountWorkingDayTypeId]);

