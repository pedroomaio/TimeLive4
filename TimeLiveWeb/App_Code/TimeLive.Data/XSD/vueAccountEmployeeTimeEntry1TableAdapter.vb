Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountEmployeeTimeEntry1TableAdapter

        Public Function GetDataByAccountIdAndEmployees(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountPartyId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountEmployeeTimeEntry where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            sql = sql + "(Submitted = 1) and "

            If AccountPartyId <> 0 Then
                sql = sql + "(AccountPartyId = @AccountPartyId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountPartyId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountPartyId").Value = AccountPartyId

            End If

            sql = sql + "("

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

            sql = sql + ") order by AccountEmployeeId, TimeEntryDate, AccountProjectId, AccountProjectTaskId"


            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function


        Public Function GetDataByUserHoursDetailReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountPartyId As Integer, ByVal Billable As String, ByVal AccountDepartmentId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime) As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountEmployeeTimeEntry where "

            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            If AccountProjectId <> 0 Then
                sql = sql + " and (AccountProjectId = @AccountProjectId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId
            End If

            If AccountProjectTaskId <> 0 Then
                sql = sql + " and (AccountProjectTaskId = @AccountProjectTaskId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectTaskId").Value = AccountProjectTaskId
            End If

            If AccountPartyId <> 0 Then
                sql = sql + " and (AccountPartyId = @AccountPartyId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountPartyId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountPartyId").Value = AccountPartyId
            End If

            If Billable = -1 Then
                sql = sql + " and ((IsBillable is null) or (IsBillable = 1) or (IsBillable = 0))"
            ElseIf Billable = 0 Then
                sql = sql + " and ((IsBillable <> 1) or (IsBillable is null))"
            ElseIf Billable = 1 Then
                sql = sql + " and ((IsBillable = 1))"
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Billable", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Billable").Value = Billable

            If AccountDepartmentId <> 0 Then
                sql = sql + " and (AccountDepartmentId = @AccountDepartmentId) "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountDepartmentId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountDepartmentId").Value = AccountDepartmentId
            End If

            If IncludeDateRange = True Then
                sql = sql + " and (TimeEntryDate >= @TimeEntryStartDate and TimeEntryDate <= @TimeEntryEndDate) "

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            End If

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

        Public Function GetDataByAccountIdAndEmployeesForTimeSheetArchive(ByVal AccountId As Integer, ByVal AccountEmployeeId As String, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountPartyId As Integer, ByVal IncludeDateRange As Boolean, ByVal TimeEntryStartDate As DateTime, ByVal TimeEntryEndDate As DateTime, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountEmployeeTimeEntry where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            If AccountEmployeeId <> 0 Then
                sql = sql + "AccountEmployeeId = @AccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            End If

            If AccountPartyId <> 0 Then
                sql = sql + "(AccountPartyId = @AccountPartyId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountPartyId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountPartyId").Value = AccountPartyId

            End If

            sql = sql + "("

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

            sql = sql + ") order by AccountEmployeeId, TimeEntryDate, AccountProjectId, AccountProjectTaskId"


            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetvueAccountEmployeeTimeEntryDataByCurrentDate(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal IsTimeOff As Boolean) As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select TotalTime,AccountEmployeeId,AccountId,Hours,IsTimeOff from vueAccountEmployeeTimeEntry where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            sql = sql + " (AccountEmployeeId = @AccountEmployeeId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            sql = sql + " (IsTimeOff = @IsTimeOff) and "
            Me.Adapter.SelectCommand.Parameters.Add("@IsTimeOff", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@IsTimeOff").Value = IsTimeOff

            sql = sql + "(CONVERT(date, TotalTime) = CONVERT(date, GETDATE())) "

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable = New TimeLiveDataSet.vueAccountEmployeeTimeEntry1DataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class
End Namespace

