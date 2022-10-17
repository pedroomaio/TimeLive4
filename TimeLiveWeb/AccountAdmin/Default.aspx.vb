''' <summary>
''' Default web form
''' </summary>
''' <remarks></remarks>
Partial Class AccountAdmin_Default
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' Calling page load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Redirecting to "AdminMain.aspx"
        Response.Redirect("AdminMain.aspx", False)
    End Sub
End Class
