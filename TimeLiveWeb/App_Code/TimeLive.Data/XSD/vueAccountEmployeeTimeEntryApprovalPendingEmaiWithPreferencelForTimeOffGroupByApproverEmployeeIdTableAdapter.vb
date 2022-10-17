Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace AccountEmployeeTimeOffRequestTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryApprovalPendingEmaiWithPreferencelForTimeOffGroupByApproverEmployeeIdTableAdapter
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
End Namespace
