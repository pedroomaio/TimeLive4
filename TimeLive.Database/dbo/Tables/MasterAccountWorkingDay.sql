CREATE TABLE [dbo].[MasterAccountWorkingDay] (
    [MasterAccountWorkingDayId] SMALLINT NOT NULL,
    [TemplateId]                SMALLINT NOT NULL,
    [WorkingDayNo]              TINYINT  NOT NULL,
    CONSTRAINT [PK_MasterAccountWorkingDay] PRIMARY KEY CLUSTERED ([MasterAccountWorkingDayId] ASC)
);

