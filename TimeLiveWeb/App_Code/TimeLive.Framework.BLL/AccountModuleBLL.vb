Imports Microsoft.VisualBasic
Imports AccountModuleTableAdapters
Imports System.Web
<System.ComponentModel.DataObject()> _
Public Class AccountModuleBLL
    Private _AccountModuleViewTableAdapter As AccountModuleViewTableAdapter = Nothing
    Private _AccountModuleFieldsTableAdapter As AccountModuleFieldsTableAdapter = Nothing
    Private _vueAccountModuleFieldsTableAdapter As vueAccountModuleFieldsTableAdapter = Nothing
    Private _SystemModuleTableAdapter As SystemModuleTableAdapter = Nothing
    Private _SystemModuleFieldsTableAdapter As SystemModuleFieldsTableAdapter = Nothing
    Private _SystemModuleViewTableAdapter As SystemModuleViewTableAdapter = Nothing
    Protected ReadOnly Property AccountModuleViewAdapter() As AccountModuleViewTableAdapter
        Get
            If _AccountModuleViewTableAdapter Is Nothing Then
                _AccountModuleViewTableAdapter = New AccountModuleViewTableAdapter()
            End If

            Return _AccountModuleViewTableAdapter
        End Get
    End Property
    Protected ReadOnly Property AccountModuleFieldsAdapter() As AccountModuleFieldsTableAdapter
        Get
            If _AccountModuleFieldsTableAdapter Is Nothing Then
                _AccountModuleFieldsTableAdapter = New AccountModuleFieldsTableAdapter()
            End If

            Return _AccountModuleFieldsTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAccountModuleFieldsAdapter() As vueAccountModuleFieldsTableAdapter
        Get
            If _vueAccountModuleFieldsTableAdapter Is Nothing Then
                _vueAccountModuleFieldsTableAdapter = New vueAccountModuleFieldsTableAdapter()
            End If

            Return _vueAccountModuleFieldsTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SystemModuleAdapter() As SystemModuleTableAdapter
        Get
            If _SystemModuleTableAdapter Is Nothing Then
                _SystemModuleTableAdapter = New SystemModuleTableAdapter()
            End If

            Return _SystemModuleTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SystemModuleFieldsAdapter() As SystemModuleFieldsTableAdapter
        Get
            If _SystemModuleFieldsTableAdapter Is Nothing Then
                _SystemModuleFieldsTableAdapter = New SystemModuleFieldsTableAdapter()
            End If

            Return _SystemModuleFieldsTableAdapter
        End Get
    End Property
    Protected ReadOnly Property SystemModuleViewAdapter() As SystemModuleViewTableAdapter
        Get
            If _SystemModuleViewTableAdapter Is Nothing Then
                _SystemModuleViewTableAdapter = New SystemModuleViewTableAdapter()
            End If

            Return _SystemModuleViewTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleView() As AccountModule.AccountModuleViewDataTable
        Return AccountModuleViewAdapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleViewByAccountModuleViewName(ByVal SystemModuleId As Guid, ByVal AccountModuleViewName As String) As AccountModule.AccountModuleViewDataTable
        Return AccountModuleViewAdapter.GetDataByAccountModuleViewName(SystemModuleId, AccountModuleViewName, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleViewBySystemModuleandAccountEmployeeId(ByVal SystemModuleId As Guid) As AccountModule.AccountModuleViewDataTable
        Return AccountModuleViewAdapter.GetAccountModuleViewsBySystemModuleIdandAccountEmployeeId(SystemModuleId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetViewDataByAccountModuleViewId(ByVal AccountModuleViewId As Guid) As AccountModule.AccountModuleViewDataTable
        Return AccountModuleViewAdapter.GetDataByAccountModuleViewId(AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleViewByIsSelected(ByVal SystemModuleId As Guid, ByVal IsSelected As Boolean) As AccountModule.AccountModuleViewDataTable
        Return AccountModuleViewAdapter.GetAccountModuleViewByIsSelected(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SystemModuleId, IsSelected)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleViewByIsDefaultView(ByVal SystemModuleId As Guid, ByVal IsDefaultView As Boolean) As AccountModule.AccountModuleViewDataTable
        Return AccountModuleViewAdapter.GetAccountModuleViewIdByIsDefaultView(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, SystemModuleId, IsDefaultView)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLastInsertedAccountModuleViewId(ByVal SystemModuleId As Guid, ByVal AccountModuleViewName As String, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountModule.AccountModuleViewDataTable
        Return AccountModuleViewAdapter.GetLasterInsertedAccountModuleViewId(SystemModuleId, AccountModuleViewName, AccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleFields() As AccountModule.AccountModuleFieldsDataTable
        Return AccountModuleFieldsAdapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleFieldsByAccountModuleViewId(ByVal AccountModuleViewId As Guid, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountModule.AccountModuleFieldsDataTable
        Return AccountModuleFieldsAdapter.GetDataByAccountModuleView(AccountModuleViewId, AccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleFieldsBySystemModuleFieldIdAndAccountModuleViewId(ByVal SystemModuleFieldId As Guid, AccountModuleViewId As Guid) As AccountModule.AccountModuleFieldsDataTable
        Return AccountModuleFieldsAdapter.GetBySystemModuleFieldIdAndAccountModuleViewId(SystemModuleFieldId, AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountModuleFields() As AccountModule.vueAccountModuleFieldsDataTable
        Return vueAccountModuleFieldsAdapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountModuleFieldsByAccountModuleViewIdAndSystemModuleId(ByVal AccountModuleViewId As Guid, ByVal SystemModuleId As Guid) As AccountModule.vueAccountModuleFieldsDataTable
        Return vueAccountModuleFieldsAdapter.GetvueAccountModuleFieldsByAccountModuleViewIdAndSystemModuleId(AccountModuleViewId, SystemModuleId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueSystemModuleFieldsBySystemModuleIdAndAccountModuleViewIsNull(ByVal SystemModuleId As Guid, ByVal AccountModuleViewId As Guid) As AccountModule.vueAccountModuleFieldsDataTable
        Return vueAccountModuleFieldsAdapter.GetvueSystemModuleFiledsBySystemModuleIdandAccountModuleViewIdAndIsNull(SystemModuleId, AccountModuleViewId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueSelectedSystemModuleFieldsBySystemModuleIdAndAccountModuleViewID(ByVal SystemModuleId As Guid, ByVal AccountModuleViewId As Guid) As AccountModule.vueAccountModuleFieldsDataTable
        Return vueAccountModuleFieldsAdapter.GetvueSystemModuleFiledsBySystemModuleIdandAccountModuleViewId(SystemModuleId, AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleFieldsByAccountModuleFieldId(ByVal AccountModuleFieldId As Guid) As AccountModule.AccountModuleFieldsDataTable
        Return AccountModuleFieldsAdapter.GetDataByAccountModuleFieldId(AccountModuleFieldId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountModuleFieldsBySystemModuleFieldId(ByVal SystemModuleFieldId As Guid, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer) As AccountModule.AccountModuleFieldsDataTable
        Return AccountModuleFieldsAdapter.GetAccountAndEmployeeModuleFiledsBySystemModuleFieldId(SystemModuleFieldId, AccountId, AccountEmployeeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemModule() As AccountModule.SystemModuleDataTable
        Return SystemModuleAdapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemModuleFields() As AccountModule.SystemModuleFieldsDataTable
        Return SystemModuleFieldsAdapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemModuleFieldsBySystemModuleIdandIsDefaultAdd(ByVal IsDefaultAdd As Boolean, ByVal SystemModuleId As Guid) As AccountModule.SystemModuleFieldsDataTable
        Return SystemModuleFieldsAdapter.GetDataBySystemModuleIdandIsDefaultAdd(IsDefaultAdd, SystemModuleId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemModuleViewBySystemModuleId(ByVal SystemModuleId As Guid) As AccountModule.SystemModuleViewDataTable
        Return SystemModuleViewAdapter.GetSystemModuleViewBySystemModuleId(SystemModuleId)
    End Function
    Public Function GetDefaultView(ByVal SystemModuleId As Guid) As Guid
        Dim DefaultVieId As New Guid
        'Dim DefaultVieName As New Guid
        Dim dtDefault As AccountModule.AccountModuleViewDataTable = New AccountModuleBLL().GetAccountModuleViewByIsDefaultView(SystemModuleId, True)
        Dim drDefault As AccountModule.AccountModuleViewRow
        If dtDefault.Rows.Count > 0 Then
            drDefault = dtDefault.Rows(0)
            DefaultVieId = drDefault.AccountModuleViewId
            'DefaultVieName = drDefault.AccountModuleViewName
        End If
        Return DefaultVieId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountModuleFields(ByVal AccountModuleFieldName As String, ByVal SystemModuleFieldId As Guid, ByVal AccountModuleViewId As Guid, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal SortOrder As Integer) As Boolean
        Dim dtAccountModuleFields As New AccountModule.AccountModuleFieldsDataTable
        Dim drAccountModuleFields As AccountModule.AccountModuleFieldsRow = dtAccountModuleFields.NewAccountModuleFieldsRow

        With drAccountModuleFields
            .AccountModuleFieldId = System.Guid.NewGuid
            .AccountModuleFieldName = AccountModuleFieldName
            .SystemModuleFieldId = SystemModuleFieldId
            .AccountModuleViewId = AccountModuleViewId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .CreatedOn = Now
            .CreatedBy = DBUtilities.GetSessionAccountEmployeeId()
            .SortOrder = SortOrder

        End With

        dtAccountModuleFields.AddAccountModuleFieldsRow(drAccountModuleFields)
        Dim rowsAffected As Integer = AccountModuleFieldsAdapter.Update(dtAccountModuleFields)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountModuleFields(ByVal Original_AccountModuleFieldId As Guid, ByVal AccountModuleFieldName As String, ByVal SystemModuleFieldId As Guid, ByVal AccountModuleViewId As Guid, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal SortOrder As Integer) As Boolean

        Dim dtAccountModuleFields As AccountModule.AccountModuleFieldsDataTable = AccountModuleFieldsAdapter.GetDataByAccountModuleFieldId(Original_AccountModuleFieldId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Dim drAccountModuleFields As AccountModule.AccountModuleFieldsRow = dtAccountModuleFields.Rows(0)

        With drAccountModuleFields
            .AccountModuleFieldId = Original_AccountModuleFieldId
            .AccountModuleFieldName = AccountModuleFieldName
            .SystemModuleFieldId = SystemModuleFieldId
            .AccountModuleViewId = AccountModuleViewId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .ModifiedOn = Now
            .ModifiedBy = DBUtilities.GetSessionAccountEmployeeId()
            .SortOrder = SortOrder

        End With

        Dim rowsAffected As Integer = AccountModuleFieldsAdapter.Update(dtAccountModuleFields)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountModuleFields(ByVal Original_SystemModuleFieldId As Guid, ByVal AccountModuleViewId As Guid) As Boolean
        Dim rowsAffected As Integer = AccountModuleFieldsAdapter.DeleteQuery(Original_SystemModuleFieldId, AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteQueryAccountModuleViewFields(ByVal AccountModuleViewId As Guid) As Boolean
        Dim rowsAffected As Integer = AccountModuleFieldsAdapter.DeleteQueryAccountModuleViewData(AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountModuleView(ByVal AccountModuleViewName As String, ByVal SystemModuleId As Guid, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal IsSelected As Integer, ByVal IsDefaultView As Boolean) As Boolean
        Dim dtAccountModuleView As New AccountModule.AccountModuleViewDataTable
        Dim drAccountModuleView As AccountModule.AccountModuleViewRow = dtAccountModuleView.NewAccountModuleViewRow

        With drAccountModuleView
            .AccountModuleViewId = System.Guid.NewGuid
            .AccountModuleViewName = AccountModuleViewName
            .SystemModuleId = SystemModuleId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .IsSelected = IsSelected
            .IsDefaultView = IsDefaultView
            .CreatedOn = Now
            .CreatedBy = DBUtilities.GetSessionAccountEmployeeId()
        End With

        dtAccountModuleView.AddAccountModuleViewRow(drAccountModuleView)
        Dim rowsAffected As Integer = AccountModuleViewAdapter.Update(dtAccountModuleView)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountModuleView(ByVal Original_AccountModuleViewId As Guid, ByVal AccountModuleViewName As String, ByVal SystemModuleId As Guid, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal IsSelected As Boolean, ByVal IsDefaultView As Boolean) As Boolean

        Dim dtAccountModuleView As AccountModule.AccountModuleViewDataTable = AccountModuleViewAdapter.GetDataByAccountModuleViewId(Original_AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Dim drAccountModuleView As AccountModule.AccountModuleViewRow = dtAccountModuleView.Rows(0)

        With drAccountModuleView
            .AccountModuleViewId = Original_AccountModuleViewId
            .AccountModuleViewName = AccountModuleViewName
            .SystemModuleId = SystemModuleId
            .AccountId = AccountId
            .AccountEmployeeId = AccountEmployeeId
            .IsSelected = IsSelected
            .IsDefaultView = IsDefaultView
            .ModifiedOn = Now
            .ModifiedBy = DBUtilities.GetSessionAccountEmployeeId()
        End With

        Dim rowsAffected As Integer = AccountModuleViewAdapter.Update(dtAccountModuleView)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountModuleView(ByVal Original_AccountModuleViewId As Guid, ByVal Original_SystemModuleFieldId As Guid) As Boolean
        Dim rowsAffected As Integer = AccountModuleViewAdapter.DeleteAccountModuleViewBySystemModuleIdandAccountModuleViewId(Original_AccountModuleViewId, Original_SystemModuleFieldId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub UpdateAccountModuleViewForddl(ByVal AccountModuleViewName As String, ByVal AccountModuleViewId As Guid, ByVal SystemModuleId As Guid)
        Dim DefaultVieId As New Guid
        DefaultVieId = GetDefaultView(SystemModuleId)
        Dim dt As AccountModule.AccountModuleViewDataTable = New AccountModuleBLL().GetAccountModuleViewBySystemModuleandAccountEmployeeId(SystemModuleId)
        Dim dr As AccountModule.AccountModuleViewRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                If dr.AccountModuleViewId = DefaultVieId Then
                    UpdateAccountModuleView(dr.Item("AccountModuleViewId"), dr.Item("AccountModuleViewName"), dr.Item("SystemModuleId"), dr.Item("AccountId"), dr.Item("AccountEmployeeId"), False, True)
                Else
                    UpdateAccountModuleView(dr.Item("AccountModuleViewId"), dr.Item("AccountModuleViewName"), dr.Item("SystemModuleId"), dr.Item("AccountId"), dr.Item("AccountEmployeeId"), False, False)
                End If
                'UpdateAccountModuleView(dr.Item("AccountModuleViewId"), dr.Item("AccountModuleViewName"), dr.Item("SystemModuleId"), dr.Item("AccountId"), dr.Item("AccountEmployeeId"), False, dr.Item("IsDefaultView"))
            Next
        End If
        'UpdateAccountModuleView(AccountModuleViewId, AccountModuleViewName, SystemModuleId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, True, dr.Item("IsDefaultView"))
        If AccountModuleViewId = DefaultVieId Then
            UpdateAccountModuleView(AccountModuleViewId, AccountModuleViewName, SystemModuleId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, True, True)
        Else
            UpdateAccountModuleView(AccountModuleViewId, AccountModuleViewName, SystemModuleId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, True, False)
        End If

    End Sub
    Public Sub SetDefaultViewIsSelected(ByVal SystemModuleId As Guid)
        Dim dtDefault As AccountModule.AccountModuleViewDataTable = New AccountModuleBLL().GetAccountModuleViewByIsDefaultView(SystemModuleId, True)
        Dim drDefault As AccountModule.AccountModuleViewRow
        If dtDefault.Rows.Count > 0 Then
            drDefault = dtDefault.Rows(0)
            UpdateAccountModuleView(drDefault.Item("AccountModuleViewId"), drDefault.Item("AccountModuleViewName"), drDefault.Item("SystemModuleId"), drDefault.Item("AccountId"), drDefault.Item("AccountEmployeeId"), True, True)
            'DefaultVieId = drDefault.AccountModuleViewId
            'DefaultVieName = drDefault.AccountModuleViewName
        End If
    End Sub
    Public Shared Function GetPage(ByVal objPage As Page) As String
        Dim ThisPage As String = objPage.AppRelativeVirtualPath
        Dim SlashPos As Integer = InStrRev(ThisPage, "/")
        Dim PageName As String = Right(ThisPage, Len(ThisPage) - SlashPos)
        Dim ThisFolder As String = objPage.AppRelativeTemplateSourceDirectory
        Dim SlashPos1 As String = Right(ThisFolder, Len(ThisFolder) - 2)
        Dim FolderName As String = Left(SlashPos1, Len(SlashPos1) - 1)
        Return PageName
    End Function
    Public Sub InsertModuleViewFirstTime(ByVal SystemModuleId As Guid)
        Dim dtDefaultView As AccountModule.AccountModuleViewDataTable = New AccountModuleBLL().GetAccountModuleViewBySystemModuleandAccountEmployeeId(SystemModuleId)
        If dtDefaultView.Rows.Count = 0 Then
            Dim dtSystemView As AccountModule.SystemModuleViewDataTable = New AccountModuleBLL().GetSystemModuleViewBySystemModuleId(SystemModuleId)
            Dim drSystemView As AccountModule.SystemModuleViewRow
            If dtSystemView.Rows.Count > 0 Then
                drSystemView = dtSystemView.Rows(0)
                Me.AddAccountModuleView(drSystemView.SystemModuleViewName, SystemModuleId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, True, True)
            End If
        End If
    End Sub
    Public Sub InsertModuleViewFieldsFirstTime(ByVal SystemModuleId As Guid, ByVal AccountModuleViewId As Guid)
        'Dim i As Integer = 0
        Dim ModuleFields As New Hashtable
        Dim dtsystemfields As AccountModule.SystemModuleFieldsDataTable = New AccountModuleBLL().GetSystemModuleFieldsBySystemModuleIdandIsDefaultAdd(True, SystemModuleId)
        Dim drsystemfields As AccountModule.SystemModuleFieldsRow
        If dtsystemfields.Rows.Count > 0 Then
            drsystemfields = dtsystemfields.Rows(0)
            Dim dtAccountModule As AccountModule.AccountModuleFieldsDataTable = New AccountModuleBLL().GetAccountModuleFieldsByAccountModuleViewId(AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
            Dim drAccountModule As AccountModule.AccountModuleFieldsRow
            If dtAccountModule.Rows.Count = 0 Then
                'drAccountModule = dtAccountModule.Rows(0)
                For Each drsystemfields In dtsystemfields
                    Me.AddAccountModuleFields(drsystemfields.SystemModuleFieldName, drsystemfields.SystemModuleFieldId, AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, drsystemfields.SystemFieldsSortOrder)
                Next
                'ElseIf dtAccountModule.Rows.Count > 0 Then
                '    For Each drsystemfields In dtsystemfields
                '        For Each drAccountModule In dtAccountModule
                '            If drsystemfields.SystemModuleFieldId = drAccountModule.SystemModuleFieldId Then
                '                ModuleFields.Add(drsystemfields.SystemModuleFieldId, drsystemfields.SystemModuleFieldName)
                '            End If
                '        Next
                '        If drsystemfields.IsDefaultAdd = False Then
                '            Me.DeleteAccountModuleFields(drsystemfields.SystemModuleFieldId, AccountModuleViewId)
                '        Else
                '            Me.AddAccountModuleFields(drsystemfields.SystemModuleFieldName, drsystemfields.SystemModuleFieldId, AccountModuleViewId, DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId, drsystemfields.SystemFieldsSortOrder)
                '        End If
                '    Next
            End If
        End If
    End Sub
End Class
'If drsystemfields.SystemModuleFieldId = New Guid("9d0fbf67-879a-4347-b994-9740ed97717f") Then
'    ''ID
'    i = 1
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("1a491415-1ff7-4857-a8a0-91540fbd4767") Then
'    ''Task Code
'    i = 2
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("31017d12-801d-42dd-92dc-84fc9d8048cb") Then
'    ''Task Name
'    i = 3
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("9fa3c704-7ba8-464a-b1fc-40514b6a1bf9") Then
'    ''Project Code
'    i = 4
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("daabb0a5-4973-48dd-b361-13b9955953df") Then
'    ''Client Name
'    i = 5
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("e5f8a29a-29e5-4838-afa1-7b8d576a76e0") Then
'    ''Task Type
'    i = 6
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("aef4c27b-e4e6-43a6-81e2-7c6cde8f8c46") Then
'    ''Assigned By
'    i = 7
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("e2653abf-23f1-4a43-ac98-f74dd5dcd425") Then
'    ''Assigned To
'    i = 8
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("2b9687b4-09f0-41c0-97b2-32044fcb7465") Then
'    ''Start Date
'    i = 9
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("5bff2fa9-bf0b-4182-9fff-1c8242e2b41c") Then
'    ''Due Date
'    i = 10
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("0c814d77-92d3-4e2b-9ec3-d4aaed3e0796") Then
'    ''Status
'    i = 11
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("8f792920-5ca2-4c01-843b-0f0e313271c0") Then
'    ''Priority
'    i = 12
'ElseIf drsystemfields.SystemModuleFieldId = New Guid("cb3288e1-340b-4b30-bee2-7471dc5b2f25") Then
'    ''Milestone
'    i = 13
'Else
'    i = dtAccountModule.Rows.Count + 1
'End If