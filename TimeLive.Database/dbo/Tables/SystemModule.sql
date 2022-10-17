CREATE TABLE [dbo].[SystemModule] (
    [SystemModuleId]   UNIQUEIDENTIFIER CONSTRAINT [DF_SystemModule_SystemModuleId] DEFAULT (newid()) NOT NULL,
    [SystemModuleName] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_SystemModule] PRIMARY KEY CLUSTERED ([SystemModuleId] ASC)
);

