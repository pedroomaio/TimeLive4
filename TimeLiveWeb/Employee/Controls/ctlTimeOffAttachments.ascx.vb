
Partial Class Employee_Controls_ctlTimeOffAttachments
    Inherits System.Web.UI.UserControl

    Dim EmptyFileUpload As FileUpload

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If AuthenticateBLL.IsNewSession() Then
            AuthenticateBLL.DoLogout(Me.Page)
        End If

        EmptyFileUpload = CType(Me.FormView1.FindControl("AttachmentFileUpload"), FileUpload)

        Dim ScriptManager As System.Web.UI.ScriptManager = Me.FindControlRecursive(Me.Page, "ScriptManager2")
        ScriptManager.RegisterPostBackControl(Me.FormView1.FindControl("btnUpload"))

        Dim isReadOnly = Me.Request.QueryString("ReadOnly")
        If isReadOnly = "true" Then
            Me.UpdatePanel2.Visible = False
        End If

        Me.SetGridViewDataSource(isReadOnly)
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim strFileName As String
        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)

        If e.CommandName = "Delete" Then
            Dim objRow As GridViewRow = Me.GridView1.Rows(e.CommandArgument)
            Dim TimeEntryId As String = Me.Request.QueryString("TimeEntry")

            strFileName = ""

            strFileName = strRoot & DBUtilities.GetSessionAccountId & "\TimeOffAttachments\" & TimeEntryId & "\" & CType(objRow.FindControl("FileHyperlink"), HyperLink).Text
            Dim BLL = New TimeOffAttachmentsBLL

            If BLL.DeleteTimeOffAttachments(CType(objRow.FindControl("AttachmentId"), Label).Text) And System.IO.File.Exists(strFileName) Then
                Try
                    System.IO.File.Delete(strFileName)

                    Dim pathToDir = strRoot & DBUtilities.GetSessionAccountId & "\TimeOffAttachments\" & TimeEntryId

                    Dim myDir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(pathToDir)
                    If Not myDir.EnumerateFiles().Any() Then
                        System.IO.Directory.Delete(pathToDir)
                    End If

                Catch ex As Exception
                    Response.Write(ex.Message)
                End Try

            End If
            Response.Redirect(Request.RawUrl)
        End If

    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Retrieve the LinkButton control from the first column.
            Dim Delete As LinkButton = CType(e.Row.Cells(3).Controls(1), LinkButton)
            ' Set the LinkButton's CommandArgument property with the
            ' row's index.
            Delete.CommandArgument = e.Row.RowIndex.ToString()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim AttachmentLocalPath As String = ""

            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "AttachmentLocalPath")) Then
                AttachmentLocalPath = "/" & Server.UrlEncode(DataBinder.Eval(e.Row.DataItem, "AttachmentLocalPath"))
            End If

            Dim TimeEntryId = DataBinder.Eval(e.Row.DataItem, "TimeEntryId")
            Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
            Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
            Dim strFileName = strRoot & DBUtilities.GetSessionAccountId & "\TimeOffAttachments\" & TimeEntryId & "\" & AttachmentLocalPath
            Dim DecodeStrRoot As String = Server.UrlDecode(strFileName)
            Dim i As String = ""

            If System.IO.File.Exists(DecodeStrRoot) Then
                i = LicensingBLL.GetEncryptedStringAsBase64ByUTF8("FileName=" & DBUtilities.GetSessionAccountId & "/TimeOffAttachments/" & TimeEntryId & "/" & AttachmentLocalPath)
            End If

            Dim FileName As String = "~/Shared/FileDownload.aspx?" & i
            If Not e.Row.Cells(2).FindControl("FileHyperlink") Is Nothing Then
                CType(e.Row.Cells(2).FindControl("FileHyperlink"), HyperLink).NavigateUrl = FileName
            End If

        End If
    End Sub
    Private Function FileNameExist() As Boolean
        For index = 0 To GridView1.Rows.Count - 1
            If CType(GridView1.Rows(index).FindControl("FileHyperlink"), HyperLink).Text = CType(Me.FormView1.FindControl("AttachmentFileUpload"), FileUpload).FileName Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType(), "alert", "alert('" + ResourceHelper.GetFromResource("TimeOff Atts Alert Message") + "');", True)
                CType(FormView1.FindControl("txtAttachmentName"), TextBox).Text = ""
                Return True
            End If
        Next
        Return False
    End Function
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim TimeEntryId = Me.Request.QueryString("TimeEntry")
        If TimeEntryId <> "" And Not FileNameExist() Then

            Dim BLL As New TimeOffAttachmentsBLL
            BLL.FileUpload(Me.FormView1.FindControl("AttachmentFileUpload"), CType(Me.FormView1.FindControl("txtAttachmentName"), TextBox).Text, TimeEntryId)
            Response.Redirect(Request.RawUrl)
        End If

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
    Public Sub SetGridViewDataSource(ByVal isReadOnly As Boolean)
        Me.GridView1.DataSourceID = ""

        If isReadOnly = True And Me.Request.QueryString("TimeEntry") Is Nothing And Me.Request.QueryString("TimeOffRequest") Is Nothing Then
            Me.GridView1.DataSourceID = "dsTimeOffAttachmentsReadOnly"
        ElseIf isReadOnly = True And Me.Request.QueryString("TimeOffRequest") IsNot Nothing Then
            Me.GridView1.DataSourceID = "dsTimeOffRequestAttachments"
        Else
            Me.GridView1.DataSourceID = "dsTimeOffAttachmentsGridViewObject"
        End If
        'Me.WG.DataBind()
    End Sub
End Class
