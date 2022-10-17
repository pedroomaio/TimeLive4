CREATE TABLE [dbo].[MasterAccountProjectType] (
    [MasterAccountProjectTypeId] SMALLINT       NOT NULL,
    [ProjectType]                NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_MasterAccountProjectType] PRIMARY KEY CLUSTERED ([MasterAccountProjectTypeId] ASC)
);

