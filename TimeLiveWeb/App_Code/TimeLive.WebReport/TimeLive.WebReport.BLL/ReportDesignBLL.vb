Imports dsReportDesign
Imports dsReportDesignTableAdapters

Namespace TimeLive.WebReport
    <System.ComponentModel.DataObject()> _
        Public Class ReportDesignBLL

        Private _AccountReportCategoryTableAdapter As New AccountReportCategoryTableAdapter
        Private _SystemReportDataSourceTableAdapter As New SystemReportDataSourceTableAdapter
        Private _vueSystemReportDataSourceFieldTableAdapter As New vueSystemReportDataSourceFieldTableAdapter
        Private _SystemReportCalculationTypeTableAdapter As New SystemReportCalculationTypeTableAdapter
        Private _SystemReportTypeTableAdapter As New SystemReportTypeTableAdapter
        Private _AccountReportTableAdapter As New AccountReportTableAdapter
        Private _AccountReportColumnTableAdapter As New AccountReportColumnTableAdapter
        Private _AccountReportDataSourceMappingTableAdapter As New AccountReportDataSourceMappingTableAdapter
        Private _AccountReportGroupTableAdapter As New AccountReportGroupTableAdapter
        Private _AccountReportSummaryTableAdapter As New AccountReportSummaryTableAdapter
        Private _vueAccountReportTableAdapter As New vueAccountReportTableAdapter
        Private _SystemReportFieldTypeTableAdapter As New SystemReportFieldTypeTableAdapter
        Private _CountReportOrderTableAdapter As New CountReportOrderTableAdapter

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountReportDataSourceMappingByAccountReportId(ByVal AccountReportId As Guid) As dsReportDesign.AccountReportDataSourceMappingDataTable
            Return _AccountReportDataSourceMappingTableAdapter.GetDataByAccountReportId(AccountReportId)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetAccountReportCategoryByAccountId(ByVal AccountId As Integer) As dsReportDesign.AccountReportCategoryDataTable
            GetAccountReportCategoryByAccountId = _AccountReportCategoryTableAdapter.GetDataByAccountId(AccountId)
            Return ResourceHelper.SetResourceValueInDataTable(GetAccountReportCategoryByAccountId, "AccountReportCategory")
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetAccountReportByAccountReportId(ByVal AccountReportId As Guid) As dsReportDesign.AccountReportDataTable
            Return _AccountReportTableAdapter.GetDataByAccountReportId(AccountReportId)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetSystemReportDataSource() As dsReportDesign.SystemReportDataSourceDataTable
            If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
                GetSystemReportDataSource = _SystemReportDataSourceTableAdapter.GetDataForBugTracking
            Else
                GetSystemReportDataSource = _SystemReportDataSourceTableAdapter.GetData
            End If
            Return ResourceHelper.SetResourceValueInDataTable(GetSystemReportDataSource, "ReportDataSourceName")
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetSystemReportDataSourceFieldBySystemReportDataSourceIdAndAccountReportId(ByVal SystemReportDataSourceId As Guid, ByVal AccountReportId As Guid) As dsReportDesign.vueSystemReportDataSourceFieldDataTable
            Return _vueSystemReportDataSourceFieldTableAdapter.GetDataBySystemReportDataSourceIdAndAccountReportId(AccountReportId, SystemReportDataSourceId)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetSystemReportCalculationTypes() As dsReportDesign.SystemReportCalculationTypeDataTable
            GetSystemReportCalculationTypes = _SystemReportCalculationTypeTableAdapter.GetData
            Return ResourceHelper.SetResourceValueInDataTable(GetSystemReportCalculationTypes, "CalculationType")
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetSystemReportTypes() As dsReportDesign.SystemReportTypeDataTable
            Return _SystemReportTypeTableAdapter.GetData
        End Function

        Public Function GetAccountReportGroupByAccountReportId(ByVal AccountReportId As Guid) As dsReportDesign.AccountReportGroupDataTable
            Return _AccountReportGroupTableAdapter.GetDataByAccountReportId(AccountReportId)
        End Function

        Public Function GetAccountReportColumnByAccountReportIdAndCalculationTypeIdIsNotNull(ByVal AccountReportId As Guid) As dsReportDesign.AccountReportColumnDataTable
            Return _AccountReportColumnTableAdapter.GetDataByAccountReportIdAndCalculationTypeIdNotNull(AccountReportId)
        End Function

        Public Function GetAccountReportColumnByAccountReportId(ByVal AccountReportId As Guid) As dsReportDesign.AccountReportColumnDataTable
            Return _AccountReportColumnTableAdapter.GetDataByAccountReportId(AccountReportId)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
        Public Sub UpdateMyReportGrid(ByVal AccountReportId As String, ByVal Visible As Boolean)

            _AccountReportTableAdapter = New AccountReportTableAdapter
            Dim dtReport As dsReportDesign.AccountReportDataTable = _AccountReportTableAdapter.GetDataByAccountReportId(New Guid(AccountReportId))
            Dim drReport As dsReportDesign.AccountReportRow
            If dtReport.Rows.Count > 0 Then
                drReport = dtReport.Rows(0)

                With drReport
                    .Visible = Visible
                End With

            End If

            _AccountReportTableAdapter.Update(dtReport)

        End Sub

        Public Function GetSystemReportFieldTypes() As dsReportDesign.SystemReportFieldTypeDataTable
            Return _SystemReportFieldTypeTableAdapter.GetData()
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
        Public Function GetDataForMyReportGrid(ByVal AccountId As Integer, ByVal AccountRoles As String, ByVal IsShowAll As Boolean, ByVal Optional ShowVisible As Boolean = True) As dsReportDesign.vueAccountReportDataTable
            If IsShowAll Then
                GetDataForMyReportGrid = _vueAccountReportTableAdapter.GetDataByAccountIdUnion(AccountId)
            Else
                GetDataForMyReportGrid = _vueAccountReportTableAdapter.GetDataByAccountIdAndAccountRoles(AccountId, AccountRoles)
            End If

            For i As Integer = 0 To GetDataForMyReportGrid.Rows.Count - 1
                Dim ColumnNameValue() As String = Split(GetDataForMyReportGrid.Rows.Item(i).Item("AccountReportCategorySequence").ToString, " - ")
                Dim value As String = ResourceHelper.GetFromResource(ColumnNameValue(1))
                'value = ColumnNameValue(0) & " - " & value
                GetDataForMyReportGrid.Rows.Item(i).Item("AccountReportCategorySequence") = value
            Next

            Dim rowToDelete As New List(Of DataRow)

            If ShowVisible = False Then

                For Each item As DataRow In GetDataForMyReportGrid.Rows
                    If item("Visible") = False Then
                        rowToDelete.Add(item)
                    End If
                Next

                For index = 0 To rowToDelete.Count - 1
                    GetDataForMyReportGrid.Rows.Remove(rowToDelete(index))
                Next

            End If

            UIUtilities.FixTableForNoRecords(GetDataForMyReportGrid)
            Return GetDataForMyReportGrid
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
        Public Function GetDataForMyReportGrid(ByVal AccountId As Integer) As dsReportDesign.vueAccountReportDataTable
            GetDataForMyReportGrid = _vueAccountReportTableAdapter.GetDataByAccountIdUnion(AccountId)
            UIUtilities.FixTableForNoRecords(GetDataForMyReportGrid)
            Return GetDataForMyReportGrid
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Function GetvueAccountReportByAccountReportId(ByVal AccountReportId As Guid) As dsReportDesign.vueAccountReportDataTable
            Return _vueAccountReportTableAdapter.GetDataByAccountReportId(AccountReportId)
        End Function

        Public Function AddAccountReport(ByVal ReportName As String, ByVal ReportDescription As String, ByVal AccountReportCategoryId As Guid, ByVal ReportIconPath As String, ByVal AccountId As Integer, ByVal IsConsolidated As Boolean, ByVal IsSystemReport As Boolean, ByVal SystemReportId As Guid, ByVal ReportOrder As Integer, ByVal ShowCompanyLogo As Boolean, ByVal ReportTitle As String, ByVal ReportHeader As String, ByVal ReportFooter As String, ByVal Optional Visible As Boolean = True) As Guid

            _AccountReportTableAdapter = New AccountReportTableAdapter

            Dim dtAccountReport As New dsReportDesign.AccountReportDataTable
            Dim drAccountReport As dsReportDesign.AccountReportRow = dtAccountReport.NewAccountReportRow
            Dim nAccountReportId As Guid = System.Guid.NewGuid

            With drAccountReport
                .AccountReportId = nAccountReportId
                .AccountReportCategoryId = AccountReportCategoryId
                .ReportName = ReportName
                .ReportDescription = ReportDescription
                If Not ReportIconPath Is Nothing Then
                    .ReportIconPath = ReportIconPath
                End If
                .AccountId = AccountId
                .IsConsolidated = IsConsolidated
                If IsSystemReport = True Then
                    .SystemReportId = SystemReportId
                End If
                .ReportOrder = ReportOrder
                .ShowCompanyLogo = ShowCompanyLogo
                If Not ReportTitle Is Nothing Then
                    .ReportTitle = ReportTitle
                End If
                If Not ReportHeader Is Nothing Then
                    .ReportHeader = ReportHeader
                End If
                If Not ReportFooter Is Nothing Then
                    .ReportFooter = ReportFooter
                End If
                .Visible = Visible
            End With

            dtAccountReport.AddAccountReportRow(drAccountReport)

            ' Add the new product
            Dim rowsAffected As Integer = _AccountReportTableAdapter.Update(dtAccountReport)

            ' Return true if precisely one row was inserted, otherwise false
            Return nAccountReportId
        End Function
        Public Function AddAccountReportColumn(ByVal AccountReportId As Guid, ByVal Caption As String, ByVal SystemReportDataSourceFieldId As Guid, ByVal ColumnOrder As String, ByVal SystemReportCalculationTypeId As Guid, ByVal Formula As String)

            _AccountReportColumnTableAdapter = New AccountReportColumnTableAdapter

            Dim dtAccountReportColumn As New dsReportDesign.AccountReportColumnDataTable
            Dim drAccountReportColumn As dsReportDesign.AccountReportColumnRow = dtAccountReportColumn.NewAccountReportColumnRow

            With drAccountReportColumn
                .AccountReportColumnId = System.Guid.NewGuid
                .AccountReportId = AccountReportId
                .Caption = Caption
                .SystemReportDataSourceFieldId = SystemReportDataSourceFieldId
                .ColumnOrder = ColumnOrder
                If SystemReportCalculationTypeId <> System.Guid.Empty Then
                    .SystemReportCalculationTypeId = SystemReportCalculationTypeId
                Else
                    .Item("SystemReportCalculationTypeId") = System.DBNull.Value
                End If
                If Formula <> "" Then
                    .ColumnFormula = Formula
                End If
            End With

            dtAccountReportColumn.AddAccountReportColumnRow(drAccountReportColumn)

            ' Add the new product
            Dim rowsAffected As Integer = _AccountReportColumnTableAdapter.Update(dtAccountReportColumn)

            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1

        End Function

        Public Function AddAccountReportGroup(ByVal AccountReportId As Guid, ByVal ReportGroup As String, ByVal ReportGroupFieldLabel As String, ByVal ReportGroupFieldOrder As String, ByVal SystemReportDataSourceFieldId As Guid) As Guid

            _AccountReportGroupTableAdapter = New AccountReportGroupTableAdapter

            Dim dtAccountReportGroup As New dsReportDesign.AccountReportGroupDataTable
            Dim drAccountReportGroup As dsReportDesign.AccountReportGroupRow = dtAccountReportGroup.NewAccountReportGroupRow
            Dim AccountReportGroupId As Guid = System.Guid.NewGuid

            With drAccountReportGroup
                .AccountReportGroupId = AccountReportGroupId
                .AccountReportId = AccountReportId
                .ReportGroup = ReportGroup
                .ReportGroupFieldLabel = ReportGroupFieldLabel
                .ReportGroupFieldOrder = ReportGroupFieldOrder
                .SystemReportDataSourceFieldId = SystemReportDataSourceFieldId
            End With

            dtAccountReportGroup.AddAccountReportGroupRow(drAccountReportGroup)

            ' Add the new product
            Dim rowsAffected As Integer = _AccountReportGroupTableAdapter.Update(dtAccountReportGroup)

            ' Return true if precisely one row was inserted, otherwise false
            Return AccountReportGroupId

        End Function

        Public Function AddAccountReportDataSourceMapping(ByVal AccountReportId As Guid, ByVal SystemReportDataSourceId As Guid)

            _AccountReportDataSourceMappingTableAdapter = New AccountReportDataSourceMappingTableAdapter

            Dim dtAccountReportDataSourceMapping As New dsReportDesign.AccountReportDataSourceMappingDataTable
            Dim drAccountReportDataSourceMapping As dsReportDesign.AccountReportDataSourceMappingRow = dtAccountReportDataSourceMapping.NewAccountReportDataSourceMappingRow

            With drAccountReportDataSourceMapping
                .AccountReportDataSourceMappingId = System.Guid.NewGuid
                .AccountReportId = AccountReportId
                .SystemReportDataSourceId = SystemReportDataSourceId
            End With

            dtAccountReportDataSourceMapping.AddAccountReportDataSourceMappingRow(drAccountReportDataSourceMapping)

            ' Add the new product
            Dim rowsAffected As Integer = _AccountReportDataSourceMappingTableAdapter.Update(dtAccountReportDataSourceMapping)

            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1

        End Function
        Public Function AddAccountReportSummary(ByVal AccountReportGroupId As Guid, ByVal AccountReportId As Guid, _
        ByVal SystemReportCalculationTypeId As Guid, ByVal AccountReportColumnId As Guid, ByVal SummaryCaption As String, _
        ByVal IsShowGroupTotal As Boolean, ByVal IsShowGrandTotal As Boolean)

            _AccountReportSummaryTableAdapter = New AccountReportSummaryTableAdapter

            Dim dtAccountReportSummary As New dsReportDesign.AccountReportSummaryDataTable
            Dim drAccountReportSummary As dsReportDesign.AccountReportSummaryRow = dtAccountReportSummary.NewAccountReportSummaryRow

            With drAccountReportSummary
                .AccountReportSummaryId = System.Guid.NewGuid
                If AccountReportGroupId <> System.Guid.Empty Then
                    .AccountReportGroupId = AccountReportGroupId
                Else
                    .Item("AccountReportGroupId") = System.DBNull.Value
                End If
                .AccountReportId = AccountReportId
                .SystemReportCalculationTypeId = SystemReportCalculationTypeId
                .AccountReportColumnId = AccountReportColumnId
                .SummaryCaption = SummaryCaption
                .IsShowGroupTotal = IsShowGroupTotal
                .IsShowGrandTotal = IsShowGrandTotal
            End With

            dtAccountReportSummary.AddAccountReportSummaryRow(drAccountReportSummary)

            ' Add the new product
            Dim rowsAffected As Integer = _AccountReportSummaryTableAdapter.Update(dtAccountReportSummary)

            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected

        End Function
        Public Function GetReportColumnByColumnId(ByVal AccountReportId As Guid, ByVal SystemReportDataSourceFieldId As Guid) As Guid

            Dim dtAccountReportColumn As dsReportDesign.AccountReportColumnDataTable = _AccountReportColumnTableAdapter.GetDataByAccountReportIdAndSystemReportDataSourceFieldId(AccountReportId, SystemReportDataSourceFieldId)
            Dim drAccountReportColumn As dsReportDesign.AccountReportColumnRow

            If dtAccountReportColumn.Rows.Count > 0 Then
                drAccountReportColumn = dtAccountReportColumn.Rows(0)
                Return drAccountReportColumn.AccountReportColumnId
            End If
        End Function
        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Function DeleteAccountReport(ByVal Original_AccountReportId As Guid) As Boolean
            Dim rowsAffected As Integer = _AccountReportTableAdapter.Delete(Original_AccountReportId)

            Return rowsAffected = 1
        End Function
        Public Function DeleteAccountReportColumn(ByVal Original_AccountReportColumnId As Guid) As Boolean
            Dim rowsAffected As Integer = _AccountReportColumnTableAdapter.Delete(Original_AccountReportColumnId)

            Return rowsAffected = 1
        End Function
        Public Function DeleteAccountReportGroup(ByVal Original_AccountReportGroupId As Guid) As Boolean
            Dim rowsAffected As Integer = _AccountReportGroupTableAdapter.Delete(Original_AccountReportGroupId)

            Return rowsAffected = 1
        End Function
        Public Function DeleteAccountReportSummary(ByVal AccountReportId As Guid, ByVal AccountReportColumnId As Guid, ByVal AccountReportGroupId As Guid) As Boolean
            Dim rowsAffected As Integer = _AccountReportSummaryTableAdapter.DeleteAccountReportSummary(AccountReportId, AccountReportColumnId, AccountReportGroupId)

            Return rowsAffected = 1
        End Function
        Public Function DeleteAccountReportSummaryByReportIdAndReportGroupIdIsNull(ByVal AccountReportId As Guid) As Boolean
            Dim rowsAffected As Integer = _AccountReportSummaryTableAdapter.DeleteReportSummaryByReportIdAndReportGroupIdIsNull(AccountReportId)

            Return rowsAffected = 1
        End Function
        Public Function DeleteAccountReportSummaryByReportIdReportColumnIdAndReportGroupIdIsNull(ByVal AccountReportId As Guid, ByVal AccountReportColumnId As Guid) As Boolean
            Dim rowsAffected As Integer = _AccountReportSummaryTableAdapter.DeleteReportSummaryByReportIdReportColumnIdAndReportGroupIdIsNull(AccountReportId, AccountReportColumnId)

            Return rowsAffected = 1
        End Function
        Public Function IsAccountReportGroupExist(ByVal AccountReportId As Guid, ByVal SystemReportDataSourceFieldId As Guid) As Boolean
            If _AccountReportGroupTableAdapter.GetDataByAccountReportIdAndSystemReportDataSourceFieldId(AccountReportId, SystemReportDataSourceFieldId).Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function GetAccountReportGroupId(ByVal AccountReportId As Guid, ByVal SystemReportDataSourceFieldId As Guid)

            _AccountReportGroupTableAdapter = New AccountReportGroupTableAdapter

            Dim dtAccountReportGroup As dsReportDesign.AccountReportGroupDataTable = _AccountReportGroupTableAdapter.GetDataByAccountReportIdAndSystemReportDataSourceFieldId(AccountReportId, SystemReportDataSourceFieldId)
            Dim drAccountReportGroup As dsReportDesign.AccountReportGroupRow

            If dtAccountReportGroup.Rows.Count > 0 Then
                drAccountReportGroup = dtAccountReportGroup.Rows(0)
                Return drAccountReportGroup.AccountReportGroupId
            End If
        End Function
        Public Function UpdateAccountReport(ByVal AccountReportId As Guid, ByVal ReportName As String, ByVal AccountReportCategoryId As Guid, ByVal ReportDescription As String, ByVal ReportIconPath As String, ByVal ShowCompanyLogo As Boolean, ByVal ReportTitle As String, ByVal ReportHeader As String, ByVal ReportFooter As String)

            Dim dtAccountReport As dsReportDesign.AccountReportDataTable = _AccountReportTableAdapter.GetDataByAccountReportId(AccountReportId)
            Dim drAccountReport As dsReportDesign.AccountReportRow = dtAccountReport.Rows(0)

            With drAccountReport
                .AccountReportCategoryId = AccountReportCategoryId
                .ReportName = ReportName
                .ReportDescription = ReportDescription
                If Not ReportIconPath Is Nothing Then
                    .ReportIconPath = ReportIconPath
                End If
                .ShowCompanyLogo = ShowCompanyLogo
                .ReportTitle = ReportTitle
                .ReportHeader = ReportHeader
                .ReportFooter = ReportFooter
            End With

            Dim rowsAffected As Integer = _AccountReportTableAdapter.Update(dtAccountReport)
            Return rowsAffected
        End Function
        Public Function UpdateAccountReportColumn(ByVal AccountReportColumnId As Guid, ByVal Caption As String, ByVal SystemReportCalculationTypeId As Guid, ByVal Formula As String)

            Dim dtAccountReportColumn As dsReportDesign.AccountReportColumnDataTable = _AccountReportColumnTableAdapter.GetDataByAccountReportColumnId(AccountReportColumnId)
            Dim drAccountReportColumn As dsReportDesign.AccountReportColumnRow = dtAccountReportColumn.Rows(0)

            With drAccountReportColumn
                .Caption = Caption
                If SystemReportCalculationTypeId <> System.Guid.Empty Then
                    .SystemReportCalculationTypeId = SystemReportCalculationTypeId
                End If
                If Formula <> "" Then
                    .ColumnFormula = Formula
                ElseIf .Item("ColumnFormula").ToString <> "" And Formula = "" Then
                    .Item("ColumnFormula") = System.DBNull.Value
                End If
            End With

            Dim rowsAffected As Integer = _AccountReportColumnTableAdapter.Update(dtAccountReportColumn)
            Return rowsAffected
        End Function

        Public Function UpdateSystemReportCalculationTypeIdInAccountReportSummary(ByVal AccountReportId As Guid, ByVal AccountReportColumnId As Guid, ByVal SystemReportCalculationTypeId As Guid)

            Dim dtAccountReportSummary As dsReportDesign.AccountReportSummaryDataTable = _AccountReportSummaryTableAdapter.GetDataByAccountReportIdAndAccountReportColumnId(AccountReportId, AccountReportColumnId)
            Dim drAccountReportSummary As dsReportDesign.AccountReportSummaryRow

            If dtAccountReportSummary.Rows.Count > 0 Then
                drAccountReportSummary = dtAccountReportSummary.Rows(0)

                For Each drAccountReportSummary In dtAccountReportSummary.Rows
                    drAccountReportSummary.SystemReportCalculationTypeId = SystemReportCalculationTypeId
                Next

                Dim rowsAffected As Integer = _AccountReportSummaryTableAdapter.Update(dtAccountReportSummary)
                Return rowsAffected
            End If
        End Function

        Public Function IsAccountReportSummaryExist(ByVal AccountReportId As Guid, ByVal AccountReportColumnId As Guid, ByVal AccountReportGroupId As Guid) As Boolean
            If _AccountReportSummaryTableAdapter.GetDataForAccountReportGroupExist(AccountReportId, AccountReportGroupId, AccountReportColumnId).Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function UpdateNullSystemReportCalculationTypeIdInAccountReportColumn(ByVal AccountReportColumnId As Guid)

            Dim dtAccountReportColumn As dsReportDesign.AccountReportColumnDataTable = _AccountReportColumnTableAdapter.GetDataByAccountReportColumnId(AccountReportColumnId)
            Dim drAccountReportColumn As dsReportDesign.AccountReportColumnRow

            If dtAccountReportColumn.Rows.Count > 0 Then
                drAccountReportColumn = dtAccountReportColumn.Rows(0)

                With drAccountReportColumn
                    .Item("SystemReportCalculationTypeId") = System.DBNull.Value
                End With

                Dim rowsAffected As Integer = _AccountReportColumnTableAdapter.Update(dtAccountReportColumn)
                Return rowsAffected
            End If
        End Function
        Public Function UpdateIsConsolidatedInAccountReport(ByVal AccountReportId As Guid, ByVal IsConsolidated As Boolean)

            Dim dtAccountReport As dsReportDesign.AccountReportDataTable = _AccountReportTableAdapter.GetDataByAccountReportId(AccountReportId)
            Dim drAccountReport As dsReportDesign.AccountReportRow = dtAccountReport.Rows(0)

            With drAccountReport
                If Not .Item("AccountId").ToString = "" Then
                    .IsConsolidated = IsConsolidated
                End If
            End With

            Dim rowsAffected As Integer = _AccountReportTableAdapter.Update(dtAccountReport)
            Return rowsAffected

        End Function
        Public Function GetCountFieldOrderByAccountReportId(ByVal AccountReportId As Guid) As Integer
            _AccountReportGroupTableAdapter = New AccountReportGroupTableAdapter
            Dim dtAccountReportGroup As dsReportDesign.AccountReportGroupDataTable = _AccountReportGroupTableAdapter.GetDataByAccountReportId(AccountReportId)
            Dim count As Integer = dtAccountReportGroup.Rows.Count
            Return count
        End Function
        Public Function UpdateReportGroupFieldOrderInAccountReportGroup(ByVal AccountReportId As Guid)

            _AccountReportGroupTableAdapter = New AccountReportGroupTableAdapter

            Dim dtAccountReportGroup As dsReportDesign.AccountReportGroupDataTable = _AccountReportGroupTableAdapter.GetDataByAccountReportId(AccountReportId)
            Dim drAccountReportGroup As dsReportDesign.AccountReportGroupRow

            Dim count As Integer = 0
            If dtAccountReportGroup.Rows.Count > 0 Then
                drAccountReportGroup = dtAccountReportGroup.Rows(0)
                For Each drAccountReportGroup In dtAccountReportGroup.Rows
                    drAccountReportGroup.ReportGroupFieldOrder = count
                    count += 1
                Next

                Dim rowsAffected As Integer = _AccountReportGroupTableAdapter.Update(dtAccountReportGroup)
                Return rowsAffected
            End If
        End Function
        Public Function IsReportSummaryExistFor(ByVal AccountReportId As Guid, ByVal AccountReportColumnId As Guid) As Boolean
            If _AccountReportSummaryTableAdapter.GetDataByReportIdReportColumnIdAndReportGroupIdIsNull(AccountReportId, AccountReportColumnId).Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function GetObjectPermissionDataRowByRole(ByVal AccountReportId As Guid, ByVal AccountRoleId As Integer) As dsObjectPermission.AccountObjectPermissionRow
            Dim dt As dsObjectPermission.AccountObjectPermissionDataTable = New ObjectPermissionBLL().GetAccountObjectPermissionsByAccountReportIdAndAccountRoleId(AccountRoleId, AccountReportId)
            Dim dr As dsObjectPermission.AccountObjectPermissionRow

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                Return dr
            End If
            Return Nothing
        End Function
        Public Function GetAccountRoleIdByRole(ByVal Role As String) As Integer

            Dim dt As TimeLiveDataSet.AccountRoleDataTable = New AccountRoleBLL().GetAccountRolesByAccountIdAndRoles(DBUtilities.GetSessionAccountId, Role)
            Dim dr As TimeLiveDataSet.AccountRoleRow

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                Return dr.AccountRoleId
            End If
            Return 0
        End Function
        Public Function UpdateColumnOrderInAccountReportColumn(ByVal AccountReportColumnId As Guid, ByVal ColumnOrder As Integer)

            Dim dtAccountReportColumn As dsReportDesign.AccountReportColumnDataTable = _AccountReportColumnTableAdapter.GetDataByAccountReportColumnId(AccountReportColumnId)
            Dim drAccountReportColumn As dsReportDesign.AccountReportColumnRow = dtAccountReportColumn.Rows(0)

            With drAccountReportColumn
                .ColumnOrder = ColumnOrder
            End With

            Dim rowsAffected As Integer = _AccountReportColumnTableAdapter.Update(dtAccountReportColumn)
            Return rowsAffected
        End Function
        Public Function UpdateColumnOrderInAccountReportGroup(ByVal AccountReportGroupId As Guid, ByVal ReportGroupFieldOrder As Integer)

            Dim dtAccountReportGroup As dsReportDesign.AccountReportGroupDataTable = _AccountReportGroupTableAdapter.GetDataByAccountReportGroupId(AccountReportGroupId)
            Dim drAccountReportGroup As dsReportDesign.AccountReportGroupRow = dtAccountReportGroup.Rows(0)

            With drAccountReportGroup
                .ReportGroupFieldOrder = ReportGroupFieldOrder
            End With

            Dim rowsAffected As Integer = _AccountReportGroupTableAdapter.Update(dtAccountReportGroup)
            Return rowsAffected
        End Function
        Public Function DeleteAccountReportColumnByAccountReportId(ByVal AccountReportId As Guid) As Boolean
            Dim rowsAffected As Integer = _AccountReportColumnTableAdapter.DeleteReportColumnByReportId(AccountReportId)

            Return rowsAffected = 1
        End Function
        Public Function DeleteAccountReportGroupByAccountReportId(ByVal AccountReportId As Guid) As Boolean
            Dim rowsAffected As Integer = _AccountReportGroupTableAdapter.DeleteReportGroupByReportId(AccountReportId)

            Return rowsAffected = 1
        End Function
        Public Function DeleteAccountReportSummaryByAccountReportId(ByVal AccountReportId As Guid) As Boolean
            Dim rowsAffected As Integer = _AccountReportSummaryTableAdapter.DeleteReportSummaryByReportId(AccountReportId)

            Return rowsAffected = 1
        End Function
        Public Function IsAccountReportGroupExistByAccountReportId(ByVal AccountReportId As Guid) As Boolean
            If _AccountReportGroupTableAdapter.GetDataByAccountReportId(AccountReportId).Rows.Count > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function GetReportGroupCaption(ByVal AccountReportId As Guid, ByVal SystemReportDataSourceFieldId As Guid) As String
            Dim dt As dsReportDesign.AccountReportGroupDataTable = _AccountReportGroupTableAdapter.GetDataByAccountReportIdAndSystemReportDataSourceFieldId(AccountReportId, SystemReportDataSourceFieldId)
            Dim dr As dsReportDesign.AccountReportGroupRow = dt.Rows(0)

            Return dr.ReportGroupFieldLabel

        End Function
        Public Function GetSystemReportDataSourceId(ByVal AccountReportId As Guid) As Guid
            Dim dt As dsReportDesign.AccountReportDataSourceMappingDataTable = _AccountReportDataSourceMappingTableAdapter.GetDataByAccountReportId(AccountReportId)
            Dim dr As dsReportDesign.AccountReportDataSourceMappingRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                Return dr.SystemReportDataSourceId
            End If
        End Function
        Public Function GetDefaultIconPath(ByVal SystemReportDataSourceId As Guid) As String
            Dim dt As dsReportDesign.SystemReportDataSourceDataTable = _SystemReportDataSourceTableAdapter.GetDataBySystemReportDataSourceId(SystemReportDataSourceId)
            Dim dr As dsReportDesign.SystemReportDataSourceRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                If Not IsDBNull(dr.Item("DefaultIconPath")) Then
                    Return dr.DefaultIconPath
                End If
            End If
        End Function
        Public Function GetMaxReportOrderFromAccountReport(ByVal AccountReportCategoryId As Guid, ByVal AccountId As Integer) As Integer
            Dim dt As dsReportDesign.CountReportOrderDataTable = _CountReportOrderTableAdapter.GetDataByAccountReportCategoryIdAndAccountId(AccountReportCategoryId, AccountId) '
            Dim dr As dsReportDesign.CountReportOrderRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                If Not IsDBNull(dr.Item("ReportOrder")) Then
                    Return dr.ReportOrder
                End If
            End If
        End Function
        Public Function GetReportIconPathForCustomizeReport(ByVal AccountReportId As Guid) As String
            Dim dtAccountReport As dsReportDesign.AccountReportDataTable = _AccountReportTableAdapter.GetDataByAccountReportId(AccountReportId)
            Dim drAccountReport As dsReportDesign.AccountReportRow
            If dtAccountReport.Rows.Count > 0 Then
                drAccountReport = dtAccountReport.Rows(0)
                If Not IsDBNull(drAccountReport.Item("ReportIconPath")) Then
                    Return drAccountReport.ReportIconPath
                End If
            End If
        End Function
        Public Function GetColumnOrderByAccountReportId(ByVal AccountReportId As Guid) As Integer
            _AccountReportColumnTableAdapter = New AccountReportColumnTableAdapter
            Dim dtAccountReportColumn As dsReportDesign.AccountReportColumnDataTable = _AccountReportColumnTableAdapter.GetDataByAccountReportId(AccountReportId)
            Dim count As Integer = dtAccountReportColumn.Rows.Count
            Return count
        End Function
        Public Function CopyReportByReportId(ByVal AccountReportId As Guid) As Guid
            Dim dt As dsReportDesign.AccountReportDataTable = _AccountReportTableAdapter.GetDataByAccountReportId(AccountReportId)
            Dim dr As dsReportDesign.AccountReportRow = dt.Rows(0)
            Dim ReportOrder As Integer = GetMaxReportOrderFromAccountReport(dr.AccountReportCategoryId, DBUtilities.GetSessionAccountId) + 1
            Dim NewAccountReportId As Guid = Me.AddAccountReport(dr.ReportName, dr.ReportDescription, dr.AccountReportCategoryId, IIf(IsDBNull(dr.Item("ReportIconPath")), Nothing, dr.Item("ReportIconPath")), DBUtilities.GetSessionAccountId, IIf(IsDBNull(dr.Item("IsConsolidated")), False, dr.Item("IsConsolidated")), False, System.Guid.Empty, ReportOrder, IIf(IsDBNull(dr.Item("ShowCompanyLogo")), False, dr.Item("ShowCompanyLogo")), IIf(IsDBNull(dr.Item("ReportTitle")), Nothing, dr.Item("ReportTitle")), IIf(IsDBNull(dr.Item("ReportHeader")), Nothing, dr.Item("ReportHeader")), IIf(IsDBNull(dr.Item("ReportFooter")), Nothing, dr.Item("ReportFooter")), dr.Visible)
            _AccountReportDataSourceMappingTableAdapter.InsertAccountReportDataSourceMappingForCopy(NewAccountReportId, AccountReportId)
            _AccountReportColumnTableAdapter.InsertAccountReportColumnForCopy(NewAccountReportId, AccountReportId)
            _AccountReportGroupTableAdapter.InsertAccountReportGroupForCopy(NewAccountReportId, AccountReportId)
            _AccountReportSummaryTableAdapter.InsertAccountReportSummaryForCopy(NewAccountReportId)
            Call New ObjectPermissionBLL().InsertObjectPermissionForCopyReport(NewAccountReportId, AccountReportId, DBUtilities.GetSessionAccountId)
            Return NewAccountReportId
        End Function
    End Class
End Namespace
