Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace AccountEmployeeTimeEntryTableAdapters
    Partial Public Class vueTimesheetEntriesForApprovalTableAdapter
        Public Function GetApprovalEntriesForTeamLead(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                      " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType " & _
                      " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                      " INNER Join " & _
                      " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId INNER JOIN " & _
                      " dbo.vueAccountApproverType ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId Where "


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

            sql = sql + ") GROUP BY dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForProjectManager(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                      " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType " & _
                      " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                      " INNER Join " & _
                      " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId INNER JOIN " & _
                      " dbo.vueAccountApproverType ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId Where "

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

            sql = sql + ") GROUP BY dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSpecificEmployee(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                      " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType " & _
                      " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                      " INNER Join " & _
                      " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId INNER JOIN " & _
                      " dbo.vueAccountApproverType ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId Where "

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

            sql = sql + ") GROUP BY dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSpecificExternalUser(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                      " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType " & _
                      " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                      " INNER Join " & _
                      " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId INNER JOIN " & _
                      " dbo.vueAccountApproverType ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId Where "

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

            sql = sql + ") GROUP BY dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForEmployeeManager(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, " & _
                      " MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                      " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                      " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType " & _
                      " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                      " dbo.AccountEmployeeTimeEntry ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId = dbo.AccountEmployeeTimeEntry.AccountProjectId AND " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                      " INNER Join " & _
                      " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId INNER JOIN " & _
                      " dbo.vueAccountApproverType ON " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountApprovalTypeId = dbo.vueAccountApproverType.AccountApprovalTypeId Where "

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

            sql = sql + ") GROUP BY dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId, dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.LeaderEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.ProjectManagerEmployeeId, " & _
                      " dbo.vueTimesheetSummaryPendingForApproval.EmployeeManagerId, dbo.vueTimesheetSummaryPendingForApproval.AccountExternalUserId, " & _
                      " dbo.vueAccountApproverType.MaxApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.ApprovalPathSequence, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable = New AccountEmployeeTimeEntry.vueTimesheetEntriesForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace
