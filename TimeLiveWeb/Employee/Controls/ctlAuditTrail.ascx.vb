
Partial Class Employee_Controls_ctlAuditTrail
    Inherits System.Web.UI.UserControl
    Dim PK As Integer
    Dim OldVal As String
    Dim NewVal As String
    Dim AccountStatusId As Integer
    Dim AccountPriorityId As Integer
    Dim AccountProjectTaskId As Integer
    Dim AccountProjectId As Integer
    Dim ParentAccountProjectTaskId As Integer
    Dim AccountTaskTypeId As Integer
    Dim AccountProjectMilestoneId As Integer
    Dim AccountEmployeeId As Integer

    Public Sub Status()

        PK = IIf(Not Me.Request.QueryString("AccountProjectTaskId") Is Nothing, Me.Request.QueryString("AccountProjectTaskId"), 98)

        Dim BLL As New AuditBLL
        Dim dt As TimeLiveDataSet.vueAuditDataTable


        Dim StatusBll As New AccountStatusBLL
        Dim dtStatus As TimeLiveDataSet.AccountStatusDataTable

        Dim PriorityBll As New AccountPriorityBLL
        Dim dtPriority As TimeLiveDataSet.AccountPriorityDataTable

        Dim AccountProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable

        Dim AccountProjectBLL As New AccountProjectBLL
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable

        Dim AccountTaskTypeBLL As New AccountTaskTypeBLL
        Dim dtTaskType As TimeLiveDataSet.AccountTaskTypeDataTable

        Dim AccountProjectMilestoneBLL As New AccountProjectMilestoneBLL
        Dim dtProjectMilestone As TimeLiveDataSet.AccountProjectMilestoneDataTable

        Dim AccountEmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable


        dt = BLL.GetDataByTableName(PK)



        dt.Columns.Add("OldForeignValue")
        dt.Columns.Add("NewForeignValue")


        Dim objRow As TimeLiveDataSet.vueAuditRow
        If dt.Rows.Count >= 1 And Not IsDBNull(dt.Rows.Item(0)("FieldName")) Then
            For Each objRow In dt.Rows

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''For TaskStatusId''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If objRow.FieldName = "TaskStatusId" Then
                    objRow.FieldName = "TaskStatus"
                    AccountStatusId = objRow("OldValue")
                    dtStatus = StatusBll.GetAccountsStatusByAccountStatusId(AccountStatusId)

                    Dim objStatusRow As TimeLiveDataSet.AccountStatusRow

                    For Each objStatusRow In dtStatus.Rows
                        dt.Columns("OldForeignValue").DefaultValue = objStatusRow("Status")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    Next

                    AccountStatusId = objRow("NewValue")
                    dtStatus = StatusBll.GetAccountsStatusByAccountStatusId(AccountStatusId)

                    For Each objStatusRow In dtStatus.Rows
                        dt.Columns("NewForeignValue").DefaultValue = objStatusRow("Status")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    Next

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''For AccountProjectId''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If objRow.FieldName = "AccountProjectTaskId" Then
                    objRow.FieldName = "AccountProjectTask"
                    AccountProjectTaskId = objRow("OldValue")
                    dtProjectTask = AccountProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)

                    Dim objProjectTaskRow As TimeLiveDataSet.AccountProjectTaskRow

                    For Each objProjectTaskRow In dtProjectTask.Rows
                        dt.Columns("OldForeignValue").DefaultValue = objProjectTaskRow("TaskName")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    Next

                    AccountProjectTaskId = objRow("NewValue")
                    dtProjectTask = AccountProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)

                    For Each objProjectTaskRow In dtProjectTask.Rows
                        dt.Columns("NewForeignValue").DefaultValue = objProjectTaskRow("TaskName")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    Next
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''For AccountProjectId''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If objRow.FieldName = "AccountProjectId" Then
                    objRow.FieldName = "AccountProject"
                    AccountProjectId = objRow("OldValue")
                    dtProject = AccountProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)

                    Dim objProjectRow As TimeLiveDataSet.AccountProjectRow

                    For Each objProjectRow In dtProject.Rows
                        dt.Columns("OldForeignValue").DefaultValue = objProjectRow("ProjectDescription")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    Next

                    AccountProjectId = objRow("NewValue")
                    dtProject = AccountProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)

                    For Each objProjectRow In dtProject.Rows
                        dt.Columns("NewForeignValue").DefaultValue = objProjectRow("ProjectDescription")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    Next

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''For ParentAccountProjectTaskId'''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If objRow.FieldName = "ParentAccountProjectTaskId" Then
                    objRow.FieldName = "ParentAccountProjectTask"
                    dt.Columns("OldForeignValue").DefaultValue = objRow("OldValue")
                    OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                    objRow("OldValue") = OldVal

                    dt.Columns("NewForeignValue").DefaultValue = objRow("NewValue")
                    NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                    objRow("NewValue") = NewVal

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''For AccountTaskTypeId''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If objRow.FieldName = "AccountTaskTypeId" Then
                    objRow.FieldName = "AccountTaskType"
                    AccountTaskTypeId = objRow("OldValue")
                    dtTaskType = AccountTaskTypeBLL.GetAccountTaskTypesByAccountTaskTypeId(AccountTaskTypeId)

                    Dim objTaskTypeRow As TimeLiveDataSet.AccountTaskTypeRow

                    For Each objTaskTypeRow In dtTaskType.Rows
                        dt.Columns("OldForeignValue").DefaultValue = objTaskTypeRow("TaskType")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    Next

                    AccountTaskTypeId = objRow("NewValue")
                    dtTaskType = AccountTaskTypeBLL.GetAccountTaskTypesByAccountTaskTypeId(AccountTaskTypeId)

                    For Each objTaskTypeRow In dtTaskType.Rows
                        dt.Columns("NewForeignValue").DefaultValue = objTaskTypeRow("TaskType")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    Next
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''For AccountPriorityId'''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If objRow.FieldName = "AccountPriorityId" Then
                    objRow.FieldName = "AccountPriority"
                    AccountPriorityId = objRow("OldValue")
                    dtPriority = PriorityBll.GetAccountPrioritiesByAccountPriorityId(AccountPriorityId)

                    Dim objPriorityrow As TimeLiveDataSet.AccountPriorityRow

                    For Each objPriorityrow In dtPriority.Rows
                        dt.Columns("OldForeignValue").DefaultValue = objPriorityrow("Priority")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    Next

                    AccountPriorityId = objRow("NewValue")
                    dtPriority = PriorityBll.GetAccountPrioritiesByAccountPriorityId(AccountPriorityId)

                    For Each objPriorityrow In dtPriority.Rows
                        dt.Columns("NewForeignValue").DefaultValue = objPriorityrow("Priority")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    Next

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''For AccountProjectMilestoneId''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If objRow.FieldName = "AccountProjectMilestoneId" Then

                    objRow.FieldName = "AccountProjectMilestone"
                    AccountProjectMilestoneId = objRow("OldValue")
                    dtProjectMilestone = AccountProjectMilestoneBLL.GetAccountProjectMilestonesByAccountProjectMilestoneId(AccountProjectMilestoneId)

                    Dim objProjectMilestoneRow As TimeLiveDataSet.AccountProjectMilestoneRow

                    For Each objProjectMilestoneRow In dtProjectMilestone.Rows
                        dt.Columns("OldForeignValue").DefaultValue = objProjectMilestoneRow("MilestoneDescription")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    Next

                    AccountProjectMilestoneId = objRow("NewValue")
                    dtProjectMilestone = AccountProjectMilestoneBLL.GetAccountProjectMilestonesByAccountProjectMilestoneId(AccountProjectMilestoneId)


                    For Each objProjectMilestoneRow In dtProjectMilestone.Rows
                        dt.Columns("NewForeignValue").DefaultValue = objProjectMilestoneRow("MilestoneDescription")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    Next
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''For CreatedByEmployeeId'''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If objRow.FieldName = "CreatedByEmployeeId" Then
                    objRow.FieldName = "CreatedByEmployee"
                    AccountEmployeeId = objRow("OldValue")
                    dtEmployee = AccountEmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)

                    Dim objCreatedByEmployeeRow As AccountEmployee.AccountEmployeeRow

                    For Each objCreatedByEmployeeRow In dtEmployee.Rows
                        dt.Columns("OldForeignValue").DefaultValue = objCreatedByEmployeeRow("FullName")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    Next

                    AccountEmployeeId = objRow("NewValue")
                    dtEmployee = AccountEmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)

                    For Each objCreatedByEmployeeRow In dtEmployee.Rows
                        dt.Columns("NewForeignValue").DefaultValue = objCreatedByEmployeeRow("FullName")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    Next
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''For ModifiedByEmployeeId'''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If objRow.FieldName = "ModifiedByEmployeeId" Then
                    objRow.FieldName = "ModifiedByEmployee"
                    AccountEmployeeId = objRow("OldValue")
                    dtEmployee = AccountEmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)

                    Dim objModifiedByEmployeeRow As AccountEmployee.AccountEmployeeRow

                    For Each objModifiedByEmployeeRow In dtEmployee.Rows
                        dt.Columns("OldForeignValue").DefaultValue = objModifiedByEmployeeRow("FullName")
                        OldVal = IIf(IsDBNull(dt.Columns("OldForeignValue").DefaultValue), OldVal, dt.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    Next

                    AccountEmployeeId = objRow("NewValue")
                    dtEmployee = AccountEmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)


                    For Each objModifiedByEmployeeRow In dtEmployee.Rows
                        dt.Columns("NewForeignValue").DefaultValue = objModifiedByEmployeeRow("FullName")
                        NewVal = IIf(IsDBNull(dt.Columns("NewForeignValue").DefaultValue), NewVal, dt.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    Next

                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Next
        End If
        Dim GridView1 As New GridView

        Me.GridView1.DataSource = dt

        Me.GridView1.DataBind()

        IIf(IsDBNull("OldForeignValue"), OldVal, NewVal)

        IIf(IsDBNull("NewForeignValue"), NewVal, OldVal)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.Status()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub
End Class
