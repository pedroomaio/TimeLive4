Imports System.Configuration
Imports System.Globalization
Imports System.Web
Imports DevDefined.OAuth.Consumer
Imports DevDefined.OAuth.Framework
''' <summary>
''' This flow is invoked when the the user selects a QuickBooks company and then clicks Authorize to 
''' grant this app access to that company's data. 
''' Behind the scenes, this app exchanges tokens with the Intuit OAuth service and then 
''' stores the authorized access token in a session store. (use persistent store such as a database in real time scenarios.)  
''' A valid access token indicates that the user has connected your app to a specific company.  
''' (Connections are important because Intuit charges you according to how many active connections 
''' users have made with your app.)  Later, when your app calls Data Services for QuickBooks, 
''' it fetches the access token from the persistent store and includes the token in the 
''' HTTP request header.  
''' </summary>
Partial Class QBO_OauthHandler
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' OAuthVerifyer, RealmId, DataSource
    ''' </summary>
    Private _oauthVerifyer As [String], _realmid As [String], _dataSource As [String]

    ''' <summary>
    ''' Action Results for Index, OAuthToken, OAuthVerifyer and RealmID is recieved as part of Response
    ''' and are stored inside Session object for future references
    ''' NOTE: Session storage is only used for demonstration purpose only.
    ''' </summary>
    ''' <param name="sender">Sender of the event.</param>
    ''' <param name="e">Event Args.</param>
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.QueryString.HasKeys() Then
            ' This value is used to Get Access Token.
            _oauthVerifyer = Request.QueryString("oauth_verifier").ToString()

            _realmid = Request.QueryString("realmId").ToString()
            HttpContext.Current.Session("realm") = _realmid

            'If dataSource is QBO call QuickBooks Online Services, else call QuickBooks Desktop Services
            _dataSource = Request.QueryString("dataSource").ToString()
            HttpContext.Current.Session("dataSource") = _dataSource

            getAccessToken()

            'Production applications should securely store the Access Token.
            'In this template, encrypted Oauth access token is persisted in OauthAccessTokenStorage.xml
            'OauthAccessTokenStorageHelper.StoreOauthAccessToken(Page)

            ' This value is used to redirect to Default.aspx from Cleanup page when user clicks on ConnectToInuit widget.
            Session("RedirectToDefault") = True
        Else
            Response.Write("No OAuth token was received")
        End If
    End Sub

    ''' <summary>
    ''' Gets the Access Token
    ''' </summary>
    Private Sub getAccessToken()
        Dim clientSession As IOAuthSession = CreateSession()
        Try
            Dim accessToken As IToken = clientSession.ExchangeRequestTokenForAccessToken(DirectCast(Session("requestToken"), IToken), _oauthVerifyer)
            Session("accessToken") = accessToken.Token

            ' Add flag to session which tells that accessToken is in session
            Session("Flag") = True

            ' Remove the Invalid Access token since we got the new access token
            HttpContext.Current.Session.Remove("InvalidAccessToken")
            Session("accessTokenSecret") = accessToken.TokenSecret
        Catch ex As Exception
            'Handle Exception if token is rejected or exchange of Request Token for Access Token failed. 
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Creates the OAuth Session using Consumer key
    ''' </summary>        
    ''' <returns>OAuth Session.</returns>
    Private Function CreateSession() As IOAuthSession
        Dim consumerContext As New OAuthConsumerContext()
        With consumerContext
            .ConsumerKey = ConfigurationManager.AppSettings("consumerKey").ToString(CultureInfo.InvariantCulture)
            .ConsumerSecret = ConfigurationManager.AppSettings("consumerSecret").ToString(CultureInfo.InvariantCulture)
            .SignatureMethod = SignatureMethod.HmacSha1
        End With
        Return New OAuthSession(consumerContext, Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken, Constants.OauthEndPoints.IdFedOAuthBaseUrl, Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken)
    End Function
End Class
