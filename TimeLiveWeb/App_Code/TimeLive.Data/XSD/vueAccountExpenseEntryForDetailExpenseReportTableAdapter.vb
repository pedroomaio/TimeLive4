Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountExpenseEntryForDetailExpenseReportTableAdapter

        Public Function GetDataByAccountIdAndEmployees(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As DateTime, ByVal AccountExpenseEntryEndDate As DateTime, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
            Dim sql As String
            Dim sql2 As String


            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountExpenseEntry where "
            '     sql2 = "select AccountProjectID from vueAccountExpenseEntry where "


            sql = sql + " (AccountId = @AccountId) and "
            '      sql2 = sql2 + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            '     sql2 = sql2 + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            sql = sql + "("
            sql = sql + "(Submitted = 1) and "
            '  sql2 = sql2 + "("
            '  sql2 = sql2 + "(Submitted = 1) and "
            If AccountProjectId <> 0 Then
                sql = sql + "(AccountProjectId = @AccountProjectId) and "
                '      sql2 = sql2 + "(AccountProjectId = @AccountProjectId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If AccountClientId <> 0 Then
                sql = sql + "(AccountClientId = @AccountClientId) and "
                '      sql2 = sql2 + "(AccountClientId = @AccountClientId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountClientId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountClientId").Value = AccountClientId

            End If

            If IncludeDateRange = True Then
                sql = sql + "(AccountExpenseEntryDate >= @AccountExpenseEntryStartDate and AccountExpenseEntryDate <= @AccountExpenseEntryEndDate) and "
                '      sql2 = sql2 + "(AccountExpenseEntryDate >= @AccountExpenseEntryStartDate and AccountExpenseEntryDate <= @AccountExpenseEntryEndDate) and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryStartDate").Value = AccountExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryEndDate").Value = AccountExpenseEntryEndDate
            End If

            If Approval = -1 Then
                sql = sql + "(Approved = Approved) and "
                '     sql2 = sql2 + "(Approved = Approved) and "
            ElseIf Approval = 0 Then
                sql = sql + "(Approved <> 1) and "
                '    sql2 = sql2 + "(Approved <> 1) and "
            ElseIf Approval = 1 Then
                sql = sql + "(Approved = 1) and "
                '    sql2 = sql2 + "(Approved = 1) and "
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Approval", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Approval").Value = Approval

            If Billable = -1 Then
                sql = sql + "((IsBillable is null) or (IsBillable = 1) or (IsBillable = 0))"
                '    sql2 = sql2 + "((IsBillable is null) or (IsBillable = 1) or (IsBillable = 0))"
            ElseIf Billable = 0 Then
                sql = sql + "((IsBillable <> 1) or (IsBillable is null))"
                '   sql2 = sql2 + "((IsBillable <> 1) or (IsBillable is null))"
            ElseIf Billable = 1 Then
                sql = sql + "((IsBillable = 1))"
                '   sql2 = sql2 + "((IsBillable = 1))"
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Billable", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Billable").Value = Billable

            sql = sql + ") Order By AccountExpenseEntryDate"
            '      sql2 = sql2 + ")"


            '        System.Web.HttpContext.Current.Session.Add("SubQuery2", sql2)

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable = New TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

        Public Function GetDataByAccountIdAndEmployeesForExpenseEntryArchive(ByVal AccountId As Integer, ByVal AccountEmployeeId As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As DateTime, ByVal AccountExpenseEntryEndDate As DateTime, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountExpenseEntry where "


            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            If AccountEmployeeId <> 0 Then
                sql = sql + "AccountEmployeeId = @AccountEmployeeId and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            End If

            sql = sql + "("

            If AccountProjectId <> 0 Then
                sql = sql + "(AccountProjectId = @AccountProjectId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If AccountClientId <> 0 Then
                sql = sql + "(AccountClientId = @AccountClientId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountClientId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountClientId").Value = AccountClientId

            End If

            If IncludeDateRange = True Then
                sql = sql + "(AccountExpenseEntryDate >= @AccountExpenseEntryStartDate and AccountExpenseEntryDate <= @AccountExpenseEntryEndDate) and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryStartDate").Value = AccountExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryEndDate").Value = AccountExpenseEntryEndDate
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

            sql = sql + ")"


            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable = New TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function


        Public Function GetDataByAccountIdAndEmployeesForProjectSummaryReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal AccountExpenseEntryStartDate As DateTime, ByVal AccountExpenseEntryEndDate As DateTime, ByVal Approval As String, ByVal Billable As String) As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
            Dim sql As String
            Dim sql2 As String


            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)


            sql = "select * from vueAccountExpenseEntry where "
            '     sql2 = "select AccountProjectID from vueAccountExpenseEntry where "


            sql = sql + " (AccountId = @AccountId) and "
            '      sql2 = sql2 + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            sql = sql + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            '     sql2 = sql2 + " (AccountEmployeeId in (" & AccountEmployees & ")) And "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployees", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployees").Value = AccountEmployees

            sql = sql + "("
            sql = sql + "(Submitted = 1) and "
            '  sql2 = sql2 + "("
            '  sql2 = sql2 + "(Submitted = 1) and "
            If AccountProjectId <> 0 Then
                sql = sql + "(AccountProjectId = @AccountProjectId) and "
                '      sql2 = sql2 + "(AccountProjectId = @AccountProjectId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            End If

            If AccountClientId <> 0 Then
                sql = sql + "(AccountClientId = @AccountClientId) and "
                '      sql2 = sql2 + "(AccountClientId = @AccountClientId) and "


                Me.Adapter.SelectCommand.Parameters.Add("@AccountClientId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountClientId").Value = AccountClientId

            End If

            'If IncludeDateRange = True Then
            sql = sql + "(AccountExpenseEntryDate >= @AccountExpenseEntryStartDate and AccountExpenseEntryDate <= @AccountExpenseEntryEndDate) and "
            '      sql2 = sql2 + "(AccountExpenseEntryDate >= @AccountExpenseEntryStartDate and AccountExpenseEntryDate <= @AccountExpenseEntryEndDate) and "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryStartDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryStartDate").Value = AccountExpenseEntryStartDate

            Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryEndDate", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryEndDate").Value = AccountExpenseEntryEndDate
            'End If

            If Approval = -1 Then
                sql = sql + "(Approved = Approved) and "
                '     sql2 = sql2 + "(Approved = Approved) and "
            ElseIf Approval = 0 Then
                sql = sql + "(Approved <> 1) and "
                '    sql2 = sql2 + "(Approved <> 1) and "
            ElseIf Approval = 1 Then
                sql = sql + "(Approved = 1) and "
                '    sql2 = sql2 + "(Approved = 1) and "
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Approval", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Approval").Value = Approval

            If Billable = -1 Then
                sql = sql + "((IsBillable is null) or (IsBillable = 1) or (IsBillable = 0))"
                '    sql2 = sql2 + "((IsBillable is null) or (IsBillable = 1) or (IsBillable = 0))"
            ElseIf Billable = 0 Then
                sql = sql + "((IsBillable <> 1) or (IsBillable is null))"
                '   sql2 = sql2 + "((IsBillable <> 1) or (IsBillable is null))"
            ElseIf Billable = 1 Then
                sql = sql + "((IsBillable = 1))"
                '   sql2 = sql2 + "((IsBillable = 1))"
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Billable", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Billable").Value = Billable

            sql = sql + ") Order By AccountExpenseEntryDate"
            '      sql2 = sql2 + ")"


            '        System.Web.HttpContext.Current.Session.Add("SubQuery2", sql2)

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable = New TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function


    End Class
End Namespace

