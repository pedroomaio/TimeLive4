Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace AccountEmployeeTableAdapters
    Public Class AccountEmployeeTableAdapter
        Public Function UpdateEmployeeCustomFieldByCustomFieldId(CustomFieldColumnName As String, AccountId As Integer)
            Dim objConnection As SqlConnection
            objConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()
            Dim sqlCommand As New SqlClient.SqlCommand
            sqlCommand.Connection = objConnection
            Dim strSQL As String = "Update AccountEmployee Set " & CustomFieldColumnName & " = NULL Where AccountId = " & AccountId
            sqlCommand.CommandText = strSQL
            sqlCommand.CommandTimeout = 1000
            Dim recordsAffected As Integer
            recordsAffected = sqlCommand.ExecuteNonQuery()
            objConnection.Close()
        End Function
        Public Function GetDataByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String)
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountEmployee "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If

            sql = sql & "(IsDeleted <> 1) AND (IsDisabled <> 1) "

            sql = sql & "and " & DatabaseFieldName & " is not null "


            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployee.AccountEmployeeDataTable = New AccountEmployee.AccountEmployeeDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetDataByEmployeeNameAndEmailAddress(ByVal AccountId As Integer, ByVal EmployeeName As String, ByVal EmailAddress As String)
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountEmployee "
            sql = sql & "WHERE (AccountId = @AccountId AND FirstName + ' ' + LastName = @EmployeeName AND IsDisabled <> 1 AND IsDeleted <> 1) "
            sql = sql & "OR (AccountId = @AccountId AND EmailAddress = @EmailAddress AND IsDisabled <> 1 AND IsDeleted <> 1)"

            Me.Adapter.SelectCommand.CommandText = sql
            Me.Adapter.SelectCommand.Parameters.AddWithValue("@AccountId", AccountId)
            Me.Adapter.SelectCommand.Parameters.AddWithValue("@EmployeeName", EmployeeName)
            Me.Adapter.SelectCommand.Parameters.AddWithValue("@EmailAddress", EmailAddress)

            Dim dataTable As AccountEmployee.AccountEmployeeDataTable = New AccountEmployee.AccountEmployeeDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetDataByEmployeeUsername(ByVal Username As String) As AccountEmployee.AccountEmployeeDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountEmployee"
            sql = sql & " WHERE Username = @Username or EmployeeCode = @Username"

            Me.Adapter.SelectCommand.CommandText = sql
            Me.Adapter.SelectCommand.Parameters.AddWithValue("@Username", Username)

            Dim dataTable As AccountEmployee.AccountEmployeeDataTable = New AccountEmployee.AccountEmployeeDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
    Public Class vueAccountEmployeeTableAdapter
        Public Function GetDataByAccountIdForGridView(ByVal AccountId As Integer, Optional ByVal AccountEmployeeId As Integer = 0) As AccountEmployee.vueAccountEmployeeDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountEmployee "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If

            sql = sql & "(IsDeleted <> 1) AND (IsDisabled <> 1) "
            If AccountEmployeeId = 0 Then
                sql = sql & "ORDER BY EmployeeName "
            Else
                sql = sql & "ORDER BY AccountEmployeeId "
            End If


            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployee.vueAccountEmployeeDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace