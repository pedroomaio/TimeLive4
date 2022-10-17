CREATE TABLE [dbo].[xp_project_budget] (
    [project_id]    INT             NOT NULL,
    [job_type_id]   NUMERIC (18)    NOT NULL,
    [budgeted_days] NUMERIC (18, 3) NOT NULL,
    CONSTRAINT [PK_xp_project_budget] PRIMARY KEY CLUSTERED ([project_id] ASC, [job_type_id] ASC)
);

