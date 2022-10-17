Public Class xtrDetailTimeSheetReport
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
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents vueAccountEmployeeTimeEntryAdapter1 As dsDetailTimeSheetReportTableAdapters.vueAccountEmployeeTimeEntryAdapter
    Private WithEvents dsDetailTimeSheetReport As dsDetailTimeSheetReport
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents groupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents reportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine5 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents cltFldAmount As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents ctlFldApproved As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents ctlFldTotalMinutes As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents ctlFldSubmitted As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel37 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel38 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine4 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLabel40 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel39 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrDetailTimeSheetReport.resx"
        Dim resources As System.Resources.ResourceManager = Global.Resources.xtrDetailTimeSheetReport.ResourceManager
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrLabel40 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel36 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel35 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel33 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel30 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel28 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel
        Me.vueAccountEmployeeTimeEntryAdapter1 = New dsDetailTimeSheetReportTableAdapters.vueAccountEmployeeTimeEntryAdapter
        Me.dsDetailTimeSheetReport = New dsDetailTimeSheetReport
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.xrLine4 = New DevExpress.XtraReports.UI.XRLine
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel39 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel26 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel38 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel37 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel34 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel32 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel29 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.reportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLine5 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.cltFldAmount = New DevExpress.XtraReports.UI.CalculatedField
        Me.ctlFldApproved = New DevExpress.XtraReports.UI.CalculatedField
        Me.ctlFldTotalMinutes = New DevExpress.XtraReports.UI.CalculatedField
        Me.ctlFldSubmitted = New DevExpress.XtraReports.UI.CalculatedField
        Me.xrLabel31 = New DevExpress.XtraReports.UI.XRLabel
        CType(Me.dsDetailTimeSheetReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel40, Me.xrLabel12, Me.xrLabel36, Me.xrLabel35, Me.xrLabel33, Me.xrLabel30, Me.xrLabel28, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18, Me.xrLabel19, Me.xrLabel27})
        Me.Detail.Height = 28
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.Scripts.OnBeforePrint = resources.GetString("Detail.Scripts.OnBeforePrint")
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel40
        '
        Me.xrLabel40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.AccountCostCenter", "")})
        Me.xrLabel40.EvenStyleName = "xtrEvenRow"
        Me.xrLabel40.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel40.Location = New System.Drawing.Point(1318, 0)
        Me.xrLabel40.Name = "xrLabel40"
        Me.xrLabel40.OddStyleName = "xtrOddRow"
        Me.xrLabel40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel40.Size = New System.Drawing.Size(115, 28)
        Me.xrLabel40.StylePriority.UseFont = False
        Me.xrLabel40.StylePriority.UseTextAlignment = False
        Me.xrLabel40.Text = "xrLabel40"
        Me.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.ctlFldApproved", "")})
        Me.xrLabel12.EvenStyleName = "xtrEvenRow"
        Me.xrLabel12.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel12.Location = New System.Drawing.Point(838, 0)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.OddStyleName = "xtrOddRow"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.Size = New System.Drawing.Size(75, 28)
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "xrLabel12"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel36
        '
        Me.xrLabel36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.AccountWorkType", "")})
        Me.xrLabel36.EvenStyleName = "xtrEvenRow"
        Me.xrLabel36.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel36.Location = New System.Drawing.Point(1108, 0)
        Me.xrLabel36.Name = "xrLabel36"
        Me.xrLabel36.OddStyleName = "xtrOddRow"
        Me.xrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel36.Size = New System.Drawing.Size(95, 28)
        Me.xrLabel36.StylePriority.UseFont = False
        Me.xrLabel36.StylePriority.UseTextAlignment = False
        Me.xrLabel36.Text = "xrLabel36"
        Me.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel35
        '
        Me.xrLabel35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.AccountCostCenterCode", "")})
        Me.xrLabel35.EvenStyleName = "xtrEvenRow"
        Me.xrLabel35.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel35.Location = New System.Drawing.Point(1203, 0)
        Me.xrLabel35.Name = "xrLabel35"
        Me.xrLabel35.OddStyleName = "xtrOddRow"
        Me.xrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel35.Size = New System.Drawing.Size(115, 28)
        Me.xrLabel35.StylePriority.UseFont = False
        Me.xrLabel35.StylePriority.UseTextAlignment = False
        Me.xrLabel35.Text = "xrLabel35"
        Me.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel33
        '
        Me.xrLabel33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.TaskCode", "")})
        Me.xrLabel33.EvenStyleName = "xtrEvenRow"
        Me.xrLabel33.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel33.Location = New System.Drawing.Point(318, 0)
        Me.xrLabel33.Name = "xrLabel33"
        Me.xrLabel33.OddStyleName = "xtrOddRow"
        Me.xrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel33.Size = New System.Drawing.Size(110, 28)
        Me.xrLabel33.StylePriority.UseFont = False
        Me.xrLabel33.StylePriority.UseTextAlignment = False
        Me.xrLabel33.Text = "xrLabel33"
        Me.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel30
        '
        Me.xrLabel30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.ProjectCode", "")})
        Me.xrLabel30.EvenStyleName = "xtrEvenRow"
        Me.xrLabel30.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel30.Location = New System.Drawing.Point(86, 0)
        Me.xrLabel30.Name = "xrLabel30"
        Me.xrLabel30.OddStyleName = "xtrOddRow"
        Me.xrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel30.Size = New System.Drawing.Size(90, 28)
        Me.xrLabel30.StylePriority.UseFont = False
        Me.xrLabel30.StylePriority.UseTextAlignment = False
        Me.xrLabel30.Text = "xrLabel30"
        Me.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel28
        '
        Me.xrLabel28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.BillingRate", "{0:c2}")})
        Me.xrLabel28.EvenStyleName = "xtrEvenRow"
        Me.xrLabel28.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel28.Location = New System.Drawing.Point(913, 0)
        Me.xrLabel28.Name = "xrLabel28"
        Me.xrLabel28.OddStyleName = "xtrOddRow"
        Me.xrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel28.Size = New System.Drawing.Size(120, 28)
        Me.xrLabel28.StylePriority.UseFont = False
        Me.xrLabel28.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:#,#}"
        Me.xrLabel28.Summary = xrSummary1
        Me.xrLabel28.Text = "xrLabel28"
        Me.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.TimeEntryDate", "{0:d}")})
        Me.xrLabel14.EvenStyleName = "xtrEvenRow"
        Me.xrLabel14.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel14.Location = New System.Drawing.Point(10, 0)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.OddStyleName = "xtrOddRow"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.Size = New System.Drawing.Size(76, 28)
        Me.xrLabel14.StylePriority.UseFont = False
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.ProjectName", "")})
        Me.xrLabel15.EvenStyleName = "xtrEvenRow"
        Me.xrLabel15.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel15.Location = New System.Drawing.Point(176, 0)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.OddStyleName = "xtrOddRow"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.Size = New System.Drawing.Size(142, 28)
        Me.xrLabel15.StylePriority.UseFont = False
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.TaskName", "")})
        Me.xrLabel16.EvenStyleName = "xtrEvenRow"
        Me.xrLabel16.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel16.Location = New System.Drawing.Point(428, 0)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.OddStyleName = "xtrOddRow"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.Size = New System.Drawing.Size(135, 28)
        Me.xrLabel16.StylePriority.UseFont = False
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.Description", "")})
        Me.xrLabel17.EvenStyleName = "xtrEvenRow"
        Me.xrLabel17.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel17.Location = New System.Drawing.Point(563, 0)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.OddStyleName = "xtrOddRow"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.Size = New System.Drawing.Size(150, 28)
        Me.xrLabel17.StylePriority.UseFont = False
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.TotalTime", "{0:HH:mm}")})
        Me.xrLabel18.EvenStyleName = "xtrEvenRow"
        Me.xrLabel18.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel18.Location = New System.Drawing.Point(713, 0)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.OddStyleName = "xtrOddRow"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.Size = New System.Drawing.Size(58, 28)
        Me.xrLabel18.StylePriority.UseFont = False
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:HH:mm}"
        Me.xrLabel18.Summary = xrSummary2
        Me.xrLabel18.Text = "xrLabel18"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.cltFldAmount", "{0:c2}")})
        Me.xrLabel19.EvenStyleName = "xtrEvenRow"
        Me.xrLabel19.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel19.Location = New System.Drawing.Point(1033, 0)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.OddStyleName = "xtrOddRow"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.Size = New System.Drawing.Size(75, 28)
        Me.xrLabel19.StylePriority.UseFont = False
        Me.xrLabel19.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:#,#}"
        Me.xrLabel19.Summary = xrSummary3
        Me.xrLabel19.Text = "xrLabel19"
        Me.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel27
        '
        Me.xrLabel27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.ctlFldSubmitted", "")})
        Me.xrLabel27.EvenStyleName = "xtrEvenRow"
        Me.xrLabel27.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel27.Location = New System.Drawing.Point(771, 0)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.OddStyleName = "xtrOddRow"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.Size = New System.Drawing.Size(67, 28)
        Me.xrLabel27.StylePriority.UseFont = False
        Me.xrLabel27.StylePriority.UseTextAlignment = False
        Me.xrLabel27.Text = "xrLabel27"
        Me.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'vueAccountEmployeeTimeEntryAdapter1
        '
        Me.vueAccountEmployeeTimeEntryAdapter1.ClearBeforeFill = True
        '
        'dsDetailTimeSheetReport
        '
        Me.dsDetailTimeSheetReport.DataSetName = "dsDetailTimeSheetReportForXtrReport"
        Me.dsDetailTimeSheetReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine4, Me.xrPageInfo1, Me.xrPageInfo2})
        Me.PageFooter.Height = 42
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLine4
        '
        Me.xrLine4.Location = New System.Drawing.Point(10, 9)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.Size = New System.Drawing.Size(1425, 6)
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo1.Location = New System.Drawing.Point(8, 15)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.Size = New System.Drawing.Size(238, 25)
        Me.xrPageInfo1.StyleName = "PageInfo"
        Me.xrPageInfo1.StylePriority.UseFont = False
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.Location = New System.Drawing.Point(1310, 15)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.Size = New System.Drawing.Size(96, 21)
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
        Me.Title.ForeColor = System.Drawing.Color.Black
        Me.Title.Name = "Title"
        '
        'FieldCaption
        '
        Me.FieldCaption.BackColor = System.Drawing.Color.White
        Me.FieldCaption.BorderColor = System.Drawing.SystemColors.ControlText
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.FieldCaption.BorderWidth = 1
        Me.FieldCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FieldCaption.ForeColor = System.Drawing.Color.Black
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
        'xrLabel3
        '
        Me.xrLabel3.BackColor = System.Drawing.Color.Silver
        Me.xrLabel3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel3.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel3.Location = New System.Drawing.Point(10, 21)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.Size = New System.Drawing.Size(76, 28)
        Me.xrLabel3.StyleName = "FieldCaption"
        Me.xrLabel3.StylePriority.UseBackColor = False
        Me.xrLabel3.StylePriority.UseBorders = False
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "Date"
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel39, Me.xrLabel8, Me.xrLabel26, Me.xrLabel38, Me.xrLabel37, Me.xrLabel34, Me.xrLabel32, Me.xrLabel29, Me.xrLabel3, Me.xrLabel24, Me.xrLabel23, Me.xrLabel9, Me.xrLabel25, Me.xrLabel4, Me.xrLabel7, Me.xrLabel6, Me.xrLabel5, Me.xrLabel10})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("EmployeeName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.Height = 50
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        Me.groupHeaderBand1.Scripts.OnBeforePrint = resources.GetString("groupHeaderBand1.Scripts.OnBeforePrint")
        '
        'xrLabel39
        '
        Me.xrLabel39.BackColor = System.Drawing.Color.Silver
        Me.xrLabel39.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel39.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel39.Location = New System.Drawing.Point(1318, 21)
        Me.xrLabel39.Name = "xrLabel39"
        Me.xrLabel39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel39.Size = New System.Drawing.Size(115, 28)
        Me.xrLabel39.StyleName = "FieldCaption"
        Me.xrLabel39.StylePriority.UseBackColor = False
        Me.xrLabel39.StylePriority.UseBorders = False
        Me.xrLabel39.StylePriority.UseFont = False
        Me.xrLabel39.StylePriority.UseTextAlignment = False
        Me.xrLabel39.Text = "Cost Center"
        Me.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel8
        '
        Me.xrLabel8.BackColor = System.Drawing.Color.Silver
        Me.xrLabel8.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel8.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel8.Location = New System.Drawing.Point(838, 21)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.Size = New System.Drawing.Size(75, 28)
        Me.xrLabel8.StyleName = "FieldCaption"
        Me.xrLabel8.StylePriority.UseBackColor = False
        Me.xrLabel8.StylePriority.UseBorders = False
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "Approved"
        Me.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel26
        '
        Me.xrLabel26.BackColor = System.Drawing.Color.Silver
        Me.xrLabel26.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel26.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel26.Location = New System.Drawing.Point(771, 21)
        Me.xrLabel26.Name = "xrLabel26"
        Me.xrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel26.Size = New System.Drawing.Size(67, 28)
        Me.xrLabel26.StyleName = "FieldCaption"
        Me.xrLabel26.StylePriority.UseBackColor = False
        Me.xrLabel26.StylePriority.UseBorders = False
        Me.xrLabel26.StylePriority.UseFont = False
        Me.xrLabel26.StylePriority.UseTextAlignment = False
        Me.xrLabel26.Text = "Submitted"
        Me.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel38
        '
        Me.xrLabel38.BackColor = System.Drawing.Color.Silver
        Me.xrLabel38.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel38.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel38.Location = New System.Drawing.Point(1108, 21)
        Me.xrLabel38.Name = "xrLabel38"
        Me.xrLabel38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel38.Size = New System.Drawing.Size(95, 28)
        Me.xrLabel38.StyleName = "FieldCaption"
        Me.xrLabel38.StylePriority.UseBackColor = False
        Me.xrLabel38.StylePriority.UseBorders = False
        Me.xrLabel38.StylePriority.UseFont = False
        Me.xrLabel38.StylePriority.UseTextAlignment = False
        Me.xrLabel38.Text = "Work Type"
        Me.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel37
        '
        Me.xrLabel37.BackColor = System.Drawing.Color.Silver
        Me.xrLabel37.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel37.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel37.Location = New System.Drawing.Point(1203, 21)
        Me.xrLabel37.Name = "xrLabel37"
        Me.xrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel37.Size = New System.Drawing.Size(115, 28)
        Me.xrLabel37.StyleName = "FieldCaption"
        Me.xrLabel37.StylePriority.UseBackColor = False
        Me.xrLabel37.StylePriority.UseBorders = False
        Me.xrLabel37.StylePriority.UseFont = False
        Me.xrLabel37.StylePriority.UseTextAlignment = False
        Me.xrLabel37.Text = "Cost Center Code"
        Me.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel34
        '
        Me.xrLabel34.BackColor = System.Drawing.Color.Silver
        Me.xrLabel34.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel34.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel34.Location = New System.Drawing.Point(318, 21)
        Me.xrLabel34.Name = "xrLabel34"
        Me.xrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel34.Size = New System.Drawing.Size(110, 28)
        Me.xrLabel34.StyleName = "FieldCaption"
        Me.xrLabel34.StylePriority.UseBackColor = False
        Me.xrLabel34.StylePriority.UseBorders = False
        Me.xrLabel34.StylePriority.UseFont = False
        Me.xrLabel34.StylePriority.UseTextAlignment = False
        Me.xrLabel34.Text = "Task Code"
        Me.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel32
        '
        Me.xrLabel32.BackColor = System.Drawing.Color.Silver
        Me.xrLabel32.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel32.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel32.Location = New System.Drawing.Point(86, 21)
        Me.xrLabel32.Name = "xrLabel32"
        Me.xrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel32.Size = New System.Drawing.Size(90, 28)
        Me.xrLabel32.StyleName = "FieldCaption"
        Me.xrLabel32.StylePriority.UseBackColor = False
        Me.xrLabel32.StylePriority.UseBorders = False
        Me.xrLabel32.StylePriority.UseFont = False
        Me.xrLabel32.StylePriority.UseTextAlignment = False
        Me.xrLabel32.Text = "Project Code"
        Me.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel29
        '
        Me.xrLabel29.BackColor = System.Drawing.Color.Silver
        Me.xrLabel29.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel29.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel29.Location = New System.Drawing.Point(913, 21)
        Me.xrLabel29.Name = "xrLabel29"
        Me.xrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel29.Size = New System.Drawing.Size(120, 28)
        Me.xrLabel29.StyleName = "FieldCaption"
        Me.xrLabel29.StylePriority.UseBackColor = False
        Me.xrLabel29.StylePriority.UseBorders = False
        Me.xrLabel29.StylePriority.UseFont = False
        Me.xrLabel29.StylePriority.UseTextAlignment = False
        Me.xrLabel29.Text = "Billing Rate"
        Me.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel24
        '
        Me.xrLabel24.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel24.Location = New System.Drawing.Point(225, 0)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.Size = New System.Drawing.Size(108, 17)
        Me.xrLabel24.StyleName = "FieldCaption"
        Me.xrLabel24.StylePriority.UseFont = False
        Me.xrLabel24.StylePriority.UseTextAlignment = False
        Me.xrLabel24.Text = "Employee Name :"
        Me.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel23
        '
        Me.xrLabel23.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel23.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.Size = New System.Drawing.Size(108, 17)
        Me.xrLabel23.StyleName = "FieldCaption"
        Me.xrLabel23.StylePriority.UseFont = False
        Me.xrLabel23.StylePriority.UseTextAlignment = False
        Me.xrLabel23.Text = "Employee Code :"
        Me.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel9
        '
        Me.xrLabel9.BackColor = System.Drawing.Color.Silver
        Me.xrLabel9.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel9.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel9.Location = New System.Drawing.Point(1033, 21)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.Size = New System.Drawing.Size(75, 28)
        Me.xrLabel9.StyleName = "FieldCaption"
        Me.xrLabel9.StylePriority.UseBackColor = False
        Me.xrLabel9.StylePriority.UseBorders = False
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "Amount"
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel25
        '
        Me.xrLabel25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.EmployeeCode", "")})
        Me.xrLabel25.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel25.Location = New System.Drawing.Point(117, 0)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.Size = New System.Drawing.Size(100, 17)
        Me.xrLabel25.StyleName = "DataField"
        Me.xrLabel25.StylePriority.UseFont = False
        Me.xrLabel25.StylePriority.UseTextAlignment = False
        Me.xrLabel25.Text = "xrLabel25"
        Me.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel4
        '
        Me.xrLabel4.BackColor = System.Drawing.Color.Silver
        Me.xrLabel4.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel4.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel4.Location = New System.Drawing.Point(176, 21)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(142, 28)
        Me.xrLabel4.StyleName = "FieldCaption"
        Me.xrLabel4.StylePriority.UseBackColor = False
        Me.xrLabel4.StylePriority.UseBorders = False
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.Text = "Project Name"
        Me.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel7
        '
        Me.xrLabel7.BackColor = System.Drawing.Color.Silver
        Me.xrLabel7.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel7.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel7.Location = New System.Drawing.Point(713, 21)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.Size = New System.Drawing.Size(58, 28)
        Me.xrLabel7.StyleName = "FieldCaption"
        Me.xrLabel7.StylePriority.UseBackColor = False
        Me.xrLabel7.StylePriority.UseBorders = False
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "Duration"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel6
        '
        Me.xrLabel6.BackColor = System.Drawing.Color.Silver
        Me.xrLabel6.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel6.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel6.Location = New System.Drawing.Point(563, 21)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.Size = New System.Drawing.Size(150, 28)
        Me.xrLabel6.StyleName = "FieldCaption"
        Me.xrLabel6.StylePriority.UseBackColor = False
        Me.xrLabel6.StylePriority.UseBorders = False
        Me.xrLabel6.StylePriority.UseFont = False
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "Description"
        Me.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel5
        '
        Me.xrLabel5.BackColor = System.Drawing.Color.Silver
        Me.xrLabel5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel5.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel5.Location = New System.Drawing.Point(428, 21)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.Size = New System.Drawing.Size(135, 28)
        Me.xrLabel5.StyleName = "FieldCaption"
        Me.xrLabel5.StylePriority.UseBackColor = False
        Me.xrLabel5.StylePriority.UseBorders = False
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "Task Name"
        Me.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel10
        '
        Me.xrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.EmployeeName", "")})
        Me.xrLabel10.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel10.Location = New System.Drawing.Point(333, 0)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.Size = New System.Drawing.Size(1100, 17)
        Me.xrLabel10.StyleName = "DataField"
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'groupFooterBand1
        '
        Me.groupFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel13, Me.xrLabel1, Me.xrLine3, Me.xrLine2, Me.xrLabel11})
        Me.groupFooterBand1.Height = 34
        Me.groupFooterBand1.Name = "groupFooterBand1"
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.cltFldAmount", "")})
        Me.xrLabel13.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel13.Location = New System.Drawing.Point(1033, 8)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.Size = New System.Drawing.Size(75, 18)
        Me.xrLabel13.StyleName = "FieldCaption"
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        xrSummary4.FormatString = "{0:c2}"
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel13.Summary = xrSummary4
        Me.xrLabel13.Text = "xrLabel13"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel1
        '
        Me.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.Location = New System.Drawing.Point(312, 8)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(96, 18)
        Me.xrLabel1.StyleName = "FieldCaption"
        Me.xrLabel1.StylePriority.UseBorders = False
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "Total :"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLine3
        '
        Me.xrLine3.Location = New System.Drawing.Point(10, 26)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.Size = New System.Drawing.Size(1425, 6)
        '
        'xrLine2
        '
        Me.xrLine2.Location = New System.Drawing.Point(10, 2)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.Size = New System.Drawing.Size(1425, 6)
        '
        'xrLabel11
        '
        Me.xrLabel11.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel11.Location = New System.Drawing.Point(713, 8)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.Size = New System.Drawing.Size(58, 18)
        Me.xrLabel11.StyleName = "FieldCaption"
        Me.xrLabel11.StylePriority.UseFont = False
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel20})
        Me.reportHeaderBand1.Height = 32
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel20
        '
        Me.xrLabel20.BackColor = System.Drawing.Color.Silver
        Me.xrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrLabel20.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel20.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.Size = New System.Drawing.Size(1425, 21)
        Me.xrLabel20.StyleName = "Title"
        Me.xrLabel20.StylePriority.UseBackColor = False
        Me.xrLabel20.StylePriority.UseBorders = False
        Me.xrLabel20.StylePriority.UseFont = False
        Me.xrLabel20.Text = "Detail Time Sheet Report"
        '
        'reportFooterBand1
        '
        Me.reportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel22, Me.xrLine5, Me.xrLabel2, Me.xrLabel21})
        Me.reportFooterBand1.Height = 26
        Me.reportFooterBand1.Name = "reportFooterBand1"
        '
        'xrLabel22
        '
        Me.xrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.cltFldAmount", "")})
        Me.xrLabel22.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel22.Location = New System.Drawing.Point(1033, 0)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.Size = New System.Drawing.Size(75, 18)
        Me.xrLabel22.StyleName = "FieldCaption"
        Me.xrLabel22.StylePriority.UseFont = False
        Me.xrLabel22.StylePriority.UseTextAlignment = False
        xrSummary5.FormatString = "{0:c2}"
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel22.Summary = xrSummary5
        Me.xrLabel22.Text = "xrLabel22"
        Me.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLine5
        '
        Me.xrLine5.Location = New System.Drawing.Point(10, 18)
        Me.xrLine5.Name = "xrLine5"
        Me.xrLine5.Size = New System.Drawing.Size(1425, 6)
        '
        'xrLabel2
        '
        Me.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrLabel2.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.Location = New System.Drawing.Point(312, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(96, 18)
        Me.xrLabel2.StyleName = "FieldCaption"
        Me.xrLabel2.StylePriority.UseBorders = False
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.Text = "Grand Total :"
        Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel21
        '
        Me.xrLabel21.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel21.Location = New System.Drawing.Point(713, 0)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.Size = New System.Drawing.Size(58, 18)
        Me.xrLabel21.StyleName = "FieldCaption"
        Me.xrLabel21.StylePriority.UseFont = False
        Me.xrLabel21.StylePriority.UseTextAlignment = False
        Me.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        'GroupHeader1
        '
        Me.GroupHeader1.Height = 0
        Me.GroupHeader1.Level = 1
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'cltFldAmount
        '
        Me.cltFldAmount.DataMember = "vueAccountEmployeeTimeEntry"
        Me.cltFldAmount.DataSource = Me.dsDetailTimeSheetReport
        Me.cltFldAmount.Expression = "isnull([TotalMinutes] * [BillingRate] / 60,0)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.cltFldAmount.FieldType = DevExpress.XtraReports.UI.FieldType.Float
        Me.cltFldAmount.Name = "cltFldAmount"
        '
        'ctlFldApproved
        '
        Me.ctlFldApproved.DataMember = "vueAccountEmployeeTimeEntry"
        Me.ctlFldApproved.DataSource = Me.dsDetailTimeSheetReport
        Me.ctlFldApproved.Expression = "Iif([Approved]=True,'Yes'  ,'No' )"
        Me.ctlFldApproved.Name = "ctlFldApproved"
        '
        'ctlFldTotalMinutes
        '
        Me.ctlFldTotalMinutes.DataMember = "vueAccountEmployeeTimeEntry"
        Me.ctlFldTotalMinutes.DataSource = Me.dsDetailTimeSheetReport
        Me.ctlFldTotalMinutes.Name = "ctlFldTotalMinutes"
        '
        'ctlFldSubmitted
        '
        Me.ctlFldSubmitted.DataMember = "vueAccountEmployeeTimeEntry"
        Me.ctlFldSubmitted.DataSource = Me.dsDetailTimeSheetReport
        Me.ctlFldSubmitted.DisplayName = "ctlFldSubmitted"
        Me.ctlFldSubmitted.Expression = "Iif([Submitted]=True,'Yes'  ,'No' )"
        Me.ctlFldSubmitted.Name = "ctlFldSubmitted"
        '
        'xrLabel31
        '
        Me.xrLabel31.BackColor = System.Drawing.Color.Silver
        Me.xrLabel31.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel31.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel31.Location = New System.Drawing.Point(558, 133)
        Me.xrLabel31.Name = "xrLabel31"
        Me.xrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel31.Size = New System.Drawing.Size(58, 28)
        Me.xrLabel31.StylePriority.UseBackColor = False
        Me.xrLabel31.StylePriority.UseBorders = False
        Me.xrLabel31.StylePriority.UseFont = False
        Me.xrLabel31.StylePriority.UseTextAlignment = False
        Me.xrLabel31.Text = "Duration"
        Me.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xtrDetailTimeSheetReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageFooter, Me.PageHeader, Me.groupHeaderBand1, Me.groupFooterBand1, Me.reportHeaderBand1, Me.reportFooterBand1, Me.GroupHeader1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.cltFldAmount, Me.ctlFldApproved, Me.ctlFldTotalMinutes, Me.ctlFldSubmitted})
        Me.DataAdapter = Me.vueAccountEmployeeTimeEntryAdapter1
        Me.DataMember = "vueAccountEmployeeTimeEntry"
        Me.DataSource = Me.dsDetailTimeSheetReport
        Me.GridSize = New System.Drawing.Size(2, 2)
        Me.Margins = New System.Drawing.Printing.Margins(0, 0, 50, 100)
        Me.PageHeight = 750
        Me.PageWidth = 1467
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField, Me.xtrEvenRow, Me.xtrOddRow})
        Me.Version = "8.2"
        CType(Me.dsDetailTimeSheetReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub xtrDetailTimeSheetReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel20.Text = Resources.TimeLive.Resource.Detail_TimeSheet_Report
        Me.xrLabel23.Text = Resources.TimeLive.Resource.Employee_Code_
        Me.xrLabel24.Text = Resources.TimeLive.Resource.Employee_Name_
        Me.xrLabel3.Text = Resources.TimeLive.Resource.Date
        Me.xrLabel32.Text = Resources.TimeLive.Resource.Project_Code
        Me.xrLabel4.Text = Resources.TimeLive.Resource.Project_Name
        Me.xrLabel34.Text = Resources.TimeLive.Resource.Task_Code
        Me.xrLabel5.Text = Resources.TimeLive.Resource.Task_Name
        Me.xrLabel6.Text = Resources.TimeLive.Resource.Description
        Me.xrLabel7.Text = Resources.TimeLive.Resource.Duration
        Me.xrLabel26.Text = Resources.TimeLive.Resource.Submitted
        Me.xrLabel8.Text = Resources.TimeLive.Resource.Approved
        Me.xrLabel29.Text = Resources.TimeLive.Resource.Billing_Rate
        Me.xrLabel9.Text = Resources.TimeLive.Resource.Amount
        Me.xrLabel38.Text = Resources.TimeLive.Resource.Work_Type
        Me.xrLabel37.Text = ResourceHelper.GetFromResource("Cost Center Code")
        Me.xrLabel39.Text = ResourceHelper.GetFromResource("Cost Center")
        Me.xrLabel1.Text = Resources.TimeLive.Resource.Total_
        Me.xrLabel2.Text = Resources.TimeLive.Resource.Grand_Total_


    End Sub

End Class