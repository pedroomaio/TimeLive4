''' <summary>
''' AccountApprovalForm web user control
''' </summary>
''' <remarks></remarks>
Partial Class AccountAdmin_Controls_ctlAccountApprovalForm
    Inherits System.Web.UI.UserControl
    Dim IsApprovalInsert As Boolean = True
    Dim IsApprovalUpdate As Boolean = True
    Dim GridView1 As GridView
    ''' <summary>
    ''' Insert account approver type records
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertAccountApproverTypeRecords()
        With dsAccountApprovalTypeObject
            .InsertParameters("ApprovalTypeName").DefaultValue = CType(Me.FormView1.FindControl("ApprovalTypeNameTextBox"), TextBox).Text
            .InsertParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
            .InsertParameters("IsTimeOffApprovalTypes").DefaultValue = CType(Me.FormView1.FindControl("chkIsTimeOff"), CheckBox).Checked
            .Insert()
        End With
        Me.Save()
    End Sub
    ''' <summary>
    ''' Calling add button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            IsApprovalInsert = True
            If CType(row.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 0 Then
                ShowNotFoundMessage()
                IsApprovalInsert = False
            ElseIf CType(row.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 3 And CType(row.FindControl("ddlAccountExternalUserId"), DropDownList).SelectedValue = 0 And CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0 Then
                ShowNotFoundMessage()
                IsApprovalInsert = False
            ElseIf CType(row.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 4 And CType(row.FindControl("ddlAccountExternalUserId"), DropDownList).SelectedValue = 0 And CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0 Then
                ShowNotFoundMessage()
                IsApprovalInsert = False
            ElseIf IsApprovalInsert = True Then
                Me.InsertAccountApproverTypeRecords()
                Response.Redirect("~/AccountAdmin/AccountApprovals.aspx", False)
                Exit Sub
            End If
        Next
    End Sub
    ''' <summary>
    ''' Calling update button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            IsApprovalUpdate = True
            If CType(row.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 0 Then
                ShowNotFoundMessage()
                IsApprovalUpdate = False
            ElseIf CType(row.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 3 And CType(row.FindControl("ddlAccountExternalUserId"), DropDownList).SelectedValue = 0 And CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0 Then
                ShowNotFoundMessage()
                IsApprovalUpdate = False
            ElseIf CType(row.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 4 And CType(row.FindControl("ddlAccountExternalUserId"), DropDownList).SelectedValue = 0 And CType(row.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0 Then
                ShowNotFoundMessage()
                IsApprovalUpdate = False
            ElseIf IsApprovalUpdate = True Then
                Me.UpdateMasterRecords()
                Response.Redirect("~/AccountAdmin/AccountApprovals.aspx", False)
                Exit Sub
            End If
        Next
    End Sub
    ''' <summary>
    ''' Calling account approval path object datasource inserting event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountApprovalPathObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs)
        If Me.FormView1.CurrentMode = FormViewMode.Insert Then
            e.InputParameters("AccountApprovalTypeId") = New AccountApprovalBLL().GetLastInsertedId
        End If
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            e.InputParameters("AccountApprovalTypeId") = Me.Request.QueryString("AccountApprovalTypeId")
        End If
    End Sub
    ''' <summary>
    ''' Update gridview row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="NewValues"></param>
    ''' <remarks></remarks>
    Public Sub UpdateRow(ByVal objRow As GridViewRow, ByVal NewValues As System.Collections.Specialized.IOrderedDictionary)
        If objRow.RowType = DataControlRowType.DataRow Then
            NewValues("SystemApproverTypeId") = Me.GetCellValue(objRow, 1, "ddlSystemApproverTypeId")
            NewValues("AccountExternalUserId") = Me.GetCellValue(objRow, 2, "ddlAccountExternalUserId")
            NewValues("AccountEmployeeId") = Me.GetCellValue(objRow, 3, "ddlAccountEmployeeId")
            NewValues("ApprovalPathSequence") = Me.GetCellValue(objRow, 4, "ddlApprovalPathSequence")
        End If
    End Sub
    ''' <summary>
    ''' Get cell value
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="nCellIndex"></param>
    ''' <param name="strObjectId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCellValue(ByVal objRow As GridViewRow, ByVal nCellIndex As Integer, ByVal strObjectId As String) As Object
        Dim UIObject As Object = objRow.Cells(nCellIndex).FindControl(strObjectId)
        If UIObject Is Nothing Then
            Return Nothing
        End If
        If TypeOf UIObject Is DropDownList Then
            Return UIObject.SelectedValue
        ElseIf TypeOf UIObject Is eWorld.UI.TimePicker Then
            Return UIObject.controls(1).text
        Else
            Return UIObject.Text()
        End If
    End Function
    ''' <summary>
    ''' Validate gridview row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <param name="NewValues"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidateRow(ByVal objRow As GridViewRow, ByVal NewValues As System.Collections.Specialized.IOrderedDictionary) As Boolean
        If NewValues("SystemApproverTypeId") = 0 Then
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' Calling gridview rowupdating event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs)
        Dim objRow As GridViewRow = GridView1.Rows(e.RowIndex)
        If objRow.RowType = DataControlRowType.DataRow Then
            Me.UpdateRow(objRow, e.NewValues)
            e.Cancel = Not Me.ValidateRow(objRow, e.NewValues)
        End If
    End Sub
    ''' <summary>
    ''' Save approval records
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
        Dim objRow As GridViewRow
        For Each objRow In Me.GridView1.Rows
            If objRow.RowType = DataControlRowType.DataRow Then
                If Me.GridView1.DataKeys(objRow.RowIndex)("AccountApprovalTypeId") = 0 Then
                    IsApprovalInsert = True
                    If CType(objRow.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 0 Then
                        ShowNotFoundMessage()
                        IsApprovalInsert = False
                    ElseIf CType(objRow.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 3 And CType(objRow.FindControl("ddlAccountExternalUserId"), DropDownList).SelectedValue = 0 And CType(objRow.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0 Then
                        ShowNotFoundMessage()
                        IsApprovalInsert = False
                    ElseIf CType(objRow.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 4 And CType(objRow.FindControl("ddlAccountExternalUserId"), DropDownList).SelectedValue = 0 And CType(objRow.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0 Then
                        ShowNotFoundMessage()
                        IsApprovalInsert = False
                    ElseIf IsApprovalInsert = True Then
                        Me.InsertRecord(objRow)
                    End If
                Else
                    If Me.IsRowChanged(objRow) Then
                        IsApprovalUpdate = True
                        If CType(objRow.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 0 Then
                            Call New AccountApprovalBLL().DeleteAccountApprovalPath(Me.GridView1.DataKeys(objRow.RowIndex)("AccountApprovalPathId"))
                            ShowNotFoundMessage()
                            IsApprovalUpdate = False
                        ElseIf CType(objRow.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 3 And CType(objRow.FindControl("ddlAccountExternalUserId"), DropDownList).SelectedValue = 0 And CType(objRow.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0 Then
                            Call New AccountApprovalBLL().DeleteAccountApprovalPath(Me.GridView1.DataKeys(objRow.RowIndex)("AccountApprovalPathId"))
                            ShowNotFoundMessage()
                            IsApprovalUpdate = False
                        ElseIf CType(objRow.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 4 And CType(objRow.FindControl("ddlAccountExternalUserId"), DropDownList).SelectedValue = 0 And CType(objRow.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0 Then
                            Call New AccountApprovalBLL().DeleteAccountApprovalPath(Me.GridView1.DataKeys(objRow.RowIndex)("AccountApprovalPathId"))
                            ShowNotFoundMessage()
                            IsApprovalUpdate = False
                        ElseIf IsApprovalUpdate = True Then
                            Me.UpdateRecord(objRow)
                        End If
                    End If
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Insert record by gridview row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub InsertRecord(ByVal objRow As GridViewRow)
        With Me.dsAccountApprovalPathObject
            If Me.GetCellValue(objRow, 1, "ddlSystemApproverTypeId") <> 0 Then
                .InsertParameters("AccountApprovalTypeId").DefaultValue = Me.GridView1.DataKeys(objRow.RowIndex)("AccountApprovalTypeId")
                .InsertParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
                .InsertParameters("SystemApproverTypeId").DefaultValue = Me.GetCellValue(objRow, 1, "ddlSystemApproverTypeId")
                .InsertParameters("AccountExternalUserId").DefaultValue = Me.GetCellValue(objRow, 2, "ddlAccountExternalUserId")
                .InsertParameters("AccountEmployeeId").DefaultValue = Me.GetCellValue(objRow, 3, "ddlAccountEmployeeId")
                .InsertParameters("ApprovalPathSequence").DefaultValue = Me.GetCellValue(objRow, 4, "ddlApprovalPathSequence")
                .Insert()
            End If
        End With
    End Sub
    ''' <summary>
    ''' Update record by gridview row
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <remarks></remarks>
    Public Sub UpdateRecord(ByVal objRow As GridViewRow)
        With Me.dsAccountApprovalPathObject
            If Me.GetCellValue(objRow, 1, "ddlSystemApproverTypeId") <> 0 Then
                .UpdateParameters("AccountApprovalTypeId").DefaultValue = Me.GridView1.DataKeys(objRow.RowIndex)("AccountApprovalTypeId")
                .UpdateParameters("Original_AccountApprovalPathId").DefaultValue = Me.GridView1.DataKeys(objRow.RowIndex)("AccountApprovalPathId")
                .UpdateParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
                .UpdateParameters("SystemApproverTypeId").DefaultValue = Me.GetCellValue(objRow, 1, "ddlSystemApproverTypeId")
                .UpdateParameters("AccountExternalUserId").DefaultValue = Me.GetCellValue(objRow, 2, "ddlAccountExternalUserId")
                .UpdateParameters("AccountEmployeeId").DefaultValue = Me.GetCellValue(objRow, 3, "ddlAccountEmployeeId")
                .UpdateParameters("ApprovalPathSequence").DefaultValue = Me.GetCellValue(objRow, 4, "ddlApprovalPathSequence")
                .Update()
            End If
        End With
    End Sub
    ''' <summary>
    ''' Validate row by calling isrowchanged event
    ''' </summary>
    ''' <param name="objRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsRowChanged(ByVal objRow As GridViewRow) As Boolean
        If objRow.RowType = DataControlRowType.DataRow Then
            If Me.GridView1.DataKeys(objRow.RowIndex)("SystemApproverTypeId") <> Me.GetCellValue(objRow, 1, "ddlSystemApproverTypeId") Then
                Return True
            End If
            If LocaleUtilitiesBLL.GetString0IfNull(Me.GridView1.DataKeys(objRow.RowIndex)("AccountExternalUserId")) <> Me.GetCellValue(objRow, 2, "ddlAccountExternalUserId") Then
                Return True
            End If
            If LocaleUtilitiesBLL.GetString0IfNull(Me.GridView1.DataKeys(objRow.RowIndex)("AccountEmployeeId")) <> Me.GetCellValue(objRow, 3, "ddlAccountEmployeeId") Then
                Return True
            End If
            If Me.GridView1.DataKeys(objRow.RowIndex)("ApprovalPathSequence") <> Me.GetCellValue(objRow, 4, "ddlApprovalPathSequence") Then
                Return True
            End If
        End If
        Return False
    End Function
    ''' <summary>
    ''' Calling page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridView1 = Me.FormView1.FindControl("GridView1")
        If Not Me.IsPostBack Then
            If Not Me.Request.QueryString("AccountApprovalTypeId") Is Nothing Then
                Me.FormView1.ChangeMode(FormViewMode.Edit)
                Me.dsAccountApprovalTypeObject.SelectParameters("AccountApprovalTypeId").DefaultValue = Me.Request.QueryString("AccountApprovalTypeId")
                Me.dsAccountApprovalPathObject.SelectParameters("AccountApprovalTypeId").DefaultValue = Me.Request.QueryString("AccountApprovalTypeId")
            Else
                Me.PopulateBlankDetail()
            End If
        End If
        Me.PopulateAccountExternalUserDropDown()
    End Sub
    ''' <summary>
    ''' update master records
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateMasterRecords()
        With dsAccountApprovalTypeObject
            .UpdateParameters("Original_AccountApprovalTypeId").DefaultValue = Me.Request.QueryString("AccountApprovalTypeId")
            .UpdateParameters("ApprovalTypeName").DefaultValue = CType(Me.FormView1.FindControl("ApprovalTypeNameTextBox"), TextBox).Text
            .UpdateParameters("AccountId").DefaultValue = DBUtilities.GetSessionAccountId
            .UpdateParameters("IsTimeOffApprovalTypes").DefaultValue = CType(Me.FormView1.FindControl("chkIsTimeOff"), CheckBox).Checked
            .Update()
        End With
        Me.Save()
    End Sub
    ''' <summary>
    ''' Populate blank detail rows in gridview
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PopulateBlankDetail()
        Dim Grid As GridView = Me.FormView1.FindControl("GridView1")
        Grid.DataSourceID = ""
        Grid.DataSource = New AccountApprovalBLL().GetBlankDetail()
        Grid.DataBind()
    End Sub
    ''' <summary>
    ''' Calling account approval type object datasource inserting event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub dsAccountApprovalTypeObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs)
    End Sub
    ''' <summary>
    ''' Populate account external user dropdown on system approver type dropdown selectindexchanged event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddlSystemApproverTypeId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.PopulateAccountExternalUserDropDown()
    End Sub
    ''' <summary>
    ''' Populate account external user dropdown
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PopulateAccountExternalUserDropDown()
        Dim objRow As GridViewRow
        For Each objRow In Me.GridView1.Rows
            PopulateAccountExternalUserDropDownOfRow(objRow)
        Next
    End Sub
    ''' <summary>
    ''' Populate account external user dropdown by gridview row
    ''' </summary>
    ''' <param name="objrow"></param>
    ''' <remarks></remarks>
    Public Sub PopulateAccountExternalUserDropDownOfRow(ByVal objrow As GridViewRow)
        If objrow.RowType = DataControlRowType.DataRow Then
            If CType(objrow.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 4 Then
                CType(objrow.FindControl("ddlAccountExternalUserId"), DropDownList).Enabled = True
            Else
                CType(objrow.FindControl("ddlAccountExternalUserId"), DropDownList).Enabled = False
                CType(objrow.FindControl("ddlAccountExternalUserId"), DropDownList).SelectedValue = 0
            End If
            If CType(objrow.FindControl("ddlSystemApproverTypeId"), DropDownList).SelectedValue = 3 Then
                CType(objrow.FindControl("ddlAccountEmployeeId"), DropDownList).Enabled = True
            Else
                CType(objrow.FindControl("ddlAccountEmployeeId"), DropDownList).Enabled = False
                CType(objrow.FindControl("ddlAccountEmployeeId"), DropDownList).SelectedValue = 0
            End If
            If Not objrow.DataItem Is Nothing Then
                CType(objrow.FindControl("ddlApprovalPathSequence"), DropDownList).SelectedValue = LocaleUtilitiesBLL.GetString0IfNull(objrow.DataItem("ApprovalPathSequence"))
            End If
        End If
    End Sub
    ''' <summary>
    ''' Calling gridview rowdatabound event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        Me.PopulateAccountExternalUserDropDownOfRow(e.Row)
        If Me.FormView1.CurrentMode = FormViewMode.Edit Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim dataValue As Object
                Dim objDropdown As DropDownList
                Dim objdatasource As ObjectDataSource
                objDropdown = CType(e.Row.Cells(1).FindControl("ddlAccountExternalUserId"), DropDownList)
                If Not objDropdown Is Nothing Then
                    dataValue = DataBinder.Eval(e.Row.DataItem, "AccountExternalUserId")
                    If IsDBNull(dataValue) Then
                        objDropdown.SelectedValue = 0
                    Else
                        objDropdown.SelectedValue = dataValue
                    End If
                End If
                objDropdown = CType(e.Row.Cells(2).FindControl("ddlAccountEmployeeId"), DropDownList)
                objdatasource = CType(e.Row.Cells(2).FindControl("dsAccountEmployeeObject"), ObjectDataSource)
                ShowDataForddlAccountEmployeeId(e)
                If Not objDropdown Is Nothing Then
                    dataValue = DataBinder.Eval(e.Row.DataItem, "AccountEmployeeId")
                    If IsDBNull(dataValue) Then
                        objDropdown.SelectedValue = 0
                    Else
                        objDropdown.SelectedValue = dataValue
                        objdatasource.SelectParameters("AccountEmployeeId").DefaultValue = dataValue
                    End If
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' Show data for account employee dropdownlist
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub ShowDataForddlAccountEmployeeId(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        CType(e.Row.Cells(2).FindControl("ddlAccountEmployeeId"), DropDownList).Items.Clear()
        Dim item As New System.Web.UI.WebControls.ListItem
        item.Text = "Select"
        item.Value = "0"
        CType(e.Row.Cells(2).FindControl("ddlAccountEmployeeId"), DropDownList).Items.Add(item)
        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AccountEmployeeId")) Then
            CType(e.Row.Cells(2).FindControl("dsAccountEmployeeObject"), ObjectDataSource).SelectParameters("AccountEmployeeId").DefaultValue = DataBinder.Eval(e.Row.DataItem, "AccountEmployeeId")
        End If
        CType(e.Row.Cells(2).FindControl("ddlAccountEmployeeId"), DropDownList).DataBind()
    End Sub
    ''' <summary>
    ''' Deleting approval path records by calling delete button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If CType(row.FindControl("chkDelete"), CheckBox).Checked = True Then
                Call New AccountApprovalBLL().DeleteAccountApprovalPath(Me.GridView1.DataKeys(row.RowIndex)("AccountApprovalPathId"))
            End If
        Next
        Me.GridView1.DataBind()
    End Sub
    ''' <summary>
    ''' Check all gridview rows by calling checkall hyperlink click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub CheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            CType(row.Cells(0).FindControl("chkDelete"), CheckBox).Checked = True
        Next
    End Sub
    ''' <summary>
    ''' Uncheck all gridview rows by calling uncheckall hyperlink click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub UnCheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            CType(row.Cells(0).FindControl("chkDelete"), CheckBox).Checked = False
        Next
    End Sub
    ''' <summary>
    ''' Show javascript alert message
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowNotFoundMessage()
        Dim strMessage As String = Resources.TimeLive.Resource.Please_select_employee_
        Dim strScript As String = "alert('" & strMessage & "'); "
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
End Class
