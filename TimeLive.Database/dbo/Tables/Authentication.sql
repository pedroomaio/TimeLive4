CREATE TABLE [dbo].[Authentication] (
    [AuthenticationSettingId]       INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]                     INT            NOT NULL,
    [ActiveDirectoryAuthentication] BIT            CONSTRAINT [DF_Authentication_ActiveDirectoryAuthentication] DEFAULT ((0)) NOT NULL,
    [Domain]                        NVARCHAR (100) NOT NULL,
    [DirectoryName]                 NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Authentication] PRIMARY KEY CLUSTERED ([AuthenticationSettingId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[Authentication]([AccountId] ASC);

