''' <summary>
''' Employee controls for expense sheet list class
''' </summary>
''' <remarks></remarks>
Partial Class Employee_Controls_ctlAccountExpenseSheetList
    Inherits System.Web.UI.UserControl
    Dim AccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow
    ''' <summary>
    '''  Button add click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Dim FilterBLL As New AccountFilterModuleBLL
    Public Event btnShowClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeId=" & ddlEmployeeName.SelectedValue, False)
    End Sub
    ''' <summary>
    ''' Grid view row data bound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            CType(e.Row.FindControl("lbtnAmount"), LinkButton).Text = String.Format("{0} ({1})", ResourceHelper.GetFromResource("Total Amount"), GetAccountBaseCurrencyCode)
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            LockGridViewExpenseEntry(e)
        End If
    End Sub
    ''' <summary>
    ''' Grid view row deleting event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Me.GridView1.DataBind() 'To get the keys first.

        If Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeExpenseSheetId") IsNot Nothing Then
            Call New AccountAttachmentsBLL().DeleteAccountAttachmentsFileByExpenseSheetId(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeExpenseSheetId"))
            Call New AccountEmployeeExpenseSheetBLL().DeleteAccountEmployeeExpenseSheet(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeExpenseSheetId"))
        End If

        Me.GridView1.DataBind()
        e.Cancel = True
    End Sub
    ''' <summary>
    ''' Setting permissions
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetPermissions()
        AccountPagePermissionBLL.SetPagePermissionForGridView(135, Me.GridView1, 4, 5)
        AccountPagePermissionBLL.SetPagePermissionForAddButton(135, Me.btnAdd)

        If GridView1.Visible = False Then
            Me.btnAdd.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' Page initializing event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If IsPostBack Then
            '            Me.StartDateTextBox.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDateTextBox.PostedDate)
            'Me.StartDateTextBox.Culture = LocaleUtilitiesBLL.GetCurrentCultureInfo
            'Me.EndDateTextBox.Culture = LocaleUtilitiesBLL.GetCurrentCultureInfo
            'Dim StartDate As Date = Convert.ToDateTime(Me.StartDateTextBox.PostedDate, LocaleUtilitiesBLL.GetCurrentCultureInfo)
            'Dim EndDate As Date = Convert.ToDateTime(Me.EndDateTextBox.PostedDate, LocaleUtilitiesBLL.GetCurrentCultureInfo)
            'Me.StartDateTextBox.SelectedDate = StartDate
            'Me.StartDateTextBox.VisibleDate = StartDate
            'Me.EndDateTextBox.SelectedDate = EndDate
            'Me.EndDateTextBox.VisibleDate = EndDate
        End If
    End Sub
    ''' <summary>
    ''' Page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetPermissions()
        Me.Literal1.Text = ResourceHelper.GetFromResource("Expense Sheet")
        Me.Literal2.Text = ResourceHelper.GetFromResource("Search Parameters")
        Me.Literal3.Text = ResourceHelper.GetFromResource("Approval Status:")
        Me.Literal4.Text = ResourceHelper.GetFromResource("Include Date Range:")
        Me.Literal5.Text = ResourceHelper.GetFromResource("Start Date:")
        Me.Literal6.Text = ResourceHelper.GetFromResource("End Date:")
        If Not AccountPagePermissionBLL.IsPageHasPermissionOf(135, 2) = True Then
            btnAdd.Enabled = False
        End If
        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(135, ddlEmployeeName)
            ddlEmployeeName.SelectedValue = DBUtilities.GetSessionAccountEmployeeId
            AddListItemInDropDown()
            Me.ddlExpenseSheet.SelectedValue = 1
            SetDateValue()
            FilterBLL.InsertFilterDefaultValues(Me, Me.Page)
            FilterBLL.GetFilterModuleForNonGridViewObject(Me, Me.Page)
            Me.StartDateTextBox.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDateTextBox.PostedDate)
            Me.EndDateTextBox.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDateTextBox.PostedDate)
            Me.dsEmployeeExpenseSheetGridViewObject.SelectParameters("StartDate").DefaultValue = Me.StartDateTextBox.PostedDate
            Me.dsEmployeeExpenseSheetGridViewObject.SelectParameters("EndDate").DefaultValue = Me.EndDateTextBox.PostedDate
            Me.GridView1.DataBind()

        End If

        Me.GridView1.Sort("ExpenseSheetDate", SortDirection.Descending)
    End Sub
    ''' <summary>
    ''' Lock grid view expense entry event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub LockGridViewExpenseEntry(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If AccountExpenseEntryBLL.DoUnlockForExpenseSheet(e.Row) = False Then
            e.Row.Cells(5).FindControl("lnkDelete").Visible = False
        End If
    End Sub
    ''' <summary>
    ''' Add list item in drop down 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddListItemInDropDown()
        Me.AddDropDownItem("All Expenses", 0, Me.ddlExpenseSheet)
        Me.AddDropDownItem("All Open Expenses", 1, Me.ddlExpenseSheet)
        Me.AddDropDownItem("Not Submitted", 2, Me.ddlExpenseSheet)
        Me.AddDropDownItem("Submitted", 3, Me.ddlExpenseSheet)
        Me.AddDropDownItem("Approved", 4, Me.ddlExpenseSheet)
        Me.AddDropDownItem("Rejected", 5, Me.ddlExpenseSheet)
    End Sub
    ''' <summary>
    ''' Add drop down item of specified text, value and drop down list
    ''' </summary>
    ''' <param name="Text"></param>
    ''' <param name="value"></param>
    ''' <param name="ddl"></param>
    ''' <remarks></remarks>
    Public Sub AddDropDownItem(ByVal Text As String, ByVal value As String, ByVal ddl As DropDownList)
        Dim item As New System.Web.UI.WebControls.ListItem
        ddl.AppendDataBoundItems = True
        item.Text = ResourceHelper.GetFromResource(Text)
        item.Value = value
        ddl.Items.Add(item)
    End Sub
    ''' <summary>
    ''' Set date value
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDateValue()
        Me.StartDateTextBox.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
        Me.EndDateTextBox.SelectedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone
    End Sub
    ''' <summary>
    ''' Button show click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        FilterBLL.InsertFilterModuleForNonGridViewObject(Me, Me.Page)
        Me.StartDateTextBox.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDateTextBox.PostedDate)
        Me.EndDateTextBox.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDateTextBox.PostedDate)
        Me.dsEmployeeExpenseSheetGridViewObject.SelectParameters("StartDate").DefaultValue = Me.StartDateTextBox.PostedDate
        Me.dsEmployeeExpenseSheetGridViewObject.SelectParameters("EndDate").DefaultValue = Me.EndDateTextBox.PostedDate
        Me.GridView1.DataBind()
        'Response.Redirect(Request.RawUrl, False)
        RaiseEvent btnShowClick(sender, e)
    End Sub
    ''' <summary>
    ''' Drop down list employee name selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlEmployeeName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If AccountPagePermissionBLL.IsEmployeeHasPermission(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, ddlEmployeeName.SelectedValue, 135, 1) <> True Then
        '    btnAdd.Enabled = False
        'Else
        '    btnAdd.Enabled = True
        'End If
        'SetDateValue()
    End Sub
    Private Function GetAccountBaseCurrencyCode() As String
        If IsNothing(AccountBaseCurrency) Then
            Dim dtAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = New AccountCurrencyExchangeRateBLL().GetvueAccountBaseCurrencyByAccountId(DBUtilities.GetSessionAccountId)
            If dtAccountBaseCurrency.Rows.Count > 0 Then
                AccountBaseCurrency = dtAccountBaseCurrency.Rows(0)
            End If
        End If

        Return AccountBaseCurrency.CurrencyCode
    End Function
End Class
