Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports TimeLiveDataSet
''' <summary>
''' This class perform database operations for AccountApproval table. AccountApproval table 
''' store records for Approval Type data
''' </summary>
''' <remarks></remarks>
<System.ComponentModel.DataObject()> _
Public Class AccountApprovalBLL

    Private CacheKey As String
    Private _vueAccountApprovalTableAdapter As vueAccountApprovalTableAdapter = Nothing
    Private _AccountApprovalTypeTableAdapter As AccountApprovalTypeTableAdapter = Nothing
    Private _AccountApprovalPathTableAdapter As AccountApprovalPathTableAdapter = Nothing
    ''' <summary>
    ''' Return Adapter object of vueAccountApprovalTableAdapter table adapter
    ''' </summary>
    ''' <value></value>
    ''' <returns>AccountAbsenceTypeTableAdapter table adapter</returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property vueAccountApprovalAdapter() As vueAccountApprovalTableAdapter
        Get
            If _vueAccountApprovalTableAdapter Is Nothing Then
                _vueAccountApprovalTableAdapter = New vueAccountApprovalTableAdapter()
            End If

            Return _vueAccountApprovalTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountApprovalTypeAdapter() As AccountApprovalTypeTableAdapter
        Get
            If _AccountApprovalTypeTableAdapter Is Nothing Then
                _AccountApprovalTypeTableAdapter = New AccountApprovalTypeTableAdapter()
            End If

            Return _AccountApprovalTypeTableAdapter
        End Get
    End Property

    Protected ReadOnly Property AccountApprovalPathAdapter() As AccountApprovalPathTableAdapter
        Get
            If _AccountApprovalPathTableAdapter Is Nothing Then
                _AccountApprovalPathTableAdapter = New AccountApprovalPathTableAdapter()
            End If

            Return _AccountApprovalPathTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountApprovals() As TimeLiveDataSet.vueAccountApprovalDataTable
        Return vueAccountApprovalAdapter.GetData()
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountApprovalsByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountApprovalDataTable
        GetvueAccountApprovalsByAccountId = vueAccountApprovalAdapter.GetAccountApprovalsByAccountId(AccountId)
        UIUtilities.FixTableForNoRecords(GetvueAccountApprovalsByAccountId)
        Return GetvueAccountApprovalsByAccountId
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalTypes() As TimeLiveDataSet.AccountApprovalTypeDataTable
        Return AccountApprovalTypeAdapter.GetData()
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalTypesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountApprovalTypeDataTable
        Return AccountApprovalTypeAdapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalTypesByAccountApprovalTypeIdandIstimeoff(ByVal AccountApprovalTypeId As Integer) As TimeLiveDataSet.AccountApprovalTypeDataTable
        Return AccountApprovalTypeAdapter.GetDataByAccountApprovalTypeIdandIsTimeOff(AccountApprovalTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalTypesByAccountIdForTimeOffApproval(ByVal AccountId As Integer) As TimeLiveDataSet.AccountApprovalTypeDataTable
        Return AccountApprovalTypeAdapter.GetDataByAccountIdForTimeOffApproval(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalTypesByAccountIdForTimeSheetApproval(ByVal AccountId As Integer) As TimeLiveDataSet.AccountApprovalTypeDataTable
        Return AccountApprovalTypeAdapter.GetDataByAccountIdForTimeSheetApproval(AccountId)
    End Function
    '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    'Public Function GetAccountApprovalPathByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountApprovalPathDataTable
    '    Return AccountApprovalPathAdapter.get
    'End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetMaxApprovalPathSequenceByAccountApprovalTypeId(ByVal AccountApprovalTypeId As Integer) As TimeLiveDataSet.AccountApprovalPathDataTable
        Return AccountApprovalPathAdapter.GetMaxApprovalPathSequence(AccountApprovalTypeId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalPaths() As TimeLiveDataSet.AccountApprovalPathDataTable
        Return AccountApprovalPathAdapter.GetData()
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalPathsByAccountApprovalPathId(ByVal AccountApprovalPathId As Integer) As TimeLiveDataSet.AccountApprovalPathDataTable
        Return AccountApprovalPathAdapter.GetDataByAccountApprovalPathId(AccountApprovalPathId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalPathsByAccountApprovalTypeId(ByVal AccountApprovalTypeId As Integer) As TimeLiveDataSet.AccountApprovalPathDataTable
        Return AddBlankRowsInDataTable(AccountApprovalPathAdapter.GetDataByAccountApprovalTypeId(AccountApprovalTypeId))
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalPathsByAccountApprovalTypeIdAndAccountId(ByVal AccountApprovalTypeId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.AccountApprovalPathDataTable
        Return AccountApprovalPathAdapter.GetDataByAccountApprovalTypeIdAndAccountId(AccountApprovalTypeId, AccountId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountApprovalTypesByAccountApprovalTypeId(ByVal AccountApprovalTypeId As Integer, ByVal AccountId As Integer) As TimeLiveDataSet.AccountApprovalTypeDataTable
        Return AccountApprovalTypeAdapter.GetDataByAccountApprovalTypeId(AccountApprovalTypeId, AccountId)
    End Function
    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountApprovalTypeLastId.Rows(0)
        Return a.LastId
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountApprovalType(ByVal ApprovalTypeName As String, ByVal AccountId As Integer, ByVal MasterAccountApprovalTypeId As Integer, ByVal IsTimeOffApprovalTypes As Boolean) As Boolean
        ' Create a new ProductRow instance
        Try
            _AccountApprovalTypeTableAdapter = New AccountApprovalTypeTableAdapter
            Dim AccountApprovalTypes As New TimeLiveDataSet.AccountApprovalTypeDataTable
            Dim AccountApprovalTypesRow As TimeLiveDataSet.AccountApprovalTypeRow = AccountApprovalTypes.NewAccountApprovalTypeRow

            With AccountApprovalTypesRow
                .ApprovalTypeName = ApprovalTypeName
                .AccountId = AccountId
                '.MasterAccountApprovalTypeId = MasterAccountApprovalTypeId
                .IsTimeOffApprovalTypes = IsTimeOffApprovalTypes
            End With

            AccountApprovalTypes.AddAccountApprovalTypeRow(AccountApprovalTypesRow)

            'Dim rowsAffected As Integer = .InsertRole(AccountId, Role, False, Now, CreatedByEmployeeId, Now, ModifiedByEmployeeId)
            Dim rowsAffected As Integer = AccountApprovalTypeAdapter.Update(AccountApprovalTypes)

            CacheManager.ClearCache("AccountApprovalTypeDataTable", , True)

            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountApprovalType(ByVal ApprovalTypeName As String, ByVal AccountId As Integer, ByVal MasterAccountApprovalTypeId As Integer, ByVal Original_AccountApprovalTypeId As Integer, ByVal IsTimeOffApprovalTypes As Boolean) As Boolean

        ' Update the product record

        Dim AccountApprovalTypes As TimeLiveDataSet.AccountApprovalTypeDataTable = AccountApprovalTypeAdapter.GetDataByAccountApprovalTypeId(Original_AccountApprovalTypeId, AccountId)
        Dim AccountApprovalTypesRow As TimeLiveDataSet.AccountApprovalTypeRow = AccountApprovalTypes.Rows(0)

        With AccountApprovalTypesRow
            .ApprovalTypeName = ApprovalTypeName
            .AccountId = AccountId
            .MasterAccountApprovalTypeId = MasterAccountApprovalTypeId
            .IsTimeOffApprovalTypes = IsTimeOffApprovalTypes
        End With

        Dim rowsAffected As Integer = AccountApprovalTypeAdapter.Update(AccountApprovalTypes)

        CacheManager.ClearCache("AccountApprovalTypeDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountApprovalPath(ByVal AccountId As Integer, ByVal AccountApprovalTypeId As Integer, ByVal SystemApproverTypeId As Short, ByVal AccountExternalUserId As Integer, ByVal AccountEmployeeId As Integer, ByVal ApprovalPathSequence As String) As Boolean

        ' Create a new ProductRow instance

        Try


            _AccountApprovalPathTableAdapter = New AccountApprovalPathTableAdapter


            Dim AccountApprovalPaths As New TimeLiveDataSet.AccountApprovalPathDataTable
            Dim AccountApprovalPathsRow As TimeLiveDataSet.AccountApprovalPathRow = AccountApprovalPaths.NewAccountApprovalPathRow

            With AccountApprovalPathsRow
                .AccountId = AccountId
                .AccountApprovalTypeId = AccountApprovalTypeId
                .SystemApproverTypeId = SystemApproverTypeId
                If AccountExternalUserId <> 0 Then
                    .AccountExternalUserId = AccountExternalUserId
                Else
                    .Item("AccountExternalUserId") = System.DBNull.Value
                End If
                If AccountEmployeeId <> 0 Then
                    .AccountEmployeeId = AccountEmployeeId
                Else
                    .Item("AccountEmployeeId") = System.DBNull.Value
                End If
                .ApprovalPathSequence = ApprovalPathSequence
            End With

            AccountApprovalPaths.AddAccountApprovalPathRow(AccountApprovalPathsRow)

            'Dim rowsAffected As Integer = .InsertRole(AccountId, Role, False, Now, CreatedByEmployeeId, Now, ModifiedByEmployeeId)
            Dim rowsAffected As Integer = AccountApprovalPathAdapter.Update(AccountApprovalPaths)

            CacheManager.ClearCache("AccountApprovalPathDataTable", , True)

            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountApprovalPath(ByVal AccountId As Integer, ByVal AccountApprovalTypeId As Integer, ByVal SystemApproverTypeId As Short, ByVal AccountExternalUserId As Integer, ByVal AccountEmployeeId As Integer, ByVal ApprovalPathSequence As String, ByVal Original_AccountApprovalPathId As System.Nullable(Of Integer)) As Boolean

        ' Update the product record

        Dim AccountApprovalPaths As TimeLiveDataSet.AccountApprovalPathDataTable = AccountApprovalPathAdapter.GetDataByAccountApprovalPathId(Original_AccountApprovalPathId)
        Dim AccountApprovalPathsRow As TimeLiveDataSet.AccountApprovalPathRow = AccountApprovalPaths.Rows(0)

        With AccountApprovalPathsRow
            .AccountId = AccountId
            .AccountApprovalTypeId = AccountApprovalTypeId
            .SystemApproverTypeId = SystemApproverTypeId
            If AccountExternalUserId <> 0 Then
                .AccountExternalUserId = AccountExternalUserId
            Else
                .Item("AccountExternalUserId") = System.DBNull.Value
            End If
            If AccountEmployeeId <> 0 Then
                .AccountEmployeeId = AccountEmployeeId
            Else
                .Item("AccountEmployeeId") = System.DBNull.Value
            End If
            .ApprovalPathSequence = ApprovalPathSequence
        End With

        Dim rowsAffected As Integer = AccountApprovalPathAdapter.Update(AccountApprovalPathsRow)

        CacheManager.ClearCache("AccountApprovalPathDataTable", , True)

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountApprovals(ByVal Original_AccountApprovalTypeId As Integer) As Boolean
        Dim rowsAffected As Integer = AccountApprovalTypeAdapter.Delete(Original_AccountApprovalTypeId)

        CacheManager.ClearCache("AccountApprovalTypeDataTable", , True)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function DeleteAccountApprovalPath(ByVal Original_AccountApprovalPathId As Integer) As Boolean
        Dim rowsAffected As Integer = AccountApprovalPathAdapter.DeleteQuery(Original_AccountApprovalPathId)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function GetBlankDetail() As TimeLiveDataSet.AccountApprovalPathDataTable

        Dim dtBlank As TimeLiveDataSet.AccountApprovalPathDataTable = Me.GetAccountApprovalPathsByAccountApprovalTypeId(-1)

        Return dtBlank

    End Function

    Public Function AddBlankRowsInDataTable(ByVal dtBlank As AccountApprovalPathDataTable) As TimeLiveDataSet.AccountApprovalPathDataTable

        Dim detailRow As AccountApprovalPathRow
        For n As Integer = 1 To 5
            detailRow = dtBlank.NewAccountApprovalPathRow
            detailRow.AccountId = 0
            detailRow.AccountApprovalTypeId = 0
            detailRow.SystemApproverTypeId = 0
            detailRow.ApprovalPathSequence = 1
            detailRow.AccountExternalUserId = 0
            detailRow.AccountEmployeeId = 0
            dtBlank.Rows.Add(detailRow)
        Next

        Return dtBlank
    End Function
    Public Sub InsertDefaultAccountApprovalType(ByVal AccountId As Integer, ByVal UserInterfaceLanguage As String)
        If Me.GetAccountApprovalTypesByAccountId(AccountId).Rows.Count = 0 Then
            AccountApprovalTypeAdapter.InsertDefault(AccountId)
            If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
                Me.ChangeApprovalTypeNameByUICulture(AccountId)
            End If
        End If
    End Sub
    Public Sub ChangeApprovalTypeNameByUICulture(ByVal AccountId As Integer)
        Dim dtApprovalType As TimeLiveDataSet.AccountApprovalTypeDataTable = Me.GetAccountApprovalTypesByAccountId(AccountId)
        Dim drApprovalType As TimeLiveDataSet.AccountApprovalTypeRow
        For Each drApprovalType In dtApprovalType.Rows
            Me.UpdateAccountApprovalType(ResourceHelper.GetDefaultDataLocalValue(drApprovalType.ApprovalTypeName), drApprovalType.AccountId, drApprovalType.MasterAccountApprovalTypeId, drApprovalType.AccountApprovalTypeId, drApprovalType.IsTimeOffApprovalTypes)
        Next

    End Sub
    Public Sub InsertDefaultAccountApprovalPath(ByVal AccountId As Integer)
        AccountApprovalPathAdapter.InsertDefault(AccountId)
        UpdateAccountEmployeeIdInTimeOffAdministrator(AccountId)
    End Sub
    Public Sub InsertEmployeeManagerApprovalType(ByVal AccountId As Integer)
        AccountApprovalTypeAdapter.InsertEmployeeManagerApprovalType(AccountId)
    End Sub
    Public Sub InsertEmployeeManagerApprovalPath(ByVal AccountId As Integer, ByVal AccountApprovalTypeId As Integer)
        AccountApprovalPathAdapter.InsertEmployeeManagerApprovalPath(AccountId, AccountApprovalTypeId)
    End Sub
    Public Sub InsertDefaultAccountApprovalPathForEmployeeTimeOff(ByVal AccountId As Integer)
        If AccountApprovalPathAdapter.GetDataByAccountIdAndMasterApprovalPathId(AccountId, 6).Rows.Count = 0 Then
            AccountApprovalPathAdapter.InsertDefaultForTimeOff(AccountId)
        End If
    End Sub
    Public Sub InsertDefaultAccountApprovalTypeForEmployeeTimeOff(ByVal AccountId As Integer)
        If AccountApprovalTypeAdapter.GetDataByAccountIdAndMasterApprovalId(AccountId, 5).Rows.Count = 0 Then
            AccountApprovalTypeAdapter.InsertDefaultForTimeOff(AccountId)
        End If
    End Sub
    Public Sub UpdateAccountEmployeeIdInTimeOffAdministrator(ByVal AccountId As Integer)
        AccountApprovalPathAdapter.UpdateAccountEmployeeIdInTimeOffAdministrator(AccountId)
    End Sub
End Class
