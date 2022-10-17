Public Class xtrEmployeeTimesheetSubmissionStatusReport
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Designer.
        InitializeComponent()
        Me.SetReportFontStyle()
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
    Private WithEvents dsEmployeeTimesheetSubmissionStatusReport1 As dsEmployeeTimesheetSubmissionStatusReport
    Private WithEvents vueAccountEmployeeTimesheetSubmissionStatusTableAdapter1 As dsEmployeeTimesheetSubmissionStatusReportTableAdapters.vueAccountEmployeeTimesheetSubmissionStatusTableAdapter
    Private WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents GroupHeader2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents calculatedField1 As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents calculatedField2 As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine
    Dim FontStyle As String
    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrEmployeeTimesheetSubmissionStatusReport.resx"
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.dsEmployeeTimesheetSubmissionStatusReport1 = New dsEmployeeTimesheetSubmissionStatusReport
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.vueAccountEmployeeTimesheetSubmissionStatusTableAdapter1 = New dsEmployeeTimesheetSubmissionStatusReportTableAdapters.vueAccountEmployeeTimesheetSubmissionStatusTableAdapter
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.GroupHeader2 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.calculatedField1 = New DevExpress.XtraReports.UI.CalculatedField
        Me.calculatedField2 = New DevExpress.XtraReports.UI.CalculatedField
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLabel26 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLabel28 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle
        CType(Me.dsEmployeeTimesheetSubmissionStatusReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel19, Me.xrLabel18, Me.xrLabel17, Me.xrLabel16, Me.xrLabel15, Me.xrLabel14, Me.xrLabel13, Me.xrLabel12, Me.xrLabel11})
        Me.Detail.Height = 20
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("TimeEntryDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.calculatedField1", "")})
        Me.xrLabel19.EvenStyleName = "xtrEvenRow"
        Me.xrLabel19.Location = New System.Drawing.Point(676, 0)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.OddStyleName = "xtrOddRow"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.Size = New System.Drawing.Size(83, 20)
        Me.xrLabel19.StylePriority.UseFont = False
        Me.xrLabel19.StylePriority.UseTextAlignment = False
        Me.xrLabel19.Text = "xrLabel19"
        Me.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        SetReportDetailLabelNewStyle(xrLabel19)
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.Rejected", "")})
        Me.xrLabel18.EvenStyleName = "xtrEvenRow"
        Me.xrLabel18.Location = New System.Drawing.Point(609, 0)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.OddStyleName = "xtrOddRow"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.Size = New System.Drawing.Size(67, 20)
        Me.xrLabel18.StylePriority.UseFont = False
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        Me.xrLabel18.Text = "xrLabel18"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        SetReportDetailLabelNewStyle(xrLabel18)
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.Approved", "")})
        Me.xrLabel17.EvenStyleName = "xtrEvenRow"
        Me.xrLabel17.Location = New System.Drawing.Point(534, 0)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.OddStyleName = "xtrOddRow"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.Size = New System.Drawing.Size(75, 20)
        Me.xrLabel17.StylePriority.UseFont = False
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.Text = "xrLabel17"
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        SetReportDetailLabelNewStyle(xrLabel17)
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.Submitted", "")})
        Me.xrLabel16.EvenStyleName = "xtrEvenRow"
        Me.xrLabel16.Location = New System.Drawing.Point(467, 0)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.OddStyleName = "xtrOddRow"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.Size = New System.Drawing.Size(67, 20)
        Me.xrLabel16.StylePriority.UseFont = False
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        SetReportDetailLabelNewStyle(xrLabel16)
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.Entered", "")})
        Me.xrLabel15.EvenStyleName = "xtrEvenRow"
        Me.xrLabel15.Location = New System.Drawing.Point(392, 0)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.OddStyleName = "xtrOddRow"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.Size = New System.Drawing.Size(75, 20)
        Me.xrLabel15.StylePriority.UseFont = False
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        Me.xrLabel15.Text = "xrLabel15"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        SetReportDetailLabelNewStyle(xrLabel15)
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.calculatedField2", "")})
        Me.xrLabel14.EvenStyleName = "xtrEvenRow"
        Me.xrLabel14.Location = New System.Drawing.Point(317, 0)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.OddStyleName = "xtrOddRow"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.Size = New System.Drawing.Size(75, 20)
        Me.xrLabel14.StylePriority.UseFont = False
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.Text = "xrLabel14"
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        SetReportDetailLabelNewStyle(xrLabel14)
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.TimeEntryDate", "{0:d}")})
        Me.xrLabel13.EvenStyleName = "xtrEvenRow"
        Me.xrLabel13.Location = New System.Drawing.Point(250, 0)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.OddStyleName = "xtrOddRow"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.Size = New System.Drawing.Size(67, 20)
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "xrLabel13"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        SetReportDetailLabelNewStyle(xrLabel13)
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.Role", "")})
        Me.xrLabel12.EvenStyleName = "xtrEvenRow"
        Me.xrLabel12.Location = New System.Drawing.Point(150, 0)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.OddStyleName = "xtrOddRow"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.Size = New System.Drawing.Size(100, 20)
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "xrLabel12"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        SetReportDetailLabelNewStyle(xrLabel12)
        '
        'xrLabel11
        '
        Me.xrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.EmployeeName", "")})
        Me.xrLabel11.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.OddStyleName = "xtrOddRow"
        Me.xrLabel11.EvenStyleName = "xtrEvenRow"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.Size = New System.Drawing.Size(142, 20)
        Me.xrLabel11.StylePriority.UseFont = False
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "xrLabel11"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        SetReportDetailLabelNewStyle(xrLabel11)
        '
        'dsEmployeeTimesheetSubmissionStatusReport1
        '
        Me.dsEmployeeTimesheetSubmissionStatusReport1.DataSetName = "dsEmployeeTimesheetSubmissionStatusReport"
        Me.dsEmployeeTimesheetSubmissionStatusReport1.EnforceConstraints = False
        Me.dsEmployeeTimesheetSubmissionStatusReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.PageFooter.Height = 43
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLine3
        '
        Me.xrLine3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.xrLine3.Location = New System.Drawing.Point(8, 0)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.Size = New System.Drawing.Size(750, 7)
        Me.xrLine3.StylePriority.UseForeColor = False
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo1.Location = New System.Drawing.Point(8, 8)
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
        Me.xrPageInfo2.Location = New System.Drawing.Point(658, 8)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.Size = New System.Drawing.Size(100, 25)
        Me.xrPageInfo2.StylePriority.UseFont = False
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'vueAccountEmployeeTimesheetSubmissionStatusTableAdapter1
        '
        Me.vueAccountEmployeeTimesheetSubmissionStatusTableAdapter1.ClearBeforeFill = True
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel23})
        Me.ReportHeader.Height = 31
        Me.ReportHeader.Name = "ReportHeader"
        '
        'xrLabel23
        '
        'Me.xrLabel23.BackColor = System.Drawing.Color.Silver
        Me.xrLabel23.Font = New System.Drawing.Font(FontStyle, 13.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel23.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.Size = New System.Drawing.Size(750, 21)
        Me.xrLabel23.StylePriority.UseBackColor = False
        Me.xrLabel23.StylePriority.UseFont = False
        Me.xrLabel23.Text = "Employee Timesheet Submission Status Report"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel10, Me.xrLabel9, Me.xrLabel8, Me.xrLabel7, Me.xrLabel6, Me.xrLabel5, Me.xrLabel2, Me.xrLabel4, Me.xrLabel3})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("AccountEmployeeId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.Height = 28
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'xrLabel10
        '
        Me.xrLabel10.CanGrow = False
        Me.xrLabel10.Location = New System.Drawing.Point(676, 0)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.Size = New System.Drawing.Size(83, 30)
        Me.xrLabel10.StylePriority.UseBackColor = False
        Me.xrLabel10.StylePriority.UseBorders = False
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseForeColor = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "Un Apprvoed"
        Me.xrLabel10.WordWrap = False
        SetReportHeaderNewStyle(xrLabel10)
        '
        'xrLabel9
        '
        Me.xrLabel9.Location = New System.Drawing.Point(609, 0)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.Size = New System.Drawing.Size(67, 30)
        Me.xrLabel9.StylePriority.UseBackColor = False
        Me.xrLabel9.StylePriority.UseBorders = False
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseForeColor = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "Rejected"
        SetReportHeaderNewStyle(xrLabel9)
        '
        'xrLabel8
        '
        Me.xrLabel8.Location = New System.Drawing.Point(534, 0)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.Size = New System.Drawing.Size(75, 30)
        Me.xrLabel8.StylePriority.UseBackColor = False
        Me.xrLabel8.StylePriority.UseBorders = False
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.StylePriority.UseForeColor = False
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "Approved"
        SetReportHeaderNewStyle(xrLabel8)
        '
        'xrLabel7
        '
        Me.xrLabel7.Location = New System.Drawing.Point(467, 0)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.Size = New System.Drawing.Size(67, 30)
        Me.xrLabel7.StylePriority.UseBackColor = False
        Me.xrLabel7.StylePriority.UseBorders = False
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseForeColor = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "Submitted"
        SetReportHeaderNewStyle(xrLabel7)
        '
        'xrLabel6
        '
        Me.xrLabel6.Location = New System.Drawing.Point(392, 0)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.Size = New System.Drawing.Size(75, 30)
        Me.xrLabel6.StylePriority.UseBackColor = False
        Me.xrLabel6.StylePriority.UseBorders = False
        Me.xrLabel6.StylePriority.UseFont = False
        Me.xrLabel6.StylePriority.UseForeColor = False
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "Entered"
        SetReportHeaderNewStyle(xrLabel6)
        '
        'xrLabel5
        '
        Me.xrLabel5.CanGrow = False
        Me.xrLabel5.Location = New System.Drawing.Point(317, 0)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.Size = New System.Drawing.Size(75, 30)
        Me.xrLabel5.StylePriority.UseBackColor = False
        Me.xrLabel5.StylePriority.UseBorders = False
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseForeColor = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "Not Entered"
        Me.xrLabel5.WordWrap = False
        SetReportHeaderNewStyle(xrLabel5)
        '
        'xrLabel2
        '
        Me.xrLabel2.Location = New System.Drawing.Point(250, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(67, 30)
        Me.xrLabel2.StylePriority.UseBackColor = False
        Me.xrLabel2.StylePriority.UseBorders = False
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseForeColor = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.Text = "Date"
        SetReportHeaderNewStyle(xrLabel2)
        '
        'xrLabel4
        '
        Me.xrLabel4.Location = New System.Drawing.Point(150, 0)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(100, 30)
        Me.xrLabel4.StylePriority.UseBackColor = False
        Me.xrLabel4.StylePriority.UseBorders = False
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseForeColor = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.Text = "Role"
        SetReportHeaderNewStyle(xrLabel4)
        '
        'xrLabel3
        '
        Me.xrLabel3.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.Size = New System.Drawing.Size(142, 30)
        Me.xrLabel3.StylePriority.UseBackColor = False
        Me.xrLabel3.StylePriority.UseBorders = False
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseForeColor = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "Employee Name"
        SetReportHeaderNewStyle(xrLabel3)
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel25, Me.xrLabel1})
        Me.GroupHeader2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("DepartmentName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader2.Height = 20
        Me.GroupHeader2.Level = 1
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'xrLabel25
        '
        Me.xrLabel25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.DepartmentName", "")})
        Me.xrLabel25.Font = New System.Drawing.Font(FontStyle, 7.25!)
        Me.xrLabel25.Location = New System.Drawing.Point(125, 0)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.Size = New System.Drawing.Size(633, 17)
        Me.xrLabel25.StylePriority.UseFont = False
        Me.xrLabel25.StylePriority.UseTextAlignment = False
        Me.xrLabel25.Text = "xrLabel25"
        Me.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel1
        '
        Me.xrLabel1.Font = New System.Drawing.Font(FontStyle, 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.ForeColor = System.Drawing.Color.Black
        Me.xrLabel1.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(117, 17)
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseForeColor = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "Department Name :"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'calculatedField1
        '
        Me.calculatedField1.DataMember = "vueAccountEmployeeTimesheetSubmissionStatus"
        Me.calculatedField1.DataSource = Me.dsEmployeeTimesheetSubmissionStatusReport1
        Me.calculatedField1.Expression = "isnull([Submitted] - [Approved],0)"
        Me.calculatedField1.Name = "calculatedField1"
        '
        'calculatedField2
        '
        Me.calculatedField2.DataMember = "vueAccountEmployeeTimesheetSubmissionStatus"
        Me.calculatedField2.DataSource = Me.dsEmployeeTimesheetSubmissionStatusReport1
        Me.calculatedField2.Expression = "IIF(NotEntered<>1,'No','Yes')" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.calculatedField2.Name = "calculatedField2"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel26, Me.xrLabel24, Me.xrLabel27, Me.xrLabel22, Me.xrLabel21, Me.xrLabel20})
        Me.GroupFooter1.Height = 51
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrLabel26
        '
        Me.xrLabel26.CanGrow = False
        Me.xrLabel26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.Rejected", "")})
        Me.xrLabel26.Location = New System.Drawing.Point(609, 11)
        Me.xrLabel26.Name = "xrLabel26"
        Me.xrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel26.Size = New System.Drawing.Size(67, 20)
        Me.xrLabel26.StylePriority.UseFont = False
        Me.xrLabel26.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:#}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel26.Summary = xrSummary1
        Me.xrLabel26.Text = "xrLabel26"
        Me.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel26.WordWrap = False
        SetReportFooterDetailNewStyle(xrLabel26)
        '
        'xrLabel24
        '
        Me.xrLabel24.CanGrow = False
        Me.xrLabel24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.Approved", "")})
        Me.xrLabel24.Location = New System.Drawing.Point(534, 11)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.Size = New System.Drawing.Size(75, 20)
        Me.xrLabel24.StylePriority.UseFont = False
        Me.xrLabel24.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:#}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel24.Summary = xrSummary2
        Me.xrLabel24.Text = "xrLabel24"
        Me.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel24.WordWrap = False
        SetReportFooterDetailNewStyle(xrLabel24)
        '
        'xrLine1
        '
        'Me.xrLine1.ForeColor = System.Drawing.SystemColors.ControlText
        'Me.xrLine1.Location = New System.Drawing.Point(8, 30)
        'Me.xrLine1.Name = "xrLine1"
        'Me.xrLine1.Size = New System.Drawing.Size(750, 7)
        'Me.xrLine1.StylePriority.UseForeColor = False
        '
        'xrLine2
        '
        'Me.xrLine2.ForeColor = System.Drawing.SystemColors.ControlText
        'Me.xrLine2.Location = New System.Drawing.Point(8, 3)
        'Me.xrLine2.Name = "xrLine2"
        'Me.xrLine2.Size = New System.Drawing.Size(750, 7)
        'Me.xrLine2.StylePriority.UseForeColor = False
        '
        'xrLabel28
        '
        'Me.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None
        'Me.xrLabel28.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        'Me.xrLabel28.ForeColor = System.Drawing.Color.Black
        'Me.xrLabel28.Location = New System.Drawing.Point(150, 11)
        'Me.xrLabel28.Name = "xrLabel28"
        'Me.xrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        'Me.xrLabel28.Size = New System.Drawing.Size(100, 17)
        'Me.xrLabel28.StylePriority.UseBorders = False
        'Me.xrLabel28.StylePriority.UseFont = False
        'Me.xrLabel28.StylePriority.UseForeColor = False
        'Me.xrLabel28.StylePriority.UseTextAlignment = False
        'Me.xrLabel28.Text = "Total"
        'Me.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel27
        '
        Me.xrLabel27.CanGrow = False
        Me.xrLabel27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.calculatedField1", "")})
        Me.xrLabel27.Location = New System.Drawing.Point(676, 11)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.Size = New System.Drawing.Size(82, 20)
        Me.xrLabel27.StylePriority.UseFont = False
        Me.xrLabel27.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:#}"
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel27.Summary = xrSummary3
        Me.xrLabel27.Text = "xrLabel27"
        Me.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel27.WordWrap = False
        SetReportFooterDetailNewStyle(xrLabel27)
        '
        'xrLabel22
        '
        Me.xrLabel22.CanGrow = False
        Me.xrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.Submitted", "")})
        Me.xrLabel22.Location = New System.Drawing.Point(467, 11)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.Size = New System.Drawing.Size(67, 20)
        Me.xrLabel22.StylePriority.UseFont = False
        Me.xrLabel22.StylePriority.UseTextAlignment = False
        xrSummary4.FormatString = "{0:#}"
        xrSummary4.IgnoreNullValues = True
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel22.Summary = xrSummary4
        Me.xrLabel22.Text = "xrLabel22"
        Me.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel22.WordWrap = False
        SetReportFooterDetailNewStyle(xrLabel22)
        '
        'xrLabel21
        '
        Me.xrLabel21.CanGrow = False
        Me.xrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.Entered", "")})
        Me.xrLabel21.Location = New System.Drawing.Point(392, 11)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.Size = New System.Drawing.Size(75, 20)
        Me.xrLabel21.StylePriority.UseFont = False
        Me.xrLabel21.StylePriority.UseTextAlignment = False
        xrSummary5.FormatString = "{0:#}"
        xrSummary5.IgnoreNullValues = True
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel21.Summary = xrSummary5
        Me.xrLabel21.Text = "xrLabel21"
        Me.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel21.WordWrap = False
        SetReportFooterDetailNewStyle(xrLabel21)
        '
        'xrLabel20
        '
        Me.xrLabel20.Location = New System.Drawing.Point(317, 11)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.Size = New System.Drawing.Size(75, 20)
        Me.xrLabel20.StylePriority.UseBorders = False
        Me.xrLabel20.StylePriority.UseFont = False
        Me.xrLabel20.StylePriority.UseForeColor = False
        Me.xrLabel20.StylePriority.UseTextAlignment = False
        Me.xrLabel20.Text = "Total"
        Me.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        SetReportFooterDetailNewStyle(xrLabel20)
        'Me.xrLabel20.CanGrow = False
        ''Me.xrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimesheetSubmissionStatus.calculatedField2", "")})
        'Me.xrLabel20.Location = New System.Drawing.Point(317, 11)
        'Me.xrLabel20.Name = "xrLabel20"
        'Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        'Me.xrLabel20.Size = New System.Drawing.Size(75, 20)
        'Me.xrLabel20.StylePriority.UseFont = False
        'Me.xrLabel20.StylePriority.UseTextAlignment = False
        'xrSummary6.FormatString = "{0:#}"
        'xrSummary6.IgnoreNullValues = True
        'xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        'Me.xrLabel20.Summary = xrSummary6
        'Me.xrLabel20.Text = "Total"
        'Me.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        'Me.xrLabel20.WordWrap = False
        'SetReportFooterDetailNewStyle(xrLabel20)
        '
        'xtrEvenRow
        '
        'Me.xtrEvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        'Me.xtrEvenRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
        'Me.xtrEvenRow.Borders = DevExpress.XtraPrinting.BorderSide.Top
        'Me.xtrEvenRow.BorderWidth = 1
        Me.xtrEvenRow.Name = "xtrEvenRow"
        '
        'xtrOddRow
        '
        Me.xtrOddRow.BackColor = Drawing.ColorTranslator.FromHtml("#F6F6F6")
        'Me.xtrOddRow.Borders = DevExpress.XtraPrinting.BorderSide.Top
        'Me.xtrOddRow.BorderWidth = 1
        Me.xtrOddRow.Name = "xtrOddRow"
        '
        'xrControlStyle1
        '
        Me.xrControlStyle1.Name = "xrControlStyle1"
        Me.xrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        '
        'xtrEmployeeTimesheetSubmissionStatusReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter, Me.ReportHeader, Me.GroupHeader1, Me.GroupHeader2, Me.GroupFooter1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.calculatedField1, Me.calculatedField2})
        Me.DataAdapter = Me.vueAccountEmployeeTimesheetSubmissionStatusTableAdapter1
        Me.DataMember = "vueAccountEmployeeTimesheetSubmissionStatus"
        Me.DataSource = Me.dsEmployeeTimesheetSubmissionStatusReport1
        Me.Margins = New System.Drawing.Printing.Margins(50, 20, 100, 100)
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.xtrEvenRow, Me.xtrOddRow, Me.xrControlStyle1})
        Me.Version = "11.1"
        CType(Me.dsEmployeeTimesheetSubmissionStatusReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand

#End Region
    Private Sub xtrEmployeeTimeSheetSubmissionStatusReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel23.Text = Resources.TimeLive.Resource.Employee_Timesheet_Submission_Status_Report
        Me.xrLabel1.Text = Resources.TimeLive.Resource.Department_Name_
        Me.xrLabel3.Text = Resources.TimeLive.Resource.Employee_Name
        Me.xrLabel4.Text = Resources.TimeLive.Resource.Role
        Me.xrLabel2.Text = Resources.TimeLive.Resource.Date
        Me.xrLabel5.Text = Resources.TimeLive.Resource.Not_Entered
        Me.xrLabel6.Text = Resources.TimeLive.Resource.Entered
        Me.xrLabel7.Text = Resources.TimeLive.Resource.Submitted
        Me.xrLabel8.Text = Resources.TimeLive.Resource.Approved
        Me.xrLabel9.Text = Resources.TimeLive.Resource.Rejected
        Me.xrLabel10.Text = Resources.TimeLive.Resource.Un_Approved
        Me.xrLabel28.Text = Resources.TimeLive.Resource.Total

    End Sub
    Public Sub SetReportFontStyle()
        'Arial,Sans-Serif Arial Unicode MS
        FontStyle = "Sans-Serif Unicode MS"
    End Sub
    Public Function SetReportHeaderBackColor() As System.Drawing.Color
        Return Drawing.ColorTranslator.FromHtml("#369")
    End Function
    Public Sub SetReportHeaderNewStyle(xrLabel As DevExpress.XtraReports.UI.XRLabel)
        With xrLabel
            .BackColor = Drawing.ColorTranslator.FromHtml("#369")
            .ForeColor = Drawing.Color.White
            .BorderColor = Drawing.Color.White
            .Borders = 15
            .BorderWidth = 1
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        End With
    End Sub
    Public Sub SetReportDetailLabelNewStyle(xrLabel As DevExpress.XtraReports.UI.XRLabel)
        With xrLabel
            xrLabel.Font = New System.Drawing.Font(FontStyle, 8.0!, System.Drawing.FontStyle.Regular)
            xrLabel.BorderColor = Color.Silver
            xrLabel.BorderWidth = 1
            xrLabel.Borders = DevExpress.XtraPrinting.BorderSide.Top
        End With
    End Sub
    Public Sub SetReportFooterDetailNewStyle(xrLabel As DevExpress.XtraReports.UI.XRLabel)
        With xrLabel
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            .BackColor = Drawing.ColorTranslator.FromHtml("#F0F0F0")
            .ForeColor = Drawing.Color.Black
            .Borders = DevExpress.XtraPrinting.BorderSide.Top
            .BorderWidth = 1
            .BorderColor = Drawing.Color.Silver
        End With
    End Sub
End Class