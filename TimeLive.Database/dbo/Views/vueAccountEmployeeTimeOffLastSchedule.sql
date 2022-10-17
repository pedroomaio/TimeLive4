
CREATE VIEW dbo.vueAccountEmployeeTimeOffLastSchedule
AS                      
SELECT        dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployee.AccountId, dbo.AccountEmployee.AccountTimeOffPolicyId, dbo.AccountEmployee.TimeOffApprovalTypeId, 
                         dbo.AccountEmployee.LastTimeOffCalculationScheduledTime, 1 AS TotalYears, 1 AS TotalDays, 1 AS TotalMonth, 1 AS TotalWeeks, dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, 
                         dbo.AccountTimeOffPolicy.MasterTimeOffPolicyId, dbo.AccountTimeOffPolicyDetail.AccountTimeOffPolicyDetailId, dbo.AccountTimeOffPolicyDetail.AccountTimeOffTypeId, 
                         dbo.AccountTimeOffPolicyDetail.SystemEarnPeriodId, dbo.AccountTimeOffPolicyDetail.SystemResetToZeroTypeId, dbo.AccountTimeOffPolicyDetail.ResetToHours, dbo.AccountTimeOffPolicyDetail.EarnHours, 
                         dbo.AccountTimeOffPolicyDetail.CarryOver, dbo.AccountTimeOffPolicyDetail.MaximumAvailable, dbo.AccountTimeOffPolicyDetail.MasterTimeOffPolicyDetailId, dbo.SystemEarnPeriod.SystemEarnPeriod, 
                         dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountTimeOffType.IsTimeOffRequestRequired, dbo.AccountTimeOffPolicyDetail.InitialSetToHours, dbo.AccountEmployee.InitialPolicy, 
                         dbo.SystemResetToZeroType.SystemResetToZeroType, dbo.AccountEmployee.EMailAddress, dbo.AccountTimeOffPolicyDetail.EffectiveDate, ISNULL(dbo.AccountEmployee.HiredDate,dbo.AccountEmployee.CreatedOn) As HiredDate, 
                         dbo.AccountEmployeeTimeOff.LastEarnedDate, DATEDIFF(day, dbo.AccountEmployeeTimeOff.LastResetDate, GETDATE()) AS ResetTotalDays, DATEDIFF(month, dbo.AccountEmployeeTimeOff.LastResetDate, 
                         GETDATE()) AS ResetTotalMonth, dbo.AccountEmployeeTimeOff.LastResetDate, dbo.AccountEmployee.TerminationDate, CONVERT(VARCHAR, DATEADD(month, 1, dbo.AccountEmployeeTimeOff.LastEarnedDate), 
                         112) AS NextMonthEarnedDate, CONVERT(VARCHAR, DATEADD(month, 1, dbo.AccountEmployeeTimeOff.LastResetDate), 112) AS NextMonthResetDate, CONVERT(varchar, DAY(dbo.AccountEmployee.HiredDate)) 
                         + CASE WHEN Day(HiredDate) = 1 THEN 'st' WHEN DAY(HiredDate) = 2 THEN 'nd' WHEN DAY(HiredDate) = 3 THEN 'rd' ELSE '' END + ' of every month' AS NextMonthAnniversaryEarnedDate, CONVERT(varchar, 
                         DAY(dbo.AccountEmployee.HiredDate)) + CASE WHEN Day(HiredDate) = 1 THEN 'st' WHEN DAY(HiredDate) = 2 THEN 'nd' WHEN DAY(HiredDate) 
                         = 3 THEN 'rd' ELSE '' END + ' of every month' AS NextMonthAnniversaryResetDate, CONVERT(VARCHAR, DATEADD(week, 1, dbo.AccountEmployeeTimeOff.LastEarnedDate), 112) AS NextWeekEarnedDate, 
                         CONVERT(VARCHAR, DATEADD(year, 1, dbo.AccountEmployeeTimeOff.LastEarnedDate), 112) AS NextYearEarnedDate, CONVERT(VARCHAR, DATEADD(year, 1, dbo.AccountEmployeeTimeOff.LastResetDate), 112) 
                         AS NextYearResetDate, CONVERT(varchar, DAY(dbo.AccountEmployee.HiredDate)) + CASE WHEN Day(HiredDate) = 1 THEN 'st ' WHEN DAY(HiredDate) = 2 THEN 'nd ' WHEN DAY(HiredDate) 
                         = 3 THEN 'rd ' ELSE ' ' END + DATENAME(mm, GETDATE()) + ' of every year' AS NextYearAnniversaryEarnedDate, CONVERT(varchar, DAY(dbo.AccountEmployee.HiredDate)) + CASE WHEN Day(HiredDate) 
                         = 1 THEN 'st ' WHEN DAY(HiredDate) = 2 THEN 'nd ' WHEN DAY(HiredDate) = 3 THEN 'rd ' ELSE ' ' END + DATENAME(mm, GETDATE()) + ' of every year' AS NextYearAnniversaryResetDate, CONVERT(varchar, 
                         GETDATE(), 112) AS CurrentDate, CASE WHEN ISDATE(HiredDate) = 0 THEN 0 ELSE DATEDIFF(year, dbo.AccountEmployee.HiredDate, GETDATE()) END AS AnniversaryYearsCount, 
                         dbo.AccountTimeOffPolicyDetail.AdditionalHours, dbo.AccountTimeOffPolicyDetail.IsInclude, dbo.AccountTimeOffType.IsDisabled AS TimeOffTypeDisabled, 
                         dbo.AccountTimeOffPolicyDetail.CarryForwardExpiryDate, CONVERT(varchar, DAY(dbo.AccountTimeOffPolicyDetail.CarryForwardExpiryDate)) + CASE WHEN Day(CarryForwardExpiryDate) 
                         = 1 THEN 'st ' WHEN DAY(CarryForwardExpiryDate) = 2 THEN 'nd ' WHEN DAY(CarryForwardExpiryDate) = 3 THEN 'rd ' ELSE ' ' END + DATENAME(mm, GETDATE()) 
                         + ' of every year' AS NextYearCarryForwardExpiryDate, CONVERT(varchar, DAY(dbo.AccountTimeOffPolicyDetail.CarryForwardExpiryDate)) AS CarryForwardExpiryDay, CONVERT(varchar, 
                         MONTH(dbo.AccountTimeOffPolicyDetail.CarryForwardExpiryDate)) AS CarryForwardExpiryMonth, CONVERT(varchar, DAY(dbo.AccountTimeOffPolicyDetail.CarryForwardExpiryDate)) + '-' + CONVERT(varchar, 
                         MONTH(dbo.AccountTimeOffPolicyDetail.CarryForwardExpiryDate)) AS CarryForwardExpiryDayMonth, CONVERT(varchar, DAY(GETDATE())) + '-' + CONVERT(varchar, MONTH(GETDATE())) AS CurrentDayMonth
FROM            dbo.SystemResetToZeroType RIGHT OUTER JOIN
                         dbo.AccountTimeOffPolicyDetail INNER JOIN
                         dbo.AccountTimeOffType ON dbo.AccountTimeOffPolicyDetail.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId RIGHT OUTER JOIN
                         dbo.AccountEmployee INNER JOIN
                         dbo.AccountTimeOffPolicy ON dbo.AccountEmployee.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId INNER JOIN
                         dbo.AccountEmployeeTimeOff ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeOff.AccountEmployeeId ON 
                         dbo.AccountTimeOffType.AccountTimeOffTypeId = dbo.AccountEmployeeTimeOff.AccountTimeOffTypeId AND 
                         dbo.AccountTimeOffPolicyDetail.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId LEFT OUTER JOIN
                         dbo.SystemEarnPeriod ON dbo.AccountTimeOffPolicyDetail.SystemEarnPeriodId = dbo.SystemEarnPeriod.SystemEarnPeriodId ON 
                         dbo.SystemResetToZeroType.SystemResetToZeroTypeId = dbo.AccountTimeOffPolicyDetail.SystemResetToZeroTypeId
WHERE        (CONVERT(varchar, ISNULL(dbo.AccountEmployee.TerminationDate, CONVERT(varchar, GETDATE(), 112)), 112) >= CONVERT(varchar, GETDATE(), 112)) AND (dbo.AccountEmployee.IsDisabled <> 1) AND 
                         (dbo.AccountEmployee.IsDeleted <> 1)