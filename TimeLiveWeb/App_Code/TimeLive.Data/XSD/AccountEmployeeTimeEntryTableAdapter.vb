Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryWithLastStatusTableAdapter

        Public Function GetDataByEmployeeIdAndDate(ByVal AccountEmployeeId As Integer, ByVal TimeEntryDate As Date, Optional ByVal IsCopy As Boolean = False, Optional ByVal IsAllowTimeOff As Boolean = False, Optional ByVal IsFromMobile As Boolean = False) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT     vueAccountEmployeeTimeEntryWithLastStatus.*" & _
            " FROM vueAccountEmployeeTimeEntryWithLastStatus" & _
            " LEFT OUTER JOIN AccountProject" & _
            " On vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectId = AccountProject.AccountProjectId where"

            sql = sql + " (AccountEmployeeId = @AccountEmployeeId) and"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            sql = sql + " (TimeEntryDate = @TimeEntryDate) "
            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryDate").Value = TimeEntryDate
            If IsCopy Or IsFromMobile Then
                sql = sql + " and (AccountEmployeeTimeOffRequestId is null)"
            End If
            If Not IsAllowTimeOff Or IsFromMobile Then
                sql = sql + " and (IsTimeOff = 0)"
            End If
            If DBUtilities.GetSortTimesheet = "Client" Then
                sql = sql + " ORDER BY PartyName"
            End If

            Me.Adapter.SelectCommand.CommandText = sql
            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function

        Public Function GetDataByAccountEmployeeIdAndDateRange(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT     vueAccountEmployeeTimeEntryWithLastStatus.*" & _
            " FROM vueAccountEmployeeTimeEntryWithLastStatus" & _
            " LEFT OUTER JOIN AccountProject" & _
            " On vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectId = AccountProject.AccountProjectId where"

            sql = sql + " (AccountEmployeeId = @AccountEmployeeId) and"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            sql = sql + " (TimeEntryDate >= @TimeEntryStartDate) and (TimeEntryDate <= @TimeEntryEndDate)"
            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate
            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate

            'sql = sql + " ((AccountProject.ProjectBillingRateTypeId is null or AccountProject.ProjectBillingRateTypeId = 0)" & _
            '" Or (AccountEmployeeTimeEntryId NOT IN" & _
            '" (SELECT     AccountEmployeeTimeEntryId" & _
            '" FROM AccountEmployeeTimeEntryApproval" & _
            '" WHERE      (TimeSheetApprovalId = (SELECT     MAX(TimeSheetApprovalId) AS Expr1" & _
            '" FROM          AccountEmployeeTimeEntryApproval AS AccountEmployeeTimeEntryApproval_1" & _
            '" WHERE      (AccountEmployeeTimeEntryId = AccountEmployeeTimeEntry.AccountEmployeeTimeEntryId)))" & _
            '" AND (IsApproved = 1))) AND" & _
            '" (Approved <> 1 or TimeSheetApprovalTypeId is null or TimeSheetApprovalTypeId = 0))" & _
            sql = sql + " ORDER BY vueAccountEmployeeTimeEntryWithLastStatus.TimeEntryDate, vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectId, vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectTaskId"


            Me.Adapter.SelectCommand.CommandText = sql
            Me.Adapter.SelectCommand.ExecuteScalar()

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
            '" ((AccountProject.ProjectBillingRateTypeId is null" & _
            '" Or AccountProject.ProjectBillingRateTypeId = 0) Or" & _
        End Function

        Public Function GetDataByAccountEmployeeIdAndDateRangeForDescriptionReadOnlyView(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT     vueAccountEmployeeTimeEntryWithLastStatus.*" & _
            " FROM vueAccountEmployeeTimeEntryWithLastStatus" & _
            " LEFT OUTER JOIN AccountProject" & _
            " On vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectId = AccountProject.AccountProjectId where"

            sql = sql + " (AccountEmployeeId = @AccountEmployeeId) and"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            sql = sql + " (TimeEntryDate >= @TimeEntryStartDate) and (TimeEntryDate <= @TimeEntryEndDate) and"
            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate
            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate

            sql = sql + " (Description IS NOT NULL) AND (Description <> '')"
            sql = sql + " ORDER BY vueAccountEmployeeTimeEntryWithLastStatus.TimeEntryDate, vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectId, vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectTaskId"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetDataByAccountEmployeeIdAndDateRangeForDescriptionReadOnlyViewForRelevantProject(ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal ViewerAccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT     vueAccountEmployeeTimeEntryWithLastStatus.*" & _
            " FROM vueAccountEmployeeTimeEntryWithLastStatus" & _
            " LEFT OUTER JOIN AccountProject" & _
            " On vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectId = AccountProject.AccountProjectId where"

            sql = sql + " (AccountEmployeeId = @AccountEmployeeId) and"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            sql = sql + " (TimeEntryDate >= @TimeEntryStartDate) and (TimeEntryDate <= @TimeEntryEndDate) and"
            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate
            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate

            sql = sql + " (vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectId IN " & _
                          "(SELECT     AccountProjectId " & _
            "FROM vueAccountEmployeeTimeEntryApprovalPending " & _
                            "WHERE      (SystemApproverTypeId = 1) AND (LeaderEmployeeId = @ViewerAccountEmployeeId) OR " & _
                                                   "(SystemApproverTypeId = 2) AND (ProjectManagerEmployeeId = @ViewerAccountEmployeeId) OR " & _
                                                   "(SystemApproverTypeId = 3) AND (AccountEmployeeId = @ViewerAccountEmployeeId) OR " & _
                                                   "(SystemApproverTypeId = 4) AND (AccountExternalUserId = @ViewerAccountEmployeeId) OR " & _
                                                   "(SystemApproverTypeId = 5) AND (EmployeeManagerId = @ViewerAccountEmployeeId))) and"

            Me.Adapter.SelectCommand.Parameters.Add("@ViewerAccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@ViewerAccountEmployeeId").Value = ViewerAccountEmployeeId

            sql = sql + " (Description IS NOT NULL) AND (Description <> '')"
            sql = sql + " ORDER BY vueAccountEmployeeTimeEntryWithLastStatus.TimeEntryDate, vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectId, vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectTaskId"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function

        Public Function GetDataByAccountEmployeeTimeEntryId(ByVal AccountEmployeeTimeEntryId As Integer) As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT     vueAccountEmployeeTimeEntryWithLastStatus.*" & _
            " FROM vueAccountEmployeeTimeEntryWithLastStatus" & _
            " LEFT OUTER JOIN AccountProject" & _
            " On vueAccountEmployeeTimeEntryWithLastStatus.AccountProjectId = AccountProject.AccountProjectId where"

            sql = sql + " (AccountEmployeeTimeEntryId = @AccountEmployeeTimeEntryId)"
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeTimeEntryId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeTimeEntryId").Value = AccountEmployeeTimeEntryId
            Me.Adapter.SelectCommand.CommandText = sql
            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntryWithLastStatusDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace

