CREATE TABLE [dbo].[AccountLocation] (
    [AccountLocationId]    INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]            INT            NOT NULL,
    [AccountLocation]      NVARCHAR (100) NOT NULL,
    [CreatedOn]            SMALLDATETIME  CONSTRAINT [DF_AccountLocation_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]  INT            CONSTRAINT [DF_AccountLocation_CreatedByEmployeeId] DEFAULT ((0)) NOT NULL,
    [ModifiedOn]           SMALLDATETIME  CONSTRAINT [DF_AccountLocation_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId] INT            CONSTRAINT [DF_AccountLocation_ModifiedByEmployeeId] DEFAULT ((0)) NOT NULL,
    [IsDisabled]           BIT            CONSTRAINT [DF_AccountLocation_IsDisabled] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccountLocation] PRIMARY KEY CLUSTERED ([AccountLocationId] ASC),
    CONSTRAINT [FK_AccountLocation_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountLocation]
    ON [dbo].[AccountLocation]([AccountLocationId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountLocation]([AccountId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountLocation', @level2type = N'COLUMN', @level2name = N'ModifiedByEmployeeId';

