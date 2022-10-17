Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace dsReportFilterSourceTableAdapters
    Public Class ClientFilterTableAdapter

        Public Function GetDataByAccountIdAndAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As dsReportFilterSource.ClientFilterDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from accountparty where (IsDisabled <> 1) And accountpartyid in "

            sql = sql & "(Select AccountClientId from AccountProject Where AccountProjectId in"

            sql = sql & "(Select AccountProjectId from AccountPRojectEmployee Where AccountEmployeeId = " & AccountEmployeeId & ") OR (LeaderEmployeeId = " & AccountEmployeeId & ") OR (ProjectManagerEmployeeId = " & AccountEmployeeId & ") And (IsTemplate <> 1))"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As dsReportFilterSource.ClientFilterDataTable = New dsReportFilterSource.ClientFilterDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace
