Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class AccountPartyBLL
    Private _AccountPartyTableAdapter As AccountPartyTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountPartyTableAdapter
        Get
            If _AccountPartyTableAdapter Is Nothing Then
                _AccountPartyTableAdapter = New AccountPartyTableAdapter()
            End If

            Return _AccountPartyTableAdapter
        End Get
    End Property

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPartys() As TimeLiveDataSet.AccountPartyDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPartiesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountPartyDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPartiesByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String) As TimeLiveDataSet.AccountPartyDataTable
        GetAccountPartiesByAccountIdAndDatabaseFieldName = Adapter.GetDataByAccountIdAndDatabaseFieldName(AccountId, DatabaseFieldName)
        Return GetAccountPartiesByAccountIdAndDatabaseFieldName
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPartiesByAccountIdForQB(ByVal AccountId As Integer) As TimeLiveDataSet.AccountPartyDataTable
        Return Adapter.GetDataByAccountIdForQB(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
Public Function GetAccountPartiesByAccountIdAndAccountPartyId(ByVal AccountId As Integer, ByVal AccountPartyId As Integer) As TimeLiveDataSet.AccountPartyDataTable
        Return Adapter.GetDataByAccountIdAndAccountPartyId(AccountId, AccountPartyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetClientsByName(ByVal AccountId As Integer, ByVal ClientName As String) As TimeLiveDataSet.AccountPartyDataTable
        Return Adapter.GetClientByNameAndAccountId(AccountId, ClientName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPartiesByAccountPartyId(ByVal AccountPartyId As Integer) As TimeLiveDataSet.AccountPartyDataTable
        Return Adapter.GetDataByAccountPartyId(AccountPartyId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountPartiesByAccountId(ByVal AccountId As Integer, ByVal AccountPartyId As Integer) As TimeLiveDataSet.vueAccountPartyDataTable
        Dim _vueAccountPartyTableAdapter As New vueAccountPartyTableAdapter
        GetvueAccountPartiesByAccountId = _vueAccountPartyTableAdapter.GetDataByAccountIdForDropdownList(AccountId, AccountPartyId)
        Return GetvueAccountPartiesByAccountId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountPartiesByAccountIdForGridView(ByVal AccountId As Integer, ByVal AccountPartyId As Integer) As TimeLiveDataSet.vueAccountPartyDataTable
        Dim _vueAccountPartyTableAdapter As New vueAccountPartyTableAdapter
        GetvueAccountPartiesByAccountIdForGridView = _vueAccountPartyTableAdapter.GetDataByAccountIdForGridView(AccountId, AccountPartyId)
        UIUtilities.FixTableForNoRecords(GetvueAccountPartiesByAccountIdForGridView)
        Return GetvueAccountPartiesByAccountIdForGridView
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetClientsByAccountIdAndClientIdForNotDeleted(ByVal AccountId As Integer, ByVal AccountClientId As Integer) As TimeLiveDataSet.vueAccountPartyDataTable
        '''''''''''''''''Retruns 0 record if specific AccountClientId isdeleted=1
        Dim _vueAccountPartyTableAdapter As New vueAccountPartyTableAdapter
        Return _vueAccountPartyTableAdapter.GetClientsByAccountIdAndClientIdNotDeleted(AccountId, AccountClientId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountParty( _
                    ByVal AccountId As System.Nullable(Of Integer), _
                    ByVal PartyName As String, _
                    ByVal PartyNick As String, _
                    ByVal EMailAddress As String, _
                    ByVal Address1 As String, _
                    ByVal Address2 As String, _
                    ByVal CountryId As System.Nullable(Of Short), _
                    ByVal State As String, _
                    ByVal City As String, _
                    ByVal ZipCode As String, _
                    ByVal Telephone1 As String, _
                    ByVal Telephone2 As String, _
                    ByVal Fax As String, _
                    ByVal DefaultBillingRate As System.Nullable(Of Decimal), _
                    ByVal Website As String, _
                    ByVal Notes As String, _
                    ByVal IsDisabled As Boolean, _
                    ByVal IsDeleted As Boolean, _
                    ByVal CreatedOn As DateTime, _
                    ByVal CreatedByEmployeeId As Integer, _
                    ByVal ModifiedOn As DateTime, _
                    ByVal ModifiedByEmployeeId As Integer, _
                    ByVal FixedBidBillingMode As Integer, _
                    ByVal FixedCost As Double, _
                    Optional ByVal IsWebServiceCall As Boolean = False, _
                    Optional ByVal CustomField1 As String = "", _
                    Optional ByVal CustomField2 As String = "", _
                    Optional ByVal CustomField3 As String = "", _
                    Optional ByVal CustomField4 As String = "", _
                    Optional ByVal CustomField5 As String = "", _
                    Optional ByVal CustomField6 As String = "", _
                    Optional ByVal CustomField7 As String = "", _
                    Optional ByVal CustomField8 As String = "", _
                    Optional ByVal CustomField9 As String = "", _
                    Optional ByVal CustomField10 As String = "", _
                    Optional ByVal CustomField11 As String = "", _
                    Optional ByVal CustomField12 As String = "", _
                    Optional ByVal CustomField13 As String = "", _
                    Optional ByVal CustomField14 As String = "", _
                    Optional ByVal CustomField15 As String = "" _
                    ) As Boolean

        Try
            _AccountPartyTableAdapter = New AccountPartyTableAdapter
            Dim AccountParties As New TimeLiveDataSet.AccountPartyDataTable
            Dim AccountParty As TimeLiveDataSet.AccountPartyRow = AccountParties.NewAccountPartyRow
            With AccountParty
                .AccountId = AccountId
                .PartyName = PartyName
                .PartyTypeId = 1
                .PartyNick = PartyNick
                .EMailAddress = EMailAddress
                .Address1 = Address1
                .Address2 = Address2
                .CountryId = CountryId
                .State = State
                .City = City
                .ZipCode = ZipCode
                .Telephone1 = Telephone1
                .Telephone2 = Telephone2
                .Fax = Fax
                If DefaultBillingRate.HasValue Then
                    .DefaultBillingRate = DefaultBillingRate
                End If
                .Website = Website
                .Notes = Notes
                .IsDisabled = False
                .IsDeleted = False
                .CreatedOn = Now
                .CreatedByEmployeeId = CreatedByEmployeeId
                .ModifiedOn = Now
                .ModifiedByEmployeeId = ModifiedByEmployeeId
                .FixedBidBillingMode = FixedBidBillingMode
                .FixedCost = FixedCost
                If CustomField1 <> "" Then
                    .CustomField1 = CustomField1
                Else
                    .Item("CustomField1") = System.DBNull.Value
                End If
                If CustomField2 <> "" Then
                    .CustomField2 = CustomField2
                Else
                    .Item("CustomField2") = System.DBNull.Value
                End If
                If CustomField3 <> "" Then
                    .CustomField3 = CustomField3
                Else
                    .Item("CustomField3") = System.DBNull.Value
                End If
                If CustomField4 <> "" Then
                    .CustomField4 = CustomField4
                Else
                    .Item("CustomField4") = System.DBNull.Value
                End If
                If CustomField5 <> "" Then
                    .CustomField5 = CustomField5
                Else
                    .Item("CustomField5") = System.DBNull.Value
                End If
                If CustomField6 <> "" Then
                    .CustomField6 = CustomField6
                Else
                    .Item("CustomField6") = System.DBNull.Value
                End If
                If CustomField7 <> "" Then
                    .CustomField7 = CustomField7
                Else
                    .Item("CustomField7") = System.DBNull.Value
                End If
                If CustomField8 <> "" Then
                    .CustomField8 = CustomField8
                Else
                    .Item("CustomField8") = System.DBNull.Value
                End If
                If CustomField9 <> "" Then
                    .CustomField9 = CustomField9
                Else
                    .Item("CustomField9") = System.DBNull.Value
                End If
                If CustomField10 <> "" Then
                    .CustomField10 = CustomField10
                Else
                    .Item("CustomField10") = System.DBNull.Value
                End If
                If CustomField11 <> "" Then
                    .CustomField11 = CustomField11
                Else
                    .Item("CustomField11") = System.DBNull.Value
                End If
                If CustomField12 <> "" Then
                    .CustomField12 = CustomField12
                Else
                    .Item("CustomField12") = System.DBNull.Value
                End If
                If CustomField13 <> "" Then
                    .CustomField13 = CustomField13
                Else
                    .Item("CustomField13") = System.DBNull.Value
                End If
                If CustomField14 <> "" Then
                    .CustomField14 = CustomField14
                Else
                    .Item("CustomField14") = System.DBNull.Value
                End If
                If CustomField15 <> "" Then
                    .CustomField15 = CustomField15
                Else
                    .Item("CustomField15") = System.DBNull.Value
                End If
            End With
            AccountParties.AddAccountPartyRow(AccountParty)
            ' Add the new product
            Dim rowsAffected As Integer = Adapter.Update(AccountParties)

            If Not IsWebServiceCall Then
                AfterUpdate()
            End If

            If rowsAffected = 1 Then
                If DBUtilities.HideProjectFromApplication Then
                    Me.HideProjectFromApplication(GetLastInsertedPartyId, PartyName, PartyNick)
                End If
            End If
            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1
5:      Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountParty( _
                    ByVal PartyTypeId As Short, _
                    ByVal AccountId As System.Nullable(Of Integer), _
                    ByVal PartyName As String, _
                    ByVal PartyNick As String, _
                    ByVal EMailAddress As String, _
                    ByVal Address1 As String, _
                    ByVal Address2 As String, _
                    ByVal CountryId As System.Nullable(Of Short), _
                    ByVal State As String, _
                    ByVal City As String, _
                    ByVal ZipCode As String, _
                    ByVal Telephone1 As String, _
                    ByVal Telephone2 As String, _
                    ByVal Fax As String, _
                    ByVal DefaultBillingRate As System.Nullable(Of Decimal), _
                    ByVal Website As String, _
                    ByVal Notes As String, _
                    ByVal IsDisabled As Boolean, _
                    ByVal IsDeleted As Boolean, _
                    ByVal CreatedOn As DateTime, _
                    ByVal CreatedByEmployeeId As Integer, _
                    ByVal ModifiedOn As DateTime, _
                    ByVal ModifiedByEmployeeId As Integer, _
                    ByVal Original_AccountPartyId As Integer, _
                    ByVal FixedBidBillingMode As Integer, _
                    ByVal FixedCost As Double, _
                    Optional ByVal CustomField1 As String = "", _
                    Optional ByVal CustomField2 As String = "", _
                    Optional ByVal CustomField3 As String = "", _
                    Optional ByVal CustomField4 As String = "", _
                    Optional ByVal CustomField5 As String = "", _
                    Optional ByVal CustomField6 As String = "", _
                    Optional ByVal CustomField7 As String = "", _
                    Optional ByVal CustomField8 As String = "", _
                    Optional ByVal CustomField9 As String = "", _
                    Optional ByVal CustomField10 As String = "", _
                    Optional ByVal CustomField11 As String = "", _
                    Optional ByVal CustomField12 As String = "", _
                    Optional ByVal CustomField13 As String = "", _
                    Optional ByVal CustomField14 As String = "", _
                    Optional ByVal CustomField15 As String = "" _
                    ) As Boolean

        ' Update the product record

        Dim AccountParties As TimeLiveDataSet.AccountPartyDataTable = Adapter.GetDataByAccountPartyId(Original_AccountPartyId)
        Dim AccountParty As TimeLiveDataSet.AccountPartyRow = AccountParties.Rows(0)

        With AccountParty
            .AccountId = AccountId
            .PartyName = PartyName
            .PartyNick = PartyNick
            .EMailAddress = EMailAddress
            .Address1 = Address1
            .Address2 = Address2
            .CountryId = CountryId
            .State = State
            .City = City
            .ZipCode = ZipCode
            .Telephone1 = Telephone1
            .Telephone2 = Telephone2
            .Fax = Fax
            If DefaultBillingRate.HasValue Then
                .DefaultBillingRate = DefaultBillingRate
            End If
            .Website = Website
            .Notes = Notes
            .IsDisabled = IsDisabled
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .FixedCost = FixedCost
            .FixedBidBillingMode = FixedBidBillingMode
            If CustomField1 <> "" Then
                .CustomField1 = CustomField1
            Else
                .Item("CustomField1") = System.DBNull.Value
            End If
            If CustomField2 <> "" Then
                .CustomField2 = CustomField2
            Else
                .Item("CustomField2") = System.DBNull.Value
            End If
            If CustomField3 <> "" Then
                .CustomField3 = CustomField3
            Else
                .Item("CustomField3") = System.DBNull.Value
            End If
            If CustomField4 <> "" Then
                .CustomField4 = CustomField4
            Else
                .Item("CustomField4") = System.DBNull.Value
            End If
            If CustomField5 <> "" Then
                .CustomField5 = CustomField5
            Else
                .Item("CustomField5") = System.DBNull.Value
            End If
            If CustomField6 <> "" Then
                .CustomField6 = CustomField6
            Else
                .Item("CustomField6") = System.DBNull.Value
            End If
            If CustomField7 <> "" Then
                .CustomField7 = CustomField7
            Else
                .Item("CustomField7") = System.DBNull.Value
            End If
            If CustomField8 <> "" Then
                .CustomField8 = CustomField8
            Else
                .Item("CustomField8") = System.DBNull.Value
            End If
            If CustomField9 <> "" Then
                .CustomField9 = CustomField9
            Else
                .Item("CustomField9") = System.DBNull.Value
            End If
            If CustomField10 <> "" Then
                .CustomField10 = CustomField10
            Else
                .Item("CustomField10") = System.DBNull.Value
            End If
            If CustomField11 <> "" Then
                .CustomField11 = CustomField11
            Else
                .Item("CustomField11") = System.DBNull.Value
            End If
            If CustomField12 <> "" Then
                .CustomField12 = CustomField12
            Else
                .Item("CustomField12") = System.DBNull.Value
            End If
            If CustomField13 <> "" Then
                .CustomField13 = CustomField13
            Else
                .Item("CustomField13") = System.DBNull.Value
            End If
            If CustomField14 <> "" Then
                .CustomField14 = CustomField14
            Else
                .Item("CustomField14") = System.DBNull.Value
            End If
            If CustomField15 <> "" Then
                .CustomField15 = CustomField15
            Else
                .Item("CustomField15") = System.DBNull.Value
            End If
        End With


        Dim rowsAffected As Integer = Adapter.Update(AccountParty)

        Me.AfterUpdate()

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function AfterUpdate()
        If DBUtilities.IsApplicationContext Then
            CacheManager.ClearCache("AccountPartyDataTable", , True)
            CacheManager.ClearCache("ClientDataTable", , True)
            CacheManager.ClearCache("Client", , , True)
            CacheManager.ClearCache("vueAccountProjectsDataTable", , True)
            CacheManager.ClearCache("AccountProjectDataTable", , True)
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountParty(ByVal original_AccountPartyId As Integer) As Boolean
        Try
            'Dim rowsAffected As Integer = Adapter.Delete(original_AccountPartyId)
            Dim AccountParties As TimeLiveDataSet.AccountPartyDataTable = Adapter.GetDataByAccountPartyId(original_AccountPartyId)
            Dim AccountParty As TimeLiveDataSet.AccountPartyRow = AccountParties.Rows(0)
            With AccountParty
                .IsDeleted = True
                .ModifiedOn = Now.Date
                .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            End With
            Dim rowsAffected As Integer = Adapter.Update(AccountParty)
            CacheManager.ClearCache("vueAccountProjectsDataTable", "", True)
            AfterUpdate()
            CacheManager.ClearCache("vueAccountEmployeeTimeEntryWithStatusDataTable", "", , True)
            CacheManager.ClearCache("vueAccountEmployeeTimeEntryWithStatusGroupedDataTable", "", , True)
            ' Return true if precisely one row was deleted, otherwise false
            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception("Can’t delete. Dependent data is exist with this record.")
        End Try
    End Function
    Public Shared Sub SetDataForProjectDropdownForCustomaizeReport(ByVal DropDownName As DropDownList, ByVal AccountReportId As Guid)
        Dim ReportPermission As New ObjectPermissionBLL
        Dim objDataView As New DataView()
        Dim ReportFiler As New ReportFilterBLL
        Dim dtvueAccountClient As dsReportFilterSource.ClientFilterDataTable

        If ReportPermission.IsReportHasPermissionOfAllowOwnApproval(AccountReportId, True) = True Then
            If LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "ad0ea79d-c1d7-40ed-a7c4-03cc4f565873" Or LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "e3803dc0-49fd-4fc8-b414-ea264ffe85aa" Then
                SetClientOwnApprovalPermission(DropDownName, AccountReportId)
                Return
            End If
        End If
        If ReportPermission.IsReportHasPermissionOfAllowAllUser(AccountReportId, True) Then
            dtvueAccountClient = ReportFiler.GetAccountClientByAccountId(DBUtilities.GetSessionAccountId)
        ElseIf ReportPermission.IsReportHasPermissionOfAllowOwnReport(AccountReportId, True) Then
            dtvueAccountClient = ReportFiler.GetAccountClientByAccountIdAndAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
        Else
            dtvueAccountClient = ReportFiler.GetAccountClientByAccountIdAndAccountEmployeeId(DBUtilities.GetSessionAccountEmployeeId)
        End If

        objDataView = dtvueAccountClient.DefaultView
        objDataView.Sort = "PartyName"
        DropDownName.DataTextField = "PartyName"
        DropDownName.DataValueField = "AccountPartyId"
        DropDownName.DataSource = objDataView
        DropDownName.DataBind()

    End Sub
    Public Shared Sub SetClientOwnApprovalPermission(ByVal DropdownName As DropDownList, ByVal AccountReportId As Guid)
        Dim ReportFiler As New ReportFilterBLL
        Dim objDataView As New DataView()
        Dim dt As New DataTable
        If LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "ad0ea79d-c1d7-40ed-a7c4-03cc4f565873" Then
            Dim dtvueApprovedBy As dsReportFilterSource.ApprovedByTimeEntryFilterDataTable
            dtvueApprovedBy = ReportFiler.GetApprovalClientByAccountId(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
            dt = dtvueApprovedBy
        ElseIf LiveReportData.GetSystemReportDataSourceIdByAccountReportId(AccountReportId) = "e3803dc0-49fd-4fc8-b414-ea264ffe85aa" Then
            Dim dtvueApprovedBy As dsReportFilterSource.ApprovedByExpenseFilterDataTable
            dtvueApprovedBy = ReportFiler.GetApprovalClientByAccountIdForExpense(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
            dt = dtvueApprovedBy
        End If
        objDataView = dt.DefaultView
        objDataView.Sort = "PartyName"
        DropdownName.DataTextField = "PartyName"
        DropdownName.DataValueField = "AccountClientId"
        DropdownName.DataSource = objDataView
        DropdownName.DataBind()
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountPartiesForTimeEntryByAccountEmployeeId(ByVal AccountEmployeeId As Integer, Optional ByVal AccountClientId As Integer = 0) As AccountClient.TimeEntryClientDataTable
        'strCacheKey = CacheManager.GetCacheKeyForAccountEmployeeData("TimeEntryClientDataTable", "GetAccountPartiesForTimeEntryByAccountEmployeeId", "AccountEmployeeId=" & AccountEmployeeId & "AccountClientId=" & AccountClientId)

        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAccountPartiesForTimeEntryByAccountEmployeeId = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        Dim _TimeEntryClientTableAdapter As New AccountClientTableAdapters.TimeEntryClientTableAdapter
        GetAccountPartiesForTimeEntryByAccountEmployeeId = _TimeEntryClientTableAdapter.GetDataByAccountEmployeeId(AccountClientId, AccountEmployeeId)
        'CacheManager.AddAccountDataInCache(GetAccountPartiesForTimeEntryByAccountEmployeeId, strCacheKey)
        'End If
        Return GetAccountPartiesForTimeEntryByAccountEmployeeId
    End Function
    Public Sub UpdateCustomFieldInClient(CustomFieldColumnName As String, ByVal AccountId As Integer)
        Adapter.UpdateClientCustomFieldByCustomFieldId(CustomFieldColumnName, AccountId)
    End Sub
    Public Function GetLastInsertedPartyId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountPartyLastId.Rows(0)
        Return a.LastId

    End Function
    Public Function HideProjectFromApplication(ByVal PartyId As Integer, ByVal PartyName As String, ByVal PartyNick As String)
        Dim AccountStatusId As Integer
        Dim AccountProjectTypeId As Integer
        Dim AccountBillingTypeId As Integer
        Dim ProjectBLL As New AccountProjectBLL
        Dim ProjectEmployeeBLL As New AccountProjectEmployeeBLL
        Dim AccountId = DBUtilities.GetSessionAccountId
        Dim AccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId

        Dim dtStatus As TimeLiveDataSet.AccountStatusDataTable = New AccountStatusBLL().GetAccountsStatusByStatusTypeId(AccountId, 3)
        Dim drStatus As TimeLiveDataSet.AccountStatusRow

        If dtStatus.Rows.Count > 0 Then
            drStatus = dtStatus.Rows(0)
            AccountStatusId = drStatus.AccountStatusId
        End If
        Dim dtProjectType As TimeLiveDataSet.AccountProjectTypeDataTable = New AccountProjectTypeBLL().GetAccountProjectTypeByAccountId(AccountId)
        Dim drProjectType As TimeLiveDataSet.AccountProjectTypeRow

        If dtProjectType.Rows.Count > 0 Then
            drProjectType = dtProjectType.Rows(0)
            AccountProjectTypeId = drProjectType.AccountProjectTypeId
        End If

        Dim dtBillingType As TimeLiveDataSet.AccountBillingTypeDataTable = New AccountBillingTypeBLL().GetAccountBillingTypesForProjectByAccountId(AccountId)
        Dim drBillingType As TimeLiveDataSet.AccountBillingTypeRow
        If dtBillingType.Rows.Count > 0 Then
            drBillingType = dtBillingType.Rows(0)
            AccountBillingTypeId = drBillingType.AccountBillingTypeId
        End If
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = New AccountProjectBLL().GetAccountProjectsByAccountId(AccountId, True)
        If dtProject.Rows.Count = 0 Then
            ProjectBLL.InsertDefaultProject(AccountId, AccountProjectTypeId, New AccountPartyBLL().GetLastInsertedPartyId, 0, 0, AccountBillingTypeId, PartyName, PartyName, Now.Date, Now.Date, AccountStatusId, AccountEmployeeId, AccountEmployeeId, 0, 0, 0, "", PartyNick, 0, 1, False, False, 0, Now.Date, AccountEmployeeId, Now.Date, AccountEmployeeId, False, "", True)
        Else
            ProjectBLL.InsertDefaultProject(AccountId, AccountProjectTypeId, New AccountPartyBLL().GetLastInsertedPartyId, 0, 0, AccountBillingTypeId, PartyName, PartyName, Now.Date, Now.Date, AccountStatusId, AccountEmployeeId, AccountEmployeeId, 0, 0, 0, "", PartyNick, 0, 1, False, False, 0, Now.Date, AccountEmployeeId, Now.Date, AccountEmployeeId, False, "", False)
        End If
        Dim ProjectMilestoneBLL As New AccountProjectMilestoneBLL
        ProjectMilestoneBLL.AddAccountProjectMilestone(AccountId, ProjectBLL.GetLastInsertedId, "Default Milestone", Now.Date, Now.Date, AccountEmployeeId, Now.Date, AccountEmployeeId, "", False, False)
        Dim dtemployee As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountId(AccountId)
        Dim dremployee As AccountEmployee.AccountEmployeeRow
        If dtemployee.Rows.Count > 0 Then
            dremployee = dtemployee.Rows(0)
            For Each dremployee In dtemployee.Rows
                ProjectEmployeeBLL.AddAccountProjectEmployee(dremployee.AccountId, ProjectBLL.GetLastInsertedId, dremployee.AccountEmployeeId, 0, 0)
            Next
        End If

    End Function

End Class
