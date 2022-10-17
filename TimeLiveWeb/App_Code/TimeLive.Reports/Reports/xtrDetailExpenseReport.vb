Public Class xtrDetailExpenseReport
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
    Private WithEvents vueAccountExpenseEntryAdapter1 As dsDetailExpenseReportTableAdapters.vueAccountExpenseEntryAdapter
    Private WithEvents dsDetailExpenseReport1 As dsDetailExpenseReport
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents cltFldApproved As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents cltfldSubmitted As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblCurrencyCode As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents calculatedField1 As DevExpress.XtraReports.UI.CalculatedField

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrDetailExpenseReport.resx"
        Dim resources As System.Resources.ResourceManager = Global.Resources.xtrDetailExpenseReport.ResourceManager
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel
        Me.lblCurrencyCode = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.dsDetailExpenseReport1 = New dsDetailExpenseReport
        Me.vueAccountExpenseEntryAdapter1 = New dsDetailExpenseReportTableAdapters.vueAccountExpenseEntryAdapter
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel26 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.cltFldApproved = New DevExpress.XtraReports.UI.CalculatedField
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable
        Me.xrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow
        Me.xrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell
        Me.cltfldSubmitted = New DevExpress.XtraReports.UI.CalculatedField
        Me.calculatedField1 = New DevExpress.XtraReports.UI.CalculatedField
        CType(Me.dsDetailExpenseReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel22, Me.lblCurrencyCode, Me.xrLabel27, Me.xrLabel24, Me.xrLabel20, Me.xrLabel21, Me.xrLabel19, Me.xrLabel18, Me.xrLabel17, Me.xrLabel16, Me.xrLabel15})
        Me.Detail.Height = 29
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.Scripts.OnBeforePrint = resources.GetString("Detail.Scripts.OnBeforePrint")
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel22
        '
        Me.xrLabel22.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel22.Location = New System.Drawing.Point(617, 0)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.Size = New System.Drawing.Size(16, 17)
        Me.xrLabel22.StylePriority.UseFont = False
        Me.xrLabel22.StylePriority.UseTextAlignment = False
        Me.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel22.Visible = False
        '
        'lblCurrencyCode
        '
        Me.lblCurrencyCode.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.lblCurrencyCode.Location = New System.Drawing.Point(651, 0)
        Me.lblCurrencyCode.Name = "lblCurrencyCode"
        Me.lblCurrencyCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCurrencyCode.Size = New System.Drawing.Size(8, 17)
        Me.lblCurrencyCode.StylePriority.UseFont = False
        Me.lblCurrencyCode.StylePriority.UseTextAlignment = False
        Me.lblCurrencyCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblCurrencyCode.Visible = False
        '
        'xrLabel27
        '
        Me.xrLabel27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.cltfldSubmitted", "")})
        Me.xrLabel27.EvenStyleName = "xtrEvenRow"
        Me.xrLabel27.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel27.Location = New System.Drawing.Point(517, 0)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.OddStyleName = "xtrOddRow"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.Size = New System.Drawing.Size(67, 28)
        Me.xrLabel27.StylePriority.UseFont = False
        Me.xrLabel27.StylePriority.UseTextAlignment = False
        Me.xrLabel27.Text = "xrLabel27"
        Me.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel24
        '
        Me.xrLabel24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.cltFldApproved", "")})
        Me.xrLabel24.EvenStyleName = "xtrEvenRow"
        Me.xrLabel24.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel24.Location = New System.Drawing.Point(584, 0)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.OddStyleName = "xtrOddRow"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.Size = New System.Drawing.Size(67, 28)
        Me.xrLabel24.StylePriority.UseFont = False
        Me.xrLabel24.StylePriority.UseTextAlignment = False
        Me.xrLabel24.Text = "xrLabel24"
        Me.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel20
        '
        Me.xrLabel20.CanGrow = False
        Me.xrLabel20.EvenStyleName = "xtrEvenRow"
        Me.xrLabel20.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel20.Location = New System.Drawing.Point(741, 0)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.OddStyleName = "xtrOddRow"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.Size = New System.Drawing.Size(95, 28)
        Me.xrLabel20.StylePriority.UseFont = False
        Me.xrLabel20.StylePriority.UseTextAlignment = False
        Me.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel20.WordWrap = False
        '
        'xrLabel21
        '
        Me.xrLabel21.CanGrow = False
        Me.xrLabel21.EvenStyleName = "xtrEvenRow"
        Me.xrLabel21.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel21.Location = New System.Drawing.Point(651, 0)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.OddStyleName = "xtrOddRow"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.Size = New System.Drawing.Size(91, 28)
        Me.xrLabel21.StylePriority.UseFont = False
        Me.xrLabel21.StylePriority.UseTextAlignment = False
        Me.xrLabel21.Text = "xrLabel21"
        Me.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel21.WordWrap = False
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.Description", "")})
        Me.xrLabel19.EvenStyleName = "xtrEvenRow"
        Me.xrLabel19.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel19.Location = New System.Drawing.Point(392, 0)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.OddStyleName = "xtrOddRow"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.Size = New System.Drawing.Size(125, 28)
        Me.xrLabel19.StylePriority.UseFont = False
        Me.xrLabel19.StylePriority.UseTextAlignment = False
        Me.xrLabel19.Text = "xrLabel19"
        Me.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.AccountExpenseName", "")})
        Me.xrLabel18.EvenStyleName = "xtrEvenRow"
        Me.xrLabel18.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel18.Location = New System.Drawing.Point(300, 0)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.OddStyleName = "xtrOddRow"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.Size = New System.Drawing.Size(92, 28)
        Me.xrLabel18.StylePriority.UseFont = False
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        Me.xrLabel18.Text = "xrLabel18"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.ExpenseType", "")})
        Me.xrLabel17.EvenStyleName = "xtrEvenRow"
        Me.xrLabel17.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel17.Location = New System.Drawing.Point(202, 0)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.OddStyleName = "xtrOddRow"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.Size = New System.Drawing.Size(98, 28)
        Me.xrLabel17.StylePriority.UseFont = False
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.Text = "xrLabel17"
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.ProjectName", "")})
        Me.xrLabel16.EvenStyleName = "xtrEvenRow"
        Me.xrLabel16.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel16.Location = New System.Drawing.Point(102, 0)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.OddStyleName = "xtrOddRow"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.Size = New System.Drawing.Size(100, 28)
        Me.xrLabel16.StylePriority.UseFont = False
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.AccountExpenseEntryDate", "{0:d}")})
        Me.xrLabel15.EvenStyleName = "xtrEvenRow"
        Me.xrLabel15.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel15.Location = New System.Drawing.Point(10, 0)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.OddStyleName = "xtrOddRow"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.Size = New System.Drawing.Size(92, 28)
        Me.xrLabel15.StylePriority.UseFont = False
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        Me.xrLabel15.Text = "xrLabel15"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'dsDetailExpenseReport1
        '
        Me.dsDetailExpenseReport1.DataSetName = "dsDetailExpenseReport"
        Me.dsDetailExpenseReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'vueAccountExpenseEntryAdapter1
        '
        Me.vueAccountExpenseEntryAdapter1.ClearBeforeFill = True
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrPageInfo1, Me.xrLine1, Me.xrPageInfo2})
        Me.PageFooter.Height = 57
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo1.Location = New System.Drawing.Point(8, 25)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.Size = New System.Drawing.Size(233, 25)
        Me.xrPageInfo1.StyleName = "PageInfo"
        Me.xrPageInfo1.StylePriority.UseFont = False
        '
        'xrLine1
        '
        Me.xrLine1.Location = New System.Drawing.Point(8, 17)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.Size = New System.Drawing.Size(825, 8)
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.Location = New System.Drawing.Point(717, 25)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.Size = New System.Drawing.Size(115, 25)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.StylePriority.UseFont = False
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.White
        Me.Title.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.BorderWidth = 1
        Me.Title.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Title.ForeColor = System.Drawing.Color.Maroon
        Me.Title.Name = "Title"
        '
        'FieldCaption
        '
        Me.FieldCaption.BackColor = System.Drawing.Color.White
        Me.FieldCaption.BorderColor = System.Drawing.SystemColors.ControlText
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.FieldCaption.BorderWidth = 1
        Me.FieldCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FieldCaption.ForeColor = System.Drawing.Color.Maroon
        Me.FieldCaption.Name = "FieldCaption"
        '
        'PageInfo
        '
        Me.PageInfo.BackColor = System.Drawing.Color.White
        Me.PageInfo.BorderColor = System.Drawing.SystemColors.ControlText
        Me.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PageInfo.BorderWidth = 1
        Me.PageInfo.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PageInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PageInfo.Name = "PageInfo"
        '
        'DataField
        '
        Me.DataField.BackColor = System.Drawing.Color.White
        Me.DataField.BorderColor = System.Drawing.SystemColors.ControlText
        Me.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DataField.BorderWidth = 1
        Me.DataField.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.DataField.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataField.Name = "DataField"
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1})
        Me.reportHeaderBand1.Height = 32
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel1
        '
        Me.xrLabel1.BackColor = System.Drawing.Color.Silver
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.ForeColor = System.Drawing.Color.Black
        Me.xrLabel1.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(825, 21)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.StylePriority.UseBackColor = False
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseForeColor = False
        Me.xrLabel1.Text = "Detail Expense Report"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel26, Me.xrLabel14, Me.xrLabel12, Me.xrLabel11, Me.xrLabel10, Me.xrLabel9, Me.xrLabel7, Me.xrLabel8, Me.xrLabel13, Me.xrLabel6, Me.xrLabel5, Me.xrLabel3, Me.xrLabel2})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("EmployeeName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.Height = 53
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.Scripts.OnBeforePrint = resources.GetString("GroupHeader1.Scripts.OnBeforePrint")
        '
        'xrLabel26
        '
        Me.xrLabel26.BackColor = System.Drawing.Color.Silver
        Me.xrLabel26.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel26.CanGrow = False
        Me.xrLabel26.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel26.ForeColor = System.Drawing.Color.Black
        Me.xrLabel26.Location = New System.Drawing.Point(517, 25)
        Me.xrLabel26.Name = "xrLabel26"
        Me.xrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel26.Size = New System.Drawing.Size(67, 28)
        Me.xrLabel26.StylePriority.UseBackColor = False
        Me.xrLabel26.StylePriority.UseBorders = False
        Me.xrLabel26.StylePriority.UseFont = False
        Me.xrLabel26.StylePriority.UseForeColor = False
        Me.xrLabel26.StylePriority.UseTextAlignment = False
        Me.xrLabel26.Text = "Submitted"
        Me.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel26.WordWrap = False
        '
        'xrLabel14
        '
        Me.xrLabel14.BackColor = System.Drawing.Color.Silver
        Me.xrLabel14.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel14.CanGrow = False
        Me.xrLabel14.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel14.ForeColor = System.Drawing.Color.Black
        Me.xrLabel14.Location = New System.Drawing.Point(741, 25)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.Size = New System.Drawing.Size(95, 28)
        Me.xrLabel14.StylePriority.UseBackColor = False
        Me.xrLabel14.StylePriority.UseBorders = False
        Me.xrLabel14.StylePriority.UseFont = False
        Me.xrLabel14.StylePriority.UseForeColor = False
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.Text = "Total Amount"
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel14.WordWrap = False
        '
        'xrLabel12
        '
        Me.xrLabel12.BackColor = System.Drawing.Color.Silver
        Me.xrLabel12.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel12.CanGrow = False
        Me.xrLabel12.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel12.ForeColor = System.Drawing.Color.Black
        Me.xrLabel12.Location = New System.Drawing.Point(584, 25)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.Size = New System.Drawing.Size(67, 28)
        Me.xrLabel12.StylePriority.UseBackColor = False
        Me.xrLabel12.StylePriority.UseBorders = False
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseForeColor = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "Approved"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel12.WordWrap = False
        '
        'xrLabel11
        '
        Me.xrLabel11.BackColor = System.Drawing.Color.Silver
        Me.xrLabel11.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel11.CanGrow = False
        Me.xrLabel11.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel11.ForeColor = System.Drawing.Color.Black
        Me.xrLabel11.Location = New System.Drawing.Point(392, 25)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.Size = New System.Drawing.Size(125, 28)
        Me.xrLabel11.StylePriority.UseBackColor = False
        Me.xrLabel11.StylePriority.UseBorders = False
        Me.xrLabel11.StylePriority.UseFont = False
        Me.xrLabel11.StylePriority.UseForeColor = False
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "Description"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel11.WordWrap = False
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
        Me.xrLabel10.Location = New System.Drawing.Point(300, 25)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.Size = New System.Drawing.Size(92, 28)
        Me.xrLabel10.StylePriority.UseBackColor = False
        Me.xrLabel10.StylePriority.UseBorders = False
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseForeColor = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "Expense Name"
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
        Me.xrLabel9.Location = New System.Drawing.Point(202, 25)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.Size = New System.Drawing.Size(98, 28)
        Me.xrLabel9.StylePriority.UseBackColor = False
        Me.xrLabel9.StylePriority.UseBorders = False
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseForeColor = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "Expense Type"
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
        Me.xrLabel7.Location = New System.Drawing.Point(102, 25)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.Size = New System.Drawing.Size(100, 28)
        Me.xrLabel7.StylePriority.UseBackColor = False
        Me.xrLabel7.StylePriority.UseBorders = False
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseForeColor = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "Project Name"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel7.WordWrap = False
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
        Me.xrLabel8.Location = New System.Drawing.Point(10, 25)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.Size = New System.Drawing.Size(92, 28)
        Me.xrLabel8.StylePriority.UseBackColor = False
        Me.xrLabel8.StylePriority.UseBorders = False
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.StylePriority.UseForeColor = False
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "Date"
        Me.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel8.WordWrap = False
        '
        'xrLabel13
        '
        Me.xrLabel13.BackColor = System.Drawing.Color.Silver
        Me.xrLabel13.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel13.CanGrow = False
        Me.xrLabel13.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel13.ForeColor = System.Drawing.Color.Black
        Me.xrLabel13.Location = New System.Drawing.Point(651, 25)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.Size = New System.Drawing.Size(91, 28)
        Me.xrLabel13.StylePriority.UseBackColor = False
        Me.xrLabel13.StylePriority.UseBorders = False
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseForeColor = False
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "Amount"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel13.WordWrap = False
        '
        'xrLabel6
        '
        Me.xrLabel6.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel6.Location = New System.Drawing.Point(233, 0)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.Size = New System.Drawing.Size(108, 17)
        Me.xrLabel6.StylePriority.UseFont = False
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "Employee Name :"
        Me.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel5
        '
        Me.xrLabel5.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel5.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.Size = New System.Drawing.Size(124, 17)
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "Employee Code :"
        Me.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel3
        '
        Me.xrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.EmployeeName", "")})
        Me.xrLabel3.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel3.Location = New System.Drawing.Point(350, 0)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.Size = New System.Drawing.Size(483, 17)
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.Text = "xrLabel3"
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.EmployeeCode", "")})
        Me.xrLabel2.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.Location = New System.Drawing.Point(133, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(100, 17)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "xrLabel2"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel25, Me.xrLabel23, Me.xrLabel4, Me.xrLine2, Me.xrLine3})
        Me.GroupFooter1.Height = 46
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrLabel25
        '
        Me.xrLabel25.CanGrow = False
        Me.xrLabel25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.Amount", "")})
        Me.xrLabel25.EvenStyleName = "xtrEvenRow"
        Me.xrLabel25.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel25.Location = New System.Drawing.Point(651, 17)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.OddStyleName = "xtrOddRow"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.Size = New System.Drawing.Size(91, 17)
        Me.xrLabel25.StylePriority.UseFont = False
        Me.xrLabel25.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel25.Summary = xrSummary1
        Me.xrLabel25.Text = "xrLabel25"
        Me.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel25.WordWrap = False
        '
        'xrLabel23
        '
        Me.xrLabel23.CanGrow = False
        Me.xrLabel23.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel23.Location = New System.Drawing.Point(741, 17)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.Size = New System.Drawing.Size(95, 17)
        Me.xrLabel23.StylePriority.UseFont = False
        Me.xrLabel23.StylePriority.UseTextAlignment = False
        Me.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel23.WordWrap = False
        '
        'xrLabel4
        '
        Me.xrLabel4.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel4.Location = New System.Drawing.Point(300, 17)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(92, 17)
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.Text = "Total :"
        Me.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLine2
        '
        Me.xrLine2.Location = New System.Drawing.Point(8, 3)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.Size = New System.Drawing.Size(825, 12)
        '
        'xrLine3
        '
        Me.xrLine3.Location = New System.Drawing.Point(8, 39)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.Size = New System.Drawing.Size(825, 2)
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
        'cltFldApproved
        '
        Me.cltFldApproved.DataMember = "vueAccountExpenseEntry"
        Me.cltFldApproved.DataSource = Me.dsDetailExpenseReport1
        Me.cltFldApproved.DisplayName = "cltFldApproved"
        Me.cltFldApproved.Expression = "Iif([Approved]=True,'Yes'  ,'No' )"
        Me.cltFldApproved.Name = "cltFldApproved"
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.Location = New System.Drawing.Point(6, 0)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow2})
        Me.xrTable2.Size = New System.Drawing.Size(719, 28)
        '
        'xrTableRow2
        '
        Me.xrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell14})
        Me.xrTableRow2.Name = "xrTableRow2"
        Me.xrTableRow2.Size = New System.Drawing.Size(719, 28)
        '
        'xrTableCell14
        '
        Me.xrTableCell14.CanGrow = False
        Me.xrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntry.Amount", "{0:#,#}")})
        Me.xrTableCell14.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrTableCell14.Location = New System.Drawing.Point(0, 0)
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrTableCell14.Size = New System.Drawing.Size(719, 28)
        Me.xrTableCell14.StylePriority.UseFont = False
        Me.xrTableCell14.StylePriority.UseTextAlignment = False
        Me.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'cltfldSubmitted
        '
        Me.cltfldSubmitted.DataMember = "vueAccountExpenseEntry"
        Me.cltfldSubmitted.DataSource = Me.dsDetailExpenseReport1
        Me.cltfldSubmitted.DisplayName = "cltfldSubmitted"
        Me.cltfldSubmitted.Expression = "Iif([Submitted]=True,'Yes'  ,'No' )"
        Me.cltfldSubmitted.Name = "cltfldSubmitted"
        '
        'calculatedField1
        '
        Me.calculatedField1.DataMember = "vueAccountExpenseEntry"
        Me.calculatedField1.DataSource = Me.dsDetailExpenseReport1
        Me.calculatedField1.Expression = "[CurrencyCode] & ' ' & [Amount]"
        Me.calculatedField1.Name = "calculatedField1"
        '
        'xtrDetailExpenseReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageFooter, Me.PageHeader, Me.reportHeaderBand1, Me.GroupHeader1, Me.GroupFooter1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.cltFldApproved, Me.cltfldSubmitted, Me.calculatedField1})
        Me.DataAdapter = Me.vueAccountExpenseEntryAdapter1
        Me.DataMember = "vueAccountExpenseEntry"
        Me.DataSource = Me.dsDetailExpenseReport1
        Me.Margins = New System.Drawing.Printing.Margins(0, 6, 100, 100)
        Me.PageHeight = 1803
        Me.PageWidth = 856
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField, Me.xtrEvenRow, Me.xtrOddRow})
        Me.Version = "8.2"
        CType(Me.dsDetailExpenseReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region
    Private Sub xtrDetailExpenseReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel1.Text = Resources.TimeLive.Resource.Detail_Expense_Report
        Me.xrLabel8.Text = Resources.TimeLive.Resource.Date
        Me.xrLabel5.Text = Resources.TimeLive.Resource.Employee_Code_
        Me.xrLabel6.Text = Resources.TimeLive.Resource.Employee_Name_
        Me.xrLabel7.Text = Resources.TimeLive.Resource.Project_Name
        Me.xrLabel9.Text = Resources.TimeLive.Resource.Expense_Type
        Me.xrLabel10.Text = Resources.TimeLive.Resource.Expense_Name_
        Me.xrLabel11.Text = Resources.TimeLive.Resource.Description
        Me.xrLabel26.Text = Resources.TimeLive.Resource.Submitted
        Me.xrLabel12.Text = Resources.TimeLive.Resource.Approved
        Me.xrLabel13.Text = Resources.TimeLive.Resource.Amount
        Me.xrLabel14.Text = Resources.TimeLive.Resource.Total_Amount
        Me.xrLabel4.Text = Resources.TimeLive.Resource.Total_

    End Sub
End Class