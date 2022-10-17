Imports System.Xml
Imports System.Configuration
Imports DotNetOpenAuth.Messaging
Imports DotNetOpenAuth.OpenId
Imports DotNetOpenAuth.OpenId.Extensions.AttributeExchange
Imports DotNetOpenAuth.OpenId.RelyingParty
''' <summary>
''' This flow enables single sign on (SSO) between this app and the Intuit App Center.
''' This feature offers two key benefits:  First, the user only has to sign in once, 
''' instead of having to sign in to both this app and Intuit App Center.  
''' Second, this app does not need to implement a customized solution for user authentication 
''' because it relies on Intuit's OpenID service.
''' the following occurs during the sign in process:
''' 1.The user initiates the sign in process by going to your app and clicking the Sign in with Intuit button.
''' 2.The Intuit sign in window appears, where the user enters the Intuit user ID (email) and password.
''' 3.this app sends an authentication request to the Intuit OpenID service.
''' 4.This page verifies the authentication response it receives from the Intuit OpenID service and stores
''' user information inside the session object.
''' </summary>
Partial Class QBO_OpenIdHandler
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' OpenId Relying Party
    ''' </summary>
    Private Shared openid As New OpenIdRelyingParty()

    ''' <summary>
    ''' Action Results for Index, uses DotNetOpenAuth for creating OpenId Request with Intuit
    ''' and handling response recieved. 
    ''' </summary>
    ''' <param name="sender">Sender of the event.</param>
    ''' <param name="e">Event Args.</param>
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim openid_identifier = ConfigurationManager.AppSettings("openid_identifier")
        Dim returnUrl = "OpenIdHandler.aspx"
        Dim response__1 = openid.GetResponse()
        If response__1 Is Nothing Then
            ' Stage 2: user submitting Identifier
            Dim id As Identifier
            If Identifier.TryParse(openid_identifier, id) Then
                Try
                    Dim request__2 As IAuthenticationRequest = openid.CreateRequest(openid_identifier)
                    Dim fetch As New FetchRequest()
                    fetch.Attributes.Add(New AttributeRequest(WellKnownAttributes.Contact.Email))
                    fetch.Attributes.Add(New AttributeRequest(WellKnownAttributes.Name.FullName))
                    request__2.AddExtension(fetch)
                    request__2.RedirectToProvider()
                Catch ex As ProtocolException
                    Throw ex
                End Try
            End If
        Else
            If response__1.FriendlyIdentifierForDisplay Is Nothing Then
                Response.Redirect("/OpenIdHandler.aspx")
            End If

            ' Stage 3: OpenID Provider sending assertion response
            Session("FriendlyIdentifier") = response__1.FriendlyIdentifierForDisplay
            Dim fetch As FetchResponse = response__1.GetExtension(Of FetchResponse)()
            If fetch IsNot Nothing Then
                Session("OpenIdResponse") = "True"
                Session("FriendlyEmail") = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email)
                Session("FriendlyName") = fetch.GetAttributeValue(WellKnownAttributes.Name.FullName)

                'get the OAuth Access token for the user from OauthAccessTokenStorage.xml
                'OauthAccessTokenStorageHelper.GetOauthAccessTokenForUser(Session("FriendlyEmail").ToString(), Page)
            End If

            Dim query As String = Request.Url.Query
            If Not String.IsNullOrWhiteSpace(query) AndAlso query.ToLower().Contains("disconnect=true") Then
                Session("accessToken") = "dummyAccessToken"
                Session("accessTokenSecret") = "dummyAccessTokenSecret"
                Session("Flag") = True
                Response.Redirect("CleanupOnDisconnect.aspx")
            End If

            If Not String.IsNullOrEmpty(returnUrl) Then
                Response.Redirect("Default.aspx")
            End If
        End If
    End Sub

End Class
