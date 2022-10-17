
Partial Class AccountAdmin_AccountQBoLog
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SetImageUrl()
    End Sub
    Public Sub SetImageUrl()
        If LocaleUtilitiesBLL.IsShowCompanyOwnLogo = True And LocaleUtilitiesBLL.IsLogoFileExistInSessionAccount = True Then
            imgCompanyLogo.ImageUrl = "~/Uploads/" & DBUtilities.GetSessionAccountId & "/Logo/CompanyLogo.gif"
        Else
            imgCompanyLogo.ImageUrl = "~/Images/TopHeader.png"
        End If
    End Sub
End Class
