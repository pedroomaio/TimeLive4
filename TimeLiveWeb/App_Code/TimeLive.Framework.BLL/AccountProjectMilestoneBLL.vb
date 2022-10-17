Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountProjectMilestoneBLL

    Dim strCacheKey As String
    Private _AccountProjectMilestoneTableAdapter As AccountProjectMilestoneTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As AccountProjectMilestoneTableAdapter
        Get
            If _AccountProjectMilestoneTableAdapter Is Nothing Then
                _AccountProjectMilestoneTableAdapter = New AccountProjectMilestoneTableAdapter()
            End If

            Return _AccountProjectMilestoneTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjecMilestones() As TimeLiveDataSet.AccountProjectMilestoneDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectMilestonesByAccountId(ByVal AccountId As Integer) As TimeLiveDataSet.AccountProjectMilestoneDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectMilestonesByProjectId(ByVal AccountProjectId As Integer) As TimeLiveDataSet.AccountProjectMilestoneDataTable
        Return Adapter.GetDataByAccountProjectId(AccountProjectId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectMilestonesByAccountProjectIdForMilestoneCompleted(ByVal AccountProjectId As Integer, ByVal AccountProjectMilestoneId As Integer) As TimeLiveDataSet.AccountProjectMilestoneDataTable
        'If IsMyTask = True Then
        Return Adapter.GetDataByAccountProjectIdForCompleted(AccountProjectId, AccountProjectMilestoneId)
        'Else
        'Return Adapter.GetDataByAccountProjectId(AccountProjectId)
        'End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectMilestonesByAccountProjectId(ByVal AccountProjectId As Integer, Optional ByVal NotFixTable As Boolean = False) As TimeLiveDataSet.AccountProjectMilestoneDataTable
        GetAccountProjectMilestonesByAccountProjectId = Adapter.GetDataByAccountProjectId(AccountProjectId)
        UIUtilities.FixTableForNoRecords(GetAccountProjectMilestonesByAccountProjectId)
        Return GetAccountProjectMilestonesByAccountProjectId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectMilestonesByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer, Optional ByVal AccountProjectMilestoneid As Integer = 0) As TimeLiveDataSet.AccountProjectMilestoneDataTable


        'strCacheKey = CacheManager.GetCacheKeyForAccountsData("AccountProjectMilestoneDataTable", "GetAccountProjectMilestonesByAccountProjectTaskId", "AccountProjectTaskId=" & AccountProjectTaskId)

        'If Not CacheManager.GetItemFromCache(strCacheKey) Is Nothing Then
        'GetAccountProjectMilestonesByAccountProjectTaskId = CacheManager.GetItemFromCache(strCacheKey)
        'Else
        GetAccountProjectMilestonesByAccountProjectTaskId = Adapter.GetDataByAccountProjectTaskId(AccountProjectMilestoneid, AccountProjectTaskId)
        'CacheManager.AddAccountDataInCache(GetAccountProjectMilestonesByAccountProjectTaskId, strCacheKey)
        'End If

        Return GetAccountProjectMilestonesByAccountProjectTaskId

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectMilestonesByAccountProjectMilestoneId(ByVal AccountProjectMilestoneId As Integer) As TimeLiveDataSet.AccountProjectMilestoneDataTable
        Return Adapter.GetDataByAccountProjectMilestoneId(DBUtilities.GetSessionAccountId, AccountProjectMilestoneId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProjectMilestone( _
                        ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal MilestoneDescription As String, ByVal MilestoneDate As Date, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, _
                        ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal Comments As String, ByVal Completed As Boolean, Optional ByVal IsWebServiceCall As Boolean = False, Optional ByVal IsDisabled As Boolean = False) As Boolean
        ' Create a new ProductRow instance


        _AccountProjectMilestoneTableAdapter = New AccountProjectMilestoneTableAdapter

        Dim AccountProjectMilestones As New TimeLiveDataSet.AccountProjectMilestoneDataTable
        Dim AccountProjectMilestone As TimeLiveDataSet.AccountProjectMilestoneRow = AccountProjectMilestones.NewAccountProjectMilestoneRow

        With AccountProjectMilestone
            .AccountId = AccountId
            .AccountProjectId = AccountProjectId
            .MilestoneDescription = MilestoneDescription
            .MilestoneDate = MilestoneDate
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .Comments = Comments
            .Completed = False
            .IsDisabled = False
        End With

        AccountProjectMilestones.AddAccountProjectMilestoneRow(AccountProjectMilestone)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountProjectMilestones)
        If Not IsWebServiceCall Then
            AfterUpdate(AccountProjectId)
        End If

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function
    Public Sub AfterUpdate(ByVal AccountProjectId As Integer)
        CacheManager.ClearCache("AccountProjectMilestoneDataTable", "AccountProjectId=" & AccountProjectId)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProjectMilestone(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal MilestoneDescription As String, ByVal MilestoneDate As Date, ByVal Original_AccountProjectMilestoneId As Integer, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, _
                                                  ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer, ByVal Comments As String, ByVal Completed As Boolean, ByVal IsDisabled As Boolean) As Boolean

        ' Update the product record

        Dim AccountProjectMilestones As TimeLiveDataSet.AccountProjectMilestoneDataTable = Adapter.GetDataByAccountProjectMilestoneId(AccountId, Original_AccountProjectMilestoneId)
        Dim AccountProjectMilestone As TimeLiveDataSet.AccountProjectMilestoneRow = AccountProjectMilestones.Rows(0)

        With AccountProjectMilestone
            '.AccountId = AccountId
            '.AccountProjectId = AccountProjectId
            .MilestoneDescription = MilestoneDescription
            .MilestoneDate = MilestoneDate
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .Comments = Comments
            .Completed = Completed
            .IsDisabled = IsDisabled
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountProjectMilestone)

        AfterUpdate(AccountProjectId)


        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectMilestone(ByVal original_AccountProjectMilestoneId As Integer, ByVal original_Comments As String, ByVal original_Completed As Boolean) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(Original_AccountProjectMilestoneId)

        CacheManager.ClearCache("AccountProjectMilestoneDataTable", , True)


        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub InsertAccountProjectMilestonesByProjectTemplate(ByVal AccountId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTemplateId As Integer)
        Adapter.InsertAccountProjectMilestoneByAccountProjectTemplate(AccountId, AccountProjectId, AccountProjectTemplateId)
    End Sub
    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountProjectMilestoneLastId.Rows(0)
        Return a.LastId
    End Function
End Class
