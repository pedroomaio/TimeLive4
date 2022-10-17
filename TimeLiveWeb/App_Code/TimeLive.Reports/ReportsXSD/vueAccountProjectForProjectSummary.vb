Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters

    Public Class vueAccountProjectForProjectSummaryTableAdapter




        Public Function GetProjectsByAccountID(ByVal AccountId As Integer, ByVal AccountProjectID As Integer) As TimeLiveDataSet.vueAccountProjectForProjectSummaryDataTable



            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "SELECT     * from vueAccountProjectForProjectSummary  where "
            sql = sql + " (AccountId = @AccountId) "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            If AccountProjectID <> 0 Then
                sql = sql + "  and  (AccountProjectID = @AccountProjectID)  "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectID", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectID").Value = AccountProjectID

            End If


            Me.Adapter.SelectCommand.CommandText = sql

            ' ''            sql3 = "Declare @startdate datetime    Declare @enddate datetime        Set @startdate='04/01/2007'   Set @enddate='04/10/2007'" & _
            ' '' " insert into tempAbsentDate(AbsentDate, AccountEmployeeID, AccountID) Select dateadd(day,number,@startdate), 129 as AccountEmployeeID, 151 as AccountID from master.dbo.spt_values " & _
            ' ''" where master.dbo.spt_values.type='p' and dateadd(day,number,@startdate)<=@enddate " & _
            ' ''" and dateadd(day,number,@startdate) not in " & _
            ' ''" (" & sql2 & ")"

            ' ''            DBUtilities.ExecuteCommand(sql3)
            'running store procedure 



            Dim dataTable As TimeLiveDataSet.vueAccountProjectForProjectSummaryDataTable = New TimeLiveDataSet.vueAccountProjectForProjectSummaryDataTable

            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class
End Namespace

