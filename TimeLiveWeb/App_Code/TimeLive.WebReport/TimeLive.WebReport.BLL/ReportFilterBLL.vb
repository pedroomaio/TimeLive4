Imports dsReportFilterSourceTableAdapters

<System.ComponentModel.DataObject()> _
Public Class ReportFilterBLL

    Private _EmployeeFilterTableAdapter As New EmployeeFilterTableAdapter
    Private _DepartmentFilterTableAdapter As New DepartmentFilterTableAdapter
    Private _ProjectFilterTableAdapter As New ProjectFilterTableAdapter
    Private _LocationFilterTableAdapter As New LocationFilterTableAdapter
    Private _ClientFilterTableAdapter As New ClientFilterTableAdapter
    Private _ProjectTaskFilterTableAdapter As New ProjectTaskFilterTableAdapter
    Private _ExpenseFilterTableAdapter As New ExpenseFilterTableAdapter
    Private _ExpenseTypeFilterTableAdapter As New ExpenseTypeFilterTableAdapter
    Private _RoleFilterTableAdapter As New RoleFilterTableAdapter
    Private _StatusFilterTableAdapter As New StatusFilterTableAdapter
    Private _CurrencyFilterTableAdapter As New CurrencyFilterTableAdapter
    Private _TaskTypeFilterTableAdapter As New TaskTypeFilterTableAdapter
    Private _PriorityFilterTableAdapter As New PriorityFilterTableAdapter
    Private _ApprovedByTimeEntryFilterTableAdapter As New ApprovedByTimeEntryFilterTableAdapter
    Private _ApprovedByExpenseFilterTableAdapter As New ApprovedByExpenseFilterTableAdapter
    Private _ProjectTypeFilterTableAdapter As New ProjectTypeFilterTableAdapter
    Private _TimeOffTypeFilterTableAdapter As New TimeOffTypeFilterTableAdapter
    Private _TimeOffPolicyFilterTableAdapter As New TimeOffPolicyFilterTableAdapter
    Private _WorkTypeFilterTableAdapter As New WorkTypeFilterTableAdapter
    Private _CostCenterFilterTableAdapter As New CostCenterFilterTableAdapter

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedEmployee() As dsReportFilterSource.EmployeeFilterDataTable
        Return _EmployeeFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllEmployees() As dsReportFilterSource.EmployeeFilterDataTable
        Return _EmployeeFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllDepartments() As dsReportFilterSource.DepartmentFilterDataTable
        Return _DepartmentFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignProjects() As dsReportFilterSource.ProjectFilterDataTable
        Return _ProjectFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllProjects() As dsReportFilterSource.ProjectFilterDataTable
        Return _ProjectFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllLocation() As dsReportFilterSource.LocationFilterDataTable
        Return _LocationFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountClientByAccountIdAndAccountEmployeeId(ByVal AccountEmployeeId As String) As dsReportFilterSource.ClientFilterDataTable
        Return _ClientFilterTableAdapter.GetDataByAccountIdAndAccountEmployeeId(DBUtilities.GetSessionAccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountClientByAccountId(ByVal AccountEmployeeId As String) As dsReportFilterSource.ClientFilterDataTable
        Return _ClientFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllProjectTask() As dsReportFilterSource.ProjectTaskFilterDataTable
        Return _ProjectTaskFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllExpense() As dsReportFilterSource.ExpenseFilterDataTable
        Return _ExpenseFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllExpenseType() As dsReportFilterSource.ExpenseTypeFilterDataTable
        Return _ExpenseTypeFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllRoles() As dsReportFilterSource.RoleFilterDataTable
        Return _RoleFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllProjectStatus() As dsReportFilterSource.StatusFilterDataTable
        Return _StatusFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId, 3)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllCurrencies() As dsReportFilterSource.CurrencyFilterDataTable
        Return _CurrencyFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllTaskType() As dsReportFilterSource.TaskTypeFilterDataTable
        Return _TaskTypeFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllTaskStatus() As dsReportFilterSource.StatusFilterDataTable
        Return _StatusFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId, 4)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllPriority() As dsReportFilterSource.PriorityFilterDataTable
        Return _PriorityFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEmployeesByAccountId(ByVal AccountId As Integer, ByVal ApprovedByEmployeeId As Integer) As dsReportFilterSource.ApprovedByTimeEntryFilterDataTable
        Return _ApprovedByTimeEntryFilterTableAdapter.GetDataByAccountId(AccountId, ApprovedByEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovedByEmployeesByApprovedByEmployeeId() As dsReportFilterSource.ApprovedByTimeEntryFilterDataTable
        Return _ApprovedByTimeEntryFilterTableAdapter.GetDataByEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalProjectByAccountId(ByVal AccountId As Integer, ByVal ApprovedByEmployeeId As Integer) As dsReportFilterSource.ApprovedByTimeEntryFilterDataTable
        Return _ApprovedByTimeEntryFilterTableAdapter.GetDataByAccountIdForProject(AccountId, ApprovedByEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalClientByAccountId(ByVal AccountId As Integer, ByVal ApprovedByEmployeeId As Integer) As dsReportFilterSource.ApprovedByTimeEntryFilterDataTable
        Return _ApprovedByTimeEntryFilterTableAdapter.GetDataByAccountIdForClient(AccountId, ApprovedByEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEmployeesByAccountIdForExpense(ByVal AccountId As Integer, ByVal ApprovedByEmployeeId As Integer) As dsReportFilterSource.ApprovedByExpenseFilterDataTable
        Return _ApprovedByExpenseFilterTableAdapter.GetDataByAccountId(AccountId, ApprovedByEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalClientByAccountIdForExpense(ByVal AccountId As Integer, ByVal ApprovedByEmployeeId As Integer) As dsReportFilterSource.ApprovedByExpenseFilterDataTable
        Return _ApprovedByExpenseFilterTableAdapter.GetDataByAccountIdForClient(AccountId, ApprovedByEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalProjectByAccountIdForExpense(ByVal AccountId As Integer, ByVal ApprovedByEmployeeId As Integer) As dsReportFilterSource.ApprovedByExpenseFilterDataTable
        Return _ApprovedByExpenseFilterTableAdapter.GetDataByAccountIdForProject(AccountId, ApprovedByEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
  Public Function GetApprovalEmployeesByAccountIdForExpenseApprovedBy(ByVal AccountId As Integer, ByVal ApprovedByEmployeeId As Integer) As dsReportFilterSource.ApprovedByExpenseFilterDataTable
        Return _ApprovedByExpenseFilterTableAdapter.GetDataByAccountIdForApprovalEmployees(AccountId, ApprovedByEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetApprovalEmployeesByAccountIdForTimeEntryApprovedBy(ByVal AccountId As Integer, ByVal ApprovedByEmployeeId As Integer) As dsReportFilterSource.ApprovedByTimeEntryFilterDataTable
        Return _ApprovedByTimeEntryFilterTableAdapter.GetDataByAccountIdForApprovalEmployees(AccountId, ApprovedByEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllProjectTypes() As dsReportFilterSource.ProjectTypeFilterDataTable
        Return _ProjectTypeFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
  Public Function GetAllTimeOffTypes() As dsReportFilterSource.TimeOffTypeFilterDataTable
        Return _TimeOffTypeFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllTimeOffPolicy() As dsReportFilterSource.TimeOffPolicyFilterDataTable
        Return _TimeOffPolicyFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllWorkType() As dsReportFilterSource.WorkTypeFilterDataTable
        Return _WorkTypeFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAllCostCenter() As dsReportFilterSource.CostCenterFilterDataTable
        Return _CostCenterFilterTableAdapter.GetDataByAccountId(DBUtilities.GetSessionAccountId)
    End Function
End Class

