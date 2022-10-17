Imports System.Collections.Specialized
Imports System.Collections.Generic
Imports System.Drawing
''' <summary>
''' Employee controls of employee time entry for week view
''' </summary>
''' <remarks></remarks>
Partial Class Employee_Controls_ctlAccountEmployeeTimeEntryWeekViewTemplate
    Inherits System.Web.UI.UserControl


    Protected Sub GridView1_DataBound(sender As Object, e As System.EventArgs) Handles GridView1.DataBound
        If Not AccountPagePermissionBLL.IsPageHasPermissionOf(19, 3) = True Then
            btnSave.Enabled = False
        End If
        Me.GridView1.Columns(0).Visible = False
        Dim objRow As GridViewRow
        For Each objRow In Me.GridView1.Rows
            Me.SetCascadingAccountId(objRow)
            ' ''Me.SetCascadingAccountIdForParentTask(objRow)
            SetClientCascadingEnabled(objRow)
        Next

    End Sub
    Public Sub SetClientCascadingEnabled(ByVal objRow As GridViewRow)
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        Dim dsObject As ObjectDataSource = CType(objRow.Cells(1).FindControl("dsAccountProjectsObject"), ObjectDataSource)
        Dim AccountProjectId As Integer = dsObject.SelectParameters("AccountProjectId").DefaultValue
        MyCascading = CType(objRow.FindControl("CP"), AjaxControlToolkit.CascadingDropDown)
        '''''If DBUtilities.GetShowClientInTimesheet = False Then
        MyCascading.ParentControlID = Nothing
        '''''End If
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & AccountProjectId & "," & False & "," & DBUtilities.GetSessionAccountId & "," & 0 & "," & LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet & "," & DBUtilities.GetShowAdditionalProjectInformationType
    End Sub
    Public Sub SetCascadingAccountId(ByVal objRow As GridViewRow)
        Dim MyCascading As AjaxControlToolkit.CascadingDropDown
        MyCascading = CType(objRow.FindControl("CT"), AjaxControlToolkit.CascadingDropDown)
        Dim dsObject As ObjectDataSource
        dsObject = CType(objRow.Cells(1).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
        Dim AccountProjectTaskId As Integer = dsObject.SelectParameters("AccountProjectTaskId").DefaultValue
        dsObject = CType(objRow.Cells(1).FindControl("dsAccountProjectsObject"), ObjectDataSource)
        Dim AccountProjectId As Integer = dsObject.SelectParameters("AccountProjectId").DefaultValue
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet & "," & AccountProjectTaskId & "," & DBUtilities.GetSessionAccountId & "," & AccountProjectId & "," & DBUtilities.GetShowAdditionalTaskInformationType
    End Sub
    Protected Sub GridView1_Disposed(sender As Object, e As System.EventArgs) Handles GridView1.Disposed

    End Sub

    Public Sub SetTaskValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        objDropdown = CType(Row.Cells(1).FindControl("PT"), DropDownList)
        dsObject = CType(Row.Cells(0).FindControl("dsAccountProjectTasksObject"), ObjectDataSource)
        If Not objDropdown Is Nothing Then
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectTaskId")) Then
                dataValue = DataBinder.Eval(Row.DataItem, "AccountProjectTaskId")
                dsObject.SelectParameters("AccountProjectTaskId").DefaultValue = dataValue
                ''objDropdown.DataBind()
                objDropdown.SelectedValue = dataValue
            End If
        End If
        MyCascading = CType(Row.Cells(1).FindControl("CT"), AjaxControlToolkit.CascadingDropDown)
        MyCascading.SelectedValue = dataValue
        MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & LocaleUtilitiesBLL.IsShowCompletedTasksInTimeSheet & "," & dataValue & "," & DBUtilities.GetSessionAccountId & "," & DataBinder.Eval(Row.DataItem, "AccountProjectId") & "," & DBUtilities.GetShowAdditionalTaskInformationType
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dataValue As Object
            Dim objDropdown As DropDownList
            Dim dsObject As ObjectDataSource
            Dim MyCascading As AjaxControlToolkit.CascadingDropDown
            Me.SetClientValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, e.Row)
            Me.SetProjectValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, e.Row)
            Me.SetTaskValueOnRowDataBound(objDropdown, dsObject, dataValue, MyCascading, e.Row)
        End If
    End Sub
    Public Sub SetClientValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        If DBUtilities.GetShowClientInTimesheet = True Then
            'objDropdown = CType(Row.Cells(1).FindControl("C"), DropDownList)
            'If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountClientId")) Then
            'objDropdown.SelectedValue = DataBinder.Eval(Row.DataItem, "AccountClientId")
            'End If
        End If
    End Sub
    Public Sub SetProjectValueOnRowDataBound(ByVal objDropdown As DropDownList, ByVal dsObject As ObjectDataSource, ByVal dataValue As Object, ByVal MyCascading As AjaxControlToolkit.CascadingDropDown, ByVal Row As GridViewRow)
        objDropdown = CType(Row.Cells(0).FindControl("P"), DropDownList)
        dsObject = CType(Row.Cells(0).FindControl("dsAccountProjectsObject"), ObjectDataSource)
        If Not objDropdown Is Nothing Then
            If Not IsDBNull(DataBinder.Eval(Row.DataItem, "AccountProjectId")) Then
                dataValue = DataBinder.Eval(Row.DataItem, "AccountProjectId")
                dsObject.SelectParameters("AccountProjectId").DefaultValue = dataValue
                objDropdown.SelectedValue = dataValue
                MyCascading = CType(Row.Cells(1).FindControl("CP"), AjaxControlToolkit.CascadingDropDown)
                MyCascading.SelectedValue = dataValue
                MyCascading.Category = DBUtilities.GetSessionAccountEmployeeId & "," & dataValue & "," & False & "," & DBUtilities.GetSessionAccountId & "," & 2 & "," & LocaleUtilitiesBLL.IsShowCompletedProjectsInTimeSheet & "," & DBUtilities.GetShowAdditionalProjectInformationType
            End If
            
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
    Dim IsUpdate As Boolean
    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        Dim bll As New AccountEmployeeTimeEntryTemplate
        Dim WeekViewBll As New AccountEmployeeTimeEntryBLL
        Dim row As GridViewRow
        Try
            If IsUpdate <> True Then
                For Each row In Me.GridView1.Rows
                    If Me.GridView1.DataKeys(row.RowIndex)("AccountEmployeeTimeEntryTemplateId") = System.Guid.Empty Then
                        If CType(row.FindControl("P"), DropDownList).SelectedValue <> "" Then
                            bll.AddAccountEmployeeTimeEntryTemplate(DBUtilities.GetSessionAccountEmployeeId, CType(row.FindControl("P"), DropDownList).SelectedValue, CType(row.FindControl("PT"), DropDownList).SelectedValue, DBUtilities.GetSessionAccountId)
                        End If
                    ElseIf Me.GridView1.DataKeys(row.RowIndex)("AccountEmployeeTimeEntryTemplateId") <> System.Guid.Empty And CType(row.FindControl("P"), DropDownList).SelectedValue <> "" Then
                        bll.UpdateAccountEmployeeTimeEntryTemplate(Me.GridView1.DataKeys(row.RowIndex).Item(0), DBUtilities.GetSessionAccountEmployeeId, CType(row.FindControl("P"), DropDownList).SelectedValue, CType(row.FindControl("PT"), DropDownList).SelectedValue, DBUtilities.GetSessionAccountId)
                    ElseIf Me.GridView1.DataKeys(row.RowIndex)("AccountEmployeeTimeEntryTemplateId") <> System.Guid.Empty And CType(row.FindControl("P"), DropDownList).SelectedValue = "" Then
                        bll.DeleteAccountEmployeeTimeEntryTemplate(Me.GridView1.DataKeys(row.RowIndex)("AccountEmployeeTimeEntryTemplateId"))
                    End If
                Next
                IsUpdate = True
            End If
        Catch ex As Exception
            Throw ex

        End Try
        Response.Redirect("~/Employee/AccountEmployeeTimeEntryPeriodView.aspx", False)
    End Sub
End Class