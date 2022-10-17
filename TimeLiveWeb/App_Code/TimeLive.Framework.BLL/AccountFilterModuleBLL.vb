Imports Microsoft.VisualBasic
Imports AccountFilterModuleTableAdapters
Public Class AccountFilterModuleBLL
    Private _AccountFilterModuleTableAdapter As AccountFilterModuleTableAdapter = Nothing
    Private _vueAccountFilterModuleTableAdapter As vueAccountFilterModuleTableAdapter = Nothing
    Private _SystemFilterModuleFieldTableAdapter As SystemFilterModuleFieldTableAdapter = Nothing
    Private _SystemFilterModuleTableAdapter As SystemFilterModuleTableAdapter = Nothing
    Private _vueSystemFilterModuleTableAdapter As vueSystemFilterModuleTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As AccountFilterModuleTableAdapter
        Get
            If _AccountFilterModuleTableAdapter Is Nothing Then
                _AccountFilterModuleTableAdapter = New AccountFilterModuleTableAdapter()
            End If

            Return _AccountFilterModuleTableAdapter
        End Get
    End Property
    Protected ReadOnly Property ViewAdapter() As vueAccountFilterModuleTableAdapter
        Get
            If _vueAccountFilterModuleTableAdapter Is Nothing Then
                _vueAccountFilterModuleTableAdapter = New vueAccountFilterModuleTableAdapter()
            End If

            Return _vueAccountFilterModuleTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SystemFieldAdapter() As SystemFilterModuleFieldTableAdapter
        Get
            If _SystemFilterModuleFieldTableAdapter Is Nothing Then
                _SystemFilterModuleFieldTableAdapter = New SystemFilterModuleFieldTableAdapter()
            End If

            Return _SystemFilterModuleFieldTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SystemModuleAdapter() As SystemFilterModuleTableAdapter
        Get
            If _SystemFilterModuleTableAdapter Is Nothing Then
                _SystemFilterModuleTableAdapter = New SystemFilterModuleTableAdapter()
            End If

            Return _SystemFilterModuleTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SystemModuleandFieldAdapter() As vueSystemFilterModuleTableAdapter
        Get
            If _vueSystemFilterModuleTableAdapter Is Nothing Then
                _vueSystemFilterModuleTableAdapter = New vueSystemFilterModuleTableAdapter()
            End If

            Return _vueSystemFilterModuleTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataBySystemFilterModuleId(ByVal SystemFilterModuleId As Guid) As AccountFilterModule.vueSystemFilterModuleDataTable
        Return SystemModuleandFieldAdapter.GetDataBySystemFilterModuleId(SystemFilterModuleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetEmployeeFilters(ByVal AccountFilterModuleId As System.Guid, ByVal SystemFilterModuleFieldId As System.Guid, ByVal AccountEmployeeId As Integer) As AccountFilterModule.vueAccountFilterModuleDataTable
        Return ViewAdapter.GetDataByAccountFilterModuleIdandAccountFilterModuleFiledIdandAccountEmployeeId(AccountFilterModuleId, SystemFilterModuleFieldId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataBySystemFilterModuleFieldName(ByVal SystemFilterModuleFieldName As String) As AccountFilterModule.vueAccountFilterModuleDataTable
        Return ViewAdapter.GetDataBySystemFilterModuleFieldName(SystemFilterModuleFieldName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountFilterModuleText(ByVal SystemFilterModuleId As System.Guid, ByVal SystemFilterModuleFieldId As System.Guid, ByVal AccountEmployeeId As Integer, ByVal AccountFilterModuleText As String) As AccountFilterModule.vueAccountFilterModuleDataTable
        Return ViewAdapter.GetDataBModuleIdandModuleFieldIdandAccountEmployeeIdandAccountFilterModuleText(SystemFilterModuleId, SystemFilterModuleFieldId, AccountEmployeeId, AccountFilterModuleText)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetFiltersBySystemFilterModuleIdandAccountEmployeeIdForReset(ByVal SystemFilterModuleId As Guid, ByVal AccountEmployeeId As Integer) As AccountFilterModule.vueAccountFilterModuleDataTable
        Return ViewAdapter.GetDataBySystemFilterModuleIdAndAccountEmployeeIdForReset(SystemFilterModuleId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetFiltersBySystemFilterModuleIdandAccountEmployeeIdAndAccountFilterModuleNameIsNull(ByVal SystemFilterModuleId As Guid, ByVal AccountEmployeeId As Integer) As AccountFilterModule.vueAccountFilterModuleDataTable
        Return ViewAdapter.GetDataForDisplayFilters(SystemFilterModuleId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetFiltersBySystemFilterModuleIdandAccountEmployeeId(ByVal SystemFilterModuleId As Guid, ByVal AccountEmployeeId As Integer) As AccountFilterModule.vueAccountFilterModuleDataTable
        Return ViewAdapter.GetvueDataByBySystemFilterModuleIdandAccountEmployeeId(SystemFilterModuleId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetFilterRecord(ByVal SystemFilterModuleId As Guid, ByVal SystemFilterModuleFieldName As String, ByVal AccountEmployeeId As Integer) As AccountFilterModule.vueAccountFilterModuleDataTable
        Return ViewAdapter.GetDataBySystemFilterModuleIdandSystemFilterModuleFieldName(SystemFilterModuleId, SystemFilterModuleFieldName, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemFilterModuleFieldIdForReset(ByVal SystemFilterModuleId As System.Guid, ByVal SystemFilterModuleFieldName As String) As AccountFilterModule.SystemFilterModuleFieldDataTable
        Return SystemFieldAdapter.GetDataBySystemFilterModuleIdAndSystemFilterModuleFieldNameForReset(SystemFilterModuleId, SystemFilterModuleFieldName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemFilterModuleFieldId(ByVal SystemFilterModuleId As System.Guid, ByVal SystemFilterModuleFieldName As String, ByVal IsGridViewFilter As Boolean) As AccountFilterModule.SystemFilterModuleFieldDataTable
        Return SystemFieldAdapter.GetDatabySystemFilterModuleIdandSystemFilterModuleFieldName(SystemFilterModuleId, SystemFilterModuleFieldName, IsGridViewFilter)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemFilterModuleId(ByVal SystemFilterModuleName As String) As AccountFilterModule.SystemFilterModuleDataTable
        Return SystemModuleAdapter.GetDataBySystemFilterModuleName(SystemFilterModuleName)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemFilterModuleName(ByVal SystemFilterModuleId As System.Guid) As AccountFilterModule.SystemFilterModuleDataTable
        Return SystemModuleAdapter.GetDataBySystemFilterModuleId(SystemFilterModuleId)
    End Function
    Public Function GetLastFilters(ByVal SystemFilterModuleId As Guid, ByVal SystemFilterModuleFieldId As Guid, ByVal AccountFilterModuleName As String) As String
        Dim m_AccountFilterModuleName As String
        Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetEmployeeFilters(SystemFilterModuleId, SystemFilterModuleFieldId, DBUtilities.GetSessionAccountEmployeeId)
        Dim dr As AccountFilterModule.vueAccountFilterModuleRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If Not IsDBNull(dr.Item("AccountFilterModuleName")) Then
                m_AccountFilterModuleName = dr.Item("AccountFilterModuleName")
            End If
        End If
        Return m_AccountFilterModuleName
    End Function
    Public Shared Function GetPage(ByVal objPage As Page) As String
        Dim ThisPage As String = objPage.AppRelativeVirtualPath
        Dim SlashPos As Integer = InStrRev(ThisPage, "/")
        Dim PageName As String = Right(ThisPage, Len(ThisPage) - SlashPos)
        Dim ThisFolder As String = objPage.AppRelativeTemplateSourceDirectory
        Dim SlashPos1 As String = Right(ThisFolder, Len(ThisFolder) - 2)
        Dim FolderName As String = Left(SlashPos1, Len(SlashPos1) - 1)
        Return PageName
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddSystemFilterModule( _
                       ByVal SystemFilterModuleName As String) As Guid
        _SystemFilterModuleTableAdapter = New SystemFilterModuleTableAdapter
        Dim dtSystemModule As New AccountFilterModule.SystemFilterModuleDataTable
        Dim drSystemModule As AccountFilterModule.SystemFilterModuleRow = dtSystemModule.NewSystemFilterModuleRow
        Dim nSystemFilterModuleId As Guid = System.Guid.NewGuid
        With drSystemModule
            .SystemFilterModuleId = nSystemFilterModuleId
            .SystemFilterModuleName = SystemFilterModuleName
        End With
        dtSystemModule.AddSystemFilterModuleRow(drSystemModule)
        Dim rowsAffected As Integer = SystemModuleAdapter.Update(dtSystemModule)
        Return nSystemFilterModuleId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddSystemFilterModuleFileld( _
                        ByVal SystemFilterModuleId As System.Guid, ByVal SystemFilterModuleFieldName As String, ByVal IsGridViewFilter As Boolean, ByVal SystemFilterModuleFieldCaption As String) As Guid
        _SystemFilterModuleFieldTableAdapter = New SystemFilterModuleFieldTableAdapter
        Dim dtSystemFilter As New AccountFilterModule.SystemFilterModuleFieldDataTable
        Dim drSystemFilter As AccountFilterModule.SystemFilterModuleFieldRow = dtSystemFilter.NewSystemFilterModuleFieldRow
        Dim nSystemFilterModuleFieldId As Guid = System.Guid.NewGuid
        With drSystemFilter
            .SystemFilterModuleFieldId = nSystemFilterModuleFieldId
            .SystemFilterModuleId = SystemFilterModuleId
            .SystemFilterModuleFieldName = SystemFilterModuleFieldName
            .IsGridViewFilter = IsGridViewFilter
            .SystemFilterModuleFieldCaption = SystemFilterModuleFieldCaption
        End With
        dtSystemFilter.AddSystemFilterModuleFieldRow(drSystemFilter)
        Dim rowsAffected As Integer = SystemFieldAdapter.Update(dtSystemFilter)
        Return nSystemFilterModuleFieldId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddFilterModule( _
                        ByVal SystemFilterModuleId As System.Guid, ByVal SystemFilterModuleFieldId As System.Guid, ByVal AccountId As Integer, _
                        ByVal AccountEmployeeId As Integer, ByVal AccountFilterModuleName As String, ByVal AccountFilterModuleText As String, ByVal CreatedOn As DateTime, _
                        ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, Optional AccountFilterModuleDefaultName As String = "") As Boolean
        _AccountFilterModuleTableAdapter = New AccountFilterModuleTableAdapter

        Dim dtFilter As New AccountFilterModule.AccountFilterModuleDataTable
        Dim drFilter As AccountFilterModule.AccountFilterModuleRow = dtFilter.NewAccountFilterModuleRow
        With drFilter
            .AccountFilterModuleId = System.Guid.NewGuid
            .SystemFilterModuleId = SystemFilterModuleId
            .SystemFilterModuleFieldId = SystemFilterModuleFieldId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .AccountFilterModuleName = AccountFilterModuleName
            .AccountFilterModuleText = AccountFilterModuleText
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .AccountFilterModuleDefaultName = AccountFilterModuleDefaultName
        End With
        dtFilter.AddAccountFilterModuleRow(drFilter)
        Dim rowsAffected As Integer = Adapter.Update(dtFilter)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateFilterModule(ByVal Original_AccountFilterModuleId As System.Guid, _
                        ByVal SystemFilterModuleId As System.Guid, ByVal SystemFilterModuleFieldId As System.Guid, ByVal AccountId As Integer, _
                        ByVal AccountEmployeeId As Integer, ByVal AccountFilterModuleName As String, ByVal AccountFilterModuleText As String, ByVal CreatedOn As DateTime, _
                        ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, Optional AccountFilterModuleDefaultName As String = "") As Boolean

        Dim dtFilter As AccountFilterModule.AccountFilterModuleDataTable = Adapter.GetDataByAccountFilterModuleId(Original_AccountFilterModuleId)
        Dim drFilter As AccountFilterModule.AccountFilterModuleRow = dtFilter.Rows(0)
        With drFilter
            .SystemFilterModuleId = SystemFilterModuleId
            .SystemFilterModuleFieldId = SystemFilterModuleFieldId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .AccountFilterModuleName = AccountFilterModuleName
            .AccountFilterModuleText = AccountFilterModuleText
            .CreatedOn = Now
            .CreatedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = DBUtilities.GetSessionAccountEmployeeId
            .AccountFilterModuleDefaultName = AccountFilterModuleDefaultName
        End With
        Dim rowsAffected As Integer = Adapter.Update(drFilter)
        Return rowsAffected = 1
    End Function
    Public Sub InsertFilters(ByVal SystemFilterModuleFieldName As String, ByVal AccountFilterModuleName As String, ByVal AccountFilterModuleText As String, ByVal m_SystemFilterModuleFieldId As Guid, ByVal IsGridViewFilter As Boolean, Page As Page, ByVal CurrentPage As control, Optional AccountFilterModuleDefaultName As String = "")
        Dim PageName As String = GetPage(Page)
        Dim SystemFilterModuleId As Guid = InsertSystemModule(Page)
        Dim SystemFilterModuleName As String = GetSystemModule(SystemFilterModuleId)
        If PageName = SystemFilterModuleName Then
            Dim SystemFilterModuleFieldId As Guid = GetSystemFilterModuleField(SystemFilterModuleId, SystemFilterModuleFieldName, IsGridViewFilter)
            Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetEmployeeFilters(SystemFilterModuleId, SystemFilterModuleFieldId, DBUtilities.GetSessionAccountEmployeeId)
            Dim dr As AccountFilterModule.vueAccountFilterModuleRow
            If dt.Rows.Count = 0 Then
                Dim InsertSystemFilterModuleFileld As Guid = m_SystemFilterModuleFieldId
                AddFilterModule(SystemFilterModuleId, InsertSystemFilterModuleFileld, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AccountFilterModuleName, AccountFilterModuleText, Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId, AccountFilterModuleDefaultName)
            Else
                UpdateFilters(SystemFilterModuleFieldId, AccountFilterModuleName, AccountFilterModuleText, IsGridViewFilter, Page, CurrentPage, "")
            End If
        End If
    End Sub
    Public Sub UpdateFilters(ByVal SystemFilterModuleFieldId As Guid, ByVal AccountFilterModuleName As String, ByVal AccountFilterModuleText As String, ByVal IsGridViewFilter As Boolean, Page As Page, ByVal CurrentPage As control, Optional AccountFilterModuleDefaultName As String = "")
        Dim PageName As String = GetPage(Page)
        Dim SystemFilterModuleId As Guid = InsertSystemModule(Page)
        Dim SystemFilterModuleName As String = GetSystemModule(SystemFilterModuleId)
        If PageName = SystemFilterModuleName Then
            'Dim SystemFilterModuleFieldId As Guid = GetSystemFilterModuleField(SystemFilterModuleId, SystemFilterModuleFieldName, IsGridViewFilter)
            Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetEmployeeFilters(SystemFilterModuleId, SystemFilterModuleFieldId, DBUtilities.GetSessionAccountEmployeeId)
            Dim dr As AccountFilterModule.vueAccountFilterModuleRow
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)
                If (dr.Item("IsGridViewFilter")) = False Then
                    UpdateFilterModule(dr.Item("AccountFilterModuleId"), SystemFilterModuleId, dr.Item("SystemFilterModuleFieldId"), DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AccountFilterModuleName, AccountFilterModuleText, Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId, dr.Item("AccountFilterModuleDefaultName"))
                Else
                    UpdateFilterModule(dr.Item("AccountFilterModuleId"), SystemFilterModuleId, dr.Item("SystemFilterModuleFieldId"), DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AccountFilterModuleName, AccountFilterModuleText, Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId, "")
                End If
            End If
        End If

    End Sub
    Public Function InsertSystemModule(objPage As Page) As Object
        Dim PageName As String = GetPage(objPage)
        Dim SystemFilterModuleName As String = PageName
        Dim SystemFilterModuleId As Guid
        Dim dtSystemModule As AccountFilterModule.SystemFilterModuleDataTable = New AccountFilterModuleBLL().GetSystemFilterModuleId(SystemFilterModuleName)
        Dim drSystemModule As AccountFilterModule.SystemFilterModuleRow
        If dtSystemModule.Rows.Count > 0 Then
            drSystemModule = dtSystemModule.Rows(0)
            If Not IsDBNull(drSystemModule.Item("SystemFilterModuleName")) Then
                SystemFilterModuleId = drSystemModule.Item("SystemFilterModuleId")
            End If
            'Else
            '    SystemFilterModuleId = AddSystemFilterModule(SystemFilterModuleName)
        End If
        Return SystemFilterModuleId

    End Function
    Public Function GetSystemFilterModuleField(ByVal SystemFilterModuleId As Guid, ByVal SystemFilterModuleFieldName As String, ByVal IsGridViewFilter As Boolean) As Object
        Dim SystemFilterModuleFieldId As Guid
        Dim dtSystemFiled As AccountFilterModule.SystemFilterModuleFieldDataTable = New AccountFilterModuleBLL().GetSystemFilterModuleFieldId(SystemFilterModuleId, SystemFilterModuleFieldName, IsGridViewFilter)
        Dim drSystemFiled As AccountFilterModule.SystemFilterModuleFieldRow
        If dtSystemFiled.Rows.Count > 0 Then
            drSystemFiled = dtSystemFiled.Rows(0)
            If Not IsDBNull(drSystemFiled.Item("SystemFilterModuleFieldName")) Then
                SystemFilterModuleFieldId = drSystemFiled.Item("SystemFilterModuleFieldId")
            End If
        End If
        Return SystemFilterModuleFieldId
    End Function
    Public Function InsertSystemFilterModuleField(ByVal SystemFilterModuleId As Guid, ByVal SystemFilterModuleFieldName As String, ByVal IsGridViewFilter As Boolean, ByVal SystemFilterModuleFieldCaption As String) As Object
        Dim SystemFilterModuleFieldId As Guid
        Dim dtSystemFiled As AccountFilterModule.SystemFilterModuleFieldDataTable = New AccountFilterModuleBLL().GetSystemFilterModuleFieldId(SystemFilterModuleId, SystemFilterModuleFieldName, IsGridViewFilter)
        Dim drSystemFiled As AccountFilterModule.SystemFilterModuleFieldRow
        If dtSystemFiled.Rows.Count = 0 Then
            'drSystemFiled = dtSystemFiled.Rows(0)
            SystemFilterModuleFieldId = AddSystemFilterModuleFileld(SystemFilterModuleId, SystemFilterModuleFieldName, IsGridViewFilter, SystemFilterModuleFieldCaption)
        End If

    End Function
    Public Function GetSystemModule(ByVal SystemFilterModuleId As Guid) As Object
        Dim SystemFilterModuleName As String
        Dim dtSystemModule As AccountFilterModule.SystemFilterModuleDataTable = New AccountFilterModuleBLL().GetSystemFilterModuleName(SystemFilterModuleId)
        Dim drSystemModule As AccountFilterModule.SystemFilterModuleRow
        If dtSystemModule.Rows.Count > 0 Then
            drSystemModule = dtSystemModule.Rows(0)
            If Not IsDBNull(drSystemModule.Item("SystemFilterModuleName")) Then
                SystemFilterModuleName = drSystemModule.Item("SystemFilterModuleName")
                Return SystemFilterModuleName
            End If
        End If
    End Function
    Public Function InsertFilterModuleForNonGridViewObject(ByVal CurrentPage As Control, ByVal objPage As Page) As Object
        Dim SystemFilterModuleId As Guid = InsertSystemModule(objPage)
        Dim dt As AccountFilterModule.vueSystemFilterModuleDataTable = New AccountFilterModuleBLL().GetDataBySystemFilterModuleId(SystemFilterModuleId)
        Dim dr As AccountFilterModule.vueSystemFilterModuleRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If Not (CurrentPage.FindControl(dr.SystemFilterModuleFieldName)) Is Nothing Then
                    Dim AccountFilterModuleDefaultName As Object = GetValues(CurrentPage, dr.SystemFilterModuleFieldName)
                    Dim AccountFilterModuleName As Object
                    AccountFilterModuleName = GetValues(CurrentPage, dr.SystemFilterModuleFieldName)
                    Dim AccountFilterModuleText As Object = GetTextValues(CurrentPage, dr.SystemFilterModuleFieldName)
                    Dim SystemFilterModuleFieldId As Object = GetSystemFilterModuleField(SystemFilterModuleId, dr.SystemFilterModuleFieldName, False)
                    InsertFilters(dr.SystemFilterModuleFieldName, AccountFilterModuleName, AccountFilterModuleText, SystemFilterModuleFieldId, False, objPage, CurrentPage, AccountFilterModuleDefaultName)
                End If
            Next
        End If
    End Function
    Public Function GetFilterModuleForNonGridViewObject(ByVal CurrentPage As Control, ByVal objPage As Page) As Object
        Dim SystemFilterModuleId As Guid = InsertSystemModule(objPage)
        Dim page As ControlCollection = CurrentPage.Controls
        Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetFiltersBySystemFilterModuleIdandAccountEmployeeId(SystemFilterModuleId, DBUtilities.GetSessionAccountEmployeeId)
        Dim dr As AccountFilterModule.vueAccountFilterModuleRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If Not (CurrentPage.FindControl(dr.SystemFilterModuleFieldName)) Is Nothing Then
                    Dim ColumnValue As Object = ""
                    Dim DDLTextValue As Object = ""
                    If Not IsDBNull(dr.Item("AccountFilterModuleName")) Then
                        ColumnValue = dr.AccountFilterModuleName
                        If Not IsDBNull(dr.Item("AccountFilterModuleDefaultName")) Then
                            DDLTextValue = dr.AccountFilterModuleDefaultName
                        End If
                    End If
                    SetValues(objPage, CurrentPage, dr.SystemFilterModuleFieldName, ColumnValue)
                End If
            Next
        End If
    End Function
    Public Function SetValues(objPage As Page, CurrentPage As Object, DatabaseFieldName As String, ColumnValue As Object) As Object
        Dim UIObject As Object = CurrentPage.FindControl(DatabaseFieldName)
        If UIObject Is Nothing Then
            Return Nothing
        End If
        If TypeOf UIObject Is DropDownList Then
            If DatabaseFieldName = "ddlAccountProjectMilestoneId" Then
                System.Web.HttpContext.Current.Session.Add("MilestoneID", ColumnValue)
            End If
            If DatabaseFieldName = "ddlProjectTasks" Then
                System.Web.HttpContext.Current.Session.Add("ProjectTaskID", ColumnValue)
            End If
            UIObject.SelectedValue = CheckDropDownValues(CurrentPage, objPage, DatabaseFieldName)
        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
            Dim ReplaceDate = Replace(ColumnValue, "?", "")
            Dim ResultDate As DateTime
            DateTime.TryParse(ReplaceDate, ResultDate)
            UIObject.SelectedDate = ResultDate
        ElseIf TypeOf UIObject Is CheckBox Then
            UIObject.Checked = ColumnValue
        Else
            UIObject.Text = ColumnValue
        End If
    End Function
    Public Function GetValues(CurrentPage As Object, DatabaseFieldName As Object) As Object
        Dim UIObject As Object = CurrentPage.FindControl(DatabaseFieldName)
        If UIObject Is Nothing Then
            Return Nothing
        End If
        If TypeOf UIObject Is DropDownList Then
            Return UIObject.SelectedValue
        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
            Return UIObject.PostedDate.ToString
        ElseIf TypeOf UIObject Is CheckBox Then
            Return UIObject.Checked
        Else
            Return UIObject.Text()
        End If
    End Function
    Public Function GetDefaultValues(CurrentPage As Object, DatabaseFieldName As Object) As Object
        Dim UIObject As Object = CurrentPage.FindControl(DatabaseFieldName)
        If UIObject Is Nothing Then
            Return Nothing
        End If
        If TypeOf UIObject Is DropDownList Then
            Return UIObject.SelectedValue
        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
            Return ""
        ElseIf TypeOf UIObject Is CheckBox Then
            Return UIObject.Checked
        Else
            Return UIObject.Text()
        End If
    End Function
    Public Function InsertFilterDefaultValues(ByVal CurrentPage As Control, ByVal objPage As Page) As Object
        Dim SystemFilterModuleId As Guid = InsertSystemModule(objPage)
        Dim PageName As String = GetPage(objPage)
        Dim dt As AccountFilterModule.vueSystemFilterModuleDataTable = New AccountFilterModuleBLL().GetDataBySystemFilterModuleId(SystemFilterModuleId)
        Dim dr As AccountFilterModule.vueSystemFilterModuleRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If Not (CurrentPage.FindControl(dr.SystemFilterModuleFieldName)) Is Nothing Then
                    Dim SystemFilterModuleFieldId As Guid = GetSystemFilterModuleField(SystemFilterModuleId, dr.SystemFilterModuleFieldName, False)
                    Dim SystemFilterModuleName As String = GetSystemModule(SystemFilterModuleId)
                    If PageName = SystemFilterModuleName Then
                        Dim SystemFilterModuleFieldName As String = dr.SystemFilterModuleFieldName
                        SystemFilterModuleFieldId = GetSystemFilterModuleField(SystemFilterModuleId, SystemFilterModuleFieldName, False)
                        Dim dtReset As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetEmployeeFilters(SystemFilterModuleId, SystemFilterModuleFieldId, DBUtilities.GetSessionAccountEmployeeId)
                        Dim drReset As AccountFilterModule.vueAccountFilterModuleRow
                        If dtReset.Rows.Count = 0 Then
                            Dim AccountFilterModuleDefaultName As Object = GetDefaultValues(CurrentPage, dr.SystemFilterModuleFieldName)
                            Dim AccountFilterModuleName As Object = GetValues(CurrentPage, dr.SystemFilterModuleFieldName)
                            Dim AccountFilterModuleText As Object = GetTextValues(CurrentPage, dr.SystemFilterModuleFieldName)
                            Dim InsertSystemFilterModuleFileld As Guid = SystemFilterModuleFieldId
                            AddFilterModule(SystemFilterModuleId, InsertSystemFilterModuleFileld, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, AccountFilterModuleName, AccountFilterModuleText, Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId, AccountFilterModuleDefaultName)
                        End If
                    End If
                End If
            Next
        End If
    End Function
    Public Function GetTextValues(CurrentPage As Object, DatabaseFieldName As Object) As Object
        Dim UIObject As Object = CurrentPage.FindControl(DatabaseFieldName)
        If UIObject Is Nothing Then
            Return Nothing
        End If
        If TypeOf UIObject Is DropDownList Then
            Return UIObject.SelectedItem.Text
        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
            Return UIObject.PostedDate.ToString
        ElseIf TypeOf UIObject Is CheckBox Then
            Return UIObject.Checked
        Else
            Return UIObject.Text()
        End If
    End Function
    Public Function ResetFilters(ByVal CurrentPage As Control, ByVal objPage As Page) As Object

        Dim SystemFilterModuleId As Guid = InsertSystemModule(objPage)
        Dim SystemFilterModuleName As String = GetSystemModule(SystemFilterModuleId)
        Dim dtReset As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetFiltersBySystemFilterModuleIdandAccountEmployeeIdForReset(SystemFilterModuleId, DBUtilities.GetSessionAccountEmployeeId)
        Dim drReset As AccountFilterModule.vueAccountFilterModuleRow
        If dtReset.Rows.Count > 0 Then
            drReset = dtReset.Rows(0)
            For Each drReset In dtReset.Rows
                Dim SystemFilterModuleFieldId As Guid = GetSystemFilterModuleFieldForReset(SystemFilterModuleId, drReset.SystemFilterModuleFieldName)
                Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetEmployeeFilters(SystemFilterModuleId, SystemFilterModuleFieldId, DBUtilities.GetSessionAccountEmployeeId)
                Dim dr As AccountFilterModule.vueAccountFilterModuleRow
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)
                    'If (dr.Item("IsGridViewFilter")) = False Then
                    UpdateFilterModule(
                        dr.Item("AccountFilterModuleId"),
                        dr.Item("SystemFilterModuleId"),
                        dr.Item("SystemFilterModuleFieldId"),
                        DBUtilities.GetSessionAccountId,
                        DBUtilities.GetSessionAccountEmployeeId,
                        dr.Item("AccountFilterModuleDefaultName").ToString(),
                        "",
                        Now,
                        DBUtilities.GetSessionAccountEmployeeId,
                        Now,
                        DBUtilities.GetSessionAccountEmployeeId,
                        dr.Item("AccountFilterModuleDefaultName").ToString())
                    'End If
                End If
            Next
        End If
        If SystemFilterModuleId.ToString() = "3b5f5d29-68ca-4e7c-964d-f63679ae16bf" Or SystemFilterModuleId.ToString() = "4c7e922f-bdf5-4cb0-b12f-99b8b1d60e0f" Then
            System.Web.HttpContext.Current.Session.Add("CascadingReset", 1)
        End If

    End Function
    Public Function ResetGridFilters(ByVal CurrentPage As Control, ByVal objPage As Page) As Object
        System.Web.HttpContext.Current.Session.Add("ResetFilter", 1)
        'Dim SystemFilterModuleId As Guid = InsertSystemModule(objPage)
        'Dim SystemFilterModuleName As String = GetSystemModule(SystemFilterModuleId)
        'Dim dtReset As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetFiltersBySystemFilterModuleIdandAccountEmployeeIdForReset(SystemFilterModuleId, DBUtilities.GetSessionAccountEmployeeId)
        'Dim drReset As AccountFilterModule.vueAccountFilterModuleRow
        'If dtReset.Rows.Count > 0 Then
        '    drReset = dtReset.Rows(0)
        '    For Each drReset In dtReset.Rows
        '        Dim AccountFilterModuleName As Object = ResetValues(CurrentPage, drReset.SystemFilterModuleFieldName)
        '        Dim SystemFilterModuleFieldId As Guid = GetSystemFilterModuleFieldForReset(SystemFilterModuleId, drReset.SystemFilterModuleFieldName)
        '        Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetEmployeeFilters(SystemFilterModuleId, SystemFilterModuleFieldId, DBUtilities.GetSessionAccountEmployeeId)
        '        Dim dr As AccountFilterModule.vueAccountFilterModuleRow
        '        If dt.Rows.Count > 0 Then
        '            dr = dt.Rows(0)
        '            If (dr.Item("IsGridViewFilter")) = True Then
        '                UpdateFilterModule(dr.Item("AccountFilterModuleId"), SystemFilterModuleId, dr.Item("SystemFilterModuleFieldId"), DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, "", Now, DBUtilities.GetSessionAccountEmployeeId, Now, DBUtilities.GetSessionAccountEmployeeId, "")
        '            End If
        '        End If
        '    Next
        'End If
    End Function
    Public Function ResetValues(CurrentPage As Object, DatabaseFieldName As String, ColumnValue As Object, Optional DDLTextValue As String = "") As Object
        Dim UIObject As Object = CurrentPage.FindControl(DatabaseFieldName)
        If UIObject Is Nothing Then
            Return Nothing
        End If
        If TypeOf UIObject Is DropDownList Then
            If DDLTextValue = "" Then
                UIObject.SelectedValue = Nothing
                'End If
            Else
                UIObject.SelectedValue = ColumnValue
            End If
        ElseIf TypeOf UIObject Is eWorld.UI.CalendarPopup Then
            Dim ReplaceDate = Replace(ColumnValue, "?", "")
            Dim ResultDate As DateTime
            DateTime.TryParse(ReplaceDate, ResultDate)
            UIObject.SelectedDate = ResultDate
        ElseIf TypeOf UIObject Is CheckBox Then
            UIObject.Checked = ColumnValue
        Else
            UIObject.Text = ColumnValue
        End If
    End Function
    Public Function GetSystemFilterModuleFieldForReset(ByVal SystemFilterModuleId As Guid, ByVal SystemFilterModuleFieldName As String) As Object
        Dim SystemFilterModuleFieldId As Guid
        Dim dtSystemFiled As AccountFilterModule.SystemFilterModuleFieldDataTable = New AccountFilterModuleBLL().GetSystemFilterModuleFieldIdForReset(SystemFilterModuleId, SystemFilterModuleFieldName)
        Dim drSystemFiled As AccountFilterModule.SystemFilterModuleFieldRow
        If dtSystemFiled.Rows.Count > 0 Then
            drSystemFiled = dtSystemFiled.Rows(0)
            If Not IsDBNull(drSystemFiled.Item("SystemFilterModuleFieldName")) Then
                SystemFilterModuleFieldId = drSystemFiled.Item("SystemFilterModuleFieldId")
            End If
        End If
        Return SystemFilterModuleFieldId
    End Function
    Public Function GetFilterResult(objPage As Page) As Hashtable
        Dim CurrentPage As Control = objPage
        Dim chkIncludeDateRangeValue As Boolean
        Dim SystemFilterModuleId As Guid = InsertSystemModule(objPage)
        If SystemFilterModuleId = New Guid("3b5f5d29-68ca-4e7c-964d-f63679ae16bf") Or SystemFilterModuleId = New Guid("b082bc6c-6b05-48a3-9742-278f1b1a750a") Or SystemFilterModuleId = New Guid("243ba324-d018-4171-84bc-030aef1c40e8") Or SystemFilterModuleId = New Guid("1451ebb6-e49d-4d2c-b3fc-138a739a37b8") Or SystemFilterModuleId = New Guid("532784da-ecb7-4539-b2ae-9e68bba456b8") Then
            Dim SystemFilterModuleFieldId As Guid = GetSystemFilterModuleField(SystemFilterModuleId, "chkIncludeDateRange", False)
            Dim dtField As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetDataByAccountFilterModuleText(SystemFilterModuleId, SystemFilterModuleFieldId, DBUtilities.GetSessionAccountEmployeeId, "True")
            Dim drField As AccountFilterModule.vueAccountFilterModuleRow
            If dtField.Rows.Count > 0 Then
                chkIncludeDateRangeValue = True
            End If
        End If
        Dim nFilterTextAndValue As New Hashtable
        Dim SystemFilterModuleName As String = GetSystemModule(SystemFilterModuleId)
        Try
            Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetFiltersBySystemFilterModuleIdandAccountEmployeeIdAndAccountFilterModuleNameIsNull(SystemFilterModuleId, DBUtilities.GetSessionAccountEmployeeId)
            Dim dr As AccountFilterModule.vueAccountFilterModuleRow
            For Each dr In dt.Rows
                If dr.Item("AccountFilterModuleDefaultName") <> dr.Item("AccountFilterModuleName") Then
                    If SystemFilterModuleId = New Guid("3b5f5d29-68ca-4e7c-964d-f63679ae16bf") Or SystemFilterModuleId = New Guid("b082bc6c-6b05-48a3-9742-278f1b1a750a") Or SystemFilterModuleId = New Guid("243ba324-d018-4171-84bc-030aef1c40e8") Or SystemFilterModuleId = New Guid("1451ebb6-e49d-4d2c-b3fc-138a739a37b8") Or SystemFilterModuleId = New Guid("532784da-ecb7-4539-b2ae-9e68bba456b8") Then
                        If dr.Item("SystemFilterModuleFieldName") = "CreatedDateUpt" Or dr.Item("SystemFilterModuleFieldName") = "CreatedDateFrom" Or dr.Item("SystemFilterModuleFieldName") = "StartDate" Or dr.Item("SystemFilterModuleFieldName") = "EndDate" Or dr.Item("SystemFilterModuleFieldName") = "StartDateTextBox" Or dr.Item("SystemFilterModuleFieldName") = "EndDateTextBox" Then
                            If chkIncludeDateRangeValue = True Then
                                nFilterTextAndValue.Add(ResourceHelper.GetFromResource(dr.Item("SystemFilterModuleFieldCaption")), dr.Item("AccountFilterModuleText"))
                            End If
                        Else
                            If dr.Item("SystemFilterModuleFieldName") <> "chkIncludeDateRange" Then
                                If nFilterTextAndValue.ContainsKey(ResourceHelper.GetFromResource(dr.Item("SystemFilterModuleFieldCaption"))) Then
                                    If dr.Item("IsGridViewFilter") = 1 Then
                                        nFilterTextAndValue(ResourceHelper.GetFromResource(dr.Item("SystemFilterModuleFieldCaption"))) = dr.Item("AccountFilterModuleText")
                                    End If
                                Else
                                    nFilterTextAndValue.Add(ResourceHelper.GetFromResource(dr.Item("SystemFilterModuleFieldCaption")), dr.Item("AccountFilterModuleText"))
                                End If

                            End If
                        End If
                    Else
                        nFilterTextAndValue.Add(ResourceHelper.GetFromResource(dr.Item("SystemFilterModuleFieldCaption")), dr.Item("AccountFilterModuleText"))
                    End If
                End If
            Next
        Catch ex As Exception
            Me.ResetFilters(CurrentPage, objPage)
            System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.RawUrl, False)
        End Try
        Return nFilterTextAndValue
    End Function
    Public Function CheckDropDownValues(CurrentPage As Object, objPage As Page, DatabaseFieldName As String) As Object
        Dim SystemFilterModuleId As Guid = InsertSystemModule(objPage)
        Dim page As ControlCollection = CurrentPage.Controls
        Dim ColumnValue As Object = ""
        Dim DefaultValue As Object = ""
        Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetFilterRecord(SystemFilterModuleId, DatabaseFieldName, DBUtilities.GetSessionAccountEmployeeId)
        Dim dr As AccountFilterModule.vueAccountFilterModuleRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            ColumnValue = dr.AccountFilterModuleName
            DefaultValue = dr.AccountFilterModuleDefaultName
        End If
        If DatabaseFieldName = "ddlProjectTasks" Then
            If ColumnValue <> DefaultValue Then
                Dim dtProjectTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = New AccountProjectTaskBLL().GetvueAccountProjectTasksByAccountProjectTaskId(ColumnValue)
                If dtProjectTask.Rows.Count = 0 Then
                    Return ResetSelectedFilter(CurrentPage, objPage, DatabaseFieldName)
                End If
            End If
        ElseIf DatabaseFieldName = "ddlProjects" Or DatabaseFieldName = "ddlAccountProjectId" Then
            If ColumnValue <> DefaultValue Then
                Dim dtProjects As TimeLiveDataSet.AccountProjectDataTable = New AccountProjectBLL().GetProjectsByAccountIdAndAccountProjectIdForNotDeleted(DBUtilities.GetSessionAccountId, ColumnValue)
                If dtProjects.Rows.Count = 0 Then
                    Return ResetSelectedFilter(CurrentPage, objPage, DatabaseFieldName)
                End If
            End If
        ElseIf DatabaseFieldName = "ddlEmployees" Or DatabaseFieldName = "ddlEmployeeName" Or DatabaseFieldName = "ddlEmployee" Then
            If ColumnValue <> DefaultValue Then
                Dim dtEmployees As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetEmployeesByAccountIdAndAccountEmployeeIdForNotDeleted(DBUtilities.GetSessionAccountId, ColumnValue)
                If dtEmployees.Rows.Count = 0 Then
                    Return ResetSelectedFilter(CurrentPage, objPage, DatabaseFieldName)
                End If
            End If
        ElseIf DatabaseFieldName = "ddlClients" Or DatabaseFieldName = "ddlAccountClientId" Then
            If ColumnValue <> DefaultValue Then
                Dim dtClients As TimeLiveDataSet.vueAccountPartyDataTable = New AccountPartyBLL().GetClientsByAccountIdAndClientIdForNotDeleted(DBUtilities.GetSessionAccountId, ColumnValue)
                If dtClients.Rows.Count = 0 Then
                    Return ResetSelectedFilter(CurrentPage, objPage, DatabaseFieldName)
                End If
            End If
        ElseIf DatabaseFieldName = "ddlAccountStatusId" Or DatabaseFieldName = "ddlProjectStatus" Then
            If ColumnValue <> DefaultValue Then
                Dim dtStatus As TimeLiveDataSet.AccountStatusDataTable = New AccountStatusBLL().GetAccountsStatusByAccountStatusId(ColumnValue)
                If dtStatus.Rows.Count = 0 Then
                    Return ResetSelectedFilter(CurrentPage, objPage, DatabaseFieldName)
                End If
            End If
        ElseIf DatabaseFieldName = "ddlAccountProjectMilestoneId" Then
            If ColumnValue <> DefaultValue Then
                Dim dtMilestone As TimeLiveDataSet.AccountProjectMilestoneDataTable = New AccountProjectMilestoneBLL().GetAccountProjectMilestonesByAccountProjectMilestoneId(ColumnValue)
                If dtMilestone.Rows.Count = 0 Then
                    Return ResetSelectedFilter(CurrentPage, objPage, DatabaseFieldName)
                End If
            End If
        ElseIf DatabaseFieldName = "ddlAccountTaskType" Then
            If ColumnValue <> DefaultValue Then
                Dim dtTaskType As TimeLiveDataSet.AccountTaskTypeDataTable = New AccountTaskTypeBLL().GetAccountTaskTypesByAccountTaskTypeId(ColumnValue)
                If dtTaskType.Rows.Count = 0 Then
                    Return ResetSelectedFilter(CurrentPage, objPage, DatabaseFieldName)
                End If
            End If
        End If
        
        Return ColumnValue
    End Function
    Public Function ResetSelectedFilter(ByVal CurrentPage As Control, ByVal objPage As Page, DatabaseFieldName As String) As Object
        Dim AccountFilterModuleDefaultName As Object
        Dim SystemFilterModuleId As Guid = InsertSystemModule(objPage)
        Dim SystemFilterModuleName As String = GetSystemModule(SystemFilterModuleId)
        Dim dtReset As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetFilterRecord(SystemFilterModuleId, DatabaseFieldName, DBUtilities.GetSessionAccountEmployeeId)
        Dim drReset As AccountFilterModule.vueAccountFilterModuleRow
        If dtReset.Rows.Count > 0 Then
            drReset = dtReset.Rows(0)
            For Each drReset In dtReset.Rows
                Dim SystemFilterModuleFieldId As Guid = GetSystemFilterModuleFieldForReset(SystemFilterModuleId, drReset.SystemFilterModuleFieldName)
                Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetEmployeeFilters(SystemFilterModuleId, SystemFilterModuleFieldId, DBUtilities.GetSessionAccountEmployeeId)
                Dim dr As AccountFilterModule.vueAccountFilterModuleRow
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)
                    UpdateFilterModule(dr.Item("AccountFilterModuleId"), dr.Item("SystemFilterModuleId"), dr.Item("SystemFilterModuleFieldId"), DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, dr.Item("AccountFilterModuleDefaultName"), "", dr.Item("CreatedOn"), dr.Item("CreatedByEmployeeId"), Now, DBUtilities.GetSessionAccountEmployeeId, dr.Item("AccountFilterModuleDefaultName"))
                    AccountFilterModuleDefaultName = dr.Item("AccountFilterModuleDefaultName")
                    'If SystemFilterModuleId.ToString() <> "D8AF0F98-81B0-4D3A-A0F9-2BCE9B997069" Or SystemFilterModuleId.ToString() <> "E37AF5C4-24F2-4A0F-9050-AFEBE705CC9F" Or SystemFilterModuleId.ToString() <> "3B5F5D29-68CA-4E7C-964D-F63679AE16BF" Then
                    System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.RawUrl, False)
                    'End If

                End If
            Next
            'System.Web.HttpContext.Current.Session.Add("ResetSelectedFilter", 1)
        End If
        If SystemFilterModuleId.ToString() = "3b5f5d29-68ca-4e7c-964d-f63679ae16bf" Or SystemFilterModuleId.ToString() = "4c7e922f-bdf5-4cb0-b12f-99b8b1d60e0f" Then
            System.Web.HttpContext.Current.Session.Add("CascadingReset", 1)
        End If
        Return AccountFilterModuleDefaultName
    End Function
   
End Class
