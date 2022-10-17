Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace TimeLiveDataSetTableAdapters
    Public Class AccountProjectTaskTableAdapter
        Public Function UpdateAccountProjectTaskMassUpdate(value1 As String, value2 As String, value3 As String, value4 As String, value5 As String, value6 As String, AccountProjectTaskId As Integer)
            Dim sql As String
            Dim objConnection As SqlConnection
            objConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()
            Dim sqlCommand As New SqlClient.SqlCommand
            sqlCommand.Connection = objConnection
            sql = "Update AccountProjectTask Set "
            
            If value1 <> "" Then
                sql = sql & "Duration = " & value1
            End If
            If value2 <> "" Then
                sql = sql & IIf(value1 <> "", ",CompletedPercent = " & value2, "CompletedPercent = " & value2)
            End If
            If value3 <> 0 Then
                sql = sql & IIf(value1 <> "" Or value2 <> "", ",TaskStatusId = " & value3, "TaskStatusId = " & value3)
            End If
            If value4 <> 0 Then
                sql = sql & IIf(value1 <> "" Or value2 <> "" Or value3 <> 0, ",AccountPriorityId = " & value4, "AccountPriorityId = " & value4)
            End If
            If value5 <> 0 Then
                sql = sql & IIf(value1 <> "" Or value2 <> "" Or value3 <> 0 Or value4 <> 0, ",AccountTaskTypeId = " & value5, "AccountTaskTypeId = " & value5)
            End If
            If value6 <> "" Then
                sql = sql & IIf(value1 <> "" Or value2 <> "" Or value3 <> 0 Or value4 <> 0 Or value5 <> 0, ",TaskName = " & "'" & value6 & "'", "TaskName = " & "'" & value6 & "'")
            End If

            sql = sql & " Where AccountProjectTaskId = " & AccountProjectTaskId & " "
            sqlCommand.CommandText = sql
            sqlCommand.CommandTimeout = 1000
            Dim recordsAffected As Integer
            recordsAffected = sqlCommand.ExecuteNonQuery()
            objConnection.Close()
        End Function
        Public Function GetDataByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String)
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountProjectTask "
            sql = sql & "WHERE  "
            If AccountId <> -1 Then
                sql = sql & "AccountProjectId in (select AccountProjectId from AccountProject where AccountId  = " & AccountId & ") And "
            End If

            sql = sql & "(IsDeleted <> 1) AND (IsDisabled <> 1) "

            sql = sql & "and " & DatabaseFieldName & " is not null "


            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.AccountProjectTaskDataTable = New TimeLiveDataSet.AccountProjectTaskDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace

