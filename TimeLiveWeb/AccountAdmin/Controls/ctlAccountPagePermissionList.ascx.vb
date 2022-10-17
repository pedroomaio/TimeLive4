
Partial Class AccountAdmin_Controls_ctlAccountPagePermissionList
    Inherits System.Web.UI.UserControl

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim row As GridViewRow
        Dim objAccountPagePermission As New AccountPagePermissionBLL



        Try
            For Each row In Me.GridView1.Rows
                If CType(row.FindControl("chkListView"), CheckBox).Checked = True Then
                    objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(0), 1, CType(row.FindControl("chkListViewShowAllData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing)
                    If Me.GridView1.DataKeys(row.RowIndex).Item(0) = 18 Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 19, 1, CType(row.FindControl("chkListViewShowAllData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing)
                    ElseIf Me.GridView1.DataKeys(row.RowIndex).Item(0) = 20 Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 20, 1, CType(row.FindControl("chkListViewShowAllData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing)
                    End If
                Else
                    If CType(row.FindControl("chkListView"), CheckBox).Checked = False Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(0), 1, CType(row.FindControl("chkListViewShowAllData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing, True)
                        If Me.GridView1.DataKeys(row.RowIndex).Item(0) = 18 Then
                            objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 19, 1, CType(row.FindControl("chkListViewShowAllData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing, True)
                        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item(0) = 20 Then
                            objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 20, 1, CType(row.FindControl("chkListViewShowAllData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkListViewShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing, True)
                        End If
                    End If
                End If


                If CType(row.FindControl("chkAdd"), CheckBox).Checked = True Then
                    objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(0), 2, CType(row.FindControl("chkAddShowAllData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing)
                    If Me.GridView1.DataKeys(row.RowIndex).Item(0) = 18 Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 19, 2, CType(row.FindControl("chkAddShowAllData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing)
                    ElseIf Me.GridView1.DataKeys(row.RowIndex).Item(0) = 20 Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 20, 2, CType(row.FindControl("chkAddShowAllData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing)
                    End If
                Else
                    If CType(row.FindControl("chkAdd"), CheckBox).Checked = False Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(0), 2, CType(row.FindControl("chkAddShowAllData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing, True)
                        If Me.GridView1.DataKeys(row.RowIndex).Item(0) = 18 Then
                            objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 19, 2, CType(row.FindControl("chkAddShowAllData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing, True)
                        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item(0) = 20 Then
                            objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 20, 2, CType(row.FindControl("chkAddShowAllData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing, True)
                        End If
                    End If
                End If


                If CType(row.FindControl("chkEdit"), CheckBox).Checked = True Then
                    objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(0), 3, CType(row.FindControl("chkEditShowAllData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing)
                    If Me.GridView1.DataKeys(row.RowIndex).Item(0) = 18 Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 19, 3, CType(row.FindControl("chkEditShowAllData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing)
                    ElseIf Me.GridView1.DataKeys(row.RowIndex).Item(0) = 20 Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 20, 3, CType(row.FindControl("chkEditShowAllData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing)
                    End If
                Else
                    If CType(row.FindControl("chkEdit"), CheckBox).Checked = False Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(0), 3, CType(row.FindControl("chkEditShowAllData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing, True)
                        If Me.GridView1.DataKeys(row.RowIndex).Item(0) = 18 Then
                            objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 19, 3, CType(row.FindControl("chkEditShowAllData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing, True)
                        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item(0) = 20 Then
                            objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 20, 3, CType(row.FindControl("chkEditShowAllData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Checked, Nothing, Nothing, True)
                        End If
                        'CType(row.FindControl("chkEditShowAllData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Checked
                    End If
                End If

                If CType(row.FindControl("chkDelete"), CheckBox).Checked = True Then
                    objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(0), 4, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                    If Me.GridView1.DataKeys(row.RowIndex).Item(0) = 18 Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 19, 4, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                    ElseIf Me.GridView1.DataKeys(row.RowIndex).Item(0) = 20 Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 20, 4, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                    End If
                Else
                    If CType(row.FindControl("chkDelete"), CheckBox).Checked = False Then
                        objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(0), 4, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, True)
                        If Me.GridView1.DataKeys(row.RowIndex).Item(0) = 18 Then
                            objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 19, 4, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, True)
                        ElseIf Me.GridView1.DataKeys(row.RowIndex).Item(0) = 20 Then
                            objAccountPagePermission.SetAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, 20, 4, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, True)
                        End If
                        'CType(row.FindControl("chkDeleteShowAllData"), CheckBox).Checked, CType(row.FindControl("chkDeleteShowMyData"), CheckBox).Checked, CType(row.FindControl("chkDeleteShowMyProjectsData"), CheckBox).Checked, CType(row.FindControl("chkDeleteShowMyTeamsData"), CheckBox).Checked
                    End If
                End If

            Next
            'If ddlDefaultAccountPageId.SelectedValue <> 0 Then
            Dim objAccountRole As New AccountRoleBLL
            objAccountRole.UpdateDefaultAccountPage(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, ddlDefaultAccountPageId.SelectedValue)
            'End If
            objAccountPagePermission.ResetPageSecurity()


        Catch ex As Exception
            Throw ex

        End Try
        UIUtilities.RedirectToAdminHomePage()

    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        AccountPagePermissionBLL.SetPagePermissionForGridViewAndButton(85, Me.GridView1, Me.btnUpdate)
        Me.SetDefaultPage()
        Dim row As GridViewRow
        Dim bll As New AccountPagePermissionBLL

        For Each row In Me.GridView1.Rows
            Dim dt As TimeLiveDataSet.AccountPagePermissionDataTable = bll.GetDataForAccountPagePermission(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue, Me.GridView1.DataKeys(row.RowIndex).Item(0))
            Me.HideInGrid(row)
            HideCheckBoxInSelectedColumn(124, row)
            HideCheckBoxInSelectedColumn(18, row)
            HideCheckBoxInSelectedColumn(135, row)
            If dt.Rows.Count > 0 Then
                Dim dr As TimeLiveDataSet.AccountPagePermissionRow = dt.Rows(0)
                For Each dr In dt.Rows


                    If dr.AccountId = DBUtilities.GetSessionAccountId And Me.ddlAccountRoleId.SelectedValue = dr.AccountRoleId And Me.GridView1.DataKeys(row.RowIndex).Item(0) = dr.SystemSecurityCategoryPageId And dr.SystemPermissionId = 1 Then
                        CType(row.FindControl("chkListView"), CheckBox).Checked = True
                        Me.ShowDataCheckBoxes("chkListViewShowAllData", "ShowAllData", row, dr)
                        Me.ShowDataCheckBoxes("chkListViewShowMyData", "ShowMyData", row, dr)
                        Me.ShowDataCheckBoxes("chkListViewShowMyProjectsData", "ShowMyProjectsData", row, dr)
                        Me.ShowDataCheckBoxes("chkListViewShowMyTeamsData", "ShowMyTeamsData", row, dr)
                        Me.ShowDataCheckBoxes("chkListViewShowMySubOrdinatesData", "ShowMySubOrdinatesData", row, dr)
                    End If

                    If dr.AccountId = DBUtilities.GetSessionAccountId And Me.ddlAccountRoleId.SelectedValue = dr.AccountRoleId And Me.GridView1.DataKeys(row.RowIndex).Item(0) = dr.SystemSecurityCategoryPageId And dr.SystemPermissionId = 2 Then
                        CType(row.FindControl("chkAdd"), CheckBox).Checked = True
                        Me.ShowDataCheckBoxes("chkAddShowAllData", "ShowAllData", row, dr)
                        Me.ShowDataCheckBoxes("chkAddShowMyData", "ShowMyData", row, dr)
                        Me.ShowDataCheckBoxes("chkAddShowMyProjectsData", "ShowMyProjectsData", row, dr)
                        Me.ShowDataCheckBoxes("chkAddShowMyTeamsData", "ShowMyTeamsData", row, dr)
                        Me.ShowDataCheckBoxes("chkAddShowMySubOrdinatesData", "ShowMySubOrdinatesData", row, dr)
                    End If

                    If dr.AccountId = DBUtilities.GetSessionAccountId And Me.ddlAccountRoleId.SelectedValue = dr.AccountRoleId And Me.GridView1.DataKeys(row.RowIndex).Item(0) = dr.SystemSecurityCategoryPageId And dr.SystemPermissionId = 3 Then
                        CType(row.FindControl("chkEdit"), CheckBox).Checked = True
                        Me.ShowDataCheckBoxes("chkEditShowAllData", "ShowAllData", row, dr)
                        Me.ShowDataCheckBoxes("chkEditShowMyData", "ShowMyData", row, dr)
                        Me.ShowDataCheckBoxes("chkEditShowMyProjectsData", "ShowMyProjectsData", row, dr)
                        Me.ShowDataCheckBoxes("chkEditShowMyTeamsData", "ShowMyTeamsData", row, dr)
                        Me.ShowDataCheckBoxes("chkEditShowMySubOrdinatesData", "ShowMySubOrdinatesData", row, dr)
                    End If

                    If dr.AccountId = DBUtilities.GetSessionAccountId And Me.ddlAccountRoleId.SelectedValue = dr.AccountRoleId And Me.GridView1.DataKeys(row.RowIndex).Item(0) = dr.SystemSecurityCategoryPageId And dr.SystemPermissionId = 4 Then
                        CType(row.FindControl("chkDelete"), CheckBox).Checked = True
                        Me.ShowDataCheckBoxes("chkDeleteShowAllData", "ShowAllData", row, dr)
                        Me.ShowDataCheckBoxes("chkDeleteShowMyData", "ShowMyData", row, dr)
                        Me.ShowDataCheckBoxes("chkDeleteShowMyProjectsData", "ShowMyProjectsData", row, dr)
                        Me.ShowDataCheckBoxes("chkDeleteShowMyTeamsData", "ShowMyTeamsData", row, dr)
                        Me.ShowDataCheckBoxes("chkDeleteShowMySubOrdinatesData", "ShowMySubOrdinatesData", row, dr)
                    End If

                Next
            End If
        Next
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'DBUtilities.SetHardcodedSessionValues()
        Me.lblSelectRole.Text = ResourceHelper.GetFromResource("Select Role:")
        Me.Label1.Text = ResourceHelper.GetFromResource("Default Page:")
    End Sub

    Protected Sub ddlAccountRoleId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.GridView1.DataBind()
    End Sub
    Public Function HideInGrid(ByVal row As GridViewRow)
        'If DBUtilities.IsNotSupportedCultureFormats = True Then
        '    DBUtilities.SetMaskEditExtenderCultureToUS(row.FindControl("MaskedEditExtender1"))
        '    DBUtilities.SetMaskEditExtenderCultureToUS(row.FindControl("MaskedEditExtender2"))
        '    DBUtilities.SetMaskEditExtenderCultureToUS(row.FindControl("MaskedEditExtender3"))
        '    DBUtilities.SetMaskEditExtenderCultureToUS(row.FindControl("MaskedEditExtender4"))
        'End If

        If Me.GridView1.DataKeys(row.RowIndex).Item(1).ToString <> "True" Then
            CType(row.FindControl("chkListView"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMySubOrdinatesData"), CheckBox).Visible = False
        End If

        If Me.GridView1.DataKeys(row.RowIndex).Item(2).ToString <> "True" Then
            CType(row.FindControl("chkAdd"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Visible = False
        End If

        If Me.GridView1.DataKeys(row.RowIndex).Item(3).ToString <> "True" Then
            CType(row.FindControl("chkEdit"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Visible = False
        End If

        If Me.GridView1.DataKeys(row.RowIndex).Item(4).ToString <> "True" Then
            CType(row.FindControl("chkDelete"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMySubOrdinatesData"), CheckBox).Visible = False
        End If

        If Me.GridView1.DataKeys(row.RowIndex).Item(6).ToString <> "True" Then
            CType(row.FindControl("chkListViewShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMySubOrdinatesData"), CheckBox).Visible = False

            CType(row.FindControl("chkAddShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Visible = False

            CType(row.FindControl("chkEditShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Visible = False

            CType(row.FindControl("chkDeleteShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMySubOrdinatesData"), CheckBox).Visible = False
        End If
    End Function
    Public Function ShowDataCheckBoxes(ByVal CheckBoxName As String, ByVal FieldName As String, ByVal row As GridViewRow, ByVal dr As TimeLiveDataSet.AccountPagePermissionRow)
        If IsDBNull(dr(FieldName)) Then
            CType(row.FindControl(CheckBoxName), CheckBox).Checked = False
        ElseIf dr(FieldName) = False Then
            CType(row.FindControl(CheckBoxName), CheckBox).Checked = False
        Else
            CType(row.FindControl(CheckBoxName), CheckBox).Checked = dr(FieldName)
        End If
    End Function
    Public Sub SetDefaultPage()
        If Not Me.IsPostBack Then
            Me.SetDataForDefaultPageDropDown(ddlDefaultAccountPageId)
        End If

        Dim BLL As New AccountRoleBLL
        Dim dt As TimeLiveDataSet.AccountRoleDataTable = BLL.GetAccountRolesByAccountIdAndAccountRoleId(DBUtilities.GetSessionAccountId, ddlAccountRoleId.SelectedValue)
        Dim dr As TimeLiveDataSet.AccountRoleRow

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("DefaultAccountPageId")) Then
                ddlDefaultAccountPageId.SelectedValue = dr.DefaultAccountPageId
            Else
                ddlDefaultAccountPageId.SelectedValue = 0
            End If
        End If
    End Sub
    Public Sub SetDataForDefaultPageDropDown(ByVal DropDownName As DropDownList)

        Dim objDataView As New DataView()
        Dim BLL As New AccountPagePermissionBLL
        Dim dt As TimeLiveDataSet.SystemSecurityCategoryPageDataTable

        dt = BLL.GetSystemSecurityCategoryPagesByIsSiteMapPageForDefaultPage(True)

        If dt.Rows.Count > 0 Then
            objDataView = dt.DefaultView
            objDataView.Sort = "SystemCategoryPageDescription"
            DropDownName.DataSource = objDataView
            DropDownName.DataBind()
        End If

    End Sub
    Public Sub HideCheckBoxInSelectedColumn(ByVal SystemSecurityCategoryPageId As Integer, ByVal row As GridViewRow)
        If Me.GridView1.DataKeys(row.RowIndex).Item(0) = SystemSecurityCategoryPageId Then
            If Not IsDBNull(Me.GridView1.DataKeys(row.RowIndex).Item(6)) Then
                If Me.GridView1.DataKeys(row.RowIndex).Item(1).ToString = "True" Then
                    Me.SetListViewDataOptionsByPageId(row, SystemSecurityCategoryPageId)
                End If
                If Me.GridView1.DataKeys(row.RowIndex).Item(2).ToString = "True" Then
                    Me.SetAddDataOptionsByPageId(row, SystemSecurityCategoryPageId)
                End If
                If Me.GridView1.DataKeys(row.RowIndex).Item(3).ToString = "True" Then
                    Me.SetEditDataOptionsByPageId(row, SystemSecurityCategoryPageId)
                End If
                If Me.GridView1.DataKeys(row.RowIndex).Item(4).ToString = "True" Then
                    Me.SetDeleteDataOptionsByPageId(row, SystemSecurityCategoryPageId)
                End If
            End If
        End If
    End Sub
    Public Sub SetListViewDataOptionsByPageId(ByVal row As GridViewRow, ByVal SystemSecurityCategoryPageId As Integer)
        If SystemSecurityCategoryPageId = 124 Then
            CType(row.FindControl("chkListViewShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkListViewShowMySubOrdinatesData"), CheckBox).Visible = False
        End If
    End Sub
    Public Sub SetAddDataOptionsByPageId(ByVal row As GridViewRow, ByVal SystemSecurityCategoryPageId As Integer)
        If SystemSecurityCategoryPageId = 124 Then
            CType(row.FindControl("chkAddShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Visible = False
        ElseIf SystemSecurityCategoryPageId = 18 Then
            CType(row.FindControl("chkAddShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Visible = False
        ElseIf SystemSecurityCategoryPageId = 135 Then
            CType(row.FindControl("chkAddShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkAddShowMySubOrdinatesData"), CheckBox).Visible = False
        End If
    End Sub
    Public Sub SetEditDataOptionsByPageId(ByVal row As GridViewRow, ByVal SystemSecurityCategoryPageId As Integer)
        If SystemSecurityCategoryPageId = 124 Then
            CType(row.FindControl("chkEditShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Visible = False
        ElseIf SystemSecurityCategoryPageId = 18 Then
            CType(row.FindControl("chkEditShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Visible = False
        ElseIf SystemSecurityCategoryPageId = 135 Then
            CType(row.FindControl("chkEditShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkEditShowMySubOrdinatesData"), CheckBox).Visible = False
        End If
    End Sub
    Public Sub SetDeleteDataOptionsByPageId(ByVal row As GridViewRow, ByVal SystemSecurityCategoryPageId As Integer)
        If SystemSecurityCategoryPageId = 124 Then
            CType(row.FindControl("chkDeleteShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMySubOrdinatesData"), CheckBox).Visible = False
        ElseIf SystemSecurityCategoryPageId = 18 Then
            CType(row.FindControl("chkDeleteShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMySubOrdinatesData"), CheckBox).Visible = False
        ElseIf SystemSecurityCategoryPageId = 135 Then
            CType(row.FindControl("chkDeleteShowAllData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyProjectsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMyTeamsData"), CheckBox).Visible = False
            CType(row.FindControl("chkDeleteShowMySubOrdinatesData"), CheckBox).Visible = False
        End If
    End Sub
End Class
