Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace dsTaskSummaryTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryTableAdapter

        Public Function GetDataByTaskSummary(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountPartyId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountLocationId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal Approval As String, ByVal Submitted As String, ByVal Billable As String) As dsTaskSummary.vueAccountEmployeeTimeEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT PartyName, ProjectName, TaskName, IsNull(SUM(TotalMinutes),0) AS TotalMinutes, IsNull(EstimatedTimeSpent,0) as EstimatedTimeSpent, IsNull(EstimatedCost,0) as EstimatedCost, IsNull(sum(BillingRate),0) AS BillingRate FROM vueAccountEmployeeTimeEntry where "

            sql = sql + " (AccountId = @AccountId) "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            sql = sql + " and (AccountEmployeeId in (" & AccountEmployees & ")) "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            If AccountPartyId <> 0 Then
                sql = sql + " and (AccountPartyId = @AccountPartyId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountPartyId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountPartyId").Value = AccountPartyId
            End If

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

            If AccountLocationId <> 0 Then
                sql = sql + " and (AccountLocationId = @AccountLocationId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountLocationId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountLocationId").Value = AccountLocationId
            End If

            If IncludeDateRange = True Then
                sql = sql + " and (TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate) "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            If Approval = -1 Then
                sql = sql + " and (Approved = Approved)"
            ElseIf Approval = 0 Then
                sql = sql + " and (Approved <> 1) "
            ElseIf Approval = 1 Then
                sql = sql + " and (Approved = 1) "
            End If

            If Submitted = -1 Then
                sql = sql + " and (Submitted = Submitted)"
            ElseIf Submitted = 0 Then
                sql = sql + " and (Submitted <> 1) "
            ElseIf Submitted = 1 Then
                sql = sql + " and (Submitted = 1) "
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Approval", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Approval").Value = Approval

            If Billable = -1 Then
                sql = sql + " and ((IsBillable is null) or (IsBillable = 1) or (IsBillable = 0))"
            ElseIf Billable = 0 Then
                sql = sql + " and ((IsBillable <> 1) or (IsBillable is null))"
            ElseIf Billable = 1 Then
                sql = sql + " and ((IsBillable = 1))"
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Billable", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Billable").Value = Billable

            sql = sql + "GROUP BY PartyName, ProjectName, TaskName, EstimatedTimeSpent, EstimatedCost"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As dsTaskSummary.vueAccountEmployeeTimeEntryDataTable = New dsTaskSummary.vueAccountEmployeeTimeEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function


    End Class
End Namespace

