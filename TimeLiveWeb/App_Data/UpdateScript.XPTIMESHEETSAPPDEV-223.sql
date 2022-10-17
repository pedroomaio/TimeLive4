GO
Alter table AccountExpense
Add ReimburseIsReadOnly bit

Alter table AccountExpense
Add BillableIsReadOnly bit
GO
Update AccountExpense
SET ReimburseIsReadOnly = 0

Update AccountExpense
SET BillableIsReadOnly = 0
GO
Alter table AccountExpense
Alter Column BillableIsReadOnly bit not null

Alter table AccountExpense
Alter Column ReimburseIsReadOnly bit not null

GO

/****** Object:  View [dbo].[vueAccountExpense]    Script Date: 06/04/2017 10:42:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vueAccountExpense]
AS
SELECT        dbo.AccountExpense.AccountExpenseId, dbo.AccountExpense.AccountExpenseName, dbo.AccountExpense.AccountExpenseTypeId, dbo.AccountExpenseType.ExpenseType, dbo.AccountExpense.AccountId, 
                         dbo.AccountExpense.CreatedOn, dbo.AccountExpense.CreatedByEmployeeId, dbo.AccountExpense.ModifiedOn, dbo.AccountExpense.ModifiedByEmployeeId, dbo.AccountExpense.IsBillable, 
                         dbo.AccountExpense.IsDisabled, dbo.AccountExpense.Reimburse, dbo.AccountExpense.ReimburseIsReadOnly, dbo.AccountExpense.BillableIsReadOnly
FROM            dbo.AccountExpense LEFT OUTER JOIN
                         dbo.AccountExpenseType ON dbo.AccountExpense.AccountExpenseTypeId = dbo.AccountExpenseType.AccountExpenseTypeId