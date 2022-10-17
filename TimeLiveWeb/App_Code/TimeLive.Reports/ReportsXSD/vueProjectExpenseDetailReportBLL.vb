Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace dsProjectExpenseDetailReportTableAdapters
    Partial Public Class vueAccountExpenseEntryTableAdapter

        Public Function GetDataForProjectExpenseDetailReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal AccountLocationId As Integer, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As DateTime, ByVal AccountExpenseEntryEndDate As DateTime, ByVal Submitted As String, ByVal Approval As String, ByVal Billable As String) As dsProjectExpenseDetailReport.vueAccountExpenseEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountExpenseEntry where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            sql = sql + "("
            'sql = sql + "(Submitted = 1) and "
            If AccountProjectId <> 0 Then
                sql = sql + "(AccountProjectId = @AccountProjectId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If AccountClientId <> 0 Then
                sql = sql + "(AccountClientId = @AccountClientId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountClientId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountClientId").Value = AccountClientId

            End If

            If AccountLocationId <> 0 Then
                sql = sql + "(AccountLocationId = @AccountLocationId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountLocationId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountLocationId").Value = AccountLocationId

            End If

            If IncludeDateRange = True Then
                sql = sql + "(AccountExpenseEntryDate >= @AccountExpenseEntryStartDate and AccountExpenseEntryDate <= @AccountExpenseEntryEndDate) and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryStartDate").Value = AccountExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryEndDate").Value = AccountExpenseEntryEndDate
            End If

            If Submitted = -1 Then
                sql = sql + "(Submitted = Submitted) and "
            ElseIf Submitted = 0 Then
                sql = sql + "(Submitted <> 1) and "
            ElseIf Submitted = 1 Then
                sql = sql + "(Submitted = 1) and "
            End If

            If Approval = -1 Then
                sql = sql + "(Approved = Approved) and "
            ElseIf Approval = 0 Then
                sql = sql + "(Approved <> 1) and "
            ElseIf Approval = 1 Then
                sql = sql + "(Approved = 1) and "
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Approval", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Approval").Value = Approval

            If Billable = -1 Then
                sql = sql + "((IsBillable is null) or (IsBillable = 1) or (IsBillable = 0))"
            ElseIf Billable = 0 Then
                sql = sql + "((IsBillable <> 1) or (IsBillable is null))"
            ElseIf Billable = 1 Then
                sql = sql + "((IsBillable = 1))"
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Billable", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Billable").Value = Billable

            sql = sql + ") Order By AccountExpenseEntryDate"


            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As dsProjectExpenseDetailReport.vueAccountExpenseEntryDataTable = New dsProjectExpenseDetailReport.vueAccountExpenseEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class
End Namespace

