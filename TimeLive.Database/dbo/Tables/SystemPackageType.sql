CREATE TABLE [dbo].[SystemPackageType] (
    [SystemPackageTypeId] TINYINT        NOT NULL,
    [SystemPackageType]   NVARCHAR (100) NOT NULL,
    [StoreCode]           NVARCHAR (100) NULL,
    [SKUReference]        NVARCHAR (100) NULL,
    [SKUId]               NVARCHAR (100) NULL,
    [IsHosted]            BIT            NULL,
    CONSTRAINT [PK_SystemPackageType] PRIMARY KEY CLUSTERED ([SystemPackageTypeId] ASC)
);

