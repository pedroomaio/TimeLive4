CREATE TABLE [dbo].[SystemWorkingDay] (
    [WorkingDayNo]       TINYINT        NOT NULL,
    [WorkingDay]         NVARCHAR (100) NOT NULL,
    [SQLServerWeekDayNo] TINYINT        NULL,
    CONSTRAINT [PK_WorkingDay] PRIMARY KEY CLUSTERED ([WorkingDayNo] ASC)
);

