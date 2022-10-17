Imports Microsoft.VisualBasic
Imports AccountTimeOffPolicyTableAdapters
Imports AccountTimeOffPolicy

<System.ComponentModel.DataObject()> _
Public Class AccountTimeOffPolicyBLL

    Private _AccountTimeOffPolicyTableAdapter As AccountTimeOffPolicyTableAdapter = Nothing
    Private _AccountTimeOffPolicyDetailTableAdapter As AccountTimeOffPolicyDetailTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As AccountTimeOffPolicyTableAdapter
        Get
            If _AccountTimeOffPolicyTableAdapter Is Nothing Then
                _AccountTimeOffPolicyTableAdapter = New AccountTimeOffPolicyTableAdapter()
            End If

            Return _AccountTimeOffPolicyTableAdapter
        End Get
    End Property

    Protected ReadOnly Property DetailAdapter() As AccountTimeOffPolicyDetailTableAdapter
        Get
            If _AccountTimeOffPolicyDetailTableAdapter Is Nothing Then
                _AccountTimeOffPolicyDetailTableAdapter = New AccountTimeOffPolicyDetailTableAdapter()
            End If

            Return _AccountTimeOffPolicyDetailTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffPolicyByAccountId(ByVal AccountId As Integer) As AccountTimeOffPolicy.AccountTimeOffPolicyDataTable
        GetAccountTimeOffPolicyByAccountId = Adapter.GetDataByAccountId(AccountId)
        UIUtilities.FixTableForNoRecords(GetAccountTimeOffPolicyByAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffPolicyByAccountTimeOffPolicyId(ByVal AccountTimeOffPolicyId As Guid) As AccountTimeOffPolicy.AccountTimeOffPolicyDataTable
        Return Adapter.GetDataByAccountTimeOffPolicyId(AccountTimeOffPolicyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffPolicyByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountTimeOffPolicyId As Guid) As AccountTimeOffPolicy.AccountTimeOffPolicyDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountTimeOffPolicyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountTimeOffPolicyDetailByAccountTimeOffPolicyId(ByVal AccountId As Integer, ByVal AccountTimeOffPolicyId As Guid) As AccountTimeOffPolicy.vueAccountTimeOffPolicyDetailDataTable
        Dim _vueAccountTimeOffPolicyDetailTableAdapter As New vueAccountTimeOffPolicyDetailTableAdapter
        Return AddBlankRowsInDataTableWithTimeOffTypeId(_vueAccountTimeOffPolicyDetailTableAdapter.GetDataByAccountTimeOffPolicyId(AccountId, AccountTimeOffPolicyId))
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffPolicyDetailByTimeOffPolicyId(ByVal AccountId As Integer, ByVal AccountTimeOffPolicyId As Guid) As AccountTimeOffPolicy.AccountTimeOffPolicyDetailDataTable
        Return DetailAdapter.GetDataByAccountIdAndAccountTimeOffPolicyId(AccountId, AccountTimeOffPolicyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountTimeOffPolicy( _
                ByVal AccountId As Integer, ByVal AccountTimeOffPolicy As String, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer _
            ) As Guid

        _AccountTimeOffPolicyTableAdapter = New AccountTimeOffPolicyTableAdapter

        Dim dtTimeOffPolicy As New AccountTimeOffPolicy.AccountTimeOffPolicyDataTable
        Dim drTimeOffPolicy As AccountTimeOffPolicy.AccountTimeOffPolicyRow = dtTimeOffPolicy.NewAccountTimeOffPolicyRow
        Dim nAccountTimeOffPolicyId As Guid = System.Guid.NewGuid

        With drTimeOffPolicy
            .AccountTimeOffPolicyId = nAccountTimeOffPolicyId
            .AccountId = AccountId
            .AccountTimeOffPolicy = AccountTimeOffPolicy
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = False
        End With

        dtTimeOffPolicy.AddAccountTimeOffPolicyRow(drTimeOffPolicy)

        Dim rowsAffected As Integer = Adapter.Update(dtTimeOffPolicy)

        Return nAccountTimeOffPolicyId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountTimeOffPolicyDetail( _
           ByVal AccountId As Integer, ByVal AccountTimeOffPolicyId As Guid, ByVal AccountTimeOffTypeId As Guid, ByVal SystemEarnPeriodId As Guid, _
           ByVal SystemResetToZeroTypeId As Guid, ByVal InitialSetToHours As Double, ByVal ResetToHours As Double, ByVal EarnHours As Double, _
           ByVal MaximumAvailable As Double, ByVal EffectiveDate As System.Nullable(Of Date), ByVal IsInclude As Boolean, ByVal AdditionalHours As Double, _
           ByVal CarryForwardExpiryDate As System.Nullable(Of Date)) As Boolean

        _AccountTimeOffPolicyDetailTableAdapter = New AccountTimeOffPolicyDetailTableAdapter

        Dim dtTimeOffPolicyDetail As New AccountTimeOffPolicy.AccountTimeOffPolicyDetailDataTable
        Dim drTimeOffPolicyDetail As AccountTimeOffPolicy.AccountTimeOffPolicyDetailRow = dtTimeOffPolicyDetail.NewAccountTimeOffPolicyDetailRow

        With drTimeOffPolicyDetail
            .AccountTimeOffPolicyDetailId = System.Guid.NewGuid
            .AccountTimeOffPolicyId = AccountTimeOffPolicyId
            .AccountTimeOffTypeId = AccountTimeOffTypeId
            .AccountId = AccountId
            If SystemEarnPeriodId <> System.Guid.Empty Then
                .SystemEarnPeriodId = SystemEarnPeriodId
            End If
            If SystemResetToZeroTypeId <> System.Guid.Empty Then
                .SystemResetToZeroTypeId = SystemResetToZeroTypeId
            End If
            .ResetToHours = ResetToHours
            .InitialSetToHours = InitialSetToHours
            .EarnHours = EarnHours
            .MaximumAvailable = MaximumAvailable
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            If EffectiveDate.HasValue Then
                .EffectiveDate = EffectiveDate
            End If
            .IsInclude = True
            .AdditionalHours = AdditionalHours
            If CarryForwardExpiryDate.HasValue Then
                .CarryForwardExpiryDate = CarryForwardExpiryDate
            End If
        End With

        dtTimeOffPolicyDetail.AddAccountTimeOffPolicyDetailRow(drTimeOffPolicyDetail)

        Dim rowsAffected As Integer = DetailAdapter.Update(dtTimeOffPolicyDetail)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountTimeOffPolicy(ByVal AccountTimeOffPolicy As String, ByVal Original_AccountTimeOffPolicyId As Guid, ByVal ModifiedByEmployeeId As Integer, _
    ByVal IsDisabled As Boolean) As Boolean

        Dim dtTimeOffPolicy As AccountTimeOffPolicy.AccountTimeOffPolicyDataTable = Adapter.GetDataByAccountTimeOffPolicyId(Original_AccountTimeOffPolicyId)
        Dim drTimeOffPolicy As AccountTimeOffPolicy.AccountTimeOffPolicyRow = dtTimeOffPolicy.Rows(0)

        With drTimeOffPolicy
            .AccountTimeOffPolicy = AccountTimeOffPolicy
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled

        End With

        Dim rowsAffected As Integer = Adapter.Update(dtTimeOffPolicy)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function UpdateAccountTimeOffPolicyDetail( _
       ByVal AccountTimeOffPolicyDetailId As Guid, ByVal AccountTimeOffPolicyId As Guid, ByVal AccountTimeOffTypeId As Guid, ByVal SystemEarnPeriodId As Guid, _
       ByVal SystemResetToZeroTypeId As Guid, ByVal InitialSetToHours As Double, ByVal ResetToHours As Decimal, ByVal EarnHours As Decimal, _
      ByVal MaximumAvailable As Decimal, ByVal EffectiveDate As System.Nullable(Of Date), ByVal IsInclude As Boolean, ByVal AdditionalHours As Decimal, _
       ByVal CarryForwardExpiryDate As System.Nullable(Of Date)) As Boolean

        Dim dtTimeOffPolicyDetail As AccountTimeOffPolicy.AccountTimeOffPolicyDetailDataTable = DetailAdapter.GetDataByAccountTimeOffPolicyDetailId(AccountTimeOffPolicyDetailId)
        Dim drTimeOffPolicyDetail As AccountTimeOffPolicy.AccountTimeOffPolicyDetailRow = dtTimeOffPolicyDetail.Rows(0)

        With drTimeOffPolicyDetail
            .AccountTimeOffPolicyId = AccountTimeOffPolicyId
            .AccountTimeOffTypeId = AccountTimeOffTypeId
            If SystemEarnPeriodId <> System.Guid.Empty Then
                .SystemEarnPeriodId = SystemEarnPeriodId
            ElseIf .Item("SystemEarnPeriodId").ToString <> "" And SystemEarnPeriodId = System.Guid.Empty Then
                .Item("SystemEarnPeriodId") = System.DBNull.Value
            End If
            If SystemResetToZeroTypeId <> System.Guid.Empty Then
                .SystemResetToZeroTypeId = SystemResetToZeroTypeId
            ElseIf .Item("SystemResetToZeroTypeId").ToString <> "" And SystemResetToZeroTypeId = System.Guid.Empty Then
                .Item("SystemResetToZeroTypeId") = System.DBNull.Value
            End If
            .ResetToHours = ResetToHours
            .InitialSetToHours = InitialSetToHours
            .EarnHours = EarnHours
            .MaximumAvailable = MaximumAvailable
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            If EffectiveDate.HasValue Then
                .EffectiveDate = EffectiveDate
            End If
            .IsInclude = IsInclude
            .AdditionalHours = AdditionalHours
            If CarryForwardExpiryDate.HasValue Then
                .CarryForwardExpiryDate = CarryForwardExpiryDate
            End If
        End With

        Dim rowsAffected As Integer = DetailAdapter.Update(dtTimeOffPolicyDetail)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTimeOffPolicy(ByVal Original_AccountTimeOffPolicyId As Guid) As Boolean
        Try
            Dim rowsAffected As Integer = Adapter.Delete(Original_AccountTimeOffPolicyId)

            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception("Can’t delete. Dependent data is exist with this record.")
        End Try
    End Function
    Public Sub InsertDefaultForPolicy(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal UserInterfaceLanguage As String = "")
        If Adapter.GetDataByAccountId(AccountId).Rows.Count = 0 Then
            Adapter.InsertDefault(AccountId, AccountEmployeeId)
        End If
        If UserInterfaceLanguage <> "" Then
            If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
                Me.ChangeTimeOffPolicyByUICulture(AccountId)
            End If
        End If
    End Sub
    Public Sub InsertDefaultForPolicyDetail(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        DetailAdapter.InsertDefault(AccountId, AccountEmployeeId)
    End Sub
    Public Sub ChangeTimeOffPolicyByUICulture(ByVal AccountId As Integer)
        Dim dtTimeOffPolicy As AccountTimeOffPolicy.AccountTimeOffPolicyDataTable = Adapter.GetDataByAccountId(AccountId)
        Dim drTimeOffPolicy As AccountTimeOffPolicy.AccountTimeOffPolicyRow
        For Each drTimeOffPolicy In dtTimeOffPolicy.Rows
            Me.UpdateAccountTimeOffPolicy(ResourceHelper.GetFromResource(drTimeOffPolicy.AccountTimeOffPolicy), drTimeOffPolicy.AccountTimeOffPolicyId, drTimeOffPolicy.ModifiedByEmployeeId, drTimeOffPolicy.IsDisabled)
        Next
    End Sub
    Public Function AddBlankRowsInDataTableWithTimeOffTypeId(ByVal dtBlank As vueAccountTimeOffPolicyDetailDataTable) As AccountTimeOffPolicy.vueAccountTimeOffPolicyDetailDataTable

        Dim detailRow As vueAccountTimeOffPolicyDetailRow
        If dtBlank.Rows.Count <= 0 Then
            Dim dt As AccountTimeOffType.AccountTimeOffTypeDataTable = New AccountTimeOffTypeBLL().GetAccountTimeOffTypesByAccountIdAndIsDisabled(DBUtilities.GetSessionAccountId, System.Guid.Empty)
            Dim dr As AccountTimeOffType.AccountTimeOffTypeRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                For Each dr In dt.Rows
                    detailRow = dtBlank.NewvueAccountTimeOffPolicyDetailRow
                    detailRow.AccountId = 0
                    'detailRow.AccountTimeOffPolicyId = System.Guid.Empty
                    detailRow.AccountTimeOffPolicyDetailId = System.Guid.Empty
                    detailRow.AccountTimeOffTypeId = dr.AccountTimeOffTypeId
                    detailRow.AccountTimeOffType = dr.AccountTimeOffType
                    dtBlank.Rows.Add(detailRow)
                Next
            End If
        End If
        Return dtBlank
    End Function
    Public Sub InsertDefaultForNewTimeOffTypes(ByVal AccountTimeOffTypeId As Guid, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
        DetailAdapter.InsertPoliciesForNewTimeOffType(AccountTimeOffTypeId, AccountId, AccountEmployeeId)
    End Sub
End Class
