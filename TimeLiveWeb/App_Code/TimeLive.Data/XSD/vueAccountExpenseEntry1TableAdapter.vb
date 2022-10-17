Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountExpenseEntryTableAdapter
        Public Function GetApprovalEntriesForTeamLead1(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountExpenseEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntry where "

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
                sql = sql + "AccountExpenseEntryDate >= @ExpenseEntryStartDate and AccountExpenseEntryDate <= @ExpenseEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If

            If AccountProjectId <> 0 Then
                sql = sql + "AccountProjectId = @AccountProjectId and"


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If ExpenseEntryAccountEmployeeId <> 0 Then
                sql = sql + " AccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + " Approved = 0"

            sql = sql + ")"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryDataTable = New TimeLiveDataSet.vueAccountExpenseEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForProjectManager1(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountExpenseEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntry where "

            ' For TimeSheetApprovalPath = TeamLead
            sql = sql + " (ProjectManagerEmployeeId = @AccountEmployeeId ) and "

            sql = sql + "("

            'sql = sql + " (TimeSheetApprovalPathId = 1 and TeamLeadApproved = 1)"

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
                sql = sql + "AccountExpenseEntryDate >= @ExpenseEntryStartDate and AccountExpenseEntryDate <= @ExpenseEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If

            If AccountProjectId <> 0 Then
                sql = sql + "AccountProjectId = @AccountProjectId and"


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If ExpenseEntryAccountEmployeeId <> 0 Then
                sql = sql + "AccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + " Approved = 0"

            sql = sql + ")"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryDataTable = New TimeLiveDataSet.vueAccountExpenseEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForOrganizaion1(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountExpenseEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntry where "

            ' For TimeSheetApprovalPath = TeamLead
            sql = sql + " (LeaderEmployeeId = @AccountEmployeeId ) and "

            sql = sql + "("

            'sql = sql + " (TimeSheetApprovalPathId = 1 and TeamLeadApproved = 1)"

            'sql = sql + " or "

            'For TimeSheetApprovalPath = ProjectManager--TeamLead
            'sql = sql + "(TimeSheetApprovalPathId = 2 and TeamLeadApproved = 1 and ProjectManagerApproved = 1)"


            'sql = sql + " or "

            'sql = sql + ""

            ' For TimeSheetApprovalPath = TeamLead--ProjectManager--Administrator
            sql = sql + "(TimeSheetApprovalPathId = 3 and TeamLeadApproved = 1 and ProjectManagerApproved = 1 and AdministratorApproved = 0)"

            sql = sql + ")"

            ' general check

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "AccountExpenseEntryDate >= @ExpenseEntryStartDate and AccountExpenseEntryDate <= @ExpenseEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If

            If AccountProjectId <> 0 Then
                sql = sql + "AccountProjectId = @AccountProjectId and"


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If ExpenseEntryAccountEmployeeId <> 0 Then
                sql = sql + "AccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + " Approved = 0"

            sql = sql + ")"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryDataTable = New TimeLiveDataSet.vueAccountExpenseEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace



