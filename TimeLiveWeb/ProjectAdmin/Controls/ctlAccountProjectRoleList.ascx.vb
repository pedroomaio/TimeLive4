
Partial Class ProjectAdmin_Controls_ctlAccountProjectRoleList
    Inherits System.Web.UI.UserControl
    Dim IsProjectRoleUpdated As Boolean

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsProjectRoleUpdated = True Then
            Me.UpdateProjectRoles()
        End If
        If IsProjectRoleUpdated = True Then
            If Me.Request.QueryString("IsTemplate") = "True" Then
                Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&" & "IsTemplate=True&Source=ProjectTemplates", False)
            Else
                If Me.Request.QueryString("Source") = "MyProjects" Then
                    Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&Source=MyProjects", False)
                Else
                    Response.Redirect("~/ProjectAdmin/AccountProjectEmployees.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId"), False)
                End If
            End If
        End If
    End Sub
    Public Sub UpdateProjectRoles()
        Dim row As GridViewRow
        Dim objAccountProjectRole As New AccountProjectRoleBLL
        Dim objAccountBillingRate As New AccountBillingRateBLL
        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL
        Dim AccountWorkTypeId As Integer = Me.lblWorkTypeValue.Text
        Try
            For Each row In Me.GridView1.Rows
                If CType(row.FindControl("BillingRateTextBox"), TextBox).Text = "" Then
                    CType(row.FindControl("BillingRateTextBox"), TextBox).Text = 0
                End If
                If CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = "" Then
                    CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = 0
                End If
                If CType(row.FindControl("NumberOfResourcesTextBox"), TextBox).Text = "" Then
                    CType(row.FindControl("NumberOfResourcesTextBox"), TextBox).Text = 0
                End If
                If CType(row.FindControl("chkSelect"), CheckBox).Checked = False And Not IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Now
                    CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Date.Now
                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And Not IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                    objAccountProjectRole.AddAccountProjectRole(Me.GridView1.DataKeys(row.RowIndex).Item(1), Me.GridView1.DataKeys(row.RowIndex).Item(2), CType(row.FindControl("NumberOfResourcesTextBox"), TextBox).Text, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingTypeId"), DropDownList).SelectedValue, Nothing)
                    objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 2, 0, objAccountProjectRole.GetLastInsertedId, 0, 0, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountWorkTypeId, CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue)
                    objAccountProjectRole.UpdateAccountProjectRole(Me.GridView1.DataKeys(row.RowIndex).Item(1), Me.GridView1.DataKeys(row.RowIndex).Item(2), CType(row.FindControl("NumberOfResourcesTextBox"), TextBox).Text, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingTypeId"), DropDownList).SelectedValue, objAccountBillingRate.GetLastInsertedId, objAccountProjectRole.GetLastInsertedId)
                    Me.UpdateWorkTypeBillingRateOfProjectRole(DBUtilities.GetSessionAccountId, 2, objAccountProjectRole.GetLastInsertedId, objAccountBillingRate.GetLastInsertedId, AccountWorkTypeId)
                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) And IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(5)) Then
                    objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 2, 0, Me.GridView1.DataKeys(row.RowIndex).Item(0), 0, 0, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountWorkTypeId, CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue)
                    objAccountProjectRole.UpdateAccountProjectRole(Me.GridView1.DataKeys(row.RowIndex).Item(1), Me.GridView1.DataKeys(row.RowIndex).Item(2), CType(row.FindControl("NumberOfResourcesTextBox"), TextBox).Text, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingTypeId"), DropDownList).SelectedValue, objAccountBillingRate.GetLastInsertedId, Me.GridView1.DataKeys(row.RowIndex).Item(0))
                    Me.UpdateWorkTypeBillingRateOfProjectRole(DBUtilities.GetSessionAccountId, 2, Me.GridView1.DataKeys(row.RowIndex).Item(0), objAccountBillingRate.GetLastInsertedId, AccountWorkTypeId)
                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) And CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate <> Me.GridView1.DataKeys(row.RowIndex).Item(5) Then
                    objAccountBillingRate.AddAccountBillingRate(DBUtilities.GetSessionAccountId, 2, 0, Me.GridView1.DataKeys(row.RowIndex).Item(0), 0, 0, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, AccountWorkTypeId, CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue)
                    objAccountProjectRole.UpdateAccountProjectRole(Me.GridView1.DataKeys(row.RowIndex).Item(1), Me.GridView1.DataKeys(row.RowIndex).Item(2), CType(row.FindControl("NumberOfResourcesTextBox"), TextBox).Text, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingTypeId"), DropDownList).SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(4), Me.GridView1.DataKeys(row.RowIndex).Item(0))
                    Me.UpdateWorkTypeBillingRateOfProjectRole(DBUtilities.GetSessionAccountId, 2, Me.GridView1.DataKeys(row.RowIndex).Item(0), objAccountBillingRate.GetLastInsertedId, AccountWorkTypeId)
                ElseIf CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) And CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = Me.GridView1.DataKeys(row.RowIndex).Item(5) Then
                    objAccountBillingRate.UpdateAccountBillingRate(DBUtilities.GetSessionAccountId, 2, 0, Me.GridView1.DataKeys(row.RowIndex).Item(0), 0, CType(row.FindControl("BillingRateTextBox"), TextBox).Text, CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate, 0, AccountWorkTypeId, CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text, CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue, CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(4))
                Else
                    If CType(row.FindControl("chkSelect"), CheckBox).Checked = False And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
                        objAccountProjectRole.DeleteAccountProjectRoleId(Me.GridView1.DataKeys(row.RowIndex).Item(0))
                    End If
                End If
            Next
            IsProjectRoleUpdated = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateWorkTypeBillingRateOfProjectRole(ByVal AccountId As Integer, ByVal SystemBillingRateTypeId As Integer, ByVal AccountProjectRoleId As Integer, ByVal AccountBillingRateId As Integer, ByVal AccountWorkTypeId As Integer)

        Dim objAccountWorkTypeBillingRate As New AccountWorkTypeBLL
        Dim objAccountProjectRole As New AccountProjectRoleBLL

        Dim dtAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateDataTable = objAccountWorkTypeBillingRate.GetProjectRoleWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, AccountProjectRoleId, AccountWorkTypeId)
        Dim drAccountWorkTypeBillingRate As TimeLiveDataSet.AccountWorkTypeBillingRateRow

        If objAccountProjectRole.IfWorkTypeBillingRateExistOfProjectRole(AccountId, SystemBillingRateTypeId, AccountProjectRoleId, AccountWorkTypeId) <> True Then
            objAccountWorkTypeBillingRate.AddAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, 0, AccountProjectRoleId, 0, AccountBillingRateId, AccountWorkTypeId)
        Else
            If dtAccountWorkTypeBillingRate.Rows.Count > 0 Then
                drAccountWorkTypeBillingRate = dtAccountWorkTypeBillingRate.Rows(0)
                objAccountWorkTypeBillingRate.UpdateAccountWorkTypeBillingRate(AccountId, SystemBillingRateTypeId, 0, 0, AccountProjectRoleId, 0, AccountBillingRateId, AccountWorkTypeId, drAccountWorkTypeBillingRate.AccountWorkTypeBillingRateId)
            End If
        End If

    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound


    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim row As GridViewRow = e.Row

            CType(row.FindControl("ddlBillingTypeId"), DropDownList).SelectedItem.Text = "Per Hour"

            If CType(row.FindControl("HyperLink1"), HyperLink).Visible = True Then
                If Me.Request.QueryString("Source") = "MyProjects" Then
                    CType(row.FindControl("HyperLink1"), HyperLink).NavigateUrl = "~/AccountAdmin/AccountBillingRate.aspx?AccountProjectRoleId=" & e.Row.DataItem("AccountProjectRoleId") & "&SystemBillingRateTypeId=2&AccountWorkTypeId=" & ddlAccountWorkTypeId.SelectedValue & "&AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Source=MyProjects"
                ElseIf Me.Request.QueryString("Source") = "ProjectTemplates" Then
                    CType(row.FindControl("HyperLink1"), HyperLink).NavigateUrl = "~/AccountAdmin/AccountBillingRate.aspx?AccountProjectRoleId=" & e.Row.DataItem("AccountProjectRoleId") & "&SystemBillingRateTypeId=2&AccountWorkTypeId=" & ddlAccountWorkTypeId.SelectedValue & "&AccountProjectId=" & Request.QueryString("AccountProjectId") & "&Source=ProjectTemplates"
                Else
                    CType(row.FindControl("HyperLink1"), HyperLink).NavigateUrl = "~/AccountAdmin/AccountBillingRate.aspx?AccountProjectRoleId=" & e.Row.DataItem("AccountProjectRoleId") & "&SystemBillingRateTypeId=2&AccountWorkTypeId=" & ddlAccountWorkTypeId.SelectedValue & "&AccountProjectId=" & Request.QueryString("AccountProjectId")
                End If
            End If

                'If Not IsDBNull(row.DataItem("BillingTypeId")) Then
                '    If Not row.DataItem("BillingTypeId") = 0 Then
                '        CType(row.FindControl("ddlBillingTypeId"), DropDownList).SelectedValue = row.DataItem("BillingTypeId")

                '    End If
                'End If

                If IsDBNull(row.DataItem("AccountProjectRoleId")) Then
                    CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                    CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                    CType(row.FindControl("BillingRateTextBox"), TextBox).Text = row.DataItem("RoleBillingRate")
                    CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = 0
                    CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate.AddYears(1)
                    CType(row.FindControl("chkSelect"), CheckBox).Checked = False
                ElseIf row.DataItem("AccountProjectRoleId") <= 0 And AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 1 Then
                    CType(row.FindControl("BillingRateTextBox"), TextBox).Text = row.DataItem("RoleBillingRate")
                    CType(row.FindControl("chkSelect"), CheckBox).Checked = False
                Else
                    If AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 1 Then
                        CType(row.FindControl("BillingRateTextBox"), TextBox).Text = row.DataItem("BillingRate")
                        CType(row.FindControl("StartDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = row.DataItem("StartDate")
                        CType(row.FindControl("EndDateTextBox"), eWorld.UI.CalendarPopup).SelectedDate = row.DataItem("EndDate")
                        CType(row.FindControl("chkSelect"), CheckBox).Checked = True
                    End If
                End If
                If Not IsDBNull(row.DataItem("AccountProjectRoleId")) And AccountProjectBLL.GetProjectBillingRateTypeId(Request.QueryString("AccountProjectId")) = 2 Then
                    If Not IsDBNull(row.DataItem("BillingRateCurrencyId")) Then
                        CType(row.FindControl("dsBillingRateCurrencyObject"), ObjectDataSource).SelectParameters("AccountCurrencyId").DefaultValue = row.DataItem("BillingRateCurrencyId")
                        CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = row.DataItem("BillingRateCurrencyId")
                    Else
                        CType(row.FindControl("ddlBillingRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                        CType(row.FindControl("BillingRateTextBox"), TextBox).Text = 0
                    End If
                    If Not IsDBNull(row.DataItem("EmployeeRateCurrencyId")) Then
                        CType(row.FindControl("dsEmployeeRateCurrencyObject"), ObjectDataSource).SelectParameters("AccountCurrencyId").DefaultValue = row.DataItem("EmployeeRateCurrencyId")
                        CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = row.DataItem("EmployeeRateCurrencyId")
                    Else
                        CType(row.FindControl("ddlEmployeeRateCurrencyId"), DropDownList).SelectedValue = DBUtilities.GetAccountBaseCurrencyId
                        CType(row.FindControl("EmployeeRateTextBox"), TextBox).Text = 0
                    End If
                End If
            End If

            'If CType(row.FindControl("chkSelect"), CheckBox).Checked = True And IsNumeric(Me.GridView1.DataKeys(row.RowIndex).Item(0)) Then
            '    'CType(row.FindControl("NumberOfResourcesTextBox"), TextBox).Text = objrow.NumberOfResources
            '    'CType(row.FindControl("BillingRateTextBox"), TextBox).Text = objrow.BillingRate
            '    'CType(row.FindControl("ddlBillingTypeId"), DropDownList).SelectedValue = objrow.BillingTypeId
            'End If

    End Sub
    Public Sub PopulateData()
        'Dim objDataView As New DataView()
        'Dim Grid As GridView = Me.GridView1
        'Grid.DataSourceID = ""
        'Dim dt As DataTable

        'dt = New AccountProjectRoleBLL().GetAccountProjectRolesForSelectionByAccountWorkTypeId(Request.QueryString("AccountProjectId"), ddlAccountWorkTypeId.SelectedValue)
        'objDataView = dt.DefaultView
        'Grid.DataSource = objDataView

        'Grid.DataBind()
    End Sub

    Protected Sub ddlAccountWorkTypeId_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccountWorkTypeId.PreRender
        Me.lblWorkTypeValue.Text = Me.ddlAccountWorkTypeId.SelectedValue
        Me.PopulateData()
    End Sub

    Protected Sub ddlAccountWorkTypeId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccountWorkTypeId.SelectedIndexChanged
        Me.GridView1.DataBind()
        Me.PopulateData()
    End Sub

    Protected Sub dsAccountProjectRoleObject_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles dsAccountProjectRoleObject.Selecting
        e.InputParameters("AccountWorkTypeId") = ddlAccountWorkTypeId.SelectedValue
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            Me.UpdateProjectRoles()
        End If
        AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        RemoveHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
End Class
