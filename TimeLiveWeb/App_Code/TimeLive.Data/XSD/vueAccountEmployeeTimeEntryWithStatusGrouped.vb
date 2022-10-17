Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace AccountEmployeeTimeEntryTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryWithStatusGroupedTableAdapter

        Public Function GetDataByAccountEmployeeTimeEntryPeriodId(ByVal AccountEmployeeTimeEntryPeriodId As Guid) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT AccountCostCenter, AccountCostCenterId, AccountEmployeeTimeEntryApprovalProjectId, AccountEmployeeTimeEntryPeriodId, AccountEmployeeTimeOffRequestId, " & _
            "AccountId, AccountProjectId, AccountProjectTaskId, AccountTimeOffType, AccountTimeOffTypeId, AccountWorkType, AccountWorkTypeId, Hours, IsTimeOff, PartyName, " & _
            "PeriodDescription, ProjectApproved, ProjectName, TaskName " & _
            "FROM vueAccountEmployeeTimeEntryWithStatus where "
            
            sql = sql + "(AccountEmployeeTimeEntryPeriodId = @AccountEmployeeTimeEntryPeriodId) "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeTimeEntryPeriodId", SqlDbType.UniqueIdentifier)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeTimeEntryPeriodId").Value = AccountEmployeeTimeEntryPeriodId
            If DBUtilities.GetSortTimesheet = "Default" Then
                sql = sql + " ORDER BY TimeEntryDate, AccountProjectId, AccountProjectTaskId, CreatedOn "
            Else
                sql = sql + " ORDER BY PartyName, TimeEntryDate "
            End If

            Me.Adapter.SelectCommand.CommandText = sql
            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryWithStatusGroupedDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace

