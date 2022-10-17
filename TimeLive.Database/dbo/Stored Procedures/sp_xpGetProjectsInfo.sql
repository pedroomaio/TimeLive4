-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpGetProjectsInfo]
	
AS

BEGIN    

	SELECT AccountProjectId, ProjectName FROM [dbo].[AccountProject]  where IsDisabled = 0 and IsDeleted is null order by ProjectName
	 
END