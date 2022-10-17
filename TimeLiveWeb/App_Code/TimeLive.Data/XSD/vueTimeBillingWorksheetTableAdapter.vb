Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace AccountTimeExpenseBillingTableAdapters
    Partial Public Class vueTimeBillingWorksheetTableAdapter
        Public Function GetDataByAccountIdAndEmployeesForTimeBillingWorksheet(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountClientId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal Billed As String) As AccountTimeExpenseBilling.vueTimeBillingWorksheetDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueTimeBillingWorksheet where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


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

            If AccountProjectTaskId <> 0 Then
                sql = sql + "(AccountProjectTaskId = @AccountProjectTaskId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectTaskId").Value = AccountProjectTaskId

            End If

            If IncludeDateRange = True Then
                sql = sql + "(TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate) and "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            If Billed = -1 Then
                sql = sql + "(Billed = Billed) "
            ElseIf Billed = 0 Then
                sql = sql + "(Billed <> 1) "
            ElseIf Billed = 1 Then
                sql = sql + "(Billed = 1) "
            End If


            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As AccountTimeExpenseBilling.vueTimeBillingWorksheetDataTable = New AccountTimeExpenseBilling.vueTimeBillingWorksheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class

End Namespace

