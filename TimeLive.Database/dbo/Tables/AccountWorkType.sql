CREATE TABLE [dbo].[AccountWorkType] (
    [AccountWorkTypeId]    INT            IDENTITY (1, 1) NOT NULL,
    [AccountWorkTypeCode]  NVARCHAR (6)   NOT NULL,
    [AccountWorkType]      NVARCHAR (100) NOT NULL,
    [SystemWorkTypeId]     INT            NULL,
    [AccountId]            INT            NOT NULL,
    [CreatedOn]            DATETIME       NOT NULL,
    [CreatedByEmployeeId]  INT            NOT NULL,
    [ModifiedOn]           DATETIME       NOT NULL,
    [ModifiedByEmployeeId] INT            NOT NULL,
    [IsDisabled]           BIT            NOT NULL,
    [SortOrder]            SMALLINT       NULL,
    CONSTRAINT [PK_AccountWorkType] PRIMARY KEY CLUSTERED ([AccountWorkTypeId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountWorkType_10_1834541669__K1_3]
    ON [dbo].[AccountWorkType]([AccountWorkTypeId] ASC, [AccountWorkType] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountWorkType_10_755585830__K5_1_2_3_4_6_7_8_9_10]
    ON [dbo].[AccountWorkType]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_755585830_3_1]
    ON [dbo].[AccountWorkType]([AccountWorkType], [AccountWorkTypeId]);


GO
CREATE STATISTICS [_dta_stat_755585830_2_1]
    ON [dbo].[AccountWorkType]([AccountWorkTypeCode], [AccountWorkTypeId]);

