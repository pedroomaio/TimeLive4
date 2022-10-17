CREATE TABLE [dbo].[AccountBillingRate] (
    [AccountBillingRateId]     INT      IDENTITY (1, 1) NOT NULL,
    [AccountId]                INT      NOT NULL,
    [SystemBillingRateTypeId]  SMALLINT NOT NULL,
    [AccountProjectEmployeeId] BIGINT   NULL,
    [AccountProjectRoleId]     INT      NULL,
    [BillingRate]              MONEY    NOT NULL,
    [StartDate]                DATETIME NULL,
    [EndDate]                  DATETIME NULL,
    [AccountEmployeeId]        INT      NULL,
    [AccountProjectTaskId]     BIGINT   NULL,
    [AccountWorkTypeId]        INT      NULL,
    [EmployeeRate]             MONEY    NULL,
    [BillingRateCurrencyId]    INT      NULL,
    [EmployeeRateCurrencyId]   INT      NULL,
    CONSTRAINT [PK_AccountBillingRate] PRIMARY KEY CLUSTERED ([AccountBillingRateId] ASC),
    CONSTRAINT [FK_AccountBillingRate_AccountCurrency] FOREIGN KEY ([BillingRateCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId]),
    CONSTRAINT [FK_AccountBillingRate_AccountCurrency1] FOREIGN KEY ([EmployeeRateCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId]),
    CONSTRAINT [FK_AccountBillingRate_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountBillingRate_AccountProjectEmployee] FOREIGN KEY ([AccountProjectEmployeeId]) REFERENCES [dbo].[AccountProjectEmployee] ([AccountProjectEmployeeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountBillingRate_AccountProjectRole] FOREIGN KEY ([AccountProjectRoleId]) REFERENCES [dbo].[AccountProjectRole] ([AccountProjectRoleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountBillingRate_AccountProjectTask] FOREIGN KEY ([AccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountBillingRate_AccountWorkType] FOREIGN KEY ([AccountWorkTypeId]) REFERENCES [dbo].[AccountWorkType] ([AccountWorkTypeId]),
    CONSTRAINT [FK_AccountBillingRate_SystemBillingRateType] FOREIGN KEY ([SystemBillingRateTypeId]) REFERENCES [dbo].[SystemBillingRateType] ([SystemBillingRateTypeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeRateCurrencyId]
    ON [dbo].[AccountBillingRate]([EmployeeRateCurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BillingRateCurrencyId]
    ON [dbo].[AccountBillingRate]([BillingRateCurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountWorkTypeId]
    ON [dbo].[AccountBillingRate]([AccountWorkTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectTaskId]
    ON [dbo].[AccountBillingRate]([AccountProjectTaskId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemBillingRateTypeId]
    ON [dbo].[AccountBillingRate]([SystemBillingRateTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectRoleId]
    ON [dbo].[AccountBillingRate]([AccountProjectRoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectEmployeeId]
    ON [dbo].[AccountBillingRate]([AccountProjectEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountBillingRate]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId]
    ON [dbo].[AccountBillingRate]([AccountEmployeeId] ASC);

