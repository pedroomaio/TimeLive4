CREATE TABLE [dbo].[AccountEmployeeProjectPreferences] (
    [AccountEmployeeProjectPreferencesId] INT IDENTITY (1, 1) NOT NULL,
    [AccountEmployeeId]                   INT NULL,
    [AccountProjectId]                    INT NULL,
    [SendEMailOfActivityAssignToMe]       BIT NULL,
    [SendEMailOfAllProjectActivities]     BIT NULL,
    CONSTRAINT [PK_AccountEmployeeProjectPreferences] PRIMARY KEY CLUSTERED ([AccountEmployeeProjectPreferencesId] ASC),
    CONSTRAINT [FK_AccountEmployeeProjectPreferences_AccountEmployee] FOREIGN KEY ([AccountEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]) ON DELETE CASCADE,
    CONSTRAINT [IX_AccountEmployeeProjectPreferences] UNIQUE NONCLUSTERED ([AccountProjectId] ASC, [AccountEmployeeId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectId]
    ON [dbo].[AccountEmployeeProjectPreferences]([AccountProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployeeId]
    ON [dbo].[AccountEmployeeProjectPreferences]([AccountEmployeeId] ASC);

