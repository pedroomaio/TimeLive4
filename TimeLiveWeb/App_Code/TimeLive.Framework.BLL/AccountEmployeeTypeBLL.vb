Imports Microsoft.VisualBasic
Imports AccountEmployeeTypeTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeTypeBLL

    Private _AccountEmployeeTypeTableAdapter As AccountEmployeeTypeTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As AccountEmployeeTypeTableAdapter
        Get
            If _AccountEmployeeTypeTableAdapter Is Nothing Then
                _AccountEmployeeTypeTableAdapter = New AccountEmployeeTypeTableAdapter()
            End If

            Return _AccountEmployeeTypeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTypeByAccountId(ByVal AccountId As Integer) As AccountEmployeeType.AccountEmployeeTypeDataTable
        GetAccountEmployeeTypeByAccountId = Adapter.GetDataByAccountId(AccountId)
        UIUtilities.FixTableForNoRecords(GetAccountEmployeeTypeByAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTypeByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountEmployeeTypeId As Guid) As AccountEmployeeType.AccountEmployeeTypeDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountEmployeeTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTypeByAccountEmployeeTypeId(ByVal AccountEmployeeTypeId As Guid) As AccountEmployeeType.AccountEmployeeTypeDataTable
        Return Adapter.GetDataByAccountEmployeeTypeId(AccountEmployeeTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountEmployeeTypeByAccountIdAndMasterEmployeeTypeId(ByVal AccountId As Integer, ByVal MasterEmployeeTypeId As Guid) As AccountEmployeeType.AccountEmployeeTypeDataTable
        Return Adapter.GetDataByMasterEmployeeTypeId(AccountId, MasterEmployeeTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountEmployeeType( _
                    ByVal AccountId As Integer, ByVal AccountEmployeeType As String, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer, ByVal IsVendor As Boolean _
                ) As Guid

        _AccountEmployeeTypeTableAdapter = New AccountEmployeeTypeTableAdapter

        Dim dtEmployeeType As New AccountEmployeeType.AccountEmployeeTypeDataTable
        Dim drEmployeeType As AccountEmployeeType.AccountEmployeeTypeRow = dtEmployeeType.NewAccountEmployeeTypeRow
        Dim nAccountEmployeeTypeId As Guid = System.Guid.NewGuid
        With drEmployeeType
            .AccountEmployeeTypeId = nAccountEmployeeTypeId
            .AccountId = AccountId
            .AccountEmployeeType = AccountEmployeeType
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = False
            .IsVendor = IsVendor
        End With

        dtEmployeeType.AddAccountEmployeeTypeRow(drEmployeeType)

        Dim rowsAffected As Integer = Adapter.Update(dtEmployeeType)

        Return nAccountEmployeeTypeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeType(ByVal AccountEmployeeType As String, ByVal Original_AccountEmployeeTypeId As Guid, ByVal ModifiedByEmployeeId As Integer, _
    ByVal IsDisabled As Boolean, ByVal IsVendor As Boolean) As Boolean

        Dim dtEmployeeType As AccountEmployeeType.AccountEmployeeTypeDataTable = Adapter.GetDataByAccountEmployeeTypeId(Original_AccountEmployeeTypeId)
        Dim drEmployeeType As AccountEmployeeType.AccountEmployeeTypeRow = dtEmployeeType.Rows(0)

        With drEmployeeType
            .AccountEmployeeType = AccountEmployeeType
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
            .IsVendor = IsVendor
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtEmployeeType)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountEmployeeTypeResource(ByVal AccountEmployeeType As String, ByVal Original_AccountEmployeeTypeId As Guid, ByVal ModifiedByEmployeeId As Integer, _
    ByVal IsDisabled As Boolean) As Boolean

        Dim dtEmployeeType As AccountEmployeeType.AccountEmployeeTypeDataTable = Adapter.GetDataByAccountEmployeeTypeId(Original_AccountEmployeeTypeId)
        Dim drEmployeeType As AccountEmployeeType.AccountEmployeeTypeRow = dtEmployeeType.Rows(0)

        With drEmployeeType
            .AccountEmployeeType = AccountEmployeeType
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtEmployeeType)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountEmployeeType(ByVal Original_AccountEmployeeTypeId As Guid) As Boolean
        Try
            Dim rowsAffected As Integer = Adapter.Delete(Original_AccountEmployeeTypeId)

            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception("Can’t delete. Dependent data is exist with this record.")
        End Try
    End Function
    Public Function InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal UserInterfaceLanguage As String = "")
        Adapter.InsertDefault(AccountId, AccountEmployeeId)
        Dim AccountEmployeeTypeId As Guid = GetDefaultAccountEmployeeTypeId(AccountId)
        If UserInterfaceLanguage <> "" Then
            If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
                Me.ChangeEmployeeNameByUICulture(AccountId)
            End If
        End If
        Return AccountEmployeeTypeId
    End Function
    Public Sub ChangeEmployeeNameByUICulture(ByVal AccountId As Integer)
        Dim dtEmployeeType As AccountEmployeeType.AccountEmployeeTypeDataTable = Me.GetAccountEmployeeTypeByAccountId(AccountId)
        Dim drEmployeeType As AccountEmployeeType.AccountEmployeeTypeRow
        For Each drEmployeeType In dtEmployeeType.Rows
            Me.UpdateAccountEmployeeTypeResource(ResourceHelper.GetFromResource(drEmployeeType.AccountEmployeeType), drEmployeeType.AccountEmployeeTypeId, drEmployeeType.ModifiedByEmployeeId, drEmployeeType.IsDisabled)
        Next
    End Sub
    Public Function GetDefaultAccountEmployeeTypeId(ByVal AccountId As Integer) As Guid
        Dim MasterEmployeeTypeId As New Guid("95ca4b30-9afc-4997-88e1-1533cce32899")
        Dim dtEmployeeType As AccountEmployeeType.AccountEmployeeTypeDataTable = Me.GetAccountEmployeeTypeByAccountIdAndMasterEmployeeTypeId(AccountId, MasterEmployeeTypeId)
        Dim drEmployeeType As AccountEmployeeType.AccountEmployeeTypeRow
        If dtEmployeeType.Rows.Count > 0 Then
            drEmployeeType = dtEmployeeType.Rows(0)
            Return drEmployeeType.AccountEmployeeTypeId
        End If
    End Function
    Public Function GetDefaultVendorAccountEmployeeTypeId(ByVal AccountId As Integer) As Guid
        Dim MasterEmployeeTypeId As New Guid("116E529E-5416-4800-B651-4B2016DF3D02")
        Dim dt As AccountEmployeeType.AccountEmployeeTypeDataTable = Me.GetAccountEmployeeTypeByAccountIdAndMasterEmployeeTypeId(AccountId, MasterEmployeeTypeId)
        Dim dr As AccountEmployeeType.AccountEmployeeTypeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.AccountEmployeeTypeId
        Else
            Return Me.AddAccountEmployeeType(AccountId, "Vendor", DBUtilities.GetSessionAccountEmployeeId, DBUtilities.GetSessionAccountEmployeeId, True)
        End If
    End Function
    Public Function GetDefaultVendorAccountEmployeeTypeId1(ByVal AccountId As Integer) As Guid
        'Dim MasterEmployeeTypeId As New Guid("116E529E-5416-4800-B651-4B2016DF3D02")
        'Dim dt As AccountEmployeeType.AccountEmployeeTypeDataTable = Me.GetAccountEmployeeTypeByAccountIdAndMasterEmployeeTypeId(AccountId, MasterEmployeeTypeId)
        'Dim dr As AccountEmployeeType.AccountEmployeeTypeRow
        'If dt.Rows.Count > 0 Then
        '    dr = dt.Rows(0)
        '    Return dr.AccountEmployeeTypeId
        'Else
        '    Return Me.AddAccountEmployeeType(AccountId, "Vendor", DBUtilities.GetSessionAccountEmployeeId, DBUtilities.GetSessionAccountEmployeeId, True)
        'End If
    End Function
End Class
