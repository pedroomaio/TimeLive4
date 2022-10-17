CREATE TABLE [dbo].[AccountDepartment] (
    [AccountDepartmentId]  INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]            INT            NOT NULL,
    [DepartmentCode]       NVARCHAR (20)  NOT NULL,
    [DepartmentName]       NVARCHAR (400) NOT NULL,
    [IsDisabled]           BIT            CONSTRAINT [DF_AccountDepartment_IsDisabled] DEFAULT ((0)) NOT NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF_AccountDepartment_IsDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedOn]            DATETIME       CONSTRAINT [DF_AccountDepartment_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]           DATETIME       CONSTRAINT [DF_AccountDepartment_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]  INT            NOT NULL,
    [ModifiedByEmployeeId] INT            NOT NULL,
    CONSTRAINT [PK_AccountDepartment] PRIMARY KEY CLUSTERED ([AccountDepartmentId] ASC),
    CONSTRAINT [FK_AccountDepartment_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountDepartment]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_1578540757_2_1_5_4]
    ON [dbo].[AccountDepartment]([AccountId], [AccountDepartmentId], [IsDisabled], [DepartmentName]);


GO
CREATE STATISTICS [_dta_stat_1578540757_4_1_2]
    ON [dbo].[AccountDepartment]([DepartmentName], [AccountDepartmentId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1578540757_1_5_4]
    ON [dbo].[AccountDepartment]([AccountDepartmentId], [IsDisabled], [DepartmentName]);


GO
CREATE STATISTICS [_dta_stat_1578540757_3_1]
    ON [dbo].[AccountDepartment]([DepartmentCode], [AccountDepartmentId]);


GO
CREATE STATISTICS [_dta_stat_1578540757_2_5]
    ON [dbo].[AccountDepartment]([AccountId], [IsDisabled]);

