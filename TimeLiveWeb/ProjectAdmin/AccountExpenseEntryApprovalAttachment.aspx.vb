
Partial Class ProjectAdmin_AccountExpenseEntryApprovalAttachment
    Inherits System.Web.UI.Page
    Dim AccountExpenseEntryId As Integer
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        AccountExpenseEntryId = Me.Request.QueryString("AccountExpenseEntryId")
        AccountExpenseEntryId = IIf(Not Request.QueryString("AccountExpenseEntryId") Is Nothing, Request.QueryString("AccountExpenseEntryId"), 64)
        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)

        If e.CommandName = "Delete" Then
            Dim objRow As GridViewRow = Me.GridView1.Rows(e.CommandArgument)
            Dim strFileName As String = strRoot & DBUtilities.GetSessionAccountId & "\" & AccountExpenseEntryId & "\" & CType(objRow.FindControl("FileHyperlink"), HyperLink).Text

            If System.IO.File.Exists(strFileName) Then
                ' Try
                System.IO.File.Delete(strFileName)
                'Catch ex As Exception
                ' R 'esponse.Write(ex.Message)
                'End Try
            End If
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
    End Sub
End Class
