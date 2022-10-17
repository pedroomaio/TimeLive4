CREATE TABLE [dbo].[AccountPreferences] (
    [AccountPreferencesId]                          INT              IDENTITY (1, 1) NOT NULL,
    [AccountId]                                     INT              NOT NULL,
    [ShowClockStartEnd]                             BIT              CONSTRAINT [DF_AccountPreferences_ShowStartAndEndTime] DEFAULT ((0)) NOT NULL,
    [CultureInfoName]                               NVARCHAR (40)    NULL,
    [TimeEntryFormat]                               NVARCHAR (50)    NULL,
    [AccountSessionTimeout]                         INT              NULL,
    [ShowCompletedTasksInTimeSheet]                 BIT              NULL,
    [CurrencySymbol]                                NVARCHAR (20)    NULL,
    [IsCompanyOwnLogo]                              BIT              NULL,
    [ScheduledEmailSendTime]                        DATETIME         NULL,
    [LastScheduledEmailSentTime]                    DATETIME         NULL,
    [Version]                                       NVARCHAR (100)   NULL,
    [FromEmailAddress]                              NVARCHAR (50)    NULL,
    [FromEmailAddressDisplayName]                   NVARCHAR (100)   NULL,
    [AccountBaseCurrencyId]                         INT              NULL,
    [AccountReimbursementCurrencyId]                INT              NULL,
    [LockSubmittedRecords]                          BIT              NULL,
    [LockApprovedRecords]                           BIT              NULL,
    [ShowWorkTypeInTimeSheet]                       BIT              CONSTRAINT [DF_AccountPreferences_ShowWorkTypeInTimeSheet] DEFAULT ((0)) NULL,
    [NumberOfBlankRowsInTimeEntry]                  SMALLINT         NULL,
    [ShowCostCenterInTimeSheet]                     BIT              CONSTRAINT [DF_AccountPreferences_ShowCostCenterInTimeSheet_1] DEFAULT ((0)) NULL,
    [WeekStartDay]                                  TINYINT          NULL,
    [UserInterfaceLanguage]                         NVARCHAR (40)    NULL,
    [DefaultTimeEntryMode]                          NVARCHAR (50)    NULL,
    [PageSize]                                      INT              NULL,
    [ShowClientInTimesheet]                         BIT              NULL,
    [ShowDescriptionInWeekView]                     BIT              NULL,
    [InvoiceNoPrefix]                               NVARCHAR (10)    NULL,
    [ShowAdditionalTaskInformationType]             INT              NULL,
    [TimesheetPrintFooter]                          NVARCHAR (4000)  NULL,
    [ExpenseSheetPrintFooter]                       NVARCHAR (4000)  NULL,
    [ShowCompletedProjectsInTimeSheet]              BIT              NULL,
    [ShowProjectForTimeOff]                         BIT              CONSTRAINT [DF_AccountPreferences_ShowProjectForTimeOff] DEFAULT ((0)) NULL,
    [ShowTimeOffInTimesheet]                        BIT              NULL,
    [PasswordExpiryPeriod]                          INT              NULL,
    [ShowAllInTimesheetReadOnly]                    BIT              NULL,
    [ShowTaskInExpenseSheet]                        BIT              NULL,
    [InvoiceBillingTypeId]                          UNIQUEIDENTIFIER NULL,
    [ShowBillingRateInInvoiceReport]                BIT              NULL,
    [InvoiceFooter]                                 NVARCHAR (4000)  NULL,
    [TimesheetOverduePeriods]                       SMALLINT         NULL,
    [ShowProjectNameInInvoiceReport]                BIT              NULL,
    [ProjectCodePrefix]                             NVARCHAR (10)    NULL,
    [AutoGenerateProjectCode]                       BIT              NULL,
    [TimeEntryHoursFormatId]                        UNIQUEIDENTIFIER NULL,
    [ShowPercentageInTimesheet]                     BIT              NULL,
    [EnablePasswordComplexity]                      BIT              NULL,
    [ShowClientDepartmentInProject]                 BIT              NULL,
    [ShowEntryDateInInvoiceReport]                  BIT              NULL,
    [TimesheetSort]                                 NVARCHAR (50)    NULL,
    [ShowCostCenterInTimesheetBy]                   NVARCHAR (50)    NULL,
    [ShowCopyTimesheetButton]                       BIT              NULL,
    [ShowCopyActivitiesButtonInTimesheet]           BIT              NULL,
    [ShowProjectNameInTask]                         BIT              NULL,
    [ShowClientNameInTask]                          BIT              NULL,
    [IsShowElectronicSign]                          BIT              NULL,
    [ShowCompletedProjectInProjectGrid]             BIT              NULL,
    [ShowEmployeeNameInInvoiceReport]               BIT              NULL,
    [CalculateTaskPercentageAutomatically]          BIT              NULL,
    [IncludeCurrentYearInProjectCode]               BIT              NULL,
    [ShowAdditionalProjectInformationType]          INT              NULL,
    [EnableOfflineTimesheet]                        BIT              NULL,
    [ShowWorkTypeInInvoiceDescription]              BIT              NULL,
    [ShowClientInExpenseSheet]                      BIT              NULL,
    [AutomaticallyIncludeAdminitratorInProjectTeam] BIT              NULL,
    [ShowAdditionalDepartmentInformationInEmployee] BIT              NULL,
    [DefaultProjectTaskSelectionInTimesheet]        BIT              NULL,
    [DefaultTaskName]                               NVARCHAR (300)   NULL,
    [InsertDefaultTaskNameInProject]                BIT              NULL,
    [RoundOffValueInInvoice]                        BIT              NULL,
    [IsProjectTemplateMandatory]                    BIT              NULL,
    [ShowDisableProjectInReport]                    BIT              NULL,
    [GoogleAppsDomain]                              NVARCHAR (100)   NULL,
    [IsShowEmployeeNameWithCode]                    BIT              NULL,
    [IsShowDisableEmployeesInReport]                BIT              NULL,
    [EnableGoogleAuthentication]                    BIT              NULL,
    [SortTaskBy]                                    NVARCHAR (100)   NULL,
    [ShowTimeOffTypesBy]                            NVARCHAR (100)   NULL,
    [ShowClockStartEndBy]                           NVARCHAR (50)    NULL,
    [IsTimeOffStatusEditMode]                       BIT              NULL,
    [AutoResizeTimesheet]                           BIT              NULL,
    [ShowEmployeeNameBy]                            INT              NULL,
    [HideProjectFromApplication]                    BIT              NULL,
    [ShowProjectInTimesheet]                        BIT              NULL,
    [IsShowTimeOffInDays]                           BIT              NULL,
    [EnableTaskHoursValidation]                     BIT              NULL,
    [EnableSingleSignonSSO]                         BIT              NULL,
    [SAMLSSOURL]                                    NVARCHAR (100)   NULL,
    [IsAllowOverlappingTimeEntries]                 BIT              NULL,
    CONSTRAINT [PK_AccountPreferences] PRIMARY KEY CLUSTERED ([AccountPreferencesId] ASC),
    CONSTRAINT [FK_AccountPreferences_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccountPreferences_AccountCurrency] FOREIGN KEY ([AccountBaseCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId]),
    CONSTRAINT [FK_AccountPreferences_AccountCurrency1] FOREIGN KEY ([AccountReimbursementCurrencyId]) REFERENCES [dbo].[AccountCurrency] ([AccountCurrencyId])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountSessionTimeout]
    ON [dbo].[AccountPreferences]([AccountSessionTimeout] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccountPreferences]
    ON [dbo].[AccountPreferences]([AccountId] ASC);


GO
CREATE STATISTICS [_dta_stat_2007886420_1_2_15]
    ON [dbo].[AccountPreferences]([AccountPreferencesId], [AccountId], [AccountBaseCurrencyId]);


GO
CREATE STATISTICS [_dta_stat_2007886420_1_15]
    ON [dbo].[AccountPreferences]([AccountPreferencesId], [AccountBaseCurrencyId]);

