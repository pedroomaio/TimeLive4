CREATE TABLE [dbo].[SystemLicense] (
    [SystemLicenseId]  UNIQUEIDENTIFIER CONSTRAINT [DF_SystemLicense_SystemLicenseId] DEFAULT (newid()) NOT NULL,
    [PackageName]      NVARCHAR (100)   NULL,
    [PackageCode]      NVARCHAR (100)   NULL,
    [NumberOfUsers]    BIGINT           NULL,
    [Version]          BIGINT           NULL,
    [ProductCode]      BIGINT           NULL,
    [IsTrakLive]       BIT              NULL,
    [IsCurrentVersion] BIT              NULL,
    [SortOrder]        INT              NULL,
    CONSTRAINT [PK_SystemLicense] PRIMARY KEY CLUSTERED ([SystemLicenseId] ASC)
);

