Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters

    Public Class vueProjectSummaryTableAdapter


        Public Function GetDataAll(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectID As Integer, ByVal AccountClientID As Integer, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As TimeLiveDataSet.vueProjectSummaryDataTable


            Dim sql As String
            Dim sql2 As String
            Dim sql3 As String



            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "SELECT     * from vueProjectSummary where Approved = 1 and "
            sql = sql + " (AccountId = @AccountId) and "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            If AccountProjectID <> 0 Then
                sql = sql + "  (AccountProjectID = @AccountProjectID) and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectID", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectID").Value = AccountProjectID

            End If



            If AccountClientID <> 0 Then
                sql = sql + "  (AccountPartyID = @AccountClientID) and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountClientID", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountClientID").Value = AccountClientID

            End If

            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & "))  "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees


            'If IncludeDateRange Then
            sql = sql + " And ((TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate)) "
            'End If


            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate




            Me.Adapter.SelectCommand.CommandText = sql

            ' ''            sql3 = "Declare @startdate datetime    Declare @enddate datetime        Set @startdate='04/01/2007'   Set @enddate='04/10/2007'" & _
            ' '' " insert into tempAbsentDate(AbsentDate, AccountEmployeeID, AccountID) Select dateadd(day,number,@startdate), 129 as AccountEmployeeID, 151 as AccountID from master.dbo.spt_values " & _
            ' ''" where master.dbo.spt_values.type='p' and dateadd(day,number,@startdate)<=@enddate " & _
            ' ''" and dateadd(day,number,@startdate) not in " & _
            ' ''" (" & sql2 & ")"

            ' ''            DBUtilities.ExecuteCommand(sql3)
            'running store procedure 



            Dim dataTable As TimeLiveDataSet.vueProjectSummaryDataTable = New TimeLiveDataSet.vueProjectSummaryDataTable

            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function


        Public Function GetDataAll2(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectID As Integer, ByVal AccountClientID As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As TimeLiveDataSet.vueProjectSummaryDataTable


            Dim sql As String
            Dim sql2 As String
            Dim sql3 As String



            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "SELECT     * from vueProjectSummary where Approved = 1  "
            sql = sql + "  and (AccountId = @AccountId)  "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            If AccountProjectID <> 0 Then
                sql = sql + "  and (AccountProjectID = @AccountProjectID) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectID", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectID").Value = AccountProjectID

            End If



            If AccountClientID <> 0 Then
                sql = sql + "  and (AccountPartyID = @AccountClientID)  "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountClientID", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountClientID").Value = AccountClientID

            End If

            sql = sql + " and (AccountEmployeeId in (" & AccountEmployees & "))  "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees


            If IncludeDateRange Then
                sql = sql + " And ((TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate)) "
            End If


            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate




            Me.Adapter.SelectCommand.CommandText = sql

            ' ''            sql3 = "Declare @startdate datetime    Declare @enddate datetime        Set @startdate='04/01/2007'   Set @enddate='04/10/2007'" & _
            ' '' " insert into tempAbsentDate(AbsentDate, AccountEmployeeID, AccountID) Select dateadd(day,number,@startdate), 129 as AccountEmployeeID, 151 as AccountID from master.dbo.spt_values " & _
            ' ''" where master.dbo.spt_values.type='p' and dateadd(day,number,@startdate)<=@enddate " & _
            ' ''" and dateadd(day,number,@startdate) not in " & _
            ' ''" (" & sql2 & ")"

            ' ''            DBUtilities.ExecuteCommand(sql3)
            'running store procedure 



            Dim dataTable As TimeLiveDataSet.vueProjectSummaryDataTable = New TimeLiveDataSet.vueProjectSummaryDataTable

            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

        'Public Function GetProjectsByAccountID(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectForProjectSummaryDataTable



        '    Dim sql As String

        '    Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


        '    sql = "SELECT     * from vueAccountProjectForProjectSummary  where "
        '    sql = sql + " (AccountId = @AccountId) "

        '    Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
        '    Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


        '    Me.Adapter.SelectCommand.CommandText = sql

        '    ' ''            sql3 = "Declare @startdate datetime    Declare @enddate datetime        Set @startdate='04/01/2007'   Set @enddate='04/10/2007'" & _
        '    ' '' " insert into tempAbsentDate(AbsentDate, AccountEmployeeID, AccountID) Select dateadd(day,number,@startdate), 129 as AccountEmployeeID, 151 as AccountID from master.dbo.spt_values " & _
        '    ' ''" where master.dbo.spt_values.type='p' and dateadd(day,number,@startdate)<=@enddate " & _
        '    ' ''" and dateadd(day,number,@startdate) not in " & _
        '    ' ''" (" & sql2 & ")"

        '    ' ''            DBUtilities.ExecuteCommand(sql3)
        '    'running store procedure 



        '    Dim dataTable As TimeLiveDataSet.vueAccountProjectForProjectSummaryDataTable = New TimeLiveDataSet.vueAccountProjectForProjectSummaryDataTable

        '    Me.Adapter.Fill(dataTable)
        '    Return dataTable

        'End Function

    End Class
End Namespace

