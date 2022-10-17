
Partial Class AccountAdmin_frmAccountProjectTasks
    Inherits System.Web.UI.Page



    Protected Sub CtlAccountProjectTaskList1_EditClick1(ByVal sender As Object, ByVal CommandArgs As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles CtlAccountProjectTaskList1.EditClick
        Me.CtlAccountProjectTaskForm1.FindControl("FormView1").Visible = True
        Me.CtlAccountProjectTaskList1.FindControl("btnAddTask").Visible = False
        Me.CtlAccountProjectTaskList1.FindControl("GridView1").Visible = False
        Dim objGridView As GridView = Me.CtlAccountProjectTaskList1.FindControl("GridView1")

        Dim SelectedValue As Integer = objGridView.Rows(CommandArgs.CommandArgument).Cells(0).Text

        Dim objDataSource As ObjectDataSource = Me.CtlAccountProjectTaskForm1.FindControl("dsAccountProjectTaskFormObject")
        objDataSource.SelectParameters("AccountProjectTaskId").DefaultValue = SelectedValue

        Dim objFormView As FormView = Me.CtlAccountProjectTaskForm1.FindControl("FormView1")
        objFormView.ChangeMode(FormViewMode.Edit)

        'Dim objUpdatePanel As UpdatePanel = Me.CtlAccountProjectTaskForm1.FindControl("UpdatePanel2")
        'objUpdatePanel.Update()
        If Me.CtlAccountProjectTaskList1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If

    End Sub

    Protected Sub CtlAccountProjectTaskForm1_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles CtlAccountProjectTaskForm1.Inserted

        Dim objGridView As GridView = Me.CtlAccountProjectTaskList1.FindControl("GridView1")

        DBUtilities.AfterInsert(objGridView)

        'Dim objUpdatePanel As UpdatePanel = Me.CtlAccountProjectTaskList1.FindControl("UpdatePanel1")
        'objUpdatePanel.Update()

    End Sub

    Protected Sub CtlAccountProjectTaskForm1_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles CtlAccountProjectTaskForm1.Updated

        Dim objGridView As GridView = Me.CtlAccountProjectTaskList1.FindControl("GridView1")

        DBUtilities.AfterUpdate(objGridView)

        'Dim objUpdatePanel As UpdatePanel = Me.CtlAccountProjectTaskList1.FindControl("UpdatePanel1")
        'objUpdatePanel.Update()

    End Sub

    Protected Sub CtlAccountProjectTaskList1_GridViewRowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles CtlAccountProjectTaskList1.GridViewRowDeleted
        If Not e.Exception Is Nothing Then
            e.ExceptionHandled = True
            Dim strScript As String = "alert('" & "Cannot delete data because of existing dependent data." & "');"
            If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
            End If
        End If
    End Sub


    Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode

        If System.Web.HttpContext.Current.Request.QueryString("Source") = "MyProjects" Then
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(27)
        ElseIf System.Web.HttpContext.Current.Request.QueryString("Source") = "ProjectTemplates" Then
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(103, "~/ProjectAdmin/AccountProjectTemplates.aspx?IsTemplate=True")
        Else
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(31)
        End If

    End Function
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' The ExpandForumPaths method is called to handle
        ' the SiteMapResolve event.
        AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        RemoveHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
    Protected Sub CtlAccountProjectTaskList1_btnAddTaskClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectTaskList1.btnAddTaskClick
        'Me.CtlAccountProjectTaskForm1.FindControl("FormView1").DataBind()
        Me.CtlAccountProjectTaskForm1.FindControl("FormView1").Visible = True
        If Me.CtlAccountProjectTaskList1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
    Protected Sub CtlAccountProjectTaskForm1_btnCancelClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectTaskForm1.btnCancelClick
        Me.CtlAccountProjectTaskList1.FindControl("GridView1").Visible = True
        Me.CtlAccountProjectTaskList1.FindControl("btnAddTask").Visible = True
        Response.Redirect("~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId"), False)
    End Sub
    Protected Sub CtlAccountProjectTaskForm1_btnUpdateClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectTaskForm1.btnUpdateClick
        Me.CtlAccountProjectTaskList1.FindControl("GridView1").Visible = True
        Me.CtlAccountProjectTaskList1.FindControl("btnAddTask").Visible = True
        'Me.CtlAccountProjectTaskForm1.FindControl("FormView1").DataBind()
    End Sub
    Protected Sub CtlAccountProjectTaskForm1_btnAddClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectTaskForm1.AddClick
        Me.CtlAccountProjectTaskList1.FindControl("GridView1").Visible = True
        Me.CtlAccountProjectTaskList1.FindControl("btnAddTask").Visible = True
    End Sub
    ''UpdateIssueClick
    Protected Sub CtlAccountProjectTaskForm1_UpdateIssueClick(ByVal sender As Object) Handles CtlAccountProjectTaskForm1.UpdateIssueClick
        Me.CtlAccountProjectTaskList1.FindControl("GridView1").Visible = False
        Me.CtlAccountProjectTaskList1.FindControl("btnAddTask").Visible = False
    End Sub
End Class
