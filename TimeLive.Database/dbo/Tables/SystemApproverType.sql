CREATE TABLE [dbo].[SystemApproverType] (
    [SystemApproverTypeId] SMALLINT      NOT NULL,
    [SystemApproverType]   NVARCHAR (60) NOT NULL,
    CONSTRAINT [PK_SystemApproverType] PRIMARY KEY CLUSTERED ([SystemApproverTypeId] ASC)
);

