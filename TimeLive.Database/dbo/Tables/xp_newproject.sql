CREATE TABLE [dbo].[xp_newproject] (
    [oldcode] NVARCHAR (50)  NOT NULL,
    [newcode] NVARCHAR (50)  NOT NULL,
    [newname] NVARCHAR (100) NOT NULL,
    [active]  BIT            NOT NULL
);

