CREATE TABLE [dbo].[MasterTimeOffPolicy] (
    [MasterTimeOffPolicyId] UNIQUEIDENTIFIER CONSTRAINT [DF_MasterTimeOffPolicy_MasterTimeOffPolicyId] DEFAULT (newid()) NOT NULL,
    [MasterTimeOffPolicy]   NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_MasterTimeOffPolicy] PRIMARY KEY CLUSTERED ([MasterTimeOffPolicyId] ASC)
);

