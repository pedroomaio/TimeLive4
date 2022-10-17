Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace AccountEmployeeTimeEntryTableAdapters

    Public Class vueAccountEmployeeTimeEntryApprovalPendingForTimeOffTableAdapter

        Public Function GetApprovalEntriesForSpecificEmployee(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntryApprovalPendingForTimeOff where "

            'For TeamLead
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

            If IncludeDateRange = True Then
                sql = sql + " and (TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate) "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If


            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + " and (TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId) "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            sql = sql + " Order By TimeEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForEmployeeManager(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntryApprovalPendingForTimeOff where "

            'For TeamLead
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

            If IncludeDateRange = True Then
                sql = sql + " and (TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate) "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If


            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + " and (TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId) "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId
            End If

            sql = sql + " Order By TimeEntryDate desc"

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

        Public Function GetApprovalEntriesForProjectManagerTimeOff(ByVal ProjectManagerId As Integer, ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal IncludeDateRange As Boolean) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select vue.* From vueAccountEmployeeTimeEntryApprovalPendingForTimeOff As vue "


            sql = sql + "Inner Join AccountEmployeeTimeEntry as Te on(vue.AccountEmployeeTimeEntryId = Te.AccountEmployeeTimeEntryId) "

            sql = sql + "Inner Join AccountProject As Ap on (Te.AccountProjectId = Ap.AccountProjectId ) "


            sql = sql + "where Te.IsTimeOff = 1 And Te.AccountEmployeeTimeOffRequestId Is null And ap.ProjectManagerEmployeeId = @ProjectManager And Te.Approved = 0 And Te.Rejected = 0 And Te.Submitted = 1 "

            If IncludeDateRange Then
                sql = sql + " and (Te.TimeEntryDate >= @TimeEntryStartDate and Te.TimeEntryDate <= @TimeEntryEndDate) "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + " and (TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId) "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            sql = sql + " Order By TimeEntryDate desc"

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@ProjectManager", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@ProjectManager").Value = ProjectManagerId

            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryApprovalPendingForTimeOffDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace
