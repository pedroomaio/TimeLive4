CREATE TABLE [dbo].[MasterAccountPreferences] (
    [MasterAccountPreferencesId]     INT           NOT NULL,
    [AccountTemplateId]              INT           NOT NULL,
    [ShowClockInClockOut]            BIT           CONSTRAINT [DF_MasterAccountPreferences_ShowClockInClockOut] DEFAULT ((0)) NOT NULL,
    [CultureInfoName]                NVARCHAR (40) NULL,
    [AccountBaseCurrencyId]          INT           NULL,
    [AccountReimbursementCurrencyId] INT           NULL,
    CONSTRAINT [PK_MasterAccountPreferences] PRIMARY KEY CLUSTERED ([MasterAccountPreferencesId] ASC)
);

