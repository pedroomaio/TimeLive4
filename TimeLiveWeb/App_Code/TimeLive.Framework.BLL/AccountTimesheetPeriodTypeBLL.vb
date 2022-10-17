Imports Microsoft.VisualBasic
Imports AccountTimesheetPeriodTypeTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountTimesheetPeriodTypeBLL
    Private _AccountTimesheetPeriodTypeTableAdapter As AccountTimesheetPeriodTypeTableAdapter = Nothing
    Private _vueAccountTimesheetPeriodTypeTableAdapter As vueAccountTimesheetPeriodTypeTableAdapter = Nothing
    Private _SystemTimesheetPeriodTypeTableAdapter As SystemTimesheetPeriodTypeTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As AccountTimesheetPeriodTypeTableAdapter
        Get
            If _AccountTimesheetPeriodTypeTableAdapter Is Nothing Then
                _AccountTimesheetPeriodTypeTableAdapter = New AccountTimesheetPeriodTypeTableAdapter()
            End If
            Return _AccountTimesheetPeriodTypeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountTimesheetPeriodTypeTableAdapter
        Get
            If _vueAccountTimesheetPeriodTypeTableAdapter Is Nothing Then
                _vueAccountTimesheetPeriodTypeTableAdapter = New vueAccountTimesheetPeriodTypeTableAdapter()
            End If
            Return _vueAccountTimesheetPeriodTypeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimesheetPeriodTypes() As AccountTimesheetPeriodType.AccountTimesheetPeriodTypeDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimesheetPeriodTypesByAccountId(ByVal AccountId As Integer) As AccountTimesheetPeriodType.AccountTimesheetPeriodTypeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimesheetPeriodTypesByAccountTimesheetPeriodTypeId(ByVal AccountTimesheetPeriodTypeId As Guid) As AccountTimesheetPeriodType.AccountTimesheetPeriodTypeDataTable
        Return Adapter.GetDataByAccountTimesheetPeriodTypeId(AccountTimesheetPeriodTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimesheetPeriodTypesByAccountId(ByVal AccountId As Integer) As AccountTimesheetPeriodType.vueAccountTimesheetPeriodTypeDataTable
        Return vueAdapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimesheetPeriodTypesByAccountIdandIsDisabled(ByVal AccountId As Integer, ByVal AccountTimesheetPeriodTypeId As Guid) As AccountTimesheetPeriodType.vueAccountTimesheetPeriodTypeDataTable
        Return vueAdapter.GetDataByAccountIdandIsDisabled(AccountId, AccountTimesheetPeriodTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimesheetPeriodTypesBySystemTimesheetPeriodTypeIdAndAccountId(ByVal SystemTimesheetPeriodTypeId As Integer, ByVal AccountId As Integer) As AccountTimesheetPeriodType.vueAccountTimesheetPeriodTypeDataTable
        Return vueAdapter.GetDataBySystemTimesheetPeriodTypeIdAndAccountId(SystemTimesheetPeriodTypeId, AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemTimesheetPeriodTypes() As AccountTimesheetPeriodType.SystemTimesheetPeriodTypeDataTable
        Dim sysTimesheetPeriodTypeAdapter As New AccountTimesheetPeriodTypeTableAdapters.SystemTimesheetPeriodTypeTableAdapter
        Return sysTimesheetPeriodTypeAdapter.GetData()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemInitialDaysOfThePeriod() As AccountTimesheetPeriodType.SystemInitialDaysOfThePeriodDataTable
        Dim sysInitialDaysOfThePeriodAdapter As New AccountTimesheetPeriodTypeTableAdapters.SystemInitialDaysOfThePeriodTableAdapter
        Return sysInitialDaysOfThePeriodAdapter.GetData()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountTimesheetPeriodType( _
                    ByVal AccountId As Integer, ByVal SystemTimesheetPeriodTypeId As Short, ByVal SystemInitialDaysOfThePeriodId As Short, _
                    ByVal InitialDayOfTheMonth As Short, ByVal CreatedOn As Date, _
                    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As Date, ByVal ModifiedByEmployeeId As Integer _
                ) As Boolean
        ' Create a new ProductRow instance

        _AccountTimesheetPeriodTypeTableAdapter = New AccountTimesheetPeriodTypeTableAdapter

        Dim dtAccountTimesheetPeriodType As New AccountTimesheetPeriodType.AccountTimesheetPeriodTypeDataTable
        Dim drAccountTimesheetPeriodType As AccountTimesheetPeriodType.AccountTimesheetPeriodTypeRow = dtAccountTimesheetPeriodType.NewAccountTimesheetPeriodTypeRow
        Dim AccountTimesheetPeriodTypeId As Guid = System.Guid.NewGuid
        With drAccountTimesheetPeriodType
            .AccountTimesheetPeriodTypeId = AccountTimesheetPeriodTypeId
            .AccountId = AccountId
            .SystemTimesheetPeriodTypeId = SystemTimesheetPeriodTypeId
            If SystemInitialDaysOfThePeriodId <> 0 Then
                .SystemInitialDaysOfThePeriodId = SystemInitialDaysOfThePeriodId
            End If
            If InitialDayOfTheMonth <> 0 Then
                .InitialDayOfTheMonth = InitialDayOfTheMonth
            End If
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = False
        End With

        dtAccountTimesheetPeriodType.AddAccountTimesheetPeriodTypeRow(drAccountTimesheetPeriodType)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(dtAccountTimesheetPeriodType)

        CacheManager.ClearCache("AccountTimesheetPeriodTypeDataTable", , True)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTimesheetPeriodType( _
                    ByVal AccountId As Integer, ByVal SystemTimesheetPeriodTypeId As Short, ByVal SystemInitialDaysOfThePeriodId As Short, _
                    ByVal InitialDayOfTheMonth As Short, ByVal ModifiedOn As Date, _
                    ByVal ModifiedByEmployeeId As Integer, ByVal IsDisabled As Boolean, _
                    ByVal Original_AccountTimesheetPeriodTypeId As Guid _
                    ) As Boolean

        '        _AccountTimesheetPeriodTypeTableAdapter = New AccountTimesheetPeriodTypeTableAdapter

        Dim dtAccountTimesheetPeriodType As AccountTimesheetPeriodType.AccountTimesheetPeriodTypeDataTable = Adapter.GetDataByAccountTimesheetPeriodTypeId(Original_AccountTimesheetPeriodTypeId)
        Dim drAccountTimesheetPeriodType As AccountTimesheetPeriodType.AccountTimesheetPeriodTypeRow = dtAccountTimesheetPeriodType.Rows(0)

        With drAccountTimesheetPeriodType
            .AccountId = AccountId
            .SystemTimesheetPeriodTypeId = SystemTimesheetPeriodTypeId
            If SystemInitialDaysOfThePeriodId <> 0 Then
                .SystemInitialDaysOfThePeriodId = SystemInitialDaysOfThePeriodId
            End If
            If InitialDayOfTheMonth <> 0 Then
                .InitialDayOfTheMonth = InitialDayOfTheMonth
            End If
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtAccountTimesheetPeriodType)
        Me.AddSessionValuesForAccountTimesheetPeriodType(SystemTimesheetPeriodTypeId, AccountId)
        Return rowsAffected = 1
    End Function
    Public Sub AddSessionValuesForAccountTimesheetPeriodType(ByVal SystemTimesheetPeriodTypeId As Integer, ByVal AccountId As Integer)
        Dim dt As AccountTimesheetPeriodType.vueAccountTimesheetPeriodTypeDataTable = Me.GetvueAccountTimesheetPeriodTypesBySystemTimesheetPeriodTypeIdAndAccountId(SystemTimesheetPeriodTypeId, AccountId)
        Dim dr As AccountTimesheetPeriodType.vueAccountTimesheetPeriodTypeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If SystemTimesheetPeriodTypeId = 4 Then
                System.Web.HttpContext.Current.Session.Add("SystemInitialDayOfFirstPeriod", dr.SystemInitialDayOfFirstPeriod)
                System.Web.HttpContext.Current.Session.Add("SystemInitialDayOfLastPeriod", dr.SystemInitialDayOfLastPeriod)
            ElseIf SystemTimesheetPeriodTypeId = 5 Then
                System.Web.HttpContext.Current.Session.Add("InitialDayOfTheMonth", dr.InitialDayOfTheMonth)
            End If
        End If
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTimesheetPeriodType(ByVal Original_AccountTimesheetPeriodTypeId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountTimesheetPeriodTypeId)

        CacheManager.ClearCache("AccountTimesheetPeriodTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        Adapter.InsertDefault(AccountId, AccountEmployeeId, Now.Date)
    End Sub
End Class
