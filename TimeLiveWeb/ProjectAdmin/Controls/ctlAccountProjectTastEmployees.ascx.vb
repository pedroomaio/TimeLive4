
Partial Class ProjectAdmin_Controls_ctlAccountProjectTastEmployees
    Inherits System.Web.UI.UserControl
    Dim IsEmployeeUpdate As Boolean

    Private Property AccountPagePermissionBLL As Object
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AccountPagePermissionBLL.SetPagePermissionForGridViewAndButton(158, Me.GridView1, Me.Update)
        If Not Me.IsPostBack Then
            If Me.Request.QueryString("Selected") = "False" Then
                Me.chkIsSelected.Checked = "False"
                Update.Visible = True
                'btnAddSelectedEmployees.Visible = True
                btnCancel.Visible = True
                btnAddEmployeesinTask.Visible = False
            Else
                Me.chkIsSelected.Checked = "True"
                Update.Visible = True
                'btnAddSelectedEmployees.Visible = False
                btnCancel.Visible = False
                btnAddEmployeesinTask.Visible = True
                Dim dt As TimeLiveDataSet.vueAccountProjectTaskEmployeeForTaskTeamDataTable = New AccountProjectTaskEmployeeBLL().GetAssignedAccountProjectTaskEmployees(Me.Request.QueryString("AccountProjectId"), Me.Request.QueryString("AccountProjectTaskId"), True)
                If dt.Rows.Count <= 1 Then
                    If dt.Rows.Count <> DataControlRowType.DataRow Then
                        GridView1.EmptyDataText = ResourceHelper.GetFromResource("No employee selected")
                    End If
                End If
            End If
        End If
        TaskInformation()
    End Sub
    Public Sub TaskInformation()
        txtTaskId.Text = CType(New AccountProjectTaskBLL().GetAccountProjectTasksByAccountProjectTaskId(Me.Request.QueryString("AccountProjectTaskId")).Rows(0), TimeLiveDataSet.AccountProjectTaskRow).AccountProjectTaskId
        Dim AccountProjectTaskBLL As New AccountProjectTaskBLL
        Dim dt As TimeLiveDataSet.AccountProjectTaskDataTable = AccountProjectTaskBLL.GetAccountProjectTasksByAccountProjectTaskId(Me.Request.QueryString("AccountProjectTaskId"))
        Dim dr As TimeLiveDataSet.AccountProjectTaskRow = dt.Rows(0)
        If Not IsDBNull(dr("TaskCode")) Then
            txtTaskCode.Text = CType(New AccountProjectTaskBLL().GetAccountProjectTasksByAccountProjectTaskId(Me.Request.QueryString("AccountProjectTaskId")).Rows(0), TimeLiveDataSet.AccountProjectTaskRow).TaskCode
        Else
            txtTaskCode.Text = ""
        End If
        txtTaskName.Text = CType(New AccountProjectTaskBLL().GetAccountProjectTasksByAccountProjectTaskId(Me.Request.QueryString("AccountProjectTaskId")).Rows(0), TimeLiveDataSet.AccountProjectTaskRow).TaskName
    End Sub
    Protected Sub Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.Click
        Me.UpdateTaskEmployees()
    End Sub
    Protected Sub btnAddSelectedEmployees_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.UpdateTaskEmployees()

        Me.chkIsSelected.Checked = True
        Update.Visible = True
        btnAddEmployeesinTask.Visible = True
        'btnAddSelectedEmployees.Visible = False
        btnCancel.Visible = False
        TaskEmployees()
    End Sub
    ''' <summary>
    ''' Update Task Employees record.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateTaskEmployees(Optional ByVal IsPageIndex As Boolean = False)
        Dim row As GridViewRow
        Dim objAccountProjectTaskEmployee As New AccountProjectTaskEmployeeBLL

        For Each row In Me.GridView1.Rows
            If CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                objAccountProjectTaskEmployee.AddAccountProjectTaskEmployee(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), Me.Request.QueryString("AccountProjectTaskId"), Me.GridView1.DataKeys(row.RowIndex).Item(3), 0)
            Else
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = False And Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    objAccountProjectTaskEmployee.DeleteAccountProjectTaskEmployeeId(Me.GridView1.DataKeys(row.RowIndex).Item(0))
                End If
            End If
        Next
        If IsPageIndex <> True Then
            ''Me.GridView1.DataBind()
            If Me.Request.QueryString("Source") = "MyTasks" Then
                Response.Redirect("~/Employee/MyTasks.aspx", False)
            Else
                Response.Redirect("~/ProjectAdmin/AccountProjectTasks.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId"), False)
            End If
        End If
    End Sub
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        'TODO: CheckAll function
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array

        'Get the header CheckBox
        If Me.GridView1.Rows.Count <> 0 Then
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
    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.UpdateTaskEmployees(True)
        Me.GridView1.PageIndex = e.NewPageIndex
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TaskName")) Then
                CType(e.Row.Cells(2).FindControl("Label130"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "TaskName").ToString.Length > 60, Left(DataBinder.Eval(e.Row.DataItem, "TaskName"), 58) & "..", DataBinder.Eval(e.Row.DataItem, "TaskName"))
                If DataBinder.Eval(e.Row.DataItem, "TaskName").ToString.Length > 60 Then
                    CType(e.Row.Cells(2).FindControl("Label130"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "TaskName")
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectName")) Then
                CType(e.Row.Cells(1).FindControl("Label30"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 60, Left(DataBinder.Eval(e.Row.DataItem, "ProjectName"), 58) & "..", DataBinder.Eval(e.Row.DataItem, "ProjectName"))
                If DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 60 Then
                    CType(e.Row.Cells(1).FindControl("Label30"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "ProjectName")
                End If
            End If
        End If
    End Sub
    Protected Sub chkIsSelected_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkIsSelected.CheckedChanged
        TaskEmployees()
    End Sub
    Protected Sub btnAddEmployeesinTask_Click1(sender As Object, e As System.EventArgs)
        Me.chkIsSelected.Checked = False
        Update.Visible = False
        btnAddEmployeesinTask.Visible = False
        'btnAddSelectedEmployees.Visible = True
        btnCancel.Visible = True
        TaskEmployees()
    End Sub
    Protected Sub btnCancel_Click1(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Me.chkIsSelected.Checked = True
        TaskEmployees()
    End Sub
    Public Sub TaskEmployees()
        If chkIsSelected.Checked = False Then
            If Me.Request.QueryString("Source") = "MyTasks" Then
                Response.Redirect("~/ProjectAdmin/AccountProjectTaskEmployees.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "&AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Source=MyTasks&Selected=False", False)
            Else
                Response.Redirect("~/ProjectAdmin/AccountProjectTaskEmployees.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "&AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Selected=False", False)
            End If
        Else
            If Me.Request.QueryString("Source") = "MyTasks" Then
                Response.Redirect("~/ProjectAdmin/AccountProjectTaskEmployees.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "&AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Source=MyTasks&Selected=True", False)
            Else
                Response.Redirect("~/ProjectAdmin/AccountProjectTaskEmployees.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "&AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Selected=True", False)
            End If
        End If
    End Sub
End Class