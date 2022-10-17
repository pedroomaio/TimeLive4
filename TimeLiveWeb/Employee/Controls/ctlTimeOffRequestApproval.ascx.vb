
Partial Class Employee_Controls_ctlTimeOffRequestApproval
    Inherits System.Web.UI.UserControl
    Public Sub RefreshGridApprovalEntries()
        If Me.ddlTimeOffTypeId.SelectedValue.ToString <> "0" Then
            Dim AccountTimeOffTypeId As New Guid(Me.ddlTimeOffTypeId.SelectedValue)
            Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("AccountTimeOffTypeId").DefaultValue = AccountTimeOffTypeId.ToString
        Else
            Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("AccountTimeOffTypeId").DefaultValue = System.Guid.Empty.ToString
        End If
        Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("TimeOffAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("StartDate").DefaultValue = Me.txtStartDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("EndDate").DefaultValue = Me.txtEndDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForSpecificEmployee.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        If Me.ddlTimeOffTypeId.SelectedValue.ToString <> "0" Then
            Dim AccountTimeOffTypeId As New Guid(Me.ddlTimeOffTypeId.SelectedValue)
            Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("AccountTimeOffTypeId").DefaultValue = AccountTimeOffTypeId.ToString
        Else
            Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("AccountTimeOffTypeId").DefaultValue = System.Guid.Empty.ToString
        End If
        Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("TimeOffAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("StartDate").DefaultValue = Me.txtStartDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("EndDate").DefaultValue = Me.txtEndDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForEmployeeManager.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        If Me.ddlTimeOffTypeId.SelectedValue.ToString <> "0" Then
            Dim AccountTimeOffTypeId As New Guid(Me.ddlTimeOffTypeId.SelectedValue)
            Me.dsTimeOffApprovalEntriesForProjectManager.SelectParameters("AccountTimeOffTypeId").DefaultValue = AccountTimeOffTypeId.ToString
        Else
            Me.dsTimeOffApprovalEntriesForProjectManager.SelectParameters("AccountTimeOffTypeId").DefaultValue = System.Guid.Empty.ToString
        End If
        Me.dsTimeOffApprovalEntriesForProjectManager.SelectParameters("TimeOffAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsTimeOffApprovalEntriesForProjectManager.SelectParameters("StartDate").DefaultValue = Me.txtStartDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForProjectManager.SelectParameters("EndDate").DefaultValue = Me.txtEndDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForProjectManager.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        If Me.ddlTimeOffTypeId.SelectedValue.ToString <> "0" Then
            Dim AccountTimeOffTypeId As New Guid(Me.ddlTimeOffTypeId.SelectedValue)
            Me.dsTimeOffApprovalEntriesForTeamLead.SelectParameters("AccountTimeOffTypeId").DefaultValue = AccountTimeOffTypeId.ToString
        Else
            Me.dsTimeOffApprovalEntriesForTeamLead.SelectParameters("AccountTimeOffTypeId").DefaultValue = System.Guid.Empty.ToString
        End If
        Me.dsTimeOffApprovalEntriesForTeamLead.SelectParameters("TimeOffAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsTimeOffApprovalEntriesForTeamLead.SelectParameters("StartDate").DefaultValue = Me.txtStartDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForTeamLead.SelectParameters("EndDate").DefaultValue = Me.txtEndDate.SelectedValue
        Me.dsTimeOffApprovalEntriesForTeamLead.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked

        Me.SpecificEmployeeGridView.DataBind()
        Me.EmployeeManagerGridView.DataBind()
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtStartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtStartDate.PostedDate)
        Me.txtEndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtEndDate.PostedDate)
        Me.RefreshGridApprovalEntries()
    End Sub
    Public Sub ForApproved()
        Dim row As GridViewRow
        Dim objTimeOff As New AccountEmployeeTimeOffRequestBLL
        Dim objEmployeeTimeOff As New AccountEmployeeTimeOffBLL
        For Each row In Me.SpecificEmployeeGridView.Rows
            If CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = True And IsDBNull(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved")) Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, True, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("ApprovalPathSequence") = Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("TimeOffAccountEmployeeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountTimeOffTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = False And IsDBNull(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved")) Then
            ElseIf CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = True And Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved") = False Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, True, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("ApprovalPathSequence") = Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("TimeOffAccountEmployeeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountTimeOffTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = False And Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved") = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, True, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("ApprovalPathSequence") = Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("TimeOffAccountEmployeeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountTimeOffTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            End If
            Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("StartDate"))
        Next
        Dim row2 As GridViewRow
        For Each row2 In Me.EmployeeManagerGridView.Rows
            If CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = True And IsDBNull(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved")) Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, True, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("ApprovalPathSequence") = Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("TimeOffAccountEmployeeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountTimeOffTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = False And IsDBNull(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved")) Then
            ElseIf CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = True And Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved") = False Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, True, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("ApprovalPathSequence") = Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("TimeOffAccountEmployeeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountTimeOffTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = False And Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved") = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, True, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("ApprovalPathSequence") = Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("TimeOffAccountEmployeeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountTimeOffTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            End If
            Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("StartDate"))

        Next
        Dim row3 As GridViewRow
        For Each row3 In Me.ProjectManagerGridView.Rows
            If CType(row3.FindControl("rdProjectManager"), CheckBox).Checked = True And IsDBNull(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("IsApproved")) Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountApprovalTypeId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountApprovalPathId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("ProjectManagerId"), False, True, CType(row3.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("ApprovalPathSequence") = Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("TimeOffAccountEmployeeId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountTimeOffTypeId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row3.FindControl("rdProjectManager"), CheckBox).Checked = False And IsDBNull(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("IsApproved")) Then
            ElseIf CType(row3.FindControl("rdProjectManager"), CheckBox).Checked = True And Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("IsApproved") = False Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountApprovalTypeId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountApprovalPathId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("ProjectManagerId"), False, True, CType(row3.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("ApprovalPathSequence") = Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("TimeOffAccountEmployeeId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row3.FindControl("rdProjectManager"), CheckBox).Checked = False And Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("IsApproved") = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountApprovalTypeId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountApprovalPathId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("ProjectManagerId"), False, True, CType(row3.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("ApprovalPathSequence") = Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("TimeOffAccountEmployeeId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountTimeOffTypeId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            End If
            Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("StartDate"))
        Next
        Dim row4 As GridViewRow
        For Each row4 In Me.TeamLeadGridView.Rows
            If CType(row4.FindControl("rdTeamLead"), CheckBox).Checked = True And IsDBNull(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("IsApproved")) Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountApprovalTypeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountApprovalPathId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("TeamLeadId"), False, True, CType(row4.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.TeamLeadGridView.DataKeys(row4.RowIndex)("ApprovalPathSequence") = Me.TeamLeadGridView.DataKeys(row4.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("TimeOffAccountEmployeeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountTimeOffTypeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row4.FindControl("rdTeamLead"), CheckBox).Checked = False And IsDBNull(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("IsApproved")) Then
            ElseIf CType(row4.FindControl("rdTeamLead"), CheckBox).Checked = True And Me.TeamLeadGridView.DataKeys(row4.RowIndex)("IsApproved") = False Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountApprovalTypeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountApprovalPathId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("TeamLeadId"), False, True, CType(row4.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.TeamLeadGridView.DataKeys(row4.RowIndex)("ApprovalPathSequence") = Me.TeamLeadGridView.DataKeys(row4.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("TimeOffAccountEmployeeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountTimeOffTypeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            ElseIf CType(row4.FindControl("rdTeamLead"), CheckBox).Checked = False And Me.TeamLeadGridView.DataKeys(row4.RowIndex)("IsApproved") = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountApprovalTypeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountApprovalPathId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("TeamLeadId"), False, True, CType(row4.FindControl("CommentsTextBox"), TextBox).Text)
                If Me.TeamLeadGridView.DataKeys(row4.RowIndex)("ApprovalPathSequence") = Me.TeamLeadGridView.DataKeys(row4.RowIndex)("MaxApprovalPathSequence") Then
                    If objEmployeeTimeOff.SetEmployeeTimeOffHoursFromTimeOffRequest(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("TimeOffAccountEmployeeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountTimeOffTypeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("HoursOff"), DBUtilities.GetEmployeeNameWithCode, "Approved", "Time Off Approval") Then
                        Call New AccountEmployeeTimeEntryBLL().UpdateIsTimeOffConsumedByAccountEmployeeTimeOffRequestId(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    End If
                    Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    objTimeOff.LockSpecificEmployeeTimeOff(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                    objTimeOff.SendTimeOffApprovedEMail(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                End If
            End If
            Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("StartDate"))
        Next
    End Sub
    Public Sub ForRejected()
        Dim row As GridViewRow
        Dim objTimeOff As New AccountEmployeeTimeOffRequestBLL
        For Each row In Me.SpecificEmployeeGridView.Rows
            If CType(row.FindControl("rdSpecificEmployeeRejected"), CheckBox).Checked = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), True, False, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                objTimeOff.LockSpecificEmployeeTimeOffRejected(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                Call New AccountEmployeeTimeEntryBLL().UpdateSubmittedByAccountEmployeeTimeOffRequestId(False, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().UpdateRejectedByAccountEmployeeTimeOffRequestId(True, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("StartDate"))
                objTimeOff.SendTimeOffRejectedEMail(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeTimeOffRequestId"))
            End If
        Next
        Dim row2 As GridViewRow
        For Each row2 In Me.EmployeeManagerGridView.Rows
            If CType(row2.FindControl("rdEmployeeManagerRejected"), CheckBox).Checked = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), True, False, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                objTimeOff.LockSpecificEmployeeTimeOffRejected(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                Call New AccountEmployeeTimeEntryBLL().UpdateSubmittedByAccountEmployeeTimeOffRequestId(False, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().UpdateRejectedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("StartDate"))
                objTimeOff.SendTimeOffRejectedEMail(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
            End If

        Next
        Dim row3 As GridViewRow
        For Each row3 In Me.ProjectManagerGridView.Rows
            If CType(row3.FindControl("rdProjectManagerRejected"), CheckBox).Checked = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountApprovalTypeId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountApprovalPathId"), Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("ProjectManagerId"), True, False, CType(row3.FindControl("CommentsTextBox"), TextBox).Text)
                objTimeOff.LockSpecificEmployeeTimeOffRejected(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                Call New AccountEmployeeTimeEntryBLL().UpdateSubmittedByAccountEmployeeTimeOffRequestId(False, Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().UpdateRejectedByAccountEmployeeTimeOffRequestId(True, Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("StartDate"))
                objTimeOff.SendTimeOffRejectedEMail(Me.ProjectManagerGridView.DataKeys(row3.RowIndex)("AccountEmployeeTimeOffRequestId"))
            End If

        Next
        Dim row4 As GridViewRow
        For Each row4 In Me.TeamLeadGridView.Rows
            If CType(row4.FindControl("rdTeamLeadRejected"), CheckBox).Checked = True Then
                objTimeOff.AddAccountEmployeeTimeOffRequestApproval(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountApprovalTypeId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountApprovalPathId"), Me.TeamLeadGridView.DataKeys(row4.RowIndex)("TeamLeadId"), True, False, CType(row4.FindControl("CommentsTextBox"), TextBox).Text)
                objTimeOff.LockSpecificEmployeeTimeOffRejected(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"), True)
                Call New AccountEmployeeTimeEntryBLL().UpdateSubmittedByAccountEmployeeTimeOffRequestId(False, Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().UpdateRejectedByAccountEmployeeTimeOffRequestId(True, Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().SetAccountEmployeeTimeEntryPeriodApprovalStatusByTimeOffRequestId(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
                Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("StartDate"))
                objTimeOff.SendTimeOffRejectedEMail(Me.TeamLeadGridView.DataKeys(row4.RowIndex)("AccountEmployeeTimeOffRequestId"))
            End If

        Next
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ForApproved()
        ForRejected()
        RefreshGridApprovalEntries()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If LocaleUtilitiesBLL.IsShowEmployeeNameWithCode = True Then

                ddlAccountEmployeeId.DataSource = dsAccountEmployeeObject
                ddlAccountEmployeeId.DataValueField = "AccountEmployeeId"
                ddlAccountEmployeeId.DataTextField = "EmployeeNameWithCode"

            Else

                ddlAccountEmployeeId.DataSource = dsAccountEmployeeObject
                ddlAccountEmployeeId.DataValueField = "AccountEmployeeId"
                ddlAccountEmployeeId.DataTextField = "FullName"

            End If
            ddlAccountEmployeeId.DataBind()
        End If
        SortGridViews()
    End Sub

    Protected Sub EmployeeManagerGridView_DataBound(sender As Object, e As System.EventArgs) Handles EmployeeManagerGridView.DataBound
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In EmployeeManagerGridView.Rows

            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("rdEmployeeManager"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs2", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.EmployeeManagerGridView.Rows.Count <> 0 Then
            Me.CheckAllEmployeeManager.Visible = True
            Me.UnCheckAllEmployeeManager.Visible = True
        Else
            Me.CheckAllEmployeeManager.Visible = False
            Me.UnCheckAllEmployeeManager.Visible = False
        End If
    End Sub

    Protected Sub ProjectManagerGridView_DataBound(sender As Object, e As System.EventArgs) Handles ProjectManagerGridView.DataBound
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In ProjectManagerGridView.Rows

            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("rdProjectManager"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs3", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.ProjectManagerGridView.Rows.Count <> 0 Then
            Me.CheckAllProjectManager.Visible = True
            Me.UnCheckAllProjectManager.Visible = True
        Else
            Me.CheckAllProjectManager.Visible = False
            Me.UnCheckAllProjectManager.Visible = False
        End If
    End Sub

    Protected Sub SpecificEmployeeGridView_DataBound(sender As Object, e As System.EventArgs) Handles SpecificEmployeeGridView.DataBound
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In SpecificEmployeeGridView.Rows

            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("rdSpecificEmployee"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs1", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.SpecificEmployeeGridView.Rows.Count <> 0 Then
            Me.CheckAllSpecificEmployee.Visible = True
            Me.UnCheckAllSpecificEmployee.Visible = True
        Else
            Me.CheckAllSpecificEmployee.Visible = False
            Me.UnCheckAllSpecificEmployee.Visible = False
        End If
    End Sub

    Protected Sub TeamLeadGridView_DataBound(sender As Object, e As System.EventArgs) Handles TeamLeadGridView.DataBound
        'On every page visit we need to build up the CheckBoxIDs array
        For Each gvr As GridViewRow In TeamLeadGridView.Rows

            'Get a programmatic reference to the CheckBox control
            Dim cb As CheckBox = CType(gvr.FindControl("rdTeamLead"), CheckBox)

            Me.Page.ClientScript.RegisterArrayDeclaration("CheckBoxIDs4", String.Concat("'", cb.ClientID, "'"))
        Next

        If Me.TeamLeadGridView.Rows.Count <> 0 Then
            Me.CheckAllTeamLead.Visible = True
            Me.UnCheckAllTeamLead.Visible = True
        Else
            Me.CheckAllTeamLead.Visible = False
            Me.UnCheckAllTeamLead.Visible = False
        End If
    End Sub

    Protected Sub CheckAllEmployeeManager_Click(sender As Object, e As System.EventArgs) Handles CheckAllEmployeeManager.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllProjectManager_Click(sender As Object, e As System.EventArgs) Handles CheckAllProjectManager.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllSpecificEmployee_Click(sender As Object, e As System.EventArgs) Handles CheckAllSpecificEmployee.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub CheckAllTeamLead_Click(sender As Object, e As System.EventArgs) Handles CheckAllTeamLead.Click
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllEmployeeManager_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllEmployeeManager.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllProjectManager_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllProjectManager.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllSpecificEmployee_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllSpecificEmployee.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub UnCheckAllTeamLead_Click(sender As Object, e As System.EventArgs) Handles UnCheckAllTeamLead.Click
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub
    Protected Sub SpecificEmployeeGridView_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles SpecificEmployeeGridView.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If LocaleUtilitiesBLL.IsShowTimeOffInDays Then
                CType(e.Row.Cells(3).FindControl("lblAvailableSpecificEmployee"), Label).Text = DataBinder.Eval(e.Row.DataItem, "AvailableDay")
                SpecificEmployeeGridView.Columns(3).HeaderText = "Available Days"
            Else
                CType(e.Row.Cells(3).FindControl("lblAvailableSpecificEmployee"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Available")
                SpecificEmployeeGridView.Columns(3).HeaderText = "Available Hours"
            End If
        End If
    End Sub

    Protected Sub EmployeeManagerGridView_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles EmployeeManagerGridView.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If LocaleUtilitiesBLL.IsShowTimeOffInDays Then
                CType(e.Row.Cells(3).FindControl("lblAvailableEmployeeManager"), Label).Text = DataBinder.Eval(e.Row.DataItem, "AvailableDay")
                EmployeeManagerGridView.Columns(3).HeaderText = "Available Days"
            Else
                CType(e.Row.Cells(3).FindControl("lblAvailableEmployeeManager"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Available")
                EmployeeManagerGridView.Columns(3).HeaderText = "Available Hours"
                CType(e.Row.Cells(0).FindControl("lnkEmployeeName"), HyperLink).NavigateUrl = String.Format("~/Employee/MyTimeOffReadOnly.aspx?AccountEmployeeId={0}", DataBinder.Eval(e.Row.DataItem, "TimeOffAccountEmployeeId"))
                SetupRowAttachmentLink(e.Row, DataBinder.Eval(e.Row.DataItem, "AccountEmployeeTimeOffRequestId"))
            End If
        End If
    End Sub
    Private Sub SetupRowAttachmentLink(row As GridViewRow, ByVal AccountEmployeeTimeOffRequestId As Guid)

        Dim hyperlinkControl = CType(row.Cells(4).FindControl("ATLink"), HyperLink)

        Dim TimeOffAttachmentsBLL = New TimeOffAttachmentsBLL

        Dim attachmentsCounter = TimeOffAttachmentsBLL.CountAttachmentsByTimeOffRequestId(AccountEmployeeTimeOffRequestId)
        If attachmentsCounter > 0 Then
            hyperlinkControl.Visible = True
            hyperlinkControl.Text = attachmentsCounter
            hyperlinkControl.NavigateUrl = "~/Employee/TimeOffAttachments.aspx?ReadOnly=true&" & "TimeOffRequest=" & AccountEmployeeTimeOffRequestId.ToString()

        End If
    End Sub
    Protected Sub ProjectManagerGridView_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ProjectManagerGridView.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If LocaleUtilitiesBLL.IsShowTimeOffInDays Then
                CType(e.Row.Cells(3).FindControl("lblAvailableProjectManager"), Label).Text = DataBinder.Eval(e.Row.DataItem, "AvailableDay")
                ProjectManagerGridView.Columns(3).HeaderText = "Available Days"
            Else
                CType(e.Row.Cells(3).FindControl("lblAvailableProjectManager"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Available")
                ProjectManagerGridView.Columns(3).HeaderText = "Available Hours"
            End If
        End If
    End Sub

    Protected Sub TeamLeadGridView_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles TeamLeadGridView.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If LocaleUtilitiesBLL.IsShowTimeOffInDays Then
                CType(e.Row.Cells(3).FindControl("lblAvailableTeamLead"), Label).Text = DataBinder.Eval(e.Row.DataItem, "AvailableDay")
                TeamLeadGridView.Columns(3).HeaderText = "Available Days"
            Else
                CType(e.Row.Cells(3).FindControl("lblAvailableTeamLead"), Label).Text = DataBinder.Eval(e.Row.DataItem, "Available")
                TeamLeadGridView.Columns(3).HeaderText = "Available Hours"
            End If
        End If
    End Sub
    Private Sub SortGridViews()
        SortGridViewByEmployeeName(Me.SpecificEmployeeGridView)
        SortGridViewByEmployeeName(Me.EmployeeManagerGridView)
        SortGridViewByEmployeeName(Me.ProjectManagerGridView)
        SortGridViewByEmployeeName(Me.TeamLeadGridView)
    End Sub
    Private Sub SortGridViewByEmployeeName(ByVal gridView As GridView)
        If String.IsNullOrEmpty(gridView.SortExpression) Then
            gridView.Sort("FullName ASC,StartDate", System.Web.UI.WebControls.SortDirection.Ascending)
        End If
    End Sub
End Class
