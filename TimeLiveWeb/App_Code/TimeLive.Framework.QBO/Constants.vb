Imports Microsoft.VisualBasic
Imports System.Configuration
''' <summary>
''' Contains Constants.
''' </summary>
Public Class Constants
    ''' <summary>
    ''' OAuth EndPoints.
    ''' </summary>
    Public Class OauthEndPoints
        ''' <summary>
        ''' Url Request Token
        ''' </summary>
        Public Shared UrlRequestToken As String = If(ConfigurationManager.AppSettings("Url_Request_Token") IsNot Nothing, ConfigurationManager.AppSettings("Url_Request_Token").ToString(), "/get_request_token")

        ''' <summary>
        ''' Url Access Token
        ''' </summary>
        Public Shared UrlAccessToken As String = If(ConfigurationManager.AppSettings("Url_Access_Token") IsNot Nothing, ConfigurationManager.AppSettings("Url_Access_Token").ToString(), "/get_access_token")

        ''' <summary>
        ''' Federation base url.
        ''' </summary>
        Public Shared IdFedOAuthBaseUrl As String = If(ConfigurationManager.AppSettings("Intuit_OAuth_BaseUrl") IsNot Nothing, ConfigurationManager.AppSettings("Intuit_OAuth_BaseUrl").ToString(), "https://oauth.intuit.com/oauth/v1")

        ''' <summary>
        ''' Authorize url.
        ''' </summary>
        Public Shared AuthorizeUrl As String = If(ConfigurationManager.AppSettings("Intuit_Workplace_AuthorizeUrl") IsNot Nothing, ConfigurationManager.AppSettings("Intuit_Workplace_AuthorizeUrl").ToString(), "https://workplace.intuit.com/Connect/Begin")
    End Class

    ''' <summary>
    ''' PlatformApiEndpoints
    ''' </summary>
    Public Class PlatformApiEndpoints
        ''' <summary>
        ''' BlueDot Menu Url.
        ''' </summary>
        Public Shared BlueDotAppMenuUrl As String = If(ConfigurationManager.AppSettings("BlueDot_AppMenuUrl") IsNot Nothing, ConfigurationManager.AppSettings("BlueDot_AppMenuUrl").ToString(), "https://workplace.intuit.com/api/v1/Account/AppMenu")

        ''' <summary>
        ''' Disconnect url.
        ''' </summary>
        Public Shared DisconnectUrl As String = If(ConfigurationManager.AppSettings("DisconnectUrl") IsNot Nothing, ConfigurationManager.AppSettings("DisconnectUrl").ToString(), "https://appcenter.intuit.com/api/v1/Connection/Disconnect")
    End Class
End Class
