Public Class repProjectSummaryTimeEntries
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
    Private WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Public WithEvents xrPivotGrid1 As DevExpress.XtraReports.UI.XRPivotGrid
    Private WithEvents timeLiveDataSet1 As TimeLiveDataSet
    Private WithEvents vueProjectSummaryTableAdapter1 As TimeLiveDataSetTableAdapters.vueProjectSummaryTableAdapter
    Private WithEvents fieldEmployeeName As DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
    Private WithEvents fieldTimeEntryDate As DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
    Private WithEvents fieldTotalMinutes As DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
    Private WithEvents fieldAccountProjectId As DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
    Private WithEvents pAccountProjectID As DevExpress.XtraReports.Parameters.Parameter
    Public WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "repProjectSummaryTimeEntries.resx"
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand
        Me.xrPivotGrid1 = New DevExpress.XtraReports.UI.XRPivotGrid
        Me.vueProjectSummaryTableAdapter1 = New TimeLiveDataSetTableAdapters.vueProjectSummaryTableAdapter
        Me.timeLiveDataSet1 = New TimeLiveDataSet
        Me.fieldEmployeeName = New DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
        Me.fieldTimeEntryDate = New DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
        Me.fieldTotalMinutes = New DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
        Me.fieldAccountProjectId = New DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.pAccountProjectID = New DevExpress.XtraReports.Parameters.Parameter
        CType(Me.timeLiveDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Height = 0
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        'ReportFooter
        '
        Me.ReportFooter.Height = 0
        Me.ReportFooter.Name = "ReportFooter"
        '
        'xrPivotGrid1
        '
        Me.xrPivotGrid1.Appearance.Cell.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrPivotGrid1.Appearance.Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrPivotGrid1.Appearance.CustomTotalCell.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrPivotGrid1.Appearance.FieldHeader.BackColor = System.Drawing.Color.Silver
        Me.xrPivotGrid1.Appearance.FieldHeader.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrPivotGrid1.Appearance.FieldHeader.ForeColor = System.Drawing.Color.Black
        Me.xrPivotGrid1.Appearance.FieldHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrPivotGrid1.Appearance.FieldValue.BackColor = System.Drawing.Color.Silver
        Me.xrPivotGrid1.Appearance.FieldValue.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.xrPivotGrid1.Appearance.FieldValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.xrPivotGrid1.Appearance.FieldValueGrandTotal.BackColor = System.Drawing.Color.Silver
        Me.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrPivotGrid1.Appearance.FieldValueTotal.BackColor = System.Drawing.Color.Silver
        Me.xrPivotGrid1.Appearance.FieldValueTotal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrPivotGrid1.Appearance.FilterSeparator.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrPivotGrid1.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.Silver
        Me.xrPivotGrid1.Appearance.GrandTotalCell.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrPivotGrid1.Appearance.HeaderGroupLine.BackColor = System.Drawing.Color.Silver
        Me.xrPivotGrid1.Appearance.HeaderGroupLine.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrPivotGrid1.Appearance.Lines.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrPivotGrid1.Appearance.TotalCell.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrPivotGrid1.DataAdapter = Me.vueProjectSummaryTableAdapter1
        Me.xrPivotGrid1.DataMember = "vueProjectSummary"
        Me.xrPivotGrid1.DataSource = Me.timeLiveDataSet1
        Me.xrPivotGrid1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.fieldEmployeeName, Me.fieldTimeEntryDate, Me.fieldTotalMinutes, Me.fieldAccountProjectId})
        Me.xrPivotGrid1.Location = New System.Drawing.Point(8, 0)
        Me.xrPivotGrid1.Name = "xrPivotGrid1"
        Me.xrPivotGrid1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrPivotGrid1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrPivotGrid1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrPivotGrid1.OptionsPrint.PrintHeadersOnEveryPage = True
        Me.xrPivotGrid1.OptionsPrint.PrintHorzLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrPivotGrid1.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.[True]
        Me.xrPivotGrid1.OptionsPrint.PrintVertLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrPivotGrid1.Size = New System.Drawing.Size(208, 50)
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
        'fieldEmployeeName
        '
        Me.fieldEmployeeName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldEmployeeName.AreaIndex = 0
        Me.fieldEmployeeName.FieldName = "EmployeeName"
        Me.fieldEmployeeName.Name = "fieldEmployeeName"
        '
        'fieldTimeEntryDate
        '
        Me.fieldTimeEntryDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.fieldTimeEntryDate.AreaIndex = 0
        Me.fieldTimeEntryDate.FieldName = "TimeEntryDate"
        Me.fieldTimeEntryDate.Name = "fieldTimeEntryDate"
        Me.fieldTimeEntryDate.ValueFormat.FormatString = "{0:d}"
        Me.fieldTimeEntryDate.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        '
        'fieldTotalMinutes
        '
        Me.fieldTotalMinutes.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.fieldTotalMinutes.AreaIndex = 0
        Me.fieldTotalMinutes.FieldName = "TotalMinutes"
        Me.fieldTotalMinutes.Name = "fieldTotalMinutes"
        '
        'fieldAccountProjectId
        '
        Me.fieldAccountProjectId.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        Me.fieldAccountProjectId.AreaIndex = 0
        Me.fieldAccountProjectId.FieldName = "AccountProjectId"
        Me.fieldAccountProjectId.Name = "fieldAccountProjectId"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrPivotGrid1, Me.xrLabel1})
        Me.ReportHeader.Height = 58
        Me.ReportHeader.Name = "ReportHeader"
        '
        'xrLabel1
        '
        Me.xrLabel1.Location = New System.Drawing.Point(408, 0)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.Size = New System.Drawing.Size(108, 17)
        Me.xrLabel1.Visible = False
        '
        'pAccountProjectID
        '
        Me.pAccountProjectID.Name = "pAccountProjectID"
        Me.pAccountProjectID.ParameterType = DevExpress.XtraReports.Parameters.ParameterType.Int32
        Me.pAccountProjectID.Value = 0
        '
        'repProjectSummaryTimeEntries
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter, Me.ReportFooter, Me.ReportHeader})
        Me.DataAdapter = Me.vueProjectSummaryTableAdapter1
        Me.DataMember = "vueProjectSummary"
        Me.DataSource = Me.timeLiveDataSet1
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.pAccountProjectID})
        Me.Version = "8.2"
        CType(Me.timeLiveDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand

#End Region

    Private Sub ReportHeader_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles ReportHeader.BeforePrint
        Me.xrLabel1.Text = Me.Parameters("pAccountProjectID").Value




        'new for datasource changing runti

        Dim m3 As New TimeLiveDataSet.vueProjectSummaryDataTable


        m3 = New ProjectSummaryBLL().GetDataAll2(System.Web.HttpContext.Current.Session("rAccountID"), System.Web.HttpContext.Current.Session("rAccountEmployees"), Me.xrLabel1.Text, System.Web.HttpContext.Current.Session("rAccountClientID"), 1, System.Web.HttpContext.Current.Session("rTimeEntryStartDate"), System.Web.HttpContext.Current.Session("rTimeEntryEndDate"))



        '        m3 = New ProjectSummaryBLL().GetDataAll(AccountID, AccountEmployeeBLL.GetAccountEmployeesFromDropdown(Me.ddlEmployees), AccountProjectID, AccountClientID, IncludeDateRange, TimeEntryStartDate, TimeEntryEndDate)
        xrPivotGrid1.DataSource = m3


        '    Me.xrPivotGrid1.Prefilter().Enabled = True


        'System.Web.HttpContext.Current("rAccountProjectID")



        'me.xrPivotGrid1.Prefilter.





        'Me.xrPivotGrid1.DataSource = Me.DataSource
        'Me.xrPivotGrid1.DataAdapter = Me.DataAdapter
        'Me.xrPivotGrid1.DataMember = Me.DataMember


        'Me.xrPivotGrid1.DataSource = Me.DataSource
        'Me.xrPivotGrid1.DataSource = Me.DataSource
        'Me.xrPivotGrid1.Prefilter().Criteria = Me.FilterString


    End Sub

    Private Sub xrPivotGrid1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles xrPivotGrid1.BeforePrint
        'Me.xrPivotGrid1.Prefilter().Criteria = "AccountProjectID = " & Me.xrLabel1.Text

    End Sub


    Private Sub repprojectsummarytimeentries_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

        Me.fieldEmployeeName.Caption = Resources.TimeLive.Resource.Employee_Name

    End Sub

End Class