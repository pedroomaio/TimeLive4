CREATE TABLE [dbo].[xp_users] (
    [id_user]  INT          IDENTITY (1, 1) NOT NULL,
    [UserName] VARCHAR (50) NULL,
    CONSTRAINT [PK_xp_users] PRIMARY KEY CLUSTERED ([id_user] ASC)
);

