Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace AccountEmployeeTableAdapters
    Partial Public Class vueAccountEmployeeTableAdapter
        Public Function GetvueAccountEmployeeForReport(ByVal WhereClause As String, Optional ByVal OrderColumnName As String = "") As AccountEmployee.vueAccountEmployeeDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
                sql = "Select TOP(3) * from vueAccountEmployee WITH (NOLOCK) " & WhereClause
            Else
                sql = "Select * from vueAccountEmployee WITH (NOLOCK) " & WhereClause
            End If


            If OrderColumnName <> "" Then
                sql = sql & " Order By " & OrderColumnName
            End If

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployee.vueAccountEmployeeDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetEmployeesRowCount(ByVal AccountId As Integer) As AccountEmployee.vueAccountEmployeeDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountEmployee "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") "
            End If

            sql = sql & "AND IsNull(IsDeleted,0) <> 1"
            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployee.vueAccountEmployeeDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace
