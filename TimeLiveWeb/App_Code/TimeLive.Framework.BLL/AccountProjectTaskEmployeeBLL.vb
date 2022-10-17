Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountProjectTaskEmployeeBLL

    Private _AccountProjectTaskEmployeeTableAdapter As AccountProjectTaskEmployeeTableAdapter = Nothing
    Private _vueAccountProjectTaskEmployeeTableAdapterFullJoin As vueAccountProjectTaskEmployeeForFullJoinTableAdapter = Nothing
    Private _vueAccountProjectTaskEmployeeForTaskTeamTableAdapter As vueAccountProjectTaskEmployeeForTaskTeamTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As AccountProjectTaskEmployeeTableAdapter
        Get
            If _AccountProjectTaskEmployeeTableAdapter Is Nothing Then
                _AccountProjectTaskEmployeeTableAdapter = New AccountProjectTaskEmployeeTableAdapter()
            End If

            Return _AccountProjectTaskEmployeeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property FullJoinAdapter() As vueAccountProjectTaskEmployeeForFullJoinTableAdapter
        Get
            If _vueAccountProjectTaskEmployeeTableAdapterFullJoin Is Nothing Then
                _vueAccountProjectTaskEmployeeTableAdapterFullJoin = New vueAccountProjectTaskEmployeeForFullJoinTableAdapter()
            End If

            Return _vueAccountProjectTaskEmployeeTableAdapterFullJoin
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskEmployees() As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskEmployeesForSelection(ByVal AccountProjectTaskId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable
        Dim _vueAccountProjectTaskEmployeeTableAdapter As New vueAccountProjectTaskEmployeeTableAdapter
        Return _vueAccountProjectTaskEmployeeTableAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId, AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAssignedAccountProjectTaskEmployees(ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal IsSelected As Boolean) As TimeLiveDataSet.vueAccountProjectTaskEmployeeForTaskTeamDataTable
        Dim _vueAccountProjectTaskEmployeeForTaskTeamTableAdapter As New vueAccountProjectTaskEmployeeForTaskTeamTableAdapter
        If IsSelected = False Then
            'GetAssignedAccountProjectTaskEmployees = _vueAccountProjectTaskEmployeeForTaskTeamTableAdapter.GetDataByAccountProjectIdandAccountProjectTaskId(AccountProjectId, AccountProjectTaskId)
            GetAssignedAccountProjectTaskEmployees = _vueAccountProjectTaskEmployeeForTaskTeamTableAdapter.GetDataByAccountProjectIdandAccountProjectTaskIdForIsNotSelected(AccountProjectId, AccountProjectTaskId)
        Else
            GetAssignedAccountProjectTaskEmployees = _vueAccountProjectTaskEmployeeForTaskTeamTableAdapter.GetDataByAccountProjectIdandAccountProjectTaskIdIsSelected(AccountProjectId, AccountProjectTaskId)
        End If
        'UIUtilities.FixTableForNoRecords(GetAssignedAccountProjectTaskEmployees)
        Return GetAssignedAccountProjectTaskEmployees
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskEmployeesByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable
        Return Adapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskEmployeesByEmployeeIdAndTaskIds(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable
        Dim _vueAccountProjectTaskEmployeeTableAdapter As New vueAccountProjectTaskEmployeeTableAdapter
        Return _vueAccountProjectTaskEmployeeTableAdapter.GetDataByAccountEmployeeIdAndTaskIds(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskEmployeesByvueAccountProjectTaskId(ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable
        Dim _vueAccountProjectTaskEmployeeTableAdapter As New vueAccountProjectTaskEmployeeTableAdapter
        Return _vueAccountProjectTaskEmployeeTableAdapter.GetDataByvueAccountProjectTaskId(AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskEmployeeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable
        Dim _vueAccountProjectTaskEmployeeTableAdapter As New vueAccountProjectTaskEmployeeTableAdapter
        Return _vueAccountProjectTaskEmployeeTableAdapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskEmployeeFullJoinByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectTaskEmployeeForFullJoinDataTable
        Return FullJoinAdapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskEmployeeFullJoinByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.vueAccountProjectTaskEmployeeForFullJoinDataTable
        Return FullJoinAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskByAccountEmployeeIdandAccountProjectTaskId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectTaskId As Integer) As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable
        Return Adapter.GetDataByAccountEmployeeIdandAccountProjectTaskId(AccountEmployeeId, AccountProjectTaskId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTaskEmployeeByAccountEmployeeIdandAccountProjectId(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer) As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable
        Dim _vueAccountProjectTaskEmployeeTableAdapter As New vueAccountProjectTaskEmployeeTableAdapter
        Return _vueAccountProjectTaskEmployeeTableAdapter.GetDataByAccountEmployeeIdAndAccountProjectId(DBUtilities.GetSessionAccountId, AccountEmployeeId, AccountProjectId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProjectTaskEmployee( _
                        ByVal AccountId As Integer, ByVal AccountProjectId As Integer, _
                        ByVal AccountProjectTaskId As Integer, ByVal AccountEmployeeId As Integer, _
                        AllocationUnits As Decimal) As Boolean
        ' Create a new ProductRow instance
        _AccountProjectTaskEmployeeTableAdapter = New AccountProjectTaskEmployeeTableAdapter
        If Me.GetAccountProjectTaskByAccountEmployeeIdandAccountProjectTaskId(AccountEmployeeId, AccountProjectTaskId).Rows.Count > 0 Then
            Return False
        End If
        Dim AccountProjectTaskEmployees As New TimeLiveDataSet.AccountProjectTaskEmployeeDataTable
        Dim AccountProjectTaskEmployee As TimeLiveDataSet.AccountProjectTaskEmployeeRow = AccountProjectTaskEmployees.NewAccountProjectTaskEmployeeRow

        With AccountProjectTaskEmployee
            .AccountId = AccountId
            .AccountProjectTaskId = AccountProjectTaskId
            .AccountEmployeeId = AccountEmployeeId
            .AllocationUnits = AllocationUnits
        End With

        AccountProjectTaskEmployees.AddAccountProjectTaskEmployeeRow(AccountProjectTaskEmployee)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountProjectTaskEmployees)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProjectTaskEmployee( _
                        ByVal AccountProjectTaskEmployeeId As Integer, AllocationUnits As Decimal) As Boolean

        _AccountProjectTaskEmployeeTableAdapter = New AccountProjectTaskEmployeeTableAdapter

        Dim AccountProjectTaskEmployees As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable = Adapter.GetDataByAccountProjectTaskEmployeeId(AccountProjectTaskEmployeeId)
        Dim AccountProjectTaskEmployee As TimeLiveDataSet.AccountProjectTaskEmployeeRow = AccountProjectTaskEmployees.Rows(0)

        With AccountProjectTaskEmployee
            .AllocationUnits = AllocationUnits
        End With

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountProjectTaskEmployees)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectTaskEmployeeId(ByVal Original_AccountProjectTaskEmployeeId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountProjectTaskEmployeeId)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectTaskEmployeeByEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As Boolean

        Dim rowsAffected As Integer = Adapter.DeleteTaskEMployeeByAccountIdAndAccountEmployeeId(AccountId, AccountEmployeeId)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub InsertAccountProjectTaskEmployeeByProjectTaskTemplate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer)
        Adapter.InsertAccountProjectTaskEmployeesByProjectTaskTemplate(AccountId, AccountProjectId)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
     Public Function AddAccountProjectTaskEmployeeFromImportExport( _
     ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer) As Boolean
        Me.AddAccountProjectTaskEmployee(AccountId, AccountProjectId, AccountProjectTaskId, AccountEmployeeId, 100)
    End Function
End Class