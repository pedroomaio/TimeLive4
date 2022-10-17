Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountTaxZoneBLL
    Private _AccountTaxZoneTableAdapter As AccountTaxZoneTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As AccountTaxZoneTableAdapter
        Get
            If _AccountTaxZoneTableAdapter Is Nothing Then
                _AccountTaxZoneTableAdapter = New AccountTaxZoneTableAdapter()
            End If
            Return _AccountTaxZoneTableAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxZones() As TimeLiveDataSet.AccountTaxZoneDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxZoneByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountTaxZoneDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxZonesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountTaxZoneDataTable
        GetAccountTaxZonesByAccountId = Adapter.GetDataByAccountId(AccountId)
        Uiutilities.FixTableForNoRecords(GetAccountTaxZonesByAccountId)
        Return GetAccountTaxZonesByAccountId
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxZonesByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountTaxZoneId As Integer) As TimeLiveDataSet.AccountTaxZoneDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountTaxZoneId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTaxZonesByAccountTaxZoneId(ByVal AccountTaxZoneId As Integer) As TimeLiveDataSet.AccountTaxZoneDataTable
        Return Adapter.GetDataByAccountTaxZoneId(AccountTaxZoneId)
    End Function
    Public Function ValidateNewTaxZone(ByVal AccountTaxZone As String, ByVal AccountId As Integer) As Boolean
        If Adapter.GetByAccountTaxZoneAndAccountId(AccountTaxZone, AccountId).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function ValidateExistingTaxZone(ByVal AccountTaxZone As String, ByVal AccountTaxZoneId As Integer) As Boolean
        If Adapter.GetTaxZoneExcludingAccountTaxZoneId(AccountTaxZone, AccountTaxZoneId).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountTaxZone( _
            ByVal AccountId As Integer, _
            ByVal AccountTaxZone As String, _
            ByVal CreatedOn As DateTime, _
            ByVal CreatedByEmployeeId As Integer, _
            ByVal ModifiedOn As DateTime, _
            ByVal ModifiedByEmployeeId As Integer _
            ) As Boolean

        If Not Me.ValidateNewTaxZone(AccountTaxZone, AccountId) Then
            Throw New Exception("Specified tax zone already exist")
            Return False
        End If
        Try
            _AccountTaxZoneTableAdapter = New AccountTaxZoneTableAdapter

            Dim AccountTaxZones As New TimeLiveDataSet.AccountTaxZoneDataTable
            Dim AccountTaxZoneRow As TimeLiveDataSet.AccountTaxZoneRow = AccountTaxZones.NewAccountTaxZoneRow

            With AccountTaxZoneRow
                .AccountId = AccountId
                .AccountTaxZone = AccountTaxZone
                .CreatedOn = Now
                .CreatedByEmployeeId = CreatedByEmployeeId
                .ModifiedOn = Now
                .ModifiedByEmployeeId = ModifiedByEmployeeId
                .IsDisabled = False
            End With

            AccountTaxZones.AddAccountTaxZoneRow(AccountTaxZoneRow)

            Dim rowsAffected As Integer = Adapter.Update(AccountTaxZones)

            Return rowsAffected = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTaxZone( _
            ByVal AccountId As Integer, _
            ByVal AccountTaxZone As String, _
            ByVal CreatedOn As DateTime, _
            ByVal CreatedByEmployeeId As Integer, _
            ByVal ModifiedOn As DateTime, _
            ByVal ModifiedByEmployeeId As Integer, _
            ByVal IsDisabled As Boolean, _
            ByVal Original_AccountTaxZoneId As Integer _
            ) As Boolean

        Dim AccountTaxZones As TimeLiveDataSet.AccountTaxZoneDataTable = Adapter.GetDataByAccountTaxZoneId(Original_AccountTaxZoneId)
        Dim AccountTaxZoneRow As TimeLiveDataSet.AccountTaxZoneRow = AccountTaxZones.Rows(0)

        With AccountTaxZoneRow
            If .AccountTaxZone <> AccountTaxZone Then
                If Not Me.ValidateExistingTaxZone(AccountTaxZone, Original_AccountTaxZoneId) Then
                    Throw New Exception("Specified tax zone already exist")
                    Return False
                Else
                    .AccountTaxZone = AccountTaxZone
                End If
            End If
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
            .AccountId = AccountId
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountTaxZones)

        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTaxZones( _
            ByVal AccountId As Integer, _
            ByVal AccountTaxZone As String, _
            ByVal Original_AccountTaxZoneId As Integer _
            )

        Dim AccountTaxZones As TimeLiveDataSet.AccountTaxZoneDataTable = Adapter.GetDataByAccountTaxZoneId(Original_AccountTaxZoneId)
        Dim AccountTaxZoneRow As TimeLiveDataSet.AccountTaxZoneRow = AccountTaxZones.Rows(0)

        With AccountTaxZoneRow
            .AccountTaxZone = AccountTaxZone
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountTaxZones)

        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTaxZone(ByVal Original_AccountTaxZoneId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountTaxZoneId)

        Return rowsAffected = 1

    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal UserInterfaceLanguage As String = "")
        If IsExistsMasterRecord(AccountId) = False Then
            Adapter.InsertDefault(AccountId, AccountEmployeeId)
            If UserInterfaceLanguage = "de-DE" Then
                Me.ChangeTaxZoneNameByUICulture(AccountId)
            End If
        End If
    End Sub
    Public Sub ChangeTaxZoneNameByUICulture(ByVal AccountId As Integer)
        Dim dtTaxZone As TimeLiveDataSet.AccountTaxZoneDataTable = Me.GetAccountTaxZoneByAccountId(AccountId)
        Dim drTaxZone As TimeLiveDataSet.AccountTaxZoneRow
        For Each drTaxZone In dtTaxZone.Rows
            Me.UpdateAccountTaxZones(AccountId, ResourceHelper.GetDefaultDataLocalValue(drTaxZone.AccountTaxZone), drTaxZone.AccountTaxZoneId)
        Next
    End Sub
    Public Function IsExistsMasterRecord(ByVal AccountId As Integer) As Boolean
        If Adapter.GetDataByAccountIdMaster(AccountId).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
End Class
