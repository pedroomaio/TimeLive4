Imports Microsoft.VisualBasic

Public Class EntryArchiveFilter

    Public Enum SearchForEnum
        Sheet = 0
        Entry = 1
    End Enum
    Public Property AccountEmployeeId As Integer
    Public Property Approved As Decimal
    Public Property ExpenseTypes As String
    Public Property PaymentStatusId As Integer
    Public Property IncludeDataRange As Boolean
    Public Property StartDate As DateTime
    Public Property EndDate As DateTime
    Public Property SearchFor As SearchForEnum
    Public Property ExpenseSheetId As List(Of Guid)


End Class
