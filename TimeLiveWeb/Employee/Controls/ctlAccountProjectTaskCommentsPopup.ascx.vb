
Partial Class Employee_Controls_ctlAccountProjectTaskCommentsPopup
    Inherits System.Web.UI.UserControl
    Dim AccountProjectTaskId As Integer
    Protected Sub FormView2_ItemInserted(sender As Object, e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView2.ItemInserted
        Dim strScript As String = "window.opener.location.href='AccountProjectTaskComments.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "'; window.close();"
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub

    Protected Sub FormView2_ItemInserting(sender As Object, e As System.Web.UI.WebControls.FormViewInsertEventArgs) Handles FormView2.ItemInserting
        e.Values("CreatedOn") = Now.Date
        e.Values("CreatedByEmployeeId") = DBUtilities.GetSessionAccountEmployeeId
    End Sub

    Protected Sub Upload_Click(sender As Object, e As System.EventArgs)

        AccountProjectTaskId = IIf(Not Request.QueryString("AccountProjectTaskId") Is Nothing, Request.QueryString("AccountProjectTaskId"), 64)
        Dim BLL As New AccountProjectTaskAttachmentBLL
        Dim FileName = CType(Me.FormView1.FindControl("AttachmentFileUpload"), FileUpload).FileName
        BLL.FileUpload(Me.FormView1.FindControl("AttachmentFileUpload"), AccountProjectTaskId, DBUtilities.GetSessionAccountId, CType(Me.FormView1.FindControl("AttachmentNameTextBox"), TextBox).Text)
        Dim strScript As String = "window.opener.location.href='AccountProjectTaskComments.aspx?AccountProjectTaskId=" & Me.Request.QueryString("AccountProjectTaskId") & "'; window.close();"
        If (Not Me.Page.ClientScript.IsClientScriptBlockRegistered("clientScript")) Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Me.Request.QueryString("Source") = "Attachment" Then
            Me.FormView2.Visible = False
        Else
            Me.FormView1.Visible = False
        End If
    End Sub

    Protected Sub FormView2_ItemUpdating(sender As Object, e As System.Web.UI.WebControls.FormViewUpdateEventArgs) Handles FormView2.ItemUpdating
        e.NewValues("CreatedOn") = Now.Date
        e.NewValues("CreatedByEmployeeId") = DBUtilities.GetSessionAccountEmployeeId
    End Sub
End Class
