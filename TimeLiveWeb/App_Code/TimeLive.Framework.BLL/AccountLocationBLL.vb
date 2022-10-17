Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountLocationBLL

    Dim strCacheKey As String
    Private _AccountLocationTableAdapter As AccountLocationTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As AccountLocationTableAdapter
        Get
            If _AccountLocationTableAdapter Is Nothing Then
                _AccountLocationTableAdapter = New AccountLocationTableAdapter()
            End If

            Return _AccountLocationTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountLocations() As TimeLiveDataSet.AccountLocationDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountLocationsByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountLocationDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountLocationDataTable", "GetAccountLocationsByAccountId", "AccountId=" & AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountLocationsByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountLocationsByAccountId = Adapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountLocationsByAccountId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountLocationsByAccountId)

        Return GetAccountLocationsByAccountId


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountLocationsByAccountIdAndAccountLocationId(ByVal AccountId As Integer, ByVal AccountLocationId As Integer) As TimeLiveDataSet.AccountLocationDataTable
        Return Adapter.GetDataByAccountIdAndAccountLocationId(AccountId, AccountLocationId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountLocationsByAccountIdAndIsNotDisabled(ByVal AccountId As Integer) As TimeLiveDataSet.AccountLocationDataTable
        Return Adapter.GetAccountLocationByAccountIdAndIsNotDisable(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDefaultLocationByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountLocationDataTable
        Return Adapter.GetDefaultLocationByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountLocationsByAccountLocationId(ByVal AccountLocationId As Integer) As TimeLiveDataSet.AccountLocationDataTable
        Return Adapter.GetDataByAccountLocationId(AccountLocationId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountLocation(ByVal AccountId As Integer, ByVal AccountLocation As String, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer) As Integer
        ' Create a new ProductRow instance


        _AccountLocationTableAdapter = New AccountLocationTableAdapter
        Dim nNewAccountLocationId As Integer = _AccountLocationTableAdapter.InsertAccountLocation(AccountId, AccountLocation, Now, CreatedByEmployeeId, Now, ModifiedByEmployeeId, False)

        CacheManager.ClearCache("AccountLocationDataTable", "AccountId=" & AccountId)

        ' Return true if precisely one row was inserted, otherwise false
        Return nNewAccountLocationId

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountLocation(ByVal AccountId As Integer, ByVal AccountLocation As String, ByVal original_AccountLocationId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal IsDisabled As Boolean) As Boolean

        ' Update the product record

        Dim AccountLocations As TimeLiveDataSet.AccountLocationDataTable = Adapter.GetDataByAccountLocationId(original_AccountLocationId)

        Dim AccountLocation0 As TimeLiveDataSet.AccountLocationRow = AccountLocations.Rows(0)

        With AccountLocation0
            .AccountLocation = AccountLocation
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
        End With



        Dim rowsAffected As Integer = Adapter.Update(AccountLocation0)

        CacheManager.ClearCache("AccountLocationDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountLocation(ByVal original_AccountLocationId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(original_AccountLocationId)

        CacheManager.ClearCache("AccountLocationDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function GetDefaultLocation(ByVal AccountId As Integer) As Integer
        Dim dtlocation As TimeLiveDataSet.AccountLocationDataTable = Me.GetDefaultLocationByAccountId(AccountId)
        Dim drlocation As TimeLiveDataSet.AccountLocationRow
        If dtlocation.Rows.Count > 0 Then
            drlocation = dtlocation.Rows(0)
            Return drlocation.AccountLocationId
        End If
    End Function
    Public Function GetLocationIdForQB(AccountId As Integer) As Integer
        Dim nLocationId As Integer
        Dim dtLocation As TimeLiveDataSet.AccountLocationDataTable = Adapter.GetDataByAccountId(AccountId)
        Dim drLocation As TimeLiveDataSet.AccountLocationRow
        If dtLocation.Rows.Count > 0 Then
            drLocation = dtLocation.Rows(0)
            nLocationId = drLocation.AccountLocationId
        Else
            nLocationId = Me.AddAccountLocation(AccountId, "Default Location", 0, 0)
        End If
        Return nLocationId
    End Function
    Public Function GetLocationId(AccountId As Integer) As Integer
        Dim nLocationId As Integer
        Dim dtLocation As TimeLiveDataSet.AccountLocationDataTable = Adapter.GetDataByAccountId(AccountId)
        Dim drLocation As TimeLiveDataSet.AccountLocationRow
        If dtLocation.Rows.Count > 0 Then
            drLocation = dtLocation.Rows(0)
            nLocationId = drLocation.AccountLocationId
        Else
            nLocationId = Me.AddAccountLocation(AccountId, "Default Location", 0, 0)
        End If
        Return nLocationId
    End Function
End Class
