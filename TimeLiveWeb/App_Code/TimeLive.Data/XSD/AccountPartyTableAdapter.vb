Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace TimeLiveDataSetTableAdapters
    Public Class AccountPartyTableAdapter
        Public Function UpdateClientCustomFieldByCustomFieldId(CustomFieldColumnName As String, AccountId As Integer)
            Dim objConnection As SqlConnection
            objConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()
            Dim sqlCommand As New SqlClient.SqlCommand
            sqlCommand.Connection = objConnection
            Dim strSQL As String = "Update AccountParty Set " & CustomFieldColumnName & " = NULL Where AccountId = " & AccountId
            sqlCommand.CommandText = strSQL
            sqlCommand.CommandTimeout = 1000
            Dim recordsAffected As Integer
            recordsAffected = sqlCommand.ExecuteNonQuery()
            objConnection.Close()
        End Function
    End Class
    Public Class vueAccountPartyTableAdapter
        Public Function GetDataByAccountIdForGridView(ByVal AccountId As Integer, Optional ByVal AccountPartyId As Integer = 0) As TimeLiveDataSet.vueAccountPartyDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountParty "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If

            sql = sql & "(IsDeleted <> 1) "
            If AccountPartyId = 0 Then
                sql = sql & "ORDER BY PartyName "
            Else
                sql = sql & "ORDER BY AccountPartyId "
            End If


            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountPartyDataTable = New TimeLiveDataSet.vueAccountPartyDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
    Public Class AccountPartyTableAdapter
        Public Function GetDataByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, Optional ByVal DatabaseFieldName As String = "") As TimeLiveDataSet.AccountPartyDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountParty "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If

            sql = sql & "(IsDeleted <> 1) AND (IsDisabled <> 1) "


            sql = sql & "and " & DatabaseFieldName & " is not null "



            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.AccountPartyDataTable = New TimeLiveDataSet.AccountPartyDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
    Public Class vueAccountPartyTableAdapter
        Public Function GetDataByAccountIdForDropdownList(ByVal AccountId As Integer, Optional ByVal AccountPartyId As Integer = 0) As TimeLiveDataSet.vueAccountPartyDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountParty "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If

            sql = sql & "(IsDeleted <> 1) AND (IsDisabled <> 1) "
            If AccountPartyId = 0 Then
                sql = sql & "ORDER BY PartyName "
            Else
                sql = sql & "ORDER BY AccountPartyId "
            End If


            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountPartyDataTable = New TimeLiveDataSet.vueAccountPartyDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
    Public Class vueAccountPartyTableAdapter
        Public Function GetClientsByAccountIdAndClientIdNotDeleted(ByVal AccountId As Integer, ByVal AccountPartyId As Integer) As TimeLiveDataSet.vueAccountPartyDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountParty "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If

            sql = sql & " (AccountPartyId = " & AccountPartyId & ") "
            sql = sql & "AND IsNull(IsDeleted,0) <> 1 AND IsNull(IsDisabled,0) <> 1 "

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountPartyDataTable = New TimeLiveDataSet.vueAccountPartyDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace