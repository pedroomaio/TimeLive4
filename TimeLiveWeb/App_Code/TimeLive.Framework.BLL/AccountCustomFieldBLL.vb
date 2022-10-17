Imports Microsoft.VisualBasic
Imports AccountCustomFieldTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountCustomFieldBLL
    Private _AccountCustomFieldTableAdapter As AccountCustomFieldTableAdapter = Nothing
    Private _vueAccountCustomFieldManageTableAdapter As vueAccountCustomFieldManageTableAdapter = Nothing
    Private _MasterEntityTypeTableAdapter As MasterEntityTypeTableAdapter = Nothing
    Private _MasterCustomDataTypeTableAdapter As MasterCustomDataTypeTableAdapter = Nothing
    Public CacheKey As String
    Protected ReadOnly Property Adapter() As AccountCustomFieldTableAdapter
        Get
            If _AccountCustomFieldTableAdapter Is Nothing Then
                _AccountCustomFieldTableAdapter = New AccountCustomFieldTableAdapter()
            End If

            Return _AccountCustomFieldTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountCustomFieldManageTableAdapter
        Get
            If _vueAccountCustomFieldManageTableAdapter Is Nothing Then
                _vueAccountCustomFieldManageTableAdapter = New vueAccountCustomFieldManageTableAdapter()
            End If

            Return _vueAccountCustomFieldManageTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCustomFieldByAccountId(ByVal AccountId As Integer) As AccountCustomField.AccountCustomFieldDataTable
        GetAccountCustomFieldByAccountId = Adapter.GetDataByAccountId(AccountId)
        UIUtilities.FixTableForNoRecords(GetAccountCustomFieldByAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountCustomFieldByAccountIdandAccountCustomFieldId(ByVal AccountId As Integer, ByVal AccountCustomFieldId As Guid) As AccountCustomField.AccountCustomFieldDataTable
        GetAccountCustomFieldByAccountIdandAccountCustomFieldId = Adapter.GetDataByAccountIdandAccountCustomFieldId(AccountId, AccountCustomFieldId)
        Return GetAccountCustomFieldByAccountIdandAccountCustomFieldId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId(ByVal AccountId As Integer, ByVal MasterEntityTypeId As Guid) As AccountCustomField.vueAccountCustomFieldManageDataTable
        ' Creating of unique cache key by combining of parameter value and function name
        CacheKey = CacheManager.GetCacheKeyForAccountsData("vueAccountCustomFieldManageDataTable", "GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId", "AccountId=" & AccountId & "MasterEntityTypeId=" & MasterEntityTypeId.ToString)
        ' If found in cache, then return from cache collection
        If Not CacheManager.GetItemFromCache(CacheKey) Is Nothing Then
            GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId = CacheManager.GetItemFromCache(CacheKey)
        Else
            ' Otherwise simply call table adapter call to retrieve database records 
            GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId = vueAdapter.GetDataByAccountIdandMasterEntityTypeId(AccountId, MasterEntityTypeId)
            ' Store datatable in cache collection
            CacheManager.AddAccountDataInCache(GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId, CacheKey)
        End If
        Return GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountCustomFieldByAccountIdandMasterEntityTypeIdForGrid(ByVal AccountId As Integer, ByVal MasterEntityTypeId As Guid) As AccountCustomField.vueAccountCustomFieldManageDataTable
        GetvueAccountCustomFieldByAccountIdandMasterEntityTypeIdForGrid = vueAdapter.GetDataByAccountIdandMasterEntityTypeId(AccountId, MasterEntityTypeId)
        UIUtilities.FixTableForNoRecords(GetvueAccountCustomFieldByAccountIdandMasterEntityTypeIdForGrid)
        Return GetvueAccountCustomFieldByAccountIdandMasterEntityTypeIdForGrid
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountCustomFieldByAccountIdMasterEntityTypeIdandDatabaseFieldName(ByVal AccountId As Integer, ByVal MasterEntityTypeId As Guid, ByVal DatabaseFieldName As String) As AccountCustomField.vueAccountCustomFieldManageDataTable
        GetvueAccountCustomFieldByAccountIdMasterEntityTypeIdandDatabaseFieldName = vueAdapter.GetDataByAccountIdMasterEntiryTypeIdandDatabaseFieldName(AccountId, MasterEntityTypeId, DatabaseFieldName)
        Return GetvueAccountCustomFieldByAccountIdMasterEntityTypeIdandDatabaseFieldName
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetMasterEntityTypeByMasterEntityTypeId(ByVal MasterEntityTypeId As Guid) As AccountCustomField.MasterEntityTypeDataTable
        GetMasterEntityTypeByMasterEntityTypeId = _MasterEntityTypeTableAdapter.GetDataByMasterEntityTypeId(MasterEntityTypeId)
        UIUtilities.FixTableForNoRecords(GetMasterEntityTypeByMasterEntityTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetMasterEntityType() As AccountCustomField.MasterEntityTypeDataTable
        If _MasterEntityTypeTableAdapter Is Nothing Then
            _MasterEntityTypeTableAdapter = New AccountCustomFieldTableAdapters.MasterEntityTypeTableAdapter
        End If

        GetMasterEntityType = Me._MasterEntityTypeTableAdapter.GetDataByMasterEntityTypeForIsFeatures(DBUtilities.GetSessionAccountId)

        Return GetMasterEntityType

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetMasterCustomDataType() As AccountCustomField.MasterCustomDataTypeDataTable

        If _MasterCustomDataTypeTableAdapter Is Nothing Then
            _MasterCustomDataTypeTableAdapter = New AccountCustomFieldTableAdapters.MasterCustomDataTypeTableAdapter
        End If

        GetMasterCustomDataType = Me._MasterCustomDataTypeTableAdapter.GetData()

        Return GetMasterCustomDataType

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddCustomFieldManage(ByVal AccountId As Integer, ByVal MasterCustomDataTypeId As Guid, ByVal MasterEntityTypeId As Guid, ByVal DatabaseFieldName As String, _
    ByVal CustomFieldName As String, ByVal CustomFieldCaption As String, ByVal DefaultValue As String, ByVal MaximumLength As Integer, ByVal MinimumValue As Integer, _
    ByVal MaximumValue As Integer, ByVal DropDownOptions As String, ByVal IsRequired As Boolean, ByVal IsDisabled As Boolean, ByVal CreatedOn As DateTime, _
    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer) As Boolean
        Try
            _AccountCustomFieldTableAdapter = New AccountCustomFieldTableAdapter
            Dim dtAccountCustomField As New AccountCustomField.AccountCustomFieldDataTable
            Dim drAccountCustomField As AccountCustomField.AccountCustomFieldRow = dtAccountCustomField.NewAccountCustomFieldRow
            Dim AccountCustomFieldId As Guid = System.Guid.NewGuid

            With drAccountCustomField
                .AccountCustomFieldId = AccountCustomFieldId
                .AccountId = AccountId
                .MasterCustomDataTypeId = MasterCustomDataTypeId
                .MasterEntityTypeId = MasterEntityTypeId
                .DatabaseFieldName = GetDatabaseFieldName(MasterEntityTypeId, "CustomField1")
                .CustomFieldName = CustomFieldName
                .CustomFieldCaption = CustomFieldCaption
                .DefaultValue = DefaultValue
                If MaximumLength <> 0 Then
                    .MaximumLength = MaximumLength
                Else
                    .Item("MaximumLength") = System.DBNull.Value
                End If
                If MinimumValue <> 0 Then
                    .MinimumValue = MinimumValue
                Else
                    .Item("MinimumValue") = System.DBNull.Value
                End If
                If MaximumValue <> 0 Then
                    .MaximumValue = MaximumValue
                Else
                    .Item("MaximumValue") = System.DBNull.Value
                End If
                If DropDownOptions <> "" Then
                    .DropDownOptions = DropDownOptions
                Else
                    .Item("DropDownOptions") = System.DBNull.Value
                End If
                .IsRequired = IsRequired
                .IsDisabled = IsDisabled
                .CreatedOn = Now
                .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
                .ModifiedOn = Now
                .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            End With
            dtAccountCustomField.AddAccountCustomFieldRow(drAccountCustomField)
            ' Add the new product
            Dim rowsAffected As Integer = Adapter.Update(dtAccountCustomField)
            AfterUpdate()
            ' Return true if precisely one row was inserted, otherwise false
            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountCustomField(ByVal Original_AccountCustomFieldId As Guid, DatabaseFieldName As String, ByVal MasterEntityTypeId As Guid) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountCustomFieldId)

        If MasterEntityTypeId.ToString = "13dbff37-a092-4ae2-a919-775cbed0edc0" Then
            Call New AccountProjectBLL().UpdateCustomFieldInProject(DatabaseFieldName, DBUtilities.GetSessionAccountId)
        ElseIf MasterEntityTypeId.ToString = "e448aed9-eab5-4cf7-a171-2a86be2bba9e" Then
            Call New AccountPartyBLL().UpdateCustomFieldInClient(DatabaseFieldName, DBUtilities.GetSessionAccountId)
        ElseIf MasterEntityTypeId.ToString = "369ed0fb-d317-4244-9f20-b7d834521e2b" Then
            Call New AccountEmployeeTimeEntryBLL().UpdateCustomFieldInTimeEntry(DatabaseFieldName, DBUtilities.GetSessionAccountId)
        ElseIf MasterEntityTypeId.ToString = "3601ae9b-3f82-4c80-9574-751f9a124fa8" Then
            Call New AccountEmployeeBLL().UpdateCustomFieldInEmployee(DatabaseFieldName, DBUtilities.GetSessionAccountId)
        End If
        AfterUpdate()
        Return rowsAffected = 1
    End Function
    'Public Function GetLastInsertedId() As Guid
    '    'Dim a As TimeLiveDataSet.IdentityQueryRow
    '    'Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
    '    'a = ad.GetAccountTimeExpenseBillingLastId.Rows(0)
    '    'Return a.LastId
    '    Return System.Web.HttpContext.Current.Session("AccountHolidayTypeId")
    'End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateCustomFieldManage(ByVal Original_AccountCustomFieldId As Guid, ByVal AccountId As Integer, ByVal MasterCustomDataTypeId As Guid, ByVal MasterEntityTypeId As Guid, ByVal DatabaseFieldName As String, _
    ByVal CustomFieldName As String, ByVal CustomFieldCaption As String, ByVal DefaultValue As String, ByVal MaximumLength As Integer, ByVal MinimumValue As Integer, _
    ByVal MaximumValue As Integer, ByVal DropDownOptions As String, ByVal IsRequired As Boolean, ByVal IsDisabled As Boolean, ByVal CreatedOn As DateTime, _
    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer) As Boolean
        Try
            ' Update the product record
            Dim dtAccountCustomField As AccountCustomField.AccountCustomFieldDataTable = Adapter.GetDataByAccountIdandAccountCustomFieldId(AccountId, Original_AccountCustomFieldId)
            Dim drAccountCustomField As AccountCustomField.AccountCustomFieldRow = dtAccountCustomField.Rows(0)

            With drAccountCustomField
                .AccountCustomFieldId = Original_AccountCustomFieldId
                .AccountId = AccountId
                .MasterCustomDataTypeId = MasterCustomDataTypeId
                .MasterEntityTypeId = MasterEntityTypeId
                .CustomFieldName = CustomFieldName
                .CustomFieldCaption = CustomFieldCaption
                .DefaultValue = DefaultValue
                If MaximumLength <> 0 Then
                    .MaximumLength = MaximumLength
                Else
                    .Item("MaximumLength") = System.DBNull.Value
                End If
                If MinimumValue <> 0 Then
                    .MinimumValue = MinimumValue
                Else
                    .Item("MinimumValue") = System.DBNull.Value
                End If
                If MaximumValue <> 0 Then
                    .MaximumValue = MaximumValue
                Else
                    .Item("MaximumValue") = System.DBNull.Value
                End If
                If DropDownOptions <> "" Then
                    .DropDownOptions = DropDownOptions
                Else
                    .Item("DropDownOptions") = System.DBNull.Value
                End If
                .IsRequired = IsRequired
                .IsDisabled = IsDisabled
                .CreatedOn = Now
                .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
                .ModifiedOn = Now
                .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            End With
            Dim rowsAffected As Integer = Adapter.Update(dtAccountCustomField)
            AfterUpdate()
            ' Return true if precisely one row was updated, otherwise false
            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function GetDatabaseFieldName(ByVal MasterEntityTypeId As Guid, ByVal DatabaseFieldName As String)
        '    Dim AccountTimeExpenseBillingTimesheetDatatable As AccountTimeExpenseBilling.AccountTimeExpenseBillingTimesheetDataTable
        Dim RValue As String
        If MasterEntityTypeId.ToString = "369ed0fb-d317-4244-9f20-b7d834521e2b" Then
            For n As Integer = 1 To 9
                Dim dtAccountCustomField As AccountCustomField.AccountCustomFieldDataTable = Adapter.GetDataByAccountIdandMasterEntityTypeId(DBUtilities.GetSessionAccountId, MasterEntityTypeId, DatabaseFieldName)
                If dtAccountCustomField.Rows.Count > 0 Then
                    DatabaseFieldName = "CustomField" & n + 1
                Else
                    Return DatabaseFieldName
                End If
            Next
        Else
            For n As Integer = 1 To 15
                Dim dtAccountCustomField As AccountCustomField.AccountCustomFieldDataTable = Adapter.GetDataByAccountIdandMasterEntityTypeId(DBUtilities.GetSessionAccountId, MasterEntityTypeId, DatabaseFieldName)
                If dtAccountCustomField.Rows.Count > 0 Then
                    DatabaseFieldName = "CustomField" & n + 1
                Else
                    Return DatabaseFieldName
                End If
            Next
        End If
        Return ""
    End Function
    Public Function GetCustomCellValueForFormView(objFormView As FormView, DatabaseFieldName As String) As Object
        Dim UIObject As Object = objFormView.FindControl(DatabaseFieldName)
        If UIObject Is Nothing Then
            Return Nothing
        End If
        If TypeOf UIObject Is DropDownList Then
            Return UIObject.SelectedValue
        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
            Return UIObject.SelectedDate.ToString
        Else
            Return UIObject.Text()
        End If
    End Function
    Public Function SetCustomCellValue(objFormView As FormView, DatabaseFieldName As String, ColumnValue As Object) As Object
        Dim UIObject As Object = objFormView.FindControl(DatabaseFieldName)
        If UIObject Is Nothing Or IsDBNull(ColumnValue) Then
            Return Nothing
        End If
        If TypeOf UIObject Is DropDownList Then
            UIObject.SelectedValue = ColumnValue
        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
            Dim ReplaceDate = Replace(ColumnValue, "?", "")
            Dim ResultDate As DateTime
            DateTime.TryParse(ReplaceDate, ResultDate)
            UIObject.SelectedDate = ResultDate
            '''UIObject.SelectedDate = Replace(ColumnValue, "?", "")
        Else
            UIObject.Text = ColumnValue
        End If
    End Function
    Public Shared Sub SetCustomValuesForFormView_Inserting(objFormView As FormView, e As System.Web.UI.WebControls.FormViewInsertEventArgs, ByVal MasterEntityTypeId As Guid, ByVal CustomField As String)
        Dim CustomBLL As New AccountCustomFieldBLL
        If MasterEntityTypeId.ToString <> "369ed0fb-d317-4244-9f20-b7d834521e2b" Then
            If CheckIsRequiredCustomField(CustomField, MasterEntityTypeId) = True Then
                If Not CustomBLL.CheckValidationOnDropdown(objFormView, CustomField) Then
                    e.Cancel = True
                    Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                    'Throw New Exception("Please Select")
                    'UIUtilities.ShowMessage("Please Select", CurrentPage)
                    Exit Sub
                End If
            End If
        End If
        e.Values(CustomField) = CustomBLL.GetCustomCellValueForFormView(objFormView, CustomField)
    End Sub
    Public Shared Sub SetCustomValuesForFormView_Updating(objFormView As FormView, e As System.Web.UI.WebControls.FormViewUpdateEventArgs, ByVal MasterEntityTypeId As Guid, ByVal CustomField As String)
        Dim CustomBLL As New AccountCustomFieldBLL
        If MasterEntityTypeId.ToString <> "369ed0fb-d317-4244-9f20-b7d834521e2b" Then
            If CheckIsRequiredCustomField(CustomField, MasterEntityTypeId) = True Then
                If Not CustomBLL.CheckValidationOnDropdown(objFormView, CustomField) Then
                    e.Cancel = True
                    Dim CurrentPage As Page = System.Web.HttpContext.Current.CurrentHandler
                    'Throw New Exception("Please Select")
                    Exit Sub
                    'UIUtilities.ShowMessage("Please Select", CurrentPage)
                End If
            End If
        End If
        e.NewValues(CustomField) = CustomBLL.GetCustomCellValueForFormView(objFormView, CustomField)
    End Sub
    Public Function CheckValidationOnDropdown(objFormView As FormView, DatabaseFieldName As String)
        Dim UIObject As Object = objFormView.FindControl(DatabaseFieldName)
        If UIObject Is Nothing Then
            Return True
        End If
        If TypeOf UIObject Is DropDownList Then
            If UIObject.SelectedValue() = "None" Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Public Shared Sub SetCustomValuesForFormView_DataBound(objFormView As FormView)
        Dim CustomBLL As New AccountCustomFieldBLL
        For n As Integer = 1 To 15
            If Not objFormView.DataItem Is Nothing Then
                CustomBLL.SetCustomCellValue(objFormView, "CustomField" & n, objFormView.DataItem("CustomField" & n))
            End If
        Next
    End Sub
    Public Shared Sub CreateCustomFieldOnFormView_ItemCreated(objFormView As FormView, MasterEntityTypeId As Guid, Optional ByVal CaptionSpecifiedWidth As String = "30%", Optional ByVal ControlsSpecifiedWidth As String = "70%", Optional ByVal SpecifiedHeight As String = "", Optional ByVal ValidationGroup As String = "", Optional ByVal IsModalPopup As Boolean = False)
        Dim CustomControlsBLL As New AspNetCustomControlsBLL
        If objFormView.CurrentMode = FormViewMode.Insert Then
            If Not objFormView.FindControl("CustomTable") Is Nothing Then
                CustomControlsBLL.AddCustomFields(CType(objFormView.FindControl("CustomTable"), Table), MasterEntityTypeId, CaptionSpecifiedWidth, ControlsSpecifiedWidth, SpecifiedHeight, ValidationGroup, IsModalPopup)
            End If
        End If
        If objFormView.CurrentMode = FormViewMode.Edit Then
            If Not objFormView.FindControl("CustomTableEdit") Is Nothing Then
                CustomControlsBLL.AddCustomFields(CType(objFormView.FindControl("CustomTableEdit"), Table), MasterEntityTypeId, CaptionSpecifiedWidth, ControlsSpecifiedWidth, SpecifiedHeight, ValidationGroup)
            End If
        End If
    End Sub
    Public Shared Sub CreateCustomField_ItemCreated(ByVal CustomTable As Table, MasterEntityTypeId As Guid, Optional ByVal CaptionSpecifiedWidth As String = "30%", Optional ByVal ControlsSpecifiedWidth As String = "70%", Optional ByVal SpecifiedHeight As String = "", Optional ByVal ValidationGroup As String = "")
        Dim CustomControlsBLL As New AspNetCustomControlsBLL
        If Not CustomTable Is Nothing Then
            CustomControlsBLL.AddCustomFields(CustomTable, MasterEntityTypeId, CaptionSpecifiedWidth, ControlsSpecifiedWidth, SpecifiedHeight, ValidationGroup)
        End If
    End Sub
    Public Sub AfterUpdate()
        CacheManager.ClearCache("vueAccountCustomFieldManageDataTable", , True)
    End Sub
    Public Shared Function CheckIsRequiredCustomField(DatabaseFieldName As String, MasterEntityTypeId As Guid)

        Dim bll As New AccountCustomFieldBLL
        Dim dtCustomField As AccountCustomField.vueAccountCustomFieldManageDataTable = bll.GetvueAccountCustomFieldByAccountIdMasterEntityTypeIdandDatabaseFieldName(DBUtilities.GetSessionAccountId, MasterEntityTypeId, DatabaseFieldName)
        '= vueAdapter.GetDataByAccountIdMasterEntiryTypeIdandDatabaseFieldName(DBUtilities.GetSessionAccountId, MasterEntityTypeId, DatabaseFieldName)
        Dim drCustomField As AccountCustomField.vueAccountCustomFieldManageRow

        If dtCustomField.Rows.Count > 0 Then
            drCustomField = dtCustomField.Rows(0)
            If drCustomField.IsRequired = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Shared Function GetCustomFieldCaption(DatabaseFieldName As String, MasterEntityTypeId As Guid)

        Dim bll As New AccountCustomFieldBLL
        Dim dtCustomField As AccountCustomField.vueAccountCustomFieldManageDataTable = bll.GetvueAccountCustomFieldByAccountIdMasterEntityTypeIdandDatabaseFieldName(DBUtilities.GetSessionAccountId, MasterEntityTypeId, DatabaseFieldName)
        '= vueAdapter.GetDataByAccountIdMasterEntiryTypeIdandDatabaseFieldName(DBUtilities.GetSessionAccountId, MasterEntityTypeId, DatabaseFieldName)
        Dim drCustomField As AccountCustomField.vueAccountCustomFieldManageRow

        If dtCustomField.Rows.Count > 0 Then
            drCustomField = dtCustomField.Rows(0)
            Return drCustomField.CustomFieldCaption
        End If
    End Function
End Class
