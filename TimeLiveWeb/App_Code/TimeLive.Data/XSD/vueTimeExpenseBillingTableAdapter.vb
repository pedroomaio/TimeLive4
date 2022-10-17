Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace AccountTimeExpenseBillingTableAdapters
    Partial Public Class vueAccountTimeExpenseBillingTimesheetTableAdapter
        Public Function GetvueAccountTimeExpenseBillingByAccountClientId(ByVal AccountClientId As Integer, ByVal BillingCycleStartDate As DateTime, ByVal BillingCycleEndDate As DateTime, ByVal AccountProjectId As Integer, ByVal Billed As String) As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountTimeExpenseBillingTimesheet where "


            'sql = sql + " (AccountId = @AccountId) and "
            'Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            'Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            If AccountClientId <> 0 Then
                sql = sql + "(AccountClientId = @AccountClientId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountClientId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountClientId").Value = AccountClientId

            End If


            sql = sql + "(TimeEntryDate >= @BillingCycleStartDate and TimeEntryDate <= @BillingCycleEndDate) and "

            Me.Adapter.SelectCommand.Parameters.Add("@BillingCycleStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@BillingCycleStartDate").Value = BillingCycleStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@BillingCycleEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@BillingCycleEndDate").Value = BillingCycleEndDate


            If AccountProjectId <> 0 Then
                sql = sql + "(AccountProjectId = @AccountProjectId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If


            If Billed = -1 Then
                sql = sql + "(Billed = Billed) "
            ElseIf Billed = 0 Then
                sql = sql + "(Billed <> 1) "
            ElseIf Billed = 1 Then
                sql = sql + "(Billed = 1) "
            End If


            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetDataTable = New AccountTimeExpenseBilling.vueAccountTimeExpenseBillingTimesheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class

End Namespace

