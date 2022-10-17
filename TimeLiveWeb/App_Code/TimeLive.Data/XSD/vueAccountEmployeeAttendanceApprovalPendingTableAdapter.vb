Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace AccountEmployeeAttendanceTableAdapters
    Partial Public Class vueAccountEmployeeAttendanceApprovalPendingTableAdapter
        Public Function GetApprovalEntriesForSpecificEmployee(ByVal AttendanceAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeAttendance.vueAccountEmployeeAttendanceApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeAttendanceApprovalPending where "

            sql = sql + " (AccountEmployeeId = @AccountEmployeeId ) and (SystemApproverTypeId = 3) and "

            sql = sql + "("

            sql = sql + " (ApprovalPathSequence = 1)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 2)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 3)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 4)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 5)"

            sql = sql + ")"

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "StartDate <= @StartDate and EndDate >= @EndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@StartDate").Value = StartDate

                Me.Adapter.SelectCommand.Parameters.Add("@EndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@EndDate").Value = EndDate
            End If



            If AttendanceAccountEmployeeId <> 0 Then
                sql = sql + " AttendanceAccountEmployeeId = @AttendanceAccountEmployeeId and"


                Me.Adapter.SelectCommand.Parameters.Add("@AttendanceAccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AttendanceAccountEmployeeId").Value = AttendanceAccountEmployeeId

            End If

            sql = sql + " Approved = 0 or Approved Is null) and (Rejected Is Null or Rejected = 0) "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeAttendance.vueAccountEmployeeAttendanceApprovalPendingDataTable = New AccountEmployeeAttendance.vueAccountEmployeeAttendanceApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function
        Public Function GetApprovalEntriesForEmployeeManager(ByVal AttendanceAccountEmployeeId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountEmployeeId As System.Nullable(Of Integer)) As AccountEmployeeAttendance.vueAccountEmployeeAttendanceApprovalPendingDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountEmployeeAttendanceApprovalPending where "

            ' For TeamLead --> ProjectManager --> SpecificEmployee
            sql = sql + " (EmployeeManagerId = @AccountEmployeeId ) and (SystemApproverTypeId = 5) and "

            sql = sql + "("

            sql = sql + " (ApprovalPathSequence = 1)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 2)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 3)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 4)"

            sql = sql + " or "

            sql = sql + " (ApprovalPathSequence = 5)"

            sql = sql + ")"

            ' General Check

            sql = sql + " and "
            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "StartDate <= @StartDate and EndDate >= @EndDate and "

                Me.Adapter.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@StartDate").Value = StartDate

                Me.Adapter.SelectCommand.Parameters.Add("@EndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@EndDate").Value = EndDate
            End If


            ' For Approved = False
            sql = sql + " Approved = 0 or Approved Is Null) and (Rejected Is Null or Rejected = 0) "

            Me.Adapter.SelectCommand.CommandText = sql

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Dim dataTable As AccountEmployeeAttendance.vueAccountEmployeeAttendanceApprovalPendingDataTable = New AccountEmployeeAttendance.vueAccountEmployeeAttendanceApprovalPendingDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable


        End Function

    End Class
End Namespace

