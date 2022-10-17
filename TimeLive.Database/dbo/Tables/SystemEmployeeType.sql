CREATE TABLE [dbo].[SystemEmployeeType] (
    [EmployeeTypeId] TINYINT        NOT NULL,
    [EmployeeType]   NVARCHAR (100) NULL,
    CONSTRAINT [PK_EmployeeType] PRIMARY KEY CLUSTERED ([EmployeeTypeId] ASC)
);

