Imports System.Configuration
Imports System.Web
Imports DevDefined.OAuth.Consumer
Imports DevDefined.OAuth.Framework
''' <summary>
''' An existing Customer when clicks Connect to QuickBooks button, this controller will initiate Autorization flow.
''' 
''' </summary>
Partial Class QBO_OauthGrant
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' CosumerSecret, ConsumerKey, OAuthLink, RequestToken, TokenSecret, OAuthCallbackUrl
    ''' </summary>
    Private consumerSecret As [String], consumerKey As [String], oauthLink As [String], RequestToken As [String], TokenSecret As [String], oauth_callback_url As [String]

    ''' <summary>
    ''' Action Result for Index, This flow will create OAuthConsumer Context using Consumer key and Consuler Secret key
    ''' obtained when Application is added at intuit workspace. It creates OAuth Session out of OAuthConsumer and Calls 
    ''' Intuit Workpsace endpoint for OAuth.
    ''' </summary>
    ''' <param name="sender">Sender of the event.</param>
    ''' <param name="e">Event Args.</param>
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        oauth_callback_url = ConfigurationManager.AppSettings("SitePrefix") + ConfigurationManager.AppSettings("oauth_callback_url")
        consumerKey = ConfigurationManager.AppSettings("consumerKey")
        consumerSecret = ConfigurationManager.AppSettings("consumerSecret")
        oauthLink = Constants.OauthEndPoints.IdFedOAuthBaseUrl
        Dim token As IToken = DirectCast(HttpContext.Current.Session("requestToken"), IToken)
        Dim session As IOAuthSession = CreateSession()
        Dim requestToken__1 As IToken = session.GetRequestToken()
        HttpContext.Current.Session("requestToken") = requestToken__1
        RequestToken = requestToken__1.Token
        TokenSecret = requestToken__1.TokenSecret
        oauthLink = Constants.OauthEndPoints.AuthorizeUrl + "?oauth_token=" & RequestToken & "&oauth_callback=" & UriUtility.UrlEncode(oauth_callback_url)
        Response.Redirect(oauthLink)
    End Sub

    ''' <summary>
    ''' Creates Session
    ''' </summary>
    ''' <returns>Returns OAuth Session</returns>
    Protected Function CreateSession() As IOAuthSession
        Dim consumerContext As New OAuthConsumerContext()
        With consumerContext
            .ConsumerKey = consumerKey
            .ConsumerSecret = consumerSecret
            .SignatureMethod = SignatureMethod.HmacSha1
        End With
        Return New OAuthSession(consumerContext, Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken, oauthLink, Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken)
    End Function

End Class
