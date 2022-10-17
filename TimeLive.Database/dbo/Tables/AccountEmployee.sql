CREATE TABLE [dbo].[AccountEmployee] (
    [AccountEmployeeId]                   INT              IDENTITY (1, 1) NOT NULL,
    [Password]                            NVARCHAR (100)   NOT NULL,
    [Prefix]                              NVARCHAR (50)    NULL,
    [FirstName]                           NVARCHAR (150)   NOT NULL,
    [LastName]                            NVARCHAR (150)   NOT NULL,
    [MiddleName]                          NVARCHAR (40)    NULL,
    [EMailAddress]                        NVARCHAR (100)   NOT NULL,
    [AccountId]                           INT              NOT NULL,
    [AccountDepartmentId]                 INT              NULL,
    [AccountRoleId]                       INT              NOT NULL,
    [AccountLocationId]                   INT              NULL,
    [Notes]                               NVARCHAR (1000)  NULL,
    [AddressLine1]                        NVARCHAR (300)   NULL,
    [AddressLine2]                        NVARCHAR (300)   NULL,
    [State]                               NVARCHAR (40)    NULL,
    [City]                                NVARCHAR (100)   NULL,
    [Zip]                                 NVARCHAR (50)    NULL,
    [CountryId]                           SMALLINT         NULL,
    [HomePhoneNo]                         NVARCHAR (40)    NULL,
    [WorkPhoneNo]                         NVARCHAR (100)   NULL,
    [MobilePhoneNo]                       NVARCHAR (100)   NULL,
    [TimeEntryApprovalPathId]             SMALLINT         NULL,
    [BillingRateStateDate]                DATETIME         NULL,
    [BillingTypeId]                       INT              NULL,
    [StartDate]                           DATETIME         NULL,
    [TerminationDate]                     DATETIME         NULL,
    [StatusId]                            INT              NULL,
    [IsDeleted]                           BIT              NOT NULL,
    [IsDisabled]                          BIT              NULL,
    [DefaultProjectId]                    INT              NULL,
    [TimeZoneId]                          TINYINT          NULL,
    [DefaultEmployee]                     BIT              NULL,
    [CreatedOn]                           DATETIME         CONSTRAINT [DF_AccountEmployee_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedByEmployeeId]                 INT              NOT NULL,
    [ModifiedOn]                          DATETIME         CONSTRAINT [DF_AccountEmployee_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedByEmployeeId]                INT              NOT NULL,
    [AllowedAccessFromIP]                 NVARCHAR (40)    NULL,
    [ExternalUserClientId]                INT              NULL,
    [EmployeeTypeId]                      TINYINT          NULL,
    [AccountBillingRateId]                INT              NULL,
    [Username]                            NVARCHAR (100)   NULL,
    [EmployeeCode]                        NVARCHAR (100)   NULL,
    [EmployeeManagerId]                   INT              NULL,
    [JobTitle]                            NVARCHAR (200)   NULL,
    [EmployeePayTypeId]                   UNIQUEIDENTIFIER NULL,
    [HiredDate]                           DATETIME         NULL,
    [AccountWorkingDayTypeId]             UNIQUEIDENTIFIER NULL,
    [LastScheduledEmailSentTime]          DATETIME         NULL,
    [AccountTimeOffPolicyId]              UNIQUEIDENTIFIER NULL,
    [TimeOffApprovalTypeId]               INT              NULL,
    [LastTimeOffCalculationScheduledTime] DATETIME         NULL,
    [InitialPolicy]                       BIT              NULL,
    [AccountHolidayTypeId]                UNIQUEIDENTIFIER NULL,
    [IsEmailSend]                         BIT              CONSTRAINT [DF_AccountEmployee_IsEmailSend] DEFAULT ((0)) NOT NULL,
    [IsForcePasswordChange]               BIT              CONSTRAINT [DF_AccountEmployee_IsForcePasswordChange_1] DEFAULT ((0)) NOT NULL,
    [PasswordChangedDate]                 DATETIME         NULL,
    [PasswordVerificationCode]            UNIQUEIDENTIFIER NULL,
    [CustomField1]                        NVARCHAR (2000)  NULL,
    [CustomField2]                        NVARCHAR (2000)  NULL,
    [CustomField3]                        NVARCHAR (2000)  NULL,
    [CustomField4]                        NVARCHAR (2000)  NULL,
    [CustomField5]                        NVARCHAR (2000)  NULL,
    [CustomField6]                        NVARCHAR (2000)  NULL,
    [CustomField7]                        NVARCHAR (2000)  NULL,
    [CustomField8]                        NVARCHAR (2000)  NULL,
    [CustomField9]                        NVARCHAR (2000)  NULL,
    [CustomField10]                       NVARCHAR (2000)  NULL,
    [CustomField11]                       NVARCHAR (2000)  NULL,
    [CustomField12]                       NVARCHAR (2000)  NULL,
    [CustomField13]                       NVARCHAR (2000)  NULL,
    [CustomField14]                       NVARCHAR (2000)  NULL,
    [CustomField15]                       NVARCHAR (2000)  NULL,
    [UserInterfaceLanguage]               NVARCHAR (40)    NULL,
    [IsShowEmployeeProfilePicture]        BIT              CONSTRAINT [DF_AccountEmployee_IsShowEmployeeProfilePicture] DEFAULT ((1)) NULL,
    [OpenIDClaimIdentifier]               NVARCHAR (1000)  NULL,
    [OpenIDSource]                        NVARCHAR (100)   NULL,
    [IsTimeInOutAvailable]                BIT              NULL,
    CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED ([AccountEmployeeId] ASC),
    CONSTRAINT [FK_AccountEmployee_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountEmployee_AccountApprovalType] FOREIGN KEY ([TimeOffApprovalTypeId]) REFERENCES [dbo].[AccountApprovalType] ([AccountApprovalTypeId]),
    CONSTRAINT [FK_AccountEmployee_AccountBillingRate] FOREIGN KEY ([AccountBillingRateId]) REFERENCES [dbo].[AccountBillingRate] ([AccountBillingRateId]),
    CONSTRAINT [FK_AccountEmployee_AccountBillingType] FOREIGN KEY ([BillingTypeId]) REFERENCES [dbo].[AccountBillingType] ([AccountBillingTypeId]),
    CONSTRAINT [FK_AccountEmployee_AccountDepartment] FOREIGN KEY ([AccountDepartmentId]) REFERENCES [dbo].[AccountDepartment] ([AccountDepartmentId]),
    CONSTRAINT [FK_AccountEmployee_AccountEmployeeType] FOREIGN KEY ([EmployeePayTypeId]) REFERENCES [dbo].[AccountEmployeeType] ([AccountEmployeeTypeId]),
    CONSTRAINT [FK_AccountEmployee_AccountLocation] FOREIGN KEY ([AccountLocationId]) REFERENCES [dbo].[AccountLocation] ([AccountLocationId]),
    CONSTRAINT [FK_AccountEmployee_AccountParty] FOREIGN KEY ([ExternalUserClientId]) REFERENCES [dbo].[AccountParty] ([AccountPartyId]),
    CONSTRAINT [FK_AccountEmployee_AccountRole] FOREIGN KEY ([AccountRoleId]) REFERENCES [dbo].[AccountRole] ([AccountRoleId]),
    CONSTRAINT [FK_AccountEmployee_AccountStatus] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[AccountStatus] ([AccountStatusId]),
    CONSTRAINT [FK_AccountEmployee_AccountTimeOffPolicy] FOREIGN KEY ([AccountTimeOffPolicyId]) REFERENCES [dbo].[AccountTimeOffPolicy] ([AccountTimeOffPolicyId]),
    CONSTRAINT [FK_AccountEmployee_AccountWorkingDayType] FOREIGN KEY ([AccountWorkingDayTypeId]) REFERENCES [dbo].[AccountWorkingDayType] ([AccountWorkingDayTypeId]),
    CONSTRAINT [FK_AccountEmployee_SystemTimeZone] FOREIGN KEY ([TimeZoneId]) REFERENCES [dbo].[SystemTimeZone] ([SystemTimeZoneId])
);


GO
CREATE NONCLUSTERED INDEX [IX_CountryId]
    ON [dbo].[AccountEmployee]([CountryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountBillingRateId]
    ON [dbo].[AccountEmployee]([AccountBillingRateId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEmployee_5_1706541213__K1_4_5]
    ON [dbo].[AccountEmployee]([AccountEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [_dta_index_AccountEmployee_5_1706541213__K8_K1_2_3_4_5_6_7_9_10_11_12_13_14_15_16_17_18_19_20_21_25_26_27_28_29_30_31_32_34_35_]
    ON [dbo].[AccountEmployee]([AccountId] ASC, [AccountEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LastName]
    ON [dbo].[AccountEmployee]([LastName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FirstName]
    ON [dbo].[AccountEmployee]([FirstName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeManagerId]
    ON [dbo].[AccountEmployee]([EmployeeManagerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Username]
    ON [dbo].[AccountEmployee]([Username] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountWorkingDayTypeId]
    ON [dbo].[AccountEmployee]([AccountWorkingDayTypeId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EMailAddress]
    ON [dbo].[AccountEmployee]([EMailAddress] ASC, [IsDeleted] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountEmployee_1]
    ON [dbo].[AccountEmployee]([AccountEmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountDepartmentId]
    ON [dbo].[AccountEmployee]([AccountDepartmentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BillingTypeId]
    ON [dbo].[AccountEmployee]([BillingTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheetApprovalPathId]
    ON [dbo].[AccountEmployee]([TimeEntryApprovalPathId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Password]
    ON [dbo].[AccountEmployee]([Password] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountRoleId]
    ON [dbo].[AccountEmployee]([AccountRoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountLocationId]
    ON [dbo].[AccountEmployee]([AccountLocationId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[AccountEmployee]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_1706541213_25_30_1_2_42_8_10_48_9_11]
    ON [dbo].[AccountEmployee]([BillingTypeId], [IsDisabled], [AccountEmployeeId], [Password], [Username], [AccountId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId], [AccountLocationId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_8_10_48_9_11_25_2_42]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId], [AccountLocationId], [BillingTypeId], [Password], [Username]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_8_10_48_9_11_25_42_30]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId], [AccountLocationId], [BillingTypeId], [Username], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1706541213_2_1_42_30_8_10_48_9_11]
    ON [dbo].[AccountEmployee]([Password], [AccountEmployeeId], [Username], [IsDisabled], [AccountId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId], [AccountLocationId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_25_8_40_10_39_9_11]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [BillingTypeId], [AccountId], [EmployeeTypeId], [AccountRoleId], [ExternalUserClientId], [AccountDepartmentId], [AccountLocationId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_9_8_40_10_48_11_25]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountDepartmentId], [AccountId], [EmployeeTypeId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountLocationId], [BillingTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_30_11_8_48_1_10_9_25]
    ON [dbo].[AccountEmployee]([IsDisabled], [AccountLocationId], [AccountId], [AccountWorkingDayTypeId], [AccountEmployeeId], [AccountRoleId], [AccountDepartmentId], [BillingTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_30_1_11_2_42_8_10_48]
    ON [dbo].[AccountEmployee]([IsDisabled], [AccountEmployeeId], [AccountLocationId], [Password], [Username], [AccountId], [AccountRoleId], [AccountWorkingDayTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_42_30_1_8_10_48_9_11]
    ON [dbo].[AccountEmployee]([Username], [IsDisabled], [AccountEmployeeId], [AccountId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId], [AccountLocationId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_11_8_48_1_10_9_25]
    ON [dbo].[AccountEmployee]([AccountLocationId], [AccountId], [AccountWorkingDayTypeId], [AccountEmployeeId], [AccountRoleId], [AccountDepartmentId], [BillingTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_40_1_10_39_9_11_25]
    ON [dbo].[AccountEmployee]([EmployeeTypeId], [AccountEmployeeId], [AccountRoleId], [ExternalUserClientId], [AccountDepartmentId], [AccountLocationId], [BillingTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_25_1_42_8_10_48_9]
    ON [dbo].[AccountEmployee]([BillingTypeId], [AccountEmployeeId], [Username], [AccountId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_30_1_10_48_9_11_25]
    ON [dbo].[AccountEmployee]([IsDisabled], [AccountEmployeeId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId], [AccountLocationId], [BillingTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_10_39_9_11_25_8]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountRoleId], [ExternalUserClientId], [AccountDepartmentId], [AccountLocationId], [BillingTypeId], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_30_1_25_8_10_48_9]
    ON [dbo].[AccountEmployee]([IsDisabled], [AccountEmployeeId], [BillingTypeId], [AccountId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_25_8_1_30_11_48_10]
    ON [dbo].[AccountEmployee]([BillingTypeId], [AccountId], [AccountEmployeeId], [IsDisabled], [AccountLocationId], [AccountWorkingDayTypeId], [AccountRoleId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_10_48_9_11_25_40]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId], [AccountLocationId], [BillingTypeId], [EmployeeTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_25_1_8_40_10_48_9]
    ON [dbo].[AccountEmployee]([BillingTypeId], [AccountEmployeeId], [AccountId], [EmployeeTypeId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_30_1_9_2_42_8_10]
    ON [dbo].[AccountEmployee]([IsDisabled], [AccountEmployeeId], [AccountDepartmentId], [Password], [Username], [AccountId], [AccountRoleId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_10_1_8_40_39_9_11]
    ON [dbo].[AccountEmployee]([AccountRoleId], [AccountEmployeeId], [AccountId], [EmployeeTypeId], [ExternalUserClientId], [AccountDepartmentId], [AccountLocationId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_40_1_10_48_9_11]
    ON [dbo].[AccountEmployee]([EmployeeTypeId], [AccountEmployeeId], [AccountRoleId], [AccountWorkingDayTypeId], [AccountDepartmentId], [AccountLocationId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_8_30_2_4_5]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountId], [IsDisabled], [Password], [FirstName], [LastName]);


GO
CREATE STATISTICS [_dta_stat_1706541213_11_1_8_40_10_48]
    ON [dbo].[AccountEmployee]([AccountLocationId], [AccountEmployeeId], [AccountId], [EmployeeTypeId], [AccountRoleId], [AccountWorkingDayTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_9_8_1_30_11_48]
    ON [dbo].[AccountEmployee]([AccountDepartmentId], [AccountId], [AccountEmployeeId], [IsDisabled], [AccountLocationId], [AccountWorkingDayTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_9_1_11_10_25_44]
    ON [dbo].[AccountEmployee]([AccountDepartmentId], [AccountEmployeeId], [AccountLocationId], [AccountRoleId], [BillingTypeId], [EmployeeManagerId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_48_30_1_2_42_8]
    ON [dbo].[AccountEmployee]([AccountWorkingDayTypeId], [IsDisabled], [AccountEmployeeId], [Password], [Username], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_11_1_8_40_10_39]
    ON [dbo].[AccountEmployee]([AccountLocationId], [AccountEmployeeId], [AccountId], [EmployeeTypeId], [AccountRoleId], [ExternalUserClientId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_11_42_8_10_48]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountLocationId], [Username], [AccountId], [AccountRoleId], [AccountWorkingDayTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_30_1_9_8_10]
    ON [dbo].[AccountEmployee]([IsDisabled], [AccountEmployeeId], [AccountDepartmentId], [AccountId], [AccountRoleId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_2_4_5_8]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [Password], [FirstName], [LastName], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_11_1_10_9_25]
    ON [dbo].[AccountEmployee]([AccountLocationId], [AccountEmployeeId], [AccountRoleId], [AccountDepartmentId], [BillingTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_10_8_1_30_11]
    ON [dbo].[AccountEmployee]([AccountRoleId], [AccountId], [AccountEmployeeId], [IsDisabled], [AccountLocationId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_48_8_40_10]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountWorkingDayTypeId], [AccountId], [EmployeeTypeId], [AccountRoleId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_10_30_1_2_42]
    ON [dbo].[AccountEmployee]([AccountRoleId], [IsDisabled], [AccountEmployeeId], [Password], [Username]);


GO
CREATE STATISTICS [_dta_stat_1706541213_44_1_11_10_9]
    ON [dbo].[AccountEmployee]([EmployeeManagerId], [AccountEmployeeId], [AccountLocationId], [AccountRoleId], [AccountDepartmentId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_9_1_42_8_10]
    ON [dbo].[AccountEmployee]([AccountDepartmentId], [AccountEmployeeId], [Username], [AccountId], [AccountRoleId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_11_8_1_30]
    ON [dbo].[AccountEmployee]([AccountLocationId], [AccountId], [AccountEmployeeId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1706541213_11_10_9_25]
    ON [dbo].[AccountEmployee]([AccountLocationId], [AccountRoleId], [AccountDepartmentId], [BillingTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_48_8_1_30]
    ON [dbo].[AccountEmployee]([AccountWorkingDayTypeId], [AccountId], [AccountEmployeeId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1706541213_48_1_42_8]
    ON [dbo].[AccountEmployee]([AccountWorkingDayTypeId], [AccountEmployeeId], [Username], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_8_2_4]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountId], [Password], [FirstName]);


GO
CREATE STATISTICS [_dta_stat_1706541213_25_1_11_10]
    ON [dbo].[AccountEmployee]([BillingTypeId], [AccountEmployeeId], [AccountLocationId], [AccountRoleId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_2_42_30]
    ON [dbo].[AccountEmployee]([Password], [Username], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_44_48]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [EmployeeManagerId], [AccountWorkingDayTypeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_8_40_1]
    ON [dbo].[AccountEmployee]([AccountId], [EmployeeTypeId], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_10_42]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountRoleId], [Username]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_9_10]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [AccountDepartmentId], [AccountRoleId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_30_8]
    ON [dbo].[AccountEmployee]([IsDisabled], [AccountId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_4_1]
    ON [dbo].[AccountEmployee]([FirstName], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_33_1]
    ON [dbo].[AccountEmployee]([DefaultEmployee], [AccountEmployeeId]);


GO
CREATE STATISTICS [_dta_stat_1706541213_9_30]
    ON [dbo].[AccountEmployee]([AccountDepartmentId], [IsDisabled]);


GO
CREATE STATISTICS [_dta_stat_1706541213_1_42]
    ON [dbo].[AccountEmployee]([AccountEmployeeId], [Username]);

