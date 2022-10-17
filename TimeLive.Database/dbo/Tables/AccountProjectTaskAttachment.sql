CREATE TABLE [dbo].[AccountProjectTaskAttachment] (
    [AccountProjectTaskAttachmentId] INT             IDENTITY (1, 1) NOT NULL,
    [AccountProjectTaskId]           BIGINT          NOT NULL,
    [AttachmentName]                 NVARCHAR (1000) NOT NULL,
    [AttachmentLocalPath]            NVARCHAR (1000) NOT NULL,
    [CreatedOn]                      DATETIME        NOT NULL,
    [CreatedByEmployeeId]            INT             NOT NULL,
    [ModifiedOn]                     DATETIME        NOT NULL,
    [ModifiedByEmployeeId]           INT             NOT NULL,
    CONSTRAINT [PK_AccountProjectTaskAttachment] PRIMARY KEY CLUSTERED ([AccountProjectTaskAttachmentId] ASC),
    CONSTRAINT [FK_AccountProjectTaskAttachment_AccountProjectTask] FOREIGN KEY ([AccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectTaskId]
    ON [dbo].[AccountProjectTaskAttachment]([AccountProjectTaskId] ASC);

