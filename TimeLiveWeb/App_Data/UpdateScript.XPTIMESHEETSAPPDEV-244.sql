Select * from AccountReportColumn as a where Caption Like '%By Employee Name'

update AccountReportColumn 
set Caption = SUBSTRING(Caption,0,12) 
where Caption  Like '%By Employee Name'