Public Class repProjectSummary
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
    Private WithEvents vueProjectSummaryTableAdapter1 As TimeLiveDataSetTableAdapters.vueAccountProjectForProjectSummaryTableAdapter
    Private WithEvents timeLiveDataSet1 As TimeLiveDataSet
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents GroupHeader2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Public WithEvents xrSubreport2 As DevExpress.XtraReports.UI.XRSubreport
    Private WithEvents GroupHeader3 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Public WithEvents xrSubreport1 As DevExpress.XtraReports.UI.XRSubreport
    Public WithEvents xrSubreport3 As DevExpress.XtraReports.UI.XRSubreport
    Private WithEvents repProjectSummaryTimeEntries1 As repProjectSummaryTimeEntries
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "repProjectSummary.resx"
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.xrSubreport2 = New DevExpress.XtraReports.UI.XRSubreport
        Me.vueProjectSummaryTableAdapter1 = New TimeLiveDataSetTableAdapters.vueAccountProjectForProjectSummaryTableAdapter
        Me.timeLiveDataSet1 = New TimeLiveDataSet
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel
        Me.GroupHeader2 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.xrSubreport3 = New DevExpress.XtraReports.UI.XRSubreport
        Me.GroupHeader3 = New DevExpress.XtraReports.UI.GroupHeaderBand
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand
        Me.xrSubreport1 = New DevExpress.XtraReports.UI.XRSubreport
        Me.repProjectSummaryTimeEntries1 = New repProjectSummaryTimeEntries
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel
        CType(Me.timeLiveDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repProjectSummaryTimeEntries1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Height = 0
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.Detail.Visible = False
        '
        'xrSubreport2
        '
        Me.xrSubreport2.Location = New System.Drawing.Point(8, 0)
        Me.xrSubreport2.Name = "xrSubreport2"
        Me.xrSubreport2.Size = New System.Drawing.Size(792, 25)
        '
        'vueProjectSummaryTableAdapter1
        '
        Me.vueProjectSummaryTableAdapter1.ClearBeforeFill = True
        '
        'timeLiveDataSet1
        '
        Me.timeLiveDataSet1.DataSetName = "TimeLiveDataSet"
        Me.timeLiveDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PageHeader
        '
        Me.PageHeader.Height = 0
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel6
        '
        Me.xrLabel6.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel6.Location = New System.Drawing.Point(8, 18)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.Size = New System.Drawing.Size(67, 16)
        Me.xrLabel6.StylePriority.UseFont = False
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "Project :"
        Me.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueProjectSummary.PartyName", "")})
        Me.xrLabel2.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel2.Location = New System.Drawing.Point(75, 0)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.Size = New System.Drawing.Size(725, 18)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseTextAlignment = False
        Me.xrLabel2.Text = "xrLabel2"
        Me.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLabel1
        '
        Me.xrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueProjectSummary.ProjectName", "")})
        Me.xrLabel1.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel1.Location = New System.Drawing.Point(75, 18)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(725, 18)
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.StylePriority.UseTextAlignment = False
        Me.xrLabel1.Text = "xrLabel1"
        Me.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PageFooter
        '
        Me.PageFooter.Height = 42
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLine1, Me.xrLabel4, Me.xrLabel6, Me.xrLabel1, Me.xrLabel2})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ProjectName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.Height = 48
        Me.GroupHeader1.Level = 2
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatEveryPage = True
        '
        'xrLabel3
        '
        Me.xrLabel3.Font = New System.Drawing.Font("Verdana", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel3.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.Size = New System.Drawing.Size(67, 17)
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.StylePriority.UseTextAlignment = False
        Me.xrLabel3.Text = "Client :"
        Me.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'xrLine1
        '
        Me.xrLine1.Location = New System.Drawing.Point(8, 42)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.Size = New System.Drawing.Size(792, 3)
        '
        'xrLabel4
        '
        Me.xrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "vueProjectSummary.AccountProjectId", "")})
        Me.xrLabel4.Location = New System.Drawing.Point(808, 17)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.Size = New System.Drawing.Size(75, 25)
        Me.xrLabel4.Text = "xrLabel4"
        Me.xrLabel4.Visible = False
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrSubreport3})
        Me.GroupHeader2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ProjectName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader2.Height = 25
        Me.GroupHeader2.Level = 1
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'xrSubreport3
        '
        Me.xrSubreport3.Location = New System.Drawing.Point(8, 0)
        Me.xrSubreport3.Name = "xrSubreport3"
        Me.xrSubreport3.Size = New System.Drawing.Size(792, 25)
        '
        'GroupHeader3
        '
        Me.GroupHeader3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrSubreport2})
        Me.GroupHeader3.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("AccountProjectId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader3.Height = 25
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrSubreport1})
        Me.GroupFooter1.Height = 33
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
        '
        'xrSubreport1
        '
        Me.xrSubreport1.Location = New System.Drawing.Point(8, 0)
        Me.xrSubreport1.Name = "xrSubreport1"
        Me.xrSubreport1.Size = New System.Drawing.Size(792, 25)
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel20})
        Me.ReportHeader.Height = 29
        Me.ReportHeader.Name = "ReportHeader"
        '
        'xrLabel20
        '
        Me.xrLabel20.BackColor = System.Drawing.Color.Silver
        Me.xrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrLabel20.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel20.Location = New System.Drawing.Point(8, 0)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.Size = New System.Drawing.Size(792, 21)
        Me.xrLabel20.StylePriority.UseBackColor = False
        Me.xrLabel20.StylePriority.UseBorders = False
        Me.xrLabel20.StylePriority.UseFont = False
        Me.xrLabel20.Text = "Project Activity Summary Report"
        '
        'repProjectSummary
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter, Me.GroupHeader1, Me.GroupHeader2, Me.GroupHeader3, Me.GroupFooter1, Me.ReportHeader})
        Me.DataAdapter = Me.vueProjectSummaryTableAdapter1
        Me.DataMember = "vueProjectSummary"
        Me.DataSource = Me.timeLiveDataSet1
        Me.DrawGrid = False
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(15, 15, 20, 100)
        Me.PageHeight = 850
        Me.PageWidth = 5000
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Version = "8.2"
        Me.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart
        CType(Me.timeLiveDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repProjectSummaryTimeEntries1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand

#End Region



    Private Sub GroupHeader2_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeader2.BeforePrint
        ' xrSubreport3.xrlabel1.text = Me.xrLabel4.Text

        xrSubreport3.ReportSource.Parameters("pAccountProjectID").Value = Me.xrLabel4.Text

        'xrSubreport3.ReportSource.FilterString = "[AccountProjectId] = " & Me.xrLabel4.Text
        ''xrSubreport3.ReportSource.xrPivotGrid1.Prefilter().Criteria =         'Dim rep12 As New repProjectSummaryTimeEntries
        'rep12.xrPivotGrid1.Prefilter().Criteria = "[AccountProjectId] = " & Me.xrLabel4.Text
        'Me.xrSubreport3.ReportSource = rep12
        '    xrSubreport3.FindControl("xrPivotgrid1", True).

        'Me.xrPivotGrid1.Prefilter().Criteria = Me.FilterString




    End Sub


    Private Sub GroupFooter1_BeforePrint1(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooter1.BeforePrint
        xrSubreport1.ReportSource.Parameters("pAccountProjectID").Value = Me.xrLabel4.Text

    End Sub

    Private Sub GroupHeader3_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeader3.BeforePrint
        xrSubreport2.ReportSource.Parameters("pAccountProjectID").Value = Me.xrLabel4.Text

    End Sub
    Private Sub repProjectSummary_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.xrLabel20.Text = Resources.TimeLive.Resource.Project_Activity_Summary_Report
        Me.xrLabel3.Text = Resources.TimeLive.Resource.Client_
        Me.xrLabel6.Text = Resources.TimeLive.Resource.Project_

    End Sub
End Class