
Partial Class Employee_Controls_ctlTimeOffStatus
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'btnResetButton.Attributes.Add("onclick", ResourceHelper.GetResetPolicyMessageJavascript)

        GetEmployeeName()
        If Not Me.IsPostBack Then
            If LocaleUtilitiesBLL.IsTimeOffStatusEditMode = True Then
                TimeOffStatusEditMode()
            Else
                TimeOffStatusReadOnlyMode()
            End If
        End If

        Me.GridView1.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(141, 1)
        'If Me.GridView1.Visible <> False Then
        '    Me.btnUpdate.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(141, 3)
        'Else
        '    Me.btnUpdate.Visible = False

        'End If
        
        If GridView1.Rows.Count > 0 Then
            For Each row As GridViewRow In Me.GridView1.Rows
                If IsDBNull(Me.GridView1.DataKeys(row.RowIndex)(0)) Then
                    btnUpdate.Enabled = False
                    'Me.btnCancel.Visible = False
                    'Me.btnEdit.Visible = False
                    'For exit the sub
                    Exit Sub
                End If
            Next
        Else
            btnEmployeeTimeOffAudit.Visible = False
            'btnResetButton.Visible = False
            btnUpdate.Visible = False
            GridView1.ShowHeaderWhenEmpty = True
            GridView1.EmptyDataText = "There are no items to display."
        End If

    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        UpdateTimeOffStatus()
        'Response.Redirect("~/AccountAdmin/AccountEmployees.aspx", False)
    End Sub
    Public Sub UpdateTimeOffStatus()
        Dim Available As Double
        Dim Earned As Double
        Dim CarryForward As Double
        Dim objTimeOff As New AccountEmployeeTimeOffBLL
        For Each row As GridViewRow In Me.GridView1.Rows
            Dim dtTimeOff As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffDataTable = objTimeOff.GetvueDataByAccountEmployeeTimeOffId((Me.GridView1.DataKeys(row.RowIndex)(0)))
            Dim drTimeOff As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffRow
            If dtTimeOff.Rows.Count > 0 Then
                drTimeOff = dtTimeOff.Rows(0)
                If CType(row.FindControl("AvailableHidden"), HiddenField).Value <> " " And CType(row.FindControl("CarryForwardTextBox"), TextBox).Text <> " " And CType(row.FindControl("EarnedTextBox"), TextBox).Text <> " " Then

                    If Not IsDBNull(drTimeOff.Item("Available")) Then
                        'If CType(row.FindControl("AvailableHidden"), HiddenField).Value <> " " Then
                        If drTimeOff.Available <> CType(row.FindControl("AvailableHidden"), HiddenField).Value Then
                            If LocaleUtilitiesBLL.IsShowTimeOffInDays Then
                                If Not IsDBNull(drTimeOff.Item("HoursPerDay")) Then
                                    Available = drTimeOff.Item("HoursPerDay") * CType(row.FindControl("AvailableHidden"), HiddenField).Value
                                End If
                            Else
                                Available = Int32.Parse(CType(row.FindControl("AvailableHidden"), HiddenField).Value) + Int32.Parse(CType(row.FindControl("TotalConsumed"), HiddenField).Value) - Int32.Parse(CType(row.FindControl("ApprovedHidden"), HiddenField).Value)
                            End If

                            If drTimeOff.Available <> Available Then
                                objTimeOff.UpdateEmployeeTimeOffFields(Me.GridView1.DataKeys(row.RowIndex)(0), IIf(Available = Nothing, 0, Available), "Availabe", DBUtilities.GetEmployeeNameWithCode, "Update Available", "Time Off Status")
                            End If
                        End If
                        'Else
                        'Available = Nothing
                        'If drTimeOff.Available <> Available Then
                        'objTimeOff.UpdateEmployeeTimeOffFields(Me.GridView1.DataKeys(row.RowIndex)(0), IIf(Available = Nothing, 0, Available), "Availabe", DBUtilities.GetEmployeeNameWithCode, "Update Available", "Time Off Status")
                        'End If
                        'End If
                    End If
                    If Not IsDBNull(drTimeOff.Item("CarryForward")) Then
                        'If CType(row.FindControl("CarryForwardTextBox"), TextBox).Text <> " " Then
                        If drTimeOff.CarryForward <> CType(row.FindControl("CarryForwardTextBox"), TextBox).Text Then
                            If LocaleUtilitiesBLL.IsShowTimeOffInDays Then
                                If Not IsDBNull(drTimeOff.Item("HoursPerDay")) Then
                                    CarryForward = drTimeOff.Item("HoursPerDay") * CType(row.FindControl("CarryForwardTextBox"), TextBox).Text
                                End If
                            Else
                                CarryForward = CType(row.FindControl("CarryForwardTextBox"), TextBox).Text
                            End If
                            If drTimeOff.CarryForward <> CarryForward Then
                                objTimeOff.UpdateEmployeeTimeOffFields(Me.GridView1.DataKeys(row.RowIndex)(0), IIf(CarryForward = Nothing, 0, CarryForward), "CarryForward", DBUtilities.GetEmployeeNameWithCode, "Update CarryForward", "Time Off Status")
                            End If
                        End If
                        'Else
                        'CarryForward = Nothing
                        'If drTimeOff.CarryForward <> CarryForward Then
                        'objTimeOff.UpdateEmployeeTimeOffFields(Me.GridView1.DataKeys(row.RowIndex)(0), IIf(CarryForward = Nothing, 0, CarryForward), "CarryForward", DBUtilities.GetEmployeeNameWithCode, "Update CarryForward", "Time Off Status")
                        'End If
                        'End If
                    End If
                    If Not IsDBNull(drTimeOff.Item("Earned")) Then
                        'If CType(row.FindControl("EarnedTextBox"), TextBox).Text <> " " Then
                        If drTimeOff.Earned <> CType(row.FindControl("EarnedTextBox"), TextBox).Text Then
                            If LocaleUtilitiesBLL.IsShowTimeOffInDays Then
                                If Not IsDBNull(drTimeOff.Item("HoursPerDay")) Then
                                    Earned = drTimeOff.Item("HoursPerDay") * CType(row.FindControl("EarnedTextBox"), TextBox).Text
                                End If
                            Else
                                Earned = CType(row.FindControl("EarnedTextBox"), TextBox).Text
                            End If
                            If drTimeOff.Earned <> Earned Then
                                objTimeOff.UpdateEmployeeTimeOffFields(Me.GridView1.DataKeys(row.RowIndex)(0), IIf(Earned = Nothing, 0, Earned), "Earned", DBUtilities.GetEmployeeNameWithCode, "Update Earned", "Time Off Status")
                            End If
                        End If
                        'Else
                        'Earned = Nothing
                        'If drTimeOff.Earned <> Earned Then
                        'objTimeOff.UpdateEmployeeTimeOffFields(Me.GridView1.DataKeys(row.RowIndex)(0), IIf(Earned = Nothing, 0, Earned), "Earned", DBUtilities.GetEmployeeNameWithCode, "Update Earned", "Time Off Status")
                        'End If
                        'End If
                    End If
                    'If LocaleUtilitiesBLL.IsTimeOffStatusEditMode = True Then
                    'If Not IsDBNull(drTimeOff.Item("LastEarnedDate")) Then
                    'If drTimeOff.LastEarnedDate <> CType(row.FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate Then
                    'objTimeOff.UpdateEmployeeTimeOffLastEarnedDate(Me.GridView1.DataKeys(row.RowIndex)(0), CType(row.FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate, DBUtilities.GetEmployeeNameWithCode, "Update LastEarned Date", "Time Off Status")
                    'End If
                    'End If
                    'End If
                    If IsDBNull(drTimeOff.Item("LastEarnedDate")) Then
                        objTimeOff.UpdateEmployeeTimeOffLastEarnedDate(Me.GridView1.DataKeys(row.RowIndex)(0), CType(row.FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate, DBUtilities.GetEmployeeNameWithCode, "Update LastEarned Date", "Time Off Status")
                    Else
                        If drTimeOff.LastEarnedDate <> CType(row.FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate Then
                            objTimeOff.UpdateEmployeeTimeOffLastEarnedDate(Me.GridView1.DataKeys(row.RowIndex)(0), CType(row.FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate, DBUtilities.GetEmployeeNameWithCode, "Update LastEarned Date", "Time Off Status")
                        End If
                    End If

                    If IsDBNull(drTimeOff.Item("LastResetDate")) Then
                        objTimeOff.UpdateEmployeeTimeOffLastResetDate(Me.GridView1.DataKeys(row.RowIndex)(0), CType(row.FindControl("LastResetDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate, DBUtilities.GetEmployeeNameWithCode, "Update LastEarned Date", "Time Off Status")
                    Else
                        If drTimeOff.LastResetDate <> CType(row.FindControl("LastResetDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate Then
                            objTimeOff.UpdateEmployeeTimeOffLastResetDate(Me.GridView1.DataKeys(row.RowIndex)(0), CType(row.FindControl("LastResetDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate, DBUtilities.GetEmployeeNameWithCode, "Update LastReset Date", "Time Off Status")
                        End If
                    End If
                End If
            End If
        Next
    End Sub
    Public Sub GetEmployeeName()
        Dim dt As AccountEmployee.vueAccountEmployeeDataTable = New AccountEmployeeBLL().GetViewAccountEmployeesByAccountEmployeeId(Me.Request.QueryString("AccountEmployeeId"))
        Dim dr As AccountEmployee.vueAccountEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.lblEmployeeName.Text = dr.EmployeeName
        End If
    End Sub
    'Protected Sub btnResetButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Dim objtimeoff As New AccountEmployeeTimeOffBLL
    '    objtimeoff.ExecuteScheduledOffDaysProcedure(Me.Request.QueryString("AccountEmployeeId"), DBUtilities.GetEmployeeNameWithCode, "Reset", "Time Off Status")
    '    Response.Redirect("~/AccountAdmin/AccountEmployees.aspx", False)
    'End Sub
    Protected Sub btnEmployeeTimeOffAudit_Click(sender As Object, e As System.EventArgs)
        Response.Redirect("~/Employee/AccountEmployeeTimeOffAudit.aspx?AccountEmployeeId=" & (Me.Request.QueryString("AccountEmployeeId")), False)
    End Sub
    Public Sub TimeOffStatusReadOnlyMode()
        Dim objRow As GridViewRow
        For Each objRow In Me.GridView1.Rows
            CType(objRow.FindControl("lblLastEarnedDate"), Label).Visible = True
            CType(objRow.FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).Visible = False
            CType(objRow.FindControl("lblEarned"), Label).Visible = True
            CType(objRow.FindControl("EarnedTextBox"), TextBox).Visible = False
            'btnCancel.Visible = False
            'If LocaleUtilitiesBLL.IsTimeOffStatusEditMode = True Then
            CType(objRow.FindControl("lblAvailable"), Label).Visible = True
            CType(objRow.FindControl("AvailableTextBox"), Label).Visible = False
            'btnEdit.Visible = True
            btnUpdate.Visible = False
            'Else
            'CType(objRow.FindControl("lblAvailable"), Label).Visible = False
            'CType(objRow.FindControl("AvailableTextBox"), TextBox).Visible = True
            ''btnEdit.Visible = False
            'btnUpdate.Visible = True
            'End If
        Next
    End Sub
    Public Sub TimeOffStatusEditMode()
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = New AccountEmployeeTimeOffBLL().GetAccountEmployeeTimeOffByAccountEmployeeId(Me.Request.QueryString("AccountEmployeeId"))
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow
        If dtTimeOff.Rows.Count > 0 Then
            drTimeOff = dtTimeOff.Rows(0)
            Dim objRow As GridViewRow
            For Each objRow In Me.GridView1.Rows
                If Not IsDBNull(Me.GridView1.DataKeys(objRow.RowIndex).Item(2)) Then
                    'If LocaleUtilitiesBLL.IsTimeOffStatusEditMode = True Then
                    CType(objRow.FindControl("lblLastEarnedDate"), Label).Visible = False
                    CType(objRow.FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).Visible = True
                    CType(objRow.FindControl("lblEarned"), Label).Visible = False
                    CType(objRow.FindControl("EarnedTextBox"), TextBox).Visible = True

                    CType(objRow.FindControl("CarryForwardTextBox"), TextBox).Visible = True
                    'End If
                    Dim dt As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = New AccountEmployeeTimeOffBLL().GetAccountEmployeeTimeOffByAccountEmployeeIdAndTimeOffTypeId(Me.Request.QueryString("AccountEmployeeId"), Me.GridView1.DataKeys(objRow.RowIndex).Item(1), Me.GridView1.DataKeys(objRow.RowIndex).Item(2))
                    Dim dr As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow
                    If dt.Rows.Count > 0 Then
                        dr = dt.Rows(0)
                        If Not IsDBNull(dr("LastEarnedDate")) Then
                            CType(objRow.FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = dr.LastEarnedDate
                        Else
                            CType(objRow.FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = New DateTime(DateTime.Now.Year, 1, 1)
                        End If
                    End If
                    CType(objRow.FindControl("lblAvailable"), Label).Visible = False
                    CType(objRow.FindControl("AvailableTextBox"), Label).Visible = True
                    btnUpdate.Visible = True
                End If
            Next
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "LastEarnedDate")) Then
                CType(e.Row.Cells(5).FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = DataBinder.Eval(e.Row.DataItem, "LastEarnedDate")
                CType(e.Row.Cells(5).FindControl("LastResetDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = DataBinder.Eval(e.Row.DataItem, "LastResetDate")
                If LocaleUtilitiesBLL.IsTimeOffStatusEditMode Then
                    CType(e.Row.Cells(5).FindControl("lblLastEarnedDate"), Label).Visible = False
                    CType(e.Row.Cells(5).FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).Visible = True
                    CType(e.Row.Cells(6).FindControl("lblLastResetDate"), Label).Visible = False
                    CType(e.Row.Cells(6).FindControl("LastResetDateCalendarPopup"), eWorld.UI.CalendarPopup).Visible = True
                Else
                    CType(e.Row.Cells(5).FindControl("lblLastEarnedDate"), Label).Visible = True
                    CType(e.Row.Cells(5).FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).Visible = False
                End If
            Else
                If LocaleUtilitiesBLL.IsTimeOffStatusEditMode Then
                    CType(e.Row.Cells(5).FindControl("lblLastEarnedDate"), Label).Visible = False
                    'CType(e.Row.Cells(5).FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).Visible = False
                    CType(e.Row.Cells(5).FindControl("lblLastResetDate"), Label).Visible = False
                    CType(e.Row.Cells(5).FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = New DateTime(Date.Now.Year, 1, 1)
                    CType(e.Row.Cells(6).FindControl("LastResetDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = New DateTime(Date.Now.Year, 1, 1)
                Else
                    CType(e.Row.Cells(5).FindControl("lblLastEarnedDate"), Label).Visible = True
                    CType(e.Row.Cells(5).FindControl("LastEarnedDateCalendarPopup"), eWorld.UI.CalendarPopup).Visible = False
                End If

            End If
            If LocaleUtilitiesBLL.IsShowTimeOffInDays Then
                If LocaleUtilitiesBLL.IsTimeOffStatusEditMode Then
                    CType(e.Row.Cells(1).FindControl("lblEarned"), Label).Visible = False
                    CType(e.Row.Cells(1).FindControl("EarnedTextBox"), TextBox).Visible = True
                    CType(e.Row.Cells(4).FindControl("lblAvailable"), Label).Visible = False
                    CType(e.Row.Cells(4).FindControl("AvailableTextBox"), Label).Visible = True


                    CType(e.Row.Cells(1).FindControl("EarnedTextBox"), TextBox).Text = DataBinder.Eval(e.Row.DataItem, "EarnedDay")
                    CType(e.Row.Cells(2).FindControl("lblConsume"), Label).Text = DataBinder.Eval(e.Row.DataItem, "ConsumeDay")
                    CType(e.Row.Cells(3).FindControl("lblCarryForward"), Label).Text = DataBinder.Eval(e.Row.DataItem, "CarryForwardDay")
                    CType(e.Row.Cells(4).FindControl("AvailableTextBox"), Label).Text = DataBinder.Eval(e.Row.DataItem, "AvailableDay")

                    btnUpdate.Visible = True
                Else
                    CType(e.Row.Cells(1).FindControl("lblEarned"), Label).Visible = True
                    CType(e.Row.Cells(1).FindControl("EarnedTextBox"), TextBox).Visible = False
                    CType(e.Row.Cells(4).FindControl("lblAvailable"), Label).Visible = True
                    CType(e.Row.Cells(4).FindControl("AvailableTextBox"), Label).Visible = False

                    CType(e.Row.Cells(1).FindControl("lblEarned"), Label).Text = DataBinder.Eval(e.Row.DataItem, "EarnedDay")
                    CType(e.Row.Cells(2).FindControl("lblConsume"), Label).Text = DataBinder.Eval(e.Row.DataItem, "ConsumeDay")
                    CType(e.Row.Cells(3).FindControl("lblCarryForward"), Label).Text = DataBinder.Eval(e.Row.DataItem, "CarryForwardDay")
                    CType(e.Row.Cells(4).FindControl("lblAvailable"), Label).Text = DataBinder.Eval(e.Row.DataItem, "AvailableDay")

                    btnUpdate.Visible = False
                End If

                GridView1.Columns(1).HeaderText = "Earned Days"
                GridView1.Columns(2).HeaderText = "Consume Days"
                GridView1.Columns(3).HeaderText = "Carry Forward Days"
                GridView1.Columns(4).HeaderText = "Available Days"
            Else
                If LocaleUtilitiesBLL.IsTimeOffStatusEditMode Then
                    CType(e.Row.Cells(1).FindControl("lblEarned"), Label).Visible = False
                    CType(e.Row.Cells(1).FindControl("EarnedTextBox"), TextBox).Visible = True
                    CType(e.Row.Cells(4).FindControl("lblAvailable"), Label).Visible = False
                    CType(e.Row.Cells(4).FindControl("AvailableTextBox"), Label).Visible = True

                    btnUpdate.Visible = True
                Else
                    CType(e.Row.Cells(1).FindControl("lblEarned"), Label).Visible = True
                    CType(e.Row.Cells(1).FindControl("EarnedTextBox"), TextBox).Visible = False
                    CType(e.Row.Cells(4).FindControl("lblAvailable"), Label).Visible = True
                    CType(e.Row.Cells(4).FindControl("AvailableTextBox"), Label).Visible = False

                    btnUpdate.Visible = False
                End If
                'GridView1.Columns(1).HeaderText = "Earned Hours"
                'GridView1.Columns(2).HeaderText = "Consume Hours"
                'GridView1.Columns(3).HeaderText = "Carry Forward Hours"
                'GridView1.Columns(4).HeaderText = "Available Hours"
            End If
        End If
    End Sub



End Class
