CREATE TABLE [dbo].[SystemTimeZone] (
    [SystemTimeZoneId]   TINYINT        NOT NULL,
    [TimeZoneDifference] NVARCHAR (255) NOT NULL,
    [TimeZone]           NVARCHAR (255) NOT NULL,
    [TimeZoneCode]       NVARCHAR (50)  NULL,
    CONSTRAINT [PK_SystemTimeZone] PRIMARY KEY CLUSTERED ([SystemTimeZoneId] ASC)
);

