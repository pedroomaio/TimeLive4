Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace dsDepartmentWiseTimesheetReportForXtrReportTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryAdapter

        Public Function GetDataByDepartmentWiseTimeSheetReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountPartyId As Integer, ByVal AccountLocationId As Integer, ByVal Submitted As String, ByVal Billable As String, ByVal AccountDepartmentId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As dsDepartmentWiseTimesheetReportForXtrReport.vueAccountEmployeeTimeEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountEmployeeTimeEntry where "

            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            If AccountProjectId <> 0 Then
                sql = sql + " and (AccountProjectId = @AccountProjectId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId
            End If

            If AccountProjectTaskId <> 0 Then
                sql = sql + " and (AccountProjectTaskId = @AccountProjectTaskId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectTaskId").Value = AccountProjectTaskId
            End If

            If AccountPartyId <> 0 Then
                sql = sql + " and (AccountPartyId = @AccountPartyId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountPartyId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountPartyId").Value = AccountPartyId
            End If

            If AccountLocationId <> 0 Then
                sql = sql + " and (AccountLocationId = @AccountLocationId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountLocationId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountLocationId").Value = AccountLocationId
            End If

            If Submitted = -1 Then
                sql = sql + " and (Submitted = Submitted)"
            ElseIf Submitted = 0 Then
                sql = sql + " and (Submitted <> 1) "
            ElseIf Submitted = 1 Then
                sql = sql + " and (Submitted = 1) "
            End If

            If Billable = -1 Then
                sql = sql + " and ((IsBillable is null) or (IsBillable = 1) or (IsBillable = 0))"
            ElseIf Billable = 0 Then
                sql = sql + " and ((IsBillable <> 1) or (IsBillable is null))"
            ElseIf Billable = 1 Then
                sql = sql + " and ((IsBillable = 1))"
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Billable", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Billable").Value = Billable

            If AccountDepartmentId <> 0 Then
                sql = sql + " and (AccountDepartmentId = @AccountDepartmentId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountDepartmentId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountDepartmentId").Value = AccountDepartmentId
            End If

            If IncludeDateRange = True Then
                sql = sql + " and (TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate) "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As dsDepartmentWiseTimesheetReportForXtrReport.vueAccountEmployeeTimeEntryDataTable = New dsDepartmentWiseTimesheetReportForXtrReport.vueAccountEmployeeTimeEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class
End Namespace

