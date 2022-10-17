CREATE TABLE [dbo].[AccountProjectRole] (
    [AccountProjectRoleId]         INT   IDENTITY (1, 1) NOT NULL,
    [AccountProjectId]             INT   NOT NULL,
    [AccountRoleId]                INT   NOT NULL,
    [NumberOfResources]            INT   NOT NULL,
    [BillingRate]                  MONEY NOT NULL,
    [BillingTypeId]                INT   NOT NULL,
    [AccountBillingRateId]         INT   NULL,
    [AccountProjectRoleTemplateId] INT   NULL,
    CONSTRAINT [PK_AccountProjectRole] PRIMARY KEY CLUSTERED ([AccountProjectRoleId] ASC),
    CONSTRAINT [FK_AccountProjectRole_AccountBillingRate] FOREIGN KEY ([AccountBillingRateId]) REFERENCES [dbo].[AccountBillingRate] ([AccountBillingRateId]),
    CONSTRAINT [FK_AccountProjectRole_AccountProject] FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId]),
    CONSTRAINT [FK_AccountProjectRole_AccountRole] FOREIGN KEY ([AccountRoleId]) REFERENCES [dbo].[AccountRole] ([AccountRoleId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountBillingRateId]
    ON [dbo].[AccountProjectRole]([AccountBillingRateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BillingTypeId]
    ON [dbo].[AccountProjectRole]([BillingTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountRoleId]
    ON [dbo].[AccountProjectRole]([AccountRoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectId]
    ON [dbo].[AccountProjectRole]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectRoleUnique]
    ON [dbo].[AccountProjectRole]([AccountProjectId] ASC, [AccountProjectRoleId] ASC);

