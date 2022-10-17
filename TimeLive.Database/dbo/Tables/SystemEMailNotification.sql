CREATE TABLE [dbo].[SystemEMailNotification] (
    [SystemEMailNotificationId]     SMALLINT         NOT NULL,
    [SystemEMailNotification]       NVARCHAR (100)   NOT NULL,
    [SystemEMailNotificationTypeId] SMALLINT         NOT NULL,
    [Enabled]                       BIT              NOT NULL,
    [IsWeekDayAllow]                BIT              NULL,
    [SystemFeatureId]               UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_SystemEMailNotification] PRIMARY KEY CLUSTERED ([SystemEMailNotificationId] ASC)
);

