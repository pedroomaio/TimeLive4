CREATE TABLE [dbo].[MasterEmployeeType] (
    [MasterEmployeeTypeId] UNIQUEIDENTIFIER CONSTRAINT [DF_MasterEmployeeType_MasterEmployeeTypeId] DEFAULT (newid()) NOT NULL,
    [MasterEmployeeType]   NVARCHAR (100)   NOT NULL,
    [IsVendor]             BIT              NULL,
    CONSTRAINT [PK_MasterEmployeeType] PRIMARY KEY CLUSTERED ([MasterEmployeeTypeId] ASC)
);

