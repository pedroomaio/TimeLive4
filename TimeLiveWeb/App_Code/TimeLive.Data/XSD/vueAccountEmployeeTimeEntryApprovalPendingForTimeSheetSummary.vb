Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryTableAdapter

        Public Function GetApprovalEntriesForTeamLeadSummarized(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, Max(dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId) as AccountProjectId, " & _
                  " Sum(dbo.AccountEmployeeTimeEntry.Percentage) as Percentage " & _
                  " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                  " dbo.AccountEmployeeTimeEntry ON " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                  " AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId " & _
                  " LEFT OUTER JOIN " & _
                  " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId Where "

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
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId
            Me.Adapter.SelectCommand.CommandTimeout = 9000000
            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForProjectManagerSummarized(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, Max(dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId) as AccountProjectId, " & _
                  " Sum(dbo.AccountEmployeeTimeEntry.Percentage) as Percentage " & _
                  " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                  " dbo.AccountEmployeeTimeEntry ON " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                  " AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId " & _
                  " LEFT OUTER JOIN " & _
                  " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId Where "

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
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId
            Me.Adapter.SelectCommand.CommandTimeout = 9000000
            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSpecificEmployeeSummarized(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, Max(dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId) as AccountProjectId, " & _
                  " Sum(dbo.AccountEmployeeTimeEntry.Percentage) as Percentage " & _
                  " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                  " dbo.AccountEmployeeTimeEntry ON " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                  " AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId " & _
                  " LEFT OUTER JOIN " & _
                  " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId Where "

            'For TeamLead
            sql = sql + " (dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 3) and "

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
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId
            Me.Adapter.SelectCommand.CommandTimeout = 9000000
            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSpecificExternalUserSummarized(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, Max(dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId) as AccountProjectId, " & _
                  " Sum(dbo.AccountEmployeeTimeEntry.Percentage) as Percentage " & _
                  " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                  " dbo.AccountEmployeeTimeEntry ON " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                  " AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId " & _
                  " LEFT OUTER JOIN " & _
                  " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId Where "

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
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId
            Me.Adapter.SelectCommand.CommandTimeout = 9000000
            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForEmployeeManagerSummarized(ByVal TimeEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, Max(dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId) as AccountProjectId, " & _
                  " Sum(dbo.AccountEmployeeTimeEntry.Percentage) as Percentage " & _
                  " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                  " dbo.AccountEmployeeTimeEntry ON " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                  " AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId " & _
                  " LEFT OUTER JOIN " & _
                  " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId Where "

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
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId
            Me.Adapter.SelectCommand.CommandTimeout = 9000000
            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSendingEmailByApproverEmployeeId(ByVal ApproverEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                      "dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                      "dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                      "dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                      "dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, " & _
                      "SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                      "dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                      "SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                      "dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                      "dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                      "dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, " & _
                      "dbo.vueTimesheetSummaryPendingForApproval.ApproverEmployeeId, MAX(dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName) " & _
                      "AS ApproverEmployeeName, MAX(dbo.AccountEmployee.EMailAddress) AS ApproverEMailAddress, " & _
                      "CASE WHEN MAX(dbo.AccountPreferences.CultureInfoName) IS NULL OR " & _
                      "MAX(dbo.AccountPreferences.CultureInfoName) = 'auto' THEN 'en-us' ELSE MAX(dbo.AccountPreferences.CultureInfoName) " & _
                      "END AS CultureInfoName, dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId, " & _
                      "dbo.vueTimesheetSummaryPendingForApproval.SubmittedDate " & _
                      "FROM dbo.AccountPreferences INNER JOIN " & _
                      "dbo.AccountEmployee ON dbo.AccountPreferences.AccountId = dbo.AccountEmployee.AccountId RIGHT OUTER JOIN " & _
                      "dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                      "dbo.AccountEmployeeTimeEntry ON " & _
                      "dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                      "dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                      "AND " & _
                      "dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId " & _
                      "ON dbo.AccountEmployee.AccountEmployeeId = dbo.vueTimesheetSummaryPendingForApproval.ApproverEmployeeId LEFT OUTER JOIN " & _
                      "dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId Where "

            sql = sql + "(dbo.vueTimesheetSummaryPendingForApproval.ApproverEmployeeId = @ApproverEmployeeId) AND " & _
                        "(dbo.vueTimesheetSummaryPendingForApproval.IsEmailSend Is Null OR " & _
                        "dbo.vueTimesheetSummaryPendingForApproval.IsEmailSend = 0) And "

            Me.Adapter.SelectCommand.Parameters.Add("@ApproverEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@ApproverEmployeeId").Value = ApproverEmployeeId

            '' For approved = false
            sql = sql + "((dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND " & _
                        " (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress, " & _
                        "dbo.vueTimesheetSummaryPendingForApproval.ApproverEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId, " & _
                        "dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId, dbo.vueTimesheetSummaryPendingForApproval.SubmittedDate " & _
                        "ORDER BY dbo.vueTimesheetSummaryPendingForApproval.ApproverEmployeeId"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetApprovalEntriesByAccountIdAndAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " & _
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " & _
                  " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, Max(dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId) as AccountProjectId, " & _
                  " Sum(dbo.AccountEmployeeTimeEntry.Percentage) as Percentage " & _
                  " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " & _
                  " dbo.AccountEmployeeTimeEntry ON " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " & _
                  " AND " & _
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId " & _
                  " LEFT OUTER JOIN " & _
                  " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId Where "

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




            '' For approved = false
            sql = sql + " (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND " & _
                        " (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " & _
                        " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetApprovalEntriesForMobile(ByVal ApproverEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " &
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " &
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " &
                  " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, SUM(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " &
                  " dbo.AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes, MAX(dbo.AccountEmployeeTimeEntry.TimeEntryDate) AS TimeEntryDate, " &
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 1 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " &
                  " dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS BillableTotalMinutes, " &
                  " SUM(CASE WHEN dbo.AccountProjectTask.IsBillable = 0 THEN DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, " &
                  " dbo.AccountEmployeeTimeEntry.TotalTime) WHEN dbo.AccountProjectTask.IsBillable IS NULL THEN DATEPART(hh, " &
                  " dbo.AccountEmployeeTimeEntry.TotalTime) * 60 + DATEPART(n, dbo.AccountEmployeeTimeEntry.TotalTime) ELSE 0 END) AS NonBillableTotalMinutes, " &
                  " dbo.vueTimesheetSummaryPendingForApproval.EMailAddress, Max(dbo.vueTimesheetSummaryPendingForApproval.AccountProjectId) as AccountProjectId, " &
                  " Sum(dbo.AccountEmployeeTimeEntry.Percentage) as Percentage " &
                  " FROM dbo.vueTimesheetSummaryPendingForApproval INNER JOIN " &
                  " dbo.AccountEmployeeTimeEntry ON " &
                  " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId = dbo.AccountEmployeeTimeEntry.AccountEmployeeId AND " &
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId " &
                  " AND " &
                  " dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryApprovalProjectId = dbo.AccountEmployeeTimeEntry.AccountEmployeeTimeEntryApprovalProjectId " &
                  " LEFT OUTER JOIN " &
                  " dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId Where "

            'For TeamLead
            sql = sql + " (ApproverEmployeeId = @AccountEmployeeId ) and "

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

            'If IncludeDateRange = True Then
            '    sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

            '    Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            '    Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

            '    Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            '    Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            'End If

            'If TimeEntryAccountEmployeeId <> 0 Then
            '    sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


            '    Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
            '    Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            'End If

            '' For approved = false
            sql = sql + " (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND " &
                        " (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR " &
                        " dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) "

            sql = sql + ") GROUP BY dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeTimeEntryPeriodId, " &
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryAccountEmployeeId, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryStartDate, " &
                        " dbo.vueTimesheetSummaryPendingForApproval.TimeEntryEndDate, dbo.vueTimesheetSummaryPendingForApproval.TimeEntryViewType, " &
                        " dbo.vueTimesheetSummaryPendingForApproval.EmployeeName, dbo.vueTimesheetSummaryPendingForApproval.EmailAddress "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = ApproverEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingForTimeSheetSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetTimeEntryApprovalCount(ByVal ApproverEmployeeId As Integer) As Integer
            Dim sql As String
            Me.Connection.Open()
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)
            sql = "Select(SELECT Count(Distinct AccountEmployeeTimeEntryPeriodId) FROM dbo.vueTimesheetSummaryPendingForApproval Where  (LeaderEmployeeId = @ApproverEmployeeId ) and (SystemApproverTypeId = 1) and ( (ApprovalPathSequence = 1) or  (ApprovalPathSequence = 2) or  (ApprovalPathSequence = 3) or  (ApprovalPathSequence = 4) or  (ApprovalPathSequence = 5)) and ( (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND  (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR  dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1))) +(SELECT count(DISTINCT AccountEmployeeTimeEntryPeriodId)  FROM dbo.vueTimesheetSummaryPendingForApproval  Where  (ProjectManagerEmployeeId = @ApproverEmployeeId ) and (SystemApproverTypeId = 2) and ( (ApprovalPathSequence = 1) or  (ApprovalPathSequence = 2) or  (ApprovalPathSequence = 3) or  (ApprovalPathSequence = 4) or  (ApprovalPathSequence = 5)) and ( (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND  (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR  dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1)))+(select Count(DISTINCT AccountEmployeeTimeEntryPeriodId) from vueAccountEmployeeTimeEntryApprovalPendingForTimeOff where  (AccountEmployeeId = @ApproverEmployeeId ) and (SystemApproverTypeId = 3) and ( (ApprovalPathSequence = 1) or  (ApprovalPathSequence = 2) or  (ApprovalPathSequence = 3) or  (ApprovalPathSequence = 4) or  (ApprovalPathSequence = 5)) )+(SELECT Count(DISTINCT AccountEmployeeTimeEntryPeriodId) FROM dbo.vueTimesheetSummaryPendingForApproval Where  (dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId = @ApproverEmployeeId ) and (SystemApproverTypeId = 3) and ( (ApprovalPathSequence = 1) or  (ApprovalPathSequence = 2) or  (ApprovalPathSequence = 3) or  (ApprovalPathSequence = 4) or  (ApprovalPathSequence = 5)) and ( (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND  (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR  dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) ) )+(SELECT Count(DISTINCT AccountEmployeeTimeEntryPeriodId) FROM dbo.vueTimesheetSummaryPendingForApproval Where  (dbo.vueTimesheetSummaryPendingForApproval.AccountEmployeeId = @ApproverEmployeeId ) and (SystemApproverTypeId = 3) and ( (ApprovalPathSequence = 1) or  (ApprovalPathSequence = 2) or  (ApprovalPathSequence = 3) or  (ApprovalPathSequence = 4) or  (ApprovalPathSequence = 5)) and ( (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND  (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR  dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) ) )+(SELECT Count(DISTINCT AccountEmployeeTimeEntryPeriodId) FROM dbo.vueTimesheetSummaryPendingForApproval Where  (EmployeeManagerId = @ApproverEmployeeId ) and (SystemApproverTypeId = 5) and ( (ApprovalPathSequence = 1) or  (ApprovalPathSequence = 2) or  (ApprovalPathSequence = 3) or  (ApprovalPathSequence = 4) or  (ApprovalPathSequence = 5)) and ( (dbo.vueTimesheetSummaryPendingForApproval.Submitted = 1) AND (dbo.vueTimesheetSummaryPendingForApproval.Approved = 0) AND  (dbo.vueTimesheetSummaryPendingForApproval.Rejected IS NULL OR  dbo.vueTimesheetSummaryPendingForApproval.Rejected = 0) AND (dbo.vueTimesheetSummaryPendingForApproval.IsDisabled <> 1) ) )+(select Count(DISTINCT vue.AccountEmployeeTimeEntryId) from vueAccountEmployeeTimeEntryApprovalPendingForTimeOff as vue Inner Join AccountEmployeeTimeEntry as Te on(vue.AccountEmployeeTimeEntryId = Te.AccountEmployeeTimeEntryId) Inner Join AccountProject As Ap on (Te.AccountProjectId = Ap.AccountProjectId ) where Te.IsTimeOff = 1 AND Te.AccountEmployeeTimeOffRequestId is null AND Ap.ProjectManagerEmployeeId  = @ApproverEmployeeId AND Te.Approved = 0 AND Te.Rejected = 0 AND Te.Submitted = 1 ) AS 'Approval Total'"
            Me.Adapter.SelectCommand.Parameters.Add("@ApproverEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@ApproverEmployeeId").Value = ApproverEmployeeId
            Me.Adapter.SelectCommand.CommandText = sql
            Dim a As Integer
            a = Me.Adapter.SelectCommand.ExecuteScalar()
            Me.Connection.Close()
            Return a
        End Function
    End Class
End Namespace
