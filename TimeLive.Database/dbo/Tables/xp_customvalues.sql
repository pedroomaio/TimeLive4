CREATE TABLE [dbo].[xp_customvalues] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [value]       FLOAT (53)   NOT NULL,
    [description] VARCHAR (50) NOT NULL,
    [year]        INT          NOT NULL,
    CONSTRAINT [PK_xp_customvalues] PRIMARY KEY CLUSTERED ([id] ASC)
);

