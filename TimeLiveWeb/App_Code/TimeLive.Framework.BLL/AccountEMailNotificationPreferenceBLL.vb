Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountEMailNotificationPreferenceBLL

    Private _AccountEMailNotificationPreferenceTableAdapter As AccountEMailNotificationPreferenceTableAdapter = Nothing
    Private _vueAccountEMailNotificationPreferenceTableAdapter As vueAccountEMailNotificationPreferenceTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountEMailNotificationPreferenceTableAdapter
        Get
            If _AccountEMailNotificationPreferenceTableAdapter Is Nothing Then
                _AccountEMailNotificationPreferenceTableAdapter = New AccountEMailNotificationPreferenceTableAdapter()
            End If

            Return _AccountEMailNotificationPreferenceTableAdapter
        End Get
    End Property

    Protected ReadOnly Property vueAdapter() As vueAccountEMailNotificationPreferenceTableAdapter
        Get
            If _vueAccountEMailNotificationPreferenceTableAdapter Is Nothing Then
                _vueAccountEMailNotificationPreferenceTableAdapter = New vueAccountEMailNotificationPreferenceTableAdapter()
            End If

            Return _vueAccountEMailNotificationPreferenceTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEMailNotificationPreferences() As TimeLiveDataSet.AccountEMailNotificationPreferenceDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEMailNotificationPreferences() As TimeLiveDataSet.vueAccountEMailNotificationPreferenceDataTable
        Return vueAdapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEMailNotificationPreferencessByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountEMailNotificationPreferenceDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountEMailNotificationPreferenceDataTable", "GetAccountEMailNotificationPreferencessByAccountId", "AccountId=" & AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountEMailNotificationPreferencessByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountEMailNotificationPreferencessByAccountId = Adapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountEMailNotificationPreferencessByAccountId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountEMailNotificationPreferencessByAccountId)

        Return GetAccountEMailNotificationPreferencessByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEMailNotificationPreferencessByAccountProjectId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountEMailNotificationPreferenceDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountEMailNotificationPreferenceDataTable", "GetAccountEMailNotificationPreferencessByAccountProjectId", "AccountProjectId=" & AccountProjectId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountEMailNotificationPreferencessByAccountProjectId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountEMailNotificationPreferencessByAccountProjectId = Adapter.GetDataByAccountProjectId(AccountProjectId)
            CacheManager.AddAccountDataInCache(GetAccountEMailNotificationPreferencessByAccountProjectId, strCacheKey)
        End If

        UIUtilities.FixTableForNoRecords(GetAccountEMailNotificationPreferencessByAccountProjectId)

        Return GetAccountEMailNotificationPreferencessByAccountProjectId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEMailNotificationPreferencessByAccountEmployeeId(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.AccountEMailNotificationPreferenceDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountEMailNotificationPreferenceDataTable", "GetAccountEMailNotificationPreferencessByAccountEmployeeId", "AccountEmployeeId=" & AccountEmployeeId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountEMailNotificationPreferencessByAccountEmployeeId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountEMailNotificationPreferencessByAccountEmployeeId = Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
            CacheManager.AddAccountDataInCache(GetAccountEMailNotificationPreferencessByAccountEmployeeId, strCacheKey)
        End If

        UIUtilities.FixTableForNoRecords(GetAccountEMailNotificationPreferencessByAccountEmployeeId)

        Return GetAccountEMailNotificationPreferencessByAccountEmployeeId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEMailNotificationPreferencessByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountEMailNotificationPreferenceDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountEMailNotificationPreferenceDataTable", "GetvueAccountEMailNotificationPreferencessByAccountId", "AccountId=" & AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetvueAccountEMailNotificationPreferencessByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetvueAccountEMailNotificationPreferencessByAccountId = vueAdapter.GetDataByAccountIdForBugTracking(AccountId)
            CacheManager.AddAccountDataInCache(GetvueAccountEMailNotificationPreferencessByAccountId, strCacheKey)
        End If

        UIUtilities.FixTableForNoRecords(GetvueAccountEMailNotificationPreferencessByAccountId)

        Return GetvueAccountEMailNotificationPreferencessByAccountId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEMailNotificationPreferencessByAccountProjectId(ByVal AccountProjectId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountEMailNotificationPreferenceDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountEMailNotificationPreferenceDataTable", "GetvueAccountEMailNotificationPreferencessByAccountProjectId", "AccountProjectId=" & AccountProjectId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetvueAccountEMailNotificationPreferencessByAccountProjectId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetvueAccountEMailNotificationPreferencessByAccountProjectId = vueAdapter.GetDataByAccountProjectIdForBugTracking(AccountProjectId, AccountId)
            CacheManager.AddAccountDataInCache(GetvueAccountEMailNotificationPreferencessByAccountProjectId, strCacheKey)
        End If

        UIUtilities.FixTableForNoRecords(GetvueAccountEMailNotificationPreferencessByAccountProjectId)

        Return GetvueAccountEMailNotificationPreferencessByAccountProjectId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountEMailNotificationPreferencessByAccountEmployeeId(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountEMailNotificationPreferenceDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountEMailNotificationPreferenceDataTable", "GetvueAccountEMailNotificationPreferencessByAccountEmployeeId", "AccountEmployeeId=" & AccountEmployeeId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetvueAccountEMailNotificationPreferencessByAccountEmployeeId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetvueAccountEMailNotificationPreferencessByAccountEmployeeId = vueAdapter.GetDataByAccountEmployeeIdForBugTracking(AccountEmployeeId, AccountId)
            CacheManager.AddAccountDataInCache(GetvueAccountEMailNotificationPreferencessByAccountEmployeeId, strCacheKey)
        End If

        UIUtilities.FixTableForNoRecords(GetvueAccountEMailNotificationPreferencessByAccountEmployeeId)

        Return GetvueAccountEMailNotificationPreferencessByAccountEmployeeId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEMailNotificationPreferencesByAccountEMailNotificationPreferenceId(ByVal AccountEMailNotificationPreferenceId As Integer) As TimeLiveDataSet.AccountEMailNotificationPreferenceDataTable
        Return Adapter.GetDataByAccountEMailNotificationPreferenceId(AccountEMailNotificationPreferenceId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEMailNotificationPreferencesByAccountIdForEmployeeEMail(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountEMailNotificationPreferenceDataTable
        Return vueAdapter.GetDataByAccountIdForEmployeeEMail(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEMailNotificationPreference( _
                        ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal SystemEMailNotificationid As Short, ByVal SystemEMailNotificationTypeId As Short, ByVal Enabled As Boolean _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountEMailNotificationPreferenceTableAdapter = New AccountEMailNotificationPreferenceTableAdapter

        Dim AccountEMailNotificationPreferences As New TimeLiveDataSet.AccountEMailNotificationPreferenceDataTable
        Dim AccountEMailNotificationPreferenceRow As TimeLiveDataSet.AccountEMailNotificationPreferenceRow = AccountEMailNotificationPreferences.NewAccountEMailNotificationPreferenceRow

        With AccountEMailNotificationPreferenceRow
            .AccountId = AccountId
            .AccountProjectId = AccountProjectId
            .AccountEmployeeId = AccountEmployeeId
            .SystemEMailNotificationId = SystemEMailNotificationid
            .SystemEMailNotificationTypeId = SystemEMailNotificationTypeId
            .Enabled = Enabled
        End With

        AccountEMailNotificationPreferences.AddAccountEMailNotificationPreferenceRow(AccountEMailNotificationPreferenceRow)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountEMailNotificationPreferences)

        CacheManager.ClearCache("AccountEMailNotificationPreferenceDataTable", , True)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEMailNotificationPreference(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, _
    ByVal SystemEMailNotificationid As Short, ByVal SystemEMailNotificationTypeId As Short, ByVal Enabled As Boolean, ByVal Original_AccountEMailNotificationPreferenceId As Integer, _
    Optional ByVal Monday As Boolean = False, Optional ByVal Tuesday As Boolean = False, Optional ByVal Wednesday As Boolean = False, Optional ByVal Thursday As Boolean = False, _
    Optional ByVal Friday As Boolean = False, Optional ByVal Saturday As Boolean = False, Optional ByVal Sunday As Boolean = False) As Boolean

        ' Update the product record

        Dim AccountEMailNotificationPreferences As TimeLiveDataSet.AccountEMailNotificationPreferenceDataTable = Adapter.GetDataByAccountEMailNotificationPreferenceId(Original_AccountEMailNotificationPreferenceId)
        Dim AccountEMailNotificationPreferenceRow As TimeLiveDataSet.AccountEMailNotificationPreferenceRow = AccountEMailNotificationPreferences.Rows(0)

        With AccountEMailNotificationPreferenceRow
            .AccountId = AccountId
            .AccountProjectId = AccountProjectId
            .AccountEmployeeId = AccountEmployeeId
            .SystemEMailNotificationId = SystemEMailNotificationid
            .SystemEMailNotificationTypeId = SystemEMailNotificationTypeId
            .Enabled = Enabled
            .Monday = Monday
            .Tuesday = Tuesday
            .Wednesday = Wednesday
            .Thursday = Thursday
            .Friday = Friday
            .Saturday = Saturday
            .Sunday = Sunday
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountEMailNotificationPreferenceRow)

        CacheManager.ClearCache("AccountEMailNotificationPreferenceDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEMailNotificationPreference(ByVal Original_AccountEMailNotificationPreferenceId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountEMailNotificationPreferenceId)

        CacheManager.ClearCache("AccountEMailNotificationPreferenceDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Sub InsertDefaultAccountEMailNotificationPreference(ByVal AccountId As Integer)
        Adapter.InsertDefaultAccountEMailNotificationPreference(AccountId)
    End Sub
    Public Sub InsertDefaultAccountProjectEMailNotificationPreference(ByVal AccountProjectId As Integer)
        Adapter.InsertDefaultAccountProjectEMailNotificationPreference(AccountProjectId)
    End Sub
    Public Sub InsertDefaultAccountEmployeeEMailNotificationPreference(ByVal AccountEmployeeId As Integer)
        Adapter.InsertDefaultAccountEmployeeEMailNotificationPreference(AccountEmployeeId)
    End Sub
    Public Sub InsertDefaultAccountEmployeeEMailNotificationPreferenceForExternalEmployee(ByVal AccountEmployeeId As Integer)
        Adapter.InsertDefaultAccountEmployeeEMailNotificationPreferenceForExternal(AccountEmployeeId)
    End Sub
    Public Sub InsertDefaultAccountEmployeeEMailNotificationPreferenceByProjectTemplate(ByVal AccountProjectId As Integer, ByVal AccountProjectTemplateId As Integer)
        Adapter.InsertDefaultAccountProjectEmailNotificationPreferenceByProjectTemplate(AccountProjectId, AccountProjectTemplateId)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEMailNotificationPreferencessByAccountEmployeeIdForOldVersion(ByVal AccountEmployeeId As Integer) As TimeLiveDataSet.AccountEMailNotificationPreferenceDataTable
        GetAccountEMailNotificationPreferencessByAccountEmployeeIdForOldVersion = Adapter.GetDataByAccountEmployeeId(AccountEmployeeId)
        Return GetAccountEMailNotificationPreferencessByAccountEmployeeIdForOldVersion
    End Function
    Public Function UpdateEnableForAccountDisable(ByVal AccountId As Integer) As Boolean
        Me.Adapter.UpdateEnableForAccountDisable(AccountId)
    End Function
End Class



