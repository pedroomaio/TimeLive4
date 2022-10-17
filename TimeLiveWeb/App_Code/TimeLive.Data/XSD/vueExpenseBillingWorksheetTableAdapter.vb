Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace AccountTimeExpenseBillingTableAdapters
    Partial Public Class vueExpenseBillingWorksheetTableAdapter
        Public Function GetDataByAccountIdAndEmployeesForExpenseBillingWorksheet(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal AccountExpenseId As Integer, ByVal AccountExpenseTypeId As Integer, ByVal IncludeDateRange As Boolean, ByVal ExpenseEntryStartDate As DateTime, ByVal ExpenseEntryEndDate As DateTime, ByVal Billed As String) As AccountTimeExpenseBilling.vueExpenseBillingWorksheetDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueExpenseBillingWorksheet where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            If AccountClientId <> 0 Then
                sql = sql + "(AccountClientId = @AccountClientId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountClientId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountClientId").Value = AccountClientId

            End If

            'sql = sql + "("

            If AccountProjectId <> 0 Then
                sql = sql + "(AccountProjectId = @AccountProjectId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If AccountExpenseId <> 0 Then
                sql = sql + "(AccountExpenseId = @AccountExpenseId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseId").Value = AccountExpenseId

            End If

            If AccountExpenseTypeId <> 0 Then
                sql = sql + "(AccountExpenseTypeId = @AccountExpenseTypeId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseTypeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseTypeId").Value = AccountExpenseTypeId
            End If

            If IncludeDateRange = True Then
                sql = sql + "(AccountExpenseEntryDate >= @ExpenseEntryStartDate and AccountExpenseEntryDate <= @ExpenseEntryEndDate) and "

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryStartDate").Value = ExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@ExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@ExpenseEntryEndDate").Value = ExpenseEntryEndDate
            End If

            If Billed = -1 Then
                sql = sql + "(Billed = Billed) "
            ElseIf Billed = 0 Then
                sql = sql + "(Billed <> 1) "
            ElseIf Billed = 1 Then
                sql = sql + "(Billed = 1) "
            End If

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As AccountTimeExpenseBilling.vueExpenseBillingWorksheetDataTable = New AccountTimeExpenseBilling.vueExpenseBillingWorksheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class

End Namespace

