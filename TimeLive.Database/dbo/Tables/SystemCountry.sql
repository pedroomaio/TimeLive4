CREATE TABLE [dbo].[SystemCountry] (
    [CountryId]      SMALLINT       NOT NULL,
    [Country]        NVARCHAR (100) NOT NULL,
    [Abbreviation]   NVARCHAR (4)   NOT NULL,
    [IsStateCountry] BIT            CONSTRAINT [DF_SystemCountry_IsStateCountry] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tblCountry] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

