
Partial Class WebReport_Reports_Controls_ctlShowReport
    Inherits System.Web.UI.UserControl

    'Protected Sub CtlLiveReportFilter1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlLiveReportFilter1.Load
    'End Sub
    Protected Sub CtlLiveReportFilter1_ShowClicked(ByVal WhereClause As String, ByVal Consolidated As Boolean, ByVal BaseCurrencyId As Integer, ByVal MissingPeriodReportWhereClause As String, ByVal MissingPeriodReportStartAndEndDate As Hashtable, ByVal TimesheetPeriodType As String) Handles CtlLiveReportFilter1.ShowClicked
        ApplyFilter(WhereClause, Consolidated, BaseCurrencyId, MissingPeriodReportWhereClause, MissingPeriodReportStartAndEndDate, TimesheetPeriodType)
    End Sub
    Public Sub ApplyFilter(ByVal WhereClause As String, ByVal Consolidated As Boolean, ByVal BaseCurrencyId As Integer, ByVal MissingPeriodReportWhereClause As String, ByVal MissingPeriodReportStartAndEndDate As Hashtable, ByVal TimesheetPeriodType As String)
        Me.ViewState.Item("WhereClause") = WhereClause
        Me.ViewState.Item("MissingPeriodReportWhereClause") = MissingPeriodReportWhereClause
        Me.ViewState.Item("MissingPeriodReportStartAndEndDate") = MissingPeriodReportStartAndEndDate
        Me.ViewState.Item("TimesheetPeriodType") = TimesheetPeriodType
        Dim ReportId As New Guid(Me.Request.QueryString("AccountReportId"))
        Dim ReportDataTable As DataTable = LiveReportData.GetDataTable(ReportId, Me.ViewState.Item("WhereClause"), Me.ViewState.Item("MissingPeriodReportWhereClause"), Me.ViewState.Item("MissingPeriodReportStartAndEndDate"), Me.ViewState.Item("TimesheetPeriodType"))

        Session("ReportDataTable_FT") = ReportDataTable

        Me.ReportControl1.SetDataSource(ReportDataTable, Consolidated)
        Me.ReportControl1.RenderReport()
        Me.AddParameterColumns(BaseCurrencyId, ReportDataTable)
        Me.ReportControl1.ShowReportFromFilter(ReportDataTable)
    End Sub
    Protected Sub CtlLiveReportFilter1_PageLoad(ByVal WhereClause As String, ByVal Consolidated As Boolean, ByVal BaseCurrencyId As Integer, ByVal MissingPeriodReportWhereClause As String, ByVal MissingPeriodReportStartAndEndDate As Hashtable, ByVal TimesheetPeriodType As String) Handles CtlLiveReportFilter1.PageLoad
        If Me.ViewState.Item("WhereClause") Is Nothing Then
            Me.ViewState.Item("WhereClause") = WhereClause
        End If
        If Me.ViewState.Item("MissingPeriodReportWhereClause") Is Nothing Then
            Me.ViewState.Item("MissingPeriodReportWhereClause") = MissingPeriodReportWhereClause
        End If
        If Me.ViewState.Item("MissingPeriodReportStartAndEndDate") Is Nothing Then
            Me.ViewState.Item("MissingPeriodReportStartAndEndDate") = MissingPeriodReportStartAndEndDate
        End If
        If Me.ViewState.Item("TimesheetPeriodType") Is Nothing Then
            Me.ViewState.Item("TimesheetPeriodType") = TimesheetPeriodType
        End If
        Me.ApplyFilter(Me.ViewState.Item("WhereClause"), Consolidated, BaseCurrencyId, Me.ViewState.Item("MissingPeriodReportWhereClause"), Me.ViewState.Item("MissingPeriodReportStartAndEndDate"), Me.ViewState.Item("TimesheetPeriodType"))
        If Not Me.IsPostBack Then
        End If
    End Sub
    Public Sub AddParameterColumns(ByVal BaseCurrencyId As Integer, ByVal dtReport As DataTable)
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        Dim BLL As New AccountCurrencyBLL

        dtReport.Columns.Add("CurrencyExchangeRate", GetType(Double))
        dtReport.Columns.Add("CalculatedCurrencyAmount", GetType(Decimal))

        Dim dt As AccountCurrency.vueAccountCurrencyDataTable = BLL.GetvueAccountCurrencyByAccountCurrencyId(BaseCurrencyId)
        Dim dr As AccountCurrency.vueAccountCurrencyRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.ReportControl1.AddParameterColumn("ParameterCurrencyCode", dr.CurrencyCode, GetType(System.String))
            Me.ReportControl1.AddParameterColumn("ParameterCurrencyExchangeRate", dr.ExchangeRate, GetType(System.Double))
        End If

        Dim ReportId As New Guid(Me.Request.QueryString("AccountReportId"))

        If New Guid(LiveReportData.GetSystemReportDataSourceIdByAccountReportId(ReportId)) = New Guid("0F2D1D68-826D-400E-BF9F-95D4A9D6C4E0") Then

            For Each row As DataRow In dtReport.Rows
                Dim Rate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(BaseCurrencyId, row("AccountExpenseEntryDate"))
                Dim AmountInMasterBase As Decimal = row("Amount") / row("ExchangeRate")
                row("CurrencyExchangeRate") = Rate
                Dim FinalCalculation As Decimal = FormatNumber(Math.Round(AmountInMasterBase * Rate, 2), 2)
                row("CalculatedCurrencyAmount") = FinalCalculation
            Next
        End If

    End Sub
End Class
