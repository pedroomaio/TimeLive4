Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountExpenseEntryApprovalPendingTableAdapter
        Public Function GetApprovalEntriesForTeamLead1(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntryApprovalPending where "

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
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                sql = sql + " AccountEmployeeExpenseSheetId = '" & AccountEmployeeExpenseSheetId.ToString & "' and "
            End If

            ' For approved = false
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By AccountExpenseEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForProjectManager1(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntryApprovalPending where "

            'For TeamLead --> ProjectManager
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

            ' General Check

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
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                sql = sql + " AccountEmployeeExpenseSheetId = '" & AccountEmployeeExpenseSheetId.ToString & "' and "
            End If

            ' For Approved = False
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By AccountExpenseEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForSpecificEmployee1(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntryApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee
            sql = sql + " (AccountEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 3) and "

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

            ' General Check

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
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                sql = sql + " AccountEmployeeExpenseSheetId = '" & AccountEmployeeExpenseSheetId.ToString & "' and "
            End If

            ' For Approved = False
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By AccountExpenseEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForSpecificExternalUser1(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntryApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee --> SpecificExternalUser
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

            ' General Check

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
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId
            End If

            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                sql = sql + " AccountEmployeeExpenseSheetId = '" & AccountEmployeeExpenseSheetId.ToString & "' and "
            End If

            ' For Approved = False
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By AccountExpenseEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForEmployeeManager1(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntryApprovalPending where "

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
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                sql = sql + " AccountEmployeeExpenseSheetId = '" & AccountEmployeeExpenseSheetId.ToString & "' and "
            End If

            ' For approved = false
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By AccountExpenseEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForTeamLeadForMobile(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer), ByVal AccountProjectId As Integer, ByVal AccountEmployeeExpenseSheetId As Guid) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntryApprovalPending where "

            'For TeamLead
            'sql = sql + " (LeaderEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 1) and "

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
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            If AccountEmployeeExpenseSheetId <> System.Guid.Empty Then
                sql = sql + " AccountEmployeeExpenseSheetId = '" & AccountEmployeeExpenseSheetId.ToString & "' and "
            End If

            ' For approved = false
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Order By AccountExpenseEntryDate desc"


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetDataByAccountIdAndEmployees(ByVal AccountId As Integer, ByVal AccountEmployees As String) As TimeLiveDataSet.vueAccountPagePermissionDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountExpenseEntryApprovalPending where AccountId = " & AccountId & " and AccountEmployeeId in (" & AccountEmployees & ")"

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountPagePermissionDataTable = New TimeLiveDataSet.vueAccountPagePermissionDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForTeamLeadByExpenseSheet(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Max(MasterDescription) as MasterDescription, Max(ExpenseSheetDate) as ExpenseSheetDate, Max(BaseCurrencyCode) as BaseCurrencyCode, Sum(Amount) as Amount from vueAccountExpenseEntryApprovalPending where "

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
                sql = sql + "ExpenseSheetDate >= @ExpenseEntryStartDate and ExpenseSheetDate <= @ExpenseEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If


            If ExpenseEntryAccountEmployeeId <> 0 Then
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By EmployeeName, ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId Order By ExpenseSheetDate desc "


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForProjectManagerByExpenseSheet(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Max(MasterDescription) as MasterDescription, Max(ExpenseSheetDate) as ExpenseSheetDate, Max(BaseCurrencyCode) as BaseCurrencyCode, Sum(Amount) as Amount from vueAccountExpenseEntryApprovalPending where "

            'For TeamLead --> ProjectManager
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

            ' General Check

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "ExpenseSheetDate >= @ExpenseEntryStartDate and ExpenseSheetDate <= @ExpenseEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If

            If ExpenseEntryAccountEmployeeId <> 0 Then
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By EmployeeName, ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId Order By ExpenseSheetDate desc "


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForSpecificEmployeeByExpenseSheet(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Max(MasterDescription) as MasterDescription, Max(ExpenseSheetDate) as ExpenseSheetDate, Max(BaseCurrencyCode) as BaseCurrencyCode, Sum(Amount) as Amount from vueAccountExpenseEntryApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee
            sql = sql + " (AccountEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 3) and "

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

            ' General Check

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "ExpenseSheetDate >= @ExpenseEntryStartDate and ExpenseSheetDate <= @ExpenseEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If

            If ExpenseEntryAccountEmployeeId <> 0 Then
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By EmployeeName, ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId Order By ExpenseSheetDate desc "


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForSpecificExternalUserByExpenseSheet(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Max(MasterDescription) as MasterDescription, Max(ExpenseSheetDate) as ExpenseSheetDate, Max(BaseCurrencyCode) as BaseCurrencyCode, Sum(Amount) as Amount from vueAccountExpenseEntryApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee --> SpecificExternalUser
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

            ' General Check

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "ExpenseSheetDate >= @ExpenseEntryStartDate and ExpenseSheetDate <= @ExpenseEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If

            If ExpenseEntryAccountEmployeeId <> 0 Then
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By EmployeeName, ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId Order By ExpenseSheetDate desc "


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForEmployeeManagerByExpenseSheet(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Max(MasterDescription) as MasterDescription, Max(ExpenseSheetDate) as ExpenseSheetDate, Max(BaseCurrencyCode) as BaseCurrencyCode, Sum(Amount) as Amount from vueAccountExpenseEntryApprovalPending where "

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
                sql = sql + "ExpenseSheetDate >= @ExpenseEntryStartDate and ExpenseSheetDate <= @ExpenseEntryEndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If

            If ExpenseEntryAccountEmployeeId <> 0 Then
                sql = sql + " ExpenseEntryAccountEmployeeId = @ExpenseEntryAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryAccountEmployeeId").Value = ExpenseEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By EmployeeName, ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId Order By ExpenseSheetDate desc "


            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace

