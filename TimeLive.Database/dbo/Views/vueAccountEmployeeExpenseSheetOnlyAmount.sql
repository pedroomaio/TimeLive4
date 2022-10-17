
CREATE VIEW [dbo].[vueAccountEmployeeExpenseSheetOnlyAmount]
AS
SELECT        ISNULL(Amount, 0) AS Amount1, ISNULL(ExchangeRate, 0) AS ExchangeRate, CASE WHEN ExchangeRate <> 0 THEN Amount / ExchangeRate ELSE 0 END AS Amount, AccountExpenseEntryId, 
                         AccountEmployeeExpenseSheetId, Reimburse, IsBillable
FROM            dbo.AccountExpenseEntry