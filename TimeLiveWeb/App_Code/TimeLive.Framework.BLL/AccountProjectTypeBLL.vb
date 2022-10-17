Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountProjectTypeBLL

    Private _AccountProjectTypeTableAdapter As AccountProjectTypeTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountProjectTypeTableAdapter
        Get
            If _AccountProjectTypeTableAdapter Is Nothing Then
                _AccountProjectTypeTableAdapter = New AccountProjectTypeTableAdapter()
            End If

            Return _AccountProjectTypeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTypeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectTypeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjecTypes() As TimeLiveDataSet.AccountProjectTypeDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTypesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectTypeDataTable
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectTypeDataTable", "GetAccountProjectTypesByAccountId", AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountProjectTypesByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountPartyTableAdapter As New vueAccountPartyTableAdapter
            GetAccountProjectTypesByAccountId = Adapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountProjectTypesByAccountId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountProjectTypesByAccountId)

        Return GetAccountProjectTypesByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetAccountProjectTypesByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountProjectTypeId As Integer) As TimeLiveDataSet.AccountProjectTypeDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountProjectTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTypesByAccountProjectTypeId(ByVal AccountProjectTypeId As Integer) As TimeLiveDataSet.AccountProjectTypeDataTable
        Return Adapter.GetDataByAccountProjectTypeId(AccountProjectTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProjectType( _
                        ByVal AccountId As Integer, ByVal ProjectType As String, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer) As Boolean
        ' Create a new ProductRow instance
        Try



            _AccountProjectTypeTableAdapter = New AccountProjectTypeTableAdapter

            Dim AccountProjectTypes As New TimeLiveDataSet.AccountProjectTypeDataTable
            Dim AccountProjectType As TimeLiveDataSet.AccountProjectTypeRow = AccountProjectTypes.NewAccountProjectTypeRow

            With AccountProjectType
                .AccountId = AccountId
                .ProjectType = ProjectType
                .CreatedOn = Now
                .CreatedByEmployeeId = CreatedByEmployeeId
                .ModifiedOn = Now
                .ModifiedByEmployeeId = ModifiedByEmployeeId
                .IsDisabled = False
            End With

            AccountProjectTypes.AddAccountProjectTypeRow(AccountProjectType)


            ' Add the new product
            Dim rowsAffected As Integer = Adapter.Update(AccountProjectTypes)

            CacheManager.ClearCache("AccountProjectTypeDataTable", , True)

            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex

        End Try
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProjectType(ByVal AccountId As Integer, ByVal ProjectType As String, ByVal Original_AccountProjectTypeId As Integer, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal IsDisabled As Boolean) As Boolean

        ' Update the product record

        Dim AccountProjectTypes As TimeLiveDataSet.AccountProjectTypeDataTable = Adapter.GetDataByAccountProjectTypeId(Original_AccountProjectTypeId)
        Dim AccountProjectType As TimeLiveDataSet.AccountProjectTypeRow = AccountProjectTypes.Rows(0)

        With AccountProjectType
            .AccountId = AccountId
            .ProjectType = ProjectType
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountProjectType)


        CacheManager.ClearCache("AccountProjectTypeDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    'Public Function UpdateAccountProjectTypes(ByVal AccountId As Integer, ByVal ProjectType As String, ByVal Original_AccountProjectTypeId As Integer)

    '    ' Update the product record

    '    Dim AccountProjectTypes As TimeLiveDataSet.AccountProjectTypeDataTable = Adapter.GetDataByAccountProjectTypeId(Original_AccountProjectTypeId)
    '    Dim AccountProjectType As TimeLiveDataSet.AccountProjectTypeRow = AccountProjectTypes.Rows(0)

    '    With AccountProjectType
    '        .AccountId = AccountId
    '        .ProjectType = ProjectType
    '    End With

    '    Dim rowsAffected As Integer = Adapter.Update(AccountProjectType)


    '    CacheManager.ClearCache("AccountProjectTypeDataTable", , True)

    '    ' Return true if precisely one row was updated, otherwise false
    '    Return rowsAffected = 1
    'End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectType(ByVal Original_AccountProjectTypeId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountProjectTypeId)

        CacheManager.ClearCache("AccountProjectTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal UserInterfaceLanguage As String)
        Adapter.InsertDefault(AccountId, AccountEmployeeId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangeProjectTypeNameByUICulture(AccountId)
        End If
    End Sub
    Public Sub ChangeProjectTypeNameByUICulture(ByVal AccountId As Integer)
        Dim dtProjectType As TimeLiveDataSet.AccountProjectTypeDataTable = Me.GetAccountProjectTypeByAccountId(AccountId)
        Dim drProjectType As TimeLiveDataSet.AccountProjectTypeRow
        For Each drProjectType In dtProjectType.Rows
            Me.UpdateAccountProjectType(AccountId, ResourceHelper.GetDefaultDataLocalValue(drProjectType.ProjectType), drProjectType.AccountProjectTypeId, Now, drProjectType.CreatedByEmployeeId, Now, drProjectType.ModifiedByEmployeeId, drProjectType.IsDisabled)
        Next

    End Sub

End Class
