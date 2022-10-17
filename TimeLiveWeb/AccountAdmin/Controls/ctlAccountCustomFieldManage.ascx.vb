''' <summary>
''' AccountApprovalForm web user control
''' </summary>
''' <remarks></remarks>
Partial Class AccountAdmin_Controls_ctlAccountCustomFieldManage
    Inherits System.Web.UI.UserControl
    Dim ItemValue As String
    Dim MasterEntityTypeId As Object
    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        SetTextbox()
        If Not Me.Request.QueryString("MasterEntityTypeId") Is Nothing Then
            MasterEntityTypeId = Me.Request.QueryString("MasterEntityTypeId")
            Me.GetCurrentLabelText()
        End If

    End Sub
    Public Function GetCurrentLabelText() As Boolean
        If MasterEntityTypeId = "13dbff37-a092-4ae2-a919-775cbed0edc0" Then
            Me.GridView1.Caption = "Custom Field List for Project"
        ElseIf MasterEntityTypeId = "e448aed9-eab5-4cf7-a171-2a86be2bba9e" Then
            Me.GridView1.Caption = "Custom Field List for Client"
        ElseIf MasterEntityTypeId = "369ed0fb-d317-4244-9f20-b7d834521e2b" Then
            Me.GridView1.Caption = "Custom Field List for Timesheet"
        ElseIf MasterEntityTypeId = "3601ae9b-3f82-4c80-9574-751f9a124fa8" Then
            Me.GridView1.Caption = "Custom Field List for Employee"
        ElseIf MasterEntityTypeId = "a55df02b-fbfb-4873-b582-6968fbaee589" Then
            Me.GridView1.Caption = "Custom Field List for Expense Sheet"
        ElseIf MasterEntityTypeId = "c9a8f7f1-1b2d-48da-aae9-74f92892a896" Then
            Me.GridView1.Caption = "Custom Field List for Project Task"
        ElseIf MasterEntityTypeId = "756e4460-a713-4bee-b3f0-708fc5be21bd" Then
            Me.GridView1.Caption = "Custom Field List for Expense Entry"
        End If
    End Function
    Public Function SetTextbox() As Boolean
        SetUITextBoxForFormViewInsertTemplate()
    End Function
    Public Sub SetUITextBoxForFormViewInsertTemplate()
        Dim CustomDataTypeId As Object
        CustomDataTypeId = CType(Me.FormView1.FindControl("ddlCustomDataType"), DropDownList).SelectedValue
        If CustomDataTypeId = "7e295184-9623-4445-b99f-48f07929dce5" Then
            CType(Me.FormView1.FindControl("MaximumLengthTextBox"), TextBox).Visible = True
            CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("MaximumValueTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Visible = True
            CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("ddlDefaultValue"), DropDownList).Visible = False
        ElseIf CustomDataTypeId = "5942a0be-e7fe-4abb-b96f-f0b20d744ce3" Then
            CType(Me.FormView1.FindControl("MaximumLengthTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("MaximumValueTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("ddlDefaultValue"), DropDownList).Visible = False
        ElseIf CustomDataTypeId = "574ded9c-7ad4-4649-8b39-d6741dd0ddca" Then
            CType(Me.FormView1.FindControl("MaximumLengthTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("MaximumValueTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Visible = True
            CType(Me.FormView1.FindControl("ddlDefaultValue"), DropDownList).Visible = True
        Else
            CType(Me.FormView1.FindControl("MaximumLengthTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Visible = True
            CType(Me.FormView1.FindControl("MaximumValueTextBox"), TextBox).Visible = True
            CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Visible = True
            CType(Me.FormView1.FindControl("ddlDefaultValue"), DropDownList).Visible = False
            CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Visible = False
        End If

    End Sub
    Protected Sub FormView1_DataBound(sender As Object, e As System.EventArgs) Handles FormView1.DataBound
        Dim CustomFieldBll As New AccountCustomFieldBLL
        AccountPagePermissionBLL.SetPagePermission(154, Me.GridView1, Me.FormView1, "Add", 5, 6)
        ''AccountPagePermissionBLL.SetPagePermissionForGridView(154, Me.GridView1, 5, 6)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            SetTextbox()
            Dim MasterEntityTypeId As New Guid(Me.Request.QueryString("MasterEntityTypeId"))
            Dim CheckCount = CustomFieldBll.GetDatabaseFieldName(MasterEntityTypeId, "CustomField1")
            If (MasterEntityTypeId.ToString = "369ed0fb-d317-4244-9f20-b7d834521e2b") And (CheckCount = "" Or CheckCount = "CustomField10") Then
                CType(Me.FormView1.FindControl("Add"), Button).Enabled = False
            End If
            If CheckCount = "" Then
                CType(Me.FormView1.FindControl("Add"), Button).Enabled = False
            End If
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            CType(Me.FormView1.FindControl("ddlCustomDataType"), DropDownList).Enabled = False
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If Not IsDBNull(Me.FormView1.DataItem("DropDownOptions")) Then
                Dim DropDownValue As String = Me.FormView1.DataItem("DropDownOptions")
                Dim SplitDropDownOption = Split(DropDownValue, "+")
                For Each arrayStr As String In SplitDropDownOption
                    Dim s As String = arrayStr
                    CType(Me.FormView1.FindControl("OptionListBox"), ListBox).Items.Add(arrayStr)
                    CType(Me.FormView1.FindControl("ddlDefaultValue"), DropDownList).Items.Add(arrayStr)
                Next
            End If
            If Not IsDBNull(Me.FormView1.DataItem("DefaultValue")) Then
                'Me.dsAccountCustomFieldManageForFormView.SelectParameters("DefaultValue").DefaultValue = Me.FormView1.DataItem("DefaultValue")
                CType(Me.FormView1.FindControl("ddlDefaultValue"), DropDownList).SelectedValue = Me.FormView1.DataItem("DefaultValue")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("MasterCustomDataTypeId")) Then
                Dim CustomDataTypeId = Convert.ToString(Me.FormView1.DataItem("MasterCustomDataTypeId"))
                If CustomDataTypeId = "574ded9c-7ad4-4649-8b39-d6741dd0ddca" Then
                    CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Visible = False
                    CType(Me.FormView1.FindControl("ddldefaultvalue"), DropDownList).Visible = True
                Else
                    CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Visible = True
                    CType(Me.FormView1.FindControl("ddldefaultvalue"), DropDownList).Visible = False
                End If
            End If
            SetTextbox()
        End If

    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim MasterEntityTypeId As New Guid(Me.Request.QueryString("MasterEntityTypeId"))
        Dim IsDataExist As Boolean = False
        If MasterEntityTypeId.ToString = "e448aed9-eab5-4cf7-a171-2a86be2bba9e" Then
            Dim dtclient As TimeLiveDataSet.AccountPartyDataTable = New AccountPartyBLL().GetAccountPartiesByAccountIdAndDatabaseFieldName(DBUtilities.GetSessionAccountId, Me.GridView1.DataKeys(e.RowIndex)("DatabaseFieldName"))
            If dtclient.Rows.Count > 0 Then
                IsDataExist = True
            End If
        ElseIf MasterEntityTypeId.ToString = "13dbff37-a092-4ae2-a919-775cbed0edc0" Then
            Dim dtproject As TimeLiveDataSet.AccountProjectDataTable = New AccountProjectBLL().GetAccountProjectsByAccountIdAndDatabaseFieldName(DBUtilities.GetSessionAccountId, Me.GridView1.DataKeys(e.RowIndex)("DatabaseFieldName"))
            If dtproject.Rows.Count > 0 Then
                IsDataExist = True
            End If
        ElseIf MasterEntityTypeId.ToString = "3601ae9b-3f82-4c80-9574-751f9a124fa8" Then
            Dim dtemployee As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountIdAndDatabaseFieldName(DBUtilities.GetSessionAccountId, Me.GridView1.DataKeys(e.RowIndex)("DatabaseFieldName"))
            If dtemployee.Rows.Count > 0 Then
                IsDataExist = True
            End If
        ElseIf MasterEntityTypeId.ToString = "c9a8f7f1-1b2d-48da-aae9-74f92892a896" Then
            Dim dtprojecttask As TimeLiveDataSet.AccountProjectTaskDataTable = New AccountProjectTaskBLL().GetAccountProjectTasksByAccountIdAndDatabaseFieldName(DBUtilities.GetSessionAccountId, Me.GridView1.DataKeys(e.RowIndex)("DatabaseFieldName"))
            If dtprojecttask.Rows.Count > 0 Then
                IsDataExist = True
            End If
        ElseIf MasterEntityTypeId.ToString = "a55df02b-fbfb-4873-b582-6968fbaee589" Then
            Dim dtexpensesheet As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = New AccountEmployeeExpenseSheetBLL().GetAccountEmployeeExpenseSheetByAccountIdAndDatabaseFieldName(DBUtilities.GetSessionAccountId, Me.GridView1.DataKeys(e.RowIndex)("DatabaseFieldName"))
            If dtexpensesheet.Rows.Count > 0 Then
                IsDataExist = True
            End If
        ElseIf MasterEntityTypeId.ToString = "756e4460-a713-4bee-b3f0-708fc5be21bd" Then
            Dim dtexpenseentry As TimeLiveDataSet.AccountExpenseEntryDataTable = New AccountExpenseEntryBLL().GetAccountExpenseEntriesByAccountIdAndDatabaseFieldName(DBUtilities.GetSessionAccountId, Me.GridView1.DataKeys(e.RowIndex)("DatabaseFieldName"))
            If dtexpenseentry.Rows.Count > 0 Then
                IsDataExist = True
            End If
        ElseIf MasterEntityTypeId.ToString = "369ed0fb-d317-4244-9f20-b7d834521e2b" Then
            Dim dttimesheet As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = New AccountEmployeeTimeEntryBLL().GetAccountEmployeeTimeEntriesByAccountIdAndDatabaseFieldName(DBUtilities.GetSessionAccountId, Me.GridView1.DataKeys(e.RowIndex)("DatabaseFieldName"))
            If dttimesheet.Rows.Count > 0 Then
                IsDataExist = True
            End If
        End If
        If IsDataExist = False Then
            Call New AccountCustomFieldBLL().DeleteAccountCustomField(Me.GridView1.DataKeys(e.RowIndex)("AccountCustomFieldId"), Me.GridView1.DataKeys(e.RowIndex)("DatabaseFieldName"), MasterEntityTypeId)
            e.Cancel = True
            Response.Redirect("~/AccountAdmin/AccountCustomFieldManage.aspx?MasterEntityTypeId=" & Me.Request.QueryString("MasterEntityTypeId"), False)
        Else
            UIUtilities.ShowMessage("Cannot delete data because of existing dependent data.", Me.Page)
            e.Cancel = True
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub
    Protected Sub FormView1_ItemCommand(sender As Object, e As System.Web.UI.WebControls.FormViewCommandEventArgs)
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
            Me.GridView1.Visible = True
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub
    Protected Sub GridView1_RowDeleted(sender As Object, e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub
    Protected Sub dsAccountCustomFieldManageForFormView_Inserted(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountCustomFieldManageForFormView.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountCustomFieldManageForFormView_Inserting(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountCustomFieldManageForFormView.Inserting
        'If CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Text <= CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Text Then
        '    CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).ValidationGroup = "Insert"
        '    CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = True
        'End If
        Dim ListBoxItem As String = ""
        If CType(Me.FormView1.FindControl("ddlCustomDataType"), DropDownList).SelectedValue <> "574ded9c-7ad4-4649-8b39-d6741dd0ddca" Then
            e.InputParameters("DefaultValue") = CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Text
        Else
            Dim ListBox As ListBox = Me.FormView1.FindControl("OptionListBox")
            For Each Item As ListItem In ListBox.Items
                If ListBoxItem = "" Then
                    ListBoxItem = Item.Value
                Else
                    ListBoxItem = ListBoxItem + "+" + Item.Value
                End If
            Next
            e.InputParameters("DefaultValue") = CType(Me.FormView1.FindControl("ddldefaultvalue"), DropDownList).SelectedValue
            e.InputParameters("DropDownOptions") = ListBoxItem
        End If
    End Sub
    Protected Sub dsAccountCustomFieldManageForFormView_Updated(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountCustomFieldManageForFormView.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    Protected Sub ddlCustomDataType_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        'Dim CustomDataTypeId As system.Guid("574DED9C-7AD4-4649-8B39-D6741DD0DDCA"
        SetTextbox()
        If CType(Me.FormView1.FindControl("ddlCustomDataType"), DropDownList).SelectedValue = "574ded9c-7ad4-4649-8b39-d6741dd0ddca" Then
            CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Visible = False
            CType(Me.FormView1.FindControl("ddldefaultvalue"), DropDownList).Visible = True
        End If
    End Sub
    Protected Sub dsAccountCustomFieldManageForFormView_Updating(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountCustomFieldManageForFormView.Updating
        Dim ListBoxItem As String = ""
        If CType(Me.FormView1.FindControl("ddlCustomDataType"), DropDownList).SelectedValue <> "574ded9c-7ad4-4649-8b39-d6741dd0ddca" Then
            e.InputParameters("DefaultValue") = CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Text
        Else
            Dim ListBox As ListBox = Me.FormView1.FindControl("OptionListBox")
            For Each Item As ListItem In ListBox.Items
                If ListBoxItem = "" Then
                    ListBoxItem = Item.Value
                Else
                    ListBoxItem = ListBoxItem + "+" + Item.Value
                End If
            Next
            e.InputParameters("DefaultValue") = CType(Me.FormView1.FindControl("ddldefaultvalue"), DropDownList).SelectedValue
            e.InputParameters("DropDownOptions") = ListBoxItem
        End If
        e.InputParameters("MasterEntityTypeId") = Me.Request.QueryString("MasterEntityTypeId")
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs)
        AddListBoxItem()
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs)
        Me.UpdateListBoxItem()
    End Sub
    Protected Sub OptionListBox_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        Dim ListBoxSelectedItemName As String = ""
        Dim ListBox As ListBox = Me.FormView1.FindControl("OptionListBox")
        For Each Item As ListItem In ListBox.Items
            If Item.Selected = True Then
                ItemValue = Item.Value
                ListBoxSelectedItemName = Item.Value
                CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Text = Item.Value
            End If
        Next
    End Sub
    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs)
        DeleteListBoxItem()
    End Sub
    Protected Sub DeleteListBoxItem()
        Dim ListBoxSelectedItemName As String = ""
        Dim ListBox As ListBox = Me.FormView1.FindControl("OptionListBox")
        For Each Item As ListItem In ListBox.Items
            If Item.Selected = True Then
                ListBoxSelectedItemName = Item.Value
            End If
        Next
        CType(Me.FormView1.FindControl("OptionListBox"), ListBox).Items.Remove(ListBoxSelectedItemName)
        CType(Me.FormView1.FindControl("ddldefaultvalue"), DropDownList).Items.Remove(ListBoxSelectedItemName)
        CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Text = ""
    End Sub
    Protected Sub UpdateListBoxItem()
        Dim ListBoxSelectedItemName As String = ""
        Dim ListBox As ListBox = Me.FormView1.FindControl("OptionListBox")
        Dim OptionTextBox = CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Text
        For Each Item As ListItem In ListBox.Items
            If Item.Selected = True Then
                ListBoxSelectedItemName = Item.Value
            End If
        Next
        If OptionTextBox <> "" And ListBoxSelectedItemName <> "" Then
            If CheckNameInListBox() Then
                Exit Sub
            End If
            If OptionTextBox.Contains("+") Then
                ShowNotFoundMessage("Dropdown options cannot contain pluses")
                Exit Sub
            End If
            CType(Me.FormView1.FindControl("OptionListBox"), ListBox).Items.Remove(ListBoxSelectedItemName)
            CType(Me.FormView1.FindControl("ddldefaultvalue"), DropDownList).Items.Remove(ListBoxSelectedItemName)
            CType(Me.FormView1.FindControl("OptionListBox"), ListBox).Items.Add(OptionTextBox)
            CType(Me.FormView1.FindControl("ddldefaultvalue"), DropDownList).Items.Add(OptionTextBox)
            CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Text = ""
        End If
    End Sub
    Protected Sub AddListBoxItem()
        Dim Value As String = CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Text
        If Value <> "" Then
            If CheckNameInListBox() Then
                Exit Sub
            End If
            If Value.Contains("+") Then
                ShowNotFoundMessage("Dropdown options cannot contain pluses")
                Exit Sub
            End If
            CType(Me.FormView1.FindControl("OptionListBox"), ListBox).Items.Add(Value)
            CType(Me.FormView1.FindControl("ddldefaultvalue"), DropDownList).Items.Add(Value)
            CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Text = ""
        End If
    End Sub
    Public Sub ShowNotFoundMessage(strmsg As String)
        Dim strMessage As String = strmsg
        Dim strScript As String = "alert('" & strMessage & "'); "
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    Public Function CheckNameInListBox() As Boolean
        Dim ListBox As ListBox = Me.FormView1.FindControl("OptionListBox")
        Dim OptionTextBox = CType(Me.FormView1.FindControl("OptionTextBox"), TextBox).Text
        For Each Item As ListItem In ListBox.Items
            If Item.Value = OptionTextBox Then
                ShowNotFoundMessage("Option already exists")
                Return True
            End If
        Next
        Return False
    End Function
    Public Function CheckDefaultValueForNumber() As Boolean
        If CType(Me.FormView1.FindControl("ddlCustomDataType"), DropDownList).SelectedValue = "bacd6824-9011-4c30-864f-0899fefc004f" Then
            If CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Text <> "" Then
                If Double.TryParse(CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Text, 0) = False Then
                    UIUtilities.ShowMessage("Default Value must be in numeric.", Me.Page)
                    UIUtilities.SetFocus(CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox))
                    Return False
                End If
            End If
            If CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Text <> "" And CType(Me.FormView1.FindControl("MaximumValueTextBox"), TextBox).Text <> "" Then
                Dim MinValue As Double = CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Text
                Dim MaxValue As Double = CType(Me.FormView1.FindControl("MaximumValueTextBox"), TextBox).Text
                If MinValue > MaxValue Then
                    UIUtilities.ShowMessage("Minimum value cannot be larger than maximum value", Me.Page)
                    UIUtilities.SetFocus(CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox))
                    Return False
                End If
                If CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Text <> "" Then
                    Dim DefaultValue As Double = CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox).Text
                    If DefaultValue < MinValue Or DefaultValue > MaxValue Then
                        UIUtilities.ShowMessage("Default Value must be between " & MinValue & " to " & MaxValue, Me.Page)
                        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("DefaultValueTextBox"), TextBox))
                        Return False
                    End If
                End If
            ElseIf CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Text <> "" Or CType(Me.FormView1.FindControl("MaximumValueTextBox"), TextBox).Text <> "" Then
                If CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox).Text <> "" Then
                    UIUtilities.ShowMessage("Please input Maximum Value", Me.Page)
                    UIUtilities.SetFocus(CType(Me.FormView1.FindControl("MaximumValueTextBox"), TextBox))
                    Return False
                Else
                    UIUtilities.ShowMessage("Please input Minimum Value", Me.Page)
                    UIUtilities.SetFocus(CType(Me.FormView1.FindControl("MinimumValueTextBox"), TextBox))
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Protected Sub FormView1_ItemInserting(sender As Object, e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        If Not CheckDefaultValueForNumber() Then
            e.Cancel = True
        End If
    End Sub

    Protected Sub FormView1_ItemUpdating(sender As Object, e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        If Not CheckDefaultValueForNumber() Then
            e.Cancel = True
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/AccountAdmin/AccountCustomField.aspx", False)
    End Sub
End Class
