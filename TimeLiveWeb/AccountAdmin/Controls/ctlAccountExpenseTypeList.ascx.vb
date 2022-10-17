
Partial Class AccountAdmin_Controls_ctlAccountExpenseTypeList
    Inherits System.Web.UI.UserControl

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub

    Protected Sub dsAccountExpenseTypeFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountExpenseTypeFormObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountExpenseTypeFormObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountExpenseTypeFormObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub

    Protected Sub dsAccountExpenseTypeFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountExpenseTypeFormObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub

    Protected Sub dsAccountExpenseTypeFormObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountExpenseTypeFormObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountPagePermissionBLL.SetPagePermission(6, Me.GridView1, Me.FormView1, "btnAdd", 3, 4)

        If FormView1.CurrentMode = FormViewMode.Edit Then
            If Me.GridView1.Rows.Count = 1 Then
                CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Enabled = False
            End If
        End If
       
    End Sub

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub

    Protected Sub FormView1_DataBound1(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.ShowDataForTaxCodeDropDown()
            If Not IsDBNull(Me.FormView1.DataItem("AccountTaxCodeId")) Then
                'dsAccountTaxCodeObject.SelectParameters("AccountTaxCodeId").DefaultValue = Me.FormView1.DataItem("AccountTaxCodeId")
                CType(Me.FormView1.FindControl("ddlAccountTaxCodeId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountTaxCodeId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("IsQuantityField")) Then
                CType(Me.FormView1.FindControl("CheckBox2"), CheckBox).Checked = Me.FormView1.DataItem("IsQuantityField")
            End If
            If CType(Me.FormView1.FindControl("CheckBox2"), CheckBox).Checked = True Then
                CType(Me.FormView1.FindControl("TextBox1"), TextBox).Enabled = True
            Else
                CType(Me.FormView1.FindControl("TextBox1"), TextBox).Enabled = False
            End If
        End If
        'If Me.FormView1.CurrentMode = FormViewMode.Insert Then
        '    If CType(Me.FormView1.FindControl("QuantityCheckBox"), CheckBox).Checked = True Then
        '        CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Enabled = True
        '    End If
        'End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            Me.ShowDataForTaxCodeDropDown()
        End If
        Me.lblTaxZone.Text = ResourceHelper.GetFromResource("Tax Zone:")
        ShowData()
        'Me.dsAccountTaxCodeObjectInsert.SelectParameters("AccountTaxZoneId").DefaultValue = Me.ddlAccountTaxZoneId.SelectedValue

    End Sub
    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        e.Values.Item("IsQuantityField") = CType(Me.FormView1.FindControl("QuantityCheckBox"), CheckBox).Checked
        e.Values.Item("AccountTaxCodeId") = CType(Me.FormView1.FindControl("ddlAccountTaxCodeId"), DropDownList).SelectedValue
        e.Values.Item("AccountTaxZoneId") = Me.ddlAccountTaxZoneId.SelectedValue
    End Sub

    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            e.NewValues("AccountTaxCodeId") = CType(Me.FormView1.FindControl("ddlAccountTaxCodeId"), DropDownList).SelectedValue
            e.NewValues("IsQuantityField") = CType(Me.FormView1.FindControl("CheckBox2"), CheckBox).Checked
            e.NewValues("AccountTaxZoneId") = Me.ddlAccountTaxZoneId.SelectedValue
        End If
    End Sub


    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If CType(Me.FormView1.FindControl("QuantityCheckBox"), CheckBox).Checked = True AndAlso CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text <> "" Then
            args.IsValid = True
        Else
            If CType(Me.FormView1.FindControl("QuantityCheckBox"), CheckBox).Checked = True AndAlso CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text = "" Then
                args.IsValid = False
            End If

        End If
    End Sub

    Protected Sub CustomValidator1_ServerValidate1(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If CType(Me.FormView1.FindControl("CheckBox2"), CheckBox).Checked = True AndAlso CType(Me.FormView1.FindControl("TextBox1"), TextBox).Text <> "" Then
            args.IsValid = True
        Else
            If CType(Me.FormView1.FindControl("CheckBox2"), CheckBox).Checked = True AndAlso CType(Me.FormView1.FindControl("TextBox1"), TextBox).Text = "" Then
                args.IsValid = False
            End If

        End If
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(Me.FormView1.FindControl("CheckBox2"), CheckBox).Checked = True Then
            CType(Me.FormView1.FindControl("TextBox1"), TextBox).Enabled = True
        Else
            CType(Me.FormView1.FindControl("TextBox1"), TextBox).Enabled = False
            CType(Me.FormView1.FindControl("TextBox1"), TextBox).Text = ""
        End If
    End Sub

    Protected Sub QuantityCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(Me.FormView1.FindControl("QuantityCheckBox"), CheckBox).Checked = True Then
            CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Enabled = True
        Else
            CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Enabled = False
        End If
    End Sub
    Public Sub ShowDataForTaxCodeDropDown()
        CType(Me.FormView1.FindControl("ddlAccountTaxCodeId"), DropDownList).Items.Clear()
        Dim item As New System.Web.UI.WebControls.ListItem
        item.Text = "<None>"
        item.Value = "0"
        CType(Me.FormView1.FindControl("ddlAccountTaxCodeId"), DropDownList).Items.Add(item)
        Me.dsAccountTaxCodeObject.SelectParameters("AccountTaxZoneId").DefaultValue = Me.ddlAccountTaxZoneId.SelectedValue
        CType(Me.FormView1.FindControl("ddlAccountTaxCodeId"), DropDownList).DataBind()
    End Sub

    Protected Sub ddlAccountTaxZoneId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ShowDataForTaxCodeDropDown()
        Me.ShowData()
    End Sub
    Public Sub ShowData()
        Me.dsAccountExpenseTypeObject.SelectParameters("AccountTaxZoneId").DefaultValue = Me.ddlAccountTaxZoneId.SelectedValue
        Me.dsAccountExpenseTypeFormObject.SelectParameters("AccountTaxZoneId").DefaultValue = Me.ddlAccountTaxZoneId.SelectedValue
        Me.GridView1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Me.IsPostBack = True Then
        '    ShowDataForTaxCodeDropDown()
        '    ShowData()
        'End If
        'Me.ShowDataForTaxCodeDropDown()
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If Me.GridView1.Rows.Count = 1 Then
            UIUtilities.ShowMessage("Can't Delete. One row is necessary.", Me.Page)
            e.Cancel = True
        End If
    End Sub
End Class
