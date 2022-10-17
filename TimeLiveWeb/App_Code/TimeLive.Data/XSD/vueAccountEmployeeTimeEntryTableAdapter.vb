Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryTableAdapter
        Public Function GetApprovalEntriesForTeamLead1(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntry where "

            ' For TimeSheetApprovalPath = TeamLead
            sql = sql + " (LeaderEmployeeId = @AccountEmployeeId ) and "

            sql = sql + "("

            sql = sql + " (TimeSheetApprovalPathId = 1)"

            sql = sql + " or "

            ' For TimeSheetApprovalPath = ProjectManager--TeamLead
            sql = sql + "(TimeSheetApprovalPathId = 2 and TeamLeadApproved = 0)"


            sql = sql + " or "

            sql = sql + ""

            ' For TimeSheetApprovalPath = TeamLead--ProjectManager--Administrator
            sql = sql + "(TimeSheetApprovalPathId = 3 and TeamLeadApproved = 0)"

            sql = sql + ")"

            ' general check

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
                sql = sql + "AccountProjectId = @AccountProjectId and"


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "AccountEmployeeId = @TimeEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + " Approved = 0"

            sql = sql + ")"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForProjectManager1(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntry where "

            ' For TimeSheetApprovalPath = TeamLead
            sql = sql + " (ProjectManagerEmployeeId = @AccountEmployeeId ) and "

            sql = sql + "("

            'sql = sql + " (TimeSheetApprovalPathId = 1 and TeamLeadApproved = 'true')"

            'sql = sql + " or "

            'For TimeSheetApprovalPath = ProjectManager--TeamLead
            sql = sql + "(TimeSheetApprovalPathId = 2 and TeamLeadApproved = 1 and ProjectManagerApproved = 0)"


            sql = sql + " or "

            sql = sql + ""

            ' For TimeSheetApprovalPath = TeamLead--ProjectManager--Administrator
            sql = sql + "(TimeSheetApprovalPathId = 3 and TeamLeadApproved = 1 and ProjectManagerApproved = 0)"

            sql = sql + ")"

            ' general check

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
                sql = sql + "AccountProjectId = @AccountProjectId and"


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "AccountEmployeeId = @TimeEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + " Approved = 0"

            sql = sql + ")"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForOrganizaion1(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntry where "

            ' For TimeSheetApprovalPath = TeamLead
            sql = sql + " (LeaderEmployeeId = @AccountEmployeeId ) and "

            sql = sql + "("

            'sql = sql + " (TimeSheetApprovalPathId = 1 and TeamLeadApproved = 'true')"

            'sql = sql + " or "

            'For TimeSheetApprovalPath = ProjectManager--TeamLead
            'sql = sql + "(TimeSheetApprovalPathId = 2 and TeamLeadApproved = 'true' and ProjectManagerApproved = 'true')"


            'sql = sql + " or "

            'sql = sql + ""

            ' For TimeSheetApprovalPath = TeamLead--ProjectManager--Administrator
            sql = sql + "(TimeSheetApprovalPathId = 3 and TeamLeadApproved = 1 and ProjectManagerApproved = 1 and AdministratorApproved = 0)"

            sql = sql + ")"

            ' general check

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
                sql = sql + "AccountProjectId = @AccountProjectId and"


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "AccountEmployeeId = @TimeEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + " Approved = 0"

            sql = sql + ")"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

        Public Function GetDataByAccountIdAndEmployees(ByVal AccountId As Integer, ByVal AccountEmployees As String) As TimeLiveDataSet.vueAccountPagePermissionDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeTimeEntry where AccountId = " & AccountId & " and AccountEmployeeId in (" & AccountEmployees & ")"

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountPagePermissionDataTable = New TimeLiveDataSet.vueAccountPagePermissionDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function



    End Class
End Namespace

