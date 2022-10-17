CREATE TABLE [dbo].[MasterTimeOffPolicyDetail] (
    [MasterTimeOffPolicyDetailId] UNIQUEIDENTIFIER CONSTRAINT [DF_MasterTimeOffPolicyDetail_MasterTimeOffPolicyDetailId] DEFAULT (newid()) NOT NULL,
    [MasterTimeOffPolicyId]       UNIQUEIDENTIFIER NOT NULL,
    [MasterTimeOffTypeId]         UNIQUEIDENTIFIER NOT NULL,
    [SystemEarnPeriodId]          UNIQUEIDENTIFIER NULL,
    [SystemResetToZeroTypeId]     UNIQUEIDENTIFIER NULL,
    [InitialSetToHours]           FLOAT (53)       NULL,
    [ResetToHours]                FLOAT (53)       NULL,
    [EarnHours]                   FLOAT (53)       NULL,
    [CarryOver]                   FLOAT (53)       NULL,
    [AccureDay]                   FLOAT (53)       NULL,
    [MaximumAvailable]            FLOAT (53)       NULL,
    [AdditionalHours]             FLOAT (53)       NULL,
    CONSTRAINT [PK_MasterTimeOffPolicyDetail] PRIMARY KEY CLUSTERED ([MasterTimeOffPolicyDetailId] ASC)
);

