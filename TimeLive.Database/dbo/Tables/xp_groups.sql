CREATE TABLE [dbo].[xp_groups] (
    [id_group]  INT          IDENTITY (1, 1) NOT NULL,
    [GroupName] VARCHAR (50) NULL,
    CONSTRAINT [PK_xp_groups] PRIMARY KEY CLUSTERED ([id_group] ASC)
);

