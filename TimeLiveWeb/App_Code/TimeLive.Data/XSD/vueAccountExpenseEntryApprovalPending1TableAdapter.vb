Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountExpenseentryApprovalPendingTableAdapter

        Public Function GetDataByAccountIdAndEmployees(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As DateTime, ByVal ExpenseEntryEndDate As DateTime, ByVal Approval As String) As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountExpenseEntryApprovalPending where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            sql = sql + "("

            If AccountProjectId <> 0 Then
                sql = sql + "(AccountProjectId = @AccountProjectId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If IncludeDateRange = True Then
                sql = sql + "(AccountExpenseEntryDate >= @ExpenseEntryStartDate and AccountExpenseEntryDate <= @ExpenseEntryEndDate) and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If

            If Approval = -1 Then
                sql = sql + "(Approved = Approved)"
            ElseIf Approval = 0 Then
                sql = sql + "(Approved <> 1)"
            ElseIf Approval = 1 Then
                sql = sql + "(Approved = 1)"
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Approval", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Approval").Value = Approval

            sql = sql + ")"


            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable = New TimeLiveDataSet.vueAccountExpenseEntryApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function



    End Class
End Namespace

