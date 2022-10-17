Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace TimeLiveDataSetTableAdapters
    Public Class vueAccountProjectsTableAdapter
        Public Function GetvueAccountProjectsForReport(ByVal WhereClause As String, Optional ByVal OrderColumnName As String = "") As TimeLiveDataSet.vueAccountProjectsDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            If LicensingBLL.IsHostedFreeCustomerLicenseExpired(DBUtilities.GetSessionAccountId) Then
                sql = "Select TOP(3) *,CASE WHEN IsDisabled = 1 THEN ProjectName + ' (Disabled)' ELSE ProjectName END AS ProjectNameWithDisabled from vueAccountProjects " & WhereClause
            Else
                sql = "Select *,CASE WHEN IsDisabled = 1 THEN ProjectName + ' (Disabled)' ELSE ProjectName END AS ProjectNameWithDisabled from vueAccountProjects " & WhereClause
            End If


            If OrderColumnName <> "" Then
                sql = sql & " Order By " & OrderColumnName
            End If

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetAssignedDataByEmployeeIdProjectIdAndCompleted(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As Boolean, Optional ByVal IsTemplate As Boolean = False, Optional ByVal AccountId As Integer = -1, Optional ByVal IsFromCSV As Boolean = False, Optional ByVal ProjectName As String = "") As TimeLiveDataSet.vueAccountProjectsDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)
            If LicensingBLL.IsHostedFreeCustomerLicenseExpired(AccountId) Then
                sql = "Select TOP(3) * from vueAccountProjects "
            Else
                sql = "Select * from vueAccountProjects "
            End If

            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If
            sql = sql & "(IsTemplate = 0) AND "
            If Completed <> True Then
                sql = sql & "(Completed = 0) And "
            End If
            sql = sql & "NOT(ProjectCode LIKE '%ABSENCE%' AND PartyName LIKE '%Xpand%') AND"
            sql = sql & "(AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId = " & AccountEmployeeId & "))) AND "
            sql = sql & "(IsDeleted <> 1 OR IsDeleted Is NULL) AND (IsDeletedClient <> 1 OR IsDeletedClient IS NULL) AND (IsDisabled <> 1) AND (IsDisabledClient <> 1) "
            If IsFromCSV Then
                sql = sql & " And (ProjectName = '" & ProjectName & "') "
            End If
            sql = sql & " OR (AccountProjectId = " & AccountProjectId & ") "
            sql = sql & "ORDER BY ProjectName"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function

        Public Function GetAssignedDataByEmployeeIdProjectIDSelected(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As Boolean, Optional ByVal IsTemplate As Boolean = False, Optional ByVal AccountId As Integer = -1) As TimeLiveDataSet.vueAccountProjectsDataTable

            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)
            If LicensingBLL.IsHostedFreeCustomerLicenseExpired(AccountId) Then
                sql = "Select TOP(3) * from vueAccountProjects "
            Else
                sql = "Select * from vueAccountProjects "
            End If

            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If
            sql = sql & "(IsTemplate = 0) AND "
            If Completed <> True Then
                sql = sql & "(Completed = 0) And "
            End If
            sql = sql & "(AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId = " & AccountEmployeeId & ")))"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

        Public Function GetAssignedDataByEmployeeIdClientIdAndCompleted(ByVal AccountProjectId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer, ByVal Completed As Boolean, Optional ByVal AccountId As Integer = -1) As TimeLiveDataSet.vueAccountProjectsDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountProjects "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") And "
            End If
            sql = sql & "(AccountClientId = " & AccountClientId & ") AND (IsTemplate = 0) AND "
            If Completed <> True Then
                sql = sql & "(Completed = 0) And "
            End If
            sql = sql & "(AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountEmployeeId = " & AccountEmployeeId & "))) AND "
            sql = sql & "(IsDeleted <> 1 OR IsDeleted Is NULL) AND (IsDisabled <> 1) AND (IsDisabledClient <> 1) OR (AccountProjectId = " & AccountProjectId & ") "
            sql = sql & " or (isforallclientproject=1) and (AccountId = " & AccountId & ") ORDER BY ProjectName"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetDataByAccountProjectsForGridView(ByVal AccountId As Integer, ByVal IsTemplate As Boolean, ByVal Completed As String, ByVal ProjectStatusId As Integer, ByVal Disabled As String, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal ProjectCode As String, ByVal IsProjectAdd As Boolean) As TimeLiveDataSet.vueAccountProjectsDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT a.AccountClientId, a.AccountId, a.AccountProjectId, a.Deadline, a.EstimatedDuration, a.EstimatedDurationUnit, a.IsActive, a.IsDeleted, a.IsDeletedClient, a.IsDisabled, a.IsLock, a.LeaderEmployeeId, a.LeaderName, a.PartyDepartmentName, a.PartyName, a.PartyNick, a.ProjectCode, a.ProjectDescription, a.ProjectManagerEmployeeId, a.ProjectManagerName, a.ProjectName, a.ProjectPrefix, a.ProjectStatusId, a.StartDate, a.Status FROM vueAccountProjects "
            sql = sql & "AS a LEFT OUTER JOIN (SELECT TOP (3) AccountProjectId, ProjectName, StartDate, ProjectCode, PartyName, AccountClientId, LeaderEmployeeId, ProjectManagerEmployeeId, LeaderName, ProjectManagerName, AccountId, IsActive, Deadline, EstimatedDuration, EstimatedDurationUnit, ProjectStatusId, Status, IsDisabled, ProjectDescription, IsTemplate, IsProject, AccountProjectTemplateId, SystemProjectBillingRateType, AccountProjectTypeId, ProjectType, MasterAccountProjectTypeId, IsDeleted, PartyDepartmentName, IsDeletedClient, Completed, IsLock, ProjectPrefix FROM vueAccountProjects AS vueAccountProjects_1 "
            sql = sql & "WHERE "
            sql = sql & "(AccountId = " & AccountId & ") And (ISNULL(IsDeleted, 0) = 0) "
            If AccountClientId <> 0 Then
                sql = sql & "AND AccountClientId = " & AccountClientId & " "
            End If
            If Not ProjectCode Is Nothing Then
                sql = sql & "AND ProjectCode LIKE " & "'%" & ProjectCode & "%'" & " "
            End If
            If AccountProjectId <> 0 And IsProjectAdd = False Then
                sql = sql & "AND AccountProjectId = " & AccountProjectId & " "
            End If
            If IsTemplate <> False Then
                sql = sql & "AND (IsTemplate = " & 1 & ") "
            Else
                sql = sql & "AND (IsTemplate = " & 0 & ") "
            End If
            If Completed = "-1" Then
                sql = sql & "AND ((ISNULL(Completed, 0) = 0) OR (ISNULL(Completed, 0) = 1)) "
            ElseIf Completed = "1" Then
                sql = sql & "AND (ISNULL(Completed, 0) = 1) "
            Else
                sql = sql & "AND (ISNULL(Completed, 0) = 0) "
            End If
            If ProjectStatusId <> "0" Then
                sql = sql & "AND ProjectStatusId = " & ProjectStatusId & " "
            End If
            If Disabled = "-1" Then
                sql = sql & "AND ((ISNULL(IsDisabled, 0) = 0) OR (ISNULL(IsDisabled, 0) = 1)) "
            ElseIf Disabled = "1" Then
                sql = sql & "AND (ISNULL(IsDisabled, 0) = 0) "
            Else
                sql = sql & "AND (ISNULL(IsDisabled, 0) = 1) "
            End If
            sql = sql & ") AS b ON a.AccountProjectId = b.AccountProjectId WHERE (a.AccountId =" & AccountId & ") "
            If IsTemplate <> False Then
                sql = sql & "AND (a.IsTemplate = " & 1 & ") "
            Else
                sql = sql & "AND (a.IsTemplate = " & 0 & ") "
            End If

            If Completed = "-1" Then
                sql = sql & "AND ((ISNULL(a.Completed, 0) = 0) OR (ISNULL(a.Completed, 0) = 1)) "
            ElseIf Completed = "1" Then
                sql = sql & "AND (ISNULL(a.Completed, 0) = 1) "
            Else
                sql = sql & "AND (ISNULL(a.Completed, 0) = 0) "
            End If
            If ProjectStatusId <> "0" Then
                sql = sql & "AND a.ProjectStatusId = " & ProjectStatusId & " "
            End If
            If Disabled = "-1" Then
                sql = sql & "AND ((ISNULL(a.IsDisabled, 0) = 0) OR (ISNULL(a.IsDisabled, 0) = 1)) "
            ElseIf Disabled = "1" Then
                sql = sql & "AND (ISNULL(a.IsDisabled, 0) = 0) "
            Else
                sql = sql & "AND (ISNULL(a.IsDisabled, 0) = 1) "
            End If
            If AccountClientId <> 0 Then
                sql = sql & "AND a.AccountClientId = " & AccountClientId & " "
            End If
            If AccountProjectId <> 0 And IsProjectAdd = False Then
                sql = sql & "AND a.AccountProjectId = " & AccountProjectId & " "
            End If
            If Not ProjectCode Is Nothing Then
                sql = sql & "AND a.ProjectCode LIKE " & "'%" & ProjectCode & "%'" & " "
            End If
            sql = sql & "AND (ISNULL(a.IsDeleted, 0) = 0) AND (ISNULL(a.IsDeletedClient, 0) = 0) AND (ISNULL(b.IsLock, 0) = CASE WHEN isnull(a.IsLock , 0) = 1 THEN 1 ELSE 0 END) "
            If AccountProjectId <> 0 Then
                sql = sql & "ORDER BY a.AccountProjectId "
            Else
                sql = sql & "ORDER BY a.ProjectName "
            End If

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetDataByAccountProjectsForGridViewFreeAccount(ByVal AccountId As Integer, ByVal IsTemplate As Boolean, ByVal Completed As String, ByVal ProjectStatusId As Integer, ByVal Disabled As String, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal ProjectCode As String, ByVal IsProjectAdd As Boolean) As TimeLiveDataSet.vueAccountProjectsDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT TOP (3) AccountClientId, AccountId, AccountProjectId, Deadline, EstimatedDuration, EstimatedDurationUnit, IsActive, IsDeleted, IsDeletedClient, IsDisabled, IsLock, LeaderEmployeeId, LeaderName, PartyDepartmentName, PartyName, PartyNick, ProjectCode, ProjectDescription, ProjectManagerEmployeeId, ProjectManagerName, ProjectName, ProjectPrefix, ProjectStatusId, StartDate, Status FROM vueAccountProjects "
            sql = sql & "WHERE (AccountId = " & AccountId & ") And (ISNULL(IsDeleted, 0) = 0) AND (ISNULL(IsDeletedClient, 0) = 0) "
            If AccountClientId <> 0 Then
                sql = sql & "AND AccountClientId = " & AccountClientId & " "
            End If
            If Not ProjectCode Is Nothing Then
                sql = sql & "AND ProjectCode LIKE " & "'%" & ProjectCode & "%'" & " "
            End If
            If AccountProjectId <> 0 And IsProjectAdd = False Then
                sql = sql & "AND AccountProjectId = " & AccountProjectId & " "
            End If
            If IsTemplate <> False Then
                sql = sql & "AND (IsTemplate = " & 1 & ") "
            Else
                sql = sql & "AND (IsTemplate = " & 0 & ") "
            End If
            If Completed = "-1" Then
                sql = sql & "AND (ISNULL(Completed, 0) = 0) "
            ElseIf Completed = "1" Then
                sql = sql & "AND (ISNULL(Completed, 0) = 1) "
            Else
                sql = sql & "AND (ISNULL(Completed, 0) = 0) "
            End If
            If ProjectStatusId <> "0" Then
                sql = sql & "AND ProjectStatusId = " & ProjectStatusId & " "
            End If
            If Disabled = "-1" Then
                sql = sql & "AND ((ISNULL(IsDisabled, 0) = 0) OR (ISNULL(IsDisabled, 0) = 1)) "
            ElseIf Disabled = "1" Then
                sql = sql & "AND (ISNULL(IsDisabled, 0) = 0) "
            Else
                sql = sql & "AND (ISNULL(IsDisabled, 0) = 1) "
            End If

            If AccountProjectId <> 0 Then
                sql = sql & "ORDER BY AccountProjectId "
            Else
                sql = sql & "ORDER BY ProjectName "
            End If

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetAssignedDataByAccountEmployeeIdForMyProjects(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As String, ByVal ProjectStatusId As Integer, ByVal Disabled As String, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal ProjectCode As String) As TimeLiveDataSet.vueAccountProjectsDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT     a.AccountClientId, a.AccountId, a.AccountProjectId, a.Deadline, a.EstimatedDuration, a.EstimatedDurationUnit, a.IsActive, a.IsDeleted, a.IsDeletedClient, a.IsDisabled, a.IsLock, a.LeaderEmployeeId, a.LeaderName, a.PartyDepartmentName, a.PartyName, a.ProjectCode, a.ProjectDescription, a.ProjectManagerEmployeeId, a.ProjectManagerName, a.ProjectName, a.ProjectStatusId, a.StartDate, a.Status, a.ProjectPrefix, a.PartyNick, CASE WHEN a.Deadline >= GETDATE() THEN 'OnTime' ELSE 'Delayed' END AS ScheduleStatus FROM         vueAccountProjects AS a LEFT OUTER JOIN "
            sql = sql & "(SELECT     TOP (3) AccountProjectId, ProjectName, StartDate, ProjectCode, PartyName, AccountClientId, LeaderEmployeeId, ProjectManagerEmployeeId, LeaderName, ProjectManagerName, AccountId, IsActive, Deadline, EstimatedDuration, EstimatedDurationUnit, ProjectStatusId, Status, IsDisabled, ProjectDescription, IsTemplate, IsProject, AccountProjectTemplateId, SystemProjectBillingRateType, AccountProjectTypeId, ProjectType, MasterAccountProjectTypeId, IsDeleted, PartyDepartmentName, IsDeletedClient, Completed, IsLock, PartyNick, CASE WHEN Deadline >= GETDATE() THEN 'OnTime' ELSE 'Delayed' END AS ScheduleStatus FROM vueAccountProjects AS vueAccountProjects_1 "
            sql = sql & "WHERE (ISNULL(IsDeleted, 0) = 0) "
            If AccountClientId <> 0 Then
                sql = sql & "AND AccountClientId = " & AccountClientId & " "
            End If
            If Not ProjectCode Is Nothing Then
                sql = sql & "AND ProjectCode LIKE " & "'%" & ProjectCode & "%'" & " "
            End If
            If AccountProjectId <> 0 Then
                sql = sql & "AND AccountProjectId = " & AccountProjectId & " "
            End If
            sql = sql & "AND (AccountId = " & AccountId & ")) AS b ON a.AccountProjectId = b.AccountProjectId WHERE "

            If Completed = "-1" Then
                sql = sql & "((ISNULL(a.Completed, 0) = 0) OR (ISNULL(a.Completed, 0) = 1)) "
            ElseIf Completed = "1" Then
                sql = sql & "(ISNULL(a.Completed, 0) = 1) "
            Else
                sql = sql & "(ISNULL(a.Completed, 0) = 0) "
            End If
            If ProjectStatusId <> "0" Then
                sql = sql & "AND a.ProjectStatusId = " & ProjectStatusId & " "
            End If
            If Disabled = "-1" Then
                sql = sql & "AND ((ISNULL(a.IsDisabled, 0) = 0) OR (ISNULL(a.IsDisabled, 0) = 1)) "
            ElseIf Disabled = "1" Then
                sql = sql & "AND (ISNULL(a.IsDisabled, 0) = 0) "
            Else
                sql = sql & "AND (ISNULL(a.IsDisabled, 0) = 1) "
            End If

            sql = sql & "AND (a.IsTemplate <> 1) AND (a.AccountProjectId IN (SELECT     AccountProjectId FROM AccountProjectEmployee "
            sql = sql & "WHERE      (AccountEmployeeId = " & AccountEmployeeId & "))) AND (ISNULL(a.IsDeleted, 0) = 0) "
            If AccountClientId <> 0 Then
                sql = sql & "AND a.AccountClientId = " & AccountClientId & " "
            End If
            If AccountProjectId <> 0 Then
                sql = sql & "AND a.AccountProjectId = " & AccountProjectId & " "
            End If
            If Not ProjectCode Is Nothing Then
                sql = sql & "AND a.ProjectCode LIKE " & "'%" & ProjectCode & "%'" & " "
            End If
            sql = sql & "AND (ISNULL(a.IsDeletedClient, 0) = 0) AND (ISNULL(b.IsLock, 0) = CASE WHEN isnull(a.IsLock, 0) = 1 THEN 1 ELSE 0 END) "

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetAssignedDataByAccountEmployeeIdForMyProjectsFreeAccount(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal Completed As String, ByVal ProjectStatusId As Integer, ByVal Disabled As String, ByVal AccountClientId As Integer, ByVal AccountProjectId As Integer, ByVal ProjectCode As String) As TimeLiveDataSet.vueAccountProjectsDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "SELECT     TOP (3) AccountProjectId, ProjectName, StartDate, ProjectCode, PartyName, AccountClientId, LeaderEmployeeId, ProjectManagerEmployeeId, LeaderName, ProjectManagerName, AccountId, IsActive, Deadline, EstimatedDuration, EstimatedDurationUnit, ProjectStatusId, Status, IsDisabled, ProjectDescription, IsTemplate, IsProject, AccountProjectTemplateId, SystemProjectBillingRateType, AccountProjectTypeId, ProjectType, MasterAccountProjectTypeId, IsDeleted, PartyDepartmentName, IsDeletedClient, Completed, IsLock, PartyNick, CASE WHEN Deadline >= GETDATE() THEN 'OnTime' ELSE 'Delayed' END AS ScheduleStatus FROM vueAccountProjects "
            sql = sql & "WHERE (ISNULL(IsDeleted, 0) = 0) "
            If AccountClientId <> 0 Then
                sql = sql & "AND AccountClientId = " & AccountClientId & " "
            End If
            If Not ProjectCode Is Nothing Then
                sql = sql & "AND ProjectCode LIKE " & "'%" & ProjectCode & "%'" & " "
            End If
            If AccountProjectId <> 0 Then
                sql = sql & "AND AccountProjectId = " & AccountProjectId & " "
            End If
            sql = sql & "AND (AccountId = " & AccountId & ") AND "

            If Completed = "-1" Then
                sql = sql & "(ISNULL(Completed, 0) = 0) "
            ElseIf Completed = "1" Then
                sql = sql & "(ISNULL(Completed, 0) = 1) "
            Else
                sql = sql & "(ISNULL(Completed, 0) = 0) "
            End If
            If ProjectStatusId <> "0" Then
                sql = sql & "AND ProjectStatusId = " & ProjectStatusId & " "
            End If
            If Disabled = "-1" Then
                sql = sql & "AND ((ISNULL(IsDisabled, 0) = 0) OR (ISNULL(IsDisabled, 0) = 1)) "
            ElseIf Disabled = "1" Then
                sql = sql & "AND (ISNULL(IsDisabled, 0) = 0) "
            Else
                sql = sql & "AND (ISNULL(IsDisabled, 0) = 1) "
            End If

            sql = sql & "AND (IsTemplate <> 1) AND (AccountProjectId IN (SELECT     AccountProjectId FROM AccountProjectEmployee "
            sql = sql & "WHERE      (AccountEmployeeId = " & AccountEmployeeId & "))) AND (ISNULL(IsDeleted, 0) = 0) "
            If AccountClientId <> 0 Then
                sql = sql & "AND AccountClientId = " & AccountClientId & " "
            End If
            If AccountProjectId <> 0 Then
                sql = sql & "AND AccountProjectId = " & AccountProjectId & " "
            End If
            If Not ProjectCode Is Nothing Then
                sql = sql & "AND ProjectCode LIKE " & "'%" & ProjectCode & "%'" & " "
            End If
            sql = sql & "AND (ISNULL(IsDeletedClient, 0) = 0)"

            If AccountProjectId <> 0 Then
                sql = sql & "ORDER BY AccountProjectId "
            Else
                sql = sql & "ORDER BY ProjectName "
            End If

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetProjectsRowCount(ByVal AccountId As Integer) As TimeLiveDataSet.vueAccountProjectsDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountProjects "
            sql = sql & "WHERE "
            If AccountId <> -1 Then
                sql = sql & "(AccountId = " & AccountId & ") "
            End If

            sql = sql & "AND IsNull(IsDeleted,0) <> 1 AND (ISNULL(IsDeletedClient, 0) = 0) AND (ISNULL(Completed, 0) = 0)"
            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
        Public Function GetTimeOffInternalProjects() As TimeLiveDataSet.vueAccountProjectsDataTable
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountProjects "
            sql = sql & "WHERE (ProjectCode LIKE '%ABSENCE%' AND PartyName LIKE '%Xpand%') AND "
            sql = sql & "(AccountProjectId IN (SELECT AccountProjectId FROM AccountProjectEmployee WHERE "
            sql = sql & " IsNull(IsDeleted,0) <> 1 AND (ISNULL(IsDeletedClient, 0) = 0) AND (ISNULL(Completed, 0) = 0))) "
            sql = sql & "Order by AccountProjectId asc"
            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectsDataTable = New TimeLiveDataSet.vueAccountProjectsDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class

End Namespace
