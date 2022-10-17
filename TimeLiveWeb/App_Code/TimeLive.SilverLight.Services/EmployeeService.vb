Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.Data.SqlClient
Imports System.Data

<ServiceContract(Namespace:="")>
<SilverLightFaultBehavior>
<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)>
Public Class EmployeeService

    <OperationContract()>
    Public Sub DoWork()
        ' Add your operation implementation here
    End Sub

    <OperationContract()> _
    Public Function GetEmployees(AccountProjectId As Integer, AccountProjectTaskId As Integer) As List(Of ProjectTaskEmployee)
        Dim EmployeeList As New List(Of ProjectTaskEmployee)
        Dim objEmployee As New ProjectTaskEmployee
        Dim EmployeeBLL As New AccountProjectEmployeeBLL
        Dim EmployeeWorkingBLL As New AccountWorkingDayBLL
        Dim dtEmployee As TimeLiveDataSet.vueAccountProjectEmployeFullJoinDataTable = EmployeeBLL.GetAccountProjectEmployeesByAccountProjectIdAsView(AccountProjectId, AccountProjectTaskId)
        Dim drEmployee As TimeLiveDataSet.vueAccountProjectEmployeFullJoinRow
        For Each drEmployee In dtEmployee.Rows
            Dim dtEmployeeWorking As TimeLiveDataSet.vueAccountEmployeeWorkingDaysDataTable = EmployeeWorkingBLL.GetWorkingDaysByAccountEmployeeId(drEmployee.AccountEmployeeId)
            Dim drEmployeeWorking As TimeLiveDataSet.vueAccountEmployeeWorkingDaysRow
            Dim dtEmployeeHoliday As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable = New AccountHolidayTypeBLL().GetvueAccountEmployeeHolidayTypesWithDetailByAccountEmployeeId(drEmployee.AccountEmployeeId)
            Dim drEmployeeHoliday As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailRow
            objEmployee = New ProjectTaskEmployee
            With objEmployee
                .ID = drEmployee.AccountEmployeeId
                .Name = drEmployee.FullName
                For Each drEmployeeWorking In dtEmployeeWorking.Rows
                    .WorkingDays.Add(drEmployeeWorking.WorkingDay)
                    .HoursPerDay = drEmployeeWorking.HoursPerDay
                Next
                For Each drEmployeeHoliday In dtEmployeeHoliday.Rows
                    .HolidayDays.Add(drEmployeeHoliday.HolidayDate.Date)
                Next
            End With
            EmployeeList.Add(objEmployee)
        Next
        Return EmployeeList
    End Function
    <OperationContract()> _
    Public Function GetProjectGanttviewEmployees(AccountProjectTaskId As Integer) As List(Of ProjectTaskEmployee)
        Dim EmployeeList As New List(Of ProjectTaskEmployee)
        Dim objEmployee As New ProjectTaskEmployee
        Dim EmployeeBLL As New AccountProjectEmployeeBLL
        Dim EmployeeWorkingBLL As New AccountWorkingDayBLL
        Dim dtEmployee As TimeLiveDataSet.vueAccountProjectEmployeFullJoinDataTable = EmployeeBLL.GetAccountProjectGanttEmployeesByAccountIdAsView(DBUtilities.GetSessionAccountId, AccountProjectTaskId)
        Dim drEmployee As TimeLiveDataSet.vueAccountProjectEmployeFullJoinRow
        For Each drEmployee In dtEmployee.Rows
            Dim dtEmployeeWorking As TimeLiveDataSet.vueAccountEmployeeWorkingDaysDataTable = EmployeeWorkingBLL.GetWorkingDaysByAccountEmployeeId(drEmployee.AccountEmployeeId)
            Dim drEmployeeWorking As TimeLiveDataSet.vueAccountEmployeeWorkingDaysRow
            Dim dtEmployeeHoliday As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable = New AccountHolidayTypeBLL().GetvueAccountEmployeeHolidayTypesWithDetailByAccountEmployeeId(drEmployee.AccountEmployeeId)
            Dim drEmployeeHoliday As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailRow
            objEmployee = New ProjectTaskEmployee
            With objEmployee
                .ID = drEmployee.AccountEmployeeId
                .Name = drEmployee.FullName
                For Each drEmployeeWorking In dtEmployeeWorking.Rows
                    .WorkingDays.Add(drEmployeeWorking.WorkingDay)
                    .HoursPerDay = drEmployeeWorking.HoursPerDay
                Next
                For Each drEmployeeHoliday In dtEmployeeHoliday.Rows
                    .HolidayDays.Add(drEmployeeHoliday.HolidayDate.Date)
                Next
            End With
            EmployeeList.Add(objEmployee)
        Next
        Return EmployeeList
    End Function
    <OperationContract()> _
    Public Function AddAccountProjectTaskEmployee( _
                      ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal AccountEmployeeId As Integer, AllocationUnits As Decimal) As Boolean
        Dim ProjectTaskEmployeeBLL As New AccountProjectTaskEmployeeBLL
        Dim dt As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable = ProjectTaskEmployeeBLL.GetAccountProjectTaskByAccountEmployeeIdandAccountProjectTaskId(AccountEmployeeId, AccountProjectTaskId)
        Dim dr As TimeLiveDataSet.AccountProjectTaskEmployeeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            ProjectTaskEmployeeBLL.UpdateAccountProjectTaskEmployee(dr.AccountProjectTaskEmployeeId, AllocationUnits)
        Else
            ProjectTaskEmployeeBLL.AddAccountProjectTaskEmployee(DBUtilities.GetSessionAccountId, AccountProjectId, AccountProjectTaskId, AccountEmployeeId, AllocationUnits)
        End If
    End Function
    <OperationContract()> _
    Public Function DeleteAccountProjectTaskEmployee(AccountProjectTaskId As Integer, AccountEmployeeId As Integer)
        Dim ProjectTaskEmployeeBLL As New AccountProjectTaskEmployeeBLL
        Dim dt As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable = ProjectTaskEmployeeBLL.GetAccountProjectTaskByAccountEmployeeIdandAccountProjectTaskId(AccountEmployeeId, AccountProjectTaskId)
        If dt.Rows.Count > 0 Then
            ProjectTaskEmployeeBLL.DeleteAccountProjectTaskEmployeeId(dt.Rows(0)("AccountProjectTaskEmployeeId"))
        End If
    End Function
End Class
