Imports Microsoft.VisualBasic
Imports AccountFeatureManagementTableAdapters
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountFeatureManagementBLL

    Private _AccountFeaturesTableAdapter As AccountFeaturesTableAdapter = Nothing
    Private _vueAccountFeaturesTableAdapter As vueAccountFeaturesTableAdapter = Nothing
    Private _SystemSecurityCategoryPageTableAdapter As SystemSecurityCategoryPageTableAdapter = Nothing
    Dim ExpenseId = New System.Guid("537F44E5-EC0F-4DE6-AA29-09450961C5E9")
    Dim AttendanceId = New System.Guid("21E65278-AB96-42C6-A332-16CAFBBC669E")
    Dim TimeOff = New System.Guid("76AAF57E-96A4-4476-94A4-575824E9B9FA")
    Dim ProjectManagement = New System.Guid("27D3A272-D849-4942-9985-7672FB582389")
    Dim TimesheetManagement = New System.Guid("DB17DEB7-51A0-4400-BF3B-9094E01EF038")
    Dim BugTracking = New System.Guid("BAB0DFA5-9339-41B2-A917-AB48A9A3D67B")
    Dim Billing = New System.Guid("DEAA2AE5-133D-4C8A-AB0C-B89EAA76116E")
    Protected ReadOnly Property Adapter() As AccountFeaturesTableAdapter
        Get
            If _AccountFeaturesTableAdapter Is Nothing Then
                _AccountFeaturesTableAdapter = New AccountFeaturesTableAdapter()
            End If

            Return _AccountFeaturesTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountFeaturesTableAdapter
        Get
            If _vueAccountFeaturesTableAdapter Is Nothing Then
                _vueAccountFeaturesTableAdapter = New vueAccountFeaturesTableAdapter()
            End If

            Return _vueAccountFeaturesTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SecurityAdapter() As SystemSecurityCategoryPageTableAdapter
        Get
            If _SystemSecurityCategoryPageTableAdapter Is Nothing Then
                _SystemSecurityCategoryPageTableAdapter = New SystemSecurityCategoryPageTableAdapter()
            End If

            Return _SystemSecurityCategoryPageTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountFeatureByAccountId(ByVal AccountId As Integer) As AccountFeatureManagement.AccountFeaturesDataTable
        GetAccountFeatureByAccountId = Adapter.GetDataByAccountId(AccountId)
        Return GetAccountFeatureByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountFeatureByAccountId(ByVal AccountId As Integer) As AccountFeatureManagement.vueAccountFeaturesDataTable
        If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
            GetvueAccountFeatureByAccountId = vueAdapter.GetDataByAccountIdForBugTracking(AccountId)
        Else
            GetvueAccountFeatureByAccountId = vueAdapter.GetDataByAccountId(AccountId)
        End If
        Return GetvueAccountFeatureByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountFeatureByAccountIdAndSystemFeatureId(ByVal AccountId As Integer, ByVal SystemFeatureId As Guid) As AccountFeatureManagement.AccountFeaturesDataTable
        Return Adapter.GetDataByAccountIdandSystemFeatureId(AccountId, SystemFeatureId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
     Public Function AddAccountFeatures(ByVal AccountId As Integer, ByVal SystemFeatureId As Guid) As Boolean

        _AccountFeaturesTableAdapter = New AccountFeaturesTableAdapter

        Dim dtAccountFeatures As New AccountFeatureManagement.AccountFeaturesDataTable
        Dim drAccountFeatures As AccountFeatureManagement.AccountFeaturesRow = dtAccountFeatures.NewAccountFeaturesRow
        Dim AccountFeatureId As Guid = System.Guid.NewGuid



        With drAccountFeatures
            .AccountFeatureId = AccountFeatureId
            .SystemFeatureId = SystemFeatureId
            .AccountId = AccountId

            If SystemFeatureId = ExpenseId Then
                .SortOrder = 1
            ElseIf SystemFeatureId = AttendanceId Then
                .SortOrder = 5
            ElseIf SystemFeatureId = TimeOff Then
                .SortOrder = 2
            ElseIf SystemFeatureId = ProjectManagement Then
                .SortOrder = 4
            ElseIf SystemFeatureId = TimesheetManagement Then
                .SortOrder = 0
            ElseIf SystemFeatureId = BugTracking Then
                .SortOrder = 6
            ElseIf SystemFeatureId = Billing Then
                .SortOrder = 3
            End If
        End With

        dtAccountFeatures.AddAccountFeaturesRow(drAccountFeatures)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(dtAccountFeatures)
        CacheManager.ClearCache("vueAccountEMailNotificationPreferenceDataTable", , True)
        System.Web.HttpContext.Current.Session.Add("AccountFeatureId", AccountFeatureId)
        Call New AccountPagePermissionBLL().ResetPageSecurity()
        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountFeatures(ByVal AccountId As Integer, ByVal SystemFeatureId As Guid, ByVal Original_AccountFeatureId As Guid) As Boolean

        ' Update the product record

        Dim AccountFeature As AccountFeatureManagement.AccountFeaturesDataTable = Adapter.GetDataByAccountFeatureId(Original_AccountFeatureId)
        Dim AccountFeaturerow As AccountFeatureManagement.AccountFeaturesRow = AccountFeature.Rows(0)

        With AccountFeaturerow
            .AccountFeatureId = Original_AccountFeatureId
            .SystemFeatureId = SystemFeatureId
            .AccountId = AccountId
            If SystemFeatureId = ExpenseId Then
                .SortOrder = 1
            ElseIf SystemFeatureId = AttendanceId Then
                .SortOrder = 5
            ElseIf SystemFeatureId = TimeOff Then
                .SortOrder = 2
            ElseIf SystemFeatureId = ProjectManagement Then
                .SortOrder = 4
            ElseIf SystemFeatureId = TimesheetManagement Then
                .SortOrder = 0
            ElseIf SystemFeatureId = BugTracking Then
                .SortOrder = 6
            ElseIf SystemFeatureId = Billing Then
                .SortOrder = 3
            End If
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountFeature)
        CacheManager.ClearCache("vueAccountEMailNotificationPreferenceDataTable", , True)
        Call New AccountPagePermissionBLL().ResetPageSecurity()
        CacheManager.ClearCache("AccountDataTable", , True)
        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountFeature(ByVal AccountFeatureId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.DeleteQuery(AccountFeatureId)
        CacheManager.ClearCache("vueAccountEMailNotificationPreferenceDataTable", , True)
        Return rowsAffected = 1
    End Function
    Public Function DeleteAccountFeatureData(ByVal AccountId As Integer, ByVal SystemFeatureId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.DeleteAccountFeatureData(AccountId, SystemFeatureId)
        CacheManager.ClearCache("vueAccountEMailNotificationPreferenceDataTable", , True)
        Call New AccountPagePermissionBLL().ResetPageSecurity()
        Return rowsAffected = 1
    End Function
    Public Sub InsertDefault(ByVal AccountId As Integer)
        If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
            Adapter.InsertQueryForBugTracking(AccountId)
        Else
            Adapter.InsertQuery(AccountId)
        End If
    End Sub
    Public Sub ChangeTaskNameByUICulture(ByVal AccountId As Integer)
        Dim dtFeatureManagement As AccountFeatureManagement.AccountFeaturesDataTable = Me.GetAccountFeatureByAccountId(AccountId)
        Dim drFeatureManagement As AccountFeatureManagement.AccountFeaturesRow
        For Each drFeatureManagement In dtFeatureManagement.Rows

        Next
    End Sub
    Public Function GetLastInsertedId() As Guid
        Return System.Web.HttpContext.Current.Session("AccountFeatureId")
    End Function
End Class
