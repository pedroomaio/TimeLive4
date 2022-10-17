Imports SMInformatik.Util
Partial Class Employee_Controls_ctlAccountEmployeeTimeEntryAudit
    Inherits System.Web.UI.UserControl
    Dim OldVal As String
    Dim NewVal As String
    Dim AccountEmployeeId As Integer
    Dim AccountProjectId As Integer
    Dim AccountProjectTaskId As Integer
    Dim AccountWorkTypeId As Integer
    Dim AccountCostCenterId As Integer
    Dim RefreshClicked As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Me.IsPostBack Then
        Me.ChangeValuesIngvAccountEmployeeTimeEntryPeriodAudit()
        Me.ChangeValuesIngvAccountEmployeeTimeEntryAudit()
        'End If
        AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
    Public Sub ChangeValuesIngvAccountEmployeeTimeEntryAudit()
        Dim PK As New Guid(Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId"))
        Dim BLL As New AccountEmployeeTimeEntryAuditBLL
        Dim dtAccountEmployeeTimeEntryAudit As AccountEmployeeTimeEntryAudit.AccountEmployeeTimeEntryAuditDataTable
        Dim ProjectBLL As New AccountProjectBLL
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable
        Dim ProjectTaskBLL As New AccountProjectTaskBLL
        Dim dtProjectTask As TimeLiveDataSet.AccountProjectTaskDataTable
        Dim WorkTypeBLL As New AccountWorkTypeBLL
        Dim dtWorkType As TimeLiveDataSet.AccountWorkTypeDataTable
        Dim CostCenterBLL As New AccountCostCenterBLL
        Dim dtCostCenter As AccountCostCenter.AccountCostCenterDataTable
        dtAccountEmployeeTimeEntryAudit = BLL.GetAccountEmployeeTimeEntryAuditByPK(PK)
        dtAccountEmployeeTimeEntryAudit.Columns.Add("OldForeignValue")
        dtAccountEmployeeTimeEntryAudit.Columns.Add("NewForeignValue")
        Dim objRow As AccountEmployeeTimeEntryAudit.AccountEmployeeTimeEntryAuditRow
        If dtAccountEmployeeTimeEntryAudit.Rows.Count >= 1 And Not IsDBNull(dtAccountEmployeeTimeEntryAudit.Rows.Item(0)("FieldName")) Then
            For Each objRow In dtAccountEmployeeTimeEntryAudit.Rows
                'For AccountProject
                If objRow.FieldName = "AccountProjectId" Then
                    objRow.FieldName = "ProjectName"
                    AccountProjectId = IIf(IsDBNull(objRow("OldValue")), 0, objRow("OldValue"))
                    dtProject = ProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
                    Dim objProjectRow As TimeLiveDataSet.AccountProjectRow
                    If dtProject.Rows.Count > 0 Then
                        objProjectRow = dtProject.Rows(0)
                        dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue = objProjectRow("ProjectName")
                        OldVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue), OldVal, dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountProjectId = IIf(IsDBNull(objRow("NewValue")), 0, objRow("NewValue"))
                    dtProject = ProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
                    If dtProject.Rows.Count > 0 Then
                        objProjectRow = dtProject.Rows(0)
                        dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue = objProjectRow("ProjectName")
                        NewVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue), NewVal, dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For AccountProjectTask
                If objRow.FieldName = "AccountProjectTaskId" Then
                    objRow.FieldName = "TaskName"
                    AccountProjectTaskId = objRow("OldValue")
                    dtProjectTask = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
                    Dim objProjectTaskRow As TimeLiveDataSet.AccountProjectTaskRow
                    If dtProjectTask.Rows.Count > 0 Then
                        objProjectTaskRow = dtProjectTask.Rows(0)
                        dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue = objProjectTaskRow("TaskName")
                        OldVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue), OldVal, dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountProjectTaskId = objRow("NewValue")
                    dtProjectTask = ProjectTaskBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)
                    If dtProjectTask.Rows.Count > 0 Then
                        objProjectTaskRow = dtProjectTask.Rows(0)
                        dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue = objProjectTaskRow("TaskName")
                        NewVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue), NewVal, dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For AccountWorkType
                If objRow.FieldName = "AccountWorkTypeId" Then
                    objRow.FieldName = "WorkType"
                    AccountWorkTypeId = objRow("OldValue")
                    dtWorkType = WorkTypeBLL.GetAccountWorkTypesByAccountWorkTypeId(AccountWorkTypeId)
                    Dim objWorkTypeRow As TimeLiveDataSet.AccountWorkTypeRow
                    If dtWorkType.Rows.Count > 0 Then
                        objWorkTypeRow = dtWorkType.Rows(0)
                        dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue = objWorkTypeRow("AccountWorkType")
                        OldVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue), OldVal, dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountWorkTypeId = objRow("NewValue")
                    dtWorkType = WorkTypeBLL.GetAccountWorkTypesByAccountWorkTypeId(AccountWorkTypeId)
                    If dtWorkType.Rows.Count > 0 Then
                        objWorkTypeRow = dtWorkType.Rows(0)
                        dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue = objWorkTypeRow("AccountWorkType")
                        NewVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue), NewVal, dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For AccountCostCenter
                If objRow.FieldName = "AccountCostCenterId" Then
                    objRow.FieldName = "CostCenter"
                    AccountCostCenterId = IIf(IsDBNull(objRow("OldValue")), 0, objRow("OldValue"))
                    dtCostCenter = CostCenterBLL.GetAccountCostCenterByAccountCostCenterId(AccountCostCenterId)
                    Dim objCostCenterRow As AccountCostCenter.AccountCostCenterRow
                    If dtCostCenter.Rows.Count > 0 Then
                        objCostCenterRow = dtCostCenter.Rows(0)
                        dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue = objCostCenterRow("AccountCostCenter")
                        OldVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue), OldVal, dtAccountEmployeeTimeEntryAudit.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountCostCenterId = IIf(IsDBNull(objRow("NewValue")), 0, objRow("NewValue"))
                    dtCostCenter = CostCenterBLL.GetAccountCostCenterByAccountCostCenterId(AccountCostCenterId)
                    If dtCostCenter.Rows.Count > 0 Then
                        objCostCenterRow = dtCostCenter.Rows(0)
                        dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue = objCostCenterRow("AccountCostCenter")
                        NewVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue), NewVal, dtAccountEmployeeTimeEntryAudit.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
            Next
        End If
        Dim dv As New DataView(dtAccountEmployeeTimeEntryAudit)
        Try
            dv.RowFilter = FilterExp()
        Catch ex As Exception
            dv.RowFilter = ""
            ShowNotFoundMessage()
        End Try
        If dv.Count <= 0 Then
            dv.RowFilter = ""
            If RefreshClicked <> True Then
                ShowNotFoundMessage()
            End If
        End If
        gvAccountEmployeeTimeEntryAudit.DataSource = dv
        gvAccountEmployeeTimeEntryAudit.DataBind()
        IIf(IsDBNull("OldForeignValue"), OldVal, NewVal)
        IIf(IsDBNull("NewForeignValue"), NewVal, OldVal)
    End Sub
    Protected Sub gvAccountEmployeeTimeEntryAudit_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAccountEmployeeTimeEntryAudit.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ''Dim SystemCurrentDateTime As DateTime
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "ProjectName")) Then
                CType(e.Row.Cells(4).FindControl("Label2"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 15, Left(DataBinder.Eval(e.Row.DataItem, "ProjectName"), 13) & "..", DataBinder.Eval(e.Row.DataItem, "ProjectName"))
                If DataBinder.Eval(e.Row.DataItem, "ProjectName").ToString.Length > 15 Then
                    CType(e.Row.Cells(4).FindControl("Label2"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "ProjectName")
                End If
            End If
            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TaskName")) Then
                CType(e.Row.Cells(4).FindControl("Label3"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "TaskName").ToString.Length > 15, Left(DataBinder.Eval(e.Row.DataItem, "TaskName"), 13) & "..", DataBinder.Eval(e.Row.DataItem, "TaskName"))
                If DataBinder.Eval(e.Row.DataItem, "TaskName").ToString.Length > 15 Then
                    CType(e.Row.Cells(4).FindControl("Label3"), Label).ToolTip = DataBinder.Eval(e.Row.DataItem, "TaskName")
                End If
            End If
            If CType(e.Row.Cells(0).FindControl("Label1"), Label).Text <> "" Then
                Dim AuditDatetime As DateTime = CType(e.Row.Cells(0).FindControl("Label1"), Label).Text
                Dim dtdatetime As SMDateTime
                With AuditDatetime
                    dtdatetime = New SMDateTime(SMTimeZone.CurrentTimeZone, .Year, .Month, .Day, .Hour, .Minute, .Second)
                End With
                AuditDatetime = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZoneForSMTimeZone(dtdatetime, GetTimeZoneId(DBUtilities.GetSessionAccountEmployeeId))
                CType(e.Row.Cells(0).FindControl("Label1"), Label).Text = AuditDatetime
            End If
            If CType(e.Row.Cells(5).FindControl("lblFieldName"), Label).Text = "StartTime" Or CType(e.Row.Cells(5).FindControl("lblFieldName"), Label).Text = "EndTime" Then
                CType(e.Row.Cells(6).FindControl("lblOldValue"), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "OldValue"))
                CType(e.Row.Cells(6).FindControl("lblNewValue"), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryStartEndTimeFormat(DataBinder.Eval(e.Row.DataItem, "NewValue"))
            End If
            If CType(e.Row.Cells(5).FindControl("lblFieldName"), Label).Text = "TotalTime" Then
                CType(e.Row.Cells(6).FindControl("lblOldValue"), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(DataBinder.Eval(e.Row.DataItem, "OldValue"))
                CType(e.Row.Cells(6).FindControl("lblNewValue"), Label).Text = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(DataBinder.Eval(e.Row.DataItem, "NewValue"))
            End If
            Dim TotalTime As String
            If Not e.Row.Cells(4).FindControl("lblTotalTime") Is Nothing Then
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "TotalTime")) Then
                    TotalTime = LocaleUtilitiesBLL.ConvertStringToTimeEntryTotalTimeFormat(DataBinder.Eval(e.Row.DataItem, "TotalTime"))
                End If
                CType(e.Row.Cells(4).FindControl("lblTotalTime"), Label).Text = TotalTime
            End If
        End If

    End Sub
    Public Sub ChangeValuesIngvAccountEmployeeTimeEntryPeriodAudit()
        Dim PK As New Guid(Me.Request.QueryString("AccountEmployeeTimeEntryPeriodId"))
        Dim BLL As New AccountEmployeeTimeEntryAuditBLL
        Dim dtAccountEmployeeTimeEntryPeriodAudit As AccountEmployeeTimeEntryAudit.AccountEmployeeTimeEntryPeriodAuditDataTable
        Dim EmployeeBLL As New AccountEmployeeBLL
        Dim dtEmployee As AccountEmployee.AccountEmployeeDataTable
        dtAccountEmployeeTimeEntryPeriodAudit = BLL.GetAccountEmployeeTimeEntryPeriodAuditByPK(PK.ToString)
        dtAccountEmployeeTimeEntryPeriodAudit.Columns.Add("OldForeignValue")
        dtAccountEmployeeTimeEntryPeriodAudit.Columns.Add("NewForeignValue")
        Dim objRow As AccountEmployeeTimeEntryAudit.AccountEmployeeTimeEntryPeriodAuditRow
        If dtAccountEmployeeTimeEntryPeriodAudit.Rows.Count >= 1 And Not IsDBNull(dtAccountEmployeeTimeEntryPeriodAudit.Rows.Item(0)("FieldName")) Then
            For Each objRow In dtAccountEmployeeTimeEntryPeriodAudit.Rows
                'For SubmittedBy
                If objRow.FieldName = "SubmittedBy" Then
                    objRow.FieldName = "SubmittedBy"
                    AccountEmployeeId = IIf(IsDBNull(objRow("OldValue")), 0, objRow("OldValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    Dim objEmployeeRow As AccountEmployee.AccountEmployeeRow
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dtAccountEmployeeTimeEntryPeriodAudit.Columns("OldForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        OldVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryPeriodAudit.Columns("OldForeignValue").DefaultValue), OldVal, dtAccountEmployeeTimeEntryPeriodAudit.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountEmployeeId = IIf(IsDBNull(objRow("NewValue")), 0, objRow("NewValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dtAccountEmployeeTimeEntryPeriodAudit.Columns("NewForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        NewVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryPeriodAudit.Columns("NewForeignValue").DefaultValue), NewVal, dtAccountEmployeeTimeEntryPeriodAudit.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For ApprovedBy
                If objRow.FieldName = "ApprovedByEmployeeId" Then
                    objRow.FieldName = "ApprovedBy"
                    AccountEmployeeId = IIf(IsDBNull(objRow("OldValue")), 0, objRow("OldValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    Dim objEmployeeRow As AccountEmployee.AccountEmployeeRow
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dtAccountEmployeeTimeEntryPeriodAudit.Columns("OldForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        OldVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryPeriodAudit.Columns("OldForeignValue").DefaultValue), OldVal, dtAccountEmployeeTimeEntryPeriodAudit.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountEmployeeId = IIf(IsDBNull(objRow("NewValue")), 0, objRow("NewValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dtAccountEmployeeTimeEntryPeriodAudit.Columns("NewForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        NewVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryPeriodAudit.Columns("NewForeignValue").DefaultValue), NewVal, dtAccountEmployeeTimeEntryPeriodAudit.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
                'For RejectedBy
                If objRow.FieldName = "RejectedByEmployeeId" Then
                    objRow.FieldName = "RejectedBy"
                    AccountEmployeeId = IIf(IsDBNull(objRow("OldValue")), 0, objRow("OldValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    Dim objEmployeeRow As AccountEmployee.AccountEmployeeRow
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dtAccountEmployeeTimeEntryPeriodAudit.Columns("OldForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        OldVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryPeriodAudit.Columns("OldForeignValue").DefaultValue), OldVal, dtAccountEmployeeTimeEntryPeriodAudit.Columns("OldForeignValue").DefaultValue)
                        objRow("OldValue") = OldVal
                    End If
                    AccountEmployeeId = IIf(IsDBNull(objRow("NewValue")), 0, objRow("NewValue"))
                    dtEmployee = EmployeeBLL.GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
                    If dtEmployee.Rows.Count > 0 Then
                        objEmployeeRow = dtEmployee.Rows(0)
                        dtAccountEmployeeTimeEntryPeriodAudit.Columns("NewForeignValue").DefaultValue = objEmployeeRow("FirstName") & " " & objEmployeeRow("LastName")
                        NewVal = IIf(IsDBNull(dtAccountEmployeeTimeEntryPeriodAudit.Columns("NewForeignValue").DefaultValue), NewVal, dtAccountEmployeeTimeEntryPeriodAudit.Columns("NewForeignValue").DefaultValue)
                        objRow("NewValue") = NewVal
                    End If
                End If
            Next
        End If
        Dim dv As New DataView(dtAccountEmployeeTimeEntryPeriodAudit)
        Try
            dv.RowFilter = PGFilterExp()
        Catch ex As Exception
            dv.RowFilter = ""
            ShowNotFoundMessage()
        End Try
        If dv.Count <= 0 Then
            dv.RowFilter = ""
            If RefreshClicked <> True Then
                ShowNotFoundMessage()
            End If
        End If
        gvAccountEmployeeTimeEntryPeriodAudit.DataSource = dv
        gvAccountEmployeeTimeEntryPeriodAudit.DataBind()
        IIf(IsDBNull("OldForeignValue"), OldVal, NewVal)
        IIf(IsDBNull("NewForeignValue"), NewVal, OldVal)
    End Sub
    Protected Sub gvAccountEmployeeTimeEntryPeriodAudit_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAccountEmployeeTimeEntryPeriodAudit.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If CType(e.Row.Cells(0).FindControl("Label1"), Label).Text <> "" Then
                Dim PeriodAuditDatetime As DateTime = CType(e.Row.Cells(0).FindControl("Label1"), Label).Text
                Dim dtdatetime As SMDateTime
                With PeriodAuditDatetime
                    dtdatetime = New SMDateTime(SMTimeZone.CurrentTimeZone, .Year, .Month, .Day, .Hour, .Minute, .Second)
                End With
                PeriodAuditDatetime = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZoneForSMTimeZone(dtdatetime, GetTimeZoneId(DBUtilities.GetSessionAccountEmployeeId))
                CType(e.Row.Cells(0).FindControl("Label1"), Label).Text = PeriodAuditDatetime
            End If
            If CType(e.Row.Cells(2).FindControl("lblFieldName"), Label).Text = "Submitted" Or CType(e.Row.Cells(5).FindControl("lblFieldName"), Label).Text = "Approved" Or CType(e.Row.Cells(5).FindControl("lblFieldName"), Label).Text = "Rejected" Then
                CType(e.Row.Cells(3).FindControl("lblOldValue"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "OldValue") <> "1", "No", "Yes")
                CType(e.Row.Cells(4).FindControl("lblNewValue"), Label).Text = IIf(DataBinder.Eval(e.Row.DataItem, "NewValue") <> "1", "No", "Yes")
            End If
            Dim PAOldVal As DateTime
            If CType(e.Row.Cells(2).FindControl("lblFieldName"), Label).Text = "SubmittedDate" Or CType(e.Row.Cells(5).FindControl("lblFieldName"), Label).Text = "ApprovedOn" Or CType(e.Row.Cells(5).FindControl("lblFieldName"), Label).Text = "RejectedOn" Then
                Dim OldVal As String
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "OldValue")) Then
                    OldVal = CDate(DataBinder.Eval(e.Row.DataItem, "OldValue"))
                    If CType(e.Row.Cells(2).FindControl("lblFieldName"), Label).Text <> "SubmittedDate" Then
                        PAOldVal = OldVal
                        Dim dtdatetime As SMDateTime
                        With PAOldVal
                            dtdatetime = New SMDateTime(SMTimeZone.CurrentTimeZone, .Year, .Month, .Day, .Hour, .Minute, .Second)
                        End With
                        PAOldVal = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZoneForSMTimeZone(dtdatetime, GetTimeZoneId(DBUtilities.GetSessionAccountEmployeeId))
                        CType(e.Row.Cells(3).FindControl("lblOldValue"), Label).Text = PAOldVal
                    Else
                        CType(e.Row.Cells(3).FindControl("lblOldValue"), Label).Text = OldVal
                    End If
                End If
                Dim NewVal As String
                Dim PANewVal As DateTime
                If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "NewValue")) Then
                    NewVal = CDate(DataBinder.Eval(e.Row.DataItem, "NewValue"))
                    If CType(e.Row.Cells(2).FindControl("lblFieldName"), Label).Text <> "SubmittedDate" Then
                        PANewVal = NewVal
                        Dim dtdatetime As SMDateTime
                        With PANewVal
                            dtdatetime = New SMDateTime(SMTimeZone.CurrentTimeZone, .Year, .Month, .Day, .Hour, .Minute, .Second)
                        End With
                        PANewVal = LocaleUtilitiesBLL.GetCurrentDateTimeFromUserTimeZoneForSMTimeZone(dtdatetime, GetTimeZoneId(DBUtilities.GetSessionAccountEmployeeId))
                        CType(e.Row.Cells(4).FindControl("lblNewValue"), Label).Text = PANewVal
                    Else
                        CType(e.Row.Cells(4).FindControl("lblNewValue"), Label).Text = NewVal
                    End If
                End If
            End If
        End If
    End Sub
    Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode
        If DBUtilities.GetDefaultTimeEntryMode = "Period View" Then
            AccountPagePermissionBLL.ChangeCurrentNodeParent(18, "~/Employee/AccountEmployeeTimeEntryPeriodView.aspx")
        Else
            AccountPagePermissionBLL.ChangeCurrentNodeParent(18, "~/Employee/AccountEmployeeTimeEntryDayView.aspx")
        End If
    End Function

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        RemoveHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths
    End Sub
    ''' <summary>
    ''' Get timezone
    ''' </summary>
    ''' <param name="AccountEmployeeID"></param>
    ''' <returns>timezoneid</returns>
    ''' <remarks></remarks>
    Public Shared Function GetTimeZoneId(ByVal AccountEmployeeID As Integer) As Byte
        Dim dt As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeID)
        Dim dr As AccountEmployee.AccountEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("TimeZoneId")) Then
                Return dr.TimeZoneId
            End If
        End If
        Return 6
    End Function
    Public Function FilterExp() As String
        If Not Me.gvAccountEmployeeTimeEntryAudit.HeaderRow Is Nothing Then
            Dim UD As String = CType(Me.gvAccountEmployeeTimeEntryAudit.HeaderRow.FindControl("UD"), TextBox).Text
            Dim PF As String = CType(Me.gvAccountEmployeeTimeEntryAudit.HeaderRow.FindControl("PF"), TextBox).Text
            Dim TF As String = CType(Me.gvAccountEmployeeTimeEntryAudit.HeaderRow.FindControl("TF"), TextBox).Text
            Dim TT As String = CType(Me.gvAccountEmployeeTimeEntryAudit.HeaderRow.FindControl("TT"), TextBox).Text
            Dim FN As String = CType(Me.gvAccountEmployeeTimeEntryAudit.HeaderRow.FindControl("FN"), TextBox).Text
            Dim OV As String = CType(Me.gvAccountEmployeeTimeEntryAudit.HeaderRow.FindControl("OV"), TextBox).Text
            Dim NV As String = CType(Me.gvAccountEmployeeTimeEntryAudit.HeaderRow.FindControl("NV"), TextBox).Text
            Dim UB As String = CType(Me.gvAccountEmployeeTimeEntryAudit.HeaderRow.FindControl("UB"), TextBox).Text
            FilterExp = "Convert(UpdateDate, 'System.String') like '%" & UD & "%'" & " And ProjectName like '%" & PF & "%' And TaskName like '%" & TF & "%' And " & "Convert(TotalTime, 'System.String') like '%" & TT & "%' And " & "Convert(FieldName, 'System.String') like '%" & FN & "%' And " & "Convert(OldValue, 'System.String') like '%" & OV & "%' And " & "Convert(NewValue, 'System.String') like '%" & NV & "%' And " & "Convert(EmployeeName, 'System.String') like '%" & UB & "%'"
        End If
        Return FilterExp
    End Function
    Public Function PGFilterExp() As String
        If Not Me.gvAccountEmployeeTimeEntryPeriodAudit.HeaderRow Is Nothing Then
            Dim PUD As String = CType(Me.gvAccountEmployeeTimeEntryPeriodAudit.HeaderRow.FindControl("PUD"), TextBox).Text
            Dim PFN As String = CType(Me.gvAccountEmployeeTimeEntryPeriodAudit.HeaderRow.FindControl("PFN"), TextBox).Text
            Dim POV As String = CType(Me.gvAccountEmployeeTimeEntryPeriodAudit.HeaderRow.FindControl("POV"), TextBox).Text
            Dim PNV As String = CType(Me.gvAccountEmployeeTimeEntryPeriodAudit.HeaderRow.FindControl("PNV"), TextBox).Text
            Dim PUB As String = CType(Me.gvAccountEmployeeTimeEntryPeriodAudit.HeaderRow.FindControl("PUB"), TextBox).Text
            PGFilterExp = "Convert(UpdateDate, 'System.String') like '%" & PUD & "%'" & " And " & "Convert(FieldName, 'System.String') like '%" & PFN & "%' And " & "Convert(OldValue, 'System.String') like '%" & POV & "%' And " & "Convert(NewValue, 'System.String') like '%" & PNV & "%' And " & "Convert(EmployeeName, 'System.String') like '%" & PUB & "%'"
        End If
        Return PGFilterExp
    End Function
    Public Sub ShowNotFoundMessage()
        Dim strMessage As String = "No records found for this specified search specification."
        Dim strScript As String = "alert('" & strMessage & "'); "
        If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub
End Class
