Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace AccountEmployeeTimeEntryTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryWithStatusTableAdapter

        Public Function GetDataByAccountEmployeeIdAndDateRangeWithStatus(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, Optional ByVal IsFromMobileTimeSheet As Boolean = False) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT     vueAccountEmployeeTimeEntryWithStatus.*" & _
            " FROM vueAccountEmployeeTimeEntryWithStatus" & _
            " LEFT OUTER JOIN AccountProject" & _
            " On vueAccountEmployeeTimeEntryWithStatus.AccountProjectId = AccountProject.AccountProjectId where"
            If IsFromMobileTimeSheet Then
                sql = sql + " (IsTimeOff = 0) and"
            End If
            sql = sql + " (AccountEmployeeId = @AccountEmployeeId) and"

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            sql = sql + " (TimeEntryDate >= @TimeEntryStartDate) and (TimeEntryDate <= @TimeEntryEndDate)"

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate
            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate

            sql = sql + " ORDER BY vueAccountEmployeeTimeEntryWithStatus.TimeEntryDate, vueAccountEmployeeTimeEntryWithStatus.AccountProjectId, vueAccountEmployeeTimeEntryWithStatus.AccountProjectTaskId, vueAccountEmployeeTimeEntryWithStatus.CreatedOn "

            Me.Adapter.SelectCommand.CommandText = sql
            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetDataByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid, Optional ByVal IsFromMobileTimeSheet As Boolean = False) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT     vueAccountEmployeeTimeEntryWithStatus.*" & _
            " FROM vueAccountEmployeeTimeEntryWithStatus" & _
            " LEFT OUTER JOIN AccountProject" & _
            " On vueAccountEmployeeTimeEntryWithStatus.AccountProjectId = AccountProject.AccountProjectId where"
            If IsFromMobileTimeSheet Then
                sql = sql + " (IsTimeOff = 0) and"
            End If
            sql = sql + " (AccountEmployeeTimeEntryPeriodId = @AccountEmployeeTimeEntryPeriodId) "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeTimeEntryPeriodId", SqlDbType.UniqueIdentifier)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeTimeEntryPeriodId").Value = AccountEmployeeTimeEntryPeriodId
            If DBUtilities.GetSortTimesheet = "Default" Then
                sql = sql + " ORDER BY vueAccountEmployeeTimeEntryWithStatus.TimeEntryDate, vueAccountEmployeeTimeEntryWithStatus.AccountProjectId, vueAccountEmployeeTimeEntryWithStatus.AccountProjectTaskId, vueAccountEmployeeTimeEntryWithStatus.CreatedOn "
            Else
                sql = sql + " ORDER BY vueAccountEmployeeTimeEntryWithStatus.PartyName, vueAccountEmployeeTimeEntryWithStatus.TimeEntryDate "
            End If

            Me.Adapter.SelectCommand.CommandText = sql
            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace

