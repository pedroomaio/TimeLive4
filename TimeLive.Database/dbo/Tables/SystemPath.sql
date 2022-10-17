CREATE TABLE [dbo].[SystemPath] (
    [SystemPathId]          INT            IDENTITY (1, 1) NOT NULL,
    [SystemPath]            NVARCHAR (200) NOT NULL,
    [SystemPathDescription] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_SystemPath] PRIMARY KEY CLUSTERED ([SystemPathId] ASC)
);

