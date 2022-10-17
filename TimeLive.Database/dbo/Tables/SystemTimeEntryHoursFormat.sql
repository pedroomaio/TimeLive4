CREATE TABLE [dbo].[SystemTimeEntryHoursFormat] (
    [SystemTimeEntryHoursFormatId] UNIQUEIDENTIFIER CONSTRAINT [DF_SystemTimeEntryHoursFormat_SystemTimeEntryHoursFormatId] DEFAULT (newid()) NOT NULL,
    [SystemTimeEntryHoursFormat]   NVARCHAR (50)    NULL,
    CONSTRAINT [PK_SystemTimeEntryHoursFormat] PRIMARY KEY CLUSTERED ([SystemTimeEntryHoursFormatId] ASC)
);

