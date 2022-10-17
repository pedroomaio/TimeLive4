CREATE TABLE [dbo].[MasterHolidayTypeDetail] (
    [MasterHolidayTypeId]       UNIQUEIDENTIFIER NOT NULL,
    [MasterHolidayTypeDetailId] UNIQUEIDENTIFIER CONSTRAINT [DF_MasterHolidayTypeDetail_MasterHolidayTypeDetailId] DEFAULT (newid()) NOT NULL,
    [HolidayName]               NVARCHAR (50)    NULL,
    [HolidayMonth]              INT              NULL,
    [HolidayDay]                INT              NULL,
    CONSTRAINT [PK_MasterHolidayTypeDetail_1] PRIMARY KEY CLUSTERED ([MasterHolidayTypeDetailId] ASC)
);

