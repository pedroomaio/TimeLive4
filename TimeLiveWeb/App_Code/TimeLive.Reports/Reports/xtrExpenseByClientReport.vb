Public Class xtrExpenseByClientReport
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
    Private WithEvents lblExchangeRate As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents vueAccountExpenseEntryAdapter1 As dsExpenseByClientTableAdapters.vueAccountExpenseEntryAdapter
    Private WithEvents dsExpenseByClientForXtrReport1 As dsExpenseByClient
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
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents groupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupFooterBand2 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents cltFldAmount As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblCurrencyCode As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents lblAmount As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xtrExpenseByClientReport.resx"
        Dim resources As System.Resources.ResourceManager = Global.Resources.xtrExpenseByClientReport.ResourceManager
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.lblAmount = New DevExpress.XtraReports.UI.XRLabel
        Me.dsExpenseByClientForXtrReport1 = New dsExpenseByClient
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.lblExchangeRate = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.lblCurrencyCode = New DevExpress.XtraReports.UI.XRLabel
        Me.vueAccountExpenseEntryAdapter1 = New dsExpenseByClientTableAdapters.vueAccountExpenseEntryAdapter
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
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
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupHeaderBand3 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.groupFooterBand2 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.reportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.cltFldAmount = New DevExpress.XtraReports.UI.CalculatedField
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine
        CType(Me.dsExpenseByClientForXtrReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAmount, Me.xrLabel12, Me.lblExchangeRate, Me.xrLabel10, Me.xrLabel9})
        Me.Detail.Height = 25
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.Scripts.OnBeforePrint = resources.GetString("Detail.Scripts.OnBeforePrint")
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblAmount
        '
        Me.lblAmount.CanGrow = False
        Me.lblAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsExpenseByClientForXtrReport1, "vueAccountExpenseEntry.Amount", "")})
        Me.lblAmount.Location = New System.Drawing.Point(600, 0)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount.Size = New System.Drawing.Size(75, 18)
        Me.lblAmount.StyleName = "DataField"
        Me.lblAmount.StylePriority.UseTextAlignment = False
        Me.lblAmount.Text = "lblAmount"
        Me.lblAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount.Visible = False
        Me.lblAmount.WordWrap = False
        '
        'dsExpenseByClientForXtrReport1
        '
        Me.dsExpenseByClientForXtrReport1.DataSetName = "dsExpenseByClientForXtrReport"
        Me.dsExpenseByClientForXtrReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'xrLabel12
        '
        Me.xrLabel12.CanGrow = False
        Me.xrLabel12.EvenStyleName = "xtrEvenRow"
        Me.xrLabel12.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel12.Location = New System.Drawing.Point(383, 0)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.OddStyleName = "xtrOddRow"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.Size = New System.Drawing.Size(100, 25)
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel12.WordWrap = False
        '
        'lblExchangeRate
        '
        Me.lblExchangeRate.Location = New System.Drawing.Point(542, 0)
        Me.lblExchangeRate.Name = "lblExchangeRate"
        Me.lblExchangeRate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblExchangeRate.Size = New System.Drawing.Size(58, 18)
        Me.lblExchangeRate.StyleName = "DataField"
        Me.lblExchangeRate.Visible = False
        '
        'xrLabel10
        '
        Me.xrLabel10.CanGrow = False
        Me.xrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsExpenseByClientForXtrReport1, "vueAccountExpenseEntry.ExpenseType", "")})
        Me.xrLabel10.EvenStyleName = "xtrEvenRow"
        Me.xrLabel10.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel10.Location = New System.Drawing.Point(208, 0)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.OddStyleName = "xtrOddRow"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.Size = New System.Drawing.Size(175, 25)
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrLabel10.WordWrap = False
        '
        'xrLabel9
        '
        Me.xrLabel9.CanGrow = False
        Me.xrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsExpenseByClientForXtrReport1, "vueAccountExpenseEntry.AccountExpenseName", "")})
        Me.xrLabel9.EvenStyleName = "xtrEvenRow"
        Me.xrLabel9.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel9.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.OddStyleName = "xtrOddRow"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.Size = New System.Drawing.Size(200, 25)
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrLabel9.WordWrap = False
        '
        'lblCurrencyCode
        '
        Me.lblCurrencyCode.Location = New System.Drawing.Point(500, 0)
        Me.lblCurrencyCode.Name = "lblCurrencyCode"
        Me.lblCurrencyCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCurrencyCode.Size = New System.Drawing.Size(58, 25)
        Me.lblCurrencyCode.StyleName = "DataField"
        Me.lblCurrencyCode.StylePriority.UseTextAlignment = False
        Me.lblCurrencyCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'vueAccountExpenseEntryAdapter1
        '
        Me.vueAccountExpenseEntryAdapter1.ClearBeforeFill = True
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine2, Me.xrPageInfo1, Me.xrPageInfo2})
        Me.PageFooter.Height = 57
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.xrPageInfo1.Location = New System.Drawing.Point(8, 12)
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
        Me.xrPageInfo2.Location = New System.Drawing.Point(383, 12)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.Size = New System.Drawing.Size(100, 25)
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
        Me.groupHeaderBand1.Level = 2
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'xrLabel1
        '
        Me.xrLabel1.BackColor = System.Drawing.Color.White
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.ForeColor = System.Drawing.Color.Black
        Me.xrLabel1.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(94, 17)
        Me.xrLabel1.StyleName = "FieldCaption"
        Me.xrLabel1.StylePriority.UseBackColor = False
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseForeColor = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "Party Name :"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsExpenseByClientForXtrReport1, "vueAccountExpenseEntry.PartyName", "")})
        Me.xrLabel2.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel2.Location = New System.Drawing.Point(102, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(381, 17)
        Me.xrLabel2.StyleName = "DataField"
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLabel4})
        Me.groupHeaderBand2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ProjectName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand2.Height = 17
        Me.groupHeaderBand2.KeepTogether = True
        Me.groupHeaderBand2.Level = 1
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        '
        'xrLabel3
        '
        Me.xrLabel3.BackColor = System.Drawing.Color.White
        Me.xrLabel3.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel3.ForeColor = System.Drawing.Color.Black
        Me.xrLabel3.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.Size = New System.Drawing.Size(94, 17)
        Me.xrLabel3.StyleName = "FieldCaption"
        Me.xrLabel3.StylePriority.UseBackColor = False
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseForeColor = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "Project Name :"
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel4
        '
        Me.xrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsExpenseByClientForXtrReport1, "vueAccountExpenseEntry.ProjectName", "")})
        Me.xrLabel4.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrLabel4.Location = New System.Drawing.Point(102, 0)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(381, 17)
        Me.xrLabel4.StyleName = "DataField"
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'groupHeaderBand3
        '
        Me.groupHeaderBand3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblCurrencyCode, Me.xrLabel5, Me.xrLabel6, Me.xrLabel8})
        Me.groupHeaderBand3.Height = 25
        Me.groupHeaderBand3.KeepTogether = True
        Me.groupHeaderBand3.Name = "groupHeaderBand3"
        Me.groupHeaderBand3.Scripts.OnBeforePrint = "Private Sub OnBeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Print" & _
            "ing.PrintEventArgs)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DetailExchangeRate = 0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DetailAmount = 0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GroupAmount = 0" & _
            "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TotalAmount = 0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "End Sub"
        '
        'xrLabel5
        '
        Me.xrLabel5.BackColor = System.Drawing.Color.Silver
        Me.xrLabel5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel5.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel5.ForeColor = System.Drawing.Color.Black
        Me.xrLabel5.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.Size = New System.Drawing.Size(200, 25)
        Me.xrLabel5.StyleName = "FieldCaption"
        Me.xrLabel5.StylePriority.UseBackColor = False
        Me.xrLabel5.StylePriority.UseBorders = False
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseForeColor = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "Expense Name"
        Me.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel6
        '
        Me.xrLabel6.BackColor = System.Drawing.Color.Silver
        Me.xrLabel6.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrLabel6.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel6.ForeColor = System.Drawing.Color.Black
        Me.xrLabel6.Location = New System.Drawing.Point(208, 0)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.Size = New System.Drawing.Size(175, 25)
        Me.xrLabel6.StyleName = "FieldCaption"
        Me.xrLabel6.StylePriority.UseBackColor = False
        Me.xrLabel6.StylePriority.UseBorders = False
        Me.xrLabel6.StylePriority.UseFont = False
        Me.xrLabel6.StylePriority.UseForeColor = False
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "Expense Type"
        Me.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.xrLabel8.Location = New System.Drawing.Point(383, 0)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.Size = New System.Drawing.Size(100, 25)
        Me.xrLabel8.StyleName = "FieldCaption"
        Me.xrLabel8.StylePriority.UseBackColor = False
        Me.xrLabel8.StylePriority.UseBorders = False
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.StylePriority.UseForeColor = False
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "Amount"
        Me.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrLabel8.WordWrap = False
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
        Me.xrLabel20.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel20.ForeColor = System.Drawing.Color.Black
        Me.xrLabel20.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.Size = New System.Drawing.Size(475, 21)
        Me.xrLabel20.StyleName = "Title"
        Me.xrLabel20.StylePriority.UseBackColor = False
        Me.xrLabel20.StylePriority.UseFont = False
        Me.xrLabel20.StylePriority.UseForeColor = False
        Me.xrLabel20.Text = "Expense By Client Report"
        '
        'groupFooterBand1
        '
        Me.groupFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel13, Me.xrLine1, Me.xrLine3, Me.xrLabel14})
        Me.groupFooterBand1.Height = 48
        Me.groupFooterBand1.Name = "groupFooterBand1"
        '
        'xrLabel13
        '
        Me.xrLabel13.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel13.ForeColor = System.Drawing.Color.Black
        Me.xrLabel13.Location = New System.Drawing.Point(208, 9)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.Size = New System.Drawing.Size(94, 17)
        Me.xrLabel13.StyleName = "FieldCaption"
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseForeColor = False
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "Total"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLine1
        '
        Me.xrLine1.Location = New System.Drawing.Point(8, 27)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.Size = New System.Drawing.Size(475, 8)
        '
        'xrLine3
        '
        Me.xrLine3.BorderWidth = 1
        Me.xrLine3.Location = New System.Drawing.Point(8, 0)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.Size = New System.Drawing.Size(475, 8)
        Me.xrLine3.StylePriority.UseBorderWidth = False
        '
        'xrLabel14
        '
        Me.xrLabel14.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel14.ForeColor = System.Drawing.Color.Black
        Me.xrLabel14.Location = New System.Drawing.Point(383, 9)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.Size = New System.Drawing.Size(100, 17)
        Me.xrLabel14.StyleName = "FieldCaption"
        Me.xrLabel14.StylePriority.UseFont = False
        Me.xrLabel14.StylePriority.UseForeColor = False
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'groupFooterBand2
        '
        Me.groupFooterBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel17, Me.xrLabel16})
        Me.groupFooterBand2.Height = 30
        Me.groupFooterBand2.Level = 1
        Me.groupFooterBand2.Name = "groupFooterBand2"
        Me.groupFooterBand2.Visible = False
        '
        'xrLabel17
        '
        Me.xrLabel17.Location = New System.Drawing.Point(6, 6)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.Size = New System.Drawing.Size(60, 18)
        Me.xrLabel17.StyleName = "FieldCaption"
        Me.xrLabel17.Text = "Sum"
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsExpenseByClientForXtrReport1, "vueAccountExpenseEntry.Amount", "")})
        Me.xrLabel16.Location = New System.Drawing.Point(565, 6)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.Size = New System.Drawing.Size(79, 18)
        Me.xrLabel16.StyleName = "FieldCaption"
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel16.Summary = xrSummary1
        '
        'reportFooterBand1
        '
        Me.reportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel19, Me.xrLabel18})
        Me.reportFooterBand1.Height = 30
        Me.reportFooterBand1.Name = "reportFooterBand1"
        Me.reportFooterBand1.Visible = False
        '
        'xrLabel19
        '
        Me.xrLabel19.Location = New System.Drawing.Point(6, 6)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.Size = New System.Drawing.Size(60, 18)
        Me.xrLabel19.StyleName = "FieldCaption"
        Me.xrLabel19.Text = "Grand Total"
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Me.dsExpenseByClientForXtrReport1, "vueAccountExpenseEntry.Amount", "")})
        Me.xrLabel18.Location = New System.Drawing.Point(565, 6)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.Size = New System.Drawing.Size(79, 18)
        Me.xrLabel18.StyleName = "FieldCaption"
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel18.Summary = xrSummary2
        '
        'cltFldAmount
        '
        Me.cltFldAmount.DataMember = "vueAccountExpenseEntry"
        Me.cltFldAmount.DataSource = Me.dsExpenseByClientForXtrReport1
        Me.cltFldAmount.Expression = "isnull([Amount] * [ExchangeRate],0)"
        Me.cltFldAmount.FieldType = DevExpress.XtraReports.UI.FieldType.Float
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
        'xrLine2
        '
        Me.xrLine2.Location = New System.Drawing.Point(8, 4)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.Size = New System.Drawing.Size(475, 8)
        '
        'xtrExpenseByClientReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageFooter, Me.PageHeader, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.groupHeaderBand3, Me.reportHeaderBand1, Me.groupFooterBand1, Me.groupFooterBand2, Me.reportFooterBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.cltFldAmount})
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField, Me.xtrEvenRow, Me.xtrOddRow})
        Me.Version = "8.2"
        CType(Me.dsExpenseByClientForXtrReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region
    Private Sub xtrExpenseByClientReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel20.Text = Resources.TimeLive.Resource.Expense_By_Client_Report
        Me.xrLabel1.Text = Resources.TimeLive.Resource.Party_Name_
        Me.xrLabel3.Text = Resources.TimeLive.Resource.Project_Name_
        Me.xrLabel5.Text = Resources.TimeLive.Resource.Expense_Name
        Me.xrLabel6.Text = Resources.TimeLive.Resource.Expense_Type
        Me.xrLabel8.Text = Resources.TimeLive.Resource.Amount
        Me.xrLabel13.Text = Resources.TimeLive.Resource.Total
        Me.xrLabel19.Text = Resources.TimeLive.Resource.Grand_Total_

    End Sub
End Class