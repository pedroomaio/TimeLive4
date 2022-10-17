
Partial Class Employee_Controls_ctlAccountEmployeeTimeEntryWeekViewDescriptionReadOnly
    Inherits System.Web.UI.UserControl
    Dim dtStartDate As DateTime = #11/1/2006#
    Dim dtEndDate As DateTime = #11/7/2006#
    Dim dtAccountEmployeeId As Integer
    Dim EmployeeName As String
    Dim dtTimesheetPeriodType As String
    Dim WorkingDays As ArrayList
    Dim WorkingDaysCount As Integer
    Public Sub ShowDate(ByVal AccountEmployeeId As Integer, ByVal dtDate As Date, ByVal TimesheetPeriodType As String)
        dtStartDate = dtStartDate
        dtEndDate = dtEndDate
        dtAccountEmployeeId = AccountEmployeeId
        dtTimesheetPeriodType = TimesheetPeriodType

        Me.ViewState.Add("dtStartDate", dtStartDate)
        Me.ViewState.Add("dtEndDate", dtEndDate)
        Me.ViewState.Add("AccountEmployeeId", dtAccountEmployeeId)
        Me.ViewState.Add("TimesheetPeriodType", dtTimesheetPeriodType)

        Me.dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnly.SelectParameters("AccountEmployeeId").DefaultValue = dtAccountEmployeeId
        Me.dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnly.SelectParameters("TimeEntryStartDate").DefaultValue = dtStartDate
        Me.dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnly.SelectParameters("TimeEntryEndDate").DefaultValue = dtEndDate
        Me.dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnlyForRelevantProject.SelectParameters("AccountEmployeeId").DefaultValue = dtAccountEmployeeId
        Me.dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnlyForRelevantProject.SelectParameters("TimeEntryStartDate").DefaultValue = dtStartDate
        Me.dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnlyForRelevantProject.SelectParameters("TimeEntryEndDate").DefaultValue = dtEndDate

    End Sub
    Public Sub SetGridViewDataSource(ByVal chkShowAllValue As Boolean)
        Me.GridView1.DataSourceID = ""
        Dim AccountEmployeeId As Integer = Me.ViewState("AccountEmployeeId")
        Dim dtDate As Date = Me.ViewState("dtStartDate")
        Dim TimesheetPeriodType As String = Me.ViewState("TimesheetPeriodType")
        If chkShowAllValue <> True Then
            Me.ShowDate(AccountEmployeeId, dtDate, TimesheetPeriodType)
            Me.GridView1.DataSourceID = "dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnlyForRelevantProject"
        Else
            Me.ShowDate(AccountEmployeeId, dtDate, TimesheetPeriodType)
            Me.GridView1.DataSourceID = "dsAccountEmployeeTimeEntryApprovalWeekViewDescriptionReadOnly"
        End If
        Me.GridView1.DataBind()
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.Show()
        Me.SetESignUrl()
    End Sub
    Public Sub Show()
        Dim dtDate As Date
        dtStartDate = dtStartDate.Date
        dtEndDate = dtEndDate.Date
        If Not Request.QueryString("StartDate") Is Nothing And Not Request.QueryString("TimesheetPeriodType") Is Nothing Then
            dtDate = LocaleUtilitiesBLL.ConvertBaseDateStringToDate(Me.Request.QueryString("StartDate"))
            WorkingDays = DateTimeUtilities.GetWorkingDays(DBUtilities.GetSessionAccountEmployeeId, dtDate, dtStartDate, dtEndDate)
            WorkingDaysCount = WorkingDays.Count
            dtTimesheetPeriodType = Me.Request.QueryString("TimesheetPeriodType")
            Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployeeBLL().GetViewAccountEmployeesByAccountEmployeeId(Me.Request.QueryString("AccountEmployeeId"))
            Dim drEmployee As AccountEmployee.vueAccountEmployeeRow
            If dtEmployee.Rows.Count > 0 Then
                drEmployee = dtEmployee.Rows(0)
                dtStartDate = DateTimeUtilities.GetPeriodStartDateByTimesheetPeriodType(dtDate, dtTimesheetPeriodType, drEmployee.EmployeeWeekStartDay, drEmployee.SystemInitialDayOfFirstPeriod, drEmployee.SystemInitialDayOfLastPeriod, drEmployee.InitialDayOfTheMonth)
                dtEndDate = DateTimeUtilities.GetPeriodEndDateByTimesheetPeriodType(dtDate, dtTimesheetPeriodType, drEmployee.EmployeeWeekStartDay, drEmployee.SystemInitialDayOfFirstPeriod, drEmployee.SystemInitialDayOfLastPeriod, drEmployee.InitialDayOfTheMonth)
            End If
        End If
        Me.lblTimesheetPrintFooter.Text = DBUtilities.GetTimesheetPrintFooter
        Me.lblSignedBy.Text = GetEmployeeName()
        Me.lblTimestamp.Text = Now
    End Sub
    Public Sub SetESignUrl()
        If LocaleUtilitiesBLL.IsShowElectronicSign = True And LocaleUtilitiesBLL.IsElectronicSignExistInSessionAccount = True Then
            imgElectronicSignature.ImageUrl = "~/Uploads/" & DBUtilities.GetSessionAccountId & "/" & DBUtilities.GetSessionAccountEmployeeId & "/Sign/E-Sign.gif"
        Else
            imgElectronicSignature.Visible = False
            'imgCompanyLogo.ImageUrl = "~/Images/TopHeader.jpg"
        End If
    End Sub
    Public Function GetEmployeeName() As String
        dtAccountEmployeeId = IIf(Me.Request.QueryString("AccountEmployeeId") Is Nothing, 0, Me.Request.QueryString("AccountEmployeeId"))
        Dim BLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = BLL.GetAccountEmployeesByAccountEmployeeId(dtAccountEmployeeId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow
        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            If DBUtilities.GetShowEmployeeNameBy = 1 Then
                EmployeeName = drEmployee.FirstName & " " & drEmployee.LastName
            Else
                EmployeeName = drEmployee.LastName & " " & drEmployee.FirstName
            End If

            Return EmployeeName
        Else
            Return ""
        End If
    End Function
    Dim HArray1() As String
    Dim Hours1 As Decimal = 0
    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If DBUtilities.IsTimeEntryHoursFormat <> "Decimal" Then
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
            Else
                Dim TotalMinute As String = DBUtilities.GetDateTimeOfMinutesAsString(DataBinder.Eval(e.Row.DataItem, "TotalMinutes"))
                HArray1 = Split(TotalMinute, ":")
                Hours1 = LocaleUtilitiesBLL.ConvertTimeIntoHoursDecimalFormat(HArray1(0), HArray1(1))
                CType(e.Row.Cells(3).FindControl("lblTotalTime"), Label).Text = Hours1
            End If
        End If
    End Sub
End Class
