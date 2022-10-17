CREATE TABLE [dbo].[AccountProjectTaskComments] (
    [AccountProjectTaskCommentsId] BIGINT          IDENTITY (1, 1) NOT NULL,
    [AccountProjectTaskId]         BIGINT          NOT NULL,
    [CommentsTitle]                NVARCHAR (1000) NOT NULL,
    [Comments]                     NVARCHAR (4000) NOT NULL,
    [CreatedByEmployeeId]          INT             NOT NULL,
    [CreatedOn]                    DATETIME        NOT NULL,
    [ModifiedByEmployeeId]         INT             NOT NULL,
    [ModifiedOn]                   DATETIME        NOT NULL,
    CONSTRAINT [PK_AccountProjectTaskComments] PRIMARY KEY CLUSTERED ([AccountProjectTaskCommentsId] ASC),
    CONSTRAINT [FK_AccountProjectTaskComments_AccountProjectTask] FOREIGN KEY ([AccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CreatedByEmployeeId]
    ON [dbo].[AccountProjectTaskComments]([CreatedByEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountProjectTaskId]
    ON [dbo].[AccountProjectTaskComments]([AccountProjectTaskId] ASC);

