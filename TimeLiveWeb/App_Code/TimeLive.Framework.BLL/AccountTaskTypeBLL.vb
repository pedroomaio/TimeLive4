Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountTaskTypeBLL

    Private _AccountTaskTypeTableAdapter As AccountTaskTypeTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountTaskTypeTableAdapter
        Get
            If _AccountTaskTypeTableAdapter Is Nothing Then
                _AccountTaskTypeTableAdapter = New AccountTaskTypeTableAdapter()
            End If

            Return _AccountTaskTypeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaskTypes() As TimeLiveDataSet.AccountTaskTypeDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaskTypesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountTaskTypeDataTable

        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountTaskTypeDataTable", "GetAccountTaskTypesByAccountId", AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountTaskTypesByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountTaskTypesByAccountId = Adapter.GetDataByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountTaskTypesByAccountId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountTaskTypesByAccountId)

        Return GetAccountTaskTypesByAccountId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaskTypesByAccountIdAndAccountTaskTypeId(ByVal AccountId As Integer, ByVal AccountTaskTypeId As Integer) As TimeLiveDataSet.AccountTaskTypeDataTable
        Return Adapter.GetDataByAccountIdAndAccountTaskTypeId(AccountId, AccountTaskTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTaskTypeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountTaskTypeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaskTypesByAccountTaskTypeId(ByVal AccountTaskTypeId As Integer) As TimeLiveDataSet.AccountTaskTypeDataTable
        Return Adapter.GetDataByAccountTaskTypeId(AccountTaskTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountTaskType( _
                        ByVal AccountId As Integer, ByVal TaskType As String, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountTaskTypeTableAdapter = New AccountTaskTypeTableAdapter

        Dim AccountTaskTypes As New TimeLiveDataSet.AccountTaskTypeDataTable
        Dim AccountTaskType As TimeLiveDataSet.AccountTaskTypeRow = AccountTaskTypes.NewAccountTaskTypeRow

        With AccountTaskType
            .AccountId = AccountId
            .TaskType = TaskType
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = False
        End With

        AccountTaskTypes.AddAccountTaskTypeRow(AccountTaskType)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountTaskTypes)

        CacheManager.ClearCache("AccountTaskTypeDataTable", , True)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTaskType(ByVal AccountId As Integer, ByVal TaskType As String, ByVal Original_AccountTaskTypeId As Integer, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal IsDisabled As Boolean) As Boolean

        ' Update the product record

        Dim AccountTaskTypes As TimeLiveDataSet.AccountTaskTypeDataTable = Adapter.GetDataByAccountTaskTypeId(Original_AccountTaskTypeId)
        Dim AccountTaskType As TimeLiveDataSet.AccountTaskTypeRow = AccountTaskTypes.Rows(0)

        With AccountTaskType
            .AccountId = AccountId
            .TaskType = TaskType
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountTaskType)

        CacheManager.ClearCache("AccountTaskTypeDataTable", , True)


        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTaskType(ByVal Original_AccountTaskTypeId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountTaskTypeId)

        CacheManager.ClearCache("AccountTaskTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        Adapter.InsertDefault(AccountId, AccountEmployeeId)
    End Sub
    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal UserInterfaceLanguage As String)
        Adapter.InsertDefault(AccountId, AccountEmployeeId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            Me.ChangeTaskNameByUICulture(AccountId)
        End If
    End Sub
    Public Sub ChangeTaskNameByUICulture(ByVal AccountId As Integer)
        Dim dtTaskType As TimeLiveDataSet.AccountTaskTypeDataTable = Me.GetTaskTypeByAccountId(AccountId)
        Dim drTaskType As TimeLiveDataSet.AccountTaskTypeRow
        For Each drTaskType In dtTaskType.Rows
            Me.UpdateAccountTaskType(AccountId, ResourceHelper.GetDefaultDataLocalValue(drTaskType.TaskType), drTaskType.AccountTaskTypeId, drTaskType.CreatedOn, drTaskType.CreatedByEmployeeId, drTaskType.ModifiedOn, drTaskType.ModifiedByEmployeeId, drTaskType.IsDisabled)
        Next

    End Sub
End Class
