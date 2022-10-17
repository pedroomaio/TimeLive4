Imports Microsoft.VisualBasic
Imports AccountHolidayTypeTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountHolidayTypeBLL
    Private _AccountHolidayTypeTableAdapter As AccountHolidayTypeTableAdapter = Nothing
    Private _vueAccountHolidayTypeTableAdapter As vueAccountHolidayTypeTableAdapter = Nothing
    Private _AccountHolidayTypeDetailTableAdapter As AccountHolidayTypeDetailTableAdapter = Nothing
    Private _vueAccountHolidayTypeDetailTableAdapter As vueAccountHolidayTypeDetailTableAdapter = Nothing
    Private _HolidayYearTableAdapter As HolidayYearTableAdapter = Nothing
    Private _vueHolidaySelectTableAdapter As vueAccountHolidaySelectTableAdapter = Nothing
    Private _MasterHolidayTypeDetailTableAdapter As MasterHolidayTypeDetailTableAdapter = Nothing
    Private _vueAccountEmployeeHolidayTypesWithDetailTableAdapter As vueAccountEmployeeHolidayTypesWithDetailTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As AccountHolidayTypeTableAdapter
        Get
            If _AccountHolidayTypeTableAdapter Is Nothing Then
                _AccountHolidayTypeTableAdapter = New AccountHolidayTypeTableAdapter()
            End If

            Return _AccountHolidayTypeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountHolidayTypeTableAdapter
        Get
            If _vueAccountHolidayTypeTableAdapter Is Nothing Then
                _vueAccountHolidayTypeTableAdapter = New vueAccountHolidayTypeTableAdapter()
            End If

            Return _vueAccountHolidayTypeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property DetailAdapter() As AccountHolidayTypeDetailTableAdapter
        Get
            If _AccountHolidayTypeDetailTableAdapter Is Nothing Then
                _AccountHolidayTypeDetailTableAdapter = New AccountHolidayTypeDetailTableAdapter()
            End If

            Return _AccountHolidayTypeDetailTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueDetailAdapter() As vueAccountHolidayTypeDetailTableAdapter
        Get
            If _vueAccountHolidayTypeDetailTableAdapter Is Nothing Then
                _vueAccountHolidayTypeDetailTableAdapter = New vueAccountHolidayTypeDetailTableAdapter()
            End If

            Return _vueAccountHolidayTypeDetailTableAdapter
        End Get
    End Property
    Protected ReadOnly Property DetailHolidayYearTableAdapter() As HolidayYearTableAdapter
        Get
            If _HolidayYearTableAdapter Is Nothing Then
                _HolidayYearTableAdapter = New HolidayYearTableAdapter()
            End If

            Return _HolidayYearTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueHolidaySelectTableAdapter() As vueAccountHolidaySelectTableAdapter
        Get
            If _vueHolidaySelectTableAdapter Is Nothing Then
                _vueHolidaySelectTableAdapter = New vueAccountHolidaySelectTableAdapter()
            End If

            Return _vueHolidaySelectTableAdapter
        End Get
    End Property
    Protected ReadOnly Property MasterHolidayTypeDetail() As MasterHolidayTypeDetailTableAdapter
        Get
            If _MasterHolidayTypeDetailTableAdapter Is Nothing Then
                _MasterHolidayTypeDetailTableAdapter = New MasterHolidayTypeDetailTableAdapter()
            End If

            Return _MasterHolidayTypeDetailTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAccountEmployeeHolidayTypesWithDetailAdapter() As vueAccountEmployeeHolidayTypesWithDetailTableAdapter
        Get
            If _vueAccountEmployeeHolidayTypesWithDetailTableAdapter Is Nothing Then
                _vueAccountEmployeeHolidayTypesWithDetailTableAdapter = New vueAccountEmployeeHolidayTypesWithDetailTableAdapter()
            End If

            Return _vueAccountEmployeeHolidayTypesWithDetailTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountHolidayTypeByAccountId(ByVal AccountId As Integer) As AccountHolidayType.vueAccountHolidayTypeDataTable
        GetvueAccountHolidayTypeByAccountId = vueAdapter.GetDataByAccountId(AccountId)
        UIUtilities.FixTableForNoRecords(GetvueAccountHolidayTypeByAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountHolidayTypeByAccountHolidayTypeId(ByVal AccountId As Integer, ByVal AccountHolidayTypeId As Guid) As AccountHolidayType.AccountHolidayTypeDataTable
        GetAccountHolidayTypeByAccountHolidayTypeId = Adapter.GetDataByAccountHolidayTypeId(AccountId, AccountHolidayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountHolidayTypeDetailByAccountHolidayTypeId(ByVal AccountHolidayTypeId As Guid) As AccountHolidayType.vueAccountHolidayTypeDetailDataTable
        GetvueAccountHolidayTypeDetailByAccountHolidayTypeId = vueDetailAdapter.GetDataByAccountHolidayTypeId(AccountHolidayTypeId)
        UIUtilities.FixTableForNoRecords(GetvueAccountHolidayTypeDetailByAccountHolidayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountHolidayTypeDetailByAccountHolidayTypeDetailId(ByVal AccountHolidayTypeDetailId As Guid) As AccountHolidayType.AccountHolidayTypeDetailDataTable
        GetAccountHolidayTypeDetailByAccountHolidayTypeDetailId = DetailAdapter.GetDataByAccountHolidayTypeDetailId(AccountHolidayTypeDetailId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountHolidayTypeDetailByAccountIdAccountHolidayTypeIdandHolidayYear(ByVal AccountId As Integer, ByVal AccountHolidayTypeId As Guid, ByVal HolidayYear As String) As AccountHolidayType.AccountHolidayTypeDetailDataTable
        GetAccountHolidayTypeDetailByAccountIdAccountHolidayTypeIdandHolidayYear = DetailAdapter.GetDataByAccountHolidayTypeIdandHolidayYear(AccountId, AccountHolidayTypeId, HolidayYear)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountHolidayTypeByAccountId(ByVal AccountId As Integer, ByVal AccountHolidayTypeId As Guid) As AccountHolidayType.AccountHolidayTypeDataTable
        GetAccountHolidayTypeByAccountId = Adapter.GetDataByAccountId(AccountId, AccountHolidayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountHolidayTypeDetailByAccountHolidayTypeIdandHolidayYear(ByVal AccountId As Integer, ByVal AccountHolidayTypeId As Guid, ByVal Year As String) As AccountHolidayType.vueAccountHolidayTypeDetailDataTable
        GetvueAccountHolidayTypeDetailByAccountHolidayTypeIdandHolidayYear = vueDetailAdapter.GetDataByAccountHolidayTypeIdandHolidayYear(AccountId, AccountHolidayTypeId, Year)
        UIUtilities.FixTableForNoRecords(GetvueAccountHolidayTypeDetailByAccountHolidayTypeIdandHolidayYear)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountHolidayTypeDetailByAccountIdandHolidayYear(ByVal AccountId As Integer) As AccountHolidayType.HolidayYearDataTable
        GetAccountHolidayTypeDetailByAccountIdandHolidayYear = DetailHolidayYearTableAdapter.GetDataByHolidayYear(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetHolidayYearByAccountIdandAccountHolidayTypeId(ByVal AccountId As Integer, ByVal AccountHolidayTypeId As Guid) As AccountHolidayType.HolidayYearDataTable
        GetHolidayYearByAccountIdandAccountHolidayTypeId = DetailHolidayYearTableAdapter.GetHolidayYearByAccountIdandAccountHolidayTypeId(AccountId, AccountHolidayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueMasterHolidaySelect() As AccountHolidayType.vueAccountHolidaySelectDataTable
        GetvueMasterHolidaySelect = vueHolidaySelectTableAdapter.GetData
    End Function
    'MasterHolidayTypeDetail
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetMasterHolidayTypeDetailByMasterHolidayTypeId(ByVal MasterHolidayTypeId As Guid) As AccountHolidayType.MasterHolidayTypeDetailDataTable
        GetMasterHolidayTypeDetailByMasterHolidayTypeId = MasterHolidayTypeDetail.GetDataByMasterHolidayTypeId(MasterHolidayTypeId)
    End Function
    'GetHolidayTypeDetail record AccountId and AccountHolidayTypeId
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountHolidayTypeDetailByAccountIdandAccountHolidayTypeId(ByVal AccountId As Integer, ByVal AccountHolidayTypeId As Guid) As AccountHolidayType.AccountHolidayTypeDetailDataTable
        GetAccountHolidayTypeDetailByAccountIdandAccountHolidayTypeId = DetailAdapter.GetDataByAccountIdandAccountHolidayTypeId(AccountId, AccountHolidayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountHolidayTypeDetailByAccountIdandHolidayDate(ByVal HolidayDate As Date, ByVal AccountHolidayTypeId As Guid) As AccountHolidayType.vueAccountHolidayTypeDetailDataTable
        GetvueAccountHolidayTypeDetailByAccountIdandHolidayDate = vueDetailAdapter.GetDataByAccountIdandHolidayDate(DBUtilities.GetSessionAccountId, HolidayDate, AccountHolidayTypeId)
        Return GetvueAccountHolidayTypeDetailByAccountIdandHolidayDate
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeHolidayTypewithDetailByAccountIdAndAccountHolidayTypeIdForTimeEntry(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal HolidayStartDate As Date, ByVal HolidayEndDate As Date, ByVal AccountHolidayTypeId As Guid) As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable
        Dim vueAccountEmployeeHolidayTypesWithDetailTableAdapter As New vueAccountEmployeeHolidayTypesWithDetailTableAdapter
        GetvueAccountEmployeeHolidayTypewithDetailByAccountIdAndAccountHolidayTypeIdForTimeEntry = vueAccountEmployeeHolidayTypesWithDetailTableAdapter.GetDataByAccountIdAndAccountEmployeeIdForTimeEntry(AccountId, AccountEmployeeId, HolidayStartDate, HolidayEndDate, AccountHolidayTypeId)
        Return GetvueAccountEmployeeHolidayTypewithDetailByAccountIdAndAccountHolidayTypeIdForTimeEntry
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeesByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountHolidayType.vueAccountHolidayEmployeeDataTable
        Dim _vueAccountHolidayEmployeeTableAdapter As New vueAccountHolidayEmployeeTableAdapter
        Return _vueAccountHolidayEmployeeTableAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountHolidayTypeByAccountIdandMasterHolidayTypeId(ByVal AccountId As Integer, ByVal MasterHolidayTypeId As Guid) As AccountHolidayType.AccountHolidayTypeDataTable
        GetAccountHolidayTypeByAccountIdandMasterHolidayTypeId = Adapter.GetDataByAccountIdandMasterHolidayTypeId(AccountId, MasterHolidayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountHolidayType(ByVal AccountId As Integer, ByVal AccountHolidayType As String, _
    ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, _
    ByVal ModifiedByEmployeeId As Integer) As Boolean

        _AccountHolidayTypeTableAdapter = New AccountHolidayTypeTableAdapter

        Dim dtAccountHolidayType As New AccountHolidayType.AccountHolidayTypeDataTable
        Dim drAccountHolidayType As AccountHolidayType.AccountHolidayTypeRow = dtAccountHolidayType.NewAccountHolidayTypeRow
        Dim AccountHolidayTypeId As Guid = System.Guid.NewGuid

        With drAccountHolidayType
            .AccountHolidayTypeId = AccountHolidayTypeId
            .AccountId = AccountId
            .AccountHolidayType = AccountHolidayType
            .IsDisabled = False
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With

        dtAccountHolidayType.AddAccountHolidayTypeRow(drAccountHolidayType)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(dtAccountHolidayType)
        System.Web.HttpContext.Current.Session.Add("AccountHolidayTypeId", AccountHolidayTypeId)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountHolidayTypeDetail(ByVal AccountHolidayTypeId As Guid, ByVal AccountId As Integer, ByVal HolidayName As String, _
    ByVal HolidayDate As Date, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, _
    ByVal ModifiedByEmployeeId As Integer) As Boolean

        _AccountHolidayTypeDetailTableAdapter = New AccountHolidayTypeDetailTableAdapter

        Dim dtAccountHolidayTypeDetail As New AccountHolidayType.AccountHolidayTypeDetailDataTable
        Dim drAccountHolidayTypeDetail As AccountHolidayType.AccountHolidayTypeDetailRow = dtAccountHolidayTypeDetail.NewAccountHolidayTypeDetailRow
        Dim AccountHolidayTypeDetailId As Guid = System.Guid.NewGuid

        With drAccountHolidayTypeDetail
            .AccountId = AccountId
            .AccountHolidayTypeId = AccountHolidayTypeId
            .AccountHolidayTypeDetailId = AccountHolidayTypeDetailId
            .HolidayName = HolidayName
            .HolidayDate = HolidayDate
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With

        dtAccountHolidayTypeDetail.AddAccountHolidayTypeDetailRow(drAccountHolidayTypeDetail)

        ' Add the new product
        Dim rowsAffected As Integer = DetailAdapter.Update(dtAccountHolidayTypeDetail)
        System.Web.HttpContext.Current.Session.Add("AccountHolidayTypeDetailId", AccountHolidayTypeDetailId)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function AddAccountHolidaySelect(ByVal AccountId As Integer, ByVal MasterHolidayTypeId As Guid, ByVal HolidayType As String, _
        ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer) As Boolean

        _AccountHolidayTypeTableAdapter = New AccountHolidayTypeTableAdapter

        Dim dtAccountHolidayType As New AccountHolidayType.AccountHolidayTypeDataTable
        Dim drAccountHolidayType As AccountHolidayType.AccountHolidayTypeRow = dtAccountHolidayType.NewAccountHolidayTypeRow
        Dim AccountHolidayTypeId As Guid = System.Guid.NewGuid

        With drAccountHolidayType
            .AccountHolidayTypeId = AccountHolidayTypeId
            .AccountId = AccountId
            .MasterHolidayTypeId = MasterHolidayTypeId
            .AccountHolidayType = HolidayType
            .IsDisabled = False
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With

        dtAccountHolidayType.AddAccountHolidayTypeRow(drAccountHolidayType)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(dtAccountHolidayType)
        System.Web.HttpContext.Current.Session.Add("AccountHolidayTypeId", AccountHolidayTypeId)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountHolidayTypeDetailSelect(ByVal AccountHolidayTypeId As Guid, ByVal AccountId As Integer, _
    ByVal MasterHolidayTypeDetailId As Guid, ByVal HolidayName As String, ByVal HolidayDate As Date, _
    ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer) As Boolean

        _AccountHolidayTypeDetailTableAdapter = New AccountHolidayTypeDetailTableAdapter

        Dim dtAccountHolidayTypeDetail As New AccountHolidayType.AccountHolidayTypeDetailDataTable
        Dim drAccountHolidayTypeDetail As AccountHolidayType.AccountHolidayTypeDetailRow = dtAccountHolidayTypeDetail.NewAccountHolidayTypeDetailRow
        Dim AccountHolidayTypeDetailId As Guid = System.Guid.NewGuid

        With drAccountHolidayTypeDetail
            .AccountId = AccountId
            .AccountHolidayTypeId = AccountHolidayTypeId
            .AccountHolidayTypeDetailId = AccountHolidayTypeDetailId
            .MasterHolidayTypeDetailId = MasterHolidayTypeDetailId
            .HolidayName = HolidayName
            .HolidayDate = HolidayDate
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With

        dtAccountHolidayTypeDetail.AddAccountHolidayTypeDetailRow(drAccountHolidayTypeDetail)

        ' Add the new product
        Dim rowsAffected As Integer = DetailAdapter.Update(dtAccountHolidayTypeDetail)
        System.Web.HttpContext.Current.Session.Add("AccountHolidayTypeDetailId", AccountHolidayTypeDetailId)
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountHolidayType(ByVal Original_AccountHolidayTypeId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountHolidayTypeId)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountHolidayTypeDetail(ByVal Original_AccountHolidayTypeDetailId As Guid) As Boolean
        Dim rowsAffected As Integer = DetailAdapter.Delete(Original_AccountHolidayTypeDetailId)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountHolidayTypeDetailByAccountHolidayTypeId(ByVal Original_AccountHolidayTypeId As Guid) As Boolean
        Dim rowsAffected As Integer = DetailAdapter.deletequery(Original_AccountHolidayTypeId)

        Return rowsAffected = 1
    End Function
    Public Function GetLastInsertedId() As Guid
        'Dim a As TimeLiveDataSet.IdentityQueryRow
        'Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        'a = ad.GetAccountTimeExpenseBillingLastId.Rows(0)
        'Return a.LastId
        Return System.Web.HttpContext.Current.Session("AccountHolidayTypeId")
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountHolidayType(ByVal AccountId As Integer, ByVal Original_AccountHolidayTypeId As Guid, _
    ByVal AccountHolidayType As String, ByVal IsDisabled As Boolean, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, _
    ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer) As Boolean

        ' Update the product record
        Dim dtAccountHolidayType As AccountHolidayType.AccountHolidayTypeDataTable = Adapter.GetDataByAccountHolidayTypeId(AccountId, Original_AccountHolidayTypeId)
        Dim drAccountHolidayType As AccountHolidayType.AccountHolidayTypeRow = dtAccountHolidayType.Rows(0)

        With drAccountHolidayType
            .AccountHolidayTypeId = Original_AccountHolidayTypeId
            .AccountId = AccountId
            .AccountHolidayType = AccountHolidayType
            .IsDisabled = IsDisabled
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtAccountHolidayType)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountHolidayTypeDetail(ByVal Original_AccountHolidayTypeDetailId As Guid, ByVal HolidayName As String, _
    ByVal AccountId As Integer, ByVal Original_AccountHolidayTypeId As Guid, ByVal HolidayDate As Date, ByVal Original_HolidayDate As Date, _
    ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer) As Boolean

        ' Update the product record

        Dim dtAccountHolidayTypeDetail As AccountHolidayType.AccountHolidayTypeDetailDataTable = DetailAdapter.GetDataByAccountHolidayTypeDetailId(Original_AccountHolidayTypeDetailId)
        Dim drAccountHolidayTypeDetail As AccountHolidayType.AccountHolidayTypeDetailRow = dtAccountHolidayTypeDetail.Rows(0)

        With drAccountHolidayTypeDetail
            .AccountId = AccountId
            .AccountHolidayTypeId = Original_AccountHolidayTypeId
            .AccountHolidayTypeDetailId = Original_AccountHolidayTypeDetailId
            .HolidayName = HolidayName
            .HolidayDate = HolidayDate
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With

        Dim rowsAffected As Integer = DetailAdapter.Update(dtAccountHolidayTypeDetail)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEmployeeHolidayTypesWithDetailByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As AccountHolidayType.vueAccountEmployeeHolidayTypesWithDetailDataTable
        GetvueAccountEmployeeHolidayTypesWithDetailByAccountEmployeeId = vueAccountEmployeeHolidayTypesWithDetailAdapter.GetDataByAccountEmployeeId(AccountEmployeeId)
        Return GetvueAccountEmployeeHolidayTypesWithDetailByAccountEmployeeId
    End Function
End Class
