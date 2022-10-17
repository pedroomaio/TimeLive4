CREATE TABLE [dbo].[xp_vacationmap] (
    [employee] NVARCHAR (50) NOT NULL,
    [date]     DATETIME      NOT NULL,
    [type]     NVARCHAR (50) NULL,
    [version]  INT           NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [vacationmap_idx]
    ON [dbo].[xp_vacationmap]([employee] ASC, [date] ASC, [version] ASC);

