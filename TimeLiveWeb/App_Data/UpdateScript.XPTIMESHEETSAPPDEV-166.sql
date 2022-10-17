GO

/****** Object:  View [dbo].[VueAccountEmployeeTimeOffTypeIsInclude]    Script Date: 23/01/2017 12:12:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VueAccountEmployeeTimeOffTypeIsInclude]
AS
SELECT        dbo.AccountEmployee.AccountEmployeeId, b.AccountTimeOffTypeId, b.AccountTimeOffType, b.IsTimeOffRequestRequired, b.AccountId, b.CreatedByEmployeeId, b.CreatedOn, b.ModifiedByEmployeeId, 
                         b.ModifiedOn, b.IsDisabled, b.MasterTimeOffTypeId, a.IsInclude, b.ScheduleWeekends, CONCAT(b.AccountTimeOffType ,' - ',b.BriefExplanation ) BriefExplanation
FROM            dbo.AccountTimeOffPolicyDetail AS a INNER JOIN
                         dbo.AccountTimeOffType AS b ON a.AccountTimeOffTypeId = b.AccountTimeOffTypeId INNER JOIN
                         dbo.AccountTimeOffPolicy ON a.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId INNER JOIN
                         dbo.AccountEmployee ON dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId = dbo.AccountEmployee.AccountTimeOffPolicyId

GO
