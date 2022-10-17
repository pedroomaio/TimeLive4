CREATE TABLE [dbo].[AccountEmployeeType] (
    [AccountEmployeeTypeId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountEmployeeType_AccountEmployeeTypeId] DEFAULT (newid()) NOT NULL,
    [AccountEmployeeType]   NVARCHAR (100)   NOT NULL,
    [AccountId]             INT              NOT NULL,
    [CreatedOn]             DATETIME         CONSTRAINT [DF_AccountEmployeeType_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]   INT              NOT NULL,
    [ModifiedOn]            DATETIME         CONSTRAINT [DF_AccountEmployeeType_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]  INT              NOT NULL,
    [IsDisabled]            BIT              CONSTRAINT [DF_AccountEmployeeType_IsDisabled] DEFAULT ((0)) NOT NULL,
    [MasterEmployeeTypeId]  UNIQUEIDENTIFIER NULL,
    [IsVendor]              BIT              NULL,
    CONSTRAINT [PK_AccountEmployeeType] PRIMARY KEY CLUSTERED ([AccountEmployeeTypeId] ASC)
);


GO
CREATE STATISTICS [_dta_stat_219303991_3_8_1_2]
    ON [dbo].[AccountEmployeeType]([AccountId], [IsDisabled], [AccountEmployeeTypeId], [AccountEmployeeType]);


GO
CREATE STATISTICS [_dta_stat_219303991_1_8_2]
    ON [dbo].[AccountEmployeeType]([AccountEmployeeTypeId], [IsDisabled], [AccountEmployeeType]);


GO
CREATE STATISTICS [_dta_stat_219303991_3_1_2]
    ON [dbo].[AccountEmployeeType]([AccountId], [AccountEmployeeTypeId], [AccountEmployeeType]);


GO
CREATE STATISTICS [_dta_stat_219303991_1_2]
    ON [dbo].[AccountEmployeeType]([AccountEmployeeTypeId], [AccountEmployeeType]);


GO
CREATE STATISTICS [_dta_stat_219303991_2_3]
    ON [dbo].[AccountEmployeeType]([AccountEmployeeType], [AccountId]);

