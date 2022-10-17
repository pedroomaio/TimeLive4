Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace AccountExpenseEntryTableAdapters
    Partial Public Class vueAccountExpenseEntryApprovalPendingSummaryTableAdapter
        Public Function GetApprovalEntriesForTeamLeadSummarized(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, BaseCurrencyCode, Sum(Amount) as Amount, ApprovalPathSequence from vueAccountExpenseEntryApprovalPendingSummary where "

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
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1) "

            sql = sql + "Group By EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, " & _
                        "BaseCurrencyCode, ApprovalPathSequence"

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable = New AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetApprovalEntriesForProjectManagerSummarized(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, BaseCurrencyCode, Sum(Amount) as Amount, ApprovalPathSequence from vueAccountExpenseEntryApprovalPendingSummary where "

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
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1) "

            sql = sql + "Group By EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, " & _
                        "BaseCurrencyCode, ApprovalPathSequence"

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable = New AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForSpecificEmployeeSummarized(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, BaseCurrencyCode, Sum(Amount) as Amount, ApprovalPathSequence from vueAccountExpenseEntryApprovalPendingSummary where "

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
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1) "

            sql = sql + "Group By EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, " & _
                        "BaseCurrencyCode, ApprovalPathSequence"

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable = New AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForSpecificExternalUserSummarized(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, BaseCurrencyCode, Sum(Amount) as Amount, ApprovalPathSequence from vueAccountExpenseEntryApprovalPendingSummary where "

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
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1) "

            sql = sql + "Group By EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, " & _
                        "BaseCurrencyCode, ApprovalPathSequence"

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable = New AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesForEmployeeManagerSummarized(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, BaseCurrencyCode, Sum(Amount) as Amount, ApprovalPathSequence from vueAccountExpenseEntryApprovalPendingSummary where "

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
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1) "

            sql = sql + "Group By EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, " & _
                        "BaseCurrencyCode, ApprovalPathSequence"

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable = New AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetApprovalEntriesSummarizedForMobile(ByVal ExpenseEntryAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As Date, ByVal ExpenseEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, BaseCurrencyCode, Sum(Amount) as Amount, ApprovalPathSequence from vueAccountExpenseEntryApprovalPendingSummary where "

            'For TeamLead
            ''sql = sql + " (AccountEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 1) and "
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
            sql = sql + " Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1) "

            sql = sql + "Group By EmployeeName,ExpenseEntryAccountEmployeeId, AccountEmployeeExpenseSheetId, Description, ExpenseSheetDate, " & _
                        "BaseCurrencyCode, ApprovalPathSequence"

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable = New AccountExpenseEntry.vueAccountExpenseEntryApprovalPendingSummaryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace
