Imports DevExpress.XtraReports.UI
Partial Class Reports_ControlsViewer_AccountTimeExpenseBillingReport
    Inherits System.Web.UI.UserControl
    Dim objReport As New LiveReport
    Public WithEvents PageHeader As New DevExpress.XtraReports.UI.PageHeaderBand
    Public Sub ShowReport(ByVal AccountId As Integer, ByVal AccountTimeExpenseBillingId As Guid)

        Dim Report As New xtrAccountTimeExpenseBillingReport
        If DBUtilities.GetSessionAccountId = 7354 Then
            Dim ds As New AccountTimeExpenseBillingReport.vueAccountTimeExpenseBillingReportDataTable
            Dim adap As New AccountTimeExpenseBillingReportTableAdapters.vueAccountTimeExpenseBillingReportTableAdapter
            ds = adap.GetDataByAccountIdAndAccountTimeExpenseBillingId(AccountId, AccountTimeExpenseBillingId)
            Report.DataAdapter = adap
            Report.DataSource = ds
        Else
            Dim ds As New AccountTimeExpenseBillingReport.AccountTimeExpenseBillingReportDataTable
            Dim adap As New AccountTimeExpenseBillingReportTableAdapters.AccountTimeExpenseBillingReportTableAdapter
            ds = adap.GetDataByAccountIdandAccountTimeExpenseBillingId(AccountId, AccountTimeExpenseBillingId)
            Report.DataAdapter = adap
            Report.DataSource = ds
        End If

        Report.DataMember = "AccountTimeExpenseBillingReport"
        Report.DetailPrintCount = 0
        Me.ReportViewer1.Report = Report

        Dim SubTotal As Double = 0
        Dim TaxCode1 As Double = 0
        Dim TaxCode2 As Double = 0
        Dim GrandTotal As Double = 0

        Dim dtExpenseSheet As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingReportDataTable = New AccountTimeExpenseBillingBLL().GetAccountTimeExpenseBillingReportByAccountIdAndAccountTimeExpenseBillingId(AccountId, AccountTimeExpenseBillingId)

        Dim drExpenseSheet As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingReportRow
        If dtExpenseSheet.Rows.Count > 0 Then
            drExpenseSheet = dtExpenseSheet.Rows(0)
            SubTotal = drExpenseSheet.SubTotal
            TaxCode1 = drExpenseSheet.TaxCode1
            TaxCode2 = drExpenseSheet.TaxCode2
            GrandTotal = drExpenseSheet.GrandTotal
        End If

        Dim dsCheckTimesheet As New AccountTimeExpenseBillingReport.AccountTimeExpenseBillingTimesheetReportDataTable
        Dim drchecktimesheet As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingTimesheetReportRow
        Dim adapCheckTimesheet As New AccountTimeExpenseBillingReportTableAdapters.AccountTimeExpenseBillingTimesheetReportTableAdapter
        dsCheckTimesheet = adapCheckTimesheet.GetDataByAccountTimeExpenseBillingIds(AccountTimeExpenseBillingId)
        If dsCheckTimesheet.Rows.Count = 0 Then
            CType(Report.Bands.Item("Detail"), DevExpress.XtraReports.UI.XRControl).Visible = False
            CType(Report.Bands.Item("GroupFooter2"), DevExpress.XtraReports.UI.XRControl).Visible = False
            CType(Report.Bands.Item("GroupHeader1").Controls("xrLabel14"), DevExpress.XtraReports.UI.XRLabel).Visible = False
            CType(Report.Bands.Item("GroupHeader1").Controls("xrLabel13"), DevExpress.XtraReports.UI.XRLabel).Visible = False
            CType(Report.Bands.Item("GroupHeader1").Controls("xrLabel12"), DevExpress.XtraReports.UI.XRLabel).Visible = False
            CType(Report.Bands.Item("GroupHeader1").Controls("xrLabel5"), DevExpress.XtraReports.UI.XRLabel).Visible = False
            CType(Report.Bands.Item("GroupHeader1").Controls("xrLabel17"), DevExpress.XtraReports.UI.XRLabel).Visible = False
            CType(Report.Bands.Item("GroupHeader1").Controls("xrLabelEntryDate"), DevExpress.XtraReports.UI.XRLabel).Visible = False

            CType(Report.Bands.Item("GroupFooter2").Controls("xrLabel26"), DevExpress.XtraReports.UI.XRLabel).Text = 0
            CType(Report.Bands.Item("Detail").Controls("xrLabel42"), DevExpress.XtraReports.UI.XRLabel).Text = 0
            CType(Report.Bands.Item("Detail").Controls("xrLabel3"), DevExpress.XtraReports.UI.XRLabel).Text = 0
            CType(Report.Bands.Item("Detail").Controls("xrLabel2"), DevExpress.XtraReports.UI.XRLabel).Text = 0
            CType(Report.Bands.Item("GroupFooter2").Controls("xrLabel9"), DevExpress.XtraReports.UI.XRLabel).Text = 0
            CType(Report.Bands.Item("GroupFooter3").Controls("xrLabel44"), DevExpress.XtraReports.UI.XRLabel).Text = String.Format("{0:n2}", SubTotal)
            CType(Report.Bands.Item("GroupFooter3").Controls("xrLabel45"), DevExpress.XtraReports.UI.XRLabel).Text = String.Format("{0:n2}", TaxCode1)
            CType(Report.Bands.Item("GroupFooter3").Controls("xrLabel46"), DevExpress.XtraReports.UI.XRLabel).Text = String.Format("{0:n2}", TaxCode2)
            CType(Report.Bands.Item("GroupFooter3").Controls("xrLabel47"), DevExpress.XtraReports.UI.XRLabel).Text = String.Format("{0:n2}", GrandTotal)

            For Each b As Band In Report.Bands
                For Each c As XRControl In b.Controls
                    If TypeOf c Is XRLabel Then
                        Dim t As XRLabel = DirectCast(c, XRLabel)
                        For Each row As XRControl In t.Controls
                            ' binding logic
                            For Each cell As XRControl In row.Controls
                            Next
                        Next
                    End If
                Next
            Next
        End If


        Dim SubReport As New subTimeBillingExpenseReport
        Dim dssub As New dsTimeBillingExpenseSubReport.AccountTimeExpenseBillingExpenseDataTable
        Dim adapsub As New dsTimeBillingExpenseSubReportTableAdapters.AccountTimeExpenseBillingExpenseTableAdapter
        dssub = adapsub.GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)
        SubReport.DataAdapter = adapsub


        If dssub.Rows.Count = 0 Then
            Report.xrSubreport1.Visible = False
        End If

        If dssub.Rows.Count = 0 And dsCheckTimesheet.Rows.Count = 0 Then
            'CType(Report.Bands.Item("GroupFooter3"), DevExpress.XtraReports.UI.XRControl).Visible = False
        End If
        SubReport.DataSource = dssub
        SubReport.DataMember = "AccountTimeExpenseBillingReport"
        SubReport.DetailPrintCount = 0
        Me.ReportViewer1.Report = Report
        Report.xrSubreport1.ReportSource = SubReport
        Report.FillDataSource()

        Dim dtAccountTimeExpenseBilling As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingReportDataTable = New AccountTimeExpenseBillingBLL().GetAccountTimeExpenseBillingReportByInvoiceNo(DBUtilities.GetSessionAccountId, AccountTimeExpenseBillingId)
        Dim drAccountTimeExpenseBilling As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingReportRow
        If dtAccountTimeExpenseBilling.Rows.Count > 0 Then
            drAccountTimeExpenseBilling = dtAccountTimeExpenseBilling.Rows(0)

            Dim Tno As String = drAccountTimeExpenseBilling.InvoiceNumber.PadLeft(5, "0")
            If Not IsDBNull(drAccountTimeExpenseBilling.Item("InvoiceNoPrefix")) Then
                Dim InvoicePrefix As String = drAccountTimeExpenseBilling.InvoiceNoPrefix & Tno
                CType(Report.Bands.Item("GroupHeader1").Controls("xrLabel25"), DevExpress.XtraReports.UI.XRLabel).Text = InvoicePrefix
            Else
                Dim InvoiceNo As String = Tno
                CType(Report.Bands.Item("GroupHeader1").Controls("xrLabel25"), DevExpress.XtraReports.UI.XRLabel).Text = InvoiceNo
            End If
        End If

        If LocaleUtilitiesBLL.IsShowCompanyOwnLogo = True And LocaleUtilitiesBLL.IsLogoFileExistInSessionAccount() = True Then
            Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("~/Uploads/" & DBUtilities.GetSessionAccountId & "/Logo/CompanyLogo.gif"))
            CType(Report.Bands.Item("PageHeader").Controls("xrPictureBox1"), DevExpress.XtraReports.UI.XRPictureBox).Image = Me.byteArrayToImage(Me.imageToByteArray(img))
        End If

        Me.ReportViewer1.DataBind()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.IspageHasRights(132)
        If Not Me.IsPostBack Then
            Me.ShowReportFromFilter()
        Else
            Me.ShowReportFromFilter()
        End If
    End Sub
    Public Sub ShowReportFromFilter()
        Dim AccountTimeExpenseBillingId As New Guid(Me.Request.QueryString("AccountTimeExpenseBillingId"))
        Me.ShowReport(DBUtilities.GetSessionAccountId, AccountTimeExpenseBillingId)
    End Sub
    Public Function imageToByteArray(ByVal img As System.Drawing.Image) As Byte()
        Dim ms As New System.IO.MemoryStream
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
        Return ms.ToArray()
    End Function
    Public Function byteArrayToImage(ByVal byteArrayIn As Byte()) As System.Drawing.Image
        Dim ms As New System.IO.MemoryStream(byteArrayIn)
        Dim returnImage As System.Drawing.Image = System.Drawing.Image.FromStream(ms)
        Return returnImage
    End Function
End Class
