
Partial Class AccountAdmin_Controls_ctlAccountCurrencyExchangeRateList
    Inherits System.Web.UI.UserControl

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(105, Me.GridView1, Me.FormView1, "AddButton", 3, 4)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today
            CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today.AddYears(1)
        End If
    End Sub

    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub

    Protected Sub dsAccountCurrencyExchangeRateFormViewObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountCurrencyExchangeRateFormViewObject.Inserted
        Dim BLL As New AccountCurrencyExchangeRateBLL
        Dim dt As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = BLL.GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId(DBUtilities.GetSessionAccountId, Request.QueryString("AccountCurrencyId"))
        Dim dr As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate >= dr.ExchangeRateEffectiveEndDate Then
                Call New AccountCurrencyBLL().UpdateAccountCurrencyExchangeRateId(BLL.GetLastInsertedId, Request.QueryString("AccountCurrencyId"))
            End If
        End If
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub

    Protected Sub dsAccountCurrencyExchangeRateFormViewObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountCurrencyExchangeRateFormViewObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub

    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            e.Values.Item("AccountCurrencyId") = Me.Request.QueryString("AccountCurrencyId")
            e.Values.Item("ExchangeRateEffectiveStartDate") = CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            e.Values.Item("ExchangeRateEffectiveEndDate") = CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        End If
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        Dim BLL As New AccountCurrencyExchangeRateBLL
        Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL
        If CType(Me.FormView1.FindControl("chkUpdateExpenseEntry"), CheckBox).Checked = True Then
            BLL.UpdateExchangeRateOfExpenseEntry(CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text, Me.Request.QueryString("AccountCurrencyId"))
            TimeEntryBLL.UpdateBillingAndEmployeeRateExchangeRateOfTimeEntry(Me.Request.QueryString("AccountCurrencyId"), CType(Me.FormView1.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(Me.FormView1.FindControl("ExchangeRateTextBox"), TextBox).Text)
        End If
    End Sub

    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            e.NewValues.Item("AccountCurrencyId") = Me.Request.QueryString("AccountCurrencyId")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.GetCurrentBaseCurreny()
    End Sub
    Public Function GetCurrentBaseCurreny() As Boolean
        Dim dtAccountCurrency As AccountCurrency.vueAccountCurrencyDataTable = New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(Me.Request.QueryString("AccountCurrencyId"))
        Dim drAccountCurrency As AccountCurrency.vueAccountCurrencyRow

        If dtAccountCurrency.Rows.Count > 0 Then
            drAccountCurrency = dtAccountCurrency.Rows(0)
            lblBaseCurrency.Text = drAccountCurrency.CurrencyCode & " - " & drAccountCurrency.Currency
        End If
    End Function

    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
        If Not e.Exception Is Nothing Then
            If Not e.Exception.InnerException Is Nothing Then
                Throw New Exception(e.Exception.InnerException.Message)
            Else
                Throw New Exception(e.Exception.Message)
            End If
        End If
    End Sub
End Class
