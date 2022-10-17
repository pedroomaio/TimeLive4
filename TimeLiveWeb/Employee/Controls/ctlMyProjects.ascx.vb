Partial Class AccountAdmin_Controls_ctlMyProjects
    Inherits System.Web.UI.UserControl
    Public Event btnShowClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event GridViewRowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles G.RowCommand
        If e.CommandName = "Select" Then
            RaiseEvent GridViewRowCommand(sender, e)
        End If
    End Sub
    Public Sub DoRefresh()
        Me.G.DataBind()

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles g.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)

        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectName")) Then
                CType(e.Row.Cells(2).FindControl("HyperLink1"), HyperLink).Text = IIf(DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 35, Left(DataBinder.Eval(e.Row.DataItem, "ProjectName"), 33) & "..", DataBinder.Eval(e.Row.DataItem, "ProjectName"))
                If DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 35 Then
                    CType(e.Row.Cells(2).FindControl("HyperLink1"), HyperLink).ToolTip = DataBinder.Eval(e.Row.DataItem, "ProjectName")
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "PartyName")) Then
                CType(e.Row.Cells(3).FindControl("L4"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "PartyName").ToString.Length > 35, Left(DataBinder.Eval(e.Row.DataItem, "PartyName"), 33) & "..", DataBinder.Eval(e.Row.DataItem, "PartyName"))
                If DataBinder.Eval(e.Row.DataItem, "PartyName").ToString.Length > 35 Then
                    CType(e.Row.Cells(3).FindControl("L4"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "PartyName")
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectDescription")) Then
                CType(e.Row.Cells(4).FindControl("D"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "ProjectDescription").ToString.Length > 55, Left(DataBinder.Eval(e.Row.DataItem, "ProjectDescription"), 53) & "..", DataBinder.Eval(e.Row.DataItem, "ProjectDescription"))
                If DataBinder.Eval(e.Row.DataItem, "ProjectDescription").ToString.Length > 55 Then
                    CType(e.Row.Cells(4).FindControl("D"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "ProjectDescription")
                End If
            End If
            If AccountPagePermissionBLL.IsPageHasPermissionOfShowAllDataByPermission(37, 3) = True Then
                CType(e.Row.Cells(7).FindControl("H1"), HyperLink).Visible = True
            ElseIf AccountPagePermissionBLL.IsPageHasPermissionOfShowMyProjectsDataByPermission(37, 3) = True And DataBinder.Eval(e.Row.DataItem, "ProjectManagerEmployeeId") = DBUtilities.GetSessionAccountEmployeeId Then
                If DataBinder.Eval(e.Row.DataItem, "ProjectManagerEmployeeId") = DBUtilities.GetSessionAccountEmployeeId Then
                    CType(e.Row.Cells(7).FindControl("H1"), HyperLink).Visible = True
                End If
            ElseIf AccountPagePermissionBLL.IsPageHasPermissionOfShowMyTeamsDataByPermission(37, 3) = True And DataBinder.Eval(e.Row.DataItem, "LeaderEmployeeId") = DBUtilities.GetSessionAccountEmployeeId Then
                If DataBinder.Eval(e.Row.DataItem, "LeaderEmployeeId") = DBUtilities.GetSessionAccountEmployeeId Then
                    CType(e.Row.Cells(7).FindControl("H1"), HyperLink).Visible = True
                End If
            ElseIf AccountPagePermissionBLL.IsPageHasPermissionOfShowMyDataByPermission(37, 3) = True Then
                CType(e.Row.Cells(7).FindControl("H1"), HyperLink).Visible = True
            End If

            'If AccountPagePermissionBLL.IsPageHasPermissionOf(37, 3) = True Then
            '    CType(e.Row.Cells(7).FindControl("H1"), HyperLink).Visible = True
            'Else
            '    CType(e.Row.Cells(7).FindControl("H1"), HyperLink).Visible = False
            'End If
            If AccountPagePermissionBLL.IsPageHasPermissionOf(32, 1) = False Then
                Me.G.Columns(7).Visible = False
            Else
                Me.G.Columns(7).Visible = True
            End If
            ''For Gantt Permission and Feature Select Project Management
            If DBUtilities.IsProjectManagementFeature = True Then
                If AccountPagePermissionBLL.IsPageHasPermissionOf(32, 1) = True Then
                    Me.G.Columns(6).Visible = True
                Else
                    Me.G.Columns(6).Visible = False
                End If
            Else
                Me.G.Columns(6).Visible = False
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectCode")) Then
                If IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectPrefix")) Then
                    CType(e.Row.Cells(1).FindControl("L2"), Label).Text = DataBinder.Eval(e.Row.DataItem, "ProjectCode")
                Else
                    CType(e.Row.Cells(1).FindControl("L2"), Label).Text = DataBinder.Eval(e.Row.DataItem, "ProjectPrefix") & IIf(DataBinder.Eval(e.Row.DataItem, "ProjectPrefix") = "", "", "-") & DataBinder.Eval(e.Row.DataItem, "ProjectCode")
                End If
            End If

        End If
    End Sub
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountPagePermissionBLL.SetPagePermissionForGridView(27, Me.G, Nothing, Nothing)

    End Sub
    Dim FilterBLL As New AccountFilterModuleBLL
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            FilterBLL.InsertFilterDefaultValues(Me, Me.Page)
            FilterBLL.GetFilterModuleForNonGridViewObject(Me, Me.Page)
            If ddlCompletedStatus.SelectedValue Is Nothing Then
                Me.dsAccountProjectObject.SelectParameters("Completed").DefaultValue = "0"
                Me.ddlCompletedStatus.SelectedValue = 0
            Else
                Me.dsAccountProjectObject.SelectParameters("Completed").DefaultValue = Me.ddlCompletedStatus.SelectedValue
            End If
            If ddlProjectStatus.SelectedValue Is Nothing Then
                Me.dsAccountProjectObject.SelectParameters("ProjectStatusId").DefaultValue = "0"
                Me.ddlProjectStatus.SelectedValue = 0
            Else
                Me.dsAccountProjectObject.SelectParameters("ProjectStatusId").DefaultValue = Me.ddlProjectStatus.SelectedValue
            End If
            Me.dsAccountProjectObject.SelectParameters("Disabled").DefaultValue = "-1"
            Me.dsAccountProjectObject.SelectParameters("AccountClientId").DefaultValue = Me.ddlAccountClientId.SelectedValue
            Me.dsAccountProjectObject.SelectParameters("AccountProjectId").DefaultValue = Nothing
            Me.dsAccountProjectObject.SelectParameters("ProjectCode").DefaultValue = Me.txtProjectCode.Text
            'Dim CurrentPage As Object = Me.Parent.FindControl("CtlMyProjects1")
            If G.Rows.Count = 0 Then
                G.ShowHeaderWhenEmpty = True
                G.EmptyDataText = "There are no items to display."
                Me.G.DataBind()
            End If
            Me.G.DataBind()

        End If

    End Sub
    Protected Sub btnShow_Click(sender As Object, e As System.EventArgs) Handles btnShow.Click
        'Dim CurrentPage As Object = Me.Parent.FindControl("CtlMyProjects1")
        FilterBLL.InsertFilterModuleForNonGridViewObject(Me, Me.Page)
        'FilterBLL.GetFilterModuleForNonGridViewObject(Me, Me.Page)
        Me.dsAccountProjectObject.SelectParameters("Completed").DefaultValue = Me.ddlCompletedStatus.SelectedValue
        Me.dsAccountProjectObject.SelectParameters("ProjectStatusId").DefaultValue = Me.ddlProjectStatus.SelectedValue
        'Me.dsAccountProjectObject.SelectParameters("Disabled").DefaultValue = Me.ddlDisable.SelectedValue
        Me.dsAccountProjectObject.SelectParameters("AccountClientId").DefaultValue = Me.ddlAccountClientId.SelectedValue
        Me.dsAccountProjectObject.SelectParameters("AccountProjectId").DefaultValue = Nothing
        Me.dsAccountProjectObject.SelectParameters("ProjectCode").DefaultValue = Me.txtProjectCode.Text
        If G.Rows.Count = 0 Then
            G.ShowHeaderWhenEmpty = True
            G.EmptyDataText = "There are no items to display."
            Me.G.DataBind()
        End If
        Me.G.DataBind()
        'Response.Redirect(Request.RawUrl, False)
        RaiseEvent btnShowClick(sender, e)

    End Sub
    'Protected Function FindControlByID(ByRef childControl As Control, ByVal ID As String) As Control
    '    Dim ctrl As Control = childControl.FindControl(ID)
    '    If Not ctrl Is Nothing Then
    '        Return ctrl
    '    Else
    '        If Not childControl.Parent Is Nothing Then
    '            Return FindControlByID(childControl.Parent, ID)
    '        Else
    '            Return Nothing
    '        End If
    '    End If
    'End Function


End Class
