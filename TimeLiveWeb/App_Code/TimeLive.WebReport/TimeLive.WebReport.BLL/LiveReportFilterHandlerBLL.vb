Imports Microsoft.VisualBasic
Public Class LiveReportFilterHandlerBLL
    Dim StartDate As New eWorld.UI.CalendarPopup
    Dim EndDate As New eWorld.UI.CalendarPopup
    Dim FilterStartDate As String
    Dim FilterEndDate As String
    Dim dtFilterStartDate As Date
    Dim dtFilterEndDate As Date
    Public Function HandlerFilter(ByVal FilterControl As Control, ByVal AccountReportId As Guid) As String
        Dim WhereClause As String = ""
        Dim ddl As New DropDownList
        Dim chk As New CheckBox
        Dim BLL As New LiveReportData
        Dim rd As New RadioButton
        Dim ExpenseEntry As New CheckBox
        Dim ExpenseSheet As New CheckBox


        Dim dtSystemReport As ReportFilter.vueAccountReportFilterDataTable = BLL.GetvueAccountReportFilterByAccountReportId(AccountReportId)
        Dim drSystemReport As ReportFilter.vueAccountReportFilterRow
        If dtSystemReport.Rows.Count > 0 Then
            drSystemReport = dtSystemReport.Rows(0)
            For Each drSystemReport In dtSystemReport.Rows

                If WhereClause = "" Then
                    WhereClause = "AccountId = " & DBUtilities.GetSessionAccountId & " and "
                End If

                If drSystemReport.FilterOperator = "=All" Then
                    ddl = CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource), DropDownList)
                    If Me.GetIdFromDropdown(ddl) <> "" Then
                        If drSystemReport.SystemReportFilterSource = "AssignedProject" And Me.GetIdFromDropdown(ddl) = "-1" Then
                            WhereClause = WhereClause + "(AccountProjectId is null) and "
                        Else
                            WhereClause = WhereClause + "(" & drSystemReport.FilterField & " in (" & Me.GetIdFromDropdown(ddl) & ")" & IIf(drSystemReport.SystemReportFilterSource = "AssignedProject" And ddl.SelectedValue = 0, " or AccountProjectId is null)", ")") & "and "
                        End If
                    End If

                ElseIf drSystemReport.FilterOperator = "=" Then
                    ddl = CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource), DropDownList)
                    If ddl.SelectedValue <> "0" And ddl.SelectedValue <> "" Then
                        WhereClause = WhereClause + "(" & drSystemReport.FilterField & " = " & ddl.SelectedValue & ") and "
                    End If

                ElseIf drSystemReport.FilterOperator = "Between" And Not drSystemReport.SystemReportDataSourceId = New Guid("665306D7-D2D5-4A9B-A248-B7AD53D587E8") Then

                    If CType(FilterControl.FindControl("IncludeDateRange"), CheckBox) IsNot Nothing Then
                        chk = CType(FilterControl.FindControl("IncludeDateRange"), CheckBox)
                    End If

                    If CType(FilterControl.FindControl("rd_expenseEntry"), CheckBox) IsNot Nothing Then
                        ExpenseEntry = CType(FilterControl.FindControl("rd_expenseEntry"), CheckBox)
                    End If

                    If CType(FilterControl.FindControl("rd_expenseSheet"), CheckBox) IsNot Nothing Then
                        ExpenseSheet = CType(FilterControl.FindControl("rd_expenseSheet"), CheckBox)
                    End If

                    If CType(FilterControl.FindControl("StartDate"), eWorld.UI.CalendarPopup) IsNot Nothing Then
                        StartDate = CType(FilterControl.FindControl("StartDate"), eWorld.UI.CalendarPopup)
                    End If

                    If CType(FilterControl.FindControl("EndDate"), eWorld.UI.CalendarPopup) IsNot Nothing Then
                        EndDate = CType(FilterControl.FindControl("EndDate"), eWorld.UI.CalendarPopup)
                    End If

                    If drSystemReport.SystemReportDataSourceId = New Guid("ee5f3316-3a5e-484e-ae9e-9b11f0990997") Then

                        'chk_DisabledFilter
                        If FilterControl.FindControl("chk_DisabledFilter") IsNot Nothing Then
                            System.Web.HttpContext.Current.Session("chk_DisabledFilter") = FilterControl.FindControl("chk_DisabledFilter")
                        End If

                        If FilterControl.FindControl("hdnFieldValues") IsNot Nothing Then
                            System.Web.HttpContext.Current.Session("DepartmentsListMultiHdnField") = FilterControl.FindControl("hdnFieldValues")
                        End If

                        If FilterControl.FindControl("AssignedProject") IsNot Nothing Then
                            System.Web.HttpContext.Current.Session("FilterAssignedProject") = FilterControl.FindControl("AssignedProject")
                        End If

                        If FilterControl.FindControl("AssignedEmployees") IsNot Nothing Then
                            System.Web.HttpContext.Current.Session("FilterAssignedEmployees") = FilterControl.FindControl("AssignedEmployees")
                        End If

                        If FilterControl.FindControl("Submitted") IsNot Nothing Then
                            System.Web.HttpContext.Current.Session("SubmittedStatus") = FilterControl.FindControl("Submitted")
                        End If

                        If FilterControl.FindControl("NotSaved") IsNot Nothing Then
                            System.Web.HttpContext.Current.Session("NotSavedStatus") = FilterControl.FindControl("NotSaved")
                        End If
                        If FilterControl.FindControl("Saved") IsNot Nothing Then
                            System.Web.HttpContext.Current.Session("SavedStatus") = FilterControl.FindControl("Saved")
                        End If
                        If FilterControl.FindControl("Rejected") IsNot Nothing Then
                            System.Web.HttpContext.Current.Session("RejectedStatus") = FilterControl.FindControl("Rejected")
                        End If
                    End If
                    SetDateValue()

                    System.Web.HttpContext.Current.Session("FilterStartDate") = CType(FilterControl.FindControl("StartDate"), eWorld.UI.CalendarPopup).SelectedDate.ToString()
                    System.Web.HttpContext.Current.Session("FilterEndDate") = CType(FilterControl.FindControl("EndDate"), eWorld.UI.CalendarPopup).SelectedDate.ToString()

                    If chk IsNot Nothing Then
                        If chk.Checked Then
                            If ExpenseEntry.Checked Or ExpenseSheet.Checked Then
                                If ExpenseEntry.Checked = True Then
                                    WhereClause = WhereClause + "(" & GetDateColumnName(drSystemReport.ReportDataSourceName, "StartDate") & " >= " & FilterStartDate & " and " & GetDateColumnName(drSystemReport.ReportDataSourceName, "EndDate") & " <= " & FilterEndDate & ") and "
                                End If
                                If ExpenseSheet.Checked = True Then
                                    WhereClause = WhereClause + "(" & GetDateColumnName("Expense Sheet", "") & " >= " & FilterStartDate & " And " & GetDateColumnName("Expense Sheet", "") & " <= " & FilterEndDate & ")"
                                End If
                            Else
                                WhereClause = WhereClause + "(" & GetDateColumnName(drSystemReport.ReportDataSourceName, "StartDate") & " >= " & FilterStartDate & " And " & GetDateColumnName(drSystemReport.ReportDataSourceName, "EndDate") & " <= " & FilterEndDate & ") And "
                            End If
                        End If
                    End If

                ElseIf drSystemReport.FilterOperator = "Approved" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Approved"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Approved"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(Approved = 1) And "
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Not Approved"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Not Approved"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "((Approved <> 1) Or (Approved Is null)) And "
                        End If

                    ElseIf drSystemReport.FilterOperator = "Submitted" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Submitted"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Submitted"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(Submitted = 1) And "
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Not Submitted"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Not Submitted"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "((Submitted <> 1) Or (Submitted Is null)) And "
                        End If

                    ElseIf drSystemReport.FilterOperator = "Billable" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Billable"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Billable"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(IsBillable = 1) And "
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Non-Billable"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Non-Billable"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "((IsBillable <> 1) Or (IsBillable Is null)) And "
                        End If

                    ElseIf drSystemReport.FilterOperator = "Paid" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Paid"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Paid"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(IsPaid = 1) And "
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "UnPaid"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "UnPaid"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "((IsPaid <> 1) Or (Ispaid Is null)) And "
                        End If

                    ElseIf drSystemReport.FilterOperator = "Disabled" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Disabled"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Disabled"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(IsDisabled = 1) And "
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Enabled"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Enabled"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "((IsDisabled <> 1) Or (IsDisabled Is null)) And "
                        End If

                    ElseIf drSystemReport.FilterOperator = "ActiveStatus" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Active"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Active"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(IsActive = 1) And "
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "InActive"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "InActive"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "((IsActive <> 1) Or (IsActive Is null)) And "
                        End If


                    ElseIf drSystemReport.FilterOperator = "ApprovalType" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Rejected"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Rejected"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(" & GetByDataSource(drSystemReport.ReportDataSourceName) & " = 1) And "
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Approved"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Approved"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(IsApproved = 1) And "
                        End If

                    ElseIf drSystemReport.FilterOperator = "Reimbursement" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Non Reimbursement"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Non Reimbursement"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(Reimburse = 0) And "
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Reimbursement"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Reimbursement"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(Reimburse = 1) And "
                        End If

                    ElseIf drSystemReport.FilterOperator = "Billed" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Not Billed"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Not Billed"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(Billed = 0 Or Billed Is null) And "
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Billed"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Billed"), RadioButton).Checked = True Then
                            WhereClause = WhereClause + "(Billed = 1) And "
                        End If

                    ElseIf drSystemReport.FilterOperator = "Guid" Then
                        ddl = CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource), DropDownList)
                        If ddl.SelectedValue <> "0" And ddl.SelectedValue <> "" Then
                            WhereClause = WhereClause + "(" & drSystemReport.FilterField & " = '" & ddl.SelectedValue & "') and "
                        End If

                    ElseIf drSystemReport.FilterOperator = "TimesheetType" Then
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Timesheet Records"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Timesheet Records"), RadioButton).Checked = True Then
                        WhereClause = WhereClause + "(IsTimeOff = 0 or IsTimeOff is null) and "
                    End If
                    If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Time Off Records"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Time Off Records"), RadioButton).Checked = True Then
                        WhereClause = WhereClause + "(IsTimeOff = 1) and "
                    End If
                End If
            Next
            If Right(WhereClause, 4).ToUpper() = "AND " Then
                WhereClause = Left(WhereClause, WhereClause.Length - 4)
            End If
            'WhereClause = WhereClause + " order by AccountEmployeeId, TimeEntryDate, AccountProjectId, AccountProjectTaskId"
        End If
        Return WhereClause
    End Function
    Public Function GetIdFromDropdown(ByVal objDropdown As DropDownList) As String
        Dim strObject As String = ""
        If objDropdown.SelectedValue = 0 Then
            For Each objListItem As ListItem In objDropdown.Items
                If objListItem.Value <> -1 Then
                    strObject = strObject & IIf(strObject = "", "", ",") & objListItem.Value
                End If
            Next
        Else
            strObject = objDropdown.SelectedValue
        End If
        Return strObject
    End Function
    Public Function GetDateColumnName(ByVal DataSourceName As String, ByVal DateType As String) As String

        If DataSourceName = "Time Entry" Or DataSourceName = "Employee Time Off Detail" Then
            Return "TimeEntryDate"
        ElseIf DataSourceName = "Time Entry Fault" Then
            Return "TimeEntryDate"
        ElseIf DataSourceName = "Expense Entry" Then
            Return "AccountExpenseEntryDate"
        ElseIf DataSourceName = "Attendance" Or DataSourceName = "Absence" Then
            Return "AttendanceDate"
        ElseIf DataSourceName = "Time Entry Approval Activity" Then
            Return "TimeEntryDate"
        ElseIf DataSourceName = "Expense Entry Approval Activity" Then
            Return "AccountExpenseEntryDate"
        ElseIf DataSourceName = "TimeLive Invoice" Then
            Return "InvoiceDate"
        ElseIf DataSourceName = "Expense Sheet" Then
            Return "ExpenseSheetDate"
        ElseIf DataSourceName = "Time Entry Period" And DateType = "StartDate" Then
            Return "TimeEntryStartDate"
        ElseIf DataSourceName = "Time Entry Period" And DateType = "EndDate" Then
            Return "TimeEntryEndDate"
        ElseIf DataSourceName = "Missing Time Entry Period" And DateType = "StartDate" Then
            Return "TimeEntryStartDate"
        ElseIf DataSourceName = "Missing Time Entry Period" And DateType = "EndDate" Then
            Return "TimeEntryEndDate"
        ElseIf DataSourceName = "Expense Sheet Audit Trail" Or DataSourceName = "Timesheet Audit Trail" Then
            Return "UpdateDate"
        ElseIf DataSourceName = "Time Off Request" Then
            Return "StartDate"
        ElseIf DataSourceName = "Employee Time Off Audit Report" Then
            'Return "cast(ExecutedDate as datetime)"
            Return "Convert(DateTime, Convert(VARCHAR(10), ExecutedDate, 120), 120)"
        ElseIf DataSourceName = "Tasks" And DateType = "StartDate" Then
            Return "StartDate"
        ElseIf DataSourceName = "Tasks" And DateType = "EndDate" Then
            Return "DeadlineDate"
        ElseIf DataSourceName = "Project Task" And DateType = "StartDate" Then
            Return "TaskStartDate"
        ElseIf DataSourceName = "ProjectTask" And DateType = "EndDate" Then
            Return "TaskDeadlineDate"
        End If
    End Function
    Public Sub SetDateValue()
        If StartDate.PostedDate Is Nothing Then
            FilterStartDate = LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQureyForReport(LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Now.Date.ToString))
            FilterEndDate = LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQureyForReport(LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(Now.Date.ToString))
        Else
            FilterStartDate = LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQureyForReport(LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(StartDate.PostedDate))
            FilterEndDate = LocaleUtilitiesBLL.ConvertDateBaseIntoSQLQureyForReport(LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(EndDate.PostedDate))
        End If
    End Sub
    Public Function GetByDataSource(ByVal DataSourceName As String) As String
        If DataSourceName = "Time Entry Approval Activity" Then
            Return "IsReject"
        ElseIf DataSourceName = "Expense Entry Approval Activity" Then
            Return "IsRejected"
        End If
    End Function
    Public Function GetFilterForTimeEntryMissingReport(ByVal FilterControl As Control, ByVal AccountReportId As Guid) As String
        Dim WhereClause As String = ""
        Dim ddl As New DropDownList
        Dim BLL As New LiveReportData

        Dim dtSystemReport As ReportFilter.vueAccountReportFilterDataTable = BLL.GetvueAccountReportFilterByAccountReportId(AccountReportId)
        Dim drSystemReport As ReportFilter.vueAccountReportFilterRow
        If dtSystemReport.Rows.Count > 0 Then
            drSystemReport = dtSystemReport.Rows(0)
            For Each drSystemReport In dtSystemReport.Rows

                If WhereClause = "" Then
                    WhereClause = "AccountId = " & DBUtilities.GetSessionAccountId & " and "
                End If
                If drSystemReport.FilterOperator = "=All" Then
                    ddl = CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource), DropDownList)
                    If Me.GetIdFromDropdown(ddl) <> "" Then
                        WhereClause = WhereClause + "(" & drSystemReport.FilterField & " in (" & Me.GetIdFromDropdown(ddl) & ")) and "
                    End If
                ElseIf drSystemReport.FilterOperator = "=" Then
                    ddl = CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource), DropDownList)
                    If ddl.SelectedValue <> "0" And ddl.SelectedValue <> "" Then
                        WhereClause = WhereClause + "(" & drSystemReport.FilterField & " = " & ddl.SelectedValue & ") and "
                    End If
                End If
            Next
            If Right(WhereClause, 4) = "and " Then
                WhereClause = Left(WhereClause, WhereClause.Length - 4)
            End If
        End If
        Return WhereClause
    End Function
    Public Function GetStartAndEndDateForTimeEntryMissingReport(ByVal FilterControl As Control, ByVal AccountReportId As Guid) As Hashtable
        Dim BLL As New LiveReportData
        Dim dtDate As New Hashtable
        Dim dtSystemReport As ReportFilter.vueAccountReportFilterDataTable = BLL.GetvueAccountReportFilterByAccountReportId(AccountReportId)
        Dim drSystemReport As ReportFilter.vueAccountReportFilterRow
        If dtSystemReport.Rows.Count > 0 Then
            drSystemReport = dtSystemReport.Rows(0)
            For Each drSystemReport In dtSystemReport.Rows
                If drSystemReport.FilterOperator = "Between" Then
                    StartDate = CType(FilterControl.FindControl("StartDate"), eWorld.UI.CalendarPopup)
                    EndDate = CType(FilterControl.FindControl("EndDate"), eWorld.UI.CalendarPopup)
                    SetDateValueForTimeEntryMissingReport()
                    dtDate.Add("TimeEntryStartDate", dtFilterStartDate)
                    dtDate.Add("TimeEntryEndDate", dtFilterEndDate)
                End If
            Next
        End If
        Return dtDate
    End Function
    Public Sub SetDateValueForTimeEntryMissingReport()
        If StartDate.PostedDate Is Nothing Then
            dtFilterStartDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
            dtFilterEndDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        Else
            dtFilterStartDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(StartDate.PostedDate))
            dtFilterEndDate = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsString(EndDate.PostedDate))
        End If
    End Sub
    Public Function GetFilterValueOfTimesheetPeriodType(ByVal FilterControl As Control, ByVal AccountReportId As Guid) As String
        Dim BLL As New LiveReportData
        Dim dtSystemReport As ReportFilter.vueAccountReportFilterDataTable = BLL.GetvueAccountReportFilterByAccountReportId(AccountReportId)
        Dim drSystemReport As ReportFilter.vueAccountReportFilterRow
        If dtSystemReport.Rows.Count > 0 Then
            drSystemReport = dtSystemReport.Rows(0)
            For Each drSystemReport In dtSystemReport.Rows
                If drSystemReport.FilterOperator = "TimesheetPeriodType" Then
                    If drSystemReport.SystemReportDataSourceId = New Guid("0A0C26BE-01EE-41CD-9503-797D8CE7B834") Then
                        Return "MissingPeriods"
                    Else
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Entered Periods"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Entered Periods"), RadioButton).Checked = True Then
                            Return "EnteredPeriods"
                        End If
                        If Not CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Missing Periods"), RadioButton) Is Nothing And CType(FilterControl.FindControl(drSystemReport.SystemReportFilterSource & "Missing Periods"), RadioButton).Checked = True Then
                            Return "MissingPeriods"
                        End If
                    End If
                End If
            Next
            Return "Both"
        End If
        Return ""
    End Function

    Public Sub TakeOffVisible_DatebyExpense_Control(ByVal ExpenseEntry As CheckBox, ByVal ExpenseSheet As CheckBox)
        ExpenseEntry.Visible = False
        ExpenseSheet.Visible = False
    End Sub

End Class

