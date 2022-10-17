CREATE TABLE [dbo].[MasterAccountApprovalPath] (
    [MasterAccountApprovalPathId] SMALLINT NOT NULL,
    [MasterAccountApprovalTypeId] SMALLINT NOT NULL,
    [SystemApproverTypeId]        SMALLINT NOT NULL,
    [ApprovalPathSequence]        TINYINT  NOT NULL,
    CONSTRAINT [PK_MasterAccountApprovalPath] PRIMARY KEY CLUSTERED ([MasterAccountApprovalPathId] ASC)
);

