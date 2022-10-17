
Partial Class AccountAdmin_Controls_ctlAccountProjectList
    Inherits System.Web.UI.UserControl
    Public Event EditClick(ByVal sender As Object, ByVal CommandArgs As GridViewCommandEventArgs)
    Public Event btnShowClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event btnAddProjectClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event GridViewRowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
    Public Event GridViewRowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs)
    Dim FilterBLL As New AccountFilterModuleBLL
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
     
        'TODO: CheckAll function
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array
        'Get the header CheckBox
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If Me.GridView1.DataKeys(row.RowIndex).Item(0) <> 0 Then
                Me.btnDeleteSelectedItem.Visible = True
                Dim cbHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("chkCheckAll"), CheckBox)
                'Run the ChangeCheckBoxState client-side function whenever the
                'header checkbox is checked/unchecked
                cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"

                For Each gvr As GridViewRow In GridView1.Rows
                    'Get a programmatic reference to the CheckBox control
                    Dim cb As CheckBox = CType(gvr.FindControl("chkselect"), CheckBox)

                    'Add the CheckBox's ID to the client-side CheckBoxIDs array
                    ScriptManager.RegisterArrayDeclaration(Me, "CheckBoxIDs", String.Concat("'", cb.ClientID, "'"))
                Next
            End If
        Next
        If DBUtilities.ShowClientDepartmentInProject = True Then
            Me.GridView1.Columns(4).Visible = True
        Else
            Me.GridView1.Columns(4).Visible = False
        End If
    End Sub


    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            RaiseEvent GridViewRowCommand(sender, e)
            RaiseEvent EditClick(sender, e)
            Me.CollapsablePanelSearch.Visible = False
        End If
    End Sub

    Public Sub DoRefresh()
        Me.GridView1.DataBind()
    End Sub


    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "PartyName")) Then
                CType(e.Row.Cells(4).FindControl("Label3"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "PartyName").ToString.Length > 23, Left(DataBinder.Eval(e.Row.DataItem, "PartyName"), 21) & "..", DataBinder.Eval(e.Row.DataItem, "PartyName"))
                If DataBinder.Eval(e.Row.DataItem, "PartyName").ToString.Length > 23 Then
                    CType(e.Row.Cells(4).FindControl("Label3"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "PartyName")
                End If
            End If
            'If Session.Item("IsAdd") = "1" Then
            If Not Me.Request.QueryString("AccountProjectId") Is Nothing Then
                If DataBinder.Eval(e.Row.DataItem, "AccountProjectId") = New AccountProjectBLL().GetLastInsertedId Then
                    Dim lastRowIndex = e.Row.RowIndex
                    Dim integ As Integer
                    Dim fract As Decimal
                    e.Row.BackColor = Color.SteelBlue
                    e.Row.Cells(0).ForeColor = Color.White
                    e.Row.Cells(1).ForeColor = Color.White
                    e.Row.Cells(2).ForeColor = Color.White
                    e.Row.Cells(3).ForeColor = Color.White
                    e.Row.Cells(4).ForeColor = Color.White
                    e.Row.Cells(5).ForeColor = Color.White
                    e.Row.Cells(6).ForeColor = Color.White
                    Dim Attachment As HyperLink = e.Row.FindControl("HyperLinkAttachment")
                    Dim Gantt As HyperLink = e.Row.FindControl("HyperLink5")
                    Dim Tasks As HyperLink = e.Row.FindControl("HyperLink2")
                    Dim Team As HyperLink = e.Row.FindControl("HyperLink4")
                    Dim Milestone As HyperLink = e.Row.FindControl("HyperLink3")
                    Attachment.ForeColor = Color.White
                    Gantt.ForeColor = Color.White
                    Tasks.ForeColor = Color.White
                    Team.ForeColor = Color.White
                    Milestone.ForeColor = Color.White
                End If
                'End If
            End If
        End If
        ''For Gantt Permission and Feature SElected
        If Not Me.Request.QueryString("IsTemplate") = "True" Then
            If DBUtilities.IsProjectManagementFeature = True Then
                If AccountPagePermissionBLL.IsPageHasPermissionOf(32, 1) = False Then
                    Me.GridView1.Columns(9).Visible = False
                Else
                    Me.GridView1.Columns(9).Visible = True
                End If
            Else
                Me.GridView1.Columns(9).Visible = False
            End If
        Else
            Me.GridView1.Columns(9).Visible = False
        End If


        ''Task link
        If AccountPagePermissionBLL.IsPageHasPermissionOf(32, 1) = False Then
            Me.GridView1.Columns(10).Visible = False
        Else
            Me.GridView1.Columns(10).Visible = True
        End If

        ''Project team link
        If AccountPagePermissionBLL.IsPageHasPermissionOf(88, 1) = False Then
            Me.GridView1.Columns(11).Visible = False
        Else
            Me.GridView1.Columns(11).Visible = True
        End If
        ''MIlestone link
        If AccountPagePermissionBLL.IsPageHasPermissionOf(30, 1) = False Then
            Me.GridView1.Columns(12).Visible = False
        Else
            Me.GridView1.Columns(12).Visible = True
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectCode")) Then
                If IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectPrefix")) Then
                    CType(e.Row.Cells(1).FindControl("Label1"), Label).Text = DataBinder.Eval(e.Row.DataItem, "ProjectCode")
                Else
                    CType(e.Row.Cells(1).FindControl("Label1"), Label).Text = DataBinder.Eval(e.Row.DataItem, "ProjectPrefix") & IIf(DataBinder.Eval(e.Row.DataItem, "ProjectPrefix") = "", "", "-") & DataBinder.Eval(e.Row.DataItem, "ProjectCode")
                End If
            End If
        End If
    End Sub
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs)
        RaiseEvent GridViewRowDeleted(sender, e)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DBUtilities.HideProjectFromApplication = True Then
            Response.Redirect("~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & New AccountProjectBLL().GetFirstProject(DBUtilities.GetSessionAccountId, True), False)
        End If
        If Me.Request.QueryString("IsTemplate") = "True" Then
            AccountPagePermissionBLL.SetPagePermissionForGridView(103, Me.GridView1, 7, 8)
            Me.GridView1.Caption = Resources.TimeLive.Resource.Project_Template_List
            If AccountPagePermissionBLL.IsPageHasPermissionOf(103, 4) = False Then
                btnDeleteSelectedItem.Visible = False
                Me.GridView1.Columns(16).Visible = False
            End If
        Else
            AccountPagePermissionBLL.SetPagePermissionForGridView(31, Me.GridView1, 7, 8)
            If AccountPagePermissionBLL.IsPageHasPermissionOf(31, 4) = False Then
                btnDeleteSelectedItem.Visible = False
                Me.GridView1.Columns(16).Visible = False
            End If
        End If

        ''database condition Account table Islock true then
        If DBUtilities.IsValidateLockAccount Then
            btnAddProject.Enabled = False
        Else
            btnAddProject.Enabled = True
        End If
        ''free account expire then
        If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
            Dim BLL As New AccountProjectBLL

            If BLL.IsCheckProjectRowsForLicense(DBUtilities.GetSessionAccountId) Then
                btnAddProject.Enabled = False
            End If
        End If
        If Not Me.IsPostBack Then
            FilterBLL.InsertFilterDefaultValues(Me, Me.Page)
            FilterBLL.GetFilterModuleForNonGridViewObject(Me, Me.Page)
            If ddlCompletedStatus.SelectedValue Is Nothing Then
                Me.dsAccountProjectObject.SelectParameters("Completed").DefaultValue = "-1"
                Me.ddlCompletedStatus.SelectedValue = "-1"
            Else
                Me.dsAccountProjectObject.SelectParameters("Completed").DefaultValue = Me.ddlCompletedStatus.SelectedValue
            End If
            If ddlProjectStatus.SelectedValue Is Nothing Then
                Me.dsAccountProjectObject.SelectParameters("ProjectStatusId").DefaultValue = 0
                Me.ddlProjectStatus.SelectedValue = 0
            Else
                Me.dsAccountProjectObject.SelectParameters("ProjectStatusId").DefaultValue = Me.ddlProjectStatus.SelectedValue
            End If
            Me.dsAccountProjectObject.SelectParameters("AccountProjectId").DefaultValue = Nothing
            Me.dsAccountProjectObject.SelectParameters("ProjectCode").DefaultValue = Me.txtProjectCode.Text
            Me.dsAccountProjectObject.SelectParameters("AccountClientId").DefaultValue = Me.ddlAccountClientId.SelectedValue
            Me.dsAccountProjectObject.SelectParameters("Disabled").DefaultValue = "-1"
            Dim IsAdd As String = CType(Session.Item("IsAdd"), String)
            If IsAdd = "1" Then
                Me.dsAccountProjectObject.SelectParameters("AccountProjectId").DefaultValue = CType(Session.Item("AccountProjectId"), String)
                Me.dsAccountProjectObject.SelectParameters("IsProjectAdd").DefaultValue = True
                Session.Remove("IsAdd")
                If Not Me.Request.QueryString("AccountProjectId") Is Nothing Then
                    Me.GridView1.DataBind()
                    GridView1.PageIndex = GridView1.PageCount
                End If
            End If
            Me.GridView1.DataBind()
            If GridView1.Rows.Count = 0 Then
                GridView1.ShowHeaderWhenEmpty = True
                GridView1.EmptyDataText = "There are no items to display."
                Me.GridView1.DataBind()
            End If
        End If

    End Sub
    Protected Sub btnAddProject_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddProject.Click
        Me.CollapsablePanelSearch.Visible = False
        Me.GridView1.Visible = False
        Me.btnAddProject.Visible = False
        Me.btnDeleteSelectedItem.Visible = False
        RaiseEvent btnAddProjectClick(sender, e)
    End Sub
    Protected Sub btnDeleteSelectedItem_Click(sender As Object, e As System.EventArgs) Handles btnDeleteSelectedItem.Click
        Dim row As GridViewRow
        Dim Original_AccountProjectId As Integer
        For Each row In Me.GridView1.Rows
            If Me.GridView1.DataKeys(row.RowIndex)(0) <> 0 Then
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = True Then
                    Original_AccountProjectId = Me.GridView1.DataKeys(row.RowIndex)(0)
                    Dim BLL As New AccountProjectBLL
                    Original_AccountProjectId = New AccountProjectBLL().DeleteAccountProject(Original_AccountProjectId)
                End If
            End If
        Next
        Me.GridView1.DataBind()
    End Sub
    Protected Sub btnShow_Click(sender As Object, e As System.EventArgs) Handles btnShow.Click
        FilterBLL.InsertFilterModuleForNonGridViewObject(Me, Me.Page)
        SetFilterControls()
        If GridView1.Rows.Count = 0 Then
            GridView1.ShowHeaderWhenEmpty = True
            GridView1.EmptyDataText = "There are no items to display."
            Me.GridView1.DataBind()
        End If
        RaiseEvent btnShowClick(sender, e)
    End Sub

    Public Sub SetFilterControls()
        'FilterBLL.GetFilterModuleForNonGridViewObject(Me, Me.Page)
        Me.dsAccountProjectObject.SelectParameters("AccountClientId").DefaultValue = ddlAccountClientId.SelectedValue
        Me.dsAccountProjectObject.SelectParameters("AccountProjectId").DefaultValue = Nothing
        Me.dsAccountProjectObject.SelectParameters("ProjectCode").DefaultValue = txtProjectCode.Text
        Me.dsAccountProjectObject.SelectParameters("Completed").DefaultValue = ddlCompletedStatus.SelectedValue
        Me.dsAccountProjectObject.SelectParameters("ProjectStatusId").DefaultValue = ddlProjectStatus.SelectedValue
        'Me.dsAccountProjectObject.SelectParameters("Disabled").DefaultValue = ddlDisable.SelectedValue
        Me.GridView1.DataBind()
    End Sub
End Class
