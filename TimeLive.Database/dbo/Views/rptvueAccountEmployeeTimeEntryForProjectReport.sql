
CREATE VIEW dbo.rptvueAccountEmployeeTimeEntryForProjectReport
AS
SELECT     AccountProjectId, AccountId, Amount, TotalHours, EmployeeCost, 
                      CASE WHEN dbo.vueAccountEmployeeTimeEntryForReport.IsBillable = 1 THEN dbo.vueAccountEmployeeTimeEntryForReport.TotalHours ELSE 0 END AS BillableTotalHours,
                       CASE WHEN dbo.vueAccountEmployeeTimeEntryForReport.IsBillable = 0 THEN dbo.vueAccountEmployeeTimeEntryForReport.TotalHours WHEN dbo.vueAccountEmployeeTimeEntryForReport.IsBillable
                       IS NULL THEN dbo.vueAccountEmployeeTimeEntryForReport.TotalHours ELSE 0 END AS NonBillableTotalHours, 
                      CASE WHEN dbo.vueAccountEmployeeTimeEntryForReport.EmployeeRateExchangeRate > 0 THEN dbo.vueAccountEmployeeTimeEntryForReport.EmployeeCost / dbo.vueAccountEmployeeTimeEntryForReport.EmployeeRateExchangeRate
                       ELSE 0 END AS CurrencyEmployeeCost, 
                      CASE WHEN dbo.vueAccountEmployeeTimeEntryForReport.IsBillable = 1 THEN dbo.vueAccountEmployeeTimeEntryForReport.BillingRate * dbo.vueAccountEmployeeTimeEntryForReport.TotalHours
                       ELSE 0 END AS BillableTotalAmount, 
                      CASE WHEN dbo.vueAccountEmployeeTimeEntryForReport.IsBillable = 0 THEN dbo.vueAccountEmployeeTimeEntryForReport.BillingRate * dbo.vueAccountEmployeeTimeEntryForReport.TotalHours
                       ELSE 0 END AS NonBillableTotalAmount
FROM         dbo.vueAccountEmployeeTimeEntryForReport