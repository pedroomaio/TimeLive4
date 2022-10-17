CREATE TABLE [dbo].[SystemInitialDaysOfThePeriod] (
    [SystemInitialDaysOfThePeriodId] SMALLINT      NOT NULL,
    [SystemInitialDaysOfThePeriod]   NVARCHAR (20) NOT NULL,
    [SystemInitialDayOfFirstPeriod]  SMALLINT      NOT NULL,
    [SystemInitialDayOfLastPeriod]   SMALLINT      NOT NULL,
    CONSTRAINT [PK_SystemInitialDaysOfThePeriod] PRIMARY KEY CLUSTERED ([SystemInitialDaysOfThePeriodId] ASC)
);

