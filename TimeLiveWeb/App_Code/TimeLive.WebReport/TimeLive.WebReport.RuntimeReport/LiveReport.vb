Imports DevExpress.XtraReports.UI
Imports Microsoft.VisualBasic
Public Class LiveReport
    Inherits XtraReport

    Public WithEvents Detail As New DevExpress.XtraReports.UI.DetailBand
    Public WithEvents PageHeader As New DevExpress.XtraReports.UI.PageHeaderBand
    Public WithEvents PageFooter As New DevExpress.XtraReports.UI.PageFooterBand
    Public WithEvents ReportHeader As New DevExpress.XtraReports.UI.ReportHeaderBand
    Public WithEvents Summary1 As New DevExpress.XtraReports.UI.XRSummary
    Public WithEvents Summary2 As New DevExpress.XtraReports.UI.XRSummary
    Public WithEvents ReportFooter As New DevExpress.XtraReports.UI.ReportFooterBand
    Public WithEvents xrLabel As XRLabel
    Private WithEvents xrReportFooterPanel As DevExpress.XtraReports.UI.XRPanel

    Public WithEvents xtrEvenRow As DevExpress.XtraReports.UI.XRControlStyle
    Public WithEvents xtrOddRow As DevExpress.XtraReports.UI.XRControlStyle

    Private ReportDatasource As DataSet
    Private ReportTableName As String

    Dim imgYPos As Integer = 0
    Dim imgXPos As Integer = 0
    Dim TitleYPos As Integer = 0
    Dim HeaderYPos As Integer = 0
    Dim ReportFooterYPos As Integer = 0
    Dim YPos As Integer = 0
    Dim XPos As Integer = 0
    Dim GSXPos As Integer = 0
    Dim GHWidth As Integer = 0
    Dim RSWidth As Integer = 0
    Dim Amount As Double = 0
    Dim RSCount As Integer = 0
    Dim ScriptDetailString As String = ""
    Dim ScriptDeclareString As String = ""
    Dim ScriptSetValueString As String = ""
    Dim ScriptDetailOnBeforePrintBody As String = ""
    Dim ScriptGroupHeaderOnBeforePrintBody As String = ""
    Dim ScriptGroupHeaderOnBeforePrint As String = ""
    Dim ScriptStringOnBeforePrintStart As String = "Private Sub OnBeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) " & vbCrLf
    Dim ScriptStringOnBeforePrintEnd As String = "End Sub "
    Public WithEvents xrGroupSummaryLabel As XRLabel
    Public WithEvents xrGrandSummaryLabel As XRLabel
    Public GroupHeaderBands As New Hashtable
    Public GroupFooterBands As New Hashtable
    Public ShowDetail As Boolean = True
    Dim FontStyle As String

    Public Function Report() As XtraReport
        Return Me
    End Function

    Public Sub New()
        Report.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Report.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        'Report.PageWidth = 5000
        Me.SetReportFontStyle()
        PageHeader.Height = 0
        PageHeader.Name = "PageHeader"
        ReportHeader.Height = 0
        ReportHeader.KeepTogether = False
        ReportHeader.Name = "ReportHeader"
        SetupDetail()
        Report.Bands.Add(PageHeader)
        Report.Bands.Add(ReportHeader)
        PageFooter.Name = "PageFooter1"
        PageFooter.Height = 0
        Report.Bands.Add(PageFooter)
        AddPageInfoLabel()
        Report.DefaultPrinterSettingsUsing.UseLandscape = True
    End Sub
    Public Sub SetReportFontStyle(ByVal Optional FontName As String = "Sans-Serif Unicode MS")
        'Arial,Sans-Serif Arial Unicode MS
        FontStyle = FontName
    End Sub
    Public Sub SetupDetail()
        'Detail
        '
        Report.Bands.Add(Detail)
        Detail.Height = 0
        Detail.KeepTogether = True
        Detail.Name = "Detail"
        Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft

    End Sub

    Public Function ReportObejct() As XtraReport
        Return Report()
    End Function

    Public Function GetReportDatasource() As DataSet
        Return Me.ReportDatasource
    End Function

    Public Sub SetDataSource(ByVal objDataSet As DataSet, ByVal TableName As String)
        Me.ReportDatasource = objDataSet
        Me.ReportTableName = TableName
    End Sub

    Public Sub AddDetailColumn(ByVal ColumnName As String, ByVal Caption As String, ByVal FieldName As String, ByVal ColumnType As String, ByVal Width As Integer, ByVal CurrencyField As String, ByVal Formula As String)

        Me.AddStyleSheet()

        Me.AddHeaderCaption(ColumnName, Caption, Width, CurrencyField)

        If ColumnType = "Duration" Then
            Me.AddDurationColumn(ColumnName, FieldName, Width)
        ElseIf ColumnType = "Decimal" Then
            Me.AddDecimalColumn(ColumnName, FieldName, Width)
        ElseIf ColumnType = "Date" Then
            Me.AddDateColumn(ColumnName, FieldName, Width)
        ElseIf ColumnType = "Time" Then
            Me.AddTimeColumn(ColumnName, FieldName, Width)
        ElseIf ColumnType = "Text" Then
            Me.AddTextColumn(ColumnName, FieldName, Width, False)
        ElseIf ColumnType = "Number" Then
            Me.AddNumberColumn(ColumnName, FieldName, Width)
        ElseIf ColumnType = "CurrencyDecimal" Then
            Me.AddCurrencyDecimalColumn(ColumnName, FieldName, Width, CurrencyField)
        ElseIf ColumnType = "Boolean" Then
            Me.AddBooleanColumn(ColumnName, FieldName, Width)
        ElseIf ColumnType = "CustomText" Then
            Me.AddTextColumn(ColumnName, FieldName, Width, True)
        End If

        Me.SetDetailScript()
    End Sub

    Public Sub AddCustomDetailColumn(ByVal ColumnName As String, ByVal Caption As String, ByVal FieldName As String, ByVal ColumnType As String, ByVal Width As Integer, ByVal CurrencyField As String, ByVal Formula As String, ByVal CustomValueFieldName As String)
        Me.AddStyleSheet()

        Me.AddHeaderCaption(ColumnName, Caption, Width, CurrencyField)

        If ColumnType = "Link" Then
            Me.AddLinkColumn(ColumnName, FieldName, Width, CustomValueFieldName)
        End If

        Me.SetDetailScript()
    End Sub

    Public Sub AddStyleSheet()
        Me.xtrEvenRow = New DevExpress.XtraReports.UI.XRControlStyle
        Me.xtrOddRow = New DevExpress.XtraReports.UI.XRControlStyle
        '
        'xtrEvenRow
        '

        'Me.xtrEvenRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
        'Me.xtrEvenRow.Borders = 10
        'Me.xtrEvenRow.BorderWidth = 1
        Me.xtrEvenRow.Name = "xtrEvenRow"
        '
        'xtrOddRow
        '
        Me.xtrOddRow.BackColor = Drawing.ColorTranslator.FromHtml("#F6F6F6")
        'Me.xtrOddRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
        'Me.xtrOddRow.Borders = 10
        'Me.xtrOddRow.BorderWidth = 1
        Me.xtrOddRow.Name = "xtrOddRow"
        Report.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.xtrEvenRow, Me.xtrOddRow})
    End Sub
    Public Function imageToByteArray(ByVal img As System.Drawing.Image) As Byte()
        Dim ms As New System.IO.MemoryStream
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
        Return ms.ToArray()
    End Function
    Public Function byteArrayToImage(ByVal byteArrayIn As Byte()) As System.Drawing.Image
        Dim ms As New System.IO.MemoryStream(byteArrayIn)
        Dim returnImage As System.Drawing.Image = System.Drawing.Image.FromStream(ms)
        Return returnImage
    End Function
    Public Sub AddCompanyLogoInHeader(ByVal ImageName As String, ByVal ImageUrl As String)

        Dim xrPicBox As New XRPictureBox

        Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(ImageUrl))

        With xrPicBox
            .Image = Me.byteArrayToImage(Me.imageToByteArray(img))
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 2, 0, 100.0!)
            '.ImageUrl = ImageUrl
            .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
            .HeightF = 50
            .WidthF = 160
            .Name = "img" & ImageName
            .Location = New System.Drawing.Point(0, -10)
        End With

        PageHeader.Controls.Add(xrPicBox)
        imgYPos = xrPicBox.Height
        imgXPos = xrPicBox.Width + 5
        YPos = imgYPos
    End Sub
    Public Sub AddReportTitleInHeader(ByVal LabelName As String, ByVal Title As String)

        Dim xrTitle As New XRLabel

        With xrTitle
            .Font = New System.Drawing.Font(FontStyle, 13.0!, System.Drawing.FontStyle.Regular)
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            .Name = "xrTitle"
            .Text = Title
            .Location = New System.Drawing.Point(0, YPos)
            .KeepTogether = True
            .WordWrap = False
            .AutoWidth = True
        End With
        PageHeader.Controls.Add(xrTitle)
        TitleYPos = YPos + xrTitle.Height + 5
        YPos = TitleYPos
    End Sub

    Public Sub AddReportTodayInHeader()

        Dim xrToday As New XRLabel

        With xrToday
            .Font = New System.Drawing.Font(FontStyle, 10.0!, System.Drawing.FontStyle.Regular)
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            .Name = "xrToday"
            .Text = DateTime.Now.ToShortDateString()
            .KeepTogether = True
            .WordWrap = False
            .AutoWidth = True
        End With
        PageHeader.Controls.Add(xrToday)
    End Sub
    Public Sub AddReportHeaderInHeader(ByVal LabelName As String, ByVal Title As String)

        Dim xrHeader As New XRLabel

        With xrHeader
            .Font = New System.Drawing.Font(FontStyle, 8.25!, System.Drawing.FontStyle.Regular)
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            .Name = "Header" & LabelName
            .Text = Title
            .Location = New System.Drawing.Point(0, YPos)
            .Width = 775
            .Multiline = True
        End With
        PageHeader.Controls.Add(xrHeader)
        HeaderYPos = YPos + xrHeader.Height + 5
        YPos = HeaderYPos
    End Sub
    Public Sub AddReportFooterInFooter(ByVal LabelName As String, ByVal ReportFooter As String)

        Dim xrFooter As New XRLabel
        With xrFooter
            .Font = New System.Drawing.Font(FontStyle, 8.25!, System.Drawing.FontStyle.Regular)
            .Name = "Footer" & LabelName
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            .Width = 775
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            .Text = ReportFooter
            .Multiline = True
        End With
        PageFooter.Controls.Add(xrFooter)
        ReportFooterYPos = xrFooter.Height + 5
    End Sub
    Public Sub AddPageHeaderLabel(ByVal LabelName As String, ByVal LabelText As String, ByVal Width As Integer)

        xrLabel = New XRLabel

        With xrLabel
            .BackColor = System.Drawing.Color.FromName("CadetBlue")
            .Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                        Or DevExpress.XtraPrinting.BorderSide.Right) _
                        Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            .Name = LabelName
            Report.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            .Location = New System.Drawing.Point(XPos, YPos)
            .Size = New System.Drawing.Size(Width, 0)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Text = LabelText
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        End With

        PageHeader.Controls.Add(xrLabel)

    End Sub
    Public Sub AddPageInfoLabel()

        Dim xrPageInfo2 As New DevExpress.XtraReports.UI.XRPageInfo
        With xrPageInfo2
            .Font = New System.Drawing.Font(FontStyle, 10.0!, System.Drawing.FontStyle.Regular)
            .Format = "Page {0} of {1}"
            .ForeColor = Drawing.Color.Black
            .Name = "xrPageInfo2"
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            .Size = New System.Drawing.Size(115, 20)
            .StyleName = "PageInfo"
            .StylePriority.UseFont = False
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

        End With

        PageFooter.Controls.Add(xrPageInfo2)

    End Sub

    Public Sub AddPageDateLabel(ByVal dataRange As String, ByVal visible As Boolean)

        Dim xrPageInfoDate As New DevExpress.XtraReports.UI.XRPageInfo
        With xrPageInfoDate
            .Font = New System.Drawing.Font(FontStyle, 10.0!, System.Drawing.FontStyle.Regular)
            .Format = "" & dataRange
            .ForeColor = Drawing.Color.Black
            .Name = "xrPageInfoDate"
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            .Size = New System.Drawing.Size(250, 20)
            .StyleName = "PageInfo"
            .StylePriority.UseFont = False
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            .Visible = visible

        End With

        PageFooter.Controls.Add(xrPageInfoDate)

    End Sub

    Public Sub AddPageCodeLabel(ByVal UserCode As String)

        Dim xrPageInfoCode As New DevExpress.XtraReports.UI.XRPageInfo
        With xrPageInfoCode
            .Font = New System.Drawing.Font(FontStyle, 10.0!, System.Drawing.FontStyle.Regular)
            .Format = "User: " & UserCode
            .ForeColor = Drawing.Color.Black
            .Name = "xrPageInfoCode"
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            .Size = New System.Drawing.Size(150, 20)
            .StyleName = "PageInfo"
            .StylePriority.UseFont = False
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

        End With

        PageFooter.Controls.Add(xrPageInfoCode)

    End Sub

    Public Function GetColumnHeight() As Integer
        Return 25
    End Function

    Public Function GetDetailBandHeight() As Integer
        Return 25
    End Function

    Public Function GetDetailDataHeight() As Integer
        Return 25
    End Function

    Public Sub AddDurationColumn(ByVal ColumnName As String, ByVal FieldName As String, ByVal Width As Integer)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, FieldName, "{0:HH:mm}")
        Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleCenter)
    End Sub
    Public Sub AddDecimalColumn(ByVal ColumnName As String, ByVal FieldName As String, ByVal Width As Integer)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, FieldName, "{0:N}")
        Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleRight)
    End Sub
    Public Sub AddDateColumn(ByVal ColumnName As String, ByVal FieldName As String, ByVal Width As Integer)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, FieldName, "{0:d}")
        Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleCenter)
    End Sub
    Public Sub AddTimeColumn(ByVal ColumnName As String, ByVal FieldName As String, ByVal Width As Integer)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, FieldName, "{0:t}")
        Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleCenter)
    End Sub
    Public Sub AddLinkColumn(ByVal ColumnName As String, ByVal FieldName As String, ByVal Width As Integer, ByVal LinkFieldName As String)
        Dim textBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, FieldName, "{0:d}")
        Dim linkBinding As New DevExpress.XtraReports.UI.XRBinding("NavigateUrl", Me.DataSource, LinkFieldName, "javascript:window.open('{0}', 'popupwindow', 'width=680,height=250,left=300,top=300'); return false;")
        'Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleCenter)

        xrLabel = New XRLabel
        xrLabel.DataBindings.Add(textBinding)
        xrLabel.DataBindings.Add(linkBinding)
        With xrLabel
            .Location = New System.Drawing.Point(Report.FindControl("lbl" & FieldName, False).Location.X, 0)
            .Name = ColumnName
            .Size = New System.Drawing.Size(Width, 20)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .TextAlignment = TextAlignment
            .Font = New System.Drawing.Font(FontStyle, 8.0!, System.Drawing.FontStyle.Regular)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            .BorderWidth = 1
            .Borders = DevExpress.XtraPrinting.BorderSide.Top
            .BorderColor = Color.Silver
            .Multiline = True
            'System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
            .EvenStyleName = "xtrEvenRow"
            .OddStyleName = "xtrOddRow"
        End With

        AddHandler xrLabel.HtmlItemCreated, AddressOf AttachmentLinkItemCreated

        Detail.Controls.Add(xrLabel)
    End Sub

    Public Sub AddTextColumn(ByVal ColumnName As String, ByVal FieldName As String, ByVal Width As Integer, ByVal Optional MiddleRight As Boolean = False)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, FieldName, "")
        If oBinding.DataMember = "ApprovalStatus" Or FieldName = "AccountWorkType" Then
            Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleCenter)
        ElseIf MiddleRight = True Then
            Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleRight)
        Else
            Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleLeft)
        End If
    End Sub
    Public Sub AddNumberColumn(ByVal ColumnName As String, ByVal FieldName As String, ByVal Width As Integer)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, FieldName, "")
        Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleCenter)
    End Sub
    Public Sub AddCurrencyDecimalColumn(ByVal ColumnName As String, ByVal FieldName As String, ByVal Width As Integer, ByVal CurrencyField As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding
        Dim GetCurrencyDetailColumnScript As String = ""
        If CurrencyField <> "" Then
            GetCurrencyDetailColumnScript = Me.GetCurrencyDecimalDetailColumnPrintScript(ColumnName, FieldName, CurrencyField)
        Else
            oBinding = New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, FieldName, "")
        End If
        Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleRight, CurrencyField, "", GetCurrencyDetailColumnScript)
    End Sub
    Public Function GetCurrencyDecimalDetailColumnPrintScript(ByVal ColumnName As String, ByVal FieldName As String, ByVal CurrencyField As String) As String
        Dim PrintScript As String = ""
        Dim variableName As String = FieldName
        PrintScript += ColumnName & ".Text = " & "String.Format(" & """{0:N}""" & ", " & "GetCurrentColumnValue(""" & variableName & """)" & ")" & " & " & """ """ & " & " & "GetCurrentColumnValue(""" & CurrencyField & """)" & vbCrLf
        Return PrintScript
    End Function
    Public Function AddCurrencyDecimalCalculatedField(ByVal FieldName As String, ByVal CurrencyField As String) As String
        Dim CalcFld As New CalculatedField
        CalcFld.DisplayName = "CalcFld" & FieldName
        CalcFld.FieldType = FieldType.None
        CalcFld.Expression = CurrencyField & " + " & "' '" & " + " & FieldName
        CalcFld.Name = "CalcFld" & FieldName
        Me.CalculatedFields.Add(CalcFld)
        Return CalcFld.Name
    End Function
    Public Function AddBooleanCalculatedField(ByVal FieldName As String) As String
        Dim CalcFld As New CalculatedField
        CalcFld.DisplayName = "CalcFld" & FieldName
        CalcFld.FieldType = FieldType.None
        CalcFld.Expression = "IIF(" & FieldName & " = True," & "'" & ResourceHelper.GetFromResource("Yes") & "'" & "," & "'" & ResourceHelper.GetFromResource("No") & "'" & ")"
        CalcFld.Name = "CalcFld" & FieldName
        Me.CalculatedFields.Add(CalcFld)
        Return CalcFld.Name
    End Function
    Public Sub AddGroupSummaryInReport(ByVal FieldName As String, ByVal GroupName As String, ByVal IsShowGroupTotal As Boolean, ByVal IsShowGrandTotal As Boolean, ByVal DataType As String, ByVal SummaryFieldType As String, ByVal SummaryCaption As String, ByVal CalculationType As String, ByVal IsConsolidated As Boolean, ByVal Width As Integer, ByVal Formula As String, ByVal IsShowCurrencyCode As Boolean, ByVal CurrencyField As String)

        'Dim ScriptString As String
        Me.SetGroupSummaryDeclareScript(FieldName, DataType, GroupName)

        If CalculationType = "Sum" Then
            Me.SetGroupSummaryRunningTotalScript(FieldName, DataType, GroupName)
        ElseIf CalculationType = "Count" Then
            Me.SetGroupSummaryCountScript(FieldName, DataType, GroupName)
        End If

        Me.SetResetGroupSummaryToZeroScript(FieldName, GroupName)

        Dim GroupSummaryScript As String = Me.GetGroupSummaryPrintScript(FieldName, GroupName, SummaryFieldType, CalculationType, IsShowCurrencyCode, CurrencyField)

        If CType(Report.FindControl(GroupName & "_Footer", False), GroupFooterBand).Level = 0 And IsConsolidated = True Then
            Me.AddHeaderCaption(FieldName, SummaryCaption, Width, CurrencyField)
            If Formula <> "" Then
                Me.AddFormulaDataColumn(FieldName, Formula, GetType(System.Double))
            End If
        End If

        Me.AddGroupFooterSummaryColumn(FieldName, DataType, CalculationType, GroupName, SummaryCaption, GroupSummaryScript, Width, Me.SetTextAlignmentsForSummary(FieldName, SummaryFieldType, IsConsolidated))

        'Me.AddGroupFooterSummaryLabel(GroupName, GroupName & "Summary", SummaryCaption, Report.FindControl(GroupName & FieldName, False).Location.X, GroupName)

        Me.SetDetailScript()

    End Sub
    Public Function SetTextAlignmentsForSummary(ByVal FieldName As String, ByVal SummaryFieldType As String, ByVal IsConsolidated As Boolean) As DevExpress.XtraPrinting.TextAlignment
        If IsConsolidated <> True Then
            Return Report.FindControl(FieldName, False).TextAlignment
        ElseIf SummaryFieldType = "Duration" Or SummaryFieldType = "Decimal" Or SummaryFieldType = "Date" Or SummaryFieldType = "Time" Or SummaryFieldType = "Number" Or SummaryFieldType = "Boolean" Then
            Return DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        ElseIf SummaryFieldType = "Text" Then
            Return DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        ElseIf SummaryFieldType = "CurrencyDecimal" Then
            Return DevExpress.XtraPrinting.TextAlignment.MiddleRight
        End If
    End Function
    Public Sub AddGrandSummaryInReport(ByVal FieldName As String, ByVal DataType As String, ByVal SummaryFieldType As String, ByVal SummaryCaption As String, ByVal CalculationType As String, ByVal Width As Integer, ByVal SummaryCount As Integer, ByVal IsConsolidated As Boolean, ByVal IsShowCurrencyCode As Boolean, ByVal CurrencyField As String)
        If ReportFooter.FindControl("GrandFooter" & FieldName, False) Is Nothing Then
            If Report.FindControl("xrReportFooterPanel", False) Is Nothing Then
                SetReportFooter()
            End If
            'Dim ScriptString As String
            Me.SetGrandSummaryDeclareScript(FieldName, DataType)

            If CalculationType = "Sum" Then
                Me.SetGrandSummaryRunningTotalScript(FieldName, DataType)
            ElseIf CalculationType = "Count" Then
                Me.SetGrandSummaryCountScript(FieldName, DataType)
            End If

            Dim GrandSummaryScript As String = Me.GetGrandSummaryPrintScript(FieldName, SummaryFieldType, CalculationType, IsShowCurrencyCode, CurrencyField)

            Me.AddReportFooterSummaryColumn(FieldName, DataType, SummaryCaption, GrandSummaryScript, Width, Me.SetTextAlignmentsForSummary(FieldName, SummaryFieldType, IsConsolidated))

            If RSCount = 0 Then
                Me.AddReportFooterSummaryLabel("FullSummary", "Full Summary", SummaryCaption, Report.FindControl("GrandFooter" & FieldName, False).Location.X)
                RSCount = 1
            End If

            Me.SetDetailScript()
        End If
    End Sub
    Public Sub SetReportFooter()
        Me.xrReportFooterPanel = New DevExpress.XtraReports.UI.XRPanel
        With xrReportFooterPanel
            .BackColor = Drawing.ColorTranslator.FromHtml("#369")
            .Location = New System.Drawing.Point(0, 0)
            .Name = "xrReportFooterPanel"
        End With

        ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {xrReportFooterPanel})
    End Sub
    Public Sub SetGroupSummaryDeclareScript(ByVal FieldName As String, ByVal DataType As String, ByVal GroupName As String)
        'Dim DurationScript As String

        Dim variableName As String = GetGroupFieldVariableName(FieldName, GroupName)
        Dim DeclareScript As String = "Dim " & variableName & " as " & DataType & vbCrLf
        If Not ScriptDeclareString.Contains(DeclareScript) Then
            ScriptDeclareString += DeclareScript
        End If

    End Sub
    Public Sub SetGrandSummaryDeclareScript(ByVal FieldName As String, ByVal DataType As String)
        'Dim DurationScript As String

        Dim variableName As String = GetGrandFieldVariableName(FieldName)
        Dim DeclareScript As String = "Dim " & variableName & " as " & DataType & vbCrLf
        If Not ScriptDeclareString.Contains(DeclareScript) Then
            ScriptDeclareString += DeclareScript
        End If

    End Sub
    Public Sub SetGroupSummaryRunningTotalScript(ByVal FieldName As String, ByVal DataType As String, ByVal GroupName As String)
        Dim variableName As String = GetGroupFieldVariableName(FieldName, GroupName)
        Dim GroupSumaryDetailScript As String

        GroupSumaryDetailScript = variableName & " += " & "GetCurrentColumnValue(""" & FieldName & """)" & vbCrLf

        Me.ScriptDetailOnBeforePrintBody += GroupSumaryDetailScript
    End Sub
    Public Sub SetGroupSummaryCountScript(ByVal FieldName As String, ByVal DataType As String, ByVal GroupName As String)
        Dim variableName As String = GetGroupFieldVariableName(FieldName, GroupName)
        Dim GroupSumaryDetailScript As String
        If ReportDatasource.Tables.Item(0).Rows.Count > 0 Then
            GroupSumaryDetailScript = "If String.IsNullOrEmpty(" & "GetCurrentColumnValue(""" & FieldName & """).ToString) <> True" &
                                                    vbCrLf & variableName & " += 1 " & vbCrLf & " Else " &
                                                    vbCrLf & variableName & " += 0 " & vbCrLf & " End If " & vbCrLf
        Else
            GroupSumaryDetailScript = variableName & " += 0 " & vbCrLf
        End If

        Me.ScriptDetailOnBeforePrintBody += GroupSumaryDetailScript
    End Sub
    Public Sub SetGrandSummaryRunningTotalScript(ByVal FieldName As String, ByVal DataType As String)
        Dim variableName As String = GetGrandFieldVariableName(FieldName)

        Dim GroupSumaryDetailScript As String

        GroupSumaryDetailScript = variableName & " += " & "GetCurrentColumnValue(""" & FieldName & """)" & vbCrLf

        Me.ScriptDetailOnBeforePrintBody += GroupSumaryDetailScript
    End Sub
    Public Sub SetGrandSummaryCountScript(ByVal FieldName As String, ByVal DataType As String)
        Dim variableName As String = GetGrandFieldVariableName(FieldName)

        Dim GroupSumaryDetailScript As String
        If ReportDatasource.Tables.Item(0).Rows.Count > 0 Then
            GroupSumaryDetailScript = "If String.IsNullOrEmpty(" & "GetCurrentColumnValue(""" & FieldName & """).ToString) <> True Then " &
                                                    vbCrLf & variableName & " += 1 " & vbCrLf & " Else " &
                                                    vbCrLf & variableName & " += 0 " & vbCrLf & " End If " & vbCrLf
        Else
            GroupSumaryDetailScript = variableName & " += 0 " & vbCrLf
        End If

        Me.ScriptDetailOnBeforePrintBody += GroupSumaryDetailScript
    End Sub
    Public Sub SetResetGroupSummaryToZeroScript(ByVal FieldName As String, ByVal GroupName As String)
        Dim variableName As String = GetGroupFieldVariableName(FieldName, GroupName)

        Dim GroupSumarySetZeroScript As String = variableName & " = 0" & vbCrLf
        Me.ScriptGroupHeaderOnBeforePrint += GroupSumarySetZeroScript
        If Not CType(Me.GroupHeaderBands(GroupName), GroupHeaderBand).Scripts.OnBeforePrint.Contains(GroupSumarySetZeroScript) Then
            CType(Me.GroupHeaderBands(GroupName), GroupHeaderBand).Scripts.OnBeforePrint = ScriptStringOnBeforePrintStart & ScriptGroupHeaderOnBeforePrint & ScriptStringOnBeforePrintEnd
        End If
    End Sub

    Public Function GetGroupSummaryPrintScript(ByVal FieldName As String, ByVal GroupName As String, ByVal SummaryFieldType As String, ByVal CalculationType As String, ByVal IsShowCurrencyCode As Boolean, ByVal CurrencyField As String) As String
        Dim variableName As String = "varGroupSummaryMinutes" & FieldName

        If SummaryFieldType = "Duration" And CalculationType = "Sum" Then
            Return GetGroupSummaryPrintScriptForDuration(FieldName, GroupName)
        End If
        If SummaryFieldType = "Decimal" And CalculationType = "Sum" Then
            Return GetGroupSummaryPrintScriptForDecimal(FieldName, GroupName)
        End If
        If SummaryFieldType = "CurrencyDecimal" And CalculationType = "Sum" Then
            Return GetGroupSummaryPrintScriptForCurrencyDecimal(FieldName, GroupName, IsShowCurrencyCode, CurrencyField)
        End If
        If CalculationType = "Count" Then
            Return GetGroupSummaryPrintScriptForCount(FieldName, GroupName)
        End If

    End Function

    Public Function GetGrandSummaryPrintScript(ByVal FieldName As String, ByVal SummaryFieldType As String, ByVal CalculationType As String, ByVal IsShowCurrencyCode As Boolean, ByVal CurrencyField As String) As String


        If SummaryFieldType = "Duration" And CalculationType = "Sum" Then
            Return GetGrandSummaryPrintScriptForDuration(FieldName)
        End If
        If SummaryFieldType = "Decimal" And CalculationType = "Sum" Then
            Return GetGrandSummaryPrintScriptForDecimal(FieldName)
        End If
        If SummaryFieldType = "CurrencyDecimal" And CalculationType = "Sum" Then
            Return GetGrandSummaryPrintScriptForCurrencyDecimal(FieldName, IsShowCurrencyCode, CurrencyField)
        End If
        If CalculationType = "Count" Then
            Return GetGrandSummaryPrintScriptForCount(FieldName)
        End If
    End Function

    Public Function GetGroupFieldVariableName(ByVal SummaryFieldName As String, ByVal GroupName As String) As String
        Return "var" & GroupName & SummaryFieldName
    End Function

    Public Function GetGrandFieldVariableName(ByVal SummaryFieldName As String) As String
        Return "varGrandSummary" & SummaryFieldName
    End Function
    Public Function GetGroupSummaryPrintScriptForDuration(ByVal FieldName As String, ByVal GroupName As String) As String

        Dim PrintScript As String = ""
        Dim variableName As String = GetGroupFieldVariableName(FieldName, GroupName)

        PrintScript += GroupName & FieldName & ".Text = Math.Round((" & variableName & "/ 60) - 0.49, 0) & "":"" " & vbCrLf

        Return PrintScript

    End Function
    Public Function GetGroupSummaryPrintScriptForCount(ByVal FieldName As String, ByVal GroupName As String) As String

        Dim PrintScript As String = ""
        Dim variableName As String = GetGroupFieldVariableName(FieldName, GroupName)

        PrintScript += GroupName & FieldName & ".Text = " & variableName & vbCrLf

        Return PrintScript

    End Function
    Public Function GetGroupSummaryPrintScriptForDecimal(ByVal FieldName As String, ByVal GroupName As String) As String

        Dim PrintScript As String = ""
        Dim variableName As String = GetGroupFieldVariableName(FieldName, GroupName)

        PrintScript += GroupName & FieldName & ".Text = " & "String.Format(" & """{0:N}""" & ", " & variableName & ")" & vbCrLf

        Return PrintScript

    End Function
    Public Function GetGrandSummaryPrintScriptForDuration(ByVal FieldName As String) As String

        Dim PrintScript As String = ""
        Dim variableName As String = GetGrandFieldVariableName(FieldName)

        PrintScript += "GrandFooter" & FieldName & ".Text = Math.Round((" & variableName & "/ 60) - 0.49, 0) & "":"" " & vbCrLf

        Return PrintScript

    End Function

    Public Function GetGrandSummaryPrintScriptForDecimal(ByVal FieldName As String) As String

        Dim PrintScript As String = ""
        Dim variableName As String = GetGrandFieldVariableName(FieldName)

        PrintScript += "GrandFooter" & FieldName & ".Text = " & "String.Format(" & """{0:N}""" & ", " & variableName & ")" & vbCrLf

        Return PrintScript

    End Function
    Public Function GetGrandSummaryPrintScriptForCount(ByVal FieldName As String) As String

        Dim PrintScript As String = ""
        Dim variableName As String = GetGrandFieldVariableName(FieldName)

        PrintScript += "GrandFooter" & FieldName & ".Text = " & variableName & vbCrLf

        Return PrintScript

    End Function
    Public Function GetGroupSummaryPrintScriptForCurrencyDecimal(ByVal FieldName As String, ByVal GroupName As String, ByVal IsShowCurrencyCode As Boolean, ByVal CurrencyField As String) As String

        Dim PrintScript As String = ""
        Dim variableName As String = GetGroupFieldVariableName(FieldName, GroupName)
        If IsShowCurrencyCode <> True Then
            PrintScript += GroupName & FieldName & ".Text = " & "String.Format(" & """{0:N}""" & ", " & variableName & ")" & vbCrLf
        Else
            PrintScript += GroupName & FieldName & ".Text = String.Format(" & """{0:n}""" & ", " & variableName & ")" & " & " & """ """ & " & " & "GetCurrentColumnValue(""" & CurrencyField & """)" & vbCrLf
        End If

        Return PrintScript

    End Function

    Public Function GetGrandSummaryPrintScriptForCurrencyDecimal(ByVal FieldName As String, ByVal IsShowCurrencyCode As Boolean, ByVal CurrencyField As String) As String

        Dim PrintScript As String = ""
        Dim variableName As String = GetGrandFieldVariableName(FieldName)

        If IsShowCurrencyCode <> True Then
            PrintScript += "GrandFooter" & FieldName & ".Text = " & "String.Format(" & """{0:N}""" & ", " & variableName & ")" & vbCrLf
        Else
            PrintScript += "GrandFooter" & FieldName & ".Text = String.Format(" & """{0:n}""" & ", " & variableName & ")" & " & " & """ """ & " & " & "GetCurrentColumnValue(""" & CurrencyField & """)" & vbCrLf
        End If

        Return PrintScript

    End Function
    Public Sub AddGroupFooterSummaryColumn(ByVal SummaryFieldName As String, ByVal DataType As String, ByVal CalculationType As String, ByVal GroupName As String, ByVal SummaryCaption As String, ByVal GroupSummaryScript As String, ByVal Width As Integer, Optional ByVal TextAlignment As DevExpress.XtraPrinting.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify)
        Dim xrGroupSummaryLabel = New XRLabel
        With xrGroupSummaryLabel
            .Location = New System.Drawing.Point(Report.FindControl("lbl" & SummaryFieldName, False).Location.X, 0)
            .Size = New System.Drawing.Size(Width, 20)
            .Name = GroupName & SummaryFieldName
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Summary.Func = SummaryFunc.Custom
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            If TextAlignment <> DevExpress.XtraPrinting.TextAlignment.MiddleJustify Then
                .TextAlignment = TextAlignment
            Else
                .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            End If
            .BackColor = Drawing.ColorTranslator.FromHtml("#F0F0F0")
            .ForeColor = Drawing.Color.Black
            .Borders = DevExpress.XtraPrinting.BorderSide.Top
            .BorderWidth = 1
            .BorderColor = Drawing.Color.Silver
        End With

        Dim GroupFooter As GroupFooterBand = Me.GroupFooterBands(GroupName)
        GroupFooter.Controls.Add(xrGroupSummaryLabel)
        ScriptDetailOnBeforePrintBody += GroupSummaryScript


    End Sub
    'Public Sub AddGroupFooterSummaryLabel(ByVal LabelName As String, ByVal LabelCaption As String, ByVal SummaryCaption As String, ByVal RSWidth As Integer, ByVal GroupName As String)
    '    Dim xrGroupSummaryLabel = New XRLabel

    '    With xrGroupSummaryLabel
    '        .Name = "GroupFooterSummary" & LabelName
    '        .Location = New System.Drawing.Point(0, 0)
    '        .Size = New System.Drawing.Size(RSWidth, 20)
    '        .StylePriority.UseFont = False
    '        .StylePriority.UseTextAlignment = False
    '        .Summary.Func = SummaryFunc.Custom
    '        .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
    '        .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
    '        .Text = LabelCaption
    '        .BackColor = Drawing.Color.LightSteelBlue
    '        .ForeColor = Drawing.Color.Black
    '        .Borders = 15
    '        .BorderWidth = 1
    '        .BorderColor = Drawing.Color.Silver
    '    End With

    '    Dim GroupFooter As GroupFooterBand = Me.GroupFooterBands(GroupName)
    '    GroupFooter.Controls.Add(xrGroupSummaryLabel)

    'End Sub
    Public Sub AddReportFooterSummaryColumn(ByVal SummaryFieldName As String, ByVal DataType As String, ByVal SummaryCaption As String, ByVal GrandSummaryScript As String, ByVal Width As Integer, ByVal TextAlignment As DevExpress.XtraPrinting.TextAlignment, Optional ByVal PrettyPrint As Boolean = False)
        Dim xrGrandSummaryLabel = New XRLabel

        With xrGrandSummaryLabel
            .Name = "GrandFooter" & SummaryFieldName
            .Location = New System.Drawing.Point(Report.FindControl("lbl" & SummaryFieldName, False).Location.X, 0)
            .Size = New System.Drawing.Size(Width, 20)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            .TextAlignment = TextAlignment
            .BackColor = Drawing.ColorTranslator.FromHtml("#369") '
            .ForeColor = Drawing.Color.White
            .Borders = DevExpress.XtraPrinting.BorderSide.Top
            .BorderWidth = 1
            .BorderColor = Drawing.Color.Silver
            If Not PrettyPrint Then
                .Summary.Func = SummaryFunc.Custom
            Else
                .Text = "aa"
            End If
        End With

        xrReportFooterPanel.Controls.Add(xrGrandSummaryLabel)
        ScriptDetailOnBeforePrintBody += GrandSummaryScript
        Report.Bands.Add(ReportFooter)
    End Sub
    Public Sub AddReportFooterSummaryLabel(ByVal LabelName As String, ByVal LabelCaption As String, ByVal SummaryCaption As String, ByVal RSWidth As Integer)
        Dim xrGrandSummaryLabel = New XRLabel

        With xrGrandSummaryLabel
            .Name = "GrandFooter" & LabelName
            .Location = New System.Drawing.Point(0, 0)
            .Size = New System.Drawing.Size(RSWidth, 20)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Summary.Func = SummaryFunc.Custom
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            .Text = ResourceHelper.GetFromResource(LabelCaption)
            .BackColor = Drawing.ColorTranslator.FromHtml("#369") '
            .ForeColor = Drawing.Color.White
            .Borders = DevExpress.XtraPrinting.BorderSide.Top
            .BorderWidth = 1
            .BorderColor = Drawing.Color.Silver
        End With

        xrReportFooterPanel.Controls.Add(xrGrandSummaryLabel)
        Report.Bands.Add(ReportFooter)
    End Sub
    Public Sub AddBooleanColumn(ByVal ColumnName As String, ByVal FieldName As String, ByVal Width As Integer)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, Me.AddBooleanCalculatedField(FieldName), "")
        Me.AddColumnLabel(oBinding, ColumnName, Width, FieldName, DevExpress.XtraPrinting.TextAlignment.MiddleCenter)
    End Sub
    Public Sub AddColumnLabel(ByVal oBinding As DevExpress.XtraReports.UI.XRBinding, ByVal ColumnName As String, ByVal Width As Integer, ByVal FieldName As String, ByVal TextAlignment As DevExpress.XtraPrinting.TextAlignment, Optional ByVal CurrencyField As String = "", Optional ByVal Formula As String = "", Optional ByVal GetDetailColumnScript As String = "")
        xrLabel = New XRLabel
        Dim summary As New XRSummary

        If GetDetailColumnScript = "" Then
            xrLabel.DataBindings.Add(oBinding)
        End If

        With xrLabel
            .Location = New System.Drawing.Point(Report.FindControl("lbl" & FieldName, False).Location.X, 0)
            .Name = ColumnName
            .Size = New System.Drawing.Size(Width, 20)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .TextAlignment = TextAlignment
            .Font = New System.Drawing.Font(FontStyle, 8.0!, System.Drawing.FontStyle.Regular)
            '.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            .BorderWidth = 1
            .Borders = DevExpress.XtraPrinting.BorderSide.Top
            .BorderColor = Color.Silver
            .Multiline = True
            'System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(238, Byte), Integer))
            .EvenStyleName = "xtrEvenRow"
            .OddStyleName = "xtrOddRow"
        End With
        ScriptDetailOnBeforePrintBody += GetDetailColumnScript
        Detail.Controls.Add(xrLabel)
    End Sub

    Public Sub AddCurrencyColumnLabel(ByVal oBindingCurrency As DevExpress.XtraReports.UI.XRBinding, ByVal ColumnName As String, ByVal Width As Integer, ByVal FieldName As String, ByVal TextAlignment As DevExpress.XtraPrinting.TextAlignment, Optional ByVal CurrencyField As String = "")
        xrLabel = New XRLabel
        xrLabel.DataBindings.Add(oBindingCurrency)
        With xrLabel
            .Location = New System.Drawing.Point(XPos, 0)
            .Name = ColumnName
            .Size = New System.Drawing.Size(Width, 0)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Text = FieldName
            .TextAlignment = TextAlignment
            xrLabel.OddStyleName = "xtrOddRow"
            xrLabel.EvenStyleName = "xtrEvenRow"
            .Visible = False
        End With

        Detail.Controls.Add(xrLabel)

    End Sub
    Public Sub AddGroupHeaderLabel(ByVal GroupField As String, ByVal GroupFieldLabel As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand)
        Dim xrGroupLabel As New XRLabel
        With xrGroupLabel
            .Location = New System.Drawing.Point(0, 0)
            .Name = "lblGroupHeader" & GroupField
            .Size = New System.Drawing.Size(150, 0)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Text = GroupFieldLabel & " : "
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            xrGroupLabel.OddStyleName = "xtrOddRow"
            xrGroupLabel.EvenStyleName = "xtrEvenRow"
        End With

        GroupHeader.Controls.Add(xrGroupLabel)
    End Sub
    Public Sub AddGroupHeaderColumn(ByVal obinding As DevExpress.XtraReports.UI.XRBinding, ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String)
        Dim xrGroupLabel As New XRLabel
        xrGroupLabel.DataBindings.Add(obinding)

        With xrGroupLabel
            .Location = New System.Drawing.Point(Report.FindControl("lbl" & GroupName & GroupField, False).Location.X, 0)
            .Name = "GroupHeader" & GroupField
            .Size = New System.Drawing.Size(Width, 0)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Text = GroupFieldLabel
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            .BackColor = Drawing.ColorTranslator.FromHtml("#F0F0F0") 'Drawing.ColorTranslator.FromHtml("#F0F0F0")
            .ForeColor = Drawing.Color.Black
            .BorderWidth = 1
            .Borders = DevExpress.XtraPrinting.BorderSide.Top
            .BorderColor = Drawing.Color.Silver
        End With

        GroupHeader.Controls.Add(xrGroupLabel)

    End Sub
    Public Sub AddGroupFooterColumn(ByVal oBinding As DevExpress.XtraReports.UI.XRBinding, ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String)
        Dim xrGroupLabel As New XRLabel
        'Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "{0:d}")
        xrGroupLabel.DataBindings.Add(oBinding)
        With xrGroupLabel
            .Location = New System.Drawing.Point(PageHeader.FindControl("lbl" & GroupName & GroupField, False).Location.X, 0)
            .Name = "GroupFooter" & GroupField
            .Size = New System.Drawing.Size(Width, 20)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Text = GroupField
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            .BackColor = Drawing.ColorTranslator.FromHtml("#F0F0F0")
            .ForeColor = Drawing.Color.Black
            .BorderWidth = 1
            .Borders = DevExpress.XtraPrinting.BorderSide.Top
            .BorderColor = Drawing.Color.Silver
        End With

        GroupFooter.Controls.Add(xrGroupLabel)

    End Sub
    Public Sub AddGroupInReport(ByVal GroupField As String, ByVal GroupFieldOrder As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal IsConsolidated As Boolean, ByVal Width As Integer, ByVal CurrencyField As String, ByVal GroupFieldType As String)

        Me.AddGroupHeaderInReport(GroupField, GroupFieldOrder, GroupName, GroupFieldLabel, IsConsolidated, Width, CurrencyField, GroupFieldType)
        Me.AddGroupFooterInReport(GroupField, GroupFieldOrder, GroupName, IsConsolidated, Width, GroupFieldType, CurrencyField)
    End Sub
    Public Sub SetReportGroup(ByVal GroupField As String, ByVal GroupName As String, ByVal GroupFieldOrder As Integer, ByVal IsConsolidated As Boolean, ByVal Width As Integer)
        'Report.PageWidth = GSXPos
        Report.FindControl(GroupName & "_Header", False).Size = New System.Drawing.Size(GSXPos, 0)

        If (IsConsolidated = False) Or (IsConsolidated = True And GroupFieldOrder <> 0) Then
            If Me.GroupHeaderBands.Count = GroupFieldOrder + 1 Then
                Report.FindControl("GroupHeader" & GroupField, False).Size = New System.Drawing.Size(GSXPos, 20)
                GHWidth = GHWidth + Width
            Else
                Report.FindControl("GroupHeader" & GroupField, False).Size = New System.Drawing.Size(GSXPos - GHWidth, 20)
                GHWidth = GHWidth + Width
            End If
        End If

        If CType(Me.GroupHeaderBands(GroupName), GroupHeaderBand).Level <> GroupFieldOrder Then
            CType(Me.GroupHeaderBands(GroupName), GroupHeaderBand).Level = GroupFieldOrder
        End If
    End Sub
    Public Sub AddGroupHeaderInReport(ByVal GroupField As String, ByVal GroupFieldOrder As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal IsConsolidated As Boolean, ByVal Width As Integer, ByVal CurrencyField As String, ByVal GroupFieldType As String)
        Dim GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand
        Report.Bands.Add(GroupHeader)
        GroupHeader.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField(GroupField, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))
        GroupHeader.Height = 0
        GroupHeader.Level = GroupFieldOrder
        GroupHeader.Name = GroupName & "_Header"

        Me.GroupHeaderBands.Add(GroupName, GroupHeader)
        Me.GroupHeaderBands.Item(GroupName).KeepTogether = True
        If (IsConsolidated = False) Or (IsConsolidated = True And GroupFieldOrder <> 0) Then
            'Me.AddGroupHeaderLabel(GroupField, GroupFieldLabel, GroupHeader)
            Me.AddHeaderCaption(GroupName & GroupField, GroupFieldLabel, Width, CurrencyField)
            Me.AddGroupHeaderColumnByType(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel, GroupFieldType, CurrencyField)
            'Me.AddGroupHeaderColumn(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel)
        Else
            Me.AddHeaderCaption(GroupName & GroupField, GroupFieldLabel, Width, CurrencyField)
        End If

    End Sub
    Public Sub AddGroupHeaderColumnByType(ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal GroupFieldType As String, Optional ByVal CurrencyField As String = "")
        If GroupFieldType = "Duration" Then
            Me.AddGroupDurationColumn(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel, GroupFieldType)
        ElseIf GroupFieldType = "Decimal" Then
            Me.AddGroupDecimalColumn(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel, GroupFieldType)
        ElseIf GroupFieldType = "Date" Then
            Me.AddGroupDateColumn(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel, GroupFieldType)
        ElseIf GroupFieldType = "Time" Then
            Me.AddGroupTimeColumn(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel, GroupFieldType)
        ElseIf GroupFieldType = "Text" Then
            Me.AddGroupTextColumn(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel, GroupFieldType)
        ElseIf GroupFieldType = "Number" Then
            Me.AddGroupNumberColumn(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel, GroupFieldType)
        ElseIf GroupFieldType = "CurrencyDecimal" Then
            Me.AddGroupCurrencyDecimalColumn(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel, GroupFieldType, CurrencyField)
        ElseIf GroupFieldType = "Boolean" Then
            Me.AddGroupBooleanColumn(GroupField, GroupHeader, Width, GroupName, GroupFieldLabel, GroupFieldType)
        End If
    End Sub
    Public Sub AddGroupFooterBooleanColumn(ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, Me.AddBooleanCalculatedField(GroupField), "")
        Me.AddGroupFooterColumn(oBinding, GroupField, GroupFooter, Width, GroupName)
    End Sub
    Public Sub AddGroupDateColumn(ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "{0:d}")
        Me.AddGroupHeaderColumn(oBinding, GroupField, GroupHeader, Width, GroupName, GroupFieldLabel)
    End Sub
    Public Sub AddGroupDurationColumn(ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "{0:HH:mm}")
        Me.AddGroupHeaderColumn(oBinding, GroupField, GroupHeader, Width, GroupName, GroupFieldLabel)
    End Sub
    Public Sub AddGroupDecimalColumn(ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "{0:N}")
        Me.AddGroupHeaderColumn(oBinding, GroupField, GroupHeader, Width, GroupName, GroupFieldLabel)
    End Sub
    Public Sub AddGroupTimeColumn(ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "{0:t}")
        Me.AddGroupHeaderColumn(oBinding, GroupField, GroupHeader, Width, GroupName, GroupFieldLabel)
    End Sub
    Public Sub AddGroupTextColumn(ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "")
        Me.AddGroupHeaderColumn(oBinding, GroupField, GroupHeader, Width, GroupName, GroupFieldLabel)
    End Sub
    Public Sub AddGroupNumberColumn(ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "")
        Me.AddGroupHeaderColumn(oBinding, GroupField, GroupHeader, Width, GroupName, GroupFieldLabel)
    End Sub
    Public Sub AddGroupCurrencyDecimalColumn(ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal GroupFieldType As String, ByVal CurrencyField As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding

        If CurrencyField <> "" Then
            oBinding = New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, AddCurrencyDecimalCalculatedField(GroupField, CurrencyField), "")
        Else
            oBinding = New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "")
        End If

        Me.AddGroupHeaderColumn(oBinding, GroupField, GroupHeader, Width, GroupName, GroupFieldLabel)
    End Sub
    Public Sub AddGroupBooleanColumn(ByVal GroupField As String, ByVal GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldLabel As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, Me.AddBooleanCalculatedField(GroupField), "")
        Me.AddGroupHeaderColumn(oBinding, GroupField, GroupHeader, Width, GroupName, GroupFieldLabel)
    End Sub
    Public Sub AddHeaderCaption(ByVal LabelName As String, ByVal LabelText As String, ByVal Width As Integer, Optional ByVal CurrencyField As String = "")

        xrLabel = New XRLabel

        With xrLabel
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
            .Name = "lbl" & LabelName
            'Report.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            .Location = New System.Drawing.Point(GSXPos, YPos)
            .Size = New System.Drawing.Size(Width, 30)
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            .Text = ResourceHelper.GetFromResource(LabelText)
            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            .BackColor = Drawing.ColorTranslator.FromHtml("#369") '
            'Drawing.Color.FromName("Desktop")
            'Drawing.ColorTranslator.FromHtml("#607890") #369
            .ForeColor = Drawing.Color.White
            .BorderColor = Drawing.Color.White
            .Borders = 15
            .BorderWidth = 1
        End With
        If CurrencyField = "ParameterCurrencyCode" Then
            ScriptDetailOnBeforePrintBody += GetHeaderCaptionScript(LabelName, LabelText, CurrencyField)
        End If
        PageHeader.Controls.Add(xrLabel)
        GSXPos = GSXPos + Width
    End Sub
    Public Function GetHeaderCaptionScript(ByVal LabelName As String, ByVal LabelText As String, ByVal CurrencyField As String) As String
        Dim PrintScript As String = ""
        PrintScript += "lbl" & LabelName & ".Text = " & """" & LabelText & """" & ".Replace(" & """" & "BaseCurrency" & """" & ", " & "GetCurrentColumnValue(""" & CurrencyField & """)" & ")" & vbCrLf
        Return PrintScript
    End Function

    Public Sub SetDetailScript()
        Me.Detail.Scripts.OnBeforePrint = Me.ScriptDeclareString & ScriptStringOnBeforePrintStart & ScriptDetailOnBeforePrintBody & ScriptStringOnBeforePrintEnd
    End Sub

    Public Sub AddGroupFooterInReport(ByVal GroupField As String, ByVal GroupFieldOrder As Integer, ByVal GroupName As String, ByVal IsConsolidated As Boolean, ByVal Width As Integer, ByVal GroupFieldType As String, ByVal CurrencyField As String)
        Dim GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand
        Report.Bands.Add(GroupFooter)
        GroupFooter.Height = 0
        GroupFooter.Name = GroupName & "_Footer"
        Me.GroupFooterBands.Add(GroupName, GroupFooter)
        Me.GroupFooterBands.Item(GroupName).KeepTogether = True

        If IsConsolidated = True And GroupFieldOrder = 0 Then
            Me.AddGroupFooterColumnByType(GroupField, GroupFooter, Width, GroupName, GroupFieldType, CurrencyField)
            'Me.AddGroupFooterColumn(GroupField, GroupFooter, Width, GroupName)
        End If

    End Sub


    Public Sub AddReportFooterSummaryControls(ByVal SummaryCaption As String, ByVal FieldName As String, ByVal CalculationType As String, ByVal SummaryFieldType As String)
        xrGrandSummaryLabel = New XRLabel

        With xrGrandSummaryLabel
            .Name = "Grand" & SummaryCaption
            .StylePriority.UseFont = False
            .StylePriority.UseTextAlignment = False
            Report.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            .Summary.Func = SummaryFunc.Custom
            .Font = New System.Drawing.Font(FontStyle, 7.75!, System.Drawing.FontStyle.Bold)
        End With

        ReportFooter.Controls.Add(xrGrandSummaryLabel)

    End Sub

    Public Sub AddFormulaDataColumn(ByVal FormulaFieldName As String, ByVal Expression As String, ByVal DataType As System.Type)
        Dim objColumn As DataColumn
        Try
            objColumn = GetDataTable().Columns.Add(FormulaFieldName, DataType, Expression)

        Catch ex As Exception
            If Not objColumn Is Nothing Then
                GetDataTable().Columns.Remove(objColumn)
                objColumn = GetDataTable().Columns.Add(FormulaFieldName, DataType, "0")
            End If
        End Try

    End Sub
    Public Sub AddParameterColumn(ByVal ParameterName As String, ByVal ParameterExpression As String, ByVal DataType As System.Type)
        Me.AddCustomColumn(ParameterName, ParameterExpression, DataType)
    End Sub
    Public Sub AddCustomColumn(ByVal Columname As String, ByVal ExpressionValue As String, ByVal DataType As System.Type)
        Dim objColumn As DataColumn = Me.GetDataTable().Columns.Add(Columname, DataType, "'" & ExpressionValue & "'")
    End Sub
    Public Sub AddGroupFooterColumnByType(ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldType As String, Optional ByVal CurrencyField As String = "")
        If GroupFieldType = "Duration" Then
            Me.AddGroupFooterDurationColumn(GroupField, GroupFooter, Width, GroupName, GroupFieldType)
        ElseIf GroupFieldType = "Decimal" Then
            Me.AddGroupFooterDecimalColumn(GroupField, GroupFooter, Width, GroupName, GroupFieldType)
        ElseIf GroupFieldType = "Date" Then
            Me.AddGroupFooterDateColumn(GroupField, GroupFooter, Width, GroupName, GroupFieldType)
        ElseIf GroupFieldType = "Time" Then
            Me.AddGroupFooterTimeColumn(GroupField, GroupFooter, Width, GroupName, GroupFieldType)
        ElseIf GroupFieldType = "Text" Then
            Me.AddGroupFooterTextColumn(GroupField, GroupFooter, Width, GroupName, GroupFieldType)
        ElseIf GroupFieldType = "Number" Then
            Me.AddGroupFooterNumberColumn(GroupField, GroupFooter, Width, GroupName, GroupFieldType)
        ElseIf GroupFieldType = "CurrencyDecimal" Then
            Me.AddGroupFooterCurrencyDecimalColumn(GroupField, GroupFooter, Width, GroupName, GroupFieldType, CurrencyField)
        ElseIf GroupFieldType = "Boolean" Then
            Me.AddGroupFooterBooleanColumn(GroupField, GroupFooter, Width, GroupName, GroupFieldType)
        End If
    End Sub
    Public Sub AddGroupFooterDurationColumn(ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "{0:HH:mm}")
        Me.AddGroupFooterColumn(oBinding, GroupField, GroupFooter, Width, GroupName)
    End Sub
    Public Sub AddGroupFooterDecimalColumn(ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "{0:N}")
        Me.AddGroupFooterColumn(oBinding, GroupField, GroupFooter, Width, GroupName)
    End Sub
    Public Sub AddGroupFooterDateColumn(ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "{0:d}")
        Me.AddGroupFooterColumn(oBinding, GroupField, GroupFooter, Width, GroupName)
    End Sub
    Public Sub AddGroupFooterTimeColumn(ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "{0:t}")
        Me.AddGroupFooterColumn(oBinding, GroupField, GroupFooter, Width, GroupName)
    End Sub
    Public Sub AddGroupFooterTextColumn(ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "")
        Me.AddGroupFooterColumn(oBinding, GroupField, GroupFooter, Width, GroupName)
    End Sub
    Public Sub AddGroupFooterNumberColumn(ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldType As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "")
        Me.AddGroupFooterColumn(oBinding, GroupField, GroupFooter, Width, GroupName)
    End Sub
    Public Sub AddGroupFooterCurrencyDecimalColumn(ByVal GroupField As String, ByVal GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand, ByVal Width As Integer, ByVal GroupName As String, ByVal GroupFieldType As String, ByVal CurrencyField As String)
        Dim oBinding As New DevExpress.XtraReports.UI.XRBinding

        If CurrencyField <> "" Then
            oBinding = New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, AddCurrencyDecimalCalculatedField(GroupField, CurrencyField), "")
        Else
            oBinding = New DevExpress.XtraReports.UI.XRBinding("Text", Me.DataSource, GroupField, "")
        End If

        Me.AddGroupFooterColumn(oBinding, GroupField, GroupFooter, Width, GroupName)
    End Sub

    Public Sub ShowReport()
        Dim i As Integer = GSXPos + 230
        If i < 750 Then
            Report.PageWidth = 750
        Else
            Report.PageWidth = i
        End If
        If Not Report.FindControl("FooterFooter", False) Is Nothing Then
            Report.FindControl("FooterFooter", False).Location = New System.Drawing.Point(0, 0)
        End If

        Dim YOffset As Integer = 100

        If Report.FindControl("xrPageInfo2", False) IsNot Nothing Then
            Report.FindControl("xrPageInfo2", False).Location = New System.Drawing.Point(GSXPos - 115, ReportFooterYPos - YOffset)
        End If
        If Report.FindControl("xrPageInfoDate", False) IsNot Nothing Then
            Report.FindControl("xrPageInfoDate", False).Location = New System.Drawing.Point(-500, ReportFooterYPos - YOffset)
        End If
        If Report.FindControl("xrPageInfoCode", False) IsNot Nothing Then
            Report.FindControl("xrPageInfoCode", False).Location = New System.Drawing.Point((GSXPos / 2) - 50, ReportFooterYPos - YOffset - 7)
        End If
        If Report.FindControl("xrTitle", False) IsNot Nothing Then
            Report.FindControl("xrTitle", False).Location = New System.Drawing.Point((GSXPos / 2) - 70, HeaderYPos + 37)
        End If
        If Report.FindControl("xrToday", False) IsNot Nothing Then
            Report.FindControl("xrToday", False).Location = New System.Drawing.Point(GSXPos - 90, HeaderYPos + 37)
        End If

        If Not Report.FindControl("xrReportFooterPanel", False) Is Nothing Then
            Report.FindControl("xrReportFooterPanel", False).Size = New System.Drawing.Size(GSXPos, 20)
        End If
        Me.DataSource = Me.GetReportDatasource

    End Sub

    Public Sub ShowReport(ByVal printing As Boolean)
        Dim i As Integer = GSXPos + 230
        If i < 750 Then
            Report.PageWidth = 750
        Else
            Report.PageWidth = i
        End If
        If Not Report.FindControl("FooterFooter", False) Is Nothing Then
            Report.FindControl("FooterFooter", False).Location = New System.Drawing.Point(0, 0)
        End If

        Report.FindControl("xrPageInfo2", False).Location = New System.Drawing.Point(GSXPos - 115, ReportFooterYPos)


        If Not Report.FindControl("xrReportFooterPanel", False) Is Nothing Then
            Report.FindControl("xrReportFooterPanel", False).Size = New System.Drawing.Size(GSXPos, 20)
        End If
        Me.DataSource = Me.GetReportDatasource

    End Sub

    Public Function GetDataTable() As DataTable
        Return Me.GetReportDatasource().Tables(Me.ReportTableName)
    End Function

    Private Sub AttachmentLinkItemCreated(sender As Object, e As HtmlEventArgs)
        'e.ContentCell.CssClass = "colAttachmentLink"
    End Sub

End Class
