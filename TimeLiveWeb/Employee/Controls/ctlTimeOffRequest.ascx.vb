
Partial Class Employee_Controls_ctlTimeOffRequest
    Inherits System.Web.UI.UserControl
    Dim AvailableTimeOffBalance As Double = 0
    Dim HoursOff As Double
    Dim TimeOffTypeId As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Me.Request.QueryString("AccountEmployeeTimeOffRequestId") Is Nothing Then
        'FormView1.ChangeMode(FormViewMode.Insert)
        'Else
        'FormView1.ChangeMode(FormViewMode.Edit)
        '   Me.dsEmployeeTimeOffRequestFormViewObject.SelectParameters("AccountEmployeeTimeOffRequestId").DefaultValue = Me.Request.QueryString("AccountEmployeeTimeOffRequestId").ToString
        'End If

        Me.FormView1.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(143, 3)
        Me.IsConsumptionAvailable()
        'If Me.FormView1.CurrentMode = FormViewMode.Insert Then

        CType(Me.FormView1.FindControl("lblErrorMessage"), Label).ForeColor = Color.Red
        CType(Me.FormView1.FindControl("lblErrorMessage"), Label).Text = " "

        CType(Me.FormView1.FindControl("lblAvailableTimeOff"), Label).Text = String.Format("{0} hours ({1} days)", AvailableTimeOffBalance, AvailableTimeOffBalance / DBUtilities.GetHoursPerDay)
        If AvailableTimeOffBalance <= 0 Then
            CType(Me.FormView1.FindControl("lblAvailableTimeOff"), Label).ForeColor = Color.Red
        Else
            CType(Me.FormView1.FindControl("lblAvailableTimeOff"), Label).ForeColor = Color.Black
        End If
        CType(Me.FormView1.FindControl("btnAdd"), Button).Enabled = AvailableTimeOffBalance > 0
        'End If


        'FormView1.FindControl("lblchkPreference").Visible = False
    End Sub
    Public Sub Calculation(Optional ByVal IsFromDaysOff As Boolean = False, Optional ByVal IsFromHoursOff As Boolean = False)
        If Not IsValidAllTextBoxValue() Then
            Return
        End If
        If CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate < CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate Then
            CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        End If

        'Dim dt As TimeLiveDataSet.vueAccountEmployeeWorkingDaysDataTable = New AccountWorkingDayBLL().GetWorkingDaysByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
        Dim dtHoliday As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable = New AccountHolidayTypeBLL().GetvueAccountEmployeeHolidayTypesWithDetailByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
        Dim startdate As Date = CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        Dim daysoff As Double = DateDiff(DateInterval.Day, CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate.AddDays(1))
        Dim FromDaysOff As Double
        Dim TotalHours As Double = DBUtilities.GetHoursPerDay
        Dim FDaysOff As Double
        Dim RoundDaysOff As Double
        If IsFromDaysOff Then
            FromDaysOff = CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text
            If FromDaysOff.ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Contains(".") Then
                Dim day As String() = FromDaysOff.ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Split(".")
                If day(1) > 0 Then
                    RoundDaysOff = day(0) + 1
                Else
                    RoundDaysOff = day(0)
                End If
            Else
                RoundDaysOff = CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text
            End If
            Dim EndDate As Date = startdate.AddDays(RoundDaysOff - 1)
            EndDate = GetEndDate(RoundDaysOff, startdate, dtHoliday)
            CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = EndDate
            FDaysOff = CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text
        End If
        If IsFromHoursOff Then
            daysoff = CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text / TotalHours
            If daysoff.ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Contains(".") Then
                Dim day As String() = daysoff.ToString("N", LocaleUtilitiesBLL.GetBaseCultureInfo).Split(".")
                If day(1) > 0 Then
                    RoundDaysOff = day(0) + 1
                Else
                    RoundDaysOff = day(0)
                End If
            Else
                RoundDaysOff = daysoff
            End If
            Dim EndDate As Date = GetEndDate(RoundDaysOff, startdate, dtHoliday)
            CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = EndDate
            FDaysOff = daysoff
        End If
        If Not IsFromHoursOff And Not IsFromDaysOff Then
            Dim TotalDaysOff As Double
            For n As Integer = 0 To daysoff - 1
                If IsCurrentDayAvailableInWorkingDay(startdate, n, dtHoliday) Then
                    TotalDaysOff += 1
                End If
            Next
            FDaysOff = TotalDaysOff
        End If
        CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text = FDaysOff
        If Not IsFromHoursOff Then
            CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text = (FDaysOff * TotalHours).ToString
        End If

        VerifySaveIsPossible(FDaysOff, FDaysOff * TotalHours)

    End Sub

    Public Function HasAvailableHoursToSave(ByVal FDaysOff As Double, ByVal TotalHours As Double) As Boolean


        If FDaysOff = 0 Or TotalHours = 0 Or TotalHours > AvailableTimeOffBalance Or (FDaysOff * DBUtilities.GetHoursPerDay) > AvailableTimeOffBalance Then
            Return False
        Else
            Return True

        End If
    End Function
    Public Function VerifySaveIsPossible(ByVal FDaysOff As Double, ByVal HoursOff As Double)

        If VerifyOverlapingPeriod() Then
            DisableButtonWithErrorMessage("* You cannot overlap timeoff periods")
            Return 1
        End If

        If HasAvailableHoursToSave(FDaysOff, HoursOff) Then
            If CType(Me.FormView1.FindControl("ActionType"), HiddenField).Value = "Update" Then
                CType(Me.FormView1.FindControl("btnAdd"), Button).Enabled = True
            End If
        Else
            DisableButtonWithErrorMessage("* You don’t have enough assigned credits")
        End If

    End Function

    Public Function DisableButtonWithErrorMessage(ByVal ErrorMsg As String)
        CType(Me.FormView1.FindControl("lblErrorMessage"), Label).Text = ErrorMsg
        CType(Me.FormView1.FindControl("btnAdd"), Button).Enabled = False
    End Function
    Public Function GetEndDate(ByVal Daysoff As Double, ByVal StartDate As Date, ByVal dtHoliday As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable)
        Dim TotalDaysOff As Double = 0
        Dim TempDaysOff As Double = 0
        Do Until TotalDaysOff = Daysoff
            If IsCurrentDayAvailableInWorkingDay(StartDate, TempDaysOff, dtHoliday) = True Then
                TotalDaysOff += 1
            End If
            If Not TotalDaysOff = Daysoff Then
                TempDaysOff += 1
            End If
        Loop
        Return StartDate.AddDays(TempDaysOff)
    End Function

    Public Function VerifyOverlapingPeriod() As Boolean

        Dim accountEmployeeTimeOffRequest = New AccountEmployeeTimeOffRequestBLL()
        Dim timeOffRequestOverlaping = accountEmployeeTimeOffRequest.VerifyTimeOffRequestPeriodOverlaping(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate)

        If (timeOffRequestOverlaping.Count > 0) Then
            If timeOffRequestOverlaping(0).ApprovalStatus <> "Rejected" And timeOffRequestOverlaping(0).ApprovalStatus <> "Saved" Then
                Return True
            End If

        End If

        Return False

    End Function
    Public Function IsCurrentDayAvailableInWorkingDay(ByVal StartDate As Date, ByVal AddDaysNo As Integer, ByVal dtHoliday As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable) As Boolean

        'If to avoid exception when employee Time Off policy is "None"
        If CType(Me.FormView1.FindControl("ddlTimeOffTypeId"), DropDownList).SelectedItem IsNot Nothing Then

            Dim selectedTimeOffTypeId = CType(Me.FormView1.FindControl("ddlTimeOffTypeId"), DropDownList).SelectedItem.Value
            Dim accountTimeOffTypeBLL = New AccountTimeOffTypeBLL()
            Dim accountTimeOffType = accountTimeOffTypeBLL.GetAccountTimeOffTypesByAccountTimeOffTypeId(Guid.Parse(selectedTimeOffTypeId))
            Dim scheduleWeekend = accountTimeOffType(0).ScheduleWeekends

            Dim NewDate As Date = StartDate.AddDays(AddDaysNo)
            'Dim dr As TimeLiveDataSet.vueAccountEmployeeWorkingDaysRow
            Dim Holidaydr() As DataRow = dtHoliday.Select("HolidayDate = '" & NewDate.Date & "'")

            If Holidaydr.Length > 0 And (scheduleWeekend = False) Then
                Return False
            ElseIf Holidaydr.Length > 0 And (scheduleWeekend = True) Then
                Return True
            End If

            If (Weekday(NewDate) = 7 Or Weekday(NewDate) = 1) And scheduleWeekend = False Then
                Return False
            End If

            Return True


        End If

    End Function

    Protected Sub StartDateTextBox_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Calculation()
    End Sub

    Protected Sub EndDateTextBox_DateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Calculation()
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        If FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text = 0
            CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text = 0
            Calculation()
        ElseIf FormView1.CurrentMode = FormViewMode.Edit Then

            If Not IsDBNull(Me.FormView1.DataItem("AccountTimeOffTypeId")) Then
                Me.dsTimeOffTypesObject.SelectParameters("AccountTimeOffTypeId").DefaultValue = Me.FormView1.DataItem("AccountTimeOffTypeId").ToString
                CType(Me.FormView1.FindControl("ddlTimeOffTypeId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountTimeOffTypeId").ToString
            End If

        End If
    End Sub

    Protected Sub Ok_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.FindControl("DivRequest").Visible = True
        Me.FormView1.FindControl("SaveIsOk").Visible = False
        Response.Redirect("~/Employee/MyTimeOff.aspx")
    End Sub

    Protected Sub Back_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.FindControl("DivRequest").Visible = True
        Me.FormView1.FindControl("SaveIsNotOk").Visible = False
        CType(Me.FormView1.FindControl("btnAdd"), Button).Enabled = True
    End Sub


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)


        Dim accountEmployeeTimeOffRequest = New AccountEmployeeTimeOffRequestBLL()
        Dim TimeOffType = New Guid(CType(Me.FormView1.FindControl("ddlTimeOffTypeId"), DropDownList).SelectedValue)
        Dim HoursOff = CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text
        Dim StartDate = CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        Dim EndDate = CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        Dim Description = CType(Me.FormView1.FindControl("DescriptionTextBox"), TextBox).Text
        Dim DaysOff = CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text
        Dim Project = CType(Me.FormView1.FindControl("ddlProjectName"), DropDownList).SelectedValue

        If HasAvailableHoursToSave(DaysOff, HoursOff) Then
            If (CType(Me.FormView1.FindControl("ActionType"), HiddenField).Value = "Update") Then
                Dim timeOffRequestId = New Guid(CType(Me.FormView1.FindControl("AccountEmployeeTimeOffRequestId"), HiddenField).Value)
                Dim New_TimeOffRequestId = accountEmployeeTimeOffRequest.UpdateAccountEmployeeTimeOffRequest(DBUtilities.GetSessionAccountId,
                                                                                      DBUtilities.GetSessionAccountEmployeeId,
                                                                                      TimeOffType,
                                                                                      HoursOff,
                                                                                      StartDate,
                                                                                      EndDate,
                                                                                      Description,
                                                                                      DaysOff,
                                                                                      timeOffRequestId,
                                                                                      Project)
                Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, New_TimeOffRequestId, True)

            Else
                Dim New_TimeOffRequestId = accountEmployeeTimeOffRequest.AddAccountEmployeeTimeOffRequest(DBUtilities.GetSessionAccountId,
                                                                               DBUtilities.GetSessionAccountEmployeeId,
                                                                               TimeOffType,
                                                                               HoursOff,
                                                                               StartDate,
                                                                               EndDate,
                                                                               Description,
                                                                               DaysOff,
                                                                               Project)

            End If

            Me.FormView1.FindControl("DivRequest").Visible = False
            Me.FormView1.FindControl("SaveIsOk").Visible = True
        Else

            Me.FormView1.FindControl("DivRequest").Visible = False
            Me.FormView1.FindControl("SaveIsNotOk").Visible = True

        End If
    End Sub

    Protected Sub dsTimeOffTypesObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsTimeOffTypesObject.Inserted
    End Sub
    Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        Response.Redirect("~/Employee/MyTimeOff.aspx", False)
    End Sub
    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        Response.Redirect("~/Employee/MyTimeOff.aspx", False)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/Employee/MyTimeOff.aspx", False)
    End Sub


    Protected Sub DaysOffTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AmountValue As Single
        If Not Single.TryParse(CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text, AmountValue) Then
            CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text = AmountValue
        End If
        Calculation(True)

    End Sub

    Protected Sub HoursOffTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AmountValue As Single
        If Not Single.TryParse(CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text, AmountValue) Then
            CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text = AmountValue
        End If
        Calculation(False, True)
    End Sub

    Protected Sub DaysOffTextBox_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AmountValue As Single
        If Not Single.TryParse(CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text, AmountValue) Then
            CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text = AmountValue
        End If
        Calculation(True)
    End Sub

    Protected Sub HoursOffTextBox_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AmountValue As Single
        If Not Single.TryParse(CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text, AmountValue) Then
            CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text = AmountValue
        End If
        Calculation(False, True)
    End Sub

    Public Function IsValidAllTextBoxValue()
        Dim AmountValue As Single
        If Not Single.TryParse(CType(Me.FormView1.FindControl("DaysOffTextBox"), TextBox).Text, AmountValue) Then
            Return False
        End If
        If Not Single.TryParse(CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text, AmountValue) Then
            Return False
        End If
        Return True
    End Function
    Public Function IsConsumptionAvailable()
        If CType(Me.FormView1.FindControl("ddlTimeOffTypeId"), DropDownList).SelectedValue <> "" Then
            Dim TimeOffRequestBLL As New AccountEmployeeTimeOffRequestBLL
            Dim TimeOffTypeId As New Guid(CType(Me.FormView1.FindControl("ddlTimeOffTypeId"), DropDownList).SelectedValue)
            Dim dt As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestDataTable = TimeOffRequestBLL.GetAccountEmployeeTimeOffByEmployeeIdAndTimeOffTypeId(DBUtilities.GetSessionAccountEmployeeId, TimeOffTypeId)
            Dim dr As AccountEmployeeTimeOffRequest.vueAccountEmployeeTimeOffRequestRow
            Dim SubmittedHours As Double
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)

                If Not IsDBNull(dr.Item("Available")) Then
                    For Each dr In dt.Rows
                        If dr.ApprovalStatus = "Submitted" Or dr.ApprovalStatus = "Saved" Then
                            If (CType(Me.FormView1.FindControl("ActionType"), HiddenField).Value = "Update") Then
                                Dim timeOffRequestId = New Guid(CType(Me.FormView1.FindControl("AccountEmployeeTimeOffRequestId"), HiddenField).Value)
                                If dr.AccountEmployeeTimeOffRequestId <> timeOffRequestId Then
                                    SubmittedHours = SubmittedHours + dr.HoursOff
                                End If
                            Else
                                SubmittedHours = SubmittedHours + dr.HoursOff
                            End If
                        End If
                    Next
                    AvailableTimeOffBalance = dr.Available - SubmittedHours
                End If
                HoursOff = CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text
                If AvailableTimeOffBalance >= HoursOff Then
                    Return True
                Else
                    Return False
                End If
            Else
                Dim TimeOffBLL As New AccountEmployeeTimeOffBLL
                Dim dtTOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = TimeOffBLL.GetAccountEmployeeTimeOffByEmployeeIdAndTimeOffTypeId(DBUtilities.GetSessionAccountEmployeeId, TimeOffTypeId)
                Dim drTOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow

                If dtTOff.Rows.Count > 0 Then
                    drTOff = dtTOff.Rows(0)
                    If drTOff.Available > 0 Then
                        If Not IsDBNull(drTOff.Item("Available")) Then
                            AvailableTimeOffBalance = drTOff.Available
                        Else
                            AvailableTimeOffBalance = 0
                        End If
                        If CType(Me.FormView1.FindControl("HoursOffTextBox"), TextBox).Text <= AvailableTimeOffBalance Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                End If
            End If
            Return False
        End If
    End Function
    Public Function ApprovalTypeValidationCheck()
        Dim IsValid As String
        Dim AccountEmployeeBLL As New AccountEmployeeBLL
        Dim ApprovalBLL As New AccountApprovalBLL
        Dim dt As AccountEmployee.AccountEmployeeDataTable = AccountEmployeeBLL.GetAccountEmployeesByAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
        Dim dr As AccountEmployee.AccountEmployeeRow
        Dim Id As Integer
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("TimeOffApprovalTypeId")) Then
                Id = dr.TimeOffApprovalTypeId
            End If
            Dim dtApproval As TimeLiveDataSet.AccountApprovalPathDataTable = ApprovalBLL.GetAccountApprovalPathsByAccountApprovalTypeId(Id)
            Dim drApproval As TimeLiveDataSet.AccountApprovalPathRow
            If dtApproval.Rows.Count > 0 Then
                drApproval = dtApproval.Rows(0)
                'For Each drApproval In dtApproval.Rows
                If drApproval.SystemApproverTypeId = 1 Or drApproval.SystemApproverTypeId = 2 Then
                    Return True


                End If
                'Next

            End If
        Else
            Return False
        End If
    End Function

    Protected Sub ddlTimeOffTypeId_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Calculation()

    End Sub

    Public Sub ShowNotFoundMessage(ByVal strMessage As String)
        Dim strScript As String = "alert('" & strMessage & "');"
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    Protected Sub ddlProjectName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Calculation()
    End Sub
End Class
