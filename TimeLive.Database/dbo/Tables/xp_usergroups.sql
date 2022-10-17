CREATE TABLE [dbo].[xp_usergroups] (
    [id_user]  INT NOT NULL,
    [id_group] INT NOT NULL,
    CONSTRAINT [PK_xp_usergroups] PRIMARY KEY CLUSTERED ([id_group] ASC, [id_user] ASC),
    CONSTRAINT [FK_xp_usergroup_xp_groups] FOREIGN KEY ([id_group]) REFERENCES [dbo].[xp_groups] ([id_group]),
    CONSTRAINT [FK_xp_usergroups_xp_users] FOREIGN KEY ([id_user]) REFERENCES [dbo].[xp_users] ([id_user])
);

