
Partial Class AccountAdmin_Controls_ctlAccountPartyList
    Inherits System.Web.UI.UserControl
    Public Event EditClick(ByVal sender As Object, ByVal CommandArgs As GridViewCommandEventArgs)
    Public Event btnAddClientClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim MasterEntityTypeId As New Guid("e448aed9-eab5-4cf7-a171-2a86be2bba9e")
    Dim CustomFieldCaption As String
    Dim inserttemp As Guid
    Protected Sub GridView1_PageIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.PageIndexChanged

    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            Me.FormView2.ChangeMode(FormViewMode.Edit)
            Dim AccountClientId = Me.GridView1.DataKeys(0)
            Me.FormView1.DataBind()
            RaiseEvent EditClick(sender, e)
            ''Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub dsAccountPartyObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountPartyObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub
    Protected Sub dsAccountPartyObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountPartyObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(8, Me.GridView1, Me.FormView1, "Add", 5, 6)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            'CType(Me.FormView1.FindControl("ddlCountryId"), DropDownList).SelectedValue = DBUtilities.GetAccountCountryId
            '''''Me.Literal21.Text = ResourceHelper.GetFromResource("Client Name:")
            Me.FormView1.Visible = False
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            'If Not IsDBNull(Me.FormView1.DataItem("FixedBidBillingMode")) Then
            'CType(Me.FormView1.FindControl("ddlFixedBidBillingMode"), CheckBox).Checked = Me.FormView1.DataItem("FixedBidBillingMode")
            'End If
            'If Not IsDBNull(Me.FormView1.DataItem("FixedCost")) Then
            '   CType(Me.FormView1.FindControl("txtFixedBidCost"), CheckBox).Checked = Me.FormView1.DataItem("FixedCost")
            'End If
            Me.FormView1.Width = Unit.Percentage(85)
            AccountCustomFieldBLL.SetCustomValuesForFormView_DataBound(FormView1)
            Me.FormView1.Visible = True
            Me.GridView1.Visible = False
            Me.btnAdd.Visible = False
            Me.btnDeleteSelectedItem.Visible = False
        End If
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
            Me.GridView1.Visible = True
        End If
    End Sub
    Protected Sub dsAccountPartyForm_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountPartyForm.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
    Protected Sub dsAccountPartyForm_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountPartyForm.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)

        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not Me.Request.QueryString("AccountPartyId") Is Nothing Then


                If DataBinder.Eval(e.Row.DataItem, "AccountPartyId") = New AccountPartyBLL().GetLastInsertedPartyId Then
                    Dim lastRowIndex = e.Row.RowIndex
                    Dim integ As Integer
                    Dim fract As Decimal
                    e.Row.BackColor = Color.SteelBlue
                    e.Row.Cells(0).ForeColor = Color.White
                    e.Row.Cells(1).ForeColor = Color.White
                    e.Row.Cells(2).ForeColor = Color.White
                    e.Row.Cells(3).ForeColor = Color.White
                    e.Row.Cells(4).ForeColor = Color.White
                    Dim ClientContact As HyperLink = e.Row.FindControl("HyperLink1")
                    Dim ClientDepartment As HyperLink = e.Row.FindControl("HyperLink2")
                    ClientContact.ForeColor = Color.White
                    ClientDepartment.ForeColor = Color.White
                End If
            End If
        End If
    End Sub
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub
    Protected Sub dsAccountPartyForm_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountPartyForm.Updating

    End Sub
    Protected Sub Add_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.FormView1.Visible = False
        'Me.GridView1.Visible = True
        'Me.btnAdd.Visible = True
        'Me.btnDeleteSelectedItem.Visible = True
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.FormView1.DataBind()
        Me.GridView1.Visible = False
        Me.btnAdd.Visible = False
        Me.FormView1.Visible = True
        Me.btnDeleteSelectedItem.Visible = False
        RaiseEvent btnAddClientClick(sender, e)
    End Sub
    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.Visible = False
        Me.GridView1.Visible = True
        Me.btnAdd.Visible = True
        Me.btnDeleteSelectedItem.Visible = True
        Response.Redirect("~/AccountAdmin/AccountParties.aspx", False)
    End Sub
    Protected Sub Update_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ''AccountPagePermissionBLL.SetPagePermission(8, Me.GridView1, Me.FormView1, "Add", 5, 6)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccountPagePermissionBLL.SetPagePermission(8, Me.GridView1, Me.FormView1, "Add", 5, 6)
        btnDeleteSelectedItem.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(8, 4)
        If AccountPagePermissionBLL.IsPageHasPermissionOf(8, 4) = False Then
            Me.GridView1.Columns(10).Visible = False
        End If

        Me.btnAdd.Text = ResourceHelper.GetFromResource("Add")
        'Dim ist = Me.Request.QueryString("AccountPartyId")
        If Not Me.IsPostBack Then
            If Not Me.Request.QueryString("AccountPartyId") Is Nothing Then
                Me.GridView1.DataBind()
                GridView1.PageIndex = GridView1.PageCount
                Session.Item("IsInsert") = 0
            Else
                Session.Item("IsInsert") = 0
            End If
        End If
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.Visible = False
        Me.GridView1.Visible = True
        Me.btnAdd.Visible = True
        Me.btnDeleteSelectedItem.Visible = True
        Response.Redirect("~/AccountAdmin/AccountParties.aspx", False)
    End Sub
    Protected Sub FormView1_Init(ByVal sender As Object, ByVal e As System.EventArgs)
        'AccountPagePermissionBLL.SetPagePermission(8, Me.GridView1, Me.FormView1, "Add", 5, 6)
    End Sub
    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        Me.dsAccountPartyForm.InsertParameters("CountryId").DefaultValue = DBUtilities.GetAccountCountryId
        Me.dsAccountPartyForm.InsertParameters("PartyNick").DefaultValue = " "
        For n As Integer = 1 To 15
            AccountCustomFieldBLL.SetCustomValuesForFormView_Inserting(FormView1, e, MasterEntityTypeId, "CustomField" & n)
            If e.Cancel = True Then
                Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
            End If
        Next
    End Sub
    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        'Me.FormView1.Visible = False
        Me.GridView1.Visible = True
        Me.btnAdd.Visible = True
        Me.btnDeleteSelectedItem.Visible = True
    End Sub

    Public Shared Function GetGridViewIndexFromDataKey(TheGridView As GridView, DataKeyToFind As Int32, IsRecord As Boolean, isrecord1 As Integer) As Integer
        'Lets go through the Gridview and select the proper row.
        Dim indexCount As Integer = 0

        For Each key As DataKey In TheGridView.DataKeys

            'Check if the value matches.
            If CInt(key.Value) = DataKeyToFind Then
                ' Looks like we found the right row. Lets get it's index.
                IsRecord = True
                Return TheGridView.Rows(indexCount).DataItemIndex
            End If
            'Didn't find.. keep going.
            indexCount += 1

        Next
        'Could not find.

        Return 0
    End Function
    Protected Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        'TODO: CheckAll function
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array

        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If Me.GridView1.DataKeys(row.RowIndex).Item(0) <> 0 Then
                ''btnDeleteSelectedItem.Visible = True
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

    End Sub
    Protected Sub btnDeleteSelectedItem_Click(sender As Object, e As System.EventArgs) Handles btnDeleteSelectedItem.Click
        Dim row As GridViewRow
        Dim Original_AccountClientId As Integer
        For Each row In Me.GridView1.Rows
            If Me.GridView1.DataKeys(row.RowIndex)(0) <> 0 Then
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = True Then
                    Original_AccountClientId = Me.GridView1.DataKeys(row.RowIndex)(0)
                    Dim BLL As New AccountPartyBLL
                    Original_AccountClientId = New AccountPartyBLL().DeleteAccountParty(Original_AccountClientId)
                End If
            End If
        Next
        Me.GridView1.DataBind()
    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

    End Sub
    Protected Sub FormView1_ItemCreated(sender As Object, e As System.EventArgs) Handles FormView1.ItemCreated
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            AccountCustomFieldBLL.CreateCustomFieldOnFormView_ItemCreated(FormView1, New Guid("e448aed9-eab5-4cf7-a171-2a86be2bba9e"), , , "26px", , )
        End If
    End Sub
    Protected Sub FormView1_ItemInserted(sender As Object, e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        Me.FormView1.Visible = False
        Me.GridView1.Visible = True
        Me.btnAdd.Visible = True
        Me.btnDeleteSelectedItem.Visible = True
    End Sub
    Protected Sub FormView1_ItemUpdating(sender As Object, e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        For n As Integer = 1 To 15
            AccountCustomFieldBLL.SetCustomValuesForFormView_Updating(FormView1, e, MasterEntityTypeId, "CustomField" & n)
            If e.Cancel = True Then
                Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
            End If
        Next
        e.NewValues("FixedCost") = 0
    End Sub

    Protected Sub btnOkay_Click(sender As Object, e As System.EventArgs)
        Dim CustomFieldBLL As New AccountCustomFieldBLL
        Dim ClientBLL As New AccountPartyBLL
        Dim ErrorMessage As String = ""

        For n As Integer = 1 To 15
            Dim UIObject As Object = Me.FormView2.FindControl("CustomTable").FindControl("CustomField" & n)
            If Not UIObject Is Nothing Then
                If TypeOf UIObject Is DropDownList Then
                    Me.ViewState.Add("CustomField" & n, UIObject.SelectedValue)
                ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
                    Me.ViewState.Add("CustomField" & n, UIObject.SelectedDate)
                ElseIf TypeOf UIObject Is TextBox Then
                    Me.ViewState.Add("CustomField" & n, UIObject.Text)
                End If
                If Me.ViewState("CustomField" & n).ToString = "" Or Me.ViewState("CustomField" & n).ToString = "None" Then
                    If AccountCustomFieldBLL.CheckIsRequiredCustomField("CustomField" & n, New Guid("e448aed9-eab5-4cf7-a171-2a86be2bba9e")) Then
                        Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                        CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                        UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
                        Me.ModalPopupExtender2.Show()
                    End If
                End If
            End If
        Next
        If ErrorMessage.ToString = "" Then
            If Session.Item("IsInsert") <> 1 Then
                ClientBLL.AddAccountParty(DBUtilities.GetSessionAccountId, PartyNameTextBox.Text, " ", "", "", "", 233, "", "", "", "", "", "", 0, "", "", False, False, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId, 0, 0, False, Me.ViewState("CustomField1"), Me.ViewState("CustomField2"), Me.ViewState("CustomField3"), Me.ViewState("CustomField4"), Me.ViewState("CustomField5"), Me.ViewState("CustomField6"), Me.ViewState("CustomField7"), Me.ViewState("CustomField8"), Me.ViewState("CustomField9"), Me.ViewState("CustomField10"), Me.ViewState("CustomField11"), Me.ViewState("CustomField12"), Me.ViewState("CustomField13"), Me.ViewState("CustomField14"), Me.ViewState("CustomField15"))
                Session.Item("IsInsert") = 1
            End If
            Server.Transfer("~/AccountAdmin/AccountParties.aspx?AccountPartyId=" & ClientBLL.GetLastInsertedPartyId)
        End If
    End Sub

    Protected Sub FormView2_ItemCreated(sender As Object, e As System.EventArgs) Handles FormView2.ItemCreated
        If Me.FormView2.CurrentMode = FormViewMode.Insert Then
            Dim CustomFieldBLL As New AccountCustomFieldBLL
            Dim dtcustomfield As AccountCustomField.vueAccountCustomFieldManageDataTable = CustomFieldBLL.GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId(DBUtilities.GetSessionAccountId, New Guid("e448aed9-eab5-4cf7-a171-2a86be2bba9e"))
            If dtcustomfield.Rows.Count > 0 Then
                AccountCustomFieldBLL.CreateCustomFieldOnFormView_ItemCreated(FormView2, New Guid("e448aed9-eab5-4cf7-a171-2a86be2bba9e"), "25%", "75%", "26px", , True)
            Else
                Me.ModalPopupExtender2.FindControl("Panel2").FindControl("Tab2li").Visible = False
            End If
        End If
    End Sub

    Protected Sub FormView2_ItemInserting(sender As Object, e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView2.ItemInserting

    End Sub

    Protected Sub ModalPopupExtender2_DataBinding(sender As Object, e As System.EventArgs) Handles ModalPopupExtender2.DataBinding

    End Sub

    Protected Sub ModalPopupExtender2_Load(sender As Object, e As System.EventArgs) Handles ModalPopupExtender2.Load

    End Sub

    Protected Sub btnCancel_Click1(sender As Object, e As System.EventArgs) Handles btnCancel.Click

    End Sub

    Protected Sub GridView1_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        'e.Row.ForeColor = System.Drawing.Color.Red
        'e.Row.BackColor = System.Drawing.Color.AliceBlue
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging

    End Sub
End Class