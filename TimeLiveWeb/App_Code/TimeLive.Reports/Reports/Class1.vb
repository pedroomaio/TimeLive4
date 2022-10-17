Imports AccountTimeExpenseBillingReportTableAdapters
Public Class xtrAccountTimeExpenseBillingReport2
    Inherits DevExpress.XtraReports.UI.XtraReport
#Region " Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents accountTimeExpenseBillingReport1 As AccountTimeExpenseBillingReport
    Private WithEvents accountTimeExpenseBillingReportTableAdapter1 As AccountTimeExpenseBillingReportTableAdapters.AccountTimeExpenseBillingReportTableAdapter
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xtraReport11 As XtraReport1
    Private WithEvents xtraReport12 As XtraReport1
    Private WithEvents xtraReport13 As XtraReport1
    Private WithEvents xtrTaskSummaryReport1 As xtrTaskSummaryReport
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents ctlTotalAmount As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel37 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel40 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents subTimeBillingExpenseReport1 As subTimeBillingExpenseReport
    Private WithEvents repProjectSummaryExpenseReport1 As repProjectSummaryExpenseReport
    Public WithEvents xrSubreport1 As DevExpress.XtraReports.UI.XRSubreport
    Private WithEvents GroupFooter2 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine4 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents GroupFooter3 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabelTerms As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabelTermsValue As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabelOtherDetails As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabelOtherDetailsValue As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine6 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine5 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents ctlBillHours As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel41 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel42 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel44 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel45 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel46 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel47 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Private WithEvents ctlInvoiceNo As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltTotalAmount As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltSubTotal As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltTaxCode1 As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltTaxCode2 As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltGrandTotal As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltCity As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents cltClientCity As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltBillingAddress As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltAccountAddress As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltBillingCountry As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltAccountCountry As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Public WithEvents xrLabel As DevExpress.XtraReports.UI.XRLabel
    Public TotalBillHoursInReport As Double
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents formattingRule1 As DevExpress.XtraReports.UI.FormattingRule
    Private WithEvents xrControlStyle2 As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents ctlProjectName As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabelEntryDate As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel39 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents ctlDateFooter As DevExpress.XtraReports.UI.CalculatedField
    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrAccountTimeExpenseBillingReport.resx"
        Dim resources As System.Resources.ResourceManager = Global.Resources.xtrAccountTimeExpenseBillingReport.ResourceManager
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel41 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrLabel39 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.xrLabel40 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.accountTimeExpenseBillingReport1 = New AccountTimeExpenseBillingReport()
        Me.accountTimeExpenseBillingReportTableAdapter1 = New AccountTimeExpenseBillingReportTableAdapters.AccountTimeExpenseBillingReportTableAdapter()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabelEntryDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrSubreport1 = New DevExpress.XtraReports.UI.XRSubreport()
        Me.xtraReport11 = New XtraReport1()
        Me.xtraReport12 = New XtraReport1()
        Me.xtraReport13 = New XtraReport1()
        Me.xtrTaskSummaryReport1 = New xtrTaskSummaryReport()
        Me.ctlTotalAmount = New DevExpress.XtraReports.UI.CalculatedField()
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.subTimeBillingExpenseReport1 = New subTimeBillingExpenseReport()
        Me.repProjectSummaryExpenseReport1 = New repProjectSummaryExpenseReport()
        Me.GroupFooter2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.formattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
        Me.xrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter3 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLabel47 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel46 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel45 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel44 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine5 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabelTerms = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabelTermsValue = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabelOtherDetails = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabelOtherDetailsValue = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine6 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ctlBillHours = New DevExpress.XtraReports.UI.CalculatedField()
        Me.ctlInvoiceNo = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltTotalAmount = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltSubTotal = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltTaxCode1 = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltTaxCode2 = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltGrandTotal = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltCity = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltClientCity = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltBillingAddress = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltAccountAddress = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltBillingCountry = New DevExpress.XtraReports.UI.CalculatedField()
        Me.cltAccountCountry = New DevExpress.XtraReports.UI.CalculatedField()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.xrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.xrControlStyle2 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.ctlProjectName = New DevExpress.XtraReports.UI.CalculatedField()
        Me.ctlDateFooter = New DevExpress.XtraReports.UI.CalculatedField()
        CType(Me.accountTimeExpenseBillingReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xtraReport11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xtraReport12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xtraReport13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xtrTaskSummaryReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.subTimeBillingExpenseReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repProjectSummaryExpenseReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel34, Me.xrLabel18, Me.xrLabel42, Me.xrLabel3, Me.xrLabel41, Me.xrLabel2, Me.xrLabel1})
        Me.Detail.EvenStyleName = "xtrEvenRow"
        Me.Detail.HeightF = 25.0!
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.OddStyleName = "xtrOddRow"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.Scripts.OnBeforePrint = "Detail_BeforePrint"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel34
        '
        Me.xrLabel34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.TimeEntryDate", "{0:d}")})
        Me.xrLabel34.Font = New System.Drawing.Font("Verdana", 7.75!)
        Me.xrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(7.000002!, 0.0!)
        Me.xrLabel34.Name = "xrLabel34"
        Me.xrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel34.SizeF = New System.Drawing.SizeF(83.0!, 25.0!)
        Me.xrLabel34.StylePriority.UseFont = False
        Me.xrLabel34.StylePriority.UseTextAlignment = False
        Me.xrLabel34.Text = "xrLabel34"
        Me.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.ProjectName")})
        Me.xrLabel18.Font = New System.Drawing.Font("Verdana", 7.75!)
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(90.0!, 0.0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(123.7083!, 25.0!)
        Me.xrLabel18.StylePriority.UseFont = False
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        Me.xrLabel18.Text = "[ProjectName]"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel42
        '
        Me.xrLabel42.Font = New System.Drawing.Font("Verdana", 7.75!)
        Me.xrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(616.0!, 0.0!)
        Me.xrLabel42.Name = "xrLabel42"
        Me.xrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel42.SizeF = New System.Drawing.SizeF(118.0!, 25.0!)
        Me.xrLabel42.StylePriority.UseFont = False
        Me.xrLabel42.StylePriority.UseTextAlignment = False
        Me.xrLabel42.Text = "0.00"
        Me.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel3
        '
        Me.xrLabel3.Font = New System.Drawing.Font("Verdana", 7.75!)
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(516.0!, 0.0!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(100.0!, 25.0!)
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "xrLabel3"
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel41
        '
        Me.xrLabel41.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.CurrencyCode")})
        Me.xrLabel41.Font = New System.Drawing.Font("Verdana", 7.75!)
        Me.xrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 0.0!)
        Me.xrLabel41.Name = "xrLabel41"
        Me.xrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel41.SizeF = New System.Drawing.SizeF(83.0!, 25.0!)
        Me.xrLabel41.StylePriority.UseFont = False
        Me.xrLabel41.StylePriority.UseTextAlignment = False
        Me.xrLabel41.Text = "xrLabel41"
        Me.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel41.Visible = False
        '
        'xrLabel2
        '
        Me.xrLabel2.Font = New System.Drawing.Font("Verdana", 7.75!)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(416.0001!, 0.0!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(100.0!, 25.0!)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.Text = "xrLabel2"
        Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel1
        '
        Me.xrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.Detail Description")})
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 7.75!)
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(214.0!, 0.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(202.0!, 25.0!)
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "xrLabel1"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel39, Me.xrLabel16, Me.xrPictureBox1, Me.xrLabel40, Me.xrLabel37, Me.xrLabel23, Me.xrLabel35})
        Me.PageHeader.HeightF = 189.5833!
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel39
        '
        Me.xrLabel39.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.AccountAddress2")})
        Me.xrLabel39.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel39.LocationFloat = New DevExpress.Utils.PointFloat(552.0!, 112.0!)
        Me.xrLabel39.Name = "xrLabel39"
        Me.xrLabel39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel39.SizeF = New System.Drawing.SizeF(180.0!, 17.0!)
        Me.xrLabel39.StylePriority.UseFont = False
        Me.xrLabel39.Text = "xrLabel39"
        Me.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.Telephone")})
        Me.xrLabel16.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(552.0!, 163.0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(180.0!, 17.0!)
        Me.xrLabel16.StylePriority.UseFont = False
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrPictureBox1
        '
        Me.xrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(549.0!, 8.0!)
        Me.xrPictureBox1.Name = "xrPictureBox1"
        Me.xrPictureBox1.SizeF = New System.Drawing.SizeF(180.0!, 50.0!)
        Me.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'xrLabel40
        '
        Me.xrLabel40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.AccountCountry")})
        Me.xrLabel40.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel40.LocationFloat = New DevExpress.Utils.PointFloat(552.0!, 146.0!)
        Me.xrLabel40.Name = "xrLabel40"
        Me.xrLabel40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel40.SizeF = New System.Drawing.SizeF(180.0!, 17.0!)
        Me.xrLabel40.StylePriority.UseFont = False
        Me.xrLabel40.Text = "xrLabel40"
        Me.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel37
        '
        Me.xrLabel37.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.cltCity")})
        Me.xrLabel37.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(552.0!, 129.0!)
        Me.xrLabel37.Name = "xrLabel37"
        Me.xrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel37.SizeF = New System.Drawing.SizeF(180.0!, 17.0!)
        Me.xrLabel37.StylePriority.UseFont = False
        Me.xrLabel37.Text = "xrLabel37"
        Me.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel23
        '
        Me.xrLabel23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.AccountAddress1")})
        Me.xrLabel23.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(552.0!, 95.0!)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.SizeF = New System.Drawing.SizeF(180.0!, 17.0!)
        Me.xrLabel23.StylePriority.UseFont = False
        Me.xrLabel23.Text = "xrLabel23"
        Me.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel35
        '
        Me.xrLabel35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.AccountName")})
        Me.xrLabel35.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(552.0!, 70.0!)
        Me.xrLabel35.Name = "xrLabel35"
        Me.xrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel35.SizeF = New System.Drawing.SizeF(180.0!, 25.0!)
        Me.xrLabel35.StylePriority.UseFont = False
        Me.xrLabel35.Text = "xrLabel35"
        Me.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel28})
        Me.PageFooter.HeightF = 60.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel28
        '
        Me.xrLabel28.CanShrink = True
        Me.xrLabel28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.Master Description")})
        Me.xrLabel28.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(7.000002!, 0.0!)
        Me.xrLabel28.Multiline = True
        Me.xrLabel28.Name = "xrLabel28"
        Me.xrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel28.SizeF = New System.Drawing.SizeF(462.0!, 60.0!)
        Me.xrLabel28.StylePriority.UseFont = False
        Me.xrLabel28.Text = "[Master Description]"
        '
        'accountTimeExpenseBillingReport1
        '
        Me.accountTimeExpenseBillingReport1.DataSetName = "AccountTimeExpenseBillingReport"
        Me.accountTimeExpenseBillingReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'accountTimeExpenseBillingReportTableAdapter1
        '
        Me.accountTimeExpenseBillingReportTableAdapter1.ClearBeforeFill = True
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel36, Me.xrLabelEntryDate, Me.xrLabel19, Me.xrLabel17, Me.xrLabel15, Me.xrLabel8, Me.xrLabel4, Me.xrLabel12, Me.xrLabel25, Me.xrLabel13, Me.xrLabel5, Me.xrLabel14, Me.xrLabel30, Me.xrLabel7, Me.xrLabel6, Me.xrLabel10, Me.xrLabel11, Me.xrLabel31, Me.xrLabel32, Me.xrLabel33})
        Me.GroupHeader1.HeightF = 250.125!
        Me.GroupHeader1.Level = 1
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.Scripts.OnBeforePrint = "GroupHeader1_BeforePrint"
        '
        'xrLabel36
        '
        Me.xrLabel36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.ClientTelephone")})
        Me.xrLabel36.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(7.0!, 148.0!)
        Me.xrLabel36.Name = "xrLabel36"
        Me.xrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel36.SizeF = New System.Drawing.SizeF(517.0!, 17.0!)
        Me.xrLabel36.StylePriority.UseFont = False
        Me.xrLabel36.Text = "xrLabel15"
        '
        'xrLabelEntryDate
        '
        Me.xrLabelEntryDate.BackColor = System.Drawing.Color.Silver
        Me.xrLabelEntryDate.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabelEntryDate.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabelEntryDate.LocationFloat = New DevExpress.Utils.PointFloat(7.000002!, 218.125!)
        Me.xrLabelEntryDate.Name = "xrLabelEntryDate"
        Me.xrLabelEntryDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabelEntryDate.SizeF = New System.Drawing.SizeF(83.0!, 32.0!)
        Me.xrLabelEntryDate.StylePriority.UseBackColor = False
        Me.xrLabelEntryDate.StylePriority.UseBorders = False
        Me.xrLabelEntryDate.StylePriority.UseFont = False
        Me.xrLabelEntryDate.StylePriority.UseTextAlignment = False
        Me.xrLabelEntryDate.Text = ResourceHelper.GetFromResource("Entry Date")
        Me.xrLabelEntryDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.ctlProjectName")})
        Me.xrLabel19.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(9.0!, 190.2083!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(517.0!, 17.0!)
        Me.xrLabel19.StylePriority.UseFont = False
        Me.xrLabel19.Text = "xrLabel19"
        '
        'xrLabel17
        '
        Me.xrLabel17.BackColor = System.Drawing.Color.Silver
        Me.xrLabel17.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel17.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(90.00001!, 218.125!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(123.7083!, 32.0!)
        Me.xrLabel17.StylePriority.UseBackColor = False
        Me.xrLabel17.StylePriority.UseBorders = False
        Me.xrLabel17.StylePriority.UseFont = False
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.Text = ResourceHelper.GetFromResource("Project Name")
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.ClientCountry")})
        Me.xrLabel15.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(7.0!, 131.0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(517.0!, 17.0!)
        Me.xrLabel15.StylePriority.UseFont = False
        Me.xrLabel15.Text = "xrLabel15"
        '
        'xrLabel8
        '
        Me.xrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.cltClientCity")})
        Me.xrLabel8.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(7.0!, 114.0!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(517.0!, 17.0!)
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.Text = "xrLabel8"
        '
        'xrLabel4
        '
        Me.xrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.Address2")})
        Me.xrLabel4.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(7.0!, 97.0!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(517.0!, 17.0!)
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.Text = "xrLabel4"
        '
        'xrLabel12
        '
        Me.xrLabel12.BackColor = System.Drawing.Color.Silver
        Me.xrLabel12.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel12.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(214.0001!, 218.125!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(202.0!, 32.0!)
        Me.xrLabel12.StylePriority.UseBackColor = False
        Me.xrLabel12.StylePriority.UseBorders = False
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "Description"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel25
        '
        Me.xrLabel25.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(642.0!, 6.0!)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.SizeF = New System.Drawing.SizeF(92.0!, 17.0!)
        Me.xrLabel25.StylePriority.UseFont = False
        Me.xrLabel25.StylePriority.UseTextAlignment = False
        Me.xrLabel25.Text = "xrLabel25"
        Me.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel13
        '
        Me.xrLabel13.BackColor = System.Drawing.Color.Silver
        Me.xrLabel13.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel13.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(516.0001!, 218.125!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(100.0!, 32.0!)
        Me.xrLabel13.StylePriority.UseBackColor = False
        Me.xrLabel13.StylePriority.UseBorders = False
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "Bill Hours"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel5
        '
        Me.xrLabel5.BackColor = System.Drawing.Color.Silver
        Me.xrLabel5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel5.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(416.0001!, 218.125!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(100.0!, 32.0!)
        Me.xrLabel5.StylePriority.UseBackColor = False
        Me.xrLabel5.StylePriority.UseBorders = False
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "Billing Rate"
        Me.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel14
        '
        Me.xrLabel14.BackColor = System.Drawing.Color.Silver
        Me.xrLabel14.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel14.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(616.0001!, 218.125!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(118.0!, 32.0!)
        Me.xrLabel14.StylePriority.UseBackColor = False
        Me.xrLabel14.StylePriority.UseBorders = False
        Me.xrLabel14.StylePriority.UseFont = False
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.Text = "Amount"
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel30
        '
        Me.xrLabel30.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(549.0!, 6.0!)
        Me.xrLabel30.Name = "xrLabel30"
        Me.xrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel30.SizeF = New System.Drawing.SizeF(92.0!, 17.0!)
        Me.xrLabel30.StylePriority.UseFont = False
        Me.xrLabel30.StylePriority.UseTextAlignment = False
        Me.xrLabel30.Text = "Invoice #:"
        Me.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel7
        '
        Me.xrLabel7.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(549.0!, 40.0!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(92.0!, 17.0!)
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "PO Number :"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel6
        '
        Me.xrLabel6.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(549.0!, 23.0!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(92.0!, 17.0!)
        Me.xrLabel6.StylePriority.UseFont = False
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "Invoice Date :"
        Me.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel10
        '
        Me.xrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.InvoiceDate", "{0:d}")})
        Me.xrLabel10.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(642.0!, 23.0!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(92.0!, 17.0!)
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "xrLabel10"
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel11
        '
        Me.xrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.PONumber")})
        Me.xrLabel11.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(642.0!, 40.0!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(92.0!, 17.0!)
        Me.xrLabel11.StylePriority.UseFont = False
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "xrLabel11"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel31
        '
        Me.xrLabel31.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(7.0!, 38.0!)
        Me.xrLabel31.Name = "xrLabel31"
        Me.xrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel31.SizeF = New System.Drawing.SizeF(517.0!, 25.0!)
        Me.xrLabel31.StylePriority.UseFont = False
        Me.xrLabel31.StylePriority.UseTextAlignment = False
        Me.xrLabel31.Text = "Billing Address :"
        Me.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel32
        '
        Me.xrLabel32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.PartyName")})
        Me.xrLabel32.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(7.0!, 63.0!)
        Me.xrLabel32.Name = "xrLabel32"
        Me.xrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel32.SizeF = New System.Drawing.SizeF(517.0!, 17.0!)
        Me.xrLabel32.StylePriority.UseFont = False
        Me.xrLabel32.Text = "xrLabel32"
        '
        'xrLabel33
        '
        Me.xrLabel33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.Address1")})
        Me.xrLabel33.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(7.0!, 80.0!)
        Me.xrLabel33.Name = "xrLabel33"
        Me.xrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel33.SizeF = New System.Drawing.SizeF(517.0!, 17.0!)
        Me.xrLabel33.StylePriority.UseFont = False
        Me.xrLabel33.Text = "xrLabel33"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrSubreport1})
        Me.GroupFooter1.HeightF = 38.0!
        Me.GroupFooter1.KeepTogether = True
        Me.GroupFooter1.Level = 1
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrSubreport1
        '
        Me.xrSubreport1.LocationFloat = New DevExpress.Utils.PointFloat(8.0!, 5.0!)
        Me.xrSubreport1.Name = "xrSubreport1"
        Me.xrSubreport1.SizeF = New System.Drawing.SizeF(708.0!, 33.0!)
        '
        'ctlTotalAmount
        '
        Me.ctlTotalAmount.DataMember = "AccountTimeExpenseBillingReport"
        Me.ctlTotalAmount.DataSource = Me.accountTimeExpenseBillingReport1
        Me.ctlTotalAmount.DisplayName = "ctlTotalAmount"
        Me.ctlTotalAmount.FieldType = DevExpress.XtraReports.UI.FieldType.[Double]
        Me.ctlTotalAmount.Name = "ctlTotalAmount"
        '
        'xtrEvenRow
        '
        Me.xtrEvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.xtrEvenRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.xtrEvenRow.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xtrEvenRow.Name = "xtrEvenRow"
        Me.xtrEvenRow.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        '
        'xtrOddRow
        '
        Me.xtrOddRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.xtrOddRow.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xtrOddRow.Name = "xtrOddRow"
        Me.xtrOddRow.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        '
        'DataField
        '
        Me.DataField.BackColor = System.Drawing.Color.White
        Me.DataField.BorderColor = System.Drawing.SystemColors.ControlText
        Me.DataField.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.DataField.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.DataField.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataField.Name = "DataField"
        '
        'FieldCaption
        '
        Me.FieldCaption.BackColor = System.Drawing.Color.White
        Me.FieldCaption.BorderColor = System.Drawing.SystemColors.ControlText
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.FieldCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FieldCaption.ForeColor = System.Drawing.Color.Black
        Me.FieldCaption.Name = "FieldCaption"
        '
        'PageInfo
        '
        Me.PageInfo.BackColor = System.Drawing.Color.White
        Me.PageInfo.BorderColor = System.Drawing.SystemColors.ControlText
        Me.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PageInfo.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PageInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PageInfo.Name = "PageInfo"
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.White
        Me.Title.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Title.ForeColor = System.Drawing.Color.Black
        Me.Title.Name = "Title"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine2, Me.xrLine4, Me.xrLabel26, Me.xrLabel27, Me.xrLabel9})
        Me.GroupFooter2.HeightF = 47.0!
        Me.GroupFooter2.KeepTogether = True
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'xrLine2
        '
        Me.xrLine2.EvenStyleName = "Title"
        Me.xrLine2.LocationFloat = New DevExpress.Utils.PointFloat(9.0!, 27.0!)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.OddStyleName = "Title"
        Me.xrLine2.SizeF = New System.Drawing.SizeF(725.0!, 8.0!)
        Me.xrLine2.StyleName = "Title"
        '
        'xrLine4
        '
        Me.xrLine4.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.xrLine4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrLine4.BorderWidth = 1
        Me.xrLine4.EvenStyleName = "xrControlStyle2"
        Me.xrLine4.FormattingRules.Add(Me.formattingRule1)
        Me.xrLine4.LocationFloat = New DevExpress.Utils.PointFloat(9.0!, 0.0!)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.SizeF = New System.Drawing.SizeF(725.0!, 8.0!)
        Me.xrLine4.StyleName = "Title"
        Me.xrLine4.StylePriority.UseBorderDashStyle = False
        Me.xrLine4.StylePriority.UseBorders = False
        Me.xrLine4.StylePriority.UseBorderWidth = False
        '
        'formattingRule1
        '
        '
        '
        '
        Me.formattingRule1.Formatting.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.formattingRule1.Name = "formattingRule1"
        '
        'xrLabel26
        '
        Me.xrLabel26.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(616.0!, 9.0!)
        Me.xrLabel26.Name = "xrLabel26"
        Me.xrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel26.SizeF = New System.Drawing.SizeF(118.0!, 17.0!)
        Me.xrLabel26.StylePriority.UseFont = False
        Me.xrLabel26.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        Me.xrLabel26.Summary = xrSummary1
        Me.xrLabel26.Text = "xrLabel26"
        Me.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel27
        '
        Me.xrLabel27.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(317.0!, 9.0!)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.SizeF = New System.Drawing.SizeF(75.0!, 17.0!)
        Me.xrLabel27.StylePriority.UseFont = False
        Me.xrLabel27.StylePriority.UseTextAlignment = False
        Me.xrLabel27.Text = "Total :"
        Me.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel9
        '
        Me.xrLabel9.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(516.0!, 9.0!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(100.0!, 17.0!)
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "xrLabel9"
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel47, Me.xrLabel46, Me.xrLabel45, Me.xrLabel44, Me.xrLine5, Me.xrLabel29, Me.xrLabelTerms, Me.xrLabelTermsValue, Me.xrLabelOtherDetails, Me.xrLabelOtherDetailsValue, Me.xrLine6, Me.xrLabel22, Me.xrLabel24, Me.xrLabel21, Me.xrLabel20})
        Me.GroupFooter3.HeightF = 108.0!
        Me.GroupFooter3.KeepTogether = True
        Me.GroupFooter3.Level = 2
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'xrLabel47
        '
        Me.xrLabel47.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel47.LocationFloat = New DevExpress.Utils.PointFloat(616.0!, 77.0!)
        Me.xrLabel47.Name = "xrLabel47"
        Me.xrLabel47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel47.SizeF = New System.Drawing.SizeF(118.0!, 17.0!)
        Me.xrLabel47.StylePriority.UseFont = False
        Me.xrLabel47.StylePriority.UseTextAlignment = False
        Me.xrLabel47.Text = "xrLabel47"
        Me.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel47.Visible = False
        '
        'xrLabel46
        '
        Me.xrLabel46.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel46.LocationFloat = New DevExpress.Utils.PointFloat(616.0!, 52.0!)
        Me.xrLabel46.Name = "xrLabel46"
        Me.xrLabel46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel46.SizeF = New System.Drawing.SizeF(118.0!, 17.0!)
        Me.xrLabel46.StylePriority.UseFont = False
        Me.xrLabel46.StylePriority.UseTextAlignment = False
        Me.xrLabel46.Text = "xrLabel46"
        Me.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel46.Visible = False
        '
        'xrLabel45
        '
        Me.xrLabel45.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel45.LocationFloat = New DevExpress.Utils.PointFloat(616.0!, 35.0!)
        Me.xrLabel45.Name = "xrLabel45"
        Me.xrLabel45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel45.SizeF = New System.Drawing.SizeF(118.0!, 17.0!)
        Me.xrLabel45.StylePriority.UseFont = False
        Me.xrLabel45.StylePriority.UseTextAlignment = False
        Me.xrLabel45.Text = "xrLabel45"
        Me.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel45.Visible = False
        '
        'xrLabel44
        '
        Me.xrLabel44.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel44.LocationFloat = New DevExpress.Utils.PointFloat(616.0!, 18.0!)
        Me.xrLabel44.Name = "xrLabel44"
        Me.xrLabel44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel44.SizeF = New System.Drawing.SizeF(118.0!, 17.0!)
        Me.xrLabel44.StylePriority.UseFont = False
        Me.xrLabel44.StylePriority.UseTextAlignment = False
        Me.xrLabel44.Text = "xrLabel44"
        Me.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLine5
        '
        Me.xrLine5.LocationFloat = New DevExpress.Utils.PointFloat(538.0!, 95.0!)
        Me.xrLine5.Name = "xrLine5"
        Me.xrLine5.SizeF = New System.Drawing.SizeF(196.0!, 8.0!)
        Me.xrLine5.Visible = False
        '
        'xrLabel29
        '
        Me.xrLabel29.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 20.0!)
        Me.xrLabel29.Name = "xrLabel29"
        Me.xrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel29.SizeF = New System.Drawing.SizeF(66.0!, 83.0!)
        Me.xrLabel29.StylePriority.UseFont = False
        Me.xrLabel29.StylePriority.UseTextAlignment = False
        Me.xrLabel29.Text = "Notes :"
        Me.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.xrLabel29.Visible = False
        '
        'xrLabelTerms
        '
        Me.xrLabelTerms.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabelTerms.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 30.0!)
        Me.xrLabelTerms.Name = "xrLabelTerms"
        Me.xrLabelTerms.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabelTerms.SizeF = New System.Drawing.SizeF(66.0!, 83.0!)
        Me.xrLabelTerms.StylePriority.UseFont = False
        Me.xrLabelTerms.StylePriority.UseTextAlignment = False
        Me.xrLabelTerms.Text = "Terms :"
        Me.xrLabelTerms.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.xrLabelTerms.Visible = False
        '
        'xrLabelTermsValue
        '
        Me.xrLabelTermsValue.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.Terms")})
        Me.xrLabelTermsValue.LocationFloat = New DevExpress.Utils.PointFloat(85.0!, 19.0!)
        Me.xrLabelTermsValue.Name = "xrLabelTermsValue"
        Me.xrLabelTermsValue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabelTermsValue.SizeF = New System.Drawing.SizeF(462.0!, 83.0!)
        Me.xrLabelTermsValue.Text = "xrlabeltermsvalue"
        Me.xrLabelTermsValue.Visible = False
        '
        'xrLabelOtherDetails
        '
        Me.xrLabelOtherDetails.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabelOtherDetails.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 40.0!)
        Me.xrLabelOtherDetails.Name = "xrLabelOtherDetails"
        Me.xrLabelOtherDetails.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabelOtherDetails.SizeF = New System.Drawing.SizeF(66.0!, 83.0!)
        Me.xrLabelOtherDetails.StylePriority.UseFont = False
        Me.xrLabelOtherDetails.StylePriority.UseTextAlignment = False
        Me.xrLabelOtherDetails.Text = "Other Details :"
        Me.xrLabelOtherDetails.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.xrLabelOtherDetails.Visible = False
        '
        'xrLabelOtherDetailsValue
        '
        Me.xrLabelOtherDetailsValue.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingReport.Bank Details")})
        Me.xrLabelOtherDetailsValue.LocationFloat = New DevExpress.Utils.PointFloat(95.0!, 19.0!)
        Me.xrLabelOtherDetailsValue.Name = "xrLabelOtherDetailsValue"
        Me.xrLabelOtherDetailsValue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabelOtherDetailsValue.SizeF = New System.Drawing.SizeF(462.0!, 83.0!)
        Me.xrLabelOtherDetailsValue.Text = "xrlabelotherdetailsvalue"
        Me.xrLabelOtherDetailsValue.Visible = False
        '
        'xrLine6
        '
        Me.xrLine6.LocationFloat = New DevExpress.Utils.PointFloat(538.0!, 69.0!)
        Me.xrLine6.Name = "xrLine6"
        Me.xrLine6.SizeF = New System.Drawing.SizeF(196.0!, 8.0!)
        Me.xrLine6.Visible = False
        '
        'xrLabel22
        '
        Me.xrLabel22.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(538.0!, 35.0!)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.SizeF = New System.Drawing.SizeF(78.0!, 17.0!)
        Me.xrLabel22.StylePriority.UseFont = False
        Me.xrLabel22.StylePriority.UseTextAlignment = False
        Me.xrLabel22.Text = "Tax 1 :"
        Me.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel22.Visible = False
        '
        'xrLabel24
        '
        Me.xrLabel24.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(538.0!, 18.0!)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.SizeF = New System.Drawing.SizeF(78.0!, 17.0!)
        Me.xrLabel24.StylePriority.UseFont = False
        Me.xrLabel24.StylePriority.UseTextAlignment = False
        Me.xrLabel24.Text = "Sub Total :"
        Me.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel21
        '
        Me.xrLabel21.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(538.0!, 52.0!)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.SizeF = New System.Drawing.SizeF(78.0!, 17.0!)
        Me.xrLabel21.StylePriority.UseFont = False
        Me.xrLabel21.StylePriority.UseTextAlignment = False
        Me.xrLabel21.Text = "Tax 2 :"
        Me.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel21.Visible = False
        '
        'xrLabel20
        '
        Me.xrLabel20.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(538.0!, 77.0!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(78.0!, 17.0!)
        Me.xrLabel20.StylePriority.UseFont = False
        Me.xrLabel20.StylePriority.UseTextAlignment = False
        Me.xrLabel20.Text = "Grand Total :"
        Me.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel20.Visible = False
        '
        'ctlBillHours
        '
        Me.ctlBillHours.DataMember = "AccountTimeExpenseBillingReport"
        Me.ctlBillHours.DataSource = Me.accountTimeExpenseBillingReport1
        Me.ctlBillHours.DisplayName = "ctlBillHours"
        Me.ctlBillHours.Expression = "Iif(IsNull([BillHours]) or  [BillHours] = 0, '0:00', [BillHours] + ':00'  )"
        Me.ctlBillHours.Name = "ctlBillHours"
        '
        'ctlInvoiceNo
        '
        Me.ctlInvoiceNo.DataMember = "AccountTimeExpenseBillingReport"
        Me.ctlInvoiceNo.DataSource = Me.accountTimeExpenseBillingReport1
        Me.ctlInvoiceNo.DisplayName = "ctlInvoiceNo"
        Me.ctlInvoiceNo.Name = "ctlInvoiceNo"
        '
        'cltTotalAmount
        '
        Me.cltTotalAmount.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltTotalAmount.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltTotalAmount.DisplayName = "cltTotalAmount"
        Me.cltTotalAmount.Expression = "[CurrencyCode] + ' ' + [TotalAmount!#.000]"
        Me.cltTotalAmount.Name = "cltTotalAmount"
        '
        'cltSubTotal
        '
        Me.cltSubTotal.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltSubTotal.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltSubTotal.DisplayName = "cltSubTotal"
        Me.cltSubTotal.Expression = "[CurrencyCode] + ' ' + [SubTotal]"
        Me.cltSubTotal.Name = "cltSubTotal"
        '
        'cltTaxCode1
        '
        Me.cltTaxCode1.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltTaxCode1.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltTaxCode1.DisplayName = "cltTaxCode1"
        Me.cltTaxCode1.Expression = "[CurrencyCode] + ' ' + [TaxCode1]"
        Me.cltTaxCode1.Name = "cltTaxCode1"
        '
        'cltTaxCode2
        '
        Me.cltTaxCode2.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltTaxCode2.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltTaxCode2.DisplayName = "cltTaxCode2"
        Me.cltTaxCode2.Expression = "[CurrencyCode] + ' ' + [TaxCode2]"
        Me.cltTaxCode2.Name = "cltTaxCode2"
        '
        'cltGrandTotal
        '
        Me.cltGrandTotal.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltGrandTotal.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltGrandTotal.DisplayName = "cltGrandTotal"
        Me.cltGrandTotal.Expression = "[CurrencyCode] + ' ' + [GrandTotal]"
        Me.cltGrandTotal.Name = "cltGrandTotal"
        '
        'cltCity
        '
        Me.cltCity.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltCity.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltCity.DisplayName = "cltCity"
        Me.cltCity.Expression = "[City] + ' ' + [State] + ' ' + [ZipCode]"
        Me.cltCity.Name = "cltCity"
        '
        'cltClientCity
        '
        Me.cltClientCity.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltClientCity.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltClientCity.DisplayName = "cltClientCity"
        Me.cltClientCity.Expression = "[ClientCity] + ' ' + [ClientState] + ' ' + [ClientZipcode]"
        Me.cltClientCity.Name = "cltClientCity"
        '
        'cltBillingAddress
        '
        Me.cltBillingAddress.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltBillingAddress.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltBillingAddress.Expression = "[Address1] + [Address2]"
        Me.cltBillingAddress.Name = "cltBillingAddress"
        '
        'cltAccountAddress
        '
        Me.cltAccountAddress.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltAccountAddress.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltAccountAddress.DisplayName = "cltAccountAddress"
        Me.cltAccountAddress.Expression = "[AccountAddress1] + [AccountAddress2]"
        Me.cltAccountAddress.Name = "cltAccountAddress"
        '
        'cltBillingCountry
        '
        Me.cltBillingCountry.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltBillingCountry.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltBillingCountry.Expression = "[ClientCountry] + [ClientTelephone]"
        Me.cltBillingCountry.Name = "cltBillingCountry"
        '
        'cltAccountCountry
        '
        Me.cltAccountCountry.DataMember = "AccountTimeExpenseBillingReport"
        Me.cltAccountCountry.DataSource = Me.accountTimeExpenseBillingReport1
        Me.cltAccountCountry.Expression = "[AccountCountry] + [Telephone]"
        Me.cltAccountCountry.Name = "cltAccountCountry"
        '
        'topMarginBand1
        '
        Me.topMarginBand1.HeightF = 23.0!
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.HeightF = 33.0!
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'xrControlStyle1
        '
        Me.xrControlStyle1.Name = "xrControlStyle1"
        Me.xrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        '
        'xrControlStyle2
        '
        Me.xrControlStyle2.Name = "xrControlStyle2"
        Me.xrControlStyle2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        '
        'ctlProjectName
        '
        Me.ctlProjectName.DataMember = "AccountTimeExpenseBillingReport"
        Me.ctlProjectName.DataSource = Me.accountTimeExpenseBillingReport1
        Me.ctlProjectName.Expression = "Iif(IsNull([MasterProjectName]) or  [MasterProjectName] = 0, ' ', 'RE:' + ' ' + [" & _
    "MasterProjectName])"
        Me.ctlProjectName.Name = "ctlProjectName"
        '
        'ctlDateFooter
        '
        Me.ctlDateFooter.DataMember = "AccountTimeExpenseBillingReport"
        Me.ctlDateFooter.DataSource = Me.accountTimeExpenseBillingReport1
        Me.ctlDateFooter.Expression = "'From' + ' ' + [BillingCycleStartDate] + ' ' + 'To' + ' ' + [BillingCycleEndDate]" & _
    ""
        Me.ctlDateFooter.Name = "ctlDateFooter"
        '
        'xtrAccountTimeExpenseBillingReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter, Me.GroupHeader1, Me.GroupFooter1, Me.GroupFooter2, Me.GroupFooter3, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ctlTotalAmount, Me.ctlBillHours, Me.ctlInvoiceNo, Me.cltTotalAmount, Me.cltSubTotal, Me.cltTaxCode1, Me.cltTaxCode2, Me.cltGrandTotal, Me.cltCity, Me.cltClientCity, Me.cltBillingAddress, Me.cltAccountAddress, Me.cltBillingCountry, Me.cltAccountCountry, Me.ctlProjectName, Me.ctlDateFooter})
        Me.DataAdapter = Me.accountTimeExpenseBillingReportTableAdapter1
        Me.DataMember = "AccountTimeExpenseBillingReport"
        Me.DataSource = Me.accountTimeExpenseBillingReport1
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.formattingRule1})
        Me.Margins = New System.Drawing.Printing.Margins(51, 36, 23, 33)
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.ScriptsSource = resources.GetString("$this.ScriptsSource")
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.xtrEvenRow, Me.xtrOddRow, Me.DataField, Me.FieldCaption, Me.PageInfo, Me.Title, Me.xrControlStyle1, Me.xrControlStyle2})
        Me.Version = "11.1"
        Me.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart
        CType(Me.accountTimeExpenseBillingReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xtraReport11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xtraReport12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xtraReport13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xtrTaskSummaryReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.subTimeBillingExpenseReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repProjectSummaryExpenseReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand

#End Region

    Private Sub Detail_AfterPrint(sender As Object, e As System.EventArgs) Handles Detail.AfterPrint

    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        If LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And Not LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel18.Visible = False
            xrLabel34.Visible = False
            Me.xrLabel1.Location = New System.Drawing.Point(9, 0.0)
            Me.xrLabel1.Size = New System.Drawing.Size(425.7083, 25)
        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel2.Visible = False
            Me.xrLabel1.Location = New System.Drawing.Point(190.25, 0.0)
            Me.xrLabel1.Size = New System.Drawing.Size(325.75, 25.0)
            xrLabel34.Visible = False
        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And Not LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel18.Visible = False
            Me.xrLabel2.Visible = False
            xrLabel34.Visible = False
            Me.xrLabel1.Location = New System.Drawing.Point(9, 0.0)
            Me.xrLabel1.Size = New System.Drawing.Size(507, 25)
        End If
        If LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel34.Visible = False
            Me.xrLabel18.Location = New System.Drawing.Point(9, 0.0)
            Me.xrLabel18.Size = New System.Drawing.Size(181.0, 25.0)

            Me.xrLabel1.Location = New System.Drawing.Point(190.0!, 0.0!)
            Me.xrLabel1.Size = New System.Drawing.Size(226.0!, 25.0!)
        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel34.Visible = False
            Me.xrLabel2.Visible = False

            Me.xrLabel18.Location = New System.Drawing.Point(9.0!, 0.0!)
            Me.xrLabel18.Size = New System.Drawing.Size(181.0!, 25.0!)
        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel2.Visible = False

            Me.xrLabel1.Location = New System.Drawing.Point(190.0!, 0.0!)
            Me.xrLabel1.Size = New System.Drawing.Size(326.0!, 25.0!)
        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And Not LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel2.Visible = False
            Me.xrLabel18.Visible = False

            Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(90.0!, 0.0!)
            Me.xrLabel1.SizeF = New System.Drawing.SizeF(425.7083!, 25.0!)
        End If
        If LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And Not LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel18.Visible = False

            Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(90.0!, 0.0!)
            Me.xrLabel1.SizeF = New System.Drawing.SizeF(325.7083!, 25.0!)
        End If
        If DBUtilities.IsInvoiceBillingTypeDaily Then
            Me.xrLabel3.Text = CType(GetCurrentColumnValue("BillHours"), Double) / DBUtilities.GetHoursPerDay
            xrLabel2.Text = ResourceHelper.GetFromResource(CType(GetCurrentColumnValue("CurrencyCode"), String)) + " " + CStr(CType(GetCurrentColumnValue("ActualBillingRate"), Double) * DBUtilities.GetHoursPerDay)
            TotalBillHoursInReport += Me.xrLabel3.Text
        Else
            Me.xrLabel3.Text = CType(GetCurrentColumnValue("BillHours"), Double)
            xrLabel2.Text = ResourceHelper.GetFromResource(CType(GetCurrentColumnValue("CurrencyCode"), String)) + " " + CStr(CType(GetCurrentColumnValue("ActualBillingRate"), Double))
            TotalBillHoursInReport += Me.xrLabel3.Text
        End If
        Me.xrLabel42.Text = ResourceHelper.GetFromResource(xrLabel42.Text, )
        ''Me.xrLabel34.Text = LocaleUtilitiesBLL.ConvertDateBaseToCurrentLocaleAsString(CType(GetCurrentColumnValue("TimeEntryDate"), String))
    End Sub
    Public Function IsLogoFileExist() As Boolean

    End Function
    Private Sub xtrAccountTimeExpenseBillingReport2_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Me.xrLabel31.Text = ResourceHelper.GetFromResource("Billing Address :")
        Me.xrLabel30.Text = ResourceHelper.GetFromResource("Invoice No.")
        Me.xrLabel6.Text = ResourceHelper.GetFromResource("Invoice Date:")
        Me.xrLabel7.Text = ResourceHelper.GetFromResource("PO Number:")
        'Me.xrLabel8.Text = Resources.TimeLive.Resource.Bill_Date__
        Me.xrLabel12.Text = ResourceHelper.GetFromResource("Timesheet Description")
        Me.xrLabel14.Text = ResourceHelper.GetFromResource("Amount")
        If DBUtilities.IsInvoiceBillingTypeDaily Then
            Me.xrLabel5.Text = ResourceHelper.GetFromResource("Day Rate")
            Me.xrLabel13.Text = ResourceHelper.GetFromResource("Days")
        Else
            Me.xrLabel5.Text = ResourceHelper.GetFromResource("Billing Rate")
            Me.xrLabel13.Text = ResourceHelper.GetFromResource("Bill Hours")
        End If
        Me.xrLabel27.Text = ResourceHelper.GetFromResource("Total:")
        Me.xrLabel29.Text = ResourceHelper.GetFromResource("Notes:")
        Me.xrLabel20.Text = ResourceHelper.GetFromResource("Grand Total:")
        Me.xrLabel21.Text = ResourceHelper.GetFromResource("Tax 2:")
        Me.xrLabel22.Text = ResourceHelper.GetFromResource("Tax 1:")
        Me.xrLabel24.Text = ResourceHelper.GetFromResource("Sub Total:")

    End Sub

    Private Sub GroupHeader1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeader1.BeforePrint
        If LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And Not LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel17.Visible = False
            Me.xrLabelEntryDate.Visible = False
            Me.xrLabel12.Location = New System.Drawing.Point(9, 218.125)
            Me.xrLabel12.Size = New System.Drawing.Size(408.71, 32.0)
        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel5.Visible = False
            Me.xrLabelEntryDate.Visible = False
            Me.xrLabel12.Location = New System.Drawing.Point(190.25, 218.125)
            Me.xrLabel12.Size = New System.Drawing.Size(325.75, 32.0)
        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And Not LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel5.Visible = False
            Me.xrLabel17.Visible = False
            Me.xrLabelEntryDate.Visible = False
            Me.xrLabel12.Location = New System.Drawing.Point(9, 218.125)
            Me.xrLabel12.Size = New System.Drawing.Size(507, 32.0)
        End If
        If LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabelEntryDate.Visible = False
            Me.xrLabel17.Location = New System.Drawing.Point(9, 218.125)
            Me.xrLabel17.Size = New System.Drawing.Size(181.0, 32.0)

            Me.xrLabel12.Location = New System.Drawing.Point(190.0001, 218.125)
            Me.xrLabel12.Size = New System.Drawing.Size(226.0!, 32.0!)
        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And Not DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel5.Visible = False
            Me.xrLabelEntryDate.Visible = False

            Me.xrLabel17.Location = New System.Drawing.Point(9.000079!, 218.125!)
            Me.xrLabel17.Size = New System.Drawing.Size(181.0!, 32.0!)
        End If
        If LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And Not LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel17.Visible = False

            Me.xrLabel12.Location = New System.Drawing.Point(90.00001!, 218.125!)
            Me.xrLabel12.Size = New System.Drawing.Size(325.7083!, 32.0!)

        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel5.Visible = False

            Me.xrLabel12.Location = New System.Drawing.Point(190.0!, 218.125!)
            Me.xrLabel12.Size = New System.Drawing.Size(326.0!, 32.0!)
        End If
        If Not LocaleUtilitiesBLL.ShowBillingRateInInvoiceReport And Not LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport And DBUtilities.ShowEntryDateInInvoiceReport Then
            Me.xrLabel17.Visible = False
            Me.xrLabel5.Visible = False

            Me.xrLabel12.Size = New System.Drawing.Size(425.7083!, 32.0!)
            Me.xrLabel12.Location = New System.Drawing.Point(90.00001!, 218.125!)
        End If
    End Sub
    Public Sub AddTaxLabel(LabelName As String, LabelText As String, x As Integer, y As Integer)
        xrLabel = New DevExpress.XtraReports.UI.XRLabel
        With xrLabel
            .Font = New System.Drawing.Font("Verdana", 7.25, System.Drawing.FontStyle.Bold)
            .Location = New System.Drawing.Point(x, y)
            '.Location = New System.Drawing.Point(538, 35)
            .Name = LabelName
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100)
            .Size = New System.Drawing.Size(78, 17)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Text = LabelText
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        End With
        GroupFooter3.Controls.Add(xrLabel)
    End Sub
    Public Sub AddTaxValue(LabelName As String, LabelText As String, x As Integer, y As Integer)
        xrLabel = New DevExpress.XtraReports.UI.XRLabel
        With xrLabel
            .Font = New System.Drawing.Font("Verdana", 7.75, System.Drawing.FontStyle.Bold)
            .Location = New System.Drawing.Point(x, y)
            .Name = LabelName
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100)
            .Size = New System.Drawing.Size(118, 17)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Text = LabelText
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        End With
        GroupFooter3.Controls.Add(xrLabel)
    End Sub
    Public Sub AddLine(LineName As String, x As Integer, y As Integer)
        xrLine = New DevExpress.XtraReports.UI.XRLine
        With xrLine
            .Location = New System.Drawing.Point(x, y)
            .Name = LineName
            .Size = New System.Drawing.Size(196, 8)
            .LineWidth = 1
        End With
        GroupFooter3.Controls.Add(xrLine)
    End Sub
    Private Sub GroupFooter3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooter3.BeforePrint
        Dim AccountTimeExpenseBillingId As New Guid(CType(GetCurrentColumnValue("AccountTimeExpenseBillingId"), Guid).ToString)
        Dim dt As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingTimesheetTaxDataTable = New AccountTimeExpenseBillingTimesheetTaxTableAdapter().GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)
        Dim dr As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingTimesheetTaxRow
        Dim dtExpense As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingExpenseTaxDataTable = New AccountTimeExpenseBillingExpenseTaxTableAdapter().GetDataByAccountTimeExpenseBillingId(AccountTimeExpenseBillingId)
        Dim drExpense As AccountTimeExpenseBillingReport.AccountTimeExpenseBillingExpenseTaxRow

        Dim TaxArray As New Hashtable
        Dim TC As Double
        Dim TTC As Double
        If dt.Rows.Count > 0 Then
            For Each dr In dt.Rows
                If Not IsDBNull(dr.Item("AccountTaxCodeId1")) Then
                    If TaxArray.Contains(dr.TaxCodeName1) Then
                        TC = TaxArray.Item(dr.TaxCodeName1)
                        TTC = TC + dr.TaxCode1
                        TaxArray.Item(dr.TaxCodeName1) = TTC
                        TC = 0
                        TTC = 0
                    Else
                        TaxArray.Add(dr.TaxCodeName1, dr.TaxCode1)
                    End If
                End If
                If Not IsDBNull(dr.Item("AccountTaxCodeId2")) Then
                    If TaxArray.Contains(dr.TaxCodeName2) Then
                        TC = TaxArray.Item(dr.TaxCodeName2)
                        TTC = TC + dr.TaxCode2
                        TaxArray.Item(dr.TaxCodeName2) = TTC
                        TC = 0
                        TTC = 0
                    Else
                        TaxArray.Add(dr.TaxCodeName2, dr.TaxCode2)
                    End If
                End If
            Next
        End If
        If dtExpense.Rows.Count > 0 Then
            For Each drExpense In dtExpense.Rows
                If Not IsDBNull(drExpense.Item("AccountTaxCodeId1")) Then
                    If TaxArray.Contains(drExpense.TaxCodeName1) Then
                        TC = TaxArray.Item(drExpense.TaxCodeName1)
                        TTC = TC + drExpense.TaxCode1
                        TaxArray.Item(drExpense.TaxCodeName1) = TTC
                        TC = 0
                        TTC = 0
                    Else
                        TaxArray.Add(drExpense.TaxCodeName1, drExpense.TaxCode1)
                    End If
                End If
                If Not IsDBNull(drExpense.Item("AccountTaxCodeId2")) Then
                    If TaxArray.Contains(drExpense.TaxCodeName2) Then
                        TC = TaxArray.Item(drExpense.TaxCodeName2)
                        TTC = TC + drExpense.TaxCode2
                        TaxArray.Item(drExpense.TaxCodeName2) = TTC
                        TC = 0
                        TTC = 0
                    Else
                        TaxArray.Add(drExpense.TaxCodeName2, drExpense.TaxCode2)
                    End If
                End If
            Next
        End If
        Dim y As Integer = 35
        For i As Integer = 0 To TaxArray.Count - 1
            '.Location = New System.Drawing.Point(538, 35)
            AddTaxLabel("hlbl" & TaxArray.Keys(i), TaxArray.Keys(i) + ":", 538, y)
            AddTaxValue("lbl" & TaxArray.Keys(i), ResourceHelper.GetFromResource(CType(GetCurrentColumnValue("CurrencyCode"), String), ) + " " + String.Format("{0:n2}", TaxArray.Values(i)), 616, y)
            y += 17
        Next
        AddLine("line1g", 538, y)
        y += 17 - 9
        AddTaxLabel("hlblGrandTotal", "Grand Total:", 538, y)
        AddTaxValue("lblGrandTotalValue", ResourceHelper.GetFromResource(CType(GetCurrentColumnValue("CurrencyCode"), String), ) + " " + String.Format("{0:n2}", CType(GetCurrentColumnValue("GrandTotal"), Double)), 616, y)
        y += 17
        AddLine("line2g", 538, y)
        y += 17
        Me.xrLabel28.Location = New System.Drawing.Point(9, 30)
        Me.xrLabel44.Text = ResourceHelper.GetFromResource(xrLabel44.Text, )
    End Sub
    Private Sub GroupFooter2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooter2.BeforePrint
        If DBUtilities.IsInvoiceBillingTypeDaily Then
            xrLabel9.Text = TotalBillHoursInReport
        Else
            xrLabel9.Text = TotalBillHoursInReport
        End If
        Me.xrLabel26.Text = ResourceHelper.GetFromResource(xrLabel26.Text, )
    End Sub

    Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        'Me.xrLabel28.Location = New System.Drawing.Point(616, 9)
    End Sub
End Class