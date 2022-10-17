Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Configuration

<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<System.Web.Script.Services.ScriptService()>
Public Class ProjectService
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()>
    Public Function GetAccountProjectTasks(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim CategoryValue() As String = Split(category, ",")


        Dim objRow As TimeLiveDataSet.AccountProjectTaskTimesheetRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable

        objTable = objAccountProjectTaskBLL.GetAssignedProjectTasksFromvueAccountProjectTask(Value, CategoryValue(0), IIf(CategoryValue(2) = "", Nothing, CategoryValue(2)), CategoryValue(3), CBool(CategoryValue(1)))

        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
        Next

        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function

    <WebMethod()>
    Public Function GetAccountProjectsByClient(ByVal knownCategoryValues As String, ByVal category As String, ByVal contextKey As String) As AjaxControlToolkit.CascadingDropDownNameValue()
        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim CategoryValue() As String = Split(category, ",")

        Dim objRow As TimeLiveDataSet.vueAccountProjectsRow
        Dim objAccountProjectBLL As New AccountProjectBLL
        Dim objTable As TimeLiveDataSet.vueAccountProjectsDataTable

        'If CategoryValue(4) <> Value Then
        '    CategoryValue(1) = ""
        'End If

        Dim SessionAccountId As Integer = CategoryValue(3)
        Dim ShowClientInTimesheet = CategoryValue(7)
        Dim ShowProjectInTimesheet = CategoryValue(8)


        ''If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") <> "Yes" Then
        If ShowProjectInTimesheet = False And ShowClientInTimesheet = True Then
            objTable = objAccountProjectBLL.GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient(IIf(CategoryValue(1) = "", Nothing, CategoryValue(1)), CategoryValue(0), CategoryValue(5), False, SessionAccountId)

        Else
            If CBool(CategoryValue(2)) = True Then
                If contextKey <> "isTimeOff" Then
                    objTable = objAccountProjectBLL.GetAssignedAccountProjectsByAccountEmployeeIdAndAccountClientIdForProjects(IIf(CategoryValue(1) = "", Nothing, CategoryValue(1)), CategoryValue(0), Value, CategoryValue(5), SessionAccountId)
                Else
                    objTable = objAccountProjectBLL.GetTimeOffInternalProjects()

                End If

            Else
                If contextKey <> "isTimeOff" Then
                    objTable = objAccountProjectBLL.GetAssignedAccountProjectsByAccountEmployeeIdAndAccountProjectIdForIsDeletedClient(IIf(CategoryValue(1) = "", Nothing, CategoryValue(1)), CategoryValue(0), CategoryValue(5), False, SessionAccountId)
                Else
                    objTable = objAccountProjectBLL.GetTimeOffInternalProjects()
                End If

            End If

        End If

        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        For Each objRow In objTable.Rows
            ''If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") = "Yes" Then
            If ShowProjectInTimesheet = False And ShowClientInTimesheet = True Then
                values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(GetFullProjectNameInTimeSheet(objRow, CategoryValue(6)), objRow.AccountProjectId, True))
            Else
                values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(GetFullProjectNameInTimeSheet(objRow, CategoryValue(6)), objRow.AccountProjectId))
            End If
        Next

        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray
    End Function

    <WebMethod()>
    Public Function GetAccountProjectTasksForReport(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)
        Dim CategoryValue() As String = Split(category, ",")



        Dim objRow As TimeLiveDataSet.vueAccountProjectTaskRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.vueAccountProjectTaskDataTable


        objTable = objAccountProjectTaskBLL.GetAssignedAccountProjectTasksByAccountProjectIdForReports(Value, CategoryValue(0), IIf(CategoryValue(1) = "", Nothing, CategoryValue(1)))


        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
        Next


        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function
    <WebMethod()>
    Public Function GetAccountProjectTasksByAccountProjectIdForReport(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)
        Dim CategoryValue() As String = Split(category, ",")



        Dim objRow As TimeLiveDataSet.vueAccountProjectTaskRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.vueAccountProjectTaskDataTable


        objTable = objAccountProjectTaskBLL.GetAssignedAccountProjectTasksByAccountProjectIdAndAccountIdForReports(Value, CategoryValue(0))


        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
        Next


        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function
    <WebMethod()> Public Function GetAccountProjectMileStones(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()
        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)
        Dim CategoryValue() As String = Split(category, ",")
        If Value <> "0" Then
            Dim objRow As TimeLiveDataSet.AccountProjectMilestoneRow
            Dim objAccountProjectMilestoneBLL As New AccountProjectMilestoneBLL
            Dim objTable As TimeLiveDataSet.AccountProjectMilestoneDataTable
            If Value <> "" Then
                objTable = objAccountProjectMilestoneBLL.GetAccountProjectMilestonesByAccountProjectId(Value, True)
            End If
            For Each objRow In objTable.Rows
                If CategoryValue(0) <> "" Then
                    If CategoryValue(0) = objRow.AccountProjectMilestoneId Then
                        values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.MilestoneDescription, objRow.AccountProjectMilestoneId, True))
                    Else
                        values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.MilestoneDescription, objRow.AccountProjectMilestoneId))
                    End If
                Else
                    values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.MilestoneDescription, objRow.AccountProjectMilestoneId))
                End If
            Next
        End If
        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Return values.ToArray
    End Function

    <WebMethod()>
    Public Function GetParentAccountProjectTasks(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim CategoryValue() As String = Split(category, ",")

        Dim objRow As TimeLiveDataSet.AccountProjectTaskRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.AccountProjectTaskDataTable

        objTable = objAccountProjectTaskBLL.GetParentAccountProjectTasksByAccountProjectId(Value, CategoryValue(0))
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
        Next

        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function
    <WebMethod()>
    Public Function GetAccountProjectTasksInTimeSheet(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim Id() As String = Split(Value, ":")
        Dim AccountProjectId As Integer

        Dim CategoryValue() As String = Split(category, ",")
        Dim ShowClientInTimesheet = CategoryValue(6)
        Dim ShowProjectInTimesheet = CategoryValue(7)

        ''If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") = "Yes" Then
        If Id(0) <> "" Then
            If ShowProjectInTimesheet = False And ShowClientInTimesheet = True Then
                AccountProjectId = Id(0)
            Else
                AccountProjectId = Id(1)
            End If
        End If
        Dim objRow As TimeLiveDataSet.AccountProjectTaskTimesheetRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
        If ShowProjectInTimesheet = True Then
            If CategoryValue(4) <> AccountProjectId Then
                CategoryValue(2) = ""
            End If
        End If
        ''If System.Configuration.ConfigurationManager.AppSettings("DisableSchedule1") = "Yes" Then
        If ShowProjectInTimesheet = False And ShowClientInTimesheet = True Then
            objTable = objAccountProjectTaskBLL.GetAssignedProjectTasksFromvueAccountProjectTaskForCLient(AccountProjectId, CategoryValue(0), IIf(CategoryValue(2) = "", Nothing, CategoryValue(2)), CategoryValue(3), CBool(CategoryValue(1)))
        ElseIf ShowClientInTimesheet = False And ShowProjectInTimesheet = False Then
            objTable = objAccountProjectTaskBLL.GetAssignedProjectTasksFromvueAccountProjectTaskForTimesheetTaskDropdown(CategoryValue(0), IIf(CategoryValue(2) = "", Nothing, CategoryValue(2)), CategoryValue(3), CBool(CategoryValue(1)))
        Else
            objTable = objAccountProjectTaskBLL.GetAssignedProjectTasksFromvueAccountProjectTask(AccountProjectId, CategoryValue(0), IIf(CategoryValue(2) = "", Nothing, CategoryValue(2)), CategoryValue(3), CBool(CategoryValue(1)))
        End If
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        For Each objRow In objTable.Rows
            If System.Configuration.ConfigurationManager.AppSettings("TimeSheetTaskSelected") = "Yes" Then
                values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(GetFullTaskNameInTimeSheet(objRow, CategoryValue(5)), objRow.AccountProjectTaskId, True))
            Else
                values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(GetFullTaskNameInTimeSheet(objRow, CategoryValue(5)), objRow.AccountProjectTaskId))
            End If
        Next
        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Return values.ToArray
    End Function
    <WebMethod()>
    Public Function GetAccountProjectTasksInExpensesheet(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim Id() As String = Split(Value, ":")
        Dim AccountProjectId As Integer

        Dim CategoryValue() As String = Split(category, ",")
        AccountProjectId = Id(1)

        Dim objRow As TimeLiveDataSet.AccountProjectTaskTimesheetRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable

        objTable = objAccountProjectTaskBLL.GetAssignedProjectTasksFromvueAccountProjectTask(AccountProjectId, CategoryValue(0), IIf(CategoryValue(2) = "", Nothing, CategoryValue(2)), CategoryValue(3), CBool(CategoryValue(1)))
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)
        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(GetFullTaskNameInTimeSheet(objRow, CategoryValue(4)), objRow.AccountProjectTaskId))
        Next
        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Return values.ToArray
    End Function
    Public Function GetFullTaskNameInTimeSheet(ByVal objrow As TimeLiveDataSet.AccountProjectTaskTimesheetRow, ByVal TaskTypeId As Integer)
        Dim TaskName As String = objrow.TaskName
        Dim AdditionalTask As String = New AccountProjectTaskBLL().GetShowAdditionalTaskInformationValue(TaskTypeId, IIf(IsDBNull(objrow.Item("ParentAccountProjectTaskId")), 0, objrow.Item("ParentAccountProjectTaskId")), IIf(IsDBNull(objrow.Item("TaskCode")), "", objrow.Item("TaskCode")))
        If Not AdditionalTask = "" Then
            Return TaskName & " (" & AdditionalTask & ")"
        Else
            Return TaskName
        End If
    End Function
    Public Function GetFullProjectNameInTimeSheet(ByVal objrow As TimeLiveDataSet.vueAccountProjectsRow, ByVal TaskTypeId As Integer)
        Dim ProjectName As String = objrow.ProjectName
        Dim AdditionalProject As String = New AccountProjectBLL().GetShowAdditionalProjectInformationValue(TaskTypeId, IIf(IsDBNull(objrow.Item("AccountProjectId")), 0, objrow.Item("AccountProjectId")), IIf(IsDBNull(objrow.Item("ProjectCode")), "", objrow.Item("ProjectCode")))
        If Not AdditionalProject = "" Then
            Return ProjectName & " (" & AdditionalProject & ")"
        Else
            Return ProjectName
        End If
    End Function
    <WebMethod()>
    Public Function GetAccountProjectTasksForReportByTimeSheet(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)
        Dim CategoryValue() As String = Split(category, ",")
        If Value <> "0" Then
            Dim objRow As TimeLiveDataSet.AccountProjectTaskTimesheetRow
            Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL
            Dim objTable As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
            If Value <> "" Then
                objTable = objAccountProjectTaskBLL.GetAssignedProjectTasksFromvueAccountProjectTask(Value, CategoryValue(0), IIf(CategoryValue(2) = "", Nothing, CategoryValue(2)), CategoryValue(3), CBool(CategoryValue(1)))
            End If
            For Each objRow In objTable.Rows
                If CategoryValue(2) <> "" Then
                    If CategoryValue(2) = objRow.AccountProjectTaskId Then
                        If Value <> 0 Then
                            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId, True))
                        End If
                    Else
                        values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
                    End If
                Else
                    values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
                End If
            Next
        End If
        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Return values.ToArray
    End Function
    <WebMethod()>
    Public Function GetAccountProjectTasksInTimeSheetTimeCardView(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")

        Dim objRow As TimeLiveDataSet.AccountProjectTaskRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.AccountProjectTaskDataTable

        objTable = objAccountProjectTaskBLL.GetAssignedAccountProjectTasksByAccountProjectId(Value, category)
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
        Next

        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function
    <WebMethod()>
    Public Function GetAccountPartyContacts(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")


        Dim objRow As TimeLiveDataSet.AccountPartyContactRow
        Dim objAccountPartyContactBLL As New AccountPartyContactBLL

        Dim objTable As TimeLiveDataSet.AccountPartyContactDataTable

        objTable = objAccountPartyContactBLL.GetAccountPartyContactsByAccountPartyId(Value)
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.FirstName + " " + objRow.LastName, objRow.AccountPartyContactId))
        Next

        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function
    <WebMethod()>
    Public Function GetAccountProject(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")


        Dim objRow As TimeLiveDataSet.vueAccountProjectsRow
        Dim objAccountProjectBLL As New AccountProjectBLL

        Dim objTable As TimeLiveDataSet.vueAccountProjectsDataTable

        objTable = objAccountProjectBLL.GetAccountClientByAccountProjectId(Value)
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.ProjectName, objRow.AccountProjectId))
        Next

        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function
    <WebMethod()>
    Public Function GetAccountPartyDepartments(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")

        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        If Value <> "0" Then

            Dim objRow As TimeLiveDataSet.AccountPartyDepartmentRow
            Dim objAccountPartydepartmentBLL As New AccountPartyDepartmentBLL

            Dim objTable As TimeLiveDataSet.AccountPartyDepartmentDataTable

            objTable = objAccountPartydepartmentBLL.GetDataByAccountPartyId(Value)


            For Each objRow In objTable.Rows
                values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.PartyDepartmentCode, objRow.AccountPartyDepartmentId))
            Next
        End If
        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function
    <WebMethod()>
    Public Function GetAccountProjectTasksForCustomizedReport(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim CategoryValue() As String = Split(category, ",")
        Dim AccountReportId As New Guid(CategoryValue(4))

        Dim objRow As TimeLiveDataSet.AccountProjectTaskTimesheetRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable

        objTable = objAccountProjectTaskBLL.GetAssignedProjectTasksFromvueAccountProjectTaskForCustomizedReport(CategoryValue(3), CategoryValue(0), Value, IIf(CategoryValue(2) = "", Nothing, CategoryValue(2)), CBool(CategoryValue(1)), AccountReportId, CategoryValue(5))

        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        For Each objRow In objTable.Rows
            If Value <> -1 Then
                values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
            End If
        Next
        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Return values.ToArray
    End Function
    <WebMethod()>
    Public Function GetAccountProjectForInvoice(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")


        Dim objRow As TimeLiveDataSet.vueAccountProjectsRow
        Dim objAccountProjectBLL As New AccountProjectBLL

        Dim objTable As TimeLiveDataSet.vueAccountProjectsDataTable

        objTable = objAccountProjectBLL.GetAccountClientByAccountProjectIdandIsDisabled(Value, 0)
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)

        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.ProjectName, objRow.AccountProjectId))
        Next

        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function
    <WebMethod()>
    Public Function GetAccountProjectTasksForInvoice(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()
        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)
        Dim CategoryValue() As String = Split(category, ",")

        Dim objRow As TimeLiveDataSet.vueAccountProjectTaskRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.vueAccountProjectTaskDataTable

        If CategoryValue(1) <> "" Then
            objTable = objAccountProjectTaskBLL.GetAssignedAccountProjectTasksByAccountProjectIdAndAccountIdForInvoice(CategoryValue(0), Value, CategoryValue(1))
        Else
            objTable = objAccountProjectTaskBLL.GetAssignedAccountProjectTasksByAccountProjectIdAndAccountIdForInvoice(CategoryValue(0), Value)
        End If

        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
        Next

        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray
    End Function
    <WebMethod()>
    Public Function GetParentTasksForInvoice(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim AccountProjectId As Integer
        Dim Value As String = Replace(knownCategoryValues, ";", "")
        Dim NewValue() As String = Split(Value, "Project:")
        If NewValue.Length = 2 Then
            AccountProjectId = NewValue(1)
        End If
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)
        'Dim CategoryValue() As String = Split(category, ",")

        Dim objRow As TimeLiveDataSet.vueAccountProjectTaskRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.vueAccountProjectTaskDataTable


        objTable = objAccountProjectTaskBLL.GetParentTasksByAccountProjectIdForInvoice(AccountProjectId)


        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
        Next


        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function
    <WebMethod()>
    Public Function GetParentAccountProjectTasksForGridView(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()

        Dim Value As String = Replace(Replace(knownCategoryValues, ";", ""), "undefined:", "")
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)
        Dim CategoryValue() As String = Split(category, ",")



        Dim objRow As TimeLiveDataSet.vueAccountProjectTaskRow
        Dim objAccountProjectTaskBLL As New AccountProjectTaskBLL

        Dim objTable As TimeLiveDataSet.vueAccountProjectTaskDataTable


        objTable = objAccountProjectTaskBLL.GetAssignedParentAccountProjectTasksByAccountProjectIdAndAccountIdForGridView(Value)


        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.TaskName, objRow.AccountProjectTaskId))
        Next


        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)

        Return values.ToArray

    End Function

    <WebMethod()>
    Public Function GetAccountTimeOffTypesInTimesheet(ByVal knownCategoryValues As String, ByVal category As String) As AjaxControlToolkit.CascadingDropDownNameValue()
        Dim values As New Generic.List(Of AjaxControlToolkit.CascadingDropDownNameValue)
        Dim objAccountTimeOffType As New AccountTimeOffTypeBLL
        Dim objTable As AccountTimeOffType.VueAccountEmployeeTimeOffTypeIsIncludeDataTable
        Dim objRow As AccountTimeOffType.VueAccountEmployeeTimeOffTypeIsIncludeRow
        Dim CategoryValue() As String = Split(knownCategoryValues, ",")
        If category = "isRequired" Then
            objTable = objAccountTimeOffType.GetDataByAccountIdAccountEmployeeIdandIsTimeOffRequestRequired(CategoryValue(0), CategoryValue(3), True, Guid.Empty)
        Else
            objTable = objAccountTimeOffType.GetDataByAccountIdAccountEmployeeIdandIsTimeOffRequestRequired(CategoryValue(0), CategoryValue(3), False, Guid.Empty)
        End If


        For Each objRow In objTable.Rows
            values.Add(New AjaxControlToolkit.CascadingDropDownNameValue(objRow.BriefExplanation, objRow.AccountTimeOffTypeId.ToString()))
        Next
        Me.Context.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Return values.ToArray()
    End Function

End Class