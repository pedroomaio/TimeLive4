Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Projects
    Inherits System.Web.Services.WebService
    Public SoapHeader As SecuredWebServiceHeader
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function AddProject(ByVal objProject As Project) As String
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Return "Please call AuthenitcateUser() first."
        End If
        Return "Hello World"
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjects() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ProjectArrayList As New ArrayList
        Dim objProject As New Project
        Dim ProjectBLL As New AccountProjectBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtProject As TimeLiveDataSet.vueAccountProjectsDataTable = ProjectBLL.GetAccountProjectsForGridView(AccountId, False, "-1", 0, "1")
        Dim drProject As TimeLiveDataSet.vueAccountProjectsRow
        For Each drProject In dtProject.Rows
            objProject = New Project
            With objProject
                If Not IsDBNull(drProject.Item("ProjectCode")) Then
                    .ProjectCode = drProject.Item("ProjectCode")
                Else
                    .ProjectCode = ""
                End If
                .ProjectName = drProject.ProjectName
                .ClientName = drProject.PartyName
            End With
            ProjectArrayList.Add(objProject)
        Next
        Return ProjectArrayList
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetAssignedProjects() As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ProjectArrayList As New ArrayList
        Dim objProject As New Project
        Dim ProjectBLL As New AccountProjectBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim AccountEmployeeId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountEmployeeID
        Dim dtProject As TimeLiveDataSet.vueAccountProjectsDataTable = ProjectBLL.GetAssignedAccountProjectsByAccountEmployeeIdForMobile(AccountId, AccountEmployeeId, "-1", 0, "1")
        Dim drProject As TimeLiveDataSet.vueAccountProjectsRow
        For Each drProject In dtProject.Rows
            objProject = New Project
            With objProject
                If Not IsDBNull(drProject.Item("ProjectCode")) Then
                    .ProjectCode = drProject.Item("ProjectCode")
                Else
                    .ProjectCode = ""
                End If
                If Not IsDBNull(drProject.Item("ProjectName")) Then
                    .ProjectName = drProject.ProjectName
                End If
                If Not IsDBNull(drProject.Item("PartyName")) Then
                    .ClientName = drProject.PartyName
                End If
                .ProjectID = drProject.AccountProjectId
            End With
            ProjectArrayList.Add(objProject)
        Next
        Return ProjectArrayList
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetAssignedProjectsByClient(ByVal AccountClientId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ProjectArrayList As New ArrayList
        Dim objProject As New Project
        Dim ProjectBLL As New AccountProjectBLL
        Dim dtProject As TimeLiveDataSet.vueAccountProjectsDataTable = ProjectBLL.GetAssignedAccountProjectsByAccountClientId(AccountClientId)
        Dim drProject As TimeLiveDataSet.vueAccountProjectsRow
        For Each drProject In dtProject.Rows
            objProject = New Project
            With objProject
                If Not IsDBNull(drProject.Item("ProjectCode")) Then
                    .ProjectCode = drProject.Item("ProjectCode")
                Else
                    .ProjectCode = ""
                End If
                .ProjectID = drProject.AccountProjectId
                .ProjectName = drProject.ProjectName
                .ClientId = drProject.AccountClientId
                .ClientName = drProject.PartyName
            End With
            ProjectArrayList.Add(objProject)
        Next
        Return ProjectArrayList
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjectNameByProjectId(ByVal AccountProjectId As Integer) As ArrayList
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ProjectArrayList As New ArrayList
        Dim objProject As New Project
        Dim ProjectBLL As New AccountProjectBLL
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByAccountProjectId(AccountProjectId)
        Dim drProject As TimeLiveDataSet.AccountProjectRow
        For Each drProject In dtProject.Rows
            objProject = New Project
            With objProject
                .ProjectCode = drProject.ProjectCode
                .ProjectName = drProject.ProjectName
            End With
            ProjectArrayList.Add(objProject)
        Next
        Return ProjectArrayList
    End Function
    <WebMethod()> _
    Public Function GetAccountEmployeeId(ByVal Username As String, ByVal Password As String) As Integer
        Dim BLL As New AccountEmployeeBLL
        Dim dtAccountEmployee As AccountEmployee.vueAccountEmployeeDataTable = BLL.GetDataByAdminLogin(Username, Password)
        Dim drAccountEmployee As AccountEmployee.vueAccountEmployeeRow
        If dtAccountEmployee.Rows.Count > 0 Then
            drAccountEmployee = dtAccountEmployee.Rows(0)
            Return drAccountEmployee.AccountEmployeeId
        Else
            Return 0
        End If
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Sub InsertProject(ByVal AccountProjectTypeId As Integer, _
    ByVal AccountClientId As Integer, ByVal AccountPartyContactId As Integer, _
    ByVal AccountPartyDepartmentId As Integer, ByVal ProjectBillingTypeId As Integer, ByVal ProjectName As String, _
    ByVal ProjectDescription As String, ByVal StartDate As Date, ByVal DeadLine As Date, _
    ByVal ProjectStatusId As Integer, ByVal LeaderEmployeeId As Integer, ByVal ProjectManagerEmployeeId As Integer, _
    ByVal TimesheetApprovalTypeId As Integer, ByVal ExpenseApprovalTypeId As Integer, _
    ByVal EstimatedDuration As Double, ByVal EstimatedDurationUnit As String, ByVal ProjectCode As String, _
    ByVal DefaultBillingRate As Decimal, ByVal ProjectBillingRateTypeId As Integer, ByVal IsTemplate As Boolean, _
    ByVal IsProject As Boolean, ByVal AccountProjectTemplateId As Integer, ByVal CreatedOn As Date, _
    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As Date, ByVal ModifiedByEmployeeId As Integer, _
    ByVal Completed As Boolean)
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim ProjectBLL As New AccountProjectBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = ProjectBLL.GetAccountProjectsByProjectName(AccountId, ProjectName)
        If dtProject.Rows.Count > 0 Then
        Else
            ProjectBLL.AddAccountProject(AccountId, AccountProjectTypeId, AccountClientId, AccountPartyContactId, _
            AccountPartyDepartmentId, ProjectBillingTypeId, ProjectName, ProjectDescription, StartDate, DeadLine, _
            ProjectStatusId, LeaderEmployeeId, ProjectManagerEmployeeId, TimesheetApprovalTypeId, _
            ExpenseApprovalTypeId, EstimatedDuration, EstimatedDurationUnit, ProjectCode, DefaultBillingRate, _
            ProjectBillingRateTypeId, IsTemplate, IsProject, AccountProjectTemplateId, CreatedOn, CreatedByEmployeeId, _
            ModifiedOn, ModifiedByEmployeeId, Completed, "", True, 0, 0)
        End If
    End Sub
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjectId(ByVal ProjectName As String) As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objProject As New AccountProjectBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nProjectId As Integer
        Try
            nProjectId = objProject.GetAccountProjectsByProjectName(AccountId, ProjectName).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project " & """" & ProjectName & """" & " not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjectTypeId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objProjectType As New AccountProjectTypeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nProjectTypeId As Integer
        Try
            nProjectTypeId = objProjectType.GetAccountProjectTypesByAccountIdAndIsDisabled(AccountId, 0).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Type not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectTypeId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjectBillingTypeId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objProjectBillingType As New AccountBillingTypeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nProjectBillingTypeId As Integer
        Try
            nProjectBillingTypeId = objProjectBillingType.GetAccountBillingTypesForProjectByAccountIdAndIsDisabled(AccountId, 0).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Billing Type not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectBillingTypeId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjectStatusId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objProjectStatus As New AccountStatusBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nProjectStatusId As Integer
        Try
            nProjectStatusId = objProjectStatus.GetAccountsStatusForProjectByIsDisabled(AccountId, 0).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Status not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectStatusId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetTeamLeadId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objTeamLead As New AccountEmployeeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nTeamLeadId As Integer = objTeamLead.GetAccountEmployeesByAccountIdAndIsDisabled(AccountId, 0).Rows(0).Item(0)
        Return nTeamLeadId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjectManagerId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objProjectManager As New AccountEmployeeBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nProjectManagerId As Integer = objProjectManager.GetAccountEmployeesByAccountIdAndIsDisabled(AccountId, 0).Rows(0).Item(0)
        Return nProjectManagerId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjectBillingRateTypeId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objProjectBillingRateType As New SystemDataBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nProjectBillingRateTypeId As Integer
        Try
            nProjectBillingRateTypeId = objProjectBillingRateType.GetProjectBillingRateTypeForQB().Rows(3).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Billing Rate Type not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectBillingRateTypeId
    End Function
    <WebMethod()> _
    <System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjectMilestoneId() As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objProjectMilestone As New AccountProjectMilestoneBLL
        Dim AccountId As Integer = TimeLiveServices.GetSecurityToken(SoapHeader.AuthenticatedToken).AccountID
        Dim nProjectMilestoneId As Integer
        Try
            nProjectMilestoneId = objProjectMilestone.GetAccountProjectMilestonesByAccountId(AccountId).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Milestone not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectMilestoneId
    End Function
    <WebMethod()> _
<System.Web.Services.Protocols.SoapHeader("SoapHeader")> _
    Public Function GetProjectMilestoneIdByProjectId(ByVal AccountProjectId As Integer) As Integer
        If Not TimeLiveServices.IsUserValid(SoapHeader) Then
            Throw New Exception("You are not authorized to access this.")
        End If
        Dim objProjectMilestone As New AccountProjectMilestoneBLL
        Dim nProjectMilestoneId As Integer
        Try
            nProjectMilestoneId = objProjectMilestone.GetAccountProjectMilestonesByProjectId(AccountProjectId).Rows(0).Item(0)
        Catch ex As Exception
            If ex.Message = "There is no row at position 0." Then
                Throw New Exception("Project Milestone not exist.")
            Else
                Throw ex
            End If
        End Try
        Return nProjectMilestoneId
    End Function
End Class
