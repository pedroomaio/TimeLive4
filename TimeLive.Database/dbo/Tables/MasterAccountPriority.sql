CREATE TABLE [dbo].[MasterAccountPriority] (
    [MasterAccountPriorityId] TINYINT        NOT NULL,
    [TemplateId]              TINYINT        NOT NULL,
    [Priority]                NVARCHAR (100) NOT NULL,
    [PriorityOrder]           TINYINT        NOT NULL,
    CONSTRAINT [PK_MasterAccountPriority] PRIMARY KEY CLUSTERED ([MasterAccountPriorityId] ASC)
);

