CREATE TABLE [dbo].[AccountQBOnlineLog] (
    [AccountQBOnlineLogId] UNIQUEIDENTIFIER NOT NULL,
    [AccountId]            INT              NOT NULL,
    [AccountEmployeeId]    INT              NOT NULL,
    [ExecutedDate]         DATETIME         NOT NULL,
    [EntityName]           NVARCHAR (100)   NOT NULL,
    [QBEntityName]         NVARCHAR (100)   NOT NULL,
    [DataDisplayName]      NVARCHAR (1000)  NULL,
    [ErrorCode]            NVARCHAR (50)    NULL,
    [Message]              NVARCHAR (1000)  NULL,
    [MessageDetail]        NVARCHAR (4000)  NULL,
    [CreatedOn]            DATETIME         NULL,
    [ModifiedOn]           DATETIME         NULL,
    CONSTRAINT [PK_AccountQBOnlineLog] PRIMARY KEY CLUSTERED ([AccountQBOnlineLogId] ASC)
);

