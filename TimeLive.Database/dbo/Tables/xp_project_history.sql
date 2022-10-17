CREATE TABLE [dbo].[xp_project_history] (
    [project_id]   INT             NOT NULL,
    [job_type_id]  NUMERIC (18)    NOT NULL,
    [history_days] NUMERIC (18, 3) NOT NULL,
    CONSTRAINT [PK_xp_project_history] PRIMARY KEY CLUSTERED ([project_id] ASC, [job_type_id] ASC)
);

