
Partial Class Employee_Controls_ctlAccountEmployeeAttendanceApproval
    Inherits System.Web.UI.UserControl
    Public Sub RefreshGridApprovalEntries()
        Me.dsAttendanceApprovalEntriesForSpecificEmployee.SelectParameters("AttendanceAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsAttendanceApprovalEntriesForSpecificEmployee.SelectParameters("StartDate").DefaultValue = Me.txtStartDate.SelectedValue
        Me.dsAttendanceApprovalEntriesForSpecificEmployee.SelectParameters("EndDate").DefaultValue = Me.txtEndDate.SelectedValue
        Me.dsAttendanceApprovalEntriesForSpecificEmployee.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked


        Me.dsAttendanceApprovalEntriesForEmployeeManager.SelectParameters("AttendanceAccountEmployeeId").DefaultValue = Me.ddlAccountEmployeeId.SelectedValue
        Me.dsAttendanceApprovalEntriesForEmployeeManager.SelectParameters("StartDate").DefaultValue = Me.txtStartDate.SelectedValue
        Me.dsAttendanceApprovalEntriesForEmployeeManager.SelectParameters("EndDate").DefaultValue = Me.txtEndDate.SelectedValue
        Me.dsAttendanceApprovalEntriesForEmployeeManager.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked


        Me.SpecificEmployeeGridView.DataBind()
        Me.EmployeeManagerGridView.DataBind()
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        RefreshGridApprovalEntries()
    End Sub
    Public Sub ForApproved()
        Dim row As GridViewRow
        Dim objAttendance As New AccountEmployeeAttendanceBLL

        For Each row In Me.SpecificEmployeeGridView.Rows
            If CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = True And IsDBNull(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved")) Then
                objAttendance.AddAccountEmployeeAttendanceApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeAttendanceId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, True, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                objAttendance.UpdateAccountEmployeeAttendanceForApproval(DBUtilities.GetSessionAccountId, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), True, True, False, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeAttendanceId"))
                If Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("ApprovalPathSequence") = Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("MaxApprovalPathSequence") Then

                End If
            ElseIf CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = False And IsDBNull(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved")) Then
            ElseIf CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = True And Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved") = False Then
                objAttendance.AddAccountEmployeeAttendanceApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeAttendanceId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, True, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                objAttendance.UpdateAccountEmployeeAttendanceForApproval(DBUtilities.GetSessionAccountId, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), True, True, False, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeAttendanceId"))
                If Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("ApprovalPathSequence") = Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("MaxApprovalPathSequence") Then
                End If
            ElseIf CType(row.FindControl("rdSpecificEmployee"), CheckBox).Checked = False And Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("IsApproved") = True Then
                objAttendance.AddAccountEmployeeAttendanceApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeAttendanceId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, True, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                objAttendance.UpdateAccountEmployeeAttendanceForApproval(DBUtilities.GetSessionAccountId, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), True, True, False, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeAttendanceId"))
                If Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("ApprovalPathSequence") = Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("MaxApprovalPathSequence") Then

                End If
            End If
            Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("StartDate"))
        Next
        Dim row2 As GridViewRow
        For Each row2 In Me.EmployeeManagerGridView.Rows
            If CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = True And IsDBNull(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved")) Then
                objAttendance.AddAccountEmployeeAttendanceApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeAttendanceId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, True, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                objAttendance.UpdateAccountEmployeeAttendanceForApproval(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), True, True, False, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeAttendanceId"))
                If Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("ApprovalPathSequence") = Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("MaxApprovalPathSequence") Then
                    'Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
                    
                End If
            ElseIf CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = False And IsDBNull(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved")) Then
            ElseIf CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = True And Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved") = False Then
                objAttendance.AddAccountEmployeeAttendanceApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeAttendanceId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, True, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                objAttendance.UpdateAccountEmployeeAttendanceForApproval(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), True, True, False, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeAttendanceId"))
                If Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("ApprovalPathSequence") = Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("MaxApprovalPathSequence") Then

                    '                Call New AccountEmployeeTimeEntryBLL().UpdateApprovedByAccountEmployeeTimeOffRequestId(True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeTimeOffRequestId"))
 
                End If
            ElseIf CType(row2.FindControl("rdEmployeeManager"), CheckBox).Checked = False And Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("IsApproved") = True Then
                objAttendance.AddAccountEmployeeAttendanceApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeAttendanceId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, True, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                objAttendance.UpdateAccountEmployeeAttendanceForApproval(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), True, True, False, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeAttendanceId"))
                If Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("ApprovalPathSequence") = Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("MaxApprovalPathSequence") Then
                    
                End If
            End If
            Call New AccountEmployeeTimeEntryBLL().AfterUpdate(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("StartDate"))
        Next
 
    End Sub
    Public Sub ForRejected()
        Dim row As GridViewRow
        Dim objAttendance As New AccountEmployeeAttendanceBLL
        For Each row In Me.SpecificEmployeeGridView.Rows
            If CType(row.FindControl("rdSpecificEmployeeRejected"), CheckBox).Checked = True Then
                objAttendance.AddAccountEmployeeAttendanceApproval(Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeAttendanceId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalTypeId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountApprovalPathId"), Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), True, False, CType(row.FindControl("CommentsTextBox"), TextBox).Text)
                objAttendance.UpdateAccountEmployeeAttendanceForApproval(DBUtilities.GetSessionAccountId, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeId"), False, False, True, Me.SpecificEmployeeGridView.DataKeys(row.RowIndex)("AccountEmployeeAttendanceId"))
            End If
        Next
        Dim row2 As GridViewRow
        For Each row2 In Me.EmployeeManagerGridView.Rows
            If CType(row2.FindControl("rdEmployeeManagerRejected"), CheckBox).Checked = True Then
                objAttendance.AddAccountEmployeeAttendanceApproval(Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeAttendanceId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalTypeId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountApprovalPathId"), Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), True, False, CType(row2.FindControl("CommentsTextBox"), TextBox).Text)
                objAttendance.UpdateAccountEmployeeAttendanceForApproval(DBUtilities.GetSessionAccountId, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("EmployeeManagerId"), False, False, True, Me.EmployeeManagerGridView.DataKeys(row2.RowIndex)("AccountEmployeeAttendanceId"))

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


End Class
