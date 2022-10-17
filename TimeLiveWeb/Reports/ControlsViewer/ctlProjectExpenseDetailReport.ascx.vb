
Partial Class Reports_ControlsViewer_ctlProjectExpenseDetailReport
    Inherits System.Web.UI.UserControl

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        Me.ShowReportFromFilter()

    End Sub
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal AccountLocationId As Integer, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As Date, ByVal AccountExpenseEntryEndDate As Date, ByVal Submitted As String, ByVal Approval As String, ByVal Billable As String)


        'Dim m As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
        ' m = New AccountExpenseEntryBLL().GetDataForProjectExpenseDetailReport(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountClientId, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval, Billable)

        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()

        'Dim BLL As New AccountBLL
        'Dim dtPreference As AccountPreferences.AccountPreferencesDataTable = _
        '                    BLL.GetPreferencesByAccountId(DBUtilities.GetSessionAccountId)
        'Dim drPreference As AccountPreferences.AccountPreferencesRow

        'Dim BaseCurrencyId As Integer

        'If dtPreference.Rows.Count > 0 Then
        '    drPreference = dtPreference.Rows(0)
        '    BaseCurrencyId = drPreference.AccountBaseCurrencyId
        'End If

        'If Not Me.IsPostBack Then
        '    Me.ddlAccountCurrencyId.SelectedValue = BaseCurrencyId
        'End If

        'Dim dt As AccountCurrency.vueAccountCurrencyDataTable = _
        'New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(IIf(Me.ddlAccountCurrencyId.SelectedValue <> "", _
        'Me.ddlAccountCurrencyId.SelectedValue, BaseCurrencyId))

        'Dim dr As AccountCurrency.vueAccountCurrencyRow

        'If dt.Rows.Count > 0 Then
        '    dr = dt.Rows(0)
        '    C1WebReport1.Report.Sections.Detail.Fields("ExchangeRateCtl").Text = dr.ExchangeRate
        '    C1WebReport1.Report.Sections("EmployeeName_Footer").Fields("CurrencyCodeCtl2").Text = dr.CurrencyCode
        '    C1WebReport1.Report.Sections.Footer.Fields("CurrencyCodeCtl3").Text = dr.CurrencyCode
        'End If

        'Me.C1WebReport1.DataBind()

        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrProjectExpenseDetailReport

        Dim ds As New dsProjectExpenseDetailReport.vueAccountExpenseEntryDataTable
        Dim adap As New dsProjectExpenseDetailReportTableAdapters.vueAccountExpenseEntryTableAdapter
        ds = adap.GetDataForProjectExpenseDetailReport(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountClientId, AccountLocationId, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Submitted, Approval, Billable)

        Dim BLL As New AccountBLL
        Dim dtPreference As AccountPreferences.AccountPreferencesDataTable = BLL.GetPreferencesByAccountId(DBUtilities.GetSessionAccountId)
        Dim drPreference As AccountPreferences.AccountPreferencesRow

        Dim BaseCurrencyId As Integer
        If dtPreference.Rows.Count > 0 Then
            drPreference = dtPreference.Rows(0)
            BaseCurrencyId = drPreference.AccountBaseCurrencyId
        End If

        If Not Me.IsPostBack Then
            Me.ddlAccountCurrencyId.SelectedValue = BaseCurrencyId
        End If

        Dim dt As AccountCurrency.vueAccountCurrencyDataTable = New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(IIf(Me.ddlAccountCurrencyId.SelectedValue <> "", Me.ddlAccountCurrencyId.SelectedValue, BaseCurrencyId))
        Dim dr As AccountCurrency.vueAccountCurrencyRow

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Report.Bands.Item("Detail").Controls("lblExchangeRate").Text = dr.ExchangeRate
            Report.Bands.Item("Detail").Controls("lblDetailCurrency").Text = dr.CurrencyCode
            Report.Bands.Item("GroupFooter1").Controls("lblGroupCurrency").Text = dr.CurrencyCode
            Report.Bands.Item("ReportFooter").Controls("lblGrandCurrency").Text = dr.CurrencyCode
            '            Report.Bands.Item("Detail").Controls("lblCurrencyCode").Text = dr.CurrencyCode
            ' Report.Bands.Item("GroupHeader1").Controls("xrLabel14").Text = "Amount  " & "(" & dr.CurrencyCode & ")"

        End If

        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()


    End Sub
    Public Sub ShowReportFromFilter()
        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, ddlProjects.SelectedValue, ddlClients.SelectedValue, ddlLocation.SelectedValue, chkIncludeDateRange.Checked, StartDate.SelectedDate, EndDate.SelectedDate, ddlSubmitted.SelectedValue, ddlApproved.SelectedValue, ddlBillable.SelectedValue)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(115, Me.ddlEmployees)
            AccountProjectBLL.SetDataForProjectDropdown(115, Me.ddlProjects)
            ReportUtilities.SetDefaultValuesOfFilerItem(Me.ddlEmployees, Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)
            Me.ShowReportFromFilter()
        Else
            Me.ShowReportFromFilter()
        End If
    End Sub
End Class
