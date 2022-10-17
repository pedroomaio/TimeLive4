
Partial Class Reports_ControlsViewer_ctlExpenseByClientReport
    Inherits System.Web.UI.UserControl
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountClientId As Integer, ByVal AccountEmployees As String, ByVal AccountProjectId As Integer, ByVal AccountLocationId As Integer, ByVal AccountExpenseId As Integer, ByVal Submitted As String, ByVal IncludeDateRange As Boolean, ByVal AccountExpenseEntryStartDate As Date, ByVal AccontExpenseEntryEndDate As Date)
        ''Dim docReport As New C1.Web.C1WebReport.C1WebReport
        ''docReport.ReportSource.FileName = (Server.MapPath("ReportFiles\rptDepartmentListReport.xml"))
        'Dim m As TimeLiveDataSet.vueAccountExpenseEntryForReportDataTable
        'm = New AccountExpenseEntryBLL().GetDataForExpenseByClientReport(AccountId, AccountClientId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountExpenseId, IncludeDateRange, AccountExpenseEntryStartDate, AccontExpenseEntryEndDate)
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

        Dim Report As New xtrExpenseByClientReport

        Dim ds As New dsExpenseByClient.vueAccountExpenseEntryDataTable
        Dim adap As New dsExpenseByClientTableAdapters.vueAccountExpenseEntryAdapter
        ds = adap.GetDataForExpenseByClientReort(AccountId, AccountClientId, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectId, AccountLocationId, AccountExpenseId, Submitted, IncludeDateRange, AccountExpenseEntryStartDate, AccontExpenseEntryEndDate)

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
            '            Report.Bands.Item("Detail").Controls("lblCurrencyCode").Text = dr.CurrencyCode
            Report.Bands.Item("groupHeaderBand3").Controls("xrLabel8").Text = "Amount  " & "(" & dr.CurrencyCode & ")"
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
    Public Sub FilterReport()
        Me.ShowReport(DBUtilities.GetSessionAccountId, ddlClients.SelectedValue, ddlEmployees.SelectedValue, ddlProjects.SelectedValue, ddlLocation.SelectedValue, ddlExpenseName.SelectedValue, ddlSubmitted.SelectedValue, chkIncludeDateRange.Checked, txtStartDate.SelectedDate, txtEndDate.SelectedDate)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(63, Me.ddlEmployees)
            AccountProjectBLL.SetDataForProjectDropdown(63, Me.ddlProjects)
            ReportUtilities.SetDefaultValuesOfFilerItem(Me.ddlEmployees, Me.txtStartDate, Me.txtEndDate, Me.chkIncludeDateRange)
            Me.FilterReport()
        Else
            Me.FilterReport()
        End If


    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtStartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtStartDate.PostedDate)
        Me.txtEndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtEndDate.PostedDate)
        Me.ViewState.Add("IsFromFilter", True)
        Me.FilterReport()
    End Sub
End Class
