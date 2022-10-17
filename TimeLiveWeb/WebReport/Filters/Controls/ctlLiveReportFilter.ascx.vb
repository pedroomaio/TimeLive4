Imports dsReportDesign

Partial Class WebReport_ctlLiveReportFilter
    Inherits System.Web.UI.UserControl
    'Dim FilterTable As New Table
    Dim FilterRow As TableRow
    Dim FilterCell As TableCell
    Dim FilterTableForDate As New Table
    Dim FilterRowForDate As TableRow
    Dim FilterCellForDate As TableCell
    Dim Consolidated As Boolean
    Dim ReportFilterBLL As New ReportFilterBLL
    Public Const DROPDOWN_WIDTH As Integer = 450%
    Public Const DROPDOWN_SMALL_WIDTH As Integer = 150%
    Public Const TEXTBOX_WIDTH As Integer = 60
    Public Event ShowClicked(ByVal WhereClause As String, ByVal Consolidated As Boolean, ByVal BaseCurrencyId As Integer, ByVal MissingPeriodReportWhereClause As String, ByVal MissingPeriodReportStartAndEndDate As Hashtable, ByVal TimesheetPeriodType As String)
    Public Event PageLoad(ByVal WhereClause As String, ByVal Consolidated As Boolean, ByVal BaseCurrencyId As Integer, ByVal MissingPeriodReportWhereClause As String, ByVal MissingPeriodReportStartAndEndDate As Hashtable, ByVal TimesheetPeriodType As String)
    Dim OjectPermissionBLL As New ObjectPermissionBLL
    Dim ddl As DropDownList

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If AuthenticateBLL.IsNewSession() Then
            If Me.Page.IsCallback Then
                AuthenticateBLL.DoLogoutForCallBack(Me.Page)
            Else
                AuthenticateBLL.DoLogout(Me.Page)
            End If
        End If
        LocaleUtilitiesBLL.SetPageCultureSetting(Me.Page)

        FilterTable.Attributes.Add("width", "700px")
        FilterTableForDate.Attributes.Add("width", "50%")
        FilterTableForDate.CssClass = "xTableWithoutBorder"
        FilterTableForDate.BorderWidth = 0

        Me.GetFiltersByReport()
        SetPermissionForDropDown()
        Me.AddCasDropDown()


        If Me.ViewState("WhereClause") Is Nothing Then
            Me.ViewState("WhereClause") = ""
        End If
        If Me.ViewState("MissingPeriodReportWhereClause") Is Nothing Then
            Me.ViewState("MissingPeriodReportWhereClause") = ""
        End If
        If Me.ViewState("MissingPeriodReportStartAndEndDate") Is Nothing Then
            Me.ViewState("MissingPeriodReportStartAndEndDate") = ""
        End If
        If Me.ViewState("TimesheetPeriodType") Is Nothing Then
            Me.ViewState("TimesheetPeriodType") = ""
        End If
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        Me.ViewState("WhereClause") = Me.GetFilterWhereClause(AccountReportId)
        Me.ViewState("MissingPeriodReportWhereClause") = Me.GetFilterWhereClauseForTimeEntryMissingReport(AccountReportId)
        Me.ViewState("MissingPeriodReportStartAndEndDate") = Me.GetFilterStartAndEndDateForTimeEntryMissingReport(AccountReportId)
        Me.ViewState("TimesheetPeriodType") = Me.GetFilterTimesheetPeriodType(AccountReportId)
        If Not Me.IsPostBack Then
            If Not CType(Me.FindControl("BaseCurrency"), DropDownList) Is Nothing Then
                CType(Me.FindControl("BaseCurrency"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BaseCurrencyId As Integer
        If Not Me.FindControl("BaseCurrency") Is Nothing Then
            If Me.ViewState("BaseCurrencyId") Is Nothing Then
                BaseCurrencyId = CType(Me.FindControl("BaseCurrency"), DropDownList).SelectedValue
            Else
                BaseCurrencyId = Me.ViewState("BaseCurrencyId")
            End If
        End If
        Dim bllreport As New TimeLive.WebReport.ReportDesignBLL
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        If bllreport.IsAccountReportGroupExistByAccountReportId(AccountReportId) Then
            Me.UpdateIsConsolidated(AccountReportId)
        End If
        If Me.IsPostBack Then
            RaiseEvent PageLoad(Me.ViewState("WhereClause"), Consolidated, BaseCurrencyId, Me.ViewState("MissingPeriodReportWhereClause"), Me.ViewState("MissingPeriodReportStartAndEndDate"), Me.ViewState("TimesheetPeriodType"))
        End If

        If CType(Me.FindControl("IncludeDateRange"), CheckBox) IsNot Nothing Then
            Session("ReportIncludeDataRange") = CType(Me.FindControl("IncludeDateRange"), CheckBox).Checked
        End If


        Dim StartDate As New eWorld.UI.CalendarPopup
        Dim EndDate As New eWorld.UI.CalendarPopup

        StartDate = CType(Me.FindControl("StartDate"), eWorld.UI.CalendarPopup)
        EndDate = CType(Me.FindControl("EndDate"), eWorld.UI.CalendarPopup)

        If StartDate IsNot Nothing And EndDate IsNot Nothing Then
            Dim DateRange As String = StartDate.SelectedDate.ToShortDateString() & " - " & EndDate.SelectedDate.ToShortDateString()
            Session("ReportsDataRange") = DateRange
        End If

    End Sub
    Public Sub GetFiltersByReport()
        Dim BLL As New LiveReportData
        Dim value As New Guid(Me.Request.QueryString("AccountReportId"))
        Dim dtSystemReport As ReportFilter.vueAccountReportFilterDataTable = BLL.GetvueAccountReportFilterByAccountReportId(value)
        Dim drSystemReport As ReportFilter.vueAccountReportFilterRow
        Dim ReportDataSourceId As Guid

        If dtSystemReport.Rows.Count > 0 Then
            drSystemReport = dtSystemReport.Rows(0)
            Me.AddFilterTableHeader(drSystemReport.ReportName)
            Me.AddFilterTableSubHeader()

            For Each drSystemReport In dtSystemReport.Rows
                Me.AddFilter("", drSystemReport.SystemReportFilterSource, drSystemReport.Caption, drSystemReport.IsRequired, drSystemReport.IsAllowAll, drSystemReport.SystemReportDataSourceId)
            Next
            Dim bllreport As New TimeLive.WebReport.ReportDesignBLL
            If bllreport.IsAccountReportGroupExistByAccountReportId(value) Then

                Dim dtAccountReportDataSourceMapping As dsReportDesign.AccountReportDataSourceMappingDataTable = bllreport.GetAccountReportDataSourceMappingByAccountReportId(value)
                Dim drAccountReportDataSourceMappingRow As dsReportDesign.AccountReportDataSourceMappingRow

                If dtAccountReportDataSourceMapping.Rows.Count > 0 Then
                    drAccountReportDataSourceMappingRow = dtAccountReportDataSourceMapping.Rows(0)
                    ReportDataSourceId = drAccountReportDataSourceMappingRow.SystemReportDataSourceId
                    If drAccountReportDataSourceMappingRow.SystemReportDataSourceId = New Guid("0f2d1d68-826d-400e-bf9f-95d4a9d6c4e0") Then
                        Me.AddReportTypeFilterDate()
                    End If
                End If

                If ReportDataSourceId <> New Guid("EE5F3316-3A5E-484E-AE9E-9B11F0990997") Then
                    Me.AddReportTypeFilter()
                Else
                    Me.AddRow()
                    Me.AddListBoxFilter("Departments: ", True, "DepartmentsListMulti", False)
                    Me.AddRow()
                    Me.AddCheckBoxFilter(Me.GetFromRescource("Include Disabled"), "chk_DisabledFilter", 1)
                    Me.AddRow()
                    Me.AddStatusCheckFilter("Status: ", "StatusFilter", True, True, True)
                End If

                Me.SetDefaultCheckedInRadioButtonForDetailedOrConsolidated()
                'Me.UpdateIsConsolidated(value)
            End If
            Me.AddShowButtonInFilterTable()
        End If
    End Sub
    Public Sub FinishFilter()
        'Me.Controls.Add(Me.FilterTableForDate)

        Me.FilterCell.Controls.Add(FilterTableForDate)
        'Me.Controls.Add(Me.FilterTableForDate)
    End Sub
    Public Sub GetFilterWhereClause()
        Dim value As New Guid(Me.Request.QueryString("AccountReportId"))
        Me.GetFilterWhereClause(value)
    End Sub
    Public Sub AddCasDropDown()
        Dim BLL As New LiveReportData
        Dim value As New Guid(Me.Request.QueryString("AccountReportId"))
        Dim dtSystemReport As ReportFilter.vueAccountReportFilterDataTable = BLL.GetvueAccountReportFilterByAccountReportId(value)
        Dim drSystemReport As ReportFilter.vueAccountReportFilterRow
        If dtSystemReport.Rows.Count > 0 Then
            drSystemReport = dtSystemReport.Rows(0)
            For Each drSystemReport In dtSystemReport.Rows
                If Not IsDBNull(drSystemReport.Item("ParentFilterSource")) Then
                    Me.AddCascadingDropDown(drSystemReport.ParentFilterSource, drSystemReport.SystemReportFilterSource)
                    'Me.LiveReportFilter1.SetProjectTaskData()
                End If
            Next
        End If
    End Sub

    Public Sub AddRow()
        FilterRow = New TableRow
        FilterTable.Rows.Add(FilterRow)
    End Sub
    Public Sub AddCell()
        FilterCell = New TableCell
        ' FilterCell.BorderWidth = 1
    End Sub

    Public Sub AddRowForDate()
        FilterRowForDate = New TableRow
        FilterTableForDate.Rows.Add(FilterRowForDate)
    End Sub
    Public Sub AddCellForDate()
        FilterCellForDate = New TableCell
        ' FilterCellForDate.BorderWidth = 1
    End Sub

    Public Sub AddFilter(ByVal FilterType As String, ByVal FilterName As String, ByVal Caption As String, ByVal IsRequired As Boolean, ByVal IsAllowAll As Boolean, ByVal SystemReportDataSourceId As Guid)
        Me.AddRow()
        If FilterName = "AssignedEmployees" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "AllEmployees" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "AssignedProject" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "AllProject" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "ProjectTask" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "Clients" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "AllDepartments" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "AllLocations" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "Approved" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Approved", "Not Approved"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Approved", "Not Approved"), FilterName)
        ElseIf FilterName = "Submitted" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Submitted", "Not Submitted"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Submitted", "Not Submitted"), FilterName)
        ElseIf FilterName = "Billable" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Billable", "Non-Billable"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Billable", "Non-Billable"), FilterName, SystemReportDataSourceId)
        ElseIf FilterName = "DateRange" Then
            'Me.AddRowForDate()
            AddDateRangeFilter(Caption, FilterName, IsRequired, SystemReportDataSourceId)
        ElseIf FilterName = "Show" Then
            Me.AddButtonFilter(Caption, FilterName, IsRequired)
        ElseIf FilterName = "ExpenseType" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "Expense" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "Role" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "ProjectStatus" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll, True)
        ElseIf FilterName = "ActiveStatus" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Active", "InActive"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Active", "InActive"), FilterName)
        ElseIf FilterName = "Disabled" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Disabled", "Enabled"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Disabled", "Enabled"), FilterName)
        ElseIf FilterName = "BaseCurrency" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll, True)
        ElseIf FilterName = "TaskType" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "ApprovalType" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Rejected", "Approved"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Rejected", "Approved"), FilterName)
        ElseIf FilterName = "Reimbursement" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Reimbursement", "Non Reimbursement"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Reimbursement", "Non Reimbursement"), FilterName)
        ElseIf FilterName = "TaskStatus" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "Priority" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "Paid" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Paid", "UnPaid"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Paid", "UnPaid"), FilterName)
        ElseIf FilterName = "ApprovedBy" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "ProjectType" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "Billed" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Billed", "Not Billed"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Billed", "Not Billed"), FilterName)
        ElseIf FilterName = "TimeOffType" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "TimeOffPolicy" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "TimesheetType" Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Timesheet Records", "Time Off Records"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Timesheet Records", "Time Off Records"), FilterName)
        ElseIf FilterName = "WorkType" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "CostCenter" Then
            Me.AddDropdownFilter(Caption, FilterName, IsRequired, IsAllowAll)
        ElseIf FilterName = "TimesheetPeriodType" And SystemReportDataSourceId <> New Guid("0A0C26BE-01EE-41CD-9503-797D8CE7B834") Then
            AddRadioButtonFilterOf(GetFilterTextName("Both", "Entered Periods", "Missing Periods"), Caption, FilterName, GetSelectedCaptionForRB("Both", "Entered Periods", "Missing Periods"), FilterName)
        End If
    End Sub
    Public Sub AddDropdownFilter(ByVal Caption As String, ByVal FilterName As String, ByVal IsRequired As Boolean, ByVal IsAllowAll As Boolean, Optional ByVal IsSmallWidth As Boolean = False)
        Me.AddCell()
        Me.AddCaption(Caption)

        Me.AddCell()
        Me.AddDropDownList(IsAllowAll, FilterName, IsSmallWidth)
    End Sub
    Public Sub AddStatusCheckFilter(ByVal Caption As String, ByVal FilterName As String, ByVal IsRequired As Boolean, ByVal IsAllowAll As Boolean, ByVal MultiSelect As Boolean, Optional ByVal IsSmallWidth As Boolean = False)
        Me.AddRow()
        Me.AddCell()
        Me.AddCaption(Caption, True, True)

        Me.AddCell()

        Dim chk_Save As New RadioButton
        Dim chk_NotSave As New RadioButton
        Dim chk_Submitted As New RadioButton
        Dim chk_Rejected As New RadioButton

        chk_Save.ID = "Saved"
        chk_Save.Text = "Saved"
        chk_Save.CssClass = "UndoChecked"

        chk_NotSave.ID = "NotSaved"
        chk_NotSave.Text = "Not Saved"
        chk_NotSave.CssClass = "UndoChecked"

        chk_Submitted.ID = "Submitted"
        chk_Submitted.Text = "Submitted"
        chk_Submitted.CssClass = "UndoChecked"

        chk_Rejected.ID = "Rejected"
        chk_Rejected.Text = "Rejected"
        chk_Rejected.CssClass = "UndoChecked"

        Dim ltrdc As New LiteralControl("&nbsp;&nbsp;&nbsp;")
        Dim ltrdc1 As New LiteralControl("&nbsp;&nbsp;&nbsp;")
        Dim ltrdc2 As New LiteralControl("&nbsp;&nbsp;&nbsp;")
        Dim ltrdc3 As New LiteralControl("&nbsp;&nbsp;&nbsp;")

        FilterCell.Controls.Add(ltrdc)
        FilterCell.Controls.Add(chk_Save)
        FilterCell.Controls.Add(ltrdc1)
        FilterCell.Controls.Add(chk_NotSave)
        FilterCell.Controls.Add(ltrdc2)
        FilterCell.Controls.Add(chk_Submitted)
        FilterCell.Controls.Add(ltrdc3)
        FilterCell.Controls.Add(chk_Rejected)
        FilterRow.Cells.Add(FilterCell)
    End Sub

    Public Sub AddListBoxFilter(ByVal Caption As String, ByVal IsAllowAll As Boolean, ByVal FilterName As String, ByVal IsSmallWidth As Boolean)

        Me.AddCell()
        Me.AddCaption(Caption)

        Me.AddCell()

        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        Dim lstBox = New ListBox
        lstBox.ID = FilterName
        lstBox.SelectionMode = ListSelectionMode.Multiple

        If IsAllowAll Then
            AddDropDownItem(Me.GetFromRescource("<All>"), 0, ddl)
        End If

        If FilterName = "DepartmentsListMulti" Then
            Dim departmentsBll As New AccountDepartmentBLL
            Dim departments As TimeLiveDataSet.AccountDepartmentDataTable = departmentsBll.GetAccountDepartments()
            lstBox.Attributes.Add("Rows", departments.Rows.Count.ToString())

            Dim lAll As New ListItem
            lAll.Text = "< All >"
            lAll.Value = 0
            lstBox.Items.Add(lAll)

            For Each item As TimeLiveDataSet.AccountDepartmentRow In departments
                Dim lItem As New ListItem
                lItem.Text = item.DepartmentName
                lItem.Value = item.AccountDepartmentId
                lstBox.Items.Add(lItem)
            Next
        End If

        lstBox.SelectedIndex = 0

        FilterCell.Controls.Add(lstBox)
        Me.AddFilterCellIntoFilterRow()
        If IsSmallWidth Then
            lstBox.Width = DROPDOWN_SMALL_WIDTH
        Else
            lstBox.Width = DROPDOWN_WIDTH
        End If

        lstBox.Height = 80

    End Sub

    Public Sub AddDropDownList(ByVal IsAllowAll As Boolean, ByVal FilterName As String, ByVal IsSmallWidth As Boolean)
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        ddl = New DropDownList
        ddl.ID = FilterName

        If IsAllowAll Then
            AddDropDownItem(Me.GetFromRescource("<All>"), 0, ddl)
        End If

        If FilterName = "Approved" Then
            AddDropDownItem("Both", -1, ddl)
            AddDropDownItem("Approved", 1, ddl)
            AddDropDownItem("Not Approved", 0, ddl)
        ElseIf FilterName = "StatusFilter" Then
            AddDropDownItem("Not Saved", 1, ddl)
            AddDropDownItem("Saved", 2, ddl)
            AddDropDownItem("Submitted", 3, ddl)
            AddDropDownItem("Rejected", 4, ddl)
        ElseIf FilterName = "Submitted" Then
            AddDropDownItem("Both", -1, ddl)
            AddDropDownItem("Sumbitted", 1, ddl)
            AddDropDownItem("Not Submitted", 0, ddl)
        ElseIf FilterName = "Billable" Then
            AddDropDownItem("Both", -1, ddl)
            AddDropDownItem("Billable", 1, ddl)
            AddDropDownItem("UnBillable", 0, ddl)
        ElseIf FilterName = "Disabled" Then
            AddDropDownItem("Both", -1, ddl)
            AddDropDownItem("Disabled", 1, ddl)
            AddDropDownItem("Not Disabled", 0, ddl)
        ElseIf FilterName = "ActiveStatus" Then
            AddDropDownItem("Both", -1, ddl)
            AddDropDownItem("Active", 1, ddl)
            AddDropDownItem("InActive", 0, ddl)
        ElseIf FilterName = "ApprovalType" Then
            AddDropDownItem("Both", -1, ddl)
            AddDropDownItem("Only Rejection", 1, ddl)
            AddDropDownItem("Only Approved", 0, ddl)
        ElseIf FilterName = "AssignedProject" And AccountProjectBLL.IsAllowProjectNONE(AccountReportId) Then
            AddDropDownItem("None", -1, ddl)
        ElseIf FilterName = "DepartmentsListMulti" Then
            Dim departmentsBll As New AccountDepartmentBLL
            Dim departments As TimeLiveDataSet.AccountDepartmentDataTable = departmentsBll.GetAccountDepartmentsByAccountIdAndIsDisabled(DBUtilities.GetCurrentAccountId(), 0)
            For Each item As TimeLiveDataSet.AccountDepartmentRow In departments
                AddDropDownItem(item.DepartmentName, item.AccountDepartmentId, ddl)
            Next
        End If

        If FilterName = "Clients" Then
            ddl.AutoPostBack = True
            AddHandler ddl.SelectedIndexChanged, AddressOf ddlClient_Changed
        End If

        Me.SetDropDownData(FilterName, ddl)
        FilterCell.Controls.Add(ddl)
        Me.AddFilterCellIntoFilterRow()
        If IsSmallWidth Then
            ddl.Width = DROPDOWN_SMALL_WIDTH
        Else
            ddl.Width = DROPDOWN_WIDTH
        End If
    End Sub

    Private Sub ddlClient_Changed(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        If Not CType(Me.FindControl("AssignedProject"), DropDownList) Is Nothing Then
            AccountProjectBLL.SetDataForProjectDropdownForCustomaizeReport(CType(Me.FindControl("AssignedProject"), DropDownList), AccountReportId, CType(Me.FindControl("Clients"), DropDownList).SelectedValue)
        End If
    End Sub
    Public Sub AddDropDownItem(ByVal Text As String, ByVal value As String, ByVal ddl As DropDownList)
        Dim item As New System.Web.UI.WebControls.ListItem
        ddl.AppendDataBoundItems = True
        item.Text = Text
        item.Value = value
        ddl.Items.Add(item)
    End Sub
    Public Sub AddCascadingDropDown(ByVal ParentFilterSource As String, ByVal FilterName As String)
        If ParentFilterSource = "AssignedProject" Then
            Me.AddCascadingDropDownFilter(FilterName)
        End If
    End Sub
    Public Function GetProjectTaskFuctionForCascading() As String
        Return "GetAccountProjectTasksForCustomizedReport"
    End Function
    Public Function GetCategoryForCascading() As String
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        Dim ReportPermission As New ObjectPermissionBLL

        Dim nAccountProjectTaskId As Long
        If CType(Me.FindControl("ProjectTask"), DropDownList).SelectedValue = "" Then
            nAccountProjectTaskId = 0
            CType(Me.FindControl("ProjectTask"), DropDownList).SelectedValue = 0
        Else
            nAccountProjectTaskId = CType(Me.FindControl("ProjectTask"), DropDownList).SelectedValue
        End If
        Return DBUtilities.GetSessionAccountEmployeeId & "," & True & "," & nAccountProjectTaskId & "," & DBUtilities.GetSessionAccountId & "," & AccountReportId.ToString & "," & GetRolesString()
    End Function
    Public Function GetRolesString()
        Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))
        Dim strRoles As String = ""
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & AccountRoles(n)
            If n + 1 <> AccountRoles.Length Then
                strRoles = strRoles + "."
            End If
        Next
        Return strRoles
    End Function
    Public Sub AddCascadingDropDownFilter(ByVal FilterName As String)
        AddRow()
        If FilterName = "ProjectTask" Then
            AddCascadingForSelectedFilter(FilterName, "Loading", CType(Me.FindControl("AssignedProject"), DropDownList), CType(Me.FindControl("ProjectTask"), DropDownList), GetProjectTaskFuctionForCascading, "~/Services/ProjectService.asmx", Me.GetFromRescource("<All>"), GetCategoryForCascading)
        End If
    End Sub
    Public Sub AddCascadingForSelectedFilter(ByVal FilterName As String, ByVal LoadingText As String, ByVal ParentControlId As DropDownList,
    ByVal TargetControlId As DropDownList, ByVal ServiceMethod As String, ByVal ServicePath As String, ByVal PromptText As String, ByVal Category As String)


        Dim ddlCascading As New AjaxControlToolkit.CascadingDropDown
        ddlCascading.Enabled = True
        ddlCascading.ID = FilterName & "CascadingDropdown"
        ddlCascading.LoadingText = LoadingText

        ddlCascading.ParentControlID = ParentControlId.ID
        ddlCascading.TargetControlID = TargetControlId.ID
        ddlCascading.ServiceMethod = ServiceMethod
        ddlCascading.ServicePath = ServicePath
        ddlCascading.PromptText = PromptText
        ddlCascading.Category = Category

        FilterCell.Controls.Add(ddlCascading)
        '        Me.AddFilterCellIntoFilterRow()
    End Sub
    Public Sub AddCheckBoxFilter(ByVal Caption As String, ByVal FilterName As String, ByVal IsRequired As Boolean)
        Me.AddCell()
        Me.AddCaption(Caption)

        Me.AddCell()
        Me.AddCheckBox(FilterName)
    End Sub

    Public Sub AddCheckBox(ByVal FilterName As String, Optional ByVal Caption As String = "", Optional ByVal SkipCellAddInRow As Boolean = False, Optional ByVal AddRowForDate As Boolean = False)

        If Caption <> "" Then
            Me.AddCaption(Caption, False, False, True)
        End If
        If AddRowForDate Then
            Me.AddCellForDate()
        End If

        Dim chk As New CheckBox
        chk.ID = FilterName
        If FilterName IsNot "chk_DisabledFilter" Then
            chk.Checked = True
        Else
            chk.Checked = False
        End If

        If AddRowForDate Then
            FilterCellForDate.Controls.Add(chk)
        Else
            FilterCell.Controls.Add(chk)
        End If

        If SkipCellAddInRow = False Then
            Me.AddFilterCellIntoFilterRow()
        End If
        If AddRowForDate Then
            AddFilterCellIntoFilterRowForDate()
        End If

    End Sub
    Public Sub AddDateFilter(ByVal Caption As String, ByVal FilterName As String, ByVal IsRequired As Boolean)
        Me.AddCell()
        Me.AddCaption(Caption)

        Me.AddCell()
        Me.AddDateTextBox(FilterName)
    End Sub
    Public Sub AddDateTextBox(ByVal FilterName As String)
        Dim CalendarPopup As New eWorld.UI.CalendarPopup
        CalendarPopup.ID = FilterName
        FilterCell.Controls.Add(CalendarPopup)
        Me.AddFilterCellIntoFilterRow()
    End Sub
    Public Sub AddButtonFilter(ByVal Caption As String, ByVal FilterName As String, ByVal IsRequired As Boolean)
        Me.AddCell()
        Me.AddBlankCell()

        Me.AddCell()
        Me.AddButton(FilterName, Caption)
    End Sub
    Public Sub AddButton(ByVal FilterName As String, ByVal Caption As String)
        Dim btn As New Button
        btn.ID = FilterName
        btn.Text = Caption
        FilterCell.Controls.Add(btn)
        Me.AddFilterCellIntoFilterRow()
    End Sub

    Public Sub AddCaption(ByVal caption As String, Optional ByVal AddCellToRow As Boolean = True, Optional ByVal SetRight As Boolean = True, Optional ByVal AddCellToRowForDate As Boolean = False)
        Dim lbl As New Label
        lbl.Text = GetFromRescource(caption)

        If AddCellToRowForDate Then
            FilterCellForDate.Controls.Add(lbl)
        Else
            FilterCell.Controls.Add(lbl)
        End If

        If AddCellToRow = True Then
            Me.AddFilterCellIntoFilterRowForCaption("FormViewLabelCell")
        End If
        If SetRight Then
            FilterCell.HorizontalAlign = HorizontalAlign.Right
        End If
        If AddCellToRowForDate = True Then
            AddFilterCellIntoFilterRowForDateForCaption()
        End If
    End Sub
    Public Sub AddCaptionInCurrentCell(ByVal caption As String)
        Dim lbl As New Label
        lbl.Text = caption
        FilterCell.Controls.Add(lbl)
        Me.AddFilterCellIntoFilterRowForCaption()
    End Sub
    Public Sub AddTextboxFilter(ByVal Caption As String, ByVal FilterName As String, ByVal IsRequired As Boolean)
        Me.AddCell()
        Me.AddCaption(Caption)

        Me.AddCell()
        Me.AddTextbox()
    End Sub
    Public Sub AddTextbox()
        Dim txt As New TextBox
        txt.Text = "test"
        FilterCell.Controls.Add(txt)
        Me.AddFilterCellIntoFilterRow()
    End Sub
    Public Sub AddBlankCell()
        FilterRow.Cells.Add(FilterCell)
    End Sub
    Public Sub AddDateRangeFilter(ByVal Caption As String, ByVal FilterName As String, ByVal IsShowIncludeDateRange As Boolean, Optional ByVal SystemReportId As Guid = Nothing)

        'Me.AddCell()
        'Me.AddCaption(Caption)
        'Me.AddCell()
        'Me.AddCellForDate()

        If IsShowIncludeDateRange Then
            Me.AddRow()
            AddCheckBoxFilter("Include Date Range:", "IncludeDateRange", False)
            'Me.AddCheckBox("IncludeDateRange", "Include Date Range:", True, True)
            'AddLiteral("</br>", True)
        End If
        Me.AddRow()
        AddCalendarPopupFilter("Start Date:", "StartDate", SystemReportId)
        Me.AddRow()
        AddCalendarPopupFilter("End Date:", "EndDate", SystemReportId)
        'Me.AddFilterCellIntoFilterRow()
        'Me.FinishFilter()
    End Sub
    Public Sub AddCalendarPopupFilter(ByVal Caption As String, ByVal FilterName As String, Optional ByVal SystemReportId As Guid = Nothing)
        Me.AddCell()
        Me.AddCaption(Caption)

        Me.AddCell()
        Me.AddCalendarPopup(FilterName, SystemReportId)
    End Sub
    Public Sub AddLiteral(ByVal LiteralValue As String, Optional ByVal AddRowForDate As Boolean = False)
        'AddCellForDate()
        Dim objLiterControl As New LiteralControl
        objLiterControl.Text = LiteralValue
        If AddRowForDate Then
            FilterCellForDate.Controls.Add(objLiterControl)
            'AddFilterCellIntoFilterRowForDate()
        Else
            FilterCell.Controls.Add(objLiterControl)
        End If
    End Sub
    Public Sub AddCalendarPopup(ByVal FilterName As String, Optional ByVal SystemReportId As Guid = Nothing)
        Dim CalendarPopup As New eWorld.UI.CalendarPopup
        CalendarPopup.ID = FilterName
        CalendarPopup.SkinID = "DatePicker"
        'CalendarPopup.Culture = LocaleUtilitiesBLL.GetCurrentCultureInfo
        CalendarPopup.Width = 150%



        If SystemReportId = New Guid("3a080202-6842-4eca-8c79-a945978810b4") Then

            Dim ListOfCalculatedDates As List(Of Date) = GetFirstAndLastDayOfMonth()

            Dim FirstDayOfLastMonth As Date = ListOfCalculatedDates(0)
            Dim LastDayOfLastMonth As Date = ListOfCalculatedDates(1)

            If FilterName = "StartDate" Then
                CalendarPopup.SelectedDate = FirstDayOfLastMonth
            ElseIf FilterName = "EndDate" Then
                CalendarPopup.SelectedDate = LastDayOfLastMonth
            End If

        End If
        FilterCell.Controls.Add(CalendarPopup)
        Me.AddFilterCellIntoFilterRow()
    End Sub
    Public Sub AddStartEndDateAndIncludeDateRangeFilter(ByVal caption As String, ByVal FilterName As String, ByVal FilterType As String)
        Me.AddCell()
        Me.AddCaption(caption)
        If FilterType = "Date" Then
            ' Me.AddCell()
            Dim CalendarPopup As New eWorld.UI.CalendarPopup
            CalendarPopup.ID = FilterName
            FilterCell.Controls.Add(CalendarPopup)
            Me.AddFilterCellIntoFilterRow()
        ElseIf FilterType = "CheckBox" Then
            ' Me.AddCell()
            Dim chk As New CheckBox
            chk.ID = FilterName
            chk.Checked = True
            FilterCell.Controls.Add(chk)
            Me.AddFilterCellIntoFilterRow()
        End If
    End Sub
    Public Sub AddFilterCellIntoFilterRow(Optional ByVal SpecificWidth As String = "70%")
        'FilterCell.Width = 600%
        FilterRow.Cells.Add(FilterCell)
        FilterCell.Attributes.Add("Width", SpecificWidth)
        'FilterTable.BorderWidth = 2
        'FilterTable.BorderStyle = BorderStyle.Solid
        'FilterRow.BorderStyle = BorderStyle.Solid
        'FilterCell.BorderStyle = BorderStyle.Solid
    End Sub
    Public Sub AddFilterCellIntoFilterRowForDate()
        FilterRowForDate.Cells.Add(FilterCellForDate)
        FilterCellForDate.Attributes.Add("Width", "75%")
    End Sub
    Public Sub AddFilterCellIntoFilterRowForDateForCaption()
        FilterRowForDate.Cells.Add(FilterCellForDate)
        FilterCellForDate.Attributes.Add("Width", "25%")
        FilterCellForDate.CssClass = "FormViewLabelCellBold"
    End Sub
    Public Sub AddFilterCellIntoFilterRowForCaption(Optional ByVal CSSClass As String = "")
        FilterCell.Attributes.Add("Width", "30%")
        If CSSClass <> "" Then
            FilterCell.CssClass = CSSClass
        End If
        FilterRow.Cells.Add(FilterCell)

        'FilterTable.BorderWidth = 2
        'FilterTable.BorderStyle = BorderStyle.Solid
        'FilterRow.BorderStyle = BorderStyle.Solid
        'FilterCell.BorderStyle = BorderStyle.Solid
    End Sub
    Public Sub SetDropDownData(ByVal FilterName As String, ByVal ddl As DropDownList)
        'If FilterName = "AssignedEmployees" Then
        '    Me.SetAssignEmployeeData(ddl)
        If FilterName = "AllEmployees" Then
            Me.SetAllEmployeeData(ddl)
            'ElseIf FilterName = "AssignedProject" Then
            '    Me.SetAssignProjects(ddl)
        ElseIf FilterName = "AllProject" Then
            Me.SetAllProjects(ddl)
        ElseIf FilterName = "AllDepartments" Then
            Me.SetDepartmentData(ddl)
        ElseIf FilterName = "AllLocations" Then
            Me.SetLocationData(ddl)
        ElseIf FilterName = "Expense" Then
            Me.SetExpenseData(ddl)
        ElseIf FilterName = "ExpenseType" Then
            Me.SetExpenseTypeData(ddl)
        ElseIf FilterName = "Role" Then
            Me.SetRoleData(ddl)
        ElseIf FilterName = "ProjectStatus" Then
            Me.SetProjectStatusData(ddl)
        ElseIf FilterName = "BaseCurrency" Then
            Me.SetCurrencyData(ddl)
        ElseIf FilterName = "TaskType" Then
            Me.SetTaskTypeData(ddl)
        ElseIf FilterName = "TaskStatus" Then
            Me.SetTaskStatusData(ddl)
        ElseIf FilterName = "Priority" Then
            Me.SetPriorityData(ddl)
        ElseIf FilterName = "ProjectType" Then
            Me.SetProjectTypeData(ddl)
        ElseIf FilterName = "TimeOffType" Then
            Me.SetTimeOffTypeData(ddl)
        ElseIf FilterName = "TimeOffPolicy" Then
            Me.SetTimeOffPolicyData(ddl)
        ElseIf FilterName = "WorkType" Then
            Me.SetWorkTypeData(ddl)
        ElseIf FilterName = "CostCenter" Then
            Me.SetCostCenterData(ddl)
        End If
    End Sub
    Public Sub SetAssignEmployeeData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAssignedEmployee.DefaultView
        objDataView.Sort = "EmployeeNameWithCode"
        ddl.DataTextField = "EmployeeNameWithCode"
        ddl.DataValueField = "AccountEmployeeId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetAllEmployeeData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllEmployees.DefaultView
        objDataView.Sort = "EmployeeNameWithCode"
        ddl.DataTextField = "EmployeeNameWithCode"
        ddl.DataValueField = "AccountEmployeeId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetDepartmentData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllDepartments.DefaultView
        objDataView.Sort = "DepartmentName"
        ddl.DataTextField = "DepartmentName"
        ddl.DataValueField = "AccountDepartmentId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetLocationData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllLocation.DefaultView
        objDataView.Sort = "AccountLocation"
        ddl.DataTextField = "AccountLocation"
        ddl.DataValueField = "AccountLocationId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetAssignProjects(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAssignProjects.DefaultView
        objDataView.Sort = "ProjectName"
        ddl.DataTextField = "ProjectName"
        ddl.DataValueField = "AccountProjectId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetAllProjects(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllProjects.DefaultView
        objDataView.Sort = "ProjectName"
        ddl.DataTextField = "ProjectName"
        ddl.DataValueField = "AccountProjectId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetClientData(ByVal ddl As DropDownList, ByVal AccountReportId As Guid)
        AccountPartyBLL.SetDataForProjectDropdownForCustomaizeReport(ddl, AccountReportId)
    End Sub
    Public Sub SetExpenseData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllExpense.DefaultView
        objDataView.Sort = "AccountExpenseName"
        ddl.DataTextField = "AccountExpenseName"
        ddl.DataValueField = "AccountExpenseId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetExpenseTypeData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllExpenseType.DefaultView
        objDataView.Sort = "ExpenseType"
        ddl.DataTextField = "ExpenseType"
        ddl.DataValueField = "AccountExpenseTypeId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetRoleData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllRoles.DefaultView
        objDataView.Sort = "Role"
        ddl.DataTextField = "Role"
        ddl.DataValueField = "AccountRoleId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetProjectStatusData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllProjectStatus.DefaultView
        objDataView.Sort = "Status"
        ddl.DataTextField = "Status"
        ddl.DataValueField = "AccountStatusId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetCurrencyData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllCurrencies.DefaultView
        objDataView.Sort = "CurrencyCode"
        ddl.DataTextField = "CurrencyCode"
        ddl.DataValueField = "AccountCurrencyId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetTaskTypeData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllTaskType.DefaultView
        objDataView.Sort = "TaskType"
        ddl.DataTextField = "TaskType"
        ddl.DataValueField = "AccountTaskTypeId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetPriorityData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllPriority.DefaultView
        objDataView.Sort = "Priority"
        ddl.DataTextField = "Priority"
        ddl.DataValueField = "AccountPriorityId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetTaskStatusData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllTaskStatus.DefaultView
        objDataView.Sort = "Status"
        ddl.DataTextField = "Status"
        ddl.DataValueField = "AccountStatusId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetProjectTaskData()
        Dim ddl As New DropDownList, ddlProject As New DropDownList
        ddl = CType(Me.FindControl("ProjectTask"), DropDownList)
        ddlProject = CType(Me.FindControl("AssignedProject"), DropDownList)
        Dim objDataView As New DataView()
        Dim BLL As New ReportFilterCascadingBLL
        objDataView = BLL.GetAccountProjectTasksByAccountProjectIdCascading(ddlProject.SelectedValue).DefaultView
        objDataView.Sort = "TaskName"
        ddl.DataTextField = "TaskName"
        ddl.DataValueField = "AccountProjectTaskId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetProjectTypeData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllProjectTypes.DefaultView
        objDataView.Sort = "ProjectType"
        ddl.DataTextField = "ProjectType"
        ddl.DataValueField = "AccountProjectTypeId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetTimeOffTypeData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllTimeOffTypes.DefaultView
        objDataView.Sort = "AccountTimeOffType"
        ddl.DataTextField = "AccountTimeOffType"
        ddl.DataValueField = "AccountTimeOffTypeId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetTimeOffPolicyData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllTimeOffPolicy.DefaultView
        objDataView.Sort = "AccountTimeOffPolicy"
        ddl.DataTextField = "AccountTimeOffPolicy"
        ddl.DataValueField = "AccountTimeOffPolicyId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetWorkTypeData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllWorkType.DefaultView
        objDataView.Sort = "AccountWorkType"
        ddl.DataTextField = "AccountWorkType"
        ddl.DataValueField = "AccountWorkTypeId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Sub SetCostCenterData(ByVal ddl As DropDownList)
        Dim objDataView As New DataView()
        objDataView = ReportFilterBLL.GetAllCostCenter.DefaultView
        objDataView.Sort = "AccountCostCenter"
        ddl.DataTextField = "AccountCostCenter"
        ddl.DataValueField = "AccountCostCenterId"
        ddl.DataSource = objDataView
        ddl.DataBind()
    End Sub
    Public Function GetFilterWhereClause(ByVal AccountReportId As Guid) As String
        Dim LiveReportFilterHandlerBLL As New LiveReportFilterHandlerBLL
        Return LiveReportFilterHandlerBLL.HandlerFilter(Me, AccountReportId)
    End Function
    Protected Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        Dim strWhereClause As String = Me.GetFilterWhereClause(AccountReportId)
        Dim strMissingPeriodReportWhereClause As String = Me.GetFilterWhereClauseForTimeEntryMissingReport(AccountReportId)
        Dim strMissingPeriodReportStartAndEndDate As Hashtable = Me.GetFilterStartAndEndDateForTimeEntryMissingReport(AccountReportId)
        Dim strTimesheetPeriodType As String = Me.GetFilterTimesheetPeriodType(AccountReportId)
        Dim BaseCurrencyId As Integer
        If Not Me.FindControl("BaseCurrency") Is Nothing Then
            BaseCurrencyId = CType(Me.FindControl("BaseCurrency"), DropDownList).SelectedValue
            Me.ViewState.Add("BaseCurrencyId", BaseCurrencyId)
        End If
        Me.UpdateIsConsolidated(AccountReportId)

        Dim lstBox As New ListBox
        Dim hdnField As New HiddenField

        If Me.FindControl("DepartmentsListMulti") IsNot Nothing Then
            lstBox = Me.FindControl("DepartmentsListMulti")
        End If
        If Me.FindControl("hdnFieldValues") IsNot Nothing Then
            hdnField = Me.FindControl("hdnFieldValues")
        End If

        If lstBox IsNot Nothing Then
            Dim stringconcat As String = ""
            For Each item As ListItem In lstBox.Items
                If item.Selected = True Then
                    If item.Value = 0 Then
                        stringconcat = ""
                        Exit For
                    End If
                    stringconcat = stringconcat + item.Value + ","
                End If
            Next
            If stringconcat.Length > 0 Then
                stringconcat = stringconcat.Trim().Substring(0, stringconcat.Length - 1)
            End If
            hdnField.Value = stringconcat
        End If

        RaiseEvent ShowClicked(strWhereClause, Consolidated, BaseCurrencyId, strMissingPeriodReportWhereClause, strMissingPeriodReportStartAndEndDate, strTimesheetPeriodType)
    End Sub
    Public Sub AddFilterTableHeader(ByVal Header As String)

        FilterRow = New TableRow
        FilterCell = New TableHeaderCell
        FilterCell.CssClass = "caption"
        'Me.AddCell()
        FilterCell.ColumnSpan = 2 ' FilterTable.Rows.Count - 1
        AddFilterCellIntoFilterRowForCaption()
        FilterCell.Text = Me.GetFromRescource(Header)
        FilterCell.Font.Bold = True
        Me.FilterRow.Cells.Add(FilterCell)
        FilterTable.Rows.Add(FilterRow)
    End Sub
    Public Sub AddFilterTableSubHeader()
        FilterRow = New TableRow
        FilterCell = New TableHeaderCell
        FilterCell.CssClass = "FormViewSubHeader"
        Dim lblSubHeader As New Label
        FilterCell.ColumnSpan = 2 'FilterTable.Rows.Count - 1
        'AddFilterCellIntoFilterRow()
        lblSubHeader.Text = Me.GetFromRescource("Search Parameters")
        Me.FilterCell.Controls.Add(lblSubHeader)

        Me.FilterRow.Cells.Add(FilterCell)
        FilterTable.Rows.Add(FilterRow)
    End Sub
    Public Sub AddShowButtonInFilterTable()
        Dim ShowButton As Button = CType(Me.FindControl("btnshow"), Button)
        ShowButton.Text = Me.GetFromRescource("Show_text")
        Me.AddRow()
        Me.AddCell()
        '        Me.AddLiteral("test222")
        AddFilterCellIntoFilterRow("30%")
        ' AddFilterCellIntoFilterRowForCaption()
        Me.AddCell()
        '        Me.AddLiteral("test222")
        '       Me.AddLiteral("test222")
        FilterCell.Controls.Add(ShowButton)
        AddFilterCellIntoFilterRow("70%")
    End Sub
    Public Sub AddReportTypeFilter()
        Me.AddRow()
        Me.AddCell()
        Me.AddCaption("Report Type:", True, True)
        '        FilterRow.Cells.Add(FilterCell)

        Me.AddCell()


        Dim rd As New RadioButton
        Dim rd1 As New RadioButton

        rd.ID = "rdDetailed"
        rd.Text = Me.GetFromRescource("Detailed")
        rd.GroupName = "Detailed"
        rd1.ID = "rdConsolidated"
        rd1.Text = Me.GetFromRescource("Consolidated")
        rd1.GroupName = "Detailed"

        FilterCell.Controls.Add(rd)
        Dim ltrdc As New LiteralControl("&nbsp;&nbsp;&nbsp;")
        FilterCell.Controls.Add(ltrdc)
        FilterCell.Controls.Add(rd1)
        FilterRow.Cells.Add(FilterCell)

    End Sub

    Public Sub AddReportTypeFilterDate()

        Me.AddRow()
        Me.AddCell()
        Me.AddCaption("Date:", True, True)

        Me.AddCell()


        Dim rd_expenseEntry As New RadioButton
        Dim rd_expenseSheet As New RadioButton

        rd_expenseEntry.ID = "rd_expenseEntry"
        rd_expenseEntry.Text = "Expense Entry"
        rd_expenseEntry.Checked = True
        rd_expenseEntry.GroupName = "Date"
        rd_expenseSheet.ID = "rd_expenseSheet"
        rd_expenseSheet.Text = "Expense Sheet"
        rd_expenseSheet.GroupName = "Date"

        FilterCell.Controls.Add(rd_expenseEntry)
        Dim ltrdc2 As New LiteralControl("&nbsp;&nbsp;&nbsp;")
        FilterCell.Controls.Add(ltrdc2)
        FilterCell.Controls.Add(rd_expenseSheet)
        FilterRow.Cells.Add(FilterCell)

    End Sub
    Public Sub SetDefaultCheckedInRadioButtonForDetailedOrConsolidated()
        Dim bll As New TimeLive.WebReport.ReportDesignBLL
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        Dim dt As dsReportDesign.vueAccountReportDataTable = bll.GetvueAccountReportByAccountReportId(AccountReportId)
        Dim dr As dsReportDesign.vueAccountReportRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If IsDBNull(dr.Item("IsConsolidated")) Then
                If Not CType(Me.FindControl("rdDetailed"), RadioButton) Is Nothing Then
                    CType(Me.FindControl("rdDetailed"), RadioButton).Checked = True
                End If
            Else
                If dr.Item("IsConsolidated") = True Then
                    If Not CType(Me.FindControl("rdConsolidated"), RadioButton) Is Nothing Then
                        CType(Me.FindControl("rdConsolidated"), RadioButton).Checked = True
                    End If
                ElseIf dr.Item("IsConsolidated") = False Then
                    If Not CType(Me.FindControl("rdDetailed"), RadioButton) Is Nothing Then
                        CType(Me.FindControl("rdDetailed"), RadioButton).Checked = True
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub UpdateIsConsolidated(ByVal AccountReportId As Guid)
        Dim IsConsolidated As Boolean
        If Not CType(Me.FindControl("rdDetailed"), RadioButton) Is Nothing Then
            If CType(Me.FindControl("rdDetailed"), RadioButton).Checked = True Then
                IsConsolidated = False
            End If
        End If
        If Not CType(Me.FindControl("rdConsolidated"), RadioButton) Is Nothing Then
            If CType(Me.FindControl("rdConsolidated"), RadioButton).Checked = True Then
                IsConsolidated = True
            End If
        End If
        Dim bll As New TimeLive.WebReport.ReportDesignBLL
        bll.UpdateIsConsolidatedInAccountReport(AccountReportId, IsConsolidated)
        Consolidated = IsConsolidated
    End Sub

    Public Sub SetPermissionForDropDown()
        Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        If Not CType(Me.FindControl("AssignedEmployees"), DropDownList) Is Nothing Then
            AccountEmployeeBLL.SetDataForEmployeeDropdownForCustomaizeReport(CType(Me.FindControl("AssignedEmployees"), DropDownList), AccountReportId)
        End If
        If Not CType(Me.FindControl("AssignedProject"), DropDownList) Is Nothing And Not CType(Me.FindControl("Clients"), DropDownList) Is Nothing Then
            AccountProjectBLL.SetDataForProjectDropdownForCustomaizeReport(CType(Me.FindControl("AssignedProject"), DropDownList), AccountReportId, CType(Me.FindControl("Clients"), DropDownList).SelectedValue)
        End If
        If Not CType(Me.FindControl("AssignedProject"), DropDownList) Is Nothing Then
            AccountProjectBLL.SetDataForProjectDropdownForCustomaizeReport(CType(Me.FindControl("AssignedProject"), DropDownList), AccountReportId, 0)
        End If
        If Not CType(Me.FindControl("Clients"), DropDownList) Is Nothing Then
            Me.SetClientData(CType(Me.FindControl("Clients"), DropDownList), AccountReportId)
        End If
        If Not CType(Me.FindControl("ApprovedBy"), DropDownList) Is Nothing Then
            If LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "ad0ea79d-c1d7-40ed-a7c4-03cc4f565873" Then
                Me.SetDataInApprovedByDropDownForTimeSheet(CType(Me.FindControl("ApprovedBy"), DropDownList), AccountReportId)
            ElseIf LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "e3803dc0-49fd-4fc8-b414-ea264ffe85aa" Then
                Me.SetDataInApprovedByDropDownForExpense(CType(Me.FindControl("ApprovedBy"), DropDownList), AccountReportId)
            End If
        End If
    End Sub
    Public Sub AddRadioButtonFilterOf(ByVal column As String(), ByVal Caption As String, ByVal FilterName As String, ByVal SelectedCaption As String(), ByVal GroupName As String, Optional ByVal SystemReportId As Guid = Nothing)
        Me.AddCell()
        Me.AddCaption(Caption)

        Me.AddCell()
        Me.AddRadioButtonFilter(column, FilterName, SelectedCaption, GroupName, SystemReportId)
    End Sub
    Public Sub AddRadioButtonFilter(ByVal Column As String(), ByVal FilterName As String, ByVal SelectedCaption As String(), ByVal GroupName As String, Optional ByVal SystemReportId As Guid = Nothing)
        For i As Integer = 0 To Column.Length - 1
            Dim rd As New RadioButton
            rd.ID = FilterName & Column(i)
            rd.Text = Me.GetFromRescource(SelectedCaption(i))
            rd.GroupName = GroupName

            If Not SystemReportId = New Guid("3a080202-6842-4eca-8c79-a945978810b4") Then

                If Column(i) = "Both" Then
                    rd.Checked = True
                ElseIf Column(i) = "Enabled" And FilterName = "Disabled" Then
                    rd.Checked = True
                End If

            Else
                If Column(i) = "Both" Then
                    rd.Checked = True
                End If

            End If

            FilterCell.Controls.Add(rd)
            Dim ltr As New LiteralControl("&nbsp;&nbsp;&nbsp;")
            FilterCell.Controls.Add(ltr)
        Next
        Me.AddFilterCellIntoFilterRow()
    End Sub
    Public Function GetFilterTextName(ByVal Text1 As String, ByVal Text2 As String, ByVal Text3 As String)
        Dim column(2) As String
        column(0) = Text1
        column(1) = Text2
        column(2) = Text3
        Return column
    End Function
    Public Function GetSelectedCaptionForRB(ByVal Text1 As String, ByVal Text2 As String, ByVal Text3 As String)
        Dim selectedcaption(2) As String
        selectedcaption(0) = Text1
        selectedcaption(1) = Text2
        selectedcaption(2) = Text3
        Return selectedcaption
    End Function
    Public Function GetFromRescource(ByVal Caption As String) As String
        Return ResourceHelper.GetFromResource(Caption)
    End Function
    Public Sub SetDataInApprovedByDropDownForTimeSheet(ByVal DropDownName As DropDownList, ByVal AccountReportId As Guid)
        Dim ReportPermission As New ObjectPermissionBLL
        Dim objDataView As New DataView()
        Dim ReportFiler As New ReportFilterBLL
        Dim objemployeebll As New AccountEmployeeBLL
        Dim dtEmployee As New AccountEmployee.vueAccountEmployeeDataTable

        If ReportPermission.IsReportHasPermissionOfAllowOwnApproval(AccountReportId, True) Then
            dtEmployee = objemployeebll.GetViewAccountEmployeesByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
            objDataView = dtEmployee.DefaultView
            DropDownName.DataValueField = "AccountEmployeeId"
            objDataView.Sort = "EmployeeName"
            DropDownName.DataTextField = "EmployeeName"
            DropDownName.DataSource = objDataView
            DropDownName.DataBind()
        Else
            objemployeebll.SetApprovedByDropDownPermission(DropDownName, AccountReportId)
        End If
    End Sub
    Public Sub SetDataInApprovedByDropDownForExpense(ByVal DropDownName As DropDownList, ByVal AccountReportId As Guid)
        Dim ReportPermission As New ObjectPermissionBLL
        Dim objDataView As New DataView()
        Dim ReportFiler As New ReportFilterBLL
        Dim objemployeebll As New AccountEmployeeBLL
        Dim dtEmployee As New AccountEmployee.vueAccountEmployeeDataTable

        If ReportPermission.IsReportHasPermissionOfAllowOwnApproval(AccountReportId, True) Then
            dtEmployee = objemployeebll.GetViewAccountEmployeesByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
            objDataView = dtEmployee.DefaultView
            DropDownName.DataValueField = "AccountEmployeeId"
            objDataView.Sort = "EmployeeName"
            DropDownName.DataTextField = "EmployeeName"
            DropDownName.DataSource = objDataView
            DropDownName.DataBind()
        Else
            objemployeebll.SetApprovedByDropDownPermission(DropDownName, AccountReportId)
        End If
    End Sub
    Public Function GetFilterWhereClauseForTimeEntryMissingReport(ByVal AccountReportId As Guid) As String
        Dim LiveReportFilterHandlerBLL As New LiveReportFilterHandlerBLL
        Return LiveReportFilterHandlerBLL.GetFilterForTimeEntryMissingReport(Me, AccountReportId)
    End Function
    Public Function GetFilterStartAndEndDateForTimeEntryMissingReport(ByVal AccountReportId As Guid) As Hashtable
        Dim LiveReportFilterHandlerBLL As New LiveReportFilterHandlerBLL
        Return LiveReportFilterHandlerBLL.GetStartAndEndDateForTimeEntryMissingReport(Me, AccountReportId)
    End Function
    Public Function GetFilterTimesheetPeriodType(ByVal AccountReportId As Guid) As String
        Dim LiveReportFilterHandlerBLL As New LiveReportFilterHandlerBLL
        Return LiveReportFilterHandlerBLL.GetFilterValueOfTimesheetPeriodType(Me, AccountReportId)
    End Function

    Private Function GetFirstAndLastDayOfMonth() As List(Of Date)

        Dim MyDate As Date = Now

        Dim FirstDayInPreviousMonthDate As Date
        Dim LastDayInPreviousMonthDate As Date

        Dim DaysInPreviousMonth = Nothing

        If MyDate.Month <> 1 Then
            DaysInPreviousMonth = Date.DaysInMonth(MyDate.Year, MyDate.Month - 1)
        Else
            DaysInPreviousMonth = Date.DaysInMonth(MyDate.Year - 1, 12)
        End If

        If MyDate.Month <> 1 Then
            LastDayInPreviousMonthDate = New Date(MyDate.Year, MyDate.Month - 1, DaysInPreviousMonth)
            FirstDayInPreviousMonthDate = New Date(MyDate.Year, MyDate.Month - 1, 1)
        Else
            LastDayInPreviousMonthDate = New Date(MyDate.Year - 1, 12, DaysInPreviousMonth)
            FirstDayInPreviousMonthDate = New Date(MyDate.Year - 1, 12, 1)
        End If



        Dim ListOFItems As New List(Of Date)

        ListOFItems.Add(FirstDayInPreviousMonthDate)
        ListOFItems.Add(LastDayInPreviousMonthDate)

        Return ListOFItems

    End Function
End Class