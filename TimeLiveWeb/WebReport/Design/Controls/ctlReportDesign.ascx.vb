
Partial Class WebReport_Design_Controls_ctlReportDesign
    Inherits System.Web.UI.UserControl
    Dim ReportDesignBLL As New TimeLive.WebReport.ReportDesignBLL
    Dim Data As Boolean

    Protected Sub ReportWizard_FinishButtonClick(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles ReportWizard.FinishButtonClick
        AddColumnOrderForAccountReportColumn()
        AddColumnOrderForAccountReportGroup()
        Response.Redirect("~/WebReport/MyReports.aspx", False)
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    End Sub
    Public Sub SetGridViewRowsWithData()
        Dim row As GridViewRow
        For Each row In GridView1.Rows

            If Me.Request.QueryString("AccountReportId") Is Nothing And Me.ViewState("AccountReportId") Is Nothing Then
                If Me.ddlSystemReportDataSourceId.SelectedValue <> GetSystemReportDataSourceIdForReportCustomaize(GetAccountReportId) Then
                    If Me.GridView1.DataKeys(row.RowIndex).Item("DefaultAvailable") = True Then
                        CType(row.FindControl("chkSelect"), CheckBox).Checked = True
                    End If
                End If
                'CType(row.FindControl("lblReportColumn"), Label).Text = ResourceHelper.GetFromResource(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceField"))
                CType(row.FindControl("CaptionTextBox"), TextBox).Text = ResourceHelper.GetFromResource(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceFieldCaption"))

            Else
                If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("AccountReportColumnId")) Then
                    CType(row.FindControl("chkSelect"), CheckBox).Checked = True
                End If

                If ReportDesignBLL.IsAccountReportGroupExist(GetAccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceFieldId")) = True Then
                    CType(row.FindControl("chkGroup"), CheckBox).Checked = True
                End If

                If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId")) Then
                    CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue = Convert.ToString(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId"))
                End If

                If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("AccountReportColumnId")) Then
                    'CType(row.FindControl("lblReportColumn"), Label).Text = ResourceHelper.GetFromResource(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceField"))
                    CType(row.FindControl("CaptionTextBox"), TextBox).Text = ResourceHelper.GetFromResource(Me.GridView1.DataKeys(row.RowIndex).Item("Caption"))
                    If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("ColumnFormula")) Then
                        CType(row.FindControl("FormulaTextBox"), TextBox).Text = Me.GridView1.DataKeys(row.RowIndex).Item("ColumnFormula")
                    End If
                ElseIf ReportDesignBLL.IsAccountReportGroupExist(GetAccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceFieldId")) = True Then
                    'CType(row.FindControl("lblReportColumn"), Label).Text = ResourceHelper.GetFromResource(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceField"))
                    CType(row.FindControl("CaptionTextBox"), TextBox).Text = ResourceHelper.GetFromResource(ReportDesignBLL.GetReportGroupCaption(GetAccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceFieldId")))
                Else
                    'CType(row.FindControl("lblReportColumn"), Label).Text = ResourceHelper.GetFromResource(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceField"))
                    CType(row.FindControl("CaptionTextBox"), TextBox).Text = ResourceHelper.GetFromResource(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceFieldCaption"))
                End If

            End If
            HideTextBoxInGrid(row)
        Next
    End Sub
    Private Sub ReportWizard_NextButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles ReportWizard.NextButtonClick
        Me.FileUpload(CType(Me.FormView1.FindControl("ReportIconPathTextBox"), FileUpload))
        If CType(Me.FormView1.FindControl("ReportIconPathTextBox"), FileUpload).FileName <> "" Then
            Me.ViewState.Add("ReportIconPath", CType(Me.FormView1.FindControl("ReportIconPathTextBox"), FileUpload).FileName)
        End If
        Me.ReportNameTextBox.Text = CType(Me.FormView1.FindControl("ReportNameTextBox"), TextBox).Text
        Me.reportNameTextBox1.Text = CType(Me.FormView1.FindControl("ReportNameTextBox"), TextBox).Text
    End Sub
    Public Function GetReportIconPath() As String
        If Me.ViewState("ReportIconPath") Is Nothing Then
            Return Nothing
        Else
            Return Me.ViewState("ReportIconPath")
        End If
    End Function
    Public Function GetReportName(ByVal IsSystemReport As Boolean) As String
        Dim reportname As String
        If IsSystemReport = True Then
            reportname = CType(Me.FormView1.FindControl("ReportNameTextBox"), TextBox).Text
            reportname = reportname & " " & ResourceHelper.GetFromResource("Customized")
        Else
            reportname = CType(Me.FormView1.FindControl("ReportNameTextBox"), TextBox).Text
        End If
        Return reportname
    End Function
    Public Function GetIsConsolidated(ByVal IsSystemReport As Boolean) As Boolean
        If IsSystemReport = False Then
            If CType(Me.FormView1.FindControl("rdDetailed"), RadioButton).Checked = True Then
                Return False
            ElseIf CType(Me.FormView1.FindControl("rdConsolidated"), RadioButton).Checked = True Then
                Return True
            End If
        Else
            If Not IsDBNull(Me.FormView1.DataKey("IsConsolidated")) Then
                Return Me.FormView1.DataKey("IsConsolidated")
            End If
        End If
        Return False
    End Function
    Public Function GetSystemReportId(ByVal IsSystemReport As Boolean) As Guid
        If IsSystemReport = True Then
            Dim SystemReportId As New Guid(Me.Request.QueryString("AccountReportId"))
            Return SystemReportId
        Else
            Return System.Guid.Empty
        End If
    End Function
    Public Sub AddNewReport(Optional ByVal IsSystemReport As Boolean = False)
        Dim row As GridViewRow
        Dim count As Integer = 0
        Dim AccountReportIdLast As Guid

        Dim AccountReportCategoryId As New Guid(CType(Me.FormView1.FindControl("ddlReportCategory"), DropDownList).SelectedValue)
        Dim ReportOrder As Integer = ReportDesignBLL.GetMaxReportOrderFromAccountReport(AccountReportCategoryId, DBUtilities.GetSessionAccountId) + 1
        AddCustomizeReportIcon(IsSystemReport)
        AccountReportIdLast = ReportDesignBLL.AddAccountReport(GetReportName(IsSystemReport), CType(Me.FormView1.FindControl("ReportDescriptionTextBox"), TextBox).Text, AccountReportCategoryId, GetReportIconPath, DBUtilities.GetSessionAccountId, GetIsConsolidated(IsSystemReport), IsSystemReport, GetSystemReportId(IsSystemReport), ReportOrder, CType(Me.FormView1.FindControl("chkShowCompanyLogo"), CheckBox).Checked, CType(Me.FormView1.FindControl("ReportTitleTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("ReportHeaderTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("ReportFooterTextBox"), TextBox).Text)
        AddReportPermissionForNewReport(AccountReportIdLast)

        Dim SystemReportDataSourceId As New Guid(Me.ddlSystemReportDataSourceId.SelectedValue)
        ReportDesignBLL.AddAccountReportDataSourceMapping(AccountReportIdLast, SystemReportDataSourceId)

        For Each row In GridView1.Rows
            If CType(row.FindControl("chkSelect"), CheckBox).Checked = True And Not IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                ReportDesignBLL.AddAccountReportColumn(AccountReportIdLast, CType(row.FindControl("CaptionTextBox"), TextBox).Text, Me.GridView1.DataKeys(row.RowIndex).Item(1), Me.GridView1.DataKeys(row.RowIndex).Item(2), GetCalculationTypeIdFromDropdown(row), CType(row.FindControl("FormulaTextBox"), TextBox).Text)
            End If
            If CType(row.FindControl("chkGroup"), CheckBox).Checked = True And Not IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(3)) Then
                Dim AccountReportGroupId As Guid = ReportDesignBLL.AddAccountReportGroup(AccountReportIdLast, Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceField"), CType(row.FindControl("CaptionTextBox"), TextBox).Text, count, Me.GridView1.DataKeys(row.RowIndex).Item(1))
                count += 1
            End If
        Next

        Me.AddReportSummary(AccountReportIdLast)
        Me.ViewState.Add("AccountReportId", AccountReportIdLast)

    End Sub
    Public Sub UpdateReport()
        Dim row As GridViewRow

        Dim count As Integer = GetFieldOrder()
        Dim AccountReportIdLast As Guid = GetAccountReportId()
        Dim ColumnOrder As Integer = ReportDesignBLL.GetColumnOrderByAccountReportId(AccountReportIdLast) + 1
        Dim AccountReportCategoryId As New Guid(CType(Me.FormView1.FindControl("ddlReportCategory"), DropDownList).SelectedValue)
        If IsDBNull(Me.FormView1.DataKey("AccountId")) Then
            CType(Me.FormView1.FindControl("ReportNameTextBox"), TextBox).Text = GetReportName(True)
        End If
        ReportDesignBLL.UpdateAccountReport(AccountReportIdLast, CType(Me.FormView1.FindControl("ReportNameTextBox"), TextBox).Text, AccountReportCategoryId, CType(Me.FormView1.FindControl("ReportDescriptionTextBox"), TextBox).Text, GetReportIconPath, CType(Me.FormView1.FindControl("chkShowCompanyLogo"), CheckBox).Checked, CType(Me.FormView1.FindControl("ReportTitleTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("ReportHeaderTextBox"), TextBox).Text, CType(Me.FormView1.FindControl("ReportFooterTextBox"), TextBox).Text)
        'Me.FileUpload(CType(Me.FormView1.FindControl("ReportIconPathTextBox"), FileUpload), AccountReportIdLast)
        If IsNewAccountReportGroupAdd(AccountReportIdLast) Then
            ReportDesignBLL.DeleteAccountReportSummaryByReportIdAndReportGroupIdIsNull(AccountReportIdLast)
        End If
        For Each row In GridView1.Rows

            If CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                ReportDesignBLL.AddAccountReportColumn(AccountReportIdLast, CType(row.FindControl("CaptionTextBox"), TextBox).Text, Me.GridView1.DataKeys(row.RowIndex).Item(1), ColumnOrder, GetCalculationTypeIdFromDropdown(row), CType(row.FindControl("FormulaTextBox"), TextBox).Text)
                ColumnOrder += 1

            ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(0)) And IsRowChanged(row) Then
                ReportDesignBLL.UpdateAccountReportColumn(Me.GridView1.DataKeys(row.RowIndex).Item(0), CType(row.FindControl("CaptionTextBox"), TextBox).Text, GetCalculationTypeIdFromDropdown(row), CType(row.FindControl("FormulaTextBox"), TextBox).Text)

            ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = False And Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                ReportDesignBLL.DeleteAccountReportColumn(Me.GridView1.DataKeys(row.RowIndex).Item(0))
            End If

            If CType(row.FindControl("chkGroup"), CheckBox).Checked = True And ReportDesignBLL.IsAccountReportGroupExist(AccountReportIdLast, Me.GridView1.DataKeys(row.RowIndex).Item(1)) = False Then
                Dim AccountReportGroupId As Guid = ReportDesignBLL.AddAccountReportGroup(AccountReportIdLast, Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceField"), CType(row.FindControl("CaptionTextBox"), TextBox).Text, count, Me.GridView1.DataKeys(row.RowIndex).Item(1))
                count += 1

            ElseIf CType(row.FindControl("chkGroup"), CheckBox).Checked = False And ReportDesignBLL.IsAccountReportGroupExist(AccountReportIdLast, Me.GridView1.DataKeys(row.RowIndex).Item(1)) = True Then
                Dim AccountReportGroupId As Guid = ReportDesignBLL.GetAccountReportGroupId(AccountReportIdLast, Me.GridView1.DataKeys(row.RowIndex).Item(1))
                DeleteAccountReportSummaryBeforeReportGroupIsDeleted(AccountReportIdLast, AccountReportGroupId)
                ReportDesignBLL.DeleteAccountReportGroup(AccountReportGroupId)
            End If
        Next

        Me.AddReportSummary(AccountReportIdLast)
        ' ReportDesignBLL.UpdateReportGroupFieldOrderInAccountReportGroup(AccountReportIdLast)
    End Sub
    Public Sub AddReportSummary(ByVal AccountReportIdLast As Guid)
        Dim row As GridViewRow
        Dim ReportColumnId As Guid
        For Each row In GridView1.Rows
            ReportColumnId = ReportDesignBLL.GetReportColumnByColumnId(AccountReportIdLast, Me.GridView1.DataKeys(row.RowIndex).Item(1))

            If CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedItem.Text <> "<None>" And IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId")) Then
                Dim SystemReportCalculationTypeId As New Guid(CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue)

                If ReportColumnId <> System.Guid.Empty Then
                    AddAccountReportSummaryForNewReport(row, AccountReportIdLast, SystemReportCalculationTypeId, ReportColumnId)
                End If
            End If
            If CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedItem.Text <> "<None>" And Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId")) Then
                Dim SystemReportCalculationTypeId As New Guid(CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue)

                Me.AddAccountSummaryByGroupIfGroupNotExist(row, AccountReportIdLast, ReportColumnId, SystemReportCalculationTypeId)
            End If
            If CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedItem.Text = "<None>" And Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId")) Then
                DeleteColumnFromAccountReportSummary(AccountReportIdLast, ReportColumnId)
                ReportDesignBLL.UpdateNullSystemReportCalculationTypeIdInAccountReportColumn(ReportColumnId)
            End If

            If IsSystemReportCalculationTypeChanged(row) Then
                Dim SystemReportCalculationTypeId As New Guid(CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue)
                ReportDesignBLL.UpdateSystemReportCalculationTypeIdInAccountReportSummary(AccountReportIdLast, ReportColumnId, SystemReportCalculationTypeId)
            End If

        Next
        AddAccountReportSummaryWhenGrouupNotAdd(AccountReportIdLast)
        DeleteFromAccountReportSummaryWhenSummartNotAdd(AccountReportIdLast)
    End Sub

    Public Function IsSystemReportCalculationTypeChanged(ByVal row As GridViewRow) As Boolean
        If CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedItem.Text <> "<None>" Then
            If Convert.ToString(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId")) <> CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue Then
                Return True
            End If
        End If
    End Function

    Public Sub AddAccountReportSummaryWhenGrouupNotAdd(ByVal AccountReportId As Guid)
        Dim row As GridViewRow
        Dim ReportColumnId As Guid
        Dim dtAccountReportGroup As dsReportDesign.AccountReportGroupDataTable = ReportDesignBLL.GetAccountReportGroupByAccountReportId(AccountReportId)
        If dtAccountReportGroup.Rows.Count = 0 Then
            For Each row In GridView1.Rows
                ReportColumnId = ReportDesignBLL.GetReportColumnByColumnId(AccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item(1))
                If CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedItem.Text <> "<None>" Then
                    Dim SystemReportCalculationTypeId As New Guid(CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue)
                    If ReportDesignBLL.IsReportSummaryExistFor(AccountReportId, ReportColumnId) = False Then
                        ReportDesignBLL.AddAccountReportSummary(System.Guid.Empty, AccountReportId, SystemReportCalculationTypeId, ReportColumnId, CType(row.FindControl("lblReportColumn"), Label).Text, False, True)
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub DeleteFromAccountReportSummaryWhenSummartNotAdd(ByVal AccountReportId As Guid)
        Dim row As GridViewRow
        Dim ReportColumnId As Guid
        For Each row In GridView1.Rows
            If CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedItem.Text = "<None>" Then
                ReportColumnId = ReportDesignBLL.GetReportColumnByColumnId(AccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item(1))
                ReportDesignBLL.DeleteAccountReportSummaryByReportIdReportColumnIdAndReportGroupIdIsNull(AccountReportId, ReportColumnId)
            End If
        Next
    End Sub
    Public Function IsNewAccountReportGroupAdd(ByVal AccountReportId As Guid) As Boolean
        Dim row As GridViewRow
        For Each row In GridView1.Rows
            If ReportDesignBLL.IsAccountReportGroupExist(AccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item(1)) = False And CType(row.FindControl("chkGroup"), CheckBox).Checked = True Then
                Return True
            End If
        Next
    End Function
    Public Function IsRowChanged(ByVal row As GridViewRow) As Boolean
        If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("AccountReportColumnId")) Then
            If Me.GridView1.DataKeys(row.RowIndex).Item("Caption") <> CType(row.FindControl("CaptionTextBox"), TextBox).Text Then
                Return True
            End If
        End If

        If IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId")) Then
            Dim SystemReportCalculationTypeId As String = 0
            If SystemReportCalculationTypeId <> Convert.ToString(CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue) Then
                Return True
            End If
        Else
            If Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId").ToString <> CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue.ToString Then
                Return True
            End If
        End If
        If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("ColumnFormula")) Then
            If CType(row.FindControl("FormulaTextBox"), TextBox).Text <> Me.GridView1.DataKeys(row.RowIndex).Item("ColumnFormula") Then
                Return True
            End If
        Else
            If CType(row.FindControl("FormulaTextBox"), TextBox).Text <> "" Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function GetCalculationTypeIdFromDropdown(ByVal row As GridViewRow) As Guid
        If CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedItem.Text <> "<None>" Then
            Dim SystemReportCalculationTypeId As New Guid(CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue)
            Return SystemReportCalculationTypeId
        End If
    End Function
    Public Sub AddAccountSummaryByGroupIfGroupNotExist(ByVal row As GridViewRow, ByVal AccountReportIdLast As Guid, ByVal AccountReportColumnId As Guid, ByVal SystemReportCalculationTypeId As Guid)
        Dim dtAccountReportGroup As dsReportDesign.AccountReportGroupDataTable = ReportDesignBLL.GetAccountReportGroupByAccountReportId(AccountReportIdLast)
        Dim drAccountReportGroup As dsReportDesign.AccountReportGroupRow
        If dtAccountReportGroup.Rows.Count > 0 Then
            drAccountReportGroup = dtAccountReportGroup.Rows(0)
            For Each drAccountReportGroup In dtAccountReportGroup.Rows
                If ReportDesignBLL.IsAccountReportSummaryExist(AccountReportIdLast, AccountReportColumnId, drAccountReportGroup.AccountReportGroupId) = False Then
                    ReportDesignBLL.AddAccountReportSummary(drAccountReportGroup.AccountReportGroupId, AccountReportIdLast, SystemReportCalculationTypeId, AccountReportColumnId, CType(row.FindControl("lblReportColumn"), Label).Text, True, True)
                End If
            Next
        End If
    End Sub
    Public Sub AddAccountReportSummaryForNewReport(ByVal row As GridViewRow, ByVal AccountReportIdLast As Guid, ByVal SystemReportCalculationTypeId As Guid, ByVal ReportColumnId As Guid)
        Dim dtAccountReportGroup As dsReportDesign.AccountReportGroupDataTable = ReportDesignBLL.GetAccountReportGroupByAccountReportId(AccountReportIdLast)
        Dim drAccountReportGroup As dsReportDesign.AccountReportGroupRow
        If dtAccountReportGroup.Rows.Count > 0 Then
            drAccountReportGroup = dtAccountReportGroup.Rows(0)
            For Each drAccountReportGroup In dtAccountReportGroup.Rows
                ReportDesignBLL.AddAccountReportSummary(drAccountReportGroup.AccountReportGroupId, AccountReportIdLast, SystemReportCalculationTypeId, ReportColumnId, CType(row.FindControl("lblReportColumn"), Label).Text, True, True)
            Next
        Else
            ReportDesignBLL.AddAccountReportSummary(System.Guid.Empty, AccountReportIdLast, SystemReportCalculationTypeId, ReportColumnId, CType(row.FindControl("lblReportColumn"), Label).Text, False, True)
        End If
    End Sub
    Public Sub DeleteColumnFromAccountReportSummary(ByVal AccountReportIdLast As Guid, ByVal AccountReportColumnId As Guid)
        Dim dtAccountReportGroup As dsReportDesign.AccountReportGroupDataTable = ReportDesignBLL.GetAccountReportGroupByAccountReportId(AccountReportIdLast)
        Dim drAccountReportGroup As dsReportDesign.AccountReportGroupRow
        If dtAccountReportGroup.Rows.Count > 0 Then
            drAccountReportGroup = dtAccountReportGroup.Rows(0)
            For Each drAccountReportGroup In dtAccountReportGroup.Rows
                If ReportDesignBLL.IsAccountReportSummaryExist(AccountReportIdLast, AccountReportColumnId, drAccountReportGroup.AccountReportGroupId) Then
                    ReportDesignBLL.DeleteAccountReportSummary(AccountReportIdLast, AccountReportColumnId, drAccountReportGroup.AccountReportGroupId)
                End If
            Next
        End If
    End Sub
    Public Sub DeleteAccountReportSummaryBeforeReportGroupIsDeleted(ByVal AccountReportIdLast As Guid, ByVal AccountReportGroupId As Guid)
        Dim dtAccountReportColumn As dsReportDesign.AccountReportColumnDataTable = ReportDesignBLL.GetAccountReportColumnByAccountReportIdAndCalculationTypeIdIsNotNull(AccountReportIdLast)
        Dim drAccountReportColumn As dsReportDesign.AccountReportColumnRow

        If dtAccountReportColumn.Rows.Count > 0 Then
            drAccountReportColumn = dtAccountReportColumn.Rows(0)
            For Each drAccountReportColumn In dtAccountReportColumn.Rows
                If ReportDesignBLL.IsAccountReportSummaryExist(AccountReportIdLast, drAccountReportColumn.AccountReportColumnId, AccountReportGroupId) Then
                    ReportDesignBLL.DeleteAccountReportSummary(AccountReportIdLast, drAccountReportColumn.AccountReportColumnId, AccountReportGroupId)
                End If
            Next
        End If
    End Sub
    Public Sub CopyReport(ByVal AccountReportId As Guid)

        If Me.IsSystemReportChanged(AccountReportId) Or Me.IsSystemColumOrGroupChanged(AccountReportId) Then
            Me.AddNewReport(True)
        End If

    End Sub
    Public Function IsSystemReportChanged(ByVal AccountReportId As Guid) As Boolean

        Dim dtAccountReport As dsReportDesign.AccountReportDataTable = ReportDesignBLL.GetAccountReportByAccountReportId(AccountReportId)
        Dim drAccountReport As dsReportDesign.AccountReportRow = dtAccountReport.Rows(0)

        If dtAccountReport.Rows.Count > 0 Then

            If drAccountReport.ReportName <> CType(Me.FormView1.FindControl("ReportNameTextBox"), TextBox).Text Then
                Return True
            End If

            If drAccountReport.ReportDescription <> CType(Me.FormView1.FindControl("ReportDescriptionTextBox"), TextBox).Text Then
                Return True
            End If

            Dim AccountReportCategoryId As New Guid(CType(Me.FormView1.FindControl("ddlReportCategory"), DropDownList).SelectedValue)
            If drAccountReport.AccountReportCategoryId <> AccountReportCategoryId Then
                Return True
            End If

            If Not Me.ViewState("ReportIconPath") Is Nothing Then
                Return True
            End If

            If drAccountReport.ShowCompanyLogo <> CType(Me.FormView1.FindControl("chkShowCompanyLogo"), CheckBox).Checked Then
                Return True
            End If

            If Not IsDBNull(drAccountReport.Item("ReportTitle")) Then
                If drAccountReport.ReportTitle <> CType(Me.FormView1.FindControl("ReportTitleTextBox"), TextBox).Text Then
                    Return True
                End If
            End If

            If Not IsDBNull(drAccountReport.Item("ReportHeader")) Then
                If drAccountReport.ReportHeader <> CType(Me.FormView1.FindControl("ReportHeaderTextBox"), TextBox).Text Then
                    Return True
                End If
            End If

            If Not IsDBNull(drAccountReport.Item("ReportFooter")) Then
                If drAccountReport.ReportFooter <> CType(Me.FormView1.FindControl("ReportFooterTextBox"), TextBox).Text Then
                    Return True
                End If
            End If

        End If

        Return False

    End Function
    Public Function IsSystemColumOrGroupChanged(ByVal AccountReportId As Guid) As Boolean
        Dim row As GridViewRow

        For Each row In GridView1.Rows
            If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("AccountReportColumnId")) Then

                If CType(row.FindControl("chkSelect"), CheckBox).Checked = False Then
                    Return True
                End If

                If Me.GridView1.DataKeys(row.RowIndex).Item("Caption") <> CType(row.FindControl("CaptionTextBox"), TextBox).Text Then
                    Return True
                End If
            Else
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = True Then
                    Return True
                End If

                'If Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportDataSourceFieldCaption") <> CType(row.FindControl("CaptionTextBox"), TextBox).Text Then
                '    Return True
                'End If

            End If

            If ReportDesignBLL.IsAccountReportGroupExist(AccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item(1)) = True And CType(row.FindControl("chkGroup"), CheckBox).Checked = False Then
                Return True
            ElseIf ReportDesignBLL.IsAccountReportGroupExist(AccountReportId, Me.GridView1.DataKeys(row.RowIndex).Item(1)) = False And CType(row.FindControl("chkGroup"), CheckBox).Checked = True Then
                Return True
            End If

            If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId")) Then
                If Convert.ToString(Me.GridView1.DataKeys(row.RowIndex).Item("SystemReportCalculationTypeId")) <> CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedValue Then
                    Return True
                End If
            Else
                If CType(row.FindControl("ddlGroupSummary"), DropDownList).SelectedItem.Text <> "<None>" Then
                    Return True
                End If
            End If
        Next

        Return False

    End Function
    Public Function GetFieldOrder() As Integer
        Return ReportDesignBLL.GetCountFieldOrderByAccountReportId(GetAccountReportId)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If AccountPagePermissionBLL.IsPageHasPermissionOf(127, 1) = False Then
            ReportWizard.Visible = False
        End If
        If Not Me.IsPostBack Then
            Me.ReportWizard.ActiveStepIndex = 0
            CType(Me.FormView1.FindControl("rdDetailed"), RadioButton).Checked = True
        End If
        If Not Me.Request.QueryString("AccountReportId") Is Nothing Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            Me.ddlSystemReportDataSourceId.Enabled = False
        End If
        ShowSelectedValueForddlSystemReportDatasource()
        SetDataInDropdownByDataType()
       
        'Dim ScriptManager As System.Web.UI.ScriptManager = Me.FindControlRecursive(Me.Page.Master.Master, "ScriptManager2")
        'ScriptManager.RegisterPostBackControl(Me.FormView1.FindControl("ReportIconPathTextBox"))
    End Sub

    Protected Sub ddlSystemReportDataSourceId_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSystemReportDataSourceId.PreRender
        ShowGridBySystemReportDataSource()
        SetDataInDropdownByDataType()
        Me.SetGridViewRowsWithData()

    End Sub

    Protected Sub ddlSystemReportDataSourceId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSystemReportDataSourceId.SelectedIndexChanged
        ReportDesignBLL.DeleteAccountReport(GetAccountReportId)
        If Not Me.ViewState("AccountReportId") Is Nothing Then
            Me.ViewState("AccountReportId") = Nothing
        End If
        ShowGridBySystemReportDataSource()
        SetDataInDropdownByDataType()
        Me.SetGridViewRowsWithData()
    End Sub
    Public Sub ShowGridBySystemReportDataSource()
        'Dim SystemReportDataSourceId As New Guid(Me.ddlSystemReportDataSourceId.SelectedValue)
        Me.dsAccountReportColumnObject.SelectParameters("AccountReportId").DefaultValue = Convert.ToString(GetAccountReportId)
        Me.dsAccountReportColumnObject.SelectParameters("SystemReportDataSourceId").DefaultValue = Me.ddlSystemReportDataSourceId.SelectedValue
        Me.GridView1.DataBind()
    End Sub
    Public Sub ShowSelectedValueForddlSystemReportDatasource()
        If Not Me.Request.QueryString("AccountReportId") Is Nothing Then
            Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
            Me.ddlSystemReportDataSourceId.SelectedValue = GetSystemReportDataSourceIdForReportCustomaize(AccountReportId)
            If Me.GridView1.Rows.Count = 0 Then
                ShowGridBySystemReportDataSourceForEdit(GetSystemReportDataSourceIdForReportCustomaizeInGuid(AccountReportId))
            End If
        End If
    End Sub
    Public Function GetSystemReportDataSourceIdForReportCustomaize(ByVal AccountReportId As Guid) As String
        Dim dt As dsReportDesign.AccountReportDataSourceMappingDataTable = ReportDesignBLL.GetAccountReportDataSourceMappingByAccountReportId(AccountReportId)
        Dim dr As dsReportDesign.AccountReportDataSourceMappingRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return Convert.ToString(dr.SystemReportDataSourceId)
        End If
    End Function
    Public Sub ShowGridBySystemReportDataSourceForEdit(ByVal SystemReportDataSourceId As Guid)
        Me.dsAccountReportColumnObject.SelectParameters("AccountReportId").DefaultValue = Convert.ToString(GetAccountReportId)
        Me.dsAccountReportColumnObject.SelectParameters("SystemReportDataSourceId").DefaultValue = Convert.ToString(SystemReportDataSourceId)
        Me.GridView1.DataBind()
    End Sub
    Public Function GetSystemReportDataSourceIdForReportCustomaizeInGuid(ByVal AccountReportId As Guid) As Guid
        Dim dt As dsReportDesign.AccountReportDataSourceMappingDataTable = ReportDesignBLL.GetAccountReportDataSourceMappingByAccountReportId(AccountReportId)
        Dim dr As dsReportDesign.AccountReportDataSourceMappingRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.SystemReportDataSourceId
        End If
    End Function

    Protected Sub ReportWizard_ActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportWizard.ActiveStepChanged
        If Me.IsPostBack Then
            If ReportWizard.ActiveStep.StepType = WizardStepType.Finish Then
                If IsDBNull(Me.FormView1.DataKey("AccountId")) And Not Me.Request.QueryString("AccountReportId") Is Nothing And Me.ViewState("AccountReportId") Is Nothing Then
                    Me.CopyReport(GetAccountReportId)
                Else
                    If Me.ddlSystemReportDataSourceId.SelectedValue <> GetSystemReportDataSourceIdForReportCustomaize(GetAccountReportId) Then
                        'DeleteReport(GetAccountReportId)
                    End If
                    If Me.ViewState("AccountReportId") Is Nothing And Me.Request.QueryString("AccountReportId") Is Nothing Then
                        Me.AddNewReport()
                    ElseIf Not Me.Request.QueryString("AccountReportId") Is Nothing OrElse Not Me.ViewState("AccountReportId") Is Nothing Then
                        Me.UpdateReport()
                    End If
                End If
                Me.SetGridViewRowsWithData()
                SetDataInReportColumnListBox()
                SetDataInReportGroupListBox()
            Else
                Me.SetGridViewRowsWithData()
            End If
        End If
    End Sub

    Protected Sub ReportWizard_PreviousButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles ReportWizard.PreviousButtonClick
        If ReportWizard.ActiveStep.StepType = WizardStepType.Finish Then
            ShowGridBySystemReportDataSourceForEdit(GetSystemReportDataSourceIdForReportCustomaizeInGuid(GetAccountReportId))
        End If
    End Sub
    Public Sub SetDataInReportColumnListBox()
        Dim objDataView As New DataView()
        objDataView = ReportDesignBLL.GetAccountReportColumnByAccountReportId(GetAccountReportId).DefaultView
        objDataView.Sort = "ColumnOrder"
        Me.SelectedListBox.DataTextField = "Caption"
        Me.SelectedListBox.DataValueField = "AccountReportColumnId"
        Me.SelectedListBox.DataSource = objDataView
        Me.SelectedListBox.DataBind()
    End Sub
    Public Sub SetDataInReportGroupListBox()
        Dim objDataView As New DataView()
        objDataView = ReportDesignBLL.GetAccountReportGroupByAccountReportId(GetAccountReportId).DefaultView
        objDataView.Sort = "ReportGroupFieldOrder desc"
        Me.ReportGroupListBox.DataTextField = "ReportGroupFieldLabel"
        Me.ReportGroupListBox.DataValueField = "AccountReportGroupId"
        Me.ReportGroupListBox.DataSource = objDataView
        Me.ReportGroupListBox.DataBind()
    End Sub
    Public Function GetAccountReportId() As Guid
        Dim AccountReportId As Guid
        If Not Me.ViewState("AccountReportId") Is Nothing Then
            AccountReportId = Me.ViewState("AccountReportId")
        ElseIf Not Me.Request.QueryString("AccountReportId") Is Nothing Then
            AccountReportId = New Guid(Me.Request.QueryString("AccountReportId"))
        End If
        Return AccountReportId
    End Function
    Public Sub AddColumnOrderForAccountReportColumn()
        For n As Integer = 0 To SelectedListBox.Items.Count - 1
            Dim AccountReportColumnId As New Guid(SelectedListBox.Items(n).Value)
            ReportDesignBLL.UpdateColumnOrderInAccountReportColumn(AccountReportColumnId, n + 1)
        Next
    End Sub
    Public Sub AddColumnOrderForAccountReportGroup()
        Dim total As Integer = Me.ReportGroupListBox.Items.Count - 1
        For n As Integer = 0 To ReportGroupListBox.Items.Count - 1
            Dim AccountReportGroupId As New Guid(ReportGroupListBox.Items(n).Value)
            ReportDesignBLL.UpdateColumnOrderInAccountReportGroup(AccountReportGroupId, total)
            total = total - 1
        Next
    End Sub
    Public Sub SetDataInDropdownByDataType()

        Dim dtSystemReportCalculation As dsReportDesign.SystemReportCalculationTypeDataTable = ReportDesignBLL.GetSystemReportCalculationTypes
        Dim drSystemReportCalculation As dsReportDesign.SystemReportCalculationTypeRow = dtSystemReportCalculation.Rows(0)

        Dim row As GridViewRow

        For Each row In Me.GridView1.Rows
            If Me.GridView1.DataKeys(row.RowIndex).Item("IsAllowSummaryCalculation").ToString = "False" Then
                For Each drSystemReportCalculation In dtSystemReportCalculation
                    If drSystemReportCalculation.ExcludeForCalculationSummary <> True Then
                        RemoveDataFromDropDown(row, drSystemReportCalculation.CalculationType)
                    End If
                Next
            End If
            'CType(row.FindControl("ddlGroupSummary"), DropDownList).Items(0).Text = ResourceHelper.GetFromResource(CType(row.FindControl("ddlGroupSummary"), DropDownList).Items(0).Text.ToString)
        Next
    End Sub
    Public Function RemoveDataFromDropDown(ByVal row As GridViewRow, ByVal value As String) As Boolean
        For i As Integer = 0 To CType(row.FindControl("ddlGroupSummary"), DropDownList).Items.Count - 1
            If CType(row.FindControl("ddlGroupSummary"), DropDownList).Items(i).Text = value Then
                CType(row.FindControl("ddlGroupSummary"), DropDownList).Items.RemoveAt(i)
                Return True
            End If
        Next
    End Function
    Public Sub DeleteReport(ByVal AccountReportId As Guid)
        ReportDesignBLL.DeleteAccountReportColumnByAccountReportId(AccountReportId)
        ReportDesignBLL.DeleteAccountReportGroupByAccountReportId(AccountReportId)
        ReportDesignBLL.DeleteAccountReportSummaryByAccountReportId(AccountReportId)
    End Sub
    Public Function FileUpload(ByVal objFileUpload As FileUpload) As Boolean

        If objFileUpload.FileName = "" Then
            Return True
        End If

        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")

        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
        If Not System.IO.Directory.Exists(strRoot) Then
            System.IO.Directory.CreateDirectory(strRoot)
        End If
        Dim strAccountPath As String = strRoot & DBUtilities.GetSessionAccountId & "\"
        If Not System.IO.Directory.Exists(strAccountPath) Then
            System.IO.Directory.CreateDirectory(strAccountPath)
        End If
        Dim strLogoPath As String = strAccountPath & "ReportIcon" & "\"
        If Not System.IO.Directory.Exists(strLogoPath) Then
            System.IO.Directory.CreateDirectory(strLogoPath)
        End If
        Dim FileToSave As String = strLogoPath & objFileUpload.FileName
        objFileUpload.SaveAs(FileToSave)

    End Function
    Private Function FindControlRecursive(ByVal root As Control, ByVal id As String) As Control
        If root.ID = id Then
            Return root
        End If
        Dim c As Control
        For Each c In root.Controls
            Dim t As Control = FindControlRecursive(c, id)
            If Not t Is Nothing Then
                Return t
            End If
        Next
        Return Nothing
    End Function
    Public Sub HideTextBoxInGrid(ByVal row As GridViewRow)
        If Me.GridView1.DataKeys(row.RowIndex).Item("IsFormulaField") = False Then
            CType(row.FindControl("FormulaTextBox"), TextBox).Visible = False
            CType(row.FindControl("imgFormula"), HyperLink).Visible = False
        End If
    End Sub
    Public Sub AddReportPermissionForNewReport(ByVal AccountReportIdNew As Guid)
        Dim bll As New ObjectPermissionBLL
        If Me.Request.QueryString("AccountReportId") Is Nothing Then
            Dim RoleBLL As New AccountRoleBLL
            Dim dt As TimeLiveDataSet.AccountRoleDataTable = RoleBLL.GetAccountRolesByAccountIdAndMasterAccountRoleId(DBUtilities.GetSessionAccountId, 1)
            Dim dr As TimeLiveDataSet.AccountRoleRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                bll.AddAccountObjectPermission(AccountReportIdNew, dr.AccountRoleId, DBUtilities.GetSessionAccountId, True, True, True, False, False, False, False, False)
            End If
        Else
            Dim AccountReportIdOld As New Guid(Me.Request.QueryString("AccountReportId"))
            bll.InsertPermissionForNewReport(DBUtilities.GetSessionAccountId, AccountReportIdNew, AccountReportIdOld)
        End If
    End Sub

    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            CType(Me.FormView1.FindControl("ReportNameTextBox"), TextBox).Text = ResourceHelper.GetFromResource(Me.FormView1.DataItem("ReportName"))
            CType(Me.FormView1.FindControl("ReportDescriptionTextBox"), TextBox).Text = ResourceHelper.GetFromResource(Me.FormView1.DataItem("ReportDescription"))
            CType(Me.FormView1.FindControl("chkShowCompanyLogo"), CheckBox).Checked = Me.FormView1.DataItem("ShowCompanyLogo")
            If Not IsDBNull(Me.FormView1.DataItem("ReportTitle")) Then
                CType(Me.FormView1.FindControl("ReportTitleTextBox"), TextBox).Text = Me.FormView1.DataItem("ReportTitle")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ReportHeader")) Then
                CType(Me.FormView1.FindControl("ReportHeaderTextBox"), TextBox).Text = Me.FormView1.DataItem("ReportHeader")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("ReportFooter")) Then
                CType(Me.FormView1.FindControl("ReportFooterTextBox"), TextBox).Text = Me.FormView1.DataItem("ReportFooter")
            End If
        End If
    End Sub
    Public Sub AddCustomizeReportIcon(ByVal IsSystemReport As Boolean)
        If IsSystemReport Then
            If Me.ViewState("ReportIconPath") Is Nothing Then
                Dim AccountReportId As New Guid(Me.Request.QueryString("AccountReportId"))
                Dim ReportIconPath As String = ReportDesignBLL.GetReportIconPathForCustomizeReport(AccountReportId)
                Me.ViewState.Add("ReportIconPath", ReportIconPath)
            End If
        End If
    End Sub
End Class
