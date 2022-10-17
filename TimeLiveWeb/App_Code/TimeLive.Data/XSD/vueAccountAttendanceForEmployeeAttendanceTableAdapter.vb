Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountAttendanceForEmployeeAttendanceTableAdapter



        Public Function GetDataByEmployees(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AttendanceStartDate As Date, ByVal AttendanceEndDate As Date) As TimeLiveDataSet.vueAccountAttendanceForEmployeeAttendanceDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "SELECT EmployeeCode, EmployeeName, InOut, Count(InOut) as TotalInOut FROM vueAccountAttendance where AccountEmployeeAttendanceId in (select max(AccountEmployeeAttendanceId) FROM AccountEmployeeAttendance where (AccountEmployeeId =vueAccountAttendance.AccountEmployeeId) And (AttendanceDate = vueAccountAttendance.AttendanceDate) And (InOut = vueAccountAttendance.InOut) GROUP BY AttendanceDate) "

            sql = sql + "and (InOut = 'In') and "

            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            If AccountEmployees <> "" Then
                sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
                Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
                Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees
            End If
            sql = sql + "("


            sql = sql + "(AttendanceDate >= @AttendanceStartDate and AttendanceDate <= @AttendanceEndDate)"

            Me.Adapter.SelectCommand.Parameters.Add("@AttendanceStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@AttendanceStartDate").Value = AttendanceStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@AttendanceEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@AttendanceEndDate").Value = AttendanceEndDate


            sql = sql + ") "

            sql = sql + "GROUP BY EmployeeCode, EmployeeName, InOut"
            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountAttendanceForEmployeeAttendanceDataTable = New TimeLiveDataSet.vueAccountAttendanceForEmployeeAttendanceDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class
End Namespace

