CREATE TABLE [dbo].[AccountTimeOffPolicy] (
    [AccountTimeOffPolicyId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountTimeOffPolicy_AccountTimeOffPolicyId] DEFAULT (newid()) NOT NULL,
    [AccountTimeOffPolicy]   NVARCHAR (100)   NOT NULL,
    [AccountId]              INT              NOT NULL,
    [MasterTimeOffPolicyId]  UNIQUEIDENTIFIER NULL,
    [CreatedByEmployeeId]    INT              NOT NULL,
    [CreatedOn]              DATETIME         CONSTRAINT [DF_AccountTimeOffPolicy_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]   INT              NOT NULL,
    [ModifiedOn]             DATETIME         CONSTRAINT [DF_AccountTimeOffPolicy_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [IsDisabled]             BIT              CONSTRAINT [DF_AccountTimeOffPolicy_IsDisabled] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccountTimeOffPolicy] PRIMARY KEY CLUSTERED ([AccountTimeOffPolicyId] ASC)
);

