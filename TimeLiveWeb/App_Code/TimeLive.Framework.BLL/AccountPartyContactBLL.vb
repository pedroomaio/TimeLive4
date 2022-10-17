Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountPartyContactBLL

    Dim _AccountPartyContactTableAdapter As AccountPartyContactTableAdapter = Nothing
    Dim _vueAccountPartyContactTableAdapter As vueAccountPartyContactTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountPartyContactTableAdapter
        Get
            If _AccountPartyContactTableAdapter Is Nothing Then
                _AccountPartyContactTableAdapter = New AccountPartyContactTableAdapter

            End If
            Return _AccountPartyContactTableAdapter

        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountPartyContactTableAdapter
        Get
            If _vueAccountPartyContactTableAdapter Is Nothing Then
                _vueAccountPartyContactTableAdapter = New vueAccountPartyContactTableAdapter

            End If
            Return _vueAccountPartyContactTableAdapter

        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPartyContact() As TimeLiveDataSet.AccountPartyContactDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPartyContactsByAccountPartyId(ByVal AccountPartyId As Integer) As TimeLiveDataSet.AccountPartyContactDataTable
        Return Adapter.GetDataByAccountPartyId(AccountPartyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountPartyContactId(ByVal AccountPartyContactId As Integer) As TimeLiveDataSet.AccountPartyContactDataTable
        Return Adapter.GetDataByAccountPartyContactId(AccountPartyContactId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountPartyContactsByAccountPartyId(ByVal AccountPartyId As Integer) As TimeLiveDataSet.vueAccountPartyContactDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountPartyContactDataTable", "GetvueAccountPartyContactsByAccountPartyId", "AccountPartyId=" & AccountPartyId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetvueAccountPartyContactsByAccountPartyId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountPartyContactTableAdapter As New vueAccountPartyContactTableAdapter
            GetvueAccountPartyContactsByAccountPartyId = _vueAccountPartyContactTableAdapter.GetDataByAccountPartyId(DBUtilities.GetSessionAccountId, AccountPartyId)
            CacheManager.AddAccountDataInCache(GetvueAccountPartyContactsByAccountPartyId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetvueAccountPartyContactsByAccountPartyId)

        Return GetvueAccountPartyContactsByAccountPartyId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function AddAccountPartyContact(ByVal AccountPartyId As Integer, ByVal FirstName As String, _
        ByVal LastName As String, _
        ByVal Telephone1 As String, _
        ByVal Telephone2 As String, _
        ByVal Fax As String, _
        ByVal EMailAddress As String, _
        ByVal State As String, _
        ByVal City As String, _
        ByVal Zip As String, _
        ByVal Address1 As String, _
        ByVal Address2 As String, _
        ByVal CountryId As Short, _
        ByVal AccountPartyDepartmentId As Integer, _
        ByVal Location As String) As Boolean

        _AccountPartyContactTableAdapter = New AccountPartyContactTableAdapter

        Dim AccountPartyContacts As New TimeLiveDataSet.AccountPartyContactDataTable
        Dim AccountPartyContactsRow As TimeLiveDataSet.AccountPartyContactRow = AccountPartyContacts.NewAccountPartyContactRow

        With AccountPartyContactsRow
            .AccountPartyId = AccountPartyId
            .FirstName = FirstName
            .LastName = LastName
            .Telephone1 = Telephone1
            .Telephone2 = Telephone2
            .Fax = Fax
            .EMailAddress = EMailAddress
            .State = State
            .City = City
            .Zip = Zip
            .Address1 = Address1
            .Address2 = Address2
            .CountryId = CountryId
            .AccountPartyDepartmentId = AccountPartyDepartmentId
            .Location = Location
        End With

        AccountPartyContacts.AddAccountPartyContactRow(AccountPartyContactsRow)

        CacheManager.ClearCache("AccountPartyContactDataTable", , True)

        Dim rowsaffected As Integer = Adapter.Update(AccountPartyContacts)

        Return rowsaffected = 1

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function UpdateAccountPartyContact(ByVal AccountPartyId As Integer, ByVal FirstName As String, _
        ByVal LastName As String, _
        ByVal Telephone1 As String, _
        ByVal Telephone2 As String, _
        ByVal Fax As String, _
        ByVal EMailAddress As String, _
        ByVal State As String, _
        ByVal City As String, _
        ByVal Zip As String, _
        ByVal Address1 As String, _
        ByVal Address2 As String, _
        ByVal CountryId As Short, _
        ByVal AccountPartyDepartmentId As Integer, _
        ByVal Location As String, _
        ByVal Original_AccountPartyContactId As Integer) As Boolean

        Dim AccountPartyContacts As TimeLiveDataSet.AccountPartyContactDataTable = Adapter.GetDataByAccountPartyContactId(Original_AccountPartyContactId)

        Dim AccountPartyContactsRow As TimeLiveDataSet.AccountPartyContactRow = AccountPartyContacts.Rows(0)

        With AccountPartyContactsRow
            .AccountPartyId = AccountPartyId
            .FirstName = FirstName
            .LastName = LastName
            .Telephone1 = Telephone1
            .Telephone2 = Telephone2
            .Fax = Fax
            .EMailAddress = EMailAddress
            .State = State
            .City = City
            .Zip = Zip
            .Address1 = Address1
            .Address2 = Address2
            .CountryId = CountryId
            .AccountPartyDepartmentId = AccountPartyDepartmentId
            .Location = Location
        End With

        CacheManager.ClearCache("AccountPartyContactDataTable", , True)

        Dim rowsAffected As Integer = Adapter.Update(AccountPartyContacts)

        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function DeleteAccountPartyContact(ByVal Original_AccountPartyContactId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountPartyContactId)

        CacheManager.ClearCache("AccountPartyContactDataTable", , True)

        Return rowsAffected = 1

    End Function
End Class
