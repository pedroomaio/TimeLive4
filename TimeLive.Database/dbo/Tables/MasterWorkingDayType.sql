CREATE TABLE [dbo].[MasterWorkingDayType] (
    [MasterWorkingDayTypeId]   UNIQUEIDENTIFIER CONSTRAINT [DF_MasterWorkingDayType_MasterWorkingDayTypeId] DEFAULT (newid()) NOT NULL,
    [MasterWorkingDayType]     NVARCHAR (500)   NOT NULL,
    [WeekStartDay]             TINYINT          NOT NULL,
    [MinimumHoursPerDay]       FLOAT (53)       NOT NULL,
    [MaximumHoursPerDay]       FLOAT (53)       NOT NULL,
    [MinimumHoursPerWeek]      FLOAT (53)       NOT NULL,
    [MaximumHoursPerWeek]      FLOAT (53)       NOT NULL,
    [HoursPerDay]              FLOAT (53)       NOT NULL,
    [MinimumPercentagePerDay]  INT              NULL,
    [MaximumPercentagePerDay]  INT              NULL,
    [MinimumPercentagePerWeek] INT              NULL,
    [MaximumPercentagePerWeek] INT              NULL,
    CONSTRAINT [PK_MasterWorkingDayType] PRIMARY KEY CLUSTERED ([MasterWorkingDayTypeId] ASC)
);

