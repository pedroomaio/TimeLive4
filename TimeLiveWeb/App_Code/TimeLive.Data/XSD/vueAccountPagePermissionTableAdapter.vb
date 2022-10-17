Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace TimeLiveDataSetTableAdapters
    Partial Public Class vueAccountPagePermissionTableAdapter
        Public Function GetDataByAccountRolesId(ByVal AccountId As Integer, ByVal AccountRoles As String()) As TimeLiveDataSet.vueAccountPagePermissionDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountPagePermission where AccountId =  " & AccountId

            Dim strRoles As String = ""
            For n As Integer = 0 To AccountRoles.Length - 1
                strRoles = strRoles & "'" & AccountRoles(n) & "'"
                If n + 1 <> AccountRoles.Length Then
                    strRoles = strRoles + ","
                End If

            Next

            ' For TimeSheetApprovalPath = TeamLead
            sql = sql + " and Role in (N" & strRoles & ") and (IsSiteMapPage = 1 or ControlLevelPermission = 1) "

            sql = sql + " and ((SystemFeatureId IN (SELECT SystemFeatureId FROM AccountFeatures WHERE (AccountId = " & DBUtilities.GetSessionAccountId & "))) or SystemFeatureId is null) ORDER BY SequenceNumber"

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountPagePermissionDataTable = New TimeLiveDataSet.vueAccountPagePermissionDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetDataByAccountRolesIdAndSystemSecurityCategoryPageId(ByVal AccountId As Integer, ByVal SystemSecurityCategoryPageId As Integer) As TimeLiveDataSet.vueAccountPagePermissionDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountPagePermission where AccountId =  " & AccountId

            'Dim strRoles As String = ""
            'For n As Integer = 0 To AccountRoles.Length - 1
            '    strRoles = strRoles & "'" & AccountRoles(n) & "'"
            '    If n + 1 <> AccountRoles.Length Then
            '        strRoles = strRoles + ","
            '    End If

            'Next

            ' For TimeSheetApprovalPath = TeamLead
            sql = sql + " and (SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & ") and (IsSiteMapPage = 1 or ControlLevelPermission = 1) ORDER BY SequenceNumber "

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountPagePermissionDataTable = New TimeLiveDataSet.vueAccountPagePermissionDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetDataByAccountIdAndEmployees(ByVal AccountId As Integer, ByVal AccountEmployees As String) As TimeLiveDataSet.vueAccountPagePermissionDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountPagePermission where AccountId =  " & AccountId & " and AccountEmployeeId in (" & AccountEmployees & ")"

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountPagePermissionDataTable = New TimeLiveDataSet.vueAccountPagePermissionDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function

    End Class
End Namespace

