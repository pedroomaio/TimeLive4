CREATE TABLE [dbo].[MasterEntityType] (
    [MasterEntityTypeId]   UNIQUEIDENTIFIER CONSTRAINT [DF_MasterEntityType_MasterEntityTypeId] DEFAULT (newid()) NOT NULL,
    [MasterEntityTypeName] NVARCHAR (200)   NOT NULL,
    [SystemFeatureId]      UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_MasterEntityType] PRIMARY KEY CLUSTERED ([MasterEntityTypeId] ASC)
);

