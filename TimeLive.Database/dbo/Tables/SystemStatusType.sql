CREATE TABLE [dbo].[SystemStatusType] (
    [SystemStatusTypeId] TINYINT       NOT NULL,
    [SystemStatusType]   NVARCHAR (90) NOT NULL,
    CONSTRAINT [PK_SystemStatusType] PRIMARY KEY CLUSTERED ([SystemStatusTypeId] ASC)
);

