Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace AccountEmployeeTimeOffRequestTableAdapters
    Partial Public Class vueAccountEmployeeTimeOffRequestApprovalPendingTableAdapter
        Public Function GetApprovalEntriesForSpecificEmployee(ByVal AccountTimeOffTypeId As Guid, ByVal TimeOffAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeOffRequestApprovalPending where "

            sql = sql + " (AccountEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 3) and "

            sql = sql + "("

            sql = sql + " (ApprovalPathSequence = 1)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 2)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 3)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 4)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 5)"

            sql = sql + ")"

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "StartDate >= @StartDate and EndDate <= @EndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@StartDate").Value = StartDate

                Me.Adapter.SelectCommand.Parameters.Add("@EndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@EndDate").Value = EndDate
            End If

            If AccountTimeOffTypeId <> System.Guid.Empty Then
                sql = sql + "AccountTimeOffTypeId = '" & AccountTimeOffTypeId.ToString & "' and"
            End If

            If TimeOffAccountEmployeeId <> 0 Then
                sql = sql + " TimeOffAccountEmployeeId = @TimeOffAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@TimeOffAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeOffAccountEmployeeId").Value = TimeOffAccountEmployeeId

            End If

            sql = sql + " Approved = 0 or Approved Is null) and (Rejected Is Null or Rejected = 0) "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable = New AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForEmployeeManager(ByVal AccountTimeOffTypeId As Guid, ByVal TimeOffAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeOffRequestApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee
            sql = sql + " (EmployeeManagerId = @AccountEmployeeId ) and (SystemApproverTypeId = 5) and "

            sql = sql + "("

            sql = sql + " (ApprovalPathSequence = 1)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 2)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 3)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 4)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 5)"

            sql = sql + ")"

            ' General Check

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "StartDate >= @StartDate and EndDate <= @EndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@StartDate").Value = StartDate

                Me.Adapter.SelectCommand.Parameters.Add("@EndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@EndDate").Value = EndDate
            End If

            If AccountTimeOffTypeId <> System.Guid.Empty Then
               sql = sql + "AccountTimeOffTypeId = '" & AccountTimeOffTypeId.ToString & "' and"
            End If

            If TimeOffAccountEmployeeId <> 0 Then
                sql = sql + " TimeOffAccountEmployeeId = @TimeOffAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@TimeOffAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeOffAccountEmployeeId").Value = TimeOffAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + " Approved = 0 or Approved Is Null) and (Rejected Is Null or Rejected = 0) "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable = New AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForProjectManager(ByVal AccountTimeOffTypeId As Guid, ByVal TimeOffAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeOffRequestApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee
            sql = sql + " (ProjectManagerId = @AccountEmployeeId ) and (SystemApproverTypeId = 2) and "

            sql = sql + "("

            sql = sql + " (ApprovalPathSequence = 1)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 2)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 3)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 4)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 5)"

            sql = sql + ")"

            ' General Check

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "StartDate >= @StartDate and EndDate <= @EndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@StartDate").Value = StartDate

                Me.Adapter.SelectCommand.Parameters.Add("@EndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@EndDate").Value = EndDate
            End If

            If AccountTimeOffTypeId <> System.Guid.Empty Then
                sql = sql + "AccountTimeOffTypeId = '" & AccountTimeOffTypeId.ToString & "' and"
            End If

            If TimeOffAccountEmployeeId <> 0 Then
                sql = sql + " TimeOffAccountEmployeeId = @TimeOffAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@TimeOffAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeOffAccountEmployeeId").Value = TimeOffAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + " Approved = 0 or Approved Is Null) and (Rejected Is Null or Rejected = 0) "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable = New AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForTeamLead(ByVal AccountTimeOffTypeId As Guid, ByVal TimeOffAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeOffRequestApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee
            sql = sql + " (TeamLeadId = @AccountEmployeeId ) and (SystemApproverTypeId = 1) and "

            sql = sql + "("

            sql = sql + " (ApprovalPathSequence = 1)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 2)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 3)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 4)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 5)"

            sql = sql + ")"

            ' General Check

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "StartDate >= @StartDate and EndDate <= @EndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@StartDate").Value = StartDate

                Me.Adapter.SelectCommand.Parameters.Add("@EndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@EndDate").Value = EndDate
            End If

            If AccountTimeOffTypeId <> System.Guid.Empty Then
                sql = sql + "AccountTimeOffTypeId = '" & AccountTimeOffTypeId.ToString & "' and"
            End If

            If TimeOffAccountEmployeeId <> 0 Then
                sql = sql + " TimeOffAccountEmployeeId = @TimeOffAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@TimeOffAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeOffAccountEmployeeId").Value = TimeOffAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + " Approved = 0 or Approved Is Null) and (Rejected Is Null or Rejected = 0) "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable = New AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
    End Class
End Namespace

