Imports Microsoft.VisualBasic

Public Class ExpenseEntryListForMobile
    Public AccountEmployeeExpenseSheetId As String
    Public AccountExpenseEntryId As Integer
    Public AccountExpenseId As Integer
    Public AccountExpenseName As String
    Public ExpenseEntryDescription As String
    Public ExpenseEntryAmount As Double
    Public ExpenseEntryCurrencyCode As String
    Public AccountTaxCodeId As Integer
    Public AccountTaxZoneId As Integer
    Public AccountPaymentMethodId As Integer
    Public AccountClientId As Integer
    Public AccountProjectId As Integer
    Public AccountProjectTaskId As Integer
    Public NetAmount As Double
    Public Reimburse As Boolean
    Public Billable As Boolean
    Public Quantity As Double
    Public Rate As Double
    Public TaxAmount As Double
    Public IsShowClient As Boolean = False
    Public IsShowTask As Boolean = False
End Class
