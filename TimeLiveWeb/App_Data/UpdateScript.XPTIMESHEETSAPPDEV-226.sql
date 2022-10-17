update AccountEmployeeTimeOffRequest set AccountProjectId = 378
update AccountEmployeeTimeEntry set AccountProjectId = 378 where IsTimeOff = 1

update AccountEmployeeTimeOffRequest set AccountProjectId = 1027 where AccountEmployeeId = 525
update AccountEmployeeTimeEntry set AccountProjectId = 1027 where IsTimeOff = 1 And AccountEmployeeId = 525


