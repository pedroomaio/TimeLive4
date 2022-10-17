CREATE TABLE [dbo].[AccountEMailNotificationPreference] (
    [AccountEMailNotificationPreferenceId]         INT      IDENTITY (1, 1) NOT NULL,
    [AccountId]                                    INT      NULL,
    [AccountProjectId]                             INT      NULL,
    [AccountEmployeeId]                            INT      NULL,
    [SystemEMailNotificationId]                    SMALLINT NOT NULL,
    [SystemEMailNotificationTypeId]                SMALLINT NOT NULL,
    [Enabled]                                      BIT      NOT NULL,
    [AccountEmailNotificationPreferenceTemplateId] INT      NULL,
    [Monday]                                       BIT      NULL,
    [Tuesday]                                      BIT      NULL,
    [Wednesday]                                    BIT      NULL,
    [Thursday]                                     BIT      NULL,
    [Friday]                                       BIT      NULL,
    [Saturday]                                     BIT      NULL,
    [Sunday]                                       BIT      NULL,
    CONSTRAINT [PK_AccountEMailNotificationPreference] PRIMARY KEY CLUSTERED ([AccountEMailNotificationPreferenceId] ASC),
    CONSTRAINT [FK_AccountEMailNotificationPreference_SystemEMailNotification] FOREIGN KEY ([SystemEMailNotificationId]) REFERENCES [dbo].[SystemEMailNotification] ([SystemEMailNotificationId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountEMailNotificationPreference_SystemEMailNotificationType] FOREIGN KEY ([SystemEMailNotificationTypeId]) REFERENCES [dbo].[SystemEMailNotificationType] ([SystemEMailNotificationTypeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEMailNotificationPreferen_5_1697441121__K2_K1_K5_K6_3_4_7]
    ON [dbo].[AccountEMailNotificationPreference]([AccountId] ASC, [AccountEMailNotificationPreferenceId] ASC, [SystemEMailNotificationId] ASC, [SystemEMailNotificationTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemEMailNotificationTypeId]
    ON [dbo].[AccountEMailNotificationPreference]([SystemEMailNotificationTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemEMailNotificationId]
    ON [dbo].[AccountEMailNotificationPreference]([SystemEMailNotificationId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountEMailNotificationPreference]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectId]
    ON [dbo].[AccountEMailNotificationPreference]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId]
    ON [dbo].[AccountEMailNotificationPreference]([AccountEmployeeId] ASC);


GO
CREATE STATISTICS [_dta_stat_1697441121_1_5_6_2]
    ON [dbo].[AccountEMailNotificationPreference]([AccountEMailNotificationPreferenceId], [SystemEMailNotificationId], [SystemEMailNotificationTypeId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1697441121_1_5_6_4]
    ON [dbo].[AccountEMailNotificationPreference]([AccountEMailNotificationPreferenceId], [SystemEMailNotificationId], [SystemEMailNotificationTypeId], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1697441121_4_1_5]
    ON [dbo].[AccountEMailNotificationPreference]([AccountEmployeeId], [AccountEMailNotificationPreferenceId], [SystemEMailNotificationId]);

