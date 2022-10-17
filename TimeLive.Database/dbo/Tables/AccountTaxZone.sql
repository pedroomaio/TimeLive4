CREATE TABLE [dbo].[AccountTaxZone] (
    [AccountTaxZoneId]     INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]            INT            NOT NULL,
    [AccountTaxZone]       NVARCHAR (100) NOT NULL,
    [CreatedOn]            DATETIME       CONSTRAINT [DF_AccountTaxZone_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]  INT            NOT NULL,
    [ModifiedOn]           DATETIME       CONSTRAINT [DF_AccountTaxZone_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId] INT            NOT NULL,
    [IsDisabled]           BIT            CONSTRAINT [DF_AccountTaxZone_IsDisabled] DEFAULT ((0)) NOT NULL,
    [MasterTaxZoneId]      SMALLINT       NULL,
    CONSTRAINT [PK_AccountTaxZone] PRIMARY KEY CLUSTERED ([AccountTaxZoneId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountTaxZone]
    ON [dbo].[AccountTaxZone]([AccountId] ASC, [AccountTaxZone] ASC);

