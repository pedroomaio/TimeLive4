CREATE TABLE [dbo].[AccountProjectTaskEmployee] (
    [AccountProjectTaskEmployeeId] BIGINT          IDENTITY (1, 1) NOT NULL,
    [AccountId]                    INT             NOT NULL,
    [AccountProjectTaskId]         BIGINT          NOT NULL,
    [AccountEmployeeId]            INT             NOT NULL,
    [AllocationUnits]              DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_AccountProjectEmployeeTask] PRIMARY KEY CLUSTERED ([AccountProjectTaskEmployeeId] ASC),
    CONSTRAINT [FK_AccountProjectTaskEmployee_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_AccountProjectTaskEmployee_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountProjectTaskEmployee_AccountProjectTask] FOREIGN KEY ([AccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountProjectTaskEmployee]([AccountId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountProjectTaskEmployee]
    ON [dbo].[AccountProjectTaskEmployee]([AccountEmployeeId] ASC, [AccountProjectTaskId] ASC);

