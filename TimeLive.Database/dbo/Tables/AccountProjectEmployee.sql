CREATE TABLE [dbo].[AccountProjectEmployee] (
    [AccountProjectEmployeeId]         BIGINT   IDENTITY (1, 1) NOT NULL,
    [AccountId]                        INT      NULL,
    [AccountProjectId]                 INT      NOT NULL,
    [AccountEmployeeId]                INT      NOT NULL,
    [TaskCompletedPercentage]          SMALLINT NULL,
    [TaskCompleted]                    BIT      NULL,
    [AccountRoleId]                    INT      NULL,
    [AccountBillingRateId]             INT      NULL,
    [AccountProjectEmployeeTemplateId] BIGINT   NULL,
    CONSTRAINT [PK_AccountProjectEmployee] PRIMARY KEY CLUSTERED ([AccountProjectEmployeeId] ASC),
    CONSTRAINT [FK_AccountProjectEmployee_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_AccountProjectEmployee_AccountBillingRate] FOREIGN KEY ([AccountBillingRateId]) REFERENCES [dbo].[AccountBillingRate] ([AccountBillingRateId]),
    CONSTRAINT [FK_AccountProjectEmployee_AccountProject] FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountBillingRateId]
    ON [dbo].[AccountProjectEmployee]([AccountBillingRateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountRoleId]
    ON [dbo].[AccountProjectEmployee]([AccountRoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectEmployee]
    ON [dbo].[AccountProjectEmployee]([AccountProjectEmployeeId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EmployeeId_ProjectId_Unique]
    ON [dbo].[AccountProjectEmployee]([AccountEmployeeId] ASC, [AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectId]
    ON [dbo].[AccountProjectEmployee]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountProjectEmployee]([AccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId]
    ON [dbo].[AccountProjectEmployee]([AccountEmployeeId] ASC);

