CREATE TABLE [dbo].[AccountFilterModule] (
    [AccountFilterModuleId]          UNIQUEIDENTIFIER CONSTRAINT [DF_AccountFilterModule_AccountFilterModuleId] DEFAULT (newid()) NOT NULL,
    [SystemFilterModuleId]           UNIQUEIDENTIFIER NOT NULL,
    [SystemFilterModuleFieldId]      UNIQUEIDENTIFIER NOT NULL,
    [AccountId]                      INT              NOT NULL,
    [AccountEmployeeId]              INT              NOT NULL,
    [AccountFilterModuleName]        NVARCHAR (2000)  NULL,
    [AccountFilterModuleText]        NVARCHAR (2000)  NULL,
    [CreatedOn]                      DATETIME         NULL,
    [CreatedByEmployeeId]            INT              NULL,
    [ModifiedOn]                     DATETIME         NULL,
    [ModifiedByEmployeeId]           INT              NULL,
    [AccountFilterModuleDefaultName] NVARCHAR (2000)  NULL,
    CONSTRAINT [PK_AccountFilterModule_1] PRIMARY KEY CLUSTERED ([AccountFilterModuleId] ASC)
);

