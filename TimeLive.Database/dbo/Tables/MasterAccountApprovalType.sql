CREATE TABLE [dbo].[MasterAccountApprovalType] (
    [MasterAccountApprovalTypeId] SMALLINT       NOT NULL,
    [ApprovalTypeName]            NVARCHAR (100) NOT NULL,
    [IsTimeOffApprovalTypes]      BIT            NULL,
    CONSTRAINT [PK_MasterAccountApprovalType] PRIMARY KEY CLUSTERED ([MasterAccountApprovalTypeId] ASC)
);

