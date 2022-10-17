CREATE TABLE [dbo].[AccountPartyContact] (
    [AccountPartyContactId]    INT            IDENTITY (1, 1) NOT NULL,
    [AccountPartyId]           INT            NOT NULL,
    [FirstName]                NVARCHAR (100) NOT NULL,
    [LastName]                 NVARCHAR (100) NOT NULL,
    [Telephone1]               NVARCHAR (50)  NULL,
    [Telephone2]               NVARCHAR (50)  NULL,
    [Fax]                      NVARCHAR (50)  NULL,
    [EMailAddress]             NVARCHAR (100) NULL,
    [State]                    NVARCHAR (40)  NULL,
    [City]                     NVARCHAR (100) NULL,
    [Zip]                      NVARCHAR (20)  NULL,
    [CountryId]                SMALLINT       NULL,
    [Address1]                 NVARCHAR (300) NULL,
    [Address2]                 NVARCHAR (300) NULL,
    [AccountPartyDepartmentId] INT            NULL,
    [Location]                 NVARCHAR (50)  NULL,
    CONSTRAINT [PK_AccountPartyContact] PRIMARY KEY CLUSTERED ([AccountPartyContactId] ASC),
    CONSTRAINT [FK_AccountPartyContact_AccountParty] FOREIGN KEY ([AccountPartyId]) REFERENCES [dbo].[AccountParty] ([AccountPartyId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CountryId]
    ON [dbo].[AccountPartyContact]([CountryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPartyDepartmentId]
    ON [dbo].[AccountPartyContact]([AccountPartyDepartmentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPartyId]
    ON [dbo].[AccountPartyContact]([AccountPartyId] ASC);

