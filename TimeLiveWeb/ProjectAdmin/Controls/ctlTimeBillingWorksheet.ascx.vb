Partial Class ProjectAdmin_Controls_ctlTimeBillingWorksheet
    Inherits System.Web.UI.UserControl
    Dim TotalTime As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ReportUtilities.SetDefaultValuesOfFilerItemBilling(Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)
            Me.ShowGridFromFilter()
        End If
        Me.Literal2.Text = ResourceHelper.GetFromResource("Time Billing Worksheet")
        Me.Literal1.Text = ResourceHelper.GetFromResource("Search Parameters")
        Me.Literal3.Text = ResourceHelper.GetFromResource("Project")
        Me.Literal4.Text = ResourceHelper.GetFromResource("Project Tasks")
        Me.Literal5.Text = ResourceHelper.GetFromResource("Billed")
        Me.Literal7.Text = ResourceHelper.GetFromResource("Include Date Range")
        Me.Literal8.Text = ResourceHelper.GetFromResource("Start Date")
        Me.Literal9.Text = ResourceHelper.GetFromResource("End Date")

    End Sub
    Public Sub ShowGridFromFilter()
        Dim nAccountProjectTaskId As Long
        If ddlProjectTasks.SelectedValue = "" Then
            nAccountProjectTaskId = 0
        Else
            nAccountProjectTaskId = ddlProjectTasks.SelectedValue
        End If
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FindControl("CascadingDropDown1"), AjaxControlToolkit.CascadingDropDown)
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & nAccountProjectTaskId

        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)

        Me.dsTimeBillingWorksheetObject.SelectParameters("AccountProjectId").DefaultValue = Me.ddlProjects.SelectedValue
        Me.dsTimeBillingWorksheetObject.SelectParameters("AccountProjectTaskId").DefaultValue = Me.ddlProjectTasks.SelectedValue
        Me.dsTimeBillingWorksheetObject.SelectParameters("AccountClientId").DefaultValue = Me.ddlClients.SelectedValue
        Me.dsTimeBillingWorksheetObject.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked
        Me.dsTimeBillingWorksheetObject.SelectParameters("TimeEntryStartDate").DefaultValue = Me.StartDate.SelectedDate
        Me.dsTimeBillingWorksheetObject.SelectParameters("TimeEntryEndDate").DefaultValue = Me.EndDate.SelectedDate
        Me.dsTimeBillingWorksheetObject.SelectParameters("Billed").DefaultValue = Me.ddlBilled.SelectedValue

        Me.GridView1.DataBind()
    End Sub
    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        ShowGridFromFilter()
    End Sub
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountPagePermissionBLL.SetPagePermissionForGridViewAndEdit(130, GridView1, 7)
        'Me.btnDeleteSelectedItem.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(130, 4)
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        TotalTime = TotalTime + DBUtilities.GetMinutesOfTime(CType(DataBinder.Eval(e.Row.DataItem, "TotalTime"), Date))
        If e.Row.RowType = DataControlRowType.Footer Then
            CType(e.Row.Cells(6).FindControl("SumTime"), Label).Text = DBUtilities.GetDateTimeOfMinutesAsString(TotalTime)
        End If
    End Sub
    'Protected Sub CheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim row As GridViewRow
    '    For Each row In Me.GridView1.Rows
    '        CType(row.Cells(0).FindControl("chkDelete"), CheckBox).Checked = True
    '    Next
    'End Sub
    'Protected Sub UnCheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim row As GridViewRow
    '    For Each row In Me.GridView1.Rows
    '        CType(row.Cells(0).FindControl("chkDelete"), CheckBox).Checked = False
    '    Next
    'End Sub
    'Protected Sub btnDeleteSelectedItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim row As GridViewRow
    '    Dim Original_AccountEmployeeTimeEntryId As Integer
    '    For Each row In Me.GridView1.Rows
    '        If CType(row.FindControl("chkDelete"), CheckBox).Checked = True Then
    '            Original_AccountEmployeeTimeEntryId = Me.GridView1.DataKeys(row.RowIndex)(0)
    '            Original_AccountEmployeeTimeEntryId = New AccountTimeExpenseBillingBLL().DeleteAccountEmployeeTimeEntry(Original_AccountEmployeeTimeEntryId)
    '        End If
    '    Next
    '    Me.GridView1.DataBind()
    'End Sub

End Class
