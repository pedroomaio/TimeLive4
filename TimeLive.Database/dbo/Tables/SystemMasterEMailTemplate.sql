CREATE TABLE [dbo].[SystemMasterEMailTemplate] (
    [MasterEMailTemplateId] INT             NOT NULL,
    [TemplateName]          NVARCHAR (400)  NOT NULL,
    [TemplateDescription]   NVARCHAR (1000) NOT NULL,
    [TemplateContent]       NVARCHAR (4000) NOT NULL,
    CONSTRAINT [PK_MasterTemplate] PRIMARY KEY CLUSTERED ([MasterEMailTemplateId] ASC)
);

