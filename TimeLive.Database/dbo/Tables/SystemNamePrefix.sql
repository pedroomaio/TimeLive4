CREATE TABLE [dbo].[SystemNamePrefix] (
    [SystemNamePrefix] NVARCHAR (10) NOT NULL,
    [Sequence]         TINYINT       NULL,
    CONSTRAINT [PK_SystemNamePrefix] PRIMARY KEY CLUSTERED ([SystemNamePrefix] ASC)
);

