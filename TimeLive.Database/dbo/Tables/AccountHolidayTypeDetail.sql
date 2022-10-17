CREATE TABLE [dbo].[AccountHolidayTypeDetail] (
    [AccountHolidayTypeDetailId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountHolidayTypeDetail_AccountHolidayTypeDetailId] DEFAULT (newid()) NOT NULL,
    [AccountHolidayTypeId]       UNIQUEIDENTIFIER NOT NULL,
    [MasterHolidayTypeDetailId]  UNIQUEIDENTIFIER NULL,
    [HolidayName]                NVARCHAR (50)    NULL,
    [HolidayDate]                DATETIME         NULL,
    [AccountId]                  INT              NULL,
    [CreatedOn]                  DATETIME         NULL,
    [CreatedByEmployeeId]        INT              NULL,
    [ModifiedOn]                 DATETIME         NULL,
    [ModifiedByEmployeeId]       INT              NULL,
    CONSTRAINT [PK_AccountHolidayTypeDetail] PRIMARY KEY CLUSTERED ([AccountHolidayTypeDetailId] ASC),
    CONSTRAINT [FK_AccountHolidayTypeDetail_AccountHolidayType] FOREIGN KEY ([AccountHolidayTypeId]) REFERENCES [dbo].[AccountHolidayType] ([AccountHolidayTypeId]) ON DELETE CASCADE
);

