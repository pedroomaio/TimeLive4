Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountExpenseEntryApprovalPendingEmailWithPreferenceGroupByApproverEmployeeIdTableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
End Namespace
