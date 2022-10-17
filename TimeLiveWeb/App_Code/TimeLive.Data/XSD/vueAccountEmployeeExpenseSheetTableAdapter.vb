Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Namespace AccountExpenseEntryTableAdapters
    Public Class vueAccountEmployeeExpenseSheetTableAdapter

        Public Function GetDataByAccountIdAndEmployeesForExpenseEntryArchiveBySheet(ByVal AccountId As Integer, ByVal AccountEmployeeId As String, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As DateTime, ByVal AccountExpenseEntryEndDate As DateTime, ByVal Approval As String, ByVal ExpenseTypes As String, ByVal PaymentStatus As Integer) As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable

            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountEmployeeExpenseSheet where "

            sql = sql + " (AccountId = @AccountId) and "
            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId


            If AccountEmployeeId <> 0 Then
                sql = sql + "AccountEmployeeId = @AccountEmployeeId and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId
            End If

            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "(ExpenseSheetDate >= @AccountExpenseEntryStartDate and ExpenseSheetDate <= @AccountExpenseEntryEndDate) and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryStartDate").Value = AccountExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryEndDate").Value = AccountExpenseEntryEndDate
            End If

            If Approval = -1 Then
                sql = sql + "(Approved = Approved) "
            ElseIf Approval = 0 Then
                sql = sql + "(Approved <> 1) "
            ElseIf Approval = 1 Then
                sql = sql + "(Approved = 1) "
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Approval", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Approval").Value = Approval

            sql = sql + ")"

            If ExpenseTypes IsNot "" Then
                sql = sql + " AND AccountEmployeeExpenseSheetId IN( "
                sql = sql + "(Select DISTINCT AccountEmployeeExpenseSheetId from AccountExpenseEntry "
                sql = sql + "Where AccountExpenseId IN "
                sql = sql + "(Select AccountExpenseId from AccountExpense expense "
                sql = sql + "Where ','+@ExpenseTypes+',' LIKE '%,'+CAST(AccountExpenseTypeId AS varchar)+',%'))) "
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@ExpenseTypes", SqlDbType.NVarChar)
            Me.Adapter.SelectCommand.Parameters("@ExpenseTypes").Value = ExpenseTypes

            Dim SpaceValues() As String = Split(" "c)

            If SpaceValues.Length >= 1 Then
                If SpaceValues(SpaceValues.Length - 1).Trim(" ") <> "and" Then
                    sql = sql + " and "
                End If
            End If

            sql = sql + " PaymentStatusId = @PaymentStatusId"

            Me.Adapter.SelectCommand.Parameters.Add("@PaymentStatusId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@PaymentStatusId").Value = PaymentStatus

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable = New AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

        Public Function GetDataByAccountIdAndEmployeesForExpenseEntryArchiveByEntry(ByVal AccountId As Integer, ByVal AccountEmployeeId As String, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As DateTime, ByVal AccountExpenseEntryEndDate As DateTime, ByVal Approval As String, ByVal ExpenseTypes As String, ByVal PaymentStatus As Integer) As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable

            Dim sql As String = ""

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = sql + "DECLARE @TableOfSheets table(AccountEmployeeExpenseSheetId uniqueidentifier , NewCalculatedAmount decimal(18,2)) "

            sql = sql + "Insert into @TableOfSheets "
            sql = sql + "Select AccountEmployeeExpenseSheetId , Amount = (Select Amount from vueAccountEmployeeExpenseSheetOnlyAmount b where b.AccountExpenseEntryId = a.AccountExpenseEntryId) from AccountExpenseEntry a where "

            sql = sql + " (AccountId = @AccountId) and "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            If AccountEmployeeId <> 0 Then
                sql = sql + "AccountEmployeeId = @AccountEmployeeId and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
                Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId
            End If

            sql = sql + "("

            If IncludeDateRange = True Then
                sql = sql + "(AccountExpenseEntryDate >= @AccountExpenseEntryStartDate and AccountExpenseEntryDate <= @AccountExpenseEntryEndDate) and "

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryStartDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryStartDate").Value = AccountExpenseEntryStartDate

                Me.Adapter.SelectCommand.Parameters.Add("@AccountExpenseEntryEndDate", SqlDbType.DateTime)
                Me.Adapter.SelectCommand.Parameters("@AccountExpenseEntryEndDate").Value = AccountExpenseEntryEndDate
            End If

            If Approval = -1 Then
                sql = sql + "(Approved = Approved) "
            ElseIf Approval = 0 Then
                sql = sql + "(Approved <> 1) "
            ElseIf Approval = 1 Then
                sql = sql + "(Approved = 1) "
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@Approval", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Approval").Value = Approval

            sql = sql + ")"

            If ExpenseTypes IsNot "" Then
                sql = sql + "and AccountExpenseId IN((Select AccountExpenseId from AccountExpense "
                sql = sql + "expense Where ','+@ExpenseTypes+',' LIKE '%,'"
                sql = sql + "+CAST(AccountExpenseTypeId AS varchar)+',%'))"
            End If

            Me.Adapter.SelectCommand.Parameters.Add("@ExpenseTypes", SqlDbType.NVarChar)
            Me.Adapter.SelectCommand.Parameters("@ExpenseTypes").Value = ExpenseTypes

            Dim SpaceValues() As String = Split(" "c)

            If SpaceValues.Length >= 1 Then
                If SpaceValues(SpaceValues.Length - 1).Trim(" ") <> "and" Then
                    sql = sql + " and "
                End If
            End If

            sql = sql + " PaymentStatusId = @PaymentStatusId "

            Me.Adapter.SelectCommand.Parameters.Add("@PaymentStatusId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@PaymentStatusId").Value = PaymentStatus

            sql = sql + "DECLARE @TableOfSheetsCalculated table(AccountEmployeeExpenseSheetId uniqueidentifier , NewCalculatedAmount decimal(18,2)) "
            sql = sql + "Insert into @TableOfSheetsCalculated "
            sql = sql + "Select Distinct AccountEmployeeExpenseSheetId , Sum(NewCalculatedAmount) from @TableOfSheets "
            sql = sql + "Group by AccountEmployeeExpenseSheetId "
            sql = sql + "Select * from vueAccountEmployeeExpenseSheet b "
            sql = sql + "Right join @TableOfSheetsCalculated a on b.AccountEmployeeExpenseSheetId = a.AccountEmployeeExpenseSheetId "

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dt As DataTable = New DataTable
            Me.Adapter.Fill(dt)
            For Each item As DataRow In dt.Rows
                item("Amount") = Math.Round(item("NewCalculatedAmount"), 2)
            Next
            dt.Columns.Remove("NewCalculatedAmount")

            Dim datatable As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable = New AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable
            datatable.Merge(dt)
            Return datatable

        End Function

        Public Function GetDataByAccountEmployeeIdAndApprovalStatus(ByVal AccountEmployeeId As Integer, ByVal ExpenseSheetStatudId As Integer, ByVal IncludeDateRange As Boolean, ByVal StartDate As Date, ByVal EndDate As Date) As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)
            ' Dim ExpenseStartDate As String = LocaleUtilitiesBLL.ConvertCurrentDateStringToDate(StartDate).ToString(LocaleUtilitiesBLL.GetBaseCultureInfo.DateTimeFormat.ShortDatePattern)
            'Dim ExpenseEntryDate As String = LocaleUtilitiesBLL.ConvertCurrentDateStringToDate(EndDate).ToString(LocaleUtilitiesBLL.GetBaseCultureInfo.DateTimeFormat.ShortDatePattern)
            sql = "Select * from vueAccountEmployeeExpenseSheet where (AccountEmployeeId = " & AccountEmployeeId & ") "
            If IncludeDateRange Then
                sql = sql + " and (ExpenseSheetDate >= " & LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQurey(StartDate) & " and ExpenseSheetDate <= " & LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQurey(EndDate) & ")"
            End If
            If ExpenseSheetStatudId = 1 Then
                sql = sql + "and ((approved = 0 and rejected = 0) or (AccountEmployeeId = " & AccountEmployeeId & " and rejected = 1))"
            ElseIf ExpenseSheetStatudId = 2 Then
                sql = sql + "and (submitted = 0 and approved = 0 and rejected = 0)"
            ElseIf ExpenseSheetStatudId = 3 Then
                sql = sql + "and (submitted = 1 and approved = 0 and rejected = 0)"
            ElseIf ExpenseSheetStatudId = 4 Then
                sql = sql + "and (approved = 1 and rejected = 0 and submitted = 1)"
            ElseIf ExpenseSheetStatudId = 5 Then
                sql = sql + "and (rejected = 1 and approved = 0 and submitted = 0)"
            End If
           
            sql = sql + " Order By ExpenseSheetDate"
            Me.Adapter.SelectCommand.CommandText = sql
            Dim dataTable As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable = New AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace
