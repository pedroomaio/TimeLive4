
Partial Class AccountAdmin_Controls_ctlAccountTimesheetPeriodTypeList
    Inherits System.Web.UI.UserControl

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermissionForGridViewAndEdit(136, Me.GridView1, 3)
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If Not IsDBNull(Me.FormView1.DataItem("SystemInitialDaysOfThePeriodId")) Then
                CType(Me.FormView1.FindControl("ddlInitialDaysOfThePeriod"), DropDownList).SelectedValue = Me.FormView1.DataItem("SystemInitialDaysOfThePeriodId")
            End If
        End If
        Me.SetUI()
    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub

    Protected Sub ddlTimesheetPeriodType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.SetUI()
    End Sub

    Protected Sub dsAccountTimesheetPeriodTypeFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTimesheetPeriodTypeFormViewObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountTimesheetPeriodTypeFormViewObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountTimesheetPeriodTypeFormViewObject.Inserting
        DBUtilities.SetRowForInserting(e)
        Me.SetValueForDataInserting()
    End Sub
    Public Sub SetUI()
        Dim ddlTimesheetPeriodType As DropDownList = CType(Me.FormView1.FindControl("ddlTimesheetPeriodType"), DropDownList)
        Dim ddlInitialDaysOfThePeriod As DropDownList = CType(Me.FormView1.FindControl("ddlInitialDaysOfThePeriod"), DropDownList)
        Dim txtInitialDayOfTheMonth As TextBox = CType(Me.FormView1.FindControl("txtInitialDayOfTheMonth"), TextBox)
        If ddlTimesheetPeriodType.SelectedValue = 4 Then
            ddlInitialDaysOfThePeriod.Visible = True
        Else
            ddlInitialDaysOfThePeriod.Visible = False
        End If
        If ddlTimesheetPeriodType.SelectedValue = 5 Then
            txtInitialDayOfTheMonth.Visible = True
        Else
            txtInitialDayOfTheMonth.Visible = False
        End If
    End Sub
    Public Sub SetValueForDataInserting()
        'Dim ddlTimesheetPeriodType As DropDownList = CType(Me.FormView1.FindControl("ddlTimesheetPeriodType"), DropDownList)
        'Dim ddlInitialDaysOfThePeriod As DropDownList = CType(Me.FormView1.FindControl("ddlInitialDaysOfThePeriod"), DropDownList)
        'Dim txtInitialDayOfTheMonth As TextBox = CType(Me.FormView1.FindControl("txtInitialDayOfTheMonth"), TextBox)
        'If ddlTimesheetPeriodType.SelectedValue <> 4 Then
        '    ddlInitialDaysOfThePeriod.SelectedValue = 0
        'End If
        'If ddlTimesheetPeriodType.SelectedValue <> 5 Then
        '    txtInitialDayOfTheMonth.Text = 0
        'End If
    End Sub

    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If CType(Me.FormView1.FindControl("ddlInitialDaysOfThePeriod"), DropDownList).SelectedValue <> 0 Then
                dsAccountTimesheetPeriodTypeFormViewObject.UpdateParameters("SystemInitialDaysOfThePeriodId").DefaultValue = CType(Me.FormView1.FindControl("ddlInitialDaysOfThePeriod"), DropDownList).SelectedValue
            End If
        End If
    End Sub

    Protected Sub dsAccountTimesheetPeriodTypeFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountTimesheetPeriodTypeFormViewObject.Updated
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
End Class
