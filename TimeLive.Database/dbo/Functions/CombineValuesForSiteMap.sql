
    CREATE FUNCTION [dbo].[CombineValuesForSiteMap]
    (
    @FK_ID INT, @ACC_ID INT --The foreign key from TableA which is used to fetch corresponding records
    )
    RETURNS NVARCHAR(4000)
    AS
    BEGIN
    DECLARE @SomeColumnList NVARCHAR(4000);

    SELECT @SomeColumnList = COALESCE(@SomeColumnList + ', ', '') + CAST(C.Role AS nvarchar(100)) 
    FROM vueSystemPagesWithRolesForSiteMap C
    WHERE C.SystemSecurityCategoryPageId = @FK_ID And C.AccountId = @ACC_ID;

    RETURN 
    (
    SELECT @SomeColumnList
    )
    END