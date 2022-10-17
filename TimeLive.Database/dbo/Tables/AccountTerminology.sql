CREATE TABLE [dbo].[AccountTerminology] (
    [AccountTerminologyId] INT            IDENTITY (1, 1) NOT NULL,
    [UserDefinedName]      NVARCHAR (300) NULL,
    [AccountId]            INT            NOT NULL,
    [CreatedByEmployeeId]  INT            NULL,
    [ModifiedByEmployeeId] INT            NULL,
    [CreatedOn]            DATETIME       NULL,
    [ModifiedOn]           DATETIME       NULL,
    [TerminologyName]      NVARCHAR (300) NULL,
    CONSTRAINT [PK_AccountTerminology] PRIMARY KEY CLUSTERED ([AccountTerminologyId] ASC),
    CONSTRAINT [FK_AccountTerminology_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountTerminologyName]
    ON [dbo].[AccountTerminology]([TerminologyName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserDefinedName]
    ON [dbo].[AccountTerminology]([UserDefinedName] ASC);

