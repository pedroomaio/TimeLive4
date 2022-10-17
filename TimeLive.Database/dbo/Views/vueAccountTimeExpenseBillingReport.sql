
CREATE VIEW dbo.vueAccountTimeExpenseBillingReport
AS
SELECT     dbo.AccountTimeExpenseBilling.InvoiceNumber, dbo.AccountTimeExpenseBilling.InvoiceDate, ISNULL(dbo.AccountTimeExpenseBilling.PONumber, 0) 
                      AS PONumber, ISNULL(dbo.AccountTimeExpenseBilling.SubTotal, 0) AS SubTotal, ISNULL(dbo.AccountTimeExpenseBilling.TaxCode1, 0) AS TaxCode1, 
                      ISNULL(dbo.AccountTimeExpenseBilling.TaxCode2, 0) AS TaxCode2, ISNULL(dbo.AccountTimeExpenseBilling.GrandTotal, 0) AS GrandTotal, 
                      dbo.AccountTimeExpenseBilling.AccountId, dbo.AccountTimeExpenseBillingTimesheet.Description AS [Detail Description], 
                      ISNULL(dbo.AccountTimeExpenseBillingTimesheet.ActualBillingRate, 0) AS ActualBillingRate, 
                      ISNULL(dbo.AccountTimeExpenseBillingTimesheet.BillHours, 0) AS BillHours, ISNULL(dbo.AccountTimeExpenseBillingTimesheet.TotalAmount, 0) 
                      AS TotalAmount, dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId, dbo.AccountParty.PartyName, 
                      dbo.AccountTimeExpenseBilling.Description AS [Master Description], dbo.AccountParty.Address1, dbo.AccountParty.Address2, 
                      dbo.Account.AccountName, dbo.Account.Address1 AS AccountAddress1, dbo.Account.ZipCode, dbo.Account.State, dbo.Account.City, 
                      dbo.Account.Telephone, dbo.Account.Address2 AS AccountAddress2, dbo.AccountTimeExpenseBilling.AccountCurrencyId, 
                      dbo.SystemCurrency.CurrencyCode, dbo.AccountPreferences.InvoiceNoPrefix, dbo.AccountParty.State AS ClientState, 
                      dbo.AccountParty.City AS ClientCity, dbo.AccountParty.ZipCode AS ClientZipcode, dbo.AccountParty.Telephone1 AS ClientTelephone, 
                      dbo.AccountParty.Fax AS ClientFax, SystemCountry_1.Country AS AccountCountry, dbo.SystemCountry.Country AS ClientCountry, 
                      dbo.AccountTimeExpenseBilling.Terms, dbo.AccountTimeExpenseBilling.BankDetails, dbo.AccountProject.ProjectName, 
                      AccountProject_1.ProjectName AS MasterProjectName, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountTimeExpenseBilling.BillingCycleStartDate, dbo.AccountTimeExpenseBilling.BillingCycleEndDate, 
                      dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName AS EmployeeName, AccountProject_1.ProjectCode AS MasterProjectCode, 
                      dbo.AccountProjectTask.TaskName
FROM         dbo.AccountProject RIGHT OUTER JOIN
                      dbo.AccountProjectTask RIGHT OUTER JOIN
                      dbo.AccountEmployeeTimeEntry RIGHT OUTER JOIN
                      dbo.AccountTimeExpenseBillingTimesheet ON 
                      dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId = dbo.AccountTimeExpenseBillingTimesheet.AccountEmployeeTimeEntryId LEFT OUTER
                       JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployee.AccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId ON 
                      dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountTimeExpenseBillingTimesheet.AccountProjectTaskId RIGHT OUTER JOIN
                      dbo.AccountCurrency INNER JOIN
                      dbo.AccountTimeExpenseBilling ON dbo.AccountCurrency.AccountCurrencyId = dbo.AccountTimeExpenseBilling.AccountCurrencyId INNER JOIN
                      dbo.SystemCurrency ON dbo.AccountCurrency.SystemCurrencyId = dbo.SystemCurrency.CurrencyId LEFT OUTER JOIN
                      dbo.SystemCountry RIGHT OUTER JOIN
                      dbo.AccountParty ON dbo.SystemCountry.CountryId = dbo.AccountParty.CountryId RIGHT OUTER JOIN
                      dbo.Account ON dbo.AccountParty.AccountId = dbo.Account.AccountId LEFT OUTER JOIN
                      dbo.SystemCountry AS SystemCountry_1 ON dbo.Account.CountryId = SystemCountry_1.CountryId LEFT OUTER JOIN
                      dbo.AccountPreferences ON dbo.Account.AccountId = dbo.AccountPreferences.AccountId ON 
                      dbo.AccountTimeExpenseBilling.AccountClientId = dbo.AccountParty.AccountPartyId ON 
                      dbo.AccountTimeExpenseBillingTimesheet.AccountTimeExpenseBillingId = dbo.AccountTimeExpenseBilling.AccountTimeExpenseBillingId LEFT OUTER
                       JOIN
                      dbo.AccountProject AS AccountProject_1 ON dbo.AccountTimeExpenseBilling.AccountProjectId = AccountProject_1.AccountProjectId ON 
                      dbo.AccountProject.AccountProjectId = dbo.AccountTimeExpenseBillingTimesheet.AccountProjectId