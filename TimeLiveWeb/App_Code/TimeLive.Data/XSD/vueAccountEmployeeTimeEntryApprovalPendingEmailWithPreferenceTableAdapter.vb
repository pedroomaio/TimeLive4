Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceTableAdapter
        Public Function GetDataByApproverEmployeeIdForEmail(ByVal AccountEmployeeId As Integer, AccountId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceDataTable
            LoggingBLL.WriteToLog("GetDataByApproverEmployeeIdForEmail" & " " & AccountEmployeeId)
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT EmployeeName, Sum(TotalMinutes) as TotalMinutes, max(TimeEntryDate)as TimeEntryDate, sum(BillableTotalMinutes) as BillableTotalMinutes, Sum(NonBillableTotalMinutes) as NonBillableTotalMinutes, AccountId, ApproverEmailAddress, Max(CultureInfoName) as CultureInfoName, Max(TimeEntryAccountEmployeeId) as TimeEntryAccountEmployeeId, Max(TimeEntryStartDate) as TimeEntryStartDate, Max(TimeEntryEndDate) as TimeEntryEndDate, AccountEmployeeTimeEntryPeriodId From vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreference WITH (NOLOCK) where "

            sql = sql + " (AccountId = " & AccountId & ")"

            sql = sql + " and (ApproverEmployeeId = " & AccountEmployeeId & ")"

            sql = sql + " Group By EmployeeName, AccountId, ApproverEmailAddress, AccountEmployeeTimeEntryPeriodId order by TimeEntryStartDate desc"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable1 As TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryApprovalPendingEmailWithPreferenceDataTable
            Me.Adapter.Fill(dataTable1)
            Return dataTable1

        End Function
        Public Sub SetCommandTimeOut(ByVal timeOut As Integer)
            For Each command As SqlCommand In Me.CommandCollection
                command.CommandTimeout = timeOut
            Next
        End Sub
    End Class
End Namespace
