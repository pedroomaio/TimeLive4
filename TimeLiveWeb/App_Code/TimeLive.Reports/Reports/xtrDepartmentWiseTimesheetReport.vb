Public Class xtrDepartmentWiseTimesheetReport
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
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents vueAccountEmployeeTimeEntryAdapter1 As dsDepartmentWiseTimesheetReportForXtrReportTableAdapters.vueAccountEmployeeTimeEntryAdapter
    Private WithEvents dsDepartmentWiseTimesheetReportForXtrReport1 As dsDepartmentWiseTimesheetReportForXtrReport
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents groupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents groupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents cltFldApproved As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents cltFldAmount As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrLine4 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents calculatedField1 As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents calculatedField2 As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cltfldSubmitted As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrDepartmentWiseTimesheetReport.resx"
        Dim resources As System.Resources.ResourceManager = Global.Resources.xtrDepartmentWiseTimesheetReport.ResourceManager
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.dsDepartmentWiseTimesheetReportForXtrReport1 = New dsDepartmentWiseTimesheetReportForXtrReport
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel
        Me.vueAccountEmployeeTimeEntryAdapter1 = New dsDepartmentWiseTimesheetReportForXtrReportTableAdapters.vueAccountEmployeeTimeEntryAdapter
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLine4 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.reportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.cltFldApproved = New DevExpress.XtraReports.UI.CalculatedField
        Me.cltFldAmount = New DevExpress.XtraReports.UI.CalculatedField
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.calculatedField1 = New DevExpress.XtraReports.UI.CalculatedField
        Me.calculatedField2 = New DevExpress.XtraReports.UI.CalculatedField
        Me.cltfldSubmitted = New DevExpress.XtraReports.UI.CalculatedField
        CType(Me.dsDepartmentWiseTimesheetReportForXtrReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel13, Me.xrLabel10, Me.xrLabel11, Me.xrLabel12, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel24})
        Me.Detail.Height = 28
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.Scripts.OnBeforePrint = resources.GetString("Detail.Scripts.OnBeforePrint")
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.TimeEntryDate", "{0:d}")})
        Me.xrLabel13.EvenStyleName = "xtrEvenRow"
        Me.xrLabel13.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel13.Location = New System.Drawing.Point(425, 0)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.OddStyleName = "xtrOddRow"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.Size = New System.Drawing.Size(67, 28)
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'dsDepartmentWiseTimesheetReportForXtrReport1
        '
        Me.dsDepartmentWiseTimesheetReportForXtrReport1.DataSetName = "dsDepartmentWiseTimesheetReportForXtrReport"
        Me.dsDepartmentWiseTimesheetReportForXtrReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'xrLabel10
        '
        Me.xrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.EmployeeName", "")})
        Me.xrLabel10.EvenStyleName = "xtrEvenRow"
        Me.xrLabel10.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel10.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.OddStyleName = "xtrOddRow"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.Size = New System.Drawing.Size(167, 28)
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel11
        '
        Me.xrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.ProjectName", "")})
        Me.xrLabel11.EvenStyleName = "xtrEvenRow"
        Me.xrLabel11.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel11.Location = New System.Drawing.Point(175, 0)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.OddStyleName = "xtrOddRow"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.Size = New System.Drawing.Size(133, 28)
        Me.xrLabel11.StylePriority.UseFont = False
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.TaskName", "")})
        Me.xrLabel12.EvenStyleName = "xtrEvenRow"
        Me.xrLabel12.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel12.Location = New System.Drawing.Point(308, 0)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.OddStyleName = "xtrOddRow"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.Size = New System.Drawing.Size(117, 28)
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.TotalTime", "{0:HH:mm}")})
        Me.xrLabel14.EvenStyleName = "xtrEvenRow"
        Me.xrLabel14.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel14.Location = New System.Drawing.Point(492, 0)
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
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.cltFldAmount", "{0:c2}")})
        Me.xrLabel15.EvenStyleName = "xtrEvenRow"
        Me.xrLabel15.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel15.Location = New System.Drawing.Point(711, 0)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.OddStyleName = "xtrOddRow"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.Size = New System.Drawing.Size(75, 28)
        Me.xrLabel15.StylePriority.UseFont = False
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        Me.xrLabel15.Text = "xrLabel15"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.cltFldApproved", "")})
        Me.xrLabel16.EvenStyleName = "xtrEvenRow"
        Me.xrLabel16.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel16.Location = New System.Drawing.Point(635, 0)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.OddStyleName = "xtrOddRow"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.Size = New System.Drawing.Size(76, 28)
        Me.xrLabel16.StylePriority.UseFont = False
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel24
        '
        Me.xrLabel24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.cltfldSubmitted", "")})
        Me.xrLabel24.EvenStyleName = "xtrEvenRow"
        Me.xrLabel24.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel24.Location = New System.Drawing.Point(568, 0)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.OddStyleName = "xtrOddRow"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.Size = New System.Drawing.Size(67, 28)
        Me.xrLabel24.StylePriority.UseFont = False
        Me.xrLabel24.StylePriority.UseTextAlignment = False
        Me.xrLabel24.Text = "xrLabel24"
        Me.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'vueAccountEmployeeTimeEntryAdapter1
        '
        Me.vueAccountEmployeeTimeEntryAdapter1.ClearBeforeFill = True
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine3, Me.xrPageInfo1, Me.xrPageInfo2})
        Me.PageFooter.Height = 61
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLine3
        '
        Me.xrLine3.Location = New System.Drawing.Point(8, 9)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.Size = New System.Drawing.Size(775, 8)
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo1.Location = New System.Drawing.Point(8, 17)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.Size = New System.Drawing.Size(233, 25)
        Me.xrPageInfo1.StyleName = "PageInfo"
        Me.xrPageInfo1.StylePriority.UseFont = False
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.Location = New System.Drawing.Point(694, 17)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.Size = New System.Drawing.Size(92, 25)
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
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1, Me.xrLabel2})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("DepartmentName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.Height = 24
        Me.groupHeaderBand1.Level = 1
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        Me.groupHeaderBand1.Scripts.OnBeforePrint = resources.GetString("groupHeaderBand1.Scripts.OnBeforePrint")
        '
        'xrLabel1
        '
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.Location = New System.Drawing.Point(6, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(123, 17)
        Me.xrLabel1.StyleName = "FieldCaption"
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.Text = "Department Name :"
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.DepartmentName", "")})
        Me.xrLabel2.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel2.Location = New System.Drawing.Point(129, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(654, 17)
        Me.xrLabel2.StyleName = "DataField"
        Me.xrLabel2.StylePriority.UseFont = False
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel25, Me.xrLabel3, Me.xrLabel4, Me.xrLabel5, Me.xrLabel6, Me.xrLabel7, Me.xrLabel8, Me.xrLabel9})
        Me.groupHeaderBand2.Height = 25
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        '
        'xrLabel25
        '
        Me.xrLabel25.BackColor = System.Drawing.Color.Silver
        Me.xrLabel25.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel25.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel25.Location = New System.Drawing.Point(568, 0)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.Size = New System.Drawing.Size(67, 25)
        Me.xrLabel25.StyleName = "FieldCaption"
        Me.xrLabel25.StylePriority.UseBackColor = False
        Me.xrLabel25.StylePriority.UseBorders = False
        Me.xrLabel25.StylePriority.UseFont = False
        Me.xrLabel25.StylePriority.UseTextAlignment = False
        Me.xrLabel25.Text = "Submitted"
        Me.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.xrLabel3.Size = New System.Drawing.Size(167, 25)
        Me.xrLabel3.StyleName = "FieldCaption"
        Me.xrLabel3.StylePriority.UseBackColor = False
        Me.xrLabel3.StylePriority.UseBorders = False
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "Employee Name"
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel4
        '
        Me.xrLabel4.BackColor = System.Drawing.Color.Silver
        Me.xrLabel4.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel4.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel4.Location = New System.Drawing.Point(175, 0)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(133, 25)
        Me.xrLabel4.StyleName = "FieldCaption"
        Me.xrLabel4.StylePriority.UseBackColor = False
        Me.xrLabel4.StylePriority.UseBorders = False
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.Text = "Project Name"
        Me.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel5
        '
        Me.xrLabel5.BackColor = System.Drawing.Color.Silver
        Me.xrLabel5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel5.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel5.Location = New System.Drawing.Point(308, 0)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.Size = New System.Drawing.Size(117, 25)
        Me.xrLabel5.StyleName = "FieldCaption"
        Me.xrLabel5.StylePriority.UseBackColor = False
        Me.xrLabel5.StylePriority.UseBorders = False
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "Task Name"
        Me.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel6
        '
        Me.xrLabel6.BackColor = System.Drawing.Color.Silver
        Me.xrLabel6.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel6.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel6.Location = New System.Drawing.Point(425, 0)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.Size = New System.Drawing.Size(67, 25)
        Me.xrLabel6.StyleName = "FieldCaption"
        Me.xrLabel6.StylePriority.UseBackColor = False
        Me.xrLabel6.StylePriority.UseBorders = False
        Me.xrLabel6.StylePriority.UseFont = False
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "Date"
        Me.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel7
        '
        Me.xrLabel7.BackColor = System.Drawing.Color.Silver
        Me.xrLabel7.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel7.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel7.Location = New System.Drawing.Point(492, 0)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.Size = New System.Drawing.Size(76, 25)
        Me.xrLabel7.StyleName = "FieldCaption"
        Me.xrLabel7.StylePriority.UseBackColor = False
        Me.xrLabel7.StylePriority.UseBorders = False
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "Total Time"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel8
        '
        Me.xrLabel8.BackColor = System.Drawing.Color.Silver
        Me.xrLabel8.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel8.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel8.Location = New System.Drawing.Point(635, 0)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.Size = New System.Drawing.Size(76, 25)
        Me.xrLabel8.StyleName = "FieldCaption"
        Me.xrLabel8.StylePriority.UseBackColor = False
        Me.xrLabel8.StylePriority.UseBorders = False
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "Approved"
        Me.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel9
        '
        Me.xrLabel9.BackColor = System.Drawing.Color.Silver
        Me.xrLabel9.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel9.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel9.Location = New System.Drawing.Point(711, 0)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.Size = New System.Drawing.Size(75, 25)
        Me.xrLabel9.StyleName = "FieldCaption"
        Me.xrLabel9.StylePriority.UseBackColor = False
        Me.xrLabel9.StylePriority.UseBorders = False
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "Amount"
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel23})
        Me.reportHeaderBand1.Height = 31
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel23
        '
        Me.xrLabel23.BackColor = System.Drawing.Color.Silver
        Me.xrLabel23.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel23.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.Size = New System.Drawing.Size(775, 21)
        Me.xrLabel23.StyleName = "Title"
        Me.xrLabel23.StylePriority.UseBackColor = False
        Me.xrLabel23.StylePriority.UseFont = False
        Me.xrLabel23.Text = "Department Wise Timesheet Report"
        '
        'groupFooterBand1
        '
        Me.groupFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine1, Me.xrLine4, Me.xrLabel19, Me.xrLabel18, Me.xrLabel17})
        Me.groupFooterBand1.Height = 37
        Me.groupFooterBand1.Name = "groupFooterBand1"
        '
        'xrLine1
        '
        Me.xrLine1.Location = New System.Drawing.Point(8, 29)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.Size = New System.Drawing.Size(775, 8)
        '
        'xrLine4
        '
        Me.xrLine4.Location = New System.Drawing.Point(8, 2)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.Size = New System.Drawing.Size(775, 8)
        '
        'xrLabel19
        '
        Me.xrLabel19.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel19.Location = New System.Drawing.Point(308, 11)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.Size = New System.Drawing.Size(90, 18)
        Me.xrLabel19.StyleName = "FieldCaption"
        Me.xrLabel19.StylePriority.UseFont = False
        Me.xrLabel19.StylePriority.UseTextAlignment = False
        Me.xrLabel19.Text = "Total :"
        Me.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.cltFldAmount", "{0:C2}")})
        Me.xrLabel18.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel18.Location = New System.Drawing.Point(711, 11)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.Size = New System.Drawing.Size(75, 18)
        Me.xrLabel18.StyleName = "FieldCaption"
        Me.xrLabel18.StylePriority.UseFont = False
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:C2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel18.Summary = xrSummary1
        Me.xrLabel18.Text = "xrLabel18"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel17
        '
        Me.xrLabel17.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel17.Location = New System.Drawing.Point(492, 11)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.Size = New System.Drawing.Size(76, 18)
        Me.xrLabel17.StyleName = "FieldCaption"
        Me.xrLabel17.StylePriority.UseFont = False
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'reportFooterBand1
        '
        Me.reportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine2, Me.xrLabel22, Me.xrLabel21, Me.xrLabel20})
        Me.reportFooterBand1.Height = 28
        Me.reportFooterBand1.Name = "reportFooterBand1"
        '
        'xrLine2
        '
        Me.xrLine2.Location = New System.Drawing.Point(8, 18)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.Size = New System.Drawing.Size(775, 8)
        '
        'xrLabel22
        '
        Me.xrLabel22.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel22.Location = New System.Drawing.Point(308, 0)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.Size = New System.Drawing.Size(100, 18)
        Me.xrLabel22.StyleName = "FieldCaption"
        Me.xrLabel22.StylePriority.UseFont = False
        Me.xrLabel22.StylePriority.UseTextAlignment = False
        Me.xrLabel22.Text = "Grand Total :"
        Me.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel21
        '
        Me.xrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsDepartmentWiseTimesheetReportForXtrReport1, "vueAccountEmployeeTimeEntry.cltFldAmount", "{0:C2}")})
        Me.xrLabel21.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel21.Location = New System.Drawing.Point(711, 0)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.Size = New System.Drawing.Size(75, 18)
        Me.xrLabel21.StyleName = "FieldCaption"
        Me.xrLabel21.StylePriority.UseFont = False
        Me.xrLabel21.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:C2}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel21.Summary = xrSummary2
        Me.xrLabel21.Text = "xrLabel21"
        Me.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel20
        '
        Me.xrLabel20.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel20.Location = New System.Drawing.Point(492, 0)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.Size = New System.Drawing.Size(76, 18)
        Me.xrLabel20.StyleName = "FieldCaption"
        Me.xrLabel20.StylePriority.UseFont = False
        Me.xrLabel20.StylePriority.UseTextAlignment = False
        Me.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cltFldApproved
        '
        Me.cltFldApproved.DataMember = "vueAccountEmployeeTimeEntry"
        Me.cltFldApproved.DataSource = Me.dsDepartmentWiseTimesheetReportForXtrReport1
        Me.cltFldApproved.Expression = "Iif([Approved]=True,'Yes'  ,'No' )"
        Me.cltFldApproved.Name = "cltFldApproved"
        '
        'cltFldAmount
        '
        Me.cltFldAmount.DataMember = "vueAccountEmployeeTimeEntry"
        Me.cltFldAmount.DataSource = Me.dsDepartmentWiseTimesheetReportForXtrReport1
        Me.cltFldAmount.DisplayName = "cltFldAmount"
        Me.cltFldAmount.Expression = "isnull([TotalMinutes] * [BillingRate] / 60,0)"
        Me.cltFldAmount.Name = "cltFldAmount"
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
        'calculatedField1
        '
        Me.calculatedField1.DataMember = "vueAccountEmployeeTimeEntry"
        Me.calculatedField1.Name = "calculatedField1"
        '
        'calculatedField2
        '
        Me.calculatedField2.DataMember = "vueAccountEmployeeTimeEntry"
        Me.calculatedField2.Name = "calculatedField2"
        '
        'cltfldSubmitted
        '
        Me.cltfldSubmitted.DataMember = "vueAccountEmployeeTimeEntry"
        Me.cltfldSubmitted.DataSource = Me.dsDepartmentWiseTimesheetReportForXtrReport1
        Me.cltfldSubmitted.DisplayName = "cltfldSubmitted"
        Me.cltfldSubmitted.Expression = "Iif([Submitted]=True,'Yes'  ,'No' )"
        Me.cltfldSubmitted.Name = "cltfldSubmitted"
        '
        'xtrDepartmentWiseTimesheetReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageFooter, Me.PageHeader, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.reportHeaderBand1, Me.groupFooterBand1, Me.reportFooterBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.cltFldApproved, Me.cltFldAmount, Me.calculatedField1, Me.calculatedField2, Me.cltfldSubmitted})
        Me.Margins = New System.Drawing.Printing.Margins(0, 18, 50, 50)
        Me.PageWidth = 823
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField, Me.xtrEvenRow, Me.xtrOddRow})
        Me.Version = "8.2"
        CType(Me.dsDepartmentWiseTimesheetReportForXtrReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region
    Private Sub xtrClientListReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel23.Text = Resources.TimeLive.Resource.Department_Wise_Timesheet_Report
        Me.xrLabel1.Text = Resources.TimeLive.Resource.Department_Name
        Me.xrLabel3.Text = Resources.TimeLive.Resource.Employee_Name
        Me.xrLabel4.Text = Resources.TimeLive.Resource.Project_Name
        Me.xrLabel5.Text = Resources.TimeLive.Resource.Task_Name
        Me.xrLabel6.Text = Resources.TimeLive.Resource.Date
        Me.xrLabel7.Text = Resources.TimeLive.Resource.Total_Time
        Me.xrLabel25.Text = Resources.TimeLive.Resource.Submitted
        Me.xrLabel8.Text = Resources.TimeLive.Resource.Approved
        Me.xrLabel9.Text = Resources.TimeLive.Resource.Amount
        Me.xrLabel19.Text = Resources.TimeLive.Resource.Total_
        Me.xrLabel22.Text = Resources.TimeLive.Resource.Grand_Total_



    End Sub
End Class