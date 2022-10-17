Imports Bestcode.MathParser
Imports System.Linq

''' <summary>
''' Employee controls for expense entry list class
''' </summary>
''' <remarks></remarks>
Partial Class Employee_Controls_ctlAccountExpenseEntryList
    Inherits System.Web.UI.UserControl
    Dim AccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow
    Dim SumTotalAmount As Double = 0
    Dim MasterEntityTypeId As New Guid("756e4460-a713-4bee-b3f0-708fc5be21bd")
    Dim MasterEnityTypeIdExpenseSheet As New Guid("a55df02b-fbfb-4873-b582-6968fbaee589")
    Dim ErrorMessage As String = "Error: Unable to save the expense sheet. A description is required."
    Dim CustomFieldCaption As String
    Dim NoEntrys As Boolean = False
    ''' <summary>
    ''' Grid view data bound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        SumTotalAmount = 0

        If AccountPagePermissionBLL.IsPageHasPermissionOf(15, 1) = False Then
            SetVisibleFalseForPaymentStatusElements()
        End If

        Dim AccountEmployeeExpenseSheetId As Guid
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        End If
        Dim BLL As New AccountEmployeeExpenseSheetBLL
        Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = BLL.GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If dr.Submitted = False And dr.Approved = False Then
                SetVisibleFalseForPaymentStatusElements()
            End If
        End If

    End Sub

    Sub SetVisibleFalseForPaymentStatusElements()
        GridView1.Columns(0).Visible = False
        Me.PayBtPaymentStatus.Visible = False
    End Sub

    ''' <summary>
    ''' Grid view row command event for select
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            Me.FormView1.Visible = True
            Me.btnAddExpenseEntry.Visible = False
            Me.btnPrint.Visible = False
            Me.GridView1.Visible = False
            Me.btnSubmit.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' Data set expense entry form object event for inserted
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountExpenseEntryFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountExpenseEntryFormObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
    ''' <summary>
    ''' Data set expense entry form object event for inserting
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountExpenseEntryFormObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountExpenseEntryFormObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub
    ''' <summary>
    ''' Data set expense entry form object event for updated
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountExpenseEntryFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountExpenseEntryFormObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    ''' <summary>
    ''' Data set expense entry form object event for updating
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountExpenseEntryFormObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountExpenseEntryFormObject.Updating
        If VerifyIfGridHasRows() = False Then
            ShowNotFoundMessage("The sheet couldn't be submitted")
            e.Cancel = True
            Return
        End If
        DBUtilities.SetRowForUpdating(e)
    End Sub
    ''' <summary>
    ''' Grid view row data bound event 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)

        If e.Row.RowType = DataControlRowType.Header Then

            CType(e.Row.FindControl("lblAmountbase"), LinkButton).Text = String.Format("{0} ({1})", ResourceHelper.GetFromResource("Amount"), GetAccountBaseCurrencyCode)
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            LockGridViewExpenseEntry(e)
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then

            CType(e.Row.Cells(0).Controls(1), CheckBox).Visible = CType(e.Row.Cells(0).Controls(1), CheckBox).Enabled

            Dim AccountExpenseEntry = DataBinder.Eval(e.Row.DataItem, "AccountExpenseEntryId")

            If AccountExpenseEntry <> 0 Then
                Dim counter = New AccountAttachmentsBLL().GetAttachmentsCountByExpenseEntryId(AccountExpenseEntry)
                If counter <> 0 Then
                    CType(e.Row.FindControl("AttchCount"), Label).Visible = True
                    CType(e.Row.FindControl("AttchCount"), Label).ToolTip = String.Format("This expense entry has {0} attachments", counter)
                End If
            Else
                LockGridViewExpenseEntryNoEntries(e)
                Exit Sub
            End If

            If e.Row.FindControl("lblbaseCurrency") IsNot Nothing Then
                CType(e.Row.FindControl("lblbaseCurrency"), Label).Text = String.Format("{0} ", GetAccountBaseCurrencyCode)
            End If

            If e.Row.FindControl("Lbl_ExchangeRate") IsNot Nothing Then

                Dim ExchangeRate As Label = e.Row.FindControl("Lbl_ExchangeRate")

                If e.Row.FindControl("Lbl_Amount") IsNot Nothing Then
                    Dim Amount As Label = e.Row.FindControl("Lbl_Amount")
                    If e.Row.FindControl("Label_Amount_Base") IsNot Nothing Then
                        CType(e.Row.FindControl("Label_Amount_Base"), Label).Text = String.Format("{0:N} ", Math.Round(Amount.Text / ExchangeRate.Text, 2))
                    End If

                End If

            Else
                btnPrint.Enabled = False
            End If

            Me.ShowExpenseEntryStatus(e.Row)
            Dim dtExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryDataTable = New AccountExpenseEntryBLL().GetvueAccountExpenseEntriesByAccountExpenseEntryId(DataBinder.Eval(e.Row.DataItem, "AccountExpenseEntryId"))

            Dim drExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryRow = dtExpenseEntry.Rows(0)


            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Amount")) Then
                SumTotalAmount += Math.Round(DataBinder.Eval(e.Row.DataItem, "Amount") / drExpenseEntry.ExchangeRate, 2)

            End If
            LockGridViewExpenseEntry(e)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            SetFooterAmount(e)
        End If
        If LocaleUtilitiesBLL.ShowTaskInExpenseSheet = True Then
            'CType(Me.GridView1.FindControl("label7"), Label).Visible = True
            Me.GridView1.Columns(3).Visible = True
        Else
            Me.GridView1.Columns(3).Visible = False
        End If
    End Sub
    ''' <summary>
    ''' Set footer amount event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SetFooterAmount(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim dtAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = New AccountCurrencyExchangeRateBLL().GetvueAccountBaseCurrencyByAccountId(DBUtilities.GetSessionAccountId)
        Dim drAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow
        If dtAccountBaseCurrency.Rows.Count > 0 Then
            drAccountBaseCurrency = dtAccountBaseCurrency.Rows(0)

            Dim dtAccountCurrency As AccountCurrency.vueAccountCurrencyDataTable = New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(drAccountBaseCurrency.AccountBaseCurrencyId)
            Dim drAccountCurrency As AccountCurrency.vueAccountCurrencyRow
            If dtAccountCurrency.Rows.Count > 0 Then

                drAccountCurrency = dtAccountCurrency.Rows(0)

                Dim TotalFooterAmount As Double = drAccountCurrency.ExchangeRate * SumTotalAmount

                e.Row.Cells(8).Text = String.Format("{0:N} ", TotalFooterAmount) & drAccountBaseCurrency.CurrencyCode
                e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            End If
        End If
    End Sub
    ''' <summary>
    ''' Lock grid view expense entry event
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub LockGridViewExpenseEntry(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If AccountExpenseEntryBLL.DoUnlock(e.Row) = False Then
            e.Row.Cells(6).FindControl("LinkButton2").Visible = False
            e.Row.Cells(7).FindControl("LinkButton1").Visible = False
        End If

    End Sub
    Public Sub LockGridViewExpenseEntryNoEntries(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        e.Row.Cells(0).FindControl("ExpenseEntryIdLbl").Visible = False
        e.Row.Cells(7).FindControl("ChckBoxReimburse").Visible = False
        e.Row.Cells(8).FindControl("ChckBoxBilliable").Visible = False
        e.Row.Cells(6).FindControl("LinkButton2").Visible = False
        e.Row.Cells(7).FindControl("LinkButton1").Visible = False
        e.Row.Cells(8).FindControl("HyperLink1").Visible = False
        e.Row.Cells(5).FindControl("lblbaseCurrency").Visible = False
    End Sub
    ''' <summary>
    ''' Check expense entry lock
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub IsExpenseEntryLock()
        Dim AccountEmployeeExpenseSheetId As Guid
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        End If
        Dim BLL As New AccountEmployeeExpenseSheetBLL
        Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = BLL.GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If (LocaleUtilitiesBLL.IsShowLockSubmittedRecords And dr.Submitted = True) Or (LocaleUtilitiesBLL.IsShowLockApprovedRecords And dr.Approved = True) Then
                Me.btnSubmit.Enabled = False
                Me.btnMasterUpdate.Enabled = False
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set reimbursment drop down data
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetReimbursmentDropDownData()
        Dim dt As AccountPreferences.AccountPreferencesDataTable = New AccountBLL().GetPreferencesByAccountId(DBUtilities.GetSessionAccountId)
        Dim dr As AccountPreferences.AccountPreferencesRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.dsReimbursementCurrencyObject.SelectParameters("AccountCurrencyId").DefaultValue = dr.AccountReimbursementCurrencyId
            Me.ddlReimbursementCurrency.SelectedValue = dr.AccountReimbursementCurrencyId
            Me.ddlReimbursementCurrency.DataBind()
        End If
    End Sub
    ''' <summary>
    ''' Page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            SetVisibleFalseForPaymentStatusElements()
        End If

        'Fill the dll with LastDayOfCurrentMonth and LastDayOfPreviousMonth

        If Page.IsPostBack = False Then

            ddlExpenseSheetDate.Items.Clear()

            Dim ListOFItems As New ListItemCollection

            Dim LastDayOfThisMonth As Date = GetLastDayOfThisMonth(DateTime.Now())

            ListOFItems.Add(LastDayOfThisMonth.ToShortDateString())

            Dim monthsBack = 3
            Dim DateToGetPrevious As Date = LastDayOfThisMonth

            For index = 0 To monthsBack - 1
                DateToGetPrevious = GetLastDayOfPreviousMonth(DateToGetPrevious)
                ListOFItems.Add(DateToGetPrevious.ToShortDateString())
            Next

            ddlExpenseSheetDate.DataSource = ListOFItems
            ddlExpenseSheetDate.DataBind()

            Dim AccountEmployeeExpenseSheetID As Guid
            If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
                AccountEmployeeExpenseSheetID = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))

                Dim BLL As New AccountEmployeeExpenseSheetBLL
                Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = BLL.GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetID)
                Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)
                    If dr.Submitted = True Or dr.Approved = True Then
                        ListOFItems.Clear()
                        ListOFItems.Add(dr.ExpenseSheetDate.ToShortDateString())
                        CType(Me.UpdatePanel3.FindControl("ddlExpenseSheetDate"), DropDownList).Enabled = False
                        ddlExpenseSheetDate.DataSource = ListOFItems
                        ddlExpenseSheetDate.DataBind()
                    Else
                        If ddlExpenseSheetDate.Items.FindByText(dr.ExpenseSheetDate.ToShortDateString()) IsNot Nothing Then
                            ddlExpenseSheetDate.Items.FindByText(dr.ExpenseSheetDate.ToShortDateString()).Selected = True
                        End If
                    End If

                End If
            End If
        End If



        '-----------------------------------------------------------------------------------------------------

        AccountCustomFieldBLL.CreateCustomField_ItemCreated(CustomTable, New Guid("a55df02b-fbfb-4873-b582-6968fbaee589"), "20%", "80%", "35px")
        If CustomTable.Rows.Count <= 1 Then
            CustomTable.Visible = False
            MainCustomTable.Visible = False
        Else
            Dim ltrTableRow As New TableRow
            Dim ltrTableCell As New TableCell
            Dim ltr As New LiteralControl("<br />")
            ltrTableCell.Controls.Add(ltr)
            ltrTableRow.Cells.Add(ltrTableCell)
            ltrTable.Rows.Add(ltrTableRow)
        End If
        Dim AccountEmployeeId As Integer = IIf(ddlEmployeeName.SelectedValue = "", Me.Request.QueryString("AccountEmployeeId"), ddlEmployeeName.SelectedValue)
        If Not Me.Request.QueryString("IsCopy") Is Nothing And Me.Request.QueryString("IsCopy") = "True" Then
            CopyExpenseSheet()
        End If
        'Me.CW2.Visible = False

        SetMasterUpdateButtonVisible()
        If Not Me.IsPostBack Then
            AccountEmployeeBLL.SetDataForEmployeeDropdown(135, ddlEmployeeName)

            RefreshDllemployeeSeleccted(AccountEmployeeId)

            If VerifyIfGridHasRows() = False Then
                btnSubmit.Enabled = False
                btnPrint.Enabled = False
                NoEntrys = True
            Else
                SetPrintButton()
            End If

            'RefreshDateSeleccted()

            If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
                SetDataInMasterRecord()
            End If
            AccountPagePermissionBLL.SetPagePermission(135, Me.GridView1, Me.FormView1, "btnAdd", 6, 7)

            CType(Me.FormView1.FindControl("txtDate"), eWorld.UI.CalendarPopup).PostedDate = LocaleUtilitiesBLL.GetCurrentDateFromUserTimeZone

            Me.GetQuantityAndTax()

            IsCurrentEmployeeHasPermissionOffADD()
            IsAllowAddBySubmitted()
            IsExpenseEntryLock()
        Else
            SetVisibleGridViewIcons()
            RefreshDllemployeeSeleccted(AccountEmployeeId)
            'RefreshDateSeleccted()
        End If
        Me.Literal26.Text = ResourceHelper.GetFromResource("Expense Sheet Status")
        Me.Literal24.Text = ResourceHelper.GetFromResource("Description:")
        Me.Literal111.Text = ResourceHelper.GetFromResource("Reimbursement Currency:")
        Me.Literal2.Text = ResourceHelper.GetFromResource("Total Reimbursement:")
        Me.Literal25.Text = ResourceHelper.GetFromResource("Date:")
        If FormView1.Visible <> False Then
            CType(Me.FormView1.FindControl("lblNetAmountNR"), Label).Visible = False
            CType(Me.FormView1.FindControl("lblAmountNR"), Label).Visible = False
        End If
        ShowApprovalDetail()



    End Sub

    Function GetLastDayOfThisMonth(ByVal MyDate As Date) As Date

        Dim DaysInCurrentMonth As Integer = Date.DaysInMonth(MyDate.Year, MyDate.Month)
        Dim LastDayInMonthDate As New Date(MyDate.Year, MyDate.Month, DaysInCurrentMonth)

        Return LastDayInMonthDate

    End Function
    Function GetLastDayOfPreviousMonth(ByVal MyDate As Date) As Date

        Dim LastDayInPreviousMonthDate As Date

        Dim DaysInPreviousMonth = Nothing
        Dim DaysInCurrentMonth As Integer = Date.DaysInMonth(MyDate.Year, MyDate.Month)

        If MyDate.Month <> 1 Then
            DaysInPreviousMonth = Date.DaysInMonth(MyDate.Year, MyDate.Month - 1)
            LastDayInPreviousMonthDate = New Date(MyDate.Year, MyDate.Month - 1, DaysInPreviousMonth)
        Else
            DaysInPreviousMonth = Date.DaysInMonth(MyDate.Year - 1, 12)
            LastDayInPreviousMonthDate = New Date(MyDate.Year - 1, 12, DaysInPreviousMonth)
        End If

        Return LastDayInPreviousMonthDate

    End Function

    Sub RefreshDllemployeeSeleccted(ByVal AccountEmployeeId)
        If Session("dllEmployeeSelected") IsNot Nothing Then

            If Session("dllEmployeeSelected") <> AccountEmployeeId Then
                Me.ddlEmployeeName.SelectedValue = Session("dllEmployeeSelected")
                Session("dllEmployeeSelected") = Nothing
            Else
                Me.ddlEmployeeName.SelectedValue = AccountEmployeeId
            End If

        Else
            Me.ddlEmployeeName.SelectedValue = AccountEmployeeId
        End If
    End Sub

    Sub RefreshDateSeleccted()
        If Session("ddlExpenseSheetDate") IsNot Nothing Then
            Me.ddlExpenseSheetDate.SelectedValue = Session("ddlExpenseSheetDate")
            Session("ddlExpenseSheetDate") = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Set print button
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetPrintButton()
        Dim URL As String
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            URL = "AccountExpenseEntryReadOnly.aspx?AccountEmployeeExpenseSheetId=" & Me.Request.QueryString("AccountEmployeeExpenseSheetId").ToString & "&IsPrint=True" & "&AccountEmployeeId=" & Me.ddlEmployeeName.SelectedValue
            Me.ViewState.Add("AccountEmployeeExpenseSheetId", Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Else
            URL = "AccountExpenseEntryReadOnly.aspx?AccountEmployeeExpenseSheetId=" & System.Guid.Empty.ToString & "&IsPrint=True" & "&AccountEmployeeId=" & Me.ddlEmployeeName.SelectedValue
            btnPrint.Enabled = False
        End If
        btnPrint.Attributes.Add("onclick", "javascript:window.open(" & """" & URL & """" & ", 'popupwindow', 'width=1000,height=675,left=0,top=0,scrollbars=yes,resizable=yes'); return false;")
    End Sub
    ''' <summary>
    ''' Show approval detail
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowApprovalDetail()
        Dim AccountEmployeeExpenseSheetID As Guid
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            AccountEmployeeExpenseSheetID = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        End If
        CW2.Show(AccountEmployeeExpenseSheetID)
    End Sub
    ''' <summary>
    ''' Set master update button visible
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetMasterUpdateButtonVisible()
        If Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            Me.btnMasterUpdate.Visible = False
            Me.btnSubmit.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' Set visible grid view icons
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetVisibleGridViewIcons()
        Dim row As GridViewRow
        Dim AccountEmployeeExpenseSheetId As Guid
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        End If
        Dim dtExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable = New AccountExpenseEntryBLL().GetvueAccountExpenseEntryWithLastStausByEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim drExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusRow
        If dtExpenseEntry.Rows.Count > 0 Then
            drExpenseEntry = dtExpenseEntry.Rows(0)
            For Each row In GridView1.Rows
                If Not drExpenseEntry.AccountExpenseEntryId > 0 Then
                    row.Cells(6).FindControl("LinkButton2").Visible = False
                    row.Cells(7).FindControl("LinkButton1").Visible = False
                    row.Cells(8).FindControl("HyperLink1").Visible = False
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' Show expense sheet status
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowExpenseSheetStatus()
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            Dim AccountEmployeeExpenseSHeetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
            Call New AccountExpenseEntryBLL().SetExpenseStatus(lblExpenseStatus, Me.imgES, AccountEmployeeExpenseSHeetId)
        Else
            lblExpenseStatus.Text = ResourceHelper.GetFromResource("Not Submitted")
            imgES.ImageUrl = "~/images/NotSubmittedStatus.gif"
        End If
    End Sub
    ''' <summary>
    ''' Form view data bound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        UIUtilities.SetFocus(Me.DescriptionTextBox)
        ShowExpenseSheetStatus()

        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If Not IsDBNull(Me.FormView1.DataItem("IsBillable")) Then
                CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Checked = Me.FormView1.DataItem("IsBillable")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("Reimburse")) Then
                CType(Me.FormView1.FindControl("chkReimburse"), CheckBox).Checked = Me.FormView1.DataItem("Reimburse")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountProjectId")) Then
                Me.dsAccountProjectObject.SelectParameters("AccountProjectId").DefaultValue = Me.FormView1.DataItem("AccountProjectId")
                CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountProjectId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountExpenseId")) Then
                Me.dsAccountExpenseObject.SelectParameters("AccountExpenseId").DefaultValue = Me.FormView1.DataItem("AccountExpenseId")
                CType(Me.FormView1.FindControl("CascadingDropDown2"), AjaxControlToolkit.CascadingDropDown).SelectedValue = Me.FormView1.DataItem("AccountProjectId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountExpenseId")) Then
                Me.dsAccountExpenseObject.SelectParameters("AccountExpenseId").DefaultValue = Me.FormView1.DataItem("AccountExpenseId")
                CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountExpenseId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountCurrencyId")) Then
                Me.dsAccountCurrencyObject.SelectParameters("AccountCurrencyId").DefaultValue = Me.FormView1.DataItem("AccountCurrencyId")
                CType(Me.FormView1.FindControl("ddlAccountCurrencyId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountCurrencyId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountPaymentMethodId")) Then
                'Me.dsAccountPaymentMethodObject.SelectParameters("AccountPaymentMethodId").DefaultValue = Me.FormView1.DataItem("AccountPaymentMethodId")
                CType(Me.FormView1.FindControl("ddlAccountPaymentMethodId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountPaymentMethodId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountTaxZoneId")) Then
                Me.dsAccountTaxZoneObject.SelectParameters("AccountTaxZoneId").DefaultValue = Me.FormView1.DataItem("AccountTaxZoneId")
                CType(Me.FormView1.FindControl("ddlAccountTaxZoneId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountTaxZoneId")
            End If
            Me.dsAccountProjectObjectInsert.SelectParameters("AccountEmployeeId").DefaultValue = ddlEmployeeName.SelectedValue
            Me.GetQuantityAndTax()
            Me.Calculation(, True)
            Me.IsCurrentEmployeeHasPermissionOffADD()

            If Not IsDBNull(Me.FormView1.DataItem("AccountProjectTaskId")) Then
                CType(Me.FormView1.FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown).SelectedValue = Me.FormView1.DataItem("AccountProjectTaskId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountClientId")) Then
                CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountClientId")
            End If
            'SetCascadingAccountIdEdit()
            If CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue <> "" Then
                CheckExpensesVisibility(CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue)
            End If
        End If
        If LocaleUtilitiesBLL.ShowClientInExpenseSheet = False Then
            CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).Visible = False
        Else
            CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).Visible = True
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            SetReimbursmentDropDownData()

            'Me.ExpenseSheetDate.SelectedDate = Now.Date
            CType(Me.FormView1.FindControl("txtDate"), eWorld.UI.CalendarPopup).SelectedDate = Now.Date
            SetDefaultValues()
            CType(Me.FormView1.FindControl("chkReimburse"), CheckBox).Checked = True
            Me.GetQuantityAndTax()
            Me.Calculation()
            Dim dtAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = New AccountCurrencyExchangeRateBLL().GetvueAccountBaseCurrencyByAccountId(DBUtilities.GetSessionAccountId)
            Dim drAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow
            If dtAccountBaseCurrency.Rows.Count > 0 Then
                drAccountBaseCurrency = dtAccountBaseCurrency.Rows(0)
                CType(Me.FormView1.FindControl("ddlAccountCurrencyId"), DropDownList).SelectedValue = drAccountBaseCurrency.AccountBaseCurrencyId
            End If


            If CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue <> "" Then
                CheckExpensesVisibility(CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue)
            End If

            'Me.IsCurrentEmployeeHasPermissionOffADD()
            IsExpenseEntryLock()
            'Me.SetCascadingAccountId()
            ''Me.FormView1.Visible = False
            ''Me.GridView1.Visible = True
            ''Me.btnAddExpenseEntry.Visible = True
            ''Me.btnPrint.Visible = True
            ''Me.btnSubmit.Visible = True

        End If

        Me.SetCascadingAccountId()
        Me.SetCascadingAccountIdForProject()

    End Sub
    Public Sub SetCascadingAccountId()
        'Dim objDropdownTask As DropDownList
        'Dim dsObjectTask As ObjectDataSource
        'Dim dataValueTask As Object
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FormView1.FindControl("ddlAccountProjectTaskIdCascadingDropDown"), AjaxControlToolkit.CascadingDropDown)
        Dim dsObject As ObjectDataSource
        dsObject = CType(Me.FormView1.FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
        Dim AccountProjectTaskId As Integer = dsObject.SelectParameters("AccountProjectTaskId").DefaultValue
        'Dim dsObjects As ObjectDataSource
        'dsObjects = CType(Me.FormView1.FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
        'Dim AccountProjectId As Integer = dsObjects.SelectParameters("AccountProjectId").DefaultValue
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet & "," & AccountProjectTaskId & "," & DBUtilities.GetSessionAccountId & "," & DBUtilities.GetShowAdditionalTaskInformationType & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetShowProjectInTimesheet
    End Sub
    Public Sub SetCascadingAccountIdForProject()
        'Dim objDropdownTask As DropDownList
        'Dim dsObjectTask As ObjectDataSource
        'Dim dataValueTask As Object
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FormView1.FindControl("CascadingDropDown2"), AjaxControlToolkit.CascadingDropDown)
        Dim dsObject As ObjectDataSource
        dsObject = Me.dsAccountProjectObject
        Dim AccountProjectId As Integer = dsObject.SelectParameters("AccountProjectId").DefaultValue
        If LocaleUtilitiesBLL.ShowClientInExpenseSheet = False Then
            MyCascading.ParentControlID = Nothing
        End If
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & ddlEmployeeName.SelectedValue & "," & LocaleUtilitiesBLL.ShowClientInExpenseSheet & "," & DBUtilities.GetSessionAccountId & "," & 0 & "," & LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet & "," & DBUtilities.GetShowAdditionalProjectInformationType & "," & DBUtilities.GetShowClientInTimesheet & "," & DBUtilities.GetShowProjectInTimesheet
    End Sub
    ''' <summary>
    ''' Check allow add by submitted
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub IsAllowAddBySubmitted()
        Dim AccountEmployeeExpenseSheetId As Guid
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        End If
        Dim BLL As New AccountEmployeeExpenseSheetBLL
        Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = BLL.GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If (LocaleUtilitiesBLL.IsShowLockSubmittedRecords And dr.Submitted = True) Or (LocaleUtilitiesBLL.IsShowLockApprovedRecords And dr.Approved = True) Then
                CType(Me.FormView1.FindControl("btnAdd"), Button).Enabled = False
                Me.btnAddExpenseEntry.Visible = False
            End If
        End If
    End Sub

    Protected Sub FormView1_DataBound1(sender As Object, e As System.EventArgs) Handles FormView1.DataBound
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            AccountCustomFieldBLL.SetCustomValuesForFormView_DataBound(FormView1)
            If CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue <> "" Then
                CheckExpensesVisibility(CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Form view item inserted event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        If Session("CopyExpenseEntryControls") IsNot Nothing Then

        Else
            Response.Redirect("~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSheetId=" & Me.ViewState("AccountEmployeeExpenseSheetId").ToString, False)
        End If
    End Sub
    ''' <summary>
    ''' Form view item inserting event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' CUSTOMFIELD ERROR HERE -------- RELATED TO UIUTILITIES.SHOWMESSAGE?
    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        For n As Integer = 1 To 15
            AccountCustomFieldBLL.SetCustomValuesForFormView_Inserting(FormView1, e, MasterEntityTypeId, "CustomField" & n)
            If e.Cancel = True Then
                Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                UIUtilities.ShowMessage(CustomFieldCaption & " Field is required ", CurrentPage)
                FormView1.Visible = True
                GridView1.Visible = False
                Me.btnAddExpenseEntry.Visible = False
            End If
        Next
        If e.Cancel <> True Then
            If Not IsValidAllTextBoxValue() Then
                e.Cancel = True
            Else
                If InsertMasterExpenseSheet() = False Then
                    Me.ShowNotFoundMessage(ErrorMessage)
                    UIUtilities.SetFocus(Me.DescriptionTextBox)
                    e.Cancel = True
                    Me.FormView1.Visible = True
                    Me.GridView1.Visible = False
                    Me.btnAddExpenseEntry.Visible = False
                    Me.btnSubmit.Visible = False
                    Me.btnPrint.Visible = False
                End If
                e.Values.Item("AccountExpenseEntryDate") = CType(Me.FormView1.FindControl("txtDate"), eWorld.UI.CalendarPopup).SelectedDate.Date
                If LocaleUtilitiesBLL.ShowClientInExpenseSheet = True Then
                    e.Values.Item("AccountClientId") = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
                Else
                    e.Values.Item("AccountClientId") = 0
                End If
                e.Values.Item("AccountProjectId") = CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
                e.Values.Item("AccountProjectTaskId") = CType(Me.FormView1.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue
                e.Values.Item("AccountEmployeeId") = Me.ddlEmployeeName.SelectedValue

                If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
                    e.Values.Item("AccountEmployeeExpenseSheetId") = Me.Request.QueryString("AccountEmployeeExpenseSheetId")
                Else
                    e.Values.Item("AccountEmployeeExpenseSheetId") = Me.ViewState("AccountEmployeeExpenseSheetId")
                End If
            End If
        End If

    End Sub
    ''' <summary>
    ''' Form view item updated event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        Response.Redirect("~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSheetId=" & Me.ViewState("AccountEmployeeExpenseSheetId").ToString, False)
    End Sub
    ''' <summary>
    ''' Form view item updating event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    '''
    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        For n As Integer = 1 To 15
            AccountCustomFieldBLL.SetCustomValuesForFormView_Updating(FormView1, e, MasterEntityTypeId, "CustomField" & n)
            If e.Cancel = True Then
                Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
            End If
        Next
        If e.Cancel <> True Then
            If Not IsValidAllTextBoxValue() Then
                e.Cancel = True
            Else
                If InsertMasterExpenseSheet() = False Then
                    Dim ErrorMessage As String = "Error: Unable to save the expense sheet. A description is required."
                    Me.ShowNotFoundMessage(ErrorMessage)
                    UIUtilities.SetFocus(Me.DescriptionTextBox)
                    e.Cancel = True
                End If
            End If
            If Me.FormView1.CurrentMode = FormViewMode.Edit Then
                If LocaleUtilitiesBLL.ShowClientInExpenseSheet = True Then
                    e.NewValues.Item("AccountClientId") = CType(Me.FormView1.FindControl("ddlClientId"), DropDownList).SelectedValue
                Else
                    e.NewValues.Item("AccountClientId") = 0
                End If
                e.NewValues.Item("AccountProjectId") = CType(Me.FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
                e.NewValues.Item("AccountProjectTaskId") = CType(Me.FormView1.FindControl("ddlAccountProjectTaskId"), DropDownList).SelectedValue
                e.NewValues.Item("AccountExpenseId") = CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue
                e.NewValues.Item("IsBillable") = CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Checked
                e.NewValues.Item("Reimburse") = CType(Me.FormView1.FindControl("chkReimburse"), CheckBox).Checked
                e.NewValues.Item("AccountCurrencyId") = CType(Me.FormView1.FindControl("ddlAccountCurrencyId"), DropDownList).SelectedValue
                e.NewValues.Item("AccountPaymentMethodId") = CType(Me.FormView1.FindControl("ddlAccountPaymentMethodId"), DropDownList).SelectedValue
                e.NewValues.Item("AccountTaxZoneId") = CType(Me.FormView1.FindControl("ddlAccountTaxZoneId"), DropDownList).SelectedValue
                If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
                    e.NewValues.Item("AccountEmployeeExpenseSheetId") = Me.Request.QueryString("AccountEmployeeExpenseSheetId")
                Else
                    e.NewValues.Item("AccountEmployeeExpenseSheetId") = Me.ViewState("AccountEmployeeExpenseSheetId")
                End If
                e.NewValues.Item("AccountEmployeeId") = Me.ddlEmployeeName.SelectedValue
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemCreated(sender As Object, e As System.EventArgs) Handles FormView1.ItemCreated
        AccountCustomFieldBLL.CreateCustomFieldOnFormView_ItemCreated(FormView1, New Guid("756e4460-a713-4bee-b3f0-708fc5be21bd"), , , "26px")
    End Sub
    ''' <summary>
    ''' Show message not found of specified strMessage
    ''' </summary>
    ''' <param name="strMessage"></param>
    ''' <remarks></remarks>
    Public Sub ShowNotFoundMessage(ByVal strMessage As String)
        Dim strScript As String = "alert('" & strMessage & "');"
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    ''' <summary>
    ''' Calculate amount and reimburse
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CalculateAmountAndReimburse()
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        Dim ExchangeRate As Double
        If Not IsValidAllTextBoxValue() Then
            Return
        End If
        Dim AccountEmployeeExpenseSheetId As Guid
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        End If
        Dim TotalAmount As Double
        Dim dtExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusDataTable = New AccountExpenseEntryBLL().GetvueAccountExpenseEntryWithLastStausByEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim drExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryWithLastStatusRow

        If dtExpenseEntry.Rows.Count > 0 Then
            drExpenseEntry = dtExpenseEntry.Rows(0)
            For Each drExpenseEntry In dtExpenseEntry.Rows
                If Not IsDBNull(drExpenseEntry("Reimburse")) Then
                    If drExpenseEntry.Reimburse <> False Then
                        TotalAmount += drExpenseEntry.Amount / drExpenseEntry.ExchangeRate
                    End If
                End If
            Next
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If CType(Me.FormView1.FindControl("chkReimburse"), CheckBox).Checked = True Then
                Dim SelectedDate As Date
                Date.TryParse(Me.ddlExpenseSheetDate.SelectedItem.ToString(), SelectedDate)
                ExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(CType(Me.FormView1.FindControl("ddlAccountCurrencyId"), DropDownList).SelectedValue, SelectedDate)
                If ExchangeRate <> 0 Then
                    TotalAmount += CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text / ExchangeRate
                Else
                    TotalAmount += CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text / 1
                End If
                txtTotalReimbursement.Text = String.Format("{0:N}", TotalAmount)
            End If
        End If
        If Not ddlReimbursementCurrency.SelectedValue = "" Then
            Dim SelectedDate As Date
            Date.TryParse(Me.ddlExpenseSheetDate.SelectedItem.ToString(), SelectedDate)
            ExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(ddlReimbursementCurrency.SelectedValue, SelectedDate)
            Dim TotalReimbursementAmount As Double
            If ExchangeRate <> 0 Then
                TotalReimbursementAmount = ExchangeRate * TotalAmount
            Else
                TotalReimbursementAmount = 1 * TotalAmount
            End If
            txtTotalReimbursement.Text = String.Format("{0:N}", TotalReimbursementAmount)
        End If
    End Sub
    ''' <summary>
    ''' Check valid all text box value
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValidAllTextBoxValue() As Boolean
        Dim AmountValue As Single
        If CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Visible = True Then
            If Not Single.TryParse(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text, AmountValue) Then
                CType(Me.FormView1.FindControl("lblNetAmountNR"), Label).Visible = True
                Return False
            End If
        End If
        If CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Visible = True Then
            If Not Single.TryParse(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text, AmountValue) Then
                CType(Me.FormView1.FindControl("lblAmountNR"), Label).Visible = True
                Return False
            End If
        End If
        If CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Visible = True Then
            If Not Single.TryParse(CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text, AmountValue) Then
                Return False
            End If
        End If
        If CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Visible = True Then
            If Not Single.TryParse(CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text, AmountValue) Then
                Return False
            End If
            'Me.FormView1.FindControl("HideAst").Visible = False
            'ElseIf CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Visible = False Then
            '    Me.FormView1.FindControl("HideAst").Visible = True
        End If
        If CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Visible = True Then
            If Not Single.TryParse(CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text, AmountValue) Then
                Return False
            End If
        End If
        Return True
    End Function
    ''' <summary>
    ''' Calculation of specified IsUserTaxAmount, IsUserChanged, IsChangedNetAmount
    ''' </summary>
    ''' <param name="IsUserTaxAmount"></param>
    ''' <param name="IsUserChanged"></param>
    ''' <param name="IsChangedNetAmount"></param>
    ''' <remarks></remarks>
    Public Sub Calculation(Optional ByVal IsUserTaxAmount As Boolean = False, Optional ByVal IsUserChanged As Boolean = False, Optional ByVal IsChangedNetAmount As Boolean = False)
        If Not IsValidAllTextBoxValue() Then
            Return
        End If
        If CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text <> "" Then
            Me.CalculateAmountAndReimburse()
            Dim AccountExpenseId As Integer
            If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                If Not CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue = "" Then
                    AccountExpenseId = CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue
                End If
            Else
                AccountExpenseId = CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue
            End If
            SetCalculationForAllTextBox(IsUserTaxAmount, IsUserChanged, IsChangedNetAmount, AccountExpenseId)
        End If
    End Sub
    ''' <summary>
    ''' Set calculation for all text box of specified IsUserTaxAmount, IsUserChanged, IsChangedNetAmount, AccountExpenseId
    ''' </summary>
    ''' <param name="IsUserTaxAmount"></param>
    ''' <param name="IsUserChanged"></param>
    ''' <param name="IsChangedNetAmount"></param>
    ''' <param name="AccountExpenseId"></param>
    ''' <remarks></remarks>
    Public Sub SetCalculationForAllTextBox(ByVal IsUserTaxAmount As Boolean, ByVal IsUserChanged As Boolean, ByVal IsChangedNetAmount As Boolean, ByVal AccountExpenseId As Integer)
        Dim dtExpenseEntrys As TimeLiveDataSet.AccountExpenseEntryDataTable = New AccountExpenseEntryBLL().GetAccountExpenseEntriesByAccountExpenseEntryId(Me.FormView1.DataKey("AccountExpenseEntryId"))
        Dim drExpenseEntrys As TimeLiveDataSet.AccountExpenseEntryRow
        If IsUserChanged Then
            If dtExpenseEntrys.Rows.Count > 0 Then
                drExpenseEntrys = dtExpenseEntrys.Rows(0)
                CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = drExpenseEntrys.Amount
                If Not IsDBNull(drExpenseEntrys.Item("AmountBeforeTax")) Then
                    CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = drExpenseEntrys.AmountBeforeTax
                End If
                If Not IsDBNull(drExpenseEntrys.Item("TaxAmount")) Then
                    CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text = drExpenseEntrys.TaxAmount
                End If
                If Not IsDBNull(drExpenseEntrys.Item("Quantity")) Then
                    CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text = drExpenseEntrys.Quantity
                End If
                If Not IsDBNull(drExpenseEntrys.Item("Rate")) Then
                    CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text = drExpenseEntrys.Rate
                End If
            End If
        Else
            Dim ExpenseBLL As New AccountExpenseBLL
            Dim dtAccountExpenseWithTaxCode As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable = ExpenseBLL.GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseId(DBUtilities.GetSessionAccountId, AccountExpenseId)
            Dim drAccountExpenseWithTaxCode As TimeLiveDataSet.vueAccountExpenseWithTaxCodeRow

            If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
                drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)
                If Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    If dtExpenseEntrys.Rows.Count > 0 Then
                        drExpenseEntrys = dtExpenseEntrys.Rows(0)
                        If CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = "" Then
                            CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = drExpenseEntrys.Amount
                            CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text = 0
                            CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = drExpenseEntrys.Amount
                        End If
                    End If
                    If IsUserTaxAmount = False Then
                        Me.TaxFormulaEvaluate(AccountExpenseId)
                    End If
                    CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = CSng(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text) + CSng(CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text)
                End If
                If drAccountExpenseWithTaxCode.IsQuantityField = True And IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text * CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text
                End If
                If drAccountExpenseWithTaxCode.IsQuantityField <> False And Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    If IsChangedNetAmount = False Then
                        CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text * CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text
                    End If
                    If IsUserTaxAmount = False Then
                        Me.TaxFormulaEvaluate(AccountExpenseId)
                    End If
                    CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = CSng(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text) + CSng(CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set enabled for amount text box 
    ''' </summary>
    ''' <param name="Enabled"></param>
    ''' <remarks></remarks>
    Public Sub SetEnabledForAmountTextBox(ByVal Enabled As Boolean)
        CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).ReadOnly = Enabled
    End Sub
    ''' <summary>
    ''' Set enabled for net amount text box 
    ''' </summary>
    ''' <param name="Enabled"></param>
    ''' <remarks></remarks>
    Public Sub SetEnabledForNetAmountTextBox(ByVal Enabled As Boolean)
        CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).ReadOnly = Enabled
    End Sub
    ''' <summary>
    ''' Set enabled for tax amount text box 
    ''' </summary>
    ''' <param name="Enabled"></param>
    ''' <remarks></remarks>
    Public Sub SetEnabledForTaxAmountTextBox(ByVal Enabled As Boolean)
        CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).ReadOnly = Enabled
    End Sub
    ''' <summary>
    ''' Set uer interface for tax field enabled
    ''' </summary>
    ''' <param name="Enabled"></param>
    ''' <remarks></remarks>
    Public Sub SetUIForTaxField(ByVal Enabled As Boolean)
        CType(Me.FormView1.FindControl("lblTax"), Label).Visible = Enabled
        CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Visible = Enabled
    End Sub
    ''' <summary>
    ''' Set user interface for quantity field enabled
    ''' </summary>
    ''' <param name="Enabled"></param>
    ''' <remarks></remarks>
    Public Sub SetUIForQuantityField(ByVal Enabled As Boolean)
        CType(Me.FormView1.FindControl("lblQuantity"), Label).Visible = Enabled
        CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Visible = Enabled
        CType(Me.FormView1.FindControl("lblRate"), Label).Visible = Enabled
        CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Visible = Enabled
    End Sub
    ''' <summary>
    ''' Set user interface for net amount field enabled
    ''' </summary>
    ''' <param name="Enabled"></param>
    ''' <remarks></remarks>
    Public Sub SetUIForNetAmountField(ByVal Enabled As Boolean)
        CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Visible = Enabled
        CType(Me.FormView1.FindControl("lblNetAmount"), Label).Visible = Enabled
    End Sub
    ''' <summary>
    ''' Set default values for form view
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaultValues()
        CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text = 0
        CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text = 0
        CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = 0
        CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text = 0
        CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = 0
    End Sub
    ''' <summary>
    ''' Set validator enabled
    ''' </summary>
    ''' <param name="Enabled"></param>
    ''' <remarks></remarks>
    Public Sub SetValidatorEnabled(ByVal Enabled As Boolean)
        If Me.GetFocusTextBox = "NetAmount" Or Me.GetFocusTextBox = "QuantityAndNetAmount" Then
            CType(Me.FormView1.FindControl("RangeValidatorNetAmount"), RangeValidator).Enabled = Enabled
        Else
            CType(Me.FormView1.FindControl("RangeValidatorNetAmount"), RangeValidator).Enabled = False
        End If
        CType(Me.FormView1.FindControl("RangeValidatorAmount"), RangeValidator).Enabled = Enabled
    End Sub
    ''' <summary>
    ''' Set text box values by expense of specified AccountExpenseId
    ''' </summary>
    ''' <param name="AccountExpenseId"></param>
    ''' <remarks></remarks>
    Public Sub SetTextBoxValuesByExpense(ByVal AccountExpenseId As Integer)
        If IsValidAllTextBoxValue() Then
            If Me.GetFocusTextBox = "NetAmount" Then
                CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text = 0
                CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text = 0
                TaxFormulaEvaluate(AccountExpenseId)
                If CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text <> 0 Then
                    CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = CSng(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text) + CSng(CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text)
                End If
            ElseIf Me.GetFocusTextBox = "Quantity" Then
                CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text = 0
                CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = 0
                CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text * CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text
            ElseIf Me.GetFocusTextBox = "Amount" Then
                CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text = 0
                CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text = 0
                CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text = 0
                CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = 0
            ElseIf Me.GetFocusTextBox = "QuantityAndNetAmount" Then
                Dim NetAmount As Double = CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox).Text * CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text
                If NetAmount <> 0 Then
                    CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = NetAmount
                End If
                TaxFormulaEvaluate(AccountExpenseId)
                If CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text <> 0 Then
                    CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = CSng(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text) + CSng(CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Get quantity and tax
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQuantityAndTax() As Boolean
        ' SetValidatorEnabled(False)
        If FormView1.CurrentMode = FormViewMode.Insert Then
            SetUITextBoxForFormViewInsertTemplate()
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            SetUITextBoxForFormViewEditTemplate()
        End If
    End Function
    ''' <summary>
    ''' Set user interface text box for form view insert template
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetUITextBoxForFormViewInsertTemplate()
        Me.SetEnabledForAmountTextBox(False)
        Me.SetEnabledForNetAmountTextBox(False)
        Me.SetEnabledForTaxAmountTextBox(False)
        Dim ExpenseBLL As New AccountExpenseBLL
        If CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue <> "" Then
            Dim AccountExpenseId As Integer = CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue
            Dim dtAccountExpenseWithTaxCode As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable = ExpenseBLL.GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseId(DBUtilities.GetSessionAccountId, AccountExpenseId)
            Dim drAccountExpenseWithTaxCode As TimeLiveDataSet.vueAccountExpenseWithTaxCodeRow
            If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
                drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)
                If IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    Me.SetUIForTaxField(False)
                    Me.SetUIForQuantityField(False)
                    Me.SetUIForNetAmountField(False)
                ElseIf drAccountExpenseWithTaxCode.TaxCode <> "" Then
                    Me.SetUIForTaxField(True)
                    CType(Me.FormView1.FindControl("lblTax"), Label).Text = ResourceHelper.GetFromResource(drAccountExpenseWithTaxCode.TaxCode & ":")
                    Me.SetUIForNetAmountField(True)
                    Me.SetUIForQuantityField(False)
                Else
                    Me.SetUIForTaxField(False)
                End If
                If Not IsDBNull(drAccountExpenseWithTaxCode.Item("IsQuantityField")) And drAccountExpenseWithTaxCode.IsQuantityField <> False Then
                    Me.SetUIForQuantityField(True)
                    Me.SetDefaultExpenseRate(drAccountExpenseWithTaxCode, True)
                    CType(Me.FormView1.FindControl("lblQuantity"), Label).Text = "Quantity(" & drAccountExpenseWithTaxCode.QuantityFieldCaption & ")"
                    Me.SetUIForTaxField(False)
                    Me.SetUIForNetAmountField(False)
                    Me.SetEnabledForAmountTextBox(True)
                End If

                If Not IsDBNull(drAccountExpenseWithTaxCode.Item("IsQuantityField")) <> True And IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    Me.SetUIForTaxField(False)
                    Me.SetUIForQuantityField(False)
                    Me.SetUIForNetAmountField(False)
                End If
                If Not IsDBNull(drAccountExpenseWithTaxCode.Item("TaxCode")) Then
                    If drAccountExpenseWithTaxCode.IsQuantityField <> False And drAccountExpenseWithTaxCode.TaxCode <> "" Then
                        Me.SetUIForTaxField(True)
                        Me.SetUIForQuantityField(True)
                        Me.SetDefaultExpenseRate(drAccountExpenseWithTaxCode, True)
                        Me.SetUIForNetAmountField(True)
                        Me.SetEnabledForAmountTextBox(True)
                        Me.SetEnabledForNetAmountTextBox(True)
                        Me.SetEnabledForTaxAmountTextBox(True)
                    End If
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set user interface text box for form view edit template
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetUITextBoxForFormViewEditTemplate()
        Me.SetEnabledForAmountTextBox(False)
        Me.SetEnabledForNetAmountTextBox(False)
        Me.SetEnabledForTaxAmountTextBox(False)
        Dim ExpenseBLL As New AccountExpenseBLL
        If CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue <> 0 Then
            Dim AccountExpenseId As Integer = CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue
            Dim ExpenseEntryBLL As New AccountExpenseEntryBLL
            Dim dt As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable = ExpenseBLL.GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseId(DBUtilities.GetSessionAccountId, AccountExpenseId)
            Dim dr As TimeLiveDataSet.vueAccountExpenseWithTaxCodeRow

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                If IsDBNull(dr("TaxCode")) Then
                    Me.SetUIForTaxField(False)
                    Me.SetUIForQuantityField(False)
                    Me.SetUIForNetAmountField(False)
                Else
                    If dr.TaxCode <> "" Then
                        Me.SetUIForTaxField(True)
                        CType(Me.FormView1.FindControl("lblTax"), Label).Text = ResourceHelper.GetFromResource(dr.TaxCode) & ":"
                    Else
                        Me.SetUIForTaxField(False)
                    End If
                End If
                If dr.IsQuantityField = True Then
                    Me.SetUIForQuantityField(True)
                    CType(Me.FormView1.FindControl("lblQuantity"), Label).Text = "Quantity(" & dr.QuantityFieldCaption & "):"
                    Me.SetDefaultExpenseRate(dr, False)
                    Me.SetUIForTaxField(False)
                    Me.SetUIForNetAmountField(False)
                    Me.SetEnabledForAmountTextBox(True)
                Else
                    Me.SetUIForQuantityField(False)
                    Me.SetUIForTaxField(True)
                    Me.SetUIForNetAmountField(True)
                End If
                If dr.IsQuantityField <> True And IsDBNull(dr.Item("TaxCode")) Then
                    Me.SetUIForTaxField(False)
                    Me.SetUIForQuantityField(False)
                    Me.SetUIForNetAmountField(False)
                End If
                If dr.IsQuantityField <> False And Not IsDBNull(dr("TaxCode")) Then
                    Me.SetUIForTaxField(True)
                    Me.SetUIForQuantityField(True)
                    Me.SetDefaultExpenseRate(dr, False)
                    Me.SetUIForNetAmountField(True)
                    Me.SetEnabledForAmountTextBox(True)
                    Me.SetEnabledForNetAmountTextBox(True)
                    Me.SetEnabledForTaxAmountTextBox(True)
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Set default expense rate
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <param name="IsInsertTemplate"></param>
    ''' <remarks></remarks>
    Public Sub SetDefaultExpenseRate(ByVal dr As TimeLiveDataSet.vueAccountExpenseWithTaxCodeRow, ByVal IsInsertTemplate As Boolean)
        If Not IsDBNull(dr.Item("DefaultExpenseRate")) Then 'And IsInsertTemplate = True Then -- Bugfix: XPTIMESHEETSAPPDEV-5
            CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text = dr.DefaultExpenseRate
        End If
        If dr.DisabledEditingOfRate = True Then
            CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' Evaluate tax formula of specified  AccountExpenseId, IsFromAmount
    ''' </summary>
    ''' <param name="AccountExpenseId"></param>
    ''' <param name="IsFromAmount"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TaxFormulaEvaluate(ByVal AccountExpenseId As Integer, Optional ByVal IsFromAmount As Boolean = False) As Boolean
        If CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text <> "0" Or IsFromAmount Then
            If CType(Me.FormView1.FindControl("ddlAccountTaxZoneId"), DropDownList).SelectedValue <> "" Then
                Dim dtAccountExpenseWithTaxCode As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable = New AccountExpenseBLL().GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseIdAndAccountTaxZoneId(DBUtilities.GetSessionAccountId, AccountExpenseId, CType(Me.FormView1.FindControl("ddlAccountTaxZoneId"), DropDownList).SelectedValue)
                Dim drAccountExpenseWithTaxCode As TimeLiveDataSet.vueAccountExpenseWithTaxCodeRow

                If dtAccountExpenseWithTaxCode.Rows.Count > 0 Then
                    drAccountExpenseWithTaxCode = dtAccountExpenseWithTaxCode.Rows(0)
                    Try
                        If IsFromAmount Then
                            CalculateTaxAmountByAmount(drAccountExpenseWithTaxCode)
                            Return True
                        End If

                        Dim myParser As MathParser
                        myParser = New MathParser

                        myParser.X = Double.Parse(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text)

                        myParser.SetVariable("Net", Double.Parse(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text), Nothing)

                        myParser.Expression = drAccountExpenseWithTaxCode.Formula
                        myParser.OptimizationOn = True

                        CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text = myParser.ValueAsString()

                    Catch exception As Exception
                        Throw New Exception(exception.Message)
                    End Try
                Else
                    CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text = 0
                End If
            End If
        End If
    End Function
    ''' <summary>
    ''' Calculate tax amount by amount of specified drAccountExpenseWithTaxCode
    ''' </summary>
    ''' <param name="drAccountExpenseWithTaxCode"></param>
    ''' <remarks></remarks>
    Public Sub CalculateTaxAmountByAmount(ByVal drAccountExpenseWithTaxCode As TimeLiveDataSet.vueAccountExpenseWithTaxCodeRow)
        Dim TaxAmount As Double
        Dim NetAmount As Double
        Dim IsEvaluate As Boolean
        Dim Amount As Double = CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text
        If drAccountExpenseWithTaxCode.Formula.Contains("Net *") Or drAccountExpenseWithTaxCode.Formula.Contains("Net*") Then
            Dim FormulaAmount As String() = Split(drAccountExpenseWithTaxCode.Formula, "*")
            TaxAmount = FormulaAmount(1)
            NetAmount = Amount / (1 + TaxAmount)
            TaxAmount = Amount - NetAmount
        ElseIf drAccountExpenseWithTaxCode.Formula.Contains("Net") = False Then
            TaxAmount = drAccountExpenseWithTaxCode.Formula
            NetAmount = Amount - TaxAmount
        Else
            CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = String.Format("{0:N}", Amount)
            CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text = String.Format("{0:N}", 0)
            IsEvaluate = True
        End If
        If Not IsEvaluate Then
            CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text = String.Format("{0:N}", NetAmount)
            CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text = String.Format("{0:N}", TaxAmount)
        End If
    End Sub
    ''' <summary>
    ''' Drop down list for reimbursement currency selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlReimbursementCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReimbursementCurrency.SelectedIndexChanged
        Call New AccountBLL().UpdateAccountReimbursementCurrencyId(DBUtilities.GetSessionAccountId, ddlReimbursementCurrency.SelectedValue)
        Me.Calculation()
    End Sub
    ''' <summary>
    ''' Drop down list expense name selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlExpenseName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Me.Calculation()
        Me.GetQuantityAndTax()
        Me.SetTextBoxValuesByExpense(CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue <> "" Then
                CheckExpensesVisibility(CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue)
            End If
        End If
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("DescriptionTextBox"), TextBox))
    End Sub
    ''' <summary>
    ''' Check box reimburse prerender event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub chkReimburse_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CalculateAmountAndReimburse()
    End Sub
    ''' <summary>
    ''' Quantity text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub QuantityTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation()
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("RateTextBox"), TextBox))
    End Sub
    ''' <summary>
    ''' Rate text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub RateTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation()
        If Me.GetFocusTextBox = "Quantity" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "QuantityAndNetAmount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "NetAmount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "Amount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox))
        End If
    End Sub
    ''' <summary>
    ''' Net amount text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub NetAmountTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation(, , True)
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("ddlAccountTaxZoneId"), DropDownList))
    End Sub
    ''' <summary>
    ''' Tax amount text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub TaxAmountTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation(True, , True)
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox))
    End Sub
    ''' <summary>
    ''' Drop down list expense name selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlExpenseName_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.GetQuantityAndTax()
            SetTextBoxValuesByExpense(CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue)
            If CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue <> "" Then
                CheckExpensesVisibility(CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Quantity text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub QuantityTextBox_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation()
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("RateTextBox"), TextBox))
    End Sub
    ''' <summary>
    ''' Rate text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub RateTextBox_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation()
        If Me.GetFocusTextBox = "Quantity" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "QuantityAndNetAmount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "NetAmount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "Amount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox))
        End If
    End Sub
    ''' <summary>
    ''' Net amount text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub NetAmountTextBox_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation(, , True)
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("ddlAccountTaxZoneId"), DropDownList))
    End Sub
    ''' <summary>
    ''' Tax amount text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub TaxAmountTextBox_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation(True, , True)
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox))
    End Sub
    ''' <summary>
    ''' Grid view row deleted event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
        Response.Redirect(Request.RawUrl)
        Me.FormView1.DataBind()

    End Sub
    ''' <summary>
    ''' Drop down list currency id selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlAccountCurrencyId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CalculateAmountAndReimburse()
        If Me.GetFocusTextBox = "NetAmount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "Quantity" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "QuantityAndNetAmount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "Amount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox))
        End If
    End Sub
    ''' <summary>
    ''' Drop down list currency id selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlAccountCurrencyId_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CalculateAmountAndReimburse()
        If Me.GetFocusTextBox = "NetAmount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "Quantity" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "QuantityAndNetAmount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("QuantityTextBox"), TextBox))
        ElseIf Me.GetFocusTextBox = "Amount" Then
            UIUtilities.SetFocus(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox))
        End If
    End Sub
    ''' <summary>
    ''' Amount text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub AmountTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        SetAmountCalculation()
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox))
    End Sub
    ''' <summary>
    ''' Amount text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub AmountTextBox_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Calculation()
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox))
    End Sub
    ''' <summary>
    ''' Custom validator server validate event
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="args"></param>
    ''' <remarks></remarks>
    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If CType(Me.FormView1.FindControl("ddlProjectName"), DropDownList).SelectedValue <> 0 Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub
    ''' <summary>
    ''' Custom validator server validate event
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="args"></param>
    ''' <remarks></remarks>
    Protected Sub CustomValidator4_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Visible = True Then
            If CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text > 0 Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If
        End If
    End Sub
    ''' <summary>
    ''' Custom validator server validate event 
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="args"></param>
    ''' <remarks></remarks>
    Protected Sub CustomValidator6_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Visible = True Then
            If CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text = "" Then
                args.IsValid = False
                CType(Me.FormView1.FindControl("CustomValidator6"), CustomValidator).ErrorMessage = "*"
            ElseIf CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text > 0 Then
                args.IsValid = True
                CType(Me.FormView1.FindControl("CustomValidator6"), CustomValidator).ErrorMessage = "*"
            Else
                args.IsValid = False
            End If
        End If
    End Sub
    ''' <summary>
    ''' Update expense entry record as submitted of specified AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateExpenseEntryRecordAsSubmitted(ByVal AccountEmployeeExpenseSheetId As Guid)
        Dim BLL As New AccountExpenseEntryBLL
        BLL.UpdateSubmittedByAccountEmployeeExpenseSheetId(True, AccountEmployeeExpenseSheetId)
        BLL.UpdateRejectedByAccountEmployeeExpenseSheetId(False, AccountEmployeeExpenseSheetId)
        BLL.SetApprovalState(Me.GridView1)
    End Sub
    ''' <summary>
    ''' Update expense sheet record as submitted of specified AccountEmployeeExpenseSheetId
    ''' </summary>
    ''' <param name="AccountEmployeeExpenseSheetId"></param>
    ''' <remarks></remarks>
    Public Sub UpdateExpenseSheetRecordAsSubmitted(ByVal AccountEmployeeExpenseSheetId As Guid)
        Dim SheetBLL As New AccountEmployeeExpenseSheetBLL
        SheetBLL.UpdateSubmittedDate(Now.Date, AccountEmployeeExpenseSheetId)
        SheetBLL.UpdateMasterSubmitted(True, AccountEmployeeExpenseSheetId)
        SheetBLL.UpdateMasterRejected(False, AccountEmployeeExpenseSheetId)
        Call New AccountExpenseEntryBLL().UpdateMasterApprovedByDetail(AccountEmployeeExpenseSheetId)
    End Sub
    ''' <summary>
    ''' Drop down list tax zone id selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlAccountTaxZoneId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation(, , True)
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox))
    End Sub
    ''' <summary>
    ''' Drop down list tax zone id selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlAccountTaxZoneId_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Calculation(, , True)
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox))
    End Sub
    ''' <summary>
    ''' Show expense entry status
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Public Sub ShowExpenseEntryStatus(ByVal row As GridViewRow)
        Dim i As Integer = Me.GridView1.Columns.Count - 1
        AccountExpenseEntryBLL.SetSubmittedStatus("lblStatus", "DS0", "lblStatusNote", "imgStatus", row, i, "Approved", "Submitted", "Rejected", Me.GridView1)
    End Sub
    ''' <summary>
    ''' Button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.SetValidatorEnabled(True)
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue <> "" Then
                ServerSideConfirmationForExpensesVisibility()
            End If
        End If
    End Sub
    ''' <summary>
    ''' Button add click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        SetVisibleFalseForPaymentStatusElements()

        If IsValidAllTextBoxValue() Then
            'Me.SetValidatorEnabled(True)
            Me.GridView1.Visible = True
            Me.btnAddExpenseEntry.Visible = True
            Me.FormView1.Visible = False
        End If

        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue <> "" Then
                ServerSideConfirmationForExpensesVisibility()
            End If
        End If

    End Sub
    ''' <summary>
    ''' Insert master expense sheet
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertMasterExpenseSheet() As Boolean
        Dim CustomFieldBLL As New AccountCustomFieldBLL

        If Me.DescriptionTextBox.Text <> "" Then
            Dim SheetBLL As New AccountEmployeeExpenseSheetBLL
            Dim AccountEmployeeExpenseSheetId As Guid
            For n As Integer = 1 To 15
                Dim UIObject As Object = CustomTable.FindControl("CustomField" & n)
                If Not UIObject Is Nothing Then
                    If TypeOf UIObject Is DropDownList Then
                        Me.ViewState.Add("CustomField" & n, UIObject.SelectedValue)
                    ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
                        Me.ViewState.Add("CustomField" & n, UIObject.SelectedDate)
                    ElseIf TypeOf UIObject Is TextBox Then
                        Me.ViewState.Add("CustomField" & n, UIObject.Text)
                    End If
                    If Me.ViewState("CustomField" & n).ToString = "" Or Me.ViewState("CustomField" & n).ToString = "None" Then
                        If AccountCustomFieldBLL.CheckIsRequiredCustomField("CustomField" & n, MasterEnityTypeIdExpenseSheet) Then
                            Dim Caption As String = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEnityTypeIdExpenseSheet)
                            ErrorMessage = "Error: Unable to save the expense sheet." & " " & Caption & " " & "is required."
                            ''Dim ErrorMessage As String = "Unable to save the expense sheet. A description is required."
                            Return False
                        End If
                    End If
                End If
            Next

            Dim SelectedDate As Date
            Date.TryParse(Me.ddlExpenseSheetDate.SelectedItem.ToString(), SelectedDate)

            If Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing And Me.ViewState("AccountEmployeeExpenseSheetId") Is Nothing Then
                AccountEmployeeExpenseSheetId = SheetBLL.AddAccountEmployeeExpenseSheet(DBUtilities.GetSessionAccountId, Me.ddlEmployeeName.SelectedValue, Me.DescriptionTextBox.Text, SelectedDate, False, False, False, False, Now.Date, Me.ViewState("CustomField1"), Me.ViewState("CustomField2"), Me.ViewState("CustomField3"), Me.ViewState("CustomField4"), Me.ViewState("CustomField5"), Me.ViewState("CustomField6"), Me.ViewState("CustomField7"), Me.ViewState("CustomField8"), Me.ViewState("CustomField9"), Me.ViewState("CustomField10"), Me.ViewState("CustomField11"), Me.ViewState("CustomField12"), Me.ViewState("CustomField13"), Me.ViewState("CustomField14"), Me.ViewState("CustomField15"))
                Me.ViewState.Add("AccountEmployeeExpenseSheetId", AccountEmployeeExpenseSheetId)
            Else

                If Me.ViewState("AccountEmployeeExpenseSheetId") Is Nothing Then
                    AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
                Else
                    AccountEmployeeExpenseSheetId = New Guid(Me.ViewState("AccountEmployeeExpenseSheetId").ToString())
                End If

                SheetBLL.UpdateAccountEmployeeExpenseSheet(Me.DescriptionTextBox.Text, SelectedDate, AccountEmployeeExpenseSheetId, Me.ViewState("CustomField1"), Me.ViewState("CustomField2"), Me.ViewState("CustomField3"), Me.ViewState("CustomField4"), Me.ViewState("CustomField5"), Me.ViewState("CustomField6"), Me.ViewState("CustomField7"), Me.ViewState("CustomField8"), Me.ViewState("CustomField9"), Me.ViewState("CustomField10"), Me.ViewState("CustomField11"), Me.ViewState("CustomField12"), Me.ViewState("CustomField13"), Me.ViewState("CustomField14"), Me.ViewState("CustomField15"))

                If Me.ViewState("AccountEmployeeExpenseSheetId") Is Nothing Then
                    Me.ViewState.Add("AccountEmployeeExpenseSheetId", AccountEmployeeExpenseSheetId)
                End If

            End If
                Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Get focus text box
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFocusTextBox() As String
        Dim ExpenseBLL As New AccountExpenseBLL
        Dim AccountExpenseId As Integer
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue <> "" Then
                AccountExpenseId = CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue
            End If
        Else
            AccountExpenseId = CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue
        End If
        Dim dt As TimeLiveDataSet.vueAccountExpenseWithTaxCodeDataTable = ExpenseBLL.GetvueAccountExpensesWithTaxCodeByAccountIdAndAccountExpenseId(DBUtilities.GetSessionAccountId, AccountExpenseId)
        Dim dr As TimeLiveDataSet.vueAccountExpenseWithTaxCodeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("TaxCode")) And dr.Item("IsQuantityField").ToString = "False" Then
                Return "NetAmount"
            ElseIf dr.Item("IsQuantityField").ToString = "True" And Not IsDBNull(dr.Item("TaxCode")) Then
                Return "QuantityAndNetAmount"
            ElseIf dr.Item("IsQuantityField").ToString = "True" And IsDBNull(dr.Item("TaxCode")) Then
                Return "Quantity"
            ElseIf IsDBNull(dr.Item("TaxCode")) And dr.Item("IsQuantityField").ToString = "False" Then
                Return "Amount"
            End If
        End If
        Return ""
    End Function
    ''' <summary>
    ''' Set data in master record 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDataInMasterRecord()
        Dim SelectedDate As Date
        Date.TryParse(Me.ddlExpenseSheetDate.SelectedItem.ToString(), SelectedDate)
        Dim CustomFieldBLl As New AccountCustomFieldBLL
        Dim ExpenseBLL As New AccountEmployeeExpenseSheetBLL
        Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = ExpenseBLL.GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.DescriptionTextBox.Text = dr.Description
            SelectedDate = dr.ExpenseSheetDate
            For n As Integer = 1 To 15
                Dim UIObject As Object = CustomTable.FindControl("CustomField" & n)
                If Not UIObject Is Nothing Then
                    If Not IsDBNull(dr.Item("CustomField" & n)) Then
                        If TypeOf UIObject Is DropDownList Then
                            UIObject.SelectedValue = dr.Item("CustomField" & n)
                        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
                            UIObject.SelectedDate = dr.Item("CustomField" & n)
                        ElseIf TypeOf UIObject Is TextBox Then
                            UIObject.Text = dr.Item("CustomField" & n)
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    ''' <summary>
    ''' Button master update click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnMasterUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If InsertMasterExpenseSheet() = False Then
            ''Dim ErrorMessage As String = "Unable to save the expense sheet. A description is required."
            Me.ShowNotFoundMessage(ErrorMessage)
            UIUtilities.SetFocus(Me.DescriptionTextBox)
            Return
        Else
            Me.SetDataInMasterRecord()
        End If
    End Sub
    ''' <summary>
    ''' Copy expense sheet
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CopyExpenseSheet()
        Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Dim NewExpenseSheetID As Guid = System.Guid.NewGuid
        Call New AccountEmployeeExpenseSheetBLL().InsertAccountEmployeeExpenseSheetByExpenseSheetId(AccountEmployeeExpenseSheetId, NewExpenseSheetID)
        Call New AccountExpenseEntryBLL().InsertAccountExpenseEntryByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId, NewExpenseSheetID)
        Call New AccountAttachmentsBLL().InsertAccountAttachmentsByExpenseSheetId(NewExpenseSheetID)
        Dim strMessage As String = "Expense sheet copied successfully."
        Dim strScript As String = "alert('" & strMessage & "'); window.location = 'AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSHeetId=" & NewExpenseSheetID.ToString & "';"
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
        'Response.Redirect("~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSHeetId=" & NewExpenseSheetID.ToString & "&IsCopy=False")
    End Sub
    ''' <summary>
    ''' Amount text box text changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub AmountTextBox_TextChanged2(ByVal sender As Object, ByVal e As System.EventArgs)
        SetAmountCalculation()
        UIUtilities.SetFocus(CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox))
    End Sub
    ''' <summary>
    ''' Set amount calculation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetAmountCalculation()
        Dim AccountExpenseId As Integer
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If Not CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue = "" Then
                AccountExpenseId = CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue
            End If
        Else
            AccountExpenseId = CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue
        End If
        Dim Amount As Single
        If Single.TryParse(CType(Me.FormView1.FindControl("AmountTextBox"), TextBox).Text, Amount) Then
            TaxFormulaEvaluate(AccountExpenseId, True)
        End If
    End Sub
    ''' <summary>
    ''' Button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.SetDefaultValues()
        'FormView1.ChangeMode(FormViewMode.Insert)
        Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Response.Redirect("~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSheetId=" & AccountEmployeeExpenseSheetId.ToString(), False)
    End Sub
    ''' <summary>
    ''' Drop down list employee name selected index changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlEmployeeName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmployeeName.SelectedIndexChanged
        IsCurrentEmployeeHasPermissionOffADD()
        'Me.dsAccountProjectObject.DataBind()
        'Me.dsAccountProjectObjectInsert.DataBind()
        'Response.Redirect("~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSheetId=" & Me.ViewState("AccountEmployeeExpenseSheetId").ToString & "&AccountEmployeeId=" & Me.ddlEmployeeName.SelectedValue)
        Session("dllEmployeeSelected") = CType(sender, DropDownList).SelectedValue
        Response.Redirect(Request.RawUrl)
    End Sub
    ''' <summary>
    ''' Check current employee has permission off add
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub IsCurrentEmployeeHasPermissionOffADD()
        SetDropDownEmployeeByExpenseSheetId()
        If Not AccountPagePermissionBLL.IsPageHasPermissionOf(135, 2) = True Then
            If FormView1.CurrentMode = FormViewMode.Insert Then
                CType(Me.FormView1.FindControl("btnAdd"), Button).Enabled = False
                Me.btnAddExpenseEntry.Enabled = False
            ElseIf FormView1.CurrentMode = FormViewMode.Edit Then
                CType(Me.FormView1.FindControl("Button1"), Button).Enabled = False
            End If
            Me.btnMasterUpdate.Enabled = False
            Me.btnSubmit.Enabled = False
        Else
            If FormView1.CurrentMode = FormViewMode.Insert Then
                CType(Me.FormView1.FindControl("btnAdd"), Button).Enabled = True
                Me.btnAddExpenseEntry.Enabled = True
            ElseIf FormView1.CurrentMode = FormViewMode.Edit Then
                CType(Me.FormView1.FindControl("Button1"), Button).Enabled = True
            End If
            Me.btnMasterUpdate.Enabled = True
            If NoEntrys = False Then
                Me.btnSubmit.Enabled = True
            End If

        End If
        Me.SetCascadingAccountIdForProject()
        Me.dsAccountProjectObjectInsert.SelectParameters("AccountEmployeeId").DefaultValue = ddlEmployeeName.SelectedValue
        Me.dsAccountProjectObject.SelectParameters("AccountEmployeeId").DefaultValue = ddlEmployeeName.SelectedValue
        Me.dsAccountProjectObjectInsert.DataBind()
        Me.dsAccountProjectObject.DataBind()
    End Sub
    ''' <summary>
    ''' Set drop down employee by expense sheet id
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDropDownEmployeeByExpenseSheetId()
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            Dim ExpenseBLL As New AccountEmployeeExpenseSheetBLL
            Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
            Dim dt As AccountExpenseEntry.AccountEmployeeExpenseSheetDataTable = ExpenseBLL.GetAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
            Dim dr As AccountExpenseEntry.AccountEmployeeExpenseSheetRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                Me.ddlEmployeeName.SelectedValue = dr.AccountEmployeeId
                Me.ddlEmployeeName.Enabled = False
            End If
        End If
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As System.EventArgs) Handles btnPrint.Click

    End Sub

    Protected Sub btnAddExpenseEntry_Click(sender As Object, e As System.EventArgs) Handles btnAddExpenseEntry.Click
        IsCurrentEmployeeHasPermissionOffADD()
        Me.FormView1.Visible = True
        Me.GridView1.Visible = False
        Me.btnAddExpenseEntry.Visible = False
        Me.btnPrint.Visible = False
        Me.btnSubmit.Visible = False
        Me.CtlStatusLegend1.Visible = False
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs)

        If Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            If Me.ViewState("AccountEmployeeExpenseSheetId") IsNot Nothing Then
                Response.Redirect("~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSheetId=" & Me.ViewState("AccountEmployeeExpenseSheetId").ToString(), False)
            End If
        End If

        Me.GridView1.Visible = True
        Me.btnAddExpenseEntry.Visible = True
        Me.FormView1.Visible = False
        Me.btnPrint.Visible = True
        Me.btnSubmit.Visible = True
    End Sub
    Protected Sub ddlAccountProjectId_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        'Me.SetCascadingAccountIdForProject()
    End Sub

    Protected Sub ddlClientId_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        'Me.SetCascadingAccountIdForProject()
    End Sub

    Protected Sub FormView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.FormViewPageEventArgs) Handles FormView1.PageIndexChanging

    End Sub

    Protected Sub chkReimburse_CheckedChanged(sender As Object, e As System.EventArgs)
        Me.Calculation()
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
    Protected Sub btnBackExpenseEntry0_Click(sender As Object, e As EventArgs) Handles btnBackExpenseEntry0.Click
        Response.Redirect("~/Employee/AccountExpenseEntry.aspx")
    End Sub

    ''' <summary>
    ''' Button submit click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' 
    Protected Sub btnSubmit_Click1(sender As Object, e As EventArgs) Handles btnSubmit.Click

        If VerifyIfGridHasRows() = False Then
            ShowNotFoundMessage("The sheet couldn't be submitted")
            Return
        End If

        Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        UpdateExpenseEntryRecordAsSubmitted(AccountEmployeeExpenseSheetId)
        UpdateExpenseSheetRecordAsSubmitted(AccountEmployeeExpenseSheetId)
        Call New AccountExpenseEntryBLL().SendExpenseApprovalPendingEmail(AccountEmployeeExpenseSheetId)
        Response.Redirect("~/Employee/AccountExpenseEntryForm.aspx?AccountEmployeeExpenseSheetId=" & Me.Request.QueryString("AccountEmployeeExpenseSheetId"), False)

    End Sub

    Private Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
        If e.SortExpression <> CType(sender, GridView).SortExpression Then
            e.SortDirection = SortDirection.Descending
        End If
    End Sub
    Protected Sub ddlExpenseSheetDate_SelectedIndexChanged(sender As Object, e As EventArgs)

        Session("ddlExpenseSheetDate") = CType(sender, DropDownList).SelectedValue
        'Response.Redirect(Request.RawUrl)

    End Sub
    Protected Sub btnAddCopy_Click(sender As Object, e As EventArgs)

        If IsValidAllTextBoxValue() Then
            CreateNewExpenseEntry()
        End If

    End Sub
    Private Sub CheckExpensesVisibility(ByVal AccountExpenseId As Integer)
        Dim dtAccountExpense As TimeLiveDataSet.AccountExpenseDataTable = New AccountExpenseBLL().GetAccountExpensesByAccountExpenseId(AccountExpenseId)
        Dim drAccountExpense As TimeLiveDataSet.AccountExpenseRow = dtAccountExpense.Rows(0)

        If dtAccountExpense.Rows.Count > 0 Then
            If Not IsDBNull(drAccountExpense.Item("BillableIsReadOnly")) Then
                Dim ReadOnlychk = drAccountExpense.Item("BillableIsReadOnly")

                If ReadOnlychk = True Then
                    CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Enabled = False
                Else
                    CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Enabled = True
                End If
                If Not IsDBNull(drAccountExpense.Item("IsBillable")) Then
                    CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Checked = drAccountExpense.Item("IsBillable")
                End If
            End If

            If Not IsDBNull(drAccountExpense.Item("ReimburseIsReadOnly")) Then
                Dim ReadOnlychk = drAccountExpense.Item("ReimburseIsReadOnly")

                If ReadOnlychk = True Then
                    CType(Me.FormView1.FindControl("chkReimburse"), CheckBox).Enabled = False
                Else
                    CType(Me.FormView1.FindControl("chkReimburse"), CheckBox).Enabled = True
                End If
                If Not IsDBNull(drAccountExpense.Item("Reimburse")) Then
                    CType(Me.FormView1.FindControl("chkReimburse"), CheckBox).Checked = drAccountExpense.Item("Reimburse")
                End If
            End If

        End If

    End Sub
    Private Sub ServerSideConfirmationForExpensesVisibility()

        'Edit Mode

        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue <> "" Then

                Dim AccountExpenseId = CType(Me.FormView1.FindControl("ddlExpenseNameEdit"), DropDownList).SelectedValue
                Dim dtAccountExpense As TimeLiveDataSet.AccountExpenseDataTable = New AccountExpenseBLL().GetAccountExpensesByAccountExpenseId(AccountExpenseId)
                Dim drAccountExpense As TimeLiveDataSet.AccountExpenseRow = dtAccountExpense.Rows(0)

                If dtAccountExpense.Rows.Count > 0 Then

                    If Not IsDBNull(drAccountExpense.Item("BillableIsReadOnly")) Then
                        Dim ReadOnlychk = drAccountExpense.Item("BillableIsReadOnly")

                        If ReadOnlychk = True Then
                            CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Checked = drAccountExpense.Item("IsBillable")
                        End If

                    End If

                    If Not IsDBNull(drAccountExpense.Item("ReimburseIsReadOnly")) Then
                        Dim ReadOnlychk = drAccountExpense.Item("ReimburseIsReadOnly")

                        If ReadOnlychk = True Then
                            CType(Me.FormView1.FindControl("chkReimburse"), CheckBox).Checked = drAccountExpense.Item("Reimburse")
                        End If
                    End If
                End If
            End If
        End If

        'Insert Mode

        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue <> "" Then

                Dim AccountExpenseId = CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue
                Dim dtAccountExpense As TimeLiveDataSet.AccountExpenseDataTable = New AccountExpenseBLL().GetAccountExpensesByAccountExpenseId(AccountExpenseId)
                Dim drAccountExpense As TimeLiveDataSet.AccountExpenseRow = dtAccountExpense.Rows(0)

                If dtAccountExpense.Rows.Count > 0 Then

                    If Not IsDBNull(drAccountExpense.Item("BillableIsReadOnly")) Then
                        Dim ReadOnlychk = drAccountExpense.Item("BillableIsReadOnly")

                        If ReadOnlychk = True Then
                            CType(Me.FormView1.FindControl("chkIsBillable"), CheckBox).Checked = drAccountExpense.Item("IsBillable")
                        End If

                    End If

                    If Not IsDBNull(drAccountExpense.Item("ReimburseIsReadOnly")) Then
                        Dim ReadOnlychk = drAccountExpense.Item("ReimburseIsReadOnly")

                        If ReadOnlychk = True Then
                            CType(Me.FormView1.FindControl("chkReimburse"), CheckBox).Checked = drAccountExpense.Item("Reimburse")
                        End If
                    End If
                End If
            End If

        End If
    End Sub
    Private Sub CreateNewExpenseEntry()

        If ValidateCustomFields() = False Then
            ShowNotFoundMessage(ErrorMessage)
            Return
        End If

        Dim AccountId As Integer
        AccountId = 354
        Dim AccountExpenseEntryDate As Date = CType(CType(Me.FormView1.FindControl("txtDate"), eWorld.UI.CalendarPopup).PostedDate, Date)
        Dim AccountEmployeeId As Integer
        AccountEmployeeId = CType(Me.Parent.FindControl("CtlAccountExpenseEntryList1").FindControl("ddlEmployeeName"), DropDownList).SelectedValue
        Dim AccountClientId As Integer
        AccountClientId = 0
        Dim AccountProjectId As Integer
        AccountProjectId = CType(FormView1.FindControl("ddlAccountProjectId"), DropDownList).SelectedValue
        Dim AccountProjectTaskId As Integer
        AccountProjectTaskId = 0
        Dim AccountExpenseId As Integer
        AccountExpenseId = CType(FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue

        Dim Amount As Double
        Double.TryParse(CType(FormView1.FindControl("AmountTextBox"), TextBox).Text, Amount)

        Dim RandomDate As New DateTime
        Dim CreatedByEmployeeId As Integer
        CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
        Dim ModifiedByEmployeeId As Integer
        ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
        Dim Description As String
        Description = CType(FormView1.FindControl("DescriptionTextBox"), TextBox).Text
        Dim IsBillable As Boolean
        IsBillable = CType(FormView1.FindControl("chkIsBillable"), CheckBox).Checked
        Dim Reimburse As Boolean
        Reimburse = CType(FormView1.FindControl("chkReimburse"), CheckBox).Checked
        Dim AccountCurrencyId As Integer
        AccountCurrencyId = CType(FormView1.FindControl("ddlAccountCurrencyId"), DropDownList).SelectedValue

        Dim Quantity As Double
        Double.TryParse(CType(FormView1.FindControl("QuantityTextBox"), TextBox).Text, Quantity)

        Dim Rate As Double
        Double.TryParse(CType(Me.FormView1.FindControl("RateTextBox"), TextBox).Text, Rate)

        Dim AmountBeforeTax As Double
        If CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text IsNot Nothing Then
            Double.TryParse(CType(Me.FormView1.FindControl("NetAmountTextBox"), TextBox).Text, AmountBeforeTax)
        Else
            AmountBeforeTax = 0
        End If

        Dim TaxAmount As Double
        Double.TryParse(CType(Me.FormView1.FindControl("TaxAmountTextBox"), TextBox).Text, TaxAmount)

        Dim AccountPaymentMethodId As System.Nullable(Of Integer) = CType(FormView1.FindControl("ddlAccountPaymentMethodId"), DropDownList).SelectedValue
        Dim ExchangeRate As Double
        ExchangeRate = 0

        Dim AccountTaxZoneId As Integer
        AccountTaxZoneId = CType(FormView1.FindControl("ddlAccountTaxZoneId"), DropDownList).SelectedValue

        Dim Submitted As Boolean
        Submitted = False

        Dim newSheet As Boolean = False

        Dim AccountEmployeeExpenseSheetId As Guid
        If Me.Request.QueryString("AccountEmployeeExpenseSheetId") IsNot Nothing Then
            AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Else
            If Me.ViewState("AccountEmployeeExpenseSheetId") IsNot Nothing Then
                AccountEmployeeExpenseSheetId = New Guid(Me.ViewState("AccountEmployeeExpenseSheetId").ToString())
            Else
                If InsertMasterExpenseSheet() Then
                    AccountEmployeeExpenseSheetId = New Guid(Me.ViewState("AccountEmployeeExpenseSheetId").ToString())
                    newSheet = True
                End If
            End If
        End If

        Dim CustomField1 As String = Me.ViewState("CustomField1").ToString()
        Dim CustomField2 As String = Me.ViewState("CustomField2").ToString()
        Dim CustomField3 As String = Me.ViewState("CustomField3").ToString()
        Dim CustomField4 As String = Me.ViewState("CustomField4").ToString()
        Dim CustomField5 As String = Me.ViewState("CustomField5").ToString()
        Dim CustomField6 As String = Me.ViewState("CustomField6").ToString()
        Dim CustomField7 As String = Me.ViewState("CustomField7").ToString()
        Dim CustomField8 As String = Me.ViewState("CustomField8").ToString()
        Dim CustomField9 As String = Me.ViewState("CustomField9").ToString()
        Dim CustomField10 As String = Me.ViewState("CustomField10").ToString()
        Dim CustomField11 As String = Me.ViewState("CustomField11").ToString()
        Dim CustomField12 As String = Me.ViewState("CustomField12").ToString()
        Dim CustomField13 As String = Me.ViewState("CustomField13").ToString()
        Dim CustomField14 As String = Me.ViewState("CustomField14").ToString()
        Dim CustomField15 As String = Me.ViewState("CustomField15").ToString()

        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If CType(Me.FormView1.FindControl("ddlExpenseName"), DropDownList).SelectedValue <> "" Then
                ServerSideConfirmationForExpensesVisibility()
            End If
        End If

        Dim ExpenseEntryBll As New AccountExpenseEntryBLL

        Try
            ExpenseEntryBll.AddAccountExpenseEntry(AccountId, AccountExpenseEntryDate, AccountEmployeeId, AccountClientId, AccountProjectId, AccountProjectTaskId, AccountExpenseId, Amount, RandomDate, CreatedByEmployeeId, RandomDate, ModifiedByEmployeeId, Description, IsBillable, Reimburse, AccountCurrencyId, Quantity, Rate, AmountBeforeTax, TaxAmount, AccountPaymentMethodId, ExchangeRate, AccountTaxZoneId, Submitted, AccountEmployeeExpenseSheetId, False, False, False, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15)
        Catch ex As Exception
            ShowNotFoundMessage("Something went wrong.")
        End Try

        If Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            If Me.ViewState("AccountEmployeeExpenseSheetId") IsNot Nothing Then
                If newSheet = False Then
                    ShowNotFoundMessage("New expense entry has been added to the sheet.")
                Else
                    ShowNotFoundMessage("New Expense Sheet has been created.")
                    newSheet = False
                End If
            End If
        Else
            ShowNotFoundMessage("New expense entry has been added to the sheet.")
        End If

    End Sub

    Function ValidateCustomFields() As Boolean
        If Me.DescriptionTextBox.Text <> "" Then
            Dim SheetBLL As New AccountEmployeeExpenseSheetBLL
            For n As Integer = 1 To 15
                Dim UIObject As Object = FormView1.FindControl("CustomField" & n)
                If Not UIObject Is Nothing Then
                    If TypeOf UIObject Is DropDownList Then
                        Me.ViewState.Add("CustomField" & n, UIObject.SelectedValue)
                    ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
                        Me.ViewState.Add("CustomField" & n, UIObject.SelectedDate)
                    ElseIf TypeOf UIObject Is TextBox Then
                        Me.ViewState.Add("CustomField" & n, UIObject.Text)
                    End If
                    If Me.ViewState("CustomField" & n).ToString = "" Or Me.ViewState("CustomField" & n).ToString = "None" Then
                        If AccountCustomFieldBLL.CheckIsRequiredCustomField("CustomField" & n, MasterEntityTypeId) Then
                            Dim Caption As String = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                            ErrorMessage = "Error: Unable to save the expense sheet." & " " & Caption & " " & "is required."
                            ShowNotFoundMessage(ErrorMessage)
                            Return False
                        End If
                    End If
                Else
                    Me.ViewState.Add("CustomField" & n, "")
                End If
            Next
            Return True
        End If
        Return False
    End Function

    Private Function VerifyIfGridHasRows() As Boolean
        If GridView1.Rows.Count >= 1 Then
            If CType(GridView1.Rows(0).Cells(1).Controls(1), Label) Is Nothing Or CType(GridView1.Rows(0).Cells(1).Controls(1), Label).Text = "0" Then
                Return False
            End If
        End If
        Return True
    End Function
    Protected Sub PayBtPaymentStatus_Click(sender As Object, e As EventArgs)

        Dim EntrysToUpdate As New List(Of Integer)

        For Each item As GridViewRow In GridView1.Rows
            If CType(item.Cells(0).Controls(1), CheckBox).Checked = True Then
                EntrysToUpdate.Add(GridView1.DataKeys(item.RowIndex)("AccountExpenseEntryId"))
            End If
        Next


        Dim AccountEmployeeExpenseSheetId As Guid
        If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
            AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        End If

        Dim AccExpenseEntryBll As New AccountExpenseEntryBLL
        AccExpenseEntryBll.UpdatePaymentStatusOfEntrys(EntrysToUpdate, 2)
        AccExpenseEntryBll.UpdatePaymentStatusOfExpenseSheet(AccountEmployeeExpenseSheetId)

        Response.Redirect(Request.RawUrl)

    End Sub
End Class