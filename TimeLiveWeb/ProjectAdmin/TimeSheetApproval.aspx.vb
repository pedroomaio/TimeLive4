
Partial Class ProjectAdmin_TimeSheetApproval
    Inherits System.Web.UI.Page
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtTimeEntryStartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtTimeEntryStartDate.PostedDate)
        Me.txtTimeEntryEndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.txtTimeEntryEndDate.PostedDate)
        Me.ShowData()
    End Sub
    Public Sub ShowData()
        Me.CtlTimeSheetApprovalSummary1.ShowDataForTimeSheetApprovalSummary(ddlAccountEmployeeId.SelectedValue, txtTimeEntryStartDate.SelectedDate, txtTimeEntryEndDate.SelectedDate, chkIncludeDateRange.Checked)
    End Sub

    Protected Sub chkIncludeDateRange_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btnUpdate1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ''Me.DisableButton()
        If Me.CtlTimeSheetApprovalSummary1.CheckApprovalEntriesForApproved() = True Then
            Me.CtlTimeSheetApprovalSummary1.ForApproved(DBUtilities.GetSessionAccountEmployeeId, txtTimeEntryStartDate.SelectedDate, txtTimeEntryEndDate.SelectedDate, chkIncludeDateRange.Checked)
        End If
        If Me.CtlTimeSheetApprovalSummary1.CheckApprovalEntriesForReject() = True Then
            Me.CtlTimeSheetApprovalSummary1.ForReject(DBUtilities.GetSessionAccountEmployeeId, txtTimeEntryStartDate.SelectedDate, txtTimeEntryEndDate.SelectedDate, chkIncludeDateRange.Checked)
        End If

        AccountEmployeeTimeEntryBLL.ClearTimeEntryCacheOfAllAccount()
        Me.ShowData()
        btnUpdate1.Enabled = True
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisableButton()
        If Not Me.IsPostBack Then
            'DBUtilities.GetSessionAccountEmployeeId()

            '            AccountEmployeeBLL.SetDataForEmployeeDropdown(38, Me.ddlAccountEmployeeId)
            'AccountProjectBLL.SetDataForProjectDropdown(38, Me.ddlAccountProjectId)
            Me.ShowData()
            'AccountEmployeeBLL.SetDataForEmployeeDropdownAdministratorWhereClause(ddlAccountEmployeeId)
            If LocaleUtilitiesBLL.IsShowEmployeeNameWithCode = True Then

                ddlAccountEmployeeId.DataSource = dsAccountEmployeeObject
                ddlAccountEmployeeId.DataValueField = "AccountEmployeeId"
                ddlAccountEmployeeId.DataTextField = "EmployeeNameWithCode"

            Else

                ddlAccountEmployeeId.DataSource = dsAccountEmployeeObject
                ddlAccountEmployeeId.DataValueField = "AccountEmployeeId"
                ddlAccountEmployeeId.DataTextField = "EmployeeName"

            End If
            ddlAccountEmployeeId.DataBind()
        End If
        Me.Literal3.Text = ResourceHelper.GetFromResource("Time Sheet Approval")
        Me.Literal4.Text = ResourceHelper.GetFromResource("Search Parameters")
        Me.Literal7.Text = ResourceHelper.GetFromResource("Employee Name:")
        Me.Literal2.Text = ResourceHelper.GetFromResource("Include Date Range:")
        Me.Literal5.Text = ResourceHelper.GetFromResource("Start Date:")
        Me.Literal1.Text = ResourceHelper.GetFromResource("End Date:")
    End Sub
    Protected Sub chkSummarized_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Public Sub DisableButton()
        'btnUpdate1.Attributes.Add("onclick", "this.disabled=true;" + Me.Page.ClientScript.GetPostBackEventReference(btnUpdate1, ""))
        btnUpdate1.Attributes.Add("onclick", "javascript: if ( Page_ClientValidate() )" + "{" + btnUpdate1.ClientID + ".disabled=true;" + Me.Page.ClientScript.GetPostBackEventReference(btnUpdate1, ""))
    End Sub
End Class
