CREATE TABLE [dbo].[SystemFilterModule] (
    [SystemFilterModuleId]   UNIQUEIDENTIFIER CONSTRAINT [DF_SystemFilterModule_SystemFilterModuleId] DEFAULT (newid()) NOT NULL,
    [SystemFilterModuleName] NVARCHAR (200)   NOT NULL,
    CONSTRAINT [PK_SystemFilterModule] PRIMARY KEY CLUSTERED ([SystemFilterModuleId] ASC)
);

