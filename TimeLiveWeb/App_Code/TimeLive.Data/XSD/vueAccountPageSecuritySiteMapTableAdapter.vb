Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Namespace AccountPageSecuritySiteMapTableAdapters
    Partial Public Class vueAccountPageSecuritySiteMapTableAdapter
        Public Function GetDataByAccountId(ByVal AccountId As Integer) As AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountPageSecuritySiteMap where AccountId =  " & AccountId

            sql = sql + " and (IsSiteMapPage = 1 or ControlLevelPermission = 1) "

            sql = sql + "  ORDER BY SequenceNumber"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable = New AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetDataByAccountIdForFeatures(ByVal AccountId As Integer) As AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountPageSecuritySiteMap where AccountId =  " & AccountId

            sql = sql + " and (IsSiteMapPage = 1 or ControlLevelPermission = 1) "

            sql = sql + " and ((SystemFeatureId IN (SELECT SystemFeatureId FROM AccountFeatures WHERE (AccountId = " & DBUtilities.GetSessionAccountId & "))) or SystemFeatureId is null) ORDER BY SequenceNumber"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable = New AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetDataByAccountIdAndSystemSecurityCategoryPageId(ByVal AccountId As Integer, ByVal SystemSecurityCategoryPageId As Integer) As AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountPageSecuritySiteMap where AccountId =  " & AccountId

            sql = sql + " and (SystemSecurityCategoryPageId = " & SystemSecurityCategoryPageId & ") and (IsSiteMapPage = 1 or ControlLevelPermission = 1) "

            sql = sql + " and ((SystemFeatureId IN (SELECT SystemFeatureId FROM AccountFeatures WHERE (AccountId = " & DBUtilities.GetSessionAccountId & "))) or SystemFeatureId is null) ORDER BY SequenceNumber"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable = New AccountPageSecuritySiteMap.vueAccountPageSecuritySiteMapDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
    End Class
End Namespace

