CREATE TABLE [dbo].[MasterHolidayType] (
    [MasterHolidayTypeId] UNIQUEIDENTIFIER CONSTRAINT [DF_MasterHolidayType_AccountHolidayTypeId] DEFAULT (newid()) NOT NULL,
    [HolidayType]         NVARCHAR (50)    NULL,
    CONSTRAINT [PK_MasterHolidayType] PRIMARY KEY CLUSTERED ([MasterHolidayTypeId] ASC)
);

