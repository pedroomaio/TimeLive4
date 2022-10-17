Public Class xtrLeaveSummaryReport
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
    Private WithEvents dsLeaveSummaryReport1 As dsLeaveSummaryReport
    Private WithEvents vueAccountAttendanceTableAdapter1 As dsEmployeeAttendanceSummaryReportTableAdapters.vueAccountAttendanceTableAdapter
    Private WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrLeaveSummaryReport.resx"
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.dsLeaveSummaryReport1 = New dsLeaveSummaryReport
        Me.vueAccountAttendanceTableAdapter1 = New dsEmployeeAttendanceSummaryReportTableAdapters.vueAccountAttendanceTableAdapter
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        CType(Me.dsLeaveSummaryReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel4, Me.xrLabel2})
        Me.Detail.Height = 25
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel4
        '
        Me.xrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountAttendance.TotalAbsenceDescription", "")})
        Me.xrLabel4.EvenStyleName = "xtrEvenRow"
        Me.xrLabel4.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel4.Location = New System.Drawing.Point(233, 0)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.OddStyleName = "xtrOddRow"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(90, 25)
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.Text = "xrLabel4"
        Me.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountAttendance.AbsenceDescription", "")})
        Me.xrLabel2.EvenStyleName = "xtrEvenRow"
        Me.xrLabel2.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel2.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.OddStyleName = "xtrOddRow"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(225, 25)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.Text = "xrLabel2"
        Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1, Me.xrLabel3})
        Me.PageHeader.Height = 25
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel1
        '
        Me.xrLabel1.BackColor = System.Drawing.Color.Silver
        Me.xrLabel1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.Location = New System.Drawing.Point(233, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(90, 25)
        Me.xrLabel1.StylePriority.UseBackColor = False
        Me.xrLabel1.StylePriority.UseBorders = False
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "Total"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel3
        '
        Me.xrLabel3.BackColor = System.Drawing.Color.Silver
        Me.xrLabel3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel3.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel3.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.Size = New System.Drawing.Size(225, 25)
        Me.xrLabel3.StylePriority.UseBackColor = False
        Me.xrLabel3.StylePriority.UseBorders = False
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "Absence Type"
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine1, Me.xrPageInfo2, Me.xrPageInfo1})
        Me.PageFooter.Height = 52
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLine1
        '
        Me.xrLine1.Location = New System.Drawing.Point(8, 0)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.Size = New System.Drawing.Size(625, 8)
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.Location = New System.Drawing.Point(533, 17)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.Size = New System.Drawing.Size(100, 25)
        Me.xrPageInfo2.StylePriority.UseFont = False
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo1.Location = New System.Drawing.Point(8, 17)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.Size = New System.Drawing.Size(233, 25)
        Me.xrPageInfo1.StylePriority.UseFont = False
        '
        'dsLeaveSummaryReport1
        '
        Me.dsLeaveSummaryReport1.DataSetName = "dsLeaveSummaryReport"
        Me.dsLeaveSummaryReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'vueAccountAttendanceTableAdapter1
        '
        Me.vueAccountAttendanceTableAdapter1.ClearBeforeFill = True
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel23})
        Me.ReportHeader.Height = 31
        Me.ReportHeader.Name = "ReportHeader"
        '
        'xrLabel23
        '
        Me.xrLabel23.BackColor = System.Drawing.Color.Silver
        Me.xrLabel23.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel23.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.Size = New System.Drawing.Size(625, 21)
        Me.xrLabel23.StylePriority.UseBackColor = False
        Me.xrLabel23.StylePriority.UseFont = False
        Me.xrLabel23.Text = "Leave Summary Report"
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
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel15, Me.xrLabel13, Me.xrLabel10})
        Me.ReportFooter.Height = 33
        Me.ReportFooter.Name = "ReportFooter"
        '
        'xrLabel15
        '
        Me.xrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrLabel15.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel15.Location = New System.Drawing.Point(160, 8)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.Size = New System.Drawing.Size(40, 20)
        Me.xrLabel15.StylePriority.UseBorders = False
        Me.xrLabel15.StylePriority.UseFont = False
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        Me.xrLabel15.Text = "Days"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountAttendance.TotalAbsenceDescription", "")})
        Me.xrLabel13.EvenStyleName = "xtrEvenRow"
        Me.xrLabel13.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel13.Location = New System.Drawing.Point(120, 8)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.OddStyleName = "xtrOddRow"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.Size = New System.Drawing.Size(40, 20)
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:#,#}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel13.Summary = xrSummary1
        Me.xrLabel13.Text = "xrLabel13"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel10
        '
        Me.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrLabel10.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel10.Location = New System.Drawing.Point(8, 8)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.Size = New System.Drawing.Size(110, 20)
        Me.xrLabel10.StylePriority.UseBorders = False
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "Total Absent :"
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xtrLeaveSummaryReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter, Me.ReportHeader, Me.ReportFooter})
        Me.DataAdapter = Me.vueAccountAttendanceTableAdapter1
        Me.DataMember = "vueAccountAttendance"
        Me.DataSource = Me.dsLeaveSummaryReport1
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.xtrEvenRow, Me.xtrOddRow})
        Me.Version = "8.2"
        CType(Me.dsLeaveSummaryReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand

#End Region
    Private Sub xtrLeaveSummaryReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel23.Text = Resources.TimeLive.Resource.Leave_Summary_Report
        Me.xrLabel3.Text = Resources.TimeLive.Resource.Absence_Type
        Me.xrLabel1.Text = Resources.TimeLive.Resource.Total
        Me.xrLabel10.Text = Resources.TimeLive.Resource.TotalAbsent
        Me.xrLabel15.Text = Resources.TimeLive.Resource.Days

    End Sub
End Class