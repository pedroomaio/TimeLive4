Partial Class ProjectAdmin_Controls_ctlAccountProjectTaskAttachmentList
    Inherits System.Web.UI.UserControl

    Dim AccountProjectTaskId As Long
    Dim AttachmentName As String
    Dim AttachmentLocalPath As String
    Protected Sub dsAccountProjectTaskAttachmentFormObject_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectTaskAttachmentFormObject.Inserted
        DBUtilities.AfterInsert(Me.GridView1)
    End Sub
    Protected Sub dsAccountProjectTaskAttachmentFormObject_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectTaskAttachmentFormObject.Inserting
        DBUtilities.SetRowForInserting(e)
    End Sub
    Protected Sub dsAccountProjectTaskAttachmentFormObject_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectTaskAttachmentFormObject.Updated
        DBUtilities.AfterUpdate(Me.GridView1)
    End Sub
    Protected Sub dsAccountProjectTaskAttachmentFormObject_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles dsAccountProjectTaskAttachmentFormObject.Updating
        DBUtilities.SetRowForUpdating(e)
    End Sub
    Private Function FindControlRecursive(ByVal root As Control, ByVal id As String) As Control
        If root.ID = id Then
            Return root
        End If
        Dim c As Control
        For Each c In root.Controls
            Dim t As Control = FindControlRecursive(c, id)
            If Not t Is Nothing Then
                Return t
            End If
        Next
        Return Nothing
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            Me.AccountProjectTaskId = Me.dsAccountProjectTaskAttachmentObject.SelectParameters("AccountProjectTaskId").DefaultValue
        End If
        If Me.Request.QueryString("AccountAttachmentTypeId") <> 1 Then
            Me.FormView2.Visible = False
            Me.FormView1.Visible = True
            Dim ScriptManager As System.Web.UI.ScriptManager = Me.FindControlRecursive(Me.Page.Master.Master, "ScriptManager2")
            ScriptManager.RegisterPostBackControl(Me.FormView1.FindControl("Upload"))
        Else
            Me.FormView1.Visible = False
            Me.FormView2.Visible = True
        End If
        Me.GetAccountProjectTaskIdAndProjectTaskName()
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        AccountProjectTaskId = IIf(Not Request.QueryString("AccountProjectTaskId") Is Nothing, Request.QueryString("AccountProjectTaskId"), 64)
        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)

        If e.CommandName = "Delete" Then
            Dim objRow As GridViewRow = Me.GridView1.Rows(e.CommandArgument)
            Dim strFileName As String = strRoot & DBUtilities.GetSessionAccountId & "\" & AccountProjectTaskId & "\" & CType(objRow.FindControl("FileHyperlink"), HyperLink).Text

            If System.IO.File.Exists(strFileName) Then
                ' Try
                System.IO.File.Delete(strFileName)
                'Catch ex As Exception
                ' R 'esponse.Write(ex.Message)
                'End Try
            End If
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        AccountProjectTaskId = IIf(Not Request.QueryString("AccountProjectTaskId") Is Nothing, Request.QueryString("AccountProjectTaskId"), 64)
        'Dim objFileUpload As FileUpload
        'objFileUpload = Me.FormView1.Row.FindControl("AttachmentFileUpload")
        'Dim strRoot As String = Server.MapPath(".\..")
        'If Not System.IO.Directory.Exists(strRoot & "\Uploads") Then
        '    System.IO.Directory.CreateDirectory(strRoot & "\Uploads")
        'End If
        'If Not System.IO.Directory.Exists(strRoot & "\Uploads\" & AccountProjectTaskId) Then
        '    System.IO.Directory.CreateDirectory(strRoot & "\Uploads\" & AccountProjectTaskId)
        'End If
        'Dim FileToSave As String = strRoot & "\Uploads\" & AccountProjectTaskId & "\" & objFileUpload.FileName
        'objFileUpload.SaveAs(FileToSave)

        'Me.dsAccountProjectTaskAttachmentFormObject.InsertParameters("AttachmentLocalPath").DefaultValue = objFileUpload.FileName
        'Me.dsAccountProjectTaskAttachmentFormObject.InsertParameters("AttachmentName").DefaultValue = CType(Me.FormView1.FindControl("AttachmentNameTextBox"), TextBox).Text
        'Me.dsAccountProjectTaskAttachmentFormObject.Insert()
        Dim BLL As New AccountProjectTaskAttachmentBLL
        BLL.FileUpload(Me.FormView1.FindControl("AttachmentFileUpload"), AccountProjectTaskId, DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("AttachmentNameTextBox"), TextBox).Text)

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        UIUtilities.ClearCellsForNoRecords(e.Row)
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        ' The GridViewCommandEventArgs class does not contain a 
        ' property that indicates which row's command button was
        ' clicked. To identify which row's button was clicked, use 
        ' the button's CommandArgument property by setting it to the 
        ' row's index.
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Retrieve the LinkButton control from the first column.
            Dim Delete As LinkButton = CType(e.Row.Cells(8).Controls(1), LinkButton)
            ' Set the LinkButton's CommandArgument property with the
            ' row's index.
            Delete.CommandArgument = e.Row.RowIndex.ToString()
        End If
    End Sub
    Protected Sub Upload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        AccountProjectTaskId = IIf(Not Request.QueryString("AccountProjectTaskId") Is Nothing, Request.QueryString("AccountProjectTaskId"), 64)
        'Dim objFileUpload As FileUpload
        'objFileUpload = Me.FormView1.Row.FindControl("AttachmentFileUpload")
        'Dim strRoot As String = Server.MapPath(".\..")
        'If Not System.IO.Directory.Exists(strRoot & "\Uploads") Then
        '    System.IO.Directory.CreateDirectory(strRoot & "\Uploads")
        'End If
        'If Not System.IO.Directory.Exists(strRoot & "\Uploads\" & AccountProjectTaskId) Then
        '    System.IO.Directory.CreateDirectory(strRoot & "\Uploads\" & AccountProjectTaskId)
        'End If
        'Dim FileToSave As String = strRoot & "\Uploads\" & AccountProjectTaskId & "\" & objFileUpload.FileName
        'objFileUpload.SaveAs(FileToSave)

        'Me.dsAccountProjectTaskAttachmentFormObject.InsertParameters("AttachmentLocalPath").DefaultValue = objFileUpload.FileName
        'Me.dsAccountProjectTaskAttachmentFormObject.InsertParameters("AttachmentName").DefaultValue = CType(Me.FormView1.FindControl("AttachmentNameTextBox"), TextBox).Text
        'Me.dsAccountProjectTaskAttachmentFormObject.Insert()
        Dim BLL As New AccountProjectTaskAttachmentBLL
        BLL.FileUpload(Me.FormView1.FindControl("AttachmentFileUpload"), AccountProjectTaskId, DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("AttachmentNameTextBox"), TextBox).Text)

        Me.GridView1.DataBind()

        Response.Redirect("AccountProjectTaskComments.aspx?AccountProjectTaskId=" & Request.QueryString("AccountProjectTaskId"), False)
    End Sub
    Protected Sub FormView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewPageEventArgs)

    End Sub
    Public Function GetAccountProjectTaskIdAndProjectTaskName() As Boolean
        AccountProjectTaskId = Me.Request.QueryString("AccountProjectTaskId")
        Dim dtPTask As TimeLiveDataSet.vueAccountProjectTaskDataTable = New AccountProjectTaskBLL().GetAccountProjectTaskByvueAccountProjectTaskId(AccountProjectTaskId)
        Dim drPTask As TimeLiveDataSet.vueAccountProjectTaskRow

        If dtPTask.Rows.Count > 0 Then
            drPTask = dtPTask.Rows(0)
            CType(Me.FormView2.FindControl("txtProjectTaskId"), TextBox).Text = drPTask.AccountProjectTaskId
            CType(Me.FormView2.FindControl("txtProjectName"), TextBox).Text = drPTask.ProjectName
            CType(Me.FormView2.FindControl("txtTaskName"), TextBox).Text = drPTask.TaskName
        End If

    End Function
End Class
