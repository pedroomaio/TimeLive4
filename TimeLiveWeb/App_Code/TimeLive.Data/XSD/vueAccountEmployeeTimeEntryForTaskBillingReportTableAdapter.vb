Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryForTaskBillingReportTableAdapter


        Public Function GetDataByAccountIdAndEmployees(ByVal AccountId As Integer, ByVal AccountPartyId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal Billable As String) As TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "SELECT MAX(BillingRate) AS BillingRate, MAX(BillingType) AS BillingType, EmployeeName, PartyName, ProjectName, TaskName, SUM(TotalMinutes) AS TotalMinutes FROM vueAccountEmployeeTimeEntry where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            sql = sql + "("

            If AccountPartyId <> 0 Then
                sql = sql + "(AccountPartyId = @AccountPartyId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountPartyId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountPartyId").Value = AccountPartyId

            End If

            If AccountProjectId <> 0 Then
                sql = sql + "(AccountProjectId = @AccountProjectId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If AccountProjectTaskId <> 0 Then
                sql = sql + "(AccountProjectTaskId = @AccountProjectTaskId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectTaskId").Value = AccountProjectTaskId

            End If

            If IncludeDateRange = True Then
                sql = sql + "((TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate)) and "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            sql = sql + "(Approved = 1)"

            sql = sql + " and "
            If Billable = -1 Then
                sql = sql + "((IsBillable is null) or (IsBillable = 1) or (IsBillable = 0))"
            ElseIf Billable = 0 Then
                sql = sql + "((IsBillable <> 1) or (IsBillable is null))"
            ElseIf Billable = 1 Then
                sql = sql + "((IsBillable = 1))"
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Billable", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Billable").Value = Billable

            sql = sql + ") "

            sql = sql + "GROUP BY TaskName, EmployeeName, PartyName, ProjectName"



            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

        Public Function GetDataByTaskSummaryReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountPartyId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT EmployeeName, PartyName, ProjectName, TaskName, SUM(TotalMinutes) AS TotalMinutes, EstimatedTimeSpent, EstimatedCost, MAX(BillingRate) AS BillingRate FROM vueAccountEmployeeTimeEntry where "

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

            sql = sql + "GROUP BY TaskName, EmployeeName, PartyName, ProjectName,EstimatedTimeSpent, EstimatedCost"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryForTaskBillingReportDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function


    End Class
End Namespace

