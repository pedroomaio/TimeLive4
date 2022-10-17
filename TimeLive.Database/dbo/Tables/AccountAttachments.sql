CREATE TABLE [dbo].[AccountAttachments] (
    [AccountAttachmentId]              INT              IDENTITY (1, 1) NOT NULL,
    [AccountAttachmentTypeId]          INT              NOT NULL,
    [AccountExpenseEntryId]            INT              NOT NULL,
    [AttachmentName]                   NVARCHAR (1000)  NOT NULL,
    [AttachmentLocalPath]              NVARCHAR (1000)  NOT NULL,
    [CreatedOn]                        DATETIME         NOT NULL,
    [CreatedByEmployeeId]              INT              NOT NULL,
    [ModifiedOn]                       DATETIME         NOT NULL,
    [ModifiedByEmployeeId]             INT              NOT NULL,
    [AccountEmployeeTimeEntryPeriodId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_AccountAttachments] PRIMARY KEY CLUSTERED ([AccountAttachmentId] ASC),
    CONSTRAINT [FK_AccountAttachments_AccountAttachments] FOREIGN KEY ([AccountAttachmentId]) REFERENCES [dbo].[AccountAttachments] ([AccountAttachmentId])
);

