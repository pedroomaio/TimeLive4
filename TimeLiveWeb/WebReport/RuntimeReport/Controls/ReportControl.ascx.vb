Imports System.Text
Imports System.Diagnostics
Imports System.Globalization
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports System.IO
Imports System.Windows.Forms

Partial Class WebReport_RuntimeReport_Controls_ReportControl
    Inherits System.Web.UI.UserControl
    Dim objReport As New LiveReport
    Dim ReportDataTable As DataTable
    Dim ReportDataSet As DataSet
    Dim IsConsolidated As Boolean
    Dim DataRangeString As String
    Dim AllColWidths As New List(Of Tuple(Of String, Integer))

    Private ReadOnly Property AccountReportId As Guid
        Get
            Return New Guid(Me.Request.QueryString("AccountReportId"))
        End Get
    End Property

    Public Sub SetDataSource(ByVal objDataTable As DataTable, ByVal Consolidated As Boolean)
        ReportDataTable = objDataTable
        ReportDataSet = New DataSet
        ReportDataSet.Tables.Add(ReportDataTable)
        IsConsolidated = Consolidated
    End Sub

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If CheckIfReportIsDetailExpenses() Then
                Session("AccountExpenseEntryAttachmentDetails") = Nothing

                btnCustomAction.Text = ResourceHelper.GetFromResource("ExportAllImageAttachments")
                btnCustomAction.OnClientClick = "open('DetailExpenseReportAttachmentsView.aspx','_blank',null,true);"
                btnCustomAction.Visible = True
            End If
            If CheckIfReportIsDetailTimeSheet() Then
                Session("ReportDataTable_FT") = Nothing

                btnPrettyPrint.Text = ResourceHelper.GetFromResource("ExportPrettyPrintTimeSheets")
                btnPrettyPrint.OnClientClick = "open('DetailTimeSheetReport_PrettyPrint.aspx','_blank',null,true);"
                btnPrettyPrint.Visible = True
            End If
        End If

    End Sub
    Public Sub ShowReport()

        Me.objReport.ShowReport()

        Me.ReportViewer1.DataBind()
        Me.ReportViewer1.Report.ExportOptions.Csv.Encoding = Encoding.UTF8
    End Sub
    Public Sub AddParameterColumn(ByVal ParameterName As String, ByVal ParameterValue As String, ByVal ParameterType As System.Type)
        objReport.AddParameterColumn(ParameterName, ParameterValue, ParameterType)
    End Sub
    Public Sub RenderReport()
        objReport = New LiveReport
        Me.ReportViewer1.Report = objReport.ReportObejct
        objReport.SetDataSource(ReportDataSet, ReportDataTable.TableName)
    End Sub
    Public Sub ShowReportFromFilter(Optional ReportDataTable As DataTable = Nothing)
        Dim ReportAdapter As New dsReportDesignTableAdapters.AccountReportTableAdapter
        Dim ListOfCurrencys As New List(Of Integer)

        If CheckIfReportIsDetailExpenses() Then
            If ReportDataTable IsNot Nothing Then
                Dim FirstRowCurrencyCode As Integer
                If ReportDataTable.Rows.Count >= 1 Then
                    FirstRowCurrencyCode = ReportDataTable.Rows(0)("AccountCurrencyId")
                End If
                For Each item As DataRow In ReportDataTable.Rows
                    ListOfCurrencys.Add(item("AccountCurrencyId"))
                Next
            End If
        End If

        Dim dtReport As dsReportDesign.AccountReportDataTable = ReportAdapter.GetDataByAccountReportId(AccountReportId)
        Dim drReport As dsReportDesign.AccountReportRow = dtReport.Rows(0)

        If Session("ReportIncludeDataRange") = True Then
            objReport.AddPageDateLabel("Date Range: " & Session("ReportsDataRange"), Session("ReportIncludeDataRange"))
        Else
            objReport.AddPageDateLabel("", Session("ReportIncludeDataRange"))
        End If

        objReport.AddPageCodeLabel(DBUtilities.GetEmployeeCode.ToString())
        objReport.AddReportTodayInHeader()
        objReport.AddCompanyLogoInHeader("CompanyLogo", "~/img/Xpand_it_logo.png")

        'If drReport.ShowCompanyLogo = True Then
        '    If Not IsDBNull(LocaleUtilitiesBLL.IsShowCompanyOwnLogo) Then
        '        If LocaleUtilitiesBLL.IsShowCompanyOwnLogo = True And LocaleUtilitiesBLL.IsLogoFileExistInSessionAccount = True Then
        '            objReport.AddCompanyLogoInHeader("CompanyLogo", "~/img/Xpand_it_logo.png")
        '        End If
        '    End If
        'End If



        If Not IsDBNull(drReport.Item("ReportTitle")) Then
            If drReport.ReportTitle <> "" Then
                objReport.AddReportTitleInHeader("Title", ResourceHelper.GetFromResource(drReport.ReportTitle))
            End If
        End If
        If Not IsDBNull(drReport.Item("ReportHeader")) Then
            If drReport.ReportHeader <> "" Then
                objReport.AddReportHeaderInHeader("Header", ResourceHelper.GetFromResource(drReport.ReportHeader))
            End If
        End If
        ''Adding Group In Report

        Dim ReportGroupAdapter As New dsReportControlTableAdapters.vueAccountReportGroupTableAdapter
        Dim dtReportGroup As dsReportControl.vueAccountReportGroupDataTable = ReportGroupAdapter.GetReportGroupsByReportId(AccountReportId)
        Dim drReportGroup As dsReportControl.vueAccountReportGroupRow

        If dtReportGroup.Rows.Count > 0 Then
            drReportGroup = dtReportGroup.Rows(0)

            For Each drReportGroup In dtReportGroup.Rows
                Dim stringFont As New Font("Microsoft Sans Serif", 11)
                drReportGroup.SystemReportDataSourceFieldWidth = AddNewColumnsWidthToAllColWidthsList(drReportGroup.SystemReportDataSourceField, drReportGroup.SystemReportDataSourceFieldCaption, stringFont)
                objReport.AddGroupInReport(drReportGroup.SystemReportDataSourceField, drReportGroup.ReportGroupFieldOrder, drReportGroup.ReportGroup, drReportGroup.ReportGroupFieldLabel, IsConsolidated, drReportGroup.SystemReportDataSourceFieldWidth, IIf(IsDBNull(drReportGroup.Item("CurrencyField")), "", drReportGroup.Item("CurrencyField")), drReportGroup.SystemReportFieldType)
            Next
        End If

        ''Adding Detail In Report

        Dim ReportControlAdapter As New dsReportControlTableAdapters.vueAccountReportColumnTableAdapter
        Dim dtReportControl As dsReportControl.vueAccountReportColumnDataTable = ReportControlAdapter.GetReportColumnsByReportId(AccountReportId)
        Dim drReportControl As dsReportControl.vueAccountReportColumnRow

        If dtReportControl.Rows.Count > 0 Then

            drReportControl = dtReportControl.Rows(0)
            For Each drReportControl In dtReportControl.Rows
                Dim Formula As String = IIf(IsDBNull(drReportControl.Item("ColumnFormula")), IIf(IsDBNull(drReportControl.Item("Formula")), "", drReportControl.Item("Formula")), drReportControl.Item("ColumnFormula"))
                If Formula <> "" Then
                    objReport.AddFormulaDataColumn(drReportControl.SystemReportDataSourceField, Formula, GetType(System.Object))
                End If
                If IsConsolidated <> True Then
                    Dim stringFont As New Font("Microsoft Sans Serif", 11)
                    drReportControl.SystemReportDataSourceFieldWidth = AddNewColumnsWidthToAllColWidthsList(drReportControl.SystemReportDataSourceField, drReportControl.Caption, stringFont)
                    objReport.AddDetailColumn(drReportControl.SystemReportDataSourceField, drReportControl.Caption, drReportControl.SystemReportDataSourceField, drReportControl.SystemReportFieldType, drReportControl.SystemReportDataSourceFieldWidth, IIf(IsDBNull(drReportControl.Item("CurrencyField")), "", drReportControl.Item("CurrencyField")), Formula)
                End If
            Next
        End If
        If Not ReportDataTable Is Nothing And New Guid(LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId)) = New Guid("665306D7-D2D5-4A9B-A248-B7AD53D587E8") Then
            For n As Integer = 0 To ReportDataTable.Columns.Count - 1
                If Not ReportDataTable.Columns(n).ColumnName = "EmployeeName" Then
                    objReport.AddDetailColumn(n, "", n, "Text", 120, "", "")
                End If
            Next
        End If

        'Detail Expense Report
        If CheckIfReportIsDetailExpenses() Then
            SetupDetailExpenseReportAttachmentLinks()
            Session("ClientFilterForExpensesReport") = CType(Me.Parent.Controls(1).FindControl("Clients"), DropDownList).SelectedItem.ToString()
            Session("ProjectsFilterForExpensesReport") = CType(Me.Parent.Controls(1).FindControl("AssignedProject"), DropDownList).SelectedItem.ToString()
            Session("StartDateFilterForExpensesReport") = UIUtilities.ConverFromDateToConsolidatedDate(CType(Me.Parent.Controls(1).FindControl("StartDate"), eWorld.UI.CalendarPopup).PostedDate)
            Session("EndDateFilterForExpensesReport") = UIUtilities.ConverFromDateToConsolidatedDate(CType(Me.Parent.Controls(1).FindControl("EndDate"), eWorld.UI.CalendarPopup).PostedDate)
            Session("BaseCurrencyFilterForExpensesReport") = CType(Me.Parent.Controls(1).FindControl("BaseCurrency"), DropDownList)
        End If
        If CheckIfReportIsDetailTimeOffs() Then
            SetupDetailTimeOffReportAttachmentLinks()
        End If
        If CheckIfReportIsDetailTimeSheet() Then
            Session("ClientFilterForPretty") = CType(Me.Parent.Controls(1).FindControl("Clients"), DropDownList).SelectedItem.ToString()
            Session("ProjectsFilterForPretty") = CType(Me.Parent.Controls(1).FindControl("AssignedProject"), DropDownList).SelectedItem.ToString()
            Session("StartDateFilterForPretty") = UIUtilities.ConverFromDateToConsolidatedDate(CType(Me.Parent.Controls(1).FindControl("StartDate"), eWorld.UI.CalendarPopup).PostedDate)
            Session("EndDateFilterForPretty") = UIUtilities.ConverFromDateToConsolidatedDate(CType(Me.Parent.Controls(1).FindControl("EndDate"), eWorld.UI.CalendarPopup).PostedDate)
        End If

        ''Adding Summary In Report

        Dim ReportSummaryAdapter As New dsReportControlTableAdapters.vueAccountReportSummaryTableAdapter
        Dim dtReportSummary As dsReportControl.vueAccountReportSummaryDataTable = ReportSummaryAdapter.GetDataForSummary(AccountReportId)
        Dim drReportSummary As dsReportControl.vueAccountReportSummaryRow
        If dtReportSummary.Rows.Count > 0 Then

            If ReportDataTable IsNot Nothing Then
                If ListOfCurrencys.Distinct().Count > 1 Then
                    Dim ListOfNetAmountsFields As List(Of dsReportControl.vueAccountReportSummaryRow) = dtReportSummary.Where(Function(x) x.SystemReportDataSourceField = "NetAmount").ToList()
                    For Each item As dsReportControl.vueAccountReportSummaryRow In ListOfNetAmountsFields
                        dtReportSummary.Rows.Remove(item)
                    Next
                End If
            End If

            drReportSummary = dtReportSummary.Rows(0)
            For Each drReportSummary In dtReportSummary.Rows

                Dim Width = AllColWidths.Where(Function(x) x.Item1 = drReportSummary.SystemReportDataSourceField).FirstOrDefault()

                If Width IsNot Nothing Then
                    drReportSummary.SystemReportDataSourceFieldWidth = Width.Item2
                End If

                If drReportSummary.IsShowGroupTotal = True Then
                    If ReportDataTable.Columns(drReportSummary.SystemReportDataSourceField) Is Nothing OrElse Not Left(ReportDataTable.Columns(drReportSummary.SystemReportDataSourceField).Expression, 1).Contains("'") Then
                        objReport.AddGroupSummaryInReport(drReportSummary.SystemReportDataSourceField, drReportSummary.ReportGroup, drReportSummary.IsShowGroupTotal, drReportSummary.IsShowGrandTotal, "Object", drReportSummary.SystemReportFieldType, drReportSummary.Caption, drReportSummary.CalculationType, IsConsolidated, drReportSummary.SystemReportDataSourceFieldWidth, IIf(IsDBNull(drReportSummary.Item("Formula")), "", drReportSummary.Item("Formula")), drReportSummary.ShowCurrencyCodeInSummary, IIf(IsDBNull(drReportSummary.Item("CurrencyField")), "", drReportSummary.Item("CurrencyField")))
                    End If
                End If
                If drReportSummary.IsShowGrandTotal = True Then
                    If ReportDataTable.Columns(drReportSummary.SystemReportDataSourceField) Is Nothing OrElse Not Left(ReportDataTable.Columns(drReportSummary.SystemReportDataSourceField).Expression, 1).Contains("'") Then
                        objReport.AddGrandSummaryInReport(drReportSummary.SystemReportDataSourceField, "Object", drReportSummary.SystemReportFieldType, drReportSummary.SummaryCaption, drReportSummary.CalculationType, drReportSummary.SystemReportDataSourceFieldWidth, dtReportSummary.Count, IsConsolidated, drReportSummary.ShowCurrencyCodeInSummary, IIf(IsDBNull(drReportSummary.Item("CurrencyField")), "", drReportSummary.Item("CurrencyField")))
                    End If
                End If
            Next
        End If


        ''Setting Report Group In Report

        If dtReportGroup.Rows.Count > 0 Then
            drReportGroup = dtReportGroup.Rows(0)
            For Each drReportGroup In dtReportGroup.Rows
                Dim Width = AllColWidths.Where(Function(x) x.Item1 = drReportGroup.SystemReportDataSourceField).FirstOrDefault()

                If Width IsNot Nothing Then
                    drReportGroup.SystemReportDataSourceFieldWidth = Width.Item2
                End If

                objReport.SetReportGroup(drReportGroup.SystemReportDataSourceField, drReportGroup.ReportGroup, drReportGroup.ReportGroupFieldOrder, IsConsolidated, drReportGroup.SystemReportDataSourceFieldWidth)
            Next
        End If

        If Not IsDBNull(drReport.Item("ReportFooter")) Then
            If drReport.ReportFooter <> "" Then
                objReport.AddReportFooterInFooter("Footer", drReport.ReportFooter)
            End If
        End If

        'objReport.SetReportTitleAndHeaderWidth()
        ''Calling ShowReport Function

        Me.ShowReport()

    End Sub
    Private Function CheckIfReportIsDetailExpenses() As Boolean
        Return New Guid(LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId)) = New Guid("0F2D1D68-826D-400E-BF9F-95D4A9D6C4E0")
    End Function
    Private Function CheckIfReportIsDetailTimeOffs() As Boolean
        Return New Guid(LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId)) = New Guid("5AD7C2EE-4CBD-42A7-A4FF-394BEAA47CF8")
    End Function
    Private Function CheckIfReportIsDetailTimeSheet() As Boolean
        Return New Guid(LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId)) = New Guid("3a080202-6842-4eca-8c79-a945978810b4")
    End Function

    Function AddNewColumnsWidthToAllColWidthsList(ByVal DataSourceField As String, ByVal caption As String, ByVal stringFont As Font) As Integer

        Dim ColumnsWidth As Integer

        Dim listOfStringLengths As New List(Of String)

        For Each item As DataRow In ReportDataTable.Rows
            listOfStringLengths.Add(item(DataSourceField).ToString())
        Next

        Dim measureString As String = listOfStringLengths.OrderByDescending(Function(x) x.Length).FirstOrDefault()

        Dim HeaderWidth As New Integer
        HeaderWidth = TextRenderer.MeasureText(caption, stringFont).Width + 5

        Dim ColWidths As Tuple(Of String, Integer)

        If measureString IsNot Nothing Then

            Dim width As New Integer
            width = TextRenderer.MeasureText(measureString, stringFont).Width

            ColumnsWidth = IIf(HeaderWidth > width, HeaderWidth, width)

            ColWidths = New Tuple(Of String, Integer)(DataSourceField, ColumnsWidth)

        Else

            ColWidths = New Tuple(Of String, Integer)(DataSourceField, HeaderWidth)
            ColumnsWidth = HeaderWidth

        End If

        AllColWidths.Add(ColWidths)

        Return ColumnsWidth

    End Function
    Private Sub SetupDetailTimeOffReportAttachmentLinks()
        Dim TimeOffAttchBll = New TimeOffAttachmentsBLL()

        Dim dt = objReport.GetDataTable()
        dt.Columns.Add("Attachments", GetType(System.String))
        dt.Columns.Add("AttachmentsUrl", GetType(System.String))

        Dim AccountTimeOffEntryAttachmentDetails = New ArrayList()

        Dim AcceptableExtensions = New String() {".jpg", ".png", ".gif", ".jpeg", ".pdf", ".img", ".jpe", ".tiff", ".bmp", ".pbm"}

        For Each dr As DataRow In dt.Rows
            Dim accountTimeOffEntryId = CType(dr("AccountEmployeeTimeEntryId"), Integer)

            Dim aeeDT As TimeOffAttachments.TimeOffAttachmentsDataTable = TimeOffAttchBll.GetTimeOffAttachmentsByTimeEntryId(accountTimeOffEntryId)
            Dim aeeDR As TimeOffAttachments.TimeOffAttachmentsRow
            If aeeDT.Rows.Count > 0 Then
                aeeDR = aeeDT.Rows(0)
                dr("Attachments") = TimeOffAttchBll.CountAttachmentsByTimeEntryId(accountTimeOffEntryId)
                dr("AttachmentsUrl") = ResolveUrl("~/Employee/TimeOffAttachments.aspx") + String.Format("?ReadOnly=False&TimeEntry={0}", accountTimeOffEntryId)

                'For Each row As TimeOffAttachments.TimeOffAttachmentsRow In aeeDT
                '    If AcceptableExtensions.Any(Function(x) row.AttachmentLocalPath.ToUpper().Contains(x.ToString().ToUpper())) Or CheckFileIsImage(row.AttachmentLocalPath) = True Then
                '        Dim uri = ResolveUrl("~/Shared/FileDownload.aspx") & "?" & LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/TimeOffAttachments/" & accountTimeOffEntryId & "/" & row.AttachmentLocalPath)
                '        AccountTimeOffEntryAttachmentDetails.Add(New Tuple(Of String, DataRow)(DBUtilities.GetSessionAccountId & "/TimeOffAttachments" & "/" & accountTimeOffEntryId & "/" & row.AttachmentLocalPath, dr))
                '    End If
                'Next

            Else
                dr("Attachments") = 0
                dr("AttachmentsUrl") = ResolveUrl("~/Employee/TimeOffAttachments.aspx") + String.Format("?ReadOnly=False&TimeEntry={0}", accountTimeOffEntryId)
            End If
        Next

        If IsConsolidated = False Then
            objReport.AddCustomDetailColumn("Attachments", "Attachments", "Attachments", "Link", 80, "", "", "AttachmentsUrl")
        End If


        'Session("AccountTimeOffEntryAttachmentDetails") = AccountTimeOffEntryAttachmentDetails
    End Sub

    Private Sub SetupDetailExpenseReportAttachmentLinks()
        Dim accountAttachmentsBLL = New AccountAttachmentsBLL()

        Dim dt = objReport.GetDataTable()
        dt.Columns.Add("Attachments", GetType(System.String))
        dt.Columns.Add("AttachmentsUrl", GetType(System.String))
        dt.Columns.Add("AttUrlForPdf", GetType(System.String))

        Dim AccountExpenseEntryAttachmentDetails As DataTable = dt.Clone()

        Dim AcceptableExtensions = New String() {".jpg", ".png", ".gif", ".jpeg", ".pdf", ".img", ".jpe", ".tiff", ".bmp", ".pbm"}

        For Each dr As DataRow In dt.Rows
            Dim accountExpenseEntryId = CType(dr("AccountExpenseEntryId"), Integer)

            Dim aeeDT As TimeLiveDataSet.CountAccountExpenseEntryIdDataTable = accountAttachmentsBLL.GetCountAccountExpenseEntryId(accountExpenseEntryId)
            Dim aeeDR As TimeLiveDataSet.CountAccountExpenseEntryIdRow
            If aeeDT.Rows.Count > 0 Then
                aeeDR = aeeDT.Rows(0)

                dr("Attachments") = aeeDR.TotalCount
                dr("AttachmentsUrl") = ResolveUrl("~/ProjectAdmin/AccountExpenseEntryApprovalAttachment.aspx") + String.Format("?AccountExpenseEntryId={0}&AccountAttachmentTypeId=1", accountExpenseEntryId)
                dr("AttUrlForPdf") = ""

                Dim attachments = accountAttachmentsBLL.GetAccountAttachmentsByAccountExpenseEntryId(accountExpenseEntryId, Guid.Empty)
                For index = 0 To (attachments.Count - 1)
                    Dim att = attachments(index)
                    If Not att.AccountExpenseEntryId = 0 Then
                        If AcceptableExtensions.Any(Function(x) att.AttachmentLocalPath.ToUpper().Contains(x.ToString().ToUpper())) Or CheckFileIsImage(att.AttachmentLocalPath) = True Then
                            dr("AttUrlForPdf") = DBUtilities.GetSessionAccountId & "/" & accountExpenseEntryId & "/" & att.AttachmentLocalPath
                            AccountExpenseEntryAttachmentDetails.Rows.Add(dr.ItemArray)
                        End If
                    End If
                Next
            End If
        Next

        If IsConsolidated = False Then
            objReport.AddCustomDetailColumn("Attachments", "Attachments", "Attachments", "Link", 80, "", "", "AttachmentsUrl")
        End If

        Dim dtaView As New DataView(AccountExpenseEntryAttachmentDetails)
        dtaView.Sort = "EmployeeName ASC , AccountExpenseName ASC , ExpenseType ASC"
        AccountExpenseEntryAttachmentDetails = dtaView.ToTable

        Session("AccountExpenseEntryAttachmentDetails") = AccountExpenseEntryAttachmentDetails
    End Sub

    Public Function CheckFileIsImage(file As String) As Boolean
        Dim result As Boolean
        Try
            Dim imgInput As System.Drawing.Image = System.Drawing.Image.FromFile(file)
            Dim gInput As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(imgInput)
            Dim thisFormat As Imaging.ImageFormat = imgInput.RawFormat
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

End Class
