CREATE TABLE [dbo].[MasterCustomDataType] (
    [MasterCustomDataTypeId]   UNIQUEIDENTIFIER CONSTRAINT [DF_MasterCustomDataType_MasterCustomDataTypeId] DEFAULT (newid()) NOT NULL,
    [MasterCustomDataTypeName] NVARCHAR (200)   NOT NULL,
    CONSTRAINT [PK_MasterCustomDataType] PRIMARY KEY CLUSTERED ([MasterCustomDataTypeId] ASC)
);

