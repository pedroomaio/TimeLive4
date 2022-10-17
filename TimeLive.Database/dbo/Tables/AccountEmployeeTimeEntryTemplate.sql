CREATE TABLE [dbo].[AccountEmployeeTimeEntryTemplate] (
    [AccountEmployeeTimeEntryTemplateId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountEmployeeTimeEntryTemplate_AccountEmployeeTimeEntryTemplateId] DEFAULT (newid()) NOT NULL,
    [AccountId]                          INT              NULL,
    [AccountEmployeeId]                  INT              NULL,
    [AccountProjectId]                   INT              NULL,
    [AccountProjectTaskId]               INT              NULL,
    CONSTRAINT [PK_AccountEmployeeTimeEntryTemplate] PRIMARY KEY CLUSTERED ([AccountEmployeeTimeEntryTemplateId] ASC)
);

