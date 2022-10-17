Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AuditBLL

    Private _AuditTableAdapter As AuditTableAdapter = Nothing
    Dim strCacheKey As String
    Protected ReadOnly Property Adapter() As AuditTableAdapter
        Get
            If _AuditTableAdapter Is Nothing Then
                _AuditTableAdapter = New AuditTableAdapter()
            End If

            Return _AuditTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAudits() As TimeLiveDataSet.AuditDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByTableName(ByVal PK As String) As TimeLiveDataSet.vueAuditDataTable

        '       strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAuditDataTable", "GetDataByTableName", "PK=" & PK)

        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        '    GetDataByTableName = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim _vueAuditTableAdapter As New vueAuditTableAdapter
        GetDataByTableName = _vueAuditTableAdapter.GetDataByTableName(DBUtilities.GetSessionAccountId, PK)
        '        CacheManager.AddAccountDataInCache(GetDataByTableName, strCacheKey)
        'End If

        UIUtilities.FixTableForNoRecords(GetDataByTableName)

        Return GetDataByTableName
        'Dim _vueAuditTableAdapter As New vueAuditTableAdapter
        'Return _vueAuditTableAdapter.GetDataByTableName(PK)
    End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    'Public Function AddAccountWorkingDay( _
    '                    ByVal AccountId As Integer, ByVal WorkingDayNo As Integer) As Boolean
    '    ' Create a new ProductRow instance


    '    _AccountWorkingDayTableAdapter = New AccountWorkingDayTableAdapter

    '    Dim AccountWorkingDays As New TimeLiveDataSet.AccountWorkingDayDataTable
    '    Dim AccountWorkingDay As TimeLiveDataSet.AccountWorkingDayRow = AccountWorkingDays.NewAccountWorkingDayRow

    '    With AccountWorkingDay
    '        .AccountId = AccountId
    '        .WorkingDayNo = WorkingDayNo
    '    End With

    '    AccountWorkingDays.AddAccountWorkingDayRow(AccountWorkingDay)


    '    ' Add the new product
    '    Dim rowsAffected As Integer = Adapter.Update(AccountWorkingDays)

    '    ' Return true if precisely one row was inserted, otherwise false
    '    Return rowsAffected = 1


    'End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    'Public Function DeleteAccountWorkingDayId(ByVal Original_AccountWorkingDayId As Integer) As Boolean
    '    Dim rowsAffected As Integer = Adapter.Delete(Original_AccountWorkingDayId)

    '    ' Return true if precisely one row was deleted, otherwise false
    '    Return rowsAffected = 1
    'End Function

    'Public Sub InsertDefault(ByVal AccountId As Integer)
    '    Adapter.InsertDefault(AccountId)
    'End Sub

End Class