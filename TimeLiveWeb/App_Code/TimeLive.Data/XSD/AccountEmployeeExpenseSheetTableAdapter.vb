Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace AccountExpenseEntryTableAdapters
    Public Class AccountEmployeeExpenseSheetTableAdapter
        Public Function GetDataByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String)
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountEmployeeExpensesheet "
            sql = sql & "WHERE  "
            If AccountId <> -1 Then
                sql = sql & "AccountId  = " & AccountId & ") "
            End If

            sql = sql & "And " & DatabaseFieldName & " is not null "


            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = New AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace

