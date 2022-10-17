
Partial Class ProjectAdmin_Controls_ctlAccountProjectAttachmentList
    Inherits System.Web.UI.UserControl
    Dim AccountProjectId As Long
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.AccountProjectId = Me.dsAccountProjectAttachmentObject.SelectParameters("AccountProjectId").DefaultValue
        End If
        If Me.Request.QueryString("AccountAttachmentTypeId") <> 1 Then
            Me.FormView1.Visible = False
            Me.FormView2.Visible = True
            'Dim ScriptManager As System.Web.UI.ScriptManager = Me.FindControlRecursive(Me.Page.Master.Master, "ScriptManager2")
            'ScriptManager.RegisterPostBackControl(Me.FormView1.FindControl("Upload"))
        Else
            Me.FormView1.Visible = False
            Me.FormView2.Visible = True
        End If
        Me.GetAccountProjectIdAndProjectName()
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
    Public Function GetAccountProjectIdAndProjectName() As Boolean
        AccountProjectId = Me.Request.QueryString("AccountProjectId")
        Dim dtProject As TimeLiveDataSet.AccountProjectDataTable = New AccountProjectBLL().GetAccountProjectsByAccountProjectId(AccountProjectId)
        Dim drProject As TimeLiveDataSet.AccountProjectRow

        If dtProject.Rows.Count > 0 Then
            drProject = dtProject.Rows(0)
            CType(Me.FormView2.FindControl("txtProjectId"), TextBox).Text = drProject.AccountProjectId
            CType(Me.FormView2.FindControl("txtProjectName"), TextBox).Text = drProject.ProjectName
            'CType(Me.FormView2.FindControl("txtTaskName"), TextBox).Text = drProject.TaskName
        End If
    End Function

    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        AccountProjectId = IIf(Not Request.QueryString("AccountProjectId") Is Nothing, Request.QueryString("AccountProjectId"), 64)
        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)

        If e.CommandName = "Delete" Then
            Dim objRow As GridViewRow = Me.GridView1.Rows(e.CommandArgument)
            Dim strFileName As String = strRoot & DBUtilities.GetSessionAccountId & "\" & AccountProjectId & "\" & CType(objRow.FindControl("FileHyperlink"), HyperLink).Text

            If System.IO.File.Exists(strFileName) Then
                ' Try
                System.IO.File.Delete(strFileName)
                'Catch ex As Exception
                ' R 'esponse.Write(ex.Message)
                'End Try
            End If
        End If
    End Sub

    Protected Sub GridView1_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Retrieve the LinkButton control from the first column.
            Dim Delete As LinkButton = CType(e.Row.Cells(8).Controls(1), LinkButton)
            ' '' '' Set the LinkButton's CommandArgument property with the
            ' '' '' row's index.
            Delete.CommandArgument = e.Row.RowIndex.ToString()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        UIUtilities.ClearCellsForNoRecords(e.Row)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim objDropdownTax2 As LinkButton
            objDropdownTax2 = CType(e.Row.Cells(8).FindControl("LinkButton1"), LinkButton)
            objDropdownTax2.PostBackUrl = "~/ProjectAdmin/AccountProjectAttachmentsPopUp.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&AccountAttachmentTypeId=" & Me.Request.QueryString("AccountAttachmentTypeId")

        End If
    End Sub

    Protected Sub FormView1_DataBound(sender As Object, e As System.EventArgs) Handles FormView1.DataBound

    End Sub

    Protected Sub FormView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.FormViewPageEventArgs) Handles FormView1.PageIndexChanging

    End Sub

    Protected Sub GridView1_RowDeleted(sender As Object, e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        ' Me.GridView1.DataBind()
        ''Response.Redirect("~/ProjectAdmin/AccountProjectAttachmentPopUp.aspx?AccountProjectId=" & Me.Request.QueryString("AccountProjectId") & "&AccountAttachmentTypeId=" & Me.Request.QueryString("AccountAttachmentTypeId"), False)
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'Dim ProjectAttachmentBLL As New AccountProjectAttachmentBLL
        'e.Values("AccountProjectAttachmentId") = ProjectAttachmentBLL.DeleteAccountProjectAttachment(Me.GridView1.DataKeys("0").Value)
    End Sub

    Protected Sub dsAccountProjectAttachmentObject_Deleted(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles dsAccountProjectAttachmentObject.Deleted
        ' Me.GridView1.DataBind()
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs)

    End Sub
End Class
