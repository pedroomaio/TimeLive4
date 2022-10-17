-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_xpGetLocationsInfo]

AS
BEGIN
Select AccountLocationId, AccountLocation FROM [dbo].[AccountLocation] AL where AL.IsDisabled = 0 
END