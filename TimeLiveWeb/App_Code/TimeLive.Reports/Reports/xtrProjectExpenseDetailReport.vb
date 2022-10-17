Public Class xtrProjectExpenseDetailReport
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
    Private WithEvents dsProjectExpenseDetailReport1 As dsProjectExpenseDetailReport
    Private WithEvents vueAccountExpenseEntryTableAdapter1 As dsProjectExpenseDetailReportTableAdapters.vueAccountExpenseEntryTableAdapter
    Private WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents GroupHeader2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblDetailCurrency As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents lblGroupNetAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblGroupTaxAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblGroupAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents lblGrandNetAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblGrandTaxAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblGrandAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine4 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblGroupCurrency As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblGrandCurrency As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents cltfldSubmitted As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblNetAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblTaxAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblExchangeRate As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrProjectExpenseDetailReport.resx"
        Dim resources As System.Resources.ResourceManager = Global.Resources.xtrProjectExpenseDetailReport.ResourceManager
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.dsProjectExpenseDetailReport1 = New dsProjectExpenseDetailReport
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.lblTaxAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.lblAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.lblExchangeRate = New DevExpress.XtraReports.UI.XRLabel
        Me.lblNetAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.lblDetailCurrency = New DevExpress.XtraReports.UI.XRLabel
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.vueAccountExpenseEntryTableAdapter1 = New dsProjectExpenseDetailReportTableAdapters.vueAccountExpenseEntryTableAdapter
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.GroupHeader2 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.lblGroupCurrency = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel28 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.lblGroupAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.lblGroupTaxAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.lblGroupNetAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand
        Me.lblGrandCurrency = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel29 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLine4 = New DevExpress.XtraReports.UI.XRLine
        Me.lblGrandAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.lblGrandTaxAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.lblGrandNetAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.cltfldSubmitted = New DevExpress.XtraReports.UI.CalculatedField
        CType(Me.dsProjectExpenseDetailReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel18, Me.xrLabel17, Me.xrLabel16, Me.lblTaxAmount, Me.lblAmount, Me.lblExchangeRate, Me.lblNetAmount, Me.xrLabel27, Me.xrLabel11, Me.xrLabel12, Me.xrLabel13, Me.xrLabel14, Me.lblDetailCurrency})
        Me.Detail.Height = 25
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.Scripts.OnBeforePrint = resources.GetString("Detail.Scripts.OnBeforePrint")
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsProjectExpenseDetailReport1, "vueAccountExpenseEntry.Amount", "{0:n2}")})
        Me.xrLabel18.EvenStyleName = "xtrEvenRow"
        Me.xrLabel18.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel18.Location = New System.Drawing.Point(700, 0)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.OddStyleName = "xtrOddRow"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.Size = New System.Drawing.Size(92, 25)
        Me.xrLabel18.StylePriority.UseFont = False
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        Me.xrLabel18.Text = "xrLabel18"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel18.Visible = False
        '
        'dsProjectExpenseDetailReport1
        '
        Me.dsProjectExpenseDetailReport1.DataSetName = "dsProjectExpenseDetailReport"
        Me.dsProjectExpenseDetailReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsProjectExpenseDetailReport1, "vueAccountExpenseEntry.TaxAmount", "{0:n2}")})
        Me.xrLabel17.EvenStyleName = "xtrEvenRow"
        Me.xrLabel17.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel17.Location = New System.Drawing.Point(642, 0)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.OddStyleName = "xtrOddRow"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.Size = New System.Drawing.Size(58, 25)
        Me.xrLabel17.StylePriority.UseFont = False
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.Text = "xrLabel17"
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel17.Visible = False
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsProjectExpenseDetailReport1, "vueAccountExpenseEntry.NetAmount", "{0:n2}")})
        Me.xrLabel16.EvenStyleName = "xtrEvenRow"
        Me.xrLabel16.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel16.Location = New System.Drawing.Point(567, 0)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.OddStyleName = "xtrOddRow"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.Size = New System.Drawing.Size(75, 25)
        Me.xrLabel16.StylePriority.UseFont = False
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel16.Visible = False
        '
        'lblTaxAmount
        '
        Me.lblTaxAmount.EvenStyleName = "xtrEvenRow"
        Me.lblTaxAmount.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.lblTaxAmount.Location = New System.Drawing.Point(642, 0)
        Me.lblTaxAmount.Name = "lblTaxAmount"
        Me.lblTaxAmount.OddStyleName = "xtrOddRow"
        Me.lblTaxAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTaxAmount.Size = New System.Drawing.Size(58, 25)
        Me.lblTaxAmount.StylePriority.UseFont = False
        Me.lblTaxAmount.StylePriority.UseTextAlignment = False
        Me.lblTaxAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblAmount
        '
        Me.lblAmount.EvenStyleName = "xtrEvenRow"
        Me.lblAmount.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.lblAmount.Location = New System.Drawing.Point(700, 0)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.OddStyleName = "xtrOddRow"
        Me.lblAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount.Size = New System.Drawing.Size(92, 25)
        Me.lblAmount.StylePriority.UseFont = False
        Me.lblAmount.StylePriority.UseTextAlignment = False
        Me.lblAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblExchangeRate
        '
        Me.lblExchangeRate.EvenStyleName = "xtrEvenRow"
        Me.lblExchangeRate.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.lblExchangeRate.Location = New System.Drawing.Point(642, 0)
        Me.lblExchangeRate.Name = "lblExchangeRate"
        Me.lblExchangeRate.OddStyleName = "xtrOddRow"
        Me.lblExchangeRate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblExchangeRate.Size = New System.Drawing.Size(58, 25)
        Me.lblExchangeRate.StylePriority.UseFont = False
        Me.lblExchangeRate.StylePriority.UseTextAlignment = False
        Me.lblExchangeRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblExchangeRate.Visible = False
        '
        'lblNetAmount
        '
        Me.lblNetAmount.EvenStyleName = "xtrEvenRow"
        Me.lblNetAmount.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.lblNetAmount.Location = New System.Drawing.Point(567, 0)
        Me.lblNetAmount.Name = "lblNetAmount"
        Me.lblNetAmount.OddStyleName = "xtrOddRow"
        Me.lblNetAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNetAmount.Size = New System.Drawing.Size(75, 25)
        Me.lblNetAmount.StylePriority.UseFont = False
        Me.lblNetAmount.StylePriority.UseTextAlignment = False
        Me.lblNetAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel27
        '
        Me.xrLabel27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.cltfldSubmitted", "")})
        Me.xrLabel27.EvenStyleName = "xtrEvenRow"
        Me.xrLabel27.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel27.Location = New System.Drawing.Point(442, 0)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.OddStyleName = "xtrOddRow"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.Size = New System.Drawing.Size(67, 25)
        Me.xrLabel27.StylePriority.UseFont = False
        Me.xrLabel27.StylePriority.UseTextAlignment = False
        Me.xrLabel27.Text = "xrLabel27"
        Me.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel11
        '
        Me.xrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsProjectExpenseDetailReport1, "vueAccountExpenseEntry.AccountExpenseEntryDate", "{0:d}")})
        Me.xrLabel11.EvenStyleName = "xtrEvenRow"
        Me.xrLabel11.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel11.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.OddStyleName = "xtrOddRow"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.Size = New System.Drawing.Size(75, 25)
        Me.xrLabel11.StylePriority.UseFont = False
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "xrLabel11"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsProjectExpenseDetailReport1, "vueAccountExpenseEntry.ExpenseType", "")})
        Me.xrLabel12.EvenStyleName = "xtrEvenRow"
        Me.xrLabel12.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel12.Location = New System.Drawing.Point(83, 0)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.OddStyleName = "xtrOddRow"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.Size = New System.Drawing.Size(100, 25)
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "xrLabel12"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsProjectExpenseDetailReport1, "vueAccountExpenseEntry.AccountExpenseName", "")})
        Me.xrLabel13.EvenStyleName = "xtrEvenRow"
        Me.xrLabel13.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel13.Location = New System.Drawing.Point(183, 0)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.OddStyleName = "xtrOddRow"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.Size = New System.Drawing.Size(108, 25)
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "xrLabel13"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsProjectExpenseDetailReport1, "vueAccountExpenseEntry.Description", "")})
        Me.xrLabel14.EvenStyleName = "xtrEvenRow"
        Me.xrLabel14.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel14.Location = New System.Drawing.Point(291, 0)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.OddStyleName = "xtrOddRow"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.Size = New System.Drawing.Size(151, 25)
        Me.xrLabel14.StylePriority.UseFont = False
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.Text = "xrLabel14"
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblDetailCurrency
        '
        Me.lblDetailCurrency.EvenStyleName = "xtrEvenRow"
        Me.lblDetailCurrency.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.lblDetailCurrency.Location = New System.Drawing.Point(509, 0)
        Me.lblDetailCurrency.Name = "lblDetailCurrency"
        Me.lblDetailCurrency.OddStyleName = "xtrOddRow"
        Me.lblDetailCurrency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDetailCurrency.Size = New System.Drawing.Size(58, 25)
        Me.lblDetailCurrency.StylePriority.UseFont = False
        Me.lblDetailCurrency.StylePriority.UseTextAlignment = False
        Me.lblDetailCurrency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine3, Me.xrPageInfo1, Me.xrPageInfo2})
        Me.PageFooter.Height = 49
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLine3
        '
        Me.xrLine3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xrLine3.Location = New System.Drawing.Point(8, 1)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.Size = New System.Drawing.Size(783, 8)
        Me.xrLine3.StylePriority.UseForeColor = False
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo1.Location = New System.Drawing.Point(8, 10)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.Size = New System.Drawing.Size(233, 25)
        Me.xrPageInfo1.StylePriority.UseFont = False
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.Location = New System.Drawing.Point(675, 10)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.Size = New System.Drawing.Size(117, 25)
        Me.xrPageInfo2.StylePriority.UseFont = False
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'vueAccountExpenseEntryTableAdapter1
        '
        Me.vueAccountExpenseEntryTableAdapter1.ClearBeforeFill = True
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel20})
        Me.ReportHeader.Height = 32
        Me.ReportHeader.Name = "ReportHeader"
        '
        'xrLabel20
        '
        Me.xrLabel20.BackColor = System.Drawing.Color.Silver
        Me.xrLabel20.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel20.ForeColor = System.Drawing.Color.Black
        Me.xrLabel20.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.Size = New System.Drawing.Size(783, 21)
        Me.xrLabel20.StylePriority.UseBackColor = False
        Me.xrLabel20.StylePriority.UseFont = False
        Me.xrLabel20.StylePriority.UseForeColor = False
        Me.xrLabel20.Text = "Project Expense Detail Report"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel19, Me.xrLabel8, Me.xrLabel10, Me.xrLabel9, Me.xrLabel7, Me.xrLabel6, Me.xrLabel1, Me.xrLabel2, Me.xrLabel3, Me.xrLabel4, Me.xrLabel5})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("EmployeeName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.Height = 53
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.Scripts.OnBeforePrint = resources.GetString("GroupHeader1.Scripts.OnBeforePrint")
        '
        'xrLabel19
        '
        Me.xrLabel19.BackColor = System.Drawing.Color.Silver
        Me.xrLabel19.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel19.CanGrow = False
        Me.xrLabel19.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel19.ForeColor = System.Drawing.Color.Black
        Me.xrLabel19.Location = New System.Drawing.Point(442, 25)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.Size = New System.Drawing.Size(67, 28)
        Me.xrLabel19.StylePriority.UseBackColor = False
        Me.xrLabel19.StylePriority.UseBorders = False
        Me.xrLabel19.StylePriority.UseFont = False
        Me.xrLabel19.StylePriority.UseForeColor = False
        Me.xrLabel19.StylePriority.UseTextAlignment = False
        Me.xrLabel19.Text = "Submitted"
        Me.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel19.WordWrap = False
        '
        'xrLabel8
        '
        Me.xrLabel8.BackColor = System.Drawing.Color.Silver
        Me.xrLabel8.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel8.CanGrow = False
        Me.xrLabel8.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel8.ForeColor = System.Drawing.Color.Black
        Me.xrLabel8.Location = New System.Drawing.Point(567, 25)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.Size = New System.Drawing.Size(75, 28)
        Me.xrLabel8.StylePriority.UseBackColor = False
        Me.xrLabel8.StylePriority.UseBorders = False
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.StylePriority.UseForeColor = False
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "Net Amount"
        Me.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel8.WordWrap = False
        '
        'xrLabel10
        '
        Me.xrLabel10.BackColor = System.Drawing.Color.Silver
        Me.xrLabel10.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel10.CanGrow = False
        Me.xrLabel10.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel10.ForeColor = System.Drawing.Color.Black
        Me.xrLabel10.Location = New System.Drawing.Point(700, 25)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.Size = New System.Drawing.Size(92, 28)
        Me.xrLabel10.StylePriority.UseBackColor = False
        Me.xrLabel10.StylePriority.UseBorders = False
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseForeColor = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "Amount"
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel10.WordWrap = False
        '
        'xrLabel9
        '
        Me.xrLabel9.BackColor = System.Drawing.Color.Silver
        Me.xrLabel9.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel9.CanGrow = False
        Me.xrLabel9.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel9.ForeColor = System.Drawing.Color.Black
        Me.xrLabel9.Location = New System.Drawing.Point(642, 25)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.Size = New System.Drawing.Size(58, 28)
        Me.xrLabel9.StylePriority.UseBackColor = False
        Me.xrLabel9.StylePriority.UseBorders = False
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseForeColor = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "Tax"
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel9.WordWrap = False
        '
        'xrLabel7
        '
        Me.xrLabel7.BackColor = System.Drawing.Color.Silver
        Me.xrLabel7.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel7.CanGrow = False
        Me.xrLabel7.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel7.ForeColor = System.Drawing.Color.Black
        Me.xrLabel7.Location = New System.Drawing.Point(509, 25)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.Size = New System.Drawing.Size(58, 28)
        Me.xrLabel7.StylePriority.UseBackColor = False
        Me.xrLabel7.StylePriority.UseBorders = False
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseForeColor = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "Currency"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel7.WordWrap = False
        '
        'xrLabel6
        '
        Me.xrLabel6.BackColor = System.Drawing.Color.Silver
        Me.xrLabel6.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel6.CanGrow = False
        Me.xrLabel6.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel6.ForeColor = System.Drawing.Color.Black
        Me.xrLabel6.Location = New System.Drawing.Point(291, 25)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.Size = New System.Drawing.Size(151, 28)
        Me.xrLabel6.StylePriority.UseBackColor = False
        Me.xrLabel6.StylePriority.UseBorders = False
        Me.xrLabel6.StylePriority.UseFont = False
        Me.xrLabel6.StylePriority.UseForeColor = False
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "Description"
        Me.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel6.WordWrap = False
        '
        'xrLabel1
        '
        Me.xrLabel1.BackColor = System.Drawing.Color.White
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.ForeColor = System.Drawing.Color.Black
        Me.xrLabel1.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(108, 17)
        Me.xrLabel1.StylePriority.UseBackColor = False
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseForeColor = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "Employee Name :"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsProjectExpenseDetailReport1, "vueAccountExpenseEntry.EmployeeName", "")})
        Me.xrLabel2.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel2.Location = New System.Drawing.Point(117, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(675, 17)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.Text = "xrLabel2"
        Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel3
        '
        Me.xrLabel3.BackColor = System.Drawing.Color.Silver
        Me.xrLabel3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel3.CanGrow = False
        Me.xrLabel3.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel3.ForeColor = System.Drawing.Color.Black
        Me.xrLabel3.Location = New System.Drawing.Point(8, 25)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.Size = New System.Drawing.Size(75, 28)
        Me.xrLabel3.StylePriority.UseBackColor = False
        Me.xrLabel3.StylePriority.UseBorders = False
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseForeColor = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "Date"
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel3.WordWrap = False
        '
        'xrLabel4
        '
        Me.xrLabel4.BackColor = System.Drawing.Color.Silver
        Me.xrLabel4.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel4.CanGrow = False
        Me.xrLabel4.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel4.ForeColor = System.Drawing.Color.Black
        Me.xrLabel4.Location = New System.Drawing.Point(83, 25)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(100, 28)
        Me.xrLabel4.StylePriority.UseBackColor = False
        Me.xrLabel4.StylePriority.UseBorders = False
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseForeColor = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.Text = "Expense Type"
        Me.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel4.WordWrap = False
        '
        'xrLabel5
        '
        Me.xrLabel5.BackColor = System.Drawing.Color.Silver
        Me.xrLabel5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel5.CanGrow = False
        Me.xrLabel5.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel5.ForeColor = System.Drawing.Color.Black
        Me.xrLabel5.Location = New System.Drawing.Point(183, 25)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.Size = New System.Drawing.Size(108, 28)
        Me.xrLabel5.StylePriority.UseBackColor = False
        Me.xrLabel5.StylePriority.UseBorders = False
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseForeColor = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "Expense Name"
        Me.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel5.WordWrap = False
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel25, Me.xrLabel23})
        Me.GroupHeader2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ProjectName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader2.Height = 20
        Me.GroupHeader2.Level = 1
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'xrLabel25
        '
        Me.xrLabel25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsProjectExpenseDetailReport1, "vueAccountExpenseEntry.ProjectName", "")})
        Me.xrLabel25.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel25.Location = New System.Drawing.Point(117, 0)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.Size = New System.Drawing.Size(675, 17)
        Me.xrLabel25.StylePriority.UseFont = False
        Me.xrLabel25.StylePriority.UseTextAlignment = False
        Me.xrLabel25.Text = "xrLabel25"
        Me.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel23
        '
        Me.xrLabel23.BackColor = System.Drawing.Color.White
        Me.xrLabel23.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel23.ForeColor = System.Drawing.Color.Black
        Me.xrLabel23.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.Size = New System.Drawing.Size(108, 17)
        Me.xrLabel23.StylePriority.UseBackColor = False
        Me.xrLabel23.StylePriority.UseFont = False
        Me.xrLabel23.StylePriority.UseForeColor = False
        Me.xrLabel23.StylePriority.UseTextAlignment = False
        Me.xrLabel23.Text = "Project Name :"
        Me.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblGroupCurrency, Me.xrLabel28, Me.xrLine2, Me.xrLine1, Me.lblGroupAmount, Me.lblGroupTaxAmount, Me.lblGroupNetAmount})
        Me.GroupFooter1.Height = 41
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.Scripts.OnBeforePrint = "Private Sub OnBeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Print" & _
            "ing.PrintEventArgs)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "End Sub"
        '
        'lblGroupCurrency
        '
        Me.lblGroupCurrency.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupCurrency.Location = New System.Drawing.Point(509, 11)
        Me.lblGroupCurrency.Name = "lblGroupCurrency"
        Me.lblGroupCurrency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGroupCurrency.Size = New System.Drawing.Size(58, 18)
        Me.lblGroupCurrency.StylePriority.UseFont = False
        Me.lblGroupCurrency.StylePriority.UseTextAlignment = False
        Me.lblGroupCurrency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel28
        '
        Me.xrLabel28.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel28.ForeColor = System.Drawing.Color.Black
        Me.xrLabel28.Location = New System.Drawing.Point(292, 11)
        Me.xrLabel28.Name = "xrLabel28"
        Me.xrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel28.Size = New System.Drawing.Size(100, 17)
        Me.xrLabel28.StylePriority.UseFont = False
        Me.xrLabel28.StylePriority.UseForeColor = False
        Me.xrLabel28.StylePriority.UseTextAlignment = False
        Me.xrLabel28.Text = "Total :"
        Me.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLine2
        '
        Me.xrLine2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xrLine2.Location = New System.Drawing.Point(8, 30)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.Size = New System.Drawing.Size(783, 8)
        Me.xrLine2.StylePriority.UseForeColor = False
        '
        'xrLine1
        '
        Me.xrLine1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xrLine1.Location = New System.Drawing.Point(8, 0)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.Size = New System.Drawing.Size(783, 8)
        Me.xrLine1.StylePriority.UseForeColor = False
        '
        'lblGroupAmount
        '
        Me.lblGroupAmount.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupAmount.Location = New System.Drawing.Point(700, 11)
        Me.lblGroupAmount.Name = "lblGroupAmount"
        Me.lblGroupAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGroupAmount.Size = New System.Drawing.Size(92, 18)
        Me.lblGroupAmount.StylePriority.UseFont = False
        Me.lblGroupAmount.StylePriority.UseTextAlignment = False
        Me.lblGroupAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblGroupTaxAmount
        '
        Me.lblGroupTaxAmount.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupTaxAmount.Location = New System.Drawing.Point(642, 11)
        Me.lblGroupTaxAmount.Name = "lblGroupTaxAmount"
        Me.lblGroupTaxAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGroupTaxAmount.Size = New System.Drawing.Size(58, 18)
        Me.lblGroupTaxAmount.StylePriority.UseFont = False
        Me.lblGroupTaxAmount.StylePriority.UseTextAlignment = False
        Me.lblGroupTaxAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblGroupNetAmount
        '
        Me.lblGroupNetAmount.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupNetAmount.Location = New System.Drawing.Point(567, 11)
        Me.lblGroupNetAmount.Name = "lblGroupNetAmount"
        Me.lblGroupNetAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGroupNetAmount.Size = New System.Drawing.Size(75, 18)
        Me.lblGroupNetAmount.StylePriority.UseFont = False
        Me.lblGroupNetAmount.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        Me.lblGroupNetAmount.Summary = xrSummary1
        Me.lblGroupNetAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xtrEvenRow
        '
        Me.xtrEvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.xtrEvenRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.xtrEvenRow.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xtrEvenRow.BorderWidth = 1
        Me.xtrEvenRow.Name = "xtrEvenRow"
        '
        'xtrOddRow
        '
        Me.xtrOddRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.xtrOddRow.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xtrOddRow.BorderWidth = 1
        Me.xtrOddRow.Name = "xtrOddRow"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblGrandCurrency, Me.xrLabel29, Me.xrLine4, Me.lblGrandAmount, Me.lblGrandTaxAmount, Me.lblGrandNetAmount})
        Me.ReportFooter.Height = 28
        Me.ReportFooter.Name = "ReportFooter"
        '
        'lblGrandCurrency
        '
        Me.lblGrandCurrency.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandCurrency.Location = New System.Drawing.Point(509, 0)
        Me.lblGrandCurrency.Name = "lblGrandCurrency"
        Me.lblGrandCurrency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGrandCurrency.Size = New System.Drawing.Size(58, 18)
        Me.lblGrandCurrency.StylePriority.UseFont = False
        Me.lblGrandCurrency.StylePriority.UseTextAlignment = False
        Me.lblGrandCurrency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel29
        '
        Me.xrLabel29.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel29.ForeColor = System.Drawing.Color.Black
        Me.xrLabel29.Location = New System.Drawing.Point(292, 0)
        Me.xrLabel29.Name = "xrLabel29"
        Me.xrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel29.Size = New System.Drawing.Size(110, 17)
        Me.xrLabel29.StylePriority.UseFont = False
        Me.xrLabel29.StylePriority.UseForeColor = False
        Me.xrLabel29.StylePriority.UseTextAlignment = False
        Me.xrLabel29.Text = "Grand Total :"
        Me.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLine4
        '
        Me.xrLine4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xrLine4.Location = New System.Drawing.Point(8, 19)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.Size = New System.Drawing.Size(783, 8)
        Me.xrLine4.StylePriority.UseForeColor = False
        '
        'lblGrandAmount
        '
        Me.lblGrandAmount.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandAmount.Location = New System.Drawing.Point(700, 0)
        Me.lblGrandAmount.Name = "lblGrandAmount"
        Me.lblGrandAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGrandAmount.Size = New System.Drawing.Size(92, 18)
        Me.lblGrandAmount.StylePriority.UseFont = False
        Me.lblGrandAmount.StylePriority.UseTextAlignment = False
        Me.lblGrandAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblGrandTaxAmount
        '
        Me.lblGrandTaxAmount.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTaxAmount.Location = New System.Drawing.Point(642, 0)
        Me.lblGrandTaxAmount.Name = "lblGrandTaxAmount"
        Me.lblGrandTaxAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGrandTaxAmount.Size = New System.Drawing.Size(58, 18)
        Me.lblGrandTaxAmount.StylePriority.UseFont = False
        Me.lblGrandTaxAmount.StylePriority.UseTextAlignment = False
        Me.lblGrandTaxAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblGrandNetAmount
        '
        Me.lblGrandNetAmount.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandNetAmount.Location = New System.Drawing.Point(567, 0)
        Me.lblGrandNetAmount.Name = "lblGrandNetAmount"
        Me.lblGrandNetAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGrandNetAmount.Size = New System.Drawing.Size(75, 18)
        Me.lblGrandNetAmount.StylePriority.UseFont = False
        Me.lblGrandNetAmount.StylePriority.UseTextAlignment = False
        Me.lblGrandNetAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'cltfldSubmitted
        '
        Me.cltfldSubmitted.DataMember = "vueAccountExpenseEntry"
        Me.cltfldSubmitted.DataSource = Me.dsProjectExpenseDetailReport1
        Me.cltfldSubmitted.Expression = "Iif([Submitted]=True,'Yes'  ,'No' )"
        Me.cltfldSubmitted.Name = "cltfldSubmitted"
        '
        'xtrProjectExpenseDetailReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter, Me.ReportHeader, Me.GroupHeader1, Me.GroupHeader2, Me.GroupFooter1, Me.ReportFooter})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.cltfldSubmitted})
        Me.Margins = New System.Drawing.Printing.Margins(41, 0, 100, 100)
        Me.PageHeight = 750
        Me.PageWidth = 951
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.xtrEvenRow, Me.xtrOddRow})
        Me.Version = "8.2"
        CType(Me.dsProjectExpenseDetailReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand

#End Region
    Private Sub xtrProjectExpenseDetailReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel20.Text = Resources.TimeLive.Resource.Project_Expense_Detail_Report
        Me.xrLabel23.Text = Resources.TimeLive.Resource.Project_Name_
        Me.xrLabel1.Text = Resources.TimeLive.Resource.Employee_Name_
        Me.xrLabel3.Text = Resources.TimeLive.Resource.Date
        Me.xrLabel4.Text = Resources.TimeLive.Resource.Expense_Type
        Me.xrLabel5.Text = Resources.TimeLive.Resource.Expense_Name
        Me.xrLabel6.Text = Resources.TimeLive.Resource.Description
        Me.xrLabel19.Text = Resources.TimeLive.Resource.Submitted
        Me.xrLabel7.Text = Resources.TimeLive.Resource.Currency
        Me.xrLabel8.Text = Resources.TimeLive.Resource.Net_Amount
        Me.xrLabel9.Text = Resources.TimeLive.Resource.Tax
        Me.xrLabel10.Text = Resources.TimeLive.Resource.Amount
        Me.xrLabel28.Text = Resources.TimeLive.Resource.Total_
        Me.xrLabel29.Text = Resources.TimeLive.Resource.Grand_Total_

    End Sub
End Class