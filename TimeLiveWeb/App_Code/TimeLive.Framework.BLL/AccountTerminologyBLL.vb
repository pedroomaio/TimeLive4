Imports Microsoft.VisualBasic
Imports AccountTerminologyTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountTerminologyBLL

    Private _AccountTerminologyTableAdapter As AccountTerminologyTableAdapter = Nothing
    Private strCacheKey As String
    Protected ReadOnly Property Adapter() As AccountTerminologyTableAdapter
        Get
            If _AccountTerminologyTableAdapter Is Nothing Then
                _AccountTerminologyTableAdapter = New AccountTerminologyTableAdapter
            End If

            Return _AccountTerminologyTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTerminologyByAccountId(ByVal AccountId As Integer, ByVal SystemTerminologyId As Integer) As AccountTerminology.vueAccountTerminologyDataTable
        Dim _vueAccountTerminologyTableAdapter As New vueAccountTerminologyTableAdapter
        GetvueAccountTerminologyByAccountId = _vueAccountTerminologyTableAdapter.GetDataByAccountId(AccountId)
        Return GetvueAccountTerminologyByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTerminologyByAccountIdForSearch() As AccountTerminology.vueAccountTerminologyDataTable
        Dim AccountId As Integer = DBUtilities.GetCurrentAccountId()
        strCacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountTerminologyDataTable", "GetvueAccountTerminologyByAccountId", "AccountId=" & AccountId, AccountId)
        If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
            GetAccountTerminologyByAccountIdForSearch = CacheManager.GetItemFromCache(strCacheKey)
        Else
            Dim _vueAccountTerminologyTableAdapter As New vueAccountTerminologyTableAdapter
            GetAccountTerminologyByAccountIdForSearch = _vueAccountTerminologyTableAdapter.GetDataByAccountIdOnly(AccountId)
            CacheManager.AddAccountDataInCache(GetAccountTerminologyByAccountIdForSearch, strCacheKey)
        End If
        Return GetAccountTerminologyByAccountIdForSearch
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTerminologyByAccountIdForSearchForEmail(ByVal AccountId As Integer) As AccountTerminology.vueAccountTerminologyDataTable
        Dim _vueAccountTerminologyTableAdapter As New vueAccountTerminologyTableAdapter
        GetAccountTerminologyByAccountIdForSearchForEmail = _vueAccountTerminologyTableAdapter.GetDataByAccountIdOnly(AccountId)
        Return GetAccountTerminologyByAccountIdForSearchForEmail
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTerminologiesByAccountId(ByVal AccountId As Integer) As AccountTerminology.vueAccountTerminologyDataTable
        Dim _vueAccountTerminologyTableAdapter As New vueAccountTerminologyTableAdapter
        GetTerminologiesByAccountId = _vueAccountTerminologyTableAdapter.GetTerminologiesByAccountId(AccountId)
        Return AddBlankRowsInDataTable(GetTerminologiesByAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTerminologyByAccountTerminologyId(ByVal AccountTerminologyId As Integer) As AccountTerminology.AccountTerminologyDataTable
        Return Adapter.GetDataByAccountTerminologyId(AccountTerminologyId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTerminologyByAccountId(ByVal AccountId As Integer) As AccountTerminology.AccountTerminologyDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTerminologyByAccountIdAndUserDefinedName(ByVal AccountId As Integer, ByVal UserDefinedName As String) As AccountTerminology.AccountTerminologyDataTable
        Return Adapter.GetDataByAccountIdAndUserDefinedName(AccountId, UserDefinedName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTerminologyByAccountIdAndUserDefinedNameAndAccountTerminologyId(ByVal AccountTerminologyId As Integer, ByVal AccountId As Integer, ByVal UserDefinedName As String) As AccountTerminology.AccountTerminologyDataTable
        Return Adapter.GetDataByAccountIdAndUserDefinedNameAndAccountTerminologyId(AccountTerminologyId, AccountId, UserDefinedName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemTerminolgys() As AccountTerminology.SystemTerminologyDataTable
        Dim _SystemTerminologyTableAdapter As New SystemTerminologyTableAdapter
        GetSystemTerminolgys = _SystemTerminologyTableAdapter.GetData
        Return GetSystemTerminolgys
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTerminologyByAccountIdAndTerminologyName(ByVal AccountId As Integer, ByVal TerminologyName As String) As AccountTerminology.vueAccountTerminologyDataTable
        Dim _vueAccountTerminologyTableAdapter As New vueAccountTerminologyTableAdapter
        GetvueAccountTerminologyByAccountIdAndTerminologyName = _vueAccountTerminologyTableAdapter.GetDataByAccountIdAndTerminologyName(AccountId, TerminologyName)
        Return GetvueAccountTerminologyByAccountIdAndTerminologyName
    End Function
    Public Function IsExistsAccountTerminology(ByVal AccountId As Integer, ByVal SystemTerminologyId As Integer) As Boolean
        If Me.Adapter.GetDataByAccountIdAndSystemTerminologyId(AccountId, SystemTerminologyId).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function AddAccountTerminology(ByVal AccountId As Integer, ByVal UserDefinedName As String, _
    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer, ByVal TerminologyName As String) As Boolean

        _AccountTerminologyTableAdapter = New AccountTerminologyTableAdapter

        Dim AccountTerminology As New AccountTerminology.AccountTerminologyDataTable
        Dim AccountTerminologyRow As AccountTerminology.AccountTerminologyRow = AccountTerminology.NewAccountTerminologyRow

        With AccountTerminologyRow
            .UserDefinedName = UserDefinedName
            .AccountId = AccountId
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .TerminologyName = TerminologyName
        End With

        AccountTerminology.AddAccountTerminologyRow(AccountTerminologyRow)
        Dim rowsAffected1 As Integer = Adapter.Update(AccountTerminology)
        Me.AfterUpdate()
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected1 = 1
    End Function

    Public Function UpdateAccountTerminology(ByVal Original_AccountTerminologyId As Integer, ByVal UserDefinedName As String, _
    ByVal ModifiedByEmployeeId As Integer, ByVal TerminologyName As String) As Boolean

        ' Update the product record

        Dim AccountTerminology As AccountTerminology.AccountTerminologyDataTable = Adapter.GetDataByAccountTerminologyId(Original_AccountTerminologyId)
        Dim AccountTerminologyRow As AccountTerminology.AccountTerminologyRow = AccountTerminology.Rows(0)

        With AccountTerminologyRow
            .UserDefinedName = UserDefinedName
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .TerminologyName = TerminologyName
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountTerminology)

        Me.AfterUpdate()

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    Public Function DeleteAccountTerminology(ByVal Original_AccountTerminologyId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountTerminologyId)

        Me.AfterUpdate()

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub AfterUpdate()
        CacheManager.ClearCache("AccountTerminology", , True)
    End Sub
    Public Function AddBlankRowsInDataTable(ByVal dtBlank As AccountTerminology.vueAccountTerminologyDataTable) As AccountTerminology.vueAccountTerminologyDataTable
        Dim detailRow As AccountTerminology.vueAccountTerminologyRow
        For n As Integer = 1 To 5
            detailRow = dtBlank.NewvueAccountTerminologyRow
            dtBlank.Rows.Add(detailRow)
        Next
        Return dtBlank
    End Function
    Public Shared Function GetTransformedStringFromTerminology(ByVal SourceValue As String, Optional ByVal AccountId As Integer = 0) As String
        Dim dtAccountTerminology As AccountTerminology.vueAccountTerminologyDataTable
        'If DBUtilities.IsAccountIdExistInSession() = False Then
        '    Return SourceValue
        'End If
        If DBUtilities.IsApplicationContext Then
            dtAccountTerminology = New AccountTerminologyBLL().GetAccountTerminologyByAccountIdForSearch
        Else
            dtAccountTerminology = New AccountTerminologyBLL().GetAccountTerminologyByAccountIdForSearchForEmail(AccountId)
        End If

        If dtAccountTerminology.Rows.Count = 0 Then
            Return SourceValue
        End If
        Dim drAccountTerminology As AccountTerminology.vueAccountTerminologyRow
        For Each drAccountTerminology In dtAccountTerminology.Rows
            If SourceValue.Contains(drAccountTerminology.TerminologyName) Then
                Return SourceValue.Replace(drAccountTerminology.TerminologyName, drAccountTerminology.UserDefinedName)
            End If
        Next
        Return SourceValue
    End Function

End Class
