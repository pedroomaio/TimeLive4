CREATE TABLE [dbo].[EmailMessage] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [ChangeStamp]     DATETIME         NOT NULL,
    [Priority]        INT              NOT NULL,
    [Status]          INT              NOT NULL,
    [NumberOfRetry]   INT              NOT NULL,
    [RetryTime]       DATETIME         NOT NULL,
    [MaximumRetry]    INT              NOT NULL,
    [ExpiryDateTime]  DATETIME         NOT NULL,
    [ArrivedDateTime] DATETIME         NOT NULL,
    [SenderInfo]      VARCHAR (50)     NOT NULL,
    [EMailTo]         VARCHAR (50)     NOT NULL,
    [EMailFrom]       VARCHAR (50)     NOT NULL,
    [EMailSubject]    NVARCHAR (4000)  NOT NULL,
    [EMailBody]       NTEXT            NOT NULL,
    [EMailCC]         VARCHAR (100)    NOT NULL,
    [EMailBCC]        VARCHAR (100)    NOT NULL,
    [IsHTML]          BIT              NOT NULL,
    CONSTRAINT [PK_EmailMessage] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Status]
    ON [dbo].[EmailMessage]([Status] ASC);

