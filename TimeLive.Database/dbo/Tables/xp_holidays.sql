CREATE TABLE [dbo].[xp_holidays] (
    [Date]        DATETIME      NOT NULL,
    [Description] VARCHAR (50)  NOT NULL,
    [country]     CHAR (2)      DEFAULT ('PT') NOT NULL,
    [city]        VARCHAR (255) DEFAULT ('--') NOT NULL
);

