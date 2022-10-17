Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports AccountPageSecuritySiteMapTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountPagePermissionBLL

    Private _vueAccountPagePermissionTableAdapter As vueAccountPagePermissionTableAdapter = Nothing
    Private _AccountPagePermissionTableAdapter As AccountPagePermissionTableAdapter = Nothing
    Private _vueAccountPagePermissionViewTableAdapter As vueAccountPagePermissionViewTableAdapter = Nothing
    Private _vueSystemSecurityCategoryPageTableAdapter As vueSystemSecurityCategoryPageTableAdapter = Nothing
    Private _vueAccountPageSecuritySiteMapTableAdapter As vueAccountPageSecuritySiteMapTableAdapter = Nothing
    Private _SystemSecurityCategoryPageTableAdapter As AccountPageSecuritySiteMapTableAdapters.SystemSecurityCategoryPageTableAdapter = Nothing


    Protected ReadOnly Property vueAccountPagePermissionTableAdapter() As vueAccountPagePermissionTableAdapter
        Get
            If _vueAccountPagePermissionTableAdapter Is Nothing Then
                _vueAccountPagePermissionTableAdapter = New vueAccountPagePermissionTableAdapter()
            End If
            Return _vueAccountPagePermissionTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAccountPageSecuritySiteMapTableAdapter() As vueAccountPageSecuritySiteMapTableAdapter
        Get
            If _vueAccountPageSecuritySiteMapTableAdapter Is Nothing Then
                _vueAccountPageSecuritySiteMapTableAdapter = New vueAccountPageSecuritySiteMapTableAdapter()
            End If
            Return _vueAccountPageSecuritySiteMapTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SystemSecurityCategoryPageTableAdapter() As AccountPageSecuritySiteMapTableAdapters.SystemSecurityCategoryPageTableAdapter
        Get
            If _SystemSecurityCategoryPageTableAdapter Is Nothing Then
                _SystemSecurityCategoryPageTableAdapter = New AccountPageSecuritySiteMapTableAdapters.SystemSecurityCategoryPageTableAdapter()
            End If
            Return _SystemSecurityCategoryPageTableAdapter
        End Get
    End Property

    Protected ReadOnly Property vueSystemSecurityCategoryPageTableAdapter() As vueSystemSecurityCategoryPageTableAdapter
        Get
            If _vueSystemSecurityCategoryPageTableAdapter Is Nothing Then
                _vueSystemSecurityCategoryPageTableAdapter = New vueSystemSecurityCategoryPageTableAdapter()
            End If
            Return _vueSystemSecurityCategoryPageTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAccountPagePermissionViewTableAdapter() As vueAccountPagePermissionViewTableAdapter
        Get
            If _vueAccountPagePermissionViewTableAdapter Is Nothing Then
                _vueAccountPagePermissionViewTableAdapter = New vueAccountPagePermissionViewTableAdapter()
            End If
            Return _vueAccountPagePermissionViewTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPermissionsByAccountId(ByVal AccountId As Integer, ByVal AccountRoleId As Integer) As TimeLiveDataSet.vueAccountPagePermissionDataTable
        Return vueAccountPagePermissionTableAdapter.GetDataByAccountRoleId(AccountId, AccountRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPermissionsByAccountRolesAndSystemSecurityCategoryPageId(ByVal AccountId As Integer, ByVal SystemSecurityCategoryPageId As Integer) As TimeLiveDataSet.vueAccountPagePermissionDataTable
        Return vueAccountPagePermissionTableAdapter.GetDataByAccountRolesIdAndSystemSecurityCategoryPageId(AccountId, SystemSecurityCategoryPageId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPageSecurityByAccountIdAndSystemSecurityCategoryPageId(ByVal SystemSecurityCategoryPageId As Integer) As AccountPageSecuritySiteMap.SystemSecurityCategoryPageDataTable
        Return SystemSecurityCategoryPageTableAdapter.GetDataBySystemSecurityCategoryPageId(SystemSecurityCategoryPageId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPermissionsOfCurrentRoles() As TimeLiveDataSet.vueAccountPagePermissionDataTable
        If Not System.Web.HttpContext.Current.Session("PermissionTable") Is Nothing Then
            GetAccountPermissionsOfCurrentRoles = System.Web.HttpContext.Current.Session("PermissionTable")
        Else
            Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))
            System.Web.HttpContext.Current.Session("PermissionTable") = vueAccountPagePermissionTableAdapter.GetDataByAccountRolesId(DBUtilities.GetSessionAccountId, AccountRoles)
            GetAccountPermissionsOfCurrentRoles = System.Web.HttpContext.Current.Session("PermissionTable")
        End If
        'ChangeURLsFromPreferencesUpdates(GetAccountPermissionsOfCurrentRoles)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPageSecurityOfRoles() As AccountPageSecuritySiteMap.SystemSecurityCategoryPageDataTable
        GetAccountPageSecurityOfRoles = SystemSecurityCategoryPageTableAdapter.GetData
        'ChangeURLsFromPreferencesUpdates(GetAccountPageSecurityOfRoles)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemSecurityCategoryPageView(ByVal AccountId As Integer) As TimeLiveDataSet.vueSystemSecurityCategoryPageDataTable
        Return Me.vueSystemSecurityCategoryPageTableAdapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPagePermissionView() As TimeLiveDataSet.vueAccountPagePermissionViewDataTable
        Return vueAccountPagePermissionViewTableAdapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPagePermissionViewByAccountId(ByVal AccountId As Integer, ByVal AccountRoleId As Integer) As TimeLiveDataSet.vueAccountPagePermissionViewDataTable
        Return vueAccountPagePermissionViewTableAdapter.GetDataForAccountPagePermissionView(AccountId, AccountRoleId)
    End Function
    Protected ReadOnly Property Adapter() As AccountPagePermissionTableAdapter
        Get
            If _AccountPagePermissionTableAdapter Is Nothing Then
                _AccountPagePermissionTableAdapter = New AccountPagePermissionTableAdapter()
            End If

            Return _AccountPagePermissionTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPagePermissions() As TimeLiveDataSet.AccountPagePermissionDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPagePermissionsOfWholeAccount(ByVal AccountId As Integer, ByVal AccountRoleId As Integer) As TimeLiveDataSet.AccountPagePermissionDataTable
        Return Adapter.GetDataByOfWholeAccount(AccountId, AccountRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPagePermissionsByAccountPagePermissionId(ByVal AccountPagePermissionId As Integer) As TimeLiveDataSet.AccountPagePermissionDataTable
        Return Adapter.GetDataByAccountPagePermissionId(AccountPagePermissionId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPagePermissionsByAccountIdAndAccountRoleId(ByVal AccountId As Integer, ByVal AccountRoleId As Integer) As TimeLiveDataSet.AccountPagePermissionDataTable
        Return Adapter.GetDataByAccountIdAndAccountRoleId(AccountId, AccountRoleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataForAccountPagePermission(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal SystemSecurityCategoryPageId As Integer) As TimeLiveDataSet.AccountPagePermissionDataTable
        Return Adapter.GetDataForAccountPagePermission(AccountId, AccountRoleId, SystemSecurityCategoryPageId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Shared Function GetSystemSecurityCategoryPages() As TimeLiveDataSet.SystemSecurityCategoryPageDataTable
        If Not CacheManager.GetItemFromCache("SystemSecurityCategoryPages") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemSecurityCategoryPages")
        Else
            Dim _SystemSecurityCategoryPageTableAdapter As New TimeLiveDataSetTableAdapters.SystemSecurityCategoryPageTableAdapter
            GetSystemSecurityCategoryPages = _SystemSecurityCategoryPageTableAdapter.GetData
            CacheManager.AddStaticDataInCache(GetSystemSecurityCategoryPages, "SystemSecurityCategoryPages")
            Return GetSystemSecurityCategoryPages
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemSecurityCategoryPagesByIsSiteMapPage(ByVal IsSiteMapPage As Boolean) As TimeLiveDataSet.SystemSecurityCategoryPageDataTable
        If Not CacheManager.GetItemFromCache("GetSystemSecurityCategoryPagesByIsSiteMapPage") Is Nothing Then
            Return CacheManager.GetItemFromCache("GetSystemSecurityCategoryPagesByIsSiteMapPage")
        Else
            Dim _SystemSecurityCategoryPageTableAdapter As New TimeLiveDataSetTableAdapters.SystemSecurityCategoryPageTableAdapter
            GetSystemSecurityCategoryPagesByIsSiteMapPage = _SystemSecurityCategoryPageTableAdapter.GetDataByIsSiteMapPage(IsSiteMapPage)
            CacheManager.AddStaticDataInCache(GetSystemSecurityCategoryPages, "GetSystemSecurityCategoryPagesByIsSiteMapPage")
            Return GetSystemSecurityCategoryPages()
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemSecurityCategoryPagesByIsSiteMapPageForDefaultPage(ByVal IsSiteMapPage As Boolean) As TimeLiveDataSet.SystemSecurityCategoryPageDataTable
        If Not CacheManager.GetItemFromCache("GetSystemSecurityCategoryPagesByIsSiteMapPageForDefaultPage") Is Nothing Then
            Return CacheManager.GetItemFromCache("GetSystemSecurityCategoryPagesByIsSiteMapPageForDefaultPage")
        Else
            Dim _SystemSecurityCategoryPageTableAdapter As New TimeLiveDataSetTableAdapters.SystemSecurityCategoryPageTableAdapter
            GetSystemSecurityCategoryPagesByIsSiteMapPageForDefaultPage = _SystemSecurityCategoryPageTableAdapter.GetDataByIsSiteMapPage(IsSiteMapPage)
            CacheManager.AddStaticDataInCache(GetSystemSecurityCategoryPagesByIsSiteMapPageForDefaultPage, "GetSystemSecurityCategoryPagesByIsSiteMapPageForDefaultPage")
            Return GetSystemSecurityCategoryPagesByIsSiteMapPageForDefaultPage
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Shared Function GetSystemSecurityCategoryPageBySystemSecurityCategoryPageId(ByVal SystemSecurityCategoryPageId As Integer) As TimeLiveDataSet.SystemSecurityCategoryPageRow
        Return AccountPagePermissionBLL.GetSystemSecurityCategoryPages().Select("SystemSecurityCategoryPageId=" & SystemSecurityCategoryPageId)(0)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function SetAccountPagePermission( _
                        ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As System.Nullable(Of Integer), ByVal ShowAllData As System.Nullable(Of Boolean), ByVal ShowMyData As System.Nullable(Of Boolean), ByVal ShowMyProjectsData As System.Nullable(Of Boolean), ByVal ShowMyTeamsData As System.Nullable(Of Boolean), ByVal ShowMySubOrdinatesData As System.Nullable(Of Boolean), ByVal TillDate As System.Nullable(Of Date), ByVal TillHours As System.Nullable(Of Integer), Optional ByVal IsDelete As Boolean = False) As Boolean
        ' Create a new ProductRow instance


        _AccountPagePermissionTableAdapter = New AccountPagePermissionTableAdapter

        Dim AccountPagePermissions As New TimeLiveDataSet.AccountPagePermissionDataTable
        AccountPagePermissions = Me.Adapter.GetUniqueDataBySystemPermissionId(AccountId, AccountRoleId, SystemSecurityCategoryPageId, SystemPermissionId)

        Dim AccountPagePermission As TimeLiveDataSet.AccountPagePermissionRow

        If AccountPagePermissions.Rows.Count > 0 And IsDelete = True Then
            AccountPagePermission = AccountPagePermissions.Rows(0)
            Me.DeleteAccountPagePermissionId(AccountPagePermission.AccountPagePermissionId)
            Return True
        End If


        If AccountPagePermissions.Rows.Count > 0 Then
            AccountPagePermission = AccountPagePermissions.Rows(0)
            Me.UpdateAccountPagePermission(AccountId, AccountRoleId, SystemSecurityCategoryPageId, SystemPermissionId, ShowAllData, ShowMyData, ShowMyProjectsData, ShowMyTeamsData, ShowMySubOrdinatesData, TillDate, TillHours, AccountPagePermission.AccountPagePermissionId, IsDelete)
            Return True
        Else
            If IsDelete = True Then
                Return True
            Else
                AccountPagePermission = AccountPagePermissions.NewRow
            End If

        End If



        With AccountPagePermission
            .AccountId = AccountId
            .AccountRoleId = AccountRoleId
            .SystemSecurityCategoryPageId = SystemSecurityCategoryPageId

            If SystemPermissionId.HasValue Then
                .SystemPermissionId = SystemPermissionId
            End If

            If ShowAllData.HasValue Then
                .ShowAllData = ShowAllData
            End If

            If ShowMyData.HasValue Then
                .ShowMyData = ShowMyData
            End If

            If ShowMyTeamsData.HasValue Then
                .ShowMyTeamsData = ShowMyTeamsData
            End If

            If ShowMyProjectsData.HasValue Then
                .ShowMyProjectsData = ShowMyProjectsData
            End If

            If ShowMySubOrdinatesData.HasValue Then
                .ShowMySubOrdinatesData = ShowMySubOrdinatesData
            End If

            If TillDate.HasValue Then
                .TillDate = TillDate
            End If

            If TillHours.HasValue Then
                .TillHours = TillHours
            End If

        End With

        AccountPagePermissions.AddAccountPagePermissionRow(AccountPagePermission)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountPagePermissions)

        'Dim AccountProjectPreferences As New AccountRoleProjectPreferencesBLL
        'AccountProjectPreferences.AddAccountRoleProjectPreference(AccountRoleId, AccountProjectId, True, False)


        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
Public Function UpdateAccountPagePermission( _
                    ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As System.Nullable(Of Integer), ByVal ShowAllData As System.Nullable(Of Boolean), ByVal ShowMyData As System.Nullable(Of Boolean), ByVal ShowMyProjectsData As System.Nullable(Of Boolean), ByVal ShowMyTeamsData As System.Nullable(Of Boolean), ByVal ShowMySubOrdinatesData As System.Nullable(Of Boolean), ByVal TillDate As System.Nullable(Of Date), ByVal TillHours As System.Nullable(Of Integer), ByVal Original_AccountPagePermissionId As Integer, Optional ByVal IsDelete As Boolean = False) As Boolean
        ' Create a new ProductRow instance


        Dim AccountPagePermissions As TimeLiveDataSet.AccountPagePermissionDataTable = Adapter.GetDataByAccountPagePermissionId(Original_AccountPagePermissionId)
        Dim AccountPagePermission As TimeLiveDataSet.AccountPagePermissionRow = AccountPagePermissions.Rows(0)

        With AccountPagePermission
            .AccountId = AccountId
            .AccountRoleId = AccountRoleId
            .SystemSecurityCategoryPageId = SystemSecurityCategoryPageId

            If SystemPermissionId.HasValue Then
                .SystemPermissionId = SystemPermissionId
            End If

            If ShowAllData.HasValue Then
                .ShowAllData = ShowAllData
            End If

            If ShowMyData.HasValue Then
                .ShowMyData = ShowMyData
            End If

            If ShowMyTeamsData.HasValue Then
                .ShowMyTeamsData = ShowMyTeamsData
            End If

            If ShowMyProjectsData.HasValue Then
                .ShowMyProjectsData = ShowMyProjectsData
            End If

            If ShowMySubOrdinatesData.HasValue Then
                .ShowMySubOrdinatesData = ShowMySubOrdinatesData
            End If

            If TillDate.HasValue Then
                .TillDate = TillDate
            End If

            If TillHours.HasValue Then
                .TillHours = TillHours
            End If

        End With

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountPagePermissions)

        'Dim AccountProjectPreferences As New AccountRoleProjectPreferencesBLL
        'AccountProjectPreferences.AddAccountRoleProjectPreference(AccountRoleId, AccountProjectId, True, False)


        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountPagePermissionId(ByVal Original_AccountPagePermissionId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountPagePermissionId)

        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function

    Public Shared Function IsPageHasPermissionOf(ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer) As Boolean

        If AccountPagePermissionBLL.IsDependentChildPage(SystemSecurityCategoryPageId) Then
            Return True
        End If

        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable = New AccountPagePermissionBLL().GetAccountPermissionsOfCurrentRoles()

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and SystemPermissionId = " & SystemPermissionId)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function GetPageIdByPage(ByVal objPage As Page) As Integer

        If System.Web.HttpContext.Current.Session("PermissionTable") Is Nothing Then
            Return True
        End If

        Dim ThisPage As String = objPage.AppRelativeVirtualPath
        Dim SlashPos As Integer = InStrRev(ThisPage, "/")
        Dim PageName As String = Right(ThisPage, Len(ThisPage) - SlashPos)

        Dim ThisFolder As String = objPage.AppRelativeTemplateSourceDirectory
        Dim SlashPos1 As String = Right(ThisFolder, Len(ThisFolder) - 2)
        Dim FolderName As String = Left(SlashPos1, Len(SlashPos1) - 1)

        Dim PageId As Integer = GetPageIdByPageName(PageName, FolderName)

        Return PageId


    End Function
    Public Shared Function IsPageHasRightsByPage(ByVal objPage As Page) As Boolean

        If System.Web.HttpContext.Current.Session("PermissionTable") Is Nothing Then
            Return True
        End If

        Dim ThisPage As String = objPage.AppRelativeVirtualPath
        Dim SlashPos As Integer = InStrRev(ThisPage, "/")
        Dim PageName As String = Right(ThisPage, Len(ThisPage) - SlashPos)

        Dim ThisFolder As String = objPage.AppRelativeTemplateSourceDirectory
        Dim SlashPos1 As String = Right(ThisFolder, Len(ThisFolder) - 2)
        Dim FolderName As String = Left(SlashPos1, Len(SlashPos1) - 1)

        Dim PageId As Integer = GetPageIdByPageName(PageName, FolderName)

        If IsSystemPage(PageId) Then
            Return True
        End If
        If IsReportPage(PageId) Then
            Return True
        End If

        Return AccountPagePermissionBLL.IspageHasRights(PageId)


    End Function
    Public Shared Function IsSystemPage(ByVal SystemSecurityCategoryPageId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.SystemSecurityCategoryPageDataTable
        dtPermissions = AccountPagePermissionBLL.GetSystemSecurityCategoryPages
        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId)


        If IsDBNull(dr(0).Item("IsSystemPage")) Then
            Return False
        ElseIf dr(0).Item("IsSystemPage") = True Then
            Return True
        Else
            Return False
        End If


    End Function
    Public Shared Function GetPageIdByPageName(ByVal strPageName As String, ByVal strFolderName As String) As Integer
        Dim dtPermissions As TimeLiveDataSet.SystemSecurityCategoryPageDataTable
        dtPermissions = AccountPagePermissionBLL.GetSystemSecurityCategoryPages

        Dim dr() As DataRow = dtPermissions.Select("SystemCategoryPage = '" & strPageName & "' and Folder='" & strFolderName & "'")

        Return dr(0).Item("SystemSecurityCategoryPageId")


    End Function
    Public Shared Function IspageHasRights(ByVal SystemSecurityCategoryPageId As Integer, Optional ByVal CheckParent As Boolean = False) As Boolean

        If AccountPagePermissionBLL.IsDependentChildPage(SystemSecurityCategoryPageId) Then
            Return True
        End If

        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable = New AccountPagePermissionBLL().GetAccountPermissionsOfCurrentRoles()

        Dim drPermission As TimeLiveDataSet.vueAccountPagePermissionRow

        If dtPermissions.Rows.Count > 0 Then
            drPermission = dtPermissions.Rows(0)
            If Not dtPermissions Is Nothing Then
                Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId)
                If dr.Length > 0 Then
                    Return True
                End If
            End If
            If CheckParent = True Then
                Return AccountPagePermissionBLL.IsParentPageHasRights(SystemSecurityCategoryPageId)
            End If
        End If

    End Function
    Public Shared Function IsParentPageHasRights(ByVal ParentSystemSecurityCateogoryPageId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable = New AccountPagePermissionBLL().GetAccountPermissionsOfCurrentRoles()
        Dim drPermission As TimeLiveDataSet.vueAccountPagePermissionRow

        If dtPermissions.Rows.Count > 0 Then
            drPermission = dtPermissions.Rows(0)
            If Not dtPermissions Is Nothing Then
                Dim dr() As DataRow = dtPermissions.Select("ParentSystemSecurityCateogoryPageId = " & ParentSystemSecurityCateogoryPageId)
                If IsDependentChildOfRows(dr) Then
                    Return False
                End If
                If dr.Length > 0 Then
                    Return True
                End If
            End If
        End If


    End Function
    Public Shared Function IsDependentChildOfRows(ByVal objRows() As DataRow) As Boolean
        For n As Integer = 0 To objRows.Length - 1
            If IsDependentChild(objRows(n)("SystemSecurityCategoryPageId")) Then
                Return True
            End If
        Next
    End Function
    Public Shared Function IsDependentChild(ByVal PageId As Integer) As Boolean
        If PageId = 108 Or PageId = 24 Or PageId = 116 Or PageId = 120 Then
            Return True
        End If
    End Function
    Public Sub InsertDefaultPermissionOfRole(ByVal MasterAccountRoleId As Short, ByVal AccountRoleId As Integer, ByVal AccountId As Integer)
        Adapter.InsertDefaultPermissionOfRole(AccountId, AccountRoleId, MasterAccountRoleId)
    End Sub
    Public Sub InsertDefaultPermissionOfPage(ByVal MasterAccountRoleId As Short, ByVal AccountRoleId As Integer, ByVal AccountId As Integer, ByVal SystemSecurityCategoryPageId As Integer)
        If SystemSecurityCategoryPageId = 124 Or SystemSecurityCategoryPageId = 125 Then
            Adapter.InsertPermissionOfPageById(MasterAccountRoleId, AccountRoleId, AccountId, SystemSecurityCategoryPageId)

        Else
            Adapter.InsertDefaultPermissionOfPage(MasterAccountRoleId, AccountRoleId, AccountId, SystemSecurityCategoryPageId)
        End If
    End Sub
    Public Sub InsertDefaultPermissionOfPageEdit(ByVal MasterAccountRoleId As Short, ByVal AccountRoleId As Integer, ByVal AccountId As Integer, ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer)
        Adapter.InsertQueryforEdit(MasterAccountRoleId, AccountId, AccountRoleId, SystemSecurityCategoryPageId, SystemPermissionId)
    End Sub
    Public Sub InsertPermissionOfSelectedPage(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer)
        Adapter.InsertPermissionSelectedPage(AccountId, AccountRoleId, SystemSecurityCategoryPageId, SystemPermissionId, False, False, False, False, False)
    End Sub
    Public Shared Function SetPagePermission(ByVal SystemSecurityCategoryPageId As Integer, ByVal objGridView As GridView, ByVal objFormView As FormView, ByVal AddButtonName As String, ByVal EditColumnNo As Integer, ByVal DeleteColumnNo As Integer)

        objGridView.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 1)

        If objFormView.CurrentMode = FormViewMode.Insert Then
            CType(objFormView.FindControl(AddButtonName), Button).Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 2)
            'objFormView.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 2)
        End If

        objGridView.Columns(EditColumnNo).Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 3)
        objGridView.Columns(DeleteColumnNo).Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 4)

    End Function
    Public Shared Function SetPagePermissionForFormView(ByVal SystemSecurityCategoryPageId As Integer, ByVal objFormView As FormView, ByVal AddButtonName As String)
        If objFormView.CurrentMode = FormViewMode.Insert Then
            CType(objFormView.FindControl(AddButtonName), Button).Enabled = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 2)
        End If
    End Function
    Public Shared Function SetPagePermissionForGridView(ByVal SystemSecurityCategoryPageId As Integer, ByVal objGridView As GridView, ByVal EditColumnNo As Integer, ByVal DeleteColumnNo As Integer)

        objGridView.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 1)
        If Not EditColumnNo = Nothing Then
            objGridView.Columns(EditColumnNo).Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 3)
        End If
        If Not DeleteColumnNo = Nothing Then
            objGridView.Columns(DeleteColumnNo).Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 4)
        End If

    End Function
    Public Shared Function SetPagePermissionForGridViewAndEdit(ByVal SystemSecurityCategoryPageId As Integer, ByVal objGridView As GridView, ByVal EditColumnNo As Integer)

        objGridView.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 1)
        objGridView.Columns(EditColumnNo).Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 3)

    End Function
    Public Shared Function SetPagePermissionForGridViewUpdate(ByVal SystemSecurityCategoryPageId As Integer, ByVal objGridView As GridView)

        objGridView.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 1)

    End Function
    Public Shared Function SetPagePermissionForGridViewAndButton(ByVal SystemSecurityCategoryPageId As Integer, ByVal objGridView As GridView, ByVal objButton As Button)

        objGridView.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 1)
        objButton.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 3)
    End Function
    Public Shared Function SetPagePermissionForAddButton(ByVal SystemSecurityCategoryPageId As Integer, ByVal objButton As Button)

        objButton.Visible = AccountPagePermissionBLL.IsPageHasPermissionOf(SystemSecurityCategoryPageId, 2)
    End Function

    Public Sub InsertDefaultPermissionOfAccount(ByVal AccountId As Integer, ByVal AccountRoleId As Integer)
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountIdAndAccountRoleId(AccountId, AccountRoleId)

        For Each role In roles.Rows
            If IsDBNull(role("MasterAccountRoleId")) Then
                Me.InsertDefaultPermissionOfRole(2, role.AccountRoleId, AccountId)
            Else
                Me.InsertDefaultPermissionOfRole(role.MasterAccountRoleId, role.AccountRoleId, AccountId)
            End If

        Next


    End Sub
    Public Sub InsertDefaultPermissionOfAccountPage(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal SystemSecurityCategoryPageId As Integer)
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountIdAndAccountRoleId(AccountId, AccountRoleId)

        For Each role In roles.Rows
            If IsDBNull(role("MasterAccountRoleId")) Then
                Me.InsertDefaultPermissionOfPage(2, role.AccountRoleId, AccountId, SystemSecurityCategoryPageId)
            Else
                Me.InsertDefaultPermissionOfPage(role.MasterAccountRoleId, role.AccountRoleId, AccountId, SystemSecurityCategoryPageId)
            End If

        Next


    End Sub
    Public Sub InsertDefaultPermissionOfEditByAccountPage(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer)
        Dim role As TimeLiveDataSet.AccountRoleRow
        Dim roles As TimeLiveDataSet.AccountRoleDataTable

        Dim roleBLL As New AccountRoleBLL
        roles = roleBLL.GetAccountRolesByAccountIdAndAccountRoleId(AccountId, AccountRoleId)

        For Each role In roles.Rows
            If IsDBNull(role("MasterAccountRoleId")) Then
                Me.InsertDefaultPermissionOfPageEdit(2, role.AccountRoleId, AccountId, SystemSecurityCategoryPageId, SystemPermissionId)
            Else
                Me.InsertDefaultPermissionOfPageEdit(role.MasterAccountRoleId, role.AccountRoleId, AccountId, SystemSecurityCategoryPageId, SystemPermissionId)
            End If

        Next


    End Sub
    Public Sub InsertPermissionIfBlank(ByVal AccountId As Integer, ByVal AccountRoleId As Integer)
        If Me.GetAccountPagePermissionsOfWholeAccount(AccountId, AccountRoleId).Rows.Count = 0 Then
            Call New AccountPagePermissionBLL().InsertDefaultPermissionOfAccount(AccountId, AccountRoleId)
        End If

    End Sub
    Public Sub InsertPermissionOfPage(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal SystemSecurityCategoryPageId As Integer)
        Call New AccountPagePermissionBLL().InsertDefaultPermissionOfAccountPage(AccountId, AccountRoleId, SystemSecurityCategoryPageId)
    End Sub
    Public Sub InsertEditPermissionOfPage(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer)
        Call New AccountPagePermissionBLL().InsertDefaultPermissionOfEditByAccountPage(AccountId, AccountRoleId, SystemSecurityCategoryPageId, SystemPermissionId)
    End Sub
    Public Sub ResetPageSecurity()
        System.Web.HttpContext.Current.Session.Remove("RootNode")
        System.Web.HttpContext.Current.Session.Remove("PermissionTable")
        CacheManager.RemoveFromCache("SystemStatusType")
        CacheManager.RemoveFromCache("SystemBillingCategory")
    End Sub
    Public Shared Function IsPageHasPermissionOfShowAllData(ByVal SystemSecurityCategoryPageId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & 1 & " and " & "ShowAllData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageHasPermissionOfShowMyData(ByVal SystemSecurityCategoryPageId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & 1 & " and " & "ShowMyData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageHasPermissionOfShowMySubOrdinatesData(ByVal SystemSecurityCategoryPageId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & 1 & " and " & "ShowMySubOrdinatesData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageHasPermissionOfShowMyTeamsData(ByVal SystemSecurityCategoryPageId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & 1 & " and " & "ShowMyTeamsData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageHasPermissionOfShowMyProjectsData(ByVal SystemSecurityCategoryPageId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & 1 & " and " & "ShowMyProjectsData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageHasPermissionOfShowAllDataByPermission(ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & SystemPermissionId & " and " & "ShowAllData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageHasPermissionOfShowMyDataByPermission(ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & SystemPermissionId & " and " & "ShowMyData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageHasPermissionOfShowMyTeamsDataByPermission(ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & SystemPermissionId & " and " & "ShowMyTeamsData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageHasPermissionOfShowMyProjectsDataByPermission(ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & SystemPermissionId & " and " & "ShowMyProjectsData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageHasPermissionOfShowMySubOrdinatesDataByPermission(ByVal SystemSecurityCategoryPageId As Integer, ByVal SystemPermissionId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & SystemPermissionId & " and " & "ShowMySubOrdinatesData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function
    Public Shared Function IsPageIsAllowed(ByVal SystemSecurityCategoryPageId As Integer) As Boolean
        Dim dtPermissions As TimeLiveDataSet.vueAccountPagePermissionDataTable
        dtPermissions = System.Web.HttpContext.Current.Session("PermissionTable")

        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & " and " & "SystemPermissionId = " & 1 & " and " & "ShowAllData = " & True)

        If dr.Length > 0 Then
            Return True
        End If

    End Function

    Public Sub DeleteAllAccountPageSecurityRecords(ByVal AccountId As Integer)
        Adapter.DeleteAllPermissionRecords(AccountId)
    End Sub

    Public Sub ResetAllPagePermission(ByVal AccountId As Integer)
        Me.DeleteAllAccountPageSecurityRecords(AccountId)

        'Me.InsertDefaultPermissionOfAccount(AccountId)
    End Sub
    Public Sub UpdateDefaultAccountPage(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal DefaultAccountPageId As Integer)
        Adapter.UpdateDefaultAccountPage(DefaultAccountPageId, AccountRoleId, AccountId)

        'Me.InsertDefaultPermissionOfAccount(AccountId)
    End Sub
    Public Shared Function GetDefaultPage() As TimeLiveDataSet.SystemSecurityCategoryPageRow
        Dim bll As New AccountRoleBLL
        Dim dt As TimeLiveDataSet.AccountRoleDataTable = bll.GetAccountRolesByAccountIdAndAccountRoleId(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountRoleId)
        Dim dr As TimeLiveDataSet.AccountRoleRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Dim DefaultPageId As Integer = 0

            If Not IsDBNull(dr.Item("DefaultAccountPageId")) Then
                DefaultPageId = dr.DefaultAccountPageId
                If DefaultPageId = 18 Or DefaultPageId = 19 Then
                    If DBUtilities.GetDefaultTimeEntryMode <> "Period View" Then
                        DefaultPageId = 18
                    Else
                        DefaultPageId = 19
                    End If
                End If
            End If

            If DefaultPageId = 0 Then
                Return Nothing
            End If

            Dim drvue As TimeLiveDataSet.SystemSecurityCategoryPageRow = GetSystemSecurityCategoryPageBySystemSecurityCategoryPageId(DefaultPageId)
            Return drvue
        Else
            Return Nothing
        End If
    End Function
    Public Sub UpdateShowDataPagePermission(ByVal AccountId As Integer, ByVal SystemSecurityCategoryPageId As Integer, ByVal MasterAccountRoleId As Short, ByVal AccountRoleId As Integer)
        Me.Adapter.UpdateShowDataPagePermission(AccountId, SystemSecurityCategoryPageId, MasterAccountRoleId, AccountRoleId)
    End Sub
    Public Shared Function GetNodeByPageId(ByVal PageId As String)

        For Each objSiteMapNode As SiteMapNode In SiteMap.RootNode.GetAllNodes
            If objSiteMapNode.Key = PageId Then
                Return objSiteMapNode
            End If
        Next

        Return Nothing

    End Function

    Public Shared Function ChangeCurrentNodeParent(ByVal ParentPageId As String, Optional ByVal Url As String = "", Optional ByVal ParentParentPageId As String = "") As SiteMapNode
        If Not SiteMap.CurrentNode Is Nothing Then
            Dim tempNode As SiteMapNode = SiteMap.CurrentNode.Clone(True)
            tempNode.ParentNode = AccountPagePermissionBLL.GetNodeByPageId(ParentPageId)
            If Url <> "" Then
                tempNode.ParentNode.Url = Url
            End If
            If ParentParentPageId <> "" Then
                tempNode.ParentNode.ParentNode = AccountPagePermissionBLL.GetNodeByPageId(ParentParentPageId)
            End If
            Return tempNode
        End If
    End Function

    Public Shared Function ChangeCurrentNode(ByVal PageId As String, Optional ByVal Title As String = "") As SiteMapNode
        Dim tempNode As SiteMapNode = SiteMap.CurrentNode.Clone(True)
        tempNode = AccountPagePermissionBLL.GetNodeByPageId(PageId)
        If Title <> "" Then
            tempNode.Title = Title
        End If
        Return tempNode
    End Function
    Public Shared Function IsReportPage(ByVal SystemSecurityCategoryId As Integer) As Boolean
        If SystemSecurityCategoryId = 116 Then
            Return True
        ElseIf SystemSecurityCategoryId = 120 Then
            Return True
        End If
    End Function
    Public Shared Function UpdateSiteMapData(ByVal dtPermissions As AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable, ByVal SystemSecurityCategoryPageId As Integer, ByVal UpdatedPageURL As String)
        Dim dr() As DataRow = dtPermissions.Select("SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId)

        For n As Integer = 0 To dr.Length - 1
            If DBUtilities.GetDefaultTimeEntryMode = "Period View" Then
                dr(n).Item("SystemCategoryPage") = UpdatedPageURL
            End If
        Next

    End Function

    Public Sub ChangeURLsFromPreferencesUpdates(ByVal dtPermissions As AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable)
        If DBUtilities.GetDefaultTimeEntryMode = "Period View" Then
            'UpdateSiteMapData(dtPermissions, 18, "AccountEmployeeTimeEntryPeriodView.aspx?Mode=Updated")
        ElseIf DBUtilities.GetDefaultTimeEntryMode = "Day View" Then
            'UpdateSiteMapData(dtPermissions, 18, "AccountEmployeeTimeEntryDayView.aspx?Mode=Updated")
        End If
    End Sub
    Public Shared Function IsDependentChildPage(ByVal PageId As Integer) As Boolean
        If PageId = 108 Then Return True
        If PageId = 95 Then Return True
        If PageId = 24 Then Return True
        If PageId = 21 Then Return True
        If PageId = 35 Then Return True
        If PageId = 95 Then Return True
        'If PageId = 32 Then Return True
        'If PageId = 37 Then Return True
        If PageId = 86 Then Return True
        'If PageId = 88 Then Return True
        If PageId = 99 Then Return True
        If PageId = 100 Then Return True
        If PageId = 126 Then Return True
    End Function
    Public Sub DeletePagePermissionByAccountIdAndSystemSecurityCategoryPageId(ByVal AccountID As Integer, ByVal SystemSecurityCategoryPageId As Integer)
        Adapter.DeletePagePermissionByAccountIdAndCategoryPageId(AccountID, SystemSecurityCategoryPageId)
    End Sub
    Public Shared Function IsEmployeeHasPermission(ByVal AccountId As Integer, ByVal SessionEmployeeId As Integer, ByVal AccountEmployeeId As Integer, ByVal SystemSecurtiyCategoryPageId As Integer, ByVal SystemPermissionId As Integer) As Boolean
        Dim bllAccountEmployee As New AccountEmployeeBLL
        Dim dtvueAccountEmployee As AccountEmployee.vueAccountEmployeeDataTable

        Dim WhereClause As String = ""
        Dim IsPermission As Boolean = False

        If AccountPagePermissionBLL.IsPageHasPermissionOfShowAllDataByPermission(SystemSecurtiyCategoryPageId, SystemPermissionId) = True Then
            WhereClause = bllAccountEmployee.GetAdministratorWhereClause(AccountId)
            IsPermission = True
        End If

        If AccountPagePermissionBLL.IsPageHasPermissionOfShowMyProjectsDataByPermission(SystemSecurtiyCategoryPageId, SystemPermissionId) = True Then
            WhereClause = WhereClause & bllAccountEmployee.GetProjectManagerWhereClause(WhereClause, SessionEmployeeId, AccountId)
            IsPermission = True
        End If

        If AccountPagePermissionBLL.IsPageHasPermissionOfShowMyTeamsDataByPermission(SystemSecurtiyCategoryPageId, SystemPermissionId) = True Then
            WhereClause = WhereClause & bllAccountEmployee.GetTeamLeadWhereClause(WhereClause, SessionEmployeeId, AccountId)
            IsPermission = True
        End If

        If AccountPagePermissionBLL.IsPageHasPermissionOfShowMyDataByPermission(SystemSecurtiyCategoryPageId, SystemPermissionId) = True Then
            WhereClause = WhereClause & bllAccountEmployee.GetMyOwnWhereClause(WhereClause, SessionEmployeeId)
            IsPermission = True
        End If

        If AccountPagePermissionBLL.IsPageHasPermissionOfShowMySubOrdinatesDataByPermission(SystemSecurtiyCategoryPageId, SystemPermissionId) = True Then
            WhereClause = WhereClause & bllAccountEmployee.GetSubOrdinatesWhereClause(WhereClause, SessionEmployeeId)
            IsPermission = True
        End If

        If IsPermission = False Then
            WhereClause = WhereClause & bllAccountEmployee.GetMyOwnWhereClause(WhereClause, SessionEmployeeId)
        End If

        Dim _vueAccountEmployeeTableAdapter As New AccountEmployeeTableAdapters.vueAccountEmployeeTableAdapter
        dtvueAccountEmployee = _vueAccountEmployeeTableAdapter.GetvueAccountEmployeeForReport(WhereClause)

        Dim dr() As DataRow = dtvueAccountEmployee.Select("AccountEmployeeId = " & AccountEmployeeId)
        If dr.Length > 0 Then
            Return True
        End If
        Return False
    End Function
End Class
