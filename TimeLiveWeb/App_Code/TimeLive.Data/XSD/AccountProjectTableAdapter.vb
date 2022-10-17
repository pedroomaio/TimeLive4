Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace TimeLiveDataSetTableAdapters
    Public Class AccountProjectTableAdapter

        Public Function GetAssignedDataByEmployeeIdProjectIdAndCompleted(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As Boolean, Optional ByVal IsTemplate As Boolean = False, Optional ByVal AccountId As Integer = -1, Optional ByVal IsFromCSV As Boolean = False, Optional ByVal ProjectName As String = "") As TimeLiveDataSet.AccountProjectDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountProject "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If
            sql = sql & "(IsTemplate = 0) AND "
            If Completed <> True Then
                sql = sql & "(Completed = 0) And "
            End If
            sql = sql & "(AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId = " & AccountEmployeeId & "))) AND "
            sql = sql & "(IsDeleted <> 1 OR IsDeleted Is NULL) AND (IsDisabled <> 1) "
            If IsFromCSV Then
                sql = sql & " And (ProjectName = '" & ProjectName & "') "
            End If
            sql = sql & " OR (AccountProjectId = " & AccountProjectId & ") "
            sql = sql & "ORDER BY ProjectName"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.AccountProjectDataTable = New TimeLiveDataSet.AccountProjectDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetAssignedDataByEmployeeIdClientIdAndCompleted(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer, ByVal Completed As Boolean, Optional ByVal AccountId As Integer = -1) As TimeLiveDataSet.AccountProjectDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountProject "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If
            sql = sql & "(AccountClientId = " & AccountClientId & ") AND (IsTemplate = 0) AND "
            If Completed <> True Then
                sql = sql & "(Completed = 0) And "
            End If
            sql = sql & "(AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId = " & AccountEmployeeId & "))) AND "
            sql = sql & "(IsDeleted <> 1 OR IsDeleted Is NULL) AND (IsDisabled <> 1) OR (AccountProjectId = " & AccountProjectId & ") "
            sql = sql & "ORDER BY ProjectName"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.AccountProjectDataTable = New TimeLiveDataSet.AccountProjectDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function UpdateProjectCustomFieldByCustomFieldId(CustomFieldColumnName As String, AccountId As Integer)
            Dim objConnection As SqlConnection
            objConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()
            Dim sqlCommand As New SqlClient.SqlCommand
            sqlCommand.Connection = objConnection
            Dim strSQL As String = "Update AccountProject Set " & CustomFieldColumnName & " = NULL Where AccountId = " & AccountId
            sqlCommand.CommandText = strSQL
            sqlCommand.CommandTimeout = 1000
            Dim recordsAffected As Integer
            recordsAffected = sqlCommand.ExecuteNonQuery()
            objConnection.Close()
        End Function
        Public Function GetAccountProjectsByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountProject "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") "
            End If
            sql = sql & "AND (IsDeleted <> 1 OR IsDeleted Is NULL) AND (IsDisabled <> 1) "
            sql = sql & "ORDER BY ProjectName"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.AccountProjectDataTable = New TimeLiveDataSet.AccountProjectDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetAccountProjectsByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String) As TimeLiveDataSet.AccountProjectDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountProject "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") "
            End If
            sql = sql & "AND (IsDeleted <> 1 OR IsDeleted Is NULL) AND (IsDisabled <> 1) "

            sql = sql & "and " & DatabaseFieldName & " is not null "

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.AccountProjectDataTable = New TimeLiveDataSet.AccountProjectDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetProjectsByAccountIdAndAccountProjectIdNotDeleted(ByVal AccountId As Integer, ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountProject "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If
            sql = sql & " (AccountProjectId = " & AccountProjectId & ") "
            sql = sql & "AND IsNull(IsDeleted,0) <> 1 AND IsNull(IsDisabled,0) <> 1 "
            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.AccountProjectDataTable = New TimeLiveDataSet.AccountProjectDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace