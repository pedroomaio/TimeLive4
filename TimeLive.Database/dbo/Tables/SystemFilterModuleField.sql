CREATE TABLE [dbo].[SystemFilterModuleField] (
    [SystemFilterModuleFieldId]      UNIQUEIDENTIFIER CONSTRAINT [DF_SystemFilterModuleField_SystemFilterModuleFieldId] DEFAULT (newid()) NOT NULL,
    [SystemFilterModuleId]           UNIQUEIDENTIFIER NOT NULL,
    [SystemFilterModuleFieldName]    NVARCHAR (200)   NOT NULL,
    [IsGridViewFilter]               BIT              NOT NULL,
    [SystemFilterModuleFieldCaption] NVARCHAR (200)   NULL,
    CONSTRAINT [PK_SystemFilterModuleField] PRIMARY KEY CLUSTERED ([SystemFilterModuleFieldId] ASC)
);

