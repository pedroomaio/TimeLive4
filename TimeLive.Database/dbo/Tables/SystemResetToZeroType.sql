CREATE TABLE [dbo].[SystemResetToZeroType] (
    [SystemResetToZeroTypeId] UNIQUEIDENTIFIER CONSTRAINT [DF_SystemResetToZeroType_SystemResetToZeroTypeId] DEFAULT (newid()) NOT NULL,
    [SystemResetToZeroType]   NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_SystemResetToZeroType] PRIMARY KEY CLUSTERED ([SystemResetToZeroTypeId] ASC)
);

