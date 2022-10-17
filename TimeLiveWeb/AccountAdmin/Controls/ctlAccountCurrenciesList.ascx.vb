
Partial Class AccountAdmin_Controls_ctlAccountCurrenciesList
    Inherits System.Web.UI.UserControl
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub
    Protected Sub dsAccountCurrencyFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountCurrencyFormViewObject.Inserted
        Dim ObjAccountCurrencyBLL As New AccountCurrencyBLL
        If Not CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text = "" Then
            ObjAccountCurrencyBLL.AddAccountCurrencyForExchangeRate(CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text, Date.Today, Date.Today.AddYears(1))
        End If
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
    Protected Sub dsAccountCurrencyFormViewObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountCurrencyFormViewObject.Inserting
    End Sub

    Protected Sub dsAccountCurrencyFormViewObject_Load(sender As Object, e As System.EventArgs) Handles dsAccountCurrencyFormViewObject.Load

    End Sub
    Protected Sub dsAccountCurrencyFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountCurrencyFormViewObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(104, Me.GridView1, Me.FormView1, "InsertButton", 4, 5)
        Me.HyperLink3.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(104, 3)
        Me.HyperLink2.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(104, 3)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text = 0
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Dim ObjAccountCurrencyBLL As New AccountCurrencyBLL
            Dim dt As AccountCurrency.vueAccountCurrencyDataTable = ObjAccountCurrencyBLL.GetvueAccountCurrencyByAccountCurrencyId(Me.FormView1.DataKey("AccountCurrencyId"))
            Dim dr As AccountCurrency.vueAccountCurrencyRow = dt.Rows(0)
            If Not IsDBNull(dr("ExchangeRate")) Then
                CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text = CType(New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(Me.FormView1.DataKey("AccountCurrencyId")).Rows(0), AccountCurrency.vueAccountCurrencyRow).ExchangeRate
            Else
                CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text = 0
            End If
            If Me.FormView1.DataKey("AccountCurrencyId") = DBUtilities.GetAccountBaseCurrencyId And CType(Me.FormView1.FindControl("DisabledCheckBox"), CheckBox).Checked = False Then
                CType(Me.FormView1.FindControl("DisabledCheckBox"), CheckBox).Enabled = False
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub
    Protected Sub dsAccountCurrencyFormViewObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountCurrencyFormViewObject.Updating
        Dim ObjAccountCurrencyBLL As New AccountCurrencyBLL
        Dim objAccountCurrencyExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        Dim dt As AccountCurrency.vueAccountCurrencyDataTable = ObjAccountCurrencyBLL.GetvueAccountCurrencyByAccountCurrencyId(Me.FormView1.DataKey("AccountCurrencyId"))
        Dim dr As AccountCurrency.vueAccountCurrencyRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                If IsDBNull(dr("ExchangeRate")) Then
                    objAccountCurrencyExchangeRateBLL.AddAccountCurrencyExchangeRate(Date.Today, Date.Today.AddYears(1), CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text, DBUtilities.GetSessionAccountId, (Me.FormView1.DataKey("AccountCurrencyId")))
                    ObjAccountCurrencyBLL.UpdateAccountCurrencyExchangeRateId(objAccountCurrencyExchangeRateBLL.GetLastInsertedId, Me.FormView1.DataKey("AccountCurrencyId"))
                    e.InputParameters("AccountCurrencyExchangeRateId") = objAccountCurrencyExchangeRateBLL.GetLastInsertedId
                ElseIf CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text = dr.ExchangeRate Then
                    objAccountCurrencyExchangeRateBLL.UpdateAccountCurrencyExchangeRate(Date.Today, Date.Today.AddYears(1), CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text, DBUtilities.GetSessionAccountId, dr.AccountCurrencyExchangeRateId, (Me.FormView1.DataKey("AccountCurrencyId")))
                    e.InputParameters("AccountCurrencyExchangeRateId") = dr.AccountCurrencyExchangeRateId
                ElseIf CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text <> dr.ExchangeRate Then
                    objAccountCurrencyExchangeRateBLL.AddAccountCurrencyExchangeRate(Date.Today, Date.Today.AddYears(1), CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text, DBUtilities.GetSessionAccountId, (Me.FormView1.DataKey("AccountCurrencyId")))
                    ObjAccountCurrencyBLL.UpdateAccountCurrencyExchangeRateId(objAccountCurrencyExchangeRateBLL.GetLastInsertedId, Me.FormView1.DataKey("AccountCurrencyId"))
                    e.InputParameters("AccountCurrencyExchangeRateId") = objAccountCurrencyExchangeRateBLL.GetLastInsertedId
                End If
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        If Not e.Exception Is Nothing Then
            Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            lblExceptionText.Visible = True
            lblExceptionText.Text = e.Exception.InnerException.Message
            e.ExceptionHandled = True
            e.KeepInInsertMode = True
        End If
    End Sub
    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
    End Sub
    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        If Not e.Exception Is Nothing Then
            Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            lblExceptionText.Visible = True
            lblExceptionText.Text = e.Exception.InnerException.Message
            e.ExceptionHandled = True
            e.KeepInEditMode = True
        End If
    End Sub
    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            e.NewValues.Item("Disabled") = CType(Me.FormView1.FindControl("DisabledCheckBox"), CheckBox).Checked
        End If
    End Sub
    Public Function GetCurrentBaseCurreny() As Boolean
        Dim dtAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = New AccountCurrencyExchangeRateBLL().GetvueAccountBaseCurrencyByAccountId(DBUtilities.GetSessionAccountId)
        Dim drAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow = dtAccountBaseCurrency.Rows(0)

        If dtAccountBaseCurrency.Rows.Count > 0 Then
            If Not IsDBNull(drAccountBaseCurrency("BaseCurrency")) Then
                Label3.Text = drAccountBaseCurrency.BaseCurrency
            End If
        End If
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.GetCurrentBaseCurreny()
    End Sub
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub
    Protected Sub NetAmountCustomValidatorEdit_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text > 0 Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub
    Protected Sub NetAmountCustomValidator_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text > 0 Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub
End Class
