Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace dsExpenseByClientTableAdapters
    Partial Public Class vueAccountExpenseEntryAdapter


        Public Function GetDataForExpenseByClientReort(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountLocationId As Integer, ByVal AccountExpenseId As Integer, ByVal Submitted As String, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As DateTime, ByVal AccountExpenseEntryEndDate As DateTime) As dsExpenseByClient.vueAccountExpenseEntryDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "SELECT EmployeeName, AccountExpenseName, ProjectName, SUM(Amount/ExchangeRate) AS Amount, PartyName,ExpenseType FROM vueAccountExpenseEntry where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            sql = sql + "("

            If AccountClientId <> 0 Then
                sql = sql + "(AccountClientId = @AccountClientId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountClientId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountClientId").Value = AccountClientId

            End If

            If AccountProjectId <> 0 Then
                sql = sql + "(AccountProjectId = @AccountProjectId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If AccountLocationId <> 0 Then
                sql = sql + "(AccountLocationId = @AccountLocationId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountLocationId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountLocationId").Value = AccountLocationId

            End If

            If AccountExpenseId <> 0 Then
                sql = sql + "(AccountExpenseId = @AccountExpenseId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseId").Value = AccountExpenseId

            End If

            If Submitted = -1 Then
                sql = sql + "(Submitted = Submitted) and "
            ElseIf Submitted = 0 Then
                sql = sql + "(Submitted <> 1) and "
            ElseIf Submitted = 1 Then
                sql = sql + "(Submitted = 1) and "
            End If

            If IncludeDateRange = True Then
                sql = sql + "(AccountExpenseEntryDate >= @AccountExpenseEntryStartDate and AccountExpenseEntryDate <= @AccountExpenseEntryEndDate) and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryStartDate").Value = AccountExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryEndDate").Value = AccountExpenseEntryEndDate
            End If

            sql = sql + "(Approved = 1)"
            sql = sql + ") "
            sql = sql + "GROUP BY ProjectName, EmployeeName, AccountExpenseName, PartyName,ExpenseType"

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As dsExpenseByClient.vueAccountExpenseEntryDataTable = New dsExpenseByClient.vueAccountExpenseEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class
End Namespace

