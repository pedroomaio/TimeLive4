Imports System.DirectoryServices
Partial Class Controls_ctlAccountEmployeeList
    Inherits System.Web.UI.UserControl
    Public Event EditClick(ByVal sender As Object, ByVal CommandArgs As GridViewCommandEventArgs)
    Public Event btnAddEmployeeClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim MasterEntityTypeId As New Guid("3601ae9b-3f82-4c80-9574-751f9a124fa8")
    Dim CustomFieldCaption As String
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            Me.FormView1.Visible = True
            Me.GridView1.Visible = False
            Me.btnAddEmployee.Visible = False
            Me.btnDeleteSelectedItem.Visible = False
            RaiseEvent EditClick(sender, e)
        End If
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        AccountPagePermissionBLL.SetPagePermission(4, Me.GridView1, Me.FormView1, "Add", 6, 7)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            Me.FormView1.Visible = False
            Me.GridView1.Visible = True
            If DBUtilities.IsValidateLockAccount Then
                btnAddEmployee.Enabled = False
            Else
                btnAddEmployee.Enabled = True
            End If
            If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
                Dim BLL As New AccountEmployeeBLL
                If BLL.IsCheckEmployeesRowForLicense(DBUtilities.GetSessionAccountId) Then
                    btnAddEmployee.Enabled = False
                End If
            End If
            Dim LDAP As New LDAPUtilitiesBLL
            If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then
                CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).ValidationGroup = "Insert"
                If DBUtilities.EnablePasswordComplexity = False Then
                    CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = False
                Else
                    CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = True
                End If
            Else
                CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).ValidationGroup = "None"
                CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = False
            End If
            Me.ShowbtnGetUserData()
            'CType(Me.FormView1.FindControl("ddlCountryId"), DropDownList).SelectedValue = DBUtilities.GetAccountCountryId
            'CType(Me.FormView1.FindControl("ddlCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetDefaultCurrencyId
            'CType(Me.FormView1.FindControl("ddlTimeZoneId"), DropDownList).SelectedValue = DBUtilities.GetTimeZoneId
            'CType(Me.FormView1.FindControl("TerminationDateCalendarPopup"), eWorld.UI.CalendarPopup).Nullable = True
            'CType(Me.FormView1.FindControl("HiredDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = Now.Date
            'Me.dsEmployeeTypeObjectInsert.SelectParameters("AccountEmployeeTypeId").DefaultValue = System.Guid.Empty.ToString
            'Me.dsWorkingDayTypeObjectInserted.SelectParameters("AccountWorkingDayTypeId").DefaultValue = System.Guid.Empty.ToString
            'Me.ShowDataForddlEmployeeManagerId()
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            If AccountEmployeeBLL.GetTotalNumberOfUsersInAccount(DBUtilities.GetSessionAccountId) >= LicensingBLL.GetNumberOfUsersAllowed(DBUtilities.GetSessionAccountId) Then
                CType(Me.FormView1.FindControl("ADD"), Button).Enabled = False
            End If
            'CType(Me.FormView1.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
            'CType(Me.FormView1.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
            'CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text = 0
            'CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text = 0
            'CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today
            'CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today
            'CType(Me.FormView1.FindControl("BillingRateEndDateTextbox"), eWorld.UI.CalendarPopup).SelectedDate = CType(Me.FormView1.FindControl("BillingRateEndDateTextbox"), eWorld.UI.CalendarPopup).SelectedDate.AddYears(1)
            'CType(Me.FormView1.FindControl("dllBillingTypeEdit"), DropDownList).Items(1).Selected = True
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Me.FormView1.Visible = True
            Me.GridView1.Visible = False
            GetBillingAndEmployeeRateOfEmployeeOwn(DBUtilities.GetSessionAccountId, 1, Me.FormView1.DataKey("AccountEmployeeId"), CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
            Me.ShowbtnGetUserData()
            Me.ShowDataForddlEmployeeManagerId()
            Me.ShowDataForddlEmployeePolicyId()
            Me.ShowDataForddlHolidayTypeId()
            Me.GetUILanguage()
            Dim LDAP As New LDAPUtilitiesBLL
            If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then
                CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).ValidationGroup = "Edit"
                If DBUtilities.EnablePasswordComplexity = False Then
                    CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = False
                Else
                    CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = True
                End If
            Else
                CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).ValidationGroup = "None"
                CType(Me.FormView1.FindControl("RegularExpressionValidator2"), RegularExpressionValidator).Enabled = False
            End If
            'Dim objAccountEmployee As New AccountEmployeeBLL
            'Dim dt As TimeLiveDataSet.vueAccountEmployeeWithBillingRateDataTable = objAccountEmployee.GetAccountEmployeesWithBillingRateByAccountEmployeeId(Me.FormView1.DataKey("AccountEmployeeId"), CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
            'Dim dr As TimeLiveDataSet.vueAccountEmployeeWithBillingRateRow = dt.Rows(0)
            'If Not IsDBNull(dr("BillingRate")) Then
            'CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text = CType(New AccountEmployeeBLL().GetAccountEmployeesWithBillingRateByAccountEmployeeId(Me.FormView1.DataKey("AccountEmployeeId")).Rows(0), TimeLiveDataSet.vueAccountEmployeeWithBillingRateRow).BillingRate
            'CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).SelectedDate = CType(New AccountEmployeeBLL().GetAccountEmployeesWithBillingRateByAccountEmployeeId(Me.FormView1.DataKey("AccountEmployeeId"), CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue).Rows(0), TimeLiveDataSet.vueAccountEmployeeWithBillingRateRow).BillingRateStartDate
            'CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = CType(New AccountEmployeeBLL().GetAccountEmployeesWithBillingRateByAccountEmployeeId(Me.FormView1.DataKey("AccountEmployeeId"), CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue).Rows(0), TimeLiveDataSet.vueAccountEmployeeWithBillingRateRow).BillingRateEndDate
            'Else
            'CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text = 0
            'CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today
            'CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today
            'CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate.AddYears(1)
            'End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountDepartmentId")) Then
                Me.dsAccountDepartmentObject.SelectParameters("AccountDepartmentId").DefaultValue = Me.FormView1.DataItem("AccountDepartmentId")
                CType(Me.FormView1.FindControl("ddlAccountDepartmentId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountDepartmentId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("Username")) Then
                CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text = Me.FormView1.DataItem("Username")

            Else
                Me.FillUsername()
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountRoleId")) Then
                Me.dsAccountRoleObject.SelectParameters("AccountRoleId").DefaultValue = Me.FormView1.DataItem("AccountRoleId")
                CType(Me.FormView1.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountRoleId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountLocationId")) Then
                Me.dsAccountLocation.SelectParameters("AccountLocationId").DefaultValue = Me.FormView1.DataItem("AccountLocationId")
                CType(Me.FormView1.FindControl("ddlAccountLocationId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountLocationId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("EmployeeManagerId")) Then
                Me.dsEmployeeManagerObject.SelectParameters("AccountEmployeeId").DefaultValue = Me.FormView1.DataItem("EmployeeManagerId")
                CType(Me.FormView1.FindControl("ddlEmployeeManagerId"), DropDownList).SelectedValue = Me.FormView1.DataItem("EmployeeManagerId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("EmployeePayTypeId")) Then
                Dim nAccountEmployeeTypeId As Guid = Me.FormView1.DataItem("EmployeePayTypeId")
                Me.dsEmployeeTypeObject.SelectParameters("AccountEmployeeTypeId").DefaultValue = nAccountEmployeeTypeId.ToString
                CType(Me.FormView1.FindControl("ddlEmployeeTypeId"), DropDownList).SelectedValue = nAccountEmployeeTypeId.ToString
            End If
            If Not IsDBNull(Me.FormView1.DataItem("StatusId")) Then
                Me.dsEmployeeStatusObject.SelectParameters("AccountStatusId").DefaultValue = Me.FormView1.DataItem("StatusId")
                CType(Me.FormView1.FindControl("ddlEmployeeStatusId"), DropDownList).SelectedValue = Me.FormView1.DataItem("StatusId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("HiredDate")) Then
                CType(Me.FormView1.FindControl("HiredDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = Me.FormView1.DataItem("HiredDate")
            Else
                CType(Me.FormView1.FindControl("HiredDateCalendarPopup"), eWorld.UI.CalendarPopup).Nullable = True
                CType(Me.FormView1.FindControl("HiredDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = Nothing
            End If
            If Not IsDBNull(Me.FormView1.DataItem("TerminationDate")) Then
                CType(Me.FormView1.FindControl("TerminationDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate = Me.FormView1.DataItem("TerminationDate")
            Else
                CType(Me.FormView1.FindControl("TerminationDateCalendarPopup"), eWorld.UI.CalendarPopup).Nullable = True
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountWorkingDayTypeId")) Then
                Dim nAccountWorkingDayTypeId As Guid = Me.FormView1.DataItem("AccountWorkingDayTypeId")
                Me.dsWorkingDayTypeObject.SelectParameters("AccountWorkingDayTypeId").DefaultValue = nAccountWorkingDayTypeId.ToString
                CType(Me.FormView1.FindControl("ddlWorkingDayTypeId"), DropDownList).SelectedValue = nAccountWorkingDayTypeId.ToString
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountTimeOffPolicyId")) Then
                Me.dsEmployeePolicyObject.SelectParameters("AccountTimeOffPolicyId").DefaultValue = Me.FormView1.DataItem("AccountTimeOffPolicyId").ToString
                CType(Me.FormView1.FindControl("ddlEmployeePolicyId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountTimeOffPolicyId").ToString
            End If
            If Not IsDBNull(Me.FormView1.DataItem("TimeOffApprovalTypeId")) Then
                CType(Me.FormView1.FindControl("ddlTimeOffApprovalTypeId"), DropDownList).SelectedValue = Me.FormView1.DataItem("TimeOffApprovalTypeId")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("AccountHolidayTypeId")) Then
                'Dim nAccountHolidayTypeId As Guid = Me.FormView1.DataItem("AccountHolidayTypeId")
                CType(Me.FormView1.FindControl("ddlHolidayTypeId"), DropDownList).SelectedValue = Me.FormView1.DataItem("AccountHolidayTypeId").ToString
            End If
            If Not IsDBNull(Me.FormView1.DataItem("IsShowEmployeeProfilePicture")) Then
                CType(Me.FormView1.FindControl("chkIsShowEmployeePicture"), CheckBox).Checked = Me.FormView1.DataItem("IsShowEmployeeProfilePicture")
            End If
            If Not IsDBNull(Me.FormView1.DataItem("IsTimeInOutAvailable")) Then
                CType(Me.FormView1.FindControl("chkTimeinOut"), CheckBox).Checked = Me.FormView1.DataItem("IsTimeInOutAvailable")
            End If
            'CType(Me.FormView1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetSavedCurrentUICulture
            CType(Me.FormView1.FindControl("dllBillingTypeEdit"), DropDownList).Items(1).Selected = True
            'If Not IsDBNull(Me.FormView1.DataItem("BillingTypeId")) Then
            '    Me.dsAccountBillingTypeObject.SelectParameters("AccountBillingTypeId").DefaultValue = Me.FormView1.DataItem("BillingTypeId")
            '    CType(Me.FormView1.FindControl("dllBillingTypeEdit"), DropDownList).SelectedValue = Me.FormView1.DataItem("BillingTypeId")
            'End If
            AccountCustomFieldBLL.SetCustomValuesForFormView_DataBound(FormView1)
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Dim Bll As New AccountEmployeeBLL
            Dim dtEmployee As AccountEmployee.vueAccountEmployeeDataTable = Bll.GetAccountEmployeesByAccountIdAndRole(DBUtilities.GetSessionAccountId, "Administrator")
            Dim drEmployee As AccountEmployee.vueAccountEmployeeRow
            If dtEmployee.Rows.Count = 1 Then
                drEmployee = dtEmployee.Rows(0)
                If drEmployee.AccountEmployeeId = Me.FormView1.DataItem("AccountEmployeeId") Then
                    CType(Me.FormView1.FindControl("chkIsDisabled"), CheckBox).Enabled = False
                    CType(Me.FormView1.FindControl("ddlAccountRoleId"), DropDownList).Enabled = False
                Else
                    CType(Me.FormView1.FindControl("chkIsDisabled"), CheckBox).Enabled = True
                    CType(Me.FormView1.FindControl("ddlAccountRoleId"), DropDownList).Enabled = True
                End If
            End If
            If DBUtilities.IsBillingFeature = True Then
                CType(Me.FormView1.FindControl("RangeValidator1"), RangeValidator).ValidationGroup = "Edit"
                CType(Me.FormView1.FindControl("RangeValidator3"), RangeValidator).ValidationGroup = "Edit"
                CType(Me.FormView1.FindControl("RequiredFieldValidator8"), RequiredFieldValidator).ValidationGroup = "Edit"
                CType(Me.FormView1.FindControl("RequiredFieldValidator1"), RequiredFieldValidator).ValidationGroup = "Edit"

            End If
            If DBUtilities.IsBillingFeature = False Then
                CType(Me.FormView1.FindControl("Billingratetr"), HtmlTableRow).Style("Display") = "none"
                CType(Me.FormView1.FindControl("billingtypetr"), HtmlTableRow).Style("Display") = "none"
                CType(Me.FormView1.FindControl("employeecurrencytr"), HtmlTableRow).Style("Display") = "none"
                CType(Me.FormView1.FindControl("billingcurrencytr"), HtmlTableRow).Style("Display") = "none"
                CType(Me.FormView1.FindControl("billingdatetr"), HtmlTableRow).Style("Display") = "none"
            End If

        End If
    End Sub
    Protected Sub FormView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles FormView1.ItemCommand
        If e.CommandName = "Cancel" Then
            Me.FormView1.ChangeMode(FormViewMode.Insert)
            Me.FormView1.DataBind()
        End If
    End Sub
    Protected Sub dsAccountEmployeeList_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountEmployeeList.Inserting

    End Sub
    Protected Sub dsAccountEmployeeList_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountEmployeeList.Updating

    End Sub
    Protected Sub Update_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.dsAccountEmployeeObject.Update()
    End Sub
    Protected Sub ObjectDataSource1_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
        'If CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text = "" Then
        'CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text = 0
        'End If

        '        If CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text = "" Then
        'CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text = 0
        'E'nd If

        Dim EmployeeBLL As New AccountEmployeeBLL
        'If Not CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text = "" Then
        '        New AccountWorkTypeBLL().GetAccountWorkTypeByAccountId(DBUtilities.getsessionaccountid)

        Dim AccountWorkTypeId As Integer = New AccountWorkTypeBLL().GetDefaultWorkType(DBUtilities.GetSessionAccountId)
        EmployeeBLL.AddBillingRateOfEmployee(0, Now.Date, Now.Date, AccountWorkTypeId, 0, DBUtilities.GetAccountBaseCurrencyId, DBUtilities.GetAccountBaseCurrencyId)
        'End If
        Dim DashboardBLL As New AccountEmployeeDashboardBLL
        DashboardBLL.InsertDefaultForEmployeee(DBUtilities.GetSessionAccountId, EmployeeBLL.GetLastInsertedId)
        Dim ChartBLL As New AccountEmployeeChartBLL
        ChartBLL.InsertDefaultForEmployee(DBUtilities.GetSessionAccountId, EmployeeBLL.GetLastInsertedId)
    End Sub
    Protected Sub ObjectDataSource1_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Inserting
        'If CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).PostedDate = "" Then
        ' CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).PostedDate = Date.Today
        ' End If
        'If CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).PostedDate = "" Then
        'CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).PostedDate = CDate(Date.Today.AddYears(1))
        'CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today.AddYears(1)
        'End If
        'If CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).PostedDate = "" Then
        '    ' e.InputParameters("BillingRateStartDate") = Nothing
        'End If
        DBUtilities.SetRowForInserting(e)
    End Sub
    Protected Sub ObjectDataSource1_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ObjectDataSource1.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            Dim objAccountBillingRate As New AccountBillingRateBLL
            Dim objAccountEmployee As New AccountEmployeeBLL
            Dim BillingRateStartDate As Date
            Dim BillingRateEndDate As Date
            If DBUtilities.IsBillingFeature = True Then
                BillingRateStartDate = CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).SelectedDate
                BillingRateEndDate = CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
            Else
                BillingRateStartDate = Now.Date.Date
                BillingRateEndDate = Now.Date.Date
            End If
            Dim dtEmployee As TimeLiveDataSet.vueAccountEmployeeWithBillingRateDataTable = objAccountEmployee.GetAccountEmployeesWithBillingRateByAccountEmployeeId(Me.FormView1.DataKey("AccountEmployeeId"), CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
            Dim drEmployee As TimeLiveDataSet.vueAccountEmployeeWithBillingRateRow = dtEmployee.Rows(0)
            If IsDBNull(drEmployee("BillingRateStartDate")) Then
                objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 1, 0, 0, Me.FormView1.DataKey("AccountEmployeeId"), 0, IIf(CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text <> "", CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text, 0), BillingRateStartDate, BillingRateEndDate, CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue, IIf(CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text <> "", CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text, 0), CType(Me.FormView1.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue)
                objAccountEmployee.UpdateAccountBillingRateId(objAccountBillingRate.GetLastInsertedId, Me.FormView1.DataKey("AccountEmployeeId"))
                Me.UpdateWorkTypeBillingRateOfEmployeeOwn(DBUtilities.GetSessionAccountId, 1, Me.FormView1.DataKey("AccountEmployeeId"), objAccountBillingRate.GetLastInsertedId, CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
            ElseIf BillingRateStartDate = drEmployee.BillingRateStartDate Then
                objAccountBillingRate.UpdateAccountBillingRate(DBUtilities.GetSessionAccountId, 1, 0, 0, Me.FormView1.DataKey("AccountEmployeeId"), IIf(CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text <> "", CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text, 0), BillingRateStartDate, BillingRateEndDate, 0, CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue, IIf(CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text <> "", CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text, 0), CType(Me.FormView1.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, CType(Me.FormView1.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue, drEmployee.AccountBillingRateId)
            ElseIf BillingRateStartDate <> drEmployee.BillingRateStartDate Then
                objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 1, 0, 0, Me.FormView1.DataKey("AccountEmployeeId"), 0, IIf(CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text <> "", CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text, 0), BillingRateStartDate, BillingRateEndDate, CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue, IIf(CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text <> "", CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text, 0), IIf(CType(Me.FormView1.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue <> "", CType(Me.FormView1.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, DBUtilities.GetAccountBaseCurrencyId), IIf(CType(Me.FormView1.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue <> "", CType(Me.FormView1.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue, DBUtilities.GetAccountBaseCurrencyId))
                objAccountEmployee.UpdateAccountBillingRateId(objAccountBillingRate.GetLastInsertedId, Me.FormView1.DataKey("AccountEmployeeId"))
                Me.UpdateWorkTypeBillingRateOfEmployeeOwn(DBUtilities.GetSessionAccountId, 1, Me.FormView1.DataKey("AccountEmployeeId"), objAccountBillingRate.GetLastInsertedId, CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
            End If
        End If
    End Sub
    Public Sub UpdateWorkTypeBillingRateOfEmployeeOwn(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountBillingRateId As Integer, ByVal AccountWorkTypeId As Integer)
        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL
        Dim objAccountEmployee As New AccountEmployeeBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetEmployeeOwnWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountEmployeeId, AccountWorkTypeId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow
        If objAccountEmployee.IfWorkTypeBillingRateExistOfEmployeeOwn(AccountId, SystemBillingRateTypeId, AccountEmployeeId, AccountWorkTypeId) <> True Then
            objAccountWorkTypeBillingRate.AddAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountEmployeeId, 0, 0, 0, AccountBillingRateId, AccountWorkTypeId)
        Else
            If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
                drAccountWorkTypeBillingRate = dtAccountWorkTypeBillingRate.Rows(0)
                objAccountWorkTypeBillingRate.UpdateAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountEmployeeId, 0, 0, 0, AccountBillingRateId, AccountWorkTypeId, drAccountWorkTypeBillingRate.AccountWorkTypeBillingRateId)
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.ItemCreated
        AccountCustomFieldBLL.CreateCustomFieldOnFormView_ItemCreated(FormView1, New Guid("3601ae9b-3f82-4c80-9574-751f9a124fa8"), "20%", "80%", , IIf(Me.FormView1.CurrentMode = FormViewMode.Edit, "Edit", "Insert"))
        'Dim dllBillingType As DropDownList = Me.FormView1.Row.FindControl("dllBillingTypeEdit")
        'If Not dllBillingType Is Nothing And Not Me.FormView1.DataItem Is Nothing Then
        '    If Not IsDBNull(Me.FormView1.DataItem("BillingTypeId")) Then
        '        dllBillingType.SelectedValue = Me.FormView1.DataItem("BillingTypeId")
        '    End If
        'End If
    End Sub
    Protected Sub ObjectDataSource1_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ObjectDataSource1.Updating
        Dim ddlBillingTypeId As DropDownList = Me.FormView1.Row.FindControl("dllBillingTypeEdit")
        If ddlBillingTypeId.SelectedValue <> "None" Then
            e.InputParameters("BillingTypeId") = ddlBillingTypeId.SelectedValue
        End If

        DBUtilities.SetRowForUpdating(e)

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If LocaleUtilitiesBLL.ShowAdditionalDepartmentInformationInEmployee Then
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "Department")) Then
                    CType(e.Row.Cells(4).FindControl("lblDepartment"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "Department").ToString.Length > 25, Left(DataBinder.Eval(e.Row.DataItem, "Department"), 23) & "..", DataBinder.Eval(e.Row.DataItem, "Department"))
                    If DataBinder.Eval(e.Row.DataItem, "Department").ToString.Length > 25 Then
                        CType(e.Row.Cells(4).FindControl("lblDepartment"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "Department")
                    End If
                End If
            Else
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "DepartmentName")) Then
                    CType(e.Row.Cells(4).FindControl("lblDepartment"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "DepartmentName").ToString.Length > 25, Left(DataBinder.Eval(e.Row.DataItem, "DepartmentName"), 23) & "..", DataBinder.Eval(e.Row.DataItem, "DepartmentName"))
                    If DataBinder.Eval(e.Row.DataItem, "DepartmentName").ToString.Length > 25 Then
                        CType(e.Row.Cells(4).FindControl("lblDepartment"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "DepartmentName")
                    End If
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountLocation")) Then
                CType(e.Row.Cells(5).FindControl("lblLocation"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "AccountLocation").ToString.Length > 23, Left(DataBinder.Eval(e.Row.DataItem, "AccountLocation"), 21) & "..", DataBinder.Eval(e.Row.DataItem, "AccountLocation"))
                If DataBinder.Eval(e.Row.DataItem, "AccountLocation").ToString.Length > 23 Then
                    CType(e.Row.Cells(5).FindControl("lblLocation"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "AccountLocation")
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "EmployeeCode")) Then
                CType(e.Row.Cells(1).FindControl("lblEmployeeCode"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "EmployeeCode").ToString.Length > 13, Left(DataBinder.Eval(e.Row.DataItem, "EmployeeCode"), 11) & "..", DataBinder.Eval(e.Row.DataItem, "EmployeeCode"))
                If DataBinder.Eval(e.Row.DataItem, "EmployeeCode").ToString.Length > 13 Then
                    CType(e.Row.Cells(1).FindControl("lblEmployeeCode"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "EmployeeCode")
                End If
            End If
            If Not Me.Request.QueryString("AccountEmployeeId") Is Nothing Then

                If DataBinder.Eval(e.Row.DataItem, "AccountEmployeeId") = New AccountEmployeeBLL().GetLastInsertedId Then
                    Dim lastRowIndex = e.Row.RowIndex
                    Dim integ As Integer
                    Dim fract As Decimal
                    e.Row.BackColor = Color.SteelBlue
                    e.Row.Cells(0).ForeColor = Color.White
                    e.Row.Cells(1).ForeColor = Color.White
                    e.Row.Cells(2).ForeColor = Color.White
                    e.Row.Cells(3).ForeColor = Color.White
                    e.Row.Cells(4).ForeColor = Color.White
                    e.Row.Cells(5).ForeColor = Color.White
                    Dim TimeOff As HyperLink = e.Row.FindControl("TimeOffStausHyperLink")
                    Dim EmployeeProject As HyperLink = e.Row.FindControl("EmployeeProjectHyperLink")
                    Dim CostCenter As HyperLink = e.Row.FindControl("CostCenterEmployeeHyperLink")

                    TimeOff.ForeColor = Color.White
                    EmployeeProject.ForeColor = Color.White
                    CostCenter.ForeColor = Color.White

                End If
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.ShowbtnGetUserData()
            If Not Me.Request.QueryString("AccountEmployeeId") Is Nothing Then
                Me.GridView1.DataBind()
                GridView1.PageIndex = GridView1.PageCount
                Session.Item("IsInsert") = 0
            Else
                Session.Item("IsInsert") = 0
            End If
        Else
            Me.ShowbtnGetUserData()
        End If
    End Sub
    Public Sub ShowbtnGetUserData()
        Dim LDAP As New LDAPUtilitiesBLL
        If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            CType(Me.FormView1.FindControl("btnGetUserData"), Button).Visible = True
        Else
            If Not CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox) Is Nothing Then
                CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).ReadOnly = True
                CType(Me.FormView1.FindControl("btnGetUserData"), Button).Visible = False
            End If
        End If
    End Sub
    Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        Dim BLL As New AccountEmployeeBLL
        If Not e.Exception Is Nothing Then
            Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            If Not e.Exception.InnerException Is Nothing Then
                lblExceptionText.Text = e.Exception.InnerException.Message
            Else
                lblExceptionText.Text = e.Exception.Message
            End If
            lblExceptionText.Visible = True
            e.ExceptionHandled = True
            e.KeepInInsertMode = True
        Else
            Me.FormView1.Visible = False
            Me.GridView1.Visible = True
            Me.btnAddEmployee.Visible = True
        End If
        If e.Exception Is Nothing Then
            Me.FormView1.DataBind()
            ''Response.Redirect("~/AccountAdmin/AccountEmployees.aspx?AccountEmployeeId=" & BLL.GetLastInsertedId, False)
            Session.Item("IsInsert") = 1
            Server.Transfer("~/AccountAdmin/AccountEmployees.aspx?AccountEmployeeId=" & New AccountEmployeeBLL().GetLastInsertedId)
        End If
    End Sub
    Protected Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView1.ItemInserting
        If Session.Item("IsInsert") <> 1 Then
            Dim AccountId As Integer
            AccountId = DBUtilities.GetSessionAccountId
            e.Values.Item("EmployeePayTypeId") = New AccountEmployeeTypeBLL().GetDefaultAccountEmployeeTypeId(AccountId)
            e.Values.Item("StatusId") = New AccountStatusBLL().GetDefaultAccountStatusId(AccountId)
            e.Values.Item("AccountWorkingDayTypeId") = New AccountWorkingDayTypeBLL().GetDefaultAccountWorkingDayTypeId(AccountId)
            e.Values.Item("BillingTypeId") = New AccountBillingTypeBLL().GetDefaultBillingType(AccountId, 1)
            e.Values.Item("UserInterfaceLanguage") = DBUtilities.GetUserInterfaceLanguage
            e.Values.Item("HiredDate") = CType(Me.FormView1.FindControl("HiredDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate
            e.Values.Item("TimeZoneId") = DBUtilities.GetTimeZoneId
            e.Values.Item("CountryId") = DBUtilities.GetAccountCountryId
            e.Values.Item("AccountLocationId") = New AccountLocationBLL().GetLocationId(AccountId)
            For n As Integer = 1 To 15
                AccountCustomFieldBLL.SetCustomValuesForFormView_Inserting(FormView1, e, MasterEntityTypeId, "CustomField" & n)
                If e.Cancel = True Then
                    Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                    CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                    UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
                End If
            Next
            'If CType(Me.FormView1.FindControl("ddlEmployeePolicyId"), DropDownList).SelectedValue <> "0" Then
            '    e.Values.Item("AccountTimeOffPolicyId") = CType(Me.FormView1.FindControl("ddlEmployeePolicyId"), DropDownList).SelectedValue
            'Else
            '    e.Values.Item("AccountTimeOffPolicyId") = System.Guid.Empty.ToString
            'End If
        Else
            e.Cancel = True
            Server.Transfer("~/AccountAdmin/AccountEmployees.aspx")

        End If
    End Sub
    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        'AddEmployeeTypeOffByPolicy(True)
        If Not e.Exception Is Nothing Then
            Dim lblExceptionText As Label = Me.FormView1.FindControl("lblExceptionText")
            lblExceptionText.Visible = True
            lblExceptionText.Text = e.Exception.InnerException.Message
            e.ExceptionHandled = True
            e.KeepInEditMode = True
        Else
        End If
        'Me.GridView1.DataBind()
        Response.Redirect("~/AccountAdmin/AccountEmployees.aspx", False)
    End Sub
    Protected Sub FormView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView1.ItemUpdating
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            e.NewValues.Item("Username") = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
            e.NewValues.Item("AccountLocationId") = CType(Me.FormView1.FindControl("ddlAccountLocationId"), DropDownList).SelectedValue
            e.NewValues.Item("AccountRoleId") = CType(Me.FormView1.FindControl("ddlAccountRoleId"), DropDownList).SelectedValue
            e.NewValues.Item("AccountDepartmentId") = CType(Me.FormView1.FindControl("ddlAccountDepartmentId"), DropDownList).SelectedValue
            e.NewValues.Item("EmployeeManagerId") = CType(Me.FormView1.FindControl("ddlEmployeeManagerId"), DropDownList).SelectedValue
            e.NewValues.Item("EmployeePayTypeId") = CType(Me.FormView1.FindControl("ddlEmployeeTypeId"), DropDownList).SelectedValue
            e.NewValues.Item("StatusId") = CType(Me.FormView1.FindControl("ddlEmployeeStatusId"), DropDownList).SelectedValue
            e.NewValues.Item("AccountWorkingDayTypeId") = CType(Me.FormView1.FindControl("ddlWorkingDayTypeId"), DropDownList).SelectedValue
            e.NewValues.Item("UserInterfaceLanguage") = CType(Me.FormView1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue
            e.NewValues.Item("IsShowEmployeeProfilePicture") = CType(Me.FormView1.FindControl("chkIsShowEmployeePicture"), CheckBox).Checked
            If DBUtilities.IsAttendanceFeature Then
                e.NewValues.Item("IsTimeInOutAvailable") = CType(Me.FormView1.FindControl("chkTimeinOut"), CheckBox).Checked
            Else
                e.NewValues.Item("IsTimeInOutAvailable") = False
            End If
            If CType(Me.FormView1.FindControl("ddlHolidayTypeId"), DropDownList).SelectedValue <> "0" Then
                e.NewValues.Item("AccountHolidayTypeId") = CType(Me.FormView1.FindControl("ddlHolidayTypeId"), DropDownList).SelectedValue
            Else
                e.NewValues.Item("AccountHolidayTypeId") = System.Guid.Empty.ToString
            End If
            If CType(Me.FormView1.FindControl("HiredDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedValue.HasValue Then
                e.NewValues.Item("HiredDate") = CType(Me.FormView1.FindControl("HiredDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate
            End If
            If CType(Me.FormView1.FindControl("TerminationDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedValue.HasValue Then
                e.NewValues.Item("TerminationDate") = CType(Me.FormView1.FindControl("TerminationDateCalendarPopup"), eWorld.UI.CalendarPopup).SelectedDate
            End If
            If e.NewValues.Item("EmployeeCode") = "" Then
                e.NewValues.Item("EmployeeCode") = "RedirectFromAccountEmployee"
            End If
            If CType(Me.FormView1.FindControl("ddlEmployeePolicyId"), DropDownList).SelectedValue <> "0" Then
                e.NewValues.Item("AccountTimeOffPolicyId") = CType(Me.FormView1.FindControl("ddlEmployeePolicyId"), DropDownList).SelectedValue
            Else
                e.NewValues.Item("AccountTimeOffPolicyId") = System.Guid.Empty.ToString
            End If
            e.NewValues.Item("TimeOffApprovalTypeId") = CType(Me.FormView1.FindControl("ddlTimeOffApprovalTypeId"), DropDownList).SelectedValue
        End If
        For n As Integer = 1 To 15
            AccountCustomFieldBLL.SetCustomValuesForFormView_Updating(FormView1, e, MasterEntityTypeId, "CustomField" & n)
            If e.Cancel = True Then
                Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                CustomFieldCaption = AccountCustomFieldBLL.GetCustomFieldCaption("CustomField" & n, MasterEntityTypeId)
                UIUtilities.ShowMessage(CustomFieldCaption & " Field is required.", CurrentPage)
            End If
        Next
        If e.Cancel = True Then
            Me.GridView1.Visible = False
            Me.btnAddEmployee.Visible = False
            Me.btnDeleteSelectedItem.Visible = False
        Else
            Me.GridView1.Visible = True
            Me.btnAddEmployee.Visible = True
            Me.btnDeleteSelectedItem.Visible = True
        End If
        'If CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).SelectedValue.HasValue Then
        '    e.NewValues("BillingRateStartDate") = CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).SelectedDate
        'End If
        'If CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedValue.HasValue Then
        '    e.NewValues("BillingRateEndDate") = CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate
        'End If
    End Sub
    Public Function Validate() As Boolean
        Dim LDAP As New LDAPUtilitiesBLL
        Dim username As String = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
        Dim password As String = CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text
        If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            If LDAP.IsValidUserNameAndPassword(username, password) = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function
    Public Function GetUserData() As Boolean
        Dim LDAP As New LDAPUtilitiesBLL
        If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            Dim Username As String = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
            Dim User As DirectoryEntry = LDAP.GetUserByName(Username)
            If Not User Is Nothing Then
                If Not User.Properties("givenname").Value Is Nothing Then
                    CType(Me.FormView1.FindControl("FirstNameTextBox"), TextBox).Text = User.Properties("givenname").Item(0)
                Else
                    CType(Me.FormView1.FindControl("FirstNameTextBox"), TextBox).Text = Username
                End If
                If Not User.Properties("sn").Value Is Nothing Then
                    CType(Me.FormView1.FindControl("LastNameTextBox"), TextBox).Text = User.Properties("sn").Item(0)
                Else
                    CType(Me.FormView1.FindControl("LastNameTextBox"), TextBox).Text = Username
                End If
                If Not User.Properties("mail").Value Is Nothing Then
                    CType(Me.FormView1.FindControl("EMailAddressTextBox"), TextBox).Text = User.Properties("mail").Item(0)
                Else
                    CType(Me.FormView1.FindControl("EMailAddressTextBox"), TextBox).Text = Username & "@" & Username & ".com"
                End If
                If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                    CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text = Username
                    CType(Me.FormView1.FindControl("VerifyPasswordTextbox"), TextBox).Text = Username
                End If
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Protected Sub UsernameTextBox_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub btnGetUserData_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.GetUserData()

    End Sub
    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim LDAP As New LDAPUtilitiesBLL
        If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            args.IsValid = Me.GetUserData = True
        End If
    End Sub
    Protected Sub CustomValidator2_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim LDAP As New LDAPUtilitiesBLL
        If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            args.IsValid = Me.CheckUserOnUpdate = True
        End If
    End Sub
    Protected Sub EMailAddressTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FillUsername()
    End Sub
    Public Sub FillUsername()
        Dim LDAP As New LDAPUtilitiesBLL
        If LDAP.IsAspNetActiveDirectoryMembershipProvider <> True Then
            CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text = CType(Me.FormView1.FindControl("EMailAddressTextBox"), TextBox).Text
        End If
    End Sub
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        UIUtilities.OnDeleteException(e)
        UIUtilities.AfterGridViewRowDelete(Me.FormView1)
    End Sub
    Public Function CheckUserOnUpdate() As Boolean
        Dim LDAP As New LDAPUtilitiesBLL
        If LDAP.IsAspNetActiveDirectoryMembershipProvider = True Then
            Dim Username As String = CType(Me.FormView1.FindControl("UsernameTextBox"), TextBox).Text
            Dim User As DirectoryEntry = LDAP.GetUserByName(Username)
            If Not User Is Nothing Then
                If Me.FormView1.CurrentMode = FormViewMode.Insert Then
                    CType(Me.FormView1.FindControl("PasswordTextBox"), TextBox).Text = Username
                    CType(Me.FormView1.FindControl("VerifyPasswordTextbox"), TextBox).Text = Username
                End If
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Protected Sub ddlAccountWorkTypeId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        GetBillingAndEmployeeRateOfEmployeeOwn(DBUtilities.GetSessionAccountId, 1, Me.FormView1.DataKey("AccountEmployeeId"), CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue)
    End Sub
    Public Sub GetBillingAndEmployeeRateOfEmployeeOwn(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountWorkTypeId As Integer)
        Dim WorkTypeBLL As New AccountWorkTypeBLL
        Dim BillingRateBLL As New AccountBillingRateBLL
        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = WorkTypeBLL.GetEmployeeOwnWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountEmployeeId, AccountWorkTypeId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow
        If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
            drAccountWorkTypeBillingRate = dtAccountWorkTypeBillingRate.Rows(0)
            Dim dtAccountBillingRate As AccountBillingRate.AccountBillingRateDataTable = BillingRateBLL.GetAccountBillingRatesByAccountBillingRateId(drAccountWorkTypeBillingRate.AccountBillingRateId)
            Dim drAccountBillingRate As AccountBillingRate.AccountBillingRateRow
            If dtAccountBillingRate.Rows.Count > 0 Then
                drAccountBillingRate = dtAccountBillingRate.Rows(0)
                If Not IsDBNull(drAccountBillingRate.BillingRateCurrencyId) Then
                    Me.dsBillingRateCurrencyObject.SelectParameters("AccountCurrencyId").DefaultValue = drAccountBillingRate.BillingRateCurrencyId
                    CType(Me.FormView1.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = drAccountBillingRate.BillingRateCurrencyId
                End If
                If Not IsDBNull(drAccountBillingRate.EmployeeRateCurrencyId) Then
                    Me.dsEmployeeRateCurrencyObject.SelectParameters("AccountCurrencyId").DefaultValue = drAccountBillingRate.EmployeeRateCurrencyId
                    CType(Me.FormView1.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = drAccountBillingRate.EmployeeRateCurrencyId
                End If
                CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text = drAccountBillingRate.BillingRate
                CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text = drAccountBillingRate.EmployeeRate
                CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).SelectedDate = drAccountBillingRate.StartDate
                CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = drAccountBillingRate.EndDate
            Else
                CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text = 0
                CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text = 0
            End If
        Else
            CType(Me.FormView1.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
            CType(Me.FormView1.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
            CType(Me.FormView1.FindControl("BillingRateTextBox"), TextBox).Text = 0
            CType(Me.FormView1.FindControl("EmployeeRateTextBox"), TextBox).Text = 0
            CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today
            CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today
            CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate.AddYears(1)
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AccountEmployeeId As Integer = Me.FormView1.DataKey("AccountEmployeeId")
        Dim AccountWorkTypeId As Integer = CType(Me.FormView1.FindControl("ddlAccountWorkTypeId"), DropDownList).SelectedValue
        Response.Redirect("~/AccountAdmin/AccountBillingRate.aspx?AccountEmployeeId=" & AccountEmployeeId & "&SystemBillingRateTypeId=1&AccountWorkTypeId=" & AccountWorkTypeId, False)
    End Sub
    Public Sub ShowDataForddlEmployeeManagerId()
        CType(Me.FormView1.FindControl("ddlEmployeeManagerId"), DropDownList).Items.Clear()
        Dim item As New System.Web.UI.WebControls.ListItem
        item.Text = "<None>"
        item.Value = "0"
        CType(Me.FormView1.FindControl("ddlEmployeeManagerId"), DropDownList).Items.Add(item)
        If Not IsDBNull(Me.FormView1.DataItem("EmployeeManagerId")) Then
            Me.dsEmployeeManagerObject.SelectParameters("AccountEmployeeId").DefaultValue = Me.FormView1.DataItem("EmployeeManagerId")
        End If
        CType(Me.FormView1.FindControl("ddlEmployeeManagerId"), DropDownList).DataBind()
    End Sub
    Public Sub ShowDataForddlEmployeePolicyId()
        CType(Me.FormView1.FindControl("ddlEmployeePolicyId"), DropDownList).Items.Clear()
        Dim item As New System.Web.UI.WebControls.ListItem
        item.Text = "None"
        item.Value = "0"
        CType(Me.FormView1.FindControl("ddlEmployeePolicyId"), DropDownList).Items.Add(item)
        If Not IsDBNull(Me.FormView1.DataItem("AccountTimeOffPolicyId")) Then
            Me.dsEmployeePolicyObject.SelectParameters("AccountTimeOffPolicyId").DefaultValue = Me.FormView1.DataItem("AccountTimeOffPolicyId").ToString
        Else
            Me.dsEmployeePolicyObject.SelectParameters("AccountTimeOffPolicyId").DefaultValue = System.Guid.Empty.ToString
        End If
        CType(Me.FormView1.FindControl("ddlEmployeePolicyId"), DropDownList).DataBind()
    End Sub
    Public Sub ShowDataForddlHolidayTypeId()
        CType(Me.FormView1.FindControl("ddlHolidayTypeId"), DropDownList).Items.Clear()
        Dim item As New System.Web.UI.WebControls.ListItem
        item.Text = "None"
        item.Value = "0"
        CType(Me.FormView1.FindControl("ddlHolidayTypeId"), DropDownList).Items.Add(item)
        If Not IsDBNull(Me.FormView1.DataItem("AccountHolidayTypeId")) Then
            Me.dsHolidayTypeObject.SelectParameters("AccountHolidayTypeId").DefaultValue = Me.FormView1.DataItem("AccountHolidayTypeId").ToString
        Else
            Me.dsHolidayTypeObject.SelectParameters("AccountHolidayTypeId").DefaultValue = System.Guid.Empty.ToString
        End If
        CType(Me.FormView1.FindControl("ddlHolidayTypeId"), DropDownList).DataBind()
    End Sub
    Protected Sub Add_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.FormView1.Visible = False
        'Me.GridView1.Visible = True
        'Me.btnAddEmployee.Visible = True
        'Dim BLL As New AccountEmployeeBLL
        'If Me.FormView1.CurrentMode = FormViewMode.Insert Then
        '    BLL.FileUpload(Me.FormView1.FindControl("txtElectronicSign"), BLL.GetLastInsertedId)
        'End If
    End Sub
    Protected Sub Update_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.FormView1.Visible = False
        Dim BLL As New AccountEmployeeBLL
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            BLL.FileUpload(Me.FormView1.FindControl("txtElectronicSign"), Me.FormView1.DataKey("AccountEmployeeId"))
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            BLL.FileUploadForProfile(Me.FormView1.FindControl("FileUpload1"), Me.FormView1.DataKey("AccountEmployeeId"))
        End If
        'BLL.UpdateIsElectronicSign(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, CType(Me.FormView1.FindControl("chkShowElectronicSignInTimesheet"), CheckBox).Checked)
        'UIUtilities.RedirectToAdminHomePage()
    End Sub
    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FormView1.Visible = False
        Me.GridView1.Visible = True
        Me.btnAddEmployee.Visible = True
        Me.btnDeleteSelectedItem.Visible = True
    End Sub
    Protected Sub btnAddEmployee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddEmployee.Click
        Me.FormView1.Visible = True
        'CType(Me.FormView1.FindControl("BillingRateStartDate"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today
        'CType(Me.FormView1.FindControl("BillingRateEndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Today
        'CType(Me.FormView1.FindControl("BillingRateEndDateTextbox"), eWorld.UI.CalendarPopup).SelectedDate = CType(Me.FormView1.FindControl("BillingRateEndDateTextbox"), eWorld.UI.CalendarPopup).SelectedDate.AddYears(1)
        'Me.FormView1.DataBind()
        Me.GridView1.Visible = False
        Me.btnAddEmployee.Visible = False
        Me.btnDeleteSelectedItem.Visible = False
        RaiseEvent btnAddEmployeeClick(sender, e)
    End Sub
    Protected Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        Dim dt As AccountFeatureManagement.AccountFeaturesDataTable
        dt = New AccountFeatureManagementBLL().GetAccountFeatureByAccountIdAndSystemFeatureId(DBUtilities.GetSessionAccountId, New System.Guid("76AAF57E-96A4-4476-94A4-575824E9B9FA"))
        If dt.Rows.Count > 0 Then
            Me.GridView1.Columns(10).Visible = True
        Else
            Me.GridView1.Columns(10).Visible = False
        End If

        'TODO: CheckAll function
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array

        'Get the header CheckBox
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If Me.GridView1.DataKeys(row.RowIndex).Item(0) <> 0 Then
                Me.btnDeleteSelectedItem.Visible = True
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
        If DBUtilities.GetCostCenterInTimesheetBy = "Account" Then
            Me.GridView1.Columns(12).Visible = False
        Else
            Me.GridView1.Columns(12).Visible = True
        End If
    End Sub
    Protected Sub btnDeleteSelectedItem_Click(sender As Object, e As System.EventArgs) Handles btnDeleteSelectedItem.Click
        Dim row As GridViewRow
        Dim Original_AccountEmployeeId As Integer
        For Each row In Me.GridView1.Rows
            If Me.GridView1.DataKeys(row.RowIndex)(0) <> 0 Then
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = True Then
                    Original_AccountEmployeeId = Me.GridView1.DataKeys(row.RowIndex)(0)
                    Dim BLL As New AccountEmployeeBLL
                    If Original_AccountEmployeeId <> DBUtilities.GetSessionAccountEmployeeId Then
                        Original_AccountEmployeeId = New AccountEmployeeBLL().DeleteAccountEmployee(Original_AccountEmployeeId)
                    End If
                End If
            End If
        Next
        Me.GridView1.DataBind()
    End Sub
    Public Sub GetUILanguage()
        Dim bll As New AccountEmployeeBLL
        Dim AccountEmployeeId As Integer = Me.FormView1.DataKey("AccountEmployeeId")
        Dim dt As AccountEmployee.AccountEmployeeDataTable = bll.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
        Dim dr As AccountEmployee.AccountEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.UserInterfaceLanguage) Then
                CType(Me.FormView1.FindControl("ddlUserInterfaceLanguage"), DropDownList).SelectedValue = dr.UserInterfaceLanguage
            End If
        End If
    End Sub
End Class



