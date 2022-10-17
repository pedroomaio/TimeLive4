
Partial Class Employee_Controls_ctlAccountExpenseEntryReadOnly
    Inherits System.Web.UI.UserControl
    Dim SumTotalAmount As Double = 0
    Dim SumTaxAmount As Double = 0
    Dim SumNetAmount As Double = 0
    Dim TotalReimbursementAmount As Double = 0
    Dim dtAccountEmployeeId As Integer
    Dim MasterEntityTypeIdExpenseSheet As New Guid("a55df02b-fbfb-4873-b582-6968fbaee589")
    Dim MasterEntityTypeIdExpenseEntry As New Guid("756e4460-a713-4bee-b3f0-708fc5be21bd")
    Dim EmployeeName As String
    Dim CustomFieldRow As TableRow
    Dim CustomFieldCell As TableCell
    Dim CustomFieldTable As Table
    Dim AccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyRow
    Dim filterModel As New EntryArchiveFilter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetAccountBaseCurrency()
        End If

        AccountBaseCurrency = Session("AccountBaseCurrency")

        Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Dim ExpenseSheetBLL As New AccountEmployeeExpenseSheetBLL
        Dim CustomControlBll As New AspNetCustomControlsBLL

        Dim dtExpenseSheet As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable = ExpenseSheetBLL.GetvueAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        If dtExpenseSheet.Rows.Count > 0 Then
            AddExpenseSheetCustomFields(dtExpenseSheet.Rows(0))
        End If

        LocaleUtilitiesBLL.SetPageCultureSetting(Me.Page)
        Me.Literal3.Text = ResourceHelper.GetFromResource("Employee Name:")
        Me.Literal2.Text = ResourceHelper.GetFromResource("Description:")
        Me.Literal1.Text = ResourceHelper.GetFromResource("Date:")
        Me.RCurrencyLiteral.Text = ResourceHelper.GetFromResource("Reimbursement Currency:")
        Me.RTotalLiteral.Text = ResourceHelper.GetFromResource("Total Reimbursement :")
        Me.txtExpenseSheetFooter.Text = DBUtilities.GetExpenseSheetPrintFooter()
        SetMasterValue()
        SetGridViewDataSource()
        Me.SetImageUrl()
        Me.SetESignUrl()
        If Me.Request.QueryString("IsPrint") = "True" Then
            If Not IsPostBack Then
                Me.Page.ClientScript.RegisterStartupScript(Me.GetType, "Print", "javascript:window.print();", True)
            End If
        End If
        Me.lblSignedBy.Text = GetEmployeeName()
        Me.lblTimestamp.Text = Now
        'If Not Me.IsPostBack Then
        '    CalculateAmountAndReimburse()
        'End If
    End Sub

    Private Sub AddExpenseSheetCustomFields(drExpenseSheet As AccountExpenseEntry.vueAccountEmployeeExpenseSheetRow)
        Dim BLL As New AccountCustomFieldBLL
        For n As Integer = 1 To 15
            Dim dt As AccountCustomField.vueAccountCustomFieldManageDataTable = BLL.GetvueAccountCustomFieldByAccountIdMasterEntityTypeIdandDatabaseFieldName(DBUtilities.GetSessionAccountId, MasterEntityTypeIdExpenseSheet, "CustomField" & n)
            Dim dr As AccountCustomField.vueAccountCustomFieldManageRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                If dr.IsDisabled <> True Then
                    Dim tRow As New TableRow
                    CustomTable.Rows.Add(tRow)

                    Dim tCell As New TableCell
                    Dim tCell1 As New TableCell

                    tRow.Cells.Add(tCell)
                    tRow.Cells.Add(tCell1)
                    Dim tlabel As New Label
                    Dim tlabel1 As New Label

                    tlabel.Text = dr.CustomFieldCaption
                    tlabel.Font.Bold = True
                    tlabel.Style.Add(HtmlTextWriterStyle.FontSize, "11px")
                    If Not IsDBNull(drExpenseSheet.Item("CustomField" & n)) Then
                        tlabel1.Text = drExpenseSheet.Item("CustomField" & n)
                    End If
                    'CustomTable.CssClass = "xFormView"
                    tCell.CssClass = "HighlightedTextMedium"
                    tCell1.CssClass = "HighlightedTextMedium"
                    tCell1.HorizontalAlign = HorizontalAlign.Left
                    'CustomTable.Width = "500px"
                    tCell1.Attributes.Add("Width", "80%")
                    tCell.Attributes.Add("Width", "20%")
                    tCell1.Attributes.Add("Height", "22px")
                    tCell.Attributes.Add("Height", "22px")
                    tCell.Controls.Add(tlabel)
                    tCell1.Controls.Add(tlabel1)
                End If
            End If
        Next
    End Sub
    Public Sub AddCaption(ByVal ID As String, ByVal Caption As String, Optional ByVal AddCellToRow As Boolean = True, Optional ByVal SetRight As Boolean = True, Optional ByVal AddCellToRowForDate As Boolean = False, Optional ByVal SpecificWidth As String = "30%")
        Dim lbl As Label
        Me.AddCell()
        lbl = Me.AddLabel(ID, Caption)
        Me.CustomFieldCell.Controls.Add(lbl)
        'If AddCellToRow = True Then
        '    Me.AddFilterCellIntoFilterRowForCaption("FormViewLabelCell", SpecificWidth)
        'End If
        If SetRight Then
            CustomFieldCell.HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub
    Public Sub AddCell()
        CustomFieldCell = New TableCell
        ' FilterCell.BorderWidth = 1
    End Sub
    Public Function AddLabel(ID As String, Caption As String, Optional CssClass As String = "") As Label
        Dim lbl As New Label
        lbl.ID = "lbl" & ID
        lbl.Text = Caption & ": "
        If CssClass <> "" Then
            lbl.CssClass = CssClass
        End If
        Return lbl
    End Function
    Public Function GetEmployeeName() As String
        dtAccountEmployeeId = IIf(Me.Request.QueryString("AccountEmployeeId") Is Nothing, 0, Me.Request.QueryString("AccountEmployeeId"))
        Dim BLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable = BLL.GetAccountEmployeesByAccountEmployeeId(dtAccountEmployeeId)
        Dim drEmployee As AccountEmployee.AccountEmployeeRow
        If dtEmployee.Rows.Count > 0 Then
            drEmployee = dtEmployee.Rows(0)
            EmployeeName = drEmployee.FirstName & " " & drEmployee.LastName
            Return EmployeeName
        Else
            Return ""
        End If
    End Function
    Public Sub SetMasterValue()
        Dim BLL As New AccountEmployeeExpenseSheetBLL
        Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Dim dt As AccountExpenseEntry.vueAccountEmployeeExpenseSheetDataTable = BLL.GetvueAccountEmployeeExpenseSheetByAccountEmployeeExpenseSheetId(AccountEmployeeExpenseSheetId)
        Dim dr As AccountExpenseEntry.vueAccountEmployeeExpenseSheetRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.lblEmployeeName.Text = dr.EmployeeName
            Me.lblDescription.Text = dr.Description
            Me.lblDate.Text = dr.ExpenseSheetDate
        Else
            Me.lblEmployeeName.Text = ""
            Me.lblDescription.Text = ""
            Me.lblDate.Text = ""
        End If
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        SumTotalAmount = 0
        SumTaxAmount = 0
        SumNetAmount = 0
        TotalReimbursementAmount = 0

        If LocaleUtilitiesBLL.ShowTaskInExpenseSheet = True Then
            Me.GridView1.Columns(2).Visible = True
        Else
            Me.GridView1.Columns(2).Visible = False
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.Header And Not IsNothing(AccountBaseCurrency) Then
            CType(e.Row.FindControl("lbtnHeaderAmount"), LinkButton).Text = String.Format("Net Amount ({0})", AccountBaseCurrency.CurrencyCode)
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim dtExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryDataTable = New AccountExpenseEntryBLL().GetvueAccountExpenseEntriesByAccountExpenseEntryId(DataBinder.Eval(e.Row.DataItem, "AccountExpenseEntryId"))
            If DataBinder.Eval(e.Row.DataItem, "AccountExpenseEntryId") = 0 Then
                CType(e.Row.Cells(11).FindControl("AttachmentHyperLink"), HyperLink).Visible = False
                Exit Sub
            End If
            Dim drExpenseEntry As TimeLiveDataSet.vueAccountExpenseEntryRow = dtExpenseEntry.Rows(0)

            Dim convertedAmount = DataBinder.Eval(e.Row.DataItem, "Amount") / drExpenseEntry.ExchangeRate
            CType(e.Row.FindControl("lblConvertedCurrencyCode"), Label).Text = AccountBaseCurrency.CurrencyCode
            CType(e.Row.FindControl("lblConvertedAmount"), Label).Text = String.Format("{0:N}", convertedAmount)

            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Amount")) Then
                SumTotalAmount += convertedAmount
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "NetAmount")) Then
                SumNetAmount += DataBinder.Eval(e.Row.DataItem, "NetAmount")
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TaxAmount")) Then
                SumTaxAmount += DataBinder.Eval(e.Row.DataItem, "TaxAmount")
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Reimburse")) And DataBinder.Eval(e.Row.DataItem, "Reimburse") <> "False" Then
                Dim CurrencyBLL As New AccountCurrencyBLL
                Dim ExchangeRate As Double = CurrencyBLL.GetExchangeRateByAccountCurrencyId(DataBinder.Eval(e.Row.DataItem, "AccountCurrencyId"))
                TotalReimbursementAmount += DataBinder.Eval(e.Row.DataItem, "Amount") / ExchangeRate
            End If
            SetReimburseAmountAndCurrency(TotalReimbursementAmount)

            Dim accountExpenseEntryId = DataBinder.Eval(e.Row.DataItem, "AccountExpenseEntryId")
            SetupRowAttachmentLink(e.Row, accountExpenseEntryId)

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            SetFooterAmount(e)
        End If
    End Sub
    Public Sub SetFooterAmount(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Dim dtAccountCurrency As AccountCurrency.vueAccountCurrencyDataTable = New AccountCurrencyBLL().GetvueAccountCurrencyByAccountCurrencyId(AccountBaseCurrency.AccountBaseCurrencyId)
        Dim drAccountCurrency As AccountCurrency.vueAccountCurrencyRow
        If dtAccountCurrency.Rows.Count > 0 Then
            drAccountCurrency = dtAccountCurrency.Rows(0)

            Dim TotalFooterAmount As Double = drAccountCurrency.ExchangeRate * SumTotalAmount

            e.Row.Cells(10).Text = String.Format("{0:N}", TotalFooterAmount) & " " & AccountBaseCurrency.CurrencyCode
            e.Row.Cells(10).HorizontalAlign = HorizontalAlign.Right
            'e.Row.Cells(7).Text = String.Format("{0:N}", SumNetAmount)
            'e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(9).Text = String.Format("{0:N}", SumTaxAmount)
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub
    Public Sub SetGridViewDataSource()
        Me.GridView1.DataSourceID = ""
        If Me.Request.QueryString("IsPrint") = "True" Then
            Me.GridView1.DataSourceID = "dsAccountExpenseEntryForPrintObject"
        Else

            If Me.Request.QueryString("IsFromArchive") = "True" Then

                showAllchkbox.Visible = True

                If Session("EntryArchiveFilterInfo") IsNot Nothing Then
                    filterModel = Session("EntryArchiveFilterInfo")
                Else Return
                End If

                Dim AccountEmployeeExpenseSheetId As Guid
                If Not Me.Request.QueryString("AccountEmployeeExpenseSheetId") Is Nothing Then
                    AccountEmployeeExpenseSheetId = New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
                End If

                filterModel.ExpenseSheetId = New List(Of Guid)
                filterModel.ExpenseSheetId.Add(AccountEmployeeExpenseSheetId)

                If showAllchkbox.Checked = True Then
                    Me.GridView1.DataSourceID = "dsAccountExpenseEntryFromArchive"
                Else
                    Me.GridView1.DataSourceID = "dsAccountExpenseEntryFromArchiveFiltred"
                End If


            Else

                Me.GridView1.DataSourceID = "dsAccountExpenseEntryObject"
            End If


        End If

        If Not Me.Request.QueryString("IsFromArchive") = "True" Then
            Me.showAllchkbox.Visible = False
        End If

        Me.GridView1.DataBind()
    End Sub
    Public Sub SetImageUrl()
        If LocaleUtilitiesBLL.IsShowCompanyOwnLogo = True And LocaleUtilitiesBLL.IsLogoFileExistInSessionAccount = True Then
            imgCompanyLogo.ImageUrl = "~/Uploads/" & DBUtilities.GetSessionAccountId & "/Logo/CompanyLogo.gif"
        Else
            imgCompanyLogo.ImageUrl = "~/Images/TopHeader.png"
        End If
    End Sub
    Public Sub SetESignUrl()
        If LocaleUtilitiesBLL.IsShowElectronicSign = True And LocaleUtilitiesBLL.IsElectronicSignExistInSessionAccount = True Then
            imgElectronicSignature.ImageUrl = "~/Uploads/" & DBUtilities.GetSessionAccountId & "/" & DBUtilities.GetSessionAccountEmployeeId & "/Sign/E-Sign.gif"
        Else
            imgElectronicSignature.Visible = False
            'imgCompanyLogo.ImageUrl = "~/Images/TopHeader.jpg"
        End If
    End Sub
    Public Sub CalculateAmountAndReimburse()
        Dim ExchangeRateBLL As New AccountCurrencyExchangeRateBLL
        Dim ExchangeRate As Double

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

        'If drExpenseEntry.Reimburse = True Then
        '    ExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(drExpenseEntry.AccountCurrencyId, drExpenseEntry.ExpenseSheetDate)
        '    If ExchangeRate <> 0 Then
        '        TotalAmount += drExpenseEntry.Amount / ExchangeRate
        '    Else
        '        TotalAmount += drExpenseEntry.Amount / 1
        '    End If
        '    lblReimburseAmount.Text = String.Format("{0:N}", TotalAmount)
        'End If

        Dim dt As AccountExpenseEntry.vueAccountReimbursementCurrencyDataTable = New AccountExpenseEntryBLL().GetvueAccountReimbursementCurrencyByAccountId(DBUtilities.GetSessionAccountId)
        Dim dr As AccountExpenseEntry.vueAccountReimbursementCurrencyRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.lblReimbursCurrency.Text = dr.CurrencyCode
            ExchangeRate = ExchangeRateBLL.GetCurrentExchangeRateByCurrencyIdAndDate(dr.AccountReimbursementCurrencyId, drExpenseEntry.ExpenseSheetDate)
        End If
        Dim TotalReimbursementAmount As Double
        If ExchangeRate <> 0 Then
            TotalReimbursementAmount = ExchangeRate * TotalAmount
        Else
            TotalReimbursementAmount = 1 * TotalAmount
        End If
        lblReimburseAmount.Text = String.Format("{0:N}", TotalReimbursementAmount)

    End Sub
    Public Sub SetReimburseAmountAndCurrency(ByVal TotalAmount As Double)
        Dim BLL As New AccountExpenseEntryBLL
        Dim AccountEmployeeExpenseSheetId As New Guid(Me.Request.QueryString("AccountEmployeeExpenseSheetId"))
        Dim dt As AccountExpenseEntry.vueAccountReimbursementCurrencyDataTable = New AccountExpenseEntryBLL().GetvueAccountReimbursementCurrencyByAccountId(DBUtilities.GetSessionAccountId)
        Dim dr As AccountExpenseEntry.vueAccountReimbursementCurrencyRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.lblReimbursCurrency.Text = dr.CurrencyCode
            Me.lblReimburseAmount.Text = BLL.GetTotalReimbursementAmount(TotalAmount, dr.AccountReimbursementCurrencyId, lblDate.Text)
        End If
    End Sub
    Private Sub GetAccountBaseCurrency()
        Dim dtAccountBaseCurrency As AccountCurrencyExchangeRate.vueAccountBaseCurrencyDataTable = New AccountCurrencyExchangeRateBLL().GetvueAccountBaseCurrencyByAccountId(DBUtilities.GetSessionAccountId)
        If dtAccountBaseCurrency.Rows.Count > 0 Then
            AccountBaseCurrency = dtAccountBaseCurrency.Rows(0)
            Session("AccountBaseCurrency") = AccountBaseCurrency
        End If
    End Sub
    Private Sub SetupRowAttachmentLink(row As GridViewRow, accountExpenseEntryId As Integer)
        Dim accountAttachmentsBLL = New AccountAttachmentsBLL()

        Dim dt As TimeLiveDataSet.CountAccountExpenseEntryIdDataTable = accountAttachmentsBLL.GetCountAccountExpenseEntryId(accountExpenseEntryId)
        Dim dr As TimeLiveDataSet.CountAccountExpenseEntryIdRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Dim hyperlinkControl = CType(row.FindControl("AttachmentHyperlink"), HyperLink)
            If dr.TotalCount = 0 Then
                hyperlinkControl.Visible = False
                Exit Sub
            End If
            hyperlinkControl.Text = dr.TotalCount

            Dim attachments = accountAttachmentsBLL.GetAccountAttachmentsByAccountExpenseEntryId(accountExpenseEntryId, Guid.Empty)
            If attachments.Count > 0 Then
                Dim att = attachments(0)
                If Not att.AccountExpenseEntryId = 0 Then
                    If UIUtilities.IsFileAnImage(att.AttachmentLocalPath) Then
                        CType(row.FindControl("imgTooltip"), System.Web.UI.WebControls.Image).ImageUrl = "~/Shared/FileDownload.aspx?" & LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/" & accountExpenseEntryId & "/" & att.AttachmentLocalPath)
                        hyperlinkControl.CssClass = "tooltip"
                        hyperlinkControl.Attributes("data-tooltip-content") = "#" + CType(row.FindControl("tooltipContent"), Label).ClientID
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
        If e.SortExpression <> CType(sender, GridView).SortExpression Then
            e.SortDirection = SortDirection.Descending
        End If
    End Sub

    Protected Sub dsAccountExpenseEntryFromArchive_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs)
        e.InputParameters.Add("filter", filterModel)
    End Sub
    Protected Sub dsAccountExpenseEntryFromArchiveFiltred_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs)
        e.InputParameters.Add("filter", filterModel)
    End Sub
End Class
