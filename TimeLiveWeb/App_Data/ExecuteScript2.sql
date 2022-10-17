--TimeLive 2.4
--Start 2.4

GO

-- Drop Foreign Key FK_AccountEmployee_SystemTimeZone from AccountEmployee
Print 'Drop Foreign Key FK_AccountEmployee_SystemTimeZone from AccountEmployee'
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployee_SystemTimeZone' AND TABLE_NAME='AccountEmployee')
ALTER TABLE [dbo].[AccountEmployee] DROP CONSTRAINT [FK_AccountEmployee_SystemTimeZone]
GO

-- Drop Foreign Key FK_AccountProject_SystemTimeSheetApprovalPath from AccountProject
Print 'Drop Foreign Key FK_AccountProject_SystemTimeSheetApprovalPath from AccountProject'
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE  CONSTRAINT_NAME='FK_AccountProject_SystemTimeSheetApprovalPath' AND TABLE_NAME='AccountProject')
ALTER TABLE [dbo].[AccountProject] DROP CONSTRAINT [FK_AccountProject_SystemTimeSheetApprovalPath]
GO

-- Drop Foreign Key FK_AccountEmployeeTimeEntry_SystemTimeSheetApprovalPath from AccountEmployeeTimeEntry
Print 'Drop Foreign Key FK_AccountEmployeeTimeEntry_SystemTimeSheetApprovalPath from AccountEmployeeTimeEntry'
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE  CONSTRAINT_NAME='FK_AccountEmployeeTimeEntry_SystemTimeSheetApprovalPath' AND TABLE_NAME='AccountEmployeeTimeEntry')
ALTER TABLE [dbo].[AccountEmployeeTimeEntry] DROP CONSTRAINT [FK_AccountEmployeeTimeEntry_SystemTimeSheetApprovalPath]
GO

-- Drop Foreign Key FK_AccountEmployeeTimeEntry_AccountEmployee from AccountEmployeeTimeEntry
Print 'Drop Foreign Key FK_AccountEmployeeTimeEntry_AccountEmployee from AccountEmployeeTimeEntry'
GO
IF  EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE  CONSTRAINT_NAME='FK_AccountEmployeeTimeEntry_AccountEmployee' AND TABLE_NAME='AccountEmployeeTimeEntry')
ALTER TABLE [dbo].[AccountEmployeeTimeEntry] DROP CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountEmployee]
GO

-- Drop Trigger tr_trigtest
Print 'Drop Trigger tr_trigtest'
GO
IF (EXISTS(SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[tr_trigtest]') AND [type]='TR'))
DROP TRIGGER [dbo].[tr_trigtest]
GO

-- Drop View vueAccountProjectEmployee
Print 'Drop View vueAccountProjectEmployee'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectEmployee' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountProjectEmployee]
GO

-- Drop View vueAccountProjectRole
Print 'Drop View vueAccountProjectRole'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectRole' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountProjectRole]
GO

-- Drop View vueAccountExpenseEntry
Print 'Drop View vueAccountExpenseEntry'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntry]
GO

-- Drop View vueAccountBillingType
Print 'Drop View vueAccountBillingType'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountBillingType' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountBillingType]
GO

-- Drop View vueAccount
Print 'Drop View vueAccount'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccount' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccount]
GO

-- Drop View vueAccountEmployee
Print 'Drop View vueAccountEmployee'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployee]
GO

-- Drop View vueAccountEmployeeTimeEntry
Print 'Drop View vueAccountEmployeeTimeEntry'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntry' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntry]
GO

-- Drop View vueAccountProjectTask
Print 'Drop View vueAccountProjectTask'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectTask' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountProjectTask]
GO

-- Drop Primary Key PK_SystemTimeSheetApprovalPath from SystemTimeSheetApprovalPath
Print 'Drop Primary Key PK_SystemTimeSheetApprovalPath from SystemTimeSheetApprovalPath'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemTimeSheetApprovalPath' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_SystemTimeSheetApprovalPath' AND TABLE_NAME='SystemTimeSheetApprovalPath'))
ALTER TABLE [dbo].[SystemTimeSheetApprovalPath] DROP CONSTRAINT [PK_SystemTimeSheetApprovalPath]
GO

-- Drop Default Constraint DF_AccountDepartment_IsDeleted from AccountDepartment
Print 'Drop Default Constraint DF_AccountDepartment_IsDeleted from AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDeleted'))
ALTER TABLE [dbo].[AccountDepartment] DROP CONSTRAINT [DF_AccountDepartment_IsDeleted]
GO

-- Drop Default Constraint DF_AccountDepartment_IsDisabled from AccountDepartment
Print 'Drop Default Constraint DF_AccountDepartment_IsDisabled from AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDisabled'))
ALTER TABLE [dbo].[AccountDepartment] DROP CONSTRAINT [DF_AccountDepartment_IsDisabled]
GO

-- Drop Default Constraint DF_AccountLocation_CreatedByEmployeeId from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_CreatedByEmployeeId from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_CreatedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountLocation_IsDisabled from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_IsDisabled from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_IsDisabled'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_IsDisabled]
GO

-- Drop Default Constraint DF_AccountLocation_ModifiedByEmployeeId from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_ModifiedByEmployeeId from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_ModifiedByEmployeeId]
GO

-- Drop View vueTaskBillingRate
Print 'Drop View vueTaskBillingRate'
GO
if exists (select * from information_schema.tables where table_name = 'vueTaskBillingRate' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueTaskBillingRate]
GO

-- Drop Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId from AccountEmployeeAttendance
Print 'Drop Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId from AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance] DROP CONSTRAINT [DF_AccountEmployeeAttendance_CreatedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId from AccountEmployeeAttendance
Print 'Drop Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId from AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance] DROP CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountRole_IsDeleted from AccountRole
Print 'Drop Default Constraint DF_AccountRole_IsDeleted from AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountRole_IsDeleted'))
ALTER TABLE [dbo].[AccountRole] DROP CONSTRAINT [DF_AccountRole_IsDeleted]
GO

-- Drop Default Constraint DF_AccountRole_IsDisabled from AccountRole
Print 'Drop Default Constraint DF_AccountRole_IsDisabled from AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountRole_IsDisabled'))
ALTER TABLE [dbo].[AccountRole] DROP CONSTRAINT [DF_AccountRole_IsDisabled]
GO

-- Drop Default Constraint DF_AccountProject_TimeSheetApprovalPathId from AccountProject
Print 'Drop Default Constraint DF_AccountProject_TimeSheetApprovalPathId from AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountProject_TimeSheetApprovalPathId'))
ALTER TABLE [dbo].[AccountProject] DROP CONSTRAINT [DF_AccountProject_TimeSheetApprovalPathId]
GO

-- Drop Index IX_TimeSheetApprovalPathId from AccountProject
Print 'Drop Index IX_TimeSheetApprovalPathId from AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID (N'[dbo].[AccountProject]') AND name = N'IX_TimeSheetApprovalPathId'))
DROP INDEX [dbo].[AccountProject].[IX_TimeSheetApprovalPathId]
GO

-- Drop Column TimeSheetApprovalPathId from AccountProject
Print 'Drop Column TimeSheetApprovalPathId from AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='TimeSheetApprovalPathId' AND TABLE_NAME='AccountProject'))
ALTER TABLE [dbo].[AccountProject] DROP COLUMN [TimeSheetApprovalPathId]
GO

-- Drop Index IX_AccountLocationId from AccountEmployee
Print 'Drop Index IX_AccountLocationId from AccountEmployee'
GO
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID (N'[dbo].[AccountEmployee]') AND name = N'IX_AccountLocationId'))
DROP INDEX [dbo].[AccountEmployee].[IX_AccountLocationId]
GO

-- Drop Index IX_AccountDepartmentId from AccountEmployee
Print 'Drop Index IX_AccountDepartmentId from AccountEmployee'
GO
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID (N'[dbo].[AccountEmployee]') AND name = N'IX_AccountDepartmentId'))
DROP INDEX [dbo].[AccountEmployee].[IX_AccountDepartmentId]
GO

-- Drop Column BillingRate from AccountEmployee
Print 'Drop Column BillingRate from AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='BillingRate' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee] DROP COLUMN [BillingRate]
GO

-- Drop Column BillingRateStartDate from AccountEmployee
Print 'Drop Column BillingRateStartDate from AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='BillingRateStartDate' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee] DROP COLUMN [BillingRateStartDate]
GO

-- Create Table AccountEmployeeTimeEntryApproval
Print 'Create Table AccountEmployeeTimeEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountEmployeeTimeEntryApproval' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountEmployeeTimeEntryApproval] (
		[TimeSheetApprovalId]            int NOT NULL IDENTITY(1, 1),
		[AccountEmployeeTimeEntryId]     int NOT NULL,
		[TimeSheetApprovalTypeId]        int NOT NULL,
		[TimeSheetApprovalPathId]        int NOT NULL,
		[ApprovedByEmployeeId]           int NOT NULL,
		[ApprovedOn]                     datetime NOT NULL,
		[Comments]                       varchar(200) NULL,
		[IsReject]                       bit NOT NULL,
		[IsApproved]                     bit NOT NULL
)
GO

-- Add Primary Key PK_TimeSheetApproval to AccountEmployeeTimeEntryApproval
Print 'Add Primary Key PK_TimeSheetApproval to AccountEmployeeTimeEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_TimeSheetApproval' AND TABLE_NAME='AccountEmployeeTimeEntryApproval'))
ALTER TABLE [dbo].[AccountEmployeeTimeEntryApproval]
	ADD
	CONSTRAINT [PK_TimeSheetApproval]
	PRIMARY KEY
	([TimeSheetApprovalId])
GO

-- Add Default Constraint DF_TimeSheetApproval_IsApproved to AccountEmployeeTimeEntryApproval
Print 'Add Default Constraint DF_TimeSheetApproval_IsApproved to AccountEmployeeTimeEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_TimeSheetApproval_IsApproved'))
ALTER TABLE [dbo].[AccountEmployeeTimeEntryApproval]
	ADD
	CONSTRAINT [DF_TimeSheetApproval_IsApproved]
	DEFAULT ((0)) FOR [IsApproved]
GO

-- Add Default Constraint DF_TimeSheetApproval_IsReject to AccountEmployeeTimeEntryApproval
Print 'Add Default Constraint DF_TimeSheetApproval_IsReject to AccountEmployeeTimeEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_TimeSheetApproval_IsReject'))
ALTER TABLE [dbo].[AccountEmployeeTimeEntryApproval]
	ADD
	CONSTRAINT [DF_TimeSheetApproval_IsReject]
	DEFAULT ((0)) FOR [IsReject]
GO

-- Add Column Rejected to AccountEmployeeTimeEntry
Print 'Add Column Rejected to AccountEmployeeTimeEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Rejected' AND TABLE_NAME='AccountEmployeeTimeEntry'))
ALTER TABLE [dbo].[AccountEmployeeTimeEntry]
	ADD [Rejected] bit NULL

GO

-- Add Column BillingRate to AccountEmployeeTimeEntry
Print 'Add Column BillingRate to AccountEmployeeTimeEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='BillingRate' AND TABLE_NAME='AccountEmployeeTimeEntry'))
ALTER TABLE [dbo].[AccountEmployeeTimeEntry]
	ADD [BillingRate] money NULL

GO

-- Add Default Constraint DF_AccountEmployeeTimeEntry_Rejected to AccountEmployeeTimeEntry
Print 'Add Default Constraint DF_AccountEmployeeTimeEntry_Rejected to AccountEmployeeTimeEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeTimeEntry_Rejected'))
ALTER TABLE [dbo].[AccountEmployeeTimeEntry]
	ADD
	CONSTRAINT [DF_AccountEmployeeTimeEntry_Rejected]
	DEFAULT ((0)) FOR [Rejected]
GO

-- Create Table AccountApprovalPath
Print 'Create Table AccountApprovalPath'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountApprovalPath' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountApprovalPath] (
		[AccountApprovalPathId]           int NOT NULL IDENTITY(1, 1),
		[AccountId]                       int NOT NULL,
		[AccountApprovalTypeId]           int NOT NULL,
		[SystemApproverTypeId]            smallint NOT NULL,
		[AccountExternalUserId]           int NULL,
		[AccountEmployeeId]               int NULL,
		[ApprovalPathSequence]            tinyint NOT NULL,
		[MasterAccountApprovalPathId]     smallint NULL
)
GO

-- Add Primary Key PK_AccountApproverPath to AccountApprovalPath
Print 'Add Primary Key PK_AccountApproverPath to AccountApprovalPath'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountApprovalPath' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountApproverPath' AND TABLE_NAME='AccountApprovalPath'))
ALTER TABLE [dbo].[AccountApprovalPath]
	ADD
	CONSTRAINT [PK_AccountApproverPath]
	PRIMARY KEY
	([AccountApprovalPathId])
GO

-- Create Table AccountApprovalType
Print 'Create Table AccountApprovalType'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountApprovalType' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountApprovalType] (
		[AccountApprovalTypeId]           int NOT NULL IDENTITY(1, 1),
		[ApprovalTypeName]                varchar(100) NOT NULL,
		[AccountId]                       int NOT NULL,
		[MasterAccountApprovalTypeId]     smallint NULL
)
GO

-- Add Primary Key PK_AccountApproverType to AccountApprovalType
Print 'Add Primary Key PK_AccountApproverType to AccountApprovalType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountApprovalType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountApproverType' AND TABLE_NAME='AccountApprovalType'))
ALTER TABLE [dbo].[AccountApprovalType]
	ADD
	CONSTRAINT [PK_AccountApproverType]
	PRIMARY KEY
	([AccountApprovalTypeId])
GO

-- Add Column TimeSheetApprovalTypeId to AccountProject
Print 'Add Column TimeSheetApprovalTypeId to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='TimeSheetApprovalTypeId' AND TABLE_NAME='AccountProject'))
ALTER TABLE [dbo].[AccountProject]
	ADD [TimeSheetApprovalTypeId] int NULL

GO

-- Add Column ExpenseApprovalTypeId to AccountProject
Print 'Add Column ExpenseApprovalTypeId to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='ExpenseApprovalTypeId' AND TABLE_NAME='AccountProject'))
ALTER TABLE [dbo].[AccountProject]
	ADD [ExpenseApprovalTypeId] int NULL

GO

-- Add Default Constraint DF_AccountProject_ExpenseApprovalTypeId to AccountProject
Print 'Add Default Constraint DF_AccountProject_ExpenseApprovalTypeId to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountProject_ExpenseApprovalTypeId'))
ALTER TABLE [dbo].[AccountProject]
	ADD
	CONSTRAINT [DF_AccountProject_ExpenseApprovalTypeId]
	DEFAULT ((0)) FOR [ExpenseApprovalTypeId]
GO

-- Add Default Constraint DF_AccountProject_TimeSheetApprovalTypeId to AccountProject
Print 'Add Default Constraint DF_AccountProject_TimeSheetApprovalTypeId to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountProject_TimeSheetApprovalTypeId'))
ALTER TABLE [dbo].[AccountProject]
	ADD
	CONSTRAINT [DF_AccountProject_TimeSheetApprovalTypeId]
	DEFAULT ((0)) FOR [TimeSheetApprovalTypeId]
GO

-- Alter Column AccountDepartmentId on AccountEmployee
Print 'Alter Column AccountDepartmentId on AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountDepartmentId' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee]
	 ALTER COLUMN [AccountDepartmentId] int NULL
GO

-- Alter Column AccountLocationId on AccountEmployee
Print 'Alter Column AccountLocationId on AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountLocationId' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee]
	 ALTER COLUMN [AccountLocationId] int NULL
GO

-- Alter Column TimeZoneId on AccountEmployee
Print 'Alter Column TimeZoneId on AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='TimeZoneId' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee]
	 ALTER COLUMN [TimeZoneId] tinyint NULL
GO

-- Add Column ExternalUserClientId to AccountEmployee
Print 'Add Column ExternalUserClientId to AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='ExternalUserClientId' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee]
	ADD [ExternalUserClientId] int NULL

GO

-- Add Column EmployeeTypeId to AccountEmployee
Print 'Add Column EmployeeTypeId to AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='EmployeeTypeId' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee]
	ADD [EmployeeTypeId] tinyint NULL

GO

-- Add Column AccountBillingRateId to AccountEmployee
Print 'Add Column AccountBillingRateId to AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountBillingRateId' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee]
	ADD [AccountBillingRateId] int NULL

GO

-- Create Index IX_AccountLocationId on AccountEmployee
Print 'Create Index IX_AccountLocationId on AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEmployee]') AND name = N'IX_AccountLocationId'))
CREATE INDEX [IX_AccountLocationId]
	ON [dbo].[AccountEmployee] ([AccountLocationId])
GO

-- Create Index IX_AccountDepartmentId on AccountEmployee
Print 'Create Index IX_AccountDepartmentId on AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEmployee]') AND name = N'IX_AccountDepartmentId'))
CREATE INDEX [IX_AccountDepartmentId]
	ON [dbo].[AccountEmployee] ([AccountDepartmentId])
GO

-- Alter Column EstimatedTimeSpent on AccountProjectTask
Print 'Alter Column EstimatedTimeSpent on AccountProjectTask'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectTask' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='EstimatedTimeSpent' AND TABLE_NAME='AccountProjectTask'))
ALTER TABLE [dbo].[AccountProjectTask]
	 ALTER COLUMN [EstimatedTimeSpent] float NULL
GO

-- Add Column IsBillable to AccountProjectTask
Print 'Add Column IsBillable to AccountProjectTask'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectTask' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsBillable' AND TABLE_NAME='AccountProjectTask'))
ALTER TABLE [dbo].[AccountProjectTask]
	ADD [IsBillable] bit NULL

GO

-- Create Table AccountBillingRate
Print 'Create Table AccountBillingRate'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountBillingRate' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountBillingRate] (
		[AccountBillingRateId]         int NOT NULL IDENTITY(1, 1),
		[AccountId]                    int NOT NULL,
		[SystemBillingRateTypeId]      smallint NOT NULL,
		[AccountProjectEmployeeId]     bigint NOT NULL,
		[AccountProjectRoleId]         int NOT NULL,
		[BillingRate]                  money NOT NULL,
		[StartDate]                    datetime NULL,
		[EndDate]                      datetime NULL,
		[AccountEmployeeId]            int NULL
)
GO

-- Add Primary Key PK_AccountBillingRate to AccountBillingRate
Print 'Add Primary Key PK_AccountBillingRate to AccountBillingRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountBillingRate' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountBillingRate' AND TABLE_NAME='AccountBillingRate'))
ALTER TABLE [dbo].[AccountBillingRate]
	ADD
	CONSTRAINT [PK_AccountBillingRate]
	PRIMARY KEY
	([AccountBillingRateId])
GO

-- Create Index IX_AccountEmployeeId on AccountBillingRate
Print 'Create Index IX_AccountEmployeeId on AccountBillingRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountBillingRate' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountBillingRate]') AND name = N'IX_AccountEmployeeId'))
CREATE INDEX [IX_AccountEmployeeId]
	ON [dbo].[AccountBillingRate] ([AccountEmployeeId])
GO

-- Create Index IX_AccountProjectEmployeeId on AccountBillingRate
Print 'Create Index IX_AccountProjectEmployeeId on AccountBillingRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountBillingRate' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountBillingRate]') AND name = N'IX_AccountProjectEmployeeId'))
CREATE INDEX [IX_AccountProjectEmployeeId]
	ON [dbo].[AccountBillingRate] ([AccountProjectEmployeeId])
GO

-- Create Index IX_AccountProjectRoleId on AccountBillingRate
Print 'Create Index IX_AccountProjectRoleId on AccountBillingRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountBillingRate' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountBillingRate]') AND name = N'IX_AccountProjectRoleId'))
CREATE INDEX [IX_AccountProjectRoleId]
	ON [dbo].[AccountBillingRate] ([AccountProjectRoleId])
GO

-- Create Index IX_SystemBillingRateTypeId on AccountBillingRate
Print 'Create Index IX_SystemBillingRateTypeId on AccountBillingRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountBillingRate' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountBillingRate]') AND name = N'IX_SystemBillingRateTypeId'))
CREATE INDEX [IX_SystemBillingRateTypeId]
	ON [dbo].[AccountBillingRate] ([SystemBillingRateTypeId])
GO

-- Add Column IsBillable to AccountExpenseEntry
Print 'Add Column IsBillable to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsBillable' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [IsBillable] bit NULL

GO

-- Add Column Rejected to AccountExpenseEntry
Print 'Add Column Rejected to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Rejected' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [Rejected] bit NULL

GO

-- Create Table AccountExpenseEntryApproval
Print 'Create Table AccountExpenseEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountExpenseEntryApproval' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountExpenseEntryApproval] (
		[ExpenseApprovalId]         int NOT NULL IDENTITY(1, 1),
		[AccountExpenseEntryId]     int NOT NULL,
		[ExpenseApprovalTypeId]     int NOT NULL,
		[ExpenseApprovalPathId]     int NOT NULL,
		[ApprovedByEmployeeId]      int NOT NULL,
		[ApprovedOn]                datetime NOT NULL,
		[Comments]                  varchar(200) NULL,
		[IsRejected]                bit NOT NULL,
		[IsApproved]                bit NOT NULL
)
GO

-- Add Primary Key PK_ExpenseApproval to AccountExpenseEntryApproval
Print 'Add Primary Key PK_ExpenseApproval to AccountExpenseEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_ExpenseApproval' AND TABLE_NAME='AccountExpenseEntryApproval'))
ALTER TABLE [dbo].[AccountExpenseEntryApproval]
	ADD
	CONSTRAINT [PK_ExpenseApproval]
	PRIMARY KEY
	([ExpenseApprovalId])
GO

-- Add Default Constraint DF_ExpenseApproval_IsApproved to AccountExpenseEntryApproval
Print 'Add Default Constraint DF_ExpenseApproval_IsApproved to AccountExpenseEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_ExpenseApproval_IsApproved'))
ALTER TABLE [dbo].[AccountExpenseEntryApproval]
	ADD
	CONSTRAINT [DF_ExpenseApproval_IsApproved]
	DEFAULT ((0)) FOR [IsApproved]
GO

-- Add Default Constraint DF_ExpenseApproval_IsRejected to AccountExpenseEntryApproval
Print 'Add Default Constraint DF_ExpenseApproval_IsRejected to AccountExpenseEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_ExpenseApproval_IsRejected'))
ALTER TABLE [dbo].[AccountExpenseEntryApproval]
	ADD
	CONSTRAINT [DF_ExpenseApproval_IsRejected]
	DEFAULT ((0)) FOR [IsRejected]
GO

-- Add Column AccountBillingRateId to AccountProjectRole
Print 'Add Column AccountBillingRateId to AccountProjectRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountBillingRateId' AND TABLE_NAME='AccountProjectRole'))
ALTER TABLE [dbo].[AccountProjectRole]
	ADD [AccountBillingRateId] int NULL

GO

-- Add Default Constraint DF_AccountRole_IsDeleted to AccountRole
Print 'Add Default Constraint DF_AccountRole_IsDeleted to AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountRole_IsDeleted'))
ALTER TABLE [dbo].[AccountRole]
	ADD
	CONSTRAINT [DF_AccountRole_IsDeleted]
	DEFAULT (0) FOR [IsDeleted]
GO

-- Add Default Constraint DF_AccountRole_IsDisabled to AccountRole
Print 'Add Default Constraint DF_AccountRole_IsDisabled to AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountRole_IsDisabled'))
ALTER TABLE [dbo].[AccountRole]
	ADD
	CONSTRAINT [DF_AccountRole_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO

-- Add Column AccountBillingRateId to AccountProjectEmployee
Print 'Add Column AccountBillingRateId to AccountProjectEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountBillingRateId' AND TABLE_NAME='AccountProjectEmployee'))
ALTER TABLE [dbo].[AccountProjectEmployee]
	ADD [AccountBillingRateId] int NULL

GO

-- Add Column ShowClientData to SystemSecurityCategoryMasterAccountRole
Print 'Add Column ShowClientData to SystemSecurityCategoryMasterAccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemSecurityCategoryMasterAccountRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='ShowClientData' AND TABLE_NAME='SystemSecurityCategoryMasterAccountRole'))
ALTER TABLE [dbo].[SystemSecurityCategoryMasterAccountRole]
	ADD [ShowClientData] bit NULL

GO

-- Add Default Constraint DF_AccountLocation_CreatedByEmployeeId to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_CreatedByEmployeeId to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_CreatedByEmployeeId]
	DEFAULT (0) FOR [CreatedByEmployeeId]
GO

-- Add Default Constraint DF_AccountLocation_IsDisabled to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_IsDisabled to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_IsDisabled'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO

-- Add Default Constraint DF_AccountLocation_ModifiedByEmployeeId to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_ModifiedByEmployeeId to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_ModifiedByEmployeeId]
	DEFAULT (0) FOR [ModifiedByEmployeeId]
GO

-- Add Default Constraint DF_AccountDepartment_IsDeleted to AccountDepartment
Print 'Add Default Constraint DF_AccountDepartment_IsDeleted to AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDeleted'))
ALTER TABLE [dbo].[AccountDepartment]
	ADD
	CONSTRAINT [DF_AccountDepartment_IsDeleted]
	DEFAULT (0) FOR [IsDeleted]
GO

-- Add Default Constraint DF_AccountDepartment_IsDisabled to AccountDepartment
Print 'Add Default Constraint DF_AccountDepartment_IsDisabled to AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDisabled'))
ALTER TABLE [dbo].[AccountDepartment]
	ADD
	CONSTRAINT [DF_AccountDepartment_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO

-- Add Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId to AccountEmployeeAttendance
Print 'Add Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId to AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance]
	ADD
	CONSTRAINT [DF_AccountEmployeeAttendance_CreatedByEmployeeId]
	DEFAULT (0) FOR [CreatedByEmployeeId]
GO

-- Add Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId to AccountEmployeeAttendance
Print 'Add Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId to AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance]
	ADD
	CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedByEmployeeId]
	DEFAULT (0) FOR [ModifiedByEmployeeId]
GO

-- Create View vueTimesheetApprovalSequence
Print 'Create View vueTimesheetApprovalSequence'
GO
if not exists (select * from information_schema.tables where table_name = 'vueTimesheetApprovalSequence' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueTimesheetApprovalSequence
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId AND 
                      dbo.AccountEmployeeTimeEntryApproval.IsReject <> ''true'''
GO

-- Create View vueAccountApproverType
Print 'Create View vueAccountApproverType'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountApproverType' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountApproverType
AS
SELECT     dbo.AccountApprovalType.AccountApprovalTypeId, dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalType.AccountId, 
                      dbo.AccountApprovalType.MasterAccountApprovalTypeId, MAX(dbo.AccountApprovalPath.ApprovalPathSequence) AS MaxApprovalPathSequence
FROM         dbo.AccountApprovalType INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId
GROUP BY dbo.AccountApprovalType.AccountApprovalTypeId, dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalType.AccountId, 
                      dbo.AccountApprovalType.MasterAccountApprovalTypeId'
GO

-- Create View vueAccountEmployeeTimeEntryApproval
Print 'Create View vueAccountEmployeeTimeEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.AccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskDescription, dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, 
                      dbo.AccountEmployeeTimeEntry.Approved, dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountEmployeeTimeEntry.TotalTime, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntryApproval.Comments, dbo.AccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.AccountEmployeeTimeEntryApproval.IsApproved
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountProjectTask INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId'
GO

-- Create View vueAccountEmployeeWithBillingRate
Print 'Create View vueAccountEmployeeWithBillingRate'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeWithBillingRate' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeWithBillingRate
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.Password, dbo.AccountEmployee.Prefix, dbo.AccountEmployee.FirstName, 
                      dbo.AccountEmployee.LastName, dbo.AccountEmployee.MiddleName, dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.AccountId, 
                      dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountRoleId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.Notes, dbo.AccountEmployee.AddressLine1, dbo.AccountEmployee.AddressLine2, dbo.AccountEmployee.State, 
                      dbo.AccountEmployee.City, dbo.AccountEmployee.Zip, dbo.AccountEmployee.CountryId, dbo.AccountEmployee.HomePhoneNo, 
                      dbo.AccountEmployee.WorkPhoneNo, dbo.AccountEmployee.MobilePhoneNo, dbo.AccountEmployee.TimeEntryApprovalPathId, 
                      dbo.AccountEmployee.BillingRateStateDate, dbo.AccountEmployee.BillingTypeId, 
                      dbo.AccountEmployee.StartDate, dbo.AccountEmployee.TerminationDate, dbo.AccountEmployee.StatusId, dbo.AccountEmployee.IsDeleted, 
                      dbo.AccountEmployee.IsDisabled, dbo.AccountEmployee.DefaultProjectId, dbo.AccountEmployee.TimeZoneId, dbo.AccountEmployee.DefaultEmployee, 
                      dbo.AccountEmployee.CreatedOn, dbo.AccountEmployee.CreatedByEmployeeId, dbo.AccountEmployee.ModifiedOn, 
                      dbo.AccountEmployee.ModifiedByEmployeeId, dbo.AccountEmployee.AllowedAccessFromIP, dbo.AccountEmployee.ExternalUserClientId, 
                      dbo.AccountEmployee.EmployeeTypeId, dbo.AccountEmployee.AccountBillingRateId, dbo.AccountBillingRate.SystemBillingRateTypeId, 
                      dbo.AccountBillingRate.BillingRate, dbo.AccountBillingRate.StartDate AS BillingRateStartDate, 
                      dbo.AccountBillingRate.EndDate AS BillingRateEndDate
FROM         dbo.AccountEmployee LEFT OUTER JOIN
                      dbo.AccountBillingRate ON dbo.AccountEmployee.AccountBillingRateId = dbo.AccountBillingRate.AccountBillingRateId'
GO

-- Create View vueExpenseApprovalSequence
Print 'Create View vueExpenseApprovalSequence'
GO
if not exists (select * from information_schema.tables where table_name = 'vueExpenseApprovalSequence' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueExpenseApprovalSequence
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountExpenseEntryApproval.ExpenseApprovalId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.AccountExpenseEntry.AccountExpenseEntryId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountProject.AccountProjectId = dbo.AccountExpenseEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId AND 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId AND 
                      dbo.AccountExpenseEntryApproval.IsRejected <> ''true'''
GO

-- Create View vueAccountExpenseEntryApproval
Print 'Create View vueAccountExpenseEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountExpenseEntry.AccountExpenseEntryId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, dbo.AccountExpenseEntry.Amount, 
                      dbo.AccountExpense.AccountExpenseName, dbo.AccountExpense.IsBillable
FROM         dbo.AccountExpense RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountExpenseEntry.AccountEmployeeId ON 
                      dbo.AccountExpense.AccountExpenseId = dbo.AccountExpenseEntry.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId'
GO

-- Create Table SystemApproverType
Print 'Create Table SystemApproverType'
GO
if not exists (select * from information_schema.tables where table_name = 'SystemApproverType' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[SystemApproverType] (
		[SystemApproverTypeId]     smallint NOT NULL,
		[SystemApproverType]       varchar(30) NOT NULL
)
GO

-- Add Primary Key PK_SystemApproverType to SystemApproverType
Print 'Add Primary Key PK_SystemApproverType to SystemApproverType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemApproverType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_SystemApproverType' AND TABLE_NAME='SystemApproverType'))
ALTER TABLE [dbo].[SystemApproverType]
	ADD
	CONSTRAINT [PK_SystemApproverType]
	PRIMARY KEY
	([SystemApproverTypeId])
GO

-- Create Table SystemBillingRateType
Print 'Create Table SystemBillingRateType'
GO
if not exists (select * from information_schema.tables where table_name = 'SystemBillingRateType' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[SystemBillingRateType] (
		[SystemBillingRateTypeId]     smallint NOT NULL,
		[SystemBillingRateType]       varchar(50) NOT NULL
)
GO

-- Add Primary Key PK_SystemBillingRateType to SystemBillingRateType
Print 'Add Primary Key PK_SystemBillingRateType to SystemBillingRateType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemBillingRateType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_SystemBillingRateType' AND TABLE_NAME='SystemBillingRateType'))
ALTER TABLE [dbo].[SystemBillingRateType]
	ADD
	CONSTRAINT [PK_SystemBillingRateType]
	PRIMARY KEY
	([SystemBillingRateTypeId])
GO

-- Create Table MasterAccountApprovalPath
Print 'Create Table MasterAccountApprovalPath'
GO
if not exists (select * from information_schema.tables where table_name = 'MasterAccountApprovalPath' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[MasterAccountApprovalPath] (
		[MasterAccountApprovalPathId]     smallint NOT NULL,
		[MasterAccountApprovalTypeId]     smallint NOT NULL,
		[SystemApproverTypeId]            smallint NOT NULL,
		[ApprovalPathSequence]            tinyint NOT NULL
)
GO

-- Add Primary Key PK_MasterAccountApprovalPath to MasterAccountApprovalPath
Print 'Add Primary Key PK_MasterAccountApprovalPath to MasterAccountApprovalPath'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountApprovalPath' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_MasterAccountApprovalPath' AND TABLE_NAME='MasterAccountApprovalPath'))
ALTER TABLE [dbo].[MasterAccountApprovalPath]
	ADD
	CONSTRAINT [PK_MasterAccountApprovalPath]
	PRIMARY KEY
	([MasterAccountApprovalPathId])
GO

-- Create Table MasterAccountApprovalType
Print 'Create Table MasterAccountApprovalType'
GO
if not exists (select * from information_schema.tables where table_name = 'MasterAccountApprovalType' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[MasterAccountApprovalType] (
		[MasterAccountApprovalTypeId]     smallint NOT NULL,
		[ApprovalTypeName]                varchar(100) NOT NULL
)
GO

-- Add Primary Key PK_MasterAccountApprovalType to MasterAccountApprovalType
Print 'Add Primary Key PK_MasterAccountApprovalType to MasterAccountApprovalType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountApprovalType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_MasterAccountApprovalType' AND TABLE_NAME='MasterAccountApprovalType'))
ALTER TABLE [dbo].[MasterAccountApprovalType]
	ADD
	CONSTRAINT [PK_MasterAccountApprovalType]
	PRIMARY KEY
	([MasterAccountApprovalTypeId])
GO

-- Alter Column SystemTimeSheetApprovalPathId on SystemTimeSheetApprovalPath
Print 'Alter Column SystemTimeSheetApprovalPathId on SystemTimeSheetApprovalPath'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemTimeSheetApprovalPath' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='SystemTimeSheetApprovalPathId' AND TABLE_NAME='SystemTimeSheetApprovalPath'))
ALTER TABLE [dbo].[SystemTimeSheetApprovalPath]
	 ALTER COLUMN [SystemTimeSheetApprovalPathId] int NOT NULL
GO

-- Add Primary Key PK_SystemTimeSheetApprovalPath to SystemTimeSheetApprovalPath
Print 'Add Primary Key PK_SystemTimeSheetApprovalPath to SystemTimeSheetApprovalPath'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemTimeSheetApprovalPath' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_SystemTimeSheetApprovalPath' AND TABLE_NAME='SystemTimeSheetApprovalPath'))
ALTER TABLE [dbo].[SystemTimeSheetApprovalPath]
	ADD
	CONSTRAINT [PK_SystemTimeSheetApprovalPath]
	PRIMARY KEY
	([SystemTimeSheetApprovalPathId])
GO

-- Create Table SystemEmployeeType
Print 'Create Table SystemEmployeeType'
GO
if not exists (select * from information_schema.tables where table_name = 'SystemEmployeeType' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[SystemEmployeeType] (
		[EmployeeTypeId]     tinyint NOT NULL,
		[EmployeeType]       varchar(50) NULL
)
GO

-- Add Primary Key PK_EmployeeType to SystemEmployeeType
Print 'Add Primary Key PK_EmployeeType to SystemEmployeeType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemEmployeeType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_EmployeeType' AND TABLE_NAME='SystemEmployeeType'))
ALTER TABLE [dbo].[SystemEmployeeType]
	ADD
	CONSTRAINT [PK_EmployeeType]
	PRIMARY KEY
	([EmployeeTypeId])
GO

-- Create View vueAccountProjectTask
Print 'Create View vueAccountProjectTask'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTask' and table_type = 'VIEW') 
EXEC sp_executesql N'

CREATE VIEW dbo.vueAccountProjectTask
AS
SELECT     dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.AccountTaskTypeId, 
                      dbo.AccountProjectTask.Duration, dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, 
                      dbo.AccountProjectTask.CompletedPercent, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.CreatedOn, dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.ModifiedOn, 
                      dbo.AccountProjectTask.ModifiedByEmployeeId, dbo.AccountStatus.Status AS TaskStatus, dbo.AccountEmployee.FirstName AS CreatedByFirstName, 
                      dbo.AccountEmployee.LastName AS CreatedByLastName, dbo.AccountPriority.Priority, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectCode, dbo.AccountTaskType.TaskType, dbo.AccountProject.AccountId, dbo.AccountProjectTask.AccountProjectMilestoneId, 
                      dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountProjectTask.IsReOpen, AccountEmployee_1.FirstName AS ModifiedByFirstName, 
                      AccountEmployee_1.LastName AS ModifiedByLastName, dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, 
                      dbo.AccountProjectTask.EstimatedTimeSpentUnit
FROM         dbo.AccountStatus RIGHT OUTER JOIN
                      dbo.AccountTaskType RIGHT OUTER JOIN
                      dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTask LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountProjectTask.ModifiedByEmployeeId = AccountEmployee_1.AccountEmployeeId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountProjectMilestone ON 
                      dbo.AccountProjectTask.AccountProjectMilestoneId = dbo.AccountProjectMilestone.AccountProjectMilestoneId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountTaskType.AccountTaskTypeId = dbo.AccountProjectTask.AccountTaskTypeId ON 
                      dbo.AccountStatus.AccountStatusId = dbo.AccountProjectTask.TaskStatusId LEFT OUTER JOIN
                      dbo.AccountPriority ON dbo.AccountProjectTask.AccountPriorityId = dbo.AccountPriority.AccountPriorityId'
GO

-- Create View vueAccountProjectRole
Print 'Create View vueAccountProjectRole'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectRole' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectRole
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountRole.AccountRoleId, dbo.AccountRole.AccountId, 
                      dbo.AccountRole.Role, dbo.AccountRole.MasterAccountRoleId, dbo.AccountProjectRole.AccountProjectRoleId, dbo.AccountProjectRole.BillingTypeId, 
                      dbo.AccountProjectRole.NumberOfResources, dbo.AccountBillingRate.SystemBillingRateTypeId, dbo.AccountBillingRate.BillingRate, 
                      dbo.AccountBillingRate.StartDate, dbo.AccountBillingRate.EndDate, dbo.AccountProjectRole.AccountBillingRateId, 
                      dbo.AccountProject.DefaultBillingRate AS RoleBillingRate
FROM         dbo.AccountBillingRate RIGHT OUTER JOIN
                      dbo.AccountProjectRole ON dbo.AccountBillingRate.AccountBillingRateId = dbo.AccountProjectRole.AccountBillingRateId RIGHT OUTER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountRole ON dbo.AccountProject.AccountId = dbo.AccountRole.AccountId ON 
                      dbo.AccountProjectRole.AccountRoleId = dbo.AccountRole.AccountRoleId AND 
                      dbo.AccountProjectRole.AccountProjectId = dbo.AccountProject.AccountProjectId'
GO

-- Create View vueAccountProjectRoleBillingRate
Print 'Create View vueAccountProjectRoleBillingRate'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectRoleBillingRate' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectRoleBillingRate
AS
SELECT     dbo.AccountProjectRole.AccountProjectRoleId, dbo.AccountProjectRole.AccountProjectId, dbo.AccountProjectRole.AccountRoleId, 
                      dbo.AccountProjectRole.NumberOfResources, dbo.AccountProjectRole.BillingRate, dbo.AccountProjectRole.BillingTypeId, 
                      dbo.AccountProjectRole.AccountBillingRateId, dbo.AccountProjectEmployee.AccountProjectEmployeeId, 
                      dbo.AccountProjectEmployee.AccountEmployeeId
FROM         dbo.AccountProjectEmployee INNER JOIN
                      dbo.AccountProjectRole ON dbo.AccountProjectEmployee.AccountProjectId = dbo.AccountProjectRole.AccountProjectId AND 
                      dbo.AccountProjectEmployee.AccountRoleId = dbo.AccountProjectRole.AccountRoleId'
GO

-- Create View vueExternalAccountEmployee
Print 'Create View vueExternalAccountEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueExternalAccountEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueExternalAccountEmployee
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.AccountId, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.Password, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.BillingTypeId, dbo.AccountBillingType.BillingType, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountPreferences.ShowClockStartEnd, 
                      dbo.Account.TimeZoneId, dbo.AccountRole.MasterAccountRoleId, dbo.Account.DefaultCurrencyId, dbo.Account.CountryId, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.TimeEntryFormat, dbo.AccountEmployee.AllowedAccessFromIP, 
                      dbo.AccountRole.AccountRoleId, dbo.AccountPreferences.AccountSessionTimeout, dbo.AccountPreferences.ShowCompletedTasksInTimeSheet, 
                      dbo.AccountPreferences.CurrencySymbol, dbo.AccountPreferences.IsCompanyOwnLogo, dbo.Account.AccountExpiryActivation, 
                      dbo.Account.LicenseActivation, dbo.AccountEmployee.EmployeeTypeId, dbo.AccountEmployee.ExternalUserClientId, dbo.AccountParty.PartyName, 
                      dbo.AccountParty.PartyNick
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountEmployee.ExternalUserClientId = dbo.AccountParty.AccountPartyId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId'
GO

-- Create View vueTaskBillingRate
Print 'Create View vueTaskBillingRate'
GO
if not exists (select * from information_schema.tables where table_name = 'vueTaskBillingRate' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueTaskBillingRate
AS
SELECT     CASE WHEN dbo.AccountProject.ProjectBillingRateTypeId = 2 THEN dbo.AccountProjectRole.BillingRate ELSE dbo.AccountProjectRole.BillingRate END AS
                       BillingRate, 
                      CASE WHEN dbo.AccountProject.ProjectBillingRateTypeId = 2 THEN dbo.AccountProjectRole.BillingTypeId ELSE dbo.AccountEmployee.BillingTypeId END
                       AS BillingTypeId, dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTaskEmployee.AccountEmployeeId, 
                      dbo.AccountEmployee.BillingTypeId AS EmployeeBillingTypeId, dbo.AccountProjectRole.BillingRate AS EmployeeBillingRate, 
                      dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountProject.ProjectBillingRateTypeId, dbo.AccountProjectEmployee.AccountRoleId, dbo.AccountProjectEmployee.AccountProjectEmployeeId, 
                      dbo.AccountProjectRole.NumberOfResources, dbo.AccountProjectRole.BillingRate AS RoleBillingRate, 
                      dbo.AccountProjectRole.BillingTypeId AS RoleBillingTypeId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountProject.AccountProjectId = dbo.AccountProjectTask.AccountProjectId INNER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountProjectRole ON dbo.AccountProjectEmployee.AccountProjectId = dbo.AccountProjectRole.AccountProjectId AND 
                      dbo.AccountProjectEmployee.AccountRoleId = dbo.AccountProjectRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountProjectTaskEmployee ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTaskEmployee.AccountEmployeeId ON 
                      dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountProjectTaskEmployee.AccountEmployeeId AND 
                      dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountProjectTaskEmployee.AccountProjectTaskId'
GO

-- Create View vueAccountEmployeeTimeEntry
Print 'Create View vueAccountEmployeeTimeEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountProject.ProjectName, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProject.AccountProjectId, dbo.AccountEmployeeTimeEntry.TeamLeadApproved, 
                      dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, dbo.AccountEmployeeTimeEntry.AdministratorApproved, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.Description, dbo.AccountProject.AccountId, DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, DATEPART(dw, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS WeekDay, dbo.AccountParty.AccountPartyId, dbo.AccountParty.PartyName, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountBillingType.BillingType, dbo.AccountProject.LeaderEmployeeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, 
                      dbo.AccountProjectTask.IsBillable, dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, 
                      dbo.AccountProject.ProjectBillingRateTypeId
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId'
GO

-- Create View vueAccountEmployeeTimeEntryWithAccountProjectEmployee
Print 'Create View vueAccountEmployeeTimeEntryWithAccountProjectEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithAccountProjectEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithAccountProjectEmployee
AS
SELECT     dbo.AccountProjectEmployee.AccountProjectEmployeeId, dbo.AccountProjectEmployee.AccountId, dbo.AccountProjectEmployee.AccountProjectId, 
                      dbo.AccountProjectEmployee.AccountEmployeeId, dbo.AccountProjectEmployee.TaskCompletedPercentage, 
                      dbo.AccountProjectEmployee.TaskCompleted, dbo.AccountProjectEmployee.AccountRoleId, dbo.AccountProjectEmployee.AccountBillingRateId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountProject.ProjectBillingRateTypeId
FROM         dbo.AccountProjectEmployee INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND 
                      dbo.AccountProjectEmployee.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId'
GO

-- Create View vueAccountEmployeeTimeEntryApprovalPending
Print 'Create View vueAccountEmployeeTimeEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPending
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectId, dbo.vueAccountEmployeeTimeEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.SystemApproverTypeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectDescription, dbo.vueAccountEmployeeTimeEntryApproval.ProjectCode, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskName, dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskDescription, dbo.vueAccountEmployeeTimeEntryApproval.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Approved, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TotalTime, dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Comments, dbo.vueAccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApproval.IsApproved, dbo.vueAccountApproverType.MaxApprovalPathSequence
FROM         dbo.vueAccountEmployeeTimeEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId IN
                          (SELECT      AccountApprovalPathId
                            FROM          dbo.vueTimesheetApprovalSequence
                            WHERE      (TimeSheetApprovalId IS NULL) AND (AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId)))'
GO

-- Create View vueAccountEmployee
Print 'Create View vueAccountEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployee
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.AccountId, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.Password, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.BillingTypeId, dbo.AccountBillingType.BillingType, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountPreferences.ShowClockStartEnd, 
                      dbo.Account.TimeZoneId, dbo.AccountRole.MasterAccountRoleId, dbo.Account.DefaultCurrencyId, dbo.Account.CountryId, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.TimeEntryFormat, dbo.AccountEmployee.AllowedAccessFromIP, 
                      dbo.AccountRole.AccountRoleId, dbo.AccountPreferences.AccountSessionTimeout, dbo.AccountPreferences.ShowCompletedTasksInTimeSheet, 
                      dbo.AccountPreferences.CurrencySymbol, dbo.AccountPreferences.IsCompanyOwnLogo, dbo.Account.AccountExpiryActivation, 
                      dbo.Account.LicenseActivation, dbo.AccountEmployee.EmployeeTypeId, dbo.AccountEmployee.ExternalUserClientId, 
                      dbo.AccountEmployee.AccountBillingRateId
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId'
GO

-- Create View vueAccountApproval
Print 'Create View vueAccountApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountApproval
AS
SELECT     AccountId, MasterAccountApprovalTypeId, AccountApprovalTypeId, ApprovalTypeName
FROM         dbo.AccountApprovalType'
GO

-- Create View vueAccount
Print 'Create View vueAccount'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccount' and table_type = 'VIEW') 
EXEC sp_executesql N'

CREATE VIEW dbo.vueAccount
AS
SELECT     dbo.Account.AccountId, dbo.Account.AccountTypeId, dbo.Account.AccountName, dbo.Account.Address1, dbo.Account.Address2, dbo.Account.ZipCode, 
                      dbo.Account.State, dbo.Account.City, dbo.Account.CountryId, dbo.Account.EMailAddress, dbo.Account.Telephone, dbo.Account.Fax, 
                      dbo.Account.DefaultCurrencyId, dbo.Account.TimeZoneId, dbo.Account.IsDisabled, dbo.Account.IsDeleted, dbo.Account.StatusId, 
                      dbo.Account.CreatedOn, dbo.Account.ModifiedOn, dbo.Account.ModifiedByEmployeeId, dbo.AccountPreferences.ShowClockStartEnd, 
                      dbo.AccountPreferences.AccountPreferencesId, dbo.Account.LicenseKey, dbo.Account.SystemPackageTypeId, 
                      dbo.AccountPreferences.TimeEntryFormat
FROM         dbo.Account INNER JOIN
                      dbo.AccountPreferences ON dbo.Account.AccountId = dbo.AccountPreferences.AccountId
'
GO

-- Create View vueAccountBillingType
Print 'Create View vueAccountBillingType'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountBillingType' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW [dbo].[vueAccountBillingType]
AS
SELECT     dbo.AccountBillingType.AccountBillingTypeId, dbo.AccountBillingType.AccountId, dbo.AccountBillingType.BillingType, 
                      dbo.SystemBillingCategory.SystemBillingCategory, dbo.AccountBillingType.MasterAccountBillingTypeId
FROM         dbo.AccountBillingType LEFT OUTER JOIN
                      dbo.SystemBillingCategory ON dbo.AccountBillingType.BillingCategoryId = dbo.SystemBillingCategory.SystemBillingCategoryId 
'
GO

-- Create View vueAccountProjectEmployeeBillingRate
Print 'Create View vueAccountProjectEmployeeBillingRate'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectEmployeeBillingRate' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectEmployeeBillingRate
AS
SELECT     dbo.AccountProjectEmployee.*
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountProject.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId'
GO

-- Create View vueAccountProjectEmployee
Print 'Create View vueAccountProjectEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectEmployee
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountEmployee.Password, dbo.AccountEmployee.FirstName, 
                      dbo.AccountEmployee.LastName, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProjectEmployee.AccountProjectEmployeeId, 
                      dbo.AccountEmployee.AccountId, dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS FullName, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountProjectEmployee.AccountRoleId, 
                      dbo.AccountProjectEmployee.AccountBillingRateId, dbo.AccountBillingRate.StartDate, dbo.AccountBillingRate.EndDate, 
                      dbo.AccountBillingRate.BillingRate, dbo.vueAccountEmployeeWithBillingRate.BillingRate AS EmployeeBillingRate, 
                      dbo.AccountBillingRate.SystemBillingRateTypeId
FROM         dbo.vueAccountEmployeeWithBillingRate RIGHT OUTER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProject.AccountId = dbo.AccountEmployee.AccountId ON 
                      dbo.vueAccountEmployeeWithBillingRate.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountProjectEmployee LEFT OUTER JOIN
                      dbo.AccountBillingRate ON dbo.AccountProjectEmployee.AccountBillingRateId = dbo.AccountBillingRate.AccountBillingRateId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId AND 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectEmployee.AccountEmployeeId'
GO

-- Create View vueAccountExpenseEntryApprovalPending
Print 'Create View vueAccountExpenseEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryApprovalPending
AS
SELECT     dbo.vueAccountExpenseEntryApproval.AccountProjectId, dbo.vueAccountExpenseEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId, dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountExpenseEntryApproval.SystemApproverTypeId, dbo.vueAccountExpenseEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApproval.AccountEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId, dbo.vueAccountExpenseEntryApproval.ExpenseApprovalId, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.vueAccountExpenseEntryApproval.ProjectName, 
                      dbo.vueAccountExpenseEntryApproval.ProjectDescription, dbo.vueAccountExpenseEntryApproval.ProjectCode, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeName, dbo.vueAccountExpenseEntryApproval.Approved, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntryApproval.Comments, dbo.vueAccountExpenseEntryApproval.IsRejected, 
                      dbo.vueAccountExpenseEntryApproval.IsApproved, dbo.vueAccountExpenseEntryApproval.Amount, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseName, dbo.vueAccountExpenseEntryApproval.IsBillable, 
                      dbo.vueAccountApproverType.MaxApprovalPathSequence
FROM         dbo.vueAccountExpenseEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId IN
                          (SELECT      AccountApprovalPathId
                            FROM          dbo.vueExpenseApprovalSequence AS vueExpenseApprovalSequence_1
                            WHERE      (ExpenseApprovalId IS NULL) AND (AccountExpenseEntryId = dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId)))'
GO

-- Create View vueAccountEmployeeTimeEntryWithAccountProjectRole
Print 'Create View vueAccountEmployeeTimeEntryWithAccountProjectRole'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithAccountProjectRole' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithAccountProjectRole
AS
SELECT     dbo.AccountProjectRole.AccountProjectRoleId, dbo.AccountProjectRole.AccountProjectId, dbo.AccountProjectRole.AccountRoleId, 
                      dbo.AccountProjectRole.NumberOfResources, dbo.AccountProjectRole.BillingRate, dbo.AccountProjectRole.BillingTypeId, 
                      dbo.AccountProjectRole.AccountBillingRateId, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeId, dbo.AccountProject.ProjectBillingRateTypeId
FROM         dbo.AccountProjectRole INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectRole.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId INNER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountProjectRole.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId AND 
                      dbo.AccountProjectRole.AccountRoleId = dbo.AccountProjectEmployee.AccountRoleId INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId'
GO

-- Create View vueAccountExpenseEntry
Print 'Create View vueAccountExpenseEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpense.AccountExpenseName, 
                      dbo.AccountProject.ProjectName, dbo.AccountExpenseEntry.AccountExpenseEntryId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountProjectId, 
                      dbo.AccountExpenseEntry.AccountExpenseId, dbo.AccountExpenseEntry.Amount, dbo.AccountExpenseEntry.TeamLeadApproved, 
                      dbo.AccountExpenseEntry.ProjectManagerApproved, dbo.AccountExpenseEntry.AdministratorApproved, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountExpenseEntry.CreatedOn, dbo.AccountExpenseEntry.CreatedByEmployeeId, dbo.AccountExpenseEntry.ModifiedOn, 
                      dbo.AccountExpenseEntry.ModifiedByEmployeeId, dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, 
                      dbo.AccountExpenseEntry.Description, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountExpenseTypeId, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpenseEntry.Rejected
FROM         dbo.AccountExpenseType RIGHT OUTER JOIN
                      dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId ON 
                      dbo.AccountExpenseType.AccountExpenseTypeId = dbo.AccountExpense.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId'
GO

-- Create Trigger tr_trigtest
Print 'Create Trigger tr_trigtest'
GO
IF NOT (EXISTS(SELECT * FROM sysobjects WHERE id = OBJECT_ID(N'[dbo].[tr_trigtest]') AND [type]='TR'))
EXEC sp_executesql N'CREATE trigger [dbo].[tr_trigtest] on dbo.AccountProjectTask for insert, update, delete
as

declare @bit int ,
	@field int ,
	@maxfield int ,
	@char int ,
	@fieldname varchar(128) ,
	@TableName varchar(128) ,
	@PKCols varchar(1000) ,
	@sql varchar(2000), 
	@UpdateDate varchar(21) ,
	@UserName varchar(128) ,
	@Type char(1) ,
	@PKSelect varchar(1000)
	
	select @TableName = ''AccountProjectTask''

	-- date and user
	select 	@UserName = system_user ,
		@UpdateDate = convert(varchar(8), getdate(), 112) + '' '' + convert(varchar(12), getdate(), 114)



	-- Action
	if exists (select * from inserted)
		if exists (select * from deleted)
			Begin
				select @Type = ''U''
				select @UserName  = ModifiedByEmployeeId from inserted
			End 
		else
			Begin
				select @UserName  = CreatedByEmployeeId from inserted
				select @Type = ''I''
			End
	else
		Begin
			select @Type = ''D''
			select @UserName  = ModifiedByEmployeeId from deleted
		End 
	
	-- get list of columns
	select * into #ins from inserted
	select * into #del from deleted
	
	-- Get primary key columns for full outer join
	select	@PKCols = coalesce(@PKCols + '' and'', '' on'') + '' i.'' + c.COLUMN_NAME + '' = d.'' + c.COLUMN_NAME
	from	INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,
		INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
	where 	pk.TABLE_NAME = @TableName
	and	CONSTRAINT_TYPE = ''PRIMARY KEY''
	and	c.TABLE_NAME = pk.TABLE_NAME
	and	c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
	
	-- Get primary key select for insert
	select @PKSelect = coalesce(@PKSelect+''+'','''') + ''''''<'' + COLUMN_NAME + ''=''''+convert(varchar(100),coalesce(i.'' + COLUMN_NAME +'',d.'' + COLUMN_NAME + ''))+''''>'''''' 
	from	INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,
		INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
	where 	pk.TABLE_NAME = @TableName
	and	CONSTRAINT_TYPE = ''PRIMARY KEY''
	and	c.TABLE_NAME = pk.TABLE_NAME
	and	c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
	
	if @PKCols is null
	begin
		raiserror(''no PK on table %s'', 16, -1, @TableName)
		return
	end
	
	select @field = 0, @maxfield = max(ORDINAL_POSITION) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName
	while @field < @maxfield
	begin
		select @field = min(ORDINAL_POSITION) from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName and ORDINAL_POSITION > @field
		select @bit = (@field - 1 )% 8 + 1
		select @bit = power(2,@bit - 1)
		select @char = ((@field - 1) / 8) + 1
		if substring(COLUMNS_UPDATED(),@char, 1) & @bit > 0 or @Type in (''I'',''D'')
		begin
			select @fieldname = COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName and ORDINAL_POSITION = @field
			select @sql = 		''insert Audit (Type, TableName, PK, FieldName, OldValue, NewValue, UpdateDate, UserName)''
			select @sql = @sql + 	'' select '''''' + @Type + ''''''''
			select @sql = @sql + 	'','''''' + @TableName + ''''''''
			select @sql = @sql + 	'','' + Replace(Replace(@PKSelect,''<AccountProjectTaskId='',''''),''>'','''')
			select @sql = @sql + 	'','''''' + @fieldname + ''''''''
			select @sql = @sql + 	'',convert(varchar(1000),d.'' + @fieldname + '')''
			select @sql = @sql + 	'',convert(varchar(1000),i.'' + @fieldname + '')''
			select @sql = @sql + 	'','''''' + @UpdateDate + ''''''''
			select @sql = @sql + 	'','''''' + @UserName + ''''''''
			select @sql = @sql + 	'' from #ins i full outer join #del d''
			select @sql = @sql + 	@PKCols
			select @sql = @sql + 	'' where i.'' + @fieldname + '' <> d.'' + @fieldname 
			select @sql = @sql + 	'' or (i.'' + @fieldname + '' is null and  d.'' + @fieldname + '' is not null)'' 
			select @sql = @sql + 	'' or (i.'' + @fieldname + '' is not null and  d.'' + @fieldname + '' is null)'' 
			exec (@sql)
		end
	end'
GO

-- Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountApprovalPath on AccountEmployeeTimeEntryApproval
Print 'Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountApprovalPath on AccountEmployeeTimeEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployeeTimeEntryApproval_AccountApprovalPath' AND TABLE_NAME='AccountEmployeeTimeEntryApproval')

BEGIN
		ALTER TABLE [dbo].[AccountEmployeeTimeEntryApproval]
			ADD CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountApprovalPath]
			FOREIGN KEY ([TimeSheetApprovalPathId]) REFERENCES [dbo].[AccountApprovalPath] ([AccountApprovalPathId])
END
GO

-- Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountApprovalType on AccountEmployeeTimeEntryApproval
Print 'Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountApprovalType on AccountEmployeeTimeEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployeeTimeEntryApproval_AccountApprovalType' AND TABLE_NAME='AccountEmployeeTimeEntryApproval')
BEGIN
		ALTER TABLE [dbo].[AccountEmployeeTimeEntryApproval]
			ADD CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountApprovalType]
			FOREIGN KEY ([TimeSheetApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId])
END
GO

-- Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntry on AccountEmployeeTimeEntryApproval
Print 'Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntry on AccountEmployeeTimeEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntry' AND TABLE_NAME='AccountEmployeeTimeEntryApproval')
BEGIN
		ALTER TABLE [dbo].[AccountEmployeeTimeEntryApproval]
			ADD CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntry]
			FOREIGN KEY ([AccountEmployeeTimeEntryId]) REFERENCES [dbo].[AccountEmployeeTimeEntry] ([AccountEmployeeTimeEntryId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountBillingRate_SystemBillingRateType on AccountBillingRate
Print 'Create Foreign Key FK_AccountBillingRate_SystemBillingRateType on AccountBillingRate'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountBillingRate_SystemBillingRateType' AND TABLE_NAME='AccountBillingRate')
BEGIN
		ALTER TABLE [dbo].[AccountBillingRate]
			ADD CONSTRAINT [FK_AccountBillingRate_SystemBillingRateType]
			FOREIGN KEY ([SystemBillingRateTypeId]) REFERENCES [dbo].[SystemBillingRateType] ([SystemBillingRateTypeId])
END
GO

-- Create Foreign Key FK_AccountApprovalPath_AccountApprovalType on AccountApprovalPath
Print 'Create Foreign Key FK_AccountApprovalPath_AccountApprovalType on AccountApprovalPath'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountApprovalPath_AccountApprovalType' AND TABLE_NAME='AccountApprovalPath')
BEGIN
		ALTER TABLE [dbo].[AccountApprovalPath]
			ADD CONSTRAINT [FK_AccountApprovalPath_AccountApprovalType]
			FOREIGN KEY ([AccountApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId])
			ON DELETE CASCADE
			ON UPDATE CASCADE
END
GO

-- Create Foreign Key FK_AccountApprovalPath_SystemApproverType on AccountApprovalPath
Print 'Create Foreign Key FK_AccountApprovalPath_SystemApproverType on AccountApprovalPath'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountApprovalPath_SystemApproverType' AND TABLE_NAME='AccountApprovalPath')
BEGIN
		ALTER TABLE [dbo].[AccountApprovalPath]
			ADD CONSTRAINT [FK_AccountApprovalPath_SystemApproverType]
			FOREIGN KEY ([SystemApproverTypeId]) REFERENCES [dbo].[SystemApproverType] ([SystemApproverTypeId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountEmployee_SystemTimeZone on AccountEmployee
Print 'Create Foreign Key FK_AccountEmployee_SystemTimeZone on AccountEmployee'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployee_SystemTimeZone' AND TABLE_NAME='AccountEmployee')
BEGIN
		ALTER TABLE [dbo].[AccountEmployee]
			ADD CONSTRAINT [FK_AccountEmployee_SystemTimeZone]
			FOREIGN KEY ([TimeZoneId]) REFERENCES [dbo].[SystemTimeZone] ([SystemTimeZoneId])
END
GO

-- Create Foreign Key FK_AccountEmployee_AccountParty on AccountEmployee
Print 'Create Foreign Key FK_AccountEmployee_AccountParty on AccountEmployee'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployee_AccountParty' AND TABLE_NAME='AccountEmployee')
BEGIN
		ALTER TABLE [dbo].[AccountEmployee]
			ADD CONSTRAINT [FK_AccountEmployee_AccountParty]
			FOREIGN KEY ([ExternalUserClientId]) REFERENCES [dbo].[AccountParty] ([AccountPartyId])
END
GO

-- Create Foreign Key FK_AccountProject_AccountApprovalType on AccountProject
Print 'Create Foreign Key FK_AccountProject_AccountApprovalType on AccountProject'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountApprovalType' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountProject]
			ADD CONSTRAINT [FK_AccountProject_AccountApprovalType]
			FOREIGN KEY ([ExpenseApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId])
		ALTER TABLE [dbo].[AccountProject]
			CHECK CONSTRAINT [FK_AccountProject_AccountApprovalType]

END
GO

-- Create Foreign Key FK_AccountProject_AccountApprovalType2 on AccountProject
Print 'Create Foreign Key FK_AccountProject_AccountApprovalType2 on AccountProject'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountApprovalType2' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountProject]
			ADD CONSTRAINT [FK_AccountProject_AccountApprovalType2]
			FOREIGN KEY ([TimeSheetApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId])
		ALTER TABLE [dbo].[AccountProject]
			CHECK CONSTRAINT [FK_AccountProject_AccountApprovalType2]

END
GO

-- Create Foreign Key FK_AccountExpenseEntryApproval_AccountApprovalPath on AccountExpenseEntryApproval
Print 'Create Foreign Key FK_AccountExpenseEntryApproval_AccountApprovalPath on AccountExpenseEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountApprovalType2' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntryApproval]
			ADD CONSTRAINT [FK_AccountExpenseEntryApproval_AccountApprovalPath]
			FOREIGN KEY ([ExpenseApprovalPathId]) REFERENCES [dbo].[AccountApprovalPath] ([AccountApprovalPathId])
END
GO

-- Create Foreign Key FK_AccountExpenseEntryApproval_AccountApprovalType on AccountExpenseEntryApproval
Print 'Create Foreign Key FK_AccountExpenseEntryApproval_AccountApprovalType on AccountExpenseEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntryApproval_AccountApprovalType' AND TABLE_NAME='AccountExpenseEntryApproval')

BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntryApproval]
			ADD CONSTRAINT [FK_AccountExpenseEntryApproval_AccountApprovalType]
			FOREIGN KEY ([ExpenseApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId])
END
GO

-- Create Foreign Key FK_AccountExpenseEntryApproval_AccountExpenseEntry on AccountExpenseEntryApproval
Print 'Create Foreign Key FK_AccountExpenseEntryApproval_AccountExpenseEntry on AccountExpenseEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntryApproval_AccountExpenseEntry' AND TABLE_NAME='AccountExpenseEntryApproval')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntryApproval]
			ADD CONSTRAINT [FK_AccountExpenseEntryApproval_AccountExpenseEntry]
			FOREIGN KEY ([AccountExpenseEntryId]) REFERENCES [dbo].[AccountExpenseEntry] ([AccountExpenseEntryId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountApprovalType_Account on AccountApprovalType
Print 'Create Foreign Key FK_AccountApprovalType_Account on AccountApprovalType'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountApprovalType_Account' AND TABLE_NAME='AccountApprovalType')
BEGIN
		ALTER TABLE [dbo].[AccountApprovalType]
			ADD CONSTRAINT [FK_AccountApprovalType_Account]
			FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountApprovalPath on AccountEmployeeTimeEntryApproval
Print 'Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountApprovalPath on AccountEmployeeTimeEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployeeTimeEntryApproval_AccountApprovalPath' AND TABLE_NAME='AccountEmployeeTimeEntryApproval')
BEGIN
		ALTER TABLE [dbo].[AccountEmployeeTimeEntryApproval]
			ADD CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountApprovalPath]
			FOREIGN KEY ([TimeSheetApprovalPathId]) REFERENCES [dbo].[AccountApprovalPath] ([AccountApprovalPathId])
END
GO

-- Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountApprovalType on AccountEmployeeTimeEntryApproval
Print 'Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountApprovalType on AccountEmployeeTimeEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployeeTimeEntryApproval_AccountApprovalType' AND TABLE_NAME='AccountEmployeeTimeEntryApproval')
BEGIN
		ALTER TABLE [dbo].[AccountEmployeeTimeEntryApproval]
			ADD CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountApprovalType]
			FOREIGN KEY ([TimeSheetApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId])
END
GO

-- Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntry on AccountEmployeeTimeEntryApproval
Print 'Create Foreign Key FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntry on AccountEmployeeTimeEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntry' AND TABLE_NAME='AccountEmployeeTimeEntryApproval')
BEGIN
		ALTER TABLE [dbo].[AccountEmployeeTimeEntryApproval]
			ADD CONSTRAINT [FK_AccountEmployeeTimeEntryApproval_AccountEmployeeTimeEntry]
			FOREIGN KEY ([AccountEmployeeTimeEntryId]) REFERENCES [dbo].[AccountEmployeeTimeEntry] ([AccountEmployeeTimeEntryId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountBillingRate_SystemBillingRateType on AccountBillingRate
Print 'Create Foreign Key FK_AccountBillingRate_SystemBillingRateType on AccountBillingRate'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountBillingRate_SystemBillingRateType' AND TABLE_NAME='AccountBillingRate')
BEGIN
		ALTER TABLE [dbo].[AccountBillingRate]
			ADD CONSTRAINT [FK_AccountBillingRate_SystemBillingRateType]
			FOREIGN KEY ([SystemBillingRateTypeId]) REFERENCES [dbo].[SystemBillingRateType] ([SystemBillingRateTypeId])
END
GO

-- Create Foreign Key FK_AccountApprovalPath_AccountApprovalType on AccountApprovalPath
Print 'Create Foreign Key FK_AccountApprovalPath_AccountApprovalType on AccountApprovalPath'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountApprovalPath_AccountApprovalType' AND TABLE_NAME='AccountApprovalPath')
BEGIN
		ALTER TABLE [dbo].[AccountApprovalPath]
			ADD CONSTRAINT [FK_AccountApprovalPath_AccountApprovalType]
			FOREIGN KEY ([AccountApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId])
			ON DELETE CASCADE
			ON UPDATE CASCADE
END
GO

-- Create Foreign Key FK_AccountApprovalPath_SystemApproverType on AccountApprovalPath
Print 'Create Foreign Key FK_AccountApprovalPath_SystemApproverType on AccountApprovalPath'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountApprovalPath_SystemApproverType' AND TABLE_NAME='AccountApprovalPath')
BEGIN
		ALTER TABLE [dbo].[AccountApprovalPath]
			ADD CONSTRAINT [FK_AccountApprovalPath_SystemApproverType]
			FOREIGN KEY ([SystemApproverTypeId]) REFERENCES [dbo].[SystemApproverType] ([SystemApproverTypeId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountExpenseEntryApproval_AccountApprovalPath on AccountExpenseEntryApproval
Print 'Create Foreign Key FK_AccountExpenseEntryApproval_AccountApprovalPath on AccountExpenseEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntryApproval_AccountApprovalPath' AND TABLE_NAME='AccountExpenseEntryApproval')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntryApproval]
			ADD CONSTRAINT [FK_AccountExpenseEntryApproval_AccountApprovalPath]
			FOREIGN KEY ([ExpenseApprovalPathId]) REFERENCES [dbo].[AccountApprovalPath] ([AccountApprovalPathId])
END
GO

-- Create Foreign Key FK_AccountExpenseEntryApproval_AccountApprovalType on AccountExpenseEntryApproval
Print 'Create Foreign Key FK_AccountExpenseEntryApproval_AccountApprovalType on AccountExpenseEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntryApproval_AccountApprovalType' AND TABLE_NAME='AccountExpenseEntryApproval')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntryApproval]
			ADD CONSTRAINT [FK_AccountExpenseEntryApproval_AccountApprovalType]
			FOREIGN KEY ([ExpenseApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId])
END
GO

-- Create Foreign Key FK_AccountExpenseEntryApproval_AccountExpenseEntry on AccountExpenseEntryApproval
Print 'Create Foreign Key FK_AccountExpenseEntryApproval_AccountExpenseEntry on AccountExpenseEntryApproval'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntryApproval_AccountExpenseEntry' AND TABLE_NAME='AccountExpenseEntryApproval')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntryApproval]
			ADD CONSTRAINT [FK_AccountExpenseEntryApproval_AccountExpenseEntry]
			FOREIGN KEY ([AccountExpenseEntryId]) REFERENCES [dbo].[AccountExpenseEntry] ([AccountExpenseEntryId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountApprovalType_Account on AccountApprovalType
Print 'Create Foreign Key FK_AccountApprovalType_Account on AccountApprovalType'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountApprovalType_Account' AND TABLE_NAME='AccountApprovalType')
BEGIN
		ALTER TABLE [dbo].[AccountApprovalType]
			ADD CONSTRAINT [FK_AccountApprovalType_Account]
			FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId])
			ON DELETE CASCADE
END
GO

--INSERTING RECORDS IN MASTER AND SYSTEM TABLES

-- =======================================================
-- Foreign Key Constraint Nochecks's for Table: [dbo].[SystemSecurityCategoryPermission]
-- =======================================================
Print ' Foreign Key Constraint Nochecks''s for Table: [dbo].[SystemSecurityCategoryPermission]'

ALTER TABLE [dbo].[SystemSecurityCategoryPermission] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPermission_SystemPermission]
ALTER TABLE [dbo].[SystemSecurityCategoryPermission] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPermission_SystemSecurityCategory]
GO
-- =======================================================
-- Foreign Key Constraint Nochecks's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Nochecks''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]
GO
-- =======================================================
-- Foreign Key Constraint Nochecks's for Table: [dbo].[SystemSecurityCategoryMasterAccountRole]
-- =======================================================
Print ' Foreign Key Constraint Nochecks''s for Table: [dbo].[SystemSecurityCategoryMasterAccountRole]'

ALTER TABLE [dbo].[SystemSecurityCategoryMasterAccountRole] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryMasterAccountRole_MasterAccountRole]
ALTER TABLE [dbo].[SystemSecurityCategoryMasterAccountRole] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryMasterAccountRole_SystemSecurityCategoryMasterAccountRole]
GO
-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountApprovalPath]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountApprovalPath]'
IF NOT EXISTS (SELECT * FROM [dbo].[MasterAccountApprovalPath] WHERE [MasterAccountApprovalPathId] = 1 and [MasterAccountApprovalTypeId] = 1 and [SystemApproverTypeId] = 1 and [ApprovalPathSequence] =1)
BEGIN
INSERT INTO [dbo].[MasterAccountApprovalPath] ([MasterAccountApprovalPathId], [MasterAccountApprovalTypeId], [SystemApproverTypeId], [ApprovalPathSequence]) VALUES (1, 1, 1, 1)
INSERT INTO [dbo].[MasterAccountApprovalPath] ([MasterAccountApprovalPathId], [MasterAccountApprovalTypeId], [SystemApproverTypeId], [ApprovalPathSequence]) VALUES (2, 1, 2, 2)
INSERT INTO [dbo].[MasterAccountApprovalPath] ([MasterAccountApprovalPathId], [MasterAccountApprovalTypeId], [SystemApproverTypeId], [ApprovalPathSequence]) VALUES (3, 2, 1, 1)
INSERT INTO [dbo].[MasterAccountApprovalPath] ([MasterAccountApprovalPathId], [MasterAccountApprovalTypeId], [SystemApproverTypeId], [ApprovalPathSequence]) VALUES (4, 3, 2, 1)
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountApprovalType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountApprovalType]'
IF NOT EXISTS (SELECT * FROM [dbo].[MasterAccountApprovalType] WHERE  [MasterAccountApprovalTypeId] = 1 and [ApprovalTypeName] = 'Team Lead --> Project Manager')
BEGIN
INSERT INTO [dbo].[MasterAccountApprovalType] ([MasterAccountApprovalTypeId], [ApprovalTypeName]) VALUES (1, 'Team Lead --> Project Manager')
INSERT INTO [dbo].[MasterAccountApprovalType] ([MasterAccountApprovalTypeId], [ApprovalTypeName]) VALUES (2, 'Team Lead')
INSERT INTO [dbo].[MasterAccountApprovalType] ([MasterAccountApprovalTypeId], [ApprovalTypeName]) VALUES (3, 'Project Manager')
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountRole]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountRole]'
IF NOT EXISTS (SELECT * FROM [dbo].[MasterAccountRole] WHERE [MasterAccountRoleId]=102 AND [TemplateId]=1 AND [Role]='External User' AND [IsSystemRole] Is NULL)
BEGIN
INSERT INTO [dbo].[MasterAccountRole] ([MasterAccountRoleId], [TemplateId], [Role], [IsSystemRole]) VALUES (102, 1, 'External User', NULL)
INSERT INTO [dbo].[MasterAccountRole] ([MasterAccountRoleId], [TemplateId], [Role], [IsSystemRole]) VALUES (103, 1, 'Time Entry Approver', 1)
INSERT INTO [dbo].[MasterAccountRole] ([MasterAccountRoleId], [TemplateId], [Role], [IsSystemRole]) VALUES (104, 1, 'Expense Entry Approver', 1)
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemApproverType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemApproverType]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemApproverType] WHERE [SystemApproverTypeId]=1 AND [SystemApproverType]= 'Team Lead')
BEGIN
INSERT INTO [dbo].[SystemApproverType] ([SystemApproverTypeId], [SystemApproverType]) VALUES (1, 'Team Lead')
INSERT INTO [dbo].[SystemApproverType] ([SystemApproverTypeId], [SystemApproverType]) VALUES (2, 'Project Manager')
INSERT INTO [dbo].[SystemApproverType] ([SystemApproverTypeId], [SystemApproverType]) VALUES (3, 'Specific Employee')
INSERT INTO [dbo].[SystemApproverType] ([SystemApproverTypeId], [SystemApproverType]) VALUES (4, 'Specific External User')
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemBillingRateType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemBillingRateType]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemBillingRateType] WHERE [SystemBillingRateTypeId]=1 AND [SystemBillingRateType]='Employee')
BEGIN
INSERT INTO [dbo].[SystemBillingRateType] ([SystemBillingRateTypeId], [SystemBillingRateType]) VALUES (1, 'Employee')
INSERT INTO [dbo].[SystemBillingRateType] ([SystemBillingRateTypeId], [SystemBillingRateType]) VALUES (2, 'Project Role')
INSERT INTO [dbo].[SystemBillingRateType] ([SystemBillingRateTypeId], [SystemBillingRateType]) VALUES (3, 'Project Based Employee')
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemEmployeeType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemEmployeeType]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemEmployeeType] WHERE [EmployeeTypeId]=1 AND [EmployeeType]='Internal Employee')
BEGIN
INSERT INTO [dbo].[SystemEmployeeType] ([EmployeeTypeId], [EmployeeType]) VALUES (1, 'Internal Employee')
INSERT INTO [dbo].[SystemEmployeeType] ([EmployeeTypeId], [EmployeeType]) VALUES (2, 'External Users')
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemProjectBillingRateType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemProjectBillingRateType]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemProjectBillingRateType] WHERE [SystemProjectBillingRateTypeId]=3 AND [SystemProjectBillingRateType] = 'Use Project Employee Billing Rate')
BEGIN
INSERT INTO [dbo].[SystemProjectBillingRateType] ([SystemProjectBillingRateTypeId], [SystemProjectBillingRateType]) VALUES (3, 'Use Project Employee Billing Rate')
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategory]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategory]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategory] WHERE [SystemSecurityCategoryId]=7 AND [SystemSecurityCategory] = 'Time Sheet Approvals' AND [IsSiteMapPage] Is NULL)
BEGIN
SET IDENTITY_INSERT [dbo].[SystemSecurityCategory] ON
INSERT INTO [dbo].[SystemSecurityCategory] ([SystemSecurityCategoryId], [SystemSecurityCategory], [IsSiteMapPage]) VALUES (7, 'Time Sheet Approvals', NULL)
INSERT INTO [dbo].[SystemSecurityCategory] ([SystemSecurityCategoryId], [SystemSecurityCategory], [IsSiteMapPage]) VALUES (8, 'Expense Entry Approval', NULL)
SET IDENTITY_INSERT [dbo].[SystemSecurityCategory] OFF
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryMasterAccountRole]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryMasterAccountRole]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryMasterAccountRole] WHERE [SystemSecurityCategoryMasterAccountRoleId] = 15 AND [SystemSecurityCategoryId] = 7 AND [MasterRoleId] = 100 AND [ShowAllData] Is NULL AND [ShowMyData] Is NULL AND [ShowMyProjectsData] Is NULL AND [ShowMyTeamsData] = 1 AND [ShowClientData] Is NULL)
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryMasterAccountRole] ([SystemSecurityCategoryMasterAccountRoleId], [SystemSecurityCategoryId], [MasterRoleId], [ShowAllData], [ShowMyData], [ShowMyProjectsData], [ShowMyTeamsData], [ShowClientData]) VALUES (15, 7, 100, NULL, NULL, NULL, 1, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryMasterAccountRole] ([SystemSecurityCategoryMasterAccountRoleId], [SystemSecurityCategoryId], [MasterRoleId], [ShowAllData], [ShowMyData], [ShowMyProjectsData], [ShowMyTeamsData], [ShowClientData]) VALUES (16, 7, 101, NULL, NULL, 1, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryMasterAccountRole] ([SystemSecurityCategoryMasterAccountRoleId], [SystemSecurityCategoryId], [MasterRoleId], [ShowAllData], [ShowMyData], [ShowMyProjectsData], [ShowMyTeamsData], [ShowClientData]) VALUES (17, 7, 102, NULL, NULL, NULL, NULL, 1)
INSERT INTO [dbo].[SystemSecurityCategoryMasterAccountRole] ([SystemSecurityCategoryMasterAccountRoleId], [SystemSecurityCategoryId], [MasterRoleId], [ShowAllData], [ShowMyData], [ShowMyProjectsData], [ShowMyTeamsData], [ShowClientData]) VALUES (18, 7, 1, NULL, NULL, 1, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryMasterAccountRole] ([SystemSecurityCategoryMasterAccountRoleId], [SystemSecurityCategoryId], [MasterRoleId], [ShowAllData], [ShowMyData], [ShowMyProjectsData], [ShowMyTeamsData], [ShowClientData]) VALUES (19, 8, 1, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryMasterAccountRole] ([SystemSecurityCategoryMasterAccountRoleId], [SystemSecurityCategoryId], [MasterRoleId], [ShowAllData], [ShowMyData], [ShowMyProjectsData], [ShowMyTeamsData], [ShowClientData]) VALUES (20, 8, 100, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryMasterAccountRole] ([SystemSecurityCategoryMasterAccountRoleId], [SystemSecurityCategoryId], [MasterRoleId], [ShowAllData], [ShowMyData], [ShowMyProjectsData], [ShowMyTeamsData], [ShowClientData]) VALUES (21, 8, 101, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryMasterAccountRole] ([SystemSecurityCategoryMasterAccountRoleId], [SystemSecurityCategoryId], [MasterRoleId], [ShowAllData], [ShowMyData], [ShowMyProjectsData], [ShowMyTeamsData], [ShowClientData]) VALUES (22, 8, 102, NULL, NULL, NULL, NULL, NULL)
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPage] WHERE [SystemSecurityCategoryPageId] =92 AND [SystemSecurityCategoryId] = 1 AND [SequenceNumber] = '210122' AND [Folder] = 'AccountAdmin' AND [SystemCategoryPage] = 'ExternalUsers.aspx' AND [SystemCategoryPageDescription] = 'External Users' AND [ParentSystemSecurityCateogoryPageId] = 15 AND [IsSiteMapPage] = 1 AND [IsCustomizeable] = 1 AND [IsAllowAdd] = 1 AND [IsAllowEdit]=1 AND [IsAllowDelete]=1 AND [IsAllowList]=1 AND [IsShowDataOptions]=0 AND [IsShowTillOptions]=0 AND [IsSystemPage]=0 AND [ControlLevelPermission]=0)
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (92, 1, '210122', 'AccountAdmin', 'ExternalUsers.aspx', 'External Users', 15, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (93, 1, '210123', 'AccountAdmin', 'AccountApprovals.aspx', 'Approval Types', 15, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (94, 1, '21012301', 'AccountAdmin', 'AccountApproval.aspx', 'Approval Type', 93, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (95, 1, '21012302', 'AccountAdmin', 'AccountBillingRate.aspx', 'Billing Rate', 28, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0)
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPermission]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPermission]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPermission] WHERE [SystemSecurityCategoryPermissionId]=16 AND [SystemSecurityCategoryId]=7 AND [SystemPermissionId] =1 AND [ShowMyData] Is NULL AND [ShowMyTeamsData] Is NULL AND [ShowMyProjectsData] Is NULL AND [ShowAllData] Is NULL AND [TillDate] Is NULL AND [TillHours] Is NULL)
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPermission] ([SystemSecurityCategoryPermissionId], [SystemSecurityCategoryId], [SystemPermissionId], [ShowMyData], [ShowMyTeamsData], [ShowMyProjectsData], [ShowAllData], [TillDate], [TillHours]) VALUES (16, 7, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPermission] ([SystemSecurityCategoryPermissionId], [SystemSecurityCategoryId], [SystemPermissionId], [ShowMyData], [ShowMyTeamsData], [ShowMyProjectsData], [ShowAllData], [TillDate], [TillHours]) VALUES (17, 7, 3, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPermission] ([SystemSecurityCategoryPermissionId], [SystemSecurityCategoryId], [SystemPermissionId], [ShowMyData], [ShowMyTeamsData], [ShowMyProjectsData], [ShowAllData], [TillDate], [TillHours]) VALUES (18, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPermission] ([SystemSecurityCategoryPermissionId], [SystemSecurityCategoryId], [SystemPermissionId], [ShowMyData], [ShowMyTeamsData], [ShowMyProjectsData], [ShowAllData], [TillDate], [TillHours]) VALUES (19, 8, 3, NULL, NULL, NULL, NULL, NULL, NULL)
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountProjectType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountProjectType]'

UPDATE [dbo].[MasterAccountProjectType] SET [ProjectType]='Technology ' WHERE [MasterAccountProjectTypeId]=1
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemCurrency]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemCurrency]'

UPDATE [dbo].[SystemCurrency] SET [Currency]='Dominican Republic, ' WHERE [CurrencyId]=42
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemMasterEMailTemplate]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemMasterEMailTemplate]'

UPDATE [dbo].[SystemMasterEMailTemplate] SET [TemplateContent]='Welcome to TimeLive!

Your new Hosted TimeLive account has been created. 

TimeLive Login Information
----------------------
##Body##
What to do next?
----------------
1. TimeLive is a TimeManagement system with support of managing
   a. Projects
   b. Tasks
   c. TimeSheet
   d. Employees
   e. Employees Attendance

2. Login to Your Account by using the login link.
   Your login data is given above.

3. TimeLive support multi-Location organization.  Location represents branches / sites of 
   an organization.  You can create new Locations under "Administrations", "Locations".  

4. Create new members under "Administration", "Employees" in Your TimeLive Administration menu.
   TimeLive will create an Employee account and will send New TimeLive account notification 
   automatically.
   
5. Want to be informed without login on TimeLive.  Just subscribe yourself for different 
   scheduled reports which will be send to your email address automatically.

We wish You a lot of success with Your new TimeLive account.
If You have any remarks or questions feel free to contact us via e-mail anytime.

Best regards,
TimeLive Support team

e-mail support@livetecs.com

Let''s work together !
______________________________________________________________________
TimeLive is a service of LiveTecs.com (www.LiveTecs.com)
' WHERE [MasterEMailTemplateId]=1
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemPackageType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemPackageType]'

UPDATE [dbo].[SystemPackageType] SET [SKUId]='TLIE2334137826 ' WHERE [SystemPackageTypeId]=20
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'

UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemSecurityCategoryId]=8 WHERE [SystemSecurityCategoryPageId]=36
UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemSecurityCategoryId]=7 WHERE [SystemSecurityCategoryPageId]=38
UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemCategoryPageDescription]='Application Preferences ' WHERE [SystemSecurityCategoryPageId]=91
UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemCategoryPage]='AuditTrail.aspx', [SystemCategoryPageDescription]='Audit Trail' WHERE [SystemSecurityCategoryPageId]=24
UPDATE [dbo].[SystemSecurityCategoryPage] SET [IsCustomizeable]=1, [IsAllowList]=1 WHERE [SystemSecurityCategoryPageId]=16

GO

-- =======================================================
-- Foreign Key Constraint Check's for Table: [dbo].[SystemSecurityCategoryMasterAccountRole]
-- =======================================================
Print ' Foreign Key Constraint Check''s for Table: [dbo].[SystemSecurityCategoryMasterAccountRole]'

ALTER TABLE [dbo].[SystemSecurityCategoryMasterAccountRole] CHECK CONSTRAINT [FK_SystemSecurityCategoryMasterAccountRole_MasterAccountRole]
ALTER TABLE [dbo].[SystemSecurityCategoryMasterAccountRole] CHECK CONSTRAINT [FK_SystemSecurityCategoryMasterAccountRole_SystemSecurityCategoryMasterAccountRole]
GO

-- =======================================================
-- Foreign Key Constraint Check's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Check''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]
GO

-- =======================================================
-- Foreign Key Constraint Check's for Table: [dbo].[SystemSecurityCategoryPermission]
-- =======================================================
Print ' Foreign Key Constraint Check''s for Table: [dbo].[SystemSecurityCategoryPermission]'

ALTER TABLE [dbo].[SystemSecurityCategoryPermission] CHECK CONSTRAINT [FK_SystemSecurityCategoryPermission_SystemPermission]
ALTER TABLE [dbo].[SystemSecurityCategoryPermission] CHECK CONSTRAINT [FK_SystemSecurityCategoryPermission_SystemSecurityCategory]

--END 2.4

--TimeLive 2.5
--Start 2.5

GO
-- Drop Foreign Key FK_AccountEmployee_SystemTimeZone from AccountEmployee
Print 'Drop Foreign Key FK_AccountEmployee_AccountDepartment from AccountEmployee'
GO
IF  EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployee_AccountDepartment' AND TABLE_NAME='AccountEmployee')
ALTER TABLE [dbo].[AccountEmployee] DROP CONSTRAINT [FK_AccountEmployee_AccountDepartment]
GO
-- Drop View vueAccountEmployeeTimeEntryApprovalPending
Print 'Drop View vueAccountEmployeeTimeEntryApprovalPending'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPending' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovalPending]
GO

-- Drop View vueAccountProjectTask
Print 'Drop View vueAccountProjectTask'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectTask' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountProjectTask]
GO

-- Drop View vueAccountProjectTaskAttachment
Print 'Drop View vueAccountProjectTaskAttachment'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskAttachment' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountProjectTaskAttachment]
GO

-- Drop Primary Key PK_tblPartyContact from PartyContact
Print 'Drop Primary Key PK_tblPartyContact from PartyContact'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PartyContact' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_tblPartyContact' AND TABLE_NAME='PartyContact'))
ALTER TABLE [dbo].[PartyContact] DROP CONSTRAINT [PK_tblPartyContact]
GO

-- Drop Table PartyContact
Print 'Drop Table PartyContact'
GO
if exists (select * from information_schema.tables where table_name = 'PartyContact' and table_type = 'BASE TABLE') 
DROP TABLE [dbo].[PartyContact]
GO

-- Drop View vueAccountEmployeeTimeEntryApproval
Print 'Drop View vueAccountEmployeeTimeEntryApproval'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApproval' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApproval]
GO

-- Drop View vueAccountEmployeeTimeEntryApprovalPendingEMail
Print 'Drop View vueAccountEmployeeTimeEntryApprovalPendingEMail'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPendingEMail' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovalPendingEMail]
GO

-- Drop View vueAccountEmployeeTimeEntryApprovalPendingApprover
Print 'Drop View vueAccountEmployeeTimeEntryApprovalPendingApprover'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPendingApprover' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovalPendingApprover]
GO

-- Drop Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId from AccountEmployeeAttendance
Print 'Drop Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId from AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance] DROP CONSTRAINT [DF_AccountEmployeeAttendance_CreatedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId from AccountEmployeeAttendance
Print 'Drop Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId from AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance] DROP CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountDepartment_IsDeleted from AccountDepartment
Print 'Drop Default Constraint DF_AccountDepartment_IsDeleted from AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDeleted'))
ALTER TABLE [dbo].[AccountDepartment] DROP CONSTRAINT [DF_AccountDepartment_IsDeleted]
GO

-- Drop Default Constraint DF_AccountDepartment_IsDisabled from AccountDepartment
Print 'Drop Default Constraint DF_AccountDepartment_IsDisabled from AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDisabled'))
ALTER TABLE [dbo].[AccountDepartment] DROP CONSTRAINT [DF_AccountDepartment_IsDisabled]
GO

-- Drop Default Constraint DF_AccountLocation_CreatedByEmployeeId from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_CreatedByEmployeeId from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_CreatedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountLocation_IsDisabled from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_IsDisabled from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_IsDisabled'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_IsDisabled]
GO

-- Drop Default Constraint DF_AccountLocation_ModifiedByEmployeeId from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_ModifiedByEmployeeId from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_ModifiedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountRole_IsDeleted from AccountRole
Print 'Drop Default Constraint DF_AccountRole_IsDeleted from AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountRole_IsDeleted'))
ALTER TABLE [dbo].[AccountRole] DROP CONSTRAINT [DF_AccountRole_IsDeleted]
GO

-- Drop Default Constraint DF_AccountRole_IsDisabled from AccountRole
Print 'Drop Default Constraint DF_AccountRole_IsDisabled from AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountRole_IsDisabled'))
ALTER TABLE [dbo].[AccountRole] DROP CONSTRAINT [DF_AccountRole_IsDisabled]
GO

-- Drop Foreign Key FK_AccountBillingRate_Account from AccountBillingRate
Print 'Drop Foreign Key FK_AccountBillingRate_Account from AccountBillingRate'
GO
IF OBJECT_ID(N'[FK_AccountBillingRate_Account]') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[AccountBillingRate] DROP CONSTRAINT [FK_AccountBillingRate_Account]
END
GO

-- Drop Index IX_AccountId from AccountBillingRate
Print 'Drop Index IX_AccountId from AccountBillingRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountBillingRate' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID (N'[dbo].[AccountBillingRate]') AND name = N'IX_AccountId'))
DROP INDEX [dbo].[AccountBillingRate].[IX_AccountId]
GO

-- Add Column AccountPartyContactId to AccountProject
Print 'Add Column AccountPartyContactId to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountPartyContactId' AND TABLE_NAME='AccountProject'))
ALTER TABLE [dbo].[AccountProject]
	ADD [AccountPartyContactId] int NULL

GO

-- Add Column AccountPartyDepartmentId to AccountProject
Print 'Add Column AccountPartyDepartmentId to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountPartyDepartmentId' AND TABLE_NAME='AccountProject'))
ALTER TABLE [dbo].[AccountProject]
	ADD [AccountPartyDepartmentId] int NULL

GO

-- Create View vueAccountEmployeeTimeEntryApproval
Print 'Create View vueAccountEmployeeTimeEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.TaskDescription, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments, dbo.AccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.AccountEmployeeTimeEntryApproval.IsApproved, dbo.AccountEmployeeTimeEntry.AccountEmployeeId AS TimeEntryAccountEmployeeId, 
                      dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.AccountId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountProjectTask INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId'
GO

-- Create View vueAccountEmployeeTimeEntryApprovalPending
Print 'Create View vueAccountEmployeeTimeEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPending
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectId, dbo.vueAccountEmployeeTimeEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.SystemApproverTypeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectDescription, dbo.vueAccountEmployeeTimeEntryApproval.ProjectCode, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskName, dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskDescription, dbo.vueAccountEmployeeTimeEntryApproval.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Approved, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TotalTime, dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Comments, dbo.vueAccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApproval.IsApproved, dbo.vueAccountApproverType.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryAccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.EMailAddress
FROM         dbo.vueAccountEmployeeTimeEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId IN
                          (SELECT      AccountApprovalPathId
                            FROM          dbo.vueTimesheetApprovalSequence
                            WHERE      (TimeSheetApprovalId IS NULL) AND 
                                                   (AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId)))'
GO

-- Add Default Constraint DF_AccountRole_IsDeleted to AccountRole
Print 'Add Default Constraint DF_AccountRole_IsDeleted to AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountRole_IsDeleted'))
ALTER TABLE [dbo].[AccountRole]
	ADD
	CONSTRAINT [DF_AccountRole_IsDeleted]
	DEFAULT (0) FOR [IsDeleted]
GO

-- Add Default Constraint DF_AccountRole_IsDisabled to AccountRole
Print 'Add Default Constraint DF_AccountRole_IsDisabled to AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountRole_IsDisabled'))
ALTER TABLE [dbo].[AccountRole]
	ADD
	CONSTRAINT [DF_AccountRole_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO

-- Add Default Constraint DF_AccountLocation_CreatedByEmployeeId to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_CreatedByEmployeeId to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_CreatedByEmployeeId]
	DEFAULT (0) FOR [CreatedByEmployeeId]
GO

-- Add Default Constraint DF_AccountLocation_IsDisabled to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_IsDisabled to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_IsDisabled'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO

-- Add Default Constraint DF_AccountLocation_ModifiedByEmployeeId to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_ModifiedByEmployeeId to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_ModifiedByEmployeeId]
	DEFAULT (0) FOR [ModifiedByEmployeeId]
GO

-- Add Default Constraint DF_AccountDepartment_IsDeleted to AccountDepartment
Print 'Add Default Constraint DF_AccountDepartment_IsDeleted to AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDeleted'))
ALTER TABLE [dbo].[AccountDepartment]
	ADD
	CONSTRAINT [DF_AccountDepartment_IsDeleted]
	DEFAULT (0) FOR [IsDeleted]
GO

-- Add Default Constraint DF_AccountDepartment_IsDisabled to AccountDepartment
Print 'Add Default Constraint DF_AccountDepartment_IsDisabled to AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDisabled'))
ALTER TABLE [dbo].[AccountDepartment]
	ADD
	CONSTRAINT [DF_AccountDepartment_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO

-- Create Table AccountPartyDepartment
Print 'Create Table AccountPartyDepartment'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountPartyDepartment' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountPartyDepartment] (
		[AccountPartyDepartmentId]     int NOT NULL IDENTITY(1, 1),
		[AccountPartyId]               int NOT NULL,
		[PartyDepartmentCode]          varchar(50) NOT NULL,
		[PartyDepartmentName]          varchar(100) NOT NULL,
		[PartyDepartmentLocation]      varchar(200) NULL
)
GO

-- Add Primary Key PK_AccountPartyDepartment to AccountPartyDepartment
Print 'Add Primary Key PK_AccountPartyDepartment to AccountPartyDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPartyDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountPartyDepartment' AND TABLE_NAME='AccountPartyDepartment'))
ALTER TABLE [dbo].[AccountPartyDepartment]
	ADD
	CONSTRAINT [PK_AccountPartyDepartment]
	PRIMARY KEY
	([AccountPartyDepartmentId])
GO

-- Add Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId to AccountEmployeeAttendance
Print 'Add Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId to AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance]
	ADD
	CONSTRAINT [DF_AccountEmployeeAttendance_CreatedByEmployeeId]
	DEFAULT (0) FOR [CreatedByEmployeeId]
GO

-- Add Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId to AccountEmployeeAttendance
Print 'Add Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId to AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance]
	ADD
	CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedByEmployeeId]
	DEFAULT (0) FOR [ModifiedByEmployeeId]
GO

-- Create Table SystemEMailNotificationType
Print 'Create Table SystemEMailNotificationType'
GO
if not exists (select * from information_schema.tables where table_name = 'SystemEMailNotificationType' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[SystemEMailNotificationType] (
		[SystemEMailNotificationTypeId]     smallint NOT NULL,
		[SystemEMailNotificationType]       varchar(100) NOT NULL
)
GO

-- Add Primary Key PK_SystemEMailNotificationType to SystemEMailNotificationType
Print 'Add Primary Key PK_SystemEMailNotificationType to SystemEMailNotificationType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemEMailNotificationType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_SystemEMailNotificationType' AND TABLE_NAME='SystemEMailNotificationType'))
ALTER TABLE [dbo].[SystemEMailNotificationType]
	ADD
	CONSTRAINT [PK_SystemEMailNotificationType]
	PRIMARY KEY
	([SystemEMailNotificationTypeId])
GO

-- Create Table SystemEMailNotification
Print 'Create Table SystemEMailNotification'
GO
if not exists (select * from information_schema.tables where table_name = 'SystemEMailNotification' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[SystemEMailNotification] (
		[SystemEMailNotificationId]         smallint NOT NULL,
		[SystemEMailNotification]           varchar(100) NOT NULL,
		[SystemEMailNotificationTypeId]     smallint NOT NULL,
		[Enabled]                           bit NOT NULL
)
GO

-- Add Primary Key PK_SystemEMailNotification to SystemEMailNotification
Print 'Add Primary Key PK_SystemEMailNotification to SystemEMailNotification'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemEMailNotification' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_SystemEMailNotification' AND TABLE_NAME='SystemEMailNotification'))
ALTER TABLE [dbo].[SystemEMailNotification]
	ADD
	CONSTRAINT [PK_SystemEMailNotification]
	PRIMARY KEY
	([SystemEMailNotificationId])
GO

-- Create Table AccountEMailNotificationPreference
Print 'Create Table AccountEMailNotificationPreference'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountEMailNotificationPreference' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountEMailNotificationPreference] (
		[AccountEMailNotificationPreferenceId]     int NOT NULL IDENTITY(1, 1),
		[AccountId]                                int NULL,
		[AccountProjectId]                         int NULL,
		[AccountEmployeeId]                        int NULL,
		[SystemEMailNotificationId]                smallint NOT NULL,
		[SystemEMailNotificationTypeId]            smallint NOT NULL,
		[Enabled]                                  bit NOT NULL
)
GO

-- Add Primary Key PK_AccountEMailNotificationPreference to AccountEMailNotificationPreference
Print 'Add Primary Key PK_AccountEMailNotificationPreference to AccountEMailNotificationPreference'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEMailNotificationPreference' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountEMailNotificationPreference' AND TABLE_NAME='AccountEMailNotificationPreference'))
ALTER TABLE [dbo].[AccountEMailNotificationPreference]
	ADD
	CONSTRAINT [PK_AccountEMailNotificationPreference]
	PRIMARY KEY
	([AccountEMailNotificationPreferenceId])
GO

-- Create Table AccountPartyContact
Print 'Create Table AccountPartyContact'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountPartyContact' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountPartyContact] (
		[AccountPartyContactId]        int NOT NULL IDENTITY(1, 1),
		[AccountPartyId]               int NOT NULL,
		[FirstName]                    varchar(50) NOT NULL,
		[LastName]                     varchar(50) NOT NULL,
		[Telephone1]                   varchar(25) NULL,
		[Telephone2]                   varchar(25) NULL,
		[Fax]                          varchar(25) NULL,
		[EMailAddress]                 varchar(25) NULL,
		[State]                        varchar(20) NULL,
		[City]                         varchar(50) NULL,
		[Zip]                          varchar(10) NULL,
		[CountryId]                    smallint NULL,
		[Address1]                     varchar(150) NULL,
		[Address2]                     varchar(150) NULL,
		[AccountPartyDepartmentId]     int NULL,
		[Location]                     varchar(50) NULL
)
GO

-- Add Primary Key PK_AccountPartyContact to AccountPartyContact
Print 'Add Primary Key PK_AccountPartyContact to AccountPartyContact'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPartyContact' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountPartyContact' AND TABLE_NAME='AccountPartyContact'))
ALTER TABLE [dbo].[AccountPartyContact]
	ADD
	CONSTRAINT [PK_AccountPartyContact]
	PRIMARY KEY
	([AccountPartyContactId])
GO

-- Create View vueAccountEmployeeTimeEntryApprovalPendingApprover
Print 'Create View vueAccountEmployeeTimeEntryApprovalPendingApprover'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPendingApprover' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover
AS
SELECT     AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, AccountApprovalTypeId, 
                      SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, AccountEmployeeTimeEntryId, TimeSheetApprovalId, 
                      TimeSheetApprovalPathId, ProjectName, ProjectDescription, ProjectCode, TaskName, AccountProjectTaskId, TaskDescription, EmployeeName, 
                      Approved, TimeSheetApprovalTypeId, TotalTime, TimeEntryDate, Comments, IsReject, IsApproved, MaxApprovalPathSequence, 
                      TimeEntryAccountEmployeeId, AccountId, EMailAddress, 
                      CASE WHEN systemapprovertypeid = 1 THEN LeaderEmployeeId WHEN systemapprovertypeid = 2 THEN ProjectManagerEmployeeId WHEN systemapprovertypeid
                       = 3 THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId END AS ApproverEmployeeId
FROM         dbo.vueAccountEmployeeTimeEntryApprovalPending'
GO

-- Create View vueAccountProjectTaskAttachment
Print 'Create View vueAccountProjectTaskAttachment'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskAttachment' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskAttachment
AS
SELECT     dbo.AccountProjectTaskAttachment.AccountProjectTaskAttachmentId, dbo.AccountProjectTaskAttachment.AccountProjectTaskId, 
                      dbo.AccountProjectTaskAttachment.AttachmentName, dbo.AccountProjectTaskAttachment.AttachmentLocalPath, 
                      dbo.AccountProjectTaskAttachment.CreatedOn, dbo.AccountProjectTaskAttachment.CreatedByEmployeeId, 
                      dbo.AccountProjectTaskAttachment.ModifiedOn, dbo.AccountProjectTaskAttachment.ModifiedByEmployeeId, dbo.AccountProjectTask.AccountProjectId, 
                      dbo.AccountProject.ProjectName, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployee.AccountEmployeeId, 
                      dbo.AccountEmployee.AccountId
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTaskAttachment ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTaskAttachment.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountProject RIGHT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountProject.AccountProjectId = dbo.AccountProjectTask.AccountProjectId ON 
                      dbo.AccountProjectTaskAttachment.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId'
GO

-- Create View vueAccountProjectTask
Print 'Create View vueAccountProjectTask'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTask' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTask
AS
SELECT     dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.AccountTaskTypeId, 
                      dbo.AccountProjectTask.Duration, dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, 
                      dbo.AccountProjectTask.CompletedPercent, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.CreatedOn, dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.ModifiedOn, 
                      dbo.AccountProjectTask.ModifiedByEmployeeId, dbo.AccountStatus.Status AS TaskStatus, dbo.AccountEmployee.FirstName AS CreatedByFirstName, 
                      dbo.AccountEmployee.LastName AS CreatedByLastName, dbo.AccountPriority.Priority, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectCode, dbo.AccountTaskType.TaskType, dbo.AccountProject.AccountId, dbo.AccountProjectTask.AccountProjectMilestoneId, 
                      dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountProjectTask.IsReOpen, AccountEmployee_1.FirstName AS ModifiedByFirstName, 
                      AccountEmployee_1.LastName AS ModifiedByLastName, dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, 
                      dbo.AccountProjectTask.EstimatedTimeSpentUnit, dbo.AccountEmployee.AccountEmployeeId
FROM         dbo.AccountStatus RIGHT OUTER JOIN
                      dbo.AccountTaskType RIGHT OUTER JOIN
                      dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTask LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountProjectTask.ModifiedByEmployeeId = AccountEmployee_1.AccountEmployeeId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountProjectMilestone ON 
                      dbo.AccountProjectTask.AccountProjectMilestoneId = dbo.AccountProjectMilestone.AccountProjectMilestoneId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountTaskType.AccountTaskTypeId = dbo.AccountProjectTask.AccountTaskTypeId ON 
                      dbo.AccountStatus.AccountStatusId = dbo.AccountProjectTask.TaskStatusId LEFT OUTER JOIN
                      dbo.AccountPriority ON dbo.AccountProjectTask.AccountPriorityId = dbo.AccountPriority.AccountPriorityId'
GO

-- Create View vueAccountPartyDepartment
Print 'Create View vueAccountPartyDepartment'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountPartyDepartment' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountPartyDepartment
AS
SELECT     dbo.AccountParty.PartyName, dbo.AccountParty.PartyNick, dbo.AccountPartyDepartment.*
FROM         dbo.AccountParty RIGHT OUTER JOIN
                      dbo.AccountPartyDepartment ON dbo.AccountParty.AccountPartyId = dbo.AccountPartyDepartment.AccountPartyId'
GO

-- Create View vueAccountEMailNotificationPreference
Print 'Create View vueAccountEMailNotificationPreference'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEMailNotificationPreference' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEMailNotificationPreference
AS
SELECT     dbo.AccountEMailNotificationPreference.AccountEMailNotificationPreferenceId, dbo.AccountEMailNotificationPreference.AccountId, 
                      dbo.AccountEMailNotificationPreference.AccountProjectId, dbo.AccountEMailNotificationPreference.AccountEmployeeId, 
                      dbo.AccountEMailNotificationPreference.SystemEMailNotificationId, dbo.AccountEMailNotificationPreference.SystemEMailNotificationTypeId, 
                      dbo.AccountEMailNotificationPreference.Enabled, dbo.SystemEMailNotification.SystemEMailNotification, 
                      dbo.SystemEMailNotificationType.SystemEMailNotificationType
FROM         dbo.AccountEMailNotificationPreference LEFT OUTER JOIN
                      dbo.SystemEMailNotification ON 
                      dbo.AccountEMailNotificationPreference.SystemEMailNotificationTypeId = dbo.SystemEMailNotification.SystemEMailNotificationTypeId AND 
                      dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = dbo.SystemEMailNotification.SystemEMailNotificationId LEFT OUTER JOIN
                      dbo.SystemEMailNotificationType ON 
                      dbo.SystemEMailNotification.SystemEMailNotificationTypeId = dbo.SystemEMailNotificationType.SystemEMailNotificationTypeId'
GO

-- Create View vueAccountPartyContact
Print 'Create View vueAccountPartyContact'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountPartyContact' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountPartyContact
AS
SELECT     dbo.AccountPartyContact.*, dbo.AccountParty.PartyName, dbo.AccountParty.PartyNick
FROM         dbo.AccountPartyContact LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountPartyContact.AccountPartyId = dbo.AccountParty.AccountPartyId'
GO

-- Create View vueAccountEmployeeTimeEntryApprovalPendingEMail
Print 'Create View vueAccountEmployeeTimeEntryApprovalPendingEMail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPendingEMail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeSheetApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectDescription, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectCode, dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TaskName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TaskDescription, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.Approved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TotalTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.Comments, dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.IsApproved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeEntryAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountId, dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApproverEmployeeId
FROM         dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApproverEmployeeId = dbo.AccountEMailNotificationPreference.AccountEmployeeId LEFT
                       OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountId = AccountEMailNotificationPreference_1.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 11) AND (AccountEMailNotificationPreference_1.Enabled = ''True'') AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 12) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 13) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO

-- Create Foreign Key FK_AccountPartyDepartment_AccountParty on AccountPartyDepartment
Print 'Create Foreign Key FK_AccountPartyDepartment_AccountParty on AccountPartyDepartment'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPartyDepartment_AccountParty' AND TABLE_NAME='AccountPartyDepartment')
BEGIN
		ALTER TABLE [dbo].[AccountPartyDepartment]
			ADD CONSTRAINT [FK_AccountPartyDepartment_AccountParty]
			FOREIGN KEY ([AccountPartyId]) REFERENCES [dbo].[AccountParty] ([AccountPartyId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountEMailNotificationPreference_SystemEMailNotification on AccountEMailNotificationPreference
Print 'Create Foreign Key FK_AccountEMailNotificationPreference_SystemEMailNotification on AccountEMailNotificationPreference'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEMailNotificationPreference_SystemEMailNotification' AND TABLE_NAME='AccountEMailNotificationPreference')
BEGIN
		ALTER TABLE [dbo].[AccountEMailNotificationPreference]
			ADD CONSTRAINT [FK_AccountEMailNotificationPreference_SystemEMailNotification]
			FOREIGN KEY ([SystemEMailNotificationId]) REFERENCES [dbo].[SystemEMailNotification] ([SystemEMailNotificationId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountEMailNotificationPreference_SystemEMailNotificationType on AccountEMailNotificationPreference
Print 'Create Foreign Key FK_AccountEMailNotificationPreference_SystemEMailNotificationType on AccountEMailNotificationPreference'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEMailNotificationPreference_SystemEMailNotificationType' AND TABLE_NAME='AccountEMailNotificationPreference')
BEGIN
		ALTER TABLE [dbo].[AccountEMailNotificationPreference]
			ADD CONSTRAINT [FK_AccountEMailNotificationPreference_SystemEMailNotificationType]
			FOREIGN KEY ([SystemEMailNotificationTypeId]) REFERENCES [dbo].[SystemEMailNotificationType] ([SystemEMailNotificationTypeId])
			ON DELETE CASCADE
END
GO

-- Create Foreign Key FK_AccountPartyContact_AccountParty on AccountPartyContact
Print 'Create Foreign Key FK_AccountPartyContact_AccountParty on AccountPartyContact'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPartyContact_AccountParty' AND TABLE_NAME='AccountPartyContact')
BEGIN
		ALTER TABLE [dbo].[AccountPartyContact]
			ADD CONSTRAINT [FK_AccountPartyContact_AccountParty]
			FOREIGN KEY ([AccountPartyId]) REFERENCES [dbo].[AccountParty] ([AccountPartyId])
			ON DELETE CASCADE
END

GO

-- Drop View vueAccountEmployee
Print 'Drop View vueAccountEmployee'
GO
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployee]
GO
-- Drop View vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference
Print 'Drop View vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference]
GO
-- Add Column ScheduledEmailSendTime to AccountPreferences
Print 'Add Column ScheduledEmailSendTime to AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='ScheduledEmailSendTime' AND TABLE_NAME='AccountPreferences'))
ALTER TABLE [dbo].[AccountPreferences]
	ADD [ScheduledEmailSendTime] datetime NULL

GO

-- Add Column LastScheduledEmailSentTime to AccountPreferences
Print 'Add Column LastScheduledEmailSentTime to AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='LastScheduledEmailSentTime' AND TABLE_NAME='AccountPreferences'))
ALTER TABLE [dbo].[AccountPreferences]
	ADD [LastScheduledEmailSentTime] datetime NULL

GO

-- Create View vueAccountEmployee
Print 'Create View vueAccountEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployee
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.AccountId, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.Password, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.BillingTypeId, dbo.AccountBillingType.BillingType, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountPreferences.ShowClockStartEnd, 
                      dbo.Account.TimeZoneId, dbo.AccountRole.MasterAccountRoleId, dbo.Account.DefaultCurrencyId, dbo.Account.CountryId, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.TimeEntryFormat, dbo.AccountEmployee.AllowedAccessFromIP, 
                      dbo.AccountRole.AccountRoleId, dbo.AccountPreferences.AccountSessionTimeout, dbo.AccountPreferences.ShowCompletedTasksInTimeSheet, 
                      dbo.AccountPreferences.CurrencySymbol, dbo.AccountPreferences.IsCompanyOwnLogo, dbo.Account.AccountExpiryActivation, 
                      dbo.Account.LicenseActivation, dbo.AccountEmployee.EmployeeTypeId, dbo.AccountEmployee.ExternalUserClientId, 
                      dbo.AccountEmployee.AccountBillingRateId, dbo.AccountPreferences.ScheduledEmailSendTime, 
                      dbo.AccountPreferences.LastScheduledEmailSentTime
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId'
GO

-- Create View vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference
Print 'Create View vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeSheetApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ProjectDescription, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ProjectCode, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TaskName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TaskDescription, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.EmployeeName, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Approved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TotalTime, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.Comments, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.IsApproved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.TimeEntryAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountId, dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ApproverEmployeeId, dbo.AccountPreferences.ScheduledEmailSendTime, 
                      dbo.AccountPreferences.LastScheduledEmailSentTime, dbo.AccountEmployee.EMailAddress AS ApproverEMailAddress
FROM         dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail LEFT OUTER JOIN
                      dbo.AccountEmployee ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.ApproverEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail.AccountId = dbo.AccountPreferences.AccountId'

GO

-- Create View vueAccountProjectTaskEmail
Print 'Create View vueAccountProjectTaskEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskEmail
AS
SELECT     dbo.vueAccountProjectTask.AccountProjectTaskId, dbo.vueAccountProjectTask.AccountProjectId, 
                      dbo.vueAccountProjectTask.ParentAccountProjectTaskId, dbo.vueAccountProjectTask.TaskName, dbo.vueAccountProjectTask.TaskDescription, 
                      dbo.vueAccountProjectTask.AccountTaskTypeId, dbo.vueAccountProjectTask.Duration, dbo.vueAccountProjectTask.DurationUnit, 
                      dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, dbo.vueAccountProjectTask.Completed, 
                      dbo.vueAccountProjectTask.IsParentTask, dbo.vueAccountProjectTask.IsForAllEmployees, dbo.vueAccountProjectTask.AccountPriorityId, 
                      dbo.vueAccountProjectTask.TaskStatusId, dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.CreatedByEmployeeId, 
                      dbo.vueAccountProjectTask.ModifiedOn, dbo.vueAccountProjectTask.ModifiedByEmployeeId, dbo.vueAccountProjectTask.TaskStatus, 
                      dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, dbo.vueAccountProjectTask.Priority, 
                      dbo.vueAccountProjectTask.ProjectName, dbo.vueAccountProjectTask.ProjectCode, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.AccountId, dbo.vueAccountProjectTask.AccountProjectMilestoneId, dbo.vueAccountProjectTask.MilestoneDescription, 
                      dbo.vueAccountProjectTask.IsReOpen, dbo.vueAccountProjectTask.ModifiedByFirstName, dbo.vueAccountProjectTask.ModifiedByLastName, 
                      dbo.vueAccountProjectTask.EstimatedCost, dbo.vueAccountProjectTask.EstimatedTimeSpent, dbo.vueAccountProjectTask.EstimatedTimeSpentUnit, 
                      dbo.vueAccountProjectTask.AccountEmployeeId, dbo.AccountEmployee.EMailAddress
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.vueAccountProjectTask ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTask.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTask.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTask.CreatedByEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 4) AND (AccountEMailNotificationPreference_1.Enabled = ''True'') AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 3) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 2) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO

-- Create View vueAccountProjectTaskEmployeeEmail
Print 'Create View vueAccountProjectTaskEmployeeEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskEmployeeEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskEmployeeEmail
AS
SELECT     dbo.vueAccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountProjectId, 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId, dbo.vueAccountProjectTaskEmployee.TaskName, 
                      dbo.vueAccountProjectTaskEmployee.FirstName, dbo.vueAccountProjectTaskEmployee.LastName, 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountId, 
                      dbo.vueAccountProjectTaskEmployee.ProjectCode, dbo.vueAccountProjectTaskEmployee.TaskStatusId, 
                      dbo.vueAccountProjectTaskEmployee.Completed, dbo.AccountProject.ProjectName, dbo.AccountEmployee.EMailAddress, 
                      dbo.vueAccountProjectTask.TaskDescription, dbo.vueAccountProjectTask.TaskStatus, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.Priority, dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, 
                      dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.MilestoneDescription, dbo.vueAccountProjectTask.Duration, 
                      dbo.vueAccountProjectTask.DurationUnit, dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, 
                      dbo.vueAccountProjectTask.IsReOpen
FROM         dbo.AccountProject RIGHT OUTER JOIN
                      dbo.vueAccountProjectTaskEmployee LEFT OUTER JOIN
                      dbo.vueAccountProjectTask ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId = dbo.vueAccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.vueAccountProjectTaskEmployee.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTaskEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 4) AND (AccountEMailNotificationPreference_1.Enabled = ''True'') AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 3) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 2) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO

-- Create View vueAccountProjectTaskUpdateEmail
Print 'Create View vueAccountProjectTaskUpdateEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskUpdateEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskUpdateEmail
AS
SELECT     dbo.vueAccountProjectTask.AccountProjectTaskId, dbo.vueAccountProjectTask.AccountProjectId, 
                      dbo.vueAccountProjectTask.ParentAccountProjectTaskId, dbo.vueAccountProjectTask.TaskName, dbo.vueAccountProjectTask.TaskDescription, 
                      dbo.vueAccountProjectTask.AccountTaskTypeId, dbo.vueAccountProjectTask.Duration, dbo.vueAccountProjectTask.DurationUnit, 
                      dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, dbo.vueAccountProjectTask.Completed, 
                      dbo.vueAccountProjectTask.IsParentTask, dbo.vueAccountProjectTask.IsForAllEmployees, dbo.vueAccountProjectTask.AccountPriorityId, 
                      dbo.vueAccountProjectTask.TaskStatusId, dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.CreatedByEmployeeId, 
                      dbo.vueAccountProjectTask.ModifiedOn, dbo.vueAccountProjectTask.ModifiedByEmployeeId, dbo.vueAccountProjectTask.TaskStatus, 
                      dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, dbo.vueAccountProjectTask.Priority, 
                      dbo.vueAccountProjectTask.ProjectName, dbo.vueAccountProjectTask.ProjectCode, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.AccountId, dbo.vueAccountProjectTask.AccountProjectMilestoneId, dbo.vueAccountProjectTask.MilestoneDescription, 
                      dbo.vueAccountProjectTask.IsReOpen, dbo.vueAccountProjectTask.ModifiedByFirstName, dbo.vueAccountProjectTask.ModifiedByLastName, 
                      dbo.vueAccountProjectTask.EstimatedCost, dbo.vueAccountProjectTask.EstimatedTimeSpent, dbo.vueAccountProjectTask.EstimatedTimeSpentUnit, 
                      dbo.vueAccountProjectTask.AccountEmployeeId, dbo.AccountEmployee.EMailAddress
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.vueAccountProjectTask ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTask.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTask.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTask.CreatedByEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 7) AND (AccountEMailNotificationPreference_1.Enabled = ''True'') AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 6) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 5) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO

-- Create View vueAccountProjectTaskEmployeeUpdateEmail
Print 'Create View vueAccountProjectTaskEmployeeUpdateEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskEmployeeUpdateEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskEmployeeUpdateEmail
AS
SELECT     dbo.vueAccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountProjectId, 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId, dbo.vueAccountProjectTaskEmployee.TaskName, 
                      dbo.vueAccountProjectTaskEmployee.FirstName, dbo.vueAccountProjectTaskEmployee.LastName, 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountId, 
                      dbo.vueAccountProjectTaskEmployee.ProjectCode, dbo.vueAccountProjectTaskEmployee.TaskStatusId, 
                      dbo.vueAccountProjectTaskEmployee.Completed, dbo.AccountProject.ProjectName, dbo.AccountEmployee.EMailAddress, 
                      dbo.vueAccountProjectTask.TaskDescription, dbo.vueAccountProjectTask.TaskStatus, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.Priority, dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, 
                      dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.MilestoneDescription, dbo.vueAccountProjectTask.Duration, 
                      dbo.vueAccountProjectTask.DurationUnit, dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, 
                      dbo.vueAccountProjectTask.IsReOpen, dbo.vueAccountProjectTask.ModifiedByFirstName, dbo.vueAccountProjectTask.ModifiedByLastName
FROM         dbo.AccountProject RIGHT OUTER JOIN
                      dbo.vueAccountProjectTaskEmployee LEFT OUTER JOIN
                      dbo.vueAccountProjectTask ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId = dbo.vueAccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.vueAccountProjectTaskEmployee.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTaskEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 7) AND (AccountEMailNotificationPreference_1.Enabled = ''True'') AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 6) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 5) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO

-- Create View vueAccountEmployeeTimeEntryRejectedEmail
Print 'Create View vueAccountEmployeeTimeEntryRejectedEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryRejectedEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryRejectedEmail
AS
SELECT     dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.vueAccountEmployeeTimeEntry.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntry.TaskName, dbo.vueAccountEmployeeTimeEntry.TotalTime, dbo.vueAccountEmployeeTimeEntry.Approved, 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntry.TeamLeadApproved, dbo.vueAccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.vueAccountEmployeeTimeEntry.AdministratorApproved, dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntry.StartTime, dbo.vueAccountEmployeeTimeEntry.EndTime, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntry.Description, dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.vueAccountEmployeeTimeEntry.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntry.WeekDay, dbo.vueAccountEmployeeTimeEntry.AccountPartyId, dbo.vueAccountEmployeeTimeEntry.PartyName, 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectTaskId, dbo.vueAccountEmployeeTimeEntry.BillingType, 
                      dbo.vueAccountEmployeeTimeEntry.LeaderEmployeeId, dbo.vueAccountEmployeeTimeEntry.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntry.TimeSheetApprovalTypeId, dbo.vueAccountEmployeeTimeEntry.ExpenseApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntry.IsBillable, dbo.vueAccountEmployeeTimeEntry.Rejected, dbo.vueAccountEmployeeTimeEntry.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntry.ProjectBillingRateTypeId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments
FROM         dbo.vueAccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId LEFT OUTER
                       JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectId = dbo.AccountEMailNotificationPreference.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountId = AccountEMailNotificationPreference_2.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 19) AND (AccountEMailNotificationPreference_1.Enabled = ''True'') AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 17) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 18) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO

-- Create View vueAccountEmployeeTimeEntryApprovedEmail
Print 'Create View vueAccountEmployeeTimeEntryApprovedEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovedEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovedEmail
AS
SELECT     dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.vueAccountEmployeeTimeEntry.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntry.TaskName, dbo.vueAccountEmployeeTimeEntry.TotalTime, dbo.vueAccountEmployeeTimeEntry.Approved, 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntry.TeamLeadApproved, dbo.vueAccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.vueAccountEmployeeTimeEntry.AdministratorApproved, dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntry.StartTime, dbo.vueAccountEmployeeTimeEntry.EndTime, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntry.Description, dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.vueAccountEmployeeTimeEntry.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntry.WeekDay, dbo.vueAccountEmployeeTimeEntry.AccountPartyId, dbo.vueAccountEmployeeTimeEntry.PartyName, 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectTaskId, dbo.vueAccountEmployeeTimeEntry.BillingType, 
                      dbo.vueAccountEmployeeTimeEntry.LeaderEmployeeId, dbo.vueAccountEmployeeTimeEntry.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntry.TimeSheetApprovalTypeId, dbo.vueAccountEmployeeTimeEntry.ExpenseApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntry.IsBillable, dbo.vueAccountEmployeeTimeEntry.Rejected, dbo.vueAccountEmployeeTimeEntry.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntry.ProjectBillingRateTypeId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments
FROM         dbo.vueAccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId LEFT OUTER
                       JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectId = dbo.AccountEMailNotificationPreference.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountId = AccountEMailNotificationPreference_2.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 16) AND (AccountEMailNotificationPreference_1.Enabled = ''True'') AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 14) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 15) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'

GO
-- Drop View vueAccountEmployeeTimeEntryWithAccountProjectRole
Print 'Drop View vueAccountEmployeeTimeEntryWithAccountProjectRole'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithAccountProjectRole' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryWithAccountProjectRole]
GO

-- Drop View vueAccountEmployeeTimeEntryWithAccountProjectEmployee
Print 'Drop View vueAccountEmployeeTimeEntryWithAccountProjectEmployee'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithAccountProjectEmployee' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryWithAccountProjectEmployee]
GO

-- Create View vueAccountEmployeeTimeEntryWithAccountProjectEmployee
Print 'Create View vueAccountEmployeeTimeEntryWithAccountProjectEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithAccountProjectEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithAccountProjectEmployee
AS
SELECT     dbo.AccountProjectEmployee.AccountProjectEmployeeId, dbo.AccountProjectEmployee.AccountId, dbo.AccountProjectEmployee.AccountProjectId, 
                      dbo.AccountProjectEmployee.AccountEmployeeId, dbo.AccountProjectEmployee.TaskCompletedPercentage, 
                      dbo.AccountProjectEmployee.TaskCompleted, dbo.AccountProjectEmployee.AccountRoleId, dbo.AccountProjectEmployee.AccountBillingRateId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountProject.ProjectBillingRateTypeId, 
                      dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, dbo.AccountProjectTask.IsBillable
FROM         dbo.AccountProjectEmployee INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND 
                      dbo.AccountProjectEmployee.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId'
GO
-- Create View vueAccountEmployeeTimeEntryWithAccountProjectRole
Print 'Create View vueAccountEmployeeTimeEntryWithAccountProjectRole'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithAccountProjectRole' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithAccountProjectRole
AS
SELECT     dbo.AccountProjectRole.AccountProjectRoleId, dbo.AccountProjectRole.AccountProjectId, dbo.AccountProjectRole.AccountRoleId, 
                      dbo.AccountProjectRole.NumberOfResources, dbo.AccountProjectRole.BillingRate, dbo.AccountProjectRole.BillingTypeId, 
                      dbo.AccountProjectRole.AccountBillingRateId, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeId, dbo.AccountProject.ProjectBillingRateTypeId, 
                      dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, dbo.AccountProjectTask.IsBillable
FROM         dbo.AccountProjectRole INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectRole.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId INNER JOIN
                      dbo.AccountProjectEmployee ON dbo.AccountProjectRole.AccountProjectId = dbo.AccountProjectEmployee.AccountProjectId AND 
                      dbo.AccountProjectRole.AccountRoleId = dbo.AccountProjectEmployee.AccountRoleId INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId'

GO

-- Add Column Version to AccountPreferences
Print 'Add Column Version to AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Version' AND TABLE_NAME='AccountPreferences'))
ALTER TABLE [dbo].[AccountPreferences]
	ADD [Version] varchar(50) NULL

GO

-- Alter Column EMailAddress on AccountPartyContact
Print 'Alter Column EMailAddress on AccountPartyContact'
GO
ALTER TABLE [dbo].[AccountPartyContact]
	 ALTER COLUMN [EMailAddress] varchar(50) NULL
GO

-- =======================================================
-- Foreign Key Constraint Nochecks's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Nochecks''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemEMailNotification]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemEMailNotification]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemEMailNotification] WHERE [SystemEMailNotificationId] = 1 and [SystemEMailNotification] = 'Employee Add Notification' and [SystemEMailNotificationTypeId] = 1 and [Enabled] =1)
BEGIN
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (1, 'Employee Add Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (2, 'Task Add Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (3, 'Task Add Notification', 2, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (4, 'Task Add Notification', 3, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (5, 'Task Update Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (6, 'Task Update Notification', 2, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (7, 'Task Update Notification', 3, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (8, 'Attachment Add Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (9, 'Attachment Add Notification', 2, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (10, 'Attachment Add Notification', 3, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (11, 'Daily Timesheet Approval Pending Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (12, 'Daily Timesheet Approval Pending Notification', 2, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (13, 'Daily Timesheet Approval Pending Notification', 3, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (14, 'Timesheet Approved Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (15, 'Timesheet Approved Notification', 2, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (16, 'Timesheet Approved Notification', 3, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (17, 'Timesheet Rejected Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (18, 'Timesheet Rejected Notification', 2, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (19, 'Timesheet Rejected Notification', 3, 1)
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemEMailNotificationType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemEMailNotificationType]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemEMailNotificationType] WHERE [SystemEMailNotificationTypeId] = 1 and [SystemEMailNotificationType] = 'Account Level')
BEGIN
INSERT INTO [dbo].[SystemEMailNotificationType] ([SystemEMailNotificationTypeId], [SystemEMailNotificationType]) VALUES (1, 'Account Level')
INSERT INTO [dbo].[SystemEMailNotificationType] ([SystemEMailNotificationTypeId], [SystemEMailNotificationType]) VALUES (2, 'Project Level')
INSERT INTO [dbo].[SystemEMailNotificationType] ([SystemEMailNotificationTypeId], [SystemEMailNotificationType]) VALUES (3, 'Employee Level')
END

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPage] WHERE [SystemSecurityCategoryPageId] =96 AND [SystemSecurityCategoryId] = 1 AND [SequenceNumber] = '2115' AND [Folder] = 'AccountAdmin' AND [SystemCategoryPage] = 'AccountPartyContacts.aspx' AND [SystemCategoryPageDescription] = 'Client Contacts' AND [ParentSystemSecurityCateogoryPageId] = 8 AND [IsSiteMapPage] = 1 AND [IsCustomizeable] = 1 AND [IsAllowAdd] = 1 AND [IsAllowEdit]=1 AND [IsAllowDelete]=1 AND [IsAllowList]=1 AND [IsShowDataOptions] is NULL AND [IsShowTillOptions] Is Null AND [IsSystemPage] is NULL AND [ControlLevelPermission] is NULL)
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (96, 1, '2115', 'AccountAdmin', 'AccountPartyContacts.aspx', 'Client Contacts', 8, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (97, 1, '2116', 'AccountAdmin', 'AccountPartyDepartments.aspx', 'Client Departments', 8, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (98, 1, '2117', 'AccountAdmin', 'AccountEMailNotificationPreferences.aspx', 'EMail Notification Preferences', 15, 1, 1, 0, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (99, 3, '2118', 'ProjectAdmin', 'AccountEMailNotificationPreferences.aspx', 'EMail Notification Preferences', 27, 1, 1, 0, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (100, 2, '2119', 'Employee', 'AccountEMailNotificationPreferences.aspx', 'EMail Notification Preferences', 4, 1, 1, 0, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (101, 2, '2120', 'Employee', 'MyAccountEMailNotificationPreferences.aspx', 'My Preferences', 25, 1, 1, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL)
END
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'

UPDATE [dbo].[SystemSecurityCategoryPage] SET [IsCustomizeable]=0, [IsAllowList]=NULL WHERE [SystemSecurityCategoryPageId]=16

GO

-- =======================================================
-- Foreign Key Constraint Check's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Check''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]

--END 2.5

--TimeLive 2.51.0003
--Start 2.51.0003

GO
-- Drop View vueAccountExpense
Print 'Drop View vueAccountExpense'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpense' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpense]
GO
-- Drop View vueAccountEmployeeTimeEntryApprovedEmail
Print 'Drop View vueAccountEmployeeTimeEntryApprovedEmail'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovedEmail' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovedEmail]
GO
-- Drop View vueAccountEmployeeTimeEntryRejectedEmail
Print 'Drop View vueAccountEmployeeTimeEntryRejectedEmail'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryRejectedEmail' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryRejectedEmail]
GO
-- Drop View vueAccountExpenseEntryApprovalPending
Print 'Drop View vueAccountExpenseEntryApprovalPending'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountExpenseEntryApprovalPending]
GO
-- Drop View vueAccountPagePermission
Print 'Drop View vueAccountPagePermission'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountPagePermission' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountPagePermission]
GO
-- Drop View vueAccountBillingType
Print 'Drop View vueAccountBillingType'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountBillingType' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountBillingType]
GO
-- Drop View vueAccountEmployee
Print 'Drop View vueAccountEmployee'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountEmployee]
GO
-- Drop View vueAccount
Print 'Drop View vueAccount'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccount' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccount]
GO
-- Drop View vueAccountStatus
Print 'Drop View vueAccountStatus'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountStatus' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountStatus]
GO
-- Drop View vueAccountProjectTaskEmployeeUpdateEmail
Print 'Drop View vueAccountProjectTaskEmployeeUpdateEmail'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskEmployeeUpdateEmail' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountProjectTaskEmployeeUpdateEmail]
GO
-- Drop View vueAccountProjectTaskUpdateEmail
Print 'Drop View vueAccountProjectTaskUpdateEmail'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskUpdateEmail' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountProjectTaskUpdateEmail]
GO
-- Drop View vueSystemSecurityCategoryPage
Print 'Drop View vueSystemSecurityCategoryPage'
GO
if exists (select * from information_schema.tables where table_name = 'vueSystemSecurityCategoryPage' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueSystemSecurityCategoryPage]
GO
-- Drop View vueSystemDefaultSecurity
Print 'Drop View vueSystemDefaultSecurity'
GO
if exists (select * from information_schema.tables where table_name = 'vueSystemDefaultSecurity' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueSystemDefaultSecurity]
GO
-- Drop View vueExternalAccountEmployee
Print 'Drop View vueExternalAccountEmployee'
GO
if exists (select * from information_schema.tables where table_name = 'vueExternalAccountEmployee' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueExternalAccountEmployee]
GO
-- Drop View vueAccountProjects
Print 'Drop View vueAccountProjects'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjects' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountProjects]
GO
-- Drop View vueAccountProjectTaskEmployeeEmail
Print 'Drop View vueAccountProjectTaskEmployeeEmail'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskEmployeeEmail' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountProjectTaskEmployeeEmail]
GO
-- Drop View vueAccountProjectTaskEmail
Print 'Drop View vueAccountProjectTaskEmail'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskEmail' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountProjectTaskEmail]
GO
-- Drop View vueExpenseApprovalSequence
Print 'Drop View vueExpenseApprovalSequence'
GO
if exists (select * from information_schema.tables where table_name = 'vueExpenseApprovalSequence' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueExpenseApprovalSequence]
GO
-- Drop View vueAccountEmployeeTimeEntryApprovalPendingEMail
Print 'Drop View vueAccountEmployeeTimeEntryApprovalPendingEMail'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPendingEMail' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovalPendingEMail]
GO
-- Drop Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId from AccountEmployeeAttendance
Print 'Drop Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId from AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance] DROP CONSTRAINT [DF_AccountEmployeeAttendance_CreatedByEmployeeId]
GO
-- Drop Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId from AccountEmployeeAttendance
Print 'Drop Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId from AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance] DROP CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedByEmployeeId]
GO
-- Drop Default Constraint DF_AccountDepartment_IsDeleted from AccountDepartment
Print 'Drop Default Constraint DF_AccountDepartment_IsDeleted from AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDeleted'))
ALTER TABLE [dbo].[AccountDepartment] DROP CONSTRAINT [DF_AccountDepartment_IsDeleted]
GO
-- Drop Default Constraint DF_AccountDepartment_IsDisabled from AccountDepartment
Print 'Drop Default Constraint DF_AccountDepartment_IsDisabled from AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDisabled'))
ALTER TABLE [dbo].[AccountDepartment] DROP CONSTRAINT [DF_AccountDepartment_IsDisabled]
GO
-- Drop Default Constraint DF_AccountLocation_CreatedByEmployeeId from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_CreatedByEmployeeId from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_CreatedByEmployeeId]
GO
-- Drop Default Constraint DF_AccountLocation_IsDisabled from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_IsDisabled from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_IsDisabled'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_IsDisabled]
GO
-- Drop Default Constraint DF_AccountLocation_ModifiedByEmployeeId from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_ModifiedByEmployeeId from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_ModifiedByEmployeeId]
GO
-- Drop Index IX_AccountRole from AccountRole
Print 'Drop Index IX_AccountRole from AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID (N'[dbo].[AccountRole]') AND name = N'IX_AccountRole'))
DROP INDEX [dbo].[AccountRole].[IX_AccountRole]
GO
-- Drop View vueAccountProjectTask
Print 'Drop View vueAccountProjectTask'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountProjectTask' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountProjectTask]
GO
-- Drop Foreign Key FK_AccountPriority_Account from AccountPriority
Print 'Drop Foreign Key FK_AccountPriority_Account from AccountPriority'
GO
IF OBJECT_ID(N'[FK_AccountPriority_Account]') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[AccountPriority] DROP CONSTRAINT [FK_AccountPriority_Account]
END
GO
-- Drop View vueAccountEmployeeTimeEntryApprovalPending
Print 'Drop View vueAccountEmployeeTimeEntryApprovalPending'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPending' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovalPending]
GO
-- Drop View vueTimesheetApprovalSequence
Print 'Drop View vueTimesheetApprovalSequence'
GO
if exists (select * from information_schema.tables where table_name = 'vueTimesheetApprovalSequence' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueTimesheetApprovalSequence]
GO
-- Drop Foreign Key FK_AccountProjectTask_AccountProject from AccountProjectTask
Print 'Drop Foreign Key FK_AccountProjectTask_AccountProject from AccountProjectTask'
GO
IF OBJECT_ID(N'[FK_AccountProjectTask_AccountProject]') IS NOT NULL
BEGIN
	ALTER TABLE [dbo].[AccountProjectTask] DROP CONSTRAINT [FK_AccountProjectTask_AccountProject]
END
GO
-- Create Index IX_AccountEmployeeTimeEntryId on AccountEmployeeTimeEntryApproval
Print 'Create Index IX_AccountEmployeeTimeEntryId on AccountEmployeeTimeEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEmployeeTimeEntryApproval]') AND name = N'IX_AccountEmployeeTimeEntryId'))
CREATE INDEX [IX_AccountEmployeeTimeEntryId]
	ON [dbo].[AccountEmployeeTimeEntryApproval] ([AccountEmployeeTimeEntryId])
GO
-- Create Index IX_TimeSheetApprovalTypeId on AccountEmployeeTimeEntryApproval
Print 'Create Index IX_TimeSheetApprovalTypeId on AccountEmployeeTimeEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEmployeeTimeEntryApproval]') AND name = N'IX_TimeSheetApprovalTypeId'))
CREATE INDEX [IX_TimeSheetApprovalTypeId]
	ON [dbo].[AccountEmployeeTimeEntryApproval] ([TimeSheetApprovalTypeId])
GO
-- Create Index IX_TimeSheetApprovalPathId on AccountEmployeeTimeEntryApproval
Print 'Create Index IX_TimeSheetApprovalPathId on AccountEmployeeTimeEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEmployeeTimeEntryApproval]') AND name = N'IX_TimeSheetApprovalPathId'))
CREATE INDEX [IX_TimeSheetApprovalPathId]
	ON [dbo].[AccountEmployeeTimeEntryApproval] ([TimeSheetApprovalPathId])
GO
-- Create Index IX_ApprovedByEmployeeId on AccountEmployeeTimeEntryApproval
Print 'Create Index IX_ApprovedByEmployeeId on AccountEmployeeTimeEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEmployeeTimeEntryApproval]') AND name = N'IX_ApprovedByEmployeeId'))
CREATE INDEX [IX_ApprovedByEmployeeId]
	ON [dbo].[AccountEmployeeTimeEntryApproval] ([ApprovedByEmployeeId])
GO
-- Create Index IX_AccountId on AccountApprovalPath
Print 'Create Index IX_AccountId on AccountApprovalPath'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountApprovalPath' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountApprovalPath]') AND name = N'IX_AccountId'))
CREATE INDEX [IX_AccountId]
	ON [dbo].[AccountApprovalPath] ([AccountId])
GO
-- Create Index IX_AccountApprovalTypeId on AccountApprovalPath
Print 'Create Index IX_AccountApprovalTypeId on AccountApprovalPath'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountApprovalPath' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountApprovalPath]') AND name = N'IX_AccountApprovalTypeId'))
CREATE INDEX [IX_AccountApprovalTypeId]
	ON [dbo].[AccountApprovalPath] ([AccountApprovalTypeId])
GO
-- Create Index IX_AccountExternalUserId on AccountApprovalPath
Print 'Create Index IX_AccountExternalUserId on AccountApprovalPath'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountApprovalPath' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountApprovalPath]') AND name = N'IX_AccountExternalUserId'))
CREATE INDEX [IX_AccountExternalUserId]
	ON [dbo].[AccountApprovalPath] ([AccountExternalUserId])
GO
-- Create Index IX_AccountEmployeeId on AccountApprovalPath
Print 'Create Index IX_AccountEmployeeId on AccountApprovalPath'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountApprovalPath' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountApprovalPath]') AND name = N'IX_AccountEmployeeId'))
CREATE INDEX [IX_AccountEmployeeId]
	ON [dbo].[AccountApprovalPath] ([AccountEmployeeId])
GO
-- Create Index IX_AccountId on AccountApprovalType
Print 'Create Index IX_AccountId on AccountApprovalType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountApprovalType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountApprovalType]') AND name = N'IX_AccountId'))
CREATE INDEX [IX_AccountId]
	ON [dbo].[AccountApprovalType] ([AccountId])
GO
-- Add Column IsDisabled to AccountProject
Print 'Add Column IsDisabled to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountProject'))
ALTER TABLE [dbo].[AccountProject]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountProject_IsDisabled] DEFAULT ((0))

GO
-- Create Index IX_AccountMilestoneId on AccountProject
Print 'Create Index IX_AccountMilestoneId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_AccountMilestoneId'))
CREATE INDEX [IX_AccountMilestoneId]
	ON [dbo].[AccountProject] ([AccountMilestoneId])
GO
-- Create Index IX_AccountPartyContactId on AccountProject
Print 'Create Index IX_AccountPartyContactId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_AccountPartyContactId'))
CREATE INDEX [IX_AccountPartyContactId]
	ON [dbo].[AccountProject] ([AccountPartyContactId])
GO
-- Create Index IX_AccountPartyDepartmentId on AccountProject
Print 'Create Index IX_AccountPartyDepartmentId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_AccountPartyDepartmentId'))
CREATE INDEX [IX_AccountPartyDepartmentId]
	ON [dbo].[AccountProject] ([AccountPartyDepartmentId])
GO
-- Create Index IX_AccountPriorityId on AccountProject
Print 'Create Index IX_AccountPriorityId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_AccountPriorityId'))
CREATE INDEX [IX_AccountPriorityId]
	ON [dbo].[AccountProject] ([AccountPriorityId])
GO
-- Create Index IX_AccountProjectTypeId on AccountProject
Print 'Create Index IX_AccountProjectTypeId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_AccountProjectTypeId'))
CREATE INDEX [IX_AccountProjectTypeId]
	ON [dbo].[AccountProject] ([AccountProjectTypeId])
GO
-- Create Index IX_ExpenseApprovalTypeId on AccountProject
Print 'Create Index IX_ExpenseApprovalTypeId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_ExpenseApprovalTypeId'))
CREATE INDEX [IX_ExpenseApprovalTypeId]
	ON [dbo].[AccountProject] ([ExpenseApprovalTypeId])
GO
-- Create Index IX_ProjectBillingRateTypeId on AccountProject
Print 'Create Index IX_ProjectBillingRateTypeId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_ProjectBillingRateTypeId'))
CREATE INDEX [IX_ProjectBillingRateTypeId]
	ON [dbo].[AccountProject] ([ProjectBillingRateTypeId])
GO
-- Create Index IX_ProjectBillingTypeId on AccountProject
Print 'Create Index IX_ProjectBillingTypeId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_ProjectBillingTypeId'))
CREATE INDEX [IX_ProjectBillingTypeId]
	ON [dbo].[AccountProject] ([ProjectBillingTypeId])
GO
-- Create Index IX_ProjectStatusId on AccountProject
Print 'Create Index IX_ProjectStatusId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_ProjectStatusId'))
CREATE INDEX [IX_ProjectStatusId]
	ON [dbo].[AccountProject] ([ProjectStatusId])
GO
-- Create Index IX_TimeSheetApprovalTypeId on AccountProject
Print 'Create Index IX_TimeSheetApprovalTypeId on AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProject]') AND name = N'IX_TimeSheetApprovalTypeId'))
CREATE INDEX [IX_TimeSheetApprovalTypeId]
	ON [dbo].[AccountProject] ([TimeSheetApprovalTypeId])
GO
-- Add Column Username to AccountEmployee
Print 'Add Column Username to AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Username' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee]
	ADD [Username] varchar(50) NULL

GO
-- Add Column IsDisabled to AccountProjectTask
Print 'Add Column IsDisabled to AccountProjectTask'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectTask' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountProjectTask'))
ALTER TABLE [dbo].[AccountProjectTask]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountProjectTask_IsDisabled] DEFAULT ((0))

GO
-- Create View vueTimesheetApprovalSequence
Print 'Create View vueTimesheetApprovalSequence'
GO
if not exists (select * from information_schema.tables where table_name = 'vueTimesheetApprovalSequence' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueTimesheetApprovalSequence
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId AND 
                      dbo.AccountEmployeeTimeEntryApproval.IsReject <> 1'
GO
-- Create View vueAccountEmployeeTimeEntryApprovalPending
Print 'Create View vueAccountEmployeeTimeEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPending
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectId, dbo.vueAccountEmployeeTimeEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.SystemApproverTypeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectDescription, dbo.vueAccountEmployeeTimeEntryApproval.ProjectCode, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskName, dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskDescription, dbo.vueAccountEmployeeTimeEntryApproval.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Approved, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TotalTime, dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Comments, dbo.vueAccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApproval.IsApproved, dbo.vueAccountApproverType.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryAccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.EMailAddress
FROM         dbo.vueAccountEmployeeTimeEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId IN
                          (SELECT     TOP 1 AccountApprovalPathId
                            FROM          dbo.vueTimesheetApprovalSequence
                            WHERE      (TimeSheetApprovalId IS NULL) AND 
                                                   (AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId)))'
GO
-- Add Column IsDisabled to AccountTaskType
Print 'Add Column IsDisabled to AccountTaskType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountTaskType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountTaskType'))
ALTER TABLE [dbo].[AccountTaskType]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountTaskType_IsDisabled_1] DEFAULT ((0))

GO
-- Add Column IsDisabled to AccountPriority
Print 'Add Column IsDisabled to AccountPriority'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPriority' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountPriority'))
ALTER TABLE [dbo].[AccountPriority]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountPriority_IsDisabled_1] DEFAULT ((0))

GO
-- Add Column IsDisabled to AccountStatus
Print 'Add Column IsDisabled to AccountStatus'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountStatus' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountStatus'))
ALTER TABLE [dbo].[AccountStatus]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountStatus_IsDisabled] DEFAULT ((0))

GO
-- Create Index IX_AccountId on AccountBillingRate
Print 'Create Index IX_AccountId on AccountBillingRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountBillingRate' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountBillingRate]') AND name = N'IX_AccountId'))
CREATE INDEX [IX_AccountId]
	ON [dbo].[AccountBillingRate] ([AccountId])
GO
-- Create Index IX_AccountEmployeeId on AccountEMailNotificationPreference
Print 'Create Index IX_AccountEmployeeId on AccountEMailNotificationPreference'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEMailNotificationPreference' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEMailNotificationPreference]') AND name = N'IX_AccountEmployeeId'))
CREATE INDEX [IX_AccountEmployeeId]
	ON [dbo].[AccountEMailNotificationPreference] ([AccountEmployeeId])
GO
-- Create Index IX_AccountProjectId on AccountEMailNotificationPreference
Print 'Create Index IX_AccountProjectId on AccountEMailNotificationPreference'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEMailNotificationPreference' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEMailNotificationPreference]') AND name = N'IX_AccountProjectId'))
CREATE INDEX [IX_AccountProjectId]
	ON [dbo].[AccountEMailNotificationPreference] ([AccountProjectId])
GO
-- Create Index IX_AccountId on AccountEMailNotificationPreference
Print 'Create Index IX_AccountId on AccountEMailNotificationPreference'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEMailNotificationPreference' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEMailNotificationPreference]') AND name = N'IX_AccountId'))
CREATE INDEX [IX_AccountId]
	ON [dbo].[AccountEMailNotificationPreference] ([AccountId])
GO
-- Create Index IX_SystemEMailNotificationId on AccountEMailNotificationPreference
Print 'Create Index IX_SystemEMailNotificationId on AccountEMailNotificationPreference'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEMailNotificationPreference' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEMailNotificationPreference]') AND name = N'IX_SystemEMailNotificationId'))
CREATE INDEX [IX_SystemEMailNotificationId]
	ON [dbo].[AccountEMailNotificationPreference] ([SystemEMailNotificationId])
GO
-- Create Index IX_SystemEMailNotificationTypeId on AccountEMailNotificationPreference
Print 'Create Index IX_SystemEMailNotificationTypeId on AccountEMailNotificationPreference'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEMailNotificationPreference' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEMailNotificationPreference]') AND name = N'IX_SystemEMailNotificationTypeId'))
CREATE INDEX [IX_SystemEMailNotificationTypeId]
	ON [dbo].[AccountEMailNotificationPreference] ([SystemEMailNotificationTypeId])
GO
-- Alter Column Amount on AccountExpenseEntry
Print 'Alter Column Amount on AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Amount' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	 ALTER COLUMN [Amount] float NOT NULL
GO
-- Create Index IX_AccountExpenseEntryId on AccountExpenseEntryApproval
Print 'Create Index IX_AccountExpenseEntryId on AccountExpenseEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountExpenseEntryApproval]') AND name = N'IX_AccountExpenseEntryId'))
CREATE INDEX [IX_AccountExpenseEntryId]
	ON [dbo].[AccountExpenseEntryApproval] ([AccountExpenseEntryId])
GO
-- Create Index IX_ExpenseApprovalTypeId on AccountExpenseEntryApproval
Print 'Create Index IX_ExpenseApprovalTypeId on AccountExpenseEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountExpenseEntryApproval]') AND name = N'IX_ExpenseApprovalTypeId'))
CREATE INDEX [IX_ExpenseApprovalTypeId]
	ON [dbo].[AccountExpenseEntryApproval] ([ExpenseApprovalTypeId])
GO
-- Create Index IX_ExpenseApprovalPathId on AccountExpenseEntryApproval
Print 'Create Index IX_ExpenseApprovalPathId on AccountExpenseEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountExpenseEntryApproval]') AND name = N'IX_ExpenseApprovalPathId'))
CREATE INDEX [IX_ExpenseApprovalPathId]
	ON [dbo].[AccountExpenseEntryApproval] ([ExpenseApprovalPathId])
GO
-- Create Index IX_ApprovedByEmployeeId on AccountExpenseEntryApproval
Print 'Create Index IX_ApprovedByEmployeeId on AccountExpenseEntryApproval'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntryApproval' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountExpenseEntryApproval]') AND name = N'IX_ApprovedByEmployeeId'))
CREATE INDEX [IX_ApprovedByEmployeeId]
	ON [dbo].[AccountExpenseEntryApproval] ([ApprovedByEmployeeId])
GO
-- Add Column IsDisabled to AccountExpense
Print 'Add Column IsDisabled to AccountExpense'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpense' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountExpense'))
ALTER TABLE [dbo].[AccountExpense]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountExpense_IsDisabled] DEFAULT ((0))

GO
-- Add Column IsDisabled to AccountBillingType
Print 'Add Column IsDisabled to AccountBillingType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountBillingType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountBillingType'))
ALTER TABLE [dbo].[AccountBillingType]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountBillingType_IsDisabled] DEFAULT ((0))

GO
-- Create Index IX_PartyTypeId on AccountParty
Print 'Create Index IX_PartyTypeId on AccountParty'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountParty' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountParty]') AND name = N'IX_PartyTypeId'))
CREATE INDEX [IX_PartyTypeId]
	ON [dbo].[AccountParty] ([PartyTypeId])
GO
-- Create View vueAccountProjectTask
Print 'Create View vueAccountProjectTask'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTask' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTask
AS
SELECT     dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.AccountTaskTypeId, 
                      dbo.AccountProjectTask.Duration, dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, 
                      dbo.AccountProjectTask.CompletedPercent, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.CreatedOn, dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.ModifiedOn, 
                      dbo.AccountProjectTask.ModifiedByEmployeeId, dbo.AccountStatus.Status AS TaskStatus, dbo.AccountEmployee.FirstName AS CreatedByFirstName, 
                      dbo.AccountEmployee.LastName AS CreatedByLastName, dbo.AccountPriority.Priority, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectCode, dbo.AccountTaskType.TaskType, dbo.AccountProject.AccountId, dbo.AccountProjectTask.AccountProjectMilestoneId, 
                      dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountProjectTask.IsReOpen, AccountEmployee_1.FirstName AS ModifiedByFirstName, 
                      AccountEmployee_1.LastName AS ModifiedByLastName, dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, 
                      dbo.AccountProjectTask.EstimatedTimeSpentUnit, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProjectTask.IsDisabled
FROM         dbo.AccountStatus RIGHT OUTER JOIN
                      dbo.AccountTaskType RIGHT OUTER JOIN
                      dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTask LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountProjectTask.ModifiedByEmployeeId = AccountEmployee_1.AccountEmployeeId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountProjectMilestone ON 
                      dbo.AccountProjectTask.AccountProjectMilestoneId = dbo.AccountProjectMilestone.AccountProjectMilestoneId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountTaskType.AccountTaskTypeId = dbo.AccountProjectTask.AccountTaskTypeId ON 
                      dbo.AccountStatus.AccountStatusId = dbo.AccountProjectTask.TaskStatusId LEFT OUTER JOIN
                      dbo.AccountPriority ON dbo.AccountProjectTask.AccountPriorityId = dbo.AccountPriority.AccountPriorityId'
GO
-- Create Index IX_AccountRoleId on AccountProjectEmployee
Print 'Create Index IX_AccountRoleId on AccountProjectEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProjectEmployee]') AND name = N'IX_AccountRoleId'))
CREATE INDEX [IX_AccountRoleId]
	ON [dbo].[AccountProjectEmployee] ([AccountRoleId])
GO
-- Create Index IX_AccountBillingRateId on AccountProjectEmployee
Print 'Create Index IX_AccountBillingRateId on AccountProjectEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProjectEmployee]') AND name = N'IX_AccountBillingRateId'))
CREATE INDEX [IX_AccountBillingRateId]
	ON [dbo].[AccountProjectEmployee] ([AccountBillingRateId])
GO
-- Create Index IX_AccountProjectId on AccountProjectRole
Print 'Create Index IX_AccountProjectId on AccountProjectRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProjectRole]') AND name = N'IX_AccountProjectId'))
CREATE INDEX [IX_AccountProjectId]
	ON [dbo].[AccountProjectRole] ([AccountProjectId])
GO
-- Create Index IX_AccountRoleId on AccountProjectRole
Print 'Create Index IX_AccountRoleId on AccountProjectRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProjectRole]') AND name = N'IX_AccountRoleId'))
CREATE INDEX [IX_AccountRoleId]
	ON [dbo].[AccountProjectRole] ([AccountRoleId])
GO
-- Create Index IX_BillingTypeId on AccountProjectRole
Print 'Create Index IX_BillingTypeId on AccountProjectRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProjectRole]') AND name = N'IX_BillingTypeId'))
CREATE INDEX [IX_BillingTypeId]
	ON [dbo].[AccountProjectRole] ([BillingTypeId])
GO
-- Create Index IX_AccountBillingRateId on AccountProjectRole
Print 'Create Index IX_AccountBillingRateId on AccountProjectRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountProjectRole]') AND name = N'IX_AccountBillingRateId'))
CREATE INDEX [IX_AccountBillingRateId]
	ON [dbo].[AccountProjectRole] ([AccountBillingRateId])
GO
-- Add Column LDAPRole to AccountRole
Print 'Add Column LDAPRole to AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='LDAPRole' AND TABLE_NAME='AccountRole'))
ALTER TABLE [dbo].[AccountRole]
	ADD [LDAPRole] varchar(100) NULL

GO
-- Create Index IX_AccountId on AccountRole
Print 'Create Index IX_AccountId on AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountRole]') AND name = N'IX_AccountId'))
CREATE INDEX [IX_AccountId]
	ON [dbo].[AccountRole] ([AccountId])
GO
-- Create Index IX_AccountTypeId on Account
Print 'Create Index IX_AccountTypeId on Account'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Account' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[Account]') AND name = N'IX_AccountTypeId'))
CREATE INDEX [IX_AccountTypeId]
	ON [dbo].[Account] ([AccountTypeId])
GO
-- Add Column FromEmailAddress to AccountPreferences
Print 'Add Column FromEmailAddress to AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='FromEmailAddress' AND TABLE_NAME='AccountPreferences'))
ALTER TABLE [dbo].[AccountPreferences]
	ADD [FromEmailAddress] varchar(50) NULL

GO
-- Add Column FromEmailAddressDisplayName to AccountPreferences
Print 'Add Column FromEmailAddressDisplayName to AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='FromEmailAddressDisplayName' AND TABLE_NAME='AccountPreferences'))
ALTER TABLE [dbo].[AccountPreferences]
	ADD [FromEmailAddressDisplayName] varchar(50) NULL

GO
-- Create Index IX_AccountSessionTimeout on AccountPreferences
Print 'Create Index IX_AccountSessionTimeout on AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountPreferences]') AND name = N'IX_AccountSessionTimeout'))
CREATE INDEX [IX_AccountSessionTimeout]
	ON [dbo].[AccountPreferences] ([AccountSessionTimeout])
GO
-- Add Default Constraint DF_AccountLocation_CreatedByEmployeeId to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_CreatedByEmployeeId to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_CreatedByEmployeeId]
	DEFAULT (0) FOR [CreatedByEmployeeId]
GO
-- Add Default Constraint DF_AccountLocation_IsDisabled to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_IsDisabled to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_IsDisabled'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO
-- Add Default Constraint DF_AccountLocation_ModifiedByEmployeeId to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_ModifiedByEmployeeId to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_ModifiedByEmployeeId]
	DEFAULT (0) FOR [ModifiedByEmployeeId]
GO
-- Add Default Constraint DF_AccountDepartment_IsDeleted to AccountDepartment
Print 'Add Default Constraint DF_AccountDepartment_IsDeleted to AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDeleted'))
ALTER TABLE [dbo].[AccountDepartment]
	ADD
	CONSTRAINT [DF_AccountDepartment_IsDeleted]
	DEFAULT (0) FOR [IsDeleted]
GO
-- Add Default Constraint DF_AccountDepartment_IsDisabled to AccountDepartment
Print 'Add Default Constraint DF_AccountDepartment_IsDisabled to AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDisabled'))
ALTER TABLE [dbo].[AccountDepartment]
	ADD
	CONSTRAINT [DF_AccountDepartment_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO
-- Add Column LDAPGroup to MasterAccountRole
Print 'Add Column LDAPGroup to MasterAccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='LDAPGroup' AND TABLE_NAME='MasterAccountRole'))
ALTER TABLE [dbo].[MasterAccountRole]
	ADD [LDAPGroup] varchar(50) NULL

GO
-- Create Index IX_AccountPartyId on AccountPartyDepartment
Print 'Create Index IX_AccountPartyId on AccountPartyDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPartyDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountPartyDepartment]') AND name = N'IX_AccountPartyId'))
CREATE INDEX [IX_AccountPartyId]
	ON [dbo].[AccountPartyDepartment] ([AccountPartyId])
GO
-- Add Column IsDisabled to AccountAbsenceType
Print 'Add Column IsDisabled to AccountAbsenceType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountAbsenceType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountAbsenceType'))
ALTER TABLE [dbo].[AccountAbsenceType]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountAbsenceType_IsDisabled] DEFAULT ((0))

GO
-- Add Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId to AccountEmployeeAttendance
Print 'Add Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId to AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance]
	ADD
	CONSTRAINT [DF_AccountEmployeeAttendance_CreatedByEmployeeId]
	DEFAULT (0) FOR [CreatedByEmployeeId]
GO
-- Add Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId to AccountEmployeeAttendance
Print 'Add Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId to AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance]
	ADD
	CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedByEmployeeId]
	DEFAULT (0) FOR [ModifiedByEmployeeId]
GO
-- Create View vueAccountEmployeeTimeEntryApprovalPendingEMail
Print 'Create View vueAccountEmployeeTimeEntryApprovalPendingEMail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPendingEMail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPendingEMail
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.SystemApproverTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeSheetApprovalPathId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectDescription, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ProjectCode, dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TaskName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TaskDescription, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.Approved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TotalTime, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.Comments, dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.IsApproved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.TimeEntryAccountEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountId, dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.EMailAddress, 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApproverEmployeeId
FROM         dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.ApproverEmployeeId = dbo.AccountEMailNotificationPreference.AccountEmployeeId LEFT
                       OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeEntryApprovalPendingApprover.AccountId = AccountEMailNotificationPreference_1.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 11) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 12) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 13) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueExpenseApprovalSequence
Print 'Create View vueExpenseApprovalSequence'
GO
if not exists (select * from information_schema.tables where table_name = 'vueExpenseApprovalSequence' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueExpenseApprovalSequence
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountExpenseEntryApproval.ExpenseApprovalId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.AccountExpenseEntry.AccountExpenseEntryId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountProject.AccountProjectId = dbo.AccountExpenseEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId AND 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId AND 
                      dbo.AccountExpenseEntryApproval.IsRejected <> 1'
GO
-- Create Index IX_AccountPartyId on AccountPartyContact
Print 'Create Index IX_AccountPartyId on AccountPartyContact'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPartyContact' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountPartyContact]') AND name = N'IX_AccountPartyId'))
CREATE INDEX [IX_AccountPartyId]
	ON [dbo].[AccountPartyContact] ([AccountPartyId])
GO
-- Create Index IX_AccountPartyDepartmentId on AccountPartyContact
Print 'Create Index IX_AccountPartyDepartmentId on AccountPartyContact'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPartyContact' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountPartyContact]') AND name = N'IX_AccountPartyDepartmentId'))
CREATE INDEX [IX_AccountPartyDepartmentId]
	ON [dbo].[AccountPartyContact] ([AccountPartyDepartmentId])
GO
-- Create Index IX_CountryId on AccountPartyContact
Print 'Create Index IX_CountryId on AccountPartyContact'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPartyContact' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountPartyContact]') AND name = N'IX_CountryId'))
CREATE INDEX [IX_CountryId]
	ON [dbo].[AccountPartyContact] ([CountryId])
GO
-- Add Column IsDisabled to AccountExpenseType
Print 'Add Column IsDisabled to AccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountExpenseType'))
ALTER TABLE [dbo].[AccountExpenseType]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountExpenseType_IsDisabled] DEFAULT ((0))

GO
-- Add Column IsDisabled to AccountProjectType
Print 'Add Column IsDisabled to AccountProjectType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsDisabled' AND TABLE_NAME='AccountProjectType'))
ALTER TABLE [dbo].[AccountProjectType]
	ADD [IsDisabled] bit NOT NULL
	CONSTRAINT [DF_AccountProjectType_IsDisabled] DEFAULT ((0))

GO
-- Create Table Authentication
Print 'Create Table Authentication'
GO
if not exists (select * from information_schema.tables where table_name = 'Authentication' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[Authentication] (
		[AuthenticationSettingId]           int NOT NULL IDENTITY(1, 1),
		[AccountId]                         int NOT NULL,
		[ActiveDirectoryAuthentication]     bit NOT NULL,
		[Domain]                            varchar(50) NOT NULL,
		[DirectoryName]                     varchar(50) NOT NULL
)
GO
-- Add Primary Key PK_Authentication to Authentication
Print 'Add Primary Key PK_Authentication to Authentication'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Authentication' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_Authentication' AND TABLE_NAME='Authentication'))
ALTER TABLE [dbo].[Authentication]
	ADD
	CONSTRAINT [PK_Authentication]
	PRIMARY KEY
	([AuthenticationSettingId])
GO
-- Add Default Constraint DF_Authentication_ActiveDirectoryAuthentication to Authentication
Print 'Add Default Constraint DF_Authentication_ActiveDirectoryAuthentication to Authentication'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Authentication' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_Authentication_ActiveDirectoryAuthentication'))
ALTER TABLE [dbo].[Authentication]
	ADD
	CONSTRAINT [DF_Authentication_ActiveDirectoryAuthentication]
	DEFAULT ((0)) FOR [ActiveDirectoryAuthentication]
GO
-- Create Index IX_AccountId on Authentication
Print 'Create Index IX_AccountId on Authentication'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Authentication' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[Authentication]') AND name = N'IX_AccountId'))
CREATE INDEX [IX_AccountId]
	ON [dbo].[Authentication] ([AccountId])
GO
-- Create View vueAccountProjectTaskEmail
Print 'Create View vueAccountProjectTaskEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskEmail
AS
SELECT     dbo.vueAccountProjectTask.AccountProjectTaskId, dbo.vueAccountProjectTask.AccountProjectId, 
                      dbo.vueAccountProjectTask.ParentAccountProjectTaskId, dbo.vueAccountProjectTask.TaskName, dbo.vueAccountProjectTask.TaskDescription, 
                      dbo.vueAccountProjectTask.AccountTaskTypeId, dbo.vueAccountProjectTask.Duration, dbo.vueAccountProjectTask.DurationUnit, 
                      dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, dbo.vueAccountProjectTask.Completed, 
                      dbo.vueAccountProjectTask.IsParentTask, dbo.vueAccountProjectTask.IsForAllEmployees, dbo.vueAccountProjectTask.AccountPriorityId, 
                      dbo.vueAccountProjectTask.TaskStatusId, dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.CreatedByEmployeeId, 
                      dbo.vueAccountProjectTask.ModifiedOn, dbo.vueAccountProjectTask.ModifiedByEmployeeId, dbo.vueAccountProjectTask.TaskStatus, 
                      dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, dbo.vueAccountProjectTask.Priority, 
                      dbo.vueAccountProjectTask.ProjectName, dbo.vueAccountProjectTask.ProjectCode, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.AccountId, dbo.vueAccountProjectTask.AccountProjectMilestoneId, dbo.vueAccountProjectTask.MilestoneDescription, 
                      dbo.vueAccountProjectTask.IsReOpen, dbo.vueAccountProjectTask.ModifiedByFirstName, dbo.vueAccountProjectTask.ModifiedByLastName, 
                      dbo.vueAccountProjectTask.EstimatedCost, dbo.vueAccountProjectTask.EstimatedTimeSpent, dbo.vueAccountProjectTask.EstimatedTimeSpentUnit, 
                      dbo.vueAccountProjectTask.AccountEmployeeId, dbo.AccountEmployee.EMailAddress
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.vueAccountProjectTask ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTask.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTask.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTask.CreatedByEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 4) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 3) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 2) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueAccountProjectTaskEmployeeEmail
Print 'Create View vueAccountProjectTaskEmployeeEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskEmployeeEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskEmployeeEmail
AS
SELECT     dbo.vueAccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountProjectId, 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId, dbo.vueAccountProjectTaskEmployee.TaskName, 
                      dbo.vueAccountProjectTaskEmployee.FirstName, dbo.vueAccountProjectTaskEmployee.LastName, 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountId, 
                      dbo.vueAccountProjectTaskEmployee.ProjectCode, dbo.vueAccountProjectTaskEmployee.TaskStatusId, 
                      dbo.vueAccountProjectTaskEmployee.Completed, dbo.AccountProject.ProjectName, dbo.AccountEmployee.EMailAddress, 
                      dbo.vueAccountProjectTask.TaskDescription, dbo.vueAccountProjectTask.TaskStatus, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.Priority, dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, 
                      dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.MilestoneDescription, dbo.vueAccountProjectTask.Duration, 
                      dbo.vueAccountProjectTask.DurationUnit, dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, 
                      dbo.vueAccountProjectTask.IsReOpen
FROM         dbo.AccountProject RIGHT OUTER JOIN
                      dbo.vueAccountProjectTaskEmployee LEFT OUTER JOIN
                      dbo.vueAccountProjectTask ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId = dbo.vueAccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.vueAccountProjectTaskEmployee.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTaskEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 4) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 3) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 2) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueAccountProjects
Print 'Create View vueAccountProjects'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjects' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjects
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountProject.StartDate, dbo.AccountProject.ProjectCode, 
                      dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, dbo.AccountProject.LeaderEmployeeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, AccountEmployee_1.FirstName + '' '' + dbo.AccountEmployee.LastName AS LeaderName, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS ProjectManagerName, dbo.AccountProject.AccountId, 
                      dbo.AccountProject.IsActive, dbo.AccountProject.Deadline, dbo.AccountProject.EstimatedDuration, dbo.AccountProject.EstimatedDurationUnit, 
                      dbo.AccountProject.ProjectStatusId, dbo.AccountStatus.Status, dbo.AccountProject.IsDisabled
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId LEFT OUTER JOIN
                      dbo.AccountStatus ON dbo.AccountProject.ProjectStatusId = dbo.AccountStatus.AccountStatusId FULL OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountEmployee.AccountEmployeeId = AccountEmployee_1.AccountEmployeeId ON 
                      dbo.AccountProject.ProjectManagerEmployeeId = dbo.AccountEmployee.AccountEmployeeId AND 
                      dbo.AccountProject.LeaderEmployeeId = AccountEmployee_1.AccountEmployeeId'
GO
-- Create View vueExternalAccountEmployee
Print 'Create View vueExternalAccountEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueExternalAccountEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueExternalAccountEmployee
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.AccountId, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.Password, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.BillingTypeId, dbo.AccountBillingType.BillingType, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountPreferences.ShowClockStartEnd, 
                      dbo.Account.TimeZoneId, dbo.AccountRole.MasterAccountRoleId, dbo.Account.DefaultCurrencyId, dbo.Account.CountryId, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.TimeEntryFormat, dbo.AccountEmployee.AllowedAccessFromIP, 
                      dbo.AccountRole.AccountRoleId, dbo.AccountPreferences.AccountSessionTimeout, dbo.AccountPreferences.ShowCompletedTasksInTimeSheet, 
                      dbo.AccountPreferences.CurrencySymbol, dbo.AccountPreferences.IsCompanyOwnLogo, dbo.Account.AccountExpiryActivation, 
                      dbo.Account.LicenseActivation, dbo.AccountEmployee.EmployeeTypeId, dbo.AccountEmployee.ExternalUserClientId, dbo.AccountParty.PartyName, 
                      dbo.AccountParty.PartyNick, dbo.AccountEmployee.IsDisabled
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountEmployee.ExternalUserClientId = dbo.AccountParty.AccountPartyId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId'
GO
-- Create View vueSystemDefaultSecurity
Print 'Create View vueSystemDefaultSecurity'
GO
if not exists (select * from information_schema.tables where table_name = 'vueSystemDefaultSecurity' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueSystemDefaultSecurity
AS
SELECT     dbo.SystemSecurityCategory.SystemSecurityCategoryId, dbo.SystemSecurityCategory.SystemSecurityCategory, 
                      dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId, dbo.SystemSecurityCategoryPage.Folder, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPage, dbo.SystemSecurityCategoryPage.SystemCategoryPageDescription, 
                      dbo.SystemSecurityCategoryMasterAccountRole.MasterRoleId, dbo.MasterAccountRole.Role, 
                      dbo.SystemSecurityCategoryPermission.SystemPermissionId, dbo.SystemSecurityCategoryPermission.SystemSecurityCategoryPermissionId, 
                      dbo.SystemSecurityCategoryPermission.TillDate, dbo.SystemSecurityCategoryPermission.TillHours, dbo.SystemPermission.SystemPermission, 
                      dbo.SystemSecurityCategoryMasterAccountRole.ShowMyData, dbo.SystemSecurityCategoryMasterAccountRole.ShowMyTeamsData, 
                      dbo.SystemSecurityCategoryMasterAccountRole.ShowMyProjectsData, dbo.SystemSecurityCategoryMasterAccountRole.ShowAllData, 
                      dbo.SystemSecurityCategoryPage.IsAllowAdd, dbo.SystemSecurityCategoryPage.IsAllowEdit, dbo.SystemSecurityCategoryPage.IsAllowDelete, 
                      dbo.SystemSecurityCategoryPage.IsAllowList
FROM         dbo.SystemSecurityCategory INNER JOIN
                      dbo.SystemSecurityCategoryPage ON 
                      dbo.SystemSecurityCategory.SystemSecurityCategoryId = dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId INNER JOIN
                      dbo.SystemSecurityCategoryMasterAccountRole ON 
                      dbo.SystemSecurityCategory.SystemSecurityCategoryId = dbo.SystemSecurityCategoryMasterAccountRole.SystemSecurityCategoryId INNER JOIN
                      dbo.MasterAccountRole ON dbo.SystemSecurityCategoryMasterAccountRole.MasterRoleId = dbo.MasterAccountRole.MasterAccountRoleId INNER JOIN
                      dbo.SystemSecurityCategoryPermission ON 
                      dbo.SystemSecurityCategory.SystemSecurityCategoryId = dbo.SystemSecurityCategoryPermission.SystemSecurityCategoryId INNER JOIN
                      dbo.SystemPermission ON dbo.SystemSecurityCategoryPermission.SystemPermissionId = dbo.SystemPermission.SystemPermissionId
WHERE     (dbo.SystemSecurityCategoryPermission.SystemPermissionId = 1) AND (ISNULL(dbo.SystemSecurityCategoryPage.IsAllowList, 0) = 1) OR
                      (dbo.SystemSecurityCategoryPermission.SystemPermissionId = 2) AND (ISNULL(dbo.SystemSecurityCategoryPage.IsAllowAdd, 0) = 1) OR
                      (dbo.SystemSecurityCategoryPermission.SystemPermissionId = 3) AND (ISNULL(dbo.SystemSecurityCategoryPage.IsAllowEdit, 0) = 1) OR
                      (dbo.SystemSecurityCategoryPermission.SystemPermissionId = 4) AND (ISNULL(dbo.SystemSecurityCategoryPage.IsAllowDelete, 0) = 1) OR
                      (dbo.SystemSecurityCategoryPage.IsCustomizeable = 0)'
GO
-- Create View vueSystemSecurityCategoryPage
Print 'Create View vueSystemSecurityCategoryPage'
GO
if not exists (select * from information_schema.tables where table_name = 'vueSystemSecurityCategoryPage' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueSystemSecurityCategoryPage
AS
SELECT     dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId, dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId, 
                      dbo.SystemSecurityCategoryPage.SequenceNumber, dbo.SystemSecurityCategoryPage.Folder, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPage, dbo.SystemSecurityCategoryPage.SystemCategoryPageDescription, 
                      dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId, dbo.SystemSecurityCategoryPage.IsSiteMapPage, 
                      dbo.SystemSecurityCategoryPage.IsCustomizeable, dbo.SystemSecurityCategoryPage.IsAllowAdd, dbo.SystemSecurityCategoryPage.IsAllowEdit, 
                      dbo.SystemSecurityCategoryPage.IsAllowDelete, dbo.SystemSecurityCategoryPage.IsAllowList, dbo.SystemSecurityCategoryPage.IsShowDataOptions, 
                      dbo.SystemSecurityCategoryPage.IsShowTillOptions, dbo.SystemSecurityCategoryPage.IsSystemPage, 
                      dbo.SystemSecurityCategory.SystemSecurityCategory
FROM         dbo.SystemSecurityCategoryPage INNER JOIN
                      dbo.SystemSecurityCategory ON 
                      dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId = dbo.SystemSecurityCategory.SystemSecurityCategoryId AND 
                      dbo.SystemSecurityCategoryPage.SystemSecurityCategoryId = dbo.SystemSecurityCategory.SystemSecurityCategoryId'
GO
-- Create View vueAccountProjectTaskUpdateEmail
Print 'Create View vueAccountProjectTaskUpdateEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskUpdateEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskUpdateEmail
AS
SELECT     dbo.vueAccountProjectTask.AccountProjectTaskId, dbo.vueAccountProjectTask.AccountProjectId, 
                      dbo.vueAccountProjectTask.ParentAccountProjectTaskId, dbo.vueAccountProjectTask.TaskName, dbo.vueAccountProjectTask.TaskDescription, 
                      dbo.vueAccountProjectTask.AccountTaskTypeId, dbo.vueAccountProjectTask.Duration, dbo.vueAccountProjectTask.DurationUnit, 
                      dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, dbo.vueAccountProjectTask.Completed, 
                      dbo.vueAccountProjectTask.IsParentTask, dbo.vueAccountProjectTask.IsForAllEmployees, dbo.vueAccountProjectTask.AccountPriorityId, 
                      dbo.vueAccountProjectTask.TaskStatusId, dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.CreatedByEmployeeId, 
                      dbo.vueAccountProjectTask.ModifiedOn, dbo.vueAccountProjectTask.ModifiedByEmployeeId, dbo.vueAccountProjectTask.TaskStatus, 
                      dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, dbo.vueAccountProjectTask.Priority, 
                      dbo.vueAccountProjectTask.ProjectName, dbo.vueAccountProjectTask.ProjectCode, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.AccountId, dbo.vueAccountProjectTask.AccountProjectMilestoneId, dbo.vueAccountProjectTask.MilestoneDescription, 
                      dbo.vueAccountProjectTask.IsReOpen, dbo.vueAccountProjectTask.ModifiedByFirstName, dbo.vueAccountProjectTask.ModifiedByLastName, 
                      dbo.vueAccountProjectTask.EstimatedCost, dbo.vueAccountProjectTask.EstimatedTimeSpent, dbo.vueAccountProjectTask.EstimatedTimeSpentUnit, 
                      dbo.vueAccountProjectTask.AccountEmployeeId, dbo.AccountEmployee.EMailAddress
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.vueAccountProjectTask ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTask.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTask.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTask.CreatedByEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 7) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 6) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 5) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueAccountProjectTaskEmployeeUpdateEmail
Print 'Create View vueAccountProjectTaskEmployeeUpdateEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskEmployeeUpdateEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskEmployeeUpdateEmail
AS
SELECT     dbo.vueAccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountProjectId, 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId, dbo.vueAccountProjectTaskEmployee.TaskName, 
                      dbo.vueAccountProjectTaskEmployee.FirstName, dbo.vueAccountProjectTaskEmployee.LastName, 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId, dbo.vueAccountProjectTaskEmployee.AccountId, 
                      dbo.vueAccountProjectTaskEmployee.ProjectCode, dbo.vueAccountProjectTaskEmployee.TaskStatusId, 
                      dbo.vueAccountProjectTaskEmployee.Completed, dbo.AccountProject.ProjectName, dbo.AccountEmployee.EMailAddress, 
                      dbo.vueAccountProjectTask.TaskDescription, dbo.vueAccountProjectTask.TaskStatus, dbo.vueAccountProjectTask.TaskType, 
                      dbo.vueAccountProjectTask.Priority, dbo.vueAccountProjectTask.CreatedByFirstName, dbo.vueAccountProjectTask.CreatedByLastName, 
                      dbo.vueAccountProjectTask.CreatedOn, dbo.vueAccountProjectTask.MilestoneDescription, dbo.vueAccountProjectTask.Duration, 
                      dbo.vueAccountProjectTask.DurationUnit, dbo.vueAccountProjectTask.DeadlineDate, dbo.vueAccountProjectTask.CompletedPercent, 
                      dbo.vueAccountProjectTask.IsReOpen, dbo.vueAccountProjectTask.ModifiedByFirstName, dbo.vueAccountProjectTask.ModifiedByLastName
FROM         dbo.AccountProject RIGHT OUTER JOIN
                      dbo.vueAccountProjectTaskEmployee LEFT OUTER JOIN
                      dbo.vueAccountProjectTask ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectTaskId = dbo.vueAccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.vueAccountProjectTaskEmployee.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountProjectTaskEmployee.AccountId = dbo.AccountEMailNotificationPreference.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountProjectTaskEmployee.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 7) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 6) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 5) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueAccountStatus
Print 'Create View vueAccountStatus'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountStatus' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountStatus
AS
SELECT     dbo.AccountStatus.AccountStatusId, dbo.AccountStatus.AccountId, dbo.AccountStatus.StatusTypeId, dbo.AccountStatus.Status, 
                      dbo.SystemStatusType.SystemStatusType, dbo.AccountStatus.IsDisabled
FROM         dbo.AccountStatus LEFT OUTER JOIN
                      dbo.SystemStatusType ON dbo.AccountStatus.StatusTypeId = dbo.SystemStatusType.SystemStatusTypeId'
GO
-- Create View vueAccountEmployee
Print 'Create View vueAccountEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployee
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.AccountId, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.Password, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.BillingTypeId, dbo.AccountBillingType.BillingType, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountPreferences.ShowClockStartEnd, 
                      dbo.Account.TimeZoneId, dbo.AccountRole.MasterAccountRoleId, dbo.Account.DefaultCurrencyId, dbo.Account.CountryId, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.TimeEntryFormat, dbo.AccountEmployee.AllowedAccessFromIP, 
                      dbo.AccountRole.AccountRoleId, dbo.AccountPreferences.AccountSessionTimeout, dbo.AccountPreferences.ShowCompletedTasksInTimeSheet, 
                      dbo.AccountPreferences.CurrencySymbol, dbo.AccountPreferences.IsCompanyOwnLogo, dbo.Account.AccountExpiryActivation, 
                      dbo.Account.LicenseActivation, dbo.AccountEmployee.EmployeeTypeId, dbo.AccountEmployee.ExternalUserClientId, 
                      dbo.AccountEmployee.AccountBillingRateId, dbo.AccountPreferences.ScheduledEmailSendTime, 
                      dbo.AccountPreferences.LastScheduledEmailSentTime, dbo.AccountEmployee.Username, dbo.AccountEmployee.IsDisabled, 
                      dbo.AccountPreferences.FromEmailAddress, dbo.AccountPreferences.FromEmailAddressDisplayName
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId'
GO
-- Create View vueAccount
Print 'Create View vueAccount'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccount' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccount
AS
SELECT     dbo.Account.AccountId, dbo.Account.AccountTypeId, dbo.Account.AccountName, dbo.Account.Address1, dbo.Account.Address2, dbo.Account.ZipCode, 
                      dbo.Account.State, dbo.Account.City, dbo.Account.CountryId, dbo.Account.EMailAddress, dbo.Account.Telephone, dbo.Account.Fax, 
                      dbo.Account.DefaultCurrencyId, dbo.Account.TimeZoneId, dbo.Account.IsDisabled, dbo.Account.IsDeleted, dbo.Account.StatusId, 
                      dbo.Account.CreatedOn, dbo.Account.ModifiedOn, dbo.Account.ModifiedByEmployeeId, dbo.AccountPreferences.ShowClockStartEnd, 
                      dbo.AccountPreferences.AccountPreferencesId, dbo.Account.LicenseKey, dbo.Account.SystemPackageTypeId, 
                      dbo.AccountPreferences.TimeEntryFormat, dbo.AccountPreferences.FromEmailAddress, dbo.AccountPreferences.FromEmailAddressDisplayName
FROM         dbo.Account INNER JOIN
                      dbo.AccountPreferences ON dbo.Account.AccountId = dbo.AccountPreferences.AccountId'
GO
-- Create View vueAccountBillingType
Print 'Create View vueAccountBillingType'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountBillingType' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountBillingType
AS
SELECT     dbo.AccountBillingType.AccountBillingTypeId, dbo.AccountBillingType.AccountId, dbo.AccountBillingType.BillingType, 
                      dbo.SystemBillingCategory.SystemBillingCategory, dbo.AccountBillingType.MasterAccountBillingTypeId, dbo.AccountBillingType.IsDisabled
FROM         dbo.AccountBillingType LEFT OUTER JOIN
                      dbo.SystemBillingCategory ON dbo.AccountBillingType.BillingCategoryId = dbo.SystemBillingCategory.SystemBillingCategoryId'
GO
-- Create View vueAccountPagePermission
Print 'Create View vueAccountPagePermission'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountPagePermission' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountPagePermission
AS
SELECT     dbo.AccountPagePermission.AccountPagePermissionId, dbo.AccountPagePermission.AccountId, dbo.AccountPagePermission.AccountRoleId, 
                      dbo.AccountPagePermission.SystemSecurityCategoryPageId, dbo.AccountPagePermission.ShowAllData, dbo.AccountPagePermission.ShowMyData, 
                      dbo.AccountPagePermission.ShowMyProjectsData, dbo.AccountPagePermission.ShowMyTeamsData, dbo.AccountPagePermission.TillDate, 
                      dbo.AccountPagePermission.TillHours, dbo.SystemSecurityCategoryPage.Folder, dbo.SystemSecurityCategoryPage.SystemCategoryPage, 
                      dbo.SystemSecurityCategoryPage.SystemCategoryPageDescription, dbo.SystemSecurityCategoryPage.IsSiteMapPage, 
                      dbo.SystemPermission.SystemPermission, dbo.AccountRole.Role, dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId, 
                      SystemSecurityCategoryPage_1.SystemCategoryPage AS ParentSystemCategoryPage, 
                      SystemSecurityCategoryPage_1.SystemCategoryPageDescription AS ParentSystemCategoryPageDescription, 
                      SystemSecurityCategoryPage_1.IsSiteMapPage AS ParentIsSiteMapPage, SystemSecurityCategoryPage_1.Folder AS ParentFolder, 
                      dbo.SystemSecurityCategoryPage.SequenceNumber, dbo.AccountPagePermission.SystemPermissionId, 
                      dbo.SystemSecurityCategoryPage.ControlLevelPermission
FROM         dbo.AccountPagePermission INNER JOIN
                      dbo.SystemSecurityCategoryPage ON 
                      dbo.AccountPagePermission.SystemSecurityCategoryPageId = dbo.SystemSecurityCategoryPage.SystemSecurityCategoryPageId INNER JOIN
                      dbo.AccountRole ON dbo.AccountPagePermission.AccountRoleId = dbo.AccountRole.AccountRoleId INNER JOIN
                      dbo.SystemPermission ON dbo.AccountPagePermission.SystemPermissionId = dbo.SystemPermission.SystemPermissionId LEFT OUTER JOIN
                      dbo.SystemSecurityCategoryPage AS SystemSecurityCategoryPage_1 ON 
                      dbo.SystemSecurityCategoryPage.ParentSystemSecurityCateogoryPageId = SystemSecurityCategoryPage_1.SystemSecurityCategoryPageId'
GO

-- Drop View vueAccountExpenseEntryApproval
Print 'Drop View vueAccountExpenseEntryApproval'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApproval' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntryApproval]
GO

-- Drop View vueAccountExpenseEntryApprovalPending
Print 'Drop View vueAccountExpenseEntryApprovalPending'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntryApprovalPending]
GO

-- Create View vueAccountExpenseEntryApproval
Print 'Create View vueAccountExpenseEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountExpenseEntry.AccountExpenseEntryId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, dbo.AccountExpenseEntry.Amount, 
                      dbo.AccountExpense.AccountExpenseName, dbo.AccountExpense.IsBillable, 
                      dbo.AccountExpenseEntry.AccountEmployeeId AS ExpenseEntryAccountEmployeeId, dbo.AccountExpenseEntry.Description
FROM         dbo.AccountExpense RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountExpenseEntry.AccountEmployeeId ON 
                      dbo.AccountExpense.AccountExpenseId = dbo.AccountExpenseEntry.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId'
GO

-- Create View vueAccountExpenseEntryApprovalPending
Print 'Create View vueAccountExpenseEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryApprovalPending
AS
SELECT     dbo.vueAccountExpenseEntryApproval.AccountProjectId, dbo.vueAccountExpenseEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId, dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountExpenseEntryApproval.SystemApproverTypeId, dbo.vueAccountExpenseEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApproval.AccountEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId, dbo.vueAccountExpenseEntryApproval.ExpenseApprovalId, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.vueAccountExpenseEntryApproval.ProjectName, 
                      dbo.vueAccountExpenseEntryApproval.ProjectDescription, dbo.vueAccountExpenseEntryApproval.ProjectCode, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeName, dbo.vueAccountExpenseEntryApproval.Approved, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntryApproval.Comments, dbo.vueAccountExpenseEntryApproval.IsRejected, 
                      dbo.vueAccountExpenseEntryApproval.IsApproved, dbo.vueAccountExpenseEntryApproval.Amount, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseName, dbo.vueAccountExpenseEntryApproval.IsBillable, 
                      dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueAccountExpenseEntryApproval.ExpenseEntryAccountEmployeeId
FROM         dbo.vueAccountExpenseEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId IN
                          (SELECT     TOP 1 AccountApprovalPathId
                            FROM          dbo.vueExpenseApprovalSequence AS vueExpenseApprovalSequence_1
                            WHERE      (ExpenseApprovalId IS NULL) AND (AccountExpenseEntryId = dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId)))'
GO
-- Create View vueAccountEmployeeTimeEntryRejectedEmail
Print 'Create View vueAccountEmployeeTimeEntryRejectedEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryRejectedEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryRejectedEmail
AS
SELECT     dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.vueAccountEmployeeTimeEntry.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntry.TaskName, dbo.vueAccountEmployeeTimeEntry.TotalTime, dbo.vueAccountEmployeeTimeEntry.Approved, 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntry.TeamLeadApproved, dbo.vueAccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.vueAccountEmployeeTimeEntry.AdministratorApproved, dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntry.StartTime, dbo.vueAccountEmployeeTimeEntry.EndTime, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntry.Description, dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.vueAccountEmployeeTimeEntry.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntry.WeekDay, dbo.vueAccountEmployeeTimeEntry.AccountPartyId, dbo.vueAccountEmployeeTimeEntry.PartyName, 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectTaskId, dbo.vueAccountEmployeeTimeEntry.BillingType, 
                      dbo.vueAccountEmployeeTimeEntry.LeaderEmployeeId, dbo.vueAccountEmployeeTimeEntry.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntry.TimeSheetApprovalTypeId, dbo.vueAccountEmployeeTimeEntry.ExpenseApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntry.IsBillable, dbo.vueAccountEmployeeTimeEntry.Rejected, dbo.vueAccountEmployeeTimeEntry.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntry.ProjectBillingRateTypeId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments
FROM         dbo.vueAccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId LEFT OUTER
                       JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectId = dbo.AccountEMailNotificationPreference.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountId = AccountEMailNotificationPreference_2.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 19) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 17) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 18) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueAccountEmployeeTimeEntryApprovedEmail
Print 'Create View vueAccountEmployeeTimeEntryApprovedEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovedEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovedEmail
AS
SELECT     dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.vueAccountEmployeeTimeEntry.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntry.TaskName, dbo.vueAccountEmployeeTimeEntry.TotalTime, dbo.vueAccountEmployeeTimeEntry.Approved, 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.AccountProjectId, 
                      dbo.vueAccountEmployeeTimeEntry.TeamLeadApproved, dbo.vueAccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.vueAccountEmployeeTimeEntry.AdministratorApproved, dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.vueAccountEmployeeTimeEntry.StartTime, dbo.vueAccountEmployeeTimeEntry.EndTime, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntry.Description, dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.vueAccountEmployeeTimeEntry.TotalMinutes, 
                      dbo.vueAccountEmployeeTimeEntry.WeekDay, dbo.vueAccountEmployeeTimeEntry.AccountPartyId, dbo.vueAccountEmployeeTimeEntry.PartyName, 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectTaskId, dbo.vueAccountEmployeeTimeEntry.BillingType, 
                      dbo.vueAccountEmployeeTimeEntry.LeaderEmployeeId, dbo.vueAccountEmployeeTimeEntry.ProjectManagerEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntry.TimeSheetApprovalTypeId, dbo.vueAccountEmployeeTimeEntry.ExpenseApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntry.IsBillable, dbo.vueAccountEmployeeTimeEntry.Rejected, dbo.vueAccountEmployeeTimeEntry.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntry.ProjectBillingRateTypeId, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments
FROM         dbo.vueAccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId LEFT OUTER
                       JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountProjectId = dbo.AccountEMailNotificationPreference.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountEmployeeTimeEntry.AccountId = AccountEMailNotificationPreference_2.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 16) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 14) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 15) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueAccountExpense
Print 'Create View vueAccountExpense'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpense' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpense
AS
SELECT     dbo.AccountExpense.AccountExpenseId, dbo.AccountExpense.AccountExpenseName, dbo.AccountExpense.AccountExpenseTypeId, 
                      dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountId, dbo.AccountExpense.CreatedOn, dbo.AccountExpense.CreatedByEmployeeId, 
                      dbo.AccountExpense.ModifiedOn, dbo.AccountExpense.ModifiedByEmployeeId, dbo.AccountExpense.IsBillable, dbo.AccountExpense.IsDisabled
FROM         dbo.AccountExpense LEFT OUTER JOIN
                      dbo.AccountExpenseType ON dbo.AccountExpense.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId'
GO
-- Drop View vueAccountEmployee
Print 'Drop View vueAccountEmployee'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountEmployee]
GO
-- Add Column EmployeeCode to AccountEmployee
Print 'Add Column EmployeeCode to AccountEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='EmployeeCode' AND TABLE_NAME='AccountEmployee'))
ALTER TABLE [dbo].[AccountEmployee]
	ADD [EmployeeCode] varchar(50) NULL

GO
-- Create View vueAccountEmployee
Print 'Create View vueAccountEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployee
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.AccountId, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.Password, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountLocationId, dbo.AccountEmployee.BillingTypeId, 
                      dbo.AccountBillingType.BillingType, dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, 
                      dbo.AccountPreferences.ShowClockStartEnd, dbo.Account.TimeZoneId, dbo.AccountRole.MasterAccountRoleId, dbo.Account.DefaultCurrencyId, dbo.Account.CountryId, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.TimeEntryFormat, dbo.AccountEmployee.AllowedAccessFromIP, dbo.AccountRole.AccountRoleId, 
                      dbo.AccountPreferences.AccountSessionTimeout, dbo.AccountPreferences.ShowCompletedTasksInTimeSheet, dbo.AccountPreferences.CurrencySymbol, 
                      dbo.AccountPreferences.IsCompanyOwnLogo, dbo.Account.AccountExpiryActivation, dbo.Account.LicenseActivation, dbo.AccountEmployee.EmployeeTypeId, 
                      dbo.AccountEmployee.ExternalUserClientId, dbo.AccountEmployee.AccountBillingRateId, dbo.AccountPreferences.ScheduledEmailSendTime, 
                      dbo.AccountPreferences.LastScheduledEmailSentTime, dbo.AccountEmployee.Username, dbo.AccountEmployee.IsDisabled, 
                      dbo.AccountPreferences.FromEmailAddress, dbo.AccountPreferences.FromEmailAddressDisplayName, dbo.AccountEmployee.EmployeeCode, 
                      dbo.AccountPreferences.Version
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId'


GO
-- Drop View vueAccountExpenseEntryApprovalPending
Print 'Drop View vueAccountExpenseEntryApprovalPending'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntryApprovalPending]
GO
-- Drop View vueAccountExpenseEntryApproval
Print 'Drop View vueAccountExpenseEntryApproval'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApproval' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountExpenseEntryApproval]
GO
-- Drop View vueAccountEmployeeTimeEntryApprovalPending
Print 'Drop View vueAccountEmployeeTimeEntryApprovalPending'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPending' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovalPending]
GO
-- Drop View vueAccountEmployeeTimeEntryApproval
Print 'Drop View vueAccountEmployeeTimeEntryApproval'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApproval' and table_type = 'VIEW') 

DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApproval]
GO
-- Create View vueAccountEmployeeTimeEntryApproval
Print 'Create View vueAccountEmployeeTimeEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.TaskDescription, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments, dbo.AccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.AccountEmployeeTimeEntryApproval.IsApproved, dbo.AccountEmployeeTimeEntry.AccountEmployeeId AS TimeEntryAccountEmployeeId, 
                      dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.AccountId, dbo.AccountEmployeeTimeEntry.Description
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountProjectTask INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId'
GO
-- Create View vueAccountEmployeeTimeEntryApprovalPending
Print 'Create View vueAccountEmployeeTimeEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPending
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectId, dbo.vueAccountEmployeeTimeEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.SystemApproverTypeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectDescription, dbo.vueAccountEmployeeTimeEntryApproval.ProjectCode, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskName, dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskDescription, dbo.vueAccountEmployeeTimeEntryApproval.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Approved, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TotalTime, dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Comments, dbo.vueAccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApproval.IsApproved, dbo.vueAccountApproverType.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryAccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.EMailAddress, dbo.vueAccountEmployeeTimeEntryApproval.Description
FROM         dbo.vueAccountEmployeeTimeEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId IN
                          (SELECT      TOP 1 AccountApprovalPathId
                            FROM          dbo.vueTimesheetApprovalSequence
                            WHERE      (TimeSheetApprovalId IS NULL) AND 
                                                   (AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId)))'
GO
-- Create View vueAccountExpenseEntryApproval
Print 'Create View vueAccountExpenseEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountExpenseEntry.AccountExpenseEntryId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, dbo.AccountExpenseEntry.Amount, 
                      dbo.AccountExpense.AccountExpenseName, dbo.AccountExpense.IsBillable, 
                      dbo.AccountExpenseEntry.AccountEmployeeId AS ExpenseEntryAccountEmployeeId, dbo.AccountExpenseEntry.Description
FROM         dbo.AccountExpense RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountExpenseEntry.AccountEmployeeId ON 
                      dbo.AccountExpense.AccountExpenseId = dbo.AccountExpenseEntry.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId'
GO
-- Create View vueAccountExpenseEntryApprovalPending
Print 'Create View vueAccountExpenseEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryApprovalPending
AS
SELECT     dbo.vueAccountExpenseEntryApproval.AccountProjectId, dbo.vueAccountExpenseEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId, dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountExpenseEntryApproval.SystemApproverTypeId, dbo.vueAccountExpenseEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApproval.AccountEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId, dbo.vueAccountExpenseEntryApproval.ExpenseApprovalId, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.vueAccountExpenseEntryApproval.ProjectName, 
                      dbo.vueAccountExpenseEntryApproval.ProjectDescription, dbo.vueAccountExpenseEntryApproval.ProjectCode, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeName, dbo.vueAccountExpenseEntryApproval.Approved, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntryApproval.Comments, dbo.vueAccountExpenseEntryApproval.IsRejected, 
                      dbo.vueAccountExpenseEntryApproval.IsApproved, dbo.vueAccountExpenseEntryApproval.Amount, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseName, dbo.vueAccountExpenseEntryApproval.IsBillable, 
                      dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueAccountExpenseEntryApproval.ExpenseEntryAccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.Description
FROM         dbo.vueAccountExpenseEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId IN
                          (SELECT      TOP 1 AccountApprovalPathId
                            FROM          dbo.vueExpenseApprovalSequence AS vueExpenseApprovalSequence_1
                            WHERE      (ExpenseApprovalId IS NULL) AND (AccountExpenseEntryId = dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId)))'
GO

-- Drop View vueAccountEmployeeTimeEntryApprovalLastAction
Print 'Drop View vueAccountEmployeeTimeEntryApprovalLastAction'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalLastAction' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovalLastAction]
GO

-- Drop View vueAccountEmployeeTimeEntryWithLastStatus
Print 'Drop View vueAccountEmployeeTimeEntryWithLastStatus'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithLastStatus' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryWithLastStatus]
GO

-- Create View vueAccountEmployeeTimeEntryApprovalLastAction
Print 'Create View vueAccountEmployeeTimeEntryApprovalLastAction'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalLastAction' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalLastAction
AS
SELECT     TimeSheetApprovalId, AccountEmployeeTimeEntryId, IsReject, IsApproved, Comments, ApprovedOn, ApprovedByEmployeeId, 
                      TimeSheetApprovalTypeId, TimeSheetApprovalPathId
FROM         dbo.AccountEmployeeTimeEntryApproval AS parent
WHERE     (TimeSheetApprovalId =
                          (SELECT     MAX(TimeSheetApprovalId) AS Expr1
                            FROM          dbo.AccountEmployeeTimeEntryApproval
                            WHERE      (AccountEmployeeTimeEntryId = parent.AccountEmployeeTimeEntryId)))'
GO
-- Create View vueAccountEmployeeTimeEntryWithLastStatus
Print 'Create View vueAccountEmployeeTimeEntryWithLastStatus'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithLastStatus' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithLastStatus
AS
SELECT     dbo.AccountEmployeeTimeEntry.*, dbo.vueAccountEmployeeTimeEntryApprovalLastAction.IsApproved, 
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction.IsReject
FROM         dbo.AccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApprovalLastAction.AccountEmployeeTimeEntryId'
GO

-- Create View vueAccountExpenseEntryWithLastAction
Print 'Create View vueAccountExpenseEntryWithLastAction'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryWithLastAction' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryWithLastAction
AS
SELECT     AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, AccountApprovalTypeId, 
                      SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, AccountExpenseEntryId, ExpenseApprovalId, 
                      ExpenseApprovalPathId, ProjectName, ProjectDescription, ProjectCode, EmployeeName, Approved, ExpenseApprovalTypeId, 
                      AccountExpenseEntryDate, Comments, IsRejected, IsApproved, Amount, AccountExpenseName, IsBillable, ExpenseEntryAccountEmployeeId, 
                      Description
FROM         dbo.vueAccountExpenseEntryApproval AS parent
WHERE     (ExpenseApprovalId =
                          (SELECT     MAX(ExpenseApprovalId) AS Expr1
                            FROM          dbo.AccountExpenseEntryApproval
                            WHERE      (AccountExpenseEntryId = parent.AccountExpenseEntryId)))'
GO

-- Drop View vueAccountAttendance
Print 'Drop View vueAccountAttendance'
GO
DROP VIEW [dbo].[vueAccountAttendance]
GO

-- Drop View vueAccountEmployeeTimeEntry
Print 'Drop View vueAccountEmployeeTimeEntry'
GO
DROP VIEW [dbo].[vueAccountEmployeeTimeEntry]
GO

-- Drop View vueAccountExpenseEntry
Print 'Drop View vueAccountExpenseEntry'
GO
DROP VIEW [dbo].[vueAccountExpenseEntry]
GO

-- Create View vueAccountExpenseEntry
Print 'Create View vueAccountExpenseEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpense.AccountExpenseName, 
                      dbo.AccountProject.ProjectName, dbo.AccountExpenseEntry.AccountExpenseEntryId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountProjectId, 
                      dbo.AccountExpenseEntry.AccountExpenseId, dbo.AccountExpenseEntry.Amount, dbo.AccountExpenseEntry.TeamLeadApproved, 
                      dbo.AccountExpenseEntry.ProjectManagerApproved, dbo.AccountExpenseEntry.AdministratorApproved, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountExpenseEntry.CreatedOn, dbo.AccountExpenseEntry.CreatedByEmployeeId, dbo.AccountExpenseEntry.ModifiedOn, 
                      dbo.AccountExpenseEntry.ModifiedByEmployeeId, dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, 
                      dbo.AccountExpenseEntry.Description, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountExpenseTypeId, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountEmployee.EmployeeCode
FROM         dbo.AccountExpenseType RIGHT OUTER JOIN
                      dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId ON 
                      dbo.AccountExpenseType.AccountExpenseTypeId = dbo.AccountExpense.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId'
GO

-- Create View vueAccountEmployeeTimeEntry
Print 'Create View vueAccountEmployeeTimeEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountProject.ProjectName, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProject.AccountProjectId, dbo.AccountEmployeeTimeEntry.TeamLeadApproved, 
                      dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, dbo.AccountEmployeeTimeEntry.AdministratorApproved, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.Description, dbo.AccountProject.AccountId, DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, DATEPART(dw, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS WeekDay, dbo.AccountParty.AccountPartyId, dbo.AccountParty.PartyName, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountBillingType.BillingType, dbo.AccountProject.LeaderEmployeeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, 
                      dbo.AccountProjectTask.IsBillable, dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, 
                      dbo.AccountProject.ProjectBillingRateTypeId, dbo.AccountEmployee.EmployeeCode
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId'
GO

-- Create View vueAccountAttendance
Print 'Create View vueAccountAttendance'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountAttendance' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountAttendance
AS
SELECT     dbo.AccountAbsenceType.AbsenceDescription, dbo.AccountAbsenceType.AccountAbsenceTypeId, dbo.AccountEmployeeAttendance.AttendanceDate, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, 
                      dbo.Account.AccountId, dbo.AccountEmployeeAttendance.InOut, dbo.AccountEmployeeAttendance.AttendanceTime, 
                      dbo.AccountEmployee.EmployeeCode
FROM         dbo.AccountAbsenceType RIGHT OUTER JOIN
                      dbo.AccountEmployeeAttendance LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeAttendance.AccountId = dbo.AccountEmployee.AccountId AND 
                      dbo.AccountEmployeeAttendance.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.Account ON dbo.AccountEmployeeAttendance.AccountId = dbo.Account.AccountId ON 
                      dbo.AccountAbsenceType.AccountId = dbo.AccountEmployeeAttendance.AccountId AND 
                      dbo.AccountAbsenceType.AccountAbsenceTypeId = dbo.AccountEmployeeAttendance.AccountAbsenceTypeId'

GO

-- Create View vueAccountExpenseEntryWithLastStatus
Print 'Create View vueAccountExpenseEntryWithLastStatus'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryWithLastStatus' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryWithLastStatus
AS
SELECT     dbo.vueAccountExpenseEntryWithLastAction.IsRejected, dbo.vueAccountExpenseEntryWithLastAction.IsApproved, 
                      dbo.vueAccountExpenseEntry.*
FROM         dbo.vueAccountExpenseEntryWithLastAction RIGHT OUTER JOIN
                      dbo.vueAccountExpenseEntry ON 
                      dbo.vueAccountExpenseEntryWithLastAction.AccountExpenseEntryId = dbo.vueAccountExpenseEntry.AccountExpenseEntryId'
GO

-- Create Foreign Key FK_AccountEmployee_AccountBillingType on AccountEmployee
Print 'Create Foreign Key FK_AccountEmployee_AccountBillingType on AccountEmployee'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployee_AccountBillingType' AND TABLE_NAME='AccountEmployee')
BEGIN
		ALTER TABLE [dbo].[AccountEmployee]
			ADD CONSTRAINT [FK_AccountEmployee_AccountBillingType]
			FOREIGN KEY ([BillingTypeId]) REFERENCES [dbo].[AccountBillingType] ([AccountBillingTypeId])
END

GO
-- Create Foreign Key FK_AccountProject_AccountBillingType on AccountProject
Print 'Create Foreign Key FK_AccountProject_AccountBillingType on AccountProject'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountBillingType' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountProject]
			ADD CONSTRAINT [FK_AccountProject_AccountBillingType]
			FOREIGN KEY ([ProjectBillingTypeId]) REFERENCES [dbo].[AccountBillingType] ([AccountBillingTypeId])
END
GO
-- Create Foreign Key FK_AccountEmployeeTimeEntry_AccountProjectTask on AccountEmployeeTimeEntry
Print 'Create Foreign Key FK_AccountEmployeeTimeEntry_AccountProjectTask on AccountEmployeeTimeEntry'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployeeTimeEntry_AccountProjectTask' AND TABLE_NAME='AccountEmployeeTimeEntry')
BEGIN
		ALTER TABLE [dbo].[AccountEmployeeTimeEntry]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountProjectTask]
			FOREIGN KEY ([AccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId])
		ALTER TABLE [dbo].[AccountEmployeeTimeEntry]
			CHECK CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountProjectTask]

END
GO

-- Drop Foreign Key FK_AccountEmployeeTimeEntry_AccountProject from AccountEmployeeTimeEntry
Print 'Drop Foreign Key FK_AccountEmployeeTimeEntry_AccountProject from AccountEmployeeTimeEntry'
GO
IF  EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployeeTimeEntry_AccountProject' AND TABLE_NAME='AccountEmployeeTimeEntry')
ALTER TABLE [dbo].[AccountEmployeeTimeEntry] DROP CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountProject]
GO

-- Create Foreign Key FK_AccountEmployeeTimeEntry_AccountProject on AccountEmployeeTimeEntry
Print 'Create Foreign Key FK_AccountEmployeeTimeEntry_AccountProject on AccountEmployeeTimeEntry'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployeeTimeEntry_AccountProject' AND TABLE_NAME='AccountEmployeeTimeEntry')
BEGIN
		ALTER TABLE [dbo].[AccountEmployeeTimeEntry]
			ADD CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountProject]
			FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId])
		ALTER TABLE [dbo].[AccountEmployeeTimeEntry]
			CHECK CONSTRAINT [FK_AccountEmployeeTimeEntry_AccountProject]

END

GO
-- Create Foreign Key FK_AccountProjectTask_AccountProject on AccountProjectTask
Print 'Create Foreign Key FK_AccountProjectTask_AccountProject on AccountProjectTask'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProjectTask_AccountProject' AND TABLE_NAME='AccountProjectTask')
BEGIN
		ALTER TABLE [dbo].[AccountProjectTask]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProjectTask_AccountProject]
			FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId])
		ALTER TABLE [dbo].[AccountProjectTask]
			CHECK CONSTRAINT [FK_AccountProjectTask_AccountProject]

END

GO
-- Drop Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId from AccountEmployeeAttendance
Print 'Drop Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId from AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance] DROP CONSTRAINT [DF_AccountEmployeeAttendance_CreatedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId from AccountEmployeeAttendance
Print 'Drop Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId from AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance] DROP CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountDepartment_IsDeleted from AccountDepartment
Print 'Drop Default Constraint DF_AccountDepartment_IsDeleted from AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDeleted'))
ALTER TABLE [dbo].[AccountDepartment] DROP CONSTRAINT [DF_AccountDepartment_IsDeleted]
GO

-- Drop Default Constraint DF_AccountDepartment_IsDisabled from AccountDepartment
Print 'Drop Default Constraint DF_AccountDepartment_IsDisabled from AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDisabled'))
ALTER TABLE [dbo].[AccountDepartment] DROP CONSTRAINT [DF_AccountDepartment_IsDisabled]
GO

-- Drop Default Constraint DF_AccountLocation_CreatedByEmployeeId from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_CreatedByEmployeeId from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_CreatedByEmployeeId]
GO

-- Drop Default Constraint DF_AccountLocation_IsDisabled from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_IsDisabled from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_IsDisabled'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_IsDisabled]
GO

-- Drop Default Constraint DF_AccountLocation_ModifiedByEmployeeId from AccountLocation
Print 'Drop Default Constraint DF_AccountLocation_ModifiedByEmployeeId from AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation] DROP CONSTRAINT [DF_AccountLocation_ModifiedByEmployeeId]
GO

-- Drop Index IX_AccountRole from AccountRole
Print 'Drop Index IX_AccountRole from AccountRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountRole' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID (N'[dbo].[AccountRole]') AND name = N'IX_AccountRole'))
DROP INDEX [dbo].[AccountRole].[IX_AccountRole]
GO

-- Add Default Constraint DF_AccountLocation_CreatedByEmployeeId to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_CreatedByEmployeeId to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_CreatedByEmployeeId]
	DEFAULT (0) FOR [CreatedByEmployeeId]
GO

-- Add Default Constraint DF_AccountLocation_IsDisabled to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_IsDisabled to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_IsDisabled'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO

-- Add Default Constraint DF_AccountLocation_ModifiedByEmployeeId to AccountLocation
Print 'Add Default Constraint DF_AccountLocation_ModifiedByEmployeeId to AccountLocation'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountLocation' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountLocation_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountLocation]
	ADD
	CONSTRAINT [DF_AccountLocation_ModifiedByEmployeeId]
	DEFAULT (0) FOR [ModifiedByEmployeeId]
GO

-- Add Default Constraint DF_AccountDepartment_IsDeleted to AccountDepartment
Print 'Add Default Constraint DF_AccountDepartment_IsDeleted to AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDeleted'))
ALTER TABLE [dbo].[AccountDepartment]
	ADD
	CONSTRAINT [DF_AccountDepartment_IsDeleted]
	DEFAULT (0) FOR [IsDeleted]
GO

-- Add Default Constraint DF_AccountDepartment_IsDisabled to AccountDepartment
Print 'Add Default Constraint DF_AccountDepartment_IsDisabled to AccountDepartment'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountDepartment' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountDepartment_IsDisabled'))
ALTER TABLE [dbo].[AccountDepartment]
	ADD
	CONSTRAINT [DF_AccountDepartment_IsDisabled]
	DEFAULT (0) FOR [IsDisabled]
GO

-- Add Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId to AccountEmployeeAttendance
Print 'Add Default Constraint DF_AccountEmployeeAttendance_CreatedByEmployeeId to AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_CreatedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance]
	ADD
	CONSTRAINT [DF_AccountEmployeeAttendance_CreatedByEmployeeId]
	DEFAULT (0) FOR [CreatedByEmployeeId]
GO

-- Add Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId to AccountEmployeeAttendance
Print 'Add Default Constraint DF_AccountEmployeeAttendance_ModifiedByEmployeeId to AccountEmployeeAttendance'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeAttendance' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountEmployeeAttendance_ModifiedByEmployeeId'))
ALTER TABLE [dbo].[AccountEmployeeAttendance]
	ADD
	CONSTRAINT [DF_AccountEmployeeAttendance_ModifiedByEmployeeId]
	DEFAULT (0) FOR [ModifiedByEmployeeId]
GO

-- Create Foreign Key FK_AccountEmployee_AccountDepartment on AccountEmployee
Print 'Create Foreign Key FK_AccountEmployee_AccountDepartment on AccountEmployee'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployee_AccountDepartment' AND TABLE_NAME='AccountEmployee')
BEGIN
		ALTER TABLE [dbo].[AccountEmployee]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountEmployee_AccountDepartment]
			FOREIGN KEY ([AccountDepartmentId]) REFERENCES [dbo].[AccountDepartment] ([AccountDepartmentId])
		ALTER TABLE [dbo].[AccountEmployee]
			CHECK CONSTRAINT [FK_AccountEmployee_AccountDepartment]

END
GO

-- Create Foreign Key FK_AccountEmployee_AccountLocation on AccountEmployee
Print 'Create Foreign Key FK_AccountEmployee_AccountLocation on AccountEmployee'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployee_AccountLocation' AND TABLE_NAME='AccountEmployee')
BEGIN
		ALTER TABLE [dbo].[AccountEmployee]
			WITH NOCHECK			
			ADD CONSTRAINT [FK_AccountEmployee_AccountLocation]
			FOREIGN KEY ([AccountLocationId]) REFERENCES [dbo].[AccountLocation] ([AccountLocationId])
		ALTER TABLE [dbo].[AccountEmployee]
			CHECK CONSTRAINT [FK_AccountEmployee_AccountLocation]

END
GO

-- Create Foreign Key FK_AccountExpense_AccountExpenseType on AccountExpense
Print 'Create Foreign Key FK_AccountExpense_AccountExpenseType on AccountExpense'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpense_AccountExpenseType' AND TABLE_NAME='AccountExpense')
BEGIN
		ALTER TABLE [dbo].[AccountExpense]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountExpense_AccountExpenseType]
			FOREIGN KEY ([AccountExpenseTypeId]) REFERENCES [dbo].[AccountExpenseType] ([AccountExpenseTypeId])
		ALTER TABLE [dbo].[AccountExpense]
			CHECK CONSTRAINT [FK_AccountExpense_AccountExpenseType]

END
GO

-- Create Foreign Key FK_AccountProject_AccountParty on AccountProject
Print 'Create Foreign Key FK_AccountProject_AccountParty on AccountProject'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountParty' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountProject]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProject_AccountParty]
			FOREIGN KEY ([AccountClientId]) REFERENCES [dbo].[AccountParty] ([AccountPartyId])
		ALTER TABLE [dbo].[AccountProject]
			CHECK CONSTRAINT [FK_AccountProject_AccountParty]

END

GO

-- Create Foreign Key FK_AccountProject_AccountPriority on AccountProject
Print 'Create Foreign Key FK_AccountProject_AccountPriority on AccountProject'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountPriority' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountProject]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProject_AccountPriority]
			FOREIGN KEY ([AccountPriorityId]) REFERENCES [dbo].[AccountPriority] ([AccountPriorityId])
		ALTER TABLE [dbo].[AccountProject]
			CHECK CONSTRAINT [FK_AccountProject_AccountPriority]

END
GO

-- Create Foreign Key FK_AccountProject_AccountProjectType on AccountProject
Print 'Create Foreign Key FK_AccountProject_AccountProjectType on AccountProject'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountProjectType' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountProject]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProject_AccountProjectType]
			FOREIGN KEY ([AccountProjectTypeId]) REFERENCES [dbo].[AccountProjectType] ([AccountProjectTypeId])
		ALTER TABLE [dbo].[AccountProject]
			CHECK CONSTRAINT [FK_AccountProject_AccountProjectType]

END
GO

-- Create Foreign Key FK_AccountProject_AccountStatus on AccountProject
Print 'Create Foreign Key FK_AccountProject_AccountStatus on AccountProject'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountStatus' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountProject]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProject_AccountStatus]
			FOREIGN KEY ([ProjectStatusId]) REFERENCES [dbo].[AccountStatus] ([AccountStatusId])
		ALTER TABLE [dbo].[AccountProject]
			CHECK CONSTRAINT [FK_AccountProject_AccountStatus]

END
GO

-- Create Foreign Key FK_AccountProjectTask_AccountPriority on AccountProjectTask
Print 'Create Foreign Key FK_AccountProjectTask_AccountPriority on AccountProjectTask'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProjectTask_AccountPriority' AND TABLE_NAME='AccountProjectTask')
BEGIN
		ALTER TABLE [dbo].[AccountProjectTask]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProjectTask_AccountPriority]
			FOREIGN KEY ([AccountPriorityId]) REFERENCES [dbo].[AccountPriority] ([AccountPriorityId])
		ALTER TABLE [dbo].[AccountProjectTask]
			CHECK CONSTRAINT [FK_AccountProjectTask_AccountPriority]

END
GO

-- Create Foreign Key FK_AccountProjectTask_AccountProjectMilestone on AccountProjectTask
Print 'Create Foreign Key FK_AccountProjectTask_AccountProjectMilestone on AccountProjectTask'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProjectTask_AccountProjectMilestone' AND TABLE_NAME='AccountProjectTask')
BEGIN
		ALTER TABLE [dbo].[AccountProjectTask]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProjectTask_AccountProjectMilestone]
			FOREIGN KEY ([AccountProjectMilestoneId]) REFERENCES [dbo].[AccountProjectMilestone] ([AccountProjectMilestoneId])
		ALTER TABLE [dbo].[AccountProjectTask]
			CHECK CONSTRAINT [FK_AccountProjectTask_AccountProjectMilestone]

END
GO

-- Create Foreign Key FK_AccountProjectTask_AccountStatus on AccountProjectTask
Print 'Create Foreign Key FK_AccountProjectTask_AccountStatus on AccountProjectTask'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProjectTask_AccountStatus' AND TABLE_NAME='AccountProjectTask')
BEGIN
		ALTER TABLE [dbo].[AccountProjectTask]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProjectTask_AccountStatus]
			FOREIGN KEY ([TaskStatusId]) REFERENCES [dbo].[AccountStatus] ([AccountStatusId])
		ALTER TABLE [dbo].[AccountProjectTask]
			CHECK CONSTRAINT [FK_AccountProjectTask_AccountStatus]

END
GO

-- Create Foreign Key FK_AccountProjectTask_AccountTaskType on AccountProjectTask
Print 'Create Foreign Key FK_AccountProjectTask_AccountTaskType on AccountProjectTask'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProjectTask_AccountTaskType' AND TABLE_NAME='AccountProjectTask')
BEGIN
		ALTER TABLE [dbo].[AccountProjectTask]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProjectTask_AccountTaskType]
			FOREIGN KEY ([AccountTaskTypeId]) REFERENCES [dbo].[AccountTaskType] ([AccountTaskTypeId])
		ALTER TABLE [dbo].[AccountProjectTask]
			CHECK CONSTRAINT [FK_AccountProjectTask_AccountTaskType]

END
GO

-- Create Foreign Key FK_AccountExpenseEntry_AccountExpense on AccountExpenseEntry
Print 'Create Foreign Key FK_AccountExpenseEntry_AccountExpense on AccountExpenseEntry'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntry_AccountExpense' AND TABLE_NAME='AccountExpenseEntry')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntry]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountExpenseEntry_AccountExpense]
			FOREIGN KEY ([AccountExpenseId]) REFERENCES [dbo].[AccountExpense] ([AccountExpenseId])
		ALTER TABLE [dbo].[AccountExpenseEntry]
			CHECK CONSTRAINT [FK_AccountExpenseEntry_AccountExpense]

END

GO

-- Create Foreign Key FK_AccountProject_AccountEmployee on AccountProject
Print 'Create Foreign Key FK_AccountProject_AccountEmployee on AccountProject'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountEmployee' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountProject]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProject_AccountEmployee]
			FOREIGN KEY ([LeaderEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId])
		ALTER TABLE [dbo].[AccountProject]
			CHECK CONSTRAINT [FK_AccountProject_AccountEmployee]

END

GO

-- Create Foreign Key FK_AccountProject_AccountEmployee1 on AccountProject
Print 'Create Foreign Key FK_AccountProject_AccountEmployee1 on AccountProject'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProject_AccountEmployee1' AND TABLE_NAME='AccountProject')
BEGIN
		ALTER TABLE [dbo].[AccountProject]
			WITH NOCHECK
			ADD CONSTRAINT [FK_AccountProject_AccountEmployee1]
			FOREIGN KEY ([ProjectManagerEmployeeId]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId])
		ALTER TABLE [dbo].[AccountProject]
			CHECK CONSTRAINT [FK_AccountProject_AccountEmployee1]

END

GO

-- =======================================================
-- Foreign Key Constraint Nochecks's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Nochecks''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'

UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemCategoryPageDescription]='Email Notification Preferences' WHERE [SystemSecurityCategoryPageId]=98
UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemCategoryPageDescription]='Email Notification Preferences' WHERE [SystemSecurityCategoryPageId]=99
UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemCategoryPageDescription]='Email Notification Preferences' WHERE [SystemSecurityCategoryPageId]=100

GO

-- =======================================================
-- Foreign Key Constraint Check's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Check''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[AccountEmployee]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[AccountEmployee]'

UPDATE [dbo].[AccountEmployee] SET [Username]=[EmailAddress] WHERE [Username] is null

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[AccountPagePermission]
-- =======================================================

DELETE FROM AccountPagePermission WHERE SYstemSecurityCategoryPageId In (SELECT SystemSecurityCategoryPageId FROM SystemSecurityCategoryPage WHERE SystemSecurityCategoryPageId = 33 And SystemSecurityCategoryId = 3) And AccountRoleId In (Select AccountRoleId From AccountRole Where MasterAccountRoleId In (2,100,101,102,103,104))

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'

UPDATE [dbo].[SystemSecurityCategoryPage] SET [ParentSystemSecurityCateogoryPageId] ='101' WHERE [SystemSecurityCategoryPageId]=100
UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemSecurityCategoryId]='1' WHERE [SystemSecurityCategoryPageId]=33

GO

-- Drop View vueAccountAttendance
Print 'Drop View vueAccountAttendance'
GO
DROP VIEW [dbo].[vueAccountAttendance]

GO

-- Create View vueAccountAttendance
Print 'Create View vueAccountAttendance'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountAttendance' and table_type = 'VIEW')
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountAttendance
AS
SELECT     dbo.AccountAbsenceType.AbsenceDescription, dbo.AccountAbsenceType.AccountAbsenceTypeId, dbo.AccountEmployeeAttendance.AttendanceDate, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, 
                      dbo.Account.AccountId, dbo.AccountEmployeeAttendance.InOut, dbo.AccountEmployeeAttendance.AttendanceTime, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployeeAttendance.AccountEmployeeAttendanceId
FROM         dbo.AccountAbsenceType RIGHT OUTER JOIN
                      dbo.AccountEmployeeAttendance LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeAttendance.AccountId = dbo.AccountEmployee.AccountId AND 
                      dbo.AccountEmployeeAttendance.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.Account ON dbo.AccountEmployeeAttendance.AccountId = dbo.Account.AccountId ON 
                      dbo.AccountAbsenceType.AccountId = dbo.AccountEmployeeAttendance.AccountId AND 
                      dbo.AccountAbsenceType.AccountAbsenceTypeId = dbo.AccountEmployeeAttendance.AccountAbsenceTypeId'

--End 2.51.0003

--Start 2.71.0001

GO

-- Drop View vueAccountEmployeeTimeEntryWithLastStatus
Print 'Drop View vueAccountEmployeeTimeEntryWithLastStatus'
GO
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryWithLastStatus]
GO

-- Drop View vueAccountProjects
Print 'Drop View vueAccountProjects'
GO
DROP VIEW [dbo].[vueAccountProjects]
GO

-- Drop View vueAccountProjectTask
Print 'Drop View vueAccountProjectTask'
GO
DROP VIEW [dbo].[vueAccountProjectTask]
GO

-- Add Column AccountPartyId to AccountEmployeeTimeEntry
Print 'Add Column AccountPartyId to AccountEmployeeTimeEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountPartyId' AND TABLE_NAME='AccountEmployeeTimeEntry'))
ALTER TABLE [dbo].[AccountEmployeeTimeEntry]
	ADD [AccountPartyId] int NULL

GO

-- Add Column IsTemplate to AccountProject
Print 'Add Column IsTemplate to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsTemplate' AND TABLE_NAME='AccountProject'))
ALTER TABLE [dbo].[AccountProject]
	ADD [IsTemplate] bit NOT NULL
	CONSTRAINT [DF_AccountProject_IsTemplate] DEFAULT ((0))

GO

-- Add Column IsProject to AccountProject
Print 'Add Column IsProject to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsProject' AND TABLE_NAME='AccountProject'))
ALTER TABLE [dbo].[AccountProject]
	ADD [IsProject] bit NOT NULL
	CONSTRAINT [DF_AccountProject_IsProject] DEFAULT ((0))

GO

-- Add Column AccountProjectTemplateId to AccountProject
Print 'Add Column AccountProjectTemplateId to AccountProject'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProject' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountProjectTemplateId' AND TABLE_NAME='AccountProject'))
ALTER TABLE [dbo].[AccountProject]
	ADD [AccountProjectTemplateId] int NULL

GO

-- Add Column AccountBillingRateId to AccountProjectTask
Print 'Add Column AccountBillingRateId to AccountProjectTask'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectTask' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountBillingRateId' AND TABLE_NAME='AccountProjectTask'))
ALTER TABLE [dbo].[AccountProjectTask]
	ADD [AccountBillingRateId] int NULL

GO

-- Add Column IsForAllProjectTask to AccountProjectTask
Print 'Add Column IsForAllProjectTask to AccountProjectTask'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectTask' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsForAllProjectTask' AND TABLE_NAME='AccountProjectTask'))
ALTER TABLE [dbo].[AccountProjectTask]
	ADD [IsForAllProjectTask] bit NULL

GO

-- Add Column TaskCode to AccountProjectTask
Print 'Add Column TaskCode to AccountProjectTask'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectTask' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='TaskCode' AND TABLE_NAME='AccountProjectTask'))
ALTER TABLE [dbo].[AccountProjectTask]
	ADD [TaskCode] varchar(15) NULL

GO

-- Add Column AccountProjectTaskTemplateId to AccountProjectTask
Print 'Add Column AccountProjectTaskTemplateId to AccountProjectTask'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectTask' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountProjectTaskTemplateId' AND TABLE_NAME='AccountProjectTask'))
ALTER TABLE [dbo].[AccountProjectTask]
	ADD [AccountProjectTaskTemplateId] int NULL

GO

-- Add Column AccountProjectMilestoneTemplateId to AccountProjectMilestone
Print 'Add Column AccountProjectMilestoneTemplateId to AccountProjectMilestone'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectMilestone' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountProjectMilestoneTemplateId' AND TABLE_NAME='AccountProjectMilestone'))
ALTER TABLE [dbo].[AccountProjectMilestone]
	ADD [AccountProjectMilestoneTemplateId] bigint NULL

GO

-- Add Column AccountProjectTaskId to AccountBillingRate
Print 'Add Column AccountProjectTaskId to AccountBillingRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountBillingRate' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountProjectTaskId' AND TABLE_NAME='AccountBillingRate'))
ALTER TABLE [dbo].[AccountBillingRate]
	ADD [AccountProjectTaskId] int NULL

GO

-- Create View vueAccountProjectTask
Print 'Create View vueAccountProjectTask'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTask' and table_type = 'VIEW')
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTask
AS
SELECT     dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.AccountTaskTypeId, 
                      dbo.AccountProjectTask.Duration, dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, 
                      dbo.AccountProjectTask.CompletedPercent, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.CreatedOn, dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.ModifiedOn, 
                      dbo.AccountProjectTask.ModifiedByEmployeeId, dbo.AccountStatus.Status AS TaskStatus, dbo.AccountEmployee.FirstName AS CreatedByFirstName, 
                      dbo.AccountEmployee.LastName AS CreatedByLastName, dbo.AccountPriority.Priority, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectCode, dbo.AccountTaskType.TaskType, dbo.AccountProject.AccountId, dbo.AccountProjectTask.AccountProjectMilestoneId, 
                      dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountProjectTask.IsReOpen, AccountEmployee_1.FirstName AS ModifiedByFirstName, 
                      AccountEmployee_1.LastName AS ModifiedByLastName, dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, 
                      dbo.AccountProjectTask.EstimatedTimeSpentUnit, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProjectTask.IsDisabled, 
                      dbo.AccountProjectTask.TaskCode
FROM         dbo.AccountStatus RIGHT OUTER JOIN
                      dbo.AccountTaskType RIGHT OUTER JOIN
                      dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTask LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountProjectTask.ModifiedByEmployeeId = AccountEmployee_1.AccountEmployeeId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountProjectMilestone ON 
                      dbo.AccountProjectTask.AccountProjectMilestoneId = dbo.AccountProjectMilestone.AccountProjectMilestoneId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountTaskType.AccountTaskTypeId = dbo.AccountProjectTask.AccountTaskTypeId ON 
                      dbo.AccountStatus.AccountStatusId = dbo.AccountProjectTask.TaskStatusId LEFT OUTER JOIN
                      dbo.AccountPriority ON dbo.AccountProjectTask.AccountPriorityId = dbo.AccountPriority.AccountPriorityId'
GO

-- Add Column AccountProjectEmployeeTemplateId to AccountProjectEmployee
Print 'Add Column AccountProjectEmployeeTemplateId to AccountProjectEmployee'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectEmployee' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountProjectEmployeeTemplateId' AND TABLE_NAME='AccountProjectEmployee'))
ALTER TABLE [dbo].[AccountProjectEmployee]
	ADD [AccountProjectEmployeeTemplateId] bigint NULL

GO

-- Add Column AccountProjectRoleTemplateId to AccountProjectRole
Print 'Add Column AccountProjectRoleTemplateId to AccountProjectRole'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountProjectRole' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountProjectRoleTemplateId' AND TABLE_NAME='AccountProjectRole'))
ALTER TABLE [dbo].[AccountProjectRole]
	ADD [AccountProjectRoleTemplateId] int NULL

GO

-- Add Column DefaultAccountPageId to AccountPagePermission
Print 'Add Column DefaultAccountPageId to AccountPagePermission'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPagePermission' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='DefaultAccountPageId' AND TABLE_NAME='AccountPagePermission'))
ALTER TABLE [dbo].[AccountPagePermission]
	ADD [DefaultAccountPageId] int NULL

GO

-- Create View vueAccountProjectTaskBillingRate
Print 'Create View vueAccountProjectTaskBillingRate'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskBillingRate' and table_type = 'VIEW')
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskBillingRate
AS
SELECT     dbo.AccountProjectTask.*
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountProject.AccountProjectId = dbo.AccountProjectTask.AccountProjectId'
GO

-- Create View vueAccountProjects
Print 'Create View vueAccountProjects'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjects' and table_type = 'VIEW')
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjects
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.ProjectName, dbo.AccountProject.StartDate, dbo.AccountProject.ProjectCode, 
                      dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, dbo.AccountProject.LeaderEmployeeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, AccountEmployee_1.FirstName + '' '' + dbo.AccountEmployee.LastName AS LeaderName, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS ProjectManagerName, dbo.AccountProject.AccountId, 
                      dbo.AccountProject.IsActive, dbo.AccountProject.Deadline, dbo.AccountProject.EstimatedDuration, dbo.AccountProject.EstimatedDurationUnit, 
                      dbo.AccountProject.ProjectStatusId, dbo.AccountStatus.Status, dbo.AccountProject.IsDisabled, dbo.AccountProject.ProjectDescription, 
                      dbo.AccountProject.IsTemplate, dbo.AccountProject.IsProject, dbo.AccountProject.AccountProjectTemplateId
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId LEFT OUTER JOIN
                      dbo.AccountStatus ON dbo.AccountProject.ProjectStatusId = dbo.AccountStatus.AccountStatusId FULL OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountEmployee.AccountEmployeeId = AccountEmployee_1.AccountEmployeeId ON 
                      dbo.AccountProject.ProjectManagerEmployeeId = dbo.AccountEmployee.AccountEmployeeId AND 
                      dbo.AccountProject.LeaderEmployeeId = AccountEmployee_1.AccountEmployeeId'
GO

-- Create View vueAccountProjectEmployeeTask
Print 'Create View vueAccountProjectEmployeeTask'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectEmployeeTask' and table_type = 'VIEW')
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectEmployeeTask
AS
SELECT     dbo.AccountProjectTaskEmployee.AccountProjectTaskEmployeeId, dbo.AccountProjectTask.AccountProjectId, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.TaskName, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProject.AccountId, dbo.AccountProject.ProjectCode, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.Completed, dbo.AccountProject.ProjectName, dbo.AccountBillingRate.BillingRate
FROM         dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTaskEmployee RIGHT OUTER JOIN
                      dbo.AccountBillingRate RIGHT OUTER JOIN
                      dbo.AccountProjectTask ON dbo.AccountBillingRate.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId ON 
                      dbo.AccountProjectTaskEmployee.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTaskEmployee.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId'
GO

-- Create View vueAccountProjectTaskWithBillingRate
Print 'Create View vueAccountProjectTaskWithBillingRate'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTaskWithBillingRate' and table_type = 'VIEW')
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTaskWithBillingRate
AS
SELECT     dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.AccountTaskTypeId, 
                      dbo.AccountProjectTask.Duration, dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, 
                      dbo.AccountProjectTask.CompletedPercent, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.AccountProjectMilestoneId, dbo.AccountProjectTask.IsReOpen, dbo.AccountProjectTask.CreatedOn, 
                      dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.ModifiedOn, dbo.AccountProjectTask.ModifiedByEmployeeId, 
                      dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, dbo.AccountProjectTask.EstimatedTimeSpentUnit, 
                      dbo.AccountProjectTask.IsBillable, dbo.AccountProjectTask.IsDisabled, dbo.AccountProjectTask.AccountBillingRateId, 
                      dbo.AccountProjectTask.IsForAllProjectTask, dbo.AccountBillingRate.SystemBillingRateTypeId, dbo.AccountBillingRate.BillingRate, 
                      dbo.AccountBillingRate.StartDate, dbo.AccountBillingRate.EndDate
FROM         dbo.AccountProjectTask LEFT OUTER JOIN
                      dbo.AccountBillingRate ON dbo.AccountProjectTask.AccountBillingRateId = dbo.AccountBillingRate.AccountBillingRateId'
GO

-- Create View vueAccountEmployeeTimeEntryWithLastStatus
Print 'Create View vueAccountEmployeeTimeEntryWithLastStatus'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithLastStatus' and table_type = 'VIEW')
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithLastStatus
AS
SELECT     dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.AccountEmployeeId, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, 
                      dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.AccountProjectId, dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, 
                      dbo.AccountEmployeeTimeEntry.Description, dbo.AccountEmployeeTimeEntry.TimeSheetApprovalPathId, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountEmployeeTimeEntry.TeamLeadApproved, dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.AccountEmployeeTimeEntry.AdministratorApproved, dbo.AccountEmployeeTimeEntry.CreatedOn, dbo.AccountEmployeeTimeEntry.ModifiedOn, 
                      dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction.IsApproved, dbo.vueAccountEmployeeTimeEntryApprovalLastAction.IsReject, 
                      dbo.AccountEmployeeTimeEntry.AccountPartyId
FROM         dbo.AccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApprovalLastAction.AccountEmployeeTimeEntryId'
GO

-- Drop View vueAccountProjectTask
Print 'Drop View vueAccountProjectTask'
GO
DROP VIEW [dbo].[vueAccountProjectTask]
GO

-- Add Column AccountEmailNotificationPreferenceTemplateId to AccountEMailNotificationPreference
Print 'Add Column AccountEmailNotificationPreferenceTemplateId to AccountEMailNotificationPreference'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEMailNotificationPreference' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountEmailNotificationPreferenceTemplateId' AND TABLE_NAME='AccountEMailNotificationPreference'))
ALTER TABLE [dbo].[AccountEMailNotificationPreference]
	ADD [AccountEmailNotificationPreferenceTemplateId] int NULL

GO
-- Create View vueAccountProjectTask
Print 'Create View vueAccountProjectTask'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountProjectTask' and table_type = 'VIEW')
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountProjectTask
AS
SELECT     dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.AccountTaskTypeId, 
                      dbo.AccountProjectTask.Duration, dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, 
                      dbo.AccountProjectTask.CompletedPercent, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.CreatedOn, dbo.AccountProjectTask.CreatedByEmployeeId, dbo.AccountProjectTask.ModifiedOn, 
                      dbo.AccountProjectTask.ModifiedByEmployeeId, dbo.AccountStatus.Status AS TaskStatus, dbo.AccountEmployee.FirstName AS CreatedByFirstName, 
                      dbo.AccountEmployee.LastName AS CreatedByLastName, dbo.AccountPriority.Priority, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectCode, dbo.AccountTaskType.TaskType, dbo.AccountProject.AccountId, dbo.AccountProjectTask.AccountProjectMilestoneId, 
                      dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountProjectTask.IsReOpen, AccountEmployee_1.FirstName AS ModifiedByFirstName, 
                      AccountEmployee_1.LastName AS ModifiedByLastName, dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, 
                      dbo.AccountProjectTask.EstimatedTimeSpentUnit, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProjectTask.IsDisabled, 
                      dbo.AccountProjectTask.TaskCode, dbo.AccountProject.IsTemplate
FROM         dbo.AccountStatus RIGHT OUTER JOIN
                      dbo.AccountTaskType RIGHT OUTER JOIN
                      dbo.AccountEmployee RIGHT OUTER JOIN
                      dbo.AccountProjectTask LEFT OUTER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountProjectTask.ModifiedByEmployeeId = AccountEmployee_1.AccountEmployeeId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountProjectTask.CreatedByEmployeeId LEFT OUTER JOIN
                      dbo.AccountProjectMilestone ON 
                      dbo.AccountProjectTask.AccountProjectMilestoneId = dbo.AccountProjectMilestone.AccountProjectMilestoneId LEFT OUTER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountTaskType.AccountTaskTypeId = dbo.AccountProjectTask.AccountTaskTypeId ON 
                      dbo.AccountStatus.AccountStatusId = dbo.AccountProjectTask.TaskStatusId LEFT OUTER JOIN
                      dbo.AccountPriority ON dbo.AccountProjectTask.AccountPriorityId = dbo.AccountPriority.AccountPriorityId'
GO


-- =======================================================
-- Foreign Key Constraint Nochecks's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Nochecks''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemBillingRateType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemBillingRateType]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemBillingRateType] WHERE [SystemBillingRateTypeId] =4 AND [SystemBillingRateType] = 'Project Task')
BEGIN
INSERT INTO [dbo].[SystemBillingRateType] ([SystemBillingRateTypeId], [SystemBillingRateType]) VALUES (4, 'Project Task')
END

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemProjectBillingRateType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemProjectBillingRateType]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemProjectBillingRateType] WHERE [SystemProjectBillingRateTypeId] =4 AND [SystemProjectBillingRateType]= 'Use Project Task Billing Rate')
BEGIN
INSERT INTO [dbo].[SystemProjectBillingRateType] ([SystemProjectBillingRateTypeId], [SystemProjectBillingRateType]) VALUES (4, 'Use Project Task Billing Rate')
END

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'

IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPage] WHERE [SystemSecurityCategoryPageId] =102 AND [SystemSecurityCategoryId] = 1 AND [SequenceNumber] = '21012303' AND [Folder] = 'AccountAdmin' AND [SystemCategoryPage] = 'AuthenticationSetting.aspx' AND [SystemCategoryPageDescription] = 'Authentication Setting' AND [ParentSystemSecurityCateogoryPageId] = 15 AND [IsSiteMapPage] = 1 AND [IsCustomizeable] = 1 AND [IsAllowAdd] = 0 AND [IsAllowEdit]=1 AND [IsAllowDelete]=0 AND [IsAllowList]=0 AND [IsShowDataOptions] is NULL AND [IsShowTillOptions] Is Null AND [IsSystemPage] is NULL AND [ControlLevelPermission] is NULL)
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (102, 1, '21012303', 'AccountAdmin', 'AuthenticationSetting.aspx', 'Authentication Setting', 15, 1, 1, 0, 1, 0, 0, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (103, 1, '21101', 'ProjectAdmin', 'AccountProjectTemplates.aspx', 'Project Templates', 15, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
END

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'

IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPage] WHERE [SystemSecurityCategoryPageId] =103 AND [SystemSecurityCategoryId] = 1 AND [SequenceNumber] = '21101' AND [Folder] = 'ProjectAdmin' AND [SystemCategoryPage] = 'AccountProjectTemplates.aspx' AND [SystemCategoryPageDescription] = 'Project Templates' AND [ParentSystemSecurityCateogoryPageId] = 15 AND [IsSiteMapPage] = 1 AND [IsCustomizeable] = 1 AND [IsAllowAdd] = 1 AND [IsAllowEdit]=1 AND [IsAllowDelete]= 1 AND [IsAllowList]=1 AND [IsShowDataOptions] is NULL AND [IsShowTillOptions] Is Null AND [IsSystemPage] is NULL AND [ControlLevelPermission] is NULL)
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (103, 1, '21101', 'ProjectAdmin', 'AccountProjectTemplates.aspx', 'Project Templates', 15, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
END

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountRole]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountRole]'

UPDATE [dbo].[MasterAccountRole] SET [LDAPGroup]='TimeLiveAdministrator' WHERE [MasterAccountRoleId]=1
UPDATE [dbo].[MasterAccountRole] SET [LDAPGroup]='TimeLiveUser' WHERE [MasterAccountRoleId]=2
UPDATE [dbo].[MasterAccountRole] SET [LDAPGroup]='TimeLiveTeamLead' WHERE [MasterAccountRoleId]=100
UPDATE [dbo].[MasterAccountRole] SET [LDAPGroup]='TimeLiveProjectManager' WHERE [MasterAccountRoleId]=101
UPDATE [dbo].[MasterAccountRole] SET [LDAPGroup]='TimeLiveExternalUser' WHERE [MasterAccountRoleId]=102
UPDATE [dbo].[MasterAccountRole] SET [LDAPGroup]='TimeLiveTimeEntryApprover' WHERE [MasterAccountRoleId]=103
UPDATE [dbo].[MasterAccountRole] SET [LDAPGroup]='TimeLiveExpenseEntryApprover' WHERE [MasterAccountRoleId]=104

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'

UPDATE [dbo].[SystemSecurityCategoryPage] SET [IsSiteMapPage]=0 WHERE [SystemSecurityCategoryPageId]=70

GO

-- =======================================================
-- Foreign Key Constraint Check's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Check''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]

GO
-- =======================================================
-- Update ParentAccountProjectTaskId for Table: [dbo].[AccountProjectTask]
-- =======================================================
IF EXISTS (Select * From AccountProjectTask Where ParentAccountProjectTaskId Not In (Select AccountProjectTaskId From AccountProjectTask))
BEGIN
Update AccountProjectTask Set ParentAccountProjectTaskId = 0 Where ParentAccountProjectTaskId Not In (Select AccountProjectTaskId From AccountProjectTask)
END

GO
-- =======================================================
-- Update ParentAccountProjectTaskId for Table: [dbo].[AccountProjectTask]
-- =======================================================
IF EXISTS (Select * From AccountProjectTask Where ParentAccountProjectTaskId = 0)
BEGIN
Update AccountProjectTask Set ParentAccountProjectTaskId = NULL Where ParentAccountProjectTaskId = 0
END

GO
-- Create Foreign Key FK_AccountProjectTask_AccountProjectTask on AccountProjectTask
Print 'Create Foreign Key FK_AccountProjectTask_AccountProjectTask on AccountProjectTask'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProjectTask_AccountProjectTask' AND TABLE_NAME='AccountProjectTask')
BEGIN
		ALTER TABLE [dbo].[AccountProjectTask]
			ADD CONSTRAINT [FK_AccountProjectTask_AccountProjectTask]
			FOREIGN KEY ([ParentAccountProjectTaskId]) REFERENCES [dbo].[AccountProjectTask] ([AccountProjectTaskId])
END

--End 2.71.0001


--Start 2.71.0002

GO
-- Drop View vueAccountExpenseEntry
Print 'Drop View vueAccountExpenseEntry'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntry]
GO
-- Add Column Quantity to AccountExpenseEntry
Print 'Add Column Quantity to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Quantity' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [Quantity] float NULL

GO
-- Add Column Rate to AccountExpenseEntry
Print 'Add Column Rate to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Rate' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [Rate] float NULL

GO
-- Add Column AmountBeforeTax to AccountExpenseEntry
Print 'Add Column AmountBeforeTax to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AmountBeforeTax' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [AmountBeforeTax] float NULL

GO
-- Add Column TaxAmount to AccountExpenseEntry
Print 'Add Column TaxAmount to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='TaxAmount' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [TaxAmount] float NULL

GO
-- Add Column Reimburse to AccountExpenseEntry
Print 'Add Column Reimburse to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Reimburse' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [Reimburse] bit NOT NULL
	CONSTRAINT [DF_AccountExpenseEntry_Reimburse] DEFAULT ((0))

GO

-- Add Column AccountCurrencyId to AccountExpenseEntry
Print 'Add Column AccountCurrencyId to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountCurrencyId' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [AccountCurrencyId] int NULL

GO
-- Add Column AccountPaymentMethodId to AccountExpenseEntry
Print 'Add Column AccountPaymentMethodId to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountPaymentMethodId' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [AccountPaymentMethodId] int NULL

GO
-- Create Table AccountCurrencyExchangeRate
Print 'Create Table AccountCurrencyExchangeRate'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountCurrencyExchangeRate' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountCurrencyExchangeRate] (
		[AccountCurrencyExchangeRateId]           int NOT NULL IDENTITY(1, 1),
		[ExchangeRateEffectiveStartDate]          datetime NOT NULL,
		[ExchangeRateEffectiveEndDate]            datetime NOT NULL,
		[ExchangeRate]                            float NOT NULL,
		[AccountId]                               int NOT NULL,
		[AccountCurrencyId]                       int NOT NULL,
		[MasterAccountCurrencyExchangeRateId]     smallint NULL
)
GO
-- Add Primary Key PK_AccountCurrencyExchangeRate to AccountCurrencyExchangeRate
Print 'Add Primary Key PK_AccountCurrencyExchangeRate to AccountCurrencyExchangeRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountCurrencyExchangeRate' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountCurrencyExchangeRate' AND TABLE_NAME='AccountCurrencyExchangeRate'))
ALTER TABLE [dbo].[AccountCurrencyExchangeRate]
	ADD
	CONSTRAINT [PK_AccountCurrencyExchangeRate]
	PRIMARY KEY
	([AccountCurrencyExchangeRateId])
GO
-- Create Table AccountCurrency
Print 'Create Table AccountCurrency'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountCurrency' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountCurrency] (
		[AccountCurrencyId]                 int NOT NULL IDENTITY(1, 1),
		[AccountCurrencyExchangeRateId]     int NOT NULL,
		[SystemCurrencyId]                  int NOT NULL,
		[AccountId]                         int NOT NULL,
		[Disabled]                          bit NOT NULL,
		[MasterAccountCurrencyId]           smallint NULL
)
GO
-- Add Primary Key PK_AccountCurrency to AccountCurrency
Print 'Add Primary Key PK_AccountCurrency to AccountCurrency'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountCurrency' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountCurrency' AND TABLE_NAME='AccountCurrency'))
ALTER TABLE [dbo].[AccountCurrency]
	ADD
	CONSTRAINT [PK_AccountCurrency]
	PRIMARY KEY
	([AccountCurrencyId])
GO
-- Create Index IX_AccountCurrency on AccountCurrency
Print 'Create Index IX_AccountCurrency on AccountCurrency'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountCurrency' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountCurrency]') AND name = N'IX_AccountCurrency'))
CREATE UNIQUE INDEX [IX_AccountCurrency]
	ON [dbo].[AccountCurrency] ([AccountCurrencyId])
GO
-- Create Table AccountTaxCode
Print 'Create Table AccountTaxCode'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountTaxCode' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountTaxCode] (
		[AccountTaxCodeId]     int NOT NULL IDENTITY(1, 1),
		[AccountId]            int NOT NULL,
		[TaxCode]              varchar(50) NOT NULL,
		[Formula]              varchar(100) NOT NULL,
		[MasterTaxCodeId]      smallint NULL,
		[IsDisabled]           bit NOT NULL
)
GO
-- Add Primary Key PK_AccountTaxCode to AccountTaxCode
Print 'Add Primary Key PK_AccountTaxCode to AccountTaxCode'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountTaxCode' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountTaxCode' AND TABLE_NAME='AccountTaxCode'))
ALTER TABLE [dbo].[AccountTaxCode]
	ADD
	CONSTRAINT [PK_AccountTaxCode]
	PRIMARY KEY
	([AccountTaxCodeId])
GO
-- Add Column AccountTaxCodeId to AccountExpenseType
Print 'Add Column AccountTaxCodeId to AccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountTaxCodeId' AND TABLE_NAME='AccountExpenseType'))
ALTER TABLE [dbo].[AccountExpenseType]
	ADD [AccountTaxCodeId] int NULL

GO
-- Add Column IsQuantityField to AccountExpenseType
Print 'Add Column IsQuantityField to AccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsQuantityField' AND TABLE_NAME='AccountExpenseType'))
ALTER TABLE [dbo].[AccountExpenseType]
	ADD [IsQuantityField] bit NULL

GO
-- Add Column QuantityFieldCaption to AccountExpenseType
Print 'Add Column QuantityFieldCaption to AccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='QuantityFieldCaption' AND TABLE_NAME='AccountExpenseType'))
ALTER TABLE [dbo].[AccountExpenseType]
	ADD [QuantityFieldCaption] varchar(50) NULL

GO
-- Add Column AccountBaseCurrencyId to AccountPreferences
Print 'Add Column AccountBaseCurrencyId to AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountBaseCurrencyId' AND TABLE_NAME='AccountPreferences'))
ALTER TABLE [dbo].[AccountPreferences]
	ADD [AccountBaseCurrencyId] int NULL

GO
-- Add Column AccountReimbursementCurrencyId to AccountPreferences
Print 'Add Column AccountReimbursementCurrencyId to AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountReimbursementCurrencyId' AND TABLE_NAME='AccountPreferences'))
ALTER TABLE [dbo].[AccountPreferences]
	ADD [AccountReimbursementCurrencyId] int NULL

GO
-- Create View vueAccountCurrency
Print 'Create View vueAccountCurrency'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountCurrency' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountCurrency
AS
SELECT     dbo.SystemCurrency.CurrencyCode, dbo.SystemCurrency.Currency, dbo.AccountCurrency.Disabled, dbo.AccountCurrency.AccountId, 
                      dbo.AccountCurrency.AccountCurrencyId, dbo.AccountCurrencyExchangeRate.ExchangeRate, 
                      dbo.AccountCurrency.AccountCurrencyExchangeRateId
FROM         dbo.AccountCurrencyExchangeRate RIGHT OUTER JOIN
                      dbo.AccountCurrency ON 
                      dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId = dbo.AccountCurrency.AccountCurrencyExchangeRateId LEFT OUTER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId'
GO
-- Create View vueAccountExpenseEntry
Print 'Create View vueAccountExpenseEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpense.AccountExpenseName, 
                      dbo.AccountProject.ProjectName, dbo.AccountExpenseEntry.AccountExpenseEntryId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountProjectId, 
                      dbo.AccountExpenseEntry.AccountExpenseId, dbo.AccountExpenseEntry.Amount, dbo.AccountExpenseEntry.TeamLeadApproved, 
                      dbo.AccountExpenseEntry.ProjectManagerApproved, dbo.AccountExpenseEntry.AdministratorApproved, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountExpenseEntry.CreatedOn, dbo.AccountExpenseEntry.CreatedByEmployeeId, dbo.AccountExpenseEntry.ModifiedOn, 
                      dbo.AccountExpenseEntry.ModifiedByEmployeeId, dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, 
                      dbo.AccountExpenseEntry.Description, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountExpenseTypeId, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountExpenseEntry.Reimburse, dbo.AccountExpenseEntry.AccountCurrencyId, 
                      dbo.SystemCurrency.CurrencyCode, dbo.AccountExpenseType.IsQuantityField, dbo.AccountTaxCode.TaxCode, 
                      dbo.AccountExpenseType.QuantityFieldCaption
FROM         dbo.AccountTaxCode RIGHT OUTER JOIN
                      dbo.AccountExpenseType ON dbo.AccountTaxCode.AccountTaxCodeId = dbo.AccountExpenseType.AccountTaxCodeId RIGHT OUTER JOIN
                      dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountCurrency ON dbo.AccountExpenseEntry.AccountCurrencyId = dbo.AccountCurrency.AccountCurrencyId LEFT OUTER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId ON 
                      dbo.AccountExpenseType.AccountExpenseTypeId = dbo.AccountExpense.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId'
GO
-- Create Table MasterPaymentMethod
Print 'Create Table MasterPaymentMethod'
GO
if not exists (select * from information_schema.tables where table_name = 'MasterPaymentMethod' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[MasterPaymentMethod] (
		[MasterPaymentMethodId]     smallint NOT NULL,
		[PaymentMethod]             varchar(50) NOT NULL
)
GO
-- Add Primary Key PK_SystemPaymentMethod to MasterPaymentMethod
Print 'Add Primary Key PK_SystemPaymentMethod to MasterPaymentMethod'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterPaymentMethod' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_SystemPaymentMethod' AND TABLE_NAME='MasterPaymentMethod'))
ALTER TABLE [dbo].[MasterPaymentMethod]
	ADD
	CONSTRAINT [PK_SystemPaymentMethod]
	PRIMARY KEY
	([MasterPaymentMethodId])
GO
-- Create Table MasterTaxCode
Print 'Create Table MasterTaxCode'
GO
if not exists (select * from information_schema.tables where table_name = 'MasterTaxCode' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[MasterTaxCode] (
		[MasterTaxCodeId]     smallint NOT NULL,
		[TaxCode]             varchar(50) NOT NULL,
		[Formula]             varchar(100) NOT NULL
)
GO
-- Add Primary Key PK_MasterTaxCode to MasterTaxCode
Print 'Add Primary Key PK_MasterTaxCode to MasterTaxCode'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterTaxCode' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_MasterTaxCode' AND TABLE_NAME='MasterTaxCode'))
ALTER TABLE [dbo].[MasterTaxCode]
	ADD
	CONSTRAINT [PK_MasterTaxCode]
	PRIMARY KEY
	([MasterTaxCodeId])
GO
-- Create Table SystemAttachmentType
Print 'Create Table SystemAttachmentType'
GO
if not exists (select * from information_schema.tables where table_name = 'SystemAttachmentType' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[SystemAttachmentType] (
		[SystemAttachmentTypeId]     int NOT NULL,
		[SystemAttachmentType]       varchar(50) NOT NULL
)
GO
-- Add Primary Key PK_SystemAttachmentType to SystemAttachmentType
Print 'Add Primary Key PK_SystemAttachmentType to SystemAttachmentType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SystemAttachmentType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_SystemAttachmentType' AND TABLE_NAME='SystemAttachmentType'))
ALTER TABLE [dbo].[SystemAttachmentType]
	ADD
	CONSTRAINT [PK_SystemAttachmentType]
	PRIMARY KEY
	([SystemAttachmentTypeId])
GO
-- Add Column AccountBaseCurrencyId to MasterAccountPreferences
Print 'Add Column AccountBaseCurrencyId to MasterAccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountBaseCurrencyId' AND TABLE_NAME='MasterAccountPreferences'))
ALTER TABLE [dbo].[MasterAccountPreferences]
	ADD [AccountBaseCurrencyId] int NULL

GO
-- Add Column AccountReimbursementCurrencyId to MasterAccountPreferences
Print 'Add Column AccountReimbursementCurrencyId to MasterAccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountReimbursementCurrencyId' AND TABLE_NAME='MasterAccountPreferences'))
ALTER TABLE [dbo].[MasterAccountPreferences]
	ADD [AccountReimbursementCurrencyId] int NULL

GO
-- Add Column IsShowQuantityField to MasterAccountExpenseType
Print 'Add Column IsShowQuantityField to MasterAccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsShowQuantityField' AND TABLE_NAME='MasterAccountExpenseType'))
ALTER TABLE [dbo].[MasterAccountExpenseType]
	ADD [IsShowQuantityField] bit NULL

GO
-- Add Column QuantityFieldCaption to MasterAccountExpenseType
Print 'Add Column QuantityFieldCaption to MasterAccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='QuantityFieldCaption' AND TABLE_NAME='MasterAccountExpenseType'))
ALTER TABLE [dbo].[MasterAccountExpenseType]
	ADD [QuantityFieldCaption] varchar(50) NULL

GO
-- Add Column IsInputTax to MasterAccountExpenseType
Print 'Add Column IsInputTax to MasterAccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='IsInputTax' AND TABLE_NAME='MasterAccountExpenseType'))
ALTER TABLE [dbo].[MasterAccountExpenseType]
	ADD [IsInputTax] bit NULL

GO
-- Add Column TaxFieldCaption to MasterAccountExpenseType
Print 'Add Column TaxFieldCaption to MasterAccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='TaxFieldCaption' AND TABLE_NAME='MasterAccountExpenseType'))
ALTER TABLE [dbo].[MasterAccountExpenseType]
	ADD [TaxFieldCaption] varchar(50) NULL

GO
-- Add Column MasterTaxCodeId to MasterAccountExpenseType
Print 'Add Column MasterTaxCodeId to MasterAccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='MasterTaxCodeId' AND TABLE_NAME='MasterAccountExpenseType'))
ALTER TABLE [dbo].[MasterAccountExpenseType]
	ADD [MasterTaxCodeId] smallint NULL

GO
-- Create Table MasterAccountCurrency
Print 'Create Table MasterAccountCurrency'
GO
if not exists (select * from information_schema.tables where table_name = 'MasterAccountCurrency' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[MasterAccountCurrency] (
		[MasterAccountCurrencyId]                 smallint NOT NULL,
		[MasterAccountCurrencyExchangeRateId]     smallint NOT NULL,
		[SystemCurrencyId]                        int NOT NULL
)
GO
-- Add Primary Key PK_MasterAccountCurrency to MasterAccountCurrency
Print 'Add Primary Key PK_MasterAccountCurrency to MasterAccountCurrency'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountCurrency' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_MasterAccountCurrency' AND TABLE_NAME='MasterAccountCurrency'))
ALTER TABLE [dbo].[MasterAccountCurrency]
	ADD
	CONSTRAINT [PK_MasterAccountCurrency]
	PRIMARY KEY
	([MasterAccountCurrencyId])
GO
-- Create Table MasterAccountCurrencyExchangeRate
Print 'Create Table MasterAccountCurrencyExchangeRate'
GO
if not exists (select * from information_schema.tables where table_name = 'MasterAccountCurrencyExchangeRate' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[MasterAccountCurrencyExchangeRate] (
		[MasterAccountCurrencyExchangeRateId]     smallint NOT NULL,
		[ExchangeRateEffectiveStartDate]          datetime NULL,
		[ExchangeRateEffectiveEndDate]            datetime NULL,
		[ExchangeRate]                            money NOT NULL,
		[MasterAccountCurrencyId]                 smallint NULL
)
GO
-- Add Primary Key PK_MasterAccountCurrencyExchangeRate to MasterAccountCurrencyExchangeRate
Print 'Add Primary Key PK_MasterAccountCurrencyExchangeRate to MasterAccountCurrencyExchangeRate'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MasterAccountCurrencyExchangeRate' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_MasterAccountCurrencyExchangeRate' AND TABLE_NAME='MasterAccountCurrencyExchangeRate'))
ALTER TABLE [dbo].[MasterAccountCurrencyExchangeRate]
	ADD
	CONSTRAINT [PK_MasterAccountCurrencyExchangeRate]
	PRIMARY KEY
	([MasterAccountCurrencyExchangeRateId])
GO
-- Create Table AccountAttachments
Print 'Create Table AccountAttachments'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountAttachments' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountAttachments] (
		[AccountAttachmentId]         int NOT NULL IDENTITY(1, 1),
		[AccountAttachmentTypeId]     int NOT NULL,
		[AccountExpenseEntryId]       int NOT NULL,
		[AttachmentName]              varchar(500) NOT NULL,
		[AttachmentLocalPath]         varchar(500) NOT NULL,
		[CreatedOn]                   datetime NOT NULL,
		[CreatedByEmployeeId]         int NOT NULL,
		[ModifiedOn]                  datetime NOT NULL,
		[ModifiedByEmployeeId]        int NOT NULL
)
GO
-- Add Primary Key PK_AccountAttachments to AccountAttachments
Print 'Add Primary Key PK_AccountAttachments to AccountAttachments'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountAttachments' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountAttachments' AND TABLE_NAME='AccountAttachments'))
ALTER TABLE [dbo].[AccountAttachments]
	ADD
	CONSTRAINT [PK_AccountAttachments]
	PRIMARY KEY
	([AccountAttachmentId])
GO
-- Create Table AccountPaymentMethod
Print 'Create Table AccountPaymentMethod'
GO
if not exists (select * from information_schema.tables where table_name = 'AccountPaymentMethod' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[AccountPaymentMethod] (
		[AccountPaymentMethodId]     int NOT NULL IDENTITY(1, 1),
		[AccountId]                  int NOT NULL,
		[PaymentMethod]              varchar(50) NOT NULL,
		[MasterPaymentMethodId]      smallint NULL,
		[IsDisabled]                 bit NOT NULL
)
GO
-- Add Primary Key PK_AccountPaymentMethod to AccountPaymentMethod
Print 'Add Primary Key PK_AccountPaymentMethod to AccountPaymentMethod'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPaymentMethod' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_AccountPaymentMethod' AND TABLE_NAME='AccountPaymentMethod'))
ALTER TABLE [dbo].[AccountPaymentMethod]
	ADD
	CONSTRAINT [PK_AccountPaymentMethod]
	PRIMARY KEY
	([AccountPaymentMethodId])
GO
-- Create View vueAccountCurrencyExchangeRate
Print 'Create View vueAccountCurrencyExchangeRate'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountCurrencyExchangeRate' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountCurrencyExchangeRate
AS
SELECT     dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId, dbo.AccountCurrencyExchangeRate.ExchangeRateEffectiveStartDate, 
                      dbo.AccountCurrencyExchangeRate.ExchangeRateEffectiveEndDate, dbo.AccountCurrencyExchangeRate.ExchangeRate, 
                      dbo.AccountCurrencyExchangeRate.AccountId, dbo.AccountCurrency.AccountCurrencyId
FROM         dbo.AccountCurrencyExchangeRate LEFT OUTER JOIN
                      dbo.AccountCurrency ON dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId = dbo.AccountCurrency.AccountCurrencyExchangeRateId'
GO
-- Create View vueAccountBaseCurrency
Print 'Create View vueAccountBaseCurrency'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountBaseCurrency' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountBaseCurrency
AS
SELECT     dbo.AccountPreferences.AccountBaseCurrencyId, dbo.vueAccountCurrency.CurrencyCode + '' - '' + dbo.vueAccountCurrency.Currency AS BaseCurrency, 
                      dbo.AccountPreferences.AccountId, dbo.vueAccountCurrency.CurrencyCode
FROM         dbo.AccountPreferences LEFT OUTER JOIN
                      dbo.vueAccountCurrency ON dbo.AccountPreferences.AccountBaseCurrencyId = dbo.vueAccountCurrency.AccountCurrencyId'
GO
-- Create View vueAccountExpenseType
Print 'Create View vueAccountExpenseType'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseType' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseType
AS
SELECT     dbo.AccountExpenseType.AccountExpenseTypeId, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpenseType.AccountId, 
                      dbo.AccountExpenseType.CreatedOn, dbo.AccountExpenseType.ModifiedOn, dbo.AccountExpenseType.CreatedByEmployeeId, 
                      dbo.AccountExpenseType.ModifiedByEmployeeId, dbo.AccountExpenseType.IsDisabled, dbo.AccountExpenseType.AccountTaxCodeId, 
                      dbo.AccountTaxCode.TaxCode
FROM         dbo.AccountExpenseType LEFT OUTER JOIN
                      dbo.AccountTaxCode ON dbo.AccountExpenseType.AccountTaxCodeId = dbo.AccountTaxCode.AccountTaxCodeId'
GO
-- Create View vueAccountExpenseWithTaxCode
Print 'Create View vueAccountExpenseWithTaxCode'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseWithTaxCode' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseWithTaxCode
AS
SELECT     dbo.AccountExpense.AccountExpenseId, dbo.AccountTaxCode.TaxCode, dbo.AccountTaxCode.Formula, dbo.AccountExpense.AccountId, 
                      dbo.AccountExpenseType.AccountExpenseTypeId, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpenseType.IsQuantityField, 
                      dbo.AccountExpenseType.QuantityFieldCaption
FROM         dbo.AccountExpense INNER JOIN
                      dbo.AccountExpenseType ON dbo.AccountExpense.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountTaxCode ON dbo.AccountExpenseType.AccountTaxCodeId = dbo.AccountTaxCode.AccountTaxCodeId'
GO
-- Create Foreign Key FK_AccountTaxCode_Account on AccountTaxCode
Print 'Create Foreign Key FK_AccountTaxCode_Account on AccountTaxCode'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountTaxCode_Account' AND TABLE_NAME='AccountTaxCode')
BEGIN
		ALTER TABLE [dbo].[AccountTaxCode]
			ADD CONSTRAINT [FK_AccountTaxCode_Account]
			FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId])
END
GO
 
-- Create Foreign Key FK_AccountTaxCode_MasterTaxCode on AccountTaxCode
Print 'Create Foreign Key FK_AccountTaxCode_MasterTaxCode on AccountTaxCode'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountTaxCode_MasterTaxCode' AND TABLE_NAME='AccountTaxCode')
BEGIN
		ALTER TABLE [dbo].[AccountTaxCode]
			ADD CONSTRAINT [FK_AccountTaxCode_MasterTaxCode]
			FOREIGN KEY ([MasterTaxCodeId]) REFERENCES [dbo].[MasterTaxCode] ([MasterTaxCodeId])
END
GO
-- Create Foreign Key FK_AccountAttachments_AccountAttachments on AccountAttachments
Print 'Create Foreign Key FK_AccountAttachments_AccountAttachments on AccountAttachments'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountAttachments_AccountAttachments' AND TABLE_NAME='AccountAttachments')
BEGIN
		ALTER TABLE [dbo].[AccountAttachments]
			ADD CONSTRAINT [FK_AccountAttachments_AccountAttachments]
			FOREIGN KEY ([AccountAttachmentId]) REFERENCES [dbo].[AccountAttachments] ([AccountAttachmentId])
END
GO
-- Create Foreign Key FK_AccountAttachments_AccountExpenseEntry on AccountAttachments
Print 'Create Foreign Key FK_AccountAttachments_AccountExpenseEntry on AccountAttachments'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountAttachments_AccountExpenseEntry' AND TABLE_NAME='AccountAttachments')
BEGIN
		ALTER TABLE [dbo].[AccountAttachments]
			ADD CONSTRAINT [FK_AccountAttachments_AccountExpenseEntry]
			FOREIGN KEY ([AccountExpenseEntryId]) REFERENCES [dbo].[AccountExpenseEntry] ([AccountExpenseEntryId])
END
GO
-- Create Foreign Key FK_AccountPreferences_AccountCurrency on AccountPreferences
Print 'Create Foreign Key FK_AccountPreferences_AccountCurrency on AccountPreferences'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPreferences_AccountCurrency' AND TABLE_NAME='AccountPreferences')
BEGIN
		ALTER TABLE [dbo].[AccountPreferences]
			ADD CONSTRAINT [FK_AccountPreferences_AccountCurrency]
			FOREIGN KEY ([AccountBaseCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId])
END
GO
-- Create Foreign Key FK_AccountPreferences_AccountCurrency1 on AccountPreferences
Print 'Create Foreign Key FK_AccountPreferences_AccountCurrency1 on AccountPreferences'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPreferences_AccountCurrency1' AND TABLE_NAME='AccountPreferences')
BEGIN
		ALTER TABLE [dbo].[AccountPreferences]
			ADD CONSTRAINT [FK_AccountPreferences_AccountCurrency1]
			FOREIGN KEY ([AccountReimbursementCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId])
END
GO
-- Create Foreign Key FK_AccountExpenseEntry_AccountCurrency on AccountExpenseEntry
Print 'Create Foreign Key FK_AccountExpenseEntry_AccountCurrency on AccountExpenseEntry'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntry_AccountCurrency' AND TABLE_NAME='AccountExpenseEntry')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntry]
			ADD CONSTRAINT [FK_AccountExpenseEntry_AccountCurrency]
			FOREIGN KEY ([AccountCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId])
END
GO
-- Create Foreign Key FK_AccountExpenseEntry_AccountExpenseEntry on AccountExpenseEntry
Print 'Create Foreign Key FK_AccountExpenseEntry_AccountExpenseEntry on AccountExpenseEntry'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntry_AccountExpenseEntry' AND TABLE_NAME='AccountExpenseEntry')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntry]
			ADD CONSTRAINT [FK_AccountExpenseEntry_AccountExpenseEntry]
			FOREIGN KEY ([AccountExpenseEntryId]) REFERENCES [dbo].[AccountExpenseEntry] ([AccountExpenseEntryId])
END
GO
-- Create Foreign Key FK_AccountExpenseEntry_AccountPaymentMethod on AccountExpenseEntry
Print 'Create Foreign Key FK_AccountExpenseEntry_AccountPaymentMethod on AccountExpenseEntry'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntry_AccountPaymentMethod' AND TABLE_NAME='AccountExpenseEntry')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntry]
			ADD CONSTRAINT [FK_AccountExpenseEntry_AccountPaymentMethod]
			FOREIGN KEY ([AccountPaymentMethodId]) REFERENCES [dbo].[AccountPaymentMethod] ([AccountPaymentMethodId])
END
GO
-- Create Foreign Key FK_AccountPaymentMethod_Account on AccountPaymentMethod
Print 'Create Foreign Key FK_AccountPaymentMethod_Account on AccountPaymentMethod'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPaymentMethod_Account' AND TABLE_NAME='AccountPaymentMethod')
BEGIN
		ALTER TABLE [dbo].[AccountPaymentMethod]
			ADD CONSTRAINT [FK_AccountPaymentMethod_Account]
			FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId])
END
GO
-- Create Foreign Key FK_AccountPaymentMethod_MasterPaymentMethod on AccountPaymentMethod
Print 'Create Foreign Key FK_AccountPaymentMethod_MasterPaymentMethod on AccountPaymentMethod'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPaymentMethod_MasterPaymentMethod' AND TABLE_NAME='AccountPaymentMethod')
BEGIN
		ALTER TABLE [dbo].[AccountPaymentMethod]
			ADD CONSTRAINT [FK_AccountPaymentMethod_MasterPaymentMethod]
			FOREIGN KEY ([MasterPaymentMethodId]) REFERENCES [dbo].[MasterPaymentMethod] ([MasterPaymentMethodId])
END
GO
-- =======================================================
-- Foreign Key Constraint Nochecks's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Nochecks''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]

-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountCurrency]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountCurrency]'
IF NOT EXISTS (SELECT * FROM [dbo].[MasterAccountCurrency] WHERE [MasterAccountCurrencyId]=1 AND [MasterAccountCurrencyExchangeRateId]= 1 AND [SystemCurrencyId]=1)
BEGIN
INSERT INTO [dbo].[MasterAccountCurrency] ([MasterAccountCurrencyId], [MasterAccountCurrencyExchangeRateId], [SystemCurrencyId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[MasterAccountCurrency] ([MasterAccountCurrencyId], [MasterAccountCurrencyExchangeRateId], [SystemCurrencyId]) VALUES (2, 2, 28)
INSERT INTO [dbo].[MasterAccountCurrency] ([MasterAccountCurrencyId], [MasterAccountCurrencyExchangeRateId], [SystemCurrencyId]) VALUES (3, 3, 51)
INSERT INTO [dbo].[MasterAccountCurrency] ([MasterAccountCurrencyId], [MasterAccountCurrencyExchangeRateId], [SystemCurrencyId]) VALUES (4, 4, 75)
INSERT INTO [dbo].[MasterAccountCurrency] ([MasterAccountCurrencyId], [MasterAccountCurrencyExchangeRateId], [SystemCurrencyId]) VALUES (5, 5, 48)
INSERT INTO [dbo].[MasterAccountCurrency] ([MasterAccountCurrencyId], [MasterAccountCurrencyExchangeRateId], [SystemCurrencyId]) VALUES (6, 6, 9)
INSERT INTO [dbo].[MasterAccountCurrency] ([MasterAccountCurrencyId], [MasterAccountCurrencyExchangeRateId], [SystemCurrencyId]) VALUES (7, 7, 30)
END
-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountCurrencyExchangeRate]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountCurrencyExchangeRate]'
IF NOT EXISTS (SELECT * FROM [dbo].[MasterAccountCurrencyExchangeRate] WHERE [MasterAccountCurrencyExchangeRateId]= 1 AND [ExchangeRateEffectiveStartDate]='20080403 00:00:00.000' AND [ExchangeRateEffectiveEndDate] = '20090403 00:00:00.000' And [ExchangeRate]=1.0000 And [MasterAccountCurrencyId]=1)
BEGIN
INSERT INTO [dbo].[MasterAccountCurrencyExchangeRate] ([MasterAccountCurrencyExchangeRateId], [ExchangeRateEffectiveStartDate], [ExchangeRateEffectiveEndDate], [ExchangeRate], [MasterAccountCurrencyId]) VALUES (1, '20080403 00:00:00.000', '20090403 00:00:00.000', 1.0000, 1)
INSERT INTO [dbo].[MasterAccountCurrencyExchangeRate] ([MasterAccountCurrencyExchangeRateId], [ExchangeRateEffectiveStartDate], [ExchangeRateEffectiveEndDate], [ExchangeRate], [MasterAccountCurrencyId]) VALUES (2, '20080403 00:00:00.000', '20090403 00:00:00.000', 1.3370, 2)
INSERT INTO [dbo].[MasterAccountCurrencyExchangeRate] ([MasterAccountCurrencyExchangeRateId], [ExchangeRateEffectiveStartDate], [ExchangeRateEffectiveEndDate], [ExchangeRate], [MasterAccountCurrencyId]) VALUES (3, '20080403 00:00:00.000', '20090403 00:00:00.000', 0.5448, 3)
INSERT INTO [dbo].[MasterAccountCurrencyExchangeRate] ([MasterAccountCurrencyExchangeRateId], [ExchangeRateEffectiveStartDate], [ExchangeRateEffectiveEndDate], [ExchangeRate], [MasterAccountCurrencyId]) VALUES (4, '20080403 00:00:00.000', '20090403 00:00:00.000', 105.7290, 4)
INSERT INTO [dbo].[MasterAccountCurrencyExchangeRate] ([MasterAccountCurrencyExchangeRateId], [ExchangeRateEffectiveStartDate], [ExchangeRateEffectiveEndDate], [ExchangeRate], [MasterAccountCurrencyId]) VALUES (5, '20080403 00:00:00.000', '20090403 00:00:00.000', 0.7965, 5)
INSERT INTO [dbo].[MasterAccountCurrencyExchangeRate] ([MasterAccountCurrencyExchangeRateId], [ExchangeRateEffectiveStartDate], [ExchangeRateEffectiveEndDate], [ExchangeRate], [MasterAccountCurrencyId]) VALUES (6, '20080403 00:00:00.000', '20090403 00:00:00.000', 1.3136, 6)
INSERT INTO [dbo].[MasterAccountCurrencyExchangeRate] ([MasterAccountCurrencyExchangeRateId], [ExchangeRateEffectiveStartDate], [ExchangeRateEffectiveEndDate], [ExchangeRate], [MasterAccountCurrencyId]) VALUES (7, '20080403 00:00:00.000', '20090403 00:00:00.000', 1.2493, 7)
END
-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterPaymentMethod]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterPaymentMethod]'
IF NOT EXISTS (SELECT * FROM [dbo].[MasterPaymentMethod] WHERE [MasterPaymentMethodId]= 1 AND [PaymentMethod]='American Express')
BEGIN
INSERT INTO [dbo].[MasterPaymentMethod] ([MasterPaymentMethodId], [PaymentMethod]) VALUES (1, 'American Express')
INSERT INTO [dbo].[MasterPaymentMethod] ([MasterPaymentMethodId], [PaymentMethod]) VALUES (2, 'Cash')
INSERT INTO [dbo].[MasterPaymentMethod] ([MasterPaymentMethodId], [PaymentMethod]) VALUES (3, 'Master Card')
INSERT INTO [dbo].[MasterPaymentMethod] ([MasterPaymentMethodId], [PaymentMethod]) VALUES (4, 'Visa')
END
-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterTaxCode]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterTaxCode]'
IF NOT EXISTS (SELECT * FROM [dbo].[MasterTaxCode] WHERE [MasterTaxCodeId]= 1 AND [TaxCode]='Airport Tax' And [Formula]='10.00')
BEGIN
INSERT INTO [dbo].[MasterTaxCode] ([MasterTaxCodeId], [TaxCode], [Formula]) VALUES (1, 'Airport Tax', '10.00')
INSERT INTO [dbo].[MasterTaxCode] ([MasterTaxCodeId], [TaxCode], [Formula]) VALUES (2, 'GST', 'Net * 0.05')
INSERT INTO [dbo].[MasterTaxCode] ([MasterTaxCodeId], [TaxCode], [Formula]) VALUES (3, 'Hotel Tax', 'Net * 0.06')
INSERT INTO [dbo].[MasterTaxCode] ([MasterTaxCodeId], [TaxCode], [Formula]) VALUES (4, 'PST', 'Net * 0.07')
INSERT INTO [dbo].[MasterTaxCode] ([MasterTaxCodeId], [TaxCode], [Formula]) VALUES (5, 'State Sales Tax', 'Net * 0.065')
INSERT INTO [dbo].[MasterTaxCode] ([MasterTaxCodeId], [TaxCode], [Formula]) VALUES (6, 'VAT', 'Net * 0.15')
--INSERT INTO [dbo].[MasterTaxCode] ([MasterTaxCodeId], [TaxCode], [Formula]) VALUES (7, 'VAT', 'Net * 0.15')
END
-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemAttachmentType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemAttachmentType]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemAttachmentType] WHERE [SystemAttachmentTypeId]= 1 AND [SystemAttachmentType]='ExpenseEntry')
BEGIN
INSERT INTO [dbo].[SystemAttachmentType] ([SystemAttachmentTypeId], [SystemAttachmentType]) VALUES (1, 'ExpenseEntry')
END
-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPage] WHERE [SystemSecurityCategoryPageId] =104 AND [SystemSecurityCategoryId] = 1 AND [SequenceNumber] = '2130021023' AND [Folder] = 'AccountAdmin' AND [SystemCategoryPage] = 'AccountCurrencies.aspx' AND [SystemCategoryPageDescription] = 'Currencies' AND [ParentSystemSecurityCateogoryPageId] = 15 AND [IsSiteMapPage] = 1 AND [IsCustomizeable] = 1 AND [IsAllowAdd] = 1 AND [IsAllowEdit]=1 AND [IsAllowDelete]=1 AND [IsAllowList]=1 AND [IsShowDataOptions] is NULL AND [IsShowTillOptions]is NULL AND [IsSystemPage]is NULL AND [ControlLevelPermission]is NULL)
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (104, 1, '2130021023', 'AccountAdmin', 'AccountCurrencies.aspx', 'Currencies', 15, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (105, 1, '2130021024', 'AccountAdmin', 'AccountCurrencyExchangeRate.aspx', 'Exchange Rate', 15, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (106, 1, '2130021026', 'AccountAdmin', 'AccountPaymentMethod.aspx', 'Payment Method', 15, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (107, 1, '2130021027', 'AccountAdmin', 'AccountTaxCode.aspx', 'Tax Code', 15, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (108, 1, '2130021028', 'AccountAdmin', 'AccountAttachments.aspx', 'Attachments', 20, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
--INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (109, 2, '21300210', 'Employee', 'AccountEmployeeTimeEntryTimeCardView.aspx', 'Time Entry Time Card View', 18, 1, 1, 1, 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (110, 6, '21300211', 'Reports', 'UserHoursDetail.aspx', 'Department Wise Timesheet Report', 75, 1, 1, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (111, 6, '21300212', 'Reports', 'TaskSummary.aspx', 'Task Summary Report', 75, 1, 1, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL)
END

IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPage] WHERE [SystemCategoryPage] = 'UpdateCurrencies.aspx')
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (112, 1, '21300213', 'AccountAdmin', 'UpdateCurrencies.aspx', 'Update Currencies', 20, 1, 1, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (113, 1, '21300214', 'AccountAdmin', 'TimeSheetArchieve.aspx', 'Timesheet Archieve', 15, 1, 1, NULL, 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (114, 1, '21300215', 'AccountAdmin', 'ExpenseArchieve.aspx', 'Expense Archieve', 15, 1, 1, NULL, 1, 1, 1, NULL, NULL, NULL, NULL)
END

-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountExpenseType]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountExpenseType]'
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0, [MasterTaxCodeId]=1 WHERE [MasterAccountExpenseId]=1
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0, [MasterTaxCodeId]=2 WHERE [MasterAccountExpenseId]=2
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0 WHERE [MasterAccountExpenseId]=3
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0 WHERE [MasterAccountExpenseId]=4
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0 WHERE [MasterAccountExpenseId]=5
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0 WHERE [MasterAccountExpenseId]=6
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0 WHERE [MasterAccountExpenseId]=7
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0 WHERE [MasterAccountExpenseId]=8
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0 WHERE [MasterAccountExpenseId]=9
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0, [MasterTaxCodeId]=2 WHERE [MasterAccountExpenseId]=10
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0 WHERE [MasterAccountExpenseId]=11
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0, [MasterTaxCodeId]=2 WHERE [MasterAccountExpenseId]=12
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=0 WHERE [MasterAccountExpenseId]=13

-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountPreferences]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountPreferences]'

UPDATE [dbo].[MasterAccountPreferences] SET [AccountBaseCurrencyId]=1, [AccountReimbursementCurrencyId]=1 WHERE [MasterAccountPreferencesId]=1


-- =======================================================
-- Foreign Key Constraint Check's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Check''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]



GO
-- Drop View vueAccountExpenseWithTaxCode
Print 'Drop View vueAccountExpenseWithTaxCode'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseWithTaxCode' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseWithTaxCode]
GO
-- Drop View vueAccountExpenseEntryApprovalPending
Print 'Drop View vueAccountExpenseEntryApprovalPending'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntryApprovalPending]
GO
-- Drop View vueAccountExpenseEntryWithLastStatus
Print 'Drop View vueAccountExpenseEntryWithLastStatus'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryWithLastStatus' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntryWithLastStatus]
GO
-- Drop View vueAccountExpenseEntry
Print 'Drop View vueAccountExpenseEntry'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntry]
GO
-- Drop View vueAccountExpenseEntryApproval
Print 'Drop View vueAccountExpenseEntryApproval'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApproval' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntryApproval]
GO
-- Create View vueAccountExpenseEntryApproval
Print 'Create View vueAccountExpenseEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountExpenseEntry.AccountExpenseEntryId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, dbo.AccountExpenseEntry.Amount, 
                      dbo.AccountExpense.AccountExpenseName, dbo.AccountExpense.IsBillable, 
                      dbo.AccountExpenseEntry.AccountEmployeeId AS ExpenseEntryAccountEmployeeId, dbo.AccountExpenseEntry.Description, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountEmployee.EmailAddress
FROM         dbo.AccountExpense RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountExpenseEntry.AccountEmployeeId ON 
                      dbo.AccountExpense.AccountExpenseId = dbo.AccountExpenseEntry.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId'
GO
-- Create View vueAccountExpenseEntryApprovalPending
Print 'Create View vueAccountExpenseEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPending
AS
SELECT     dbo.vueAccountExpenseEntryApproval.AccountProjectId, dbo.vueAccountExpenseEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId, dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountExpenseEntryApproval.SystemApproverTypeId, dbo.vueAccountExpenseEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApproval.AccountEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId, dbo.vueAccountExpenseEntryApproval.ExpenseApprovalId, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.vueAccountExpenseEntryApproval.ProjectName, 
                      dbo.vueAccountExpenseEntryApproval.ProjectDescription, dbo.vueAccountExpenseEntryApproval.ProjectCode, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeName, dbo.vueAccountExpenseEntryApproval.Approved, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntryApproval.Comments, dbo.vueAccountExpenseEntryApproval.IsRejected, 
                      dbo.vueAccountExpenseEntryApproval.IsApproved, dbo.vueAccountExpenseEntryApproval.Amount, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseName, dbo.vueAccountExpenseEntryApproval.IsBillable, 
                      dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueAccountExpenseEntryApproval.ExpenseEntryAccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.Description, dbo.vueAccountExpenseEntryApproval.AccountId, dbo.vueAccountExpenseEntryApproval.EmailAddress
FROM         dbo.vueAccountExpenseEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId IN
                          (SELECT     TOP 1 AccountApprovalPathId
                            FROM          dbo.vueExpenseApprovalSequence AS vueExpenseApprovalSequence_1
                            WHERE      (ExpenseApprovalId IS NULL) AND (AccountExpenseEntryId = dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId)))'
GO
-- Create View vueAccountExpenseEntryApprovalPendingApprover
Print 'Create View vueAccountExpenseEntryApprovalPendingApprover'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPendingApprover' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingApprover
AS
SELECT     AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, AccountApprovalTypeId, 
                      SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, AccountExpenseEntryId, ExpenseApprovalId, 
                      ExpenseApprovalPathId, ProjectName, ProjectCode, ProjectDescription, EmployeeName, Approved, ExpenseApprovalTypeId, 
                      AccountExpenseEntryDate, Comments, IsRejected, IsApproved, Amount, AccountExpenseName, IsBillable, ExpenseEntryAccountEmployeeId, 
                      Description, AccountId, MaxApprovalPathSequence, 
                      CASE WHEN systemapprovertypeid = 1 THEN LeaderEmployeeId WHEN systemapprovertypeid = 2 THEN ProjectManagerEmployeeId WHEN systemapprovertypeid
                       = 3 THEN AccountEmployeeId WHEN systemapprovertypeid = 4 THEN AccountExternalUserId END AS ApproverEmployeeId, EmailAddress
FROM         dbo.vueAccountExpenseEntryApprovalPending'
GO
-- Create View vueAccountExpenseEntryApprovalPendingEmail
Print 'Create View vueAccountExpenseEntryApprovalPendingEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPendingEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingEmail
AS
SELECT     dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountProjectId, dbo.vueAccountExpenseEntryApprovalPendingApprover.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ProjectManagerEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ApprovalTypeName, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountApprovalPathId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountApprovalTypeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.SystemApproverTypeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountExpenseEntryId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ExpenseApprovalId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ExpenseApprovalPathId, dbo.vueAccountExpenseEntryApprovalPendingApprover.ProjectName, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ProjectCode, dbo.vueAccountExpenseEntryApprovalPendingApprover.ProjectDescription, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.EmployeeName, dbo.vueAccountExpenseEntryApprovalPendingApprover.Approved, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ExpenseApprovalTypeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.Comments, dbo.vueAccountExpenseEntryApprovalPendingApprover.IsRejected, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.IsApproved, dbo.vueAccountExpenseEntryApprovalPendingApprover.Amount, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountExpenseName, dbo.vueAccountExpenseEntryApprovalPendingApprover.IsBillable, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ExpenseEntryAccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.Description, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.MaxApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ApproverEmployeeId, dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountId,dbo.vueAccountExpenseEntryApprovalPendingApprover.EmailAddress
FROM         dbo.vueAccountExpenseEntryApprovalPendingApprover LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountProjectId = AccountEMailNotificationPreference_2.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.AccountId = AccountEMailNotificationPreference_1.AccountId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountExpenseEntryApprovalPendingApprover.ApproverEmployeeId = dbo.AccountEMailNotificationPreference.AccountEmployeeId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 26) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 27) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 28) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueAccountExpenseEntry
Print 'Create View vueAccountExpenseEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpense.AccountExpenseName, 
                      dbo.AccountProject.ProjectName, dbo.AccountExpenseEntry.AccountExpenseEntryId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountProjectId, 
                      dbo.AccountExpenseEntry.AccountExpenseId, dbo.AccountExpenseEntry.Amount, dbo.AccountExpenseEntry.TeamLeadApproved, 
                      dbo.AccountExpenseEntry.ProjectManagerApproved, dbo.AccountExpenseEntry.AdministratorApproved, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountExpenseEntry.CreatedOn, dbo.AccountExpenseEntry.CreatedByEmployeeId, dbo.AccountExpenseEntry.ModifiedOn, 
                      dbo.AccountExpenseEntry.ModifiedByEmployeeId, dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, 
                      dbo.AccountExpenseEntry.Description, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountExpenseTypeId, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountExpenseEntry.Reimburse, dbo.AccountExpenseEntry.AccountCurrencyId, 
                      dbo.SystemCurrency.CurrencyCode, dbo.AccountExpenseType.IsQuantityField, dbo.AccountTaxCode.TaxCode, 
                      dbo.AccountExpenseType.QuantityFieldCaption, dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountProject.TimeSheetApprovalTypeId, 
                      dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountExpenseEntry.TimeSheetApprovalPathId, 
                      dbo.AccountCurrencyExchangeRate.ExchangeRate
FROM         dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountCurrency INNER JOIN
                      dbo.AccountCurrencyExchangeRate ON 
                      dbo.AccountCurrency.AccountCurrencyExchangeRateId = dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId ON 
                      dbo.AccountExpenseEntry.AccountCurrencyId = dbo.AccountCurrency.AccountCurrencyId LEFT OUTER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId LEFT OUTER JOIN
                      dbo.AccountTaxCode RIGHT OUTER JOIN
                      dbo.AccountExpenseType ON dbo.AccountTaxCode.AccountTaxCodeId = dbo.AccountExpenseType.AccountTaxCodeId ON 
                      dbo.AccountExpense.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId'
GO
-- Create View vueAccountExpenseWithTaxCode
Print 'Create View vueAccountExpenseWithTaxCode'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseWithTaxCode' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseWithTaxCode
AS
SELECT     dbo.AccountExpense.AccountExpenseId, dbo.AccountExpense.AccountId, dbo.AccountExpenseType.AccountExpenseTypeId, 
                      dbo.AccountExpenseType.ExpenseType, dbo.AccountExpenseType.IsQuantityField, dbo.AccountExpenseType.QuantityFieldCaption, 
                      dbo.AccountExpenseType.AccountTaxCodeId, dbo.AccountTaxCode.Formula, dbo.AccountTaxCode.TaxCode
FROM         dbo.AccountExpense LEFT OUTER JOIN
                      dbo.AccountExpenseType ON dbo.AccountExpense.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountTaxCode ON dbo.AccountExpenseType.AccountTaxCodeId = dbo.AccountTaxCode.AccountTaxCodeId'
GO
-- Create View vueAccountExpenseEntryApprovalPendingEmailWithPreference
Print 'Create View vueAccountExpenseEntryApprovalPendingEmailWithPreference'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPendingEmailWithPreference' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntryApprovalPendingEmailWithPreference
AS
SELECT     dbo.vueAccountExpenseEntryApprovalPendingEmail.*, dbo.AccountEmployee.EMailAddress As ApproverEmailAddress, dbo.AccountPreferences.ScheduledEmailSendTime, 
                      dbo.AccountPreferences.LastScheduledEmailSentTime
FROM         dbo.vueAccountExpenseEntryApprovalPendingEmail LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.vueAccountExpenseEntryApprovalPendingEmail.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountExpenseEntryApprovalPendingEmail.ApproverEmployeeId = dbo.AccountEmployee.AccountEmployeeId'
GO
-- Create View vueAccountExpenseEntryApprovedEmail
Print 'Create View vueAccountExpenseEntryApprovedEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovedEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntryApprovedEmail
AS
SELECT     dbo.AccountEmployee.EMailAddress, dbo.vueAccountExpenseEntry.*, dbo.AccountExpenseEntryApproval.Comments
FROM         dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.vueAccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountExpenseEntry.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.vueAccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId ON 
                      AccountEMailNotificationPreference_1.AccountEmployeeId = dbo.vueAccountExpenseEntry.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountExpenseEntry.AccountProjectId = dbo.AccountEMailNotificationPreference.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountExpenseEntry.AccountId = AccountEMailNotificationPreference_2.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 22) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 20) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 21) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueAccountExpenseEntryWithLastStatus
Print 'Create View vueAccountExpenseEntryWithLastStatus'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryWithLastStatus' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntryWithLastStatus
AS
SELECT     dbo.vueAccountExpenseEntryWithLastAction.IsRejected, dbo.vueAccountExpenseEntryWithLastAction.IsApproved, 
                      dbo.vueAccountExpenseEntry.EmployeeName, dbo.vueAccountExpenseEntry.AccountExpenseName, dbo.vueAccountExpenseEntry.ProjectName, 
                      dbo.vueAccountExpenseEntry.AccountExpenseEntryId, dbo.vueAccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntry.AccountId, dbo.vueAccountExpenseEntry.AccountEmployeeId, dbo.vueAccountExpenseEntry.AccountProjectId, 
                      dbo.vueAccountExpenseEntry.AccountExpenseId, dbo.vueAccountExpenseEntry.Amount, dbo.vueAccountExpenseEntry.TeamLeadApproved, 
                      dbo.vueAccountExpenseEntry.ProjectManagerApproved, dbo.vueAccountExpenseEntry.AdministratorApproved, 
                      dbo.vueAccountExpenseEntry.Approved, dbo.vueAccountExpenseEntry.CreatedOn, dbo.vueAccountExpenseEntry.CreatedByEmployeeId, 
                      dbo.vueAccountExpenseEntry.ModifiedOn, dbo.vueAccountExpenseEntry.ModifiedByEmployeeId, dbo.vueAccountExpenseEntry.PartyName, 
                      dbo.vueAccountExpenseEntry.AccountClientId, dbo.vueAccountExpenseEntry.Description, dbo.vueAccountExpenseEntry.ExpenseType, 
                      dbo.vueAccountExpenseEntry.AccountExpenseTypeId, dbo.vueAccountExpenseEntry.LeaderEmployeeId, dbo.vueAccountExpenseEntry.IsBillable, 
                      dbo.vueAccountExpenseEntry.Rejected, dbo.vueAccountExpenseEntry.EmployeeCode, dbo.vueAccountExpenseEntry.Reimburse, 
                      dbo.vueAccountExpenseEntry.AccountCurrencyId, dbo.vueAccountExpenseEntry.CurrencyCode, dbo.vueAccountExpenseEntry.IsQuantityField, 
                      dbo.vueAccountExpenseEntry.TaxCode, dbo.vueAccountExpenseEntry.QuantityFieldCaption
FROM         dbo.vueAccountExpenseEntryWithLastAction RIGHT OUTER JOIN
                      dbo.vueAccountExpenseEntry ON 
                      dbo.vueAccountExpenseEntryWithLastAction.AccountExpenseEntryId = dbo.vueAccountExpenseEntry.AccountExpenseEntryId'
GO
-- Create View vueAccountExpenseEntryRejectedEmail
Print 'Create View vueAccountExpenseEntryRejectedEmail'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryRejectedEmail' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntryRejectedEmail
AS
SELECT     dbo.AccountEmployee.EMailAddress, dbo.AccountExpenseEntryApproval.Comments, dbo.vueAccountExpenseEntry.EmployeeName, 
                      dbo.vueAccountExpenseEntry.AccountExpenseName, dbo.vueAccountExpenseEntry.ProjectName, 
                      dbo.vueAccountExpenseEntry.AccountExpenseEntryId, dbo.vueAccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntry.AccountId, dbo.vueAccountExpenseEntry.AccountEmployeeId, dbo.vueAccountExpenseEntry.AccountProjectId, 
                      dbo.vueAccountExpenseEntry.AccountExpenseId, dbo.vueAccountExpenseEntry.Amount, dbo.vueAccountExpenseEntry.TeamLeadApproved, 
                      dbo.vueAccountExpenseEntry.ProjectManagerApproved, dbo.vueAccountExpenseEntry.AdministratorApproved, 
                      dbo.vueAccountExpenseEntry.Approved, dbo.vueAccountExpenseEntry.CreatedOn, dbo.vueAccountExpenseEntry.CreatedByEmployeeId, 
                      dbo.vueAccountExpenseEntry.ModifiedOn, dbo.vueAccountExpenseEntry.ModifiedByEmployeeId, dbo.vueAccountExpenseEntry.PartyName, 
                      dbo.vueAccountExpenseEntry.AccountClientId, dbo.vueAccountExpenseEntry.Description, dbo.vueAccountExpenseEntry.ExpenseType, 
                      dbo.vueAccountExpenseEntry.AccountExpenseTypeId, dbo.vueAccountExpenseEntry.LeaderEmployeeId, dbo.vueAccountExpenseEntry.IsBillable, 
                      dbo.vueAccountExpenseEntry.Rejected, dbo.vueAccountExpenseEntry.EmployeeCode, dbo.vueAccountExpenseEntry.Reimburse, 
                      dbo.vueAccountExpenseEntry.AccountCurrencyId, dbo.vueAccountExpenseEntry.CurrencyCode, dbo.vueAccountExpenseEntry.IsQuantityField, 
                      dbo.vueAccountExpenseEntry.TaxCode, dbo.vueAccountExpenseEntry.QuantityFieldCaption, 
                      dbo.vueAccountExpenseEntry.ProjectManagerEmployeeId, dbo.vueAccountExpenseEntry.TimeSheetApprovalTypeId, 
                      dbo.vueAccountExpenseEntry.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntry.TimeSheetApprovalPathId, 
                     dbo.vueAccountExpenseEntry.ExchangeRate
FROM         dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.vueAccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueAccountExpenseEntry.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.vueAccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId ON 
                      AccountEMailNotificationPreference_1.AccountEmployeeId = dbo.vueAccountExpenseEntry.AccountEmployeeId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference ON 
                      dbo.vueAccountExpenseEntry.AccountProjectId = dbo.AccountEMailNotificationPreference.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 ON 
                      dbo.vueAccountExpenseEntry.AccountId = AccountEMailNotificationPreference_2.AccountId
WHERE     (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 25) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND 
                      (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 23) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 24) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'
GO
-- Create View vueAccountExpenseEntryApprovalLastAction
Print 'Create View vueAccountExpenseEntryApprovalLastAction'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalLastAction' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntryApprovalLastAction
AS
SELECT     ExpenseApprovalId, AccountExpenseEntryId, ExpenseApprovalTypeId, ExpenseApprovalPathId, ApprovedByEmployeeId, ApprovedOn, Comments, 
                      IsRejected, IsApproved
FROM         dbo.AccountExpenseEntryApproval AS parent
WHERE     (ExpenseApprovalId =
                          (SELECT     MAX(ExpenseApprovalId) AS Expr1
                            FROM          dbo.AccountExpenseEntryApproval
                            WHERE      (AccountExpenseEntryId = parent.AccountExpenseEntryId)))'
GO

IF NOT EXISTS (SELECT * FROM [dbo].[SystemEMailNotification] WHERE [SystemEMailNotificationId] = 20 and [SystemEMailNotification] = 'Expense Entry Approved Notification' and [SystemEMailNotificationTypeId] = 1 and [Enabled] =1)
BEGIN
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (20, 'Expense Entry Approved Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (21, 'Expense Entry Approved Notification', 2, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (22, 'Expense Entry Approved Notification', 3, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (23, 'Expense Entry Rejected Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (24, 'Expense Entry Rejected Notification', 2, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (25, 'Expense Entry Rejected Notification', 3, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (26, 'Daily Expense Approval Pending Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (27, 'Daily Expense Approval Pending Notification', 2, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (28, 'Daily Expense Approval Pending Notification', 3, 1)
END

UPDATE [dbo].[MasterAccountExpenseType] SET [MasterTaxCodeId]=1 WHERE [MasterAccountExpenseId]=1
UPDATE [dbo].[MasterAccountExpenseType] SET [MasterTaxCodeId]=2 WHERE [MasterAccountExpenseId]=2
UPDATE [dbo].[MasterAccountExpenseType] SET [IsShowQuantityField]=1, [QuantityFieldCaption]='Miles/Kilometer' WHERE [MasterAccountExpenseId]=8
UPDATE [dbo].[MasterAccountExpenseType] SET [MasterTaxCodeId]=2 WHERE [MasterAccountExpenseId]=10
UPDATE [dbo].[MasterAccountExpenseType] SET [MasterTaxCodeId]=2 WHERE [MasterAccountExpenseId]=12

GO

-- Add Column AccountBaseCurrencyId to AccountExpenseEntry
Print 'Add Column AccountBaseCurrencyId to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='AccountBaseCurrencyId' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [AccountBaseCurrencyId] int NULL
GO

-- Add Column ExchangeRate to AccountExpenseEntry
Print 'Add Column ExchangeRate to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='ExchangeRate' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [ExchangeRate] float NULL
GO

-- Drop View vueAccountExpenseEntry
Print 'Drop View vueAccountExpenseEntry'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntry]
GO
-- Create View vueAccountExpenseEntry
Print 'Create View vueAccountExpenseEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpense.AccountExpenseName, 
                      dbo.AccountProject.ProjectName, dbo.AccountExpenseEntry.AccountExpenseEntryId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountProjectId, 
                      dbo.AccountExpenseEntry.AccountExpenseId, dbo.AccountExpenseEntry.Amount, dbo.AccountExpenseEntry.TeamLeadApproved, 
                      dbo.AccountExpenseEntry.ProjectManagerApproved, dbo.AccountExpenseEntry.AdministratorApproved, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountExpenseEntry.CreatedOn, dbo.AccountExpenseEntry.CreatedByEmployeeId, dbo.AccountExpenseEntry.ModifiedOn, 
                      dbo.AccountExpenseEntry.ModifiedByEmployeeId, dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, 
                      dbo.AccountExpenseEntry.Description, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountExpenseTypeId, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountExpenseEntry.Reimburse, dbo.AccountExpenseEntry.AccountCurrencyId, 
                      dbo.SystemCurrency.CurrencyCode, dbo.AccountExpenseType.IsQuantityField, dbo.AccountTaxCode.TaxCode, 
                      dbo.AccountExpenseType.QuantityFieldCaption, dbo.AccountExpenseEntry.AccountBaseCurrencyId, dbo.AccountExpenseEntry.ExchangeRate
FROM         dbo.AccountTaxCode RIGHT OUTER JOIN
                      dbo.AccountExpenseType ON dbo.AccountTaxCode.AccountTaxCodeId = dbo.AccountExpenseType.AccountTaxCodeId RIGHT OUTER JOIN
                      dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountCurrency ON dbo.AccountExpenseEntry.AccountCurrencyId = dbo.AccountCurrency.AccountCurrencyId LEFT OUTER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId ON 
                      dbo.AccountExpenseType.AccountExpenseTypeId = dbo.AccountExpense.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId'
GO

-- Drop View vueAccountEmployeeTimeEntry
Print 'Drop View vueAccountEmployeeTimeEntry'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntry' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntry]
GO
-- Create View vueAccountEmployeeTimeEntry
Print 'Create View vueAccountEmployeeTimeEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountEmployeeTimeEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountProject.ProjectName, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProject.AccountProjectId, dbo.AccountEmployeeTimeEntry.TeamLeadApproved, 
                      dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, dbo.AccountEmployeeTimeEntry.AdministratorApproved, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.Description, dbo.AccountProject.AccountId, DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, DATEPART(dw, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS WeekDay, dbo.AccountParty.AccountPartyId, dbo.AccountParty.PartyName, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountBillingType.BillingType, dbo.AccountProject.LeaderEmployeeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, 
                      dbo.AccountProjectTask.IsBillable, dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, 
                      dbo.AccountProject.ProjectBillingRateTypeId, dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.AccountDepartmentId, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId'
-- End 2.71.0002

-- Start 2.71.0003

GO

-- =======================================================
-- Foreign Key Constraint Nochecks's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Nochecks''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]


-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPage] WHERE [SystemCategoryPage] = 'UpdateCurrencies.aspx')
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (112, 1, '21300213', 'AccountAdmin', 'UpdateCurrencies.aspx', 'Update Currencies', 20, 1, 1, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (113, 1, '21300214', 'AccountAdmin', 'TimeSheetArchieve.aspx', 'Timesheet Archieve', 15, 1, 1, NULL, 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (114, 1, '21300215', 'AccountAdmin', 'ExpenseArchieve.aspx', 'Expense Archieve', 15, 1, 1, NULL, 1, 1, 1, NULL, NULL, NULL, NULL)
END


-- =======================================================
-- Foreign Key Constraint Check's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Check''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory]
ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]


GO

-- =======================================================
-- ALTER PROCEDURE [dbo].[_EmailMessage_GetPendingEmailMessage]
-- =======================================================
ALTER PROCEDURE [dbo].[_EmailMessage_GetPendingEmailMessage]
AS
SELECT  [ID], [ChangeStamp], [Priority], [Status], 
             [NumberOfRetry], [RetryTime], [MaximumRetry], 
             [ExpiryDatetime], [ArrivedDateTime], [SenderInfo], 
             [EmailTo], [EmailFrom], [EmailSubject], 
             [EmailBody], [EmailCC], [EmailBCC], [IsHtml]
FROM dbo.[EmailMessage]
WHERE  Status = 0 
ORDER BY Priority,RetryTime

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'

UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemSecurityCategoryId] = 1, [SequenceNumber] = '21300213', [Folder] = 'AccountAdmin', [SystemCategoryPage] = 'UpdateCurrencies.aspx', [SystemCategoryPageDescription] = 'Update Currencies', [ParentSystemSecurityCateogoryPageId] = 20, [IsSiteMapPage] = 1, [IsCustomizeable] = 1, [IsAllowAdd] = NULL, [IsAllowEdit] = 1, [IsAllowDelete] = NULL, [IsAllowList] = 1, [IsShowDataOptions] = NULL, [IsShowTillOptions] = NULL, [IsSystemPage] = NULL, [ControlLevelPermission] = NULL WHERE [SystemSecurityCategoryPageId] = 112
UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemSecurityCategoryId] = 1, [SequenceNumber] = '21300214', [Folder] = 'AccountAdmin', [SystemCategoryPage] = 'TimeEntryArchive.aspx', [SystemCategoryPageDescription] = 'Time Entry Archive', [ParentSystemSecurityCateogoryPageId] = 15, [IsSiteMapPage] = 1, [IsCustomizeable] = 1, [IsAllowAdd] = NULL, [IsAllowEdit] = 1, [IsAllowDelete] = 1, [IsAllowList] = 1, [IsShowDataOptions] = NULL, [IsShowTillOptions] = NULL, [IsSystemPage] = NULL, [ControlLevelPermission] = NULL WHERE [SystemSecurityCategoryPageId] = 113
UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemSecurityCategoryId] = 1, [SequenceNumber] = '21300215', [Folder] = 'AccountAdmin', [SystemCategoryPage] = 'ExpenseEntryArchive.aspx', [SystemCategoryPageDescription] = 'Expense Entry Archive', [ParentSystemSecurityCateogoryPageId] = 15, [IsSiteMapPage] = 1, [IsCustomizeable] = 1, [IsAllowAdd] = NULL, [IsAllowEdit] = 1, [IsAllowDelete] = 1, [IsAllowList] = 1, [IsShowDataOptions] = NULL, [IsShowTillOptions] = NULL, [IsSystemPage] = NULL, [ControlLevelPermission] = NULL WHERE [SystemSecurityCategoryPageId] = 114
UPDATE [dbo].[SystemSecurityCategoryPage] SET [SystemSecurityCategoryId] = 6, [SequenceNumber] = '21300211', [Folder] = 'Reports', [SystemCategoryPage] = 'DepartmentWiseTimesheetReport.aspx', [SystemCategoryPageDescription] = 'Department Wise Timesheet Report', [ParentSystemSecurityCateogoryPageId] = 75, [IsSiteMapPage] = 1, [IsCustomizeable] = 1, [IsAllowAdd] = NULL, [IsAllowEdit] = NULL, [IsAllowDelete] = NULL, [IsAllowList] = 1, [IsShowDataOptions] = 1, [IsShowTillOptions] = NULL, [IsSystemPage] = NULL, [ControlLevelPermission] = NULL WHERE [SystemSecurityCategoryPageId] = 110

-- Drop Foreign Key FK_AccountAttachments_AccountExpenseEntry from AccountAttachments
Print 'Drop Foreign Key FK_AccountAttachments_AccountExpenseEntry from AccountAttachments'
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountAttachments_AccountExpenseEntry' AND TABLE_NAME='AccountAttachments')
	ALTER TABLE [dbo].[AccountAttachments] DROP CONSTRAINT [FK_AccountAttachments_AccountExpenseEntry]
GO
-- Drop View vueAccountCurrency
Print 'Drop View vueAccountCurrency'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountCurrency' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountCurrency]
GO
-- Create View vueAccountCurrency
Print 'Create View vueAccountCurrency'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountCurrency' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountCurrency
AS
SELECT     dbo.SystemCurrency.CurrencyCode, dbo.SystemCurrency.Currency, dbo.AccountCurrency.Disabled, dbo.AccountCurrency.AccountId, 
                      dbo.AccountCurrency.AccountCurrencyId, dbo.AccountCurrencyExchangeRate.ExchangeRate, dbo.AccountCurrency.AccountCurrencyExchangeRateId, 
                      dbo.AccountCurrencyExchangeRate.ExchangeRateEffectiveStartDate, dbo.AccountCurrencyExchangeRate.ExchangeRateEffectiveEndDate
FROM         dbo.AccountCurrencyExchangeRate RIGHT OUTER JOIN
                      dbo.AccountCurrency ON 
                      dbo.AccountCurrencyExchangeRate.AccountCurrencyExchangeRateId = dbo.AccountCurrency.AccountCurrencyExchangeRateId LEFT OUTER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId'
GO
-- Create Foreign Key FK_AccountAttachments_AccountExpenseEntry on AccountAttachments
Print 'Create Foreign Key FK_AccountAttachments_AccountExpenseEntry on AccountAttachments'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountAttachments_AccountExpenseEntry' AND TABLE_NAME='AccountAttachments')
BEGIN
		ALTER TABLE [dbo].[AccountAttachments]
			ADD CONSTRAINT [FK_AccountAttachments_AccountExpenseEntry]
			FOREIGN KEY ([AccountExpenseEntryId]) REFERENCES [dbo].[AccountExpenseEntry] ([AccountExpenseEntryId])
			ON DELETE CASCADE
END 

GO

IF EXISTS(SELECT * FROM [dbo].[AccountProjectTask])
BEGIN
Update [dbo].[AccountProjectTask] Set [TaskCode] = Left(TaskCode,15)
END

GO

-- Alter Column TaskCode on AccountProjectTask
Print 'Alter Column TaskCode on AccountProjectTask'
GO
ALTER TABLE [dbo].[AccountProjectTask]
	 ALTER COLUMN [TaskCode] varchar(15) NULL

GO

--Update Duplicate AccountExpenseType Records
Update AccountExpenseType 
Set AccountTaxCodeId =
(select min(AccountTaxCodeId)
from AccountTaxCode
where AccountId = AccountExpenseType.AccountId and AccountTaxCodeId is not null 
and TaxCode = (select TaxCode from AccountTaxCode innertable 
where innertable.AccountTaxCodeId = AccountExpenseType.AccountTaxCodeId and AccountId = AccountExpenseType.AccountId))
where AccountId = AccountExpenseType.AccountId and AccountTaxCodeId is not null

GO

--Delete Duplicate AccountTaxCode Records
Delete From a From AccountTaxCode a, 
AccountTaxCode b where
a.taxcode = b.taxcode and a.accountid = b.accountid and
a.accounttaxcodeid > b.accounttaxcodeid

GO

-- Create Index IX_TaxCode on AccountTaxCode
Print 'Create Index IX_TaxCode on AccountTaxCode'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountTaxCode' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountTaxCode]') AND name = N'IX_TaxCode'))
CREATE UNIQUE INDEX [IX_TaxCode]
	ON [dbo].[AccountTaxCode] ([AccountId], [TaxCode])

GO

--Update Duplicate AccountExpenseEntry Records
Update AccountExpenseEntry 
Set AccountCurrencyId =
(select min(AccountCurrencyId)
from AccountCurrency
where AccountId = AccountExpenseEntry.AccountId and AccountCurrencyId is not null 
and SystemCurrencyId = (select SystemCurrencyId from AccountCurrency innertable 
where innertable.AccountCurrencyId = AccountExpenseEntry.AccountCurrencyId 
and AccountId = AccountExpenseEntry.AccountId))
where AccountId = AccountExpenseEntry.AccountId and AccountCurrencyId is not null

GO

--Update Duplicate AccountExpenseEntry Records
Update AccountExpenseEntry 
Set AccountBaseCurrencyId =
(select min(AccountCurrencyId)
from AccountCurrency
where AccountId = AccountExpenseEntry.AccountId and AccountCurrencyId is not null 
and SystemCurrencyId = (select SystemCurrencyId from AccountCurrency innertable 
where innertable.AccountCurrencyId = AccountExpenseEntry.AccountBaseCurrencyId
and AccountId = AccountExpenseEntry.AccountId))
where AccountId = AccountExpenseEntry.AccountId and AccountCurrencyId is not null

GO

--Update Duplicate AccountPreferences Records
Update AccountPreferences 
Set AccountBaseCurrencyId =
(select min(AccountCurrencyId)
from AccountCurrency
where AccountId = AccountPreferences.AccountId and AccountCurrencyId is not null 
and SystemCurrencyId = (select SystemCurrencyId from AccountCurrency innertable 
where innertable.AccountCurrencyId = AccountPreferences.AccountBaseCurrencyId
and AccountId = AccountPreferences.AccountId))
where AccountId = AccountPreferences.AccountId and AccountBaseCurrencyId is not null

GO

--Update Duplicate AccountPreferences Records
Update AccountPreferences 
Set AccountReimbursementCurrencyId =
(select min(AccountCurrencyId)
from AccountCurrency
where AccountId = AccountPreferences.AccountId and AccountCurrencyId is not null 
and SystemCurrencyId = (select SystemCurrencyId from AccountCurrency innertable 
where innertable.AccountCurrencyId = AccountPreferences.AccountReimbursementCurrencyId
and AccountId = AccountPreferences.AccountId))
where AccountId = AccountPreferences.AccountId and AccountReimbursementCurrencyId is not null

GO

--Delete Duplicate AccountCurrency Records
Delete From a From AccountCurrency a, 
AccountCurrency b where
a.SystemCurrencyId = b.SystemCurrencyId and a.accountid = b.accountid and
a.AccountCurrencyId > b.AccountCurrencyId

GO

-- Create Index IX_SystemCurrencyId on AccountCurrency
Print 'Create Index IX_SystemCurrencyId on AccountCurrency'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountCurrency' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountCurrency]') AND name = N'IX_SystemCurrencyId'))
CREATE UNIQUE INDEX [IX_SystemCurrencyId]
	ON [dbo].[AccountCurrency] ([AccountId], [SystemCurrencyId])

GO

--Update Duplicate AccountExpenseEntry Records
Update AccountExpenseEntry 
Set AccountPaymentMethodId =
(select min(AccountPaymentMethodId)
from AccountPaymentMethod
where AccountId = AccountPaymentMethod.AccountId and AccountPaymentMethodId is not null 
and PaymentMethod = (select PaymentMethod from AccountPaymentMethod innertable 
where innertable.AccountPaymentMethodId = AccountExpenseEntry.AccountPaymentMethodId
and AccountId = AccountExpenseEntry.AccountId))
where AccountId = AccountExpenseEntry.AccountId and AccountPaymentMethodId is not null

GO

--Delete Duplicate AccountPaymentMethod Records
Delete From a From AccountPaymentMethod a, 
AccountPaymentMethod b where
a.PaymentMethod = b.PaymentMethod and a.accountid = b.accountid and
a.AccountPaymentMethodId > b.AccountPaymentMethodId

GO

-- Create Index IX_AccountPaymentMethod on AccountPaymentMethod
Print 'Create Index IX_AccountPaymentMethod on AccountPaymentMethod'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPaymentMethod' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountPaymentMethod]') AND name = N'IX_AccountPaymentMethod'))
CREATE UNIQUE INDEX [IX_AccountPaymentMethod]
	ON [dbo].[AccountPaymentMethod] ([AccountId], [PaymentMethod])



GO

--Update Duplicate AccountTaxCode In AccountExpenseType Records
Update accountexpensetype Set AccountTaxCodeId = 
(select AccountTaxCodeId from AccountTaxCode where AccountId = accountexpensetype.AccountId and TaxCode = 
  (Select TaxCode from AccountTaxCode where AccountTaxCodeId = AccountExpenseType.AccountTaxCodeId))
where AccountId = accountexpensetype.AccountId

GO

--Update Duplicate AccountExpense Records
Update AccountExpense 
Set AccountExpenseTypeId =
(select min(AccountExpenseTypeId)
from AccountExpenseType
where AccountId = AccountExpense.AccountId and AccountExpenseTypeId is not null 
and ExpenseType = (select ExpenseType from AccountExpenseType innertable 
where innertable.AccountExpenseTypeId = AccountExpense.AccountExpenseTypeId
and AccountId = AccountExpense.AccountId))
where AccountId = AccountExpense.AccountId and AccountExpenseTypeId is not null

GO

--Delete Duplicate AccountExpenseType Records
Delete From a From AccountExpenseType a, 
AccountExpenseType b where
a.ExpenseType = b.ExpenseType and a.accountid = b.accountid and
a.AccountExpenseTypeId > b.AccountExpenseTypeId

GO

-- Create Index IX_AccountExpenseType on AccountExpenseType
Print 'Create Index IX_AccountExpenseType on AccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountExpenseType]') AND name = N'IX_AccountExpenseType'))
CREATE UNIQUE INDEX [IX_AccountExpenseType]
	ON [dbo].[AccountExpenseType] ([AccountId], [ExpenseType])

GO
-- Alter Column Currency on SystemCurrency
Print 'Alter Column Currency on SystemCurrency'
GO
ALTER TABLE [dbo].[SystemCurrency]
	 ALTER COLUMN [Currency] varchar(50) NOT NULL

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemCurrency]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemCurrency]'

UPDATE [dbo].[SystemCurrency] SET [Currency]='Netherlands Antilles Guilder' WHERE [CurrencyId]=6
UPDATE [dbo].[SystemCurrency] SET [Currency]='Aruba, Guilders' WHERE [CurrencyId]=10
UPDATE [dbo].[SystemCurrency] SET [Currency]='Azerbaijan, Manats' WHERE [CurrencyId]=11
UPDATE [dbo].[SystemCurrency] SET [Currency]='Bosnia and Herzegovina' WHERE [CurrencyId]=13
UPDATE [dbo].[SystemCurrency] SET [Currency]='Bulgaria, Lev' WHERE [CurrencyId]=16
UPDATE [dbo].[SystemCurrency] SET [Currency]='Brunei Darussalam, Dollars' WHERE [CurrencyId]=20
UPDATE [dbo].[SystemCurrency] SET [Currency]='Congo/Kinshasa, Congolais' WHERE [CurrencyId]=29
UPDATE [dbo].[SystemCurrency] SET [Currency]='Switzerland, Franc' WHERE [CurrencyId]=30
UPDATE [dbo].[SystemCurrency] SET [Currency]='Czech Republic, Koruna' WHERE [CurrencyId]=39
UPDATE [dbo].[SystemCurrency] SET [Currency]='Denmark, Krone' WHERE [CurrencyId]=41
UPDATE [dbo].[SystemCurrency] SET [Currency]='Dominican Republic, Peso' WHERE [CurrencyId]=42
UPDATE [dbo].[SystemCurrency] SET [Currency]='Algeria, Algeria Dinar' WHERE [CurrencyId]=43
UPDATE [dbo].[SystemCurrency] SET [Currency]='Estonia, Kroon' WHERE [CurrencyId]=44
UPDATE [dbo].[SystemCurrency] SET [Currency]='Euro Member Countries' WHERE [CurrencyId]=48
UPDATE [dbo].[SystemCurrency] SET [Currency]='Falkland Islands (Malvinas)' WHERE [CurrencyId]=50
UPDATE [dbo].[SystemCurrency] SET [Currency]='United Kingdom, Pounds' WHERE [CurrencyId]=51
UPDATE [dbo].[SystemCurrency] SET [Currency]='Iceland, Krona' WHERE [CurrencyId]=71
UPDATE [dbo].[SystemCurrency] SET [Currency]='Cayman Islands, Dollars' WHERE [CurrencyId]=83
UPDATE [dbo].[SystemCurrency] SET [Currency]='Myanmar (Burma), Kyat' WHERE [CurrencyId]=97
UPDATE [dbo].[SystemCurrency] SET [Currency]='Maldives, Rufiyaa' WHERE [CurrencyId]=103
UPDATE [dbo].[SystemCurrency] SET [Currency]='Papua New Guinea, Kina' WHERE [CurrencyId]=118
UPDATE [dbo].[SystemCurrency] SET [Currency]='Romania, Leu' WHERE [CurrencyId]=124
UPDATE [dbo].[SystemCurrency] SET [Currency]='Romania, New Leu' WHERE [CurrencyId]=125
UPDATE [dbo].[SystemCurrency] SET [Currency]='Rwanda, Rwanda Francs' WHERE [CurrencyId]=127
UPDATE [dbo].[SystemCurrency] SET [Currency]='Solomon Islands, Dollars' WHERE [CurrencyId]=129
UPDATE [dbo].[SystemCurrency] SET [Currency]='Sweden, Krona' WHERE [CurrencyId]=132
UPDATE [dbo].[SystemCurrency] SET [Currency]='Slovenia, Tolars' WHERE [CurrencyId]=135
UPDATE [dbo].[SystemCurrency] SET [Currency]='São Tome and Principe, Dobra' WHERE [CurrencyId]=141
UPDATE [dbo].[SystemCurrency] SET [Currency]='East Caribbean Dollars' WHERE [CurrencyId]=166
UPDATE [dbo].[SystemCurrency] SET [Currency]='FRENCH POLYNESIA, CFP Francs ' WHERE [CurrencyId]=170
UPDATE [dbo].[SystemCurrency] SET [Currency]='Zimbabwe, Zimbabwe Dollars' WHERE [CurrencyId]=175

GO
-- Create Table MasterAccountExpense
Print 'Create Table MasterAccountExpense'
GO
if not exists (select * from information_schema.tables where table_name = 'MasterAccountExpense' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[MasterAccountExpense] (
		[MasterExpenseId]         smallint NOT NULL,
		[Expense]                 varchar(50) NOT NULL,
		[MasterExpenseTypeId]     smallint NOT NULL
)
GO
-- Add Default Constraint DF_AccountExpense_CreatedOn to AccountExpense
Print 'Add Default Constraint DF_AccountExpense_CreatedOn to AccountExpense'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpense' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountExpense_CreatedOn'))
ALTER TABLE [dbo].[AccountExpense]
	ADD
	CONSTRAINT [DF_AccountExpense_CreatedOn]
	DEFAULT (getdate()) FOR [CreatedOn]
GO
-- Add Default Constraint DF_AccountExpense_ModifiedOn to AccountExpense
Print 'Add Default Constraint DF_AccountExpense_ModifiedOn to AccountExpense'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpense' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountExpense_ModifiedOn'))
ALTER TABLE [dbo].[AccountExpense]
	ADD
	CONSTRAINT [DF_AccountExpense_ModifiedOn]
	DEFAULT (getdate()) FOR [ModifiedOn]
GO

Delete from AccountExpenseEntry 
Where AccountProjectId not in (select AccountProjectId from AccountProject)

GO

-- Create Foreign Key FK_AccountExpenseEntry_AccountProject on AccountExpenseEntry
Print 'Create Foreign Key FK_AccountExpenseEntry_AccountProject on AccountExpenseEntry'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountExpenseEntry_AccountProject' AND TABLE_NAME='AccountExpenseEntry')
BEGIN
		ALTER TABLE [dbo].[AccountExpenseEntry]
			ADD CONSTRAINT [FK_AccountExpenseEntry_AccountProject]
			FOREIGN KEY ([AccountProjectId]) REFERENCES [dbo].[AccountProject] ([AccountProjectId])
END

GO

Update AccountExpenseType
set IsQuantityField = 0
where IsQuantityField is null

GO
-- Alter Column IsQuantityField on AccountExpenseType
Print 'Alter Column IsQuantityField on AccountExpenseType'
GO
ALTER TABLE [dbo].[AccountExpenseType]
	 ALTER COLUMN [IsQuantityField] bit NOT NULL
GO
-- Add Default Constraint DF_AccountExpenseType_IsQuantityField to AccountExpenseType
Print 'Add Default Constraint DF_AccountExpenseType_IsQuantityField to AccountExpenseType'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseType' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM sysobjects WHERE name= N'DF_AccountExpenseType_IsQuantityField'))
ALTER TABLE [dbo].[AccountExpenseType]
	ADD
	CONSTRAINT [DF_AccountExpenseType_IsQuantityField]
	DEFAULT ((0)) FOR [IsQuantityField]

GO
-- Create Index IX_AccountExpenseName on AccountExpense
Print 'Create Index IX_AccountExpenseName on AccountExpense'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpense' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountExpense]') AND name = N'IX_AccountExpenseName'))
CREATE UNIQUE INDEX [IX_AccountExpenseName]
	ON [dbo].[AccountExpense] ([AccountId], [AccountExpenseTypeId], [AccountExpenseName])

GO
-- Create View vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreference
Print 'Create View vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreference'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreference' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountEmployeeTimeEntryPendingNotificationEmailWithPreference
AS
SELECT     dbo.AccountPreferences.ScheduledEmailSendTime, dbo.AccountPreferences.LastScheduledEmailSentTime, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployee.AccountEmployeeId, 
                      dbo.AccountEmployee.AccountId, dbo.AccountEmployee.EMailAddress
FROM         dbo.AccountEMailNotificationPreference RIGHT OUTER JOIN
                      dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_2 RIGHT OUTER JOIN
                      dbo.AccountEmployee ON AccountEMailNotificationPreference_2.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId ON 
                      dbo.AccountEMailNotificationPreference.AccountId = dbo.AccountEmployee.AccountId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId
WHERE     (AccountEMailNotificationPreference_2.SystemEMailNotificationId = 30) AND (AccountEMailNotificationPreference_2.Enabled = 1) AND 
                      (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 29) AND (dbo.AccountEMailNotificationPreference.Enabled = 1)'

GO

-- =======================================================
-- Foreign Key Constraint Nochecks's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Nochecks''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] NOCHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPage] WHERE [SystemSecurityCategoryPageId] = '115' AND [SystemCategoryPage] = 'ProjectExpenseDetailReport.aspx')
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (115, 6, '21300216', 'Reports', 'ProjectExpenseDetailReport.aspx', 'Project Expense Detail Report', 75, 1, 1, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL)
END

GO
-- =======================================================
-- Foreign Key Constraint Check's for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print ' Foreign Key Constraint Check''s for Table: [dbo].[SystemSecurityCategoryPage]'

ALTER TABLE [dbo].[SystemSecurityCategoryPage] CHECK CONSTRAINT [FK_SystemSecurityCategoryPage_SystemSecurityCategory1]

GO

-- Drop View vueAccountExpenseEntry
Print 'Drop View vueAccountExpenseEntry'

GO

if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntry]

GO

if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimesheetSubmissionStatusALL' and table_type = 'VIEW') 
drop view vueAccountEmployeeTimesheetSubmissionStatusALL

GO

if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimesheetSubmissionStatus' and table_type = 'VIEW') 
Drop view vueAccountEmployeeTimesheetSubmissionStatus

GO

IF EXISTS(SELECT name FROM sysobjects WHERE name = 'InsertAbsentDate' AND type = 'P')
drop procedure InsertAbsentDate

GO

IF EXISTS(SELECT name FROM sysobjects WHERE name = 'CreateTableforAccountEmployeeTimesheetSubmissionStatus' AND type = 'P')
drop procedure CreateTableforAccountEmployeeTimesheetSubmissionStatus

GO

-- Create View vueAccountExpenseEntry
Print 'Create View vueAccountExpenseEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'
CREATE VIEW dbo.vueAccountExpenseEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpense.AccountExpenseName, 
                      dbo.AccountProject.ProjectName, dbo.AccountExpenseEntry.AccountExpenseEntryId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountProjectId, 
                      dbo.AccountExpenseEntry.AccountExpenseId, dbo.AccountExpenseEntry.Amount, dbo.AccountExpenseEntry.TeamLeadApproved, 
                      dbo.AccountExpenseEntry.ProjectManagerApproved, dbo.AccountExpenseEntry.AdministratorApproved, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountExpenseEntry.CreatedOn, dbo.AccountExpenseEntry.CreatedByEmployeeId, dbo.AccountExpenseEntry.ModifiedOn, 
                      dbo.AccountExpenseEntry.ModifiedByEmployeeId, dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, 
                      dbo.AccountExpenseEntry.Description, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountExpenseTypeId, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountExpenseEntry.Reimburse, dbo.AccountExpenseEntry.AccountCurrencyId, 
                      dbo.SystemCurrency.CurrencyCode, dbo.AccountExpenseType.IsQuantityField, dbo.AccountTaxCode.TaxCode, 
                      dbo.AccountExpenseType.QuantityFieldCaption, dbo.AccountExpenseEntry.AccountBaseCurrencyId, dbo.AccountExpenseEntry.ExchangeRate, 
                      ISNULL(dbo.AccountExpenseEntry.TaxAmount, 0) AS TaxAmount, ISNULL(dbo.AccountExpenseEntry.AmountBeforeTax, 0) AS NetAmount
FROM         dbo.AccountTaxCode RIGHT OUTER JOIN
                      dbo.AccountExpenseType ON dbo.AccountTaxCode.AccountTaxCodeId = dbo.AccountExpenseType.AccountTaxCodeId RIGHT OUTER JOIN
                      dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountCurrency ON dbo.AccountExpenseEntry.AccountCurrencyId = dbo.AccountCurrency.AccountCurrencyId LEFT OUTER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId ON 
                      dbo.AccountExpenseType.AccountExpenseTypeId = dbo.AccountExpense.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId'

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemEMailNotification]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemEMailNotification]'

IF NOT EXISTS (SELECT * FROM [dbo].[SystemEMailNotification] WHERE [SystemEMailNotificationId] = 29 and [SystemEMailNotification] = 'Daily TimeEntry Pending Notification' and [SystemEMailNotificationTypeId] = 1 and [Enabled] =1)
BEGIN
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (29, 'Daily TimeEntry Pending Notification', 1, 1)
INSERT INTO [dbo].[SystemEMailNotification] ([SystemEMailNotificationId], [SystemEMailNotification], [SystemEMailNotificationTypeId], [Enabled]) VALUES (30, 'Daily TimeEntry Pending Notification', 3, 1)
END

GO


Print 'Create View vueAccountEmployeeTimesheetSubmissionStatusALL'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimesheetSubmissionStatusALL' and table_type = 'VIEW') 
EXEC sp_executesql N'create view dbo.vueAccountEmployeeTimesheetSubmissionStatusALL as 
SELECT     dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.AccountDepartment.DepartmentName, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
                      0 AS NotEntered, SUM(1) AS Submitted, SUM(CASE WHEN Approved = 1 THEN 1 ELSE 0 END) AS Approved, SUM(CASE WHEN Rejected = 1 THEN 1 ELSE 0 END) 
                      AS Rejected, dbo.AccountRole.Role, dbo.vueAccountEmployeeTimeEntry.AccountId
FROM         dbo.vueAccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId
inner join dbo.AccountDepartment on dbo.accountemployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentID
GROUP BY dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountRole.Role, dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.AccountDepartment.DepartmentName'

GO

Print 'Create View vueAccountEmployeeTimesheetSubmissionStatus'
GO

if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimesheetSubmissionStatus' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE view [dbo].[vueAccountEmployeeTimesheetSubmissionStatus] as 
SELECT     AccountEmployeeId, EmployeeName,  DepartmentName,
                      TimeEntryDate, NotEntered, Submitted, Approved, 
Rejected, Role, 
                      AccountId
FROM         dbo.vueAccountEmployeeTimesheetSubmissionStatusALL'
 


GO

Print 'Create Stored Procedure InsertAbsentDate'
GO
create PROCEDURE [dbo].[InsertAbsentDate]
    (
@startdate datetime,    
@enddate datetime,
@AccountEmployeeID integer,
@AccountID integer
            )
AS

    SET NOCOUNT ON

IF NOT EXISTS (SELECT * FROM TEMPDB.dbo.sysobjects WHERE NAME = '##TEMP')
create table ##temp(AbsentDate datetime, 
AccountEmployeeID int,
AccountID int)


IF EXISTS (SELECT * FROM TEMPDB.dbo.sysobjects WHERE NAME = '##TEMP')
delete from ##TEMP where AccountID = @AccountID and AccountEmployeeID = @AccountEmployeeID

insert into ##temp(AbsentDate, AccountEmployeeID, AccountID) 
Select dateadd(day,number,@startdate), @AccountEmployeeID as AccountEmployeeID, @AccountID as AccountID 
from master.dbo.spt_values  where master.dbo.spt_values.type='p' 
and dateadd(day,number,@startdate)<=@enddate  
and dateadd(day,number,@startdate) 
not in  (select TimeEntryDate from vueAccountEmployeeTimesheetSubmissionStatus  
where  (AccountID = @AccountID) and  (AccountEmployeeId in (@AccountEmployeeID)) 
And  TimeEntryDate  >= @startdate 
and TimeEntryDate <= @enddate)

GO


Print 'Create Stored Procedure CreateTableforAccountEmployeeTimesheetSubmissionStatus'
GO
CREATE PROCEDURE [dbo].[CreateTableforAccountEmployeeTimesheetSubmissionStatus]
    (
@startdate datetime,    
@enddate datetime,
@AccountEmployeeID varchar,
@AccountID integer
            )
AS

    SET NOCOUNT ON

IF EXISTS (SELECT * FROM TEMPDB.dbo.sysobjects WHERE NAME = '##tempAccountEmployeeTimesheetSubmissionStatusALL')
drop table ##tempAccountEmployeeTimesheetSubmissionStatusALL 


create table ##tempAccountEmployeeTimesheetSubmissionStatusALL 
(AccountEmployeeID int,
EmployeeName varchar(200),
DepartmentName varchar(200),
TimeEntryDate datetime,
NotEntered int,
Submitted int,
Approved int,
Rejected int,
Role varchar(100),
AccountID int)


insert into ##tempAccountEmployeeTimesheetSubmissionStatusALL
(AccountEmployeeID,
EmployeeName,
DepartmentName, 
TimeEntryDate,
NotEntered,
Submitted,
Approved,
Rejected,
Role,
AccountID)
SELECT     dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, 
dbo.vueAccountEmployeeTimeEntry.EmployeeName, 
dbo.AccountDepartment.DepartmentName, 
                      dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
0 AS NotEntered, 
SUM(1) AS Submitted, 
SUM(CASE WHEN Approved = 1 THEN 1 ELSE 0 END) 
                      AS Approved, 
SUM(CASE WHEN Rejected = 1 THEN 1 ELSE 0 END) AS Rejected, 
dbo.AccountRole.Role, 
                      dbo.vueAccountEmployeeTimeEntry.AccountId
FROM         dbo.vueAccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId
                      inner join dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentID = dbo.AccountDepartment.AccountDepartmentID 
GROUP BY dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.AccountDepartment.DepartmentName,  
                      dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountRole.Role, dbo.vueAccountEmployeeTimeEntry.AccountId
UNION ALL
SELECT     dbo.##temp.AccountEmployeeID, dbo.AccountEmployee.FirstName + SPACE(1) + dbo.AccountEmployee.LastName AS Expr1, dbo.AccountDepartment.DepartmentName, 
                      dbo.##temp.AbsentDate AS TimeEntryDate, 1 AS NotEntered, 0 AS Submitted, 0 AS Approved, 0 AS Rejected, dbo.AccountRole.Role, 
                      dbo.##temp.AccountID
FROM         dbo.##temp INNER JOIN
                      dbo.AccountEmployee ON dbo.##temp.AccountEmployeeID = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId
                      inner join dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentID = dbo.AccountDepartment.AccountDepartmentID 
GROUP BY dbo.##temp.AccountEmployeeID, dbo.##temp.AbsentDate, dbo.AccountRole.Role, dbo.##temp.AccountID, 
                      dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountDepartment.DepartmentName

GO





-- Alter Column TaskCode on AccountProjectTask
Print 'Alter Column TaskCode on AccountProjectTask'
GO
ALTER TABLE [dbo].[SystemSecurityCategoryPage]
	 ALTER COLUMN [SystemCategoryPage] varchar(200)
GO


ALTER TABLE [dbo].[SystemSecurityCategoryPage]
	 ALTER COLUMN [SystemCategoryPageDescription] varchar(200)
GO




-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'
IF NOT EXISTS (SELECT * FROM [dbo].[SystemSecurityCategoryPage] WHERE [SystemSecurityCategoryPageId] = '116' AND [SystemCategoryPage] = 'AccountEmployeeTimesheetSubmissionStatusReport.aspx')
BEGIN
INSERT INTO [dbo].[SystemSecurityCategoryPage] ([SystemSecurityCategoryPageId], [SystemSecurityCategoryId], [SequenceNumber], [Folder], [SystemCategoryPage], [SystemCategoryPageDescription], [ParentSystemSecurityCateogoryPageId], [IsSiteMapPage], [IsCustomizeable], [IsAllowAdd], [IsAllowEdit], [IsAllowDelete], [IsAllowList], [IsShowDataOptions], [IsShowTillOptions], [IsSystemPage], [ControlLevelPermission]) VALUES (116, 6, '2130021029', 'Reports', 'AccountEmployeeTimesheetSubmissionStatusReport.aspx', 'Account Employee Timesheet Submission Status Report', 75, 1, 1, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL)
END

GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[MasterAccountExpense]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[MasterAccountExpense]'
IF NOT EXISTS (SELECT * FROM [dbo].[MasterAccountExpense] WHERE [MasterExpenseId] = '1' AND [Expense] =  'Air Travel' AND [MasterExpenseTypeId] = '1')
BEGIN
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (1, 'Air Travel', 1)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (2, 'Hotel', 2)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (3, 'Auto Rental', 3)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (4, 'Taxi', 4)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (5, 'Telephone', 5)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (6, 'Parking', 6)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (7, 'Tolls', 7)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (8, 'Car Mileage', 8)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (9, 'Gas', 9)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (10, 'Food', 10)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (11, 'Supplies', 11)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (12, 'Entertainment', 12)
INSERT INTO [dbo].[MasterAccountExpense] ([MasterExpenseId], [Expense], [MasterExpenseTypeId]) VALUES (13, 'Others', 13)
END

GO

-- Drop Foreign Key FK_AccountProjectRole_AccountRole from AccountProjectRole
Print 'Drop Foreign Key FK_AccountProjectRole_AccountRole from AccountProjectRole'
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProjectRole_AccountRole' AND TABLE_NAME='AccountProjectRole')
ALTER TABLE [dbo].[AccountProjectRole] DROP CONSTRAINT [FK_AccountProjectRole_AccountRole]

GO

-- Drop Foreign Key FK_AccountPagePermission_Account from AccountPagePermission
Print 'Drop Foreign Key FK_AccountPagePermission_Account from AccountPagePermission'
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPagePermission_Account' AND TABLE_NAME='AccountPagePermission')
ALTER TABLE [dbo].[AccountPagePermission] DROP CONSTRAINT [FK_AccountPagePermission_Account]
GO

-- Drop Foreign Key FK_AccountEmployee_AccountRole from AccountEmployee
Print 'Drop Foreign Key FK_AccountEmployee_AccountRole from AccountEmployee'
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployee_AccountRole' AND TABLE_NAME='AccountEmployee')
ALTER TABLE [dbo].[AccountEmployee] DROP CONSTRAINT [FK_AccountEmployee_AccountRole]
GO

-- Drop Foreign Key FK_AccountPagePermission_AccountRole from AccountPagePermission
Print 'Drop Foreign Key FK_AccountPagePermission_AccountRole from AccountPagePermission'
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPagePermission_AccountRole' AND TABLE_NAME='AccountPagePermission')
ALTER TABLE [dbo].[AccountPagePermission] DROP CONSTRAINT [FK_AccountPagePermission_AccountRole]
GO

-- Create Foreign Key FK_AccountProjectRole_AccountRole on AccountProjectRole
Print 'Create Foreign Key FK_AccountProjectRole_AccountRole on AccountProjectRole'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountProjectRole_AccountRole' AND TABLE_NAME='AccountProjectRole')
BEGIN
		ALTER TABLE [dbo].[AccountProjectRole]
			ADD CONSTRAINT [FK_AccountProjectRole_AccountRole]
			FOREIGN KEY ([AccountRoleId]) REFERENCES [dbo].[AccountRole] ([AccountRoleId])
END
GO

-- Create Foreign Key FK_AccountEmployee_AccountRole on AccountEmployee
Print 'Create Foreign Key FK_AccountEmployee_AccountRole on AccountEmployee'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountEmployee_AccountRole' AND TABLE_NAME='AccountEmployee')
BEGIN
		ALTER TABLE [dbo].[AccountEmployee]
			ADD CONSTRAINT [FK_AccountEmployee_AccountRole]
			FOREIGN KEY ([AccountRoleId]) REFERENCES [dbo].[AccountRole] ([AccountRoleId])
END
GO

-- Create Foreign Key FK_AccountPagePermission_Account on AccountPagePermission
Print 'Create Foreign Key FK_AccountPagePermission_Account on AccountPagePermission'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPagePermission_Account' AND TABLE_NAME='AccountPagePermission')
BEGIN
		ALTER TABLE [dbo].[AccountPagePermission]
			ADD CONSTRAINT [FK_AccountPagePermission_Account]
			FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId])
END
GO

-- Create Foreign Key FK_AccountPagePermission_AccountRole on AccountPagePermission
Print 'Create Foreign Key FK_AccountPagePermission_AccountRole on AccountPagePermission'
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA='dbo' AND CONSTRAINT_NAME='FK_AccountPagePermission_AccountRole' AND TABLE_NAME='AccountPagePermission')
BEGIN
		ALTER TABLE [dbo].[AccountPagePermission]
			ADD CONSTRAINT [FK_AccountPagePermission_AccountRole]
			FOREIGN KEY ([AccountRoleId]) REFERENCES [dbo].[AccountRole] ([AccountRoleId])
			ON DELETE CASCADE
END

GO

-- Drop View vueAccountEmployeeTimeEntryWithLastStatus
Print 'Drop View vueAccountEmployeeTimeEntryWithLastStatus'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithLastStatus' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryWithLastStatus]
GO

-- Drop View vueAccountExpenseEntryWithLastStatus
Print 'Drop View vueAccountExpenseEntryWithLastStatus'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryWithLastStatus' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntryWithLastStatus]
GO

-- Drop View vueAccountExpenseEntry
Print 'Drop View vueAccountExpenseEntry'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntry]
GO

-- Drop View vueAccountEmployeeTimeEntry
Print 'Drop View vueAccountEmployeeTimeEntry'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntry' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntry]
GO

-- Drop View vueAccountExpenseEntryApprovalPending
Print 'Drop View vueAccountExpenseEntryApprovalPending'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntryApprovalPending]
GO

-- Drop View vueAccountEmployeeTimeEntryApprovalPending
Print 'Drop View vueAccountEmployeeTimeEntryApprovalPending'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPending' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApprovalPending]
GO

-- Drop View vueAccountExpenseEntryApproval
Print 'Drop View vueAccountExpenseEntryApproval'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApproval' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountExpenseEntryApproval]
GO

-- Drop View vueAccountEmployeeTimeEntryApproval
Print 'Drop View vueAccountEmployeeTimeEntryApproval'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApproval' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimeEntryApproval]
GO

-- Add Column Submitted to AccountEmployeeTimeEntry
Print 'Add Column Submitted to AccountEmployeeTimeEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Submitted' AND TABLE_NAME='AccountEmployeeTimeEntry'))
ALTER TABLE [dbo].[AccountEmployeeTimeEntry]
	ADD [Submitted] bit NULL

GO

-- Create Index IX_Submitted on AccountEmployeeTimeEntry
Print 'Create Index IX_Submitted on AccountEmployeeTimeEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountEmployeeTimeEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountEmployeeTimeEntry]') AND name = N'IX_Submitted'))
CREATE INDEX [IX_Submitted]
	ON [dbo].[AccountEmployeeTimeEntry] ([Submitted])
GO

-- Add Column Submitted to AccountExpenseEntry
Print 'Add Column Submitted to AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='Submitted' AND TABLE_NAME='AccountExpenseEntry'))
ALTER TABLE [dbo].[AccountExpenseEntry]
	ADD [Submitted] bit NULL

GO

-- Create Index IX_Submitted on AccountExpenseEntry
Print 'Create Index IX_Submitted on AccountExpenseEntry'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountExpenseEntry' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[AccountExpenseEntry]') AND name = N'IX_Submitted'))
CREATE INDEX [IX_Submitted]
	ON [dbo].[AccountExpenseEntry] ([Submitted])
GO

-- Create View vueAccountEmployeeTimeEntryApproval
Print 'Create View vueAccountEmployeeTimeEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, 
                      dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalId, dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, 
                      dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, dbo.AccountProjectTask.TaskName, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.TaskDescription, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountEmployeeTimeEntryApproval.Comments, dbo.AccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.AccountEmployeeTimeEntryApproval.IsApproved, dbo.AccountEmployeeTimeEntry.AccountEmployeeId AS TimeEntryAccountEmployeeId, 
                      dbo.AccountEmployee.EMailAddress, dbo.AccountEmployee.AccountId, dbo.AccountEmployeeTimeEntry.Description, 
                      dbo.AccountEmployeeTimeEntry.Submitted
FROM         dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.TimeSheetApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountProjectTask INNER JOIN
                      dbo.AccountEmployeeTimeEntry ON dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId ON 
                      dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployeeTimeEntryApproval ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId'
GO

-- Create View vueAccountExpenseEntryApproval
Print 'Create View vueAccountExpenseEntryApproval'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApproval' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryApproval
AS
SELECT     dbo.AccountProject.AccountProjectId, dbo.AccountProject.LeaderEmployeeId, dbo.AccountProject.ProjectManagerEmployeeId, 
                      dbo.AccountApprovalType.ApprovalTypeName, dbo.AccountApprovalPath.AccountApprovalPathId, dbo.AccountApprovalPath.AccountApprovalTypeId, 
                      dbo.AccountApprovalPath.SystemApproverTypeId, dbo.AccountApprovalPath.AccountExternalUserId, dbo.AccountApprovalPath.AccountEmployeeId, 
                      dbo.AccountApprovalPath.ApprovalPathSequence, dbo.AccountExpenseEntry.AccountExpenseEntryId, 
                      dbo.AccountExpenseEntryApproval.ExpenseApprovalId, dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.AccountProject.ProjectName, 
                      dbo.AccountProject.ProjectDescription, dbo.AccountProject.ProjectCode, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountProject.ExpenseApprovalTypeId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, dbo.AccountExpenseEntryApproval.Comments, 
                      dbo.AccountExpenseEntryApproval.IsRejected, dbo.AccountExpenseEntryApproval.IsApproved, dbo.AccountExpenseEntry.Amount, 
                      dbo.AccountExpense.AccountExpenseName, dbo.AccountExpense.IsBillable, 
                      dbo.AccountExpenseEntry.AccountEmployeeId AS ExpenseEntryAccountEmployeeId, dbo.AccountExpenseEntry.Description, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountEmployee.EMailAddress, dbo.AccountExpenseEntry.Submitted
FROM         dbo.AccountExpense RIGHT OUTER JOIN
                      dbo.AccountEmployee INNER JOIN
                      dbo.AccountExpenseEntry ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountExpenseEntry.AccountEmployeeId ON 
                      dbo.AccountExpense.AccountExpenseId = dbo.AccountExpenseEntry.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountProject INNER JOIN
                      dbo.AccountApprovalType ON dbo.AccountProject.ExpenseApprovalTypeId = dbo.AccountApprovalType.AccountApprovalTypeId INNER JOIN
                      dbo.AccountApprovalPath ON dbo.AccountApprovalType.AccountApprovalTypeId = dbo.AccountApprovalPath.AccountApprovalTypeId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountExpenseEntryApproval ON 
                      dbo.AccountExpenseEntry.AccountExpenseEntryId = dbo.AccountExpenseEntryApproval.AccountExpenseEntryId AND 
                      dbo.AccountApprovalPath.AccountApprovalPathId = dbo.AccountExpenseEntryApproval.ExpenseApprovalPathId'
GO

-- Create View vueAccountEmployeeTimeEntryApprovalPending
Print 'Create View vueAccountEmployeeTimeEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryApprovalPending
AS
SELECT     dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectId, dbo.vueAccountEmployeeTimeEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.SystemApproverTypeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalPathId, dbo.vueAccountEmployeeTimeEntryApproval.ProjectName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.ProjectDescription, dbo.vueAccountEmployeeTimeEntryApproval.ProjectCode, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskName, dbo.vueAccountEmployeeTimeEntryApproval.AccountProjectTaskId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TaskDescription, dbo.vueAccountEmployeeTimeEntryApproval.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Approved, dbo.vueAccountEmployeeTimeEntryApproval.TimeSheetApprovalTypeId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TotalTime, dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryDate, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Comments, dbo.vueAccountEmployeeTimeEntryApproval.IsReject, 
                      dbo.vueAccountEmployeeTimeEntryApproval.IsApproved, dbo.vueAccountApproverType.MaxApprovalPathSequence, 
                      dbo.vueAccountEmployeeTimeEntryApproval.TimeEntryAccountEmployeeId, dbo.vueAccountEmployeeTimeEntryApproval.AccountId, 
                      dbo.vueAccountEmployeeTimeEntryApproval.EMailAddress, dbo.vueAccountEmployeeTimeEntryApproval.Description, 
                      dbo.vueAccountEmployeeTimeEntryApproval.Submitted
FROM         dbo.vueAccountEmployeeTimeEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountEmployeeTimeEntryApproval.AccountApprovalPathId IN
                          (SELECT     TOP 1 AccountApprovalPathId
                            FROM          dbo.vueTimesheetApprovalSequence
                            WHERE      (TimeSheetApprovalId IS NULL) AND 
                                                   (AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApproval.AccountEmployeeTimeEntryId)))'
GO

-- Create View vueAccountExpenseEntryApprovalPending
Print 'Create View vueAccountExpenseEntryApprovalPending'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryApprovalPending' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryApprovalPending
AS
SELECT     dbo.vueAccountExpenseEntryApproval.AccountProjectId, dbo.vueAccountExpenseEntryApproval.LeaderEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.ProjectManagerEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalTypeName, 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId, dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId, 
                      dbo.vueAccountExpenseEntryApproval.SystemApproverTypeId, dbo.vueAccountExpenseEntryApproval.AccountExternalUserId, 
                      dbo.vueAccountExpenseEntryApproval.AccountEmployeeId, dbo.vueAccountExpenseEntryApproval.ApprovalPathSequence, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId, dbo.vueAccountExpenseEntryApproval.ExpenseApprovalId, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalPathId, dbo.vueAccountExpenseEntryApproval.ProjectName, 
                      dbo.vueAccountExpenseEntryApproval.ProjectDescription, dbo.vueAccountExpenseEntryApproval.ProjectCode, 
                      dbo.vueAccountExpenseEntryApproval.EmployeeName, dbo.vueAccountExpenseEntryApproval.Approved, 
                      dbo.vueAccountExpenseEntryApproval.ExpenseApprovalTypeId, dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntryApproval.Comments, dbo.vueAccountExpenseEntryApproval.IsRejected, 
                      dbo.vueAccountExpenseEntryApproval.IsApproved, dbo.vueAccountExpenseEntryApproval.Amount, 
                      dbo.vueAccountExpenseEntryApproval.AccountExpenseName, dbo.vueAccountExpenseEntryApproval.IsBillable, 
                      dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueAccountExpenseEntryApproval.ExpenseEntryAccountEmployeeId, 
                      dbo.vueAccountExpenseEntryApproval.Description, dbo.vueAccountExpenseEntryApproval.AccountId, 
                      dbo.vueAccountExpenseEntryApproval.EMailAddress, dbo.vueAccountExpenseEntryApproval.Submitted
FROM         dbo.vueAccountExpenseEntryApproval INNER JOIN
                      dbo.vueAccountApproverType ON 
                      dbo.vueAccountExpenseEntryApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId
WHERE     (dbo.vueAccountExpenseEntryApproval.AccountApprovalPathId IN
                          (SELECT     TOP 1 AccountApprovalPathId
                            FROM          dbo.vueExpenseApprovalSequence AS vueExpenseApprovalSequence_1
                            WHERE      (ExpenseApprovalId IS NULL) AND (AccountExpenseEntryId = dbo.vueAccountExpenseEntryApproval.AccountExpenseEntryId)))'
GO

-- Create View vueAccountEmployeeTimeEntry
Print 'Create View vueAccountEmployeeTimeEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountProject.ProjectName, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountEmployee.AccountEmployeeId, dbo.AccountProject.AccountProjectId, dbo.AccountEmployeeTimeEntry.TeamLeadApproved, 
                      dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, dbo.AccountEmployeeTimeEntry.AdministratorApproved, 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.Description, dbo.AccountProject.AccountId, DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) AS TotalMinutes, DATEPART(dw, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS WeekDay, dbo.AccountParty.AccountPartyId, dbo.AccountParty.PartyName, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountBillingType.BillingType, dbo.AccountProject.LeaderEmployeeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, 
                      dbo.AccountProjectTask.IsBillable, dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, 
                      dbo.AccountProject.ProjectBillingRateTypeId, dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.AccountDepartmentId, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountProjectTask.EstimatedCost, dbo.AccountProjectTask.EstimatedTimeSpent, 
                      dbo.AccountEmployeeTimeEntry.Submitted
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId'
GO

-- Create View vueAccountExpenseEntry
Print 'Create View vueAccountExpenseEntry'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntry' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntry
AS
SELECT     dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountExpense.AccountExpenseName, 
                      dbo.AccountProject.ProjectName, dbo.AccountExpenseEntry.AccountExpenseEntryId, dbo.AccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.AccountExpenseEntry.AccountId, dbo.AccountExpenseEntry.AccountEmployeeId, dbo.AccountExpenseEntry.AccountProjectId, 
                      dbo.AccountExpenseEntry.AccountExpenseId, dbo.AccountExpenseEntry.Amount, dbo.AccountExpenseEntry.TeamLeadApproved, 
                      dbo.AccountExpenseEntry.ProjectManagerApproved, dbo.AccountExpenseEntry.AdministratorApproved, dbo.AccountExpenseEntry.Approved, 
                      dbo.AccountExpenseEntry.CreatedOn, dbo.AccountExpenseEntry.CreatedByEmployeeId, dbo.AccountExpenseEntry.ModifiedOn, 
                      dbo.AccountExpenseEntry.ModifiedByEmployeeId, dbo.AccountParty.PartyName, dbo.AccountProject.AccountClientId, 
                      dbo.AccountExpenseEntry.Description, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountExpenseTypeId, 
                      dbo.AccountProject.LeaderEmployeeId, dbo.AccountExpenseEntry.IsBillable, dbo.AccountExpenseEntry.Rejected, 
                      dbo.AccountEmployee.EmployeeCode, dbo.AccountExpenseEntry.Reimburse, dbo.AccountExpenseEntry.AccountCurrencyId, 
                      dbo.SystemCurrency.CurrencyCode, dbo.AccountExpenseType.IsQuantityField, dbo.AccountTaxCode.TaxCode, 
                      dbo.AccountExpenseType.QuantityFieldCaption, dbo.AccountExpenseEntry.AccountBaseCurrencyId, dbo.AccountExpenseEntry.ExchangeRate, 
                      ISNULL(dbo.AccountExpenseEntry.TaxAmount, 0) AS TaxAmount, ISNULL(dbo.AccountExpenseEntry.AmountBeforeTax, 0) AS NetAmount, 
                      dbo.AccountExpenseEntry.Submitted, dbo.AccountProject.TimeSheetApprovalTypeId, dbo.AccountProject.ExpenseApprovalTypeId, 
                      dbo.AccountProject.ProjectManagerEmployeeId, dbo.AccountExpenseEntry.TimeSheetApprovalPathId
FROM         dbo.AccountTaxCode RIGHT OUTER JOIN
                      dbo.AccountExpenseType ON dbo.AccountTaxCode.AccountTaxCodeId = dbo.AccountExpenseType.AccountTaxCodeId RIGHT OUTER JOIN
                      dbo.AccountExpenseEntry INNER JOIN
                      dbo.AccountExpense ON dbo.AccountExpenseEntry.AccountExpenseId = dbo.AccountExpense.AccountExpenseId LEFT OUTER JOIN
                      dbo.AccountCurrency ON dbo.AccountExpenseEntry.AccountCurrencyId = dbo.AccountCurrency.AccountCurrencyId LEFT OUTER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId ON 
                      dbo.AccountExpenseType.AccountExpenseTypeId = dbo.AccountExpense.AccountExpenseTypeId LEFT OUTER JOIN
                      dbo.AccountProject LEFT OUTER JOIN
                      dbo.AccountParty ON dbo.AccountProject.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountExpenseEntry.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                      dbo.AccountEmployee ON dbo.AccountExpenseEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId'
GO

-- Create View vueAccountExpenseEntryWithLastStatus
Print 'Create View vueAccountExpenseEntryWithLastStatus'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountExpenseEntryWithLastStatus' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountExpenseEntryWithLastStatus
AS
SELECT     dbo.vueAccountExpenseEntryWithLastAction.IsRejected, dbo.vueAccountExpenseEntryWithLastAction.IsApproved, 
                      dbo.vueAccountExpenseEntry.EmployeeName, dbo.vueAccountExpenseEntry.AccountExpenseName, dbo.vueAccountExpenseEntry.ProjectName, 
                      dbo.vueAccountExpenseEntry.AccountExpenseEntryId, dbo.vueAccountExpenseEntry.AccountExpenseEntryDate, 
                      dbo.vueAccountExpenseEntry.AccountId, dbo.vueAccountExpenseEntry.AccountEmployeeId, dbo.vueAccountExpenseEntry.AccountProjectId, 
                      dbo.vueAccountExpenseEntry.AccountExpenseId, dbo.vueAccountExpenseEntry.Amount, dbo.vueAccountExpenseEntry.TeamLeadApproved, 
                      dbo.vueAccountExpenseEntry.ProjectManagerApproved, dbo.vueAccountExpenseEntry.AdministratorApproved, 
                      dbo.vueAccountExpenseEntry.Approved, dbo.vueAccountExpenseEntry.CreatedOn, dbo.vueAccountExpenseEntry.CreatedByEmployeeId, 
                      dbo.vueAccountExpenseEntry.ModifiedOn, dbo.vueAccountExpenseEntry.ModifiedByEmployeeId, dbo.vueAccountExpenseEntry.PartyName, 
                      dbo.vueAccountExpenseEntry.AccountClientId, dbo.vueAccountExpenseEntry.Description, dbo.vueAccountExpenseEntry.ExpenseType, 
                      dbo.vueAccountExpenseEntry.AccountExpenseTypeId, dbo.vueAccountExpenseEntry.LeaderEmployeeId, dbo.vueAccountExpenseEntry.IsBillable, 
                      dbo.vueAccountExpenseEntry.Rejected, dbo.vueAccountExpenseEntry.EmployeeCode, dbo.vueAccountExpenseEntry.Reimburse, 
                      dbo.vueAccountExpenseEntry.AccountCurrencyId, dbo.vueAccountExpenseEntry.CurrencyCode, dbo.vueAccountExpenseEntry.IsQuantityField, 
                      dbo.vueAccountExpenseEntry.TaxCode, dbo.vueAccountExpenseEntry.QuantityFieldCaption, dbo.vueAccountExpenseEntry.Submitted
FROM         dbo.vueAccountExpenseEntryWithLastAction RIGHT OUTER JOIN
                      dbo.vueAccountExpenseEntry ON 
                      dbo.vueAccountExpenseEntryWithLastAction.AccountExpenseEntryId = dbo.vueAccountExpenseEntry.AccountExpenseEntryId'
GO

-- Create View vueAccountEmployeeTimeEntryWithLastStatus
Print 'Create View vueAccountEmployeeTimeEntryWithLastStatus'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimeEntryWithLastStatus' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimeEntryWithLastStatus
AS
SELECT     dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.AccountEmployeeTimeEntry.AccountEmployeeId, 
                      dbo.AccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountEmployeeTimeEntry.StartTime, dbo.AccountEmployeeTimeEntry.EndTime, 
                      dbo.AccountEmployeeTimeEntry.TotalTime, dbo.AccountEmployeeTimeEntry.AccountProjectId, dbo.AccountEmployeeTimeEntry.AccountProjectTaskId, 
                      dbo.AccountEmployeeTimeEntry.Description, dbo.AccountEmployeeTimeEntry.TimeSheetApprovalPathId, dbo.AccountEmployeeTimeEntry.Approved, 
                      dbo.AccountEmployeeTimeEntry.TeamLeadApproved, dbo.AccountEmployeeTimeEntry.ProjectManagerApproved, 
                      dbo.AccountEmployeeTimeEntry.AdministratorApproved, dbo.AccountEmployeeTimeEntry.CreatedOn, dbo.AccountEmployeeTimeEntry.ModifiedOn, 
                      dbo.AccountEmployeeTimeEntry.Rejected, dbo.AccountEmployeeTimeEntry.BillingRate, 
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction.IsApproved, dbo.vueAccountEmployeeTimeEntryApprovalLastAction.IsReject, 
                      dbo.AccountEmployeeTimeEntry.AccountPartyId, dbo.AccountEmployeeTimeEntry.Submitted
FROM         dbo.AccountEmployeeTimeEntry LEFT OUTER JOIN
                      dbo.vueAccountEmployeeTimeEntryApprovalLastAction ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.vueAccountEmployeeTimeEntryApprovalLastAction.AccountEmployeeTimeEntryId'

GO

UPDATE    AccountEmployeeTimeEntry
SET              AccountEmployeeTimeEntry.Submitted = 1
FROM         AccountEmployeeTimeEntry INNER JOIN
                      vueAccountEmployeeTimeEntryApprovalLastAction ON 
                      AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = vueAccountEmployeeTimeEntryApprovalLastAction.AccountEmployeeTimeEntryId
Where vueAccountEmployeeTimeEntryApprovalLastAction.IsApproved = 1

GO

UPDATE AccountEmployeeTimeEntry
SET AccountEmployeeTimeEntry.Submitted = 1
Where AccountEmployeeTimeEntry.Approved = 1

GO

UPDATE    AccountExpenseEntry
SET              AccountExpenseEntry.Submitted = 1
FROM         AccountExpenseEntry INNER JOIN
                      vueAccountExpenseEntryApprovalLastAction ON 
                      AccountExpenseEntry.AccountExpenseEntryId = vueAccountExpenseEntryApprovalLastAction.AccountExpenseEntryId
Where vueAccountExpenseEntryApprovalLastAction.IsApproved = 1

GO

UPDATE AccountExpenseEntry
SET AccountExpenseEntry.Submitted = 1
Where AccountExpenseEntry.Approved = 1

-- End 2.71.0003

-- Start 2.81.0001

GO
-- Drop View vueAccountEmployee
Print 'Drop View vueAccountEmployee'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployee]
GO
-- Add Column LockSubmittedRecords to AccountPreferences
Print 'Add Column LockSubmittedRecords to AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='LockSubmittedRecords' AND TABLE_NAME='AccountPreferences'))
ALTER TABLE [dbo].[AccountPreferences]
	ADD [LockSubmittedRecords] bit NULL

GO
-- Add Column LockApprovedRecords to AccountPreferences
Print 'Add Column LockApprovedRecords to AccountPreferences'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AccountPreferences' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='LockApprovedRecords' AND TABLE_NAME='AccountPreferences'))
ALTER TABLE [dbo].[AccountPreferences]
	ADD [LockApprovedRecords] bit NULL

GO
-- Create View vueAccountEmployee
Print 'Create View vueAccountEmployee'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployee' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployee
AS
SELECT     dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountEmployee.EMailAddress, 
                      dbo.AccountDepartment.DepartmentName, dbo.AccountRole.Role, dbo.AccountEmployee.AccountId, dbo.AccountLocation.AccountLocation, 
                      dbo.AccountEmployee.Password, dbo.AccountEmployee.AccountDepartmentId, dbo.AccountEmployee.AccountLocationId, 
                      dbo.AccountEmployee.BillingTypeId, dbo.AccountBillingType.BillingType, 
                      dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeName, dbo.AccountPreferences.ShowClockStartEnd, 
                      dbo.Account.TimeZoneId, dbo.AccountRole.MasterAccountRoleId, dbo.Account.DefaultCurrencyId, dbo.Account.CountryId, 
                      dbo.AccountPreferences.CultureInfoName, dbo.AccountPreferences.TimeEntryFormat, dbo.AccountEmployee.AllowedAccessFromIP, 
                      dbo.AccountRole.AccountRoleId, dbo.AccountPreferences.AccountSessionTimeout, dbo.AccountPreferences.ShowCompletedTasksInTimeSheet, 
                      dbo.AccountPreferences.CurrencySymbol, dbo.AccountPreferences.IsCompanyOwnLogo, dbo.Account.AccountExpiryActivation, 
                      dbo.Account.LicenseActivation, dbo.AccountEmployee.EmployeeTypeId, dbo.AccountEmployee.ExternalUserClientId, 
                      dbo.AccountEmployee.AccountBillingRateId, dbo.AccountPreferences.ScheduledEmailSendTime, 
                      dbo.AccountPreferences.LastScheduledEmailSentTime, dbo.AccountEmployee.Username, dbo.AccountEmployee.IsDisabled, 
                      dbo.AccountPreferences.FromEmailAddress, dbo.AccountPreferences.FromEmailAddressDisplayName, dbo.AccountEmployee.EmployeeCode, 
                      dbo.AccountPreferences.Version, dbo.AccountPreferences.LockSubmittedRecords, dbo.AccountPreferences.LockApprovedRecords, 
                      ISNULL(dbo.AccountEmployee.EmployeeCode +  '' - '' , '''') 
                      + dbo.AccountEmployee.FirstName + '' '' + dbo.AccountEmployee.LastName AS EmployeeNameWithCode
FROM         dbo.AccountEmployee INNER JOIN
                      dbo.Account ON dbo.AccountEmployee.AccountId = dbo.Account.AccountId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId LEFT OUTER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.AccountEmployee.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                      dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                      dbo.AccountBillingType ON dbo.AccountEmployee.BillingTypeId = dbo.AccountBillingType.AccountBillingTypeId'

GO

-- Drop Procedure CreateTableforAccountEmployeeTimesheetSubmissionStatus
Print 'Drop Procedure CreateTableforAccountEmployeeTimesheetSubmissionStatus'
GO
DROP PROCEDURE [dbo].[CreateTableforAccountEmployeeTimesheetSubmissionStatus]
GO
-- Drop View vueAccountEmployeeTimesheetSubmissionStatus
Print 'Drop View vueAccountEmployeeTimesheetSubmissionStatus'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimesheetSubmissionStatus' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimesheetSubmissionStatus]
GO
-- Drop View vueAccountEmployeeTimesheetSubmissionStatusALL
Print 'Drop View vueAccountEmployeeTimesheetSubmissionStatusALL'
GO
if exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimesheetSubmissionStatusALL' and table_type = 'VIEW') 
DROP VIEW [dbo].[vueAccountEmployeeTimesheetSubmissionStatusALL]
GO
-- Create View vueAccountEmployeeTimesheetSubmissionStatusALL
Print 'Create View vueAccountEmployeeTimesheetSubmissionStatusALL'
GO
if not exists (select * from information_schema.tables where table_name = 'vueAccountEmployeeTimesheetSubmissionStatusALL' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimesheetSubmissionStatusALL
AS
SELECT     dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.EmployeeName, 
                      dbo.AccountDepartment.DepartmentName, dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 0 AS NotEntered, SUM(1) AS Entered, 
                      (CASE WHEN dbo.vueAccountEmployeeTimeEntry.Submitted = 1 THEN (COUNT(dbo.vueAccountEmployeeTimeEntry.Submitted)) ELSE 0 END) 
                      AS Submitted, SUM(CASE WHEN Approved = 1 THEN 1 ELSE 0 END) AS Approved, SUM(CASE WHEN Rejected = 1 THEN 1 ELSE 0 END) AS Rejected, 
                      dbo.AccountRole.Role, dbo.vueAccountEmployeeTimeEntry.AccountId
FROM         dbo.vueAccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId INNER JOIN
                      dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId
GROUP BY dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.EmployeeName, 
                      dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountRole.Role, dbo.vueAccountEmployeeTimeEntry.AccountId, 
                      dbo.AccountDepartment.DepartmentName, dbo.vueAccountEmployeeTimeEntry.Submitted'
GO
-- Create View vueAccountEmployeeTimesheetSubmissionStatus
Print 'Create View vueAccountEmployeeTimesheetSubmissionStatus'
GO
if not exists (select * from information_schema.tables where table_name = 'dbo.vueAccountEmployeeTimesheetSubmissionStatus' and table_type = 'VIEW') 
EXEC sp_executesql N'CREATE VIEW dbo.vueAccountEmployeeTimesheetSubmissionStatus
AS
SELECT     AccountEmployeeId, EmployeeName, DepartmentName, TimeEntryDate, NotEntered, SUM(Submitted) AS Submitted, Approved, Rejected, Role, 
                      AccountId, Entered
FROM         dbo.vueAccountEmployeeTimesheetSubmissionStatusALL
GROUP BY AccountEmployeeId, EmployeeName, DepartmentName, TimeEntryDate, NotEntered, Approved, Rejected, Role, AccountId, Entered'
GO

-- Create Procedure CreateTableforAccountEmployeeTimesheetSubmissionStatus
Print 'Create Procedure CreateTableforAccountEmployeeTimesheetSubmissionStatus'
GO
CREATE PROCEDURE [dbo].[CreateTableforAccountEmployeeTimesheetSubmissionStatus]
    (
@startdate datetime,    
@enddate datetime,
@AccountEmployeeID varchar,
@AccountID integer
            )
AS

    SET NOCOUNT ON

IF EXISTS (SELECT * FROM TEMPDB.dbo.sysobjects WHERE NAME = '##tempAccountEmployeeTimesheetSubmissionStatusALL')
drop table ##tempAccountEmployeeTimesheetSubmissionStatusALL 


create table ##tempAccountEmployeeTimesheetSubmissionStatusALL 
(AccountEmployeeID int,
EmployeeName varchar(200),
DepartmentName varchar(200),
TimeEntryDate datetime,
NotEntered int,
Entered int,
Submitted int,
Approved int,
Rejected int,
Role varchar(100),
AccountID int)


insert into ##tempAccountEmployeeTimesheetSubmissionStatusALL
(AccountEmployeeID,
EmployeeName,
DepartmentName, 
TimeEntryDate,
NotEntered,
Entered, 
Submitted,
Approved,
Rejected,
Role,
AccountID)
SELECT     dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, 
dbo.vueAccountEmployeeTimeEntry.EmployeeName, 
dbo.AccountDepartment.DepartmentName, 
                      dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, 
0 AS NotEntered,
SUM(1) AS Entered,
(CASE WHEN dbo.vueAccountEmployeeTimeEntry.Submitted = 1 THEN COUNT(dbo.vueAccountEmployeeTimeEntry.Submitted) ELSE 0 END) 
                      AS Submitted, 
SUM(CASE WHEN Approved = 1 THEN 1 ELSE 0 END) 
                      AS Approved, 
SUM(CASE WHEN Rejected = 1 THEN 1 ELSE 0 END) AS Rejected, 
dbo.AccountRole.Role, 
                      dbo.vueAccountEmployeeTimeEntry.AccountId
FROM         dbo.vueAccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountEmployee ON dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId
                      inner join dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentID = dbo.AccountDepartment.AccountDepartmentID 
GROUP BY dbo.vueAccountEmployeeTimeEntry.AccountEmployeeId, dbo.vueAccountEmployeeTimeEntry.EmployeeName, dbo.AccountDepartment.DepartmentName,  
                      dbo.vueAccountEmployeeTimeEntry.TimeEntryDate, dbo.AccountRole.Role, dbo.vueAccountEmployeeTimeEntry.AccountId, dbo.vueAccountEmployeeTimeEntry.Submitted
UNION ALL
SELECT     dbo.##temp.AccountEmployeeID, dbo.AccountEmployee.FirstName + SPACE(1) + dbo.AccountEmployee.LastName AS Expr1, dbo.AccountDepartment.DepartmentName, 
                      dbo.##temp.AbsentDate AS TimeEntryDate, 1 AS NotEntered, 0 AS Entered, 0 As Submitted, 0 AS Approved, 0 AS Rejected, dbo.AccountRole.Role, 
                      dbo.##temp.AccountID
FROM         dbo.##temp INNER JOIN
                      dbo.AccountEmployee ON dbo.##temp.AccountEmployeeID = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountRole ON dbo.AccountEmployee.AccountRoleId = dbo.AccountRole.AccountRoleId
                      inner join dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentID = dbo.AccountDepartment.AccountDepartmentID 
GROUP BY dbo.##temp.AccountEmployeeID, dbo.##temp.AbsentDate, dbo.AccountRole.Role, dbo.##temp.AccountID, 
                      dbo.AccountEmployee.FirstName, dbo.AccountEmployee.LastName, dbo.AccountDepartment.DepartmentName
GO

-- =======================================================
-- Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]
-- =======================================================
Print 'Synchronization Script for Table: [dbo].[SystemSecurityCategoryPage]'

UPDATE [dbo].[SystemSecurityCategoryPage] SET [ParentSystemSecurityCateogoryPageId]=104 WHERE [SystemSecurityCategoryPageId]=105

GO
-- Add Column LicenseId to Account
Print 'Add Column LicenseId to Account'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Account' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME='LicenseId' AND TABLE_NAME='Account'))
ALTER TABLE [dbo].[Account]
	ADD [LicenseId] varchar(50) NULL

-- END 2.81.0001

-- Start 2.81.0002
Delete from emailmessage
-- Drop Index IX_Status from EmailMessage
Print 'Drop Index IX_Status from EmailMessage'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EmailMessage' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID (N'[dbo].[EmailMessage]') AND name = N'IX_Status'))
DROP INDEX [dbo].[EmailMessage].[IX_Status]
GO
-- Drop Primary Key PK_EmailMessage from EmailMessage
Print 'Drop Primary Key PK_EmailMessage from EmailMessage'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EmailMessage' AND TABLE_TYPE='BASE TABLE')) AND (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_EmailMessage' AND TABLE_NAME='EmailMessage'))
ALTER TABLE [dbo].[EmailMessage] DROP CONSTRAINT [PK_EmailMessage]
GO
-- Preserving data from [dbo].[EmailMessage] into a temporary table temp1413580074
EXEC sp_rename @objname = N'[dbo].[EmailMessage]', @newname = N'temp1413580074', @objtype = 'OBJECT'
GO

-- Create Table EmailMessage
Print 'Create Table EmailMessage'
GO
if not exists (select * from information_schema.tables where table_name = 'EmailMessage' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[EmailMessage] (
		[Id]                  uniqueidentifier NOT NULL,
		[ChangeStamp]         datetime NOT NULL,
		[Priority]            int NOT NULL,
		[Status]              int NOT NULL,
		[NumberOfRetry]       int NOT NULL,
		[RetryTime]           datetime NOT NULL,
		[MaximumRetry]        int NOT NULL,
		[ExpiryDateTime]      datetime NOT NULL,
		[ArrivedDateTime]     datetime NOT NULL,
		[SenderInfo]          varchar(50) NOT NULL,
		[EMailTo]             varchar(50) NOT NULL,
		[EMailFrom]           varchar(50) NOT NULL,
		[EMailSubject]        varchar(8000) NOT NULL,
		[EMailBody]           ntext NOT NULL,
		[EMailCC]             varchar(100) NOT NULL,
		[EMailBCC]            varchar(100) NOT NULL,
		[IsHTML]              bit NOT NULL
)
GO
-- Add Primary Key PK_EmailMessage to EmailMessage
Print 'Add Primary Key PK_EmailMessage to EmailMessage'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EmailMessage' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='PK_EmailMessage' AND TABLE_NAME='EmailMessage'))
ALTER TABLE [dbo].[EmailMessage]
	ADD
	CONSTRAINT [PK_EmailMessage]
	PRIMARY KEY
	([Id])
GO
-- Create Index IX_Status on EmailMessage
Print 'Create Index IX_Status on EmailMessage'
GO
IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'EmailMessage' AND TABLE_TYPE='BASE TABLE')) AND NOT (EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[EmailMessage]') AND name = N'IX_Status'))
CREATE INDEX [IX_Status]
	ON [dbo].[EmailMessage] ([Status])
GO
-- Disabling constraints
ALTER TABLE [dbo].[EmailMessage] NOCHECK CONSTRAINT ALL
GO

-- Restoring data
IF OBJECT_ID('temp1413580074') IS NOT NULL
EXEC sp_executesql N'
INSERT INTO [dbo].[EmailMessage] ([Id], [ChangeStamp], [Priority], [Status], [NumberOfRetry], [RetryTime], [MaximumRetry], [ExpiryDateTime], [ArrivedDateTime], [SenderInfo], [EMailTo], [EMailFrom], [EMailSubject], [EMailBody], [EMailCC], [EMailBCC], [IsHTML])
   SELECT [Id], [ChangeStamp], [Priority], [Status], [NumberOfRetry], [RetryTime], [MaximumRetry], [ExpiryDateTime], [ArrivedDateTime], [SenderInfo], [EMailTo], [EMailFrom], [EMailSubject], CAST([EMailBody] AS text), [EMailCC], [EMailBCC], [IsHTML] FROM temp1413580074
'
GO
-- Enabling backward constraints
ALTER TABLE [dbo].[EmailMessage] CHECK CONSTRAINT ALL
GO

-- Dropping the temporary table temp1413580074
IF OBJECT_ID('temp1413580074') IS NOT NULL DROP TABLE temp1413580074
GO
-- Create Table SystemData
Print 'Create Table SystemData'
GO
IF NOT EXISTS (select * from information_schema.tables where table_name = 'SystemData' and table_type = 'BASE TABLE') 
CREATE TABLE [dbo].[SystemData] (
		[SystemDataId]     int NOT NULL IDENTITY(1, 1),
		[Version]          nvarchar(50) NULL
)
-- END 2.81.0002
