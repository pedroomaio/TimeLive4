Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace AccountEmployeeTimeEntryTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntryForApprovalTableAdapter
        Public Function GetTeamLeadEntriesForApproval(ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "Max(AccountEmployeeTimeEntryId) As AccountEmployeeTimeEntryId, TimeSheetApprovalId, TimeSheetApprovalPathId, " & _
                    "ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, Sum(TotalMinutes) As TotalMinutes, IsBillable, " & _
                    "Sum(BillableTotalMinutes) As BillableTotalMinutes, " & _
                    "Sum(NonBillableTotalMinutes) As NonBillableTotalMinutes, Rejected " & _
                    "FROM dbo.vueAccountEmployeeTimeEntryApprovalPending where "

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

            sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + "Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "TimeSheetApprovalId, TimeSheetApprovalPathId, ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, IsBillable, " & _
                    "Rejected "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetProjectManagerEntriesForApproval(ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "Max(AccountEmployeeTimeEntryId) As AccountEmployeeTimeEntryId, TimeSheetApprovalId, TimeSheetApprovalPathId, " & _
                    "ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, Sum(TotalMinutes) As TotalMinutes, IsBillable, " & _
                    "Sum(BillableTotalMinutes) As BillableTotalMinutes, " & _
                    "Sum(NonBillableTotalMinutes) As NonBillableTotalMinutes, Rejected " & _
                    "FROM dbo.vueAccountEmployeeTimeEntryApprovalPending where "

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

            sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + "Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "TimeSheetApprovalId, TimeSheetApprovalPathId, ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, IsBillable, " & _
                    "Rejected "




            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetSpecificEmployeeEntriesForApproval(ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "Max(AccountEmployeeTimeEntryId) As AccountEmployeeTimeEntryId, TimeSheetApprovalId, TimeSheetApprovalPathId, " & _
                    "ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, Sum(TotalMinutes) As TotalMinutes, IsBillable, " & _
                    "Sum(BillableTotalMinutes) As BillableTotalMinutes, " & _
                    "Sum(NonBillableTotalMinutes) As NonBillableTotalMinutes, Rejected " & _
                    "FROM dbo.vueAccountEmployeeTimeEntryApprovalPending where "

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


            sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate


            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + "Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "TimeSheetApprovalId, TimeSheetApprovalPathId, ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, IsBillable, " & _
                    "Rejected "




            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetSpecificExternalUserEntriesForApproval(ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "Max(AccountEmployeeTimeEntryId) As AccountEmployeeTimeEntryId, TimeSheetApprovalId, TimeSheetApprovalPathId, " & _
                    "ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, Sum(TotalMinutes) As TotalMinutes, IsBillable, " & _
                    "Sum(BillableTotalMinutes) As BillableTotalMinutes, " & _
                    "Sum(NonBillableTotalMinutes) As NonBillableTotalMinutes, Rejected " & _
                    "FROM dbo.vueAccountEmployeeTimeEntryApprovalPending where "

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


            sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For Approved = False
            sql = sql + "Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "TimeSheetApprovalId, TimeSheetApprovalPathId, ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, IsBillable, " & _
                    "Rejected "




            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetEmployeeManagerEntriesForApproval(ByVal TimeEntryAccountEmployeeId As Integer, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "Max(AccountEmployeeTimeEntryId) As AccountEmployeeTimeEntryId, TimeSheetApprovalId, TimeSheetApprovalPathId, " & _
                    "ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, Sum(TotalMinutes) As TotalMinutes, IsBillable, " & _
                    "Sum(BillableTotalMinutes) As BillableTotalMinutes, " & _
                    "Sum(NonBillableTotalMinutes) As NonBillableTotalMinutes, Rejected " & _
                    "FROM dbo.vueAccountEmployeeTimeEntryApprovalPending where "

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


            sql = sql + "TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate and "

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate

            If TimeEntryAccountEmployeeId <> 0 Then
                sql = sql + "TimeEntryAccountEmployeeId = @TimeEntryAccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryAccountEmployeeId").Value = TimeEntryAccountEmployeeId

            End If

            ' For approved = false
            sql = sql + "Approved = 0) and (Rejected Is Null or Rejected = 0) and (Submitted = 1"

            sql = sql + ") Group By AccountProjectId, LeaderEmployeeId, ProjectManagerEmployeeId, ApprovalTypeName, AccountApprovalPathId, " & _
                    "AccountApprovalTypeId, SystemApproverTypeId, AccountExternalUserId, AccountEmployeeId, ApprovalPathSequence, " & _
                    "TimeSheetApprovalId, TimeSheetApprovalPathId, ProjectName, ProjectDescription, " & _
                    "ProjectCode, EmployeeName, Approved, TimeSheetApprovalTypeId, " & _
                    "Comments, IsReject, IsApproved, MaxApprovalPathSequence, TimeEntryAccountEmployeeId, " & _
                    "AccountId, EMailAddress, Submitted, EmployeeManagerId, IsBillable, " & _
                    "Rejected "




            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable = New AccountEmployeeTimeEntry.vueAccountEmployeeTimeEntryForApprovalDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace