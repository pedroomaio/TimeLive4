CREATE TABLE [dbo].[MasterAccountAbsenceType] (
    [MasterAccountAbsenceTypeId] SMALLDATETIME  NOT NULL,
    [TemplateId]                 SMALLINT       NOT NULL,
    [AbsenceDescription]         NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_MasterAccountAbsenceType] PRIMARY KEY CLUSTERED ([MasterAccountAbsenceTypeId] ASC)
);

