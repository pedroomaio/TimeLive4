CREATE TABLE [dbo].[SystemModuleFields] (
    [SystemModuleFieldId]          UNIQUEIDENTIFIER CONSTRAINT [DF_SystemModuleFields_SystemModuleFieldId] DEFAULT (newid()) NOT NULL,
    [SystemModuleId]               UNIQUEIDENTIFIER NOT NULL,
    [SystemModuleFieldName]        NVARCHAR (100)   NOT NULL,
    [SystemModuleFieldDisplayName] NVARCHAR (100)   NOT NULL,
    [IsDefaultAdd]                 BIT              NOT NULL,
    [SystemModuleFieldWidth]       NVARCHAR (100)   NOT NULL,
    [IsRequired]                   BIT              NULL,
    [SystemFieldsSortOrder]        INT              NULL,
    CONSTRAINT [PK_SystemModuleFields] PRIMARY KEY CLUSTERED ([SystemModuleFieldId] ASC)
);

