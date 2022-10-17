
Partial Class AccountAdmin_Controls_ctlExternalUserList
    Inherits System.Web.UI.UserControl
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(92, Me.GridView1, Me.FormView1, "Add", 4, 5)
        'If Me.FormView1.CurrentMode = FormViewMode.Insert Then
        '    If Me.GridView1.Rows.Count >= LicensingBLL.GetNumberOfUsersAllowed(DBUtilities.GetSessionAccountId) Then
        '        CType(Me.FormView1.FindControl("ADD"), Button).Enabled = False
        '    End If
        'End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("ddlTimeZoneId"), DropDownList).SelectedValue = DBUtilities.GetTimeZoneId
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If Not IsDBNull(Me.FormView1.DataItem("ExternalUserClientId")) Then
                Me.dsClientObject.SelectParameters("AccountPartyId").DefaultValue = Me.FormView1.DataItem("ExternalUserClientId")
                CType(Me.FormView1.FindControl("ddlExternalUserClientId"), DropDownList).SelectedValue = Me.FormView1.DataItem("ExternalUserClientId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("TimeZoneId")) Then
                CType(Me.FormView1.FindControl("ddlTimeZoneId"), DropDownList).SelectedValue = Me.FormView1.DataItem("TimeZoneId")
            End If
            ''ddlPrefix
            If Not IsDBNull(Me.FormView1.DataItem("Prefix")) Then
                CType(Me.FormView1.FindControl("ddlPrefix"), DropDownList).SelectedValue = Me.FormView1.DataItem("Prefix")
            End If
        End If
        If DBUtilities.EnablePasswordComplexity = False Then
            CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = False
        Else
            CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = True
        End If
    End Sub


    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub

    Protected Sub dsAccountEmployeeList_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountEmployeeList.Inserting

    End Sub

    Protected Sub dsAccountEmployeeList_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountEmployeeList.Updating

    End Sub

    Protected Sub Update_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.dsAccountEmployeeObject.Update()
    End Sub



    Protected Sub ObjectDataSource1_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Inserted
        DBUtilities.AfterInsert(Me.GridView1)

        'Dim EmployeeBLL As New AccountEmployeeBLL
        'EmployeeBLL.SendNewEmployeeEMail(New AccountEmployeeBLL().GetLastInsertedId)

    End Sub

    Protected Sub ObjectDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub

    Protected Sub ObjectDataSource1_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    Protected Sub FormView1_ItemCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ItemCreated


    End Sub

    Protected Sub ObjectDataSource1_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

        End If


    End Sub

    Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        If Not e.Exception Is Nothing Then
            Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            lblExceptionText.Visible = True
            lblExceptionText.Text = e.Exception.InnerException.Message
            e.ExceptionHandled = True
            e.KeepInInsertMode = True

        Else

        End If

    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        If Not e.Exception Is Nothing Then
            Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            lblExceptionText.Visible = True
            lblExceptionText.Text = e.Exception.InnerException.Message
            e.ExceptionHandled = True
            e.KeepInEditMode = True

        Else

        End If
    End Sub

    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            e.NewValues.Item("ExternalUserClientId") = CType(Me.FormView1.FindControl("ddlExternalUserClientId"), DropDownList).SelectedValue
            e.NewValues.Item("TimeZoneId") = CType(Me.FormView1.FindControl("ddlTimeZoneId"), DropDownList).SelectedValue
        End If
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub

    Protected Sub Cancel_Click(sender As Object, e As System.EventArgs)
        Response.Redirect("~/AccountAdmin/AdminMain.aspx", False)
    End Sub
End Class
