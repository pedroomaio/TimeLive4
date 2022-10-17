Imports System
Imports System.Collections
Imports AjaxControlToolkit
Imports System.Web.Services
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports AccountModuleTableAdapters
Imports AccountEmployeeTableAdapters
Partial Class Employee_Controls_ctlMyTasks
    Inherits System.Web.UI.UserControl
    Public ListBoxValues As New ArrayList
    Public SelectedListBoxValues As New Hashtable
    Dim SystemModuleId As Guid = New Guid("25fd0146-f5da-4c6c-8915-abbab9852108")
    Public Event btnShowClick(ByVal sender As Object, ByVal e As System.EventArgs)
    'Dim GV1 As New GridView
    Dim dAssignedToEmployeeId As New DropDownList
    Dim Cascading As New CascadingDropDown
    Public Event btnAddTaskClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim FilterBLL As New AccountFilterModuleBLL
    Dim IsPageLoad As Integer = 1
    Dim CurrentSelectedModuleViewId As Guid
    Dim CurrentSelectedModuleViewName As String
    Dim ModuleViewbll As New AccountModuleBLL
    Public Sub FilterGridViewTask()
        If IsPageLoad = 0 Then
            FilterBLL.InsertFilterModuleForNonGridViewObject(Me, Me.Page)
        Else
            SetFilterControlsReset()
            FilterBLL.InsertFilterDefaultValues(Me, Me.Page)
            FilterBLL.GetFilterModuleForNonGridViewObject(Me, Me.Page)
        End If
        SetFilterControls()
    End Sub
    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Handles btnShow.Click
        IsPageLoad = 0
        Me.FilterGridViewTask()
        'Response.Redirect(Request.RawUrl, False)
        RaiseEvent btnShowClick(sender, e)
    End Sub
    Public Sub ShowNotFoundMessage(ByVal strMessage As String)
        Dim strScript As String
        If strMessage = "Please Select a Task" Then
            strScript = "alert('" & strMessage & "');"
        Else
            strScript = "alert('" & strMessage & "'); window.location = 'MyTasks.aspx';"
        End If
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
    Protected Sub AccountProjectTaskHierarchyObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles AccountProjectTaskHierarchyObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub
    Public Sub GetLiteralText()
        'Me.Literal3.Text = ResourceHelper.GetFromResource("Task Id:")
        Me.Literal4.Text = ResourceHelper.GetFromResource("Task Type:")
        Me.Literal5.Text = ResourceHelper.GetFromResource("Project:")
        Me.Literal6.Text = ResourceHelper.GetFromResource("Milestone:")
        'Me.Literal7.Text = ResourceHelper.GetFromResource("Report By:")
        'Me.Literal8.Text = ResourceHelper.GetFromResource("Assigned To:")
        Me.Literal9.Text = ResourceHelper.GetFromResource("Completed Status:")
        Me.Literal10.Text = ResourceHelper.GetFromResource("Task Status:")
        Me.Literal11.Text = ResourceHelper.GetFromResource("Include Date Range:")
        Me.Literal12.Text = ResourceHelper.GetFromResource("Start Date From:")
        Me.Literal13.Text = ResourceHelper.GetFromResource("Start Date Upto:")
        Me.Literal14.Text = ResourceHelper.GetFromResource("Description:")
        'Me.BoundField.HeaderText = ResourceHelper.GetFromResource("Task Code")

        Dim TaskStatus As New Literal
        TaskStatus = CType(Me.Accordion1.FindControl("Task Status"), Literal)
        Me.Literal18.Text = ResourceHelper.GetFromResource("Task Status:")
        Dim TaskType As New Literal
        TaskType = CType(Me.Accordion1.FindControl("Task Type"), Literal)
        Me.Literal22.Text = ResourceHelper.GetFromResource("Task Type:")
        Dim Completed As New Literal
        Completed = CType(Me.Accordion1.FindControl("Completed%"), Literal)
        Me.Label15.Text = ResourceHelper.GetFromResource("Completed%:")
        'Dim MassUpdate As New Literal
        'Me.Literal15.Text = ResourceHelper.GetFromResource("Search")
        Dim MassUpdate As New Literal
        Me.Label50.Text = ResourceHelper.GetFromResource("Mass Update")
        Dim TaskParameters As New Literal
        Me.Literal1.Text = ResourceHelper.GetFromResource("Task Parameters")
        Dim TaskName As New Literal
        TaskName = CType(Me.Accordion1.FindControl("TaskName"), Literal)
        Me.Label15.Text = ResourceHelper.GetFromResource("Task Name:")
        Me.Label2.Text = ResourceHelper.GetFromResource("All Fields")
        Me.Label4.Text = ResourceHelper.GetFromResource("Fields to Display")
    End Sub
    Public Sub ShowMyOpenTasks()
        Me.ViewState.Add("AssignedToEmployeeId", DBUtilities.GetSessionAccountEmployeeId)
        'AccountEmployeeBLL.SetDataForEmployeeDropdown(28, Me.ddlAssignedToEmployeeId)
        AccountProjectBLL.SetDataForProjectDropdown(28, Me.ddlAccountProjectId)
        'Me.ddlAssignedToEmployeeId.SelectedValue = DBUtilities.GetSessionAccountEmployeeId
        Me.ddlCompletedStatus.SelectedValue = -1
        Me.RefreshData()
    End Sub
    Public Function GetIdFromDropdown(ByVal objDropdown As DropDownList) As String
        Dim strObject As String = ""
        If objDropdown.SelectedValue = 0 Then
            For Each objListItem As ListItem In objDropdown.Items
                'If objListItem.Value > 0 Then
                strObject = strObject & IIf(strObject = "", "", ",") & objListItem.Value
                ' End If
            Next
        Else
            strObject = objDropdown.SelectedValue
        End If
        Return strObject
    End Function
    Public Sub RefreshData()
        FilterGridViewTask()
    End Sub
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        AccountPagePermissionBLL.SetPagePermissionForGridView(28, Me.GridView1, Nothing, Nothing)
        Me.btnAddTask.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(28, 2)

        'TODO: CheckAll function
        'Each time the data is bound to the grid we need to build up the CheckBoxIDs array

        'Get the header CheckBox
        Dim row As GridViewRow
        For Each row In Me.GridView1.Rows
            If Me.GridView1.DataKeys(row.RowIndex).Item(0) <> 0 Then
                'Me.btnUpdateSelectedItem.Visible = True
                Dim cbHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("chkCheckAll"), CheckBox)

                'Run the ChangeCheckBoxState client-side function whenever the
                'header checkbox is checked/unchecked

                cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"
                'If cbHeader.Checked = True Then
                '    System.Web.HttpContext.Current.Session.Add("TaskCheck", 1)
                'End If
                For Each gvr As GridViewRow In GridView1.Rows
                    'Get a programmatic reference to the CheckBox control
                    Dim cb As CheckBox = CType(gvr.FindControl("chkselect"), CheckBox)
                    'cb.Checked = True

                    'Add the CheckBox's ID to the client-side CheckBoxIDs array
                    ScriptManager.RegisterArrayDeclaration(Me, "CheckBoxIDs", String.Concat("'", cb.ClientID, "'"))
                Next
            End If
        Next
        Dim ChkcbHeader As Integer
        Dim ChkItems As ArrayList = DirectCast(Session("chk"), ArrayList)
        If ChkItems IsNot Nothing AndAlso ChkItems.Count > 0 Then
            ChkcbHeader = 0
            For Each gvrow As GridViewRow In GridView1.Rows
                Dim SelectedItemID As Integer = CInt(GridView1.DataKeys(gvrow.RowIndex).Value)
                If ChkItems.Contains(SelectedItemID) Then
                    Dim chkSelect As CheckBox = DirectCast(gvrow.FindControl("chkSelect"), CheckBox)
                    chkSelect.Checked = True
                    If ChkcbHeader = 9 Then
                        Dim cbHeader As CheckBox = CType(GridView1.HeaderRow.FindControl("chkCheckAll"), CheckBox)
                        cbHeader.Checked = True
                    End If
                    ChkcbHeader = ChkcbHeader + 1
                End If
            Next
        End If

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Me.Request.QueryString("IsTaskAdd") = 1 Then
                If DataBinder.Eval(e.Row.DataItem, "AccountProjectTaskId") = New AccountProjectTaskBLL().GetLastInsertedId Then
                    Dim integ As Integer
                    Dim fract As Decimal
                    Dim i As Integer = 1
                    For i = 1 To Me.GridView1.Columns.Count - 1
                        e.Row.BackColor = Color.SteelBlue
                        e.Row.Cells(i).ForeColor = Color.White

                        Dim HLTaskName As HyperLink = e.Row.FindControl("HLTaskName")
                        If Not HLTaskName Is Nothing Then
                            HLTaskName.ForeColor = Color.White
                        End If
                        Dim HLMilestone As HyperLink = e.Row.FindControl("HLMilestone")
                        If Not HLMilestone Is Nothing Then
                            HLMilestone.ForeColor = Color.White
                        End If
                    Next
                End If
            End If
        End If
        Dim ChkItems As ArrayList = DirectCast(Session("chk"), ArrayList)
        If ChkItems IsNot Nothing AndAlso ChkItems.Count > 0 Then
            For Each gvrow As GridViewRow In GridView1.Rows
                Dim SelectedItemID As Integer = CInt(GridView1.DataKeys(gvrow.RowIndex).Value)
                If ChkItems.Contains(SelectedItemID) Then
                    Dim chkSelect As CheckBox = DirectCast(gvrow.FindControl("chkSelect"), CheckBox)
                    chkSelect.Checked = True
                End If
            Next
        End If
    End Sub
    Protected Sub btnAddTask_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Panel2.Visible = False
        Me.HeaderSpan.Visible = False
        Me.Accordion1.Visible = False
        Me.GridView1.Visible = False
        Me.btnAddTask.Visible = False
        RaiseEvent btnAddTaskClick(sender, e)
    End Sub
    Dim ArrayTask As ArrayList
    Protected Sub btnUpdateSelectedItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ArrayTask = Session("chk")
        Dim row As GridViewRow
        Dim Original_AccountProjectTaskId As Integer
        Dim BLL As New AccountProjectTaskBLL

        For Each row In Me.GridView1.Rows
            If CType(row.FindControl("chkSelect"), CheckBox).Checked = True Then
                Original_AccountProjectTaskId = Me.GridView1.DataKeys(row.RowIndex)(0)

                If Not ArrayTask Is Nothing Then
                    ArrayTask.Add(Original_AccountProjectTaskId)
                Else
                    Original_AccountProjectTaskId = BLL.UpdateAccountProjectTaskMassUpdate(txtDuration.Text, txtCompletePercentage.Text, ddlTaskStatus.SelectedValue, ddlPriority.SelectedValue, ddlTaskType.SelectedValue, txtTaskName.Text, Original_AccountProjectTaskId)
                    Me.ShowNotFoundMessage(ResourceHelper.GetFromResource("Successfully Updated"))
                End If
            End If
        Next
        If Not ArrayTask Is Nothing Then
            For Each Array In ArrayTask
                Original_AccountProjectTaskId = BLL.UpdateAccountProjectTaskMassUpdate(txtDuration.Text, txtCompletePercentage.Text, ddlTaskStatus.SelectedValue, ddlPriority.SelectedValue, ddlTaskType.SelectedValue, txtTaskName.Text, Array)
                Me.ShowNotFoundMessage(ResourceHelper.GetFromResource("Successfully Updated"))
            Next
        End If
        If ArrayTask Is Nothing Then
            Me.ShowNotFoundMessage(ResourceHelper.GetFromResource("Please Select a Task"))
            Exit Sub
        End If
        Me.GridView1.DataBind()
        Session.Remove("chk")
    End Sub
    Public CheckBoxArray As New ArrayList
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        SelectedListBox.DataBind()
        For i As Integer = SelectedListBox.Items.Count - 1 To 0 Step -1
            SelectedListBoxValues.Add(SelectedListBox.Items(i).Value, i)
        Next
        For Each key As String In SelectedListBoxValues.Keys
            If key = "31017d12-801d-42dd-92dc-84fc9d8048cb" Then
                SelectedListBox.Items(SelectedListBoxValues(key)).Attributes.Add("disabled", "disabled")
                'SelectedListBox.Items(SelectedListBoxValues(key)).
            End If
        Next
        ''This method is used to populate the saved checkbox values
        Dim ChkItems As New ArrayList()
        Dim SelectedItemID As Integer = -1
        For Each gvrow As GridViewRow In GridView1.Rows
            SelectedItemID = CInt(GridView1.DataKeys(gvrow.RowIndex).Value)
            Dim chkSelect As Boolean = DirectCast(gvrow.FindControl("chkSelect"), CheckBox).Checked
            ' Check in the Session
            If Session("chk") IsNot Nothing Then
                ChkItems = DirectCast(Session("chk"), ArrayList)
                CheckBoxArray.Add(ChkItems)
            End If
            If chkSelect Then
                If Not ChkItems.Contains(SelectedItemID) Then
                    ChkItems.Add(SelectedItemID)
                End If
            Else
                ChkItems.Remove(SelectedItemID)
            End If
        Next
        ''This method is used to save the checkedstate of values
        If ChkItems IsNot Nothing AndAlso ChkItems.Count > 0 Then
            Session("chk") = ChkItems
            ArrayTask = Session("chk")
        End If
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
    Public Sub CascadingResetValues()
        Me.AccountProjectTaskHierarchyObject.SelectParameters("AccountProjectMilestoneId").DefaultValue = Me.ddlAccountProjectMilestoneId.SelectedValue
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FindControl("CascadingDropDown1"), AjaxControlToolkit.CascadingDropDown)
        Dim dsObject As ObjectDataSource
        dsObject = Me.dsAccountProjectMilestone
        Dim AccountProjectId As Integer
        AccountProjectId = ddlAccountProjectId.SelectedValue
        MyCascading.Category = 0 & "," & AccountProjectId
    End Sub
    Public Sub SetFilterControls()

        Me.AccountProjectTaskHierarchyObject.SelectParameters("AccountProjects").DefaultValue = Me.GetIdFromDropdown(Me.ddlAccountProjectId)

        If IsPageLoad = 0 Then
            Me.AccountProjectTaskHierarchyObject.SelectParameters("AccountProjectMilestoneId").DefaultValue = Me.ddlAccountProjectMilestoneId.SelectedValue
        Else
            Me.AccountProjectTaskHierarchyObject.SelectParameters("AccountProjectMilestoneId").DefaultValue = System.Web.HttpContext.Current.Session("MilestoneID")
            Dim MyCascading As AjaxControlToolkit.CascadingDropDown
            MyCascading = CType(Me.FindControl("CascadingDropDown1"), AjaxControlToolkit.CascadingDropDown)
            Dim dsObject As ObjectDataSource
            dsObject = Me.dsAccountProjectMilestone
            Dim AccountProjectId As Integer
            AccountProjectId = ddlAccountProjectId.SelectedValue
            Dim m_MilestoneId As Object = System.Web.HttpContext.Current.Session("MilestoneID")
            MyCascading.Category = m_MilestoneId & "," & AccountProjectId
            System.Web.HttpContext.Current.Session.Remove("MilestoneID")
        End If
        Me.AccountProjectTaskHierarchyObject.SelectParameters("AccountTaskTypeId").DefaultValue = Me.ddlAccountTaskType.SelectedValue

        If Not Me.ViewState("AssignedToEmployeeId") Is Nothing Then
            Me.AccountProjectTaskHierarchyObject.SelectParameters("AssignedTo").DefaultValue = Me.ViewState("AssignedToEmployeeId")
            Me.ViewState.Remove("AssignedToEmployeeId")
        Else
            Me.AccountProjectTaskHierarchyObject.SelectParameters("AssignedTo").DefaultValue = DBUtilities.GetSessionAccountEmployeeId
        End If
        Me.AccountProjectTaskHierarchyObject.SelectParameters("TaskStatusId").DefaultValue = Me.ddlAccountStatusId.SelectedValue
        Me.AccountProjectTaskHierarchyObject.SelectParameters("CompletedStatus").DefaultValue = Me.ddlCompletedStatus.SelectedValue
        Dim i As Integer

        If Me.chkIncludeDateRange.Checked = True Then
            i = 1
        Else
            i = 0
        End If
        Me.AccountProjectTaskHierarchyObject.SelectParameters("IncludeDateRange").DefaultValue = i

        If Not Me.CreatedDateFrom.PostedDate Is Nothing Then
            Me.CreatedDateFrom.SelectedDate = Convert.ToDateTime(Me.CreatedDateFrom.PostedDate)
        End If
        If Not Me.CreatedDateFrom.PostedDate Is Nothing Then
            Me.CreatedDateUpt.SelectedDate = Convert.ToDateTime(Me.CreatedDateUpt.PostedDate)
        End If
        Me.AccountProjectTaskHierarchyObject.SelectParameters("CreatedDateFrom").DefaultValue = Me.CreatedDateFrom.SelectedDate
        Me.AccountProjectTaskHierarchyObject.SelectParameters("CreatedDateUpto").DefaultValue = Me.CreatedDateUpt.SelectedDate
        Me.AccountProjectTaskHierarchyObject.SelectParameters("AccountProjectTaskId").DefaultValue = Nothing
        Me.AccountProjectTaskHierarchyObject.SelectParameters("Description").DefaultValue = Me.txtTaskDescription.Text
        If Me.Request.QueryString("IsTaskAdd") = 1 Then
            Me.AccountProjectTaskHierarchyObject.SelectParameters("IsTaskAdd").DefaultValue = True
        End If
        Me.GridView1.DataBind()
    End Sub
    Public Sub SetFilterControlsReset()
        Me.AccountProjectTaskHierarchyObject.SelectParameters("AccountProjects").DefaultValue = Me.GetIdFromDropdown(Me.ddlAccountProjectId)
        Me.AccountProjectTaskHierarchyObject.SelectParameters("AccountProjectMilestoneId").DefaultValue = Me.ddlAccountProjectMilestoneId.SelectedValue

        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(Me.FindControl("CascadingDropDown1"), AjaxControlToolkit.CascadingDropDown)
        Dim dsObject As ObjectDataSource
        dsObject = Me.dsAccountProjectMilestone
        Dim AccountProjectId As Integer
        AccountProjectId = ddlAccountProjectId.SelectedValue
        MyCascading.Category = 0 & "," & AccountProjectId

        If Not Me.ViewState("AssignedToEmployeeId") Is Nothing Then
            Me.AccountProjectTaskHierarchyObject.SelectParameters("AssignedTo").DefaultValue = Me.ViewState("AssignedToEmployeeId")
            Me.ViewState.Remove("AssignedToEmployeeId")
        Else
            Me.AccountProjectTaskHierarchyObject.SelectParameters("AssignedTo").DefaultValue = DBUtilities.GetSessionAccountEmployeeId

        End If
        Me.AccountProjectTaskHierarchyObject.SelectParameters("TaskStatusId").DefaultValue = Me.ddlAccountStatusId.SelectedValue
        Me.AccountProjectTaskHierarchyObject.SelectParameters("CompletedStatus").DefaultValue = Me.ddlCompletedStatus.SelectedValue
        Dim i As Integer
        If Me.chkIncludeDateRange.Checked = True Then
            i = 1
        Else
            i = 0
        End If
        Me.AccountProjectTaskHierarchyObject.SelectParameters("IncludeDateRange").DefaultValue = i
        Me.CreatedDateFrom.PostedDate = Now.Date
        Me.CreatedDateUpt.PostedDate = Now.Date
        Me.AccountProjectTaskHierarchyObject.SelectParameters("AccountProjectTaskId").DefaultValue = Nothing
        Me.AccountProjectTaskHierarchyObject.SelectParameters("Description").DefaultValue = Me.txtTaskDescription.Text
        If Me.Request.QueryString("IsTaskAdd") = 1 Then
            Me.AccountProjectTaskHierarchyObject.SelectParameters("IsTaskAdd").DefaultValue = True
        End If
        Me.GridView1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.ShowMyOpenTasks()
            Session.Remove("chk")
            If Me.Request.QueryString("IsTaskAdd") = 1 Then
                Me.GridView1.DataBind()
                GridView1.PageIndex = GridView1.PageCount
            End If
        End If
        If System.Web.HttpContext.Current.Session("CascadingReset") = 1 Then
            CascadingResetValues()
            'SetFilterControlsReset()
            System.Web.HttpContext.Current.Session.Remove("CascadingReset")
        End If
        GetLiteralText()
        If DBUtilities.IsValidateLockAccount Then
            btnAddTask.Enabled = False
        Else
            btnAddTask.Enabled = True
        End If
        Dim dTaskStatus As New DropDownList
        dTaskStatus = CType(Me.Accordion1.FindControl("ddlTaskStatus"), DropDownList)
        Dim dPriority As New DropDownList
        dPriority = CType(Me.Accordion1.FindControl("ddlPriority"), DropDownList)
        Dim dTaskType As New DropDownList
        dTaskType = CType(Me.Accordion1.FindControl("ddlTaskType"), DropDownList)
        Dim ResetFilter As Integer = System.Web.HttpContext.Current.Session("ResetFilter")

        If System.Web.HttpContext.Current.Session("ddlSelectedIndexChanged") = "0" Then
            System.Web.HttpContext.Current.Session.Remove("ddlSelectedIndexChanged")
            LoadModelPopUpForAddNewView()

        ElseIf System.Web.HttpContext.Current.Session("btnReset_Click") = "Reset" Then
            System.Web.HttpContext.Current.Session.Remove("btnReset_Click")
            LoadModelPopUpAfterResetView()
        Else

            If Not Me.IsPostBack Then
                ModalPopupExtender2.Hide()
                ddlAccountModuleView.Items.Insert(0, New ListItem("Add View", "0"))
                'If SelectedListBox.SelectedValue = "31017d12-801d-42dd-92dc-84fc9d8048cb" Then
                '    ddlAccountModuleView.Attributes.Add("disabled", "true")
                'End If
                SetDDLSelectedValue()
                ddlAccountModuleView.DataBind()
            End If
            'End If
            If Not ddlAccountModuleView.SelectedValue = "0" Then
                loadDynamicGridWithTemplateColumn()
                CurrentSelectedModuleViewId = New Guid(Me.ddlAccountModuleView.SelectedValue)
                CurrentSelectedModuleViewName = Me.ddlAccountModuleView.SelectedItem.Text
                LoadDynamicGridWithCustomeViews()
            End If
            If Not Me.IsPostBack Then
                If Me.Request.QueryString("IsTaskAdd") = 1 Then
                    Me.GridView1.DataBind()
                    GridView1.PageIndex = GridView1.PageCount
                End If
            End If
        End If
    End Sub
    Public Sub LoadDynamicGridWithCustomeViews()
        If Not Me.IsPostBack Then
         
            AvailableListBox.DataBind()
            SelectedListBox.DataBind()
            txtAddView.Text = ddlAccountModuleView.SelectedItem.Text
        End If
        ResetViewFields()
        btnAddView.Visible = False
        btnOkay.Visible = True
        btnReset.Visible = True
        For i As Integer = SelectedListBox.Items.Count - 1 To 0 Step -1
            ListBoxValues.Add(SelectedListBox.Items(i).Value)
        Next
        If Not Me.IsPostBack Then
            If System.Web.HttpContext.Current.Session("ShowMessageError") = "1" Then
                Dim Message As String = System.Web.HttpContext.Current.Session("ShowMessage")
                System.Web.HttpContext.Current.Session.Remove("ShowMessageError")
                System.Web.HttpContext.Current.Session.Remove("ShowMessage")
                UIUtilities.ShowMessage(Message + " is already added", Me.Page)
            End If
            'If System.Web.HttpContext.Current.Session("RequiredField") = "1" Then
            '    Dim Message As String = System.Web.HttpContext.Current.Session("RequiredFieldMessage")
            '    System.Web.HttpContext.Current.Session.Remove("RequiredField")
            '    System.Web.HttpContext.Current.Session.Remove("RequiredFieldMessage")
            '    UIUtilities.ShowMessage(Message, Me.Page)
            'End If
          
        End If
    End Sub
    Protected Sub btnOkay_Click(sender As Object, e As System.EventArgs)
        ListBoxValuesForEdit()
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub btnAddView_Click(sender As Object, e As System.EventArgs) Handles btnAddView.Click
        InsertNewView()
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ImgBtnEdit_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnEdit.Click
        ModalPopupExtender2.CancelControlID = ""
        ResetViewFields()
        txtAddView.Text = ddlAccountModuleView.SelectedItem.Text
        btnAddView.Visible = False
        btnOkay.Visible = True
        btnReset.Visible = True
        ModalPopupExtender2.Show()
    End Sub
    Public Sub ResetViewFields()

        Dim dt As AccountModule.AccountModuleViewDataTable = New AccountModuleBLL().GetAccountModuleViewByIsSelected(SystemModuleId, True)
        Dim dr As AccountModule.AccountModuleViewRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Me.ddlAccountModuleView.SelectedValue = dr.AccountModuleViewId.ToString
            AvailableListBox.DataSourceID = "ObjvueSystemModuleFields"
            AvailableListBox.DataTextField = "SystemModuleFieldDisplayName"
            AvailableListBox.DataValueField = "SystemModuleFieldId"

            SelectedListBox.DataSourceID = "ObjvueAccountModuleFields"
            SelectedListBox.DataTextField = "SystemModuleFieldDisplayName"
            SelectedListBox.DataValueField = "SystemModuleFieldId"
        End If
    End Sub
    Public Sub ListBoxValuesForEdit()
        Dim AccountModuleViewId As New Guid(ddlAccountModuleView.SelectedValue)

        ''delete listbox item from database by selecting systemid
        For i As Integer = AvailableListBox.Items.Count - 1 To 0 Step -1
            Dim SystemModuleFieldId As New Guid(AvailableListBox.Items(i).Value)
            Dim dt As AccountModule.AccountModuleFieldsDataTable
            dt = ModuleViewbll.GetAccountModuleFieldsBySystemModuleFieldId(SystemModuleFieldId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
            If dt.Rows.Count > 0 And Not ListBoxValues.Contains(SystemModuleFieldId.ToString) Then
                ModuleViewbll.DeleteAccountModuleFields(SystemModuleFieldId, AccountModuleViewId)
            End If
        Next
        ' ''id TaskName ="31017d12-801d-42dd-92dc-84fc9d8048cb"
        ' ''TaskID="9d0fbf67-879a-4347-b994-9740ed97717f"
        'Dim SystemModuleFieldIdRequired As Guid = New Guid("31017d12-801d-42dd-92dc-84fc9d8048cb")
        Dim SystemModuleFieldName As String = ""

        Dim SortOrder As Integer = 0

        For i As Integer = SelectedListBox.Items.Count - 1 To 0 Step -1
            ''If (SelectedListBox.Items(i).Value) <> SystemModuleFieldIdRequired.ToString Then
            SortOrder = i + 1
            Dim SystemModuleFieldId As New Guid(SelectedListBox.Items(i).Value)
            SystemModuleFieldName = (SelectedListBox.Items(i).Text)
            Dim dtAccountModuleFields As AccountModule.AccountModuleFieldsDataTable = ModuleViewbll.GetAccountModuleFieldsBySystemModuleFieldIdAndAccountModuleViewId(SystemModuleFieldId, AccountModuleViewId)
            Dim drAccountModuleFields As AccountModule.AccountModuleFieldsRow
            If dtAccountModuleFields.Rows.Count > 0 Then
                drAccountModuleFields = dtAccountModuleFields.Rows(0)
                ModuleViewbll.UpdateAccountModuleFields(drAccountModuleFields.Item("AccountModuleFieldId"), drAccountModuleFields.Item("AccountModuleFieldName"), drAccountModuleFields.Item("SystemModuleFieldId"), drAccountModuleFields.Item("AccountModuleViewId"), DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SortOrder)
            End If
            If dtAccountModuleFields.Rows.Count = 0 Then
                ModuleViewbll.AddAccountModuleFields(ResourceHelper.GetFromResource(SystemModuleFieldName), SystemModuleFieldId, AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SortOrder)
            End If
            ''End If
        Next
        ModuleViewbll.UpdateAccountModuleViewForddl(Me.txtAddView.Text, AccountModuleViewId, SystemModuleId)
        'If Not ListBoxValues.Contains(SystemModuleFieldIdRequired.ToString) Then
        '    If Not ResourceHelper.GetFromResource(SystemModuleFieldName) = "" Then
        '        ModuleViewbll.AddAccountModuleFields(ResourceHelper.GetFromResource(SystemModuleFieldName), SystemModuleFieldIdRequired, AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SortOrder)
        '        System.Web.HttpContext.Current.Session.Add("RequiredField", "1")
        '        System.Web.HttpContext.Current.Session.Add("RequiredFieldMessage", "cannot remove required fileds")
        '        'Dim Message As String = System.Web.HttpContext.Current.Session("cannot remove required fileds")
        '        'UIUtilities.ShowMessage(Message + " is already added", Me.Page)
        '    End If
        'End If
    End Sub
    Public Sub InsertNewView()
        Dim NewAccountModuleViewId As Guid
        Dim txtAccountModuleViewName As String = ResourceHelper.GetFromResource(txtAddView.Text)
        Dim dtAccountModuleViewName As AccountModule.AccountModuleViewDataTable = ModuleViewbll.GetAccountModuleViewByAccountModuleViewName(SystemModuleId, txtAccountModuleViewName)
        If dtAccountModuleViewName.Rows.Count = 0 Then
            ModuleViewbll.AddAccountModuleView(txtAccountModuleViewName, SystemModuleId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, True, False)
            Dim dtAccountModuleViewId As AccountModule.AccountModuleViewDataTable = ModuleViewbll.GetLastInsertedAccountModuleViewId(SystemModuleId, txtAccountModuleViewName, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
            Dim drAccountModuleViewId As AccountModule.AccountModuleViewRow
            If dtAccountModuleViewId.Rows.Count > 0 Then
                drAccountModuleViewId = dtAccountModuleViewId.Rows(0)
                NewAccountModuleViewId = drAccountModuleViewId.AccountModuleViewId
            End If
            ModuleViewbll.UpdateAccountModuleViewForddl(txtAccountModuleViewName, NewAccountModuleViewId, SystemModuleId)
        Else
            System.Web.HttpContext.Current.Session.Add("ShowMessageError", "1")
            System.Web.HttpContext.Current.Session.Add("ShowMessage", txtAddView.Text)
            'Dim Message As String = System.Web.HttpContext.Current.Session(txtAddView.Text)
            'UIUtilities.ShowMessage(Message + " is already added", Me.Page)
        End If

        ''delete listbox item from database by selecting systemid
        For i As Integer = AvailableListBox.Items.Count - 1 To 0 Step -1
            Dim SystemModuleFieldId As New Guid(AvailableListBox.Items(i).Value)
            Dim dt As AccountModule.AccountModuleFieldsDataTable
            dt = ModuleViewbll.GetAccountModuleFieldsBySystemModuleFieldId(SystemModuleFieldId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
            If dt.Rows.Count > 0 And Not ListBoxValues.Contains(SystemModuleFieldId.ToString) Then
                ModuleViewbll.DeleteAccountModuleFields(SystemModuleFieldId, NewAccountModuleViewId)
            End If
        Next
        ' ''id
        ' ''Task Name
        'Dim SystemModuleFieldIdRequired As Guid = New Guid("31017d12-801d-42dd-92dc-84fc9d8048cb")
        Dim SystemModuleFieldName As String = ""
        Dim SortOrder As Integer = 0

        For i As Integer = SelectedListBox.Items.Count - 1 To 0 Step -1
            SortOrder = i + 1
            Dim SystemModuleFieldId As New Guid(SelectedListBox.Items(i).Value)
            SystemModuleFieldName = (SelectedListBox.Items(i).Text)
            Dim dtAccountModuleFields As AccountModule.AccountModuleFieldsDataTable = ModuleViewbll.GetAccountModuleFieldsBySystemModuleFieldIdAndAccountModuleViewId(SystemModuleFieldId, NewAccountModuleViewId)
            Dim drAccountModuleFields As AccountModule.AccountModuleFieldsRow
            If dtAccountModuleFields.Rows.Count > 0 Then
                drAccountModuleFields = dtAccountModuleFields.Rows(0)
                ModuleViewbll.UpdateAccountModuleFields(drAccountModuleFields.Item("AccountModuleFieldId"), drAccountModuleFields.Item("AccountModuleFieldName"), drAccountModuleFields.Item("SystemModuleFieldId"), drAccountModuleFields.Item("AccountModuleViewId"), DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SortOrder)
            End If
            If dtAccountModuleFields.Rows.Count = 0 Then
                ModuleViewbll.AddAccountModuleFields(ResourceHelper.GetFromResource(SystemModuleFieldName), SystemModuleFieldId, NewAccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SortOrder)
            End If
            ''End If
        Next
        'If Not ListBoxValues.Contains(SystemModuleFieldIdRequired.ToString) Or ListBoxValues.Count = 0 Then
        '    ModuleViewbll.AddAccountModuleFields(ResourceHelper.GetFromResource(SystemModuleFieldName), SystemModuleFieldIdRequired, NewAccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SortOrder)
        '    'System.Web.HttpContext.Current.Session.Add("RequiredField", "1")
        '    'System.Web.HttpContext.Current.Session.Add("RequiredFieldMessage", "cannot remove required fileds")
        '    'Dim Message As String = System.Web.HttpContext.Current.Session("cannot remove required fileds")
        '    'UIUtilities.ShowMessage(Message, Me.Page)
        'End If
    End Sub
    Protected Sub imgCancel_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgCancel.Click
        ModalPopupExtender2.TargetControlID = "imgCancel"
        'If System.Web.HttpContext.Current.Session("btnReset") = "Reset" Then
        '    System.Web.HttpContext.Current.Session.Remove("btnReset")
        '    ListBoxValuesForEdit()
        '    ModalPopupExtender2.Hide()
        'End If
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Sub LoadModelPopUpForAddNewView()
        GetDatasourceForAddView()
        txtAddView.Text = ""
        btnAddView.Visible = True
        btnOkay.Visible = False
        btnReset.Visible = False
        ModalPopupExtender2.Show()
    End Sub
    Public Sub LoadModelPopUpAfterResetView()
        GetDatasourceForAddView()
        txtAddView.Text = System.Web.HttpContext.Current.Session("txtAddView_Text")
        System.Web.HttpContext.Current.Session.Remove("txtAddView_Text")
        btnAddView.Visible = False
        btnOkay.Visible = True
        btnReset.Visible = True
        ModalPopupExtender2.CancelControlID = ""
        ModalPopupExtender2.Show()
    End Sub
    Public Sub GetDatasourceForAddView()

        AvailableListBox.DataSourceID = "ObjSystemModuleFields"
        AvailableListBox.DataTextField = "SystemModuleFieldDisplayName"
        AvailableListBox.DataValueField = "SystemModuleFieldId"

        SelectedListBox.DataSourceID = "ObjAccountModuleFields"
        SelectedListBox.DataTextField = "SystemModuleFieldDisplayName"
        SelectedListBox.DataValueField = "SystemModuleFieldId"

    End Sub
    Protected Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click
        'GetDatasourceForAddView()
        'For i As Integer = SelectedListBox.Items.Count - 1 To 0 Step -1
        '    SelectedListBoxValues.Add(SelectedListBox.Items(i).Value, i)
        'Next
        'For Each key As String In SelectedListBoxValues.Keys
        '    If key = "31017d12-801d-42dd-92dc-84fc9d8048cb" Then
        '        SelectedListBox.Items(SelectedListBoxValues(key)).Attributes.Add("disabled", "disabled")
        '    End If
        'Next
        'ModalPopupExtender2.Show()
        System.Web.HttpContext.Current.Session.Add("btnReset_Click", "Reset")
        System.Web.HttpContext.Current.Session.Add("txtAddView_Text", Me.ddlAccountModuleView.SelectedItem.Text)
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ddlAccountModuleView_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAccountModuleView.SelectedIndexChanged
        If ddlAccountModuleView.SelectedValue = "0" Then
            ModalPopupExtender2.CancelControlID = ""
            System.Web.HttpContext.Current.Session.Add("ddlSelectedIndexChanged", "0")
        Else
            ModuleViewbll.UpdateAccountModuleViewForddl(CurrentSelectedModuleViewName, CurrentSelectedModuleViewId, SystemModuleId)
        End If
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub ImgBtn_delete_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImgBtn_delete.Click
        Dim ModuleViewId As New Guid(Me.ddlAccountModuleView.SelectedValue)
        ModuleViewbll.DeleteQueryAccountModuleViewFields(ModuleViewId)
        ModuleViewbll.DeleteAccountModuleView(ModuleViewId, SystemModuleId)
        ModuleViewbll.SetDefaultViewIsSelected(SystemModuleId)
        Response.Redirect(Request.RawUrl)
    End Sub
    Public Sub SetDDLGlobalViewFirstTime()
        ModuleViewbll.InsertModuleViewFirstTime(SystemModuleId)
    End Sub
    Public Sub AddDefaultModuleViewFields(ByVal AccountModuleViewId As Guid)
        ModuleViewbll.InsertModuleViewFieldsFirstTime(SystemModuleId, AccountModuleViewId)
    End Sub
    Public Sub SetDDLSelectedValue()
        SetDDLGlobalViewFirstTime()
        Dim dt As AccountModule.AccountModuleViewDataTable = New AccountModuleBLL().GetAccountModuleViewByIsSelected(SystemModuleId, True)
        Dim dr As AccountModule.AccountModuleViewRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If dr.IsDefaultView = True Then
                AddDefaultModuleViewFields(dr.AccountModuleViewId)
                ImgBtn_delete.Visible = False
                ImgBtnEdit.Visible = False
            Else
                ImgBtn_delete.Visible = True
                ImgBtnEdit.Visible = True
            End If
            Me.ddlAccountModuleView.SelectedValue = dr.AccountModuleViewId.ToString
        End If
    End Sub
    Private Sub loadDynamicGridWithTemplateColumn()
        'ddlAccountModuleView.DataBind()

        Dim i As Integer = 0
        Dim AccountModuleViewId As Guid = New Guid(Me.ddlAccountModuleView.SelectedValue)
        'Dim AccountModuleViewId As Guid = New Guid(ddlSelectedValue)
        Dim dtAccountModule As AccountModule.vueAccountModuleFieldsDataTable = New AccountModuleBLL().GetvueAccountModuleFieldsByAccountModuleViewIdAndSystemModuleId(AccountModuleViewId, SystemModuleId)
        Dim drAccountModule As AccountModule.vueAccountModuleFieldsRow
        If dtAccountModule.Rows.Count > 0 Then
            drAccountModule = dtAccountModule.Rows(0)
            Dim cbfield As New TemplateField()
            cbfield.HeaderStyle.CssClass = "xgridviewSkinEmployee"
            cbfield.HeaderStyle.Width = Unit.Percentage("3")
            cbfield.ItemStyle.Width = Unit.Percentage("3")
            'cbfield.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
            'cbfield.HeaderStyle.VerticalAlign = VerticalAlign.Middle
            cbfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            cbfield.ItemStyle.VerticalAlign = VerticalAlign.Middle
            cbfield.HeaderTemplate = New GridViewTemplate(ListItemType.Header, "CheckBox", "")
            cbfield.ItemTemplate = New GridViewTemplate(ListItemType.Item, "CheckBox", "")
            GridView1.Columns.Insert(i, cbfield)
            i = i + 1
            For Each drAccountModule In dtAccountModule.Rows
                Dim bfield As New TemplateField()
                bfield.HeaderStyle.CssClass = "xgridviewSkinEmployee"
                bfield.HeaderText = ResourceHelper.GetFromResource(drAccountModule.SystemModuleFieldDisplayName)
                bfield.SortExpression = drAccountModule.SystemModuleFieldName
                bfield.ItemStyle.Width = Unit.Pixel(drAccountModule.SystemModuleFieldWidth)
                bfield.HeaderStyle.Width = Unit.Pixel(drAccountModule.SystemModuleFieldWidth)
                If drAccountModule.SystemModuleFieldName = "AccountProjectTaskId" Then
                    'bfield.HeaderStyle.HorizontalAlign = HorizontalAlign.Left
                    'bfield.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    bfield.ItemStyle.VerticalAlign = VerticalAlign.Middle
                End If
                'If drAccountModule.SystemModuleFieldName = "StartDate" Then
                '    'bfield.HeaderStyle.HorizontalAlign = HorizontalAlign.Left
                '    'bfield.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                '    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                '    bfield.ItemStyle.VerticalAlign = VerticalAlign.Middle
                'End If
                'If drAccountModule.SystemModuleFieldName = "DeadlineDate" Then
                '    'bfield.HeaderStyle.HorizontalAlign = HorizontalAlign.Left
                '    'bfield.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                '    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                '    bfield.ItemStyle.VerticalAlign = VerticalAlign.Middle
                'End If
                'If drAccountModule.SystemModuleFieldName = "MilestoneDescription" Then
                '    bfield.HeaderStyle.HorizontalAlign = HorizontalAlign.Right
                '    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                '    bfield.ItemStyle.VerticalAlign = VerticalAlign.Middle
                'End If
                bfield.HeaderTemplate = New GridViewTemplate(ListItemType.Header, drAccountModule.SystemModuleFieldName, ResourceHelper.GetFromResource(drAccountModule.SystemModuleFieldDisplayName))
                bfield.ItemTemplate = New GridViewTemplate(ListItemType.Item, drAccountModule.SystemModuleFieldName, ResourceHelper.GetFromResource(drAccountModule.SystemModuleFieldDisplayName))
                'bfield.EditItemTemplate = New GridViewTemplate(ListItemType.EditItem, drAccountModule.SystemModuleFieldName, ResourceHelper.GetFromResource(drAccountModule.SystemModuleFieldDisplayName))
                'bfield.FooterTemplate = New GridViewTemplate(ListItemType.Footer, drAccountModule.SystemModuleFieldName, ResourceHelper.GetFromResource(drAccountModule.SystemModuleFieldDisplayName))
                GridView1.Columns.Insert(i, bfield)
                i = i + 1
            Next
        End If
        Me.GridView1.DataBind()


    End Sub
    Protected Sub SelectedListBox_Load(sender As Object, e As System.EventArgs) Handles SelectedListBox.Load
        If Not Me.IsPostBack Then
            SelectedListBox.DataBind()
            For i As Integer = SelectedListBox.Items.Count - 1 To 0 Step -1
                SelectedListBoxValues.Add(SelectedListBox.Items(i).Value, i)
            Next
            For Each key As String In SelectedListBoxValues.Keys
                If key = "31017d12-801d-42dd-92dc-84fc9d8048cb" Then
                    SelectedListBox.Items(SelectedListBoxValues(key)).Attributes.Add("disabled", "disabled")
                    'SelectedListBox.Items(SelectedListBoxValues(key)).
                End If
            Next
        End If
    End Sub
End Class
