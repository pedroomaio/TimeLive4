Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountDepartmentBLL
    Private _AccountDepartmentTableAdapter As AccountDepartmentTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountDepartmentTableAdapter
        Get
            If _AccountDepartmentTableAdapter Is Nothing Then
                _AccountDepartmentTableAdapter = New AccountDepartmentTableAdapter()
            End If

            Return _AccountDepartmentTableAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountDepartments() As TimeLiveDataSet.AccountDepartmentDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
     Public Function GetAccountDepartmentsByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountDepartmentId As Integer) As TimeLiveDataSet.AccountDepartmentDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountDepartmentId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountDepartmentsByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountDepartmentDataTable


        strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountDepartmentDataTable", "GetAccountDepartmentsByAccountId", "AccountId=" & AccountId)

        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountDepartmentsByAccountId = CacheManager.GetItemFromCache(strCacheKey)
        Else
            GetAccountDepartmentsByAccountId = Adapter.GetDepartmentByAccountId(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountDepartmentsByAccountId, strCacheKey)
        End If

        Uiutilities.FixTableForNoRecords(GetAccountDepartmentsByAccountId)

        Return GetAccountDepartmentsByAccountId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountDepartmentsByAccountDepartmentId(ByVal AccountDepartmentId As Integer) As TimeLiveDataSet.AccountDepartmentDataTable
        Return Adapter.GetDataByAccountDepartmentId(AccountDepartmentId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDefaultDepartmentByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountDepartmentDataTable
        Return Adapter.GetDefaultDepartmentByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountDepartment( _
                        ByVal AccountId As Integer, ByVal DepartmentCode As String, ByVal DepartmentName As String, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer _
                    ) As Integer
        ' Create a new ProductRow instance
        _AccountDepartmentTableAdapter = New AccountDepartmentTableAdapter

        With _AccountDepartmentTableAdapter
            Dim NewDepartmentId As Integer = .InsertDepartment(AccountId, DepartmentCode, DepartmentName, Now, Now, CreatedByEmployeeId, ModifiedByEmployeeId)
            ' Return true if precisely one row was inserted, otherwise false
            CacheManager.ClearCache("AccountDepartmentDataTable", , True)
            Return NewDepartmentId
        End With
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountDepartment(ByVal AccountId As Integer, ByVal DepartmentCode As String, ByVal DepartmentName As String, ByVal original_AccountDepartmentId As Integer, ByVal IsDisabled As Boolean, ByVal IsDeleted As Boolean, ByVal CreatedOn As DateTime, ByVal ModifiedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer) As Boolean

        ' Update the product record

        Dim AccountDepartments As TimeLiveDataSet.AccountDepartmentDataTable = Adapter.GetDataByAccountDepartmentId(original_AccountDepartmentId)
        Dim AccountDepartment As TimeLiveDataSet.AccountDepartmentRow = AccountDepartments.Rows(0)

        With AccountDepartment
            .AccountId = AccountId
            .DepartmentCode = DepartmentCode
            .DepartmentName = DepartmentName
            .IsDisabled = IsDisabled
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With




        Dim rowsAffected As Integer = Adapter.Update(AccountDepartment)

        CacheManager.ClearCache("AccountDepartmentDataTable", , True)


        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountDepartment(ByVal Original_AccountDepartmentId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountDepartmentId)

        CacheManager.ClearCache("AccountDepartmentDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function GetDepartmentIdForQB(AccountId As Integer) As Integer
        Dim nDepartmentId As Integer
        Dim dtDepartment As TimeLiveDataSet.AccountDepartmentDataTable = Me.GetDefaultDepartmentByAccountId(AccountId)
        Dim drDepartment As TimeLiveDataSet.AccountDepartmentRow
        If dtDepartment.Rows.Count > 0 Then
            drDepartment = dtDepartment.Rows(0)
            nDepartmentId = drDepartment.AccountDepartmentId
        Else
            nDepartmentId = Me.AddAccountDepartment(AccountId, "Default", "Default Department", 0, 0)
        End If
        Return nDepartmentId
    End Function

End Class
