create view AccountWorkingDayType_V as
select AccountWorkingDayTypeId, 
       CASE 
		WHEN AccountWorkingDayType = 'Full-time with weekends' 
        THEN 8 
		ELSE MinimumHoursPerDay
	   END as MinimumHoursPerDay
from AccountWorkingDayType