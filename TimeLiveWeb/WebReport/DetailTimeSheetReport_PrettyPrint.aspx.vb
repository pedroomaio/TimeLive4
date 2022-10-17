Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports System.Net
Imports System.IO
Imports DevExpress.XtraPrinting.Drawing
Imports System.Linq
Imports System.Diagnostics

Partial Class WebReport_DetailTimeSheetReport_PrettyPrint
    Inherits System.Web.UI.Page
    Dim objReport As New LiveReport
    Dim summaryReport As New LiveReport
    Sub Page_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim FontName As String = "Arial"
        Dim DataTableReport As DataTable = Nothing

        If Session("ReportDataTable_FT") IsNot Nothing Then
            DataTableReport = CType(Session("ReportDataTable_FT"), DataTable)
        End If

        If Not IsNothing(DataTableReport) Then

            Dim ShortTableReport As DataTable = DataTableReport.DefaultView.ToTable(False, "EmployeeName", "ProjectName", "Description", "AccountWorkType", "TotalHours", "AccountEmployeeTimeEntryId", "TimeEntryDate", "ClientName", "AccountCostCenter")
            Dim SummaryTableReport As DataTable = SummaryDataSource(ShortTableReport)

            summaryReport = New LiveReport
            Dim DataSetForSumReport As New DataSet
            DataSetForSumReport.Tables.Add(SummaryTableReport)
            summaryReport.Report.DataSource = SummaryTableReport
            summaryReport.SetDataSource(DataSetForSumReport, ShortTableReport.TableName)
            summaryReport.SetReportFontStyle("Arial")

            summaryReport.AddDetailColumn("EmployeeName", "Employee Name", "EmployeeName", "Text", 200, "", "")
            summaryReport.AddDetailColumn("TotalHours", "Total Working Hours", "TotalHours", "CustomText", 120, "", "")
            summaryReport.AddDetailColumn("TotalDays", "Total Working Days", "TotalDays", "CustomText", 120, "", "")

            'Detailed Report 


            objReport = New LiveReport
            Dim DataSetForReport As New DataSet
            DataSetForReport.Tables.Add(ShortTableReport)
            objReport.Report.DataSource = ShortTableReport
            objReport.SetDataSource(DataSetForReport, ShortTableReport.TableName)

            'Add Group
            objReport.AddGroupInReport("EmployeeName", 0, "EmployeeName", "Employee Name", False, 200, "", "Text")
            'Add Detailed
            objReport.AddDetailColumn("TimeEntryDate", "Date", "TimeEntryDate", "Date", 100, "", "")
            objReport.AddDetailColumn("ProjectName", "Project Name", "ProjectName", "Text", 200, "", "")
            objReport.AddDetailColumn("Description", "Description", "Description", "Text", 280, "", "")
            objReport.AddDetailColumn("AccountWorkType", "Work Type", "AccountWorkType", "Text", 120, "", "")
            objReport.AddDetailColumn("AccountCostCenter", "Cost Center", "AccountCostCenter", "Text", 120, "", "")
            objReport.AddDetailColumn("TotalHours", "Hours", "TotalHours", "Decimal", 60, "", "")
            'Add Summary for hours
            'objReport.AddGroupFooterSummaryColumn("TotalHours", "Object", "Sum", "EmployeeName", "Hours", "", 60, objReport.SetTextAlignmentsForSummary("TotalHours", "Decimal", False))
            objReport.SetReportGroup("EmployeeName", "EmployeeName", 0, False, 300)
            objReport.SetReportFontStyle("Arial")

            Dim GroupFooter As GroupFooterBand = objReport.GroupFooterBands("EmployeeName")

            '---'
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

            Dim VerticalLineCellSummaryLeft4 As New XRTableCell
            With VerticalLineCellSummaryLeft4
                .BorderColor = Color.Black
                .BorderDashStyle = BorderDashStyle.Solid
                .Borders = BorderSide.Left
                .HeightF = 1500.0F
                rows(3).Cells.Add(VerticalLineCellSummaryLeft4)
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

            Dim VerticalLineCellSummaryRight3 As New XRTableCell
            With VerticalLineCellSummaryRight3
                .BorderColor = Color.Black
                .BorderDashStyle = BorderDashStyle.Solid
                .Borders = BorderSide.Right
                .BoundsF = New RectangleF(550, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
                .HeightF = 1500.0F
                rows(3).Cells.Add(VerticalLineCellSummaryRight3)
            End With

            Dim HorizontalLineCellSummaryBottom As New XRTableCell
            With HorizontalLineCellSummaryBottom
                .BorderColor = Color.Black
                .BorderDashStyle = BorderDashStyle.Solid
                .Borders = BorderSide.Bottom
                .WidthF = 1500.0F
                rows(3).Cells.Add(HorizontalLineCellSummaryBottom)
            End With

            'Line and space

            With rows(4)
                .HeightF = 40.0F
            End With

            With rows(5)
                .HeightF = 80.0F 'Space beetween line and Logo
            End With

            Dim Project As String = Session("ProjectsFilterForPretty").ToString()
            Dim Client As String = Session("ClientFilterForPretty").ToString()
            Dim StartDate As String = Session("StartDateFilterForPretty")
            Dim EndDate As String = Session("EndDateFilterForPretty")
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

            Dim CountHoursCell As New XRTableCell
            With CountHoursCell
                .WidthF = 1600
                .Font = New Font(FontName, 10.0!, FontStyle.Bold)
                .BoundsF = New RectangleF(xOffset, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
                .TextAlignment = TextAlignment.MiddleLeft
                .Text = "Total hours:"
                .WordWrap = False
                rows(3).Cells.Add(CountHoursCell)
            End With

            Dim totalHours As Decimal = GetTotalHoursForHeader(ShortTableReport)

            Dim CountHoursCell2 As New XRTableCell
            With CountHoursCell2
                Dim Time = TimeSpan.FromHours(totalHours.ToString())
                .WidthF = 1600
                .Font = New Font(FontName, 10.0!)
                .BoundsF = New RectangleF(xOffset + 83, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
                .TextAlignment = TextAlignment.MiddleLeft
                .Text = String.Format("{0:00}:{1:00}", totalHours.ToString(New System.Globalization.CultureInfo("en-GB")).Split("."c)(0), Time.Minutes)
                .WordWrap = False
                rows(3).Cells.Add(CountHoursCell2)
            End With

            Dim CountDaysCell As New XRTableCell
            With CountDaysCell
                .WidthF = 600
                .Font = New Font(FontName, 10.0!, FontStyle.Bold)
                .BoundsF = New RectangleF(xOffset + 4, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
                .TextAlignment = TextAlignment.MiddleCenter
                .Text = "Total days:"
                .WordWrap = False
                rows(3).Cells.Add(CountDaysCell)
            End With

            Dim CountDaysCell2 As New XRTableCell
            With CountDaysCell2
                Dim Time = String.Format(New System.Globalization.CultureInfo("en-GB"), "{0:0.00}", Math.Round(totalHours / 8, 2))
                .WidthF = 600
                .Font = New Font(FontName, 10.0!)
                .BoundsF = New RectangleF(xOffset + 343, .BoundsF.Y, .BoundsF.Width, .BoundsF.Height)
                .TextAlignment = TextAlignment.MiddleLeft
                .Text = Time
                .WordWrap = False
                rows(3).Cells.Add(CountDaysCell2)
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
                .Text = "Information per person"
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

            summaryReport.ReportHeader.Controls.Add(AddCompanyLogoInHeader())

            Dim TitleText As New XRLabel
            With TitleText
                .Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
                .HeightF = 60
                .WidthF = 220
                .Font = New Font(FontName, 18.0!)
                .Text = "Project Timesheet"
                .Location = New System.Drawing.Point(400, 15)
            End With

            summaryReport.ReportHeader.Controls.Add(TitleText)

            summaryReport.ReportHeader.Controls.Add(table)
            'summaryReport.AddGrandSummaryInReport("TotalHours", "Object", "Text", "Total Hours", "Sum", 180, 0, False, False, "")

            Dim table2 As New XRTable

            Dim DetailedTitle As New XRTableRow
            DetailedTitle.HeightF = 100.0F
            Dim cellOfDetail As New XRTableCell
            With cellOfDetail
                .WidthF = 1600
                .Font = New Font(FontName, 26.0!)
                .TextAlignment = TextAlignment.MiddleLeft
                .Text = "Detail Reports"
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

            Dim SumReport = New XtraReport()
            SumReport = summaryReport.Report()
            SumReport.CreateDocument(False)
            SumReport.PageWidth += 400.0F

            Dim report = New XtraReport()
            report = objReport.Report()
            report.CreateDocument(False)
            report.PrintingSystem.Document.AutoFitToPagesWidth = 1

            Dim FinalReport As New XtraReport
            FinalReport.CreateDocument(False)
            FinalReport.Pages.AddRange(SumReport.Pages)
            FinalReport.Pages.AddRange(report.Pages)

            FinalReport.PrintingSystem.Document.AutoFitToPagesWidth = 1
            FinalReport.ExportOptions.Pdf.ImageQuality = 50
            FinalReport.ExportOptions.Pdf.ConvertImagesToJpeg = False

            Dim tempFileName As String = Path.GetTempFileName
            Dim ExpOPT As New PdfExportOptions
            ExpOPT.ConvertImagesToJpeg = False
            ExpOPT.ImageQuality = PdfJpegImageQuality.Medium
            ExpOPT.NeverEmbeddedFonts = True

            FinalReport.ExportToPdf(tempFileName, ExpOPT)

            Dim bufferSize = 10000
            Dim buffer As Byte() = New [Byte](bufferSize) {}

            Using fileStream As New FileStream(tempFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim dataToRead = fileStream.Length

                Response.Clear()
                Response.ContentType = "application/octet-stream"
                Response.AddHeader("Content-Disposition", String.Format("attachment;filename=""{0}_{1}_{2}.pdf""", StartDate, EndDate, Project))
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

            Response.Close()
        End If

        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", "window.close();", True)

    End Sub

    Public Function AddCompanyLogoInHeader() As XRPictureBox

        Dim xrPicBox As New XRPictureBox

        Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("~/img/Xpand_it_logo.png"))

        With xrPicBox
            .Image = objReport.byteArrayToImage(objReport.imageToByteArray(img))
            .Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
            .HeightF = 60
            .WidthF = 220
            .Location = New System.Drawing.Point(0, 0)
        End With
        Return xrPicBox

    End Function

    Public Function GetTotalHoursForHeader(ByVal dataTable As DataTable) As Decimal
        Dim listOfHours As New List(Of Decimal)

        For Each item As DataRow In dataTable.Rows
            listOfHours.Add(item.Item("TotalHours"))
        Next

        Return listOfHours.Sum()
    End Function

    Public Function GetTotalDaysForHeader(ByVal dataTable As DataTable) As String
        Dim ListOfDays As New List(Of Decimal)

        For Each item As DataRow In dataTable.Rows
            ListOfDays.Add(item.Item("TotalDays"))
        Next

        Dim sumPerEmployee As Integer

        For index = 0 To ListOfDays.Count - 1
            sumPerEmployee += ListOfDays(index)
        Next

        Return sumPerEmployee.ToString()
    End Function

    Public Function SummaryDataSource(ByVal DataTable As DataTable) As DataTable

        Dim SumDatasSource As New DataTable
        SumDatasSource.Columns.Add("EmployeeName")
        SumDatasSource.Columns.Add("TotalHours")
        SumDatasSource.Columns.Add("TotalDays")

        Dim Employees As New List(Of String)
        Dim ListOfCalculatedHours As New List(Of String)
        Dim ListOfCalculatedDays As New List(Of String)

        For Each item As DataRow In DataTable.Rows
            If Not Employees.Contains(item.Item("EmployeeName").ToString()) Then
                Employees.Add(item.Item("EmployeeName"))
            End If
        Next

        For index = 0 To Employees.Count - 1
            Dim sumPerEmployee As Decimal

            For Each item As DataRow In DataTable.Rows
                If Employees(index) = item.Item("EmployeeName").ToString() Then
                    sumPerEmployee += item.Item("TotalHours")
                End If
            Next


            Dim Time = TimeSpan.FromHours(sumPerEmployee)


            ListOfCalculatedHours.Add(String.Format("{0:00}:{1:00}", Time.TotalHours.ToString(New System.Globalization.CultureInfo("en-GB")).Split("."c)(0), Time.Minutes))
            ListOfCalculatedDays.Add(String.Format(New System.Globalization.CultureInfo("en-GB"), "{0:0.00}", Math.Round(sumPerEmployee / 8, 2)))
            sumPerEmployee = 0
        Next

        If Employees.Count = ListOfCalculatedDays.Count Then
            For index = 0 To Employees.Count - 1
                SumDatasSource.Rows.Add(Employees(index), ListOfCalculatedHours(index), ListOfCalculatedDays(index))
            Next
        End If

        Return SumDatasSource

    End Function

    Private Function FormatTheString(ByVal StringToFormat As String) As String

        Dim ArrayOfString() As String = StringToFormat.Split(" ").ToArray

        Dim NewString As String = ""

        For index = 0 To ArrayOfString.Count - 1
            Dim Formatter As String = ""

            If ArrayOfString(index).Length > 1 Then
                For index2 = 0 To ArrayOfString(index).Length - 1
                    If index2 = 0 Then
                        Formatter += ArrayOfString(index)(index2).ToString().ToUpper()
                    Else
                        Formatter += ArrayOfString(index)(index2).ToString().ToLower()
                    End If
                Next
            Else
                Formatter += ArrayOfString(index)(0).ToString()
            End If

            NewString += Formatter + " "

        Next

        Return NewString.TrimEnd

    End Function
End Class
