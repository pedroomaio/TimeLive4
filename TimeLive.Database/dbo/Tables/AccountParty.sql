CREATE TABLE [dbo].[AccountParty] (
    [AccountPartyId]       INT             IDENTITY (1, 1) NOT NULL,
    [PartyTypeId]          SMALLINT        NOT NULL,
    [AccountId]            INT             NOT NULL,
    [PartyName]            NVARCHAR (400)  NOT NULL,
    [PartyNick]            NVARCHAR (100)  NOT NULL,
    [EMailAddress]         NVARCHAR (100)  NULL,
    [Address1]             NVARCHAR (500)  NULL,
    [Address2]             NVARCHAR (500)  NULL,
    [CountryId]            SMALLINT        NULL,
    [State]                NVARCHAR (50)   NULL,
    [City]                 NVARCHAR (100)  NULL,
    [ZipCode]              NVARCHAR (100)  NULL,
    [Telephone1]           NVARCHAR (100)  NULL,
    [Telephone2]           NVARCHAR (100)  NULL,
    [Fax]                  NVARCHAR (100)  NULL,
    [DefaultCurrencyId]    SMALLINT        NULL,
    [DefaultBillingRate]   MONEY           NULL,
    [Website]              NVARCHAR (200)  NULL,
    [Notes]                NVARCHAR (1000) NULL,
    [IsDisabled]           BIT             CONSTRAINT [DF_AccountParty_IsDisabled] DEFAULT ((0)) NOT NULL,
    [IsDeleted]            BIT             NOT NULL,
    [CreatedOn]            DATETIME        CONSTRAINT [DF_AccountParty_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]  INT             NOT NULL,
    [ModifiedOn]           DATETIME        CONSTRAINT [DF_AccountParty_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId] INT             NOT NULL,
    [CustomField1]         NVARCHAR (2000) NULL,
    [CustomField2]         NVARCHAR (2000) NULL,
    [CustomField3]         NVARCHAR (2000) NULL,
    [CustomField4]         NVARCHAR (2000) NULL,
    [CustomField5]         NVARCHAR (2000) NULL,
    [CustomField6]         NVARCHAR (2000) NULL,
    [CustomField7]         NVARCHAR (2000) NULL,
    [CustomField8]         NVARCHAR (2000) NULL,
    [CustomField9]         NVARCHAR (2000) NULL,
    [CustomField10]        NVARCHAR (2000) NULL,
    [CustomField11]        NVARCHAR (2000) NULL,
    [CustomField12]        NVARCHAR (2000) NULL,
    [CustomField13]        NVARCHAR (2000) NULL,
    [CustomField14]        NVARCHAR (2000) NULL,
    [CustomField15]        NVARCHAR (2000) NULL,
    [FixedBidBillingMode]  INT             NULL,
    [FixedCost]            FLOAT (53)      NULL,
    CONSTRAINT [PK_tblParty] PRIMARY KEY CLUSTERED ([AccountPartyId] ASC),
    CONSTRAINT [FK_AccountParty_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountParty_SystemCountry] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[SystemCountry] ([CountryId]),
    CONSTRAINT [FK_AccountParty_SystemPartyType] FOREIGN KEY ([PartyTypeId]) REFERENCES [dbo].[SystemPartyType] ([SystemPartyTypeId])
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountParty_10_756405964__K1_4]
    ON [dbo].[AccountParty]([AccountPartyId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountParty_10_756405964__K1_K4]
    ON [dbo].[AccountParty]([AccountPartyId] ASC, [PartyName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PartyTypeId]
    ON [dbo].[AccountParty]([PartyTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountParty]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_756405964_1_9_3_4]
    ON [dbo].[AccountParty]([AccountPartyId], [CountryId], [AccountId], [PartyName]);


GO
CREATE STATISTICS [_dta_stat_756405964_3_20_1_4]
    ON [dbo].[AccountParty]([AccountId], [IsDisabled], [AccountPartyId], [PartyName]);


GO
CREATE STATISTICS [_dta_stat_756405964_1_20_4]
    ON [dbo].[AccountParty]([AccountPartyId], [IsDisabled], [PartyName]);


GO
CREATE STATISTICS [_dta_stat_756405964_4_1_3]
    ON [dbo].[AccountParty]([PartyName], [AccountPartyId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_756405964_1_9_4]
    ON [dbo].[AccountParty]([AccountPartyId], [CountryId], [PartyName]);


GO
CREATE STATISTICS [_dta_stat_756405964_1_3]
    ON [dbo].[AccountParty]([AccountPartyId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_756405964_4_3]
    ON [dbo].[AccountParty]([PartyName], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_756405964_20_1]
    ON [dbo].[AccountParty]([IsDisabled], [AccountPartyId]);

