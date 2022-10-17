CREATE TABLE [dbo].[SystemEMailNotificationType] (
    [SystemEMailNotificationTypeId] SMALLINT       NOT NULL,
    [SystemEMailNotificationType]   NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_SystemEMailNotificationType] PRIMARY KEY CLUSTERED ([SystemEMailNotificationTypeId] ASC)
);

