Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Tasks
    Inherits System.Web.Services.WebService
    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()>
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")>
    Public Function AddTask(ByVal objTask As TaskMe) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTasks() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TaskArrayList As New ArrayList
        Dim objTask As New TaskMe
        Dim TaskBLL As New AccountProjectTaskBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtTask As DataTable = TaskBLL.GetTasksForWSByAccountId(AccountId)
        Dim drTask As DataRow
        For Each drTask In dtTask.Rows
            objTask = New TaskMe
            With objTask
                .TaskName = drTask("TaskName")
                .Code = drTask("ProjectCode")
                .ItemParent = drTask("ItemParent")
                .JobItemParent = drTask("JobItemParent")
                .JobParent = drTask("JobParent")
            End With
            TaskArrayList.Add(objTask)
        Next
        Return TaskArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetAssignedTasksForMobile(ByVal AccountProjectId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TaskArrayList As New ArrayList
        Dim objTask As New TaskMe
        Dim TaskBLL As New AccountProjectTaskBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeID
        Dim dtTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = TaskBLL.GetAssignedAccountProjectTasksByAccountProjectIdForMobile(AccountId, AccountProjectId, AccountEmployeeId)
        Dim drTask As TimeLiveDataSet.vueAccountProjectTaskRow
        For Each drTask In dtTask.Rows
            objTask = New TaskMe
            With objTask
                .TaskName = drTask.TaskName
                .Code = drTask.AccountProjectId
                .TaskID = drTask.AccountProjectTaskId
            End With
            TaskArrayList.Add(objTask)
        Next
        Return TaskArrayList
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetAssignedTasks(ByVal AccountProjectId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TaskArrayList As New ArrayList
        Dim objTask As New TaskMe
        Dim TaskBLL As New AccountProjectTaskBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeID
        Dim dtTask As DataTable = TaskBLL.GetAssignedAccountProjectTasksByAccountProjectId(AccountProjectId, AccountEmployeeId)
        Dim drTask As DataRow
        For Each drTask In dtTask.Rows
            objTask = New TaskMe
            With objTask
                .TaskName = drTask("TaskName")
                .Code = drTask("ProjectCode")
                .ItemParent = drTask("ItemParent")
                .JobItemParent = drTask("JobItemParent")
                .JobParent = drTask("JobParent")
                .TaskID = drTask("AccountProjectTaskId")
            End With
            TaskArrayList.Add(objTask)
        Next
        Return TaskArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub InsertTask(ByVal AccountProjectId As Integer, ByVal ParentAccountProjectTaskid As Integer, _
    ByVal TaskName As String, ByVal TaskDescription As String, ByVal AccountTaskTypeId As Integer, _
    ByVal Duration As Double, ByVal DurationUnit As String, ByVal CompletedPercent As Integer, _
    ByVal Completed As Boolean, ByVal DeadlineDate As Date, ByVal TaskStatusId As Integer, _
    ByVal AccountPriorityId As Integer, ByVal AccountProjectMilestoneId As Integer, _
    ByVal IsForAllEmployees As Boolean, ByVal IsParentTask As Boolean, ByVal CreatedOn As Date, _
    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As Date, ByVal ModifiedByEmployeeId As Integer, _
    ByVal EstimatedCost As Double, ByVal EstimatedTimeSpent As Double, ByVal EstimatedTimeSpentUnit As String, _
    ByVal IsBillable As Boolean, ByVal TaskCode As String, ByVal AccountBillingRateId As Integer, _
    ByVal IsForAllProjectTask As Boolean, ByVal EstimatedCurrencyId As Integer)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TaskBLL As New AccountProjectTaskBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = TaskBLL.GetAccountProjectTaskByAccountIdAndTaskName(AccountId, TaskName)
        If dtTask.Rows.Count > 0 Then
        Else
            TaskBLL.AddAccountProjectTask(AccountProjectId, ParentAccountProjectTaskid, TaskName, TaskDescription, _
            AccountTaskTypeId, Duration, DurationUnit, CompletedPercent, Completed, DeadlineDate, TaskStatusId, _
            AccountPriorityId, AccountProjectMilestoneId, IsForAllEmployees, IsParentTask, CreatedOn, _
            CreatedByEmployeeId, ModifiedOn, ModifiedByEmployeeId, EstimatedCost, EstimatedTimeSpent, _
            EstimatedTimeSpentUnit, IsBillable, TaskCode, AccountBillingRateId, IsForAllProjectTask, _
            EstimatedCurrencyId, Now.Date, True)
        End If
    End Sub
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTaskId(ByVal TaskName As String) As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objTask As New AccountProjectTaskBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nTaskId As Integer
        Try
            nTaskId = objTask.GetAccountProjectTaskByAccountIdAndTaskName(AccountId, TaskName).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Task " & """" & TaskName & """" & " not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nTaskId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetParentTaskId(ByVal ParentTaskName As String) As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objParentTask As New AccountProjectTaskBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nParentTaskId As Integer
        Try
            nParentTaskId = objParentTask.GetAccountProjectTaskByAccountIdAndTaskName(AccountId, ParentTaskName).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Parent Task " & """" & ParentTaskName & """" & " not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nParentTaskId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTaskNameByTaskId(ByVal AccountProjectTaskId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim TaskArrayList As New ArrayList
        Dim objTask As New TaskMe
        Dim TaskBLL As New AccountProjectTaskBLL
        Dim dtTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = TaskBLL.GetAccountProjectTaskByvueAccountProjectTaskId(AccountProjectTaskId)
        Dim drTask As TimeLiveDataSet.vueAccountProjectTaskRow
        For Each drTask In dtTask.Rows
            objTask = New TaskMe
            With objTask
                .TaskName = drTask.TaskName
                .Code = drTask.ProjectCode
                .TaskID = drTask.AccountProjectTaskId
            End With
            TaskArrayList.Add(objTask)
        Next
        Return TaskArrayList
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub UpdateIsParentInTask(ByVal AccountProjectTaskId As Integer, ByVal IsParent As Boolean)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objParentTask As New AccountProjectTaskBLL
        objParentTask.UpdateIsParentInAccountProjectTask(AccountProjectTaskId, IsParent)
    End Sub
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTaskTypeId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objTaskType As New AccountTaskTypeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nTaskTypeId As Integer = objTaskType.GetAccountTaskTypesByAccountId(AccountId).Rows(0).Item(0)
        Return nTaskTypeId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTaskStatusId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objTaskStatus As New AccountStatusBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nTaskStatusId As Integer = objTaskStatus.GetAccountsStatusForTaskByAccountStatusId(AccountId, 0).Rows(0).Item(0)
        Return nTaskStatusId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTaskPriorityId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objTaskPriority As New AccountPriorityBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nTaskPriorityId As Integer = objTaskPriority.GetAccountPrioritiesByAccountIdAndAccountPriorityId(AccountId, 0).Rows(0).Item(0)
        Return nTaskPriorityId
    End Function
End Class
