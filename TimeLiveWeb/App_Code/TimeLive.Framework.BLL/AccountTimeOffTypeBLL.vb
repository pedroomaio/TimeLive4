Imports Microsoft.VisualBasic
Imports AccountTimeOffTypeTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountTimeOffTypeBLL

    Private _AccountTimeOffTypeTableAdapter As AccountTimeOffTypeTableAdapter = Nothing
    Private _vueAccountTimeOffTypeTableAdapter As vueAccountTimeOffTypeTableAdapter
    Private _VueAccountEmployeeTimeOffTypeIsInclude As VueAccountEmployeeTimeOffTypeIsIncludeTableAdapter
    Protected ReadOnly Property Adapter() As AccountTimeOffTypeTableAdapter
        Get
            If _AccountTimeOffTypeTableAdapter Is Nothing Then
                _AccountTimeOffTypeTableAdapter = New AccountTimeOffTypeTableAdapter()
            End If

            Return _AccountTimeOffTypeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountTimeOffTypeTableAdapter
        Get
            If _vueAccountTimeOffTypeTableAdapter Is Nothing Then
                _vueAccountTimeOffTypeTableAdapter = New vueAccountTimeOffTypeTableAdapter()
            End If

            Return _vueAccountTimeOffTypeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapterIsInclude() As VueAccountEmployeeTimeOffTypeIsIncludeTableAdapter
        Get
            If _VueAccountEmployeeTimeOffTypeIsInclude Is Nothing Then
                _VueAccountEmployeeTimeOffTypeIsInclude = New VueAccountEmployeeTimeOffTypeIsIncludeTableAdapter()
            End If

            Return _VueAccountEmployeeTimeOffTypeIsInclude
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffTypesByAccountIdForGridView(ByVal AccountId As Integer) As AccountTimeOffType.AccountTimeOffTypeDataTable
        GetAccountTimeOffTypesByAccountIdForGridView = Adapter.GetDataByAccountId(AccountId)
        UIUtilities.FixTableForNoRecords(GetAccountTimeOffTypesByAccountIdForGridView)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffTypesByAccountId(ByVal AccountId As Integer) As AccountTimeOffType.AccountTimeOffTypeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffTypesByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountTimeOffTypeId As Guid) As AccountTimeOffType.AccountTimeOffTypeDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffTypesByAccountTimeOffTypeId(ByVal AccountTimeOffTypeId As Guid) As AccountTimeOffType.AccountTimeOffTypeDataTable
        Return Adapter.GetDataByAccountTimeOffTypeId(AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffTypesByAccountIdAndRequestRequired(ByVal AccountId As Integer, ByVal AccountTimeOffTypeId As Guid, ByVal RequestRequired As Boolean) As AccountTimeOffType.AccountTimeOffTypeDataTable
        Return Adapter.GetDataByAccountIdAndIsTimeOffRequestRequired(AccountId, RequestRequired, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTimeOffTypeByIsDisabeld(ByVal AccountId As Integer, ByVal IsTimeOffRequestRequired As Boolean, ByVal AccountTimeOffTypeId As Guid) As AccountTimeOffType.vueAccountTimeOffTypeDataTable
        Return vueAdapter.GetDataByAccountTimeOffTypeId(AccountId, IsTimeOffRequestRequired, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountAndAccountEmployeeAccountTimeOffTypeIsInclude(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer, ByVal IsTimeOffRequestRequired As Boolean, ByVal AccountTimeOffTypeId As Guid)
        If DBUtilities.GetTimeOffTypesBy = "Account" Then
            Dim dt As New AccountTimeOffType.vueAccountTimeOffTypeDataTable
            Return vueAdapter.GetDataByAccountTimeOffTypeId(AccountId, IsTimeOffRequestRequired, AccountTimeOffTypeId)
        Else
            Dim dt As New AccountTimeOffType.VueAccountEmployeeTimeOffTypeIsIncludeDataTable
            Return vueAdapterIsInclude.GetDataByAccountIdandAccountEmployeeIdTimeOffTypeIdIsInclude(AccountEmployeeId, AccountId, IsTimeOffRequestRequired, AccountTimeOffTypeId)
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetAccountTimeOffTypesByAccountIdAccountEmployeeIdAndRequestRequired(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer, ByVal IsTimeOffRequestRequired As Boolean, ByVal AccountTimeOffTypeId As Guid)
        If DBUtilities.GetTimeOffTypesBy = "Account" Then
            Dim dt As New AccountTimeOffType.AccountTimeOffTypeDataTable
            Return Adapter.GetDataByAccountIdAndIsTimeOffRequestRequired(AccountId, IsTimeOffRequestRequired, AccountTimeOffTypeId)
            'Return vueAdapterIsInclude.GetTimeOffTypesByAccountIdAndIsTimeOffRequestRequired(AccountId, IsTimeOffRequestRequired, AccountTimeOffTypeId)
        Else
            Dim dt As New AccountTimeOffType.VueAccountEmployeeTimeOffTypeIsIncludeDataTable
            Return vueAdapterIsInclude.GetDataByAccountIdAccountEmployeeIdandIsTimeOffRequestRequired(AccountEmployeeId, AccountId, IsTimeOffRequestRequired, AccountTimeOffTypeId)
        End If
    End Function
    Public Function GetDataByAccountIdAccountEmployeeIdandIsTimeOffRequestRequired(ByVal AccountEmployeeId As Integer, ByVal AccountId As Integer, ByVal IsTimeOffRequestRequired As Boolean, ByVal AccountTimeOffTypeId As Guid)
        Dim dt As New AccountTimeOffType.VueAccountEmployeeTimeOffTypeIsIncludeDataTable
        Return vueAdapterIsInclude.GetDataByAccountIdAccountEmployeeIdandIsTimeOffRequestRequired(AccountEmployeeId, AccountId, IsTimeOffRequestRequired, AccountTimeOffTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)>
    Public Function AddAccountTimeOffTypes(
                    ByVal AccountId As Integer, ByVal AccountTimeOffType As String, ByVal IsTimeOffRequestRequired As Boolean, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer _
                , ByVal Paid As Boolean, ByVal Color As String, ByVal BriefExplanation As String, ByVal DisplayOrder As Integer, ByVal ScheduleWeekends As Boolean) As Boolean

        _AccountTimeOffTypeTableAdapter = New AccountTimeOffTypeTableAdapter

        Dim dtTimeOff As New AccountTimeOffType.AccountTimeOffTypeDataTable
        Dim drTimeOff As AccountTimeOffType.AccountTimeOffTypeRow = dtTimeOff.NewAccountTimeOffTypeRow
        Dim nAccountTimeOffTypeId As Guid = System.Guid.NewGuid

        With drTimeOff
            .AccountTimeOffTypeId = nAccountTimeOffTypeId
            .AccountId = AccountId
            .AccountTimeOffType = AccountTimeOffType
            .IsTimeOffRequestRequired = IsTimeOffRequestRequired
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = False
            .Paid = Paid
            .Color = Color
            .BriefExplanation = BriefExplanation
            .ScheduleWeekends = ScheduleWeekends
            .DisplayOrder = DisplayOrder
        End With

        dtTimeOff.AddAccountTimeOffTypeRow(drTimeOff)
        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)

        Me.AddDefaultPoliciesTimeOffTypes(nAccountTimeOffTypeId)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)>
    Public Function UpdateAccountTimeOffTypes(ByVal AccountTimeOffType As String, ByVal IsTimeOffRequestRequired As Boolean, ByVal Original_AccountTimeOffTypeId As Guid, ByVal ModifiedByEmployeeId As Integer,
    ByVal IsDisabled As Boolean, ByVal Paid As Boolean, ByVal Color As String, ByVal BriefExplanation As String, ByVal ScheduleWeekends As Boolean, ByVal DisplayOrder As Integer) As Boolean

        Dim dtTimeOff As AccountTimeOffType.AccountTimeOffTypeDataTable = Adapter.GetDataByAccountTimeOffTypeId(Original_AccountTimeOffTypeId)
        Dim drTimeOff As AccountTimeOffType.AccountTimeOffTypeRow = dtTimeOff.Rows(0)

        With drTimeOff
            .AccountTimeOffType = AccountTimeOffType
            .IsTimeOffRequestRequired = IsTimeOffRequestRequired
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .IsDisabled = IsDisabled
            .Paid = Paid
            .Color = Color
            .BriefExplanation = BriefExplanation
            .ScheduleWeekends = ScheduleWeekends
            .DisplayOrder = DisplayOrder
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtTimeOff)

        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountTimeOffTypes(ByVal Original_AccountTimeOffTypeId As Guid) As Boolean
        Try
            Dim rowsAffected As Integer = Adapter.Delete(Original_AccountTimeOffTypeId)

            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception("Can’t delete. Dependent data is exist with this record.")
        End Try
    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal UserInterfaceLanguage As String = "")
        If Adapter.GetDataByAccountId(AccountId).Rows.Count = 0 Then
            Adapter.InsertDefault(AccountId, AccountEmployeeId)
        End If
        If UserInterfaceLanguage <> "" Then
            If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
                Me.ChangeTimeOffTypesByUICulture(AccountId)
            End If
        End If
    End Sub
    Public Sub ChangeTimeOffTypesByUICulture(ByVal AccountId As Integer)
        Dim dtTimeOff As AccountTimeOffType.AccountTimeOffTypeDataTable = Adapter.GetDataByAccountId(AccountId)
        Dim drTimeOff As AccountTimeOffType.AccountTimeOffTypeRow
        For Each drTimeOff In dtTimeOff.Rows
            Me.UpdateAccountTimeOffTypes(ResourceHelper.GetFromResource(drTimeOff.AccountTimeOffType), drTimeOff.IsTimeOffRequestRequired, drTimeOff.AccountTimeOffTypeId, drTimeOff.ModifiedByEmployeeId, drTimeOff.IsDisabled, drTimeOff.Paid, drTimeOff.Color, drTimeOff.BriefExplanation, drTimeOff.ScheduleWeekends, drTimeOff.DisplayOrder)
        Next
    End Sub
    Public Sub AddDefaultPoliciesTimeOffTypes(ByVal AccountTimeOffTypeId As Guid)
        Dim objPolicy As New AccountTimeOffPolicyBLL
        Dim objEmployeeTimeOff As New AccountEmployeeTimeOffBLL
        objPolicy.InsertDefaultForNewTimeOffTypes(AccountTimeOffTypeId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        objEmployeeTimeOff.InsertDefaultForNewTimeOffType(AccountTimeOffTypeId, DBUtilities.GetSessionAccountId, "Inserted New TimeOffType", DBUtilities.GetEmployeeNameWithCode, "Time Off Types")
    End Sub
End Class
