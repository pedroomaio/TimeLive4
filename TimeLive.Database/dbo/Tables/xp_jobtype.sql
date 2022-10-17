CREATE TABLE [dbo].[xp_jobtype] (
    [id]    NUMERIC (18)    NOT NULL,
    [name]  NVARCHAR (50)   NULL,
    [units] NUMERIC (10, 2) NULL,
    CONSTRAINT [PK_xp_jobtype] PRIMARY KEY CLUSTERED ([id] ASC)
);

