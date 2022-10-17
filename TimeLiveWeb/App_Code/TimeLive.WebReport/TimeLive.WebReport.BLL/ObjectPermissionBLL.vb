Imports dsObjectPermission
Imports dsObjectPermissionTableAdapters

<System.ComponentModel.DataObject()> _
Public Class ObjectPermissionBLL

    Private _AccountObjectPermissionTableAdapter As AccountObjectPermissionTableAdapter = Nothing
    Private _vueAccountObjectPermissionTableAdapter As vueAccountObjectPermissionTableAdapter = Nothing
    Private _vueSystemReportPermissionTableAdapter As vueSystemReportPermissionTableAdapter = Nothing

    Protected ReadOnly Property Adapter() As AccountObjectPermissionTableAdapter
        Get
            If _AccountObjectPermissionTableAdapter Is Nothing Then
                _AccountObjectPermissionTableAdapter = New AccountObjectPermissionTableAdapter()
            End If
            Return _AccountObjectPermissionTableAdapter
        End Get
    End Property

    Protected ReadOnly Property vueAdapter() As vueAccountObjectPermissionTableAdapter
        Get
            If _vueAccountObjectPermissionTableAdapter Is Nothing Then
                _vueAccountObjectPermissionTableAdapter = New vueAccountObjectPermissionTableAdapter()
            End If
            Return _vueAccountObjectPermissionTableAdapter
        End Get
    End Property

    Protected ReadOnly Property vueSystemReportPermissionAdapter() As vueSystemReportPermissionTableAdapter
        Get
            If _vueSystemReportPermissionTableAdapter Is Nothing Then
                _vueSystemReportPermissionTableAdapter = New vueSystemReportPermissionTableAdapter()
            End If
            Return _vueSystemReportPermissionTableAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountObjectPermissionsByAccountIdAndAccountReportId(ByVal AccountId As Integer, ByVal AccountReportId As Guid) As vueAccountObjectPermissionDataTable
        Return vueAdapter.GetDataByAccountIdAndAccountReportId(AccountReportId, AccountId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountObjectPermissionsByAccountReportIdAndAccountRoleId(ByVal AccountRoleId As Integer, ByVal AccountReportId As Guid) As AccountObjectPermissionDataTable
        Return Adapter.GetDataByAccountReportIdAndAccountRoleId(AccountReportId, AccountRoleId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountObjectPermissionsByAccountId(ByVal AccountId As Integer) As AccountObjectPermissionDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function


    Public Function AddAccountObjectPermission(ByVal AccountReportId As Guid, ByVal AccountRoleId As Integer, ByVal AccountId As Integer, ByVal ShowReport As Boolean, _
    ByVal AllowCustomization As Boolean, ByVal AllowAllUser As Boolean, ByVal AllowOwnReport As Boolean, ByVal AllowOwnTeam As Boolean, _
    ByVal AllowOwnProject As Boolean, ByVal AllowOwnSubOrdinates As Boolean, ByVal AllowOwnApproval As Boolean)

        Dim dtAccountObjectPermission As New dsObjectPermission.AccountObjectPermissionDataTable
        Dim drAccountObjectPermission As dsObjectPermission.AccountObjectPermissionRow = dtAccountObjectPermission.NewAccountObjectPermissionRow

        With drAccountObjectPermission
            .AccountObjectPermissionId = System.Guid.NewGuid
            .AccountReportId = AccountReportId
            .AccountRoleId = AccountRoleId
            .AccountId = AccountId
            .ShowReport = ShowReport
            .AllowCustomization = AllowCustomization
            .AllowAllUser = AllowAllUser
            .AllowOwnReport = AllowOwnReport
            .AllowOwnTeam = AllowOwnTeam
            .AllowOwnProject = AllowOwnProject
            .AllowOwnSubOrdinates = AllowOwnSubOrdinates
            .AllowOwnApproval = AllowOwnApproval
        End With

        dtAccountObjectPermission.AddAccountObjectPermissionRow(drAccountObjectPermission)

        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(dtAccountObjectPermission)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected

    End Function
    Public Function UpdateAccountObjectPermission(ByVal AccountReportId As Guid, ByVal AccountRoleId As Integer, ByVal ShowReport As Boolean, _
    ByVal AllowCustomization As Boolean, ByVal AllowAllUser As Boolean, ByVal AllowOwnReport As Boolean, ByVal AllowOwnTeam As Boolean, _
    ByVal AllowOwnProject As Boolean, ByVal AllowOwnSubOrdinates As Boolean, ByVal Original_AccountObjectPermissionId As Guid, ByVal AllowOwnApproval As Boolean)

        Dim dtAccountObjectPermission As dsObjectPermission.AccountObjectPermissionDataTable = Adapter.GetDataByAccountObjectPermissionId(Original_AccountObjectPermissionId)
        Dim drAccountObjectPermission As dsObjectPermission.AccountObjectPermissionRow = dtAccountObjectPermission.Rows(0)

        With drAccountObjectPermission
            .ShowReport = ShowReport
            .AllowCustomization = AllowCustomization
            .AllowAllUser = AllowAllUser
            .AllowOwnReport = AllowOwnReport
            .AllowOwnTeam = AllowOwnTeam
            .AllowOwnProject = AllowOwnProject
            .AllowOwnSubOrdinates = AllowOwnSubOrdinates
            .AllowOwnApproval = AllowOwnApproval
        End With

        Dim rowsAffected As Integer = Adapter.Update(dtAccountObjectPermission)

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected
    End Function
    Public Function DeleteAccountObjectPermission(ByVal Original_AccountObjectPermissionId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountObjectPermissionId)
        Return rowsAffected = 1
    End Function

    Public Function IsReportHasPermissionOfAllowAllUser(ByVal AccountReportId As Guid, ByVal AllowAllUser As Boolean) As Boolean
        Dim AccountRoleId As Integer
        Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))
        Dim strRoles As String = ""
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & AccountRoles(n)
            Dim BLL As New TimeLive.WebReport.ReportDesignBLL
            AccountRoleId = BLL.GetAccountRoleIdByRole(strRoles)
            If Adapter.GetDataForAllowAllUser(AccountReportId, AccountRoleId, AllowAllUser).Rows.Count > 0 Then
                Return True
            End If
            strRoles = ""
        Next
    End Function
    Public Function IsReportHasPermissionOfAllowOwnReport(ByVal AccountReportId As Guid, ByVal AllowOwnReport As Boolean) As Boolean
        Dim AccountRoleId As Integer
        Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))
        Dim strRoles As String = ""
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & AccountRoles(n)
            Dim BLL As New TimeLive.WebReport.ReportDesignBLL
            AccountRoleId = BLL.GetAccountRoleIdByRole(strRoles)
            If Adapter.GetDataByAllowOwnReport(AccountReportId, AccountRoleId, AllowOwnReport).Rows.Count > 0 Then
                Return True
            End If
            strRoles = ""
        Next
    End Function
    Public Function IsReportHasPermissionOfAllowOwnTeam(ByVal AccountReportId As Guid, ByVal AllowOwnTeam As Boolean) As Boolean
        Dim AccountRoleId As Integer
        Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))
        Dim strRoles As String = ""
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & AccountRoles(n)
            Dim BLL As New TimeLive.WebReport.ReportDesignBLL
            AccountRoleId = BLL.GetAccountRoleIdByRole(strRoles)
            If Adapter.GetDataByAllowOwnTeam(AccountReportId, AccountRoleId, AllowOwnTeam).Rows.Count > 0 Then
                Return True
            End If
            strRoles = ""
        Next
    End Function
    Public Function IsReportHasPermissionOfAllowOwnSubOrdinates(ByVal AccountReportId As Guid, ByVal AllowOwnSubOrdinates As Boolean) As Boolean
        Dim AccountRoleId As Integer
        Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))
        Dim strRoles As String = ""
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & AccountRoles(n)
            Dim BLL As New TimeLive.WebReport.ReportDesignBLL
            AccountRoleId = BLL.GetAccountRoleIdByRole(strRoles)
            If Adapter.GetDataByAllowOwnSubOrdinates(AccountReportId, AccountRoleId, AllowOwnSubOrdinates).Rows.Count > 0 Then
                Return True
            End If
            strRoles = ""
        Next
    End Function
    Public Function IsReportHasPermissionOfAllowOwnProject(ByVal AccountReportId As Guid, ByVal AllowOwnProject As Boolean) As Boolean
        Dim AccountRoleId As Integer
        Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))
        Dim strRoles As String = ""
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & AccountRoles(n)
            Dim BLL As New TimeLive.WebReport.ReportDesignBLL
            AccountRoleId = BLL.GetAccountRoleIdByRole(strRoles)
            If Adapter.GetDataByAllowOwnProject(AccountReportId, AccountRoleId, AllowOwnProject).Rows.Count > 0 Then
                Return True
            End If
            strRoles = ""
        Next
    End Function
    Public Function IsReportHasPermissionOfAllowOwnApproval(ByVal AccountReportId As Guid, ByVal AllowOwnApproval As Boolean) As Boolean
        Dim AccountRoleId As Integer
        Dim AccountRoles() As String = System.Web.Security.Roles.Provider.GetRolesForUser(System.Web.HttpContext.Current.Session("UserName"))
        Dim strRoles As String = ""
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & AccountRoles(n)
            Dim BLL As New TimeLive.WebReport.ReportDesignBLL
            AccountRoleId = BLL.GetAccountRoleIdByRole(strRoles)
            If Adapter.GetDataByAllowOwnApproval(AccountReportId, AccountRoleId, AllowOwnApproval).Rows.Count > 0 Then
                Return True
            End If
            strRoles = ""
        Next
    End Function
    Public Sub InsertDefaultReportPermission(ByVal AccountId As Integer)
        Adapter.InsertReportPermissionOf(AccountId)
    End Sub
    Public Sub InsertPermissionForNewReport(ByVal AccountId As Integer, ByVal AccountReportIdNew As Guid, ByVal AccountReportIdOld As Guid)
        Adapter.InsertPermissionForNewReport(AccountId, AccountReportIdNew, AccountReportIdOld)
    End Sub
    Public Sub InsertPermissionForReportByReportId(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal AccountReportId As Guid)
        Adapter.InsertPermissionOfReportByReportId(AccountReportId, AccountRoleId, AccountId)
    End Sub
    Public Sub InsertPermissionForReportByRole(ByVal AccountId As Integer, ByVal AccountRoleId As Integer, ByVal MasterAccountRoleId As Integer)
        Adapter.InsertReportPermissionByRole(AccountId, AccountRoleId, MasterAccountRoleId)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueSystemReportPermissionByAccountId(ByVal AccountId As Integer) As vueSystemReportPermissionDataTable
        Return vueSystemReportPermissionAdapter.GetDataByAccountId(AccountId)
    End Function
    Public Sub InsertObjectPermissionForCopyReport(ByVal NewReportId As Guid, ByVal AccountReportId As Guid, ByVal AccountId As Integer)
        Adapter.InsertAccountObjectPermissionForCopy(NewReportId, AccountId, AccountReportId)
    End Sub
    Public Function IsReportHasPermissionOfAllowAllUserByRoles(ByVal AccountReportId As Guid, ByVal AllowAllUser As Boolean, ByVal Roles As String, ByVal AccountId As Integer) As Boolean
        Dim AccountRoleId As Integer
        Dim AccountRoles As String() = Split(Roles, ".")
        Dim strRoles As String = ""
        For n As Integer = 0 To AccountRoles.Length - 1
            strRoles = strRoles & AccountRoles(n)
            Dim BLL As New AccountRoleBLL
            If BLL.GetAccountRolesByAccountIdAndRoles(AccountId, strRoles).Rows.Count > 0 Then
                AccountRoleId = BLL.GetAccountRolesByAccountIdAndRoles(AccountId, strRoles).Rows(0)("AccountRoleId")
            End If
            If Adapter.GetDataForAllowAllUser(AccountReportId, AccountRoleId, AllowAllUser).Rows.Count > 0 Then
                Return True
            End If
            strRoles = ""
        Next
    End Function
End Class
