Imports Microsoft.VisualBasic
Imports AccountEmployeeTimeOffTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeTimeOffBLL
    Dim EmployeeArray As New ArrayList
    Private _AccountEmployeeTimeOffTableAdapter As AccountEmployeeTimeOffTableAdapter = Nothing
    Private _vueAccountEmployeeTimeOffAuditTableAdapter As New vueAccountEmployeeTimeOffAuditTableAdapter
    Private _vueAccountEmployeeTimeOffTableAdapter As New vueAccountEmployeeTimeOffTableAdapter
    Private _AccountEmployeeTimeOffAuditTableAdapter As New AccountEmployeeTimeOffAuditTableAdapter
    
    Protected ReadOnly Property AdapterAudit() As AccountEmployeeTimeOffAuditTableAdapter
        Get
            If _AccountEmployeeTimeOffAuditTableAdapter Is Nothing Then
                _AccountEmployeeTimeOffAuditTableAdapter = New AccountEmployeeTimeOffAuditTableAdapter()
            End If

            Return _AccountEmployeeTimeOffAuditTableAdapter
        End Get
    End Property
    Protected ReadOnly Property Adapter() As AccountEmployeeTimeOffTableAdapter
        Get
            If _AccountEmployeeTimeOffTableAdapter Is Nothing Then
                _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter()
            End If

            Return _AccountEmployeeTimeOffTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountEmployeeTimeOffTableAdapter
        Get
            If _vueAccountEmployeeTimeOffTableAdapter Is Nothing Then
                _vueAccountEmployeeTimeOffTableAdapter = New vueAccountEmployeeTimeOffTableAdapter()
            End If

            Return _vueAccountEmployeeTimeOffTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapterAudit() As vueAccountEmployeeTimeOffAuditTableAdapter
        Get
            If _vueAccountEmployeeTimeOffAuditTableAdapter Is Nothing Then
                _vueAccountEmployeeTimeOffAuditTableAdapter = New vueAccountEmployeeTimeOffAuditTableAdapter()
            End If

            Return _vueAccountEmployeeTimeOffAuditTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeOffAudit() As AccountEmployeeTimeOff.AccountEmployeeTimeOffAuditDataTable
        GetAccountEmployeeTimeOffAudit = AdapterAudit.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateAvailableWthAdditionalHoursAtAnniversaryDate(ByVal Available As Double, ByVal PolicyExecutionType As String, ByVal PolicyEarnResetAutidAction As String, ByVal AuditSource As String, ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid) As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable
        Adapter.UpdateAdditionalHoursinAvailabe(Available, PolicyExecutionType, PolicyEarnResetAutidAction, AuditSource, AccountEmployeeId, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateAvailableAndCarryForwardForCarryForwardExpiryDate(ByVal Available As Double, ByVal LastCarryForwardExpiryDate As Date, ByVal PolicyExecutionType As String, ByVal PolicyEarnResetAutidAction As String, ByVal AuditSource As String, ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid) As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable
        Adapter.UpdateAdditionalHoursinAvailabeandLastCarryForwardExpiryDate(Available, LastCarryForwardExpiryDate, PolicyExecutionType, PolicyEarnResetAutidAction, AuditSource, AccountEmployeeId, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeOffAuditByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeOff.AccountEmployeeTimeOffAuditDataTable
        GetAccountEmployeeTimeOffAuditByAccountEmployeeId = AdapterAudit.GetAccountEmployeeTimeOffAuditByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid) As AccountEmployeeTimeOff.AccountEmployeeTimeOffAuditDataTable
        If AccountTimeOffTypeId <> System.Guid.Empty Then
            GetAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId = AdapterAudit.GetDataByAccountTimeOffTypeIdAndAccountEmployeeId(AccountEmployeeId, AccountTimeOffTypeId)
        Else
            GetAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId = AdapterAudit.GetAccountEmployeeTimeOffAuditByAccountEmployeeId(AccountEmployeeId)
        End If
        UIUtilities.FixTableForNoRecords(GetAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId)
        Return GetAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid) As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffAuditDataTable
        If AccountTimeOffTypeId <> System.Guid.Empty Then
            GetvueAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId = vueAdapterAudit.GetvueAccountEmployeeTimeOffAuditDataByAccountEmployeTimeOffTypeIdandEmployeeId(AccountEmployeeId, AccountTimeOffTypeId)
        Else
            GetvueAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId = vueAdapterAudit.GetvueAccountEmployeeTimeOffAuditDataByAccountEmployeeId(AccountEmployeeId)
        End If
        UIUtilities.FixTableForNoRecords(GetvueAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId)
        Return GetvueAccountEmployeeTimeOffAuditByAccountEmployeeIdandAccountTimeOffTypeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountEmployeeTimeOffId(ByVal AccountEmployeeTimeOffId As Guid) As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable
        GetDataByAccountEmployeeTimeOffId = Adapter.GetDataByAccountEmployeeTimeOffId(AccountEmployeeTimeOffId)
    End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    'Public Function GetvueDataByAccountEmployeeTimeOffId(ByVal AccountTimeOffTypeId As Guid) As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffDataTable
    '    vueAdapter.GetvueDataByAccountEmployeeTimeOffId(AccountTimeOffTypeId)
    'End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueDataByAccountEmployeeTimeOffId(ByVal AccountTimeOffTypeId As Guid) As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffDataTable
        Dim vueEmployee As New vueAccountEmployeeTimeOffTableAdapter
        GetvueDataByAccountEmployeeTimeOffId = vueEmployee.GetvueDataByAccountEmployeeTimeOffId(AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeOffByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable
        GetAccountEmployeeTimeOffByAccountEmployeeId = Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeOffByAccountEmployeeIdAndTimeOffTypeId(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid) As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable
        Return Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTimeOffByEmployeeIdAndTimeOffTypeId(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid) As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable
        Return Adapter.GetDataByAccountEmployeeIdAndAccountTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountEmployeeTimeOffByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffDataTable
        Dim vueEmployee As New vueAccountEmployeeTimeOffTableAdapter
        GetvueAccountEmployeeTimeOffByAccountEmployeeId = vueEmployee.GetDataByAccountEmployeeId(DBUtilities.GetSessionAccountId, AccountEmployeeId)
        'UIUtilities.FixTableForNoRecords(GetvueAccountEmployeeTimeOffByAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountEmployeeTimeOffByAccountEmployeeIdAndRequestRequired(ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffDataTable
        Dim vueEmployee As New vueAccountEmployeeTimeOffTableAdapter
        GetvueAccountEmployeeTimeOffByAccountEmployeeIdAndRequestRequired = vueEmployee.GetDataByAccountEmployeIdAndRequestRequired(DBUtilities.GetSessionAccountId, AccountEmployeeId)
        'UIUtilities.FixTableForNoRecords(GetvueAccountEmployeeTimeOffByAccountEmployeeId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetvueAccountEmployeeTimeOffByAccountIdAndAccountEmployeeId(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffDataTable
        Dim vueEmployee As New vueAccountEmployeeTimeOffTableAdapter
        GetvueAccountEmployeeTimeOffByAccountIdAndAccountEmployeeId = vueEmployee.GetDataByAccountEmployeeId(AccountId, AccountEmployeeId)
        'UIUtilities.FixTableForNoRecords(GetvueAccountEmployeeTimeOffByAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateAccountTimeOffTypeId(ByVal AccountTimeOffTypeId As Guid, ByVal IsDisabled As Boolean) As Integer
        Return vueAdapter.UpdateAccountEmployeeTimeOffTypeId(IsDisabled, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesByEachYear() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForEachYear
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForAdditionalHoursByHiredDate() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataByHiredDate()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesByEachWeeks() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForEachWeek
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesByEachMonth() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForEachMonth
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesFirstTime() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataByLastEarnedDateIsNull
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesFirstTimeOnlyForMonthAnniversary() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataByLastEarnedDateIsNullAndForMonthAnniversaryEarned
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesFirstTimeOnlyForAnniversary() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataByLastEarnedDateIsNullAndForYearAnniversaryEarned
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimeOffTypeByCarryForwardExpiryDate() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataByCarryForwardExpiryDate
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesByEachYearAnniversaryDay() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForEachYearAnniversaryDay
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesByEachMonthAnniversaryDay() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForEachMonthAnniversaryDay
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesByAccountEmployeeId(ByVal AccountEmployeeID As Integer) As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeID)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForResetFirstTimeMonthAnniversary() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForResetFirstTimeMonthAnniversary
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForResetFirstTimeYearAnniversary() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForResetFirstTimeYearAnniversary
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdatePoliciesByAccountEmployeeIdAndAccountTimeOffTypeId(ByVal AccountEmployeeID As Integer, ByVal AccountTimeOffTypeId As Guid) As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataByAccountEmployeeIdandAccountTimeOffTypeId(AccountEmployeeID, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdateResetPolicyByEachMonth() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForResetEveryMonth
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdateResetPolicyByEveryYear() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForResetEveryYear
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdateResetPolicyByEveryYearAnniversaryDay() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForResetEveryYearAnniversary
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForUpdateResetPolicyByEveryMonthAnniversaryDay() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataForResetEveryMonthAnniversary
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeesForResetFirstTime() As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim _vueAccountEmployeeTimeOffLastScheduleTableAdapter As New vueAccountEmployeeTimeOffLastScheduleTableAdapter
        Return _vueAccountEmployeeTimeOffLastScheduleTableAdapter.GetDataByLastResetDateIsNull
    End Function
    Public Function IsEmployeeTimeOffExists(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid) As Boolean
        If Me.Adapter.GetDataByAccountEmployeeIdAndAccountTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeTimeOff( _
                ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal Earned As Double, _
                ByVal Consume As Double, ByVal Available As Double, ByVal LastEarnedDate As Date, ByVal CarryForward As Double, ByVal AccountTimeOffPolicyId As Guid, _
                ByVal PolicyExecutionType As String, ByVal PolicyEarnResetAutidAction As String, ByVal AuditSource As String) As Boolean

        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter

        Dim dtTimeOff As New AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.NewAccountEmployeeTimeOffRow

        With drTimeOff
            .AccountEmployeeTimeOffId = System.Guid.NewGuid
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .AccountTimeOffTypeId = AccountTimeOffTypeId
            .Earned = Earned
            .Consume = Consume
            .Available = Available
            .CarryForward = CarryForward
            ' .LastEarnedDate = LastEarnedDate
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .CreatedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .AccountTimeOffPolicyId = AccountTimeOffPolicyId
            .PolicyExecutionType = PolicyExecutionType
            .PolicyEarnResetAutidAction = PolicyEarnResetAutidAction
            .AuditSource = AuditSource
        End With
        dtTimeOff.AddAccountEmployeeTimeOffRow(drTimeOff)
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)>
    Public Function UpdateEmployeeTimeOffFields(
            ByVal AccountEmployeeTimeOffId As Guid, ByVal FieldValue As Double, ByVal FieldName As String, ByVal PolicyExecutionType As String, ByVal PolicyEarnResetAutidAction As String, ByVal AuditSource As String) As Boolean

        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter

        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByAccountEmployeeTimeOffId(AccountEmployeeTimeOffId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)

        With drTimeOff
            If FieldName = "Availabe" Then
                .Available = FieldValue
            ElseIf FieldName = "Earned" Then
                .Earned = FieldValue
            ElseIf FieldName = "CarryForward" Then
                .CarryForward = FieldValue
            End If
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .PolicyExecutionType = PolicyExecutionType
            .PolicyEarnResetAutidAction = PolicyEarnResetAutidAction
            .AuditSource = AuditSource
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)>
    Public Function UpdateEmployeeTimeOffLastResetDate(
            ByVal AccountEmployeeTimeOffId As Guid, ByVal LastResetDate As Date, ByVal PolicyExecutionType As String, ByVal PolicyEarnResetAutidAction As String, ByVal AuditSource As String) As Boolean


        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter

        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByAccountEmployeeTimeOffId(AccountEmployeeTimeOffId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)

        With drTimeOff
            .LastResetDate = LastResetDate
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .PolicyExecutionType = PolicyExecutionType
            .PolicyEarnResetAutidAction = PolicyEarnResetAutidAction
            .AuditSource = AuditSource
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)>
    Public Function UpdateEmployeeTimeOffLastEarnedDate( _
            ByVal AccountEmployeeTimeOffId As Guid, ByVal LastEarnedDate As Date, ByVal PolicyExecutionType As String, ByVal PolicyEarnResetAutidAction As String, ByVal AuditSource As String) As Boolean

        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter

        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByAccountEmployeeTimeOffId(AccountEmployeeTimeOffId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)

        With drTimeOff
            .LastEarnedDate = LastEarnedDate
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .PolicyExecutionType = PolicyExecutionType
            .PolicyEarnResetAutidAction = PolicyEarnResetAutidAction
            .AuditSource = AuditSource
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)

        Return rowsAffected = 1
    End Function
    Public Sub UpdatePolicyEarnResetAutidAction(ByVal AccountEmployeeId As Integer, ByVal PolicyEarnResetAutidAction As String, ByVal AccountTimeOffTypeId As Guid)
        Adapter.UpdatePolicyEarnResetAutidActionbyAccountEmployeeID(PolicyEarnResetAutidAction, AccountEmployeeId, AccountTimeOffTypeId)
    End Sub
    Public Sub InsertDefaultForNewTimeOffType(ByVal AccountTimeOffTypeId As Guid, ByVal AccountId As Integer, ByVal PolicyEarnResetAutidAction As String, ByVal PolicyExecutionType As String, ByVal AuditSource As String)
        Adapter.InsertEmployeeTimeOffForNewTimeOffType(AccountTimeOffTypeId, PolicyExecutionType, PolicyEarnResetAutidAction, AuditSource, AccountId)
    End Sub
    Public Sub SetPolicies(Optional ByVal PolicyExecutionType As String = "", Optional ByVal AuditSource As String = "")
        
        Dim ResetAuditAction = ExecuteScheduledResetTimeOffPolicy(PolicyExecutionType, AuditSource)
        ExecuteScheduledOffDaysProcedure(0, PolicyExecutionType, ResetAuditAction, AuditSource)
        GetUpdateAvailableandCarryForwardForCarryForwardExpiryDate(PolicyExecutionType, AuditSource)

    End Sub
    Public Function CheckEffectiveDate(ByVal dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow) As Boolean
        If Not IsDBNull(dr.Item("EffectiveDate")) Then
            If Now.Date >= dr.EffectiveDate.Date Then
                Return True
            End If
        ElseIf IsDBNull(dr.Item("EffectiveDate")) Then
            Return True
        End If
        Return False
    End Function
    Public Function CheckCarryForwardExpiryDate(ByVal dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow) As Boolean
        If Not IsDBNull(dr.Item("CarryForwardExpiryDate")) Then
            If Now.Date >= dr.CarryForwardExpiryDate.Date Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Function CheckLastCarryForwardExpiryDate(ByVal dr As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow) As Boolean
        If Not IsDBNull(dr.Item("LastCarryForwardExpiryDate")) Then
            If Now.Date <> dr.LastCarryForwardExpiryDate.Date Then
                Return True
            End If
        ElseIf IsDBNull(dr.Item("LastCarryForwardExpiryDate")) Then
            Return True
        End If
        Return False
    End Function
    Public Sub AddEmployeesInArrayForUpdatePolicy(AccountEmployeeId As Integer)
        If Not EmployeeArray.Contains(AccountEmployeeId) Then
            EmployeeArray.Add(AccountEmployeeId)
        End If
    End Sub
    Public Function ExecuteScheduledResetTimeOffPolicy(Optional ByVal PolicyExecutionType As String = "", Optional ByVal AuditSource As String = "") As String
        'PolicyEarnResetAutidAction
        Dim ResetAutidAction As String = ""
        Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow

        dt = Me.GetEmployeesForResetFirstTime
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) Then
                    Dim Available As Double
                    Available = GetResetHoursForAvailableHours(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.ResetToHours, dr.AccountTimeOffPolicyId)
                    ResetAutidAction = "Reset First Time"
                    UpdateConsumedHoursInEmployeeTimeOff(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, 0, dr.AccountTimeOffPolicyId, Available, PolicyExecutionType, ResetAutidAction, AuditSource)
                    AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)

                    '''''EachWeek'''''
                    If dr.SystemEarnPeriodId = New Guid("2986AF3C-CD0B-475A-AE46-5AAAA17C7FB7") Then
                        EarnedAtPoliciesByEachWeeks(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, PolicyExecutionType, ResetAutidAction, AuditSource)
                        '''''EachYear'''''
                    ElseIf dr.SystemEarnPeriodId = New Guid("86C995DC-262E-4585-BA1C-E7505BEE647A") Then
                        EarnedAtPoliciesByEachYear(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, PolicyExecutionType, ResetAutidAction, AuditSource)
                        '''''EachWMonth'''''
                    ElseIf dr.SystemEarnPeriodId = New Guid("564F54F2-3D71-46E8-8C99-F07C8AA65DC0") Then
                        EarnedAtPoliciesByEachMonth(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, PolicyExecutionType, ResetAutidAction, AuditSource)

                    End If
                End If
            Next
        End If

        dt = Me.GetEmployeesForResetFirstTimeYearAnniversary
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) Then
                    Dim Available As Double = GetResetHoursForAvailableHours(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.ResetToHours, dr.AccountTimeOffPolicyId)
                    ResetAutidAction = "Reset First Time Year Anniversary"
                    UpdateConsumedHoursInEmployeeTimeOff(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, 0, dr.AccountTimeOffPolicyId, Available, PolicyExecutionType, ResetAutidAction, AuditSource)
                    AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                    EarnedAtPoliciesByEachYearAnniversaryDay(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, PolicyExecutionType, ResetAutidAction, AuditSource)
                End If
            Next
        End If
        dt = Me.GetEmployeesForResetFirstTimeMonthAnniversary
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) Then
                    'If Not IsDBNull(dr.Item("LastResetDate")) Then
                    Dim Available As Double = GetResetHoursForAvailableHours(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.ResetToHours, dr.AccountTimeOffPolicyId)
                    ResetAutidAction = "Reset First Time Month Anniversary"
                    UpdateConsumedHoursInEmployeeTimeOff(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, 0, dr.AccountTimeOffPolicyId, Available, PolicyExecutionType, ResetAutidAction, AuditSource)
                    AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                    EarnedAtPoliciesByEachMonthAnniversaryDay(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, PolicyExecutionType, ResetAutidAction, AuditSource)
                End If
            Next
        End If
        dt = Me.GetEmployeesForUpdateResetPolicyByEachMonth
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) And Now.Date.Day >= dr.LastResetDate.Day Then
                    Dim Available As Double = GetResetHoursForAvailableHours(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.ResetToHours, dr.AccountTimeOffPolicyId)
                    ResetAutidAction = "Reset Each Month"
                    UpdateConsumedHoursInEmployeeTimeOff(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, 0, dr.AccountTimeOffPolicyId, Available, PolicyExecutionType, ResetAutidAction, AuditSource)
                    AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                    EarnedAtPoliciesByEachMonth(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, PolicyExecutionType, ResetAutidAction, AuditSource)
                End If

            Next
        End If
        dt = Me.GetEmployeesForUpdateResetPolicyByEveryYear
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) Then
                    Dim Available As Double = GetResetHoursForAvailableHours(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.ResetToHours, dr.AccountTimeOffPolicyId)
                    ResetAutidAction = "Reset Every Year"
                    UpdateConsumedHoursInEmployeeTimeOff(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, 0, dr.AccountTimeOffPolicyId, Available, PolicyExecutionType, ResetAutidAction, AuditSource)
                    AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                    EarnedAtPoliciesByEachYear(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, PolicyExecutionType, ResetAutidAction, AuditSource)
                End If
            Next
        End If
        dt = Me.GetEmployeesForUpdateResetPolicyByEveryYearAnniversaryDay
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) Then
                    If IIf(IsDBNull(dr.Item("LastResetDate")), Now.Date.AddDays(-1), dr.Item("LastResetDate")) < Now.Date Then
                        Dim Available As Double = GetResetHoursForAvailableHours(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.ResetToHours, dr.AccountTimeOffPolicyId)
                        ResetAutidAction = "Reset Year Anniversary Day"
                        UpdateConsumedHoursInEmployeeTimeOff(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, 0, dr.AccountTimeOffPolicyId, Available, PolicyExecutionType, ResetAutidAction, AuditSource)
                        AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                        EarnedAtPoliciesByEachYearAnniversaryDay(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, PolicyExecutionType, ResetAutidAction, AuditSource)
                    End If
                End If
            Next
        End If
        dt = Me.GetEmployeesForUpdateResetPolicyByEveryMonthAnniversaryDay
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) Then
                    If IIf(IsDBNull(dr.Item("LastResetDate")), Now.Date.AddDays(-1), dr.Item("LastResetDate")) < Now.Date Then
                        Dim Available As Double = GetResetHoursForAvailableHours(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.ResetToHours, dr.AccountTimeOffPolicyId)
                        ResetAutidAction = "Reset Month Anniversary Day"
                        UpdateConsumedHoursInEmployeeTimeOff(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, 0, dr.AccountTimeOffPolicyId, Available, PolicyExecutionType, ResetAutidAction, AuditSource)
                        AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                        EarnedAtPoliciesByEachMonthAnniversaryDay(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, PolicyExecutionType, ResetAutidAction, AuditSource)
                    End If
                End If
            Next
        End If
        Return ResetAutidAction
    End Function
    Public Function IsResetDateInclude(SystemResetToZeroTypeId As Guid, HiredDate As Date) As Boolean
        '''''''Anniversary Year'''''''''
        If SystemResetToZeroTypeId = New Guid("A356EFBF-340F-4AB9-8FDE-0344A8E4CB3D") Then
            If (HiredDate.Day = Now.Day) And (HiredDate.Month = Now.Month) Then
                Return True
            End If
            Return False
        End If
        '''''''Anniversary Month'''''''''
        If SystemResetToZeroTypeId = New Guid("8E7505FD-6329-4A39-8133-16E248F76E83") Then
            If HiredDate.Day = Now.Day Then
                Return True
            End If
            Return False
        End If

        If SystemResetToZeroTypeId = System.Guid.Empty Then
            Return False
        End If
        Return True
    End Function
    Public Sub EarnedAtPoliciesFirstTime(Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAutidAction As String = "", Optional ByVal AuditSource As String = "")
        Dim EarnedAutidAction As String = "Earned First Time"
        Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
        dt = Me.GetEmployeesForUpdatePoliciesFirstTime
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) Then
                    Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                    Dim available As Double = GetNewAvailableHours(IIf(IsDBNull(dr.Item("InitialSetToHours")), 0, dr.Item("InitialSetToHours")), dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                    available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                    available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                    If ResetAutidAction = "" Then
                        Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, IIf(IsDBNull(dr.Item("InitialSetToHours")), 0, dr.Item("InitialSetToHours")), available, PolicyExecutionType, EarnedAutidAction, AuditSource, Me.IsResetDateInclude(IIf(IsDBNull(dr.Item("SystemResetToZeroTypeId")), System.Guid.Empty, dr.Item("SystemResetToZeroTypeId")), dr.Item("HiredDate")), , False)
                    Else
                        Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, IIf(IsDBNull(dr.Item("InitialSetToHours")), 0, dr.Item("InitialSetToHours")), available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, Me.IsResetDateInclude(IIf(IsDBNull(dr.Item("SystemResetToZeroTypeId")), System.Guid.Empty, dr.Item("SystemResetToZeroTypeId")), dr.Item("HiredDate")), , False)
                    End If
                    AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                End If
            Next
        End If

    End Sub
    Public Sub EarnedAtPoliciesFirstTimeOnlyForYearAnniversary(Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAutidAction As String = "", Optional ByVal AuditSource As String = "")
        Dim EarnedAutidAction As String = "Earned First Time Year Anniversary"
        Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
        dt = Me.GetEmployeesForUpdatePoliciesFirstTimeOnlyForAnniversary
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) Then
                    Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                    Dim available As Double = GetNewAvailableHours(IIf(IsDBNull(dr.Item("InitialSetToHours")), 0, dr.Item("InitialSetToHours")), dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                    available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                    available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                    If ResetAutidAction = "" Then
                        Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, IIf(IsDBNull(dr.Item("InitialSetToHours")), 0, dr.Item("InitialSetToHours")), available, PolicyExecutionType, EarnedAutidAction, AuditSource, Me.IsResetDateInclude(IIf(IsDBNull(dr.Item("SystemResetToZeroTypeId")), System.Guid.Empty, dr.Item("SystemResetToZeroTypeId")), dr.Item("HiredDate")), , False)
                    Else
                        Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, IIf(IsDBNull(dr.Item("InitialSetToHours")), 0, dr.Item("InitialSetToHours")), available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, Me.IsResetDateInclude(IIf(IsDBNull(dr.Item("SystemResetToZeroTypeId")), System.Guid.Empty, dr.Item("SystemResetToZeroTypeId")), dr.Item("HiredDate")), , False)
                    End If
                    AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                End If
            Next
        End If

    End Sub
    Public Sub EarnedAtPoliciesFirstTimeOnlyForMonthAnniversary(Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAutidAction As String = "", Optional ByVal AuditSource As String = "")
        Dim EarnedAutidAction As String = "Earned First Time Month Anniversary"
        Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
        dt = Me.GetEmployeesForUpdatePoliciesFirstTimeOnlyForMonthAnniversary
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If CheckEffectiveDate(dr) Then

                    Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                    Dim available As Double = GetNewAvailableHours(IIf(IsDBNull(dr.Item("InitialSetToHours")), 0, dr.Item("InitialSetToHours")), dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                    available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                    available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                    If ResetAutidAction = "" Then
                        Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, IIf(IsDBNull(dr.Item("InitialSetToHours")), 0, dr.Item("InitialSetToHours")), available, PolicyExecutionType, EarnedAutidAction, AuditSource, Me.IsResetDateInclude(IIf(IsDBNull(dr.Item("SystemResetToZeroTypeId")), System.Guid.Empty, dr.Item("SystemResetToZeroTypeId")), dr.Item("HiredDate")), , False)
                    Else
                        Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, IIf(IsDBNull(dr.Item("InitialSetToHours")), 0, dr.Item("InitialSetToHours")), available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, Me.IsResetDateInclude(IIf(IsDBNull(dr.Item("SystemResetToZeroTypeId")), System.Guid.Empty, dr.Item("SystemResetToZeroTypeId")), dr.Item("HiredDate")), , False)
                    End If
                    AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                End If
            Next
        End If

    End Sub
    Public Sub EarnedAtPoliciesByEachYear(Optional ByVal AccountEmployeeId As Integer = 0, Optional ByVal AccountTimeOffTypeId As Guid = Nothing, Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAutidAction As String = "", Optional ByVal AuditSource As String = "")

        Dim EarnedAutidAction As String = "Earned Each Year"
        If AccountEmployeeId = 0 Then
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByEachYear
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    If CheckEffectiveDate(dr) Then

                        Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                        Dim EarnHours As Double = GetEarnHoursByTotalNoOfPolicyDays(dr.EarnHours, dr.TotalYears)
                        Dim available As Double = GetNewAvailableHours(EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                        available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                        available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                        If ResetAutidAction = "" Then
                            Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, EarnHours, available, PolicyExecutionType, EarnedAutidAction, AuditSource, , , False)
                        Else
                            Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , , False)
                        End If
                        AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                    End If
                Next
            End If
        Else
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByAccountEmployeeIdAndAccountTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId)
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows

                    Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                    Dim EarnHours As Double = dr.EarnHours
                    Dim available As Double = GetNewAvailableHours(EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                    available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                    available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                    Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , 0, True)

                Next
            End If
        End If

    End Sub
    Public Sub EarnedAtPoliciesByEachYearAnniversaryDay(Optional ByVal AccountEmployeeId As Integer = 0, Optional ByVal AccountTimeOffTypeId As Guid = Nothing, Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAutidAction As String = "", Optional ByVal AuditSource As String = "")

        Dim EarnedAutidAction As String = "Earned Each Year Anniversary Day"
        If AccountEmployeeId = 0 Then
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByEachYearAnniversaryDay
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    If CheckEffectiveDate(dr) Then
                        If IIf(IsDBNull(dr.Item("LastEarnedDate")), Now.Date.AddDays(-1), dr.Item("LastEarnedDate")) < Now.Date Then

                            Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                            'Dim EarnHours As Double = GetEarnHoursByTotalNoOfPolicyDays(dr.EarnHours, dr.TotalYears)
                            Dim available As Double = GetNewAvailableHours(dr.EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                            available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                            available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                            If ResetAutidAction = "" Then
                                Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, dr.EarnHours, available, PolicyExecutionType, EarnedAutidAction, AuditSource, , , False)
                            Else
                                Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, dr.EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , , False)
                            End If
                            AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                        End If
                    End If
                Next
            End If
        Else
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByAccountEmployeeIdAndAccountTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId)
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                    'Dim EarnHours As Double = GetEarnHoursByTotalNoOfPolicyDays(dr.EarnHours, dr.TotalYears)
                    Dim available As Double = GetNewAvailableHours(dr.EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                    available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                    available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                    Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, dr.EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , 0, True)

                Next
            End If
        End If

    End Sub
    Public Sub EarnedAtPoliciesByEachMonthAnniversaryDay(Optional ByVal AccountEmployeeId As Integer = 0, Optional ByVal AccountTimeOffTypeId As Guid = Nothing, Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAutidAction As String = "", Optional ByVal AuditSource As String = "")

        Dim EarnedAutidAction As String = "Earned Each Month Anniversary Day"
        If AccountEmployeeId = 0 Then
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByEachMonthAnniversaryDay
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    If CheckEffectiveDate(dr) Then
                        If IIf(IsDBNull(dr.Item("LastEarnedDate")), Now.Date.AddDays(-1), dr.Item("LastEarnedDate")) < Now.Date Then

                            Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                            'Dim EarnHours As Double = GetEarnHoursByTotalNoOfPolicyDays(dr.EarnHours, dr.TotalYears)
                            Dim available As Double = GetNewAvailableHours(dr.EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                            available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                            available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                            If ResetAutidAction = "" Then
                                Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, dr.EarnHours, available, PolicyExecutionType, EarnedAutidAction, AuditSource, , , False)
                            Else
                                Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, dr.EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , , False)
                            End If
                            AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)

                        End If
                    End If
                Next
            End If
        Else
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByAccountEmployeeIdAndAccountTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId)
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                    'Dim EarnHours As Double = GetEarnHoursByTotalNoOfPolicyDays(dr.EarnHours, dr.TotalYears)
                    Dim available As Double = GetNewAvailableHours(dr.EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                    available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                    available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                    Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, dr.EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , 0, True)

                Next
            End If
        End If
    End Sub
    Public Sub EarnedAtPoliciesByEachWeeks(Optional ByVal AccountEmployeeId As Integer = 0, Optional ByVal AccountTimeOffTypeId As Guid = Nothing, Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAutidAction As String = "", Optional ByVal AuditSource As String = "")

        Dim EarnedAutidAction As String = "Earned Each Week"
        If AccountEmployeeId = 0 Then
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByEachWeeks
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    If CheckEffectiveDate(dr) Then

                        Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                        Dim EarnHours As Double = GetEarnHoursByTotalNoOfPolicyDays(dr.EarnHours, dr.TotalWeeks)
                        Dim available As Double = GetNewAvailableHours(EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                        'If IsDBNull(dr.Item("InitialSetToHours") 
                        available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                        available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                        If ResetAutidAction = "" Then
                            Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, EarnHours, available, PolicyExecutionType, EarnedAutidAction, AuditSource, , , False)
                        Else
                            Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , , False)
                        End If
                        'dr.Item("PolicyExecutionType") = PolicyExecutionType
                        AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                    End If
                Next
            End If
        Else
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByAccountEmployeeIdAndAccountTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId)
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                    Dim EarnHours As Double = dr.EarnHours
                    Dim available As Double = GetNewAvailableHours(EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                    available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                    available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                    Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , 0, True)

                Next
            End If
        End If

    End Sub
    Public Sub EarnedAtPoliciesByEachMonth(Optional ByVal AccountEmployeeId As Integer = 0, Optional ByVal AccountTimeOffTypeId As Guid = Nothing, Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAutidAction As String = "", Optional ByVal AuditSource As String = "")

        Dim EarnedAutidAction As String = "Earned Each Month"
        If AccountEmployeeId = 0 Then
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByEachMonth
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    If CheckEffectiveDate(dr) Then

                        Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                        Dim EarnHours As Double = GetEarnHoursByTotalNoOfPolicyDays(dr.EarnHours, dr.TotalMonth)
                        Dim available As Double = GetNewAvailableHours(EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                        available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                        available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                        If ResetAutidAction = "" Then
                            Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, EarnHours, available, PolicyExecutionType, EarnedAutidAction, AuditSource, , , False)
                        Else
                            Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , , False)
                        End If

                        AddEmployeesInArrayForUpdatePolicy(dr.AccountEmployeeId)
                    End If
                Next
            End If
        Else
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForUpdatePoliciesByAccountEmployeeIdAndAccountTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId)
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                    Dim EarnHours As Double = dr.EarnHours
                    Dim available As Double = GetNewAvailableHours(EarnHours, dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward)
                    available = AdditionalHoursWithYearsCount(available, dr.AnniversaryYearsCount, dr.AdditionalHours)
                    available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, available)
                    Me.UpdatePolicyHourBySchecdule(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, CarryForward, EarnHours, available, PolicyExecutionType, ResetAutidAction & "-" & EarnedAutidAction, AuditSource, , 0, True)

                Next
            End If
        End If

    End Sub
    Public Sub ExecuteScheduledOffDaysProcedure(Optional ByVal AccountEmployeeId As Integer = 0, Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAuditAction As String = "", Optional ByVal AuditSource As String = "")
        Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow

        If AccountEmployeeId = 0 Then
            EarnedAtPoliciesFirstTime(PolicyExecutionType, ResetAuditAction, AuditSource)
            EarnedAtPoliciesFirstTimeOnlyForYearAnniversary(PolicyExecutionType, ResetAuditAction, AuditSource)
            EarnedAtPoliciesFirstTimeOnlyForMonthAnniversary(PolicyExecutionType, ResetAuditAction, AuditSource)
            EarnedAtPoliciesByEachYear(0, System.Guid.Empty, PolicyExecutionType, ResetAuditAction, AuditSource)
            EarnedAtPoliciesByEachYearAnniversaryDay(0, System.Guid.Empty, PolicyExecutionType, ResetAuditAction, AuditSource)
            EarnedAtPoliciesByEachMonthAnniversaryDay(0, System.Guid.Empty, PolicyExecutionType, ResetAuditAction, AuditSource)
            EarnedAtPoliciesByEachWeeks(0, System.Guid.Empty, PolicyExecutionType, ResetAuditAction, AuditSource)
            EarnedAtPoliciesByEachMonth(0, System.Guid.Empty, PolicyExecutionType, ResetAuditAction, AuditSource)
            EarnedAtPoliciesAdditionalHoursOnHiredDate(PolicyExecutionType, ResetAuditAction, AuditSource)
            'If AccountEmployees <> "" Then
            Me.UpdateEmployeeFieldsForTimeOff()
            'Me.UpdatePolicyIdByEmployeePolicyNone(AccountEmployeeId, System.Guid.Empty, System.Guid.Empty)
            'End If
        Else
            Me.SetResetPolicy(AccountEmployeeId)
            ResetTimeOffForNone(PolicyExecutionType, AuditSource, AccountEmployeeId)
        End If
    End Sub
    Public Sub ResetTimeOffForNone(ByVal PolicyExecutionType As String, ByVal AuditSource As String, ByVal AccountEmployeeId As Integer)
        'Adapter.ResetTimeOffForNone(PolicyExecutionType, ResetAutidAction, AuditSource, AccountEmployeeId)
        'Dim dtPolicy As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(AccountEmployeeId)
        'Dim drPolicy As AccountEmployee.AccountEmployeeRow
        Dim PolicyEarnResetAutidAction As String = "Reset None"
        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter
        Dim dtPolicy As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
        Dim drPolicy As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtPolicy.Rows(0)
        If dtPolicy.Rows.Count > 0 Then
            drPolicy = dtPolicy.Rows(0)
            If IsDBNull(drPolicy.Item("AccountTimeOffPolicyId")) Then
                For Each drPolicy In dtPolicy.Rows
                    drPolicy.Earned = 0
                    drPolicy.Consume = 0
                    drPolicy.Available = 0
                    drPolicy.Item("LastEarnedDate") = System.DBNull.Value
                    drPolicy.Item("LastResetDate") = System.DBNull.Value
                    drPolicy.CarryForward = 0
                    drPolicy.PolicyExecutionType = PolicyExecutionType
                    drPolicy.PolicyEarnResetAutidAction = PolicyEarnResetAutidAction
                    drPolicy.AuditSource = AuditSource
                Next
            End If
        End If
        Dim rowsAffected As Integer = Adapter.Update(dtPolicy)
    End Sub
    Public Sub UpdatePolicyIdByEmployeePolicyNone(ByVal AccountEmployeeId As Integer, ByVal PolicyExecutionType As String, ByVal AuditSource As String, ByVal PolicyEarnResetAutidAction As String)
        ''Adapter.UpdateAccountTimeOffPolicyIdForNone(PolicyExecutionType, ResetAutidAction, AuditSource, AccountEmployeeId)
        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow

        For Each drTimeOff In dtTimeOff.Rows
            drTimeOff.PolicyExecutionType = PolicyExecutionType
            drTimeOff.PolicyEarnResetAutidAction = PolicyEarnResetAutidAction
            drTimeOff.AuditSource = AuditSource
            drTimeOff.Item("AccountTimeOffPolicyId") = System.DBNull.Value
        Next
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)

    End Sub
    Public Function SetAvailableByMaximumAvailable(ByVal MaximumAvailable As Double, ByVal Available As Double)
        If MaximumAvailable <> 0 Then
            If Available > MaximumAvailable Then
                Return MaximumAvailable
            Else
                Return Available
            End If
        Else
            Return Available
        End If
    End Function
    Public Function GetEarnHoursByTotalNoOfPolicyDays(ByVal EarnHours As Double, ByVal EarnHoursTypeNo As Integer) As Double
        Return Math.Round(EarnHours * EarnHoursTypeNo, 2)
    End Function
    Public Sub SetResetPolicy(ByVal AccountEmployeeId As Integer)
        Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
        Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
        dt = Me.GetEmployeesForUpdatePoliciesByAccountEmployeeId(AccountEmployeeId)
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Dim dtPolicy As AccountTimeOffPolicy.AccountTimeOffPolicyDetailDataTable = New AccountTimeOffPolicyBLL().GetAccountTimeOffPolicyDetailByTimeOffPolicyId(dr.AccountId, dr.AccountTimeOffPolicyId)
            Dim drPolicy As AccountTimeOffPolicy.AccountTimeOffPolicyDetailRow
            If dtPolicy.Rows.Count > 0 Then
                drPolicy = dtPolicy.Rows(0)
                For Each drPolicy In dtPolicy.Rows
                    If CheckEffectiveDate(dr) And Not IsDBNull(drPolicy.Item("SystemEarnPeriodId")) Then
                        'Dim CarryForwardPerameter As Double = UpdateCarryForwardByParameter(AccountEmployeeId, drPolicy.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, 0)
                        Dim available As Double = GetNewAvailableHoursForResetPolicy(IIf(IsDBNull(drPolicy.Item("InitialSetToHours")), 0, drPolicy.Item("InitialSetToHours")), AccountEmployeeId, drPolicy.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId, 0)
                        UpdatePolicyHourBySchecdule(AccountEmployeeId, drPolicy.AccountTimeOffTypeId, drPolicy.AccountTimeOffPolicyId, 0, IIf(IsDBNull(drPolicy.Item("InitialSetToHours")), 0, drPolicy.Item("InitialSetToHours")), available, DBUtilities.GetEmployeeNameWithCode, "Reset Policy", "Time Off Status", Me.IsResetDateInclude(IIf(IsDBNull(drPolicy.Item("SystemResetToZeroTypeId")), System.Guid.Empty, drPolicy.Item("SystemResetToZeroTypeId")), dr.Item("HiredDate")), 0, True)
                    End If
                Next
            End If
        End If
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Sub UpdatePolicyHourBySchecdule(ByVal AccountEmployeeId As Integer, _
        ByVal AccountTimeOffTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid, ByVal CarryForward As Double, ByVal Earned As Double, ByVal Available As Double, _
       ByVal PolicyExecutionType As String, Optional ByVal PolicyEarnResetAutidAction As String = "", Optional ByVal AuditSource As String = "", Optional ByVal LastResetDate As Boolean = False, Optional ByVal Consume As Double = 0, Optional ByVal IsConsumed As Boolean = False)
        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)
        With drTimeOff
            .Earned = Earned
            .Available = Available
            .LastEarnedDate = Now.Date
            .ModifiedOn = Now
            If LastResetDate Then
                .LastResetDate = Now.Date
            End If
            .PolicyExecutionType = PolicyExecutionType
            .PolicyEarnResetAutidAction = PolicyEarnResetAutidAction
            .AuditSource = AuditSource
            .CarryForward = CarryForward
            If IsConsumed Then
                .Consume = Consume
            End If
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
    End Sub
    Public Sub UpdateEmployeeFieldsForTimeOff()
        Dim objEmployee As New AccountEmployeeBLL
        For n As Integer = 0 To EmployeeArray.Count - 1
            objEmployee.UpdateLastTimeOffCalculationScheduledTime(EmployeeArray(n))
            objEmployee.UpdateInitialPolicyByEmployeeId(EmployeeArray(n))
        Next
        'Dim AccountEmployeeId() As String = Split(AcountEmployees, ",")
        'For n As Integer = 0 To AccountEmployeeId.Length - 1
        '    objEmployee.UpdateLastTimeOffCalculationScheduledTime(AccountEmployeeId(n))
        '    objEmployee.UpdateInitialPolicyByEmployeeId(AccountEmployeeId(n))
        'Next
    End Sub
    Public Function UpdateCarryForward(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid)
        Dim CarryForward As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)
        With drTimeOff
            .CarryForward = Math.Round(CarryForward, 2)
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        Return drTimeOff.CarryForward
    End Function
    Public Function GetAvailableHoursByEmployeeIdAndTimeOffTypeId(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid) As Double
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow
        If dtTimeOff.Rows.Count > 0 Then
            drTimeOff = dtTimeOff.Rows(0)
            Return drTimeOff.Available
        Else
            Return 0
        End If
    End Function
    Public Function GetCarryForwardHoursByEmployeeIdAndTimeOffTypeId(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid) As Double
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow
        If dtTimeOff.Rows.Count > 0 Then
            drTimeOff = dtTimeOff.Rows(0)
            If Not IsDBNull(drTimeOff.Item("CarryForward")) Then
                Return drTimeOff.CarryForward
            End If
        Else
            Return 0
        End If
    End Function
    Public Function GetNewAvailableHours(ByVal Hours As Double, ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid, CarryForward As Double) As Double
        'Dim CarryForward As Double = GetCarryForwardHoursByEmployeeIdAndTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        'Dim Available As Double = GetAvailableHoursByEmployeeIdAndTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Return CDbl(Hours) + CDbl(CarryForward)
        'Dim value As Double = 
        'If Available < 0 Then
        '    value = value + Available
        'End If
        'Return value
    End Function
    Public Function GetResetHoursForAvailableHours(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal ResetHours As Double, ByVal AccountTimeOffPolicyId As Guid)
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)
        With drTimeOff
            If .Available < ResetHours Then
                Return ResetHours
            End If
        End With
        Return drTimeOff.Available
    End Function
    Public Function UpdateResetHoursInAvailableHours(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal ResetHours As Double, ByVal AccountTimeOffPolicyId As Guid)
        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter
        Dim Available As Double = 0
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)
        With drTimeOff
            If .Available > ResetHours Then
                .Available = ResetHours
            End If
            Available = .Available
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        Return Available
    End Function
    Public Function SetEmployeeTimeOffHoursFromTimeOffRequest(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal HoursOff As Double, Optional ByVal PolicyExecutionType As String = "", Optional ByVal PolicyEarnResetAutidAction As String = "", Optional ByVal AuditSource As String = "") As Boolean
        Dim dt As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByAccountEmployeeIdAndAccountTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId)
        Dim dr As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Dim TEMP As Double
            TEMP = Math.Round(dr.Consume, 2) + Math.Round(HoursOff, 2)
            dr.Consume = Math.Round(TEMP, 2)
            TEMP = Math.Round(dr.Available, 2) - Math.Round(HoursOff, 2)
            dr.Available = Math.Round(TEMP, 2)
            dr.PolicyExecutionType = PolicyExecutionType
            dr.PolicyEarnResetAutidAction = PolicyEarnResetAutidAction
            dr.AuditSource = AuditSource
            Dim rowsAffected As Integer = Adapter.Update(dt)
            Return True
        End If
    End Function
    Public Shared Sub UpdateTimeOffPolicies(ByVal PolicyExecuteType As String, Optional ByVal AuditSource As String = "")
        Call New AccountEmployeeTimeOffBLL().SetPolicies(PolicyExecuteType, AuditSource)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function UpdatePolicyIdByPolicyChanged(ByVal AccountEmployeeId As Integer, _
         ByVal AccountTimeOffTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid) As Boolean

        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter

        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByAccountEmployeeIdAndAccountTimeOffTypeId(AccountEmployeeId, AccountTimeOffTypeId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow
        If dtTimeOff.Rows.Count > 0 Then
            drTimeOff = dtTimeOff.Rows(0)
            If Not IsDBNull(drTimeOff.Item("AccountTimeOffPolicyId")) Then
                If AccountTimeOffPolicyId <> drTimeOff.AccountTimeOffPolicyId Then
                    Me.Adapter.UpdateAccountTimeOffPolicyId(AccountTimeOffPolicyId, "System", "Updated TimeOffPolicyId ", "Employee", drTimeOff.AccountEmployeeTimeOffId)
                End If
            Else
                Me.Adapter.UpdateAccountTimeOffPolicyId(AccountTimeOffPolicyId, "System", "Assigned TimeOffPolicyId From NULL ", "Employee", drTimeOff.AccountEmployeeTimeOffId)
            End If
        End If
    End Function
    Public Function UpdateConsumedHoursInEmployeeTimeOff(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal ConsumedHours As Double, ByVal AccountTimeOffPolicyId As Guid, Available As Double, ByVal PolicyExecutionType As String, ByVal PolicyEarnResetAutidAction As String, ByVal AuditSource As String)
        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)
        With drTimeOff
            .Consume = ConsumedHours
            .LastResetDate = Now.Date
            .Available = Available
            .PolicyExecutionType = PolicyExecutionType
            .PolicyEarnResetAutidAction = PolicyEarnResetAutidAction
            .AuditSource = AuditSource
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        Return rowsAffected = 1
    End Function
    Public Function GetNewAvailableHoursForResetPolicy(ByVal Hours As Double, ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid, CarryForward As Double) As Double
        Dim TotalHours As Double = Math.Round(Hours, 2) + Math.Round(CarryForward, 2)
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)
        If Not IsDBNull(drTimeOff.Item("Consume")) Then
            Return Math.Round(TotalHours - drTimeOff.Consume, 2)
        End If
        Return TotalHours
    End Function
    Public Function UpdateCarryForwardByParameter(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal AccountTimeOffPolicyId As Guid, ByVal CarryForward As Double)
        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter
        Dim CarryForwardPerameter As Double
        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(AccountEmployeeId, AccountTimeOffTypeId, AccountTimeOffPolicyId)
        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)
        With drTimeOff
            .CarryForward = CarryForward
            CarryForwardPerameter = .CarryForward
        End With

        'Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)
        'Return rowsAffected = 1
        Return CarryForwardPerameter
    End Function
    Public Function CheckTimeEntryTimeOffDeduction(ByVal drTimeEntry As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryRow) As Boolean
        Dim dt As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByAccountEmployeeIdAndAccountTimeOffTypeId(drTimeEntry.AccountEmployeeId, drTimeEntry.AccountTimeOffTypeId)
        Dim dr As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow
        Dim IsTimeOffConsumed As Boolean = IIf(IsDBNull(drTimeEntry.Item("IsTimeOffConsumed")), True, drTimeEntry.Item("IsTimeOffConsumed"))
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If IsDBNull(dr.Item("LastResetDate")) Then
                Return IsTimeOffConsumed
            End If
            If dr.LastResetDate <= drTimeEntry.TimeEntryDate Then
                Return IsTimeOffConsumed
            End If
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function UpdatePolicyIdByEmployeePolicyChanged(ByVal AccountEmployeeId As Integer, ByVal AccountTimeOffPolicyId As Guid, ByVal Original_AccountTimeOffPolicyId As Guid) As Boolean

        _AccountEmployeeTimeOffTableAdapter = New AccountEmployeeTimeOffTableAdapter
        Me.Adapter.UpdateAccountTimeOffPolicyForEmployee(AccountTimeOffPolicyId, Original_AccountTimeOffPolicyId, AccountEmployeeId)

    End Function
    Public Sub EarnedAtPoliciesAdditionalHoursOnHiredDate(Optional ByVal PolicyExecutionType As String = "", Optional ByVal ResetAutidAction As String = "", Optional ByVal AuditSource As String = "")
        If System.Configuration.ConfigurationManager.AppSettings("TIMEOFF_ADDITIONAL_HOURS") = "Yes" Then
            Dim AutidAction As String
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetEmployeesForAdditionalHoursByHiredDate()
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    If CheckEffectiveDate(dr) Then

                        Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                        Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)

                        With drTimeOff
                            Dim Available As Double
                            Available = .Available + dr.AdditionalHours
                            AutidAction = "Update Available/Anniversary Additional Hours"
                            Available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, Available)
                            Me.UpdateAvailableWthAdditionalHoursAtAnniversaryDate(Available, PolicyExecutionType, AutidAction, AuditSource, dr.AccountEmployeeId, dr.AccountTimeOffTypeId)
                        End With

                    End If
                Next
            End If
        End If
    End Sub
    Public Function AdditionalHoursWithYearsCount(ByVal Available As Double, ByVal anniversaryYearsCount As Double, ByVal AdditionalHours As Double)
        If System.Configuration.ConfigurationManager.AppSettings("TIMEOFF_ADDITIONAL_HOURS") = "Yes" Then

            Return Available + (AdditionalHours * anniversaryYearsCount)

        End If
        Return Available
    End Function
    Public Sub AddEmployeeTimeOffByPolicy(ByVal AccountTimeOffPolicyId As Guid, ByVal AccountEmployeeId As Integer, Optional ByVal IsNewAccount As Boolean = False)
        If AccountTimeOffPolicyId <> System.Guid.Empty Then
            Dim dt As AccountTimeOffPolicy.AccountTimeOffPolicyDetailDataTable = New AccountTimeOffPolicyBLL().GetAccountTimeOffPolicyDetailByTimeOffPolicyId(DBUtilities.GetSessionAccountId, AccountTimeOffPolicyId)
            Dim dr As AccountTimeOffPolicy.AccountTimeOffPolicyDetailRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    If IsEmployeeTimeOffExists(AccountEmployeeId, dr.AccountTimeOffTypeId) = False Then
                        AddAccountEmployeeTimeOff(DBUtilities.GetSessionAccountId, AccountEmployeeId, dr.AccountTimeOffTypeId, 0, 0, 0, Now.Date, 0, AccountTimeOffPolicyId, "System", "New Row Added", "Employee")
                    ElseIf IsEmployeeTimeOffExists(AccountEmployeeId, dr.AccountTimeOffTypeId) Then
                        UpdatePolicyIdByPolicyChanged(AccountEmployeeId, dr.AccountTimeOffTypeId, AccountTimeOffPolicyId)
                    End If
                Next
            End If
        ElseIf AccountTimeOffPolicyId = System.Guid.Empty Then
            UpdatePolicyIdByEmployeePolicyNone(AccountEmployeeId, "System", "Employee", "Reset Null")
        End If
        If IsNewAccount <> True Then
            SetPolicies("System", "Employee")
        End If
    End Sub
    Public Sub GetUpdateAvailableandCarryForwardForCarryForwardExpiryDate(ByVal PolicyExecutionType As String, ByVal AuditSource As String)
        If System.Configuration.ConfigurationManager.AppSettings("CarryForwardExpiryDate") = "Yes" Then
            Dim AutidAction As String
            Dim TotalEarned As Double
            Dim ConsumedDifference As Double
            Dim Available As Double
            Dim RemainingHours As Double
            Dim dt As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleDataTable
            Dim dr As AccountEmployeeTimeOff.vueAccountEmployeeTimeOffLastScheduleRow
            dt = Me.GetTimeOffTypeByCarryForwardExpiryDate()
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    Available = 0
                    AutidAction = ""
                    TotalEarned = 0
                    ConsumedDifference = 0
                    RemainingHours = 0
                    'If CheckCarryForwardExpiryDate(dr) Then
                    Dim dtTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffDataTable = Adapter.GetDataByEmployeeIdAndTimeOffTypeIdAndPolicyId(dr.AccountEmployeeId, dr.AccountTimeOffTypeId, dr.AccountTimeOffPolicyId)
                    Dim drTimeOff As AccountEmployeeTimeOff.AccountEmployeeTimeOffRow = dtTimeOff.Rows(0)
                    With drTimeOff
                        If CheckLastCarryForwardExpiryDate(drTimeOff) Then
                            If Not IsDBNull(dr.Item("ResetToHours")) And Not IsDBNull(dr.Item("EarnHours")) Then
                                TotalEarned = dr.Item("ResetToHours") + dr.Item("EarnHours")
                                RemainingHours = TotalEarned - (.Available)
                                If RemainingHours <= 0 Then
                                    '180-180 = 0 
                                    '180-190 = -10
                                    AutidAction = "TotalEarned= " & TotalEarned & " <= Available= " & .Available & " /CarryForward Expired"
                                    Available = (.Available) - (dr.Item("ResetToHours"))
                                ElseIf RemainingHours > 0 Then
                                    '180-150 = 30
                                    '180-141 = 39
                                    '180-100 = 80
                                    If dr.Item("ResetToHours") > RemainingHours Then
                                        AutidAction = "TotalEarned= " & TotalEarned & " > Available= " & .Available & " /CarryForward Expired"
                                        ConsumedDifference = (dr.Item("ResetToHours")) - RemainingHours
                                        Available = .Available - (ConsumedDifference)
                                    ElseIf dr.Item("ResetToHours") <= RemainingHours Then
                                        Available = .Available
                                        AutidAction = "Already Consumed/CarryForward Expired"
                                    End If
                                End If
                                Available = Me.SetAvailableByMaximumAvailable(dr.MaximumAvailable, Available)
                                Me.UpdateAvailableAndCarryForwardForCarryForwardExpiryDate(Math.Round(Available, 2), Now.Date, PolicyExecutionType, AutidAction, AuditSource, dr.AccountEmployeeId, dr.AccountTimeOffTypeId)
                            End If
                        End If
                    End With
                    ' End If
                Next
            End If
        End If
    End Sub
End Class