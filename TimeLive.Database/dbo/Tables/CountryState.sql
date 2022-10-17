CREATE TABLE [dbo].[CountryState] (
    [CountryStateId]    SMALLINT      IDENTITY (1, 1) NOT NULL,
    [CountryId]         SMALLINT      NOT NULL,
    [State]             NVARCHAR (50) NOT NULL,
    [StateAbbreviation] NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_CountryState] PRIMARY KEY CLUSTERED ([CountryStateId] ASC)
);

