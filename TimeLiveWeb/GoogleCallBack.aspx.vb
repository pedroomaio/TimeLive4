
Partial Class GoogleCallBack
    Inherits System.Web.UI.Page
    Public sCall As String = "var kk;"
    Public sToken As String = ""
    Public IsSessionAvailable As Boolean = False
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.QueryString("access_token") IsNot Nothing Then
            sCall = "callUserInfor();"
            sToken = Request.QueryString("access_token").ToString()
        End If
        If DBUtilities.IsApplicationContext Then
            If DBUtilities.GetSessionAccountEmployeeId <> 64 Then
                IsSessionAvailable = True
            End If
        End If
    End Sub
End Class
