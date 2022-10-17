
CREATE VIEW dbo.vueAccountTerminology
AS
SELECT     AccountTerminologyId, UserDefinedName, AccountId, CreatedByEmployeeId, ModifiedByEmployeeId, CreatedOn, ModifiedOn, TerminologyName
FROM         dbo.AccountTerminology