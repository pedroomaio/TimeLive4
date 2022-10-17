CREATE TABLE [dbo].[SystemWorkType] (
    [SystemWorkTypeId]   INT            NOT NULL,
    [SystemWorkTypeCode] NVARCHAR (6)   NOT NULL,
    [SystemWorkType]     NVARCHAR (100) NULL,
    [SystemSortOrder]    SMALLINT       NULL,
    CONSTRAINT [PK_SystemWorkType] PRIMARY KEY CLUSTERED ([SystemWorkTypeId] ASC)
);

