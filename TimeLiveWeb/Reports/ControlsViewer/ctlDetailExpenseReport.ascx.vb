Imports dsDetailExpenseReportTableAdapters
Partial Class Reports_ControlsViewer_ctlDetailExpenseReport
    Inherits System.Web.UI.UserControl
    Dim SumTotalAmount As Double = 0
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountClientId As Long, ByVal AccountLocationId As Integer, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As Date, ByVal AccountExpenseEntryEndDate As Date, ByVal Approval As String, ByVal Billable As String, ByVal Submitted As String)
        ''Dim docReport As New C1.Web.C1WebReport.C1WebReport
        ''docReport.ReportSource.FileName = (Server.MapPath("ReportFiles\rptDepartmentListReport.xml"))
        'Dim m As TimeLiveDataSet.vueAccountExpenseEntryForDetailExpenseReportDataTable
        '        m = New AccountExpenseEntryBLL().GetDataForDetailExpenseReport(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountClientId, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Approval, Billable)
        ''Dim dv As New DataView(m)

        'Me.C1WebReport1.Report.DataSource.Recordset = m
        'C1WebReport1.Report.Tag = DateTime.Now.ToString()


        'Dim BLL As New AccountBLL
        'Dim dtPreference As AccountPreferences.AccountPreferencesDataTable = BLL.GetPreferencesByAccountId(DBUtilities.GetSessionAccountId)
        'Dim drPreference As AccountPreferences.AccountPreferencesRow

        'Dim BaseCurrencyId As Integer
        'If dtPreference.Rows.Count > 0 Then
        '    drPreference = dtPreference.Rows(0)
        '    BaseCurrencyId = drPreference.AccountBaseCurrencyId
        'End If
        'If Not Me.IsPostBack Then
        '    Me.ddlAccountCurrencyId.SelectedValue = BaseCurrencyId
        'End If
        'Dim dt As AccountCurrency.vueAccountCurrencyDataTable = New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(IIf(Me.ddlAccountCurrencyId.SelectedValue <> "", Me.ddlAccountCurrencyId.SelectedValue, BaseCurrencyId))
        'Dim dr As AccountCurrency.vueAccountCurrencyRow

        'If dt.Rows.Count > 0 Then
        '    dr = dt.Rows(0)
        '    C1WebReport1.Report.Sections.Detail.Fields("ExchangeRateCtl").Text = dr.ExchangeRate
        '    C1WebReport1.Report.Sections.Detail.Fields("CurrencyCodeCtl").Text = dr.CurrencyCode
        'End If

        'Me.C1WebReport1.DataBind()

        Dim Report As New xtrDetailExpenseReport

        ''        Dim ds As New dsDetailTimeSheetReport.vueAccountEmployeeTimeEntryDataTable
        '        Dim ds As New dsDetailTimeSheetReportForXtrReport.vueAccountEmployeeTimeEntryDataTable
        '        Dim adap As New dsDetailTimeSheetReportForXtrReportTableAdapters.vueAccountEmployeeTimeEntryAdapter ' .vueAccountEmployeeTimeEntryAdapter
        '        ds = adap.GetDataByAccountIdAndEmployees(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountProjectTaskId, AccountPartyId, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate, Approval, Billable)
        Dim ds As New dsDetailExpenseReport.vueAccountExpenseEntryDataTable
        Dim adap As New dsDetailExpenseReportTableAdapters.vueAccountExpenseEntryAdapter
        ds = adap.GetDataByAccountIdAndEmployees(AccountId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountClientId, AccountLocationId, IncludeDateRange, AccountExpenseEntryStartDate, AccountExpenseEntryEndDate, Submitted, Approval, Billable)

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
            Report.Bands.Item("Detail").Controls("xrLabel22").Text = dr.ExchangeRate
            Report.Bands.Item("Detail").Controls("lblCurrencyCode").Text = dr.CurrencyCode
            'Report.Bands.Item("Detail").Controls("xrLabel20").Text = _
            '        dr.ExchangeRate * CType(Report.GetCurrentColumnValue("Amount"), Double)

            'Dim Amount As String = Report.Bands.Item("Detail").Controls("xrLabel21").Text

            '            Dim TAmount As Double = Convert.ToDouble(Amount)

            '            Report.Bands.Item("Detail").Controls("lblCurrencyCode").Text = dr.CurrencyCode
            Report.Bands.Item("GroupHeader1").Controls("xrLabel14").Text = "Amount  " & "(" & dr.CurrencyCode & ")"
            '            Report.Bands.Item("Detail").Controls("xrLabel12").Text = dr.ExchangeRate * Convert.ToDouble(Report.Bands.Item("Detail").Controls("lblAmount").Text)
        End If



        'Dim dtExpenseByClient As dsExpenseByClientForXtrReport.vueAccountExpenseEntryDataTable = New AccountCurrencyBLL().GetDataByExpenseByClientByAccountId(IIf(Me.ddlExpenseName.SelectedValue <> "", Me.ddlExpenseName.SelectedValue, 0))
        'Dim drExpenseByClient As dsExpenseByClientForXtrReport.vueAccountExpenseEntryRow

        'If dtExpenseByClient.Rows.Count > 0 Then
        '    drExpenseByClient = dtExpenseByClient.Rows(0)

        '    Dim ExchangeRate As Double = Convert.ToDouble(Report.Bands.Item("Detail").Controls("lblExchangeRate").Text)
        '    Dim Amount As Double = drExpenseByClient.Amount

        '    Report.Bands.Item("Detail").Controls("xrLabel12").Text = ExchangeRate * Amount
        'End If


        Report.DataAdapter = adap
        Report.DataSource = ds
        Me.ReportViewer1.Report = Report
        Me.ReportViewer1.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack = True Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(68, Me.ddlEmployees)
            AccountProjectBLL.SetDataForProjectDropdown(68, Me.ddlProjects)
            ReportUtilities.SetDefaultValuesOfFilerItem(Me.ddlEmployees, Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)
            Me.ShowReportFromFilter()
        Else
            Me.ShowReportFromFilter()
        End If


    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)

        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)

        Me.ShowReportFromFilter()
    End Sub
    Public Sub ShowReportFromFilter()
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlEmployees.SelectedValue, ddlProjects.SelectedValue, ddlClients.SelectedValue, ddlLocation.SelectedValue, chkIncludeDateRange.Checked, StartDate.SelectedDate, EndDate.SelectedDate, ddlApproved.SelectedValue, ddlBillable.SelectedValue, ddlSubmitted.SelectedValue)
    End Sub
End Class