Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveFileHelperTableAdapters
    Public Class AccountEmployeeTimeEntryExportForOfflineTimesheetTableAdapter
        Public Function GetDataByAccountIdForOfflineTimesheet(ByVal WhereClause As String) As TimeLiveFileHelper.AccountEmployeeTimeEntryExportForOfflineTimesheetDataTable

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            Dim Sql As String = "SELECT TimeEntryDate, ProjectName, TaskName, Description, "
            Sql = Sql & "CONVERT(varchar(10),StartTime, 108) AS StartTime, CONVERT(varchar(10), EndTime, 108) AS EndTime, CONVERT(varchar(10), "
            Sql = Sql & "TotalTime, 108) AS TotalTime FROM vueAccountEmployeeTimeEntry "

            Sql = Sql + "Where (IsTimeOff is null OR IsTimeOff = 0) and " & WhereClause


            Me.Adapter.SelectCommand.CommandText = Sql

            Dim dataTable As TimeLiveFileHelper.AccountEmployeeTimeEntryExportForOfflineTimesheetDataTable = New TimeLiveFileHelper.AccountEmployeeTimeEntryExportForOfflineTimesheetDataTable

            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace
