
CREATE PROCEDURE [dbo].[sp_xpAllocationDataSetMissing] 
	-- Add the parameters for the stored procedure here
	@pYear varchar(4), 
	@pMonth varchar(10)
AS
begin
IF @pMonth = '*' 

	begin
		WITH cte AS (
			SELECT 1 AS DayID,
			CAST(CAST(YEAR(CONVERT(VARCHAR(10),CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,'01')+'-01',120),120)) AS VARCHAR(4)) + '/' + CAST(MONTH(CONVERT(VARCHAR(10),CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,'01')+'-01',120),120)) AS VARCHAR(2)) + '/01' AS DATETIME) AS FromDate,
			DATENAME(dw, CAST(CAST(YEAR(CONVERT(VARCHAR(10),CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,'01')+'-01',120),120)) AS VARCHAR(4)) + '/' + CAST(MONTH(CONVERT(VARCHAR(10),CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,'01')+'-01',120),120)) AS VARCHAR(2)) + '/01' AS DATETIME)) AS Dayname
			UNION ALL
			SELECT cte.DayID + 1 AS DayID,
			DATEADD(d, 1 ,cte.FromDate),
			DATENAME(dw, DATEADD(d, 1 ,cte.FromDate)) AS Dayname
			FROM cte
			WHERE 
			DATEADD(d,1,cte.FromDate) <= CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,'12')+'-31',120)
		)
		SELECT EmployeeCode, count(1) as DaysMissing
		FROM (
				SELECT A.EmployeeCode, A.MinimumHoursPerDay as HoursPerDay, FromDate
				FROM (SELECT EmployeeCode, MinimumHoursPerDay, HiredDate, TerminationDate
					  FROM AccountEmployee ae, AccountWorkingDayType_V awdt
					  WHERE ae.AccountWorkingDayTypeId = awdt.AccountWorkingDayTypeId
					  AND ae.isDisabled <> 1
					  AND MinimumHoursPerDay > 0) A,
					 (SELECT FromDate
					  FROM CTE
					  WHERE DayName NOT IN ('Saturday','Sunday')) B
				WHERE (B.FromDate >= A.HiredDate OR A.HiredDate IS NULL) AND (B.FromDate <= A.TerminationDate OR A.TerminationDate IS NULL)
				EXCEPT
				SELECT C.EmployeeCode, C.HoursPerDay2, FromDate
				FROM (SELECT TimeEntryDate, EmployeeCode, CASE WHEN HoursPerDay > MinimumHoursPerDay THEN MinimumHoursPerDay ELSE HoursPerDay END as HoursPerDay2
					  FROM (
						SELECT aete.TimeEntryDate, ae.EmployeeCode, awdt.MinimumHoursPerDay, SUM(CAST(DATEPART(hh, aete.TotalTime) AS float) + CAST(DATEPART(mi, aete.TotalTime) AS float) / 60) as HoursPerDay
						FROM AccountEmployeeTimeEntry aete, AccountEmployee ae, AccountWorkingDayType_V awdt
						WHERE ae.AccountWorkingDayTypeId = awdt.AccountWorkingDayTypeId
						AND ae.isDisabled <> 1
						AND awdt.MinimumHoursPerDay > 0
						AND aete.AccountEmployeeId = ae.AccountEmployeeId
						GROUP BY aete.TimeEntryDate, ae.EmployeeCode, awdt.MinimumHoursPerDay
						)cc ) C,
					 (SELECT FromDate
					  FROM CTE
					  WHERE DayName NOT IN ('Saturday','Sunday')) D
				WHERE C.timeEntryDate = D.FromDate
			) E
		GROUP BY EmployeeCode
		OPTION (MaxRecursion 370)

	end
else
	begin
			WITH cte AS (
			SELECT 1 AS DayID,
			CAST(CAST(YEAR(CONVERT(VARCHAR(10),CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,@pMonth)+'-01',120),120)) AS VARCHAR(4)) + '/' + CAST(MONTH(CONVERT(VARCHAR(10),CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,@pMonth)+'-01',120),120)) AS VARCHAR(2)) + '/01' AS DATETIME) AS FromDate,
			DATENAME(dw, CAST(CAST(YEAR(CONVERT(VARCHAR(10),CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,@pMonth)+'-01',120),120)) AS VARCHAR(4)) + '/' + CAST(MONTH(CONVERT(VARCHAR(10),CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,@pMonth)+'-01',120),120)) AS VARCHAR(2)) + '/01' AS DATETIME)) AS Dayname
			UNION ALL
			SELECT cte.DayID + 1 AS DayID,
			DATEADD(d, 1 ,cte.FromDate),
			DATENAME(dw, DATEADD(d, 1 ,cte.FromDate)) AS Dayname
			FROM cte
			WHERE 
			DATEADD(d,1,cte.FromDate) < DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,CONVERT(VARCHAR(10),CONVERT(datetime,convert(varchar,@pYear)+'-'+convert(varchar,@pMonth)+'-01',120),120))+1,0))
		)
		SELECT EmployeeCode, count(1) as DaysMissing
		FROM (
				SELECT A.EmployeeCode, A.MinimumHoursPerDay as HoursPerDay, FromDate
				FROM (SELECT EmployeeCode, MinimumHoursPerDay, HiredDate, TerminationDate
					  FROM AccountEmployee ae, AccountWorkingDayType_V awdt
					  WHERE ae.AccountWorkingDayTypeId = awdt.AccountWorkingDayTypeId
					  AND ae.isDisabled <> 1
					  AND MinimumHoursPerDay > 0) A,
					 (SELECT FromDate
					  FROM CTE
					  WHERE DayName NOT IN ('Saturday','Sunday')) B
				WHERE (B.FromDate >= A.HiredDate OR A.HiredDate IS NULL) AND (B.FromDate <= A.TerminationDate OR A.TerminationDate IS NULL)
				EXCEPT
				SELECT C.EmployeeCode, C.HoursPerDay2, FromDate
				FROM (SELECT TimeEntryDate, EmployeeCode, CASE WHEN HoursPerDay > MinimumHoursPerDay THEN MinimumHoursPerDay ELSE HoursPerDay END as HoursPerDay2
					  FROM (
						SELECT aete.TimeEntryDate, ae.EmployeeCode, awdt.MinimumHoursPerDay, SUM(CAST(DATEPART(hh, aete.TotalTime) AS float) + CAST(DATEPART(mi, aete.TotalTime) AS float) / 60) as HoursPerDay
						FROM AccountEmployeeTimeEntry aete, AccountEmployee ae, AccountWorkingDayType_V awdt
						WHERE ae.AccountWorkingDayTypeId = awdt.AccountWorkingDayTypeId
						AND ae.isDisabled <> 1
						AND awdt.MinimumHoursPerDay > 0
						AND aete.AccountEmployeeId = ae.AccountEmployeeId
						GROUP BY aete.TimeEntryDate, ae.EmployeeCode, awdt.MinimumHoursPerDay
						)cc ) C,
					 (SELECT FromDate
					  FROM CTE
					  WHERE DayName NOT IN ('Saturday','Sunday')) D
				WHERE C.timeEntryDate = D.FromDate
			) E
		GROUP BY EmployeeCode
		OPTION (MaxRecursion 370)
	end



END