CREATE TABLE [dbo].[AccountModuleView] (
    [AccountModuleViewId]   UNIQUEIDENTIFIER CONSTRAINT [DF_AccountModule_AccountModuleId] DEFAULT (newid()) NOT NULL,
    [AccountModuleViewName] NVARCHAR (200)   NOT NULL,
    [SystemModuleId]        UNIQUEIDENTIFIER NOT NULL,
    [AccountId]             INT              NOT NULL,
    [AccountEmployeeId]     INT              NOT NULL,
    [IsSelected]            BIT              NULL,
    [IsDefaultView]         BIT              NULL,
    [CreatedOn]             DATETIME         NULL,
    [CreatedBy]             INT              NULL,
    [ModifiedOn]            DATETIME         NULL,
    [ModifiedBy]            INT              NULL,
    CONSTRAINT [PK_AccountModule] PRIMARY KEY CLUSTERED ([AccountModuleViewId] ASC)
);

