
Partial Class AccountAdmin_Controls_ctlExpenseEntryArchive
    Inherits System.Web.UI.UserControl
    Public Event btnShowClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim Amount As Integer
    Dim FilterBLL As New AccountFilterModuleBLL
    Dim expenseEntryBll As New AccountExpenseEntryBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ReportUtilities.SetDefaultValuesOfFilerItem(ddlEmployees, Me.StartDate, Me.EndDate, Me.chkIncludeDateRange)

            Me.ShowGridFromFilter()
            Me.Literal5.Text = ResourceHelper.GetFromResource("Expense Entry Archive")
            Me.Literal1.Text = ResourceHelper.GetFromResource("Search Parameters")
            Me.Literal2.Text = ResourceHelper.GetFromResource("Employees:")
            Me.Literal6.Text = ResourceHelper.GetFromResource("Approved")
            Me.Literal8.Text = ResourceHelper.GetFromResource("Include Date Range:")
            Me.Literal9.Text = ResourceHelper.GetFromResource("Start Date")
            Me.Literal10.Text = ResourceHelper.GetFromResource("End Date")

            If LocaleUtilitiesBLL.IsShowEmployeeNameWithCode = True Then
                'dsEmployeesObject.ID = "dsEmployeesObject"
                'dsEmployeesObject.SelectMethod = "GetAccountEmployeesViewByAccountIdWithDisabled"
                'dsEmployeesObject.TypeName = "AccountEmployeeBLL"
                ddlEmployees.DataSource = dsEmployeesObject
                ddlEmployees.DataValueField = "AccountEmployeeId"
                ddlEmployees.DataTextField = "EmployeeNameWithCodeWithDisabled"

            Else
                'dsEmployeesObject.ID = "dsEmployeesObject"
                ''dsEmployeesObject.SelectMethod = "GetAccountEmployeesViewByAccountIdWithDisabled"
                'dsEmployeesObject.SelectMethod = "GetAccountEmployeesViewByAccountIdWithDisabledWithName"
                'dsEmployeesObject.TypeName = "AccountEmployeeBLL"
                ddlEmployees.DataSource = dsEmployeesObject
                ddlEmployees.DataValueField = "AccountEmployeeId"
                ddlEmployees.DataTextField = "EmployeeName"

            End If
            ddlEmployees.DataBind()
            FilterBLL.InsertFilterDefaultValues(Me, Me.Page)
            FilterBLL.GetFilterModuleForNonGridViewObject(Me, Me.Page)
        End If

        ListBoxExpenseType.Items.Clear()
        ListBoxExpenseType2.Items.Clear()
        ListBoxExpenseType.DataBind()

        If hdfield.Value.ToString IsNot String.Empty Then
            Dim array As String()
            array = hdfield.Value.Split(","c)
            For index = 0 To array.Length - 1
                Dim item As ListItem = ListBoxExpenseType.Items.FindByValue(array(index))
                ListBoxExpenseType2.Items.Add(item)
                ListBoxExpenseType.Items.Remove(item)
            Next
        End If

    End Sub

    Public Sub ShowGridFromFilter()
        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)

        Me.dsUpdateExpenseEntryArchive.SelectParameters("AccountEmployees").DefaultValue = Me.ddlEmployees.SelectedValue
        Me.dsUpdateExpenseEntryArchive.SelectParameters("IncludeDateRange").DefaultValue = Me.chkIncludeDateRange.Checked
        Me.dsUpdateExpenseEntryArchive.SelectParameters("AccountExpenseEntryStartDate").DefaultValue = Me.StartDate.SelectedDate
        Me.dsUpdateExpenseEntryArchive.SelectParameters("AccountExpenseEntryEndDate").DefaultValue = Me.EndDate.SelectedDate
        Me.dsUpdateExpenseEntryArchive.SelectParameters("Approval").DefaultValue = Me.ddlApproved.SelectedValue

        Me.GridView1.DataBind()
        AccountPagePermissionBLL.SetPagePermissionForGridView(114, Me.GridView1, 7, 8)
        Me.btnDeleteSelectedItem.Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(114, 4)
    End Sub

    Function ForReadOnly() As EntryArchiveFilter

        Me.StartDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.StartDate.PostedDate)
        Me.EndDate.SelectedDate = LocaleUtilitiesBLL.ConvertDateToBaseLocaleAsDate(Me.EndDate.PostedDate)

        Dim filterModel As New EntryArchiveFilter
        With filterModel

            .AccountEmployeeId = Me.ddlEmployees.SelectedValue
            .IncludeDataRange = Me.chkIncludeDateRange.Checked
            .StartDate = Me.StartDate.SelectedDate
            .EndDate = Me.EndDate.SelectedDate
            .Approved = Me.ddlApproved.SelectedValue
            .PaymentStatusId = Me.PaymentStatusddl.SelectedValue
            .ExpenseTypes = Me.hdfield.Value
            .SearchFor = IIf(Me.SheetRadio.Checked = True, EntryArchiveFilter.SearchForEnum.Sheet, EntryArchiveFilter.SearchForEnum.Entry)

        End With

        Return filterModel

    End Function

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ViewState.Add("IsFromFilter", True)
        FilterBLL.InsertFilterModuleForNonGridViewObject(Me, Me.Page)
        ShowGridFromFilter()
        'Response.Redirect(Request.RawUrl, False)
        RaiseEvent btnShowClick(sender, e)
    End Sub

    Protected Sub btnDeleteSelectedItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If CType(row.FindControl("chkDelete"), CheckBox).Checked = True And row.Cells(0).FindControl("LinkButton1").Visible = True Then
                Call New AccountEmployeeExpenseSheetBLL().DeleteAccountEmployeeExpenseSheet(Me.GridView1.DataKeys(row.RowIndex)("AccountEmployeeExpenseSheetId"))
            End If
        Next
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound

        If Me.GridView1.Rows.Count <> 0 Then
            Me.CheckAll.Visible = True
            Me.UnCheckAll.Visible = True
        Else
            Me.CheckAll.Visible = False
            Me.UnCheckAll.Visible = False
        End If
        If Me.GridView1.Rows.Count > 0 Then
            Me.btnDeleteSelectedItem.Visible = True

            If Me.PaymentStatusddl.SelectedValue = "0" Then
                Me.btnReadyToPaySelected.Visible = True
            Else
                Me.btnReadyToPaySelected.Visible = False
            End If
            If Me.PaymentStatusddl.SelectedValue = "1" Then
                Me.btnPaidSelected.Visible = True
            Else
                Me.btnPaidSelected.Visible = False
            End If

        Else
            Me.btnDeleteSelectedItem.Visible = False
            Me.btnReadyToPaySelected.Visible = False
            Me.btnPaidSelected.Visible = False
        End If

    End Sub
    Protected Sub CheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            CType(row.Cells(0).FindControl("chkDelete"), CheckBox).Checked = True
        Next
        System.Web.HttpContext.Current.Session.Add("IsCheckAll", "1")
    End Sub

    Protected Sub UnCheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            CType(row.Cells(0).FindControl("chkDelete"), CheckBox).Checked = False
        Next
        System.Web.HttpContext.Current.Session.Add("IsUnCheckAll", "1")
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Call New AccountEmployeeExpenseSheetBLL().DeleteAccountEmployeeExpenseSheet(Me.GridView1.DataKeys(e.RowIndex)("AccountEmployeeExpenseSheetId"))
        e.Cancel = True
        Me.GridView1.DataBind()
    End Sub

    Private Sub dsUpdateExpenseEntryArchive_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles dsUpdateExpenseEntryArchive.Selecting

        Dim ExpenseEntrys As String = ""

        For Each item As ListItem In CType(Me.ListBoxExpenseType2, ListBox).Items
            If item.Selected = True Then
                ExpenseEntrys += item.Value.ToString() + ","
            End If
        Next
        If ExpenseEntrys <> "" Then
            If ExpenseEntrys(ExpenseEntrys.Length - 1).ToString() = ","c Then
                ExpenseEntrys = ExpenseEntrys.Remove(ExpenseEntrys.Length - 1)
            End If
        End If

        e.InputParameters("ExpenseTypes") = hdfield.Value.ToString()
        e.InputParameters("IsExpenseSheet") = IIf(Me.SheetRadio.Checked = True, True, False)

    End Sub
    Protected Sub lnkEmployeeName_Click(sender As Object, e As EventArgs)

        Dim filterModel As EntryArchiveFilter = ForReadOnly()
        Session("EntryArchiveFilterInfo") = filterModel
        Dim queryString As String = ResolveUrl((DirectCast(sender, LinkButton)).Attributes("NavigateUrl").ToString())
        Dim newWin As String = "window.open('" & queryString & "', 'popupwindow', 'width=800,height=400,left=300,top=300,scrollbars=yes');"
        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType(), "pop", newWin, True)

    End Sub
    Protected Sub btnReadyToPaySelected_Click(sender As Object, e As EventArgs)
        SelectedMethod(1)
    End Sub
    Protected Sub btnPaidSelected_Click(sender As Object, e As EventArgs)
        SelectedMethod(2)
    End Sub

    Sub SelectedMethod(ByVal PaymentStatusId As Integer)
        Dim filterModel As EntryArchiveFilter = ForReadOnly()
        filterModel.ExpenseSheetId = New List(Of Guid)

        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If CType(row.Cells(0).FindControl("chkDelete"), CheckBox).Checked = True Then
                filterModel.ExpenseSheetId.Add(New Guid(GridView1.DataKeys(row.RowIndex).Values(0).ToString()))
            End If
        Next

        Dim Entrys As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable
        Entrys = expenseEntryBll.GetDataForEntryArchivePopUpFiltred(filterModel)
        expenseEntryBll.UpdatePaymentStatusOfEntrys(Entrys, PaymentStatusId)

        For Each item As Guid In filterModel.ExpenseSheetId
            expenseEntryBll.UpdatePaymentStatusOfExpenseSheet(item)
        Next
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim expenseSheetId As New Guid
            If GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString() <> "" Then
                expenseSheetId = New Guid(GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString())
                Dim ArchiveInfo As EntryArchivePaymentStatusInfo = expenseEntryBll.GetCountOfPaymentStatus(expenseSheetId)
                CType(e.Row.Cells(0).FindControl("ReadyToPayLbl"), Label).Text = ArchiveInfo.ReadyToPay.ToString() + " / " + ArchiveInfo.Total.ToString()
                CType(e.Row.Cells(0).FindControl("PaidLbl"), Label).Text = ArchiveInfo.Paid.ToString() + " / " + ArchiveInfo.Total.ToString()
                If ArchiveInfo.Paid >= 1 Then
                    e.Row.Cells(0).FindControl("LinkButton1").Visible = False
                    e.Row.Cells(9).Controls(0).Visible = False
                End If
            End If
        End If

    End Sub

End Class
