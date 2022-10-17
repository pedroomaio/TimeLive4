CREATE TABLE [dbo].[SystemModuleView] (
    [SystemModuleViewId]   UNIQUEIDENTIFIER CONSTRAINT [DF_SystemModuleView_SystemModuleViewId] DEFAULT (newid()) NOT NULL,
    [SystemModuleViewName] NVARCHAR (200)   NOT NULL,
    [SystemModuleId]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_SystemModuleView] PRIMARY KEY CLUSTERED ([SystemModuleViewId] ASC)
);

