Public Class repProjectSummaryExpenseReport
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
    Private WithEvents timeLiveDataSet1 As TimeLiveDataSet
    Private WithEvents vueAccountExpenseEntryForProjectSummaryTableAdapter1 As TimeLiveDataSetTableAdapters.vueAccountExpenseEntryForProjectSummaryTableAdapter
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents calculatedField1 As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents pAccountProjectID As DevExpress.XtraReports.Parameters.Parameter

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "repProjectSummaryExpenseReport.resx"
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.timeLiveDataSet1 = New TimeLiveDataSet
        Me.vueAccountExpenseEntryForProjectSummaryTableAdapter1 = New TimeLiveDataSetTableAdapters.vueAccountExpenseEntryForProjectSummaryTableAdapter
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel
        Me.calculatedField1 = New DevExpress.XtraReports.UI.CalculatedField
        Me.pAccountProjectID = New DevExpress.XtraReports.Parameters.Parameter
        CType(Me.timeLiveDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel8, Me.xrLabel2, Me.xrLabel6, Me.xrLabel5, Me.xrLabel4, Me.xrLabel3, Me.xrLabel1})
        Me.Detail.Height = 18
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel8
        '
        Me.xrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.CurrencyCode", "")})
        Me.xrLabel8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel8.Location = New System.Drawing.Point(467, 0)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.Size = New System.Drawing.Size(61, 17)
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "xrLabel8"
        Me.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.AccountExpenseName", "")})
        Me.xrLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel2.Location = New System.Drawing.Point(100, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(148, 17)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.Text = "xrLabel2"
        Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel6
        '
        Me.xrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.Amount", "{0:0,.00}")})
        Me.xrLabel6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel6.Location = New System.Drawing.Point(714, 0)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.Size = New System.Drawing.Size(106, 17)
        Me.xrLabel6.StylePriority.UseFont = False
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "xrLabel6"
        Me.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel5
        '
        Me.xrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.TaxAmount", "{0:0,.00}")})
        Me.xrLabel5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel5.Location = New System.Drawing.Point(625, 0)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.Size = New System.Drawing.Size(86, 17)
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "xrLabel5"
        Me.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel4
        '
        Me.xrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.NetAmount", "{0:0,.00}")})
        Me.xrLabel4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel4.Location = New System.Drawing.Point(533, 0)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(90, 17)
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.Text = "xrLabel4"
        Me.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel3
        '
        Me.xrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.Description", "")})
        Me.xrLabel3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel3.Location = New System.Drawing.Point(251, 0)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.Size = New System.Drawing.Size(216, 17)
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "xrLabel3"
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel1
        '
        Me.xrLabel1.CanGrow = False
        Me.xrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.AccountExpenseEntryDate", "{0:MM/dd/yyyy}")})
        Me.xrLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel1.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(90, 17)
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "xrLabel1"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        Me.PageFooter.Height = 0
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'timeLiveDataSet1
        '
        Me.timeLiveDataSet1.DataSetName = "TimeLiveDataSet"
        Me.timeLiveDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'vueAccountExpenseEntryForProjectSummaryTableAdapter1
        '
        Me.vueAccountExpenseEntryForProjectSummaryTableAdapter1.ClearBeforeFill = True
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel14, Me.xrLabel13, Me.xrLabel12, Me.xrLabel11, Me.xrLabel10, Me.xrLabel9, Me.xrLabel7})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("AccountProjectId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.Height = 19
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'xrLabel14
        '
        Me.xrLabel14.BackColor = System.Drawing.Color.Silver
        Me.xrLabel14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel14.Location = New System.Drawing.Point(714, 0)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.Size = New System.Drawing.Size(106, 17)
        Me.xrLabel14.StylePriority.UseBackColor = False
        Me.xrLabel14.StylePriority.UseFont = False
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.Text = "Net Amount"
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel13
        '
        Me.xrLabel13.BackColor = System.Drawing.Color.Silver
        Me.xrLabel13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel13.Location = New System.Drawing.Point(625, 0)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.Size = New System.Drawing.Size(86, 17)
        Me.xrLabel13.StylePriority.UseBackColor = False
        Me.xrLabel13.StylePriority.UseFont = False
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "Tax Amount"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel12
        '
        Me.xrLabel12.BackColor = System.Drawing.Color.Silver
        Me.xrLabel12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel12.Location = New System.Drawing.Point(533, 0)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.Size = New System.Drawing.Size(90, 17)
        Me.xrLabel12.StylePriority.UseBackColor = False
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "Amount"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel11
        '
        Me.xrLabel11.BackColor = System.Drawing.Color.Silver
        Me.xrLabel11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel11.Location = New System.Drawing.Point(469, 0)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.Size = New System.Drawing.Size(61, 17)
        Me.xrLabel11.StylePriority.UseBackColor = False
        Me.xrLabel11.StylePriority.UseFont = False
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "Currency"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel10
        '
        Me.xrLabel10.BackColor = System.Drawing.Color.Silver
        Me.xrLabel10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel10.Location = New System.Drawing.Point(251, 0)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.Size = New System.Drawing.Size(216, 17)
        Me.xrLabel10.StylePriority.UseBackColor = False
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "Description"
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel9
        '
        Me.xrLabel9.BackColor = System.Drawing.Color.Silver
        Me.xrLabel9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel9.Location = New System.Drawing.Point(100, 0)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.Size = New System.Drawing.Size(148, 17)
        Me.xrLabel9.StylePriority.UseBackColor = False
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "Expense Name"
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel7
        '
        Me.xrLabel7.BackColor = System.Drawing.Color.Silver
        Me.xrLabel7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel7.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.Size = New System.Drawing.Size(90, 17)
        Me.xrLabel7.StylePriority.UseBackColor = False
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "Date"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine2, Me.xrLine1, Me.xrLabel18, Me.xrLabel17, Me.xrLabel16, Me.xrLabel15})
        Me.GroupFooter1.Height = 35
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrLine2
        '
        Me.xrLine2.Location = New System.Drawing.Point(530, 0)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.Size = New System.Drawing.Size(300, 8)
        '
        'xrLine1
        '
        Me.xrLine1.Location = New System.Drawing.Point(531, 26)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.Size = New System.Drawing.Size(300, 8)
        '
        'xrLabel18
        '
        Me.xrLabel18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel18.Location = New System.Drawing.Point(17, 7)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.Size = New System.Drawing.Size(450, 17)
        Me.xrLabel18.StylePriority.UseFont = False
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        Me.xrLabel18.Text = "Grand Total"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.Amount", "")})
        Me.xrLabel17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel17.Location = New System.Drawing.Point(714, 9)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.Size = New System.Drawing.Size(106, 15)
        Me.xrLabel17.StylePriority.UseFont = False
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:0,0.00}"
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel17.Summary = xrSummary1
        Me.xrLabel17.Text = "xrLabel17"
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.TaxAmount", "")})
        Me.xrLabel16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel16.Location = New System.Drawing.Point(625, 9)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.Size = New System.Drawing.Size(86, 15)
        Me.xrLabel16.StylePriority.UseFont = False
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:0,0.00}"
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel16.Summary = xrSummary2
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueAccountExpenseEntryForProjectSummary.NetAmount", "")})
        Me.xrLabel15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel15.Location = New System.Drawing.Point(534, 9)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.Size = New System.Drawing.Size(91, 15)
        Me.xrLabel15.StylePriority.UseFont = False
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:0,0.00}"
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel15.Summary = xrSummary3
        Me.xrLabel15.Text = "xrLabel15"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'calculatedField1
        '
        Me.calculatedField1.DataMember = "vueAccountExpenseEntryForProjectSummary"
        Me.calculatedField1.DataSource = Me.timeLiveDataSet1
        Me.calculatedField1.Name = "calculatedField1"
        '
        'pAccountProjectID
        '
        Me.pAccountProjectID.Name = "pAccountProjectID"
        Me.pAccountProjectID.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.Int32
        Me.pAccountProjectID.Value = 0
        '
        'repProjectSummaryExpenseReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter, Me.GroupHeader1, Me.GroupFooter1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.calculatedField1})
        Me.DataAdapter = Me.vueAccountExpenseEntryForProjectSummaryTableAdapter1
        Me.DataMember = "vueAccountExpenseEntryForProjectSummary"
        Me.DataSource = Me.timeLiveDataSet1
        Me.FilterString = "[AccountProjectId] = [Parameters.pAccountProjectID]"
        Me.Margins = New System.Drawing.Printing.Margins(18, 0, 19, 100)
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.pAccountProjectID})
        Me.Version = "8.2"
        CType(Me.timeLiveDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand

#End Region

End Class