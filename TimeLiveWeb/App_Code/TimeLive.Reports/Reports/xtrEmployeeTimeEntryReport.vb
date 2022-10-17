Public Class xtrEmployeeTimeEntryReport
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
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents vueAccountEmployeeTimeEntryAdapter1 As dsEmployeeTimeEntryReportTableAdapters.vueAccountEmployeeTimeEntryAdapter
    Private WithEvents dsEmployeeTimeEntryReportForXtrReport1 As dsEmployeeTimeEntryReport
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
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupHeaderBand3 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupHeaderBand4 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabelGroupTotalTime As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupFooterBand2 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupFooterBand3 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents cltFldTotalHours As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents cldFldAmount As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrEmployeeTimeEntryReport.resx"
        Dim resources As System.Resources.ResourceManager = Global.Resources.xtrEmployeeTimeEntryReport.ResourceManager
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.dsEmployeeTimeEntryReportForXtrReport1 = New dsEmployeeTimeEntryReport
        Me.vueAccountEmployeeTimeEntryAdapter1 = New dsEmployeeTimeEntryReportTableAdapters.vueAccountEmployeeTimeEntryAdapter
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupHeaderBand3 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupHeaderBand4 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabelGroupTotalTime = New DevExpress.XtraReports.UI.XRLabel
        Me.groupFooterBand2 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupFooterBand3 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.reportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.cltFldTotalHours = New DevExpress.XtraReports.UI.CalculatedField
        Me.cldFldAmount = New DevExpress.XtraReports.UI.CalculatedField
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        CType(Me.dsEmployeeTimeEntryReportForXtrReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel12, Me.xrLabel11, Me.xrLabel10})
        Me.Detail.Height = 25
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.Scripts.OnBeforePrint = resources.GetString("Detail.Scripts.OnBeforePrint")
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.cldFldAmount", "{0:c2}")})
        Me.xrLabel12.EvenStyleName = "xtrEvenRow"
        Me.xrLabel12.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel12.Location = New System.Drawing.Point(550, 0)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.OddStyleName = "xtrOddRow"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.Size = New System.Drawing.Size(100, 25)
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:$0.00}"
        Me.xrLabel12.Summary = xrSummary1
        Me.xrLabel12.Text = "xrLabel12"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel11
        '
        Me.xrLabel11.EvenStyleName = "xtrEvenRow"
        Me.xrLabel11.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel11.Location = New System.Drawing.Point(450, 0)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.OddStyleName = "xtrOddRow"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.Size = New System.Drawing.Size(100, 25)
        Me.xrLabel11.StylePriority.UseFont = False
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "xrLabel11"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel10
        '
        Me.xrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.TaskName", "")})
        Me.xrLabel10.EvenStyleName = "xtrEvenRow"
        Me.xrLabel10.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel10.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.OddStyleName = "xtrOddRow"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.Size = New System.Drawing.Size(442, 25)
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'dsEmployeeTimeEntryReportForXtrReport1
        '
        Me.dsEmployeeTimeEntryReportForXtrReport1.DataSetName = "dsEmployeeTimeEntryReportForXtrReport"
        Me.dsEmployeeTimeEntryReportForXtrReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'vueAccountEmployeeTimeEntryAdapter1
        '
        Me.vueAccountEmployeeTimeEntryAdapter1.ClearBeforeFill = True
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrPageInfo1, Me.xrPageInfo2, Me.xrLine1})
        Me.PageFooter.Height = 50
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        Me.xrPageInfo2.Location = New System.Drawing.Point(558, 17)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.Size = New System.Drawing.Size(92, 25)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.StylePriority.UseFont = False
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLine1
        '
        Me.xrLine1.Location = New System.Drawing.Point(8, 8)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.Size = New System.Drawing.Size(642, 8)
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
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None
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
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1, Me.xrLabel2})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("PartyName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.Height = 22
        Me.groupHeaderBand1.KeepTogether = True
        Me.groupHeaderBand1.Level = 3
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'xrLabel1
        '
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.ForeColor = System.Drawing.Color.Black
        Me.xrLabel1.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(108, 17)
        Me.xrLabel1.StyleName = "FieldCaption"
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseForeColor = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "Party Name :"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.PartyName", "")})
        Me.xrLabel2.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel2.Location = New System.Drawing.Point(125, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(404, 17)
        Me.xrLabel2.StyleName = "DataField"
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLabel4})
        Me.groupHeaderBand2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ProjectName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand2.Height = 22
        Me.groupHeaderBand2.KeepTogether = True
        Me.groupHeaderBand2.Level = 2
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        '
        'xrLabel3
        '
        Me.xrLabel3.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel3.ForeColor = System.Drawing.Color.Black
        Me.xrLabel3.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.Size = New System.Drawing.Size(108, 17)
        Me.xrLabel3.StyleName = "FieldCaption"
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseForeColor = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "Project Name :"
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel4
        '
        Me.xrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.ProjectName", "")})
        Me.xrLabel4.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel4.Location = New System.Drawing.Point(125, 0)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(525, 17)
        Me.xrLabel4.StyleName = "DataField"
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'groupHeaderBand3
        '
        Me.groupHeaderBand3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel5, Me.xrLabel6})
        Me.groupHeaderBand3.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("EmployeeName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand3.Height = 17
        Me.groupHeaderBand3.KeepTogether = True
        Me.groupHeaderBand3.Level = 1
        Me.groupHeaderBand3.Name = "groupHeaderBand3"
        '
        'xrLabel5
        '
        Me.xrLabel5.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel5.ForeColor = System.Drawing.Color.Black
        Me.xrLabel5.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.Size = New System.Drawing.Size(108, 17)
        Me.xrLabel5.StyleName = "FieldCaption"
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseForeColor = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "Employee Name :"
        Me.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel6
        '
        Me.xrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.EmployeeName", "")})
        Me.xrLabel6.Location = New System.Drawing.Point(125, 0)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.Size = New System.Drawing.Size(525, 17)
        Me.xrLabel6.StyleName = "DataField"
        '
        'groupHeaderBand4
        '
        Me.groupHeaderBand4.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel9, Me.xrLabel8, Me.xrLabel7})
        Me.groupHeaderBand4.Height = 33
        Me.groupHeaderBand4.KeepTogether = True
        Me.groupHeaderBand4.Name = "groupHeaderBand4"
        Me.groupHeaderBand4.Scripts.OnBeforePrint = resources.GetString("groupHeaderBand4.Scripts.OnBeforePrint")
        '
        'xrLabel9
        '
        Me.xrLabel9.BackColor = System.Drawing.Color.Silver
        Me.xrLabel9.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel9.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel9.ForeColor = System.Drawing.Color.Black
        Me.xrLabel9.Location = New System.Drawing.Point(550, 7)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.Size = New System.Drawing.Size(100, 25)
        Me.xrLabel9.StyleName = "FieldCaption"
        Me.xrLabel9.StylePriority.UseBackColor = False
        Me.xrLabel9.StylePriority.UseBorders = False
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseForeColor = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "Amount"
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel8
        '
        Me.xrLabel8.BackColor = System.Drawing.Color.Silver
        Me.xrLabel8.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel8.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel8.ForeColor = System.Drawing.Color.Black
        Me.xrLabel8.Location = New System.Drawing.Point(450, 7)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.Size = New System.Drawing.Size(100, 25)
        Me.xrLabel8.StyleName = "FieldCaption"
        Me.xrLabel8.StylePriority.UseBackColor = False
        Me.xrLabel8.StylePriority.UseBorders = False
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.StylePriority.UseForeColor = False
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "Total Hours"
        Me.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel7
        '
        Me.xrLabel7.BackColor = System.Drawing.Color.Silver
        Me.xrLabel7.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel7.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel7.ForeColor = System.Drawing.Color.Black
        Me.xrLabel7.Location = New System.Drawing.Point(8, 7)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.Size = New System.Drawing.Size(442, 25)
        Me.xrLabel7.StyleName = "FieldCaption"
        Me.xrLabel7.StylePriority.UseBackColor = False
        Me.xrLabel7.StylePriority.UseBorders = False
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseForeColor = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "Task Name"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'groupFooterBand1
        '
        Me.groupFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel15, Me.xrLabelGroupTotalTime})
        Me.groupFooterBand1.Height = 31
        Me.groupFooterBand1.KeepTogether = True
        Me.groupFooterBand1.Name = "groupFooterBand1"
        '
        'xrLabel15
        '
        Me.xrLabel15.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.cldFldAmount", "")})
        Me.xrLabel15.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel15.ForeColor = System.Drawing.Color.Black
        Me.xrLabel15.Location = New System.Drawing.Point(550, 0)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.Size = New System.Drawing.Size(100, 25)
        Me.xrLabel15.StyleName = "FieldCaption"
        Me.xrLabel15.StylePriority.UseBorders = False
        Me.xrLabel15.StylePriority.UseFont = False
        Me.xrLabel15.StylePriority.UseForeColor = False
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:c2}"
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel15.Summary = xrSummary2
        Me.xrLabel15.Text = "xrLabel15"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabelGroupTotalTime
        '
        Me.xrLabelGroupTotalTime.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabelGroupTotalTime.CanGrow = False
        Me.xrLabelGroupTotalTime.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabelGroupTotalTime.ForeColor = System.Drawing.Color.Black
        Me.xrLabelGroupTotalTime.Location = New System.Drawing.Point(450, 0)
        Me.xrLabelGroupTotalTime.Multiline = True
        Me.xrLabelGroupTotalTime.Name = "xrLabelGroupTotalTime"
        Me.xrLabelGroupTotalTime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabelGroupTotalTime.Size = New System.Drawing.Size(100, 25)
        Me.xrLabelGroupTotalTime.StyleName = "FieldCaption"
        Me.xrLabelGroupTotalTime.StylePriority.UseBorders = False
        Me.xrLabelGroupTotalTime.StylePriority.UseFont = False
        Me.xrLabelGroupTotalTime.StylePriority.UseForeColor = False
        Me.xrLabelGroupTotalTime.StylePriority.UseTextAlignment = False
        Me.xrLabelGroupTotalTime.Text = "xrLabelGroupTotalTime"
        Me.xrLabelGroupTotalTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabelGroupTotalTime.WordWrap = False
        '
        'groupFooterBand2
        '
        Me.groupFooterBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel19, Me.xrLabel18, Me.xrLabel17})
        Me.groupFooterBand2.Height = 30
        Me.groupFooterBand2.KeepTogether = True
        Me.groupFooterBand2.Level = 1
        Me.groupFooterBand2.Name = "groupFooterBand2"
        Me.groupFooterBand2.Visible = False
        '
        'xrLabel19
        '
        Me.xrLabel19.Location = New System.Drawing.Point(36, 6)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.Size = New System.Drawing.Size(60, 18)
        Me.xrLabel19.StyleName = "FieldCaption"
        Me.xrLabel19.Text = "Sum"
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.BillingRate", "{0:C2}")})
        Me.xrLabel18.Location = New System.Drawing.Point(473, 6)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.Size = New System.Drawing.Size(177, 18)
        Me.xrLabel18.StyleName = "FieldCaption"
        xrSummary3.FormatString = "{0:C2}"
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel18.Summary = xrSummary3
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.TotalTime", "")})
        Me.xrLabel17.Location = New System.Drawing.Point(264, 6)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.Size = New System.Drawing.Size(209, 18)
        Me.xrLabel17.StyleName = "FieldCaption"
        xrSummary4.FormatString = "{0:HH:mm}"
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel17.Summary = xrSummary4
        Me.xrLabel17.Text = "xrLabel17"
        '
        'groupFooterBand3
        '
        Me.groupFooterBand3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel22, Me.xrLabel21, Me.xrLabel20})
        Me.groupFooterBand3.Height = 30
        Me.groupFooterBand3.KeepTogether = True
        Me.groupFooterBand3.Level = 2
        Me.groupFooterBand3.Name = "groupFooterBand3"
        Me.groupFooterBand3.Visible = False
        '
        'xrLabel22
        '
        Me.xrLabel22.Location = New System.Drawing.Point(6, 6)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.Size = New System.Drawing.Size(90, 18)
        Me.xrLabel22.StyleName = "FieldCaption"
        Me.xrLabel22.Text = "Sum"
        '
        'xrLabel21
        '
        Me.xrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.BillingRate", "{0:C2}")})
        Me.xrLabel21.Location = New System.Drawing.Point(473, 6)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.Size = New System.Drawing.Size(177, 18)
        Me.xrLabel21.StyleName = "FieldCaption"
        xrSummary5.FormatString = "{0:C2}"
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel21.Summary = xrSummary5
        '
        'xrLabel20
        '
        Me.xrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.TotalMinutes", "")})
        Me.xrLabel20.Location = New System.Drawing.Point(264, 6)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.Size = New System.Drawing.Size(209, 18)
        Me.xrLabel20.StyleName = "FieldCaption"
        xrSummary6.FormatString = "{0:HH:mm}"
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel20.Summary = xrSummary6
        '
        'reportFooterBand1
        '
        Me.reportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel25, Me.xrLabel24, Me.xrLabel23})
        Me.reportFooterBand1.Height = 30
        Me.reportFooterBand1.Name = "reportFooterBand1"
        Me.reportFooterBand1.Visible = False
        '
        'xrLabel25
        '
        Me.xrLabel25.Location = New System.Drawing.Point(6, 6)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.Size = New System.Drawing.Size(90, 18)
        Me.xrLabel25.StyleName = "FieldCaption"
        Me.xrLabel25.Text = "Grand Total"
        '
        'xrLabel24
        '
        Me.xrLabel24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.BillingRate", "{0:C2}")})
        Me.xrLabel24.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel24.Location = New System.Drawing.Point(550, 0)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.Size = New System.Drawing.Size(100, 18)
        Me.xrLabel24.StyleName = "FieldCaption"
        Me.xrLabel24.StylePriority.UseFont = False
        Me.xrLabel24.StylePriority.UseTextAlignment = False
        xrSummary7.FormatString = "{0:C2}"
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel24.Summary = xrSummary7
        Me.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel23
        '
        Me.xrLabel23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountEmployeeTimeEntry.TotalMinutes", "")})
        Me.xrLabel23.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel23.Location = New System.Drawing.Point(450, 0)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.Size = New System.Drawing.Size(85, 18)
        Me.xrLabel23.StyleName = "FieldCaption"
        Me.xrLabel23.StylePriority.UseFont = False
        Me.xrLabel23.StylePriority.UseTextAlignment = False
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel23.Summary = xrSummary8
        Me.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel13})
        Me.reportHeaderBand1.Height = 33
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel13
        '
        Me.xrLabel13.BackColor = System.Drawing.Color.Silver
        Me.xrLabel13.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel13.ForeColor = System.Drawing.Color.Black
        Me.xrLabel13.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.Size = New System.Drawing.Size(617, 21)
        Me.xrLabel13.StyleName = "Title"
        Me.xrLabel13.StylePriority.UseBackColor = False
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseForeColor = False
        Me.xrLabel13.Text = "Task Billing By Projects/Clients Report"
        '
        'cltFldTotalHours
        '
        Me.cltFldTotalHours.DataMember = "vueAccountEmployeeTimeEntry"
        Me.cltFldTotalHours.DataSource = Me.dsEmployeeTimeEntryReportForXtrReport1
        Me.cltFldTotalHours.DisplayName = "cltFldTotalHours"
        Me.cltFldTotalHours.Expression = "[TotalMinutes] / 60"
        Me.cltFldTotalHours.Name = "cltFldTotalHours"
        '
        'cldFldAmount
        '
        Me.cldFldAmount.DataMember = "vueAccountEmployeeTimeEntry"
        Me.cldFldAmount.DataSource = Me.dsEmployeeTimeEntryReportForXtrReport1
        Me.cldFldAmount.DisplayName = "cltFldAmount"
        Me.cldFldAmount.Expression = "isnull([TotalMinutes] * [BillingRate] / 60,0)"
        Me.cldFldAmount.Name = "cldFldAmount"
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
        'xtrEmployeeTimeEntryReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageFooter, Me.PageHeader, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.groupHeaderBand3, Me.groupHeaderBand4, Me.groupFooterBand1, Me.groupFooterBand2, Me.groupFooterBand3, Me.reportFooterBand1, Me.reportHeaderBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.cltFldTotalHours, Me.cldFldAmount})
        Me.DataAdapter = Me.vueAccountEmployeeTimeEntryAdapter1
        Me.DataMember = "vueAccountEmployeeTimeEntry"
        Me.DataSource = Me.dsEmployeeTimeEntryReportForXtrReport1
        Me.Margins = New System.Drawing.Printing.Margins(100, 78, 100, 100)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField, Me.xtrEvenRow, Me.xtrOddRow})
        Me.Version = "8.2"
        CType(Me.dsEmployeeTimeEntryReportForXtrReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region
    Private Sub xtrEmployeeTimeEntryReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel13.Text = Resources.TimeLive.Resource.TaskBillingByProjectsClientsReport
        Me.xrLabel1.Text = Resources.TimeLive.Resource.Party_Name_
        Me.xrLabel3.Text = Resources.TimeLive.Resource.Project_Name_
        Me.xrLabel5.Text = Resources.TimeLive.Resource.Employee_Name_
        Me.xrLabel7.Text = Resources.TimeLive.Resource.Task_Name
        Me.xrLabel8.Text = Resources.TimeLive.Resource.Total_Hours
        Me.xrLabel9.Text = Resources.TimeLive.Resource.Amount


    End Sub

End Class