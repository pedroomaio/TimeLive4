Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace AccountEmployeeTimeEntryTableAdapters
    Partial Public Class vueTimesheetPendingForApprovalTableAdapter
        Public Function GetApprovalEntriesForTeamLead(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " Select dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId) AS AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress " & _
                      " FROM         dbo.AccountProjectTask RIGHT OUTER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId RIGHT OUTER JOIN " & _
                      " dbo.vueTimesheetSummaryPendingForApproval ON  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId AND  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId Where "


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

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            '' For approved = false
            sql = sql + " (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND " & _
                        " (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId,  " & _
          " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForProjectManager(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " Select dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId) AS AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress " & _
                      " FROM         dbo.AccountProjectTask RIGHT OUTER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId RIGHT OUTER JOIN " & _
                      " dbo.vueTimesheetSummaryPendingForApproval ON  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId AND  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId Where "

            'For ProjectManager
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

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            '' For approved = false
            sql = sql + " (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND " & _
                        " (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId,  " & _
          " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSpecificEmployee(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " Select dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId) AS AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress " & _
                      " FROM         dbo.AccountProjectTask RIGHT OUTER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId RIGHT OUTER JOIN " & _
                      " dbo.vueTimesheetSummaryPendingForApproval ON  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId AND  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId Where "

            'For TeamLead
            sql = sql + " (vueTimesheetSummaryPendingForApproval.AccountEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 3) and "

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

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            '' For approved = false
            sql = sql + " (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND " & _
                        " (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId,  " & _
          " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSpecificExternalUser(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " Select dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId) AS AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress " & _
                      " FROM         dbo.AccountProjectTask RIGHT OUTER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId RIGHT OUTER JOIN " & _
                      " dbo.vueTimesheetSummaryPendingForApproval ON  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId AND  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId Where "

            'For TeamLead
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

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            '' For approved = false
            sql = sql + " (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND " & _
                        " (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId,  " & _
          " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
          " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForEmployeeManager(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " Select dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId) AS AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress " & _
                      " FROM         dbo.AccountProjectTask RIGHT OUTER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.AccountProjectTask.AccountProjectTaskId = dbo.AccountEmployeeTimeEntry.AccountProjectTaskId RIGHT OUTER JOIN " & _
                      " dbo.vueTimesheetSummaryPendingForApproval ON  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId AND  " & _
                      " dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId = dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId Where "

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

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            '' For approved = false
            sql = sql + " (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND " & _
                        " (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalPathId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId,  " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.IsApproved, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetPendingForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace
