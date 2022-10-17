Public Class subTimeBillingExpenseReport
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
    Private WithEvents dsTimeBillingExpenseSubReport1 As dsTimeBillingExpenseSubReport
    Private WithEvents accountExpenseTableAdapter1 As TimeLiveFileHelperTableAdapters.AccountExpenseTableAdapter
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine4 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrControlStyle2 As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrControlStyle3 As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents cltBilledAmount As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Dim FontStyle As String
    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "subTimeBillingExpenseReport.resx"
        Dim resources As System.Resources.ResourceManager = Global.Resources.subTimeBillingExpenseReport.ResourceManager
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.dsTimeBillingExpenseSubReport1 = New dsTimeBillingExpenseSubReport()
        Me.accountExpenseTableAdapter1 = New TimeLiveFileHelperTableAdapters.AccountExpenseTableAdapter()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.xrControlStyle2 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.xrControlStyle3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.cltBilledAmount = New DevExpress.XtraReports.UI.CalculatedField()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.dsTimeBillingExpenseSubReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel4, Me.xrLabel2, Me.xrLabel1})
        Me.Detail.HeightF = 20
        Me.Detail.KeepTogether = True
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.Scripts.OnBeforePrint = "Detail_BeforePrint"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel4
        '
        Me.xrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingExpense.ProjectName")})
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(181.0!, 20.0!)
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.StylePriority.UseTextAlignment = False
        Me.xrLabel4.Text = "xrLabel4"
        Me.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrLabel4.EvenStyleName = "xtrEvenRow"
        Me.xrLabel4.OddStyleName = "xtrOddRow"
        SetReportDetailLabelNewStyle(xrLabel4)
        '
        'xrLabel2
        '
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(612.0!, 0.0!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(114.0!, 20.0!)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.Text = "xrLabel2"
        Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel2.EvenStyleName = "xtrEvenRow"
        Me.xrLabel2.OddStyleName = "xtrOddRow"
        SetReportDetailLabelNewStyle(xrLabel2)
        '
        'xrLabel1
        '
        Me.xrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingExpense.Description")})
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(181.0!, 0.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(431.0!, 20.0!)
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "xrLabel1"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrLabel1.EvenStyleName = "xtrEvenRow"
        Me.xrLabel1.OddStyleName = "xtrOddRow"
        SetReportDetailLabelNewStyle(xrLabel1)
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLabel5, Me.xrLabel12})
        Me.PageHeader.HeightF = 36.0!
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeader.Scripts.OnBeforePrint = "PageHeader_BeforePrint"
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel3
        '
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 11.0!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(181.0!, 32.0!)
        Me.xrLabel3.StylePriority.UseBackColor = False
        Me.xrLabel3.StylePriority.UseBorders = False
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = ResourceHelper.GetFromResource("Project Name")
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        SetReportHeaderNewStyle(xrLabel3)
        '
        'xrLabel5
        '
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(612.0!, 11.0!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(114.0!, 32.0!)
        Me.xrLabel5.StylePriority.UseBackColor = False
        Me.xrLabel5.StylePriority.UseBorders = False
        Me.xrLabel5.StylePriority.UseFont = False
        Me.xrLabel5.StylePriority.UseTextAlignment = False
        Me.xrLabel5.Text = "Billed Amount"
        Me.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        SetReportHeaderNewStyle(xrLabel5)
        '
        'xrLabel12
        '
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(181.0!, 11.0!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(431.0!, 32.0!)
        Me.xrLabel12.StylePriority.UseBackColor = False
        Me.xrLabel12.StylePriority.UseBorders = False
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "Description"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        SetReportHeaderNewStyle(xrLabel12)
        '
        'PageFooter
        '
        Me.PageFooter.HeightF = 2.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'dsTimeBillingExpenseSubReport1
        '
        Me.dsTimeBillingExpenseSubReport1.DataSetName = "dsTimeBillingExpenseSubReport"
        Me.dsTimeBillingExpenseSubReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'accountExpenseTableAdapter1
        '
        Me.accountExpenseTableAdapter1.ClearBeforeFill = True
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel7, Me.xrLabel9, Me.xrLine1, Me.xrLine4, Me.xrLabel27})
        Me.GroupFooter1.HeightF = 36.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrLabel7
        '
        Me.xrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AccountTimeExpenseBillingExpense.CurrencyCode")})
        Me.xrLabel7.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(467.0!, 11.0!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(50.0!, 17.0!)
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0}"
        Me.xrLabel7.Summary = xrSummary1
        Me.xrLabel7.Text = "xrLabel8"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrLabel7.Visible = False
        '
        'xrLabel9
        '
        Me.xrLabel9.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(612.0!, 11.0!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(114.0!, 17.0!)
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:n2}"
        Me.xrLabel9.Summary = xrSummary2
        Me.xrLabel9.Text = "xrLabel9"
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 28.0!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(725.0!, 8.0!)
        '
        'xrLine4
        '
        Me.xrLine4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 3.0!)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.SizeF = New System.Drawing.SizeF(725.0!, 8.0!)
        '
        'xrLabel27
        '
        Me.xrLabel27.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold)
        Me.xrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(309.0!, 11.0!)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.SizeF = New System.Drawing.SizeF(83.0!, 17.0!)
        Me.xrLabel27.StylePriority.UseFont = False
        Me.xrLabel27.StylePriority.UseTextAlignment = False
        Me.xrLabel27.Text = "Total :"
        Me.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        'xrControlStyle3
        '
        Me.xrControlStyle3.Name = "xrControlStyle3"
        Me.xrControlStyle3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
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
        'cltBilledAmount
        '
        Me.cltBilledAmount.DataMember = "AccountTimeExpenseBillingExpense"
        Me.cltBilledAmount.DataSource = Me.dsTimeBillingExpenseSubReport1
        Me.cltBilledAmount.DisplayName = "cltBilledAmount"
        Me.cltBilledAmount.Expression = "[CurrencyCode] + ' ' + [BilledExpenseAmount]"
        Me.cltBilledAmount.Name = "cltBilledAmount"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.HeightF = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.Scripts.OnBeforePrint = "GroupHeader1_BeforePrint"
        '
        'topMarginBand1
        '
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'subTimeBillingExpenseReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter, Me.GroupFooter1, Me.GroupHeader1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.cltBilledAmount})
        Me.DataAdapter = Me.accountExpenseTableAdapter1
        Me.DataMember = "AccountTimeExpenseBillingExpense"
        Me.DataSource = Me.dsTimeBillingExpenseSubReport1
        Me.Margins = New System.Drawing.Printing.Margins(100, 10, 100, 100)
        Me.PageHeight = 700
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.ScriptsSource = resources.GetString("$this.ScriptsSource")
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.xrControlStyle1, Me.xrControlStyle2, Me.xrControlStyle3, Me.xtrEvenRow, Me.xtrOddRow})
        Me.Version = "11.1"
        Me.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart
        CType(Me.dsTimeBillingExpenseSubReport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
#End Region
    Private Sub subTimeBillingExpenseReport_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Me.xrLabel12.Text = ResourceHelper.GetFromResource("Expense Description")
        Me.xrLabel5.Text = ResourceHelper.GetFromResource("Billed Amount")
        Me.xrLabel27.Text = ResourceHelper.GetFromResource("Total:")
    End Sub

    Private Sub Detail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        If LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport = False Then
            Me.xrLabel4.Visible = False

            Me.xrLabel1.Location = New System.Drawing.Point(0.0, 0.0)
            Me.xrLabel1.Size = New System.Drawing.Size(612.0, 20)
        End If
        Me.xrLabel2.Text = ResourceHelper.GetFromResource(xrLabel2.Text, )
    End Sub

    Private Sub GroupHeader1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeader1.BeforePrint
        If LocaleUtilitiesBLL.ShowProjectNameInInvoiceReport = False Then
            Me.xrLabel3.Visible = False

            Me.xrLabel12.Location = New System.Drawing.Point(0.0, 11.0)
            Me.xrLabel12.Size = New System.Drawing.Size(612.0, 32.0)
        End If
    End Sub

    Private Sub GroupFooter1_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooter1.BeforePrint
        Me.xrLabel9.Text = ResourceHelper.GetFromResource(xrLabel9.Text, )
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
            'If System.Configuration.ConfigurationManager.AppSettings("ColorCode") = Nothing Then
            If DBUtilities.GetSessionAccountId = 7354 Then
                .BackColor = Drawing.ColorTranslator.FromHtml("#27ADA0")
            Else
                .BackColor = Drawing.ColorTranslator.FromHtml("#369")
            End If
            .ForeColor = Drawing.Color.White
            .BorderColor = Drawing.Color.White
            .Borders = 15
            .BorderWidth = 1
            .Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        End With
    End Sub
    Public Sub SetReportDetailLabelNewStyle(xrLabel As DevExpress.XtraReports.UI.XRLabel)
        With xrLabel
            xrLabel.Font = New System.Drawing.Font("Verdana", 7.25!)
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