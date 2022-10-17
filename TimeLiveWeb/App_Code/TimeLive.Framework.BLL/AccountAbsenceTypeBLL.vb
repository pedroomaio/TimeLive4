Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
''' <summary>
''' This class perform database operations for AccountAbsenceType table. AccountAbsenceType table 
''' store records for Absence Type data
''' </summary>
''' <remarks>AccountAbsenceType Business Layer class</remarks>
<System.ComponentModel.DataObject()> _
Public Class AccountAbsenceTypeBLL
    Private CacheKey As String
    Private _AccountAbsenceTypeTableAdapter As AccountAbsenceTypeTableAdapter = Nothing
    ''' <summary>
    ''' Return Adapter object of AccountAbsenceTypeTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountAbsenceTypeTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property Adapter() As AccountAbsenceTypeTableAdapter
        Get
            If _AccountAbsenceTypeTableAdapter Is Nothing Then
                _AccountAbsenceTypeTableAdapter = New AccountAbsenceTypeTableAdapter()
            End If
            Return _AccountAbsenceTypeTableAdapter
        End Get
    End Property
    ''' <summary>
    ''' Returns all AccountAbsenceType records
    ''' </summary>
    ''' <returns>Returns AccountAbsenceType datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAbsenceTypes() As TimeLiveDataSet.AccountAbsenceTypeDataTable
        Return Adapter.GetData
    End Function
    ''' <summary>
    ''' Returns all AccountAbsenceType records of specified AccountId. After retrieved first time, datatable will be 
    ''' stored in TimeLive Cache collection with a unique key. If a cache record will be found, this function will simply
    ''' return datatable from cache collection.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <returns>AccountAbsenceType datatable</returns>
    ''' <remarks>This will return all absence types of specified accountid</remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAbsenceTypesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountAbsenceTypeDataTable
        ' Creating of unique cache key by combining of parameter value and function name
        CacheKey = CacheManager.GetCacheKeyForAccountsData("AccountAbsenceTypeDataTable", "GetAccountAbsenceTypesByAccountId", AccountId)
        ' If found in cache, then return from cache collection
        If Not CacheManager.GetItemFromCache(CacheKey) Is Nothing Then
            GetAccountAbsenceTypesByAccountId = CacheManager.GetItemFromCache(CacheKey)
        Else
            ' Otherwise simply call table adapter call to retrieve database records 
            GetAccountAbsenceTypesByAccountId = Adapter.GetDataByAccountId(AccountId)
            ' Store datatable in cache collection
            CacheManager.AddAccountDataInCache(GetAccountAbsenceTypesByAccountId, CacheKey)
        End If
        ' Add an empty row in table, if there is no row found. (ASP.Net GridView workaround)
        UIUtilities.FixTableForNoRecords(GetAccountAbsenceTypesByAccountId)
        Return GetAccountAbsenceTypesByAccountId
    End Function
    ''' <summary>
    ''' Returns all AccountAbsenceType records of specified AccountId.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <returns>AccountAbsenceType datatable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAbsenceTypeByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountAbsenceTypeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    ''' <summary>
    ''' Returns  AccountAbsenceType record of specified AccountAbsenceTypeId.
    ''' </summary>
    ''' <param name="AccountAbsenceTypeId"></param>
    ''' <returns>AccountAbsenceType datatable</returns>
    ''' <remarks></remarks>    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAbsenceTypesByAccountAbsenceTypeId(ByVal AccountAbsenceTypeId As Integer) As TimeLiveDataSet.AccountAbsenceTypeDataTable
        Return Adapter.GetDataByAccountAbsenceTypeId(AccountAbsenceTypeId)
    End Function
    ''' <summary>
    ''' Returns  AccountAbsenceType record of specified AccountId and AccountAbsenceTypeId .
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountAbsenceTypeId"></param>
    ''' <returns>AccountAbsenceType DataTable</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAbsenceTypesByAccountIdAndIsDisabled(ByVal AccountId As Integer) As TimeLiveDataSet.AccountAbsenceTypeDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId)
    End Function
    ''' <summary>
    ''' Add a new record in AccountAbsenceType table with values provided in parameters. After insert, this function will remove
    ''' cache object for AccountAbsenceType datatable.
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AbsenceDescription"></param>
    ''' <param name="CreatedOn"></param>
    ''' <param name="CreatedByEmployeeId"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="ModifiedByEmployeeId"></param>
    ''' <returns>Return true, if record will be inserted successfully</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountAbsenceType( _
                        ByVal AccountId As Integer, ByVal AbsenceDescription As String, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer _
                    ) As Boolean
        _AccountAbsenceTypeTableAdapter = New AccountAbsenceTypeTableAdapter
        Dim AccountAbsenceTypes As New TimeLiveDataSet.AccountAbsenceTypeDataTable

        'Create a new AccountAbsenceTypes datatable row 
        Dim AccountAbsenceType As TimeLiveDataSet.AccountAbsenceTypeRow = AccountAbsenceTypes.NewAccountAbsenceTypeRow

        ' Set all values from parameters to datarow attributes
        With AccountAbsenceType
            .AccountId = AccountId
            .AbsenceDescription = AbsenceDescription
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = False
        End With

        ' Add new row in datatable
        AccountAbsenceTypes.AddAccountAbsenceTypeRow(AccountAbsenceType)

        ' Call adapter update in order to insert record in database table
        Dim rowsAffected As Integer = Adapter.Update(AccountAbsenceTypes)

        ' Clear cache of AccountAbsenceType records
        CacheManager.ClearCache("AccountAbsenceTypeDataTable", , True)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Update AccountAbsenceType of specified AccountAbsenceTypeId. Function will retrieve table record of specified AccountAbsenceTypeId
    ''' And then after updating new values, it will update database record of AccountAbsenceType table
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AbsenceDescription"></param>
    ''' <param name="original_AccountAbsenceTypeId"></param>
    ''' <param name="CreatedOn"></param>
    ''' <param name="CreatedByEmployeeId"></param>
    ''' <param name="ModifiedOn"></param>
    ''' <param name="ModifiedByEmployeeId"></param>
    ''' <param name="IsDisabled"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountAbsenceType(ByVal AccountId As Integer, ByVal AbsenceDescription As String, ByVal original_AccountAbsenceTypeId As Integer, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, _
    ByVal IsDisabled As Boolean) As Boolean

        ' Retrieve AccountAbsenceType record of specified AccountAbsenceTypeId
        Dim AccountAbsenceTypes As TimeLiveDataSet.AccountAbsenceTypeDataTable = Adapter.GetDataByAccountAbsenceTypeId(original_AccountAbsenceTypeId)

        Dim AccountAbsenceType As TimeLiveDataSet.AccountAbsenceTypeRow = AccountAbsenceTypes.Rows(0)

        ' Set new values in datarow attributes
        With AccountAbsenceType
            .AbsenceDescription = AbsenceDescription
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
        End With

        ' Clear cache of AccountAbsenceType records
        CacheManager.ClearCache("AccountAbsenceTypeDataTable", , True)

        ' Update record in database using adapter.update
        Dim rowsAffected As Integer = Adapter.Update(AccountAbsenceType)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Delete AccountAbsenceType record of specified AccountAbsenceTypeId
    ''' </summary>
    ''' <param name="original_AccountAbsenceTypeId"></param>
    ''' <returns>Return true in case of succcessfully deleting of record</returns>
    ''' <remarks></remarks>
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountAbsenceType(ByVal original_AccountAbsenceTypeId As Integer) As Boolean
        ' Call Adapter delete function to delete record of specified id
        Dim rowsAffected As Integer = Adapter.Delete(original_AccountAbsenceTypeId)

        ' Clear cache of AccountAbsenceType records
        CacheManager.ClearCache("AccountAbsenceTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    ''' <summary>
    ''' Returns default AccountAbsenceType records in case of new account in TimeLive
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <param name="AccountEmployeeId"></param>
    ''' <param name="UserInterfaceLanguage"></param>
    ''' <remarks></remarks>
    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal UserInterfaceLanguage As String)
        ' Insert default records 
        Adapter.InsertDefault(AccountId, AccountEmployeeId)
        If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
            ' Change Absence Type name as per select UI culture
            Me.ChangeAbsenceNameByUICulture(AccountId)
        End If
    End Sub
    ''' <summary>
    ''' Change AbsenceType name as per selected culture
    ''' </summary>
    ''' <param name="AccountId"></param>
    ''' <remarks></remarks>
    Public Sub ChangeAbsenceNameByUICulture(ByVal AccountId As Integer)
        Dim dtAbsenceType As TimeLiveDataSet.AccountAbsenceTypeDataTable = Me.GetAccountAbsenceTypeByAccountId(AccountId)
        Dim drAbsenceType As TimeLiveDataSet.AccountAbsenceTypeRow
        For Each drAbsenceType In dtAbsenceType.Rows
            Me.UpdateAccountAbsenceType(AccountId, ResourceHelper.GetDefaultDataLocalValue(drAbsenceType.AbsenceDescription), drAbsenceType.AccountAbsenceTypeId, drAbsenceType.CreatedOn, drAbsenceType.CreatedByEmployeeId, drAbsenceType.ModifiedOn, drAbsenceType.ModifiedByEmployeeId, drAbsenceType.IsDisabled)
        Next
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAbsenceTypeByAccountIdAndAbsenceTypeName(ByVal AccountId As Integer, ByVal AbsenceTypeName As String) As TimeLiveDataSet.AccountAbsenceTypeDataTable
        GetAbsenceTypeByAccountIdAndAbsenceTypeName = Adapter.GetAbsenceTypeByAccountIdAndAbsenceTypeName(AccountId, AbsenceTypeName)
        Return GetAbsenceTypeByAccountIdAndAbsenceTypeName
    End Function
End Class
