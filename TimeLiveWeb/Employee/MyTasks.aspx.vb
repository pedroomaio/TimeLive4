
Partial Class Employee_frmMyTasks
    Inherits System.Web.UI.Page

    Public WithEvents dsTaskDataSource As ObjectDataSource

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.dsTaskDataSource = Me.CtlAccountProjectTaskForm1.FindControl("dsAccountProjectTaskFormObject")
      
    End Sub

    Protected Sub dsTaskDataSource_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsTaskDataSource.Inserted
        DBUtilities.AfterInsert(Me.CtlMyTasks1.FindControl("GridView1"))
        Me.CtlMyTasks1.RefreshData()
    End Sub

    Protected Sub dsTaskDataSource_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsTaskDataSource.Updated
        DBUtilities.AfterUpdate(Me.CtlMyTasks1.FindControl("GridView1"))
    End Sub
    Protected Sub CtlMyTasks1_AddClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlMyTasks1.btnAddTaskClick
        'Me.CtlAccountProjectTaskForm1.FindControl("FormView1").DataBind()
        Me.CtlAccountProjectTaskForm1.FindControl("FormView1").Visible = True
        Me.CtlMyTasks1.FindControl("CollapsablePanelSearch").Visible = False
        Me.CtlMyTasks1.FindControl("GridView1").Visible = False
        If Me.CtlMyTasks1.FindControl("GridView1").Visible = True Then
            Master.SetFilterFromMasterPage()
        Else
            Master.HideFilterFromMasterPage()
        End If
    End Sub
    Protected Sub CtlAccountProjectTaskForm1_AddClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectTaskForm1.AddClick
        Me.CtlAccountProjectTaskForm1.FindControl("FormView1").Visible = False
        Me.CtlMyTasks1.FindControl("CollapsablePanelSearch").Visible = True
        Me.CtlMyTasks1.FindControl("btnAddTask").Visible = True
        Me.CtlMyTasks1.FindControl("GridView1").Visible = True
    End Sub
    Protected Sub CtlAccountProjectTaskForm1_CancelClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectTaskForm1.btnCancelClick
        Me.CtlAccountProjectTaskForm1.FindControl("FormView1").Visible = False
        Me.CtlMyTasks1.FindControl("CollapsablePanelSearch").Visible = True
        Me.CtlMyTasks1.FindControl("btnAddTask").Visible = True
        Me.CtlMyTasks1.FindControl("GridView1").Visible = True
        'Response.Redirect("~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId"))
    End Sub
    Protected Sub CtlMyTasks1_btnShowClick(sender As Object, e As System.EventArgs) Handles CtlMyTasks1.btnShowClick
        Master.SetFilterFromMasterPage()
    End Sub
    Protected Sub CtlAccountProjectTaskForm1_ddlAccountProjectId(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtlAccountProjectTaskForm1.SelectIndexChanged
        Me.CtlAccountProjectTaskForm1.FindControl("FormView1").Visible = True
        Me.CtlMyTasks1.FindControl("CollapsablePanelSearch").Visible = False
        Me.CtlMyTasks1.FindControl("btnAddTask").Visible = False
        Me.CtlMyTasks1.FindControl("GridView1").Visible = False
        'Response.Redirect("~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId"))
    End Sub
End Class
