Imports Microsoft.VisualBasic
Imports dsLocationListReportTableAdapters

<System.ComponentModel.DataObject()> _
Public Class vueAccountLocationReportBLL

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
    Public Function GetAccountLocationsByAccountId(ByVal AccountId As Integer) As dsLocationListReport.AccountLocationDataTable

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
End Class