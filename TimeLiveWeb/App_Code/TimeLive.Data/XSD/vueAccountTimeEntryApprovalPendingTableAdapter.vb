Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryApprovalPendingTableAdapter
        Public Function GetApprovalEntriesForTeamLead1(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntryApprovalPending where "

            'For TeamLead
            sql = sql + " (LeaderEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 1) and "

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

            'General Check

            sql = sql + " and "

            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            If AccountProjectId <> 0 Then
                sql = sql + "AccountProjectId = @AccountProjectId and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + "Approved = 0) and (Rejected is null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By TimeEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForProjectManager1(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntryApprovalPending where "

            'For TeamLead --> ProjectManager
            sql = sql + " (ProjectManagerEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 2) and "

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
                sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            If AccountProjectId <> 0 Then
                sql = sql + "AccountProjectId = @AccountProjectId and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + "Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By TimeEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSpecificEmployee1(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntryApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee
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

            ' General Check

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            If AccountProjectId <> 0 Then
                sql = sql + "AccountProjectId = @AccountProjectId and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + "Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By TimeEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSpecificExternalUser1(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntryApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee --> SpecificExternalUser
            sql = sql + " (AccountExternalUserId = @AccountEmployeeId ) and (SystemApproverTypeId = 4) and "

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
                sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            If AccountProjectId <> 0 Then
                sql = sql + "AccountProjectId = @AccountProjectId and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + "Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By TimeEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForEmployeeManager1(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntryApprovalPending where "

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

            'General Check

            sql = sql + " and "

            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            If AccountProjectId <> 0 Then
                sql = sql + "AccountProjectId = @AccountProjectId and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + "Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By TimeEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetDataByAccountIdAndEmployees(ByVal AccountId As Integer, ByVal AccountEmployees As String) As TimeLiveDataSet.vueAccountPagePermissionDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntryApprovalPending where AccountId = " & AccountId & " and AccountEmployeeId in (" & AccountEmployees & ")"

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountPagePermissionDataTable = New TimeLiveDataSet.vueAccountPagePermissionDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function



    End Class

End Namespace

