Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace TimeLiveFileHelperTableAdapters


    Public Class AccountEmployeeTimeEntryExportQBTableAdapter

        Public Function GetDataByAccountId(ByVal WhereClause As String) As TimeLiveFileHelper.AccountEmployeeTimeEntryExportQBDataTable

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            Dim Sql As String = "SELECT 'TIMEACT' AS [!TIMEACT], LEFT(CONVERT(varchar, TimeEntryDate, 1), 8) AS DATE, EmployeeName AS EMP, PartyName AS JOB, Description AS NOTE, "
            Sql = Sql & "LEFT(CONVERT(varchar(8), TotalTime, 8), 5) AS DURATION, CAST(IsBillable AS smallint) AS BILLINGSTATUS, TaskCode AS ITEM, ProjectName AS PROJ"
            Sql = Sql & " FROM vueAccountEmployeeTimeEntry "

            Sql = Sql + "Where (IsTimeOff is null OR IsTimeOff = 0) and " & WhereClause

            Me.Adapter.SelectCommand.CommandText = Sql

            Dim dataTable As TimeLiveFileHelper.AccountEmployeeTimeEntryExportQBDataTable = New TimeLiveFileHelper.AccountEmployeeTimeEntryExportQBDataTable

            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class
End Namespace
