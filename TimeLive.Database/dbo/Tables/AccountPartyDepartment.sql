CREATE TABLE [dbo].[AccountPartyDepartment] (
    [AccountPartyDepartmentId] INT            IDENTITY (1, 1) NOT NULL,
    [AccountPartyId]           INT            NOT NULL,
    [PartyDepartmentCode]      NVARCHAR (100) NOT NULL,
    [PartyDepartmentName]      NVARCHAR (200) NOT NULL,
    [PartyDepartmentLocation]  NVARCHAR (400) NULL,
    CONSTRAINT [PK_AccountPartyDepartment] PRIMARY KEY CLUSTERED ([AccountPartyDepartmentId] ASC),
    CONSTRAINT [FK_AccountPartyDepartment_AccountParty] FOREIGN KEY ([AccountPartyId]) REFERENCES [dbo].[AccountParty] ([AccountPartyId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountPartyId]
    ON [dbo].[AccountPartyDepartment]([AccountPartyId] ASC);

