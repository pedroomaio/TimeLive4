CREATE TABLE [dbo].[xp_employeeprofile] (
    [employee_id] INT          NOT NULL,
    [profile_id]  NUMERIC (18) NOT NULL,
    [start_date]  DATE         NOT NULL,
    [end_date]    DATE         NULL,
    CONSTRAINT [FK_xp_employeeprofile_AccountEmployee] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[AccountEmployee] ([AccountEmployeeId]),
    CONSTRAINT [FK_xp_employeeprofile_xp_jobtype] FOREIGN KEY ([profile_id]) REFERENCES [dbo].[xp_jobtype] ([id])
);

