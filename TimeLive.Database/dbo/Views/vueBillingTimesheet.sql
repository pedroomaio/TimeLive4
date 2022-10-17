
CREATE VIEW dbo.vueBillingTimesheet
AS
SELECT     dbo.AccountTimeExpenseBillingTimesheet.TotalAmount, dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingTimesheetId, 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountId, dbo.AccountTimeExpenseBilling.AccountClientId, dbo.AccountTimeExpenseBillingTimesheet.AccountProjectId, 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountProjectTaskId
FROM         dbo.AccountTimeExpenseBilling LEFT OUTER JOIN
                      dbo.AccountTimeExpenseBillingTimesheet ON 
                      dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingId