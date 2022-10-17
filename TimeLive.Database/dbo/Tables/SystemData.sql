CREATE TABLE [dbo].[SystemData] (
    [SystemDataId] INT           IDENTITY (1, 1) NOT NULL,
    [Version]      NVARCHAR (50) NULL,
    CONSTRAINT [PK_SystemData] PRIMARY KEY CLUSTERED ([SystemDataId] ASC)
);

