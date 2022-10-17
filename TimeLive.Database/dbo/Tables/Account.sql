CREATE TABLE [dbo].[Account] (
    [AccountId]               INT            IDENTITY (1, 1) NOT NULL,
    [AccountTypeId]           SMALLINT       NOT NULL,
    [AccountName]             NVARCHAR (500) NOT NULL,
    [Address1]                NVARCHAR (500) NULL,
    [Address2]                NVARCHAR (500) NULL,
    [ZipCode]                 NVARCHAR (100) NULL,
    [State]                   NVARCHAR (100) NULL,
    [City]                    NVARCHAR (100) NULL,
    [CountryId]               SMALLINT       NOT NULL,
    [EMailAddress]            NVARCHAR (100) NULL,
    [Telephone]               NVARCHAR (100) NULL,
    [Fax]                     NVARCHAR (100) NULL,
    [DefaultCurrencyId]       SMALLINT       NULL,
    [TimeZoneId]              TINYINT        NOT NULL,
    [IsDisabled]              BIT            NULL,
    [IsDeleted]               BIT            NULL,
    [StatusId]                SMALLINT       NULL,
    [LicenseKey]              NVARCHAR (100) NULL,
    [LicenseActivation]       NVARCHAR (200) NULL,
    [SystemPackageTypeId]     TINYINT        NULL,
    [AccountExpiry]           SMALLDATETIME  NULL,
    [AccountExpiryActivation] NVARCHAR (100) NULL,
    [CreatedOn]               DATETIME       CONSTRAINT [DF_Account_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]              DATETIME       CONSTRAINT [DF_Account_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]    INT            CONSTRAINT [DF_Account_ModifiedByEmployeeId] DEFAULT ((0)) NULL,
    [LicenseId]               NVARCHAR (100) NULL,
    [MachineId]               NVARCHAR (100) NULL,
    [ActivationLicenseKey]    NVARCHAR (100) NULL,
    [ActivationMachineKey]    NVARCHAR (100) NULL,
    [ActivationType]          NVARCHAR (100) NULL,
    [IsLock]                  BIT            NULL,
    [IsTrakLiveAccount]       BIT            NULL,
    [SubDomain]               NVARCHAR (200) NULL,
    [IsWizardSkip]            BIT            NULL,
    CONSTRAINT [PK_tblCompany] PRIMARY KEY CLUSTERED ([AccountId] ASC),
    CONSTRAINT [FK_Account_AccountType] FOREIGN KEY ([AccountTypeId]) REFERENCES [dbo].[AccountType] ([AccountTypeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Account_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[SystemCountry] ([CountryId]),
    CONSTRAINT [FK_Account_Currency] FOREIGN KEY ([DefaultCurrencyId]) REFERENCES [dbo].[SystemCurrency] ([CurrencyId]),
    CONSTRAINT [FK_Account_SystemTimeZone] FOREIGN KEY ([TimeZoneId]) REFERENCES [dbo].[SystemTimeZone] ([SystemTimeZoneId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountTypeId]
    ON [dbo].[Account]([AccountTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ModifiedByEmployeeId]
    ON [dbo].[Account]([ModifiedByEmployeeId] ASC);


GO
CREATE STATISTICS [_dta_stat_1390784162_15_1]
    ON [dbo].[Account]([IsDisabled], [AccountId]);

