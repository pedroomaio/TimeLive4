Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace dsReportDesignTableAdapters
    Partial Public Class vueAccountReportTableAdapter

        Public Function GetDataByAccountIdAndAccountRoles(ByVal AccountId As Integer, ByVal AccountRoles As String) As dsReportDesign.vueAccountReportDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "select * from vueAccountReport where AccountReportId in (SELECT AccountReportId FROM vueAccountObjectPermission where "

            sql = sql + " Role in (" & AccountRoles & ") and ShowReport = 1 "

            'If DBUtilities.IsTimesheetFeature Then
            '    sql = sql + "And AccountReportId <> 'DB046660-CB45-4ADB-B103-27A00775D42A' "
            'End If

            sql = sql + "And AccountId = " & AccountId & ") And AccountId = " & AccountId

            sql = sql + " AND (SystemFeatureId IN (SELECT SystemFeatureId FROM AccountFeatures WHERE (AccountId = " & AccountId & ")) OR SystemFeatureId IS NULL) "

            sql = sql + " AND (SystemFeatureCategoryId IN (SELECT SystemFeatureId FROM AccountFeatures WHERE (AccountId = " & AccountId & ")) OR SystemFeatureCategoryId IS NULL) "

            sql = sql + " Union All "

            sql = sql + "select * from vueAccountReport where AccountReportId in (SELECT AccountReportId FROM vueAccountObjectPermission where "

            sql = sql + " Role in (" & AccountRoles & ") and ShowReport = 1 "

            'If DBUtilities.IsTimesheetFeature Then
            '    sql = sql + "And AccountReportId <> 'DB046660-CB45-4ADB-B103-27A00775D42A' "
            'End If

            sql = sql + "And AccountId = " & AccountId & ") And AccountId is null"

            sql = sql + " AND (AccountReportId NOT IN (SELECT SystemReportId FROM AccountReport WHERE (AccountId = " & AccountId & ") AND (SystemReportId IS NOT NULL)))"

            sql = sql + " AND (SystemFeatureId IN (SELECT SystemFeatureId FROM AccountFeatures WHERE (AccountId = " & AccountId & ")) OR SystemFeatureId IS NULL) "

            sql = sql + " AND (SystemFeatureCategoryId IN (SELECT SystemFeatureId FROM AccountFeatures WHERE (AccountId = " & AccountId & ")) OR SystemFeatureCategoryId IS NULL) "

            sql = sql + "ORDER BY SequenceNo desc, ReportOrder"

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As dsReportDesign.vueAccountReportDataTable = New dsReportDesign.vueAccountReportDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function


        Public Function GetDataByAccountIdUnion(ByVal AccountId As Integer) As dsReportDesign.vueAccountReportDataTable
            If AccountPagePermissionBLL.IsPageHasPermissionOf(136, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(113, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(147, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(149, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(1, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(118, 1) = True Or AccountPagePermissionBLL.IsPageHasPermissionOf(122, 1) = True Then
                Return Me.GetDataByAccountIdUnionAll(AccountId)
            Else
                Return Me.GetDataByAccountIdForTimesheetFeature(AccountId)
            End If
        End Function

    End Class
End Namespace
