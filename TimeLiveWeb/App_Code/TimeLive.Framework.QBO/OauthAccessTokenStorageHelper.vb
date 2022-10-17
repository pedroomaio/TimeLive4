Imports Microsoft.VisualBasic
Imports System.Xml
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Configuration
''' <summary>
''' This class stores and fetches OAuth Access token for an user from XML file. In real world it could be database or any other suitable storage.
''' </summary>
Public Class OauthAccessTokenStorageHelper
    Private Sub New()
    End Sub
    ''' <summary>
    ''' Remove oauth access toekn from storage 
    ''' </summary>
    Public Shared Sub RemoveInvalidOauthAccessToken(emailID As String, page As Page)
        Dim path As String = page.Server.MapPath("~\QBO") & "OauthAccessTokenStorage.xml"
        Dim searchUserXpath As String = "//record[@usermailid='" & emailID & "']"
        Dim doc As New XmlDocument()
        doc.Load(path)
        Dim record As XmlNode = doc.SelectSingleNode(searchUserXpath)
        If record IsNot Nothing Then
            doc.DocumentElement.RemoveChild(record)
            doc.Save(path)
        End If

        'Rermove it from session
        page.Session.Remove("realm")
        page.Session.Remove("dataSource")
        page.Session.Remove("accessToken")
        page.Session.Remove("accessTokenSecret")
        page.Session.Remove("Flag")
    End Sub

    ''' <summary>
    ''' get the oauth access token for the user from OauthAccessTokenStorage.xml
    ''' </summary>
    Public Shared Sub GetOauthAccessTokenForUser(emailID As String, page As Page)
        Dim path As String = page.Server.MapPath("~\QBO") & "OauthAccessTokenStorage.xml"
        Dim searchUserXpath As String = "//record[@usermailid='" & emailID & "']"
        Dim doc As New XmlDocument()
        doc.Load(path)
        Dim record As XmlNode = doc.SelectSingleNode(searchUserXpath)
        If record IsNot Nothing Then
            page.Session("realm") = record.Attributes("realmid").Value
            page.Session("dataSource") = record.Attributes("dataSource").Value
            Dim secuirtyKey As String = ConfigurationManager.AppSettings("securityKey")
            page.Session("accessToken") = CryptographyHelper.DecryptData(record.Attributes("encryptedaccesskey").Value, secuirtyKey)
            page.Session("accessTokenSecret") = CryptographyHelper.DecryptData(record.Attributes("encryptedaccesskeysecret").Value, secuirtyKey)

            ' Add flag to session which tells that accessToken is in session
            page.Session("Flag") = True
        End If

    End Sub

    ''' <summary>
    ''' persist the Oauth access token in OauthAccessTokenStorage.xml file
    ''' </summary>
    Public Shared Sub StoreOauthAccessToken(page As Page)
        Dim path As String = page.Server.MapPath("~\QBO") & "OauthAccessTokenStorage.xml"
        Dim doc As New XmlDocument()
        doc.Load(path)
        Dim node As XmlNode = doc.CreateElement("record")
        Dim userMailIdAttribute As XmlAttribute = doc.CreateAttribute("usermailid")
        userMailIdAttribute.Value = page.Session("FriendlyEmail").ToString()
        node.Attributes.Append(userMailIdAttribute)

        Dim accessKeyAttribute As XmlAttribute = doc.CreateAttribute("encryptedaccesskey")
        Dim secuirtyKey As String = ConfigurationManager.AppSettings("securityKey")
        accessKeyAttribute.Value = CryptographyHelper.EncryptData(page.Session("accessToken").ToString(), secuirtyKey)
        node.Attributes.Append(accessKeyAttribute)

        Dim encryptedaccesskeysecretAttribute As XmlAttribute = doc.CreateAttribute("encryptedaccesskeysecret")
        encryptedaccesskeysecretAttribute.Value = CryptographyHelper.EncryptData(page.Session("accessTokenSecret").ToString(), secuirtyKey)
        node.Attributes.Append(encryptedaccesskeysecretAttribute)

        Dim realmIdAttribute As XmlAttribute = doc.CreateAttribute("realmid")
        realmIdAttribute.Value = page.Session("realm").ToString()
        node.Attributes.Append(realmIdAttribute)

        Dim dataSourceAttribute As XmlAttribute = doc.CreateAttribute("dataSource")
        dataSourceAttribute.Value = page.Session("dataSource").ToString()
        node.Attributes.Append(dataSourceAttribute)

        doc.DocumentElement.AppendChild(node)
        doc.Save(path)
    End Sub

End Class
