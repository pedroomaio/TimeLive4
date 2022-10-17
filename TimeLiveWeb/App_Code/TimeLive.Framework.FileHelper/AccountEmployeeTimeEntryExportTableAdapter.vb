Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace TimeLiveFileHelperTableAdapters


    Public Class AccountEmployeeTimeEntryExportTableAdapter

        Public Function GetDataByAccountId(ByVal WhereClause As String) As TimeLiveFileHelper.AccountEmployeeTimeEntryExportDataTable

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            Dim Sql As String = "SELECT TimeEntryDate, EmployeeCode, DepartmentName, EmployeeName, ProjectCode, ProjectName, TaskCode, TaskName, Description, PartyName, "
            Sql = Sql & "CONVERT(varchar(10),StartTime, 108) AS StartTime, CONVERT(varchar(10), EndTime, 108) AS EndTime, CONVERT(varchar(10), "
            Sql = Sql & "TotalTime, 108) AS TotalTime, Approved, TotalMinutes, IsBillable, Rejected, BillingRate, Submitted, AccountWorkType, "
            Sql = Sql & "EMailAddress, AccountLocation, Comments, AccountCostCenter FROM vueAccountEmployeeTimeEntry "

            Sql = Sql + "Where (IsTimeOff is null OR IsTimeOff = 0) and " & WhereClause


            Me.Adapter.SelectCommand.CommandText = Sql

            Dim dataTable As TimeLiveFileHelper.AccountEmployeeTimeEntryExportDataTable = New TimeLiveFileHelper.AccountEmployeeTimeEntryExportDataTable

            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetDecimalDataByAccountId(ByVal WhereClause As String) As TimeLiveFileHelper.AccountEmployeeTimeEntryExportDataTable

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            Dim Sql As String = "SELECT TimeEntryDate, EmployeeCode, DepartmentName, EmployeeName, ProjectCode, ProjectName, TaskCode, TaskName, Description, PartyName, "
            Sql = Sql & "CONVERT(varchar(10),StartTime, 108) AS StartTime, CONVERT(varchar(10), EndTime, 108) AS EndTime, CONVERT(varchar(10), "
            Sql = Sql & "Hours, 108) AS TotalTime, Approved, TotalMinutes, IsBillable, Rejected, BillingRate, Submitted, AccountWorkType, "
            Sql = Sql & "EMailAddress, AccountLocation, Comments, AccountCostCenter FROM vueAccountEmployeeTimeEntry "

            Sql = Sql + "Where (IsTimeOff is null OR IsTimeOff = 0) and " & WhereClause


            Me.Adapter.SelectCommand.CommandText = Sql

            Dim dataTable As TimeLiveFileHelper.AccountEmployeeTimeEntryExportDataTable = New TimeLiveFileHelper.AccountEmployeeTimeEntryExportDataTable

            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace
