Insert into SystemReportFilterSourceMapping values ('00DED0D1-06A4-48A8-921D-41D134D06018' , '430CA1B0-0205-430F-9A9A-9DADD4C07A3D' , 'EE5F3316-3A5E-484E-AE9E-9B11F0380997' , 0 , 0 , 8) --Insert Billing type Filter

Insert into SystemReportFilterSourceMapping values ('00DED0D1-06A4-48A8-921D-41D134D06019' , '28F4A000-3A5B-402C-9C5F-F92AF6310C5C' , 'EE5F3316-3A5E-484E-AE9E-9B11F0380997' , 0 , 0 , 9) --Insert Reimburse Status Filter

UPDATE SystemReportFilterSourceMapping --Move Data Range Filter 1 ahead
  SET FilterSequence = 10
  Where 
  SystemReportDataSourceId = 'EE5F3316-3A5E-484E-AE9E-9B11F0380997' and -- Expense Sheet Report DataSource ID
  SystemReportFilterSourceId = '5A1515DA-E197-49C1-83FC-B0D5A9A3034A' --Data range filter ID

/****** Object:  View [dbo].[vueAccountEmployeeExpenseSheetOnlyAmount]    Script Date: 20/12/2016 17:29:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vueAccountEmployeeExpenseSheetOnlyAmount]
AS
SELECT        ISNULL(Amount, 0) AS Amount1, ISNULL(ExchangeRate, 0) AS ExchangeRate, CASE WHEN ExchangeRate <> 0 THEN Amount / ExchangeRate ELSE 0 END AS Amount, AccountExpenseEntryId, 
                         AccountEmployeeExpenseSheetId, Reimburse, IsBillable
FROM            dbo.AccountExpenseEntry

GO


