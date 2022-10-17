CREATE TABLE [dbo].[MasterTimeOffType] (
    [MasterTimeOffTypeId]      UNIQUEIDENTIFIER CONSTRAINT [DF_MasterTimeOffType_MasterTimeOffTypeId] DEFAULT (newid()) NOT NULL,
    [MasterTimeOffType]        NVARCHAR (100)   NOT NULL,
    [IsTimeOffRequestRequired] BIT              CONSTRAINT [DF_MasterTimeOffType_IsTimeOffRequestRequired] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_MasterTimeOffType] PRIMARY KEY CLUSTERED ([MasterTimeOffTypeId] ASC)
);

