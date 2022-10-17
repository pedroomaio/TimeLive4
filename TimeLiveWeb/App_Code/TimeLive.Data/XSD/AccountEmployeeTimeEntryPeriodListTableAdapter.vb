Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace AccountEmployeeTimeEntryTableAdapters
    Partial Public Class AccountEmployeeTimeEntryPeriodListTableAdapter
        Public Function GetAccountEmployeeTimeEntryPeriodList(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal IncludeDateRange As Boolean, ByVal TimesheetApprovalStatusId As Integer) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodListDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, " & _
                "AccountEmployeeTimeEntryPeriod.TimeEntryViewType, AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId,  " & _
                "AccountEmployeeTimeEntryPeriod.AccountId, AccountEmployeeTimeEntryPeriod.AccountEmployeeId, AccountEmployeeTimeEntryPeriod.Submitted, " & _
                "AccountEmployeeTimeEntryPeriod.Approved, AccountEmployeeTimeEntryPeriod.Rejected, AccountEmployeeTimeEntryPeriod.InApproval, " & _
                "AccountEmployeeTimeEntryPeriod.SubmittedDate, AccountEmployeeTimeEntryPeriod.ApprovedOn, " & _
                "AccountEmployeeTimeEntryPeriod.ApprovedByEmployeeId, AccountEmployeeTimeEntryPeriod.RejectedOn, " & _
                "AccountEmployeeTimeEntryPeriod.RejectedByEmployeeId, ROUND(SUM(CONVERT(float, DATEPART(hh, AccountEmployeeTimeEntry.TotalTime) " & _
                "* 60 + DATEPART(n, AccountEmployeeTimeEntry.TotalTime))) / 60, 2) AS TotalHours, " & _
                "SUM(DATEPART(hh, AccountEmployeeTimeEntry.TotalTime) " & _
                "* 60 + DATEPART(n, AccountEmployeeTimeEntry.TotalTime)) AS TotalMinutes " & _
                "FROM AccountEmployeeTimeEntryPeriod INNER JOIN " & _
                "AccountEmployeeTimeEntry ON " & _
                "AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodId WHERE "

            sql = sql + " (AccountId = @AccountId) and"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            sql = sql + " (AccountEmployeeTimeEntryPeriod.AccountEmployeeId = @AccountEmployeeId) "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            If IncludeDateRange = True Then
                sql = sql + " and (((AccountEmployeeTimeEntryPeriod.TimeEntryStartDate >= @TimeEntryStartDate) AND " & _
                            " (AccountEmployeeTimeEntryPeriod.TimeEntryEndDate <= @TimeEntryEndDate)) OR " & _
                            " ((AccountEmployeeTimeEntryPeriod.TimeEntryStartDate <= @TimeEntryEndDate) AND " & _
                            " (AccountEmployeeTimeEntryPeriod.TimeEntryEndDate >= @TimeEntryStartDate))) "
                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate
                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            If TimesheetApprovalStatusId = 1 Then
                sql = sql + " and ((AccountEmployeeTimeEntryPeriod.Approved = 0 and AccountEmployeeTimeEntryPeriod.Rejected = 0) or (AccountEmployeeTimeEntryPeriod.Rejected = 1)) "
            ElseIf TimesheetApprovalStatusId = 2 Then
                sql = sql + " and (AccountEmployeeTimeEntryPeriod.Submitted = 0 and AccountEmployeeTimeEntryPeriod.Approved = 0 and AccountEmployeeTimeEntryPeriod.Rejected = 0) "
            ElseIf TimesheetApprovalStatusId = 3 Then
                sql = sql + " and (AccountEmployeeTimeEntryPeriod.Submitted = 1 and AccountEmployeeTimeEntryPeriod.Approved = 0 and AccountEmployeeTimeEntryPeriod.Rejected = 0) "
            ElseIf TimesheetApprovalStatusId = 4 Then
                sql = sql + " and (AccountEmployeeTimeEntryPeriod.Approved = 1 and AccountEmployeeTimeEntryPeriod.Rejected = 0 and AccountEmployeeTimeEntryPeriod.Submitted = 1) "
            ElseIf TimesheetApprovalStatusId = 5 Then
                sql = sql + " and (AccountEmployeeTimeEntryPeriod.Rejected = 1 and AccountEmployeeTimeEntryPeriod.Approved = 0 and AccountEmployeeTimeEntryPeriod.Submitted = 0) "
            End If

            sql = sql + " GROUP BY AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, " & _
                        " AccountEmployeeTimeEntryPeriod.TimeEntryViewType, AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, " & _
                        " AccountEmployeeTimeEntryPeriod.AccountId, AccountEmployeeTimeEntryPeriod.AccountEmployeeId, AccountEmployeeTimeEntryPeriod.Submitted, " & _
                        " AccountEmployeeTimeEntryPeriod.Approved, AccountEmployeeTimeEntryPeriod.Rejected, AccountEmployeeTimeEntryPeriod.InApproval, " & _
                        " AccountEmployeeTimeEntryPeriod.SubmittedDate, AccountEmployeeTimeEntryPeriod.ApprovedOn, " & _
                        " AccountEmployeeTimeEntryPeriod.ApprovedByEmployeeId, AccountEmployeeTimeEntryPeriod.RejectedOn, " & _
                        " AccountEmployeeTimeEntryPeriod.RejectedByEmployeeId "

            sql = sql + " Order By TimeEntryStartDate desc "

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodListDataTable = New AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodListDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace