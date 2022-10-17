Imports Microsoft.VisualBasic

Public Class ExpenseApprovalObject
    Public EmployeeName As String = ""
    Public ExpenseSheetDescription As String = ""
    Public ExpenseSheetDate As Date = Now.Date
    Public ExpenseSheetAmount As Double = 0
    Public AccountEmployeeExpenseSheetId As Object = ""
    Public ExpenseEntryAccountEmployeeId As Integer = 0
End Class
