CREATE TABLE [dbo].[AccountHolidayType] (
    [AccountId]            INT              NULL,
    [AccountHolidayTypeId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountHolidayType_AccountHolidayTypeId] DEFAULT (newid()) NOT NULL,
    [MasterHolidayTypeId]  UNIQUEIDENTIFIER NULL,
    [AccountHolidayType]   NVARCHAR (50)    NULL,
    [IsDisabled]           BIT              NULL,
    [CreatedOn]            DATETIME         NULL,
    [CreatedByEmployeeId]  INT              NULL,
    [ModifiedOn]           DATETIME         NULL,
    [ModifiedByEmployeeId] INT              NULL,
    CONSTRAINT [PK_AccountHolidayType] PRIMARY KEY CLUSTERED ([AccountHolidayTypeId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IXX_AccountId]
    ON [dbo].[AccountHolidayType]([AccountId] ASC);

