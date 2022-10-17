
Partial Class Employee_Controls_ctlAbsenceMap
    Inherits System.Web.UI.UserControl

    Dim AccountId As Integer = 354
    Dim Holidays As Dictionary(Of Guid, AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable) = New Dictionary(Of Guid, AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable)
    Dim headerRow As TableHeaderRow = New TableHeaderRow
    Dim headerRowDate As TableHeaderRow = New TableHeaderRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim AnySelected As Boolean = False
        Dim item As ListItem
        For Each item In CType(Me.FindControl("ddlEmployeesDepertment"), ListBox).Items
            If item.Selected = True Then
                AnySelected = True
                Exit Sub
            End If
        Next

        If hdfield.Value IsNot "" Then
            Dim strScript As String = "LoadValues();"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "RightBt", strScript, True)
        End If

    End Sub
    Protected Sub SelectAll_Click(sender As Object, e As EventArgs)
        Dim item As ListItem
        For Each item In CType(Me.FindControl("ddlEmployeesDepertment"), ListBox).Items
            item.Selected = True
        Next
    End Sub
    Protected Sub UnselectAll_Click(sender As Object, e As EventArgs)
        Dim item As ListItem
        For Each item In CType(Me.FindControl("ddlEmployeesDepertment"), ListBox).Items
            item.Selected = False
        Next
    End Sub

    Protected Sub btnShow_Click(sender As Object, e As EventArgs)
        Dim selectedUsers = CType(Me.FindControl("hdfield"), HiddenField).Value

        Dim StartDate = CType(Me.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue.Value
        Dim EndDate = CType(Me.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue.Value

        If selectedUsers Is String.Empty Then
            ShowAlert("You have to select at least one employee")
            Exit Sub
        End If

        If EndDate < StartDate Then
            ShowAlert("The end date must be greater than start date")
            CType(Me.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue = StartDate
            Exit Sub
        End If

        CreateTable()
        RegisterJquerAnchor()
    End Sub

    Private Sub CreateTable()
        CreateTableHeadersDate()
        CreateTableHeaders()
        AbsenceMapTable.Rows.Add(headerRowDate)
        AbsenceMapTable.Rows.Add(headerRow)
        CreateTableRows()
    End Sub

    Private Sub CreateTableHeaders()
        Dim headerCell = CreateTableCell("Employees\Days")
        headerCell.CssClass = "MovingTds"
        headerCell.BackColor = Color.AliceBlue
        headerRow.CssClass = "TableHeader"
        headerRow.Controls.Add(headerCell)
        CreateDaysHeader(headerRow)
    End Sub
    Private Sub CreateTableHeadersDate()

        Dim StartDateC As DateTime = CType(Me.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue.Value
        Dim EndDateC As DateTime = CType(Me.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue.Value
        Dim IncrementDate As DateTime = StartDateC
        Dim listOfDate As New List(Of DateTime)

        While IncrementDate <= EndDateC
            listOfDate.Add(IncrementDate)
            IncrementDate = IncrementDate.AddDays(1)
        End While

        Dim IListOfMonths = From listofdays In listOfDate
                            Group listofdays By MonthsKey = listofdays.Month Into Group
                            Select Month = MonthsKey, MonthName = MonthName(MonthsKey, False), DaysCount = listOfDate.Where(Function(x) x.Month = MonthsKey).Count

        CreateDaysHeaderDate(headerRowDate, "", 1, False)

        Dim itemCount = 0
        For Each item In IListOfMonths.ToList()

            Dim maxC As Integer = 3

            If item.Month = 3 Or item.Month = 4 Or item.Month = 5 Or item.Month = 6 Or item.Month = 7 Then
                maxC = 2
            End If

            Dim tc = CreateDaysHeaderDate(headerRowDate, item.MonthName, item.DaysCount, True, maxC)

            If itemCount = 0 Then
                tc.Style.Add("border-left", "black")
                tc.Style.Add("border-left-style", "solid")
                tc.Style.Add("border-left-width", "thin")
            End If

            If itemCount = 0 And item.DaysCount < maxC Then
                tc.Style.Add("border", "transparent")
                tc.Style.Add("border-left-style", "solid")
                tc.Style.Add("border-left-width", "thin")
                tc.Text = ""
            End If

            itemCount = itemCount + 1
        Next

    End Sub

    Private Function CreateDaysHeaderDate(ByRef headerRow As TableRow, ByVal monthName As String, ByVal daysCount As Integer, ByVal Optional hasBorder As Boolean = True, ByVal Optional maxColumns As Integer = 3) As TableCell
        Dim tc = CreateTableCell(IIf(daysCount >= maxColumns, StrConv(monthName, VbStrConv.ProperCase), ""), True)
        tc.Width = 15
        tc.ColumnSpan = daysCount
        If hasBorder Then
            tc.BorderStyle = BorderStyle.Solid
            tc.BorderColor = Color.Black
        Else
            tc.BorderStyle = BorderStyle.None
            tc.BorderColor = Color.Transparent
        End If
        tc.Wrap = False
        tc.HorizontalAlign = HorizontalAlign.Center
        headerRow.Controls.Add(tc)
        Return tc
    End Function

    Private Sub CreateDaysHeader(ByRef headerRow As TableRow)

        Dim StartDate = CType(Me.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue.Value
        Dim EndDate = CType(Me.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue.Value

        While (StartDate <= EndDate)

            Dim tc = CreateTableCell(StartDate.Day.ToString().PadLeft(2, "0"))
            tc.Width = 15
            tc.Wrap = False
            tc.HorizontalAlign = HorizontalAlign.Center

            If StartDate.Day = 1 Then
                tc.CssClass = "border-left"
            End If

            Dim textTooltip As String
            textTooltip = StartDate

            tc.ToolTip = textTooltip

            headerRow.Controls.Add(tc)
            StartDate = StartDate.AddDays(1)

        End While
    End Sub

    Private Sub CreateTableRows()
        Dim selectUsers() = CType(Me.FindControl("hdfield"), HiddenField).Value.Split(New Char() {";"c})

        For Each user In selectUsers
            Dim Splited() = user.Split(New Char() {","c})


            Dim tableRow As New TableRow()
            Dim tableCell = CreateTableCell(Splited(0))
            tableCell.CssClass = "MovingTds"
            tableRow.Controls.Add(tableCell)
            CreateDaysGrid(tableRow, Splited(1), Splited(0))
            AbsenceMapTable.Controls.Add(tableRow)

        Next

    End Sub


    Private Sub CreateDaysGrid(ByRef tableRow As TableRow, ByVal AccountEmployeeId As Integer, ByVal AccountEmployeeName As String)
        Dim TimeOffRequestBLL As New AccountEmployeeTimeOffRequestBLL

        Dim StartDate = CType(Me.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue.Value
        Dim EndDate = CType(Me.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue.Value

        Dim TimeOffRequest = TimeOffRequestBLL.VerifyTimeOffRequestPeriodOverlaping(AccountId, AccountEmployeeId, StartDate, EndDate)
        Dim dtHolidays = Me.GetHolidays(AccountEmployeeId)

        While (StartDate <= EndDate)
            Dim tableCell As New TableCell
            Dim ScheduleWeekends As Boolean = False

            If TimeOffRequest.Count > 0 Then
                Dim tt As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestRow
                For Each tt In TimeOffRequest.Rows
                    If tt.AccountEmployeeId <> 0 Then
                        If StartDate >= tt.StartDate And StartDate <= tt.EndDate Then
                            tableCell.BackColor = UIUtilities.ConvertFromHexToColor(tt.Color)
                            ScheduleWeekends = tt.ScheduleWeekends
                            Exit For
                        End If
                    End If
                Next
            End If
            If (StartDate.DayOfWeek = DayOfWeek.Sunday Or StartDate.DayOfWeek = DayOfWeek.Saturday) And ScheduleWeekends = False Then
                tableCell.BackColor = Color.Gray
            End If

            If VerifyHoliday(StartDate, dtHolidays) = True And ScheduleWeekends = False Then
                tableCell.BackColor = Color.LightGray
            End If

            tableCell.CssClass = "TableHeader"

            tableCell.ToolTip = AccountEmployeeName + Environment.NewLine + StartDate
            If StartDate.Day = 1 Then
                tableCell.CssClass = "border-left TableHeader"
            End If
            tableRow.Controls.Add(tableCell)
            StartDate = StartDate.AddDays(1)
        End While
    End Sub


    Private Function GetHolidays(AccountEmployeeId As Integer) As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable
        Dim AccountHolidayId = GetHolidayTypeId(AccountEmployeeId)
        Dim dtHolidays As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable
        If AccountHolidayId <> Guid.Empty Then

            If Holidays.ContainsKey(AccountHolidayId) Then
                dtHolidays = Holidays.Item(AccountHolidayId)
            Else
                dtHolidays = New AccountHolidayTypeBLL().GetvueAccountEmployeeHolidayTypesWithDetailByAccountEmployeeId(AccountEmployeeId)
                Holidays.Add(AccountHolidayId, dtHolidays)
            End If
            Return dtHolidays
        End If
        Return dtHolidays
    End Function

    Private Function VerifyHoliday(dt As DateTime, dtHolidays As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable) As Boolean
        If dtHolidays IsNot Nothing Then
            For Each Holiday In dtHolidays
                If Holiday.HolidayDate = dt Then
                    Return True
                    Exit Function
                End If
            Next
        End If
        Return False
    End Function

    Private Function GetHolidayTypeId(ByVal AccountEmployeeId As Integer) As Guid
        Dim AccountEmployee = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
        Dim HolidayId As Guid
        If AccountEmployee.Count > 0 Then
            Try
                HolidayId = AccountEmployee.Item(0).AccountHolidayTypeId
            Catch ex As Exception
                HolidayId = Guid.Empty
            End Try
        End If
        Return HolidayId
    End Function

    'Utils possivelmente criar class para estas Utils
    Private Function CreateTableCell(ByVal text As String, ByVal Optional makeBold As Boolean = False) As TableCell
        Dim headerCell As TableCell = New TableCell

        Dim literalControl As New Label()
        literalControl.Text = text
        If makeBold Then
            literalControl.Font.Bold = True
            literalControl.Font.Size = 13.0F
        End If
        headerCell.Controls.Add(literalControl)
        Return headerCell
    End Function
    Private Sub ShowAlert(strMessage As String)
        Dim strScript As String = "alert('" & strMessage & "');"
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub

    Private Sub RegisterJquerAnchor()
        Dim strScript As String = "anchorToTable();"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "AnchorJq", strScript, True)
    End Sub
End Class
