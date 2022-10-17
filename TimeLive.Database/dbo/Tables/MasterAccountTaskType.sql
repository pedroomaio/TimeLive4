CREATE TABLE [dbo].[MasterAccountTaskType] (
    [MasterAccountTaskTypeId] SMALLINT       NOT NULL,
    [TemplateId]              SMALLINT       NOT NULL,
    [TaskType]                NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_MasterAccountTaskType] PRIMARY KEY CLUSTERED ([MasterAccountTaskTypeId] ASC)
);

