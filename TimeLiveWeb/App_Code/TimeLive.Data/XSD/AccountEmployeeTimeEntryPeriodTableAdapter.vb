Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace AccountEmployeeTimeEntryTableAdapters
    Partial Public Class AccountEmployeeTimeEntryPeriodTableAdapter
        Public Function GetApprovedEmailByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryPeriod.AccountId, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.Submitted, dbo.AccountEmployeeTimeEntryPeriod.Approved, dbo.AccountEmployeeTimeEntryPeriod.Rejected, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.InApproval, dbo.AccountEmployeeTimeEntryPeriod.SubmittedDate, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.ApprovedOn, dbo.AccountEmployeeTimeEntryPeriod.ApprovedByEmployeeId, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.RejectedOn, dbo.AccountEmployeeTimeEntryPeriod.RejectedByEmployeeId, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.SubmittedBy, dbo.AccountEmployeeTimeEntryPeriod.CreatedByEmployeeId, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.ModifiedByEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.PeriodDescription, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.CreatedOn, dbo.AccountEmployeeTimeEntryPeriod.ModifiedOn" & _
                   " FROM dbo.AccountEMailNotificationPreference RIGHT OUTER JOIN" & _
                   " dbo.AccountEmployeeTimeEntryPeriod ON " & _
                   " dbo.AccountEMailNotificationPreference.AccountId = dbo.AccountEmployeeTimeEntryPeriod.AccountId LEFT OUTER JOIN" & _
                   " dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON " & _
                   " dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId WHERE "
                  

            sql = sql + " (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 16) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND " & _
                  " (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 14) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND "

            sql = sql + " (dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = @AccountEmployeeTimeEntryPeriodId)"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeTimeEntryPeriodId", SqlDbType.UniqueIdentifier)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeTimeEntryPeriodId").Value = AccountEmployeeTimeEntryPeriodId

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = New AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetRejectedEmailByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryPeriod.AccountId, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.Submitted, dbo.AccountEmployeeTimeEntryPeriod.Approved, dbo.AccountEmployeeTimeEntryPeriod.Rejected, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.InApproval, dbo.AccountEmployeeTimeEntryPeriod.SubmittedDate, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.ApprovedOn, dbo.AccountEmployeeTimeEntryPeriod.ApprovedByEmployeeId, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.RejectedOn, dbo.AccountEmployeeTimeEntryPeriod.RejectedByEmployeeId, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.SubmittedBy, dbo.AccountEmployeeTimeEntryPeriod.CreatedByEmployeeId, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.ModifiedByEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.PeriodDescription, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.CreatedOn, dbo.AccountEmployeeTimeEntryPeriod.ModifiedOn" & _
                " FROM dbo.AccountEMailNotificationPreference RIGHT OUTER JOIN" & _
                " dbo.AccountEmployeeTimeEntryPeriod ON " & _
                " dbo.AccountEMailNotificationPreference.AccountId = dbo.AccountEmployeeTimeEntryPeriod.AccountId LEFT OUTER JOIN" & _
                " dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON " & _
                " dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId WHERE "

            sql = sql + " (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 19) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND " & _
                " (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 17) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND "

            sql = sql + " (dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = @AccountEmployeeTimeEntryPeriodId)"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeTimeEntryPeriodId", SqlDbType.UniqueIdentifier)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeTimeEntryPeriodId").Value = AccountEmployeeTimeEntryPeriodId

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = New AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetApprovedEmailToApproverByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryPeriod.AccountId, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.Submitted, dbo.AccountEmployeeTimeEntryPeriod.Approved, dbo.AccountEmployeeTimeEntryPeriod.Rejected, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.InApproval, dbo.AccountEmployeeTimeEntryPeriod.SubmittedDate, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.ApprovedOn, dbo.AccountEmployeeTimeEntryPeriod.ApprovedByEmployeeId, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.RejectedOn, dbo.AccountEmployeeTimeEntryPeriod.RejectedByEmployeeId, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.SubmittedBy, dbo.AccountEmployeeTimeEntryPeriod.CreatedByEmployeeId, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.ModifiedByEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.PeriodDescription, " & _
                   "dbo.AccountEmployeeTimeEntryPeriod.CreatedOn, dbo.AccountEmployeeTimeEntryPeriod.ModifiedOn" & _
                   " FROM dbo.AccountEMailNotificationPreference RIGHT OUTER JOIN" & _
                   " dbo.AccountEmployeeTimeEntryPeriod ON " & _
                   " dbo.AccountEMailNotificationPreference.AccountId = dbo.AccountEmployeeTimeEntryPeriod.AccountId LEFT OUTER JOIN" & _
                   " dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON " & _
                   " dbo.AccountEmployeeTimeEntryPeriod.ApprovedByEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId WHERE "


            sql = sql + " (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 50) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND " & _
                  " (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 49) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND "

            sql = sql + " (dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = @AccountEmployeeTimeEntryPeriodId)"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeTimeEntryPeriodId", SqlDbType.UniqueIdentifier)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeTimeEntryPeriodId").Value = AccountEmployeeTimeEntryPeriodId

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = New AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetRejectedEmailToApproverByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId, dbo.AccountEmployeeTimeEntryPeriod.AccountId, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryStartDate, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.TimeEntryEndDate, dbo.AccountEmployeeTimeEntryPeriod.TimeEntryViewType, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.Submitted, dbo.AccountEmployeeTimeEntryPeriod.Approved, dbo.AccountEmployeeTimeEntryPeriod.Rejected, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.InApproval, dbo.AccountEmployeeTimeEntryPeriod.SubmittedDate, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.ApprovedOn, dbo.AccountEmployeeTimeEntryPeriod.ApprovedByEmployeeId, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.RejectedOn, dbo.AccountEmployeeTimeEntryPeriod.RejectedByEmployeeId, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.SubmittedBy, dbo.AccountEmployeeTimeEntryPeriod.CreatedByEmployeeId, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.ModifiedByEmployeeId, dbo.AccountEmployeeTimeEntryPeriod.PeriodDescription, " & _
                "dbo.AccountEmployeeTimeEntryPeriod.CreatedOn, dbo.AccountEmployeeTimeEntryPeriod.ModifiedOn" & _
                " FROM dbo.AccountEMailNotificationPreference RIGHT OUTER JOIN" & _
                " dbo.AccountEmployeeTimeEntryPeriod ON " & _
                " dbo.AccountEMailNotificationPreference.AccountId = dbo.AccountEmployeeTimeEntryPeriod.AccountId LEFT OUTER JOIN" & _
                " dbo.AccountEMailNotificationPreference AS AccountEMailNotificationPreference_1 ON " & _
                " dbo.AccountEmployeeTimeEntryPeriod.RejectedByEmployeeId = AccountEMailNotificationPreference_1.AccountEmployeeId WHERE "

            sql = sql + " (AccountEMailNotificationPreference_1.SystemEMailNotificationId = 52) AND (AccountEMailNotificationPreference_1.Enabled = 1) AND " & _
                " (dbo.AccountEMailNotificationPreference.SystemEMailNotificationId = 51) AND (dbo.AccountEMailNotificationPreference.Enabled = 1) AND "

            sql = sql + " (dbo.AccountEmployeeTimeEntryPeriod.AccountEmployeeTimeEntryPeriodId = @AccountEmployeeTimeEntryPeriodId)"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeTimeEntryPeriodId", SqlDbType.UniqueIdentifier)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeTimeEntryPeriodId").Value = AccountEmployeeTimeEntryPeriodId

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable = New AccountEmployeeTimeEntry.AccountEmployeeTimeEntryPeriodDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace