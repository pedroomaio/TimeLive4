CREATE TABLE [dbo].[SystemPartyType] (
    [SystemPartyTypeId] SMALLINT       NOT NULL,
    [SystemPartyType]   NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblPartyType] PRIMARY KEY CLUSTERED ([SystemPartyTypeId] ASC)
);

