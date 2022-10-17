
Partial Class AccountAdmin_Controls_ctlAccountProjectEmployee
    Inherits System.Web.UI.UserControl
    Dim IsProjectEmployeeUpdated As Boolean
    'Dim Isselect As Boolean
    Protected Sub Update_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Not Me.IsPostBack Then
        If Not IsProjectEmployeeUpdated = True Then
            Me.UpdateProjectEmployees()
        End If
        'End If
        If IsProjectEmployeeUpdated = True Then
            If Me.Request.QueryString("IsTemplate") = "True" Then
                Response.Redirect("~/ProjectAdmin/AccountProjectTemplates.aspx?IsTemplate=True", False)
            Else
                If System.Web.HttpContext.Current.Request.QueryString("Source") = "MyProjects" Then
                    Response.Redirect("~/Employee/MyProjects.aspx", False)
                Else
                    Response.Redirect("~/ProjectAdmin/AccountProjects.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId"), False)
                    Session("AccountProjectId") = Request.QueryString("AccountProjectId")
                    Session("IsAdd") = "1"
                End If
            End If
        End If
       
    End Sub
    Protected Sub btnAddSelectedEmployees_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Not Me.IsPostBack Then
        If Not IsProjectEmployeeUpdated = True Then
            Me.UpdateProjectEmployees()

        End If
        'End If

        Me.chkIsSelected.Checked = True
        Update.Visible = True
        btnAddEmployeesinProject.Visible = True
        btnAddSelectedEmployees.Visible = False
        btnCancel.Visible = False
        ProjectEmployees()
        'Isselect = False
    End Sub
    Public Sub ProjectEmployees()
        If chkIsSelected.Checked = False Then
            If Me.Request.QueryString("IsTemplate") = "True" Then
                Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&IsTemplate=True&Source=ProjectTemplates&Selected=False", False)
            Else
                Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Selected=False&Source=" & Me.Request.QueryString("Source"), False)
            End If
        Else
            If Me.Request.QueryString("IsTemplate") = "True" Then
                Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&IsTemplate=True&Source=ProjectTemplates&Selected=True", False)
            Else
                Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Selected=True", False)
            End If
        End If
    End Sub
    Public Sub UpdateProjectEmployees()
        Dim row As GridViewRow
        Dim objAccountProjectEmployee As New AccountProjectEmployeeBLL
        Dim objAccountBillingRate As New AccountBillingRateBLL
        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL
        Dim AccountWorkTypeId As Integer = Me.lblWorkTypeValue.Text
        For Each row In Me.GridView1.Rows
            CType(row.FindControl("BillingRateTextBox"), TextBox).Text = IIf(CType(row.FindControl("BillingRateTextBox"), TextBox).Text = "", 0, CType(row.FindControl("BillingRateTextBox"), TextBox).Text)
            CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = IIf(CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = "", 0, CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text)
            If AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 1 Then

                If CType(row.FindControl("chkSelect"), CheckBox).Checked = True And Not IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    objAccountProjectEmployee.AddAccountProjectEmployee(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), IIf(Me.GridView1.Columns(1).Visible = True, Me.GridView1.DataKeys(row.RowIndex).Item(1), CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue), IIf(Me.GridView1.Columns(7).Visible = True, CType(row.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue, Nothing), Nothing)
                Else
                    If CType(row.FindControl("chkSelect"), CheckBox).Checked = False And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                        objAccountProjectEmployee.DeleteAccountProjectEmployeeId(Me.GridView1.DataKeys(row.RowIndex).Item(0), Me.Request.QueryString("AccountProjectId"), Me.GridView1.DataKeys(row.RowIndex).Item(1))
                    End If
                End If

            ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 3 Then

                If CType(row.FindControl("chkSelect"), CheckBox).Checked = False And Not IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then

                    CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Now
                    CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Now

                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = False And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    objAccountProjectEmployee.DeleteAccountProjectEmployeeId(Me.GridView1.DataKeys(row.RowIndex).Item(0), Me.Request.QueryString("AccountProjectId"), Me.GridView1.DataKeys(row.RowIndex).Item(1))

                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And Not IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    objAccountProjectEmployee.AddAccountProjectEmployee(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), IIf(Me.GridView1.Columns(1).Visible = True, Me.GridView1.DataKeys(row.RowIndex).Item(1), CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue), IIf(Me.GridView1.Columns(7).Visible = True, CType(row.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue, Nothing), Nothing)
                    objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 3, objAccountProjectEmployee.GetLastInsertedId, 0, 0, 0, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountWorkTypeId, CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingRatecurrencyId"), DropDownList).SelectedValue, CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue)
                    objAccountProjectEmployee.UpdateAccountProjectEmployee(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), IIf(Me.GridView1.Columns(1).Visible = True, Me.GridView1.DataKeys(row.RowIndex).Item(1), CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue), IIf(Me.GridView1.Columns(7).Visible = True, CType(row.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue, Nothing), objAccountBillingRate.GetLastInsertedId, objAccountProjectEmployee.GetLastInsertedId)
                    Me.UpdateWorkTypeBillingRateOfProjectEmployee(DBUtilities.GetSessionAccountId, 3, objAccountProjectEmployee.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, AccountWorkTypeId)

                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) And IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(3)) Then

                    objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 3, Me.GridView1.DataKeys(row.RowIndex).Item(0), 0, 0, 0, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountWorkTypeId, CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingRatecurrencyId"), DropDownList).SelectedValue, CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue)
                    objAccountProjectEmployee.UpdateAccountProjectEmployee(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), IIf(Me.GridView1.Columns(1).Visible = True, Me.GridView1.DataKeys(row.RowIndex).Item(1), CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue), IIf(Me.GridView1.Columns(7).Visible = True, CType(row.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue, Nothing), objAccountBillingRate.GetLastInsertedId, Me.GridView1.DataKeys(row.RowIndex).Item(0))
                    Me.UpdateWorkTypeBillingRateOfProjectEmployee(DBUtilities.GetSessionAccountId, 3, Me.GridView1.DataKeys(row.RowIndex).Item(0), objAccountBillingRate.GetLastInsertedId, AccountWorkTypeId)

                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) And CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Me.GridView1.DataKeys(row.RowIndex).Item(3) Then

                    objAccountBillingRate.UpdateAccountBillingRate(DBUtilities.GetSessionAccountId, 3, Me.GridView1.DataKeys(row.RowIndex).Item(0), 0, 0, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, 0, AccountWorkTypeId, CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingRatecurrencyId"), DropDownList).SelectedValue, CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(2))

                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) And CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate <> Me.GridView1.DataKeys(row.RowIndex).Item(3) Then

                    objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 3, Me.GridView1.DataKeys(row.RowIndex).Item(0), 0, 0, 0, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountWorkTypeId, CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingRatecurrencyId"), DropDownList).SelectedValue, CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue)
                    objAccountProjectEmployee.UpdateAccountProjectEmployee(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), IIf(Me.GridView1.Columns(1).Visible = True, Me.GridView1.DataKeys(row.RowIndex).Item(1), CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue), IIf(Me.GridView1.Columns(7).Visible = True, CType(row.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue, Nothing), objAccountBillingRate.GetLastInsertedId, Me.GridView1.DataKeys(row.RowIndex).Item(0))
                    Me.UpdateWorkTypeBillingRateOfProjectEmployee(DBUtilities.GetSessionAccountId, 3, Me.GridView1.DataKeys(row.RowIndex).Item(0), objAccountBillingRate.GetLastInsertedId, AccountWorkTypeId)

                Else

                    If CType(row.FindControl("chkSelect"), CheckBox).Checked = False And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                        objAccountProjectEmployee.DeleteAccountProjectEmployeeId(Me.GridView1.DataKeys(row.RowIndex).Item(0), Me.Request.QueryString("AccountProjectId"), Me.GridView1.DataKeys(row.RowIndex).Item(1))
                    End If
                End If
            ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 4 Then
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = True And Not IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    objAccountProjectEmployee.AddAccountProjectEmployee(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), IIf(Me.GridView1.Columns(1).Visible = True, Me.GridView1.DataKeys(row.RowIndex).Item(1), CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue), IIf(Me.GridView1.Columns(7).Visible = True, CType(row.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue, Nothing), Nothing)
                Else
                    If CType(row.FindControl("chkSelect"), CheckBox).Checked = False And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                        objAccountProjectEmployee.DeleteAccountProjectEmployeeId(Me.GridView1.DataKeys(row.RowIndex).Item(0), Me.Request.QueryString("AccountProjectId"), Me.GridView1.DataKeys(row.RowIndex).Item(1))
                    End If
                End If
            Else
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = True And Me.GridView1.DataKeys(row.RowIndex).Item(0) <= 0 Then
                    If CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0 Then
                        ShowNotFoundMessage()
                        IsProjectEmployeeUpdated = False
                        Exit Sub
                    End If
                    objAccountProjectEmployee.AddAccountProjectEmployee(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue, CType(row.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue, Nothing)
                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = False And Me.GridView1.DataKeys(row.RowIndex).Item(0) > 0 Then
                    objAccountProjectEmployee.DeleteAccountProjectEmployeeId(Me.GridView1.DataKeys(row.RowIndex).Item(0), Me.Request.QueryString("AccountProjectId"), Me.GridView1.DataKeys(row.RowIndex).Item(1))
                End If
            End If



        Next

        IsProjectEmployeeUpdated = True

    End Sub
    Public Sub UpdateWorkTypeBillingRateOfProjectEmployee(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectEmployeeId As Integer, ByVal AccountBillingRateId As Integer, ByVal AccountWorkTypeId As Integer)

        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL
        Dim objAccountProjectEmployee As New AccountProjectEmployeeBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetProjectEmployeeWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectEmployeeId, AccountWorkTypeId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow

        If objAccountProjectEmployee.IfWorkTypeBillingRateExistOfProjectEmployee(AccountId, SystemBillingRateTypeId, AccountProjectEmployeeId, AccountWorkTypeId) <> True Then
            objAccountWorkTypeBillingRate.AddAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, AccountProjectEmployeeId, 0, 0, AccountBillingRateId, AccountWorkTypeId)
        Else
            If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
                drAccountWorkTypeBillingRate = dtAccountWorkTypeBillingRate.Rows(0)
                objAccountWorkTypeBillingRate.UpdateAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, AccountProjectEmployeeId, 0, 0, AccountBillingRateId, AccountWorkTypeId, drAccountWorkTypeBillingRate.AccountWorkTypeBillingRateId)
            End If
        End If

    End Sub
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim objRow As GridViewRow
        For Each objRow In Me.GridView1.Rows
            If objRow.RowType = DataControlRowType.DataRow Then
                ShowDataForddlAccountEmployeeId(objRow)
            End If
        Next
        'TODO: CheckAll function
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array

        'Get the header CheckBox
        If Me.GridView1.Rows.Count <> 0 Then
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
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim row As GridViewRow = e.Row
            If CType(row.FindControl("HyperLink1"), HyperLink).Visible = True Then
                If Me.Request.QueryString("Source") = "MyProjects" Then
                    CType(row.FindControl("HyperLink1"), HyperLink).NavigateUrl = "~/AccountAdmin/AccountBillingRate.aspx?AccountProjectEmployeeId=" & e.Row.DataItem("AccountProjectEmployeeId") & "&SystemBillingRateTypeId=3&AccountWorkTypeId=" & ddlAccountWorkTypeId.SelectedValue & "&AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Source=MyProjects"
                ElseIf Me.Request.QueryString("Source") = "ProjectTemplates" Then
                    CType(row.FindControl("HyperLink1"), HyperLink).NavigateUrl = "~/AccountAdmin/AccountBillingRate.aspx?AccountProjectEmployeeId=" & e.Row.DataItem("AccountProjectEmployeeId") & "&SystemBillingRateTypeId=3&AccountWorkTypeId=" & ddlAccountWorkTypeId.SelectedValue & "&AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Source=ProjectTemplates"
                Else
                    CType(row.FindControl("HyperLink1"), HyperLink).NavigateUrl = "~/AccountAdmin/AccountBillingRate.aspx?AccountProjectEmployeeId=" & e.Row.DataItem("AccountProjectEmployeeId") & "&SystemBillingRateTypeId=3&AccountWorkTypeId=" & ddlAccountWorkTypeId.SelectedValue & "&AccountProjectId=" & Request.QueryString("AccountProjectId")
                End If
            End If
            If Not IsDBNull(row.DataItem("AccountRoleId")) Then
                If Not row.DataItem("AccountRoleId") = 0 Then
                    CType(row.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue = row.DataItem("AccountRoleId")
                    CType(row.Cells(8).FindControl("dsAccountEmployeeObject"), ObjectDataSource).SelectParameters("AccountEmployeeId").DefaultValue = row.DataItem("AccountEmployeeId")
                    CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).DataBind()
                    CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = row.DataItem("AccountEmployeeId")
                    If IsDBNull(row.DataItem("AccountBillingRateId")) Then
                        row.DataItem("AccountBillingRateId") = 0
                    End If
                    If row.DataItem("AccountBillingRateId") = 0 And row.DataItem("AccountEmployeeId") <> 0 Then
                        CType(row.FindControl("chkSelect"), CheckBox).Checked = True
                    End If
                ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 2 And row.DataItem("AccountRoleId") = 0 Then
                    e.Row.Visible = False
                End If
            End If
            If IsDBNull(row.DataItem("AccountProjectEmployeeId")) Then
                If Not IsDBNull(row.DataItem("EmployeeBillingRate")) And ddlAccountWorkTypeId.SelectedValue = row.DataItem("AccountWorkTypeId") Then
                    CType(row.FindControl("BillingRateTextBox"), TextBox).Text = row.DataItem("EmployeeBillingRate")
                Else
                    CType(row.FindControl("BillingRateTextBox"), TextBox).Text = 0
                End If
                If Not IsDBNull(row.DataItem("EmployeeEmployeeRate")) And ddlAccountWorkTypeId.SelectedValue = row.DataItem("AccountWorkTypeId") Then
                    CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = row.DataItem("EmployeeEmployeeRate")
                Else
                    CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = 0
                End If
                If Not IsDBNull(row.DataItem("EmployeeBillingRateCurrencyId")) And ddlAccountWorkTypeId.SelectedValue = row.DataItem("AccountWorkTypeId") Then
                    CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = row.DataItem("EmployeeBillingRateCurrencyId")
                Else
                    CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                End If
                If Not IsDBNull(row.DataItem("EmployeeEmployeeRateCurrencyId")) And ddlAccountWorkTypeId.SelectedValue = row.DataItem("AccountWorkTypeId") Then
                    CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = row.DataItem("EmployeeEmployeeRateCurrencyId")
                Else
                    CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                End If
                CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today.AddYears(1)
                CType(row.FindControl("chkSelect"), CheckBox).Checked = False
            ElseIf row.DataItem("AccountProjectEmployeeId") <= 0 And AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 1 Then
                CType(row.FindControl("BillingRateTextBox"), TextBox).Text = row.DataItem("EmployeeBillingRate")
                CType(row.FindControl("chkSelect"), CheckBox).Checked = False
            ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 1 Then
                CType(row.FindControl("chkSelect"), CheckBox).Checked = True
            ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 4 Then
                CType(row.FindControl("chkSelect"), CheckBox).Checked = True
            ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 3 And Not IsDBNull(row.DataItem("AccountProjectEmployeeId")) Then
                If Not IsDBNull(row.DataItem("BillingRate")) Then
                    CType(row.FindControl("BillingRateTextBox"), TextBox).Text = row.DataItem("BillingRate")
                End If
                If Not IsDBNull(row.DataItem("EmployeeRate")) Then
                    CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = row.DataItem("EmployeeRate")
                End If
                If Not IsDBNull(row.DataItem("StartDate")) Then
                    CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = row.DataItem("StartDate")
                End If
                If Not IsDBNull(row.DataItem("EndDate")) Then
                    CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = row.DataItem("EndDate")
                End If
                If Not IsDBNull(row.DataItem("BillingRateCurrencyId")) Then
                    CType(row.FindControl("dsBillingRateCurrencyObject"), ObjectDataSource).SelectParameters("AccountCurrencyId").DefaultValue = row.DataItem("BillingRateCurrencyId")
                    CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = row.DataItem("BillingRateCurrencyId")
                End If
                If Not IsDBNull(row.DataItem("EmployeeRateCurrencyId")) Then
                    CType(row.FindControl("dsEmployeeRateCurrencyObject"), ObjectDataSource).SelectParameters("AccountCurrencyId").DefaultValue = row.DataItem("EmployeeRateCurrencyId")
                    CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = row.DataItem("EmployeeRateCurrencyId")
                End If
                CType(row.FindControl("chkSelect"), CheckBox).Checked = True
                If IsDBNull(row.DataItem("AccountBillingRateId")) Then
                    CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today.AddYears(1)
                    CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                    CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                    CType(row.FindControl("BillingRateTextBox"), TextBox).Text = 0
                    CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = 0
                End If
            End If
            If AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 1 Then
                Me.MakeDateTextBoxesInvisible(row)
            ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 2 Then
                Me.MakeDateTextBoxesInvisible(row)
            ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 4 Then
                Me.MakeDateTextBoxesInvisible(row)
            End If

            'Dim dt As TimeLiveDataSet.vueAccountProjectEmployeeDataTable = New AccountProjectEmployeeBLL().GetAccountProjectEmployeesForSelectionByAccountWorkTypeId(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), 0, False)
            'Dim dr As TimeLiveDataSet.vueAccountProjectEmployeeRow
            'If dt.Rows.Count > 0 Then
            '    If dt.Rows.Count <> DataControlRowType.DataRow Then
            '        For Each dr In dt.Rows
            '            'Get a programmatic reference to the CheckBox control
            '            Dim cb As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)

            '            'Add the CheckBox's ID to the client-side CheckBoxIDs array
            '            ScriptManager.RegisterArrayDeclaration(Me, "CheckBoxIDs", String.Concat("'", cb.ClientID, "'"))
            '        Next
            '    End If
            'End If
        End If
    End Sub
    Public Sub MakeDateTextBoxesInvisible(ByVal row As GridViewRow)
        CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).Visible = False
        CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).Visible = False
    End Sub
    Public Sub PopulateData()
        If AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 2 Then
            Me.GridView1.DataSourceID = ""
            Me.GridView1.Columns(1).Visible = False
            Me.GridView1.Columns(2).Visible = False
            Me.GridView1.Columns(3).Visible = False
            Me.GridView1.Columns(7).Visible = True
            Me.GridView1.Columns(16).Visible = False
            Me.GridView1.Columns(14).Visible = False
            Me.GridView1.Columns(13).Visible = False
            Me.GridView1.Columns(12).Visible = False
            Me.GridView1.Columns(10).Visible = False
            Me.GridView1.Columns(11).Visible = False
            Me.GridView1.Columns(9).Visible = False
            Me.GridView1.DataKeyNames = Split("AccountProjectEmployeeId,AccountEmployeeId", ",")
            Me.GridView1.DataSource = dsFilledAccountProjectEmployee
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.UpdateProjectEmployees()
        Me.GridView1.PageIndex = e.NewPageIndex
    End Sub
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
    End Sub
    Protected Sub dsAccountProjectEmployee_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs)
        'e.InputParameters("AccountBillingRateId") = 7
    End Sub
    Protected Sub ddlAccountWorkTypeId_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccountWorkTypeId.PreRender
        lblWorkTypeValue.Text = Me.ddlAccountWorkTypeId.SelectedValue
        Me.PopulateData()
    End Sub
    Protected Sub ddlAccountWorkTypeId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccountWorkTypeId.SelectedIndexChanged
        Me.GridView1.DataBind()
        Me.PopulateData()
    End Sub
    Protected Sub dsAccountProjectEmployee_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsAccountProjectEmployee.Selecting
        If AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 1 Then
            e.InputParameters("AccountWorkTypeId") = ddlAccountWorkTypeId.SelectedValue
            Me.GridView1.Columns(16).Visible = False
            Me.GridView1.Columns(14).Visible = False
            Me.GridView1.Columns(13).Visible = False
            Me.GridView1.Columns(12).Visible = False
            Me.GridView1.Columns(10).Visible = False
            Me.GridView1.Columns(11).Visible = False
            Me.GridView1.Columns(9).Visible = False
            Me.GridView1.Columns(8).Visible = False
        ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 3 Then
            e.InputParameters("AccountWorkTypeId") = ddlAccountWorkTypeId.SelectedValue
            Me.GridView1.Columns(8).Visible = False
            Me.GridView1.Columns(2).Visible = False
            Me.GridView1.Columns(3).Visible = False
        ElseIf AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 4 Then
            e.InputParameters("AccountWorkTypeId") = ddlAccountWorkTypeId.SelectedValue
            Me.GridView1.Columns(16).Visible = False
            Me.GridView1.Columns(14).Visible = False
            Me.GridView1.Columns(13).Visible = False
            Me.GridView1.Columns(12).Visible = False
            Me.GridView1.Columns(10).Visible = False
            Me.GridView1.Columns(11).Visible = False
            Me.GridView1.Columns(9).Visible = False
            Me.GridView1.Columns(8).Visible = False
        End If
    End Sub
    Public Sub ShowNotFoundMessage()
        Dim strMessage As String = Resources.TimeLive.Resource.Please_select_employee_
        Dim strScript As String = "alert('" & strMessage & "'); "
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths

        If Not Me.IsPostBack Then
            If Me.Request.QueryString("Selected") = "False" Then
                Me.chkIsSelected.Checked = "False"
                Update.Visible = True
                btnAddSelectedEmployees.Visible = False
                btnCancel.Visible = True
                btnAddEmployeesinProject.Visible = False
            Else
                Me.chkIsSelected.Checked = "True"
                Update.Visible = True
                btnAddSelectedEmployees.Visible = False
                btnCancel.Visible = False
                btnAddEmployeesinProject.Visible = True
                Dim dt As TimeLiveDataSet.vueAccountProjectEmployeeDataTable = New AccountProjectEmployeeBLL().GetAccountProjectEmployeesForSelectionByAccountWorkTypeId(DBUtilities.GetSessionAccountId, Me.Request.QueryString("AccountProjectId"), 0, False)
                If dt.Rows.Count <= 0 Then
                    If dt.Rows.Count <> DataControlRowType.DataRow Then
                        GridView1.EmptyDataText = ResourceHelper.GetFromResource("No employee selected")
                    End If
                End If
            End If
        End If

    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        RemoveHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
    Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode

        If System.Web.HttpContext.Current.Request.QueryString("Source") = "MyProjects" Then
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(27)
        ElseIf System.Web.HttpContext.Current.Request.QueryString("Source") = "ProjectTemplates" Then
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(103, "~/ProjectAdmin/AccountProjectTemplates.aspx?IsTemplate=True")
        Else
            Return AccountPagePermissionBLL.ChangeCurrentNodeParent(31)
        End If

    End Function
    Public Sub ShowDataForddlAccountEmployeeId(ByVal objrow As GridViewRow)
        If Not CType(objrow.Cells(8).FindControl("ddlAccountEmployeeId"), DropDownList) Is Nothing Then
            CType(objrow.Cells(2).FindControl("ddlAccountEmployeeId"), DropDownList).Items.Clear()
            Dim item As New System.Web.UI.WebControls.ListItem
            item.Text = Resources.TimeLive.Resource.Select
            item.Value = "0"
            CType(objrow.Cells(2).FindControl("ddlAccountEmployeeId"), DropDownList).Items.Add(item)
            CType(objrow.Cells(2).FindControl("ddlAccountEmployeeId"), DropDownList).DataBind()
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
    Protected Sub chkIsSelected_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkIsSelected.CheckedChanged
       ProjectEmployees()
    End Sub
    Protected Sub btnCancel_Click1(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Me.chkIsSelected.Checked = True
       ProjectEmployees()
    End Sub
    Protected Sub btnAddEmployeesinProject_Click1(sender As Object, e As System.EventArgs) Handles btnAddEmployeesinProject.Click
        Me.chkIsSelected.Checked = False
        Update.Visible = False
        btnAddEmployeesinProject.Visible = False
        btnAddSelectedEmployees.Visible = True
        btnCancel.Visible = True
        ProjectEmployees()

    End Sub

End Class
