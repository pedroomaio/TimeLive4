Imports System.Data
Imports System.Data.SqlClient
Partial Class WebReport_Reports_Controls_ctlExpenseAttachmentReport
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Create the connection and DataAdapter for the Authors table.
        Dim cnn As New SqlConnection(DBUtilities.GetConnectionString)
        Dim cmd1 As New SqlDataAdapter("select * from AccountAttachments where AccountExpenseEntryId = 1407", cnn)
        'Create and fill the DataSet.
        Dim ds As New DataSet()
        cmd1.Fill(ds, "AccountAttachments")
        'Bind the Authors table to the parent Repeater control, and call DataBind.
        ExpenseAttachmentRepeater.DataSource = ds.Tables("AccountAttachments")
        ExpenseAttachmentRepeater.DataBind()
        'Close the connection.
        cnn.Close()
    End Sub

    'Protected Sub ExpenseAttachmentRepeater_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles ExpenseAttachmentRepeater.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
    '        Dim AttachmentLocalPath As String
    '        If IsDBNull(DataBinder.Eval(e.Item.DataItem, "AttachmentLocalPath")) Then
    '            AttachmentLocalPath = ""
    '        Else
    '            AttachmentLocalPath = "/" & DataBinder.Eval(e.Item.DataItem, "AttachmentLocalPath")
    '        End If
    '        Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
    '        Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
    '        Dim strRoot1 As String = "~/Uploads/" & 151 & "/" & DataBinder.Eval(e.Item.DataItem, "AccountExpenseEntryId") & AttachmentLocalPath
    '        'CType(e.Item.FindControl("img1"), System.Web.UI.WebControls.Image).ImageUrl = strRoot1
    '        CType(e.Item.FindControl("img2"), HyperLink).ImageUrl = strRoot1
    '    End If
    'End Sub

    Protected Sub ExpenseAttachmentRepeater_ItemDataBound1(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles ExpenseAttachmentRepeater.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim AttachmentLocalPath As String
            If IsDBNull(DataBinder.Eval(e.Item.DataItem, "AttachmentLocalPath")) Then
                AttachmentLocalPath = ""
            Else
                AttachmentLocalPath = "/" & DataBinder.Eval(e.Item.DataItem, "AttachmentLocalPath")
            End If
            Dim strUploadPath As String = System.Configuration.ConfigurationManager.AppSettings("UploadFilesPath")
            Dim strRoot As String = System.Web.HttpContext.Current.Server.MapPath(strUploadPath)
            Dim strRoot1 As String = "~/Uploads/" & 151 & "/" & DataBinder.Eval(e.Item.DataItem, "AccountExpenseEntryId") & AttachmentLocalPath
            CType(e.Item.FindControl("img1"), System.Web.UI.WebControls.Image).ImageUrl = strRoot1
            'CType(e.Item.FindControl("img2"), HyperLink).ImageUrl = strRoot1
        End If
    End Sub
End Class
