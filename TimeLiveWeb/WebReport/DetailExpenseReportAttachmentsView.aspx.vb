Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports System.Net
Imports System.IO
Imports DevExpress.XtraPrinting.Drawing
Imports System.Linq
Imports System.Threading.Tasks

Partial Class WebReport_DetailExpenseReportAttachmentsView
    Inherits System.Web.UI.Page
    Dim FontName As String = "Arial"
    Dim AccountCurrencyCode As String = ""
    Dim AccountCurrencyCodeId As Integer
    Dim TotalForHeader As String
    Dim dlDir As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
    Dim listOfAllImg As New List(Of System.Drawing.Bitmap)
    Sub Page_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session("BaseCurrencyFilterForExpensesReport") IsNot Nothing Then
            Dim BaseCurrencyDllFromReport As DropDownList = CType(Session("BaseCurrencyFilterForExpensesReport"), DropDownList)
            AccountCurrencyCode = BaseCurrencyDllFromReport.SelectedItem.Text
            AccountCurrencyCodeId = CType(BaseCurrencyDllFromReport.SelectedItem.Value, Integer)
        Else
            AccountCurrencyCode = ""
            AccountCurrencyCodeId = 0
        End If

        Dim accountExpenseEntryAttachmentDetails As DataTable = Session("AccountExpenseEntryAttachmentDetails")
        If Not IsNothing(accountExpenseEntryAttachmentDetails) And accountExpenseEntryAttachmentDetails.Rows.Count > 0 Then

            Dim reportLive As New LiveReport


            Dim fileNameSheetDates = (From Row As DataRow In accountExpenseEntryAttachmentDetails.Rows
                                      Select CType(Row("ExpenseSheetDate"), DateTime).ToString("dd-MM-yyyy")
                                      Distinct).ToList()
            Dim fileNameProjectNames = (From Row As DataRow In accountExpenseEntryAttachmentDetails.Rows
                                        Select Row("ProjectName")
                                        Distinct).ToList()
            Dim fileNameExpenseTypes = (From Row As DataRow In accountExpenseEntryAttachmentDetails.Rows
                                        Select Row("ExpenseType")
                                        Distinct).ToList()

            Dim fileName = String.Format("{0}_{1}_{2}",
                                     If(fileNameSheetDates.Count > 1, "ALL", fileNameSheetDates.First()),
                                     If(fileNameProjectNames.Count > 1, "ALL", fileNameProjectNames.First()),
                                     If(fileNameExpenseTypes.Count > 1, "ALL", fileNameExpenseTypes.First()))

            Dim DataSetForReport As New DataSet
            If accountExpenseEntryAttachmentDetails.DataSet IsNot Nothing Then
                DataSetForReport = accountExpenseEntryAttachmentDetails.DataSet
            Else
                DataSetForReport.Tables.Add(accountExpenseEntryAttachmentDetails)
            End If

            'Create Header And Summary
            Dim Header As New XRTable
            Header = CreateHeader()
            Dim Summary As New LiveReport
            Summary = CreateSummary(Header, DataSetForReport)
            'Create Detail
            Dim Detail As New LiveReport
            Detail = CreateDetailed(DataSetForReport)
            'Create Attachments Detail

            For index = 0 To (accountExpenseEntryAttachmentDetails.Rows.Count - 1)
                Dim attachmentDetails As DataRow = accountExpenseEntryAttachmentDetails.Rows(index)
                Dim attachmentUrl = attachmentDetails("AttUrlForPdf")

                Dim PathOfImages_FromPDF As New List(Of String)

                Dim fromPdf As Boolean = False

                If attachmentUrl.ToString().Substring(Math.Max(0, attachmentUrl.ToString().Length - 4)) = ".pdf" Then
                    PathOfImages_FromPDF = GetImagesFromPdf(attachmentUrl, fileName & index & DBUtilities.GetEmployeeCode.ToString() & "-" & DBUtilities.GetSessionAccountEmployeeId.ToString())
                    fromPdf = True
                Else
                    PathOfImages_FromPDF.Add(Server.MapPath(dlDir & attachmentUrl.ToString()))
                End If

                For index2 = 0 To PathOfImages_FromPDF.Count - 1

                    Try

                        Dim dummyLive As New LiveReport

                        Dim expenseCurrency = attachmentDetails("CurrencyCode")
                        Dim reimbursementCurrency = attachmentDetails("ParameterCurrencyCode")
                        'attachmentDetail("ReimbursementCurrencyCode")

                        If index2 = 0 Then

                            If index = 0 Then
                                ' Expense Documents

                                Dim DocumentsTitle As New XRLabel
                                With DocumentsTitle
                                    .WidthF = 1600
                                    .Font = New Font(FontName, 15.0!)
                                    .Text = "Expense Documents"
                                    .WordWrap = False
                                End With

                                dummyLive.PageHeader.Controls.Add(DocumentsTitle)

                            End If

                            Dim expenseCurrencyExchangeRate As Double
                            Double.TryParse(attachmentDetails("ExchangeRate"), expenseCurrencyExchangeRate)

                            Dim reimbursementCurrencyExchangeRate = attachmentDetails("ReimbursementExchangeRate")

                            Dim expenseCurrencyLabel = New XRLabel()
                            expenseCurrencyLabel.AutoWidth = True
                            expenseCurrencyLabel.WordWrap = False
                            expenseCurrencyLabel.Text = "Net Amount: " + attachmentDetails("CalculatedCurrencyAmount").ToString() + " " + reimbursementCurrency.ToString()
                            If index = 0 Then
                                expenseCurrencyLabel.TopF = 30
                            End If

                            dummyLive.PageHeader.Controls.Add(expenseCurrencyLabel)

                            If expenseCurrency <> AccountCurrencyCode Then
                                Dim exchangeRateLabel = New XRLabel()
                                exchangeRateLabel.Text = String.Format("1 {0} = {1} {2}", AccountCurrencyCode, Math.Round(1 / attachmentDetails("CurrencyExchangeRate") * expenseCurrencyExchangeRate, 3), expenseCurrency)
                                exchangeRateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                                exchangeRateLabel.WidthF = reportLive.PageWidth - reportLive.Margins.Left - reportLive.Margins.Right
                                If index = 0 Then
                                    exchangeRateLabel.TopF = 30
                                End If
                                dummyLive.PageHeader.Controls.Add(exchangeRateLabel)
                            End If

                        End If



                        Dim pictureBox = New XRPictureBox()

                        If Not fromPdf Then
                            pictureBox.ImageUrl = PathOfImages_FromPDF(index2)
                        Else
                            Dim fs As FileStream = New FileStream(PathOfImages_FromPDF(index2), FileMode.Open, FileAccess.Read)
                            Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(fs)
                            pictureBox.Image = image
                            listOfAllImg.Add(image)
                        End If

                        pictureBox.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze
                        pictureBox.WidthF = reportLive.PageWidth - reportLive.Margins.Left - reportLive.Margins.Right
                        pictureBox.HeightF = reportLive.PageHeight - reportLive.Margins.Top - reportLive.Margins.Bottom
                        pictureBox.SendToBack()


                        dummyLive.Detail.Controls.Add(pictureBox)

                        dummyLive.CreateDocument()

                        reportLive.Pages.Add(dummyLive.Pages(0))

                    Catch ex As WebException
                        ' Unable to download file

                    End Try

                Next

            Next

            'Create Final Report
            Dim SummaryAndHeaderReport As New XtraReport
            SummaryAndHeaderReport = Summary.Report()
            SummaryAndHeaderReport.CreateDocument(False)
            SummaryAndHeaderReport.PageWidth += 400.0F

            Dim DetailedReport As New XtraReport
            DetailedReport = Detail.Report()
            DetailedReport.CreateDocument(False)
            DetailedReport.PageWidth += 400.0F
            DetailedReport.PrintingSystem.Document.AutoFitToPagesWidth = 1

            Dim ReportMain As New XtraReport
            ReportMain.CreateDocument(False)
            ReportMain = reportLive.Report()
            ReportMain.PageWidth += 400.0F

            Dim tempFileName = Path.GetTempFileName()

            Dim FinalReport As New XtraReport
            FinalReport.CreateDocument(False)
            FinalReport.Pages.AddRange(SummaryAndHeaderReport.Pages)
            FinalReport.Pages.AddRange(DetailedReport.Pages)
            FinalReport.Pages.AddRange(ReportMain.Pages)

            FinalReport.PrintingSystem.Document.AutoFitToPagesWidth = 1
            FinalReport.ExportOptions.Pdf.ImageQuality = 50
            FinalReport.ExportOptions.Pdf.ConvertImagesToJpeg = False
            FinalReport.ExportOptions.Pdf.ImageQuality = PdfJpegImageQuality.Medium

            Dim ExpOPT As New PdfExportOptions
            ExpOPT.ConvertImagesToJpeg = False
            ExpOPT.ImageQuality = PdfJpegImageQuality.Medium
            ExpOPT.NeverEmbeddedFonts = True

            FinalReport.ExportToPdf(tempFileName, ExpOPT)
            '------------------

            'Upload
            Dim bufferSize = 10000
            Dim buffer As Byte() = New [Byte](bufferSize) {}

            Using fileStream As New FileStream(tempFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim dataToRead = fileStream.Length

                Response.Clear()
                Response.ContentType = "application/octet-stream"
                Response.AddHeader("Content-Disposition", String.Format("attachment;filename=""{0}.pdf""", fileName))
                Response.AddHeader("Content-Length", fileStream.Length.ToString())

                While dataToRead > 0
                    If Response.IsClientConnected Then
                        Dim length = fileStream.Read(buffer, 0, bufferSize)

                        Response.OutputStream.Write(buffer, 0, length)

                        Response.Flush()

                        buffer = New [Byte](bufferSize) {}
                        dataToRead = dataToRead - length
                    Else
                        dataToRead = -1
                    End If
                End While
            End Using

            For Each item In listOfAllImg
                item.Dispose()
            Next

            Response.Close()
        End If

        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", "window.close();", True)
    End Sub

    Public Function ByteArrayToImage(ByVal byteArrayIn As Byte()) As System.Drawing.Image

        Using MS As New MemoryStream(byteArrayIn)
            Return New Bitmap(MS)
        End Using

    End Function

    Private Function GetImagesFromPdf(ByVal attUrl As String, FileName As String) As List(Of String)

        Dim PathsOfImages As List(Of String) = MagickPDF.ConverPDFtoMultipleImages(attUrl, FileName, Path.GetTempPath().ToString())
        Return PathsOfImages

    End Function

    Private Function AddCompanyLogoInHeader() As XRPictureBox

        Dim liverep As New LiveReport

        Dim xrPicBox As New XRPictureBox

        Using fs As FileStream = New FileStream(System.Web.HttpContext.Current.Server.MapPath("~/img/Xpand_it_logo.png"), FileMode.Open, FileAccess.Read)
            Using original As System.Drawing.Image = System.Drawing.Image.FromStream(fs)


                With xrPicBox
                    .Image = liverep.byteArrayToImage(liverep.imageToByteArray(original))
                    .Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
                    .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                    .HeightF = 60
                    .WidthF = 220
                    .Location = New System.Drawing.Point(0, 0)
                End With
                Return xrPicBox

            End Using
        End Using

    End Function

    Private Function CreateHeader() As XRTable

        Dim table As New XRTable

        table.BeginInit()

        Dim rows(6) As XRTableRow
        rows(0) = New XRTableRow
        rows(1) = New XRTableRow
        rows(2) = New XRTableRow
        rows(3) = New XRTableRow
        rows(4) = New XRTableRow
        rows(5) = New XRTableRow

        Dim HorizontalLineCellSummary As New XRTableCell
        With HorizontalLineCellSummary
            .BorderColor = Color.Black
            .BorderDashStyle = BorderDashStyle.Solid
            .Borders = BorderSide.Top
            .WidthF = 1500.0F
            rows(0).Cells.Add(HorizontalLineCellSummary)
        End With

        Dim VerticalLineCellSummaryLeft As New XRTableCell
        With VerticalLineCellSummaryLeft
            .BorderColor = Color.Black
            .BorderDashStyle = BorderDashStyle.Solid
            .Borders = BorderSide.Left
            .HeightF = 1500.0F
            rows(0).Cells.Add(VerticalLineCellSummaryLeft)
        End With

        Dim VerticalLineCellSummaryLeft2 As New XRTableCell
        With VerticalLineCellSummaryLeft2
            .BorderColor = Color.Black
            .BorderDashStyle = BorderDashStyle.Solid
            .Borders = BorderSide.Left
            .HeightF = 1500.0F
            rows(1).Cells.Add(VerticalLineCellSummaryLeft2)
        End With

        Dim VerticalLineCellSummaryLeft3 As New XRTableCell
        With VerticalLineCellSummaryLeft3
            .BorderColor = Color.Black
            .BorderDashStyle = BorderDashStyle.Solid
            .Borders = BorderSide.Left
            .HeightF = 1500.0F
            rows(2).Cells.Add(VerticalLineCellSummaryLeft3)
        End With

        Dim Spacebetweenlines As Single = 30.0F

        With rows(0)
            .HeightF = Spacebetweenlines
        End With

        With rows(1)
            .HeightF = Spacebetweenlines
        End With

        With rows(2)
            .HeightF = Spacebetweenlines
        End With

        With rows(3)
            .HeightF = Spacebetweenlines
        End With

        Dim VerticalLineCellSummaryRight As New XRTableCell
        With VerticalLineCellSummaryRight
            .BorderColor = Color.Black
            .BorderDashStyle = BorderDashStyle.Solid
            .Borders = BorderSide.Right
            .BoundsF = New RectangleF(550, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .HeightF = 1500.0F
            rows(0).Cells.Add(VerticalLineCellSummaryRight)
        End With

        Dim VerticalLineCellSummaryRight1 As New XRTableCell
        With VerticalLineCellSummaryRight1
            .BorderColor = Color.Black
            .BorderDashStyle = BorderDashStyle.Solid
            .Borders = BorderSide.Right
            .BoundsF = New RectangleF(550, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .HeightF = 1500.0F
            rows(1).Cells.Add(VerticalLineCellSummaryRight1)
        End With

        Dim VerticalLineCellSummaryRight2 As New XRTableCell
        With VerticalLineCellSummaryRight2
            .BorderColor = Color.Black
            .BorderDashStyle = BorderDashStyle.Solid
            .Borders = BorderSide.Right
            .BoundsF = New RectangleF(550, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .HeightF = 1500.0F
            rows(2).Cells.Add(VerticalLineCellSummaryRight2)
        End With

        Dim HorizontalLineCellSummaryBottom As New XRTableCell
        With HorizontalLineCellSummaryBottom
            .BorderColor = Color.Black
            .BorderDashStyle = BorderDashStyle.Solid
            .Borders = BorderSide.Bottom
            .WidthF = 1500.0F
            rows(2).Cells.Add(HorizontalLineCellSummaryBottom)
        End With

        'Line and space

        With rows(4)
            .HeightF = 40.0F
        End With

        With rows(5)
            .HeightF = 80.0F 'Space beetween line and Logo
        End With

        Dim Project As String = Session("ProjectsFilterForExpensesReport").ToString()
        Dim Client As String = Session("ClientFilterForExpensesReport").ToString()
        Dim StartDate As String = Session("StartDateFilterForExpensesReport")
        Dim EndDate As String = Session("EndDateFilterForExpensesReport")
        'Project = "XP - ACESS"
        'Client = "XPAND-IT"

        Dim xOffset As Integer = 10

        Dim ProjectNameCell As New XRTableCell
        With ProjectNameCell
            .WidthF = 120
            .BoundsF = New RectangleF(xOffset, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .Font = New Font(FontName, 10.0!, FontStyle.Bold)
            .TextAlignment = TextAlignment.MiddleLeft
            .Text = "Project Name:"
            .WordWrap = False
            rows(0).Cells.Add(ProjectNameCell)
        End With

        Dim ProjectNameCell2 As New XRTableCell
        With ProjectNameCell2
            .WidthF = 400
            .Font = New Font(FontName, 10.0!)
            .BoundsF = New RectangleF(xOffset + 97, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .TextAlignment = TextAlignment.MiddleLeft
            .Text = Project
            .WordWrap = True
            rows(0).Cells.Add(ProjectNameCell2)
        End With

        Dim ClientCell As New XRTableCell
        With ClientCell
            .WidthF = 110
            .BoundsF = New RectangleF(xOffset, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .Font = New Font(FontName, 10.0!, FontStyle.Bold)
            .TextAlignment = TextAlignment.MiddleLeft
            .Text = "Client Name:"
            .WordWrap = False
            rows(1).Cells.Add(ClientCell)
        End With

        Dim ClientCell2 As New XRTableCell
        With ClientCell2
            .WidthF = 400
            .Font = New Font(FontName, 10.0!)
            .BoundsF = New RectangleF(xOffset + 90, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .TextAlignment = TextAlignment.MiddleLeft
            .Text = Client
            .WordWrap = True
            rows(1).Cells.Add(ClientCell2)
        End With

        Dim StartDateCell As New XRTableCell
        With StartDateCell
            .WidthF = 600
            .Font = New Font(FontName, 10.0!, FontStyle.Bold)
            .BoundsF = New RectangleF(xOffset, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .TextAlignment = TextAlignment.MiddleLeft
            .Text = "Start Date:" 'Session("FilterStartDate").ToString().Remove(10)
            .WordWrap = False
            rows(2).Cells.Add(StartDateCell)
        End With

        Dim StartDateCell2 As New XRTableCell
        With StartDateCell2
            .WidthF = 600
            .Font = New Font(FontName, 10.0!)
            .BoundsF = New RectangleF(xOffset + 75, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .TextAlignment = TextAlignment.MiddleLeft
            .Text = Session("FilterStartDate").ToString().Remove(10)
            .WordWrap = False
            rows(2).Cells.Add(StartDateCell2)
        End With


        Dim EndDateCell As New XRTableCell
        With EndDateCell
            .WidthF = 600
            .Font = New Font(FontName, 10.0!, FontStyle.Bold)
            .BoundsF = New RectangleF(xOffset, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .TextAlignment = TextAlignment.MiddleCenter
            .Text = "End Date:" 'Session("FilterEndDate").ToString.Remove(10)
            .WordWrap = False
            rows(2).Cells.Add(EndDateCell)
        End With

        Dim EndDateCell2 As New XRTableCell
        With EndDateCell2
            .WidthF = 600
            .Font = New Font(FontName, 10.0!)
            .BoundsF = New RectangleF(xOffset + 72, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
            .TextAlignment = TextAlignment.MiddleCenter
            .Text = Session("FilterEndDate").ToString.Remove(10)
            .WordWrap = False
            rows(2).Cells.Add(EndDateCell2)
        End With

        Dim HorizontalLineCell As New XRTableCell
        With HorizontalLineCell
            .BorderColor = Color.Black
            .BorderDashStyle = BorderDashStyle.Solid
            .Borders = BorderSide.Top
            .WidthF = 1200.0F
            rows(4).Cells.Add(HorizontalLineCell)
        End With

        Dim SummaryTitle As New XRTableRow
        SummaryTitle.HeightF = 50.0F
        Dim cellOfSummary As New XRTableCell
        With cellOfSummary
            .WidthF = 1600
            .Font = New Font(FontName, 14.0!)
            .TextAlignment = TextAlignment.MiddleLeft
            .Text = "Expenses Summary"
            .WordWrap = False
            SummaryTitle.Cells.Add(cellOfSummary)
        End With

        Dim SeparatorRow As New XRTableRow
        Dim SeparatorCell As New XRTableCell
        With SeparatorCell
            .HeightF = 40.0F
            SeparatorRow.Cells.Add(SeparatorCell)
        End With

        table.Rows.Add(rows(5))
        table.Rows.Add(rows(4))
        table.Rows.Add(rows(0))
        table.Rows.Add(rows(1))
        table.Rows.Add(rows(2))
        table.Rows.Add(rows(3))
        table.Rows.Add(SeparatorRow)
        table.Rows.Add(SummaryTitle)

        Return table

    End Function

    Private Function CreateSummary(ByVal table As XRTable, ByVal dt As DataSet) As LiveReport

        Dim SummaryReport As New LiveReport

        Dim dtForSummary As DataTable = dt.Tables(0).Copy()
        Dim obj As DataTable = StructureDtForSummary(dtForSummary)

        Dim dtSet As New DataSet
        dtSet.Tables.Add(obj)

        SummaryReport.Report.DataSource = obj
        SummaryReport.SetDataSource(dtSet, obj.TableName)
        SummaryReport.SetReportFontStyle(FontName)

        Dim TitleText As New XRLabel
        With TitleText
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            .HeightF = 60
            .WidthF = 220
            .Font = New Font(FontName, 18.0!)
            .Text = "Project Expenses"
            .Location = New System.Drawing.Point(400, 15)
        End With

        'Detail
        SummaryReport.AddDetailColumn("ProjectName", "Project Name", "ProjectName", "Text", 270, "", "")
        SummaryReport.AddDetailColumn("EmployeeName", "Employee Name", "EmployeeName", "Text", 140, "", "")
        SummaryReport.AddDetailColumn("ExpenseType", "Expense Type", "ExpenseType", "Text", 120, "", "")
        SummaryReport.AddDetailColumn("TotalNetAmount", "Total Amount (" + AccountCurrencyCode + ")", "TotalNetAmount", "Text", 120, "", "")

        SummaryReport.ReportHeader.Controls.Add(AddCompanyLogoInHeader())
        SummaryReport.ReportHeader.Controls.Add(TitleText)
        SummaryReport.ReportHeader.Controls.Add(table)

        Return SummaryReport
    End Function

    Private Function CreateDetailed(ByVal dtset As DataSet) As LiveReport

        Dim dt As DataTable
        dt = dtset.Tables(0)

        Dim objReport As New LiveReport
        objReport.Report.DataSource = dt
        objReport.SetDataSource(dtset, dt.TableName)

        If Not dt.Columns.Contains("NetAmountWithCurrency") Then
            dt.Columns.Add("NetAmountWithCurrency")
        End If

        For Each item As DataRow In dt.Rows
            item("NetAmountWithCurrency") = FormatNumber(item("CalculatedCurrencyAmount"), 2).ToString() + " " + AccountCurrencyCode
        Next

        'Add Detailed
        objReport.AddDetailColumn("AccountExpenseEntryDate", "Date", "AccountExpenseEntryDate", "Date", 120, "", "")
        objReport.AddDetailColumn("Description", "Description", "Description", "Text", 500, "", "")
        objReport.AddDetailColumn("NetAmountWithCurrency", "Net Amount (" + AccountCurrencyCode + ")", "NetAmountWithCurrency", "Text", 120, "", "")
        objReport.AddDetailColumn("ExpenseType", "Expense Type", "ExpenseType", "Text", 200, "", "")

        objReport.SetReportFontStyle(FontName)

        Dim table2 As New XRTable

        Dim DetailedTitle As New XRTableRow
        DetailedTitle.HeightF = 100.0F
        Dim cellOfDetail As New XRTableCell
        With cellOfDetail
            .WidthF = 1600
            .Font = New Font(FontName, 20.0!)
            .TextAlignment = TextAlignment.MiddleLeft
            .Text = "Expense Details"
            .WordWrap = False
            DetailedTitle.Cells.Add(cellOfDetail)
        End With

        table2.Rows.Add(DetailedTitle)

        Dim SeparatorRow2 As New XRTableRow
        Dim SeparatorCell2 As New XRTableCell
        With SeparatorCell2
            .HeightF = 70.0F
            SeparatorRow2.Cells.Add(SeparatorCell2)
        End With

        table2.Rows.Add(SeparatorRow2)

        objReport.ReportHeader.Controls.Add(table2)

        Return objReport

    End Function

    Private Function StructureDtForSummary(ByVal dt As DataTable) As DataTable

        Dim objCurrency As New AccountCurrencyBLL
        Dim dtCurrency As AccountCurrency.vueAccountCurrencyDataTable = objCurrency.GetvueAccountCurrencyByAccountCurrencyId(AccountCurrencyCodeId)
        If dtCurrency.Rows.Count > 0 Then
            AccountCurrencyCode = dtCurrency.Rows(0)("CurrencyCode").ToString()
        End If

        Dim reso = From row In dt
                   Select ProjectName = row("ProjectName"),
                       EmployeeName = row("EmployeeName"),
                       AccountExpenseEntryId = row("AccountExpenseEntryId"),
                       ExpenseType = row("ExpenseType"),
                       Amount = row("Amount").ToString(),
                       NetAmount = row("CalculatedCurrencyAmount").ToString(),
                       CurrencyCodeEntry = row("CurrencyCode") Distinct

        Dim result = From row In reso.ToList()
                     Order By row.ProjectName Ascending
                     Group row By ProjectName = row.ProjectName,
                         EmployeeName = row.EmployeeName,
                         ExpenseType = row.ExpenseType
                         Into MethodGroup = Group Select New With {
                         Key ProjectName,
                         Key EmployeeName,
                         Key ExpenseType,
                         Key .TotalAmount = MethodGroup.Sum(Function(x) Decimal.Parse(x.Amount)),
                         Key .TotalNetAmount = MethodGroup.Sum(Function(x) Decimal.Parse(x.NetAmount))}




        Dim NewDt As New DataTable
        NewDt.Columns.Add("ProjectName")
        NewDt.Columns.Add("EmployeeName")
        NewDt.Columns.Add("ExpenseType")
        NewDt.Columns.Add("TotalAmount")
        NewDt.Columns.Add("TotalNetAmount")

        Dim firstProject As String = ""
        If result.ToList.Count >= 1 Then
            firstProject = result.ToList(0).ProjectName
        End If

        Dim total As Double = 0

        For Each item In result.ToList
            Dim dr As DataRow = NewDt.NewRow()

            If firstProject <> item.ProjectName Then
                NewDt.Rows.Add(dr)
                dr = NewDt.NewRow()
            End If

            dr("ProjectName") = item.ProjectName
            dr("EmployeeName") = item.EmployeeName
            dr("ExpenseType") = item.ExpenseType
            dr("TotalNetAmount") = FormatNumber(item.TotalNetAmount, 2) + " " + AccountCurrencyCode

            total += item.TotalNetAmount
            firstProject = item.ProjectName
            NewDt.Rows.Add(dr)
        Next

        Return NewDt

    End Function

End Class