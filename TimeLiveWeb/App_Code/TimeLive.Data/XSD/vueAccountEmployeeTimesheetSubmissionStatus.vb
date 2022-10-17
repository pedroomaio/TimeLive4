Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters

    Public Class vueAccountEmployeeTimesheetSubmissionStatusTableAdapter


        Public Function GetDataAll(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountDepartmentID As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal objDropdown As DropDownList) As TimeLiveDataSet.vueAccountEmployeeTimesheetSubmissionStatusDataTable

            Dim sql As String
            Dim sql2 As String
            Dim sql3 As String



            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "SELECT     AccountEmployeeId, EmployeeName, DepartmentName, TimeEntryDate, sum(NotEntered) as NotEntered, sum(Entered) as Entered, Sum(Submitted) as Submitted, sum(Approved) as Approved, sum(Rejected) as Rejected, Role, AccountID FROM         dbo.##tempAccountEmployeeTimesheetSubmissionStatusALL where "
            'sql2 = "select TimeEntryDate from vueAccountEmployeeTimesheetSubmissionStatus  where "


            sql = sql + " (AccountId = @AccountId) and "
            'sql2 = sql2 + " (AccountID = " + CStr(AccountId) + ") and "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId



            If AccountDepartmentID <> 0 Then
                sql = sql + "  (AccountEmployeeID in (select AccountEmployeeID from AccountEmployee where AccountDepartmentID  = @AccountDepartmentId)) and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountDepartmentId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountDepartmentId").Value = AccountDepartmentID
            End If


            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            'sql2 = sql2 + " (AccountEmployeeId in (" & CStr(AccountEmployees) & ")) And "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            sql = sql + "((TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate)) "
            'sql2 = sql2 + " ((convert(varchar,TimeEntryDate,112) >= '" + CStr(Format(TimeEntryStartDate, "yyyymmdd")) + "' and convert(varchar,TimeEntryDate,112) <= '" + CStr(Format(TimeEntryEndDate, "yyyymmdd")) + "'))"

            sql = sql + " Group by AccountEmployeeId, EmployeeName, DepartmentName, TimeEntryDate, AccountID, Role"


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



            Dim objConnection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()

            Dim strEmployees As String
            Dim strsql As String

            strsql = "IF  EXISTS (SELECT * FROM TEMPDB.dbo.sysobjects WHERE NAME = '##TEMP') DROP TABLE Tempdb.[dbo].[##TEMP]"
            DBUtilities.ExecuteCommand(strsql)


            Dim command As SqlCommand = _
                    New SqlCommand("InsertAbsentDate", objConnection)


            ' objConnection.Open()

            If objDropdown.SelectedValue = 0 Then
                For Each objListItem As ListItem In objDropdown.Items
                    If objListItem.Value > 0 Then

                        strEmployees = objListItem.Value

                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Clear()
                        command.Parameters.Add("@startdate", TimeEntryStartDate)
                        command.Parameters.Add("@enddate", TimeEntryEndDate)
                        command.Parameters.Add("@AccountEmployeeID", strEmployees)
                        command.Parameters.Add("@AccountID", AccountId)



                        'command.Parameters.Add()
                        command.ExecuteNonQuery()

                    End If
                Next
            Else


                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Clear()
                command.Parameters.AddWithValue("@startdate", TimeEntryStartDate)
                command.Parameters.AddWithValue("@enddate", TimeEntryEndDate)
                command.Parameters.AddWithValue("@AccountEmployeeID", AccountEmployees)
                command.Parameters.AddWithValue("@AccountID", AccountId)
                command.ExecuteNonQuery()

            End If


            Dim command2 As SqlCommand = _
                    New SqlCommand("CreateTableforAccountEmployeeTimesheetSubmissionStatus", objConnection)


            command2.CommandType = CommandType.StoredProcedure
            command2.Parameters.Clear()
            command2.Parameters.AddWithValue("@startdate", TimeEntryStartDate)
            command2.Parameters.AddWithValue("@enddate", TimeEntryEndDate)
            command2.Parameters.AddWithValue("@AccountEmployeeID", AccountEmployees)
            command2.Parameters.AddWithValue("@AccountID", AccountId)
            command2.ExecuteNonQuery()
            ''DBUtilities.ExecuteCommand()






            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimesheetSubmissionStatusDataTable = New TimeLiveDataSet.vueAccountEmployeeTimesheetSubmissionStatusDataTable
            Me.Adapter.Fill(dataTable)
            objConnection.Close()
            Return dataTable

        End Function
    End Class
End Namespace

