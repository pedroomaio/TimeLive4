-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpGetDepartmentsInfo]
	
AS
BEGIN

Select AccountDepartmentId, DepartmentName FROM [dbo].[AccountDepartment]

END