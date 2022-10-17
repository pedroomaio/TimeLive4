Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
Imports System.Configuration
<System.ComponentModel.DataObject()> Public Class AccountProjectTaskCommentsBLL

    Private _AccountProjectTaskCommentsTableAdapter As AccountProjectTaskCommentsTableAdapter = Nothing
    Dim strCacheKey As String

    Protected ReadOnly Property Adapter() As AccountProjectTaskCommentsTableAdapter
        Get
            If _AccountProjectTaskCommentsTableAdapter Is Nothing Then
                _AccountProjectTaskCommentsTableAdapter = New AccountProjectTaskCommentsTableAdapter()
            End If

            Return _AccountProjectTaskCommentsTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskComments() As TimeLiveDataSet.AccountProjectTaskCommentsDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskCommentssByAccountProjectTaskId(ByVal AccountProjectTaskId As Long, Optional ByVal NotFixTable As Boolean = False) As TimeLiveDataSet.vueAccountProjectTaskCommentsDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskCommentsTableAdapter
        GetAccountProjectTaskCommentssByAccountProjectTaskId = vueAdapter.GetDataByAccountProjectTaskId(AccountProjectTaskId)

        If NotFixTable = False Then
            UIUtilities.FixTableForNoRecords(GetAccountProjectTaskCommentssByAccountProjectTaskId)
        End If
        Return GetAccountProjectTaskCommentssByAccountProjectTaskId
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountProjectTaskCommentsByAccountProjectTaskCommentsId(ByVal AccountProjectTaskCommentsId As Long) As TimeLiveDataSet.vueAccountProjectTaskCommentsDataTable
        Dim vueAdapter As New TimeLiveDataSetTableAdapters.vueAccountProjectTaskCommentsTableAdapter
        Return vueAdapter.GetDataByAccountProjectTaskCommentsId(AccountProjectTaskCommentsId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountProjectTaskCommentsByAccountProjectTaskCommentsId(ByVal AccountProjectTaskCommentsId As Integer) As TimeLiveDataSet.AccountProjectTaskCommentsDataTable
        Return Adapter.GetDataByAccountProjectTaskCommenetsId(AccountProjectTaskCommentsId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountProjectTaskComments( _
                        ByVal AccountProjectTaskId As Long, ByVal CommentsTitle As String, ByVal Comments As String, ByVal CreatedOn As DateTime, ByVal CreatedByEmployeeId As Integer, ByVal ModifiedOn As DateTime, ByVal ModifiedByEmployeeId As Integer _
                    ) As Boolean
        ' Create a new ProductRow instance


        _AccountProjectTaskCommentsTableAdapter = New AccountProjectTaskCommentsTableAdapter

        Dim AccountProjectTaskCommentss As New TimeLiveDataSet.AccountProjectTaskCommentsDataTable
        Dim AccountProjectTaskComments As TimeLiveDataSet.AccountProjectTaskCommentsRow = AccountProjectTaskCommentss.NewAccountProjectTaskCommentsRow

        With AccountProjectTaskComments
            .AccountProjectTaskId = AccountProjectTaskId
            .Comments = Comments
            .CommentsTitle = CommentsTitle
            .CreatedOn = Now
            .CreatedByEmployeeId = CreatedByEmployeeId
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With

        AccountProjectTaskCommentss.AddAccountProjectTaskCommentsRow(AccountProjectTaskComments)


        ' Add the new product
        Dim rowsAffected As Integer = Adapter.Update(AccountProjectTaskCommentss)

        AfterAddNewComments(GetLastInsertedId)
        AfterUpdate()

        ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1


    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountProjectTaskComments(ByVal Comments As String, ByVal CommentsTitle As String, ByVal original_AccountProjectTaskCommentsId As Integer, ByVal ModifiedByEmployeeId As Integer) As Boolean

        ' Update the product record

        Dim AccountProjectTaskCommentss As TimeLiveDataSet.AccountProjectTaskCommentsDataTable = Adapter.GetDataByAccountProjectTaskCommenetsId(original_AccountProjectTaskCommentsId)

        Dim AccountProjectTaskComments As TimeLiveDataSet.AccountProjectTaskCommentsRow = AccountProjectTaskCommentss.Rows(0)

        With AccountProjectTaskComments
            .Comments = Comments
            .CommentsTitle = CommentsTitle
            .ModifiedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
        End With



        Dim rowsAffected As Integer = Adapter.Update(AccountProjectTaskComments)

        AfterUpdate()

        ' Return true if precisely one row was updated, otherwise false
        Return rowsAffected = 1
    End Function
    Public Sub AfterUpdate()
        CacheManager.ClearCache("AccountProjectTaskCommentsDataTable", , True)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountProjectTaskComments(ByVal original_AccountProjectTaskCommentsId As Integer) As Boolean
        Dim rowsAffected As Integer = Adapter.Delete(original_AccountProjectTaskCommentsId)

        AfterUpdate()
        ' Return true if precisely one row was deleted, otherwise false
        Return rowsAffected = 1
    End Function
    Public Function GetLastInsertedId() As Integer
        Dim a As TimeLiveDataSet.IdentityQueryRow
        Dim ad As New TimeLiveDataSetTableAdapters.IdentityQueryTableAdapter
        a = ad.GetAccountProjectTaskCommentsLastId.Rows(0)
        Return a.LastId
    End Function
    Public Sub AfterAddNewComments(ByVal AccountProjectTaskCommentsId As Integer)
        SendNewCommentsMail(AccountProjectTaskCommentsId)
    End Sub
    Public Sub SendNewCommentsMail(ByVal AccountProjectTaskCommentsId As Integer)

        SendNewCommentsMailtoAssignee(AccountProjectTaskCommentsId)
        EMailUtilities.DequeueEmail()
    End Sub
    Public Sub SendNewCommentsMailtoAssignee(ByVal AccountProjectTaskCommentsId As Integer)


        Dim drAccountProjectTaskComments As TimeLiveDataSet.vueAccountProjectTaskCommentsRow
        Dim objAccountProjectTaskComments As New AccountProjectTaskCommentsBLL
        drAccountProjectTaskComments = objAccountProjectTaskComments.GetvueAccountProjectTaskCommentsByAccountProjectTaskCommentsId(AccountProjectTaskCommentsId).Rows(0)

        Dim drAccountProjectTaskEmployee As AccountEmployee.vueAccountEmployeeRow
        Dim dtAccountProjectTaskEmployee As AccountEmployee.vueAccountEmployeeDataTable
        Dim objAccountProjectTaskEmployee As New AccountEmployeeBLL
        dtAccountProjectTaskEmployee = objAccountProjectTaskEmployee.GetAccountEmployeesByAccountProjectTaskId(drAccountProjectTaskComments.CreatedByEmployeeId, drAccountProjectTaskComments.AccountProjectId, drAccountProjectTaskComments.AccountProjectTaskId)

        For Each drAccountProjectTaskEmployee In dtAccountProjectTaskEmployee.Rows
            EMailUtilities.SendEMail(("[" & drAccountProjectTaskComments.ProjectName & " : " & drAccountProjectTaskComments.AccountProjectTaskId & "]" & drAccountProjectTaskComments.TaskName), "NewProjectTaskCommentsTemplate", GetPreparedEMailMessageForNewComments(drAccountProjectTaskComments), drAccountProjectTaskEmployee.EMailAddress, drAccountProjectTaskEmployee.FirstName & " " & drAccountProjectTaskEmployee.LastName, EMailUtilities.TASK_NOTIFICATION_DISPLAY_NAME)
        Next



    End Sub
    Public Function GetPreparedEMailMessageForNewComments(ByVal drAccountProjectTaskComments As TimeLiveDataSet.vueAccountProjectTaskCommentsRow) As StringDictionary

        Dim dict As New StringDictionary

        'Dim ProjectTasksBLL As New AccountProjectTaskBLL
        'Dim drProjectTasks As TimeLiveDataSet.AccountProjectTaskRow
        'drProjectTasks = ProjectTasksBLL.GetAccountProjectTypesByAccountProjectTaskId(AccountProjectTaskId)

        dict.Add("[projectname]", drAccountProjectTaskComments.ProjectName)
        dict.Add("[accountprojecttaskid]", drAccountProjectTaskComments.AccountProjectTaskId)
        dict.Add("[commentsdescription]", drAccountProjectTaskComments.Comments)

        dict.Add("[createdby]", drAccountProjectTaskComments.FirstName & " " & drAccountProjectTaskComments.LastName)
        dict.Add("[projecttitle]", drAccountProjectTaskComments.CommentsTitle)
        dict.Add("[url]", System.Configuration.ConfigurationManager.AppSettings("SitePrefix") & "Employee/AccountProjectTaskComments.aspx?AccountProjectTaskid=" & drAccountProjectTaskComments.AccountProjectTaskId)

        Dim drAccountProjectTaskEmployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeRow
        Dim dtAccountProjectTaskEmployee As TimeLiveDataSet.vueAccountProjectTaskEmployeeDataTable
        Dim objAccountProjectTaskEmployee As New AccountProjectTaskEmployeeBLL

        dtAccountProjectTaskEmployee = objAccountProjectTaskEmployee.GetAccountProjectTaskEmployeesByvueAccountProjectTaskId(drAccountProjectTaskComments.AccountProjectTaskId)
        Dim Assignee As String = ""

        For Each drAccountProjectTaskEmployee In dtAccountProjectTaskEmployee.Rows
            Assignee = Assignee & IIf(Assignee = "", "", ",") & (drAccountProjectTaskEmployee.FirstName & " " & drAccountProjectTaskEmployee.LastName) & (Chr(13))
        Next

        dict.Add("[assignee]", Assignee)
        Return dict

    End Function
End Class
