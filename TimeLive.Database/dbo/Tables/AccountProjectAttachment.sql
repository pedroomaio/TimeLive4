CREATE TABLE [dbo].[AccountProjectAttachment] (
    [AccountProjectAttachmentId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountProjectAttachment_AccountProjectAttachmentId] DEFAULT (newid()) NOT NULL,
    [AccountProjectId]           INT              NOT NULL,
    [AttachmentName]             NVARCHAR (1000)  NOT NULL,
    [AttachmentLocalPath]        NVARCHAR (1000)  NOT NULL,
    [CreatedOn]                  DATETIME         NOT NULL,
    [CreatedByEmployeeId]        INT              NOT NULL,
    [ModifiedOn]                 DATETIME         NOT NULL,
    [ModifiedByEmployeeId]       INT              NOT NULL,
    CONSTRAINT [PK_AccountProjectAttachment] PRIMARY KEY CLUSTERED ([AccountProjectAttachmentId] ASC)
);

