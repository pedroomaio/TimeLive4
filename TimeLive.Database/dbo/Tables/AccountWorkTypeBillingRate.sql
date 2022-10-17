CREATE TABLE [dbo].[AccountWorkTypeBillingRate] (
    [AccountWorkTypeBillingRateId] INT      IDENTITY (1, 1) NOT NULL,
    [AccountId]                    INT      NOT NULL,
    [SystemBillingRateTypeId]      SMALLINT NOT NULL,
    [AccountEmployeeId]            INT      NULL,
    [AccountProjectEmployeeId]     BIGINT   NULL,
    [AccountProjectRoleId]         INT      NULL,
    [AccountProjectTaskId]         BIGINT   NULL,
    [AccountBillingRateId]         INT      NULL,
    [AccountWorkTypeId]            INT      NULL,
    CONSTRAINT [PK_AccountWorkTypeBillingRate] PRIMARY KEY CLUSTERED ([AccountWorkTypeBillingRateId] ASC),
    CONSTRAINT [FK_AccountWorkTypeBillingRate_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_AccountWorkTypeBillingRate_AccountBillingRate] FOREIGN KEY ([AccountBillingRateId]) REFERENCES [dbo].[AccountBillingRate] ([AccountBillingRateId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountWorkTypeBillingRate_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_AccountWorkTypeBillingRate_AccountProjectEmployee] FOREIGN KEY ([AccountProjectEmployeeId]) REFERENCES [dbo].[AccountProjectEmployee] ([AccountProjectEmployeeId]),
    CONSTRAINT [FK_AccountWorkTypeBillingRate_AccountProjectRole] FOREIGN KEY ([AccountProjectRoleId]) REFERENCES [dbo].[AccountProjectRole] ([AccountProjectRoleId]),
    CONSTRAINT [FK_AccountWorkTypeBillingRate_AccountProjectTask] FOREIGN KEY ([AccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId]),
    CONSTRAINT [FK_AccountWorkTypeBillingRate_AccountWorkType] FOREIGN KEY ([AccountWorkTypeId]) REFERENCES [dbo].[AccountWorkType] ([AccountWorkTypeId]),
    CONSTRAINT [FK_AccountWorkTypeBillingRate_SystemBillingRateType] FOREIGN KEY ([SystemBillingRateTypeId]) REFERENCES [dbo].[SystemBillingRateType] ([SystemBillingRateTypeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemBillingRateTypeId]
    ON [dbo].[AccountWorkTypeBillingRate]([SystemBillingRateTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountWorkTypeId]
    ON [dbo].[AccountWorkTypeBillingRate]([AccountWorkTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectTaskId]
    ON [dbo].[AccountWorkTypeBillingRate]([AccountProjectTaskId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountWorkTypeBillingRateId]
    ON [dbo].[AccountWorkTypeBillingRate]([AccountWorkTypeBillingRateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectRoleId]
    ON [dbo].[AccountWorkTypeBillingRate]([AccountProjectRoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectEmployeeId]
    ON [dbo].[AccountWorkTypeBillingRate]([AccountProjectEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountWorkTypeBillingRate]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId]
    ON [dbo].[AccountWorkTypeBillingRate]([AccountEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountBillingRateId]
    ON [dbo].[AccountWorkTypeBillingRate]([AccountBillingRateId] ASC);

