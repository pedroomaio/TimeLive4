''' <summary>
''' AccountBaseCurrency web form
''' </summary>
''' <remarks></remarks>
Partial Class AccountAdmin_AccountBaseCurrency
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' Updating exchange rate on update button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        Dim ExchangeRatedt As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateDataTable = ExchangeRateBLL.GetAccountCurrencyExchangeRatesByAccountIdAndAccountCurrencyId(DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("ddlAccountCurrencyId"), DropDownList).SelectedValue)
        Dim ExchangeRatedr As AccountCurrencyExchangeRate.AccountCurrencyExchangeRateRow
        If ExchangeRatedt.Rows.Count > 0 Then
            ExchangeRatedr = ExchangeRatedt.Rows(0)
            ExchangeRateBLL.UpdateExchangeRates(ExchangeRatedr.ExchangeRate, DBUtilities.GetSessionAccountId)
            ExchangeRateBLL.UpdateBaseCurrencyExchangeRate(ExchangeRatedr.AccountCurrencyExchangeRateId)
        End If
        Dim dt As AccountCurrency.vueAccountCurrencyDataTable = New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(CType(Me.FormView1.FindControl("ddlAccountCurrencyId"), DropDownList).SelectedValue)
        Dim dr As AccountCurrency.vueAccountCurrencyRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If CType(Me.FormView1.FindControl("CheckBox1"), CheckBox).Checked = True Then
                Call New AccountExpenseEntryBLL().UpdateAccountBaseCurrencyId(CType(Me.FormView1.FindControl("ddlAccountCurrencyId"), DropDownList).SelectedValue, dr.ExchangeRate, dr.AccountCurrencyId)
                Call New AccountBillingRateBLL().UpdateCurrenciesInBillngRate(dr.AccountCurrencyId, DBUtilities.GetSessionAccountId)
                Call New AccountProjectTaskBLL().UpdateEstimatedCurrencies(dr.AccountCurrencyId, DBUtilities.GetSessionAccountId)
                Call New AccountEmployeeTimeEntryBLL().UpdateCurrenciesAndExchangeRates(dr.AccountCurrencyId, dr.ExchangeRate, DBUtilities.GetSessionAccountId)
            End If
        End If
        'Clear cache of vueAccountBaseCurrencyDataTable by AccountId
        CacheManager.ClearCache("vueAccountBaseCurrencyDataTable", "AccountId=" & DBUtilities.GetSessionAccountId, True)
        System.Web.HttpContext.Current.Session.Add("AccountBaseCurrencyId", CType(Me.FormView1.FindControl("ddlAccountCurrencyId"), DropDownList).SelectedValue)
        Dim strScript As String = "window.opener.location.href='AccountCurrencies.aspx" & "'; window.close();"
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
End Class
