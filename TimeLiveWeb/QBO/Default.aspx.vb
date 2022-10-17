
Partial Class QBO_Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("show") IsNot Nothing Then
            Dim value As Boolean = Convert.ToBoolean(Session("show"))
            If value Then
                Session.Remove("show")
                'Session.Remove("show")

                'show a message to the user that token is invalid
                Dim message As String = "<SCRIPT LANGUAGE='JavaScript'>alert('This application is no longer authorized to accesss your QuickBooks data. Please reauthorize to enable this functionality.')</SCRIPT>"

                ' show user the Connect to QuickBooks page again
                Response.Write(message)
            End If
        End If

        '#Region "OpenId"

        ' Hide Connect to QuickBooks widget and show Sign in widget
        IntuitInfo.Visible = True
        IntuitSignin.Visible = True
        Me.Master.FindControl("logoutview").Visible = False
        ' If Session has keys
        If HttpContext.Current.Session.Keys.Count > 0 Then
            ' If there is a key OpenIdResponse
            If HttpContext.Current.Session("OpenIdResponse") IsNot Nothing Then
                ' Show the Sign in widget and disable the Connect to QuickBooks widget
                IntuitSignin.Visible = True
                IntuitInfo.Visible = True
                Me.Master.FindControl("logoutview").Visible = True
            End If

            ' Sow information of the user if the keys are in the session
            If Session("FriendlyIdentifier") IsNot Nothing Then
                friendlyIdentifier.Text = Session("friendlyIdentifier").ToString()
            End If
            If Session("FriendlyName") IsNot Nothing Then
                friendlyName.Text = Session("FriendlyName").ToString()
            Else
                friendlyName.Text = "User Didnt Login Via OpenID, look them up in your system"
            End If

            If Session("FriendlyEmail") IsNot Nothing Then
                friendlyEmail.Text = Session("FriendlyEmail").ToString()
            Else
                friendlyEmail.Text = "User Didnt Login Via OpenID, look them up in your system"
            End If
        End If
        '#End Region

        '#Region "oAuth"

        ' If session has accesstoken and InvalidAccessToken is null
        If HttpContext.Current.Session("accessToken") IsNot Nothing AndAlso HttpContext.Current.Session("InvalidAccessToken") Is Nothing Then
            ' Show oAuthinfo(contains Get Customers QuickBooks List) and disable Connect to QuickBooks widget
            oAuthinfo.Visible = True
            connectToIntuitDiv.Visible = True
        End If

        '#End Region
    End Sub
End Class
